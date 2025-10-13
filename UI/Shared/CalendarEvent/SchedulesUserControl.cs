using System;
using System.Windows.Forms;

namespace smpc_dispatching.UI.Shared.CalendarEvent {
    public partial class SchedulesUserControl : UserControl {

        private DateTime _currentDate;

        public SchedulesUserControl() {
            InitializeComponent();
        }


        public DateTime CurrentDate {
            get => _currentDate;
            set {
                _currentDate = value;
                Monthlabel.Text = $"MONTH:  {_currentDate.ToString("MMMMM")}".ToUpper();
                YearLabel.Text = $"YEAR:    {_currentDate.Year}".ToUpper();
            }
        }

        private void label2_Click(object sender, EventArgs e) {

        }
    }
}
