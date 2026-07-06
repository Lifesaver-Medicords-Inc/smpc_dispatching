namespace smpc_dispatching.UI.Views.Logistics {
    partial class LogisticsRoutePanelUC {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing) {
            if (disposing && (components != null)) {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        private void InitializeComponent() {
            this.lbl_header = new System.Windows.Forms.Label();
            this.lbl_ship_type = new System.Windows.Forms.Label();
            this.cmb_ship_type = new System.Windows.Forms.ComboBox();
            this.lbl_reference_doc = new System.Windows.Forms.Label();
            this.txt_reference_doc = new System.Windows.Forms.TextBox();
            this.lbl_delivery_receipt = new System.Windows.Forms.Label();
            this.txt_delivery_receipt = new System.Windows.Forms.TextBox();
            this.lbl_sales_invoice = new System.Windows.Forms.Label();
            this.txt_sales_invoice = new System.Windows.Forms.TextBox();
            this.lbl_departed = new System.Windows.Forms.Label();
            this.dtp_departed = new System.Windows.Forms.DateTimePicker();
            this.lbl_arrived = new System.Windows.Forms.Label();
            this.dtp_arrived = new System.Windows.Forms.DateTimePicker();
            this.lbl_returned = new System.Windows.Forms.Label();
            this.dtp_returned = new System.Windows.Forms.DateTimePicker();
            this.lbl_client_supplier = new System.Windows.Forms.Label();
            this.cmb_client_supplier = new System.Windows.Forms.ComboBox();
            this.lbl_location = new System.Windows.Forms.Label();
            this.lbl_receiver = new System.Windows.Forms.Label();
            this.txt_receiver = new System.Windows.Forms.TextBox();
            this.lbl_contact_no = new System.Windows.Forms.Label();
            this.txt_contact_no = new System.Windows.Forms.TextBox();
            this.lbl_notes = new System.Windows.Forms.Label();
            this.txt_notes = new System.Windows.Forms.TextBox();
            this.dg_costs = new System.Windows.Forms.DataGridView();
            this.col_cost_type = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_description = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_multiplier = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_amount = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_receipt = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btn_add_cost = new System.Windows.Forms.LinkLabel();
            this.pnl_divider = new System.Windows.Forms.Panel();
            this.txt_location = new System.Windows.Forms.TextBox();
            this.btn_pin_location = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dg_costs)).BeginInit();
            this.SuspendLayout();
            // 
            // lbl_header
            // 
            this.lbl_header.AutoSize = true;
            this.lbl_header.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_header.Location = new System.Drawing.Point(10, 8);
            this.lbl_header.Name = "lbl_header";
            this.lbl_header.Size = new System.Drawing.Size(80, 16);
            this.lbl_header.TabIndex = 0;
            this.lbl_header.Text = "ROUTE #1";
            // 
            // lbl_ship_type
            // 
            this.lbl_ship_type.AutoSize = true;
            this.lbl_ship_type.Location = new System.Drawing.Point(52, 36);
            this.lbl_ship_type.Name = "lbl_ship_type";
            this.lbl_ship_type.Size = new System.Drawing.Size(63, 13);
            this.lbl_ship_type.TabIndex = 2;
            this.lbl_ship_type.Text = "SHIP TYPE";
            // 
            // cmb_ship_type
            // 
            this.cmb_ship_type.FormattingEnabled = true;
            this.cmb_ship_type.Location = new System.Drawing.Point(121, 33);
            this.cmb_ship_type.Name = "cmb_ship_type";
            this.cmb_ship_type.Size = new System.Drawing.Size(153, 21);
            this.cmb_ship_type.TabIndex = 3;
            // 
            // lbl_reference_doc
            // 
            this.lbl_reference_doc.AutoSize = true;
            this.lbl_reference_doc.Location = new System.Drawing.Point(18, 92);
            this.lbl_reference_doc.Name = "lbl_reference_doc";
            this.lbl_reference_doc.Size = new System.Drawing.Size(98, 13);
            this.lbl_reference_doc.TabIndex = 4;
            this.lbl_reference_doc.Text = "REFERENCE DOC";
            // 
            // txt_reference_doc
            // 
            this.txt_reference_doc.Location = new System.Drawing.Point(123, 88);
            this.txt_reference_doc.Name = "txt_reference_doc";
            this.txt_reference_doc.Size = new System.Drawing.Size(150, 20);
            this.txt_reference_doc.TabIndex = 5;
            // 
            // lbl_delivery_receipt
            // 
            this.lbl_delivery_receipt.AutoSize = true;
            this.lbl_delivery_receipt.Location = new System.Drawing.Point(10, 64);
            this.lbl_delivery_receipt.Name = "lbl_delivery_receipt";
            this.lbl_delivery_receipt.Size = new System.Drawing.Size(109, 13);
            this.lbl_delivery_receipt.TabIndex = 6;
            this.lbl_delivery_receipt.Text = "DELIVERY RECEIPT";
            // 
            // txt_delivery_receipt
            // 
            this.txt_delivery_receipt.Location = new System.Drawing.Point(123, 61);
            this.txt_delivery_receipt.Name = "txt_delivery_receipt";
            this.txt_delivery_receipt.Size = new System.Drawing.Size(151, 20);
            this.txt_delivery_receipt.TabIndex = 7;
            // 
            // lbl_sales_invoice
            // 
            this.lbl_sales_invoice.AutoSize = true;
            this.lbl_sales_invoice.Location = new System.Drawing.Point(34, 122);
            this.lbl_sales_invoice.Name = "lbl_sales_invoice";
            this.lbl_sales_invoice.Size = new System.Drawing.Size(87, 13);
            this.lbl_sales_invoice.TabIndex = 8;
            this.lbl_sales_invoice.Text = "SALES INVOICE";
            // 
            // txt_sales_invoice
            // 
            this.txt_sales_invoice.Location = new System.Drawing.Point(124, 119);
            this.txt_sales_invoice.Name = "txt_sales_invoice";
            this.txt_sales_invoice.Size = new System.Drawing.Size(150, 20);
            this.txt_sales_invoice.TabIndex = 9;
            // 
            // lbl_departed
            // 
            this.lbl_departed.AutoSize = true;
            this.lbl_departed.Location = new System.Drawing.Point(307, 35);
            this.lbl_departed.Name = "lbl_departed";
            this.lbl_departed.Size = new System.Drawing.Size(66, 13);
            this.lbl_departed.TabIndex = 10;
            this.lbl_departed.Text = "DEPARTED";
            //
            // dtp_departed
            //
            this.dtp_departed.Format = System.Windows.Forms.DateTimePickerFormat.Time;
            this.dtp_departed.ShowUpDown = true;
            this.dtp_departed.Location = new System.Drawing.Point(377, 32);
            this.dtp_departed.Name = "dtp_departed";
            this.dtp_departed.Size = new System.Drawing.Size(90, 20);
            this.dtp_departed.TabIndex = 11;
            // 
            // lbl_arrived
            // 
            this.lbl_arrived.AutoSize = true;
            this.lbl_arrived.Location = new System.Drawing.Point(316, 63);
            this.lbl_arrived.Name = "lbl_arrived";
            this.lbl_arrived.Size = new System.Drawing.Size(55, 13);
            this.lbl_arrived.TabIndex = 12;
            this.lbl_arrived.Text = "ARRIVED";
            //
            // dtp_arrived
            //
            this.dtp_arrived.Format = System.Windows.Forms.DateTimePickerFormat.Time;
            this.dtp_arrived.ShowUpDown = true;
            this.dtp_arrived.Location = new System.Drawing.Point(377, 60);
            this.dtp_arrived.Name = "dtp_arrived";
            this.dtp_arrived.Size = new System.Drawing.Size(90, 20);
            this.dtp_arrived.TabIndex = 13;
            // 
            // lbl_returned
            // 
            this.lbl_returned.AutoSize = true;
            this.lbl_returned.Location = new System.Drawing.Point(307, 91);
            this.lbl_returned.Name = "lbl_returned";
            this.lbl_returned.Size = new System.Drawing.Size(68, 13);
            this.lbl_returned.TabIndex = 14;
            this.lbl_returned.Text = "RETURNED";
            //
            // dtp_returned
            //
            this.dtp_returned.Format = System.Windows.Forms.DateTimePickerFormat.Time;
            this.dtp_returned.ShowUpDown = true;
            this.dtp_returned.Location = new System.Drawing.Point(377, 88);
            this.dtp_returned.Name = "dtp_returned";
            this.dtp_returned.Size = new System.Drawing.Size(90, 20);
            this.dtp_returned.TabIndex = 15;
            // 
            // lbl_client_supplier
            // 
            this.lbl_client_supplier.AutoSize = true;
            this.lbl_client_supplier.Location = new System.Drawing.Point(13, 158);
            this.lbl_client_supplier.Name = "lbl_client_supplier";
            this.lbl_client_supplier.Size = new System.Drawing.Size(103, 13);
            this.lbl_client_supplier.TabIndex = 16;
            this.lbl_client_supplier.Text = "CLIENT/SUPPLIER";
            //
            // cmb_client_supplier
            //
            this.cmb_client_supplier.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmb_client_supplier.FormattingEnabled = true;
            this.cmb_client_supplier.Location = new System.Drawing.Point(121, 155);
            this.cmb_client_supplier.Name = "cmb_client_supplier";
            this.cmb_client_supplier.Size = new System.Drawing.Size(472, 21);
            this.cmb_client_supplier.TabIndex = 17;
            // 
            // lbl_location
            // 
            this.lbl_location.AutoSize = true;
            this.lbl_location.Location = new System.Drawing.Point(55, 203);
            this.lbl_location.Name = "lbl_location";
            this.lbl_location.Size = new System.Drawing.Size(61, 13);
            this.lbl_location.TabIndex = 18;
            this.lbl_location.Text = "LOCATION";
            // 
            // lbl_receiver
            // 
            this.lbl_receiver.AutoSize = true;
            this.lbl_receiver.Location = new System.Drawing.Point(54, 233);
            this.lbl_receiver.Name = "lbl_receiver";
            this.lbl_receiver.Size = new System.Drawing.Size(61, 13);
            this.lbl_receiver.TabIndex = 20;
            this.lbl_receiver.Text = "RECEIVER";
            // 
            // txt_receiver
            // 
            this.txt_receiver.Location = new System.Drawing.Point(121, 230);
            this.txt_receiver.Name = "txt_receiver";
            this.txt_receiver.Size = new System.Drawing.Size(280, 20);
            this.txt_receiver.TabIndex = 21;
            // 
            // lbl_contact_no
            // 
            this.lbl_contact_no.AutoSize = true;
            this.lbl_contact_no.Location = new System.Drawing.Point(407, 233);
            this.lbl_contact_no.Name = "lbl_contact_no";
            this.lbl_contact_no.Size = new System.Drawing.Size(80, 13);
            this.lbl_contact_no.TabIndex = 22;
            this.lbl_contact_no.Text = "CONTACT NO.";
            // 
            // txt_contact_no
            // 
            this.txt_contact_no.Location = new System.Drawing.Point(493, 230);
            this.txt_contact_no.Name = "txt_contact_no";
            this.txt_contact_no.Size = new System.Drawing.Size(168, 20);
            this.txt_contact_no.TabIndex = 23;
            // 
            // lbl_notes
            // 
            this.lbl_notes.AutoSize = true;
            this.lbl_notes.Location = new System.Drawing.Point(71, 263);
            this.lbl_notes.Name = "lbl_notes";
            this.lbl_notes.Size = new System.Drawing.Size(44, 13);
            this.lbl_notes.TabIndex = 24;
            this.lbl_notes.Text = "NOTES";
            // 
            // txt_notes
            // 
            this.txt_notes.Location = new System.Drawing.Point(121, 260);
            this.txt_notes.Multiline = true;
            this.txt_notes.Name = "txt_notes";
            this.txt_notes.Size = new System.Drawing.Size(540, 36);
            this.txt_notes.TabIndex = 25;
            // 
            // dg_costs
            // 
            this.dg_costs.AllowUserToAddRows = false;
            this.dg_costs.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dg_costs.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.col_cost_type,
            this.col_description,
            this.col_multiplier,
            this.col_amount,
            this.col_receipt});
            this.dg_costs.EnableHeadersVisualStyles = false;
            this.dg_costs.Location = new System.Drawing.Point(10, 335);
            this.dg_costs.Name = "dg_costs";
            this.dg_costs.RowHeadersVisible = false;
            this.dg_costs.Size = new System.Drawing.Size(651, 128);
            this.dg_costs.TabIndex = 26;
            // 
            // col_cost_type
            // 
            this.col_cost_type.HeaderText = "COST TYPE";
            this.col_cost_type.Name = "col_cost_type";
            // 
            // col_description
            // 
            this.col_description.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.col_description.HeaderText = "DESCRIPTION";
            this.col_description.MinimumWidth = 130;
            this.col_description.Name = "col_description";
            // 
            // col_multiplier
            // 
            this.col_multiplier.HeaderText = "MULTIPLIER";
            this.col_multiplier.Name = "col_multiplier";
            this.col_multiplier.Width = 80;
            // 
            // col_amount
            // 
            this.col_amount.HeaderText = "AMOUNT";
            this.col_amount.Name = "col_amount";
            this.col_amount.Width = 80;
            // 
            // col_receipt
            // 
            this.col_receipt.HeaderText = "RECEIPT";
            this.col_receipt.Name = "col_receipt";
            this.col_receipt.Width = 60;
            // 
            // btn_add_cost
            // 
            this.btn_add_cost.AutoSize = true;
            this.btn_add_cost.Location = new System.Drawing.Point(10, 480);
            this.btn_add_cost.Name = "btn_add_cost";
            this.btn_add_cost.Size = new System.Drawing.Size(68, 13);
            this.btn_add_cost.TabIndex = 27;
            this.btn_add_cost.TabStop = true;
            this.btn_add_cost.Text = "+ADD COST";
            this.btn_add_cost.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.btn_add_cost_LinkClicked);
            // 
            // pnl_divider
            // 
            this.pnl_divider.BackColor = System.Drawing.Color.Gainsboro;
            this.pnl_divider.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnl_divider.Location = new System.Drawing.Point(0, 505);
            this.pnl_divider.Name = "pnl_divider";
            this.pnl_divider.Size = new System.Drawing.Size(681, 2);
            this.pnl_divider.TabIndex = 28;
            // 
            // txt_location
            // 
            this.txt_location.Location = new System.Drawing.Point(121, 188);
            this.txt_location.Multiline = true;
            this.txt_location.Name = "txt_location";
            this.txt_location.Size = new System.Drawing.Size(472, 36);
            this.txt_location.TabIndex = 29;
            // 
            // btn_pin_location
            // 
            this.btn_pin_location.Location = new System.Drawing.Point(599, 188);
            this.btn_pin_location.Name = "btn_pin_location";
            this.btn_pin_location.Size = new System.Drawing.Size(62, 18);
            this.btn_pin_location.TabIndex = 30;
            this.btn_pin_location.Text = "PIN MAP";
            this.btn_pin_location.UseVisualStyleBackColor = true;
            this.btn_pin_location.Click += new System.EventHandler(this.btn_pin_location_Click);
            // 
            // LogisticsRoutePanelUC
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.btn_pin_location);
            this.Controls.Add(this.txt_location);
            this.Controls.Add(this.pnl_divider);
            this.Controls.Add(this.btn_add_cost);
            this.Controls.Add(this.dg_costs);
            this.Controls.Add(this.txt_notes);
            this.Controls.Add(this.lbl_notes);
            this.Controls.Add(this.txt_contact_no);
            this.Controls.Add(this.lbl_contact_no);
            this.Controls.Add(this.txt_receiver);
            this.Controls.Add(this.lbl_receiver);
            this.Controls.Add(this.lbl_location);
            this.Controls.Add(this.cmb_client_supplier);
            this.Controls.Add(this.lbl_client_supplier);
            this.Controls.Add(this.dtp_returned);
            this.Controls.Add(this.lbl_returned);
            this.Controls.Add(this.dtp_arrived);
            this.Controls.Add(this.lbl_arrived);
            this.Controls.Add(this.dtp_departed);
            this.Controls.Add(this.lbl_departed);
            this.Controls.Add(this.txt_sales_invoice);
            this.Controls.Add(this.lbl_sales_invoice);
            this.Controls.Add(this.txt_delivery_receipt);
            this.Controls.Add(this.lbl_delivery_receipt);
            this.Controls.Add(this.txt_reference_doc);
            this.Controls.Add(this.lbl_reference_doc);
            this.Controls.Add(this.cmb_ship_type);
            this.Controls.Add(this.lbl_ship_type);
            this.Controls.Add(this.lbl_header);
            this.Name = "LogisticsRoutePanelUC";
            this.Size = new System.Drawing.Size(681, 507);
            ((System.ComponentModel.ISupportInitialize)(this.dg_costs)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lbl_header;
        private System.Windows.Forms.Label lbl_ship_type;
        private System.Windows.Forms.ComboBox cmb_ship_type;
        private System.Windows.Forms.Label lbl_reference_doc;
        private System.Windows.Forms.TextBox txt_reference_doc;
        private System.Windows.Forms.Label lbl_delivery_receipt;
        private System.Windows.Forms.TextBox txt_delivery_receipt;
        private System.Windows.Forms.Label lbl_sales_invoice;
        private System.Windows.Forms.TextBox txt_sales_invoice;
        private System.Windows.Forms.Label lbl_departed;
        private System.Windows.Forms.DateTimePicker dtp_departed;
        private System.Windows.Forms.Label lbl_arrived;
        private System.Windows.Forms.DateTimePicker dtp_arrived;
        private System.Windows.Forms.Label lbl_returned;
        private System.Windows.Forms.DateTimePicker dtp_returned;
        private System.Windows.Forms.Label lbl_client_supplier;
        private System.Windows.Forms.ComboBox cmb_client_supplier;
        private System.Windows.Forms.Label lbl_location;
        private System.Windows.Forms.Label lbl_receiver;
        private System.Windows.Forms.TextBox txt_receiver;
        private System.Windows.Forms.Label lbl_contact_no;
        private System.Windows.Forms.TextBox txt_contact_no;
        private System.Windows.Forms.Label lbl_notes;
        private System.Windows.Forms.TextBox txt_notes;
        private System.Windows.Forms.DataGridView dg_costs;
        private System.Windows.Forms.LinkLabel btn_add_cost;
        private System.Windows.Forms.Panel pnl_divider;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_cost_type;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_description;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_multiplier;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_amount;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_receipt;
        private System.Windows.Forms.TextBox txt_location;
        private System.Windows.Forms.Button btn_pin_location;
    }
}
