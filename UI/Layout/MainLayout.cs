using smpc_dispatching.Core.Interfaces;
using System;
using System.Windows.Forms;

namespace smpc_dispatching.UI.Layout {
    public partial class MainLayout : Form {

        private readonly INavigationService _navigationService;
        private readonly IRouteService _routeService;
        public MainLayout(INavigationService navigationService, IRouteService routeService, IServiceProvider serviceProvider) {
            _navigationService = navigationService;
            InitializeComponent();
            _routeService = routeService;
        }

        private void MainLayout_Load(object sender, EventArgs e) {
            SetupnavigationBar();
        }



        private void SetupnavigationBar() {
            navbarTreeView.BeginUpdate();
            navbarTreeView.Nodes.Clear();
            _navigationService.Initialize(navbarTreeView, innerContainer.Panel1);

            navbarTreeView.ExpandAll();
            navbarTreeView.EndUpdate();
        }

        private void navbarTreeView_AfterSelect(object sender, TreeViewEventArgs e) {
            if (e.Node?.Tag == null)
                return;

            string code = e.Node.Tag.ToString();
            _routeService.SelectRoute(code);

            var title = _routeService.GetTitle();
            var form = _routeService.GetForm();
            ShowForm(title, form);


        }

        private void ShowForm(string title, Control form) {
            innerContainer.Panel1.Controls.Clear();


            if (form != null) {
                //form.Dock = DockStyle.Top;
                innerContainer.Panel1.Controls.Add(form);
            } else {
                MessageBox.Show("No form found for this route.", "Navigation", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
    }
}
