using smpc_dispatching.Core.Enum;
using smpc_dispatching.Core.Interfaces;
using System;
using System.Drawing;
using System.IO;
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
            TabControl.DrawItem += TabControl_DrawItem;
            TabControl.MouseDown += TabControl_MouseDown;
            statusStrip1.Dock = DockStyle.Bottom;

            StatusStrip();


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

