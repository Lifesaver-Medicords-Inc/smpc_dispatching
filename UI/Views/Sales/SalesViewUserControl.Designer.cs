namespace smpc_dispatching.UI.Views.Sales {
    partial class SalesViewUserControl {
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
            this.SalesViewPanel = new System.Windows.Forms.Panel();
            this.SuspendLayout();
            // 
            // SalesViewPanel
            // 
            this.SalesViewPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.SalesViewPanel.Location = new System.Drawing.Point(0, 0);
            this.SalesViewPanel.Name = "SalesViewPanel";
            this.SalesViewPanel.Size = new System.Drawing.Size(1164, 908);
            this.SalesViewPanel.TabIndex = 0;
            // 
            // SalesView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.SalesViewPanel);
            this.Name = "SalesView";
            this.Size = new System.Drawing.Size(1164, 908);
            this.Load += new System.EventHandler(this.SalesView_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel SalesViewPanel;
    }
}
