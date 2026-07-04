using smpc_dispatching.Core.Helpers;
using smpc_dispatching.Core.Interfaces;
using smpc_dispatching.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace smpc_dispatching.UI.Shared
{
    // Pure data-entry dialog, reused for both New and Edit. Does not call the API
    // itself — the caller reads Result after ShowDialog() returns OK and performs
    // the actual Create/Update.
    public partial class VehicleDetailsModal : Form
    {
        private readonly IWarehouseService _warehouseService;
        private readonly VehicleModel _existing;

        private static readonly string[] _types = { "Motorcycle", "Car", "Truck" };
        private static readonly string[] _statuses = { "Active", "Inactive", "Maintenance" };

        public VehicleModel Result { get; private set; }

        public VehicleDetailsModal(IWarehouseService warehouseService, VehicleModel existing = null)
        {
            InitializeComponent();
            _warehouseService = warehouseService;
            _existing = existing;

            cmb_type.Items.AddRange(_types);
            cmb_status.Items.AddRange(_statuses);

            if (existing != null)
            {
                Text = "Edit Vehicle";

                cmb_type.SelectedItem = existing.Type;
                txt_model.Text = existing.Model;
                txt_description.Text = existing.Description;
                txt_plate_no.Text = existing.PlateNo;
                txt_acquisition_year.Text = existing.AcquisitionYear;
                txt_capacity.Text = existing.Capacity.ToString();
                cmb_status.SelectedItem = existing.Status;
                txt_last_maintenance.Text = existing.LastMaintenance;
                txt_notes.Text = existing.Notes;
            }
            else
            {
                Text = "New Vehicle";
            }
        }

        private async void VehicleDetailsModal_Load(object sender, EventArgs e)
        {
            var response = await _warehouseService.GetAllAsync(null);
            var warehouses = response?.Data?.ToList() ?? new List<WarehouseModel>();

            cmb_warehouse.DataSource = warehouses;
            cmb_warehouse.DisplayMember = nameof(WarehouseModel.Name);
            cmb_warehouse.ValueMember = nameof(WarehouseModel.id);

            if (_existing != null)
            {
                cmb_warehouse.SelectedValue = (uint)_existing.WarehouseId;
            }
        }

        private bool HasValidationErrors(out string messages)
        {
            bool hasError = false;
            messages = string.Empty;

            if (cmb_type.SelectedItem == null)
            {
                messages += "Type must be selected\n";
                hasError = true;
            }

            if (string.IsNullOrWhiteSpace(txt_plate_no.Text))
            {
                messages += "Plate No. cannot be empty\n";
                hasError = true;
            }

            return hasError;
        }

        private void btn_save_Click(object sender, EventArgs e)
        {
            if (HasValidationErrors(out string errorMessage))
            {
                Helpers.ShowDialogMessage("error", errorMessage);
                return;
            }

            uint.TryParse(txt_capacity.Text, out uint capacity);
            int warehouseId = cmb_warehouse.SelectedValue is uint id ? (int)id : 0;

            Result = new VehicleModel
            {
                id = _existing?.id,
                WarehouseId = warehouseId,
                Type = cmb_type.SelectedItem?.ToString(),
                Model = txt_model.Text.Trim(),
                Description = txt_description.Text.Trim(),
                PlateNo = txt_plate_no.Text.Trim(),
                AcquisitionYear = txt_acquisition_year.Text.Trim(),
                Capacity = capacity,
                Status = cmb_status.SelectedItem?.ToString(),
                LastMaintenance = txt_last_maintenance.Text.Trim(),
                Notes = txt_notes.Text.Trim(),
            };

            DialogResult = DialogResult.OK;
            Close();
        }

        private void btn_cancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }
    }
}
