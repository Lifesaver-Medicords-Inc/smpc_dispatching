using Microsoft.Extensions.DependencyInjection;
using smpc_dispatching.Core.Enum;
using smpc_dispatching.Core.Interfaces;
using smpc_dispatching.UI.Shared.RedBox;
using System;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace smpc_dispatching.UI.Layout {
    public partial class MainLayout : Form {

        private readonly INavigationService _navigationService;
        private readonly IServiceProvider _serviceProvider;
        public MainLayout(INavigationService navigationService, IServiceProvider serviceProvider) {
            _navigationService = navigationService;
            _serviceProvider = serviceProvider;
            InitializeComponent();

            innerContainer.Panel1.Resize += (s, e) => RecalculateContentWidth();
            // Phase 4.6 (UI uniformity): set the initial capped/centered width before
            // the form is ever shown - the Resize event alone would leave panel1 at its
            // Designer-time placeholder size for one frame on startup.
            RecalculateContentWidth();
        }

        // Phase 4.6 (UI uniformity): the main content area (panel1, the bordered
        // TabControl wrapper inside innerContainer.Panel1) caps at 1280px and stays
        // centered on wide/ultrawide monitors. RedBox (innerContainer.Panel2, fixed
        // width via FixedPanel=Panel2) is left uncapped on purpose - it's persistent
        // utility chrome, not the "page" being viewed.
        //
        // Unlike the tab-based apps whose pages hardcode their own size,
        // NavigationService.TreeView_AfterSelect already force-Dock=Fills every page it
        // adds, same as smpc_admin - so there's no independent "page's own natural
        // width" to preserve here, and no scroll-below-that-width handling is needed.
        private const int MaxContentWidth = 1280;

        // Live crash found in smpc_sales_system: a Resize event can fire mid-
        // InitializeComponent() - e.g. the moment a panel is docked into its own
        // parent - which is *before* every field a handler touches is necessarily
        // assigned yet, regardless of how early each one's own "new" line appears in
        // the Designer file. Guard against null rather than relying on
        // Designer/construction order to save us.
        private void RecalculateContentWidth()
        {
            if (innerContainer == null || panel1 == null) return;

            try
            {
                int availableWidth = innerContainer.Panel1.ClientSize.Width;
                int cappedWidth = Math.Min(MaxContentWidth, availableWidth);

                panel1.Width = cappedWidth;
                panel1.Height = innerContainer.Panel1.ClientSize.Height;
                panel1.Left = (availableWidth - cappedWidth) / 2;
                panel1.Top = 0;
            } catch (Exception) {
                // Cosmetic only - never let a sizing quirk take the app down. Same
                // defense-in-depth added everywhere else after a live crash in
                // smpc_inventory_app's equivalent method (a different WinForms
                // internal-timing quirk than the null case above).
            }
        }

        private void MainLayout_Load(object sender, EventArgs e) {
            SetupnavigationBar();

            TabControl.DrawMode = TabDrawMode.OwnerDrawFixed;
            TabControl.DrawItem += TabControl_DrawItem;
            TabControl.MouseDown += TabControl_MouseDown;
            statusStrip1.Dock = DockStyle.Bottom;

            StatusStrip();
            SetupRedBox();


        }

        // Mounts the warehouse RED BOX dashboard into the permanent right-side red
        // panel (previously just an empty colored placeholder). Resolved via DI like
        // the other UserControls in this app, rather than instantiated directly, so it
        // gets its constructor-injected services. Login has already completed by the
        // time MainLayout loads (see Program.cs: LoginForm resolves MainLayout only
        // after a successful login), so RedBoxUC can safely load data from its own
        // Load event with no extra "wait for login" handshake needed.
        private void SetupRedBox() {
            var redBox = _serviceProvider.GetRequiredService<RedBoxUC>();
            redBox.Dock = DockStyle.Fill;
            innerContainer.Panel2.Controls.Clear();
            innerContainer.Panel2.Controls.Add(redBox);
        }
        // LOAD TREE VIEW
        private void SetupnavigationBar() {
            navbarTreeView.BeginUpdate();
            navbarTreeView.Nodes.Clear();
            _navigationService.Initialize(navbarTreeView, TabControl);

            navbarTreeView.ExpandAll();
            navbarTreeView.EndUpdate();
        }
        // LOAD TABS
        private void TabControl_DrawItem(object sender, DrawItemEventArgs e) {
            var tabControl = sender as TabControl;
            if (tabControl == null) return;

            var tabPage = tabControl.TabPages[e.Index];
            var tabRect = tabControl.GetTabRect(e.Index);

            // Draw background
            e.Graphics.FillRectangle(SystemBrushes.Control, tabRect);

            // Draw tab title
            string title = tabPage.Text;
            using (var brush = new SolidBrush(Color.Black)) {
                var textRect = new RectangleF(tabRect.X + 8, tabRect.Y + 4, tabRect.Width - 30, tabRect.Height - 4);
                e.Graphics.DrawString(title, e.Font, brush, textRect);
            }


            try {
                string iconsPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Icons");
                string closeIconPath = Path.Combine(iconsPath, "small_close.png");

                if (File.Exists(closeIconPath)) {
                    using (var closeImg = Image.FromFile(closeIconPath)) {

                        int iconSize = 12;
                        int iconX = tabRect.Right - iconSize - 6;
                        int iconY = tabRect.Top + (tabRect.Height - iconSize) / 2;

                        e.Graphics.DrawImage(closeImg, new Rectangle(iconX, iconY, iconSize, iconSize));
                    }
                } else {
                    // Fallback text if PNG not found
                    e.Graphics.DrawString("×", e.Font, Brushes.DarkRed,
                        tabRect.Right - 15, tabRect.Top + 4, StringFormat.GenericDefault);
                }
            } catch {
                // Fallback in case of file error
                e.Graphics.DrawString("×", e.Font, Brushes.DarkRed,
                    tabRect.Right - 15, tabRect.Top + 4, StringFormat.GenericDefault);
            }

            // Ensure focus rectangle is not drawn automatically
            e.DrawFocusRectangle();
        }
        // SELECT NAVIGATION FROM TREEVIEW
        private void TabControl_MouseDown(object sender, MouseEventArgs e) {
            for (int i = 0; i < TabControl.TabPages.Count; i++) {
                var tabRect = TabControl.GetTabRect(i);
                var closeRect = new Rectangle(tabRect.Right - 15, tabRect.Top + 4, 12, 12);

                if (closeRect.Contains(e.Location)) {
                    var result = MessageBox.Show($"Close tab '{TabControl.TabPages[i].Text}'?",
                        "Close Tab", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                    if (result == DialogResult.Yes) {
                        TabControl.TabPages.RemoveAt(i);
                        break;
                    }
                }
            }
        }
        // LOAD STATUS STRIP
        private void StatusStrip()
        {
            lbl_name.Text = CacheData.CurrentUser.first_name + " " + CacheData.CurrentUser.last_name;
            lbl_position.Text = CacheData.CurrentUser.position.name;
            lbl_department.Text = CacheData.CurrentUser.department;
        }
        // CLOSE WINDOW
        private void MainLayout_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }
    }
}

