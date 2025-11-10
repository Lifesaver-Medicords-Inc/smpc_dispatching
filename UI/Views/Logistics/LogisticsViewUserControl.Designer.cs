namespace smpc_dispatching.UI.Views.Logistics {
    partial class LogisticsViewUserControl {
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent() {
            this.LegisticsViewPanel = new System.Windows.Forms.Panel();
            this.SuspendLayout();
            // 
            // LegisticsViewPanel
            // 
            this.LegisticsViewPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.LegisticsViewPanel.Location = new System.Drawing.Point(0, 0);
            this.LegisticsViewPanel.Name = "LegisticsViewPanel";
            this.LegisticsViewPanel.Size = new System.Drawing.Size(363, 319);
            this.LegisticsViewPanel.TabIndex = 0;
            // 
            // LogisticsViewUserControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.LegisticsViewPanel);
            this.Name = "LogisticsViewUserControl";
            this.Size = new System.Drawing.Size(363, 319);
            this.Load += new System.EventHandler(this.LogisticsView_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel LegisticsViewPanel;
    }
}
