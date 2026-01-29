using Microsoft.Extensions.DependencyInjection;
using Serilog;
using smpc_dispatching.Core.Helpers;
using smpc_dispatching.Core.Interfaces;
using smpc_dispatching.Core.Models;
using smpc_dispatching.UI.Shared;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace smpc_dispatching.UI.Views.Sales
{
    public partial class SalesCalendarScheduleDetailsUC : UserControl
    {
        public string DepartmentType { get; set; } = "SALES";
        private readonly IServiceProvider _serviceProvider;
        private readonly ICalendarCategoryService _calendarCategoryService;
        private readonly IVehicleService _vehicleService;
        private readonly ICalendarScheduleService<SalesCalendarScheduleContent> _calendarScheduleService;
        private List<CalendarCategoryModel> _categories;

        public SalesCalendarScheduleDetailsUC(ICalendarScheduleService<SalesCalendarScheduleContent> calendarSchedule, ICalendarCategoryService calendarCategoryService, IVehicleService vehicleService, IServiceProvider serviceProvider)
        {
            InitializeComponent();
            _serviceProvider = serviceProvider;
            _calendarCategoryService = calendarCategoryService;
            _vehicleService = vehicleService;
            _calendarScheduleService = calendarSchedule;
        }

        public void LoadDetails(object model)
        {
            // map model to controls
        }

        public object GetDetails()
        {
            // read controls and return model
            return new { };
        }

        private async void SalesCalendarScheduleDetailsUC_Load(object sender, EventArgs e)
        {
            BtnToggle(false);
            await LoadCategoriesAsync();
        }
        private async Task LoadCategoriesAsync()
        {
            try
            {
                var res = await _calendarCategoryService.GetAllAsync(null);

                if (res?.Success == true)
                {
                    _categories = res.Data.ToList();
                }

                cmb_Category.DropDownStyle = ComboBoxStyle.DropDownList;

                cmb_Category.DataSource = _categories;
                cmb_Category.DisplayMember = "Name";
                cmb_Category.ValueMember = "Id";
            }
            catch (Exception ex)
            {
                Log.Error(ex, "Error getting calendar categories");
                MessageBox.Show(
                    "Failed to load calendar categories.",
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );
            }
        }

        private void PinMapBtn_Click(object sender, EventArgs e)
        {
            if (InvokeRequired)
            {
                BeginInvoke((Action)(() => PinMapBtn_Click(sender, e)));
                return;
            }


            using (var mapForm = _serviceProvider.GetRequiredService<MapLocPinForm>())
            {
                var result = mapForm.ShowDialog();
                if (result == DialogResult.OK && mapForm.SelectedPoint != null)
                {
                    rtxt_Location.Text = mapForm.SelectedAddress;
                }

            }
        }
        private void ResetPanels(params Panel[] panels)
        {
            foreach (var panel in panels)
            {
                Helpers.ResetControls(panel);
            }
        }
        private void BtnToggle(bool isEdit)
        {
            btn_new.Visible = !isEdit;
            btn_delete.Visible = !isEdit;
            btn_edit.Visible = !isEdit;
            btn_edit.Enabled = !string.IsNullOrEmpty(txt_Id.Text);

            btn_save.Visible = isEdit;
            btn_close.Visible = isEdit;
            flowLayoutPanel3.Enabled = isEdit;


        }

        private void btn_new_Click(object sender, EventArgs e)
        {
            BtnToggle(true);
            Helpers.ResetControls(flowLayoutPanel3);
        }

        private void btn_edit_Click(object sender, EventArgs e)
        {
            BtnToggle(true);
        }

        private void btn_close_Click(object sender, EventArgs e)
        {
            BtnToggle(false);
        }

        private async void btn_save_Click(object sender, EventArgs e)
        {
            // Disable button to prevent double-clicks
            btn_save.Enabled = false;
            try
            {
                // Validate required fields
                if (!ValidateInputs(out string validationError))
                {
                    Helpers.ShowDialogMessage("error", validationError);
                    return;
                }

                bool isNewRecord = string.IsNullOrWhiteSpace(txt_Id.Text);
                var calendarSchedule = BuildCalendarScheduleModel(isNewRecord);

                if (calendarSchedule == null)
                {
                    Helpers.ShowDialogMessage("error", "Failed to build schedule model. Please check all fields.");
                    return;
                }

                // Perform save operation
                var response = isNewRecord
                    ? await _calendarScheduleService.CreateAsync(calendarSchedule)
                    : await _calendarScheduleService.UpdateAsync(calendarSchedule);

                if (response?.Success == true)
                {
                    string successMessage = isNewRecord
                        ? "Schedule saved successfully."
                        : "Schedule updated successfully.";

                    Helpers.ShowDialogMessage("success", successMessage);

                    // Clear form for new records, keep data for updates
                    if (isNewRecord)
                    {
                        Helpers.ResetControls(flowLayoutPanel3);
                        Helpers.ResetControls(panel2);
                    }

                    BtnToggle(false);
                }
                else
                {
                    string errorMessage = isNewRecord
                        ? $"Failed to save schedule.\n{response?.Message ?? "Unknown error occurred."}"
                        : $"Failed to update schedule.\n{response?.Message ?? "Unknown error occurred."}";

                    Helpers.ShowDialogMessage("error", errorMessage);
                    Log.Warning("Failed to save calendar schedule. Response: {@Response}", response);
                }
            }
            catch (FormatException ex)
            {
                Log.Error(ex, "Invalid data format when saving calendar schedule");
                Helpers.ShowDialogMessage(
                    "error",
                    "Invalid data format. Please check dates and numeric fields.\n" + ex.Message
                );
            }
            catch (Exception ex)
            {
                Log.Error(ex, "Unexpected error saving calendar schedule");
                Helpers.ShowDialogMessage(
                    "error",
                    "An unexpected error occurred while saving.\n" + ex.Message
                );
            }
            finally
            {
                btn_save.Enabled = true;
            }
        }

        private bool ValidateInputs(out string errorMessage)
        {
            errorMessage = string.Empty;

            // Validate Category
            if (cmb_Category.SelectedValue == null ||
                (cmb_Category.SelectedValue is int categoryId && categoryId <= 0))
            {
                errorMessage = "Please select a category.";
                return false;
            }

            // Validate Title
            if (string.IsNullOrWhiteSpace(txt_Title.Text))
            {
                errorMessage = "Title is required.";
                return false;
            }

            // Validate Dates
            if (dtp_StartDate.Value == null || dtp_EndDate.Value == null)
            {
                errorMessage = "Start date and end date are required.";
                return false;
            }

            if (dtp_StartDate.Value > dtp_EndDate.Value)
            {
                errorMessage = "Start date cannot be later than end date.";
                return false;
            }

            // Validate ID for updates
            if (!string.IsNullOrWhiteSpace(txt_Id.Text))
            {
                if (!int.TryParse(txt_Id.Text, out int id) || id <= 0)
                {
                    errorMessage = "Invalid record ID format.";
                    return false;
                }
            }

            return true;
        }

        private CalendarScheduleModel<SalesCalendarScheduleContent> BuildCalendarScheduleModel(bool isNewRecord)
        {
            try
            {
                var data = Helpers.GetControlsValues(new[] { flowLayoutPanel3, panel2 });

                // Parse ID for updates
                int recordId = 0;
                if (!isNewRecord && !string.IsNullOrWhiteSpace(txt_Id.Text))
                {
                    if (!int.TryParse(txt_Id.Text, out recordId) || recordId <= 0)
                    {
                        return null;
                    }
                }

                // Parse Category ID
                int categoryId = 0;
                if (cmb_Category.SelectedValue != null)
                {
                    if (cmb_Category.SelectedValue is int catId)
                    {
                        categoryId = catId;
                    }
                    else if (int.TryParse(cmb_Category.SelectedValue.ToString(), out int parsedCatId))
                    {
                        categoryId = parsedCatId;
                    }
                }

                // Parse Reference ID
                ushort referenceId = 0;
                if (data.TryGetValue("ReferenceId", out var refId))
                {
                    if (ushort.TryParse(refId?.ToString(), out ushort parsedRefId))
                    {
                        referenceId = parsedRefId;
                    }
                }

                var calendarSchedule = new CalendarScheduleModel<SalesCalendarScheduleContent>
                {
                    Id = recordId,
                    Department = DepartmentType ?? "SALES",
                    CategoryId = categoryId,
                    StartDate = dtp_StartDate.Value,
                    EndDate = dtp_EndDate.Value,
                    Title = txt_Title.Text?.Trim() ?? string.Empty,
                    Description = rtxt_Description.Text?.Trim() ?? string.Empty,
                    Location = rtxt_Location.Text?.Trim() ?? string.Empty,
                    People = txt_People.Text?.Trim() ?? string.Empty,
                    Notes = rtxt_Notes.Text?.Trim() ?? string.Empty,
                    content = new SalesCalendarScheduleContent
                    {
                        ReferenceDocNo = data.TryGetValue("ReferenceDocNo", out var refdocno)
                            ? refdocno?.ToString()?.Trim() ?? string.Empty
                            : string.Empty,
                        ReferenceId = referenceId
                    }
                };

                return calendarSchedule;
            }
            catch (Exception ex)
            {
                Log.Error(ex, "Error building calendar schedule model");
                return null;
            }
        }

        private async void btn_delete_Click(object sender, EventArgs e)
        {
            if (!int.TryParse(txt_Id.Text, out int recordId) || recordId <= 0)
            {
                MessageBox.Show("No schedule to be deleted.");
                return;
            }
            string department = "SALES";

            try
            {
                btn_delete.Enabled = false;
                var response = await _calendarScheduleService.RemoveAsync(department, recordId);

                if (response?.Success == true)
                {
                    string successMessage = "Schedule updated successfully.";

                    Helpers.ShowDialogMessage("success", successMessage);

                    // Clear form for new records, keep data for updates
                    // LOAD EXISTING SCHEDULES
                    BtnToggle(false);
                }
                else
                {
                    string errorMessage = $"Failed to delete schedule.\n{response?.Message ?? "Unknown error occurred."}";

                    Helpers.ShowDialogMessage("error", errorMessage);
                    Log.Warning("Failed to delete calendar schedule. Response: {@Response}", response);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    ex.Message,
                    "Delete Failed",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );
                Log.Warning("Failed to save calendar schedule. Response: {@Response}", ex);
            }
            finally
            {
                btn_delete.Enabled = true;
            }
        }
    }
}
