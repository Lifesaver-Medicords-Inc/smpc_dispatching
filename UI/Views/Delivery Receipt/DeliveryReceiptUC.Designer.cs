
namespace smpc_dispatching.UI.Views.Delivery_Receipt
{
    partial class DeliveryReceiptUC
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DeliveryReceiptUC));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            this.pnl_footer = new System.Windows.Forms.Panel();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.dg_costs = new System.Windows.Forms.DataGridView();
            this.dataBindingCost = new System.Windows.Forms.BindingSource(this.components);
            this.ds_dr_cost = new System.Data.DataSet();
            this.tbl_dr_cost = new System.Data.DataTable();
            this.column1 = new System.Data.DataColumn();
            this.column2 = new System.Data.DataColumn();
            this.column3 = new System.Data.DataColumn();
            this.column4 = new System.Data.DataColumn();
            this.column5 = new System.Data.DataColumn();
            this.column6 = new System.Data.DataColumn();
            this.column7 = new System.Data.DataColumn();
            this.txt_total_cost = new System.Windows.Forms.TextBox();
            this.label17 = new System.Windows.Forms.Label();
            this.pnl_header = new System.Windows.Forms.Panel();
            this.label16 = new System.Windows.Forms.Label();
            this.txt_customer_id = new System.Windows.Forms.TextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.txt_item_release_id = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.txt_sales_order_id = new System.Windows.Forms.TextBox();
            this.cmb_sales_order_id = new System.Windows.Forms.ComboBox();
            this.cmb_ship_type_id = new System.Windows.Forms.ComboBox();
            this.txt_item_release_no = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.txt_id = new System.Windows.Forms.TextBox();
            this.dtp_delivery_date = new System.Windows.Forms.DateTimePicker();
            this.dtp_date = new System.Windows.Forms.DateTimePicker();
            this.lb_delivery_date = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.txt_sales_executive = new System.Windows.Forms.TextBox();
            this.txt_doc_no = new System.Windows.Forms.TextBox();
            this.label13 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.txt_ship_via = new System.Windows.Forms.TextBox();
            this.txt_address = new System.Windows.Forms.TextBox();
            this.txt_att = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.txt_deliver_to = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.txt_customer_name = new System.Windows.Forms.TextBox();
            this.txt_tin_no = new System.Windows.Forms.TextBox();
            this.label37 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txt_customer_code = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.btn_new = new System.Windows.Forms.ToolStripButton();
            this.btn_edit = new System.Windows.Forms.ToolStripButton();
            this.btn_delete = new System.Windows.Forms.ToolStripButton();
            this.btn_print = new System.Windows.Forms.ToolStripButton();
            this.btn_search = new System.Windows.Forms.ToolStripButton();
            this.btn_save = new System.Windows.Forms.ToolStripButton();
            this.btn_close = new System.Windows.Forms.ToolStripButton();
            this.btn_next = new System.Windows.Forms.ToolStripButton();
            this.btn_prev = new System.Windows.Forms.ToolStripButton();
            this.panel6 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.dg_items = new System.Windows.Forms.DataGridView();
            this.released_qty = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.released_uom = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.item_code = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.item_description = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.serial_no = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.item_release_id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.sales_order_id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.sales_order_details_id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.item_id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.required_qty = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.required_uom = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.delivery_preference = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.itemsidDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.itemsitemidDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.itemsqtyDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.itemsunitofmeasureDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.itemsitemcodeDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.itemsdescriptionDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.itemsserialnoDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.itemsdeliveryreceiptidDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataBindingItem = new System.Windows.Forms.BindingSource(this.components);
            this.ds_dr_item = new System.Data.DataSet();
            this.tbl_dr_items = new System.Data.DataTable();
            this.col1 = new System.Data.DataColumn();
            this.col2 = new System.Data.DataColumn();
            this.col3 = new System.Data.DataColumn();
            this.col4 = new System.Data.DataColumn();
            this.col5 = new System.Data.DataColumn();
            this.col6 = new System.Data.DataColumn();
            this.col7 = new System.Data.DataColumn();
            this.col8 = new System.Data.DataColumn();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.pnl_body = new System.Windows.Forms.Panel();
            this.pnl_toggle = new System.Windows.Forms.Panel();
            this.btn_toggle = new System.Windows.Forms.Button();
            this.ds_dr_file = new System.Data.DataSet();
            this.dr_file = new System.Data.DataTable();
            this.dataColumn9 = new System.Data.DataColumn();
            this.dataColumn10 = new System.Data.DataColumn();
            this.dataColumn11 = new System.Data.DataColumn();
            this.dataColumn12 = new System.Data.DataColumn();
            this.dataColumn13 = new System.Data.DataColumn();
            this.dataColumn14 = new System.Data.DataColumn();
            this.dataColumn15 = new System.Data.DataColumn();
            this.dataBindingFile = new System.Windows.Forms.BindingSource(this.components);
            this.costs_id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.costs_delivery_receipt_id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.costs_cost_type_id = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.costs_description = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.costs_amount = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.costs_multiplier = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.costs_total_cost = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.pnl_footer.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dg_costs)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataBindingCost)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ds_dr_cost)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbl_dr_cost)).BeginInit();
            this.pnl_header.SuspendLayout();
            this.toolStrip1.SuspendLayout();
            this.panel6.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dg_items)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataBindingItem)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ds_dr_item)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbl_dr_items)).BeginInit();
            this.flowLayoutPanel1.SuspendLayout();
            this.pnl_body.SuspendLayout();
            this.pnl_toggle.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ds_dr_file)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dr_file)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataBindingFile)).BeginInit();
            this.SuspendLayout();
            // 
            // pnl_footer
            // 
            this.pnl_footer.Controls.Add(this.splitContainer1);
            this.pnl_footer.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnl_footer.Location = new System.Drawing.Point(3, 581);
            this.pnl_footer.Name = "pnl_footer";
            this.pnl_footer.Size = new System.Drawing.Size(1236, 326);
            this.pnl_footer.TabIndex = 3;
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.dg_costs);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.txt_total_cost);
            this.splitContainer1.Panel2.Controls.Add(this.label17);
            this.splitContainer1.Size = new System.Drawing.Size(1236, 326);
            this.splitContainer1.SplitterDistance = 284;
            this.splitContainer1.TabIndex = 1;
            // 
            // dg_costs
            // 
            this.dg_costs.AutoGenerateColumns = false;
            this.dg_costs.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dg_costs.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.costs_id,
            this.costs_delivery_receipt_id,
            this.costs_cost_type_id,
            this.costs_description,
            this.costs_amount,
            this.costs_multiplier,
            this.costs_total_cost});
            this.dg_costs.DataSource = this.dataBindingCost;
            this.dg_costs.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dg_costs.Location = new System.Drawing.Point(0, 0);
            this.dg_costs.Name = "dg_costs";
            this.dg_costs.Size = new System.Drawing.Size(1236, 284);
            this.dg_costs.TabIndex = 0;
            this.dg_costs.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.dg_costs_CellEndEdit);
            this.dg_costs.DataError += new System.Windows.Forms.DataGridViewDataErrorEventHandler(this.dg_costs_DataError);
            this.dg_costs.UserDeletingRow += new System.Windows.Forms.DataGridViewRowCancelEventHandler(this.dg_costs_UserDeletingRow);
            // 
            // dataBindingCost
            // 
            this.dataBindingCost.DataMember = "tbl_dr_cost";
            this.dataBindingCost.DataSource = this.ds_dr_cost;
            // 
            // ds_dr_cost
            // 
            this.ds_dr_cost.DataSetName = "NewDataSet";
            this.ds_dr_cost.Tables.AddRange(new System.Data.DataTable[] {
            this.tbl_dr_cost});
            // 
            // tbl_dr_cost
            // 
            this.tbl_dr_cost.Columns.AddRange(new System.Data.DataColumn[] {
            this.column1,
            this.column2,
            this.column3,
            this.column4,
            this.column5,
            this.column6,
            this.column7});
            this.tbl_dr_cost.TableName = "tbl_dr_cost";
            // 
            // column1
            // 
            this.column1.ColumnName = "costs_id";
            // 
            // column2
            // 
            this.column2.ColumnName = "costs_delivery_receipt_id";
            // 
            // column3
            // 
            this.column3.ColumnName = "costs_type_id";
            // 
            // column4
            // 
            this.column4.ColumnName = "costs_description";
            // 
            // column5
            // 
            this.column5.ColumnName = "costs_amount";
            // 
            // column6
            // 
            this.column6.ColumnName = "costs_multiplier";
            // 
            // column7
            // 
            this.column7.ColumnName = "costs_total_cost";
            // 
            // txt_total_cost
            // 
            this.txt_total_cost.Location = new System.Drawing.Point(1033, 3);
            this.txt_total_cost.Name = "txt_total_cost";
            this.txt_total_cost.Size = new System.Drawing.Size(200, 20);
            this.txt_total_cost.TabIndex = 120;
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Location = new System.Drawing.Point(950, 6);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(77, 13);
            this.label17.TabIndex = 121;
            this.label17.Text = "TOTAL COST:";
            // 
            // pnl_header
            // 
            this.pnl_header.Controls.Add(this.label16);
            this.pnl_header.Controls.Add(this.txt_customer_id);
            this.pnl_header.Controls.Add(this.label12);
            this.pnl_header.Controls.Add(this.txt_item_release_id);
            this.pnl_header.Controls.Add(this.label11);
            this.pnl_header.Controls.Add(this.txt_sales_order_id);
            this.pnl_header.Controls.Add(this.cmb_sales_order_id);
            this.pnl_header.Controls.Add(this.cmb_ship_type_id);
            this.pnl_header.Controls.Add(this.txt_item_release_no);
            this.pnl_header.Controls.Add(this.label9);
            this.pnl_header.Controls.Add(this.txt_id);
            this.pnl_header.Controls.Add(this.dtp_delivery_date);
            this.pnl_header.Controls.Add(this.dtp_date);
            this.pnl_header.Controls.Add(this.lb_delivery_date);
            this.pnl_header.Controls.Add(this.label10);
            this.pnl_header.Controls.Add(this.label15);
            this.pnl_header.Controls.Add(this.txt_sales_executive);
            this.pnl_header.Controls.Add(this.txt_doc_no);
            this.pnl_header.Controls.Add(this.label13);
            this.pnl_header.Controls.Add(this.label14);
            this.pnl_header.Controls.Add(this.txt_ship_via);
            this.pnl_header.Controls.Add(this.txt_address);
            this.pnl_header.Controls.Add(this.txt_att);
            this.pnl_header.Controls.Add(this.label5);
            this.pnl_header.Controls.Add(this.label6);
            this.pnl_header.Controls.Add(this.txt_deliver_to);
            this.pnl_header.Controls.Add(this.label7);
            this.pnl_header.Controls.Add(this.label8);
            this.pnl_header.Controls.Add(this.txt_customer_name);
            this.pnl_header.Controls.Add(this.txt_tin_no);
            this.pnl_header.Controls.Add(this.label37);
            this.pnl_header.Controls.Add(this.label2);
            this.pnl_header.Controls.Add(this.txt_customer_code);
            this.pnl_header.Controls.Add(this.label3);
            this.pnl_header.Controls.Add(this.label4);
            this.pnl_header.Controls.Add(this.toolStrip1);
            this.pnl_header.Controls.Add(this.panel6);
            this.pnl_header.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnl_header.Location = new System.Drawing.Point(3, 3);
            this.pnl_header.Name = "pnl_header";
            this.pnl_header.Size = new System.Drawing.Size(1236, 335);
            this.pnl_header.TabIndex = 2;
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(492, 298);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(56, 13);
            this.label16.TabIndex = 137;
            this.label16.Text = "CUST ID: ";
            this.label16.Visible = false;
            // 
            // txt_customer_id
            // 
            this.txt_customer_id.Location = new System.Drawing.Point(554, 295);
            this.txt_customer_id.Name = "txt_customer_id";
            this.txt_customer_id.Size = new System.Drawing.Size(50, 20);
            this.txt_customer_id.TabIndex = 136;
            this.txt_customer_id.Visible = false;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(731, 298);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(38, 13);
            this.label12.TabIndex = 135;
            this.label12.Text = "IR ID: ";
            this.label12.Visible = false;
            // 
            // txt_item_release_id
            // 
            this.txt_item_release_id.Location = new System.Drawing.Point(774, 295);
            this.txt_item_release_id.Name = "txt_item_release_id";
            this.txt_item_release_id.Size = new System.Drawing.Size(50, 20);
            this.txt_item_release_id.TabIndex = 134;
            this.txt_item_release_id.Visible = false;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(620, 298);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(40, 13);
            this.label11.TabIndex = 133;
            this.label11.Text = "S0 ID: ";
            this.label11.Visible = false;
            // 
            // txt_sales_order_id
            // 
            this.txt_sales_order_id.Location = new System.Drawing.Point(663, 295);
            this.txt_sales_order_id.Name = "txt_sales_order_id";
            this.txt_sales_order_id.Size = new System.Drawing.Size(50, 20);
            this.txt_sales_order_id.TabIndex = 132;
            this.txt_sales_order_id.Visible = false;
            // 
            // cmb_sales_order_id
            // 
            this.cmb_sales_order_id.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmb_sales_order_id.Enabled = false;
            this.cmb_sales_order_id.FormattingEnabled = true;
            this.cmb_sales_order_id.Location = new System.Drawing.Point(1023, 116);
            this.cmb_sales_order_id.Name = "cmb_sales_order_id";
            this.cmb_sales_order_id.Size = new System.Drawing.Size(200, 21);
            this.cmb_sales_order_id.TabIndex = 131;
            this.cmb_sales_order_id.Tag = "DYNAMIC";
            this.cmb_sales_order_id.SelectedIndexChanged += new System.EventHandler(this.cmb_reference_doc_no_SelectedIndexChanged);
            // 
            // cmb_ship_type_id
            // 
            this.cmb_ship_type_id.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmb_ship_type_id.FormattingEnabled = true;
            this.cmb_ship_type_id.Location = new System.Drawing.Point(139, 201);
            this.cmb_ship_type_id.Name = "cmb_ship_type_id";
            this.cmb_ship_type_id.Size = new System.Drawing.Size(200, 21);
            this.cmb_ship_type_id.TabIndex = 130;
            this.cmb_ship_type_id.Tag = "DYNAMIC";
            // 
            // txt_item_release_no
            // 
            this.txt_item_release_no.Enabled = false;
            this.txt_item_release_no.Location = new System.Drawing.Point(1023, 138);
            this.txt_item_release_no.Name = "txt_item_release_no";
            this.txt_item_release_no.Size = new System.Drawing.Size(200, 20);
            this.txt_item_release_no.TabIndex = 129;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(403, 298);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(24, 13);
            this.label9.TabIndex = 127;
            this.label9.Text = "ID: ";
            this.label9.Visible = false;
            // 
            // txt_id
            // 
            this.txt_id.Location = new System.Drawing.Point(433, 295);
            this.txt_id.Name = "txt_id";
            this.txt_id.Size = new System.Drawing.Size(50, 20);
            this.txt_id.TabIndex = 126;
            this.txt_id.Visible = false;
            // 
            // dtp_delivery_date
            // 
            this.dtp_delivery_date.CustomFormat = "MM/dd/yyyy";
            this.dtp_delivery_date.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtp_delivery_date.Location = new System.Drawing.Point(598, 115);
            this.dtp_delivery_date.Name = "dtp_delivery_date";
            this.dtp_delivery_date.Size = new System.Drawing.Size(200, 20);
            this.dtp_delivery_date.TabIndex = 125;
            // 
            // dtp_date
            // 
            this.dtp_date.CustomFormat = "MM/dd/yyyy";
            this.dtp_date.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtp_date.Location = new System.Drawing.Point(598, 94);
            this.dtp_date.Name = "dtp_date";
            this.dtp_date.Size = new System.Drawing.Size(200, 20);
            this.dtp_date.TabIndex = 124;
            // 
            // lb_delivery_date
            // 
            this.lb_delivery_date.AutoSize = true;
            this.lb_delivery_date.Location = new System.Drawing.Point(472, 120);
            this.lb_delivery_date.Name = "lb_delivery_date";
            this.lb_delivery_date.Size = new System.Drawing.Size(95, 13);
            this.lb_delivery_date.TabIndex = 123;
            this.lb_delivery_date.Text = "DELIVERY DATE:";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(525, 98);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(42, 13);
            this.label10.TabIndex = 121;
            this.label10.Text = "DATE: ";
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(891, 162);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(107, 13);
            this.label15.TabIndex = 119;
            this.label15.Text = "SALES EXECUTIVE:";
            // 
            // txt_sales_executive
            // 
            this.txt_sales_executive.Enabled = false;
            this.txt_sales_executive.Location = new System.Drawing.Point(1023, 159);
            this.txt_sales_executive.Name = "txt_sales_executive";
            this.txt_sales_executive.Size = new System.Drawing.Size(200, 20);
            this.txt_sales_executive.TabIndex = 118;
            // 
            // txt_doc_no
            // 
            this.txt_doc_no.Enabled = false;
            this.txt_doc_no.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_doc_no.Location = new System.Drawing.Point(1023, 95);
            this.txt_doc_no.Name = "txt_doc_no";
            this.txt_doc_no.Size = new System.Drawing.Size(200, 20);
            this.txt_doc_no.TabIndex = 116;
            this.txt_doc_no.Text = "DR#0000";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(876, 120);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(122, 13);
            this.label13.TabIndex = 115;
            this.label13.Text = "RERERENCE DOC NO:";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(946, 95);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(52, 13);
            this.label14.TabIndex = 113;
            this.label14.Text = "DOC NO:";
            // 
            // txt_ship_via
            // 
            this.txt_ship_via.Location = new System.Drawing.Point(139, 244);
            this.txt_ship_via.Name = "txt_ship_via";
            this.txt_ship_via.Size = new System.Drawing.Size(200, 20);
            this.txt_ship_via.TabIndex = 112;
            // 
            // txt_address
            // 
            this.txt_address.Enabled = false;
            this.txt_address.Location = new System.Drawing.Point(139, 137);
            this.txt_address.Name = "txt_address";
            this.txt_address.Size = new System.Drawing.Size(200, 20);
            this.txt_address.TabIndex = 111;
            // 
            // txt_att
            // 
            this.txt_att.Location = new System.Drawing.Point(139, 265);
            this.txt_att.Multiline = true;
            this.txt_att.Name = "txt_att";
            this.txt_att.Size = new System.Drawing.Size(200, 51);
            this.txt_att.TabIndex = 108;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(13, 245);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(55, 13);
            this.label5.TabIndex = 107;
            this.label5.Text = "SHIP VIA:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(13, 226);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(74, 13);
            this.label6.TabIndex = 106;
            this.label6.Text = "DELIVER TO:";
            // 
            // txt_deliver_to
            // 
            this.txt_deliver_to.Location = new System.Drawing.Point(139, 223);
            this.txt_deliver_to.Name = "txt_deliver_to";
            this.txt_deliver_to.Size = new System.Drawing.Size(200, 20);
            this.txt_deliver_to.TabIndex = 105;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(23, 264);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(31, 13);
            this.label7.TabIndex = 104;
            this.label7.Text = "ATT:";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(13, 204);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(41, 13);
            this.label8.TabIndex = 103;
            this.label8.Text = "TYPE: ";
            // 
            // txt_customer_name
            // 
            this.txt_customer_name.Enabled = false;
            this.txt_customer_name.Location = new System.Drawing.Point(139, 95);
            this.txt_customer_name.Name = "txt_customer_name";
            this.txt_customer_name.Size = new System.Drawing.Size(200, 20);
            this.txt_customer_name.TabIndex = 101;
            // 
            // txt_tin_no
            // 
            this.txt_tin_no.Enabled = false;
            this.txt_tin_no.Location = new System.Drawing.Point(139, 158);
            this.txt_tin_no.Name = "txt_tin_no";
            this.txt_tin_no.Size = new System.Drawing.Size(200, 20);
            this.txt_tin_no.TabIndex = 100;
            // 
            // label37
            // 
            this.label37.AutoSize = true;
            this.label37.Location = new System.Drawing.Point(13, 139);
            this.label37.Name = "label37";
            this.label37.Size = new System.Drawing.Size(62, 13);
            this.label37.TabIndex = 99;
            this.label37.Text = "ADDRESS:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(13, 120);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(40, 13);
            this.label2.TabIndex = 98;
            this.label2.Text = "CODE:";
            // 
            // txt_customer_code
            // 
            this.txt_customer_code.Enabled = false;
            this.txt_customer_code.Location = new System.Drawing.Point(139, 116);
            this.txt_customer_code.Name = "txt_customer_code";
            this.txt_customer_code.Size = new System.Drawing.Size(200, 20);
            this.txt_customer_code.TabIndex = 97;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(13, 162);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(47, 13);
            this.label3.TabIndex = 96;
            this.label3.Text = "TIN NO:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(13, 98);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(74, 13);
            this.label4.TabIndex = 95;
            this.label4.Text = "CUSTOMER: ";
            // 
            // toolStrip1
            // 
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btn_new,
            this.btn_edit,
            this.btn_delete,
            this.btn_print,
            this.btn_search,
            this.btn_save,
            this.btn_close,
            this.btn_next,
            this.btn_prev});
            this.toolStrip1.Location = new System.Drawing.Point(0, 44);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(1236, 25);
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
            // btn_search
            // 
            this.btn_search.Image = ((System.Drawing.Image)(resources.GetObject("btn_search.Image")));
            this.btn_search.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btn_search.Name = "btn_search";
            this.btn_search.Size = new System.Drawing.Size(62, 22);
            this.btn_search.Text = "Search";
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
            this.panel6.Size = new System.Drawing.Size(1236, 44);
            this.panel6.TabIndex = 10;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F);
            this.label1.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label1.Location = new System.Drawing.Point(18, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(212, 25);
            this.label1.TabIndex = 1;
            this.label1.Text = "DELIVERY RECEIPT";
            // 
            // dg_items
            // 
            this.dg_items.AllowUserToDeleteRows = false;
            this.dg_items.AllowUserToResizeColumns = false;
            this.dg_items.AutoGenerateColumns = false;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dg_items.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dg_items.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dg_items.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.released_qty,
            this.released_uom,
            this.item_code,
            this.item_description,
            this.serial_no,
            this.id,
            this.item_release_id,
            this.sales_order_id,
            this.sales_order_details_id,
            this.item_id,
            this.required_qty,
            this.required_uom,
            this.delivery_preference,
            this.itemsidDataGridViewTextBoxColumn,
            this.itemsitemidDataGridViewTextBoxColumn,
            this.itemsqtyDataGridViewTextBoxColumn,
            this.itemsunitofmeasureDataGridViewTextBoxColumn,
            this.itemsitemcodeDataGridViewTextBoxColumn,
            this.itemsdescriptionDataGridViewTextBoxColumn,
            this.itemsserialnoDataGridViewTextBoxColumn,
            this.itemsdeliveryreceiptidDataGridViewTextBoxColumn});
            this.dg_items.DataSource = this.dataBindingItem;
            this.dg_items.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dg_items.Location = new System.Drawing.Point(0, 0);
            this.dg_items.Name = "dg_items";
            this.dg_items.Size = new System.Drawing.Size(1236, 200);
            this.dg_items.TabIndex = 1;
            // 
            // released_qty
            // 
            this.released_qty.DataPropertyName = "released_qty";
            this.released_qty.HeaderText = "QTY";
            this.released_qty.Name = "released_qty";
            // 
            // released_uom
            // 
            this.released_uom.DataPropertyName = "released_uom";
            this.released_uom.HeaderText = "UOM";
            this.released_uom.Name = "released_uom";
            // 
            // item_code
            // 
            this.item_code.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.item_code.DataPropertyName = "item_code";
            this.item_code.HeaderText = "ITEM CODE";
            this.item_code.Name = "item_code";
            // 
            // item_description
            // 
            this.item_description.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.item_description.DataPropertyName = "item_description";
            this.item_description.HeaderText = "ITEM DESCRIPTION";
            this.item_description.Name = "item_description";
            // 
            // serial_no
            // 
            this.serial_no.DataPropertyName = "serial_no";
            this.serial_no.HeaderText = "SERIAL NUMBER/S";
            this.serial_no.Name = "serial_no";
            // 
            // id
            // 
            this.id.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.id.DataPropertyName = "id";
            this.id.HeaderText = "id";
            this.id.Name = "id";
            this.id.Visible = false;
            // 
            // item_release_id
            // 
            this.item_release_id.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.item_release_id.DataPropertyName = "item_release_id";
            this.item_release_id.HeaderText = "item_release_id";
            this.item_release_id.Name = "item_release_id";
            this.item_release_id.Visible = false;
            // 
            // sales_order_id
            // 
            this.sales_order_id.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.sales_order_id.DataPropertyName = "sales_order_id";
            this.sales_order_id.HeaderText = "sales_order_id";
            this.sales_order_id.Name = "sales_order_id";
            this.sales_order_id.Visible = false;
            // 
            // sales_order_details_id
            // 
            this.sales_order_details_id.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.sales_order_details_id.DataPropertyName = "sales_order_details_id";
            this.sales_order_details_id.HeaderText = "sales_order_details_id";
            this.sales_order_details_id.Name = "sales_order_details_id";
            this.sales_order_details_id.Visible = false;
            // 
            // item_id
            // 
            this.item_id.DataPropertyName = "item_id";
            this.item_id.HeaderText = "item_id";
            this.item_id.Name = "item_id";
            this.item_id.Visible = false;
            // 
            // required_qty
            // 
            this.required_qty.DataPropertyName = "required_qty";
            this.required_qty.HeaderText = "required_qty";
            this.required_qty.Name = "required_qty";
            this.required_qty.Visible = false;
            // 
            // required_uom
            // 
            this.required_uom.DataPropertyName = "required_uom";
            this.required_uom.HeaderText = "required_uom";
            this.required_uom.Name = "required_uom";
            this.required_uom.Visible = false;
            // 
            // delivery_preference
            // 
            this.delivery_preference.DataPropertyName = "delivery_preference";
            this.delivery_preference.HeaderText = "delivery_preference";
            this.delivery_preference.Name = "delivery_preference";
            this.delivery_preference.Visible = false;
            // 
            // itemsidDataGridViewTextBoxColumn
            // 
            this.itemsidDataGridViewTextBoxColumn.DataPropertyName = "items_id";
            this.itemsidDataGridViewTextBoxColumn.HeaderText = "items_id";
            this.itemsidDataGridViewTextBoxColumn.Name = "itemsidDataGridViewTextBoxColumn";
            this.itemsidDataGridViewTextBoxColumn.Visible = false;
            // 
            // itemsitemidDataGridViewTextBoxColumn
            // 
            this.itemsitemidDataGridViewTextBoxColumn.DataPropertyName = "items_item_id";
            this.itemsitemidDataGridViewTextBoxColumn.HeaderText = "items_item_id";
            this.itemsitemidDataGridViewTextBoxColumn.Name = "itemsitemidDataGridViewTextBoxColumn";
            this.itemsitemidDataGridViewTextBoxColumn.Visible = false;
            // 
            // itemsqtyDataGridViewTextBoxColumn
            // 
            this.itemsqtyDataGridViewTextBoxColumn.DataPropertyName = "items_qty";
            this.itemsqtyDataGridViewTextBoxColumn.HeaderText = "items_qty";
            this.itemsqtyDataGridViewTextBoxColumn.Name = "itemsqtyDataGridViewTextBoxColumn";
            this.itemsqtyDataGridViewTextBoxColumn.Visible = false;
            // 
            // itemsunitofmeasureDataGridViewTextBoxColumn
            // 
            this.itemsunitofmeasureDataGridViewTextBoxColumn.DataPropertyName = "items_unit_of_measure";
            this.itemsunitofmeasureDataGridViewTextBoxColumn.HeaderText = "items_unit_of_measure";
            this.itemsunitofmeasureDataGridViewTextBoxColumn.Name = "itemsunitofmeasureDataGridViewTextBoxColumn";
            this.itemsunitofmeasureDataGridViewTextBoxColumn.Visible = false;
            // 
            // itemsitemcodeDataGridViewTextBoxColumn
            // 
            this.itemsitemcodeDataGridViewTextBoxColumn.DataPropertyName = "items_item_code";
            this.itemsitemcodeDataGridViewTextBoxColumn.HeaderText = "items_item_code";
            this.itemsitemcodeDataGridViewTextBoxColumn.Name = "itemsitemcodeDataGridViewTextBoxColumn";
            this.itemsitemcodeDataGridViewTextBoxColumn.Visible = false;
            // 
            // itemsdescriptionDataGridViewTextBoxColumn
            // 
            this.itemsdescriptionDataGridViewTextBoxColumn.DataPropertyName = "items_description";
            this.itemsdescriptionDataGridViewTextBoxColumn.HeaderText = "items_description";
            this.itemsdescriptionDataGridViewTextBoxColumn.Name = "itemsdescriptionDataGridViewTextBoxColumn";
            this.itemsdescriptionDataGridViewTextBoxColumn.Visible = false;
            // 
            // itemsserialnoDataGridViewTextBoxColumn
            // 
            this.itemsserialnoDataGridViewTextBoxColumn.DataPropertyName = "items_serial_no";
            this.itemsserialnoDataGridViewTextBoxColumn.HeaderText = "items_serial_no";
            this.itemsserialnoDataGridViewTextBoxColumn.Name = "itemsserialnoDataGridViewTextBoxColumn";
            this.itemsserialnoDataGridViewTextBoxColumn.Visible = false;
            // 
            // itemsdeliveryreceiptidDataGridViewTextBoxColumn
            // 
            this.itemsdeliveryreceiptidDataGridViewTextBoxColumn.DataPropertyName = "items_delivery_receipt_id";
            this.itemsdeliveryreceiptidDataGridViewTextBoxColumn.HeaderText = "items_delivery_receipt_id";
            this.itemsdeliveryreceiptidDataGridViewTextBoxColumn.Name = "itemsdeliveryreceiptidDataGridViewTextBoxColumn";
            this.itemsdeliveryreceiptidDataGridViewTextBoxColumn.Visible = false;
            // 
            // dataBindingItem
            // 
            this.dataBindingItem.DataMember = "tbl_dr_items";
            this.dataBindingItem.DataSource = this.ds_dr_item;
            // 
            // ds_dr_item
            // 
            this.ds_dr_item.DataSetName = "NewDataSet";
            this.ds_dr_item.Tables.AddRange(new System.Data.DataTable[] {
            this.tbl_dr_items});
            // 
            // tbl_dr_items
            // 
            this.tbl_dr_items.Columns.AddRange(new System.Data.DataColumn[] {
            this.col1,
            this.col2,
            this.col3,
            this.col4,
            this.col5,
            this.col6,
            this.col7,
            this.col8});
            this.tbl_dr_items.TableName = "tbl_dr_items";
            // 
            // col1
            // 
            this.col1.ColumnName = "items_id";
            // 
            // col2
            // 
            this.col2.ColumnName = "items_item_id";
            // 
            // col3
            // 
            this.col3.ColumnName = "items_qty";
            // 
            // col4
            // 
            this.col4.ColumnName = "items_unit_of_measure";
            // 
            // col5
            // 
            this.col5.ColumnName = "items_item_code";
            // 
            // col6
            // 
            this.col6.ColumnName = "items_description";
            // 
            // col7
            // 
            this.col7.ColumnName = "items_serial_no";
            // 
            // col8
            // 
            this.col8.ColumnName = "items_delivery_receipt_id";
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.Controls.Add(this.pnl_header);
            this.flowLayoutPanel1.Controls.Add(this.pnl_body);
            this.flowLayoutPanel1.Controls.Add(this.pnl_toggle);
            this.flowLayoutPanel1.Controls.Add(this.pnl_footer);
            this.flowLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flowLayoutPanel1.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(1242, 946);
            this.flowLayoutPanel1.TabIndex = 4;
            // 
            // pnl_body
            // 
            this.pnl_body.Controls.Add(this.dg_items);
            this.pnl_body.Location = new System.Drawing.Point(3, 344);
            this.pnl_body.Name = "pnl_body";
            this.pnl_body.Size = new System.Drawing.Size(1236, 200);
            this.pnl_body.TabIndex = 3;
            // 
            // pnl_toggle
            // 
            this.pnl_toggle.Controls.Add(this.btn_toggle);
            this.pnl_toggle.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnl_toggle.Location = new System.Drawing.Point(3, 550);
            this.pnl_toggle.Name = "pnl_toggle";
            this.pnl_toggle.Size = new System.Drawing.Size(1236, 25);
            this.pnl_toggle.TabIndex = 1;
            // 
            // btn_toggle
            // 
            this.btn_toggle.FlatAppearance.BorderSize = 0;
            this.btn_toggle.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_toggle.Location = new System.Drawing.Point(2, 1);
            this.btn_toggle.Name = "btn_toggle";
            this.btn_toggle.Size = new System.Drawing.Size(125, 23);
            this.btn_toggle.TabIndex = 0;
            this.btn_toggle.Text = "DELIVERY COST ";
            this.btn_toggle.UseVisualStyleBackColor = true;
            this.btn_toggle.Click += new System.EventHandler(this.btn_toggle_Click);
            // 
            // ds_dr_file
            // 
            this.ds_dr_file.DataSetName = "NewDataSet";
            this.ds_dr_file.Tables.AddRange(new System.Data.DataTable[] {
            this.dr_file});
            // 
            // dr_file
            // 
            this.dr_file.Columns.AddRange(new System.Data.DataColumn[] {
            this.dataColumn9,
            this.dataColumn10,
            this.dataColumn11,
            this.dataColumn12,
            this.dataColumn13,
            this.dataColumn14,
            this.dataColumn15});
            this.dr_file.TableName = "dr_file";
            // 
            // dataColumn9
            // 
            this.dataColumn9.ColumnName = "id";
            // 
            // dataColumn10
            // 
            this.dataColumn10.ColumnName = "delivery_receipt_id";
            // 
            // dataColumn11
            // 
            this.dataColumn11.ColumnName = "file_name";
            // 
            // dataColumn12
            // 
            this.dataColumn12.ColumnName = "original_name";
            // 
            // dataColumn13
            // 
            this.dataColumn13.ColumnName = "file_path";
            // 
            // dataColumn14
            // 
            this.dataColumn14.ColumnName = "type";
            // 
            // dataColumn15
            // 
            this.dataColumn15.ColumnName = "size";
            // 
            // dataBindingFile
            // 
            this.dataBindingFile.DataMember = "dr_file";
            this.dataBindingFile.DataSource = this.ds_dr_file;
            // 
            // costs_id
            // 
            this.costs_id.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.costs_id.DataPropertyName = "costs_id";
            this.costs_id.HeaderText = "costs_id";
            this.costs_id.Name = "costs_id";
            this.costs_id.Visible = false;
            // 
            // costs_delivery_receipt_id
            // 
            this.costs_delivery_receipt_id.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.costs_delivery_receipt_id.DataPropertyName = "costs_delivery_receipt_id";
            this.costs_delivery_receipt_id.HeaderText = "costs_delivery_receipt_id";
            this.costs_delivery_receipt_id.Name = "costs_delivery_receipt_id";
            this.costs_delivery_receipt_id.Visible = false;
            // 
            // costs_cost_type_id
            // 
            this.costs_cost_type_id.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.costs_cost_type_id.DataPropertyName = "costs_cost_type_id";
            this.costs_cost_type_id.HeaderText = "COST TYPE";
            this.costs_cost_type_id.Name = "costs_cost_type_id";
            this.costs_cost_type_id.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.costs_cost_type_id.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            // 
            // costs_description
            // 
            this.costs_description.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.costs_description.DataPropertyName = "costs_description";
            this.costs_description.HeaderText = "DESCRIPTION";
            this.costs_description.Name = "costs_description";
            // 
            // costs_amount
            // 
            this.costs_amount.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.costs_amount.DataPropertyName = "costs_amount";
            this.costs_amount.HeaderText = "AMOUNT";
            this.costs_amount.Name = "costs_amount";
            // 
            // costs_multiplier
            // 
            this.costs_multiplier.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.costs_multiplier.DataPropertyName = "costs_multiplier";
            this.costs_multiplier.HeaderText = "MULTIPLIER";
            this.costs_multiplier.Name = "costs_multiplier";
            // 
            // costs_total_cost
            // 
            this.costs_total_cost.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.costs_total_cost.DataPropertyName = "costs_total_cost";
            this.costs_total_cost.HeaderText = "TOTAL COST";
            this.costs_total_cost.Name = "costs_total_cost";
            // 
            // DeliveryReceiptUC
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.flowLayoutPanel1);
            this.Name = "DeliveryReceiptUC";
            this.Size = new System.Drawing.Size(1242, 946);
            this.Load += new System.EventHandler(this.DeliveryReceiptUC_Load);
            this.pnl_footer.ResumeLayout(false);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dg_costs)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataBindingCost)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ds_dr_cost)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbl_dr_cost)).EndInit();
            this.pnl_header.ResumeLayout(false);
            this.pnl_header.PerformLayout();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.panel6.ResumeLayout(false);
            this.panel6.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dg_items)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataBindingItem)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ds_dr_item)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbl_dr_items)).EndInit();
            this.flowLayoutPanel1.ResumeLayout(false);
            this.pnl_body.ResumeLayout(false);
            this.pnl_toggle.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.ds_dr_file)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dr_file)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataBindingFile)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.DataGridView dg_items;
        private System.Windows.Forms.Panel pnl_header;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton btn_new;
        private System.Windows.Forms.ToolStripButton btn_search;
        private System.Windows.Forms.ToolStripButton btn_edit;
        private System.Windows.Forms.ToolStripButton btn_delete;
        private System.Windows.Forms.ToolStripButton btn_save;
        private System.Windows.Forms.ToolStripButton btn_close;
        private System.Windows.Forms.ToolStripButton btn_next;
        private System.Windows.Forms.ToolStripButton btn_prev;
        private System.Windows.Forms.Panel pnl_footer;
        private System.Windows.Forms.TextBox txt_ship_via;
        private System.Windows.Forms.TextBox txt_address;
        private System.Windows.Forms.TextBox txt_att;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txt_deliver_to;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox txt_customer_name;
        private System.Windows.Forms.TextBox txt_tin_no;
        private System.Windows.Forms.Label label37;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txt_customer_code;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Panel panel6;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView dg_costs;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.TextBox txt_sales_executive;
        private System.Windows.Forms.TextBox txt_doc_no;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.ToolStripButton btn_print;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.Panel pnl_body;
        private System.Windows.Forms.Panel pnl_toggle;
        private System.Windows.Forms.Button btn_toggle;
        private System.Windows.Forms.DateTimePicker dtp_delivery_date;
        private System.Windows.Forms.DateTimePicker dtp_date;
        private System.Windows.Forms.Label lb_delivery_date;
        private System.Windows.Forms.Label label10;
        private System.Data.DataSet ds_dr_item;
        private System.Data.DataTable tbl_dr_items;
        private System.Data.DataSet ds_dr_cost;
        private System.Data.DataTable tbl_dr_cost;
        private System.Data.DataColumn column1;
        private System.Data.DataColumn column2;
        private System.Data.DataColumn column3;
        private System.Data.DataColumn column4;
        private System.Data.DataColumn column6;
        private System.Data.DataColumn column7;
        private System.Data.DataSet ds_dr_file;
        private System.Data.DataTable dr_file;
        private System.Data.DataColumn dataColumn9;
        private System.Data.DataColumn dataColumn10;
        private System.Data.DataColumn dataColumn11;
        private System.Data.DataColumn dataColumn12;
        private System.Data.DataColumn dataColumn13;
        private System.Data.DataColumn dataColumn14;
        private System.Data.DataColumn dataColumn15;
        private System.Windows.Forms.BindingSource dataBindingItem;
        private System.Windows.Forms.BindingSource dataBindingCost;
        private System.Windows.Forms.BindingSource dataBindingFile;
        private System.Data.DataColumn col1;
        private System.Data.DataColumn col2;
        private System.Data.DataColumn col3;
        private System.Data.DataColumn col4;
        private System.Data.DataColumn col5;
        private System.Data.DataColumn col6;
        private System.Data.DataColumn col7;
        private System.Data.DataColumn col8;
        private System.Data.DataColumn column5;
        private System.Windows.Forms.DataGridViewTextBoxColumn items_item_description;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox txt_id;
        private System.Windows.Forms.TextBox txt_item_release_no;
        private System.Windows.Forms.ComboBox cmb_ship_type_id;
        private System.Windows.Forms.ComboBox cmb_sales_order_id;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.TextBox txt_item_release_id;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TextBox txt_sales_order_id;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.TextBox txt_customer_id;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.TextBox txt_total_cost;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.DataGridViewTextBoxColumn released_qty;
        private System.Windows.Forms.DataGridViewTextBoxColumn released_uom;
        private System.Windows.Forms.DataGridViewTextBoxColumn item_code;
        private System.Windows.Forms.DataGridViewTextBoxColumn item_description;
        private System.Windows.Forms.DataGridViewTextBoxColumn serial_no;
        private System.Windows.Forms.DataGridViewTextBoxColumn id;
        private System.Windows.Forms.DataGridViewTextBoxColumn item_release_id;
        private System.Windows.Forms.DataGridViewTextBoxColumn sales_order_id;
        private System.Windows.Forms.DataGridViewTextBoxColumn sales_order_details_id;
        private System.Windows.Forms.DataGridViewTextBoxColumn item_id;
        private System.Windows.Forms.DataGridViewTextBoxColumn required_qty;
        private System.Windows.Forms.DataGridViewTextBoxColumn required_uom;
        private System.Windows.Forms.DataGridViewTextBoxColumn delivery_preference;
        private System.Windows.Forms.DataGridViewTextBoxColumn itemsidDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn itemsitemidDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn itemsqtyDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn itemsunitofmeasureDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn itemsitemcodeDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn itemsdescriptionDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn itemsserialnoDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn itemsdeliveryreceiptidDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn costs_id;
        private System.Windows.Forms.DataGridViewTextBoxColumn costs_delivery_receipt_id;
        private System.Windows.Forms.DataGridViewComboBoxColumn costs_cost_type_id;
        private System.Windows.Forms.DataGridViewTextBoxColumn costs_description;
        private System.Windows.Forms.DataGridViewTextBoxColumn costs_amount;
        private System.Windows.Forms.DataGridViewTextBoxColumn costs_multiplier;
        private System.Windows.Forms.DataGridViewTextBoxColumn costs_total_cost;
    }
}
