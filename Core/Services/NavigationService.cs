

using smpc_dispatching.Core.Interfaces;
using System.Windows.Forms;

namespace smpc_dispatching.Core.Services {
        public class NavigationService : INavigationService {


        private readonly IRouteService _routesService;
        private  TreeView _treeView;
        private  Panel _contentPanel;
 

        public NavigationService( IRouteService routeService) {
            _routesService = routeService;
        }


        public void Initialize(TreeView treeView, Panel contentPanel) {
            _treeView = treeView;
            _contentPanel = contentPanel;

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
                TreeNode parentNode = new TreeNode(parent);

                foreach (var child in _routesService.GetChildren(parent)) {

                    if (!HasAccess()) continue;

                    TreeNode childNode = new TreeNode(child.Title) {
                        Tag = child.Code
                    };
                    parentNode.Nodes.Add(childNode);
                }

                _treeView.Nodes.Add(parentNode);
            }

            _treeView.ExpandAll();

            // Hook up event (so MainForm doesn’t need it)
            _treeView.AfterSelect -= TreeView_AfterSelect; // avoid duplicates
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
                _contentPanel.Controls.Clear();
                view.Dock = DockStyle.Fill;
                _contentPanel.Controls.Add(view);
                //_titleLabel.Text = title;
            } else {
                MessageBox.Show($"No view found for route '{code}'", "Navigation", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }


    }
}
