using Microsoft.Extensions.DependencyInjection;
using smpc_dispatching.Core.Models;
using smpc_dispatching.UI.Shared.Calendar;
using System;
using System.Collections.Generic;
using System.Windows.Forms;
using static smpc_dispatching.UI.Shared.Calendar.EventCalendarUserControl;

namespace smpc_dispatching.UI.Shared.CalendarEvent {
    public partial class CalendarEventControllerUserControl : UserControl {

        private readonly EventCalendarUserControl _eventCalendarUserControl;
        private readonly SchedulesUserControl _schedulesUserControl;
        private readonly ScheduleDetailsUserControl _scheduleDetailsUserControl;

        private CalendarDateRange _dateRange = new CalendarDateRange {
            StartDate = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1),
            EndDate = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1)
                    .AddMonths(1)
                    .AddDays(-1)
        };


        private Boolean IsMonthView = true;

        public CalendarEventControllerUserControl(IServiceProvider serviceProvider) {
            InitializeComponent();
            _eventCalendarUserControl = serviceProvider.GetRequiredService<EventCalendarUserControl>();
            _schedulesUserControl = serviceProvider.GetRequiredService<SchedulesUserControl>();
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
            SetDateLabel();
            LoadCalendar();

            EventSplitContainer.Panel2.Controls.Clear();
            _schedulesUserControl.Dock = DockStyle.Fill;
            EventSplitContainer.Panel2.Controls.Add(_schedulesUserControl);

            MainSplitContainer.Panel2.Controls.Clear();
            _scheduleDetailsUserControl.Dock = DockStyle.Top;
            MainSplitContainer.Panel2.Controls.Add(_scheduleDetailsUserControl);


        }

        private void LoadCalendar() {
            if (_eventCalendarUserControl != null) {

                _eventCalendarUserControl.Dock = DockStyle.Fill;
                CalendarSplitContainer.Panel2.Controls.Clear();
                CalendarSplitContainer.Panel2.Controls.Add(_eventCalendarUserControl);



                var events = new List<CalendarEventModel> {
                    new CalendarEventModel {
                        DepartmentType = "Logistics",
                        Title = "Truck Delivery #SO1001",
                        StartDate = new DateTime(2025, 10, 10),
                        EndDate = new DateTime(2025, 10, 13)
                    },
                    new CalendarEventModel {
                        DepartmentType = "Sales",
                        Title = "Client Visit - Manila",
                        StartDate = new DateTime(2025, 5, 15),
                        EndDate = new DateTime(2025, 10, 15)
                    },
                                 new CalendarEventModel {
                        DepartmentType = " ",
                        Title = "Client Visit - Manila",
                        StartDate = new DateTime(2025, 10, 15),
                        EndDate = new DateTime(2025, 10, 18)
                    },
                                              new CalendarEventModel {
                        DepartmentType = "Engineering",
                        Title = "Client Visit - Manila",
                        StartDate = new DateTime(2025, 10, 10),
                        EndDate = new DateTime(2025, 10, 28)
                    }
                };

                _eventCalendarUserControl.DateRange = _dateRange;
                _eventCalendarUserControl.LoadCalendar();
                _eventCalendarUserControl.LoadEvents(events);

            }
        }

        private void SetDateLabel() {
            DateLabel.Text = $"{_dateRange.StartDate.ToString("MMMMM")}".ToUpper();
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
            _eventCalendarUserControl.DateRange = _dateRange;
            LoadCalendar();
            CalendarSwitchViewBtn.Text = !IsMonthView ? "MONTH" : "WEEK";

        }
    }
}

