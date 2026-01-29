using smpc_dispatching.Core.Interfaces;
using System;
using System.Windows.Forms;

namespace smpc_dispatching.Core.Services
{
    public class NavigationService : INavigationService
    {
        private readonly IRouteService _routesService;
        private TreeView _treeView;
        private Control _container;

        public NavigationService(IRouteService routeService)
        {
            _routesService = routeService;
        }

        public void Initialize(TreeView treeView, Control container)
        {
            _treeView = treeView;
            _container = container;

            BuildNavigation();
        }

        public bool HasAccess() => true;

        public void BuildNavigation()
        {
            _treeView.Nodes.Clear();

            foreach (var parent in _routesService.GetParents())
            {
                if (string.IsNullOrEmpty(parent))
                {
                    foreach (var child in _routesService.GetChildren(null))
                    {
                        if (!HasAccess()) continue;
                        var childNode = new TreeNode(child.Title) { Tag = child.Code };
                        _treeView.Nodes.Add(childNode);
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
                    }
                }

                _treeView.Nodes.Add(parentNode);
            }

            _treeView.ExpandAll();

            // Avoid duplicate event subscriptions
            _treeView.AfterSelect -= TreeView_AfterSelect;
            _treeView.AfterSelect += TreeView_AfterSelect;
        }

        private void TreeView_AfterSelect(object sender, TreeViewEventArgs e)
        {
            if (e.Node?.Tag == null) return;

            string code = e.Node.Tag.ToString();
            var title = _routesService.GetTitle(code);

            // Select the route so dependent controls can access it
            _routesService.SelectRoute(code);

            // Always create a new instance for reloading
            var newView = _routesService.GetForm(code);
            if (newView == null)
            {
                MessageBox.Show($"No view found for route '{code}'", "Navigation", MessageBoxButtons.OK, MessageBoxIcon.Warning);
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
