using Microsoft.Extensions.DependencyInjection;
using smpc_dispatching.UI.Shared.Calendar;
using System;
using System.Windows.Forms;

namespace smpc_dispatching.UI.Shared.CalendarEvent {
    public partial class CalendarEventController : UserControl {

        private DateTime _currentDate = DateTime.Now;
        private readonly EventCalendar _eventCalendar;
        public CalendarEventController(IServiceProvider serviceProvider) {
            InitializeComponent();
            _eventCalendar = serviceProvider.GetRequiredService<EventCalendar>();
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
        }

        private void LoadCalendar(DateTime date) {
            if (_eventCalendar != null) {
                _eventCalendar.CurrentDate = _currentDate;
                _eventCalendar.Dock = DockStyle.Fill;
                CalendarSplitContainer.Panel2.Controls.Clear();
                CalendarSplitContainer.Panel2.Controls.Add(_eventCalendar);
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
