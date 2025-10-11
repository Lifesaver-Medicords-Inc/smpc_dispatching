using Microsoft.Extensions.DependencyInjection;
using smpc_dispatching.UI.Shared.CalendarEvent;
using System;
using System.Windows.Forms;

namespace smpc_dispatching.UI.Views.Engineering {
    public partial class EngineeringView : UserControl {

        private readonly IServiceProvider _serviceProvider;
        public EngineeringView(IServiceProvider serviceProvider) {
            InitializeComponent();
            _serviceProvider = serviceProvider;
        }

        private void EngineeringView_Load(object sender, EventArgs e) {
            var eventCalendar = _serviceProvider.GetRequiredService<CalendarEventController>();
            if (eventCalendar != null) {
                eventCalendar.Dock = DockStyle.Fill;
                eventCalendar.Title = "ENGINEERING CALENDAR";
                EngineeringViewPanel.Controls.Clear();
                EngineeringViewPanel.Controls.Add(eventCalendar);
            }
        }

    }
}
