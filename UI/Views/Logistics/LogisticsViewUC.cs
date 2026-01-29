using Microsoft.Extensions.DependencyInjection;
using smpc_dispatching.UI.Shared.CalendarEvent;
using System;
using System.Windows.Forms;

namespace smpc_dispatching.UI.Views.Logistics {
    public partial class LogisticsViewUC : UserControl {
        public LogisticsViewUC() {
            InitializeComponent();
        }

        private readonly IServiceProvider _serviceProvider;
        public LogisticsViewUC(IServiceProvider serviceProvider) {
            InitializeComponent();
            _serviceProvider = serviceProvider;
        }

        private void LogisticsView_Load(object sender, EventArgs e) {
            var eventCalendar = _serviceProvider.GetRequiredService<CalendarScheduleControllerUC>();
            if (eventCalendar != null) {
                eventCalendar.Dock = DockStyle.Fill;
                eventCalendar.Title = "LOGISTICS CALENDAR";
                LegisticsViewPanel.Controls.Clear();
                LegisticsViewPanel.Controls.Add(eventCalendar);
            }
        }
    }
}
