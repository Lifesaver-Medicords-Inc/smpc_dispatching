using smpc_dispatching.Core.Interfaces;
using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace smpc_dispatching.Core.Services
{
    public class NavigationService : INavigationService
    {
        private readonly IRouteService _routesService;
        private readonly IReservationApprovalService _reservationApprovalService;
        private TreeView _treeView;
        private Control _container;

        // Route code from RouteService.RegisterRoutes - matching on this (not the display
        // Title) so the badge keeps working even if "Reservation Approvals" ever gets
        // relabeled. Set once BuildNavigation() creates that node; the badge paints onto
        // whichever node this points at.
        private const string ReservationApprovalRouteCode = "RESERVATION_APPROVAL";
        private TreeNode _reservationApprovalNode;
        private int _pendingReservationCount;

        // Polls GetPendingAsync() in the background so the badge shows up (and clears)
        // without the user having to open Reservation Approvals first. Also refreshed
        // right after BuildNavigation() and after every nav click (see TreeView_AfterSelect)
        // so approving/rejecting something updates the count promptly instead of waiting
        // out the full interval.
        private readonly System.Windows.Forms.Timer _pendingReservationTimer;

        public NavigationService(IRouteService routeService, IReservationApprovalService reservationApprovalService)
        {
            _routesService = routeService;
            _reservationApprovalService = reservationApprovalService;

            _pendingReservationTimer = new System.Windows.Forms.Timer { Interval = 60000 };
            _pendingReservationTimer.Tick += async (s, e) => await RefreshPendingReservationCountAsync();
        }

        public void Initialize(TreeView treeView, Control container)
        {
            _treeView = treeView;
            _container = container;

            BuildNavigation();

            _pendingReservationTimer.Stop();
            _pendingReservationTimer.Start();
            _ = RefreshPendingReservationCountAsync();
        }

        public bool HasAccess() => true;

        public void BuildNavigation()
        {
            _treeView.Nodes.Clear();
            _reservationApprovalNode = null;

            foreach (var parent in _routesService.GetParents())
            {
                if (string.IsNullOrEmpty(parent))
                {
                    foreach (var child in _routesService.GetChildren(null))
                    {
                        if (!HasAccess()) continue;
                        var childNode = new TreeNode(child.Title) { Tag = child.Code };
                        _treeView.Nodes.Add(childNode);

                        if (child.Code == ReservationApprovalRouteCode)
                        {
                            _reservationApprovalNode = childNode;
                        }
                    }
                    continue;
                }

                var parentNode = new TreeNode(parent);
                var children = _routesService.GetChildren(parent);
                if (children != null)
                {
                    foreach (var child in children)
                    {
                        if (!HasAccess()) continue;
                        var childNode = new TreeNode(child.Title) { Tag = child.Code };
                        parentNode.Nodes.Add(childNode);

                        if (child.Code == ReservationApprovalRouteCode)
                        {
                            _reservationApprovalNode = childNode;
                        }
                    }
                }

                _treeView.Nodes.Add(parentNode);
            }

            _treeView.ExpandAll();

            // Avoid duplicate event subscriptions
            _treeView.AfterSelect -= TreeView_AfterSelect;
            _treeView.AfterSelect += TreeView_AfterSelect;

            // OwnerDrawText, not the default mode - DrawNode below still draws every node
            // normally (e.Node.DrawDefault = true) and only adds the badge circle on top,
            // for the one node that needs it.
            _treeView.DrawMode = TreeViewDrawMode.OwnerDrawText;
            _treeView.DrawNode -= TreeView_DrawNode;
            _treeView.DrawNode += TreeView_DrawNode;
        }

        // Paints a small red circle with the pending count over the Reservation Approvals
        // node, right-aligned in the tree - the "someone needs to approve something" flag
        // the sidebar itself asked for, rather than making the user open the screen to find
        // out nothing (or something) is waiting.
        private void TreeView_DrawNode(object sender, DrawTreeNodeEventArgs e)
        {
            e.DrawDefault = true;

            if (e.Node != _reservationApprovalNode || _pendingReservationCount <= 0) return;

            string countText = _pendingReservationCount > 99 ? "99+" : _pendingReservationCount.ToString();

            using (var font = new Font(_treeView.Font.FontFamily, 7.5f, FontStyle.Bold))
            {
                var textSize = e.Graphics.MeasureString(countText, font);
                int diameter = (int)Math.Max(16, textSize.Width + 8);

                int badgeX = _treeView.ClientSize.Width - diameter - 6;
                int badgeY = e.Bounds.Top + (e.Bounds.Height - diameter) / 2;
                var badgeRect = new Rectangle(badgeX, badgeY, diameter, diameter);

                var oldSmoothing = e.Graphics.SmoothingMode;
                e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;

                using (var redBrush = new SolidBrush(Color.FromArgb(220, 53, 69)))
                {
                    e.Graphics.FillEllipse(redBrush, badgeRect);
                }

                using (var format = new StringFormat { Alignment = StringAlignment.Center, LineAlignment = StringAlignment.Center })
                {
                    e.Graphics.DrawString(countText, font, Brushes.White, badgeRect, format);
                }

                e.Graphics.SmoothingMode = oldSmoothing;
            }
        }

        // Silent by design - this runs unattended on a timer, so a transient network hiccup
        // (or a user whose Position lacks RESERVATION_APPROVAL access, which the backend
        // just reports as an unsuccessful response, not an error) should leave the badge as
        // it was rather than popping a dialog. Errs toward "no badge" for anything that
        // isn't a clean successful count.
        private async Task RefreshPendingReservationCountAsync()
        {
            int newCount = 0;
            try
            {
                var response = await _reservationApprovalService.GetPendingAsync();
                if (response != null && response.Success && response.Data != null)
                {
                    newCount = response.Data.Count();
                }
            }
            catch
            {
                newCount = 0;
            }

            if (newCount == _pendingReservationCount) return;
            _pendingReservationCount = newCount;

            if (_treeView != null && !_treeView.IsDisposed)
            {
                _treeView.Invalidate();
            }
        }

        private async void TreeView_AfterSelect(object sender, TreeViewEventArgs e)
        {
            if (e.Node?.Tag == null) return;

            string code = e.Node.Tag.ToString();
            var title = _routesService.GetTitle(code);

            // Select the route so dependent controls can access it
            _routesService.SelectRoute(code);

            // Refresh right away on any nav click too, not just every 60s - most useful
            // right after leaving Reservation Approvals having just approved/rejected
            // something, so the badge doesn't lag behind what the user just did.
            _ = RefreshPendingReservationCountAsync();

            // Always create a new instance for reloading
            var newView = _routesService.GetForm(code);
            if (newView == null)
            {
                MessageBox.Show($"No view found for route '{code}'", "Navigation", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Setup-style routes are dialogs (e.g. SetupModal), not tab content.
            if (newView is Form dialogForm)
            {
                dialogForm.ShowDialog();
                dialogForm.Dispose();
                return;
            }

            if (_container is TabControl tabControl)
            {
                // Give each new tab a unique name (e.g. "Sales Order (2)")
                int duplicateCount = 1;
                string uniqueName = title;

                while (TabExists(tabControl, uniqueName))
                {
                    duplicateCount++;
                    uniqueName = $"{title} ({duplicateCount})";
                }

                // Create new tab and load UserControl
                var newTab = new TabPage(title)
                {
                    Tag = code,
                    Name = uniqueName,
                };

                newView.Dock = DockStyle.Fill;
                newTab.Controls.Add(newView);
                tabControl.TabPages.Add(newTab);
                tabControl.SelectedTab = newTab;
            }
            else if (_container is Panel panel)
            {
                // fallback if using panel layout
                panel.Controls.Clear();
                newView.Dock = DockStyle.Fill;
                panel.Controls.Add(newView);
            }
        }

        private bool TabExists(TabControl tabControl, string title)
        {
            foreach (TabPage tab in tabControl.TabPages)
            {
                if (tab.Text.Equals(title, StringComparison.OrdinalIgnoreCase))
                    return true;
            }
            return false;
        }
    }
}
