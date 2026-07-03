namespace smpc_dispatching.UI.Shared.CalendarSchedule {
    partial class ScheduleItemUC {
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
            this.lbl_date_range = new System.Windows.Forms.Label();
            this.pnl_badge = new System.Windows.Forms.Panel();
            this.lbl_badge = new System.Windows.Forms.Label();
            this.lbl_people = new System.Windows.Forms.Label();
            this.lbl_time = new System.Windows.Forms.Label();
            this.lbl_location = new System.Windows.Forms.Label();
            this.lbl_vehicle = new System.Windows.Forms.Label();
            this.lbl_description = new System.Windows.Forms.Label();
            this.lbl_notes = new System.Windows.Forms.Label();
            this.pic_edit = new System.Windows.Forms.PictureBox();
            this.pic_delete = new System.Windows.Forms.PictureBox();
            this.pnl_divider = new System.Windows.Forms.Panel();
            this.pnl_badge.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pic_edit)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pic_delete)).BeginInit();
            this.SuspendLayout();
            // 
            // lbl_date_range
            // 
            this.lbl_date_range.AutoSize = true;
            this.lbl_date_range.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_date_range.Location = new System.Drawing.Point(14, 12);
            this.lbl_date_range.Name = "lbl_date_range";
            this.lbl_date_range.Size = new System.Drawing.Size(90, 16);
            this.lbl_date_range.TabIndex = 0;
            this.lbl_date_range.Text = "Date Range";
            // 
            // pnl_badge
            // 
            this.pnl_badge.BackColor = System.Drawing.Color.SteelBlue;
            this.pnl_badge.Controls.Add(this.lbl_badge);
            this.pnl_badge.Location = new System.Drawing.Point(230, 9);
            this.pnl_badge.Name = "pnl_badge";
            this.pnl_badge.Size = new System.Drawing.Size(210, 24);
            this.pnl_badge.TabIndex = 1;
            // 
            // lbl_badge
            // 
            this.lbl_badge.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lbl_badge.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_badge.ForeColor = System.Drawing.Color.White;
            this.lbl_badge.Location = new System.Drawing.Point(0, 0);
            this.lbl_badge.Name = "lbl_badge";
            this.lbl_badge.Size = new System.Drawing.Size(210, 24);
            this.lbl_badge.TabIndex = 0;
            this.lbl_badge.Text = "CATEGORY";
            this.lbl_badge.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lbl_people
            // 
            this.lbl_people.AutoSize = true;
            this.lbl_people.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_people.Location = new System.Drawing.Point(14, 46);
            this.lbl_people.Name = "lbl_people";
            this.lbl_people.Size = new System.Drawing.Size(40, 13);
            this.lbl_people.TabIndex = 2;
            this.lbl_people.Text = "People";
            // 
            // lbl_time
            // 
            this.lbl_time.AutoSize = true;
            this.lbl_time.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_time.Location = new System.Drawing.Point(230, 46);
            this.lbl_time.Name = "lbl_time";
            this.lbl_time.Size = new System.Drawing.Size(30, 13);
            this.lbl_time.TabIndex = 3;
            this.lbl_time.Text = "Time";
            // 
            // lbl_location
            // 
            this.lbl_location.AutoSize = true;
            this.lbl_location.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_location.Location = new System.Drawing.Point(360, 46);
            this.lbl_location.Name = "lbl_location";
            this.lbl_location.Size = new System.Drawing.Size(48, 13);
            this.lbl_location.TabIndex = 4;
            this.lbl_location.Text = "Location";
            // 
            // lbl_vehicle
            // 
            this.lbl_vehicle.AutoSize = true;
            this.lbl_vehicle.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_vehicle.Location = new System.Drawing.Point(520, 46);
            this.lbl_vehicle.Name = "lbl_vehicle";
            this.lbl_vehicle.Size = new System.Drawing.Size(42, 13);
            this.lbl_vehicle.TabIndex = 5;
            this.lbl_vehicle.Text = "Vehicle";
            // 
            // lbl_description
            // 
            this.lbl_description.AutoSize = true;
            this.lbl_description.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_description.ForeColor = System.Drawing.Color.Gray;
            this.lbl_description.Location = new System.Drawing.Point(14, 72);
            this.lbl_description.Name = "lbl_description";
            this.lbl_description.Size = new System.Drawing.Size(76, 13);
            this.lbl_description.TabIndex = 6;
            this.lbl_description.Text = "DESCRIPTION";
            // 
            // lbl_notes
            // 
            this.lbl_notes.AutoSize = true;
            this.lbl_notes.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_notes.ForeColor = System.Drawing.Color.Gray;
            this.lbl_notes.Location = new System.Drawing.Point(14, 92);
            this.lbl_notes.Name = "lbl_notes";
            this.lbl_notes.Size = new System.Drawing.Size(41, 13);
            this.lbl_notes.TabIndex = 7;
            this.lbl_notes.Text = "NOTES";
            // 
            // pic_edit
            // 
            this.pic_edit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.pic_edit.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pic_edit.Location = new System.Drawing.Point(1128, 12);
            this.pic_edit.Name = "pic_edit";
            this.pic_edit.Size = new System.Drawing.Size(20, 20);
            this.pic_edit.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pic_edit.TabIndex = 8;
            this.pic_edit.TabStop = false;
            this.pic_edit.Click += new System.EventHandler(this.pic_edit_Click);
            // 
            // pic_delete
            // 
            this.pic_delete.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.pic_delete.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pic_delete.Location = new System.Drawing.Point(1156, 12);
            this.pic_delete.Name = "pic_delete";
            this.pic_delete.Size = new System.Drawing.Size(20, 20);
            this.pic_delete.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pic_delete.TabIndex = 9;
            this.pic_delete.TabStop = false;
            // 
            // pnl_divider
            // 
            this.pnl_divider.BackColor = System.Drawing.Color.Gainsboro;
            this.pnl_divider.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnl_divider.Location = new System.Drawing.Point(0, 123);
            this.pnl_divider.Name = "pnl_divider";
            this.pnl_divider.Size = new System.Drawing.Size(1193, 1);
            this.pnl_divider.TabIndex = 10;
            // 
            // ScheduleItemUC
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.pnl_divider);
            this.Controls.Add(this.pic_delete);
            this.Controls.Add(this.pic_edit);
            this.Controls.Add(this.lbl_notes);
            this.Controls.Add(this.lbl_description);
            this.Controls.Add(this.lbl_vehicle);
            this.Controls.Add(this.lbl_location);
            this.Controls.Add(this.lbl_time);
            this.Controls.Add(this.lbl_people);
            this.Controls.Add(this.pnl_badge);
            this.Controls.Add(this.lbl_date_range);
            this.Name = "ScheduleItemUC";
            this.Size = new System.Drawing.Size(1193, 124);
            this.Load += new System.EventHandler(this.ScheduleItem_Load);
            this.pnl_badge.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pic_edit)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pic_delete)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lbl_date_range;
        private System.Windows.Forms.Panel pnl_badge;
        private System.Windows.Forms.Label lbl_badge;
        private System.Windows.Forms.Label lbl_people;
        private System.Windows.Forms.Label lbl_time;
        private System.Windows.Forms.Label lbl_location;
        private System.Windows.Forms.Label lbl_vehicle;
        private System.Windows.Forms.Label lbl_description;
        private System.Windows.Forms.Label lbl_notes;
        private System.Windows.Forms.PictureBox pic_edit;
        private System.Windows.Forms.PictureBox pic_delete;
        private System.Windows.Forms.Panel pnl_divider;
    }
}
