namespace smpc_dispatching.UI.Shared.RedBox
{
    partial class RedBoxUC
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        // Narrow (~300px) layout, mounted directly inside MainLayout's permanent
        // right-side red panel (innerContainer.Panel2). Structure: title bar, a slim
        // refresh/status strip, then RELEASE (top, more room) and INCOMING (bottom)
        // stacked sections - same skeleton as smpc_sales_system's RedBox control.
        private void InitializeComponent()
        {
            this.pnl_root = new System.Windows.Forms.Panel();
            this.pnl_body = new System.Windows.Forms.Panel();
            this.pnl_incoming_section = new System.Windows.Forms.Panel();
            this.pnl_incoming = new System.Windows.Forms.FlowLayoutPanel();
            this.lbl_incoming_header = new System.Windows.Forms.Label();
            this.pnl_release_section = new System.Windows.Forms.Panel();
            this.pnl_release = new System.Windows.Forms.FlowLayoutPanel();
            this.lbl_release_header = new System.Windows.Forms.Label();
            this.pnl_top = new System.Windows.Forms.Panel();
            this.lbl_status = new System.Windows.Forms.Label();
            this.btn_refresh = new System.Windows.Forms.Button();
            this.lbl_title = new System.Windows.Forms.Label();
            this.pnl_root.SuspendLayout();
            this.pnl_body.SuspendLayout();
            this.pnl_incoming_section.SuspendLayout();
            this.pnl_release_section.SuspendLayout();
            this.pnl_top.SuspendLayout();
            this.SuspendLayout();
            //
            // pnl_root
            //
            this.pnl_root.Controls.Add(this.pnl_body);
            this.pnl_root.Controls.Add(this.pnl_top);
            this.pnl_root.Controls.Add(this.lbl_title);
            this.pnl_root.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnl_root.Location = new System.Drawing.Point(0, 0);
            this.pnl_root.Name = "pnl_root";
            this.pnl_root.Size = new System.Drawing.Size(300, 800);
            this.pnl_root.TabIndex = 0;
            //
            // pnl_body
            //
            this.pnl_body.Controls.Add(this.pnl_incoming_section);
            this.pnl_body.Controls.Add(this.pnl_release_section);
            this.pnl_body.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnl_body.Location = new System.Drawing.Point(0, 50);
            this.pnl_body.Name = "pnl_body";
            this.pnl_body.Size = new System.Drawing.Size(300, 750);
            this.pnl_body.TabIndex = 2;
            //
            // pnl_incoming_section
            //
            this.pnl_incoming_section.Controls.Add(this.pnl_incoming);
            this.pnl_incoming_section.Controls.Add(this.lbl_incoming_header);
            this.pnl_incoming_section.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnl_incoming_section.Location = new System.Drawing.Point(0, 480);
            this.pnl_incoming_section.Name = "pnl_incoming_section";
            this.pnl_incoming_section.Size = new System.Drawing.Size(300, 270);
            this.pnl_incoming_section.TabIndex = 1;
            //
            // pnl_incoming
            //
            this.pnl_incoming.AutoScroll = true;
            this.pnl_incoming.BackColor = System.Drawing.Color.LightCoral;
            this.pnl_incoming.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnl_incoming.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.pnl_incoming.Location = new System.Drawing.Point(0, 22);
            this.pnl_incoming.Name = "pnl_incoming";
            this.pnl_incoming.Size = new System.Drawing.Size(300, 248);
            this.pnl_incoming.TabIndex = 1;
            this.pnl_incoming.WrapContents = false;
            //
            // lbl_incoming_header
            //
            this.lbl_incoming_header.BackColor = System.Drawing.Color.IndianRed;
            this.lbl_incoming_header.Dock = System.Windows.Forms.DockStyle.Top;
            this.lbl_incoming_header.Font = new System.Drawing.Font("Segoe UI", 8.5F, System.Drawing.FontStyle.Bold);
            this.lbl_incoming_header.ForeColor = System.Drawing.Color.Black;
            this.lbl_incoming_header.Location = new System.Drawing.Point(0, 0);
            this.lbl_incoming_header.Name = "lbl_incoming_header";
            this.lbl_incoming_header.Padding = new System.Windows.Forms.Padding(6, 0, 0, 0);
            this.lbl_incoming_header.Size = new System.Drawing.Size(300, 22);
            this.lbl_incoming_header.TabIndex = 0;
            this.lbl_incoming_header.Text = "INCOMING";
            this.lbl_incoming_header.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            //
            // pnl_release_section
            //
            this.pnl_release_section.Controls.Add(this.pnl_release);
            this.pnl_release_section.Controls.Add(this.lbl_release_header);
            this.pnl_release_section.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnl_release_section.Location = new System.Drawing.Point(0, 0);
            this.pnl_release_section.Name = "pnl_release_section";
            this.pnl_release_section.Size = new System.Drawing.Size(300, 480);
            this.pnl_release_section.TabIndex = 0;
            //
            // pnl_release
            //
            this.pnl_release.AutoScroll = true;
            this.pnl_release.BackColor = System.Drawing.Color.LightCoral;
            this.pnl_release.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnl_release.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.pnl_release.Location = new System.Drawing.Point(0, 22);
            this.pnl_release.Name = "pnl_release";
            this.pnl_release.Size = new System.Drawing.Size(300, 458);
            this.pnl_release.TabIndex = 1;
            this.pnl_release.WrapContents = false;
            //
            // lbl_release_header
            //
            this.lbl_release_header.BackColor = System.Drawing.Color.IndianRed;
            this.lbl_release_header.Dock = System.Windows.Forms.DockStyle.Top;
            this.lbl_release_header.Font = new System.Drawing.Font("Segoe UI", 8.5F, System.Drawing.FontStyle.Bold);
            this.lbl_release_header.ForeColor = System.Drawing.Color.Black;
            this.lbl_release_header.Location = new System.Drawing.Point(0, 0);
            this.lbl_release_header.Name = "lbl_release_header";
            this.lbl_release_header.Padding = new System.Windows.Forms.Padding(6, 0, 0, 0);
            this.lbl_release_header.Size = new System.Drawing.Size(300, 22);
            this.lbl_release_header.TabIndex = 0;
            this.lbl_release_header.Text = "RELEASE";
            this.lbl_release_header.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            //
            // pnl_top
            //
            this.pnl_top.Controls.Add(this.lbl_status);
            this.pnl_top.Controls.Add(this.btn_refresh);
            this.pnl_top.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnl_top.Location = new System.Drawing.Point(0, 26);
            this.pnl_top.Name = "pnl_top";
            this.pnl_top.Size = new System.Drawing.Size(300, 24);
            this.pnl_top.TabIndex = 1;
            //
            // lbl_status
            //
            this.lbl_status.AutoSize = true;
            this.lbl_status.Font = new System.Drawing.Font("Segoe UI", 7F);
            this.lbl_status.ForeColor = System.Drawing.Color.DimGray;
            this.lbl_status.Location = new System.Drawing.Point(4, 6);
            this.lbl_status.Name = "lbl_status";
            this.lbl_status.Size = new System.Drawing.Size(0, 12);
            this.lbl_status.TabIndex = 1;
            //
            // btn_refresh
            //
            this.btn_refresh.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_refresh.Font = new System.Drawing.Font("Segoe UI", 7F);
            this.btn_refresh.Location = new System.Drawing.Point(230, 1);
            this.btn_refresh.Name = "btn_refresh";
            this.btn_refresh.Size = new System.Drawing.Size(65, 21);
            this.btn_refresh.TabIndex = 0;
            this.btn_refresh.Text = "Refresh";
            this.btn_refresh.UseVisualStyleBackColor = true;
            this.btn_refresh.Click += new System.EventHandler(this.btn_refresh_Click);
            //
            // lbl_title
            //
            this.lbl_title.BackColor = System.Drawing.Color.Transparent;
            this.lbl_title.Dock = System.Windows.Forms.DockStyle.Top;
            this.lbl_title.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.lbl_title.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(150)))), ((int)(((byte)(20)))), ((int)(((byte)(20)))));
            this.lbl_title.Location = new System.Drawing.Point(0, 0);
            this.lbl_title.Name = "lbl_title";
            this.lbl_title.Padding = new System.Windows.Forms.Padding(6, 4, 0, 0);
            this.lbl_title.Size = new System.Drawing.Size(300, 26);
            this.lbl_title.TabIndex = 0;
            this.lbl_title.Text = "RED BOX";
            //
            // RedBoxUC
            //
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.pnl_root);
            this.Name = "RedBoxUC";
            this.Size = new System.Drawing.Size(300, 800);
            this.Load += new System.EventHandler(this.RedBoxUC_Load);
            this.pnl_root.ResumeLayout(false);
            this.pnl_body.ResumeLayout(false);
            this.pnl_incoming_section.ResumeLayout(false);
            this.pnl_release_section.ResumeLayout(false);
            this.pnl_top.ResumeLayout(false);
            this.pnl_top.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnl_root;
        private System.Windows.Forms.Label lbl_title;
        private System.Windows.Forms.Panel pnl_top;
        private System.Windows.Forms.Label lbl_status;
        private System.Windows.Forms.Button btn_refresh;
        private System.Windows.Forms.Panel pnl_body;
        private System.Windows.Forms.Panel pnl_release_section;
        private System.Windows.Forms.Label lbl_release_header;
        private System.Windows.Forms.FlowLayoutPanel pnl_release;
        private System.Windows.Forms.Panel pnl_incoming_section;
        private System.Windows.Forms.Label lbl_incoming_header;
        private System.Windows.Forms.FlowLayoutPanel pnl_incoming;
    }
}
