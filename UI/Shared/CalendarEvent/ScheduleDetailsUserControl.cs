using Microsoft.Extensions.DependencyInjection;
using System;
using System.Windows.Forms;

namespace smpc_dispatching.UI.Shared.CalendarEvent {
    public partial class ScheduleDetailsUserControl : UserControl {


        private readonly IServiceProvider _serviceProvider;

        public ScheduleDetailsUserControl(IServiceProvider serviceProvider) {
            InitializeComponent();
            _serviceProvider = serviceProvider;
        }

        private void PinMapBtn_Click(object sender, EventArgs e) {
            if (InvokeRequired) {
                BeginInvoke((Action)(() => PinMapBtn_Click(sender, e)));
                return;
            }


            using (var mapForm = _serviceProvider.GetRequiredService<MapPickerForm>()) {
                var result = mapForm.ShowDialog();
                if (result == DialogResult.OK && mapForm.SelectedPoint != null) {
                    LocationRichTextBox.Text = mapForm.SelectedAddress;
                }

            }
        }

    }
}
