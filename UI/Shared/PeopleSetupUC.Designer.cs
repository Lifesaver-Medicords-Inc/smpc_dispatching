namespace smpc_dispatching.UI.Shared
{
    partial class PeopleSetupUC
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
            this.pnl_top = new System.Windows.Forms.Panel();
            this.btn_deactivate = new System.Windows.Forms.Button();
            this.btn_edit = new System.Windows.Forms.Button();
            this.btn_add = new System.Windows.Forms.Button();
            this.btn_refresh = new System.Windows.Forms.Button();
            this.chk_show_inactive = new System.Windows.Forms.CheckBox();
            this.txt_search = new System.Windows.Forms.TextBox();
            this.lbl_search = new System.Windows.Forms.Label();
            this.lbl_title = new System.Windows.Forms.Label();
            this.dg_people = new System.Windows.Forms.DataGridView();
            this.col_id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_full_name = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_role = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_status = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.pnl_top.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dg_people)).BeginInit();
            this.SuspendLayout();
            //
            // pnl_top
            //
            this.pnl_top.Controls.Add(this.btn_deactivate);
            this.pnl_top.Controls.Add(this.btn_edit);
            this.pnl_top.Controls.Add(this.btn_add);
            this.pnl_top.Controls.Add(this.btn_refresh);
            this.pnl_top.Controls.Add(this.chk_show_inactive);
            this.pnl_top.Controls.Add(this.txt_search);
            this.pnl_top.Controls.Add(this.lbl_search);
            this.pnl_top.Controls.Add(this.lbl_title);
            this.pnl_top.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnl_top.Location = new System.Drawing.Point(0, 0);
            this.pnl_top.Name = "pnl_top";
            this.pnl_top.Size = new System.Drawing.Size(1000, 78);
            this.pnl_top.TabIndex = 0;
            //
            // btn_deactivate
            //
            this.btn_deactivate.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_deactivate.Location = new System.Drawing.Point(888, 44);
            this.btn_deactivate.Name = "btn_deactivate";
            this.btn_deactivate.Size = new System.Drawing.Size(100, 25);
            this.btn_deactivate.TabIndex = 7;
            this.btn_deactivate.Text = "Deactivate";
            this.btn_deactivate.UseVisualStyleBackColor = true;
            //
            // btn_edit
            //
            this.btn_edit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_edit.Location = new System.Drawing.Point(792, 44);
            this.btn_edit.Name = "btn_edit";
            this.btn_edit.Size = new System.Drawing.Size(90, 25);
            this.btn_edit.TabIndex = 6;
            this.btn_edit.Text = "Edit";
            this.btn_edit.UseVisualStyleBackColor = true;
            //
            // btn_add
            //
            this.btn_add.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_add.Location = new System.Drawing.Point(696, 44);
            this.btn_add.Name = "btn_add";
            this.btn_add.Size = new System.Drawing.Size(90, 25);
            this.btn_add.TabIndex = 5;
            this.btn_add.Text = "Add Person";
            this.btn_add.UseVisualStyleBackColor = true;
            //
            // btn_refresh
            //
            this.btn_refresh.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_refresh.Location = new System.Drawing.Point(600, 44);
            this.btn_refresh.Name = "btn_refresh";
            this.btn_refresh.Size = new System.Drawing.Size(90, 25);
            this.btn_refresh.TabIndex = 4;
            this.btn_refresh.Text = "Refresh";
            this.btn_refresh.UseVisualStyleBackColor = true;
            //
            // chk_show_inactive
            //
            this.chk_show_inactive.AutoSize = true;
            this.chk_show_inactive.Location = new System.Drawing.Point(320, 48);
            this.chk_show_inactive.Name = "chk_show_inactive";
            this.chk_show_inactive.Size = new System.Drawing.Size(120, 17);
            this.chk_show_inactive.TabIndex = 3;
            this.chk_show_inactive.Text = "Show inactive";
            this.chk_show_inactive.UseVisualStyleBackColor = true;
            //
            // txt_search
            //
            this.txt_search.Location = new System.Drawing.Point(64, 46);
            this.txt_search.Name = "txt_search";
            this.txt_search.Size = new System.Drawing.Size(240, 20);
            this.txt_search.TabIndex = 2;
            //
            // lbl_search
            //
            this.lbl_search.AutoSize = true;
            this.lbl_search.Location = new System.Drawing.Point(14, 49);
            this.lbl_search.Name = "lbl_search";
            this.lbl_search.Size = new System.Drawing.Size(44, 13);
            this.lbl_search.TabIndex = 1;
            this.lbl_search.Text = "Search:";
            //
            // lbl_title
            //
            this.lbl_title.AutoSize = true;
            this.lbl_title.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold);
            this.lbl_title.Location = new System.Drawing.Point(12, 10);
            this.lbl_title.Name = "lbl_title";
            this.lbl_title.Size = new System.Drawing.Size(180, 24);
            this.lbl_title.TabIndex = 0;
            this.lbl_title.Text = "PEOPLE SETUP";
            //
            // dg_people
            //
            this.dg_people.AllowUserToAddRows = false;
            this.dg_people.AllowUserToDeleteRows = false;
            this.dg_people.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dg_people.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dg_people.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.col_id,
            this.col_full_name,
            this.col_role,
            this.col_status});
            this.dg_people.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dg_people.Location = new System.Drawing.Point(0, 78);
            this.dg_people.MultiSelect = false;
            this.dg_people.Name = "dg_people";
            this.dg_people.ReadOnly = true;
            this.dg_people.RowHeadersWidth = 25;
            this.dg_people.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dg_people.Size = new System.Drawing.Size(1000, 522);
            this.dg_people.TabIndex = 1;
            //
            // col_id
            //
            this.col_id.DataPropertyName = "id";
            this.col_id.HeaderText = "id";
            this.col_id.Name = "col_id";
            this.col_id.ReadOnly = true;
            this.col_id.Visible = false;
            //
            // col_full_name
            //
            this.col_full_name.DataPropertyName = "full_name";
            this.col_full_name.FillWeight = 220F;
            this.col_full_name.HeaderText = "NAME";
            this.col_full_name.Name = "col_full_name";
            this.col_full_name.ReadOnly = true;
            //
            // col_role
            //
            this.col_role.DataPropertyName = "role";
            this.col_role.FillWeight = 90F;
            this.col_role.HeaderText = "ROLE";
            this.col_role.Name = "col_role";
            this.col_role.ReadOnly = true;
            //
            // col_status
            //
            this.col_status.FillWeight = 90F;
            this.col_status.HeaderText = "STATUS";
            this.col_status.Name = "col_status";
            this.col_status.ReadOnly = true;
            //
            // PeopleSetupUC
            //
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.dg_people);
            this.Controls.Add(this.pnl_top);
            this.Name = "PeopleSetupUC";
            this.Size = new System.Drawing.Size(1000, 600);
            this.Load += new System.EventHandler(this.PeopleSetupUC_Load);
            this.pnl_top.ResumeLayout(false);
            this.pnl_top.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dg_people)).EndInit();
            this.ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.Panel pnl_top;
        private System.Windows.Forms.Label lbl_title;
        private System.Windows.Forms.Label lbl_search;
        private System.Windows.Forms.TextBox txt_search;
        private System.Windows.Forms.CheckBox chk_show_inactive;
        private System.Windows.Forms.Button btn_refresh;
        private System.Windows.Forms.Button btn_add;
        private System.Windows.Forms.Button btn_edit;
        private System.Windows.Forms.Button btn_deactivate;
        private System.Windows.Forms.DataGridView dg_people;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_id;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_full_name;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_role;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_status;
    }
}
