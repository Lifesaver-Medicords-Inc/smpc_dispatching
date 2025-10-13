using Microsoft.Extensions.DependencyInjection;
using smpc_dispatching.UI.Shared.CalendarEvent;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace smpc_dispatching.UI.Views.Logistics {
    public partial class LogisticsViewUserControl : UserControl {
        public LogisticsViewUserControl() {
            InitializeComponent();
        }

        private readonly IServiceProvider _serviceProvider;
        public LogisticsViewUserControl(IServiceProvider serviceProvider) {
            InitializeComponent();
            _serviceProvider = serviceProvider;
        }

        private void LogisticsView_Load(object sender, EventArgs e) {
            var eventCalendar = _serviceProvider.GetRequiredService<CalendarEventControllerUserControl>();
            if (eventCalendar != null) {
                eventCalendar.Dock = DockStyle.Fill;
                eventCalendar.Title = "LOGISTICS CALENDAR";
                LegisticsViewPanel.Controls.Clear();
                LegisticsViewPanel.Controls.Add(eventCalendar);
            }
        }
    }
}
