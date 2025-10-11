namespace smpc_dispatching.UI.Layout {
    partial class MainLayout {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing) {
            if (disposing && (components != null)) {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent() {
            this.mainContainer = new System.Windows.Forms.SplitContainer();
            this.navbarTreeView = new System.Windows.Forms.TreeView();
            this.innerContainer = new System.Windows.Forms.SplitContainer();
            ((System.ComponentModel.ISupportInitialize)(this.mainContainer)).BeginInit();
            this.mainContainer.Panel1.SuspendLayout();
            this.mainContainer.Panel2.SuspendLayout();
            this.mainContainer.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.innerContainer)).BeginInit();
            this.innerContainer.SuspendLayout();
            this.SuspendLayout();
            // 
            // mainContainer
            // 
            this.mainContainer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.mainContainer.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
            this.mainContainer.Location = new System.Drawing.Point(10, 10);
            this.mainContainer.Name = "mainContainer";
            // 
            // mainContainer.Panel1
            // 
            this.mainContainer.Panel1.Controls.Add(this.navbarTreeView);
            // 
            // mainContainer.Panel2
            // 
            this.mainContainer.Panel2.Controls.Add(this.innerContainer);
            this.mainContainer.Size = new System.Drawing.Size(1208, 822);
            this.mainContainer.SplitterDistance = 207;
            this.mainContainer.TabIndex = 0;
            // 
            // navbarTreeView
            // 
            this.navbarTreeView.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.navbarTreeView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.navbarTreeView.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.navbarTreeView.Location = new System.Drawing.Point(0, 0);
            this.navbarTreeView.Name = "navbarTreeView";
            this.navbarTreeView.Size = new System.Drawing.Size(207, 822);
            this.navbarTreeView.TabIndex = 0;
            this.navbarTreeView.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.navbarTreeView_AfterSelect);
            // 
            // innerContainer
            // 
            this.innerContainer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.innerContainer.FixedPanel = System.Windows.Forms.FixedPanel.Panel2;
            this.innerContainer.Location = new System.Drawing.Point(0, 0);
            this.innerContainer.Name = "innerContainer";
            // 
            // innerContainer.Panel1
            // 
            this.innerContainer.Panel1.AutoScroll = true;
            this.innerContainer.Panel1.BackColor = System.Drawing.SystemColors.Control;
            this.innerContainer.Panel1.Padding = new System.Windows.Forms.Padding(2);
            // 
            // innerContainer.Panel2
            // 
            this.innerContainer.Panel2.AutoScroll = true;
            this.innerContainer.Panel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.innerContainer.Size = new System.Drawing.Size(997, 822);
            this.innerContainer.SplitterDistance = 681;
            this.innerContainer.TabIndex = 0;
            // 
            // MainLayout
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.ClientSize = new System.Drawing.Size(1228, 842);
            this.Controls.Add(this.mainContainer);
            this.Name = "MainLayout";
            this.Padding = new System.Windows.Forms.Padding(10);
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "MainLayout";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.MainLayout_Load);
            this.mainContainer.Panel1.ResumeLayout(false);
            this.mainContainer.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.mainContainer)).EndInit();
            this.mainContainer.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.innerContainer)).EndInit();
            this.innerContainer.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer mainContainer;
        private System.Windows.Forms.SplitContainer innerContainer;
        private System.Windows.Forms.TreeView navbarTreeView;
    }
}