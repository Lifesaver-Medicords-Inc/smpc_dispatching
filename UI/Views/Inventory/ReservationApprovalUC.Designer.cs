namespace smpc_dispatching.UI.Views.Inventory {
    partial class ReservationApprovalUC {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing) {
            if (disposing && (components != null)) {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        private void InitializeComponent() {
            this.panel_header = new System.Windows.Forms.Panel();
            this.lbl_selected_count = new System.Windows.Forms.Label();
            this.btn_select_all = new System.Windows.Forms.Button();
            this.btn_refresh = new System.Windows.Forms.Button();
            this.btn_reject = new System.Windows.Forms.Button();
            this.btn_approve = new System.Windows.Forms.Button();
            this.lbl_title = new System.Windows.Forms.Label();
            this.panel_dg = new System.Windows.Forms.Panel();
            this.dg_pending_reservations = new System.Windows.Forms.DataGridView();
            this.col_select = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.col_id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_document_no = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_customer_name = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_project_name = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_item_name = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_item_model = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_item_code = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_qty = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_requested_by = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_reserved_at = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_expires_at = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_status = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panel_header.SuspendLayout();
            this.panel_dg.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dg_pending_reservations)).BeginInit();
            this.SuspendLayout();
            // 
            // panel_header
            // 
            this.panel_header.Controls.Add(this.lbl_selected_count);
            this.panel_header.Controls.Add(this.btn_select_all);
            this.panel_header.Controls.Add(this.btn_refresh);
            this.panel_header.Controls.Add(this.btn_reject);
            this.panel_header.Controls.Add(this.btn_approve);
            this.panel_header.Controls.Add(this.lbl_title);
            this.panel_header.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel_header.Location = new System.Drawing.Point(0, 0);
            this.panel_header.Name = "panel_header";
            this.panel_header.Size = new System.Drawing.Size(1100, 70);
            this.panel_header.TabIndex = 0;
            //
            // lbl_selected_count
            //
            this.lbl_selected_count.AutoSize = true;
            this.lbl_selected_count.ForeColor = System.Drawing.Color.DimGray;
            this.lbl_selected_count.Location = new System.Drawing.Point(447, 41);
            this.lbl_selected_count.Name = "lbl_selected_count";
            this.lbl_selected_count.Size = new System.Drawing.Size(78, 13);
            this.lbl_selected_count.TabIndex = 5;
            this.lbl_selected_count.Text = "0 selected";
            //
            // btn_select_all
            //
            this.btn_select_all.Location = new System.Drawing.Point(329, 34);
            this.btn_select_all.Name = "btn_select_all";
            this.btn_select_all.Size = new System.Drawing.Size(100, 26);
            this.btn_select_all.TabIndex = 4;
            this.btn_select_all.Text = "SELECT ALL";
            this.btn_select_all.UseVisualStyleBackColor = true;
            this.btn_select_all.Click += new System.EventHandler(this.btn_select_all_Click);
            //
            // btn_refresh
            //
            this.btn_refresh.Location = new System.Drawing.Point(223, 34);
            this.btn_refresh.Name = "btn_refresh";
            this.btn_refresh.Size = new System.Drawing.Size(90, 26);
            this.btn_refresh.TabIndex = 3;
            this.btn_refresh.Text = "REFRESH";
            this.btn_refresh.UseVisualStyleBackColor = true;
            this.btn_refresh.Click += new System.EventHandler(this.btn_refresh_Click);
            // 
            // btn_reject
            // 
            this.btn_reject.BackColor = System.Drawing.Color.IndianRed;
            this.btn_reject.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_reject.ForeColor = System.Drawing.Color.White;
            this.btn_reject.Location = new System.Drawing.Point(117, 34);
            this.btn_reject.Name = "btn_reject";
            this.btn_reject.Size = new System.Drawing.Size(90, 26);
            this.btn_reject.TabIndex = 2;
            this.btn_reject.Text = "REJECT";
            this.btn_reject.UseVisualStyleBackColor = false;
            this.btn_reject.Click += new System.EventHandler(this.btn_reject_Click);
            // 
            // btn_approve
            // 
            this.btn_approve.BackColor = System.Drawing.Color.SeaGreen;
            this.btn_approve.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_approve.ForeColor = System.Drawing.Color.White;
            this.btn_approve.Location = new System.Drawing.Point(11, 34);
            this.btn_approve.Name = "btn_approve";
            this.btn_approve.Size = new System.Drawing.Size(90, 26);
            this.btn_approve.TabIndex = 1;
            this.btn_approve.Text = "APPROVE";
            this.btn_approve.UseVisualStyleBackColor = false;
            this.btn_approve.Click += new System.EventHandler(this.btn_approve_Click);
            // 
            // lbl_title
            // 
            this.lbl_title.AutoSize = true;
            this.lbl_title.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_title.Location = new System.Drawing.Point(12, 9);
            this.lbl_title.Name = "lbl_title";
            this.lbl_title.Size = new System.Drawing.Size(276, 24);
            this.lbl_title.TabIndex = 0;
            this.lbl_title.Text = "Stock Reservation Approvals";
            // 
            // panel_dg
            // 
            this.panel_dg.Controls.Add(this.dg_pending_reservations);
            this.panel_dg.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel_dg.Location = new System.Drawing.Point(0, 70);
            this.panel_dg.Name = "panel_dg";
            this.panel_dg.Padding = new System.Windows.Forms.Padding(8);
            this.panel_dg.Size = new System.Drawing.Size(1100, 530);
            this.panel_dg.TabIndex = 1;
            // 
            // dg_pending_reservations
            // 
            this.dg_pending_reservations.AllowUserToAddRows = false;
            this.dg_pending_reservations.AllowUserToDeleteRows = false;
            this.dg_pending_reservations.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dg_pending_reservations.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.col_select,
            this.col_id,
            this.col_document_no,
            this.col_customer_name,
            this.col_project_name,
            this.col_item_name,
            this.col_item_model,
            this.col_item_code,
            this.col_qty,
            this.col_requested_by,
            this.col_reserved_at,
            this.col_expires_at,
            this.col_status});
            this.dg_pending_reservations.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dg_pending_reservations.Location = new System.Drawing.Point(8, 8);
            this.dg_pending_reservations.MultiSelect = false;
            this.dg_pending_reservations.Name = "dg_pending_reservations";
            // Grid-level ReadOnly would freeze the tick box too, so the flag moves down
            // to the individual data columns and only col_select stays editable.
            this.dg_pending_reservations.ReadOnly = false;
            this.dg_pending_reservations.RowHeadersVisible = false;
            this.dg_pending_reservations.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dg_pending_reservations.Size = new System.Drawing.Size(1084, 514);
            this.dg_pending_reservations.TabIndex = 0;
            this.dg_pending_reservations.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dg_pending_reservations_CellContentClick);
            this.dg_pending_reservations.CurrentCellDirtyStateChanged += new System.EventHandler(this.dg_pending_reservations_CurrentCellDirtyStateChanged);
            //
            // col_select
            //
            this.col_select.FillWeight = 40F;
            this.col_select.HeaderText = "";
            this.col_select.Name = "col_select";
            this.col_select.ReadOnly = false;
            this.col_select.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.col_select.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            //
            // col_customer_name
            //
            this.col_customer_name.FillWeight = 150F;
            this.col_customer_name.HeaderText = "CUSTOMER NAME";
            this.col_customer_name.Name = "col_customer_name";
            this.col_customer_name.ReadOnly = true;
            //
            // col_project_name
            //
            this.col_project_name.FillWeight = 150F;
            this.col_project_name.HeaderText = "PROJECT NAME";
            this.col_project_name.Name = "col_project_name";
            this.col_project_name.ReadOnly = true;
            //
            // col_id
            //
            this.col_id.HeaderText = "ID";
            this.col_id.Name = "col_id";
            this.col_id.ReadOnly = true;
            this.col_id.Visible = false;
            // 
            // col_document_no
            // 
            this.col_document_no.FillWeight = 90F;
            this.col_document_no.HeaderText = "DOC NO.";
            this.col_document_no.Name = "col_document_no";
            this.col_document_no.ReadOnly = true;
            //
            // col_item_name
            //
            this.col_item_name.FillWeight = 160F;
            this.col_item_name.HeaderText = "ITEM";
            this.col_item_name.Name = "col_item_name";
            this.col_item_name.ReadOnly = true;
            // 
            // col_item_model
            // 
            this.col_item_model.FillWeight = 110F;
            this.col_item_model.HeaderText = "MODEL";
            this.col_item_model.Name = "col_item_model";
            this.col_item_model.ReadOnly = true;
            // 
            // col_item_code
            // 
            this.col_item_code.HeaderText = "CODE";
            this.col_item_code.Name = "col_item_code";
            this.col_item_code.ReadOnly = true;
            // 
            // col_qty
            // 
            this.col_qty.FillWeight = 60F;
            this.col_qty.HeaderText = "QTY";
            this.col_qty.Name = "col_qty";
            this.col_qty.ReadOnly = true;
            // 
            // col_requested_by
            // 
            this.col_requested_by.FillWeight = 130F;
            this.col_requested_by.HeaderText = "REQUESTED BY";
            this.col_requested_by.Name = "col_requested_by";
            this.col_requested_by.ReadOnly = true;
            // 
            // col_reserved_at
            // 
            this.col_reserved_at.FillWeight = 140F;
            this.col_reserved_at.HeaderText = "RESERVED AT";
            this.col_reserved_at.Name = "col_reserved_at";
            this.col_reserved_at.ReadOnly = true;
            // 
            // col_expires_at
            // 
            this.col_expires_at.FillWeight = 120F;
            this.col_expires_at.HeaderText = "EXPIRES AT";
            this.col_expires_at.Name = "col_expires_at";
            this.col_expires_at.ReadOnly = true;
            // 
            // col_status
            // 
            this.col_status.FillWeight = 90F;
            this.col_status.HeaderText = "STATUS";
            this.col_status.Name = "col_status";
            this.col_status.ReadOnly = true;
            // 
            // ReservationApprovalUC
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.panel_dg);
            this.Controls.Add(this.panel_header);
            this.Name = "ReservationApprovalUC";
            this.Size = new System.Drawing.Size(1100, 600);
            this.Load += new System.EventHandler(this.ReservationApprovalUC_Load);
            this.panel_header.ResumeLayout(false);
            this.panel_header.PerformLayout();
            this.panel_dg.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dg_pending_reservations)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel_header;
        private System.Windows.Forms.Button btn_select_all;
        private System.Windows.Forms.Label lbl_selected_count;
        private System.Windows.Forms.Button btn_refresh;
        private System.Windows.Forms.Button btn_reject;
        private System.Windows.Forms.Button btn_approve;
        private System.Windows.Forms.Label lbl_title;
        private System.Windows.Forms.Panel panel_dg;
        private System.Windows.Forms.DataGridView dg_pending_reservations;
        private System.Windows.Forms.DataGridViewCheckBoxColumn col_select;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_id;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_document_no;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_customer_name;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_project_name;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_item_name;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_item_model;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_item_code;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_qty;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_requested_by;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_reserved_at;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_expires_at;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_status;
    }
}
