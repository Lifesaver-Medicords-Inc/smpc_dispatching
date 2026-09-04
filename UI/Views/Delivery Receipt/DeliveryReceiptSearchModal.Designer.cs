namespace smpc_dispatching.UI.Views.Delivery_Receipt
{
    partial class DeliveryReceiptSearchModal
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.dgv_results = new System.Windows.Forms.DataGridView();
            this.col_id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_doc_no = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_sales_order = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_customer = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_delivery_date = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_sales_executive = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.label1 = new System.Windows.Forms.Label();
            this.txt_search = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_results)).BeginInit();
            this.flowLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            //
            // dgv_results
            //
            this.dgv_results.AllowUserToAddRows = false;
            this.dgv_results.AllowUserToDeleteRows = false;
            this.dgv_results.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgv_results.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.DisplayedCells;
            this.dgv_results.BackgroundColor = System.Drawing.SystemColors.Control;
            this.dgv_results.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_results.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.col_id,
            this.col_doc_no,
            this.col_sales_order,
            this.col_customer,
            this.col_delivery_date,
            this.col_sales_executive});
            this.dgv_results.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.dgv_results.Location = new System.Drawing.Point(4, 51);
            this.dgv_results.MultiSelect = false;
            this.dgv_results.Name = "dgv_results";
            this.dgv_results.ReadOnly = true;
            this.dgv_results.RowHeadersWidth = 25;
            this.dgv_results.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgv_results.Size = new System.Drawing.Size(792, 280);
            this.dgv_results.TabIndex = 1;
            this.dgv_results.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgv_results_CellContentClick);
            //
            // col_id
            //
            this.col_id.HeaderText = "ID";
            this.col_id.Name = "col_id";
            this.col_id.ReadOnly = true;
            this.col_id.Visible = false;
            //
            // col_doc_no
            //
            this.col_doc_no.HeaderText = "DR#";
            this.col_doc_no.Name = "col_doc_no";
            this.col_doc_no.ReadOnly = true;
            //
            // col_sales_order
            //
            this.col_sales_order.HeaderText = "SALES ORDER";
            this.col_sales_order.Name = "col_sales_order";
            this.col_sales_order.ReadOnly = true;
            //
            // col_customer
            //
            this.col_customer.HeaderText = "CUSTOMER";
            this.col_customer.Name = "col_customer";
            this.col_customer.ReadOnly = true;
            //
            // col_delivery_date
            //
            this.col_delivery_date.HeaderText = "DELIVERY DATE";
            this.col_delivery_date.Name = "col_delivery_date";
            this.col_delivery_date.ReadOnly = true;
            //
            // col_sales_executive
            //
            this.col_sales_executive.HeaderText = "SALES EXECUTIVE";
            this.col_sales_executive.Name = "col_sales_executive";
            this.col_sales_executive.ReadOnly = true;
            //
            // flowLayoutPanel1
            //
            this.flowLayoutPanel1.Controls.Add(this.label1);
            this.flowLayoutPanel1.Controls.Add(this.txt_search);
            this.flowLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(4, 4);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Padding = new System.Windows.Forms.Padding(4);
            this.flowLayoutPanel1.Size = new System.Drawing.Size(792, 41);
            this.flowLayoutPanel1.TabIndex = 2;
            this.flowLayoutPanel1.WrapContents = false;
            //
            // label1
            //
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
            | System.Windows.Forms.AnchorStyles.Left)));
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(7, 9);
            this.label1.Margin = new System.Windows.Forms.Padding(3, 5, 3, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(56, 15);
            this.label1.TabIndex = 0;
            this.label1.Text = "SEARCH";
            //
            // txt_search
            //
            this.txt_search.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txt_search.Dock = System.Windows.Forms.DockStyle.Right;
            this.txt_search.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_search.Location = new System.Drawing.Point(69, 7);
            this.txt_search.Name = "txt_search";
            this.txt_search.Size = new System.Drawing.Size(500, 23);
            this.txt_search.TabIndex = 1;
            this.txt_search.TextChanged += new System.EventHandler(this.txt_search_TextChanged);
            //
            // DeliveryReceiptSearchModal
            //
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 335);
            this.Controls.Add(this.flowLayoutPanel1);
            this.Controls.Add(this.dgv_results);
            this.Name = "DeliveryReceiptSearchModal";
            this.Padding = new System.Windows.Forms.Padding(4);
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Delivery Receipt List";
            ((System.ComponentModel.ISupportInitialize)(this.dgv_results)).EndInit();
            this.flowLayoutPanel1.ResumeLayout(false);
            this.flowLayoutPanel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dgv_results;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txt_search;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_id;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_doc_no;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_sales_order;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_customer;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_delivery_date;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_sales_executive;
    }
}
