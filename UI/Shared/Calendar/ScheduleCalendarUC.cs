using smpc_dispatching.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace smpc_dispatching.UI.Shared.Calendar {
    public partial class ScheduleCalendarUC : UserControl {

        public class CalendarDateRange {
            public DateTime StartDate { get; set; }
            public DateTime EndDate { get; set; }
        }

        private CalendarDateRange _dateRange = new CalendarDateRange {
            StartDate = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1),
            EndDate = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1)
                    .AddMonths(1)
                    .AddDays(-1)
        };

        public event Action<CalendarScheduleModel<SalesCalendarScheduleContent>> OnEventClick;

        public ScheduleCalendarUC() {
            InitializeComponent();
            LoadCalendar();

            CalendarHarness.ItemDoubleClick += (s, e) => {
                if (e.Item?.Tag is CalendarScheduleModel<SalesCalendarScheduleContent> schedule)
                    OnEventClick?.Invoke(schedule);
            };

            // Double-clicking empty grid space otherwise spawns a blank item on the
            // calendar itself (independent of AllowNew). Schedules are only ever added
            // through the app's own Add New form, never directly on the calendar.
            CalendarHarness.ItemCreating += (s, e) => e.Cancel = true;
        }

        public CalendarDateRange DateRange {
            get => _dateRange;
            set {
                _dateRange = value;
            }
        }

        public void LoadCalendar() {

            CalendarHarness.SetViewRange(_dateRange.StartDate, _dateRange.EndDate);
            CalendarHarness.Invalidate();
            CalendarHarness.Refresh();
        }

        public void LoadEvents(IEnumerable<CalendarScheduleModel<SalesCalendarScheduleContent>> events) {

            CalendarHarness.BeginInvoke(new Action(() => {
                CalendarHarness.Items.Clear();

                var viewStart = CalendarHarness.ViewStart.Date;
                var viewEnd = CalendarHarness.ViewEnd.Date;

                foreach (var e in events) {
                    var start = e.StartDate.Date < viewStart ? viewStart : e.StartDate.Date;
                    var end = e.EndDate.Date > viewEnd ? viewEnd : e.EndDate.Date;
                    if (start > end)
                        continue;

                    var item = new WindowsFormsCalendar.CalendarItem(
                        CalendarHarness,
                        start,
                        end,
                        e.Title
                    );
                    item.Tag = e;
                    CalendarHarness.Items.Add(item);
                }

                CalendarHarness.Invalidate();
            }));
        }
    }
}
