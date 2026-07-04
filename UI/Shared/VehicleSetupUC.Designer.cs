namespace smpc_dispatching.UI.Shared {
    partial class VehicleSetupUC {
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.panel_dg = new System.Windows.Forms.Panel();
            this.dg_vehicle = new System.Windows.Forms.DataGridView();
            this.lbl_title = new System.Windows.Forms.Label();
            this.panel_header = new System.Windows.Forms.Panel();
            this.btn_edit = new System.Windows.Forms.Button();
            this.btn_new = new System.Windows.Forms.Button();
            this.panel_dg.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dg_vehicle)).BeginInit();
            this.panel_header.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel_dg
            // 
            this.panel_dg.Controls.Add(this.dg_vehicle);
            this.panel_dg.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel_dg.Location = new System.Drawing.Point(0, 86);
            this.panel_dg.Name = "panel_dg";
            this.panel_dg.Size = new System.Drawing.Size(900, 514);
            this.panel_dg.TabIndex = 1;
            // 
            // dg_vehicle
            // 
            this.dg_vehicle.AllowUserToAddRows = false;
            this.dg_vehicle.AllowUserToDeleteRows = false;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dg_vehicle.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dg_vehicle.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dg_vehicle.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dg_vehicle.EnableHeadersVisualStyles = false;
            this.dg_vehicle.Location = new System.Drawing.Point(0, 0);
            this.dg_vehicle.Name = "dg_vehicle";
            this.dg_vehicle.RowHeadersVisible = false;
            this.dg_vehicle.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dg_vehicle.Size = new System.Drawing.Size(900, 514);
            this.dg_vehicle.TabIndex = 0;
            // 
            // lbl_title
            // 
            this.lbl_title.AutoSize = true;
            this.lbl_title.Font = new System.Drawing.Font("Microsoft Tai Le", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_title.Location = new System.Drawing.Point(12, 12);
            this.lbl_title.Name = "lbl_title";
            this.lbl_title.Size = new System.Drawing.Size(72, 23);
            this.lbl_title.TabIndex = 0;
            this.lbl_title.Text = "Vehicle";
            // 
            // panel_header
            // 
            this.panel_header.Controls.Add(this.btn_edit);
            this.panel_header.Controls.Add(this.btn_new);
            this.panel_header.Controls.Add(this.lbl_title);
            this.panel_header.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel_header.Location = new System.Drawing.Point(0, 0);
            this.panel_header.Name = "panel_header";
            this.panel_header.Size = new System.Drawing.Size(900, 86);
            this.panel_header.TabIndex = 0;
            // 
            // btn_edit
            // 
            this.btn_edit.Location = new System.Drawing.Point(84, 57);
            this.btn_edit.Name = "btn_edit";
            this.btn_edit.Size = new System.Drawing.Size(73, 22);
            this.btn_edit.TabIndex = 3;
            this.btn_edit.Text = "EDIT";
            this.btn_edit.UseVisualStyleBackColor = true;
            this.btn_edit.Click += new System.EventHandler(this.btn_edit_Click);
            // 
            // btn_new
            // 
            this.btn_new.BackColor = System.Drawing.Color.LimeGreen;
            this.btn_new.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_new.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_new.ForeColor = System.Drawing.Color.Black;
            this.btn_new.Location = new System.Drawing.Point(16, 57);
            this.btn_new.Name = "btn_new";
            this.btn_new.Size = new System.Drawing.Size(73, 22);
            this.btn_new.TabIndex = 2;
            this.btn_new.Text = "NEW";
            this.btn_new.UseVisualStyleBackColor = false;
            this.btn_new.Click += new System.EventHandler(this.btn_new_Click);
            // 
            // VehicleSetupUC
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.panel_dg);
            this.Controls.Add(this.panel_header);
            this.Name = "VehicleSetupUC";
            this.Size = new System.Drawing.Size(900, 600);
            this.Load += new System.EventHandler(this.VehicleSetupUC_Load);
            this.panel_dg.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dg_vehicle)).EndInit();
            this.panel_header.ResumeLayout(false);
            this.panel_header.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Panel panel_dg;
        private System.Windows.Forms.DataGridView dg_vehicle;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_id;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_type;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_model;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_plate_no;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_capacity;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_status;
        private System.Windows.Forms.Label lbl_title;
        private System.Windows.Forms.Panel panel_header;
        private System.Windows.Forms.Button btn_edit;
        private System.Windows.Forms.Button btn_new;
    }
}
