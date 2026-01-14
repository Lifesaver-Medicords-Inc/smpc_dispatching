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

        public string DepartmentType { get; set; } = "";
        private readonly IServiceProvider _serviceProvider;
        private readonly ICalendarCategoryService _calendarCategoryService;
        private readonly ICalendarScheduleService _calendarScheduleService;
        private List<CalendarCategoryModel> _categories;

        public ScheduleDetailsUserControl(ICalendarScheduleService calendarSchedule, ICalendarCategoryService calendarCategoryService,IServiceProvider serviceProvider)
        {
            InitializeComponent();
            _serviceProvider = serviceProvider;
            _calendarCategoryService = calendarCategoryService;
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
                    rtxt_location.Text = mapForm.SelectedAddress;
                }

            }
        }

        private void btn_add_name_Click(object sender, EventArgs e)
        {

        }

        private async void ScheduleDetailsUserControl_Load(object sender, EventArgs e)
        {
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

        private void SaveBtn_Click(object sender, EventArgs e)
        {
            // validate data
            // get data

            var data = Helpers.GetControlsValues(new[] { flowLayoutPanel3, panel2 });

            var calendarSchedule = new CalendarScheduleModel
            {
                DepartmentType = DepartmentType,
                Title = data.TryGetValue("Title", out var title) ? title?.ToString() : "",
                Description = data.TryGetValue("Description", out var desc) ? desc?.ToString() : "",
                ReferenceType = data.TryGetValue("ReferenceType", out var refType) ? refType?.ToString() : "",
                //ReferenceID = data.TryGetValue("ReferenceID", out var refId) ? Convert.ToUInt32(refId) : 0,
                StartDate = data.TryGetValue("StartDate", out var start) ? Convert.ToDateTime(start) : DateTime.MinValue,
                EndDate = data.TryGetValue("EndDate", out var end) ? Convert.ToDateTime(end) : DateTime.MinValue
            };

            var res = _calendarScheduleService.CreateAsync(calendarSchedule);

            if (res == null || !res.Result.Success)
            {

                MessageBox.Show("Saving failed");
                return;
            }

            MessageBox.Show("Success!");


        }
    }
}
