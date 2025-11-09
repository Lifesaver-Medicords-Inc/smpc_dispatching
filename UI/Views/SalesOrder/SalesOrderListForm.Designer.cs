namespace smpc_dispatching.UI.Views.SalesOrder {
    partial class SalesOrderListForm {
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent() {
            this.OrderListDataGridView = new System.Windows.Forms.DataGridView();
            this.ID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DocNo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.QuoteRef = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Status = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.QuoteID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.label1 = new System.Windows.Forms.Label();
            this.SerachTextBox = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.OrderListDataGridView)).BeginInit();
            this.flowLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // OrderListDataGridView
            // 
            this.OrderListDataGridView.AllowUserToAddRows = false;
            this.OrderListDataGridView.AllowUserToDeleteRows = false;
            this.OrderListDataGridView.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.OrderListDataGridView.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.DisplayedCells;
            this.OrderListDataGridView.BackgroundColor = System.Drawing.SystemColors.Control;
            this.OrderListDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.OrderListDataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ID,
            this.DocNo,
            this.QuoteRef,
            this.Status,
            this.QuoteID});
            this.OrderListDataGridView.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.OrderListDataGridView.Location = new System.Drawing.Point(4, 51);
            this.OrderListDataGridView.MultiSelect = false;
            this.OrderListDataGridView.Name = "OrderListDataGridView";
            this.OrderListDataGridView.ReadOnly = true;
            this.OrderListDataGridView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.OrderListDataGridView.Size = new System.Drawing.Size(710, 230);
            this.OrderListDataGridView.TabIndex = 1;
            this.OrderListDataGridView.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.OrderListDataGridView_CellContentClick);
            // 
            // ID
            // 
            this.ID.HeaderText = "ORDER ID";
            this.ID.Name = "ID";
            this.ID.ReadOnly = true;
            this.ID.Visible = false;
            // 
            // DocNo
            // 
            this.DocNo.HeaderText = "DOCUMENT NO.";
            this.DocNo.Name = "DocNo";
            this.DocNo.ReadOnly = true;
            // 
            // QuoteRef
            // 
            this.QuoteRef.HeaderText = "QUOTE REF";
            this.QuoteRef.Name = "QuoteRef";
            this.QuoteRef.ReadOnly = true;
            // 
            // Status
            // 
            this.Status.HeaderText = "STATUS";
            this.Status.Name = "Status";
            this.Status.ReadOnly = true;
            // 
            // QuoteID
            // 
            this.QuoteID.HeaderText = "QUOTATION ID";
            this.QuoteID.Name = "QuoteID";
            this.QuoteID.ReadOnly = true;
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.Controls.Add(this.label1);
            this.flowLayoutPanel1.Controls.Add(this.SerachTextBox);
            this.flowLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(4, 4);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Padding = new System.Windows.Forms.Padding(4);
            this.flowLayoutPanel1.Size = new System.Drawing.Size(710, 41);
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
            // SerachTextBox
            // 
            this.SerachTextBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.SerachTextBox.Dock = System.Windows.Forms.DockStyle.Right;
            this.SerachTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.SerachTextBox.Location = new System.Drawing.Point(69, 7);
            this.SerachTextBox.Name = "SerachTextBox";
            this.SerachTextBox.Size = new System.Drawing.Size(418, 23);
            this.SerachTextBox.TabIndex = 1;
            this.SerachTextBox.TextChanged += new System.EventHandler(this.SerachTextBox_TextChanged);
            // 
            // SalesOrderListForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(718, 285);
            this.Controls.Add(this.flowLayoutPanel1);
            this.Controls.Add(this.OrderListDataGridView);
            this.Name = "SalesOrderListForm";
            this.Padding = new System.Windows.Forms.Padding(4);
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.Text = "Order List";
            ((System.ComponentModel.ISupportInitialize)(this.OrderListDataGridView)).EndInit();
            this.flowLayoutPanel1.ResumeLayout(false);
            this.flowLayoutPanel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.DataGridView OrderListDataGridView;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox SerachTextBox;
        private System.Windows.Forms.DataGridViewTextBoxColumn ID;
        private System.Windows.Forms.DataGridViewTextBoxColumn DocNo;
        private System.Windows.Forms.DataGridViewTextBoxColumn QuoteRef;
        private System.Windows.Forms.DataGridViewTextBoxColumn Status;
        private System.Windows.Forms.DataGridViewTextBoxColumn QuoteID;
    }
}