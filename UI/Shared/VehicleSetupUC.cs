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
    public partial class VehicleSetupUC : UserControl
    {
        private readonly IVehicleService _vehicleService;

        public VehicleSetupUC(IVehicleService vehicleService)
        {
            InitializeComponent();
            _vehicleService = vehicleService;
        }

        private async void VehicleSetupUC_Load(object sender, EventArgs e)
        {
            await LoadVehicles();
        }

        private async Task LoadVehicles()
        {
            var response = await _vehicleService.GetAllAsync(null);
            var vehicles = response?.Data?.ToList() ?? new List<VehicleModel>();
            dg_vehicle.DataSource = Helpers.ToDataTable(vehicles);
        }

        private async void btn_new_Click(object sender, EventArgs e)
        {
            using (var modal = new VehicleDetailsModal())
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

            var row = dg_vehicle.CurrentRow;
            uint.TryParse(row.Cells["Capacity"].Value?.ToString(), out uint capacity);
            int.TryParse(row.Cells["WarehouseId"].Value?.ToString(), out int warehouseId);

            var existing = new VehicleModel
            {
                id = row.Cells["id"].Value == null ? (uint?)null : Convert.ToUInt32(row.Cells["id"].Value),
                WarehouseId = warehouseId,
                Type = row.Cells["Type"].Value?.ToString(),
                Model = row.Cells["Model"].Value?.ToString(),
                Description = row.Cells["Description"].Value?.ToString(),
                PlateNo = row.Cells["PlateNo"].Value?.ToString(),
                AcquisitionYear = row.Cells["AcquisitionYear"].Value?.ToString(),
                Capacity = capacity,
                Status = row.Cells["Status"].Value?.ToString(),
                LastMaintenance = row.Cells["LastMaintenance"].Value?.ToString(),
                Notes = row.Cells["Notes"].Value?.ToString(),
            };

            using (var modal = new VehicleDetailsModal(existing))
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
