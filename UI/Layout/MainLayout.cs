using smpc_dispatching.Core.Interfaces;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace smpc_dispatching.UI.Layout {
    public partial class MainLayout : Form {

        private readonly INavigationService _navigationService;
        public MainLayout(INavigationService navigationService) {
            _navigationService = navigationService;
            InitializeComponent();
        }

        private void MainLayout_Load(object sender, EventArgs e) {
            SetupnavigationBar();
            TabControl.DrawMode = TabDrawMode.OwnerDrawFixed;
            TabControl.DrawItem += MainTabControl_DrawItem;
            TabControl.MouseDown += MainTabControl_MouseDown;
        }

        private void SetupnavigationBar() {
            navbarTreeView.BeginUpdate();
            navbarTreeView.Nodes.Clear();
            _navigationService.Initialize(navbarTreeView, TabControl);

            navbarTreeView.ExpandAll();
            navbarTreeView.EndUpdate();
        }

        private void MainTabControl_DrawItem(object sender, DrawItemEventArgs e) {
            var tabControl = sender as TabControl;
            var tabPage = tabControl.TabPages[e.Index];
            var tabRect = tabControl.GetTabRect(e.Index);

            // Draw background
            e.Graphics.FillRectangle(SystemBrushes.Control, tabRect);

            // Draw tab title
            string title = tabPage.Text;
            using (var brush = new SolidBrush(Color.Black)) {
                var textRect = new RectangleF(tabRect.X + 5, tabRect.Y + 4, tabRect.Width - 30, tabRect.Height - 4);
                e.Graphics.DrawString(title, e.Font, brush, textRect);
            }

            // Draw close (×)
            e.Graphics.DrawString("×", e.Font, Brushes.DarkRed,
                tabRect.Right - 15, tabRect.Top + 4, StringFormat.GenericDefault);
        }

        private void MainTabControl_MouseDown(object sender, MouseEventArgs e) {
            for (int i = 0; i < TabControl.TabPages.Count; i++) {
                var tabRect = TabControl.GetTabRect(i);
                var closeRect = new Rectangle(tabRect.Right - 15, tabRect.Top + 4, 12, 12);

                if (closeRect.Contains(e.Location)) {
                    // Optional: confirm close
                    var result = MessageBox.Show($"Close tab '{TabControl.TabPages[i].Text}'?",
                        "Close Tab", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                    if (result == DialogResult.Yes) {
                        TabControl.TabPages.RemoveAt(i);
                        break;
                    }
                }
            }
        }


    }
}
