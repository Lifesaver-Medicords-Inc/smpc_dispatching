using Microsoft.Extensions.DependencyInjection;
using smpc_dispatching.Core.Models;
using smpc_dispatching.UI.Shared.Calendar;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace smpc_dispatching.UI.Shared.CalendarEvent {
    public partial class CalendarEventControllerUserControl : UserControl {

        private DateTime _currentDate = DateTime.Now;
        private readonly EventCalendarUserControl _eventCalendarUserControl;
        private readonly SchedulesUserControl _schedulesUserControl;
        private readonly ScheduleDetailsUserControl _scheduleDetailsUserControl;
        public CalendarEventControllerUserControl(IServiceProvider serviceProvider) {
            InitializeComponent();
            _eventCalendarUserControl = serviceProvider.GetRequiredService<EventCalendarUserControl>();
            _schedulesUserControl = serviceProvider.GetRequiredService<SchedulesUserControl>();
            _scheduleDetailsUserControl = serviceProvider.GetRequiredService<ScheduleDetailsUserControl>();
        }

        public string Title {
            get => null;
            set {
                CalendarTitleLabel.Text = value;
            }
        }


        private void CalendarEventController_Load(object sender, EventArgs e) {
            SetDateLabel();
            LoadCalendar(_currentDate);

            EventSplitContainer.Panel2.Controls.Clear();
            _schedulesUserControl.Dock = DockStyle.Fill;
            EventSplitContainer.Panel2.Controls.Add(_schedulesUserControl);

            ScheduleDetailsPanel.Controls.Clear();
            _scheduleDetailsUserControl.Dock = DockStyle.Fill;
            ScheduleDetailsPanel.Controls.Add(_scheduleDetailsUserControl);


        }

        private void LoadCalendar(DateTime date) {
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

                _schedulesUserControl.CurrentDate = _currentDate;
                _eventCalendarUserControl.CurrentDate = date;
                _eventCalendarUserControl.LoadEvents(events);

            }
        }

        private void SetDateLabel() {
            DateLabel.Text = $"{_currentDate.ToString("MMMMM")} {_currentDate.Year}".ToUpper();
        }

        private void PrevBtn_Click(object sender, EventArgs e) {
            SetDateLabel();
            _currentDate = _currentDate.AddMonths(-1);
            LoadCalendar(_currentDate);
        }

        private void NextBtn_Click(object sender, EventArgs e) {
            SetDateLabel();
            _currentDate = _currentDate.AddMonths(1);
            LoadCalendar(_currentDate);
        }

    }
}
