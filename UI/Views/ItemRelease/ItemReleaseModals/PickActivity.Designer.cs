
namespace smpc_dispatching.UI.Views.ItemRelease.ItemReleaseModals
{
    partial class PickActivity
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.txt_search = new System.Windows.Forms.TextBox();
            this.pnl_dgv = new System.Windows.Forms.Panel();
            this.dgv_item = new System.Windows.Forms.DataGridView();
            this.pnl_footer = new System.Windows.Forms.Panel();
            this.btn_save = new System.Windows.Forms.Button();
            this.Selected = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.ReleaseQty = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ReleaseUom = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.StockQty = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.StockUom = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.BinLocation = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.BinId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.WarehouseId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ITEMID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.pnl_dgv.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_item)).BeginInit();
            this.pnl_footer.SuspendLayout();
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
            this.splitContainer1.Panel1.Controls.Add(this.txt_search);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.pnl_dgv);
            this.splitContainer1.Panel2.Controls.Add(this.pnl_footer);
            this.splitContainer1.Size = new System.Drawing.Size(800, 450);
            this.splitContainer1.SplitterDistance = 25;
            this.splitContainer1.TabIndex = 1;
            // 
            // txt_search
            // 
            this.txt_search.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txt_search.Location = new System.Drawing.Point(0, 0);
            this.txt_search.Name = "txt_search";
            this.txt_search.Size = new System.Drawing.Size(800, 20);
            this.txt_search.TabIndex = 0;
            this.txt_search.Text = "Item List Search...";
            // 
            // pnl_dgv
            // 
            this.pnl_dgv.Controls.Add(this.dgv_item);
            this.pnl_dgv.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnl_dgv.Location = new System.Drawing.Point(0, 0);
            this.pnl_dgv.Name = "pnl_dgv";
            this.pnl_dgv.Size = new System.Drawing.Size(800, 377);
            this.pnl_dgv.TabIndex = 0;
            // 
            // dgv_item
            // 
            this.dgv_item.AllowUserToAddRows = false;
            this.dgv_item.AllowUserToDeleteRows = false;
            this.dgv_item.AllowUserToResizeColumns = false;
            this.dgv_item.AllowUserToResizeRows = false;
            this.dgv_item.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgv_item.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgv_item.ColumnHeadersHeight = 50;
            this.dgv_item.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dgv_item.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Selected,
            this.ReleaseQty,
            this.ReleaseUom,
            this.StockQty,
            this.StockUom,
            this.BinLocation,
            this.BinId,
            this.WarehouseId,
            this.ITEMID});
            this.dgv_item.EnableHeadersVisualStyles = false;
            this.dgv_item.Location = new System.Drawing.Point(0, 0);
            this.dgv_item.Name = "dgv_item";
            this.dgv_item.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgv_item.Size = new System.Drawing.Size(800, 421);
            this.dgv_item.TabIndex = 5;
            this.dgv_item.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgv_item_CellEndEdit);
            // 
            // pnl_footer
            // 
            this.pnl_footer.Controls.Add(this.btn_save);
            this.pnl_footer.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnl_footer.Location = new System.Drawing.Point(0, 377);
            this.pnl_footer.Name = "pnl_footer";
            this.pnl_footer.Size = new System.Drawing.Size(800, 44);
            this.pnl_footer.TabIndex = 6;
            // 
            // btn_save
            // 
            this.btn_save.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_save.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(217)))), ((int)(((byte)(234)))), ((int)(((byte)(211)))));
            this.btn_save.Location = new System.Drawing.Point(677, 11);
            this.btn_save.Name = "btn_save";
            this.btn_save.Size = new System.Drawing.Size(111, 23);
            this.btn_save.TabIndex = 39;
            this.btn_save.Text = "SAVE";
            this.btn_save.UseVisualStyleBackColor = false;
            this.btn_save.Click += new System.EventHandler(this.btn_save_Click);
            // 
            // Selected
            // 
            this.Selected.HeaderText = "SELECTED";
            this.Selected.Name = "Selected";
            this.Selected.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.Selected.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            // 
            // ReleaseQty
            // 
            this.ReleaseQty.DataPropertyName = "ReleaseQty";
            this.ReleaseQty.HeaderText = "QTY";
            this.ReleaseQty.Name = "ReleaseQty";
            // 
            // ReleaseUom
            // 
            this.ReleaseUom.DataPropertyName = "ReleaseUom";
            this.ReleaseUom.HeaderText = "UOM";
            this.ReleaseUom.Name = "ReleaseUom";
            // 
            // StockQty
            // 
            this.StockQty.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.StockQty.DataPropertyName = "StockQty";
            this.StockQty.HeaderText = "QTY";
            this.StockQty.Name = "StockQty";
            this.StockQty.ReadOnly = true;
            // 
            // StockUom
            // 
            this.StockUom.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.StockUom.DataPropertyName = "StockUom";
            this.StockUom.HeaderText = "UOM";
            this.StockUom.Name = "StockUom";
            this.StockUom.ReadOnly = true;
            // 
            // BinLocation
            // 
            this.BinLocation.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.BinLocation.DataPropertyName = "BinLocation";
            this.BinLocation.HeaderText = "BIN LOCATION";
            this.BinLocation.Name = "BinLocation";
            this.BinLocation.ReadOnly = true;
            // 
            // BinId
            // 
            this.BinId.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.BinId.DataPropertyName = "BinId";
            this.BinId.HeaderText = "BIN ID";
            this.BinId.Name = "BinId";
            this.BinId.ReadOnly = true;
            this.BinId.Visible = false;
            // 
            // WarehouseId
            // 
            this.WarehouseId.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.WarehouseId.DataPropertyName = "WarehouseId";
            this.WarehouseId.HeaderText = "WAREHOUSEID";
            this.WarehouseId.Name = "WarehouseId";
            this.WarehouseId.ReadOnly = true;
            this.WarehouseId.Visible = false;
            // 
            // ITEMID
            // 
            this.ITEMID.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.ITEMID.DataPropertyName = "ITEMID";
            this.ITEMID.HeaderText = "ITEMID";
            this.ITEMID.Name = "ITEMID";
            this.ITEMID.ReadOnly = true;
            this.ITEMID.Visible = false;
            // 
            // PickActivity
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.splitContainer1);
            this.Name = "PickActivity";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "PickActivity";
            this.Load += new System.EventHandler(this.PickActivity_Load);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel1.PerformLayout();
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.pnl_dgv.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgv_item)).EndInit();
            this.pnl_footer.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.TextBox txt_search;
        private System.Windows.Forms.DataGridView dgv_item;
        private System.Windows.Forms.Panel pnl_dgv;
        private System.Windows.Forms.Panel pnl_footer;
        private System.Windows.Forms.Button btn_save;
        private System.Windows.Forms.DataGridViewCheckBoxColumn Selected;
        private System.Windows.Forms.DataGridViewTextBoxColumn ReleaseQty;
        private System.Windows.Forms.DataGridViewTextBoxColumn ReleaseUom;
        private System.Windows.Forms.DataGridViewTextBoxColumn StockQty;
        private System.Windows.Forms.DataGridViewTextBoxColumn StockUom;
        private System.Windows.Forms.DataGridViewTextBoxColumn BinLocation;
        private System.Windows.Forms.DataGridViewTextBoxColumn BinId;
        private System.Windows.Forms.DataGridViewTextBoxColumn WarehouseId;
        private System.Windows.Forms.DataGridViewTextBoxColumn ITEMID;
    }
}