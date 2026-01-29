
namespace smpc_dispatching.UI.Views.Logistics
{
    partial class LogisticsRouteDetailsUC
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(LogisticsRouteDetailsUC));
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.flowLayoutPanel2 = new System.Windows.Forms.FlowLayoutPanel();
            this.label8 = new System.Windows.Forms.Label();
            this.txt_Id = new System.Windows.Forms.TextBox();
            this.lbl_ShipType = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.btn_add_ship_type = new System.Windows.Forms.Button();
            this.cmb_ShipType = new System.Windows.Forms.ComboBox();
            this.lbl_ReferenceDoc = new System.Windows.Forms.Label();
            this.txt_ReferenceDoc = new System.Windows.Forms.TextBox();
            this.lbl_DeliveryReceipt = new System.Windows.Forms.Label();
            this.txt_DeliveryReceipt = new System.Windows.Forms.TextBox();
            this.lbl_SalesInvoice = new System.Windows.Forms.Label();
            this.txt_SalesInvoice = new System.Windows.Forms.TextBox();
            this.lbl_Client = new System.Windows.Forms.Label();
            this.txt_Supplier = new System.Windows.Forms.TextBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.PinMapBtn = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.rtxt_Location = new System.Windows.Forms.RichTextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.rtxt_Notes = new System.Windows.Forms.RichTextBox();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cost_type_id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.description = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.mutltiplier = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.amount = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.receipt = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.flowLayoutPanel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
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
            this.splitContainer1.Panel1.Controls.Add(this.flowLayoutPanel1);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.dataGridView1);
            this.splitContainer1.Size = new System.Drawing.Size(373, 612);
            this.splitContainer1.SplitterDistance = 413;
            this.splitContainer1.TabIndex = 0;
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.Controls.Add(this.flowLayoutPanel2);
            this.flowLayoutPanel1.Controls.Add(this.label8);
            this.flowLayoutPanel1.Controls.Add(this.txt_Id);
            this.flowLayoutPanel1.Controls.Add(this.lbl_ShipType);
            this.flowLayoutPanel1.Controls.Add(this.panel2);
            this.flowLayoutPanel1.Controls.Add(this.lbl_ReferenceDoc);
            this.flowLayoutPanel1.Controls.Add(this.txt_ReferenceDoc);
            this.flowLayoutPanel1.Controls.Add(this.lbl_DeliveryReceipt);
            this.flowLayoutPanel1.Controls.Add(this.txt_DeliveryReceipt);
            this.flowLayoutPanel1.Controls.Add(this.lbl_SalesInvoice);
            this.flowLayoutPanel1.Controls.Add(this.txt_SalesInvoice);
            this.flowLayoutPanel1.Controls.Add(this.lbl_Client);
            this.flowLayoutPanel1.Controls.Add(this.txt_Supplier);
            this.flowLayoutPanel1.Controls.Add(this.panel1);
            this.flowLayoutPanel1.Controls.Add(this.rtxt_Location);
            this.flowLayoutPanel1.Controls.Add(this.label7);
            this.flowLayoutPanel1.Controls.Add(this.rtxt_Notes);
            this.flowLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flowLayoutPanel1.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(373, 413);
            this.flowLayoutPanel1.TabIndex = 1;
            // 
            // flowLayoutPanel2
            // 
            this.flowLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flowLayoutPanel2.Location = new System.Drawing.Point(3, 3);
            this.flowLayoutPanel2.Name = "flowLayoutPanel2";
            this.flowLayoutPanel2.Size = new System.Drawing.Size(367, 0);
            this.flowLayoutPanel2.TabIndex = 0;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(3, 6);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(20, 13);
            this.label8.TabIndex = 18;
            this.label8.Text = "ID";
            // 
            // txt_Id
            // 
            this.txt_Id.Location = new System.Drawing.Point(3, 22);
            this.txt_Id.Name = "txt_Id";
            this.txt_Id.Size = new System.Drawing.Size(100, 20);
            this.txt_Id.TabIndex = 17;
            // 
            // lbl_ShipType
            // 
            this.lbl_ShipType.AutoSize = true;
            this.lbl_ShipType.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_ShipType.Location = new System.Drawing.Point(3, 50);
            this.lbl_ShipType.Margin = new System.Windows.Forms.Padding(3, 5, 3, 0);
            this.lbl_ShipType.Name = "lbl_ShipType";
            this.lbl_ShipType.Size = new System.Drawing.Size(72, 13);
            this.lbl_ShipType.TabIndex = 33;
            this.lbl_ShipType.Text = "SHIP TPYE";
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.btn_add_ship_type);
            this.panel2.Controls.Add(this.cmb_ShipType);
            this.panel2.Location = new System.Drawing.Point(3, 66);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(367, 26);
            this.panel2.TabIndex = 34;
            // 
            // btn_add_ship_type
            // 
            this.btn_add_ship_type.BackColor = System.Drawing.Color.Transparent;
            this.btn_add_ship_type.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btn_add_ship_type.BackgroundImage")));
            this.btn_add_ship_type.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btn_add_ship_type.Location = new System.Drawing.Point(334, 1);
            this.btn_add_ship_type.Name = "btn_add_ship_type";
            this.btn_add_ship_type.Size = new System.Drawing.Size(30, 22);
            this.btn_add_ship_type.TabIndex = 35;
            this.btn_add_ship_type.UseVisualStyleBackColor = false;
            // 
            // cmb_ShipType
            // 
            this.cmb_ShipType.Dock = System.Windows.Forms.DockStyle.Left;
            this.cmb_ShipType.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmb_ShipType.FormattingEnabled = true;
            this.cmb_ShipType.Location = new System.Drawing.Point(0, 0);
            this.cmb_ShipType.Margin = new System.Windows.Forms.Padding(3, 5, 3, 3);
            this.cmb_ShipType.Name = "cmb_ShipType";
            this.cmb_ShipType.Size = new System.Drawing.Size(334, 23);
            this.cmb_ShipType.TabIndex = 4;
            this.cmb_ShipType.Tag = "DYNAMIC";
            // 
            // lbl_ReferenceDoc
            // 
            this.lbl_ReferenceDoc.AutoSize = true;
            this.lbl_ReferenceDoc.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_ReferenceDoc.Location = new System.Drawing.Point(3, 100);
            this.lbl_ReferenceDoc.Margin = new System.Windows.Forms.Padding(3, 5, 3, 0);
            this.lbl_ReferenceDoc.Name = "lbl_ReferenceDoc";
            this.lbl_ReferenceDoc.Size = new System.Drawing.Size(111, 13);
            this.lbl_ReferenceDoc.TabIndex = 31;
            this.lbl_ReferenceDoc.Text = "REFERENCE DOC";
            // 
            // txt_ReferenceDoc
            // 
            this.txt_ReferenceDoc.Location = new System.Drawing.Point(3, 116);
            this.txt_ReferenceDoc.Name = "txt_ReferenceDoc";
            this.txt_ReferenceDoc.Size = new System.Drawing.Size(367, 20);
            this.txt_ReferenceDoc.TabIndex = 32;
            // 
            // lbl_DeliveryReceipt
            // 
            this.lbl_DeliveryReceipt.AutoSize = true;
            this.lbl_DeliveryReceipt.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_DeliveryReceipt.Location = new System.Drawing.Point(3, 144);
            this.lbl_DeliveryReceipt.Margin = new System.Windows.Forms.Padding(3, 5, 3, 0);
            this.lbl_DeliveryReceipt.Name = "lbl_DeliveryReceipt";
            this.lbl_DeliveryReceipt.Size = new System.Drawing.Size(146, 13);
            this.lbl_DeliveryReceipt.TabIndex = 35;
            this.lbl_DeliveryReceipt.Text = "DELIVERY REFERENCE";
            // 
            // txt_DeliveryReceipt
            // 
            this.txt_DeliveryReceipt.Location = new System.Drawing.Point(3, 160);
            this.txt_DeliveryReceipt.Name = "txt_DeliveryReceipt";
            this.txt_DeliveryReceipt.Size = new System.Drawing.Size(367, 20);
            this.txt_DeliveryReceipt.TabIndex = 36;
            // 
            // lbl_SalesInvoice
            // 
            this.lbl_SalesInvoice.AutoSize = true;
            this.lbl_SalesInvoice.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_SalesInvoice.Location = new System.Drawing.Point(3, 188);
            this.lbl_SalesInvoice.Margin = new System.Windows.Forms.Padding(3, 5, 3, 0);
            this.lbl_SalesInvoice.Name = "lbl_SalesInvoice";
            this.lbl_SalesInvoice.Size = new System.Drawing.Size(100, 13);
            this.lbl_SalesInvoice.TabIndex = 37;
            this.lbl_SalesInvoice.Text = "SALES INVOICE";
            // 
            // txt_SalesInvoice
            // 
            this.txt_SalesInvoice.Location = new System.Drawing.Point(3, 204);
            this.txt_SalesInvoice.Name = "txt_SalesInvoice";
            this.txt_SalesInvoice.Size = new System.Drawing.Size(367, 20);
            this.txt_SalesInvoice.TabIndex = 38;
            // 
            // lbl_Client
            // 
            this.lbl_Client.AutoSize = true;
            this.lbl_Client.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_Client.Location = new System.Drawing.Point(3, 232);
            this.lbl_Client.Margin = new System.Windows.Forms.Padding(3, 5, 3, 0);
            this.lbl_Client.Name = "lbl_Client";
            this.lbl_Client.Size = new System.Drawing.Size(118, 13);
            this.lbl_Client.TabIndex = 39;
            this.lbl_Client.Text = "CLIENT/SUPPLIER";
            // 
            // txt_Supplier
            // 
            this.txt_Supplier.Location = new System.Drawing.Point(3, 248);
            this.txt_Supplier.Name = "txt_Supplier";
            this.txt_Supplier.Size = new System.Drawing.Size(367, 20);
            this.txt_Supplier.TabIndex = 40;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.PinMapBtn);
            this.panel1.Controls.Add(this.label5);
            this.panel1.Location = new System.Drawing.Point(3, 274);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(364, 33);
            this.panel1.TabIndex = 42;
            // 
            // PinMapBtn
            // 
            this.PinMapBtn.Location = new System.Drawing.Point(75, 5);
            this.PinMapBtn.Name = "PinMapBtn";
            this.PinMapBtn.Size = new System.Drawing.Size(75, 23);
            this.PinMapBtn.TabIndex = 8;
            this.PinMapBtn.Text = "Pin map";
            this.PinMapBtn.UseVisualStyleBackColor = true;
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
            // rtxt_Location
            // 
            this.rtxt_Location.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.rtxt_Location.Dock = System.Windows.Forms.DockStyle.Left;
            this.rtxt_Location.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rtxt_Location.Location = new System.Drawing.Point(3, 310);
            this.rtxt_Location.Margin = new System.Windows.Forms.Padding(3, 0, 3, 3);
            this.rtxt_Location.Name = "rtxt_Location";
            this.rtxt_Location.Size = new System.Drawing.Size(364, 47);
            this.rtxt_Location.TabIndex = 41;
            this.rtxt_Location.Text = "";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(3, 365);
            this.label7.Margin = new System.Windows.Forms.Padding(3, 5, 3, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(49, 13);
            this.label7.TabIndex = 43;
            this.label7.Text = "NOTES";
            // 
            // rtxt_Notes
            // 
            this.rtxt_Notes.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.rtxt_Notes.Dock = System.Windows.Forms.DockStyle.Left;
            this.rtxt_Notes.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rtxt_Notes.Location = new System.Drawing.Point(376, 5);
            this.rtxt_Notes.Margin = new System.Windows.Forms.Padding(3, 5, 3, 3);
            this.rtxt_Notes.Name = "rtxt_Notes";
            this.rtxt_Notes.Size = new System.Drawing.Size(373, 64);
            this.rtxt_Notes.TabIndex = 44;
            this.rtxt_Notes.Text = "";
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.id,
            this.cost_type_id,
            this.description,
            this.mutltiplier,
            this.amount,
            this.receipt});
            this.dataGridView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView1.Location = new System.Drawing.Point(0, 0);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(373, 195);
            this.dataGridView1.TabIndex = 0;
            // 
            // id
            // 
            this.id.HeaderText = "id";
            this.id.Name = "id";
            this.id.Width = 25;
            // 
            // cost_type_id
            // 
            this.cost_type_id.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.cost_type_id.HeaderText = "COST TYPE";
            this.cost_type_id.Name = "cost_type_id";
            // 
            // description
            // 
            this.description.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.description.HeaderText = "DESCRIPTION";
            this.description.Name = "description";
            // 
            // mutltiplier
            // 
            this.mutltiplier.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.mutltiplier.HeaderText = "MULTIPLIER";
            this.mutltiplier.Name = "mutltiplier";
            // 
            // amount
            // 
            this.amount.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.amount.HeaderText = "AMOUNT";
            this.amount.Name = "amount";
            // 
            // receipt
            // 
            this.receipt.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.receipt.HeaderText = "RECEIPT";
            this.receipt.Name = "receipt";
            // 
            // LogisticsRouteDetailsUC
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.splitContainer1);
            this.Name = "LogisticsRouteDetailsUC";
            this.Size = new System.Drawing.Size(373, 612);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.flowLayoutPanel1.ResumeLayout(false);
            this.flowLayoutPanel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel2;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox txt_Id;
        private System.Windows.Forms.Label lbl_ReferenceDoc;
        private System.Windows.Forms.TextBox txt_ReferenceDoc;
        private System.Windows.Forms.Label lbl_ShipType;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button btn_add_ship_type;
        private System.Windows.Forms.ComboBox cmb_ShipType;
        private System.Windows.Forms.Label lbl_DeliveryReceipt;
        private System.Windows.Forms.TextBox txt_DeliveryReceipt;
        private System.Windows.Forms.Label lbl_SalesInvoice;
        private System.Windows.Forms.TextBox txt_SalesInvoice;
        private System.Windows.Forms.Label lbl_Client;
        private System.Windows.Forms.TextBox txt_Supplier;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button PinMapBtn;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.RichTextBox rtxt_Location;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.RichTextBox rtxt_Notes;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.DataGridViewTextBoxColumn id;
        private System.Windows.Forms.DataGridViewTextBoxColumn cost_type_id;
        private System.Windows.Forms.DataGridViewTextBoxColumn description;
        private System.Windows.Forms.DataGridViewTextBoxColumn mutltiplier;
        private System.Windows.Forms.DataGridViewTextBoxColumn amount;
        private System.Windows.Forms.DataGridViewTextBoxColumn receipt;
    }
}
