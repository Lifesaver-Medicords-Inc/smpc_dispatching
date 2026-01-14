using Microsoft.Extensions.DependencyInjection;
using smpc_dispatching.Core.Models;
using smpc_dispatching.UI.Shared.Calendar;
using System;
using System.Collections.Generic;
using System.Windows.Forms;
using static smpc_dispatching.UI.Shared.Calendar.ScheduleCalendarUserControl;

namespace smpc_dispatching.UI.Shared.CalendarEvent {
    public partial class CalendarScheduleControllerUserControl : UserControl {

        public string DepartmentType { get; private set; }
        private readonly ScheduleCalendarUserControl _scheduleCalendarUserControl;
        private readonly ScheduleListUserControl _scheduleListUserControl;
        private readonly ScheduleDetailsUserControl _scheduleDetailsUserControl;


        private List<CalendarScheduleModel> _schedules = new List<CalendarScheduleModel> {
            new CalendarScheduleModel {
                DepartmentType = "Logistics",
                Title = "Truck Delivery #SO1001",
                StartDate = new DateTime(2025, 10, 10),
                EndDate = new DateTime(2025, 10, 13)
            },
            new CalendarScheduleModel {
                DepartmentType = "Sales",
                Title = "Client Visit - Manila",
                StartDate = new DateTime(2025, 5, 15),
                EndDate = new DateTime(2025, 10, 15)
            },
            new CalendarScheduleModel {
                DepartmentType = " ",
                Title = "Client Visit - Manila",
                StartDate = new DateTime(2025, 10, 15),
                EndDate = new DateTime(2025, 10, 18)
            },
            new CalendarScheduleModel {
                DepartmentType = "Engineering",
                Title = "Client Visit - Manila",
                StartDate = new DateTime(2025, 10, 10),
                EndDate = new DateTime(2025, 10, 28)
            }
        };

        private CalendarDateRange _dateRange = new CalendarDateRange {
            StartDate = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1),
            EndDate = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1)
                    .AddMonths(1)
                    .AddDays(-1)
        };


        private Boolean IsMonthView = true;

        public CalendarScheduleControllerUserControl(IServiceProvider serviceProvider) {
            InitializeComponent();

            DepartmentType = departmentType;
            _scheduleCalendarUserControl = serviceProvider.GetRequiredService<ScheduleCalendarUserControl>();
            _scheduleListUserControl = serviceProvider.GetRequiredService<ScheduleListUserControl>();
            _scheduleDetailsUserControl = serviceProvider.GetRequiredService<ScheduleDetailsUserControl>();

            CalendarSwitchViewBtn.Text = !IsMonthView ? "MONTH" : "WEEK";
        }

        public string Title {
            get => null;
            set {
                CalendarTitleLabel.Text = value;
            }
        }


        private void CalendarEventController_Load(object sender, EventArgs e) {

            EventSplitContainer.Panel2.Controls.Clear();
            _scheduleListUserControl.Dock = DockStyle.Fill;
            EventSplitContainer.Panel2.Controls.Add(_scheduleListUserControl);

            MainSplitContainer.Panel2.Controls.Clear();
            _scheduleDetailsUserControl.Dock = DockStyle.Top;
            MainSplitContainer.Panel2.Controls.Add(_scheduleDetailsUserControl);

            SetDateLabel();
            LoadCalendar();
            LoadScheduleList();


        }

        private void LoadCalendar() {
            if (_scheduleCalendarUserControl != null) {

                _scheduleCalendarUserControl.Dock = DockStyle.Fill;
                CalendarSplitContainer.Panel2.Controls.Clear();
                CalendarSplitContainer.Panel2.Controls.Add(_scheduleCalendarUserControl);



                _scheduleCalendarUserControl.DateRange = _dateRange;
                _scheduleCalendarUserControl.LoadCalendar();
                _scheduleCalendarUserControl.LoadEvents(_schedules);

            }
        }

        private void SetDateLabel() {
            DateLabel.Text = $"{_dateRange.StartDate.ToString("MMMMM yyyy")}".ToUpper();
        }

        private void PrevBtn_Click(object sender, EventArgs e) {
            if (IsMonthView) {
                _dateRange.StartDate = _dateRange.StartDate.AddMonths(-1);
                _dateRange.EndDate = _dateRange.StartDate.AddMonths(1).AddDays(-1);
            } else {
                _dateRange.StartDate = _dateRange.StartDate.AddDays(-7);
                _dateRange.EndDate = _dateRange.StartDate.AddDays(7);
            }

            SetDateLabel();
            LoadCalendar();
        }

        private void NextBtn_Click(object sender, EventArgs e) {
            if (IsMonthView) {
                _dateRange.StartDate = _dateRange.StartDate.AddMonths(1);
                _dateRange.EndDate = _dateRange.StartDate.AddMonths(1).AddDays(-1);
            } else {
                _dateRange.StartDate = _dateRange.StartDate.AddDays(7);
                _dateRange.EndDate = _dateRange.StartDate.AddDays(7);
            }

            SetDateLabel();
            LoadCalendar();
        }



        private void CalendarSwitchViewBtn_Click(object sender, EventArgs e) {

            IsMonthView = !IsMonthView;

            if (IsMonthView) {
                _dateRange = new CalendarDateRange {
                    StartDate = new DateTime(_dateRange.StartDate.Year, _dateRange.StartDate.Month, 1),
                    EndDate = new DateTime(_dateRange.StartDate.Year, _dateRange.StartDate.Month, 1)
                       .AddMonths(1)
                       .AddDays(-1)
                };


            } else {
                _dateRange = new CalendarDateRange {
                    StartDate = new DateTime(_dateRange.StartDate.Year, _dateRange.StartDate.Month, 1),
                    EndDate = new DateTime(_dateRange.StartDate.Year, _dateRange.StartDate.Month, 7),
                };

            }


            SetDateLabel();
            _scheduleCalendarUserControl.DateRange = _dateRange;
            LoadCalendar();
            CalendarSwitchViewBtn.Text = !IsMonthView ? "MONTH" : "WEEK";

        }

        private void LoadScheduleList() {
            _scheduleListUserControl.LoadSchedules(_schedules);
        }
    }
}

