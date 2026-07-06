namespace smpc_dispatching.UI.Views.Logistics
{
    partial class LogisticsCalendarScheduleDetailsUC
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

        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(LogisticsCalendarScheduleDetailsUC));
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.btn_new = new System.Windows.Forms.ToolStripButton();
            this.btn_edit = new System.Windows.Forms.ToolStripButton();
            this.btn_delete = new System.Windows.Forms.ToolStripButton();
            this.btn_save = new System.Windows.Forms.ToolStripButton();
            this.btn_close = new System.Windows.Forms.ToolStripButton();
            this.btn_toggle = new System.Windows.Forms.ToolStripButton();
            this.pnl_header_title = new System.Windows.Forms.Panel();
            this.lbl_title = new System.Windows.Forms.Label();
            this.lbl_type_indicator = new System.Windows.Forms.Label();
            this.pnl_root = new System.Windows.Forms.Panel();
            this.flowLayoutPanel_fields = new System.Windows.Forms.FlowLayoutPanel();
            this.lbl_id = new System.Windows.Forms.Label();
            this.txt_Id = new System.Windows.Forms.TextBox();
            this.lbl_start_date = new System.Windows.Forms.Label();
            this.dtp_StartDate = new System.Windows.Forms.DateTimePicker();
            this.lbl_end_date = new System.Windows.Forms.Label();
            this.dtp_EndDate = new System.Windows.Forms.DateTimePicker();
            this.lbl_people = new System.Windows.Forms.Label();
            this.cmb_People = new System.Windows.Forms.ComboBox();
            this.lbl_vehicle = new System.Windows.Forms.Label();
            this.pnl_vehicle = new System.Windows.Forms.Panel();
            this.btn_add_vehicle = new System.Windows.Forms.Button();
            this.cmb_Vehicle = new System.Windows.Forms.ComboBox();
            this.lbl_category = new System.Windows.Forms.Label();
            this.pnl_category = new System.Windows.Forms.Panel();
            this.btn_add_category = new System.Windows.Forms.Button();
            this.cmb_Category = new System.Windows.Forms.ComboBox();
            this.lbl_reference_doc_no = new System.Windows.Forms.Label();
            this.cmb_ReferenceDocNo = new System.Windows.Forms.ComboBox();
            this.lbl_delivery_receipt_doc_no = new System.Windows.Forms.Label();
            this.txt_DeliveryReceiptDocNo = new System.Windows.Forms.TextBox();
            this.lbl_sales_invoice_doc_no = new System.Windows.Forms.Label();
            this.txt_SalesInvoiceDocNo = new System.Windows.Forms.TextBox();
            this.lbl_client_supplier = new System.Windows.Forms.Label();
            this.cmb_ClientSupplier = new System.Windows.Forms.ComboBox();
            this.lbl_courier = new System.Windows.Forms.Label();
            this.txt_Courier = new System.Windows.Forms.TextBox();
            this.lbl_pickup_time = new System.Windows.Forms.Label();
            this.txt_PickupTime = new System.Windows.Forms.TextBox();
            this.lbl_arrival_time = new System.Windows.Forms.Label();
            this.txt_ArrivalTime = new System.Windows.Forms.TextBox();
            this.btn_add_route = new System.Windows.Forms.LinkLabel();
            this.flowLayoutPanel_routes = new System.Windows.Forms.FlowLayoutPanel();
            this.lbl_notes = new System.Windows.Forms.Label();
            this.txt_Notes = new System.Windows.Forms.TextBox();
            this.lbl_trucking = new System.Windows.Forms.Label();
            this.txt_Trucking = new System.Windows.Forms.TextBox();
            this.lbl_driver_name = new System.Windows.Forms.Label();
            this.txt_DriverName = new System.Windows.Forms.TextBox();
            this.toolStrip1.SuspendLayout();
            this.pnl_header_title.SuspendLayout();
            this.pnl_root.SuspendLayout();
            this.flowLayoutPanel_fields.SuspendLayout();
            this.pnl_vehicle.SuspendLayout();
            this.pnl_category.SuspendLayout();
            this.SuspendLayout();
            // 
            // toolStrip1
            // 
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btn_new,
            this.btn_edit,
            this.btn_delete,
            this.btn_save,
            this.btn_close,
            this.btn_toggle});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(375, 25);
            this.toolStrip1.TabIndex = 0;
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
            this.btn_delete.Click += new System.EventHandler(this.btn_delete_Click);
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
            // btn_toggle
            // 
            this.btn_toggle.Image = ((System.Drawing.Image)(resources.GetObject("btn_toggle.Image")));
            this.btn_toggle.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btn_toggle.Name = "btn_toggle";
            this.btn_toggle.Size = new System.Drawing.Size(147, 22);
            this.btn_toggle.Text = "SWITCH TO EXTERNAL";
            this.btn_toggle.Click += new System.EventHandler(this.btn_toggle_Click);
            // 
            // pnl_header_title
            // 
            this.pnl_header_title.Controls.Add(this.lbl_title);
            this.pnl_header_title.Controls.Add(this.lbl_type_indicator);
            this.pnl_header_title.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnl_header_title.Location = new System.Drawing.Point(0, 25);
            this.pnl_header_title.Name = "pnl_header_title";
            this.pnl_header_title.Size = new System.Drawing.Size(375, 32);
            this.pnl_header_title.TabIndex = 1;
            // 
            // lbl_title
            // 
            this.lbl_title.AutoSize = true;
            this.lbl_title.Dock = System.Windows.Forms.DockStyle.Left;
            this.lbl_title.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_title.Location = new System.Drawing.Point(0, 0);
            this.lbl_title.Name = "lbl_title";
            this.lbl_title.Padding = new System.Windows.Forms.Padding(10, 10, 0, 5);
            this.lbl_title.Size = new System.Drawing.Size(169, 32);
            this.lbl_title.TabIndex = 1;
            this.lbl_title.Text = "SCHEDULE DETAILS";
            // 
            // lbl_type_indicator
            // 
            this.lbl_type_indicator.Dock = System.Windows.Forms.DockStyle.Right;
            this.lbl_type_indicator.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_type_indicator.ForeColor = System.Drawing.Color.SeaGreen;
            this.lbl_type_indicator.Location = new System.Drawing.Point(225, 0);
            this.lbl_type_indicator.Name = "lbl_type_indicator";
            this.lbl_type_indicator.Size = new System.Drawing.Size(150, 32);
            this.lbl_type_indicator.TabIndex = 2;
            this.lbl_type_indicator.Text = "INTERNAL";
            this.lbl_type_indicator.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // pnl_root
            // 
            this.pnl_root.AutoScroll = true;
            this.pnl_root.Controls.Add(this.flowLayoutPanel_fields);
            this.pnl_root.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnl_root.Location = new System.Drawing.Point(0, 57);
            this.pnl_root.Name = "pnl_root";
            this.pnl_root.Padding = new System.Windows.Forms.Padding(10);
            this.pnl_root.Size = new System.Drawing.Size(375, 643);
            this.pnl_root.TabIndex = 2;
            // 
            // flowLayoutPanel_fields
            // 
            this.flowLayoutPanel_fields.AutoSize = true;
            this.flowLayoutPanel_fields.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.flowLayoutPanel_fields.Controls.Add(this.lbl_id);
            this.flowLayoutPanel_fields.Controls.Add(this.txt_Id);
            this.flowLayoutPanel_fields.Controls.Add(this.lbl_start_date);
            this.flowLayoutPanel_fields.Controls.Add(this.dtp_StartDate);
            this.flowLayoutPanel_fields.Controls.Add(this.lbl_end_date);
            this.flowLayoutPanel_fields.Controls.Add(this.dtp_EndDate);
            this.flowLayoutPanel_fields.Controls.Add(this.lbl_people);
            this.flowLayoutPanel_fields.Controls.Add(this.cmb_People);
            this.flowLayoutPanel_fields.Controls.Add(this.lbl_vehicle);
            this.flowLayoutPanel_fields.Controls.Add(this.pnl_vehicle);
            this.flowLayoutPanel_fields.Controls.Add(this.lbl_category);
            this.flowLayoutPanel_fields.Controls.Add(this.pnl_category);
            this.flowLayoutPanel_fields.Controls.Add(this.lbl_reference_doc_no);
            this.flowLayoutPanel_fields.Controls.Add(this.cmb_ReferenceDocNo);
            this.flowLayoutPanel_fields.Controls.Add(this.lbl_delivery_receipt_doc_no);
            this.flowLayoutPanel_fields.Controls.Add(this.txt_DeliveryReceiptDocNo);
            this.flowLayoutPanel_fields.Controls.Add(this.lbl_sales_invoice_doc_no);
            this.flowLayoutPanel_fields.Controls.Add(this.txt_SalesInvoiceDocNo);
            this.flowLayoutPanel_fields.Controls.Add(this.lbl_client_supplier);
            this.flowLayoutPanel_fields.Controls.Add(this.cmb_ClientSupplier);
            this.flowLayoutPanel_fields.Controls.Add(this.lbl_courier);
            this.flowLayoutPanel_fields.Controls.Add(this.txt_Courier);
            this.flowLayoutPanel_fields.Controls.Add(this.lbl_pickup_time);
            this.flowLayoutPanel_fields.Controls.Add(this.txt_PickupTime);
            this.flowLayoutPanel_fields.Controls.Add(this.lbl_arrival_time);
            this.flowLayoutPanel_fields.Controls.Add(this.txt_ArrivalTime);
            this.flowLayoutPanel_fields.Controls.Add(this.btn_add_route);
            this.flowLayoutPanel_fields.Controls.Add(this.flowLayoutPanel_routes);
            this.flowLayoutPanel_fields.Controls.Add(this.lbl_notes);
            this.flowLayoutPanel_fields.Controls.Add(this.txt_Notes);
            this.flowLayoutPanel_fields.Dock = System.Windows.Forms.DockStyle.Top;
            this.flowLayoutPanel_fields.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.flowLayoutPanel_fields.Location = new System.Drawing.Point(10, 10);
            this.flowLayoutPanel_fields.Name = "flowLayoutPanel_fields";
            this.flowLayoutPanel_fields.Size = new System.Drawing.Size(338, 691);
            this.flowLayoutPanel_fields.TabIndex = 0;
            this.flowLayoutPanel_fields.WrapContents = false;
            // 
            // lbl_id
            // 
            this.lbl_id.AutoSize = true;
            this.lbl_id.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_id.Location = new System.Drawing.Point(3, 0);
            this.lbl_id.Name = "lbl_id";
            this.lbl_id.Size = new System.Drawing.Size(20, 13);
            this.lbl_id.TabIndex = 0;
            this.lbl_id.Text = "ID";
            this.lbl_id.Visible = false;
            // 
            // txt_Id
            // 
            this.txt_Id.Location = new System.Drawing.Point(3, 13);
            this.txt_Id.Margin = new System.Windows.Forms.Padding(3, 0, 3, 10);
            this.txt_Id.Name = "txt_Id";
            this.txt_Id.ReadOnly = true;
            this.txt_Id.Size = new System.Drawing.Size(300, 20);
            this.txt_Id.TabIndex = 1;
            this.txt_Id.Visible = false;
            // 
            // lbl_start_date
            // 
            this.lbl_start_date.AutoSize = true;
            this.lbl_start_date.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_start_date.Location = new System.Drawing.Point(3, 43);
            this.lbl_start_date.Name = "lbl_start_date";
            this.lbl_start_date.Size = new System.Drawing.Size(104, 13);
            this.lbl_start_date.TabIndex = 2;
            this.lbl_start_date.Text = "DATE AND TIME";
            // 
            // dtp_StartDate
            // 
            this.dtp_StartDate.CustomFormat = "MM/dd/yyyy hh:mm tt";
            this.dtp_StartDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtp_StartDate.Location = new System.Drawing.Point(3, 56);
            this.dtp_StartDate.Margin = new System.Windows.Forms.Padding(3, 0, 3, 10);
            this.dtp_StartDate.Name = "dtp_StartDate";
            this.dtp_StartDate.Size = new System.Drawing.Size(300, 20);
            this.dtp_StartDate.TabIndex = 3;
            // 
            // lbl_end_date
            // 
            this.lbl_end_date.AutoSize = true;
            this.lbl_end_date.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_end_date.Location = new System.Drawing.Point(3, 86);
            this.lbl_end_date.Name = "lbl_end_date";
            this.lbl_end_date.Size = new System.Drawing.Size(70, 13);
            this.lbl_end_date.TabIndex = 4;
            this.lbl_end_date.Text = "END DATE";
            // 
            // dtp_EndDate
            // 
            this.dtp_EndDate.CustomFormat = "MM/dd/yyyy hh:mm tt";
            this.dtp_EndDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtp_EndDate.Location = new System.Drawing.Point(3, 99);
            this.dtp_EndDate.Margin = new System.Windows.Forms.Padding(3, 0, 3, 10);
            this.dtp_EndDate.Name = "dtp_EndDate";
            this.dtp_EndDate.Size = new System.Drawing.Size(300, 20);
            this.dtp_EndDate.TabIndex = 5;
            // 
            // lbl_people
            // 
            this.lbl_people.AutoSize = true;
            this.lbl_people.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_people.Location = new System.Drawing.Point(3, 129);
            this.lbl_people.Name = "lbl_people";
            this.lbl_people.Size = new System.Drawing.Size(55, 13);
            this.lbl_people.TabIndex = 8;
            this.lbl_people.Text = "PEOPLE";
            // 
            // cmb_People
            // 
            this.cmb_People.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cmb_People.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cmb_People.FormattingEnabled = true;
            this.cmb_People.Location = new System.Drawing.Point(3, 142);
            this.cmb_People.Margin = new System.Windows.Forms.Padding(3, 0, 3, 10);
            this.cmb_People.Name = "cmb_People";
            this.cmb_People.Size = new System.Drawing.Size(300, 21);
            this.cmb_People.TabIndex = 9;
            // 
            // lbl_vehicle
            // 
            this.lbl_vehicle.AutoSize = true;
            this.lbl_vehicle.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_vehicle.Location = new System.Drawing.Point(3, 173);
            this.lbl_vehicle.Name = "lbl_vehicle";
            this.lbl_vehicle.Size = new System.Drawing.Size(59, 13);
            this.lbl_vehicle.TabIndex = 10;
            this.lbl_vehicle.Text = "VEHICLE";
            // 
            // pnl_vehicle
            // 
            this.pnl_vehicle.Controls.Add(this.btn_add_vehicle);
            this.pnl_vehicle.Controls.Add(this.cmb_Vehicle);
            this.pnl_vehicle.Location = new System.Drawing.Point(3, 186);
            this.pnl_vehicle.Margin = new System.Windows.Forms.Padding(3, 0, 3, 10);
            this.pnl_vehicle.Name = "pnl_vehicle";
            this.pnl_vehicle.Size = new System.Drawing.Size(300, 26);
            this.pnl_vehicle.TabIndex = 11;
            // 
            // btn_add_vehicle
            // 
            this.btn_add_vehicle.BackColor = System.Drawing.Color.Transparent;
            this.btn_add_vehicle.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btn_add_vehicle.BackgroundImage")));
            this.btn_add_vehicle.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btn_add_vehicle.Location = new System.Drawing.Point(270, 1);
            this.btn_add_vehicle.Name = "btn_add_vehicle";
            this.btn_add_vehicle.Size = new System.Drawing.Size(30, 22);
            this.btn_add_vehicle.TabIndex = 1;
            this.btn_add_vehicle.UseVisualStyleBackColor = false;
            this.btn_add_vehicle.Click += new System.EventHandler(this.btn_add_vehicle_Click);
            // 
            // cmb_Vehicle
            // 
            this.cmb_Vehicle.Dock = System.Windows.Forms.DockStyle.Left;
            this.cmb_Vehicle.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmb_Vehicle.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmb_Vehicle.FormattingEnabled = true;
            this.cmb_Vehicle.Location = new System.Drawing.Point(0, 0);
            this.cmb_Vehicle.Name = "cmb_Vehicle";
            this.cmb_Vehicle.Size = new System.Drawing.Size(264, 23);
            this.cmb_Vehicle.TabIndex = 0;
            this.cmb_Vehicle.Tag = "DYNAMIC";
            // 
            // lbl_category
            // 
            this.lbl_category.AutoSize = true;
            this.lbl_category.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_category.Location = new System.Drawing.Point(3, 222);
            this.lbl_category.Name = "lbl_category";
            this.lbl_category.Size = new System.Drawing.Size(74, 13);
            this.lbl_category.TabIndex = 6;
            this.lbl_category.Text = "CATEGORY";
            // 
            // pnl_category
            // 
            this.pnl_category.Controls.Add(this.btn_add_category);
            this.pnl_category.Controls.Add(this.cmb_Category);
            this.pnl_category.Location = new System.Drawing.Point(3, 235);
            this.pnl_category.Margin = new System.Windows.Forms.Padding(3, 0, 3, 10);
            this.pnl_category.Name = "pnl_category";
            this.pnl_category.Size = new System.Drawing.Size(300, 26);
            this.pnl_category.TabIndex = 7;
            // 
            // btn_add_category
            // 
            this.btn_add_category.BackColor = System.Drawing.Color.Transparent;
            this.btn_add_category.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btn_add_category.BackgroundImage")));
            this.btn_add_category.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btn_add_category.Location = new System.Drawing.Point(270, 1);
            this.btn_add_category.Name = "btn_add_category";
            this.btn_add_category.Size = new System.Drawing.Size(30, 22);
            this.btn_add_category.TabIndex = 1;
            this.btn_add_category.UseVisualStyleBackColor = false;
            this.btn_add_category.Click += new System.EventHandler(this.btn_add_category_Click);
            // 
            // cmb_Category
            // 
            this.cmb_Category.Dock = System.Windows.Forms.DockStyle.Left;
            this.cmb_Category.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmb_Category.FormattingEnabled = true;
            this.cmb_Category.Location = new System.Drawing.Point(0, 0);
            this.cmb_Category.Name = "cmb_Category";
            this.cmb_Category.Size = new System.Drawing.Size(264, 21);
            this.cmb_Category.TabIndex = 0;
            // 
            // lbl_reference_doc_no
            // 
            this.lbl_reference_doc_no.AutoSize = true;
            this.lbl_reference_doc_no.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_reference_doc_no.Location = new System.Drawing.Point(3, 271);
            this.lbl_reference_doc_no.Name = "lbl_reference_doc_no";
            this.lbl_reference_doc_no.Size = new System.Drawing.Size(137, 13);
            this.lbl_reference_doc_no.TabIndex = 24;
            this.lbl_reference_doc_no.Text = "REFERENCE DOC NO.";
            // 
            // cmb_ReferenceDocNo
            // 
            this.cmb_ReferenceDocNo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmb_ReferenceDocNo.FormattingEnabled = true;
            this.cmb_ReferenceDocNo.Location = new System.Drawing.Point(3, 284);
            this.cmb_ReferenceDocNo.Margin = new System.Windows.Forms.Padding(3, 0, 3, 10);
            this.cmb_ReferenceDocNo.Name = "cmb_ReferenceDocNo";
            this.cmb_ReferenceDocNo.Size = new System.Drawing.Size(300, 21);
            this.cmb_ReferenceDocNo.TabIndex = 25;
            // 
            // lbl_delivery_receipt_doc_no
            // 
            this.lbl_delivery_receipt_doc_no.AutoSize = true;
            this.lbl_delivery_receipt_doc_no.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_delivery_receipt_doc_no.Location = new System.Drawing.Point(3, 315);
            this.lbl_delivery_receipt_doc_no.Name = "lbl_delivery_receipt_doc_no";
            this.lbl_delivery_receipt_doc_no.Size = new System.Drawing.Size(181, 13);
            this.lbl_delivery_receipt_doc_no.TabIndex = 28;
            this.lbl_delivery_receipt_doc_no.Text = "DELIVERY RECEIPT DOC NO.";
            // 
            // txt_DeliveryReceiptDocNo
            // 
            this.txt_DeliveryReceiptDocNo.Location = new System.Drawing.Point(3, 328);
            this.txt_DeliveryReceiptDocNo.Margin = new System.Windows.Forms.Padding(3, 0, 3, 10);
            this.txt_DeliveryReceiptDocNo.Name = "txt_DeliveryReceiptDocNo";
            this.txt_DeliveryReceiptDocNo.Size = new System.Drawing.Size(300, 20);
            this.txt_DeliveryReceiptDocNo.TabIndex = 29;
            // 
            // lbl_sales_invoice_doc_no
            // 
            this.lbl_sales_invoice_doc_no.AutoSize = true;
            this.lbl_sales_invoice_doc_no.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_sales_invoice_doc_no.Location = new System.Drawing.Point(3, 358);
            this.lbl_sales_invoice_doc_no.Name = "lbl_sales_invoice_doc_no";
            this.lbl_sales_invoice_doc_no.Size = new System.Drawing.Size(156, 13);
            this.lbl_sales_invoice_doc_no.TabIndex = 26;
            this.lbl_sales_invoice_doc_no.Text = "SALES INVOICE DOC NO.";
            // 
            // txt_SalesInvoiceDocNo
            // 
            this.txt_SalesInvoiceDocNo.Location = new System.Drawing.Point(3, 371);
            this.txt_SalesInvoiceDocNo.Margin = new System.Windows.Forms.Padding(3, 0, 3, 10);
            this.txt_SalesInvoiceDocNo.Name = "txt_SalesInvoiceDocNo";
            this.txt_SalesInvoiceDocNo.Size = new System.Drawing.Size(300, 20);
            this.txt_SalesInvoiceDocNo.TabIndex = 27;
            // 
            // lbl_client_supplier
            // 
            this.lbl_client_supplier.AutoSize = true;
            this.lbl_client_supplier.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_client_supplier.Location = new System.Drawing.Point(3, 401);
            this.lbl_client_supplier.Name = "lbl_client_supplier";
            this.lbl_client_supplier.Size = new System.Drawing.Size(118, 13);
            this.lbl_client_supplier.TabIndex = 12;
            this.lbl_client_supplier.Text = "CLIENT/SUPPLIER";
            // 
            // cmb_ClientSupplier
            // 
            this.cmb_ClientSupplier.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmb_ClientSupplier.FormattingEnabled = true;
            this.cmb_ClientSupplier.Location = new System.Drawing.Point(3, 414);
            this.cmb_ClientSupplier.Margin = new System.Windows.Forms.Padding(3, 0, 3, 10);
            this.cmb_ClientSupplier.Name = "cmb_ClientSupplier";
            this.cmb_ClientSupplier.Size = new System.Drawing.Size(300, 21);
            this.cmb_ClientSupplier.TabIndex = 13;
            // 
            // lbl_courier
            // 
            this.lbl_courier.AutoSize = true;
            this.lbl_courier.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_courier.Location = new System.Drawing.Point(3, 445);
            this.lbl_courier.Name = "lbl_courier";
            this.lbl_courier.Size = new System.Drawing.Size(63, 13);
            this.lbl_courier.TabIndex = 16;
            this.lbl_courier.Text = "COURIER";
            // 
            // txt_Courier
            // 
            this.txt_Courier.Location = new System.Drawing.Point(3, 458);
            this.txt_Courier.Margin = new System.Windows.Forms.Padding(3, 0, 3, 10);
            this.txt_Courier.Name = "txt_Courier";
            this.txt_Courier.Size = new System.Drawing.Size(300, 20);
            this.txt_Courier.TabIndex = 17;
            // 
            // lbl_pickup_time
            // 
            this.lbl_pickup_time.AutoSize = true;
            this.lbl_pickup_time.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_pickup_time.Location = new System.Drawing.Point(3, 488);
            this.lbl_pickup_time.Name = "lbl_pickup_time";
            this.lbl_pickup_time.Size = new System.Drawing.Size(86, 13);
            this.lbl_pickup_time.TabIndex = 20;
            this.lbl_pickup_time.Text = "PICKUP TIME";
            // 
            // txt_PickupTime
            // 
            this.txt_PickupTime.Location = new System.Drawing.Point(3, 501);
            this.txt_PickupTime.Margin = new System.Windows.Forms.Padding(3, 0, 3, 10);
            this.txt_PickupTime.Name = "txt_PickupTime";
            this.txt_PickupTime.Size = new System.Drawing.Size(300, 20);
            this.txt_PickupTime.TabIndex = 21;
            // 
            // lbl_arrival_time
            // 
            this.lbl_arrival_time.AutoSize = true;
            this.lbl_arrival_time.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_arrival_time.Location = new System.Drawing.Point(3, 531);
            this.lbl_arrival_time.Name = "lbl_arrival_time";
            this.lbl_arrival_time.Size = new System.Drawing.Size(94, 13);
            this.lbl_arrival_time.TabIndex = 22;
            this.lbl_arrival_time.Text = "ARRIVAL TIME";
            // 
            // txt_ArrivalTime
            // 
            this.txt_ArrivalTime.Location = new System.Drawing.Point(3, 544);
            this.txt_ArrivalTime.Margin = new System.Windows.Forms.Padding(3, 0, 3, 10);
            this.txt_ArrivalTime.Name = "txt_ArrivalTime";
            this.txt_ArrivalTime.Size = new System.Drawing.Size(300, 20);
            this.txt_ArrivalTime.TabIndex = 23;
            // 
            // btn_add_route
            // 
            this.btn_add_route.AutoSize = true;
            this.btn_add_route.BackColor = System.Drawing.Color.LightSteelBlue;
            this.btn_add_route.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_add_route.LinkBehavior = System.Windows.Forms.LinkBehavior.NeverUnderline;
            this.btn_add_route.LinkColor = System.Drawing.Color.Navy;
            this.btn_add_route.Location = new System.Drawing.Point(3, 574);
            this.btn_add_route.Margin = new System.Windows.Forms.Padding(3, 0, 3, 6);
            this.btn_add_route.Name = "btn_add_route";
            this.btn_add_route.Padding = new System.Windows.Forms.Padding(12, 6, 12, 6);
            this.btn_add_route.Size = new System.Drawing.Size(85, 25);
            this.btn_add_route.TabIndex = 30;
            this.btn_add_route.TabStop = true;
            this.btn_add_route.Text = "+ ROUTE";
            this.btn_add_route.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.btn_add_route.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.btn_add_route_LinkClicked);
            // 
            // flowLayoutPanel_routes
            // 
            this.flowLayoutPanel_routes.AutoSize = true;
            this.flowLayoutPanel_routes.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.flowLayoutPanel_routes.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.flowLayoutPanel_routes.Location = new System.Drawing.Point(3, 605);
            this.flowLayoutPanel_routes.Margin = new System.Windows.Forms.Padding(3, 0, 3, 10);
            this.flowLayoutPanel_routes.Name = "flowLayoutPanel_routes";
            this.flowLayoutPanel_routes.Size = new System.Drawing.Size(0, 0);
            this.flowLayoutPanel_routes.TabIndex = 31;
            this.flowLayoutPanel_routes.WrapContents = false;
            // 
            // lbl_notes
            // 
            this.lbl_notes.AutoSize = true;
            this.lbl_notes.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_notes.Location = new System.Drawing.Point(3, 615);
            this.lbl_notes.Name = "lbl_notes";
            this.lbl_notes.Size = new System.Drawing.Size(49, 13);
            this.lbl_notes.TabIndex = 32;
            this.lbl_notes.Text = "NOTES";
            // 
            // txt_Notes
            // 
            this.txt_Notes.Location = new System.Drawing.Point(3, 628);
            this.txt_Notes.Margin = new System.Windows.Forms.Padding(3, 0, 3, 3);
            this.txt_Notes.Multiline = true;
            this.txt_Notes.Name = "txt_Notes";
            this.txt_Notes.Size = new System.Drawing.Size(300, 60);
            this.txt_Notes.TabIndex = 33;
            // 
            // lbl_trucking
            // 
            this.lbl_trucking.AutoSize = true;
            this.lbl_trucking.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_trucking.Location = new System.Drawing.Point(3, 314);
            this.lbl_trucking.Name = "lbl_trucking";
            this.lbl_trucking.Size = new System.Drawing.Size(71, 13);
            this.lbl_trucking.TabIndex = 14;
            this.lbl_trucking.Text = "TRUCKING";
            // 
            // txt_Trucking
            // 
            this.txt_Trucking.Location = new System.Drawing.Point(3, 327);
            this.txt_Trucking.Margin = new System.Windows.Forms.Padding(3, 0, 3, 10);
            this.txt_Trucking.Name = "txt_Trucking";
            this.txt_Trucking.Size = new System.Drawing.Size(300, 20);
            this.txt_Trucking.TabIndex = 15;
            // 
            // lbl_driver_name
            // 
            this.lbl_driver_name.AutoSize = true;
            this.lbl_driver_name.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_driver_name.Location = new System.Drawing.Point(3, 400);
            this.lbl_driver_name.Name = "lbl_driver_name";
            this.lbl_driver_name.Size = new System.Drawing.Size(93, 13);
            this.lbl_driver_name.TabIndex = 18;
            this.lbl_driver_name.Text = "DRIVER NAME";
            // 
            // txt_DriverName
            // 
            this.txt_DriverName.Location = new System.Drawing.Point(3, 413);
            this.txt_DriverName.Margin = new System.Windows.Forms.Padding(3, 0, 3, 10);
            this.txt_DriverName.Name = "txt_DriverName";
            this.txt_DriverName.Size = new System.Drawing.Size(300, 20);
            this.txt_DriverName.TabIndex = 19;
            // 
            // LogisticsCalendarScheduleDetailsUC
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.pnl_root);
            this.Controls.Add(this.pnl_header_title);
            this.Controls.Add(this.toolStrip1);
            this.Name = "LogisticsCalendarScheduleDetailsUC";
            this.Size = new System.Drawing.Size(375, 700);
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.pnl_header_title.ResumeLayout(false);
            this.pnl_header_title.PerformLayout();
            this.pnl_root.ResumeLayout(false);
            this.pnl_root.PerformLayout();
            this.flowLayoutPanel_fields.ResumeLayout(false);
            this.flowLayoutPanel_fields.PerformLayout();
            this.pnl_vehicle.ResumeLayout(false);
            this.pnl_category.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton btn_new;
        private System.Windows.Forms.ToolStripButton btn_edit;
        private System.Windows.Forms.ToolStripButton btn_delete;
        private System.Windows.Forms.ToolStripButton btn_save;
        private System.Windows.Forms.ToolStripButton btn_close;
        private System.Windows.Forms.ToolStripButton btn_toggle;
        private System.Windows.Forms.Panel pnl_header_title;
        private System.Windows.Forms.Label lbl_title;
        private System.Windows.Forms.Label lbl_type_indicator;
        private System.Windows.Forms.Panel pnl_root;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel_fields;
        private System.Windows.Forms.Label lbl_id;
        private System.Windows.Forms.TextBox txt_Id;
        private System.Windows.Forms.Label lbl_start_date;
        private System.Windows.Forms.DateTimePicker dtp_StartDate;
        private System.Windows.Forms.Label lbl_end_date;
        private System.Windows.Forms.DateTimePicker dtp_EndDate;
        private System.Windows.Forms.Label lbl_category;
        private System.Windows.Forms.Panel pnl_category;
        private System.Windows.Forms.Button btn_add_category;
        private System.Windows.Forms.ComboBox cmb_Category;
        private System.Windows.Forms.Label lbl_people;
        private System.Windows.Forms.ComboBox cmb_People;
        private System.Windows.Forms.Label lbl_vehicle;
        private System.Windows.Forms.Panel pnl_vehicle;
        private System.Windows.Forms.Button btn_add_vehicle;
        private System.Windows.Forms.ComboBox cmb_Vehicle;
        private System.Windows.Forms.Label lbl_client_supplier;
        private System.Windows.Forms.ComboBox cmb_ClientSupplier;
        private System.Windows.Forms.Label lbl_trucking;
        private System.Windows.Forms.TextBox txt_Trucking;
        private System.Windows.Forms.Label lbl_courier;
        private System.Windows.Forms.TextBox txt_Courier;
        private System.Windows.Forms.Label lbl_driver_name;
        private System.Windows.Forms.TextBox txt_DriverName;
        private System.Windows.Forms.Label lbl_pickup_time;
        private System.Windows.Forms.TextBox txt_PickupTime;
        private System.Windows.Forms.Label lbl_arrival_time;
        private System.Windows.Forms.TextBox txt_ArrivalTime;
        private System.Windows.Forms.Label lbl_reference_doc_no;
        private System.Windows.Forms.ComboBox cmb_ReferenceDocNo;
        private System.Windows.Forms.Label lbl_sales_invoice_doc_no;
        private System.Windows.Forms.TextBox txt_SalesInvoiceDocNo;
        private System.Windows.Forms.Label lbl_delivery_receipt_doc_no;
        private System.Windows.Forms.TextBox txt_DeliveryReceiptDocNo;
        private System.Windows.Forms.LinkLabel btn_add_route;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel_routes;
        private System.Windows.Forms.Label lbl_notes;
        private System.Windows.Forms.TextBox txt_Notes;
    }
}
