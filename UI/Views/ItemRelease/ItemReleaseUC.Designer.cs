
namespace smpc_dispatching.UI.Views.ItemRelease
{
    partial class ItemReleaseUC
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ItemReleaseUC));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            this.pnl_header = new System.Windows.Forms.Panel();
            this.label2 = new System.Windows.Forms.Label();
            this.txt_sales_order_id = new System.Windows.Forms.TextBox();
            this.dtp_request_date = new System.Windows.Forms.DateTimePicker();
            this.dtp_released_date = new System.Windows.Forms.DateTimePicker();
            this.dtp_required_date = new System.Windows.Forms.DateTimePicker();
            this.txt_id = new System.Windows.Forms.TextBox();
            this.label13 = new System.Windows.Forms.Label();
            this.cmb_reference_doc_no = new System.Windows.Forms.ComboBox();
            this.label8 = new System.Windows.Forms.Label();
            this.txt_doc_no = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.btn_new = new System.Windows.Forms.ToolStripButton();
            this.btn_search = new System.Windows.Forms.ToolStripButton();
            this.btn_edit = new System.Windows.Forms.ToolStripButton();
            this.btn_delete = new System.Windows.Forms.ToolStripButton();
            this.btn_print = new System.Windows.Forms.ToolStripButton();
            this.btn_save = new System.Windows.Forms.ToolStripButton();
            this.btn_close = new System.Windows.Forms.ToolStripButton();
            this.btn_next = new System.Windows.Forms.ToolStripButton();
            this.btn_prev = new System.Windows.Forms.ToolStripButton();
            this.panel6 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.pnl_footer = new System.Windows.Forms.Panel();
            this.chk_is_forward = new System.Windows.Forms.CheckBox();
            this.txt_received_by = new System.Windows.Forms.TextBox();
            this.cmb_received_by_try = new System.Windows.Forms.ComboBox();
            this.btn_forward = new System.Windows.Forms.Button();
            this.txt_issued_by = new System.Windows.Forms.TextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.txt_approved_by = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.txt_requested_by = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.btn_cancel_request = new System.Windows.Forms.Button();
            this.pnl_body = new System.Windows.Forms.Panel();
            this.dgv_details = new System.Windows.Forms.DataGridView();
            this.number = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ir_id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.item_id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.item_code = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.sales_order_id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.sales_order_details_id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.item_description = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.order_qty = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.required_qty = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.required_uom = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.released_qty = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.released_uom = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.serial_no = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.delivery_preference = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.bin_location = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.pnl_header.SuspendLayout();
            this.toolStrip1.SuspendLayout();
            this.panel6.SuspendLayout();
            this.pnl_footer.SuspendLayout();
            this.pnl_body.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_details)).BeginInit();
            this.SuspendLayout();
            // 
            // pnl_header
            // 
            this.pnl_header.Controls.Add(this.label2);
            this.pnl_header.Controls.Add(this.txt_sales_order_id);
            this.pnl_header.Controls.Add(this.dtp_request_date);
            this.pnl_header.Controls.Add(this.dtp_released_date);
            this.pnl_header.Controls.Add(this.dtp_required_date);
            this.pnl_header.Controls.Add(this.txt_id);
            this.pnl_header.Controls.Add(this.label13);
            this.pnl_header.Controls.Add(this.cmb_reference_doc_no);
            this.pnl_header.Controls.Add(this.label8);
            this.pnl_header.Controls.Add(this.txt_doc_no);
            this.pnl_header.Controls.Add(this.label7);
            this.pnl_header.Controls.Add(this.label6);
            this.pnl_header.Controls.Add(this.label5);
            this.pnl_header.Controls.Add(this.label4);
            this.pnl_header.Controls.Add(this.toolStrip1);
            this.pnl_header.Controls.Add(this.panel6);
            this.pnl_header.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnl_header.Location = new System.Drawing.Point(0, 0);
            this.pnl_header.Name = "pnl_header";
            this.pnl_header.Size = new System.Drawing.Size(1242, 215);
            this.pnl_header.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(965, 133);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(39, 13);
            this.label2.TabIndex = 100;
            this.label2.Text = "SO ID:";
            this.label2.Visible = false;
            // 
            // txt_sales_order_id
            // 
            this.txt_sales_order_id.Location = new System.Drawing.Point(1029, 130);
            this.txt_sales_order_id.Name = "txt_sales_order_id";
            this.txt_sales_order_id.Size = new System.Drawing.Size(200, 20);
            this.txt_sales_order_id.TabIndex = 99;
            this.txt_sales_order_id.Tag = "";
            this.txt_sales_order_id.Visible = false;
            // 
            // dtp_request_date
            // 
            this.dtp_request_date.Enabled = false;
            this.dtp_request_date.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtp_request_date.Location = new System.Drawing.Point(139, 87);
            this.dtp_request_date.Name = "dtp_request_date";
            this.dtp_request_date.Size = new System.Drawing.Size(200, 20);
            this.dtp_request_date.TabIndex = 98;
            this.dtp_request_date.Tag = "REQUIRED";
            // 
            // dtp_released_date
            // 
            this.dtp_released_date.Enabled = false;
            this.dtp_released_date.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtp_released_date.Location = new System.Drawing.Point(139, 129);
            this.dtp_released_date.Name = "dtp_released_date";
            this.dtp_released_date.Size = new System.Drawing.Size(200, 20);
            this.dtp_released_date.TabIndex = 97;
            this.dtp_released_date.Tag = "REQUIRED";
            // 
            // dtp_required_date
            // 
            this.dtp_required_date.Enabled = false;
            this.dtp_required_date.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtp_required_date.Location = new System.Drawing.Point(139, 108);
            this.dtp_required_date.Name = "dtp_required_date";
            this.dtp_required_date.Size = new System.Drawing.Size(200, 20);
            this.dtp_required_date.TabIndex = 96;
            this.dtp_required_date.Tag = "REQUIRED";
            // 
            // txt_id
            // 
            this.txt_id.Location = new System.Drawing.Point(1029, 151);
            this.txt_id.Name = "txt_id";
            this.txt_id.Size = new System.Drawing.Size(200, 20);
            this.txt_id.TabIndex = 29;
            this.txt_id.Tag = "";
            this.txt_id.Visible = false;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(983, 154);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(21, 13);
            this.label13.TabIndex = 28;
            this.label13.Text = "ID:";
            this.label13.Visible = false;
            // 
            // cmb_reference_doc_no
            // 
            this.cmb_reference_doc_no.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmb_reference_doc_no.FormattingEnabled = true;
            this.cmb_reference_doc_no.Location = new System.Drawing.Point(1029, 108);
            this.cmb_reference_doc_no.Name = "cmb_reference_doc_no";
            this.cmb_reference_doc_no.Size = new System.Drawing.Size(200, 21);
            this.cmb_reference_doc_no.TabIndex = 27;
            this.cmb_reference_doc_no.SelectedIndexChanged += new System.EventHandler(this.cmb_ReferenceDocNo_SelectedIndexChanged);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(910, 111);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(94, 13);
            this.label8.TabIndex = 26;
            this.label8.Text = "REFERENCE NO:";
            // 
            // txt_doc_no
            // 
            this.txt_doc_no.Enabled = false;
            this.txt_doc_no.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_doc_no.Location = new System.Drawing.Point(1029, 87);
            this.txt_doc_no.Name = "txt_doc_no";
            this.txt_doc_no.Size = new System.Drawing.Size(200, 20);
            this.txt_doc_no.TabIndex = 25;
            this.txt_doc_no.Tag = "";
            this.txt_doc_no.Text = "IREL#0000";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(949, 90);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(55, 13);
            this.label7.TabIndex = 24;
            this.label7.Text = "DOC. NO:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(20, 132);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(91, 13);
            this.label6.TabIndex = 22;
            this.label6.Text = "RELEASE DATE:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(20, 111);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(99, 13);
            this.label5.TabIndex = 20;
            this.label5.Text = "REQUIRED DATE:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(20, 90);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(94, 13);
            this.label4.TabIndex = 18;
            this.label4.Text = "REQUEST DATE:";
            // 
            // toolStrip1
            // 
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btn_new,
            this.btn_search,
            this.btn_edit,
            this.btn_delete,
            this.btn_print,
            this.btn_save,
            this.btn_close,
            this.btn_next,
            this.btn_prev});
            this.toolStrip1.Location = new System.Drawing.Point(0, 44);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(1242, 25);
            this.toolStrip1.Stretch = true;
            this.toolStrip1.TabIndex = 13;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // btn_new
            // 
            this.btn_new.Image = ((System.Drawing.Image)(resources.GetObject("btn_new.Image")));
            this.btn_new.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btn_new.Name = "btn_new";
            this.btn_new.Size = new System.Drawing.Size(51, 22);
            this.btn_new.Text = "New";
            this.btn_new.Click += new System.EventHandler(this.btn_new_Click);
            // 
            // btn_search
            // 
            this.btn_search.Image = ((System.Drawing.Image)(resources.GetObject("btn_search.Image")));
            this.btn_search.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btn_search.Name = "btn_search";
            this.btn_search.Size = new System.Drawing.Size(62, 22);
            this.btn_search.Text = "Search";
            this.btn_search.Click += new System.EventHandler(this.btn_search_Click);
            // 
            // btn_edit
            // 
            this.btn_edit.Image = ((System.Drawing.Image)(resources.GetObject("btn_edit.Image")));
            this.btn_edit.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btn_edit.Name = "btn_edit";
            this.btn_edit.Size = new System.Drawing.Size(47, 22);
            this.btn_edit.Text = "Edit";
            this.btn_edit.Click += new System.EventHandler(this.btn_edit_Click);
            // 
            // btn_delete
            // 
            this.btn_delete.Image = ((System.Drawing.Image)(resources.GetObject("btn_delete.Image")));
            this.btn_delete.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btn_delete.Name = "btn_delete";
            this.btn_delete.Size = new System.Drawing.Size(60, 22);
            this.btn_delete.Text = "Delete";
            // 
            // btn_print
            // 
            this.btn_print.Image = ((System.Drawing.Image)(resources.GetObject("btn_print.Image")));
            this.btn_print.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btn_print.Name = "btn_print";
            this.btn_print.Size = new System.Drawing.Size(52, 22);
            this.btn_print.Text = "Print";
            this.btn_print.Click += new System.EventHandler(this.btn_print_Click);
            // 
            // btn_save
            // 
            this.btn_save.Image = ((System.Drawing.Image)(resources.GetObject("btn_save.Image")));
            this.btn_save.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btn_save.Name = "btn_save";
            this.btn_save.Size = new System.Drawing.Size(51, 22);
            this.btn_save.Text = "Save";
            this.btn_save.Visible = false;
            this.btn_save.Click += new System.EventHandler(this.btn_save_Click);
            // 
            // btn_close
            // 
            this.btn_close.Image = ((System.Drawing.Image)(resources.GetObject("btn_close.Image")));
            this.btn_close.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btn_close.Name = "btn_close";
            this.btn_close.Size = new System.Drawing.Size(56, 22);
            this.btn_close.Text = "Close";
            this.btn_close.Visible = false;
            this.btn_close.Click += new System.EventHandler(this.btn_close_Click);
            // 
            // btn_next
            // 
            this.btn_next.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.btn_next.Image = ((System.Drawing.Image)(resources.GetObject("btn_next.Image")));
            this.btn_next.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btn_next.Name = "btn_next";
            this.btn_next.Size = new System.Drawing.Size(51, 22);
            this.btn_next.Text = "Next";
            this.btn_next.TextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage;
            this.btn_next.Click += new System.EventHandler(this.btn_next_Click);
            // 
            // btn_prev
            // 
            this.btn_prev.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.btn_prev.Image = ((System.Drawing.Image)(resources.GetObject("btn_prev.Image")));
            this.btn_prev.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btn_prev.Name = "btn_prev";
            this.btn_prev.Size = new System.Drawing.Size(72, 22);
            this.btn_prev.Text = "Previous";
            this.btn_prev.Click += new System.EventHandler(this.btn_prev_Click);
            // 
            // panel6
            // 
            this.panel6.Controls.Add(this.label1);
            this.panel6.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel6.Location = new System.Drawing.Point(0, 0);
            this.panel6.Name = "panel6";
            this.panel6.Size = new System.Drawing.Size(1242, 44);
            this.panel6.TabIndex = 10;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F);
            this.label1.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label1.Location = new System.Drawing.Point(18, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(165, 25);
            this.label1.TabIndex = 1;
            this.label1.Text = "ITEM RELEASE";
            // 
            // pnl_footer
            // 
            this.pnl_footer.Controls.Add(this.chk_is_forward);
            this.pnl_footer.Controls.Add(this.txt_received_by);
            this.pnl_footer.Controls.Add(this.cmb_received_by_try);
            this.pnl_footer.Controls.Add(this.btn_forward);
            this.pnl_footer.Controls.Add(this.txt_issued_by);
            this.pnl_footer.Controls.Add(this.label12);
            this.pnl_footer.Controls.Add(this.txt_approved_by);
            this.pnl_footer.Controls.Add(this.label11);
            this.pnl_footer.Controls.Add(this.label10);
            this.pnl_footer.Controls.Add(this.txt_requested_by);
            this.pnl_footer.Controls.Add(this.label9);
            this.pnl_footer.Controls.Add(this.btn_cancel_request);
            this.pnl_footer.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnl_footer.Location = new System.Drawing.Point(0, 736);
            this.pnl_footer.Name = "pnl_footer";
            this.pnl_footer.Size = new System.Drawing.Size(1242, 210);
            this.pnl_footer.TabIndex = 2;
            // 
            // chk_is_forward
            // 
            this.chk_is_forward.AutoSize = true;
            this.chk_is_forward.Location = new System.Drawing.Point(885, 105);
            this.chk_is_forward.Name = "chk_is_forward";
            this.chk_is_forward.Size = new System.Drawing.Size(72, 17);
            this.chk_is_forward.TabIndex = 40;
            this.chk_is_forward.Text = "IsForward";
            this.chk_is_forward.UseVisualStyleBackColor = true;
            // 
            // txt_received_by
            // 
            this.txt_received_by.Location = new System.Drawing.Point(139, 49);
            this.txt_received_by.Name = "txt_received_by";
            this.txt_received_by.Size = new System.Drawing.Size(200, 20);
            this.txt_received_by.TabIndex = 39;
            // 
            // cmb_received_by_try
            // 
            this.cmb_received_by_try.FormattingEnabled = true;
            this.cmb_received_by_try.Items.AddRange(new object[] {
            "Management",
            "Sales",
            "Logistics",
            "Engineering",
            "Accounting",
            "Purchasing",
            "Warehouse"});
            this.cmb_received_by_try.Location = new System.Drawing.Point(139, 75);
            this.cmb_received_by_try.Name = "cmb_received_by_try";
            this.cmb_received_by_try.Size = new System.Drawing.Size(200, 21);
            this.cmb_received_by_try.TabIndex = 38;
            this.cmb_received_by_try.Tag = "DYNAMIC, REQUIRED";
            this.cmb_received_by_try.Visible = false;
            // 
            // btn_forward
            // 
            this.btn_forward.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_forward.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(217)))), ((int)(((byte)(234)))), ((int)(((byte)(211)))));
            this.btn_forward.Enabled = false;
            this.btn_forward.Location = new System.Drawing.Point(979, 101);
            this.btn_forward.Name = "btn_forward";
            this.btn_forward.Size = new System.Drawing.Size(231, 23);
            this.btn_forward.TabIndex = 36;
            this.btn_forward.Text = "FORWARD TO WAREHOUSE";
            this.btn_forward.UseVisualStyleBackColor = false;
            this.btn_forward.Click += new System.EventHandler(this.btn_forward_Click);
            // 
            // txt_issued_by
            // 
            this.txt_issued_by.Location = new System.Drawing.Point(1020, 49);
            this.txt_issued_by.Name = "txt_issued_by";
            this.txt_issued_by.Size = new System.Drawing.Size(200, 20);
            this.txt_issued_by.TabIndex = 23;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(830, 52);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(67, 13);
            this.label12.TabIndex = 24;
            this.label12.Text = "ISSUED BY:";
            // 
            // txt_approved_by
            // 
            this.txt_approved_by.Location = new System.Drawing.Point(1020, 28);
            this.txt_approved_by.Name = "txt_approved_by";
            this.txt_approved_by.Size = new System.Drawing.Size(200, 20);
            this.txt_approved_by.TabIndex = 21;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(830, 31);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(165, 13);
            this.label11.TabIndex = 22;
            this.label11.Text = "APPROVED/ AUTHORIZED BY:";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(20, 52);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(81, 13);
            this.label10.TabIndex = 20;
            this.label10.Text = "RECEIVED BY:";
            // 
            // txt_requested_by
            // 
            this.txt_requested_by.Location = new System.Drawing.Point(139, 28);
            this.txt_requested_by.Name = "txt_requested_by";
            this.txt_requested_by.Size = new System.Drawing.Size(200, 20);
            this.txt_requested_by.TabIndex = 17;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(20, 31);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(94, 13);
            this.label9.TabIndex = 18;
            this.label9.Text = "REQUESTED BY:";
            // 
            // btn_cancel_request
            // 
            this.btn_cancel_request.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_cancel_request.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.btn_cancel_request.Enabled = false;
            this.btn_cancel_request.Location = new System.Drawing.Point(979, 101);
            this.btn_cancel_request.Name = "btn_cancel_request";
            this.btn_cancel_request.Size = new System.Drawing.Size(231, 23);
            this.btn_cancel_request.TabIndex = 37;
            this.btn_cancel_request.Text = "CANCEL REQUEST";
            this.btn_cancel_request.UseVisualStyleBackColor = false;
            this.btn_cancel_request.Visible = false;
            this.btn_cancel_request.Click += new System.EventHandler(this.btn_cancel_Click);
            // 
            // pnl_body
            // 
            this.pnl_body.Controls.Add(this.dgv_details);
            this.pnl_body.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnl_body.Location = new System.Drawing.Point(0, 215);
            this.pnl_body.Name = "pnl_body";
            this.pnl_body.Size = new System.Drawing.Size(1242, 521);
            this.pnl_body.TabIndex = 3;
            // 
            // dgv_details
            // 
            this.dgv_details.AllowUserToAddRows = false;
            this.dgv_details.AllowUserToDeleteRows = false;
            this.dgv_details.AllowUserToResizeColumns = false;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgv_details.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgv_details.ColumnHeadersHeight = 40;
            this.dgv_details.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.number,
            this.id,
            this.ir_id,
            this.item_id,
            this.item_code,
            this.sales_order_id,
            this.sales_order_details_id,
            this.item_description,
            this.order_qty,
            this.required_qty,
            this.required_uom,
            this.released_qty,
            this.released_uom,
            this.serial_no,
            this.delivery_preference,
            this.bin_location});
            this.dgv_details.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgv_details.EnableHeadersVisualStyles = false;
            this.dgv_details.Location = new System.Drawing.Point(0, 0);
            this.dgv_details.Name = "dgv_details";
            this.dgv_details.Size = new System.Drawing.Size(1242, 521);
            this.dgv_details.TabIndex = 1;
            this.dgv_details.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgv_details_CellClick);
            // 
            // number
            // 
            this.number.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.number.DataPropertyName = "number";
            this.number.Frozen = true;
            this.number.HeaderText = "#";
            this.number.Name = "number";
            this.number.ReadOnly = true;
            this.number.Visible = false;
            this.number.Width = 50;
            // 
            // id
            // 
            this.id.DataPropertyName = "id";
            this.id.HeaderText = "ID";
            this.id.Name = "id";
            this.id.Visible = false;
            // 
            // ir_id
            // 
            this.ir_id.DataPropertyName = "item_release_id";
            this.ir_id.HeaderText = "IR ID";
            this.ir_id.Name = "ir_id";
            this.ir_id.Visible = false;
            // 
            // item_id
            // 
            this.item_id.DataPropertyName = "item_id";
            this.item_id.HeaderText = "ITEM ID";
            this.item_id.Name = "item_id";
            this.item_id.ReadOnly = true;
            this.item_id.Visible = false;
            // 
            // item_code
            // 
            this.item_code.DataPropertyName = "item_code";
            this.item_code.HeaderText = "ITEM CODE";
            this.item_code.Name = "item_code";
            // 
            // sales_order_id
            // 
            this.sales_order_id.DataPropertyName = "sales_order_id";
            this.sales_order_id.HeaderText = "SO ID";
            this.sales_order_id.Name = "sales_order_id";
            this.sales_order_id.ReadOnly = true;
            // 
            // sales_order_details_id
            // 
            this.sales_order_details_id.DataPropertyName = "sales_order_details_id";
            this.sales_order_details_id.HeaderText = "SOD ID";
            this.sales_order_details_id.Name = "sales_order_details_id";
            this.sales_order_details_id.ReadOnly = true;
            this.sales_order_details_id.Visible = false;
            // 
            // item_description
            // 
            this.item_description.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.item_description.DataPropertyName = "item_description";
            this.item_description.HeaderText = "ITEM DESCRIPTION";
            this.item_description.MinimumWidth = 200;
            this.item_description.Name = "item_description";
            this.item_description.ReadOnly = true;
            // 
            // order_qty
            // 
            this.order_qty.DataPropertyName = "order_qty";
            this.order_qty.HeaderText = "ORDER QTY";
            this.order_qty.Name = "order_qty";
            this.order_qty.ReadOnly = true;
            this.order_qty.Visible = false;
            // 
            // required_qty
            // 
            this.required_qty.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.required_qty.DataPropertyName = "required_qty";
            this.required_qty.HeaderText = "QTY";
            this.required_qty.MinimumWidth = 80;
            this.required_qty.Name = "required_qty";
            this.required_qty.ReadOnly = true;
            this.required_qty.Width = 80;
            // 
            // required_uom
            // 
            this.required_uom.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.required_uom.DataPropertyName = "required_uom";
            this.required_uom.HeaderText = "UOM";
            this.required_uom.MinimumWidth = 80;
            this.required_uom.Name = "required_uom";
            this.required_uom.ReadOnly = true;
            this.required_uom.Width = 80;
            // 
            // released_qty
            // 
            this.released_qty.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.released_qty.DataPropertyName = "released_qty";
            this.released_qty.HeaderText = "QTY";
            this.released_qty.MinimumWidth = 80;
            this.released_qty.Name = "released_qty";
            this.released_qty.ReadOnly = true;
            this.released_qty.Width = 80;
            // 
            // released_uom
            // 
            this.released_uom.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.released_uom.DataPropertyName = "released_uom";
            this.released_uom.HeaderText = "UOM";
            this.released_uom.MinimumWidth = 80;
            this.released_uom.Name = "released_uom";
            this.released_uom.ReadOnly = true;
            this.released_uom.Width = 80;
            // 
            // serial_no
            // 
            this.serial_no.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.serial_no.DataPropertyName = "serial_no";
            this.serial_no.HeaderText = "SERIAL NUMBER";
            this.serial_no.MinimumWidth = 180;
            this.serial_no.Name = "serial_no";
            this.serial_no.ReadOnly = true;
            // 
            // delivery_preference
            // 
            this.delivery_preference.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.delivery_preference.DataPropertyName = "delivery_preference";
            this.delivery_preference.HeaderText = "DELIVERY PREFERENCE";
            this.delivery_preference.Name = "delivery_preference";
            this.delivery_preference.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.delivery_preference.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // bin_location
            // 
            this.bin_location.HeaderText = "bin_location ";
            this.bin_location.Name = "bin_location";
            this.bin_location.Visible = false;
            // 
            // ItemReleaseUC
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.pnl_body);
            this.Controls.Add(this.pnl_footer);
            this.Controls.Add(this.pnl_header);
            this.Name = "ItemReleaseUC";
            this.Size = new System.Drawing.Size(1242, 946);
            this.Load += new System.EventHandler(this.ItemReleaseUC_Load);
            this.pnl_header.ResumeLayout(false);
            this.pnl_header.PerformLayout();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.panel6.ResumeLayout(false);
            this.panel6.PerformLayout();
            this.pnl_footer.ResumeLayout(false);
            this.pnl_footer.PerformLayout();
            this.pnl_body.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgv_details)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnl_header;
        private System.Windows.Forms.DateTimePicker dtp_request_date;
        private System.Windows.Forms.DateTimePicker dtp_released_date;
        private System.Windows.Forms.DateTimePicker dtp_required_date;
        private System.Windows.Forms.TextBox txt_id;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.ComboBox cmb_reference_doc_no;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox txt_doc_no;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton btn_new;
        private System.Windows.Forms.ToolStripButton btn_search;
        private System.Windows.Forms.ToolStripButton btn_edit;
        private System.Windows.Forms.ToolStripButton btn_delete;
        private System.Windows.Forms.ToolStripButton btn_save;
        private System.Windows.Forms.ToolStripButton btn_close;
        private System.Windows.Forms.ToolStripButton btn_next;
        private System.Windows.Forms.ToolStripButton btn_prev;
        private System.Windows.Forms.Panel panel6;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel pnl_footer;
        private System.Windows.Forms.Button btn_forward;
        private System.Windows.Forms.TextBox txt_issued_by;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.TextBox txt_approved_by;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox txt_requested_by;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Button btn_cancel_request;
        private System.Windows.Forms.Panel pnl_body;
        private System.Windows.Forms.DataGridView dgv_details;
        private System.Windows.Forms.TextBox txt_received_by;
        private System.Windows.Forms.ComboBox cmb_received_by_try;
        private System.Windows.Forms.CheckBox chk_is_forward;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txt_sales_order_id;
        private System.Windows.Forms.ToolStripButton btn_print;
        private System.Windows.Forms.DataGridViewTextBoxColumn number;
        private System.Windows.Forms.DataGridViewTextBoxColumn id;
        private System.Windows.Forms.DataGridViewTextBoxColumn ir_id;
        private System.Windows.Forms.DataGridViewTextBoxColumn item_id;
        private System.Windows.Forms.DataGridViewTextBoxColumn item_code;
        private System.Windows.Forms.DataGridViewTextBoxColumn sales_order_id;
        private System.Windows.Forms.DataGridViewTextBoxColumn sales_order_details_id;
        private System.Windows.Forms.DataGridViewTextBoxColumn item_description;
        private System.Windows.Forms.DataGridViewTextBoxColumn order_qty;
        private System.Windows.Forms.DataGridViewTextBoxColumn required_qty;
        private System.Windows.Forms.DataGridViewTextBoxColumn required_uom;
        private System.Windows.Forms.DataGridViewTextBoxColumn released_qty;
        private System.Windows.Forms.DataGridViewTextBoxColumn released_uom;
        private System.Windows.Forms.DataGridViewTextBoxColumn serial_no;
        private System.Windows.Forms.DataGridViewTextBoxColumn delivery_preference;
        private System.Windows.Forms.DataGridViewTextBoxColumn bin_location;
    }
}
