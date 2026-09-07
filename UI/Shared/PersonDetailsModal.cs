using smpc_dispatching.Core.Helpers;
using smpc_dispatching.Core.Models;
using System;
using System.Windows.Forms;

namespace smpc_dispatching.UI.Shared
{
    // Add / edit one dispatch person. Pass null to add, an existing record to edit.
    //
    // Only name, role and status - see PeopleSetupUC for why the record is this small
    // (these are not system users, and HRIS is out of scope per §15).
    public partial class PersonDetailsModal : Form
    {
        public DispatchPersonModel Person { get; private set; }

        private readonly bool _isNew;

        public PersonDetailsModal(DispatchPersonModel existing)
        {
            InitializeComponent();

            _isNew = existing == null;

            // Roles come from PeopleSetupUC.Roles, which holds the two values §13.3
            // names - not a list invented here.
            cmb_role.Items.AddRange(PeopleSetupUC.Roles);

            if (_isNew)
            {
                Text = "Add Person";
                Person = new DispatchPersonModel { is_active = true };
                cmb_role.SelectedIndex = 0;
            }
            else
            {
                Text = "Edit Person";

                // Copy rather than edit in place, so Cancel leaves the grid's record
                // untouched.
                Person = new DispatchPersonModel
                {
                    id = existing.id,
                    full_name = existing.full_name,
                    role = existing.role,
                    is_active = existing.is_active,
                };

                txt_full_name.Text = Person.full_name;
                chk_active.Checked = Person.is_active;

                int roleIndex = cmb_role.Items.IndexOf(Person.role ?? string.Empty);
                // A record whose role predates this list (or was set directly in the
                // database) would not match - leave the combo unselected rather than
                // silently reassigning them to DRIVER.
                cmb_role.SelectedIndex = roleIndex >= 0 ? roleIndex : -1;
            }

            btn_ok.Click += btn_ok_Click;
            btn_cancel.Click += (s, e) => { DialogResult = DialogResult.Cancel; Close(); };
            AcceptButton = btn_ok;
            CancelButton = btn_cancel;
        }

        private void btn_ok_Click(object sender, EventArgs e)
        {
            string name = txt_full_name.Text?.Trim() ?? string.Empty;

            if (string.IsNullOrWhiteSpace(name))
            {
                Helpers.ShowDialogMessage("error", "Enter the person's name.");
                txt_full_name.Focus();
                return;
            }

            if (cmb_role.SelectedItem == null)
            {
                Helpers.ShowDialogMessage("error", "Select a role - Driver or Helper.");
                cmb_role.Focus();
                return;
            }

            Person.full_name = name;
            Person.role = cmb_role.SelectedItem.ToString();
            Person.is_active = chk_active.Checked;

            DialogResult = DialogResult.OK;
            Close();
        }
    }
}
