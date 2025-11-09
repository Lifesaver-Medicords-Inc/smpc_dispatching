using Microsoft.Extensions.DependencyInjection;
using smpc_dispatching.UI.Shared.CalendarEvent;
using System;
using System.Windows.Forms;

namespace smpc_dispatching.UI.Views.Sales {
    public partial class SalesViewUserControl : UserControl {

        private readonly IServiceProvider _serviceProvider;
        public SalesViewUserControl(IServiceProvider serviceProvider) {
            InitializeComponent();
            _serviceProvider = serviceProvider;
        }

        private void SalesView_Load(object sender, EventArgs e) {
            var eventCalendar = _serviceProvider.GetRequiredService<CalendarScheduleControllerUserControl>();
            if (eventCalendar != null) {
                eventCalendar.Dock = DockStyle.Fill;
                eventCalendar.Title = "SALES CALENDAR";
                SalesViewPanel.Controls.Clear();
                SalesViewPanel.Controls.Add(eventCalendar);
            }
        }
    }
}
