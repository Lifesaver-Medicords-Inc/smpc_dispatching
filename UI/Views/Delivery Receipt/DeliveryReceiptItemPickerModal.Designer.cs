namespace smpc_dispatching.UI.Views.Delivery_Receipt
{
    partial class DeliveryReceiptItemPickerModal
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

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            this.dgv_items = new System.Windows.Forms.DataGridView();
            this.col_select = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.col_item_code = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_item_description = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_released = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_delivered = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_remaining = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_qty = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_uom = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_serial_no = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.pnl_top = new System.Windows.Forms.Panel();
            this.btn_clear_all = new System.Windows.Forms.Button();
            this.btn_select_all = new System.Windows.Forms.Button();
            this.lbl_instruction = new System.Windows.Forms.Label();
            this.pnl_bottom = new System.Windows.Forms.Panel();
            this.lbl_hint = new System.Windows.Forms.Label();
            this.btn_cancel = new System.Windows.Forms.Button();
            this.btn_ok = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_items)).BeginInit();
            this.pnl_top.SuspendLayout();
            this.pnl_bottom.SuspendLayout();
            this.SuspendLayout();
            //
            // dgv_items
            //
            this.dgv_items.AllowUserToAddRows = false;
            this.dgv_items.AllowUserToDeleteRows = false;
            this.dgv_items.AllowUserToResizeRows = false;
            this.dgv_items.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgv_items.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dgv_items.BackgroundColor = System.Drawing.SystemColors.Control;
            this.dgv_items.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_items.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.col_select,
            this.col_item_code,
            this.col_item_description,
            this.col_released,
            this.col_delivered,
            this.col_remaining,
            this.col_qty,
            this.col_uom,
            this.col_serial_no});
            this.dgv_items.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgv_items.Location = new System.Drawing.Point(4, 45);
            this.dgv_items.MultiSelect = false;
            this.dgv_items.Name = "dgv_items";
            this.dgv_items.RowHeadersWidth = 25;
            this.dgv_items.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.dgv_items.Size = new System.Drawing.Size(912, 340);
            this.dgv_items.TabIndex = 0;
            //
            // col_select
            //
            this.col_select.HeaderText = "";
            this.col_select.Name = "col_select";
            this.col_select.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.col_select.Width = 34;
            //
            // col_item_code
            //
            this.col_item_code.HeaderText = "ITEM CODE";
            this.col_item_code.Name = "col_item_code";
            this.col_item_code.ReadOnly = true;
            this.col_item_code.FillWeight = 110F;
            //
            // col_item_description
            //
            this.col_item_description.HeaderText = "DESCRIPTION";
            this.col_item_description.Name = "col_item_description";
            this.col_item_description.ReadOnly = true;
            this.col_item_description.FillWeight = 230F;
            //
            // col_released
            //
            this.col_released.HeaderText = "RELEASED";
            this.col_released.Name = "col_released";
            this.col_released.ReadOnly = true;
            this.col_released.FillWeight = 70F;
            //
            // col_delivered
            //
            this.col_delivered.HeaderText = "ALREADY DELIVERED";
            this.col_delivered.Name = "col_delivered";
            this.col_delivered.ReadOnly = true;
            this.col_delivered.FillWeight = 95F;
            //
            // col_remaining
            //
            this.col_remaining.HeaderText = "REMAINING";
            this.col_remaining.Name = "col_remaining";
            this.col_remaining.ReadOnly = true;
            this.col_remaining.FillWeight = 75F;
            //
            // col_qty
            //
            this.col_qty.HeaderText = "DELIVER NOW";
            this.col_qty.Name = "col_qty";
            this.col_qty.ReadOnly = false;
            this.col_qty.FillWeight = 85F;
            //
            // col_uom
            //
            this.col_uom.HeaderText = "UOM";
            this.col_uom.Name = "col_uom";
            this.col_uom.ReadOnly = true;
            this.col_uom.FillWeight = 60F;
            //
            // col_serial_no
            //
            this.col_serial_no.HeaderText = "SERIAL NO.";
            this.col_serial_no.Name = "col_serial_no";
            this.col_serial_no.ReadOnly = true;
            this.col_serial_no.FillWeight = 110F;
            //
            // pnl_top
            //
            this.pnl_top.Controls.Add(this.btn_clear_all);
            this.pnl_top.Controls.Add(this.btn_select_all);
            this.pnl_top.Controls.Add(this.lbl_instruction);
            this.pnl_top.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnl_top.Location = new System.Drawing.Point(4, 4);
            this.pnl_top.Name = "pnl_top";
            this.pnl_top.Size = new System.Drawing.Size(912, 41);
            this.pnl_top.TabIndex = 1;
            //
            // btn_clear_all
            //
            this.btn_clear_all.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_clear_all.Location = new System.Drawing.Point(798, 8);
            this.btn_clear_all.Name = "btn_clear_all";
            this.btn_clear_all.Size = new System.Drawing.Size(100, 25);
            this.btn_clear_all.TabIndex = 2;
            this.btn_clear_all.Text = "CLEAR ALL";
            this.btn_clear_all.UseVisualStyleBackColor = true;
            //
            // btn_select_all
            //
            this.btn_select_all.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_select_all.Location = new System.Drawing.Point(692, 8);
            this.btn_select_all.Name = "btn_select_all";
            this.btn_select_all.Size = new System.Drawing.Size(100, 25);
            this.btn_select_all.TabIndex = 1;
            this.btn_select_all.Text = "SELECT ALL";
            this.btn_select_all.UseVisualStyleBackColor = true;
            //
            // lbl_instruction
            //
            this.lbl_instruction.AutoSize = true;
            this.lbl_instruction.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_instruction.Location = new System.Drawing.Point(8, 13);
            this.lbl_instruction.Name = "lbl_instruction";
            this.lbl_instruction.Size = new System.Drawing.Size(420, 15);
            this.lbl_instruction.TabIndex = 0;
            this.lbl_instruction.Text = "Select which released items go on this delivery, and how many of each:";
            //
            // pnl_bottom
            //
            this.pnl_bottom.Controls.Add(this.lbl_hint);
            this.pnl_bottom.Controls.Add(this.btn_cancel);
            this.pnl_bottom.Controls.Add(this.btn_ok);
            this.pnl_bottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnl_bottom.Location = new System.Drawing.Point(4, 385);
            this.pnl_bottom.Name = "pnl_bottom";
            this.pnl_bottom.Size = new System.Drawing.Size(912, 45);
            this.pnl_bottom.TabIndex = 2;
            //
            // lbl_hint
            //
            this.lbl_hint.AutoSize = true;
            this.lbl_hint.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(90)))), ((int)(((byte)(90)))), ((int)(((byte)(90)))));
            this.lbl_hint.Location = new System.Drawing.Point(8, 17);
            this.lbl_hint.Name = "lbl_hint";
            this.lbl_hint.Size = new System.Drawing.Size(400, 13);
            this.lbl_hint.TabIndex = 2;
            this.lbl_hint.Text = "Quantities already taken by earlier delivery receipts are excluded.";
            //
            // btn_cancel
            //
            this.btn_cancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_cancel.Location = new System.Drawing.Point(798, 10);
            this.btn_cancel.Name = "btn_cancel";
            this.btn_cancel.Size = new System.Drawing.Size(100, 28);
            this.btn_cancel.TabIndex = 1;
            this.btn_cancel.Text = "CANCEL";
            this.btn_cancel.UseVisualStyleBackColor = true;
            //
            // btn_ok
            //
            this.btn_ok.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_ok.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.btn_ok.Location = new System.Drawing.Point(692, 10);
            this.btn_ok.Name = "btn_ok";
            this.btn_ok.Size = new System.Drawing.Size(100, 28);
            this.btn_ok.TabIndex = 0;
            this.btn_ok.Text = "OK";
            this.btn_ok.UseVisualStyleBackColor = false;
            //
            // DeliveryReceiptItemPickerModal
            //
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(920, 430);
            this.Controls.Add(this.dgv_items);
            this.Controls.Add(this.pnl_bottom);
            this.Controls.Add(this.pnl_top);
            this.MinimizeBox = false;
            this.MaximizeBox = false;
            this.MinimumSize = new System.Drawing.Size(760, 360);
            this.Name = "DeliveryReceiptItemPickerModal";
            this.Padding = new System.Windows.Forms.Padding(4);
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Select Delivery Items";
            ((System.ComponentModel.ISupportInitialize)(this.dgv_items)).EndInit();
            this.pnl_top.ResumeLayout(false);
            this.pnl_top.PerformLayout();
            this.pnl_bottom.ResumeLayout(false);
            this.pnl_bottom.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dgv_items;
        private System.Windows.Forms.DataGridViewCheckBoxColumn col_select;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_item_code;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_item_description;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_released;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_delivered;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_remaining;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_qty;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_uom;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_serial_no;
        private System.Windows.Forms.Panel pnl_top;
        private System.Windows.Forms.Button btn_clear_all;
        private System.Windows.Forms.Button btn_select_all;
        private System.Windows.Forms.Label lbl_instruction;
        private System.Windows.Forms.Panel pnl_bottom;
        private System.Windows.Forms.Label lbl_hint;
        private System.Windows.Forms.Button btn_cancel;
        private System.Windows.Forms.Button btn_ok;
    }
}
