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

        // Bugs #180/#182/#185-191 (Trello): none of these fields had any real
        // validation - Plate No. accepted anything, Acquisition Year and Last
        // Maintenance were plain free text, and Capacity silently fell back to 0
        // on unparseable input (uint.TryParse below) instead of rejecting it. The
        // grid these were originally filed against has since been replaced by
        // this modal, but the underlying gaps carried over.
        private static readonly System.Text.RegularExpressions.Regex PlateNoPattern =
            new System.Text.RegularExpressions.Regex(@"^[A-Za-z]{2,3}[\s-]?\d{3,5}$");

        private bool HasValidationErrors(out string messages)
        {
            bool hasError = false;
            messages = string.Empty;

            if (cmb_type.SelectedItem == null)
            {
                messages += "Type must be selected\n";
                hasError = true;
            }

            string plateNo = txt_plate_no.Text.Trim();
            if (string.IsNullOrWhiteSpace(plateNo))
            {
                messages += "Plate No. cannot be empty\n";
                hasError = true;
            }
            else if (!PlateNoPattern.IsMatch(plateNo))
            {
                messages += "Plate No. format is invalid (e.g. AAA1234)\n";
                hasError = true;
            }

            string acquisitionYear = txt_acquisition_year.Text.Trim();
            if (!string.IsNullOrWhiteSpace(acquisitionYear))
            {
                if (!int.TryParse(acquisitionYear, out int year) || acquisitionYear.Length != 4
                    || year < 1980 || year > DateTime.Now.Year + 1)
                {
                    messages += "Acquisition Year must be a valid 4-digit year\n";
                    hasError = true;
                }
            }

            string capacityText = txt_capacity.Text.Trim();
            if (!string.IsNullOrWhiteSpace(capacityText)
                && (!uint.TryParse(capacityText, out uint parsedCapacity) || parsedCapacity == 0))
            {
                messages += "Capacity must be a positive whole number\n";
                hasError = true;
            }

            string lastMaintenance = txt_last_maintenance.Text.Trim();
            if (!string.IsNullOrWhiteSpace(lastMaintenance) && !DateTime.TryParse(lastMaintenance, out _))
            {
                messages += "Last Maintenance must be a valid date\n";
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
