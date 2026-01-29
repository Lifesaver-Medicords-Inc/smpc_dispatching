using Microsoft.Extensions.DependencyInjection;
using Serilog;
using smpc_dispatching.Core.Helpers;
using smpc_dispatching.Core.Interfaces;
using smpc_dispatching.Core.Models;
using smpc_dispatching.Core.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace smpc_dispatching.UI.Shared.CalendarEvent {
    public partial class ScheduleDetailsUserControl : UserControl {

        private readonly IServiceProvider _serviceProvider;
        private readonly ICalendarCategoryService _calendarCategoryService;
        private readonly IVehicleService _vehicleService;
        private readonly ICalendarScheduleService<SalesCalendarScheduleContent> _calendarScheduleService;
        private List<CalendarCategoryModel> _categories;
        private List<VehicleModel> _vehicles;

        public ScheduleDetailsUserControl(ICalendarScheduleService<SalesCalendarScheduleContent> calendarSchedule, ICalendarCategoryService calendarCategoryService, IVehicleService vehicleService, IServiceProvider serviceProvider)
        {
            InitializeComponent();
            _serviceProvider = serviceProvider;
            _calendarCategoryService = calendarCategoryService;
            _vehicleService = vehicleService;
            _calendarScheduleService = calendarSchedule;
        }

        private void PinMapBtn_Click(object sender, EventArgs e) {
            if (InvokeRequired) {
                BeginInvoke((Action)(() => PinMapBtn_Click(sender, e)));
                return;
            }


            using (var mapForm = _serviceProvider.GetRequiredService<MapLocPinForm>()) {
                var result = mapForm.ShowDialog();
                if (result == DialogResult.OK && mapForm.SelectedPoint != null) {
                    rtxt_Location.Text = mapForm.SelectedAddress;
                }

            }
        }

        private async void ScheduleDetailsUserControl_Load(object sender, EventArgs e)
        { 
            BtnToggle(false);
            await LoadCategoriesAsync();
            await LoadVehicleAsync();
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

        private async Task LoadVehicleAsync()
        {
            try
            {
                var res = await _vehicleService.GetAllAsync(null);

                if (res?.Success == true)
                {
                    _vehicles = res.Data.ToList();
                }

                cmb_Vehicle.DropDownStyle = ComboBoxStyle.DropDownList;

                cmb_Vehicle.DataSource = _vehicles;
                cmb_Vehicle.DisplayMember = "Type";
                cmb_Vehicle.ValueMember = "Id";
            }
            catch (Exception ex)
            {
                Log.Error(ex, "Error getting vehicles");
                MessageBox.Show(
                    "Failed to load vehicles.",
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );
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

            btn_save.Visible = isEdit;
            btn_close.Visible = isEdit;
            flowLayoutPanel3.Enabled = isEdit;
            
        }
        private async void btn_save_Click(object sender, EventArgs e)
        {
            // validate data
            // get data

            var data = Helpers.GetControlsValues(new[] { flowLayoutPanel3, panel2 });

            var calendarSchedule = new CalendarScheduleModel<SalesCalendarScheduleContent>
            {

                Department = "SALES",
                CategoryId = data.TryGetValue("CategoryId", out var category) ? Convert.ToUInt16(category) : 0,
                StartDate = data.TryGetValue("StartDate", out var start) ? Convert.ToDateTime(start) : DateTime.MinValue,
                EndDate = data.TryGetValue("EndDate", out var end) ? Convert.ToDateTime(end) : DateTime.MinValue,
                Title = data.TryGetValue("Title", out var title) ? title?.ToString() : "",
                Description = data.TryGetValue("Description", out var desc) ? desc?.ToString() : "",
                People = data.TryGetValue("ReferenceType", out var refType) ? refType?.ToString() : "",
                Notes = data.TryGetValue("Notes", out var notes) ? notes?.ToString() : "",

                content = new SalesCalendarScheduleContent
                {
                    ReferenceDocNo = data.TryGetValue("ReferenceDocNo", out var refdocno) ? refdocno?.ToString() : "",
                    ReferenceId = data.TryGetValue("ReferenceId", out var refid) ? Convert.ToUInt16(refid) : 0,
                }
            };

            // CHECK IF RECORD IS EXISTING

            var res = await _calendarScheduleService.CreateAsync(calendarSchedule);

            if (res == null || !res.Success)
            {
                MessageBox.Show("Saving failed");
                return;
            }

            MessageBox.Show("Success!");
            // RELOAD NEW ADDED DATA
            BtnToggle(false);
        }

        private void btn_new_Click(object sender, EventArgs e)
        {
            BtnToggle(true);
            Helpers.ResetControls(flowLayoutPanel3);
        }

        private async void btn_close_Click(object sender, EventArgs e)
        {
            BtnToggle(false);

            
        }

        private void btn_edit_Click(object sender, EventArgs e)
        {
            BtnToggle(true);
        }
    }
}
