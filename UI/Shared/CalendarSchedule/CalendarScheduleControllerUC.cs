using Microsoft.Extensions.DependencyInjection;
using smpc_dispatching.Core.Interfaces;
using smpc_dispatching.Core.Models;
using smpc_dispatching.UI.Shared.Calendar;
using smpc_dispatching.UI.Views.Engineering;
using smpc_dispatching.UI.Views.Sales;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using static smpc_dispatching.UI.Shared.Calendar.ScheduleCalendarUC;

namespace smpc_dispatching.UI.Shared.CalendarEvent
{
    public partial class CalendarScheduleControllerUC : UserControl
    {

        private readonly ScheduleCalendarUC _scheduleCalendarUserControl;
        private readonly ScheduleListUserControl _scheduleListUserControl;
        private readonly ScheduleDetailsUserControl _scheduleDetailsUserControl;
        private readonly ICalendarScheduleService<SalesCalendarScheduleContent> _calendarScheduleService;
        private readonly ICalendarCategoryService _calendarCategoryService;
        private Dictionary<int, CalendarCategoryModel> _categoryLookup = new Dictionary<int, CalendarCategoryModel>();
        private readonly IRouteService _routeService;


        private List<CalendarScheduleModel<SalesCalendarScheduleContent>> _schedules = new List<CalendarScheduleModel<SalesCalendarScheduleContent>>();

        private CalendarDateRange _dateRange = new CalendarDateRange
        {
            StartDate = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1),
            EndDate = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1)
                    .AddMonths(1)
                    .AddDays(-1)
        };


        private Boolean IsMonthView = true;

        public CalendarScheduleControllerUC(IServiceProvider serviceProvider)
        {
            InitializeComponent();

            _routeService = serviceProvider.GetRequiredService<IRouteService>();
            _calendarScheduleService = serviceProvider.GetRequiredService<ICalendarScheduleService<SalesCalendarScheduleContent>>();

            // CALENDAR
            _scheduleCalendarUserControl = serviceProvider.GetRequiredService<ScheduleCalendarUC>();
            // SCHEDULE DETAILS
            _scheduleDetailsUserControl = serviceProvider.GetRequiredService<ScheduleDetailsUserControl>();
            _scheduleDetailsUserControl.OnSaved += LoadSchedulesAsync;

            // SCHEDULE LIST
            _scheduleListUserControl = serviceProvider.GetRequiredService<ScheduleListUserControl>();
            _scheduleListUserControl.OnScheduleListChanged += LoadSchedulesAsync;
            _scheduleListUserControl.OnEditRequested += scheduleId =>
            {
                var schedule = _schedules.FirstOrDefault(s => s.Id == scheduleId);
                if (schedule != null)
                    _scheduleDetailsUserControl.EnterEditMode(schedule);
            };
            //_salesScheduleCalendarDetails = serviceProvider.GetRequiredService<SalesCalendarScheduleDetailsUC>();
            //_engineeringScheduleCalendarDetails = serviceProvider.GetRequiredService<EngineeringScheduleCalendarDetailsUC>();
            //_logisticsScheduleCalendarDetails = serviceProvider.GetRequiredService<LogisticsCalendarScheduleDetailsUC>();

            CalendarSwitchViewBtn.Text = !IsMonthView ? "MONTH" : "WEEK";
        }
            
        public string Title
        {
            get => null;
            set
            {
                CalendarTitleLabel.Text = value;
            }
        }


        private async void CalendarEventController_Load(object sender, EventArgs e)
        {

            EventSplitContainer.Panel2.Controls.Clear();
            _scheduleListUserControl.Dock = DockStyle.Fill;
            EventSplitContainer.Panel2.Controls.Add(_scheduleListUserControl);

            MainSplitContainer.Panel2.Controls.Clear(); 

            var detailControl = GetDetailControlByDepartment();
            if (detailControl != null)
            {
                detailControl.Dock = DockStyle.Top;
                MainSplitContainer.Panel2.Controls.Add(detailControl);

            }

            // Automatically set title from route service if not already set
            if (string.IsNullOrEmpty(CalendarTitleLabel.Text) && _routeService != null)
            {
                var selectedRoute = _routeService.GetSelectedRoute();
                if (!string.IsNullOrEmpty(selectedRoute))
                {
                    Title = _routeService.GetTitle(selectedRoute).ToUpper();
                }
            }

            SetDateLabel();
            await LoadSchedulesAsync();


        }
        
        private string GetDepartmentFromRoute()
        {
            var selectedRoute = _routeService?.GetSelectedRoute();
            var routeKey = string.IsNullOrWhiteSpace(selectedRoute) ? string.Empty : selectedRoute.ToUpper();

            switch (routeKey)
            {
                case "SALES_CALENDAR":
                    return "SALES";
                case "ENGINEERING_CALENDAR":
                    return "ENGINEERING";
                case "LOGISTICS_CALENDAR":
                    return "LOGISTICS";
                default:
                    return "SALES";
            }
        }

        private async Task LoadSchedulesAsync()
        {
            var department = GetDepartmentFromRoute();
            var queryParams = new Dictionary<string, string>
            {
                { "department", department }
            };

            var response = await _calendarScheduleService.GetAllAsync(queryParams);

            if (response == null)
            {
                MessageBox.Show(
                    "Failed to load calendar schedules.",
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );
                _schedules = new List<CalendarScheduleModel<SalesCalendarScheduleContent>>();
            }
            else
            {
                
                _schedules = response.Data?.ToList() ?? new List<CalendarScheduleModel<SalesCalendarScheduleContent>>();
            }

            LoadCalendar();
            await _scheduleListUserControl.LoadSchedules(department, _schedules);
        }

        private void LoadCalendar()
        {
            if (_scheduleCalendarUserControl == null) 
                return;
            
            _scheduleCalendarUserControl.Dock = DockStyle.Fill;
            CalendarSplitContainer.Panel2.Controls.Clear();
            CalendarSplitContainer.Panel2.Controls.Add(_scheduleCalendarUserControl);
            
            _scheduleCalendarUserControl.DateRange = _dateRange;
            _scheduleCalendarUserControl.LoadCalendar();
            // schedule list
            _scheduleCalendarUserControl.LoadEvents(_schedules);

            
        }

        private void SetDateLabel()
        {
            DateLabel.Text = $"{_dateRange.StartDate.ToString("MMMMM yyyy")}".ToUpper();
        }

        private void PrevBtn_Click(object sender, EventArgs e)
        {
            if (IsMonthView)
            {
                _dateRange.StartDate = _dateRange.StartDate.AddMonths(-1);
                _dateRange.EndDate = _dateRange.StartDate.AddMonths(1).AddDays(-1);
            }
            else
            {
                _dateRange.StartDate = _dateRange.StartDate.AddDays(-7);
                _dateRange.EndDate = _dateRange.StartDate.AddDays(7);
            }

            SetDateLabel();
            LoadCalendar();
        }

        private void NextBtn_Click(object sender, EventArgs e)
        {
            if (IsMonthView)
            {
                _dateRange.StartDate = _dateRange.StartDate.AddMonths(1);
                _dateRange.EndDate = _dateRange.StartDate.AddMonths(1).AddDays(-1);
            }
            else
            {
                _dateRange.StartDate = _dateRange.StartDate.AddDays(7);
                _dateRange.EndDate = _dateRange.StartDate.AddDays(7);
            }

            SetDateLabel();
            LoadCalendar();
        }



        private void CalendarSwitchViewBtn_Click(object sender, EventArgs e)
        {

            IsMonthView = !IsMonthView;

            if (IsMonthView)
            {
                _dateRange = new CalendarDateRange
                {
                    StartDate = new DateTime(_dateRange.StartDate.Year, _dateRange.StartDate.Month, 1),
                    EndDate = new DateTime(_dateRange.StartDate.Year, _dateRange.StartDate.Month, 1)
                       .AddMonths(1)
                       .AddDays(-1)
                };


            }
            else
            {
                _dateRange = new CalendarDateRange
                {
                    StartDate = new DateTime(_dateRange.StartDate.Year, _dateRange.StartDate.Month, 1),
                    EndDate = new DateTime(_dateRange.StartDate.Year, _dateRange.StartDate.Month, 7),
                };

            }


            SetDateLabel();
            _scheduleCalendarUserControl.DateRange = _dateRange;
            LoadCalendar();
            CalendarSwitchViewBtn.Text = !IsMonthView ? "MONTH" : "WEEK";

        }

        private Control GetDetailControlByDepartment()
        {
            var selectedRoute = _routeService?.GetSelectedRoute() ?? string.Empty;

            switch (selectedRoute.ToUpper())
            {
                case "SALES_CALENDAR":
                    return _scheduleDetailsUserControl;
                case "ENGINEERING_CALENDAR":
                    return _scheduleDetailsUserControl;
                case "LOGISTICS_CALENDAR":
                    return _scheduleDetailsUserControl;
                default:
                    return _scheduleDetailsUserControl;
            }
        }
        public async Task LoadCategoryAsync()
        {
            var response = await _calendarCategoryService.GetAllAsync(null);

            if (response?.Data == null)
                return;

            _categoryLookup = response.Data
                .Where(c => c.id.HasValue && c.id.Value > 0)
                .ToDictionary(
                c => (int)c.id.Value,
                c => c
                );
        }
        private string GetCategoryName(int? categoryId)
        {
            if (!categoryId.HasValue || categoryId.Value <= 0)
                return string.Empty;

            return _categoryLookup.TryGetValue(categoryId.Value, out var category)
                ? category.Name
                : string.Empty;
        }


    }
}

