namespace smpc_dispatching.UI.Shared.CalendarEvent {
    partial class ScheduleDetailsUserControl {
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ScheduleDetailsUserControl));
            this.MainSplitContainer = new System.Windows.Forms.SplitContainer();
            this.label1 = new System.Windows.Forms.Label();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.CancelBtn = new System.Windows.Forms.Button();
            this.SaveBtn = new System.Windows.Forms.Button();
            this.flowLayoutPanel3 = new System.Windows.Forms.FlowLayoutPanel();
            this.label2 = new System.Windows.Forms.Label();
            this.dtp_StartDate = new System.Windows.Forms.DateTimePicker();
            this.dtp_EndDate = new System.Windows.Forms.DateTimePicker();
            this.label3 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.btn_add_name = new System.Windows.Forms.Button();
            this.cmb_Category = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txt_Description = new System.Windows.Forms.RichTextBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.PinMapBtn = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.rtxt_location = new System.Windows.Forms.RichTextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.cmb_Vehicle = new System.Windows.Forms.ComboBox();
            this.label7 = new System.Windows.Forms.Label();
            this.rtxt_Notes = new System.Windows.Forms.RichTextBox();
            ((System.ComponentModel.ISupportInitialize)(this.MainSplitContainer)).BeginInit();
            this.MainSplitContainer.Panel1.SuspendLayout();
            this.MainSplitContainer.Panel2.SuspendLayout();
            this.MainSplitContainer.SuspendLayout();
            this.flowLayoutPanel1.SuspendLayout();
            this.flowLayoutPanel3.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel1.SuspendLayout();
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
            this.MainSplitContainer.Panel1.Controls.Add(this.label1);
            // 
            // MainSplitContainer.Panel2
            // 
            this.MainSplitContainer.Panel2.Controls.Add(this.flowLayoutPanel1);
            this.MainSplitContainer.Panel2.Controls.Add(this.flowLayoutPanel3);
            this.MainSplitContainer.Size = new System.Drawing.Size(383, 597);
            this.MainSplitContainer.SplitterDistance = 44;
            this.MainSplitContainer.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(3, 12);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(159, 17);
            this.label1.TabIndex = 0;
            this.label1.Text = "SCHEDULE DETAILS";
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.Controls.Add(this.CancelBtn);
            this.flowLayoutPanel1.Controls.Add(this.SaveBtn);
            this.flowLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(0, 509);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.flowLayoutPanel1.Size = new System.Drawing.Size(383, 40);
            this.flowLayoutPanel1.TabIndex = 1;
            this.flowLayoutPanel1.WrapContents = false;
            // 
            // CancelBtn
            // 
            this.CancelBtn.BackColor = System.Drawing.Color.Salmon;
            this.CancelBtn.FlatAppearance.BorderSize = 0;
            this.CancelBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.CancelBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CancelBtn.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.CancelBtn.Location = new System.Drawing.Point(280, 3);
            this.CancelBtn.Name = "CancelBtn";
            this.CancelBtn.Size = new System.Drawing.Size(100, 25);
            this.CancelBtn.TabIndex = 2;
            this.CancelBtn.Text = "CANCEL";
            this.CancelBtn.UseVisualStyleBackColor = false;
            // 
            // SaveBtn
            // 
            this.SaveBtn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(180)))), ((int)(((byte)(0)))));
            this.SaveBtn.FlatAppearance.BorderSize = 0;
            this.SaveBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.SaveBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.SaveBtn.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.SaveBtn.Location = new System.Drawing.Point(174, 3);
            this.SaveBtn.Name = "SaveBtn";
            this.SaveBtn.Size = new System.Drawing.Size(100, 25);
            this.SaveBtn.TabIndex = 3;
            this.SaveBtn.Text = "SAVE";
            this.SaveBtn.UseVisualStyleBackColor = false;
            this.SaveBtn.Click += new System.EventHandler(this.SaveBtn_Click);
            // 
            // flowLayoutPanel3
            // 
            this.flowLayoutPanel3.Controls.Add(this.label2);
            this.flowLayoutPanel3.Controls.Add(this.dtp_StartDate);
            this.flowLayoutPanel3.Controls.Add(this.dtp_EndDate);
            this.flowLayoutPanel3.Controls.Add(this.label3);
            this.flowLayoutPanel3.Controls.Add(this.panel2);
            this.flowLayoutPanel3.Controls.Add(this.label4);
            this.flowLayoutPanel3.Controls.Add(this.txt_Description);
            this.flowLayoutPanel3.Controls.Add(this.panel1);
            this.flowLayoutPanel3.Controls.Add(this.rtxt_location);
            this.flowLayoutPanel3.Controls.Add(this.label6);
            this.flowLayoutPanel3.Controls.Add(this.cmb_Vehicle);
            this.flowLayoutPanel3.Controls.Add(this.label7);
            this.flowLayoutPanel3.Controls.Add(this.rtxt_Notes);
            this.flowLayoutPanel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flowLayoutPanel3.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.flowLayoutPanel3.Location = new System.Drawing.Point(0, 0);
            this.flowLayoutPanel3.Name = "flowLayoutPanel3";
            this.flowLayoutPanel3.Padding = new System.Windows.Forms.Padding(4);
            this.flowLayoutPanel3.Size = new System.Drawing.Size(383, 549);
            this.flowLayoutPanel3.TabIndex = 0;
            this.flowLayoutPanel3.WrapContents = false;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(7, 4);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(104, 13);
            this.label2.TabIndex = 0;
            this.label2.Text = "DATE AND TIME";
            // 
            // dtp_StartDate
            // 
            this.dtp_StartDate.Dock = System.Windows.Forms.DockStyle.Left;
            this.dtp_StartDate.Location = new System.Drawing.Point(7, 22);
            this.dtp_StartDate.Margin = new System.Windows.Forms.Padding(3, 5, 3, 3);
            this.dtp_StartDate.Name = "dtp_StartDate";
            this.dtp_StartDate.Size = new System.Drawing.Size(373, 20);
            this.dtp_StartDate.TabIndex = 1;
            // 
            // dtp_EndDate
            // 
            this.dtp_EndDate.Dock = System.Windows.Forms.DockStyle.Left;
            this.dtp_EndDate.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtp_EndDate.Location = new System.Drawing.Point(7, 48);
            this.dtp_EndDate.Name = "dtp_EndDate";
            this.dtp_EndDate.Size = new System.Drawing.Size(373, 21);
            this.dtp_EndDate.TabIndex = 2;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(7, 77);
            this.label3.Margin = new System.Windows.Forms.Padding(3, 5, 3, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(74, 13);
            this.label3.TabIndex = 3;
            this.label3.Text = "CATEGORY";
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.btn_add_name);
            this.panel2.Controls.Add(this.cmb_Category);
            this.panel2.Location = new System.Drawing.Point(7, 93);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(373, 26);
            this.panel2.TabIndex = 14;
            // 
            // btn_add_name
            // 
            this.btn_add_name.BackColor = System.Drawing.Color.Transparent;
            this.btn_add_name.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btn_add_name.BackgroundImage")));
            this.btn_add_name.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btn_add_name.Location = new System.Drawing.Point(340, 1);
            this.btn_add_name.Name = "btn_add_name";
            this.btn_add_name.Size = new System.Drawing.Size(30, 22);
            this.btn_add_name.TabIndex = 35;
            this.btn_add_name.UseVisualStyleBackColor = false;
            this.btn_add_name.Click += new System.EventHandler(this.btn_add_name_Click);
            // 
            // cmb_Category
            // 
            this.cmb_Category.Dock = System.Windows.Forms.DockStyle.Left;
            this.cmb_Category.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmb_Category.FormattingEnabled = true;
            this.cmb_Category.Location = new System.Drawing.Point(0, 0);
            this.cmb_Category.Margin = new System.Windows.Forms.Padding(3, 5, 3, 3);
            this.cmb_Category.Name = "cmb_Category";
            this.cmb_Category.Size = new System.Drawing.Size(334, 23);
            this.cmb_Category.TabIndex = 4;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(7, 127);
            this.label4.Margin = new System.Windows.Forms.Padding(3, 5, 3, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(99, 13);
            this.label4.TabIndex = 5;
            this.label4.Text = "DESCRIPTIONS";
            // 
            // txt_Description
            // 
            this.txt_Description.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txt_Description.Dock = System.Windows.Forms.DockStyle.Left;
            this.txt_Description.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_Description.Location = new System.Drawing.Point(7, 145);
            this.txt_Description.Margin = new System.Windows.Forms.Padding(3, 5, 3, 3);
            this.txt_Description.Name = "txt_Description";
            this.txt_Description.Size = new System.Drawing.Size(373, 103);
            this.txt_Description.TabIndex = 6;
            this.txt_Description.Text = "";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.PinMapBtn);
            this.panel1.Controls.Add(this.label5);
            this.panel1.Location = new System.Drawing.Point(7, 254);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(373, 33);
            this.panel1.TabIndex = 13;
            // 
            // PinMapBtn
            // 
            this.PinMapBtn.Location = new System.Drawing.Point(75, 5);
            this.PinMapBtn.Name = "PinMapBtn";
            this.PinMapBtn.Size = new System.Drawing.Size(75, 23);
            this.PinMapBtn.TabIndex = 8;
            this.PinMapBtn.Text = "Pin map";
            this.PinMapBtn.UseVisualStyleBackColor = true;
            this.PinMapBtn.Click += new System.EventHandler(this.PinMapBtn_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(0, 10);
            this.label5.Margin = new System.Windows.Forms.Padding(3, 10, 3, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(69, 13);
            this.label5.TabIndex = 7;
            this.label5.Text = "LOCATION";
            // 
            // rtxt_location
            // 
            this.rtxt_location.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.rtxt_location.Dock = System.Windows.Forms.DockStyle.Left;
            this.rtxt_location.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rtxt_location.Location = new System.Drawing.Point(7, 290);
            this.rtxt_location.Margin = new System.Windows.Forms.Padding(3, 0, 3, 3);
            this.rtxt_location.Name = "rtxt_location";
            this.rtxt_location.Size = new System.Drawing.Size(373, 47);
            this.rtxt_location.TabIndex = 8;
            this.rtxt_location.Text = "";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(7, 345);
            this.label6.Margin = new System.Windows.Forms.Padding(3, 5, 3, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(59, 13);
            this.label6.TabIndex = 9;
            this.label6.Text = "VEHICLE";
            // 
            // cmb_Vehicle
            // 
            this.cmb_Vehicle.Dock = System.Windows.Forms.DockStyle.Left;
            this.cmb_Vehicle.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmb_Vehicle.FormattingEnabled = true;
            this.cmb_Vehicle.Location = new System.Drawing.Point(7, 363);
            this.cmb_Vehicle.Margin = new System.Windows.Forms.Padding(3, 5, 3, 3);
            this.cmb_Vehicle.Name = "cmb_Vehicle";
            this.cmb_Vehicle.Size = new System.Drawing.Size(373, 23);
            this.cmb_Vehicle.TabIndex = 10;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(7, 394);
            this.label7.Margin = new System.Windows.Forms.Padding(3, 5, 3, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(49, 13);
            this.label7.TabIndex = 11;
            this.label7.Text = "NOTES";
            // 
            // rtxt_Notes
            // 
            this.rtxt_Notes.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.rtxt_Notes.Dock = System.Windows.Forms.DockStyle.Left;
            this.rtxt_Notes.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rtxt_Notes.Location = new System.Drawing.Point(7, 412);
            this.rtxt_Notes.Margin = new System.Windows.Forms.Padding(3, 5, 3, 3);
            this.rtxt_Notes.Name = "rtxt_Notes";
            this.rtxt_Notes.Size = new System.Drawing.Size(373, 92);
            this.rtxt_Notes.TabIndex = 12;
            this.rtxt_Notes.Text = "";
            // 
            // ScheduleDetailsUserControl
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Inherit;
            this.Controls.Add(this.MainSplitContainer);
            this.Name = "ScheduleDetailsUserControl";
            this.Padding = new System.Windows.Forms.Padding(4);
            this.Size = new System.Drawing.Size(391, 605);
            this.Load += new System.EventHandler(this.ScheduleDetailsUserControl_Load);
            this.MainSplitContainer.Panel1.ResumeLayout(false);
            this.MainSplitContainer.Panel1.PerformLayout();
            this.MainSplitContainer.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.MainSplitContainer)).EndInit();
            this.MainSplitContainer.ResumeLayout(false);
            this.flowLayoutPanel1.ResumeLayout(false);
            this.flowLayoutPanel3.ResumeLayout(false);
            this.flowLayoutPanel3.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer MainSplitContainer;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.Button CancelBtn;
        private System.Windows.Forms.Button SaveBtn;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DateTimePicker dtp_StartDate;
        private System.Windows.Forms.DateTimePicker dtp_EndDate;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cmb_Category;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.RichTextBox txt_Description;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.RichTextBox rtxt_location;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ComboBox cmb_Vehicle;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.RichTextBox rtxt_Notes;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button PinMapBtn;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button btn_add_name;
    }
}
