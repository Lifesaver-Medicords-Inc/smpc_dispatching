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
        }

        private void HideColumn(string columnName)
        {
            if (dg_vehicle.Columns.Contains(columnName))
                dg_vehicle.Columns[columnName].Visible = false;
        }

        private async void btn_new_Click(object sender, EventArgs e)
        {
            using (var modal = new VehicleDetailsModal(_warehouseService))
            {
                if (modal.ShowDialog(this) != DialogResult.OK) return;

                var response = await _vehicleService.CreateAsync(modal.Result);
                if (response == null || !response.Success)
                {
                    Helpers.ShowDialogMessage("error", $"Failed to save vehicle.\n{response?.Message}");
                    return;
                }

                Helpers.ShowDialogMessage("success", "Vehicle saved successfully.");
                await LoadVehicles();
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

                var response = await _vehicleService.UpdateAsync(modal.Result);
                if (response == null || !response.Success)
                {
                    Helpers.ShowDialogMessage("error", $"Failed to save vehicle.\n{response?.Message}");
                    return;
                }

                Helpers.ShowDialogMessage("success", "Vehicle saved successfully.");
                await LoadVehicles();
            }
        }
    }
}
