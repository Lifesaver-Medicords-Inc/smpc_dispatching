

using smpc_dispatching.Core.Interfaces;
using System.Windows.Forms;

namespace smpc_dispatching.Core.Services {
    public class NavigationService : INavigationService {


        private readonly IRouteService _routesService;
        private TreeView _treeView;
        private Control _container;


        public NavigationService(IRouteService routeService) {
            _routesService = routeService;
        }


        public void Initialize(TreeView treeView, Control container) {
            _treeView = treeView;
            _container = container;

            BuildNavigation();
        }


        public bool HasAccess() {
            return true;
        }


        /// <summary>
        /// Builds the navigation tree dynamically from registered routes.
        /// </summary>
        public void BuildNavigation() {
            _treeView.Nodes.Clear();

            foreach (var parent in _routesService.GetParents()) {
                // If parent is null, children will render at root level
                if (string.IsNullOrEmpty(parent)) {
                    // Render children with no parent
                    foreach (var child in _routesService.GetChildren(null)) {
                        if (!HasAccess()) continue;

                        var childNode = new TreeNode(child.Title) {
                            Tag = child.Code
                        };
                        _treeView.Nodes.Add(childNode);
                    }

                    continue;
                }

                // Normal parent rendering
                var parentNode = new TreeNode(parent);

                // Add child nodes
                var children = _routesService.GetChildren(parent);
                if (children != null) {
                    foreach (var child in children) {
                        if (!HasAccess()) continue;

                        var childNode = new TreeNode(child.Title) {
                            Tag = child.Code
                        };
                        parentNode.Nodes.Add(childNode);
                    }
                }

                _treeView.Nodes.Add(parentNode);
            }

            _treeView.ExpandAll();

            // Hook up event (avoid duplicate subscriptions)
            _treeView.AfterSelect -= TreeView_AfterSelect;
            _treeView.AfterSelect += TreeView_AfterSelect;
        }


        /// <summary>
        /// Handles when a user clicks a navigation item.
        /// </summary>
        private void TreeView_AfterSelect(object sender, TreeViewEventArgs e) {
            if (e.Node.Tag == null)
                return;

            string code = e.Node.Tag.ToString();
            var view = _routesService.GetForm(code);
            var title = _routesService.GetTitle(code);

            if (view != null) {

                if (_container is Panel panel) {
                    panel.Controls.Clear();
                    panel.Controls.Add(view);
                    view.Dock = DockStyle.Fill;
                } else if (_container is TabControl tabControl) {
                    var tab = new TabPage(title);
                    view.Dock = DockStyle.Fill;
                    tab.Controls.Add(view);
                    tabControl.TabPages.Add(tab);
                    tabControl.SelectedTab = tab;
                }
            } else {
                MessageBox.Show($"No view found for route '{code}'", "Navigation", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }


    }
}
