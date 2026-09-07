namespace smpc_dispatching.UI.Shared
{
    partial class PersonDetailsModal
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
            this.lbl_name = new System.Windows.Forms.Label();
            this.txt_full_name = new System.Windows.Forms.TextBox();
            this.lbl_role = new System.Windows.Forms.Label();
            this.cmb_role = new System.Windows.Forms.ComboBox();
            this.chk_active = new System.Windows.Forms.CheckBox();
            this.btn_ok = new System.Windows.Forms.Button();
            this.btn_cancel = new System.Windows.Forms.Button();
            this.SuspendLayout();
            //
            // lbl_name
            //
            this.lbl_name.AutoSize = true;
            this.lbl_name.Location = new System.Drawing.Point(18, 24);
            this.lbl_name.Name = "lbl_name";
            this.lbl_name.Size = new System.Drawing.Size(38, 13);
            this.lbl_name.TabIndex = 0;
            this.lbl_name.Text = "NAME:";
            //
            // txt_full_name
            //
            this.txt_full_name.Location = new System.Drawing.Point(90, 21);
            this.txt_full_name.MaxLength = 150;
            this.txt_full_name.Name = "txt_full_name";
            this.txt_full_name.Size = new System.Drawing.Size(260, 20);
            this.txt_full_name.TabIndex = 1;
            //
            // lbl_role
            //
            this.lbl_role.AutoSize = true;
            this.lbl_role.Location = new System.Drawing.Point(18, 56);
            this.lbl_role.Name = "lbl_role";
            this.lbl_role.Size = new System.Drawing.Size(33, 13);
            this.lbl_role.TabIndex = 2;
            this.lbl_role.Text = "ROLE:";
            //
            // cmb_role
            //
            this.cmb_role.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmb_role.FormattingEnabled = true;
            this.cmb_role.Location = new System.Drawing.Point(90, 53);
            this.cmb_role.Name = "cmb_role";
            this.cmb_role.Size = new System.Drawing.Size(160, 21);
            this.cmb_role.TabIndex = 3;
            //
            // chk_active
            //
            this.chk_active.AutoSize = true;
            this.chk_active.Checked = true;
            this.chk_active.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chk_active.Location = new System.Drawing.Point(90, 88);
            this.chk_active.Name = "chk_active";
            this.chk_active.Size = new System.Drawing.Size(56, 17);
            this.chk_active.TabIndex = 4;
            this.chk_active.Text = "Active";
            this.chk_active.UseVisualStyleBackColor = true;
            //
            // btn_ok
            //
            this.btn_ok.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.btn_ok.Location = new System.Drawing.Point(174, 126);
            this.btn_ok.Name = "btn_ok";
            this.btn_ok.Size = new System.Drawing.Size(85, 28);
            this.btn_ok.TabIndex = 5;
            this.btn_ok.Text = "SAVE";
            this.btn_ok.UseVisualStyleBackColor = false;
            //
            // btn_cancel
            //
            this.btn_cancel.Location = new System.Drawing.Point(265, 126);
            this.btn_cancel.Name = "btn_cancel";
            this.btn_cancel.Size = new System.Drawing.Size(85, 28);
            this.btn_cancel.TabIndex = 6;
            this.btn_cancel.Text = "CANCEL";
            this.btn_cancel.UseVisualStyleBackColor = true;
            //
            // PersonDetailsModal
            //
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(372, 170);
            this.Controls.Add(this.btn_cancel);
            this.Controls.Add(this.btn_ok);
            this.Controls.Add(this.chk_active);
            this.Controls.Add(this.cmb_role);
            this.Controls.Add(this.lbl_role);
            this.Controls.Add(this.txt_full_name);
            this.Controls.Add(this.lbl_name);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "PersonDetailsModal";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Person";
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        #endregion

        private System.Windows.Forms.Label lbl_name;
        private System.Windows.Forms.TextBox txt_full_name;
        private System.Windows.Forms.Label lbl_role;
        private System.Windows.Forms.ComboBox cmb_role;
        private System.Windows.Forms.CheckBox chk_active;
        private System.Windows.Forms.Button btn_ok;
        private System.Windows.Forms.Button btn_cancel;
    }
}
