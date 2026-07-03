using smpc_dispatching.Core.Helpers;
using smpc_dispatching.Core.Models;
using System;
using System.Windows.Forms;

namespace smpc_dispatching.UI.Shared
{
    // Pure data-entry dialog, reused for both New and Edit. Does not call the API
    // itself — the caller reads Result after ShowDialog() returns OK and performs
    // the actual Create/Update.
    public partial class VehicleDetailsModal : Form
    {
        private readonly uint? _existingId;

        public VehicleModel Result { get; private set; }

        public VehicleDetailsModal(VehicleModel existing = null)
        {
            InitializeComponent();

            if (existing != null)
            {
                Text = "Edit Vehicle";
                _existingId = existing.id;

                txt_type.Text = existing.Type;
                txt_model.Text = existing.Model;
                txt_description.Text = existing.Description;
                txt_plate_no.Text = existing.PlateNo;
                txt_acquisition_year.Text = existing.AcquisitionYear;
                txt_capacity.Text = existing.Capacity.ToString();
                txt_status.Text = existing.Status;
                txt_last_maintenance.Text = existing.LastMaintenance;
                txt_notes.Text = existing.Notes;
                txt_warehouse_id.Text = existing.WarehouseId.ToString();
            }
            else
            {
                Text = "New Vehicle";
            }
        }

        private bool HasValidationErrors(out string messages)
        {
            bool hasError = false;
            messages = string.Empty;

            if (string.IsNullOrWhiteSpace(txt_type.Text))
            {
                messages += "Type cannot be empty\n";
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
            int.TryParse(txt_warehouse_id.Text, out int warehouseId);

            Result = new VehicleModel
            {
                id = _existingId,
                WarehouseId = warehouseId,
                Type = txt_type.Text.Trim(),
                Model = txt_model.Text.Trim(),
                Description = txt_description.Text.Trim(),
                PlateNo = txt_plate_no.Text.Trim(),
                AcquisitionYear = txt_acquisition_year.Text.Trim(),
                Capacity = capacity,
                Status = txt_status.Text.Trim(),
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
