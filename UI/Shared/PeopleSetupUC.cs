using smpc_dispatching.Core.Helpers;
using smpc_dispatching.Core.Interfaces;
using smpc_dispatching.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace smpc_dispatching.UI.Shared
{
    // PEOPLE SETUP - the drivers and helpers who go out on deliveries.
    //
    // Added 2026-09-05 (user request). §13.3 requires the internal logistics schedule to
    // "select driver, helper, and vehicle first", but there was no roster to select
    // from: the schedule held a single free-text driver_name and no helper field at all.
    //
    // These people are NOT system users - they do not log in and hold no module access -
    // and they are not HRIS employee records either (§15 keeps HRIS out of scope). The
    // record carries only what dispatch needs: name, role, and whether they are still
    // with us (user decision).
    public partial class PeopleSetupUC : UserControl
    {
        // §13.3 names exactly these two roles. §17 defines no list for them, and
        // CLAUDE.md forbids inventing dropdown values, so there is deliberately no
        // third "Both" option - that would need to be asked for, not assumed.
        public static readonly string[] Roles = { "DRIVER", "HELPER" };

        private readonly IDispatchPersonService _peopleService;
        private List<DispatchPersonModel> _allPeople = new List<DispatchPersonModel>();

        public PeopleSetupUC(IDispatchPersonService peopleService)
        {
            InitializeComponent();
            _peopleService = peopleService;

            btn_refresh.Click += async (s, e) => await LoadPeople();
            btn_add.Click += btn_add_Click;
            btn_edit.Click += btn_edit_Click;
            btn_deactivate.Click += btn_deactivate_Click;
            txt_search.TextChanged += (s, e) => ApplyFilter();
            chk_show_inactive.CheckedChanged += (s, e) => ApplyFilter();
            dg_people.CellDoubleClick += (s, e) => { if (e.RowIndex >= 0) btn_edit_Click(s, EventArgs.Empty); };
        }

        private async void PeopleSetupUC_Load(object sender, EventArgs e)
        {
            await LoadPeople();
        }

        private async Task LoadPeople()
        {
            try
            {
                Helpers.Loading.ShowLoading(dg_people, "Loading people...");

                // No query: Setup shows inactive people too, since they are deactivated
                // rather than deleted. The "Show inactive" checkbox filters client-side.
                var response = await _peopleService.GetAllAsync(null);
                _allPeople = response?.Data?.ToList() ?? new List<DispatchPersonModel>();

                ApplyFilter();
            }
            catch (Exception ex)
            {
                Helpers.ShowDialogMessage("error", $"Could not load people: {ex.Message}");
            }
            finally
            {
                Helpers.Loading.HideLoading(dg_people);
            }
        }

        private void ApplyFilter()
        {
            string term = txt_search.Text?.Trim().ToLower() ?? string.Empty;

            IEnumerable<DispatchPersonModel> filtered = _allPeople;

            if (!chk_show_inactive.Checked)
                filtered = filtered.Where(p => p.is_active);

            if (!string.IsNullOrEmpty(term))
            {
                filtered = filtered.Where(p =>
                    (p.full_name ?? string.Empty).ToLower().Contains(term) ||
                    (p.role ?? string.Empty).ToLower().Contains(term));
            }

            var rows = filtered
                .OrderBy(p => p.role)
                .ThenBy(p => p.full_name)
                .ToList();

            dg_people.Rows.Clear();
            foreach (var person in rows)
            {
                int index = dg_people.Rows.Add();
                var row = dg_people.Rows[index];
                row.Cells["col_id"].Value = person.id;
                row.Cells["col_full_name"].Value = person.full_name;
                row.Cells["col_role"].Value = person.role;
                row.Cells["col_status"].Value = person.is_active ? "Active" : "Inactive";
                row.Tag = person;

                // Inactive rows are greyed rather than hidden when "Show inactive" is on,
                // so it stays obvious at a glance which names the schedule pickers will
                // no longer offer.
                if (!person.is_active)
                    row.DefaultCellStyle.ForeColor = System.Drawing.Color.Gray;
            }
        }

        private DispatchPersonModel SelectedPerson()
        {
            if (dg_people.CurrentRow == null) return null;
            return dg_people.CurrentRow.Tag as DispatchPersonModel;
        }

        private async void btn_add_Click(object sender, EventArgs e)
        {
            using (var modal = new PersonDetailsModal(null))
            {
                if (modal.ShowDialog() != DialogResult.OK) return;

                try
                {
                    Helpers.Loading.ShowLoading(dg_people, "Saving...");
                    var response = await _peopleService.CreateAsync(modal.Person);

                    if (response == null || !response.Success)
                    {
                        Helpers.ShowDialogMessage("error", response?.Message ?? "Could not add this person. Please try again.");
                        return;
                    }
                }
                catch (Exception ex)
                {
                    Helpers.ShowDialogMessage("error", $"Could not add this person: {ex.Message}");
                    return;
                }
                finally
                {
                    Helpers.Loading.HideLoading(dg_people);
                }
            }

            await LoadPeople();
        }

        private async void btn_edit_Click(object sender, EventArgs e)
        {
            var selected = SelectedPerson();
            if (selected == null)
            {
                Helpers.ShowDialogMessage("error", "Select a person to edit.");
                return;
            }

            using (var modal = new PersonDetailsModal(selected))
            {
                if (modal.ShowDialog() != DialogResult.OK) return;

                try
                {
                    Helpers.Loading.ShowLoading(dg_people, "Saving...");
                    var response = await _peopleService.UpdateAsync(modal.Person);

                    if (response == null || !response.Success)
                    {
                        Helpers.ShowDialogMessage("error", response?.Message ?? "Could not save this person. Please try again.");
                        return;
                    }
                }
                catch (Exception ex)
                {
                    Helpers.ShowDialogMessage("error", $"Could not save this person: {ex.Message}");
                    return;
                }
                finally
                {
                    Helpers.Loading.HideLoading(dg_people);
                }
            }

            await LoadPeople();
        }

        private async void btn_deactivate_Click(object sender, EventArgs e)
        {
            var selected = SelectedPerson();
            if (selected == null)
            {
                Helpers.ShowDialogMessage("error", "Select a person to deactivate.");
                return;
            }

            if (!selected.is_active)
            {
                Helpers.ShowDialogMessage("error", $"{selected.full_name} is already inactive.");
                return;
            }

            // Deactivate, never delete - the API does the same. Past schedules keep the
            // person's name; only the pickers stop offering them.
            var confirm = MessageBox.Show(
                $"Deactivate {selected.full_name}?{Environment.NewLine}{Environment.NewLine}" +
                "They will no longer appear when assigning a driver or helper. Deliveries they " +
                "have already been on keep their name.",
                "Confirm",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Warning,
                MessageBoxDefaultButton.Button2);

            if (confirm != DialogResult.Yes) return;

            try
            {
                Helpers.Loading.ShowLoading(dg_people, "Deactivating...");
                var response = await _peopleService.RemoveAsync(selected.id);

                if (response == null || !response.Success)
                {
                    Helpers.ShowDialogMessage("error", response?.Message ?? "Could not deactivate this person. Please try again.");
                    return;
                }
            }
            catch (Exception ex)
            {
                Helpers.ShowDialogMessage("error", $"Could not deactivate this person: {ex.Message}");
                return;
            }
            finally
            {
                Helpers.Loading.HideLoading(dg_people);
            }

            await LoadPeople();
        }
    }
}
