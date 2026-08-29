using smpc_dispatching.Core.Helpers;
using smpc_dispatching.Core.Interfaces;
using smpc_dispatching.Core.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace smpc_dispatching.UI.Shared
{
    public partial class VehicleSetupUC : UserControl
    {
        private readonly IVehicleService _vehicleService;
        private readonly IWarehouseService _warehouseService;
        private List<VehicleModel> _vehicles = new List<VehicleModel>();

        public VehicleSetupUC(IVehicleService vehicleService, IWarehouseService warehouseService)
        {
            InitializeComponent();
            _vehicleService = vehicleService;
            _warehouseService = warehouseService;
            dg_vehicle.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }

        private async void VehicleSetupUC_Load(object sender, EventArgs e)
        {
            await LoadVehicles();
        }

        private async Task LoadVehicles()
        {
            var response = await _vehicleService.GetAllAsync(null);
            _vehicles = response?.Data?.ToList() ?? new List<VehicleModel>();

            var warehouseResponse = await _warehouseService.GetAllAsync(null);
            var warehouseNames = warehouseResponse?.Data
                ?.Where(w => w.id.HasValue)
                .ToDictionary(w => (int)w.id.Value, w => w.Name)
                ?? new Dictionary<int, string>();

            var table = Helpers.ToDataTable(_vehicles);
            table.Columns.Add("Warehouse", typeof(string));
            foreach (DataRow row in table.Rows)
            {
                int warehouseId = Convert.ToInt32(row["WarehouseId"]);
                row["Warehouse"] = warehouseNames.TryGetValue(warehouseId, out var name) ? name : "-";
            }
            table.Columns["Warehouse"].SetOrdinal(0);

            dg_vehicle.DataSource = table;

            HideColumn("id");
            HideColumn("CreatedAt");
            HideColumn("UpdatedAt");
            HideColumn("WarehouseId");

            // Bug #179 (Trello, "PLATENO column should have a space") - this grid
            // auto-generates columns from VehicleModel's raw property names, so every
            // header showed the property name as-is (PlateNo, AcquisitionYear, etc.)
            // instead of a readable label. Fixed the one reported and its siblings
            // while here, rather than leave the rest looking the same way.
            SetHeaderText("Type", "Type");
            SetHeaderText("Model", "Model");
            SetHeaderText("Description", "Description");
            SetHeaderText("PlateNo", "Plate No.");
            SetHeaderText("AcquisitionYear", "Acquisition Year");
            SetHeaderText("Capacity", "Capacity");
            SetHeaderText("Status", "Status");
            SetHeaderText("LastMaintenance", "Last Maintenance");
            SetHeaderText("Notes", "Notes");
        }

        private void SetHeaderText(string columnName, string headerText)
        {
            if (dg_vehicle.Columns.Contains(columnName))
                dg_vehicle.Columns[columnName].HeaderText = headerText;
        }

        private void HideColumn(string columnName)
        {
            if (dg_vehicle.Columns.Contains(columnName))
                dg_vehicle.Columns[columnName].Visible = false;
        }

        // Bug #192 (Trello): dg_vehicle is bound straight to a DataTable with no
        // ReadOnly=true, so its cells (including Capacity, a non-nullable uint
        // column) are still directly in-cell editable. Clearing a Capacity cell
        // to blank and pressing Escape to cancel the edit makes the grid try to
        // convert an empty string back to uint, which throws - and with no
        // DataError handler that exception propagated through WinForms' own
        // default handling, which is what this report saw as a freeze.
        private void dg_vehicle_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            e.ThrowException = false;
            e.Cancel = true;
        }

        private async void btn_new_Click(object sender, EventArgs e)
        {
            using (var modal = new VehicleDetailsModal(_warehouseService))
            {
                if (modal.ShowDialog(this) != DialogResult.OK) return;

                // Bug #184 (Trello, "two saved entries instead of one"): the modal
                // is blocking, but once it closes OK this button was still
                // clickable through the whole CreateAsync + LoadVehicles await -
                // nothing here gave the user any feedback that the save was
                // already in flight, so a second New -> Save before the success
                // dialog appeared posted a second Create for the same entry.
                btn_new.Enabled = false;
                btn_edit.Enabled = false;
                try
                {
                    var response = await _vehicleService.CreateAsync(modal.Result);
                    if (response == null || !response.Success)
                    {
                        Helpers.ShowDialogMessage("error", $"Failed to save vehicle.\n{response?.Message}");
                        return;
                    }

                    Helpers.ShowDialogMessage("success", "Vehicle saved successfully.");
                    await LoadVehicles();
                }
                finally
                {
                    btn_new.Enabled = true;
                    btn_edit.Enabled = true;
                }
            }
        }

        private async void btn_edit_Click(object sender, EventArgs e)
        {
            if (dg_vehicle.CurrentRow == null)
            {
                Helpers.ShowDialogMessage("warning", "Please select a record to edit.");
                return;
            }

            if (dg_vehicle.CurrentRow.Cells["id"]?.Value == null)
            {
                Helpers.ShowDialogMessage("error", "Selected record does not have a valid ID.");
                return;
            }

            var selectedId = Convert.ToUInt32(dg_vehicle.CurrentRow.Cells["id"].Value);
            var existing = _vehicles.FirstOrDefault(v => v.id == selectedId);
            if (existing == null)
            {
                Helpers.ShowDialogMessage("error", "Selected vehicle could not be found.");
                return;
            }

            using (var modal = new VehicleDetailsModal(_warehouseService, existing))
            {
                if (modal.ShowDialog(this) != DialogResult.OK) return;

                // Bug #184 (Trello) - same double-submit window as btn_new_Click.
                btn_new.Enabled = false;
                btn_edit.Enabled = false;
                try
                {
                    var response = await _vehicleService.UpdateAsync(modal.Result);
                    if (response == null || !response.Success)
                    {
                        Helpers.ShowDialogMessage("error", $"Failed to save vehicle.\n{response?.Message}");
                        return;
                    }

                    Helpers.ShowDialogMessage("success", "Vehicle saved successfully.");
                    await LoadVehicles();
                }
                finally
                {
                    btn_new.Enabled = true;
                    btn_edit.Enabled = true;
                }
            }
        }
    }
}
