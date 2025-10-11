using System;
using System.Windows.Forms;

namespace smpc_dispatching.UI.Shared.Calendar {
    public partial class CalendarCell : UserControl {


        private DateTime _date;

        public CalendarCell() {
            InitializeComponent();
            this.AutoSize = false;  
            this.Dock = DockStyle.Fill;
            this.Margin = Padding.Empty;
            this.Padding = Padding.Empty;
        }

        public void SetDate(DateTime date) {
             labelDay.Text = date.Day.ToString();
            _date = date;
         }
    }
}
