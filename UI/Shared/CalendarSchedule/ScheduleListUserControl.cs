using Serilog;
using smpc_dispatching.Core.Interfaces;
using smpc_dispatching.Core.Models;
using smpc_dispatching.UI.Views.Engineering;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace smpc_dispatching.UI.Shared.CalendarEvent
{
    public partial class ScheduleListUserControl : UserControl
    {

        private readonly ICalendarScheduleService<SalesCalendarScheduleContent> _calendarScheduleService;

        public ScheduleListUserControl(ICalendarScheduleService<SalesCalendarScheduleContent> calendarScheduleService)
        {
            InitializeComponent();
            _calendarScheduleService = calendarScheduleService;
        }


        public async Task LoadSchedules(string department, List<CalendarScheduleModel<SalesCalendarScheduleContent>> schedules)
        {
            var data = schedules ?? new List<CalendarScheduleModel<SalesCalendarScheduleContent>>();

            if (!data.Any())
            {
                var departmentCode = string.IsNullOrWhiteSpace(department) ? "SALES" : department.ToUpperInvariant();
                var queryParams = new Dictionary<string, string>
                {
                    { "department", departmentCode }
                };

                var response = await _calendarScheduleService.GetAllAsync(queryParams);

                if (response == null)
                {
                    Log.Error("Error getting calendar schedules for {department}", departmentCode);
                    MessageBox.Show(
                        "Failed to load calendar schedules.",
                        "Error",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error
                    );
                    data = new List<CalendarScheduleModel<SalesCalendarScheduleContent>>();
                }
                else
                {
                    data = response.Data?.ToList() ?? new List<CalendarScheduleModel<SalesCalendarScheduleContent>>();
                }
            }
            dg_schedule.AutoGenerateColumns = true;
            dg_schedule.DataSource = data.ToList();


        }

        private async void dg_schedule_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            //if (e.RowIndex < 0) return;

            //// Get selected schedule model
            //var schedule = dg_schedule.Rows[e.RowIndex].DataBoundItem
            //               as CalendarScheduleModel<SalesCalendarScheduleContent>;

            //if (schedule == null) return;

            //// Get ID from schedule
            //int id = schedule.Id; // <- ensure your model has Id

            //// Determine department
            //string dept = schedule.Department?? "SALES";

            //// Call the right details control
            //await OpenDetailsByDepartment(dept, id);
        }
        private async Task OpenDetailsByDepartment(string department, int id)
        {
            //department = department?.ToUpperInvariant() ?? "SALES";

            //switch (department)
            //{
            //    case "ENGINEERING":
            //        // Use EngineeringDetails control
            //        var engDetails = _serviceProvider.GetService(typeof(EngineeringScheduleCalendarDetailsUC))
            //                           as EngineeringScheduleCalendarDetailsUC;
            //        await engDetails.LoadDetails(id);
            //        break;

            //    case "LOGISTICS":
            //        var logDetails = _serviceProvider.GetService(typeof(LogisticsScheduleCalendarDetailsUC))
            //                           as LogisticsScheduleCalendarDetailsUC;
            //        await logDetails.LoadDetails(id);
            //        break;

            //    default:
            //        var salesDetails = _serviceProvider.GetService(typeof(SalesScheduleCalendarDetailsUC))
            //                           as SalesScheduleCalendarDetailsUC;
            //        await salesDetails.LoadDetails(id);
            //        break;
            //}
        }
    }

}