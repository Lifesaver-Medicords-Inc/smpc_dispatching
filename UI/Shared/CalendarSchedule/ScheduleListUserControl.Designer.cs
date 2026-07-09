namespace smpc_dispatching.UI.Shared.CalendarEvent {
    partial class ScheduleListUserControl {
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
            this.MainSplitContainer = new System.Windows.Forms.SplitContainer();
            this.panel1 = new System.Windows.Forms.Panel();
            this.lbl_view_all = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.lbl_year_caption = new System.Windows.Forms.Label();
            this.cbo_year_filter = new System.Windows.Forms.ComboBox();
            this.lbl_month_caption = new System.Windows.Forms.Label();
            this.cbo_month_filter = new System.Windows.Forms.ComboBox();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.flowLayoutPanel2 = new System.Windows.Forms.FlowLayoutPanel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.label2 = new System.Windows.Forms.Label();
            this.SearchTextBox = new System.Windows.Forms.TextBox();
            this.flp_schedule_items = new System.Windows.Forms.FlowLayoutPanel();
            ((System.ComponentModel.ISupportInitialize)(this.MainSplitContainer)).BeginInit();
            this.MainSplitContainer.Panel1.SuspendLayout();
            this.MainSplitContainer.Panel2.SuspendLayout();
            this.MainSplitContainer.SuspendLayout();
            this.panel1.SuspendLayout();
            this.flowLayoutPanel1.SuspendLayout();
            this.flowLayoutPanel2.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // MainSplitContainer
            // 
            this.MainSplitContainer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.MainSplitContainer.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
            this.MainSplitContainer.Location = new System.Drawing.Point(4, 4);
            this.MainSplitContainer.Name = "MainSplitContainer";
            this.MainSplitContainer.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // MainSplitContainer.Panel1
            // 
            this.MainSplitContainer.Panel1.Controls.Add(this.panel1);
            this.MainSplitContainer.Panel1.Controls.Add(this.flowLayoutPanel1);
            // 
            // MainSplitContainer.Panel2
            // 
            this.MainSplitContainer.Panel2.Controls.Add(this.flp_schedule_items);
            this.MainSplitContainer.Size = new System.Drawing.Size(1247, 600);
            this.MainSplitContainer.SplitterDistance = 76;
            this.MainSplitContainer.TabIndex = 0;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.lbl_view_all);
            this.panel1.Controls.Add(this.cbo_month_filter);
            this.panel1.Controls.Add(this.lbl_month_caption);
            this.panel1.Controls.Add(this.cbo_year_filter);
            this.panel1.Controls.Add(this.lbl_year_caption);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Padding = new System.Windows.Forms.Padding(2, 4, 2, 2);
            this.panel1.Size = new System.Drawing.Size(1247, 30);
            this.panel1.TabIndex = 1;
            // 
            // lbl_view_all
            // 
            this.lbl_view_all.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lbl_view_all.AutoSize = true;
            this.lbl_view_all.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lbl_view_all.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_view_all.ForeColor = System.Drawing.Color.RoyalBlue;
            this.lbl_view_all.Location = new System.Drawing.Point(1180, 6);
            this.lbl_view_all.Name = "lbl_view_all";
            this.lbl_view_all.Size = new System.Drawing.Size(65, 13);
            this.lbl_view_all.TabIndex = 2;
            this.lbl_view_all.Text = "VIEW ALL";
            this.lbl_view_all.Click += new System.EventHandler(this.lbl_view_all_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(5, 4);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(100, 17);
            this.label1.TabIndex = 1;
            this.label1.Text = "SCHEDULES";
            //
            // lbl_year_caption
            //
            this.lbl_year_caption.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lbl_year_caption.AutoSize = true;
            this.lbl_year_caption.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_year_caption.Location = new System.Drawing.Point(735, 8);
            this.lbl_year_caption.Name = "lbl_year_caption";
            this.lbl_year_caption.Size = new System.Drawing.Size(38, 13);
            this.lbl_year_caption.TabIndex = 3;
            this.lbl_year_caption.Text = "YEAR:";
            //
            // cbo_year_filter
            //
            this.cbo_year_filter.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cbo_year_filter.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbo_year_filter.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cbo_year_filter.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbo_year_filter.FormattingEnabled = true;
            this.cbo_year_filter.Location = new System.Drawing.Point(778, 4);
            this.cbo_year_filter.Name = "cbo_year_filter";
            this.cbo_year_filter.Size = new System.Drawing.Size(70, 21);
            this.cbo_year_filter.TabIndex = 4;
            //
            // lbl_month_caption
            //
            this.lbl_month_caption.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lbl_month_caption.AutoSize = true;
            this.lbl_month_caption.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_month_caption.Location = new System.Drawing.Point(858, 8);
            this.lbl_month_caption.Name = "lbl_month_caption";
            this.lbl_month_caption.Size = new System.Drawing.Size(48, 13);
            this.lbl_month_caption.TabIndex = 5;
            this.lbl_month_caption.Text = "MONTH:";
            //
            // cbo_month_filter
            //
            this.cbo_month_filter.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cbo_month_filter.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbo_month_filter.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cbo_month_filter.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbo_month_filter.FormattingEnabled = true;
            this.cbo_month_filter.Location = new System.Drawing.Point(911, 4);
            this.cbo_month_filter.Name = "cbo_month_filter";
            this.cbo_month_filter.Size = new System.Drawing.Size(110, 21);
            this.cbo_month_filter.TabIndex = 6;
            //
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.Controls.Add(this.flowLayoutPanel2);
            this.flowLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(0, 36);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(1247, 40);
            this.flowLayoutPanel1.TabIndex = 0;
            this.flowLayoutPanel1.WrapContents = false;
            // 
            // flowLayoutPanel2
            // 
            this.flowLayoutPanel2.Controls.Add(this.panel2);
            this.flowLayoutPanel2.Controls.Add(this.SearchTextBox);
            this.flowLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.flowLayoutPanel2.Location = new System.Drawing.Point(3, 3);
            this.flowLayoutPanel2.Name = "flowLayoutPanel2";
            this.flowLayoutPanel2.Size = new System.Drawing.Size(510, 34);
            this.flowLayoutPanel2.TabIndex = 0;
            this.flowLayoutPanel2.WrapContents = false;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.label2);
            this.panel2.Location = new System.Drawing.Point(3, 3);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(77, 31);
            this.panel2.TabIndex = 0;
            // 
            // label2
            // 
            this.label2.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(3, 5);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(75, 17);
            this.label2.TabIndex = 0;
            this.label2.Text = "SEARCH:";
            // 
            // SearchTextBox
            // 
            this.SearchTextBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.SearchTextBox.Dock = System.Windows.Forms.DockStyle.Left;
            this.SearchTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.SearchTextBox.Location = new System.Drawing.Point(86, 3);
            this.SearchTextBox.Name = "SearchTextBox";
            this.SearchTextBox.Size = new System.Drawing.Size(410, 26);
            this.SearchTextBox.TabIndex = 1;
            // 
            // flp_schedule_items
            // 
            this.flp_schedule_items.AutoScroll = true;
            this.flp_schedule_items.BackColor = System.Drawing.Color.White;
            this.flp_schedule_items.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flp_schedule_items.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.flp_schedule_items.Location = new System.Drawing.Point(0, 0);
            this.flp_schedule_items.Name = "flp_schedule_items";
            this.flp_schedule_items.Size = new System.Drawing.Size(1247, 520);
            this.flp_schedule_items.TabIndex = 0;
            this.flp_schedule_items.WrapContents = false;
            // 
            // ScheduleListUserControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.MainSplitContainer);
            this.Name = "ScheduleListUserControl";
            this.Padding = new System.Windows.Forms.Padding(4);
            this.Size = new System.Drawing.Size(1255, 608);
            this.MainSplitContainer.Panel1.ResumeLayout(false);
            this.MainSplitContainer.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.MainSplitContainer)).EndInit();
            this.MainSplitContainer.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.flowLayoutPanel1.ResumeLayout(false);
            this.flowLayoutPanel2.ResumeLayout(false);
            this.flowLayoutPanel2.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer MainSplitContainer;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel2;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox SearchTextBox;
        private System.Windows.Forms.Label lbl_view_all;
        private System.Windows.Forms.FlowLayoutPanel flp_schedule_items;
        private System.Windows.Forms.Label lbl_year_caption;
        private System.Windows.Forms.ComboBox cbo_year_filter;
        private System.Windows.Forms.Label lbl_month_caption;
        private System.Windows.Forms.ComboBox cbo_month_filter;
    }
}
