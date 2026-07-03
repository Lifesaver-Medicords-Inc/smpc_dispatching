using smpc_dispatching.Core.Models;
using smpc_dispatching.UI.Shared.CalendarEvent;
using System;
using System.ComponentModel;
using System.Drawing;
using System.Resources;
using System.Windows.Forms;

namespace smpc_dispatching.UI.Shared.CalendarSchedule {
    public partial class ScheduleItemUC : UserControl {
        // Reuse the pencil/trash icons already embedded for ScheduleDetailsUserControl's
        // toolstrip buttons instead of guessing at new icon assets/glyphs.
        private static readonly ComponentResourceManager _iconResources =
            new ComponentResourceManager(typeof(ScheduleDetailsUserControl));

        public event Action OnEditClick;
        public event Action OnDeleteClick;

        public int ScheduleId { get; private set; }

        public ScheduleItemUC() {
            InitializeComponent();

            pic_edit.Image = _iconResources.GetObject("btn_edit.Image") as Image;
            pic_delete.Image = _iconResources.GetObject("btn_delete.Image") as Image;

            pic_edit.Click += (s, e) => OnEditClick?.Invoke();
            pic_delete.Click += (s, e) => OnDeleteClick?.Invoke();
        }

        private void ScheduleItem_Load(object sender, EventArgs e) {
        }

        public void Bind(CalendarScheduleModel<SalesCalendarScheduleContent> schedule, string categoryName, Color badgeColor) {
            ScheduleId = schedule.Id;

            lbl_date_range.Text = FormatDateRange(schedule.StartDate, schedule.EndDate);

            pnl_badge.BackColor = badgeColor;
            lbl_badge.Text = string.IsNullOrWhiteSpace(categoryName)
                ? (string.IsNullOrWhiteSpace(schedule.Title) ? "SCHEDULE" : schedule.Title.ToUpperInvariant())
                : categoryName.ToUpperInvariant();

            lbl_people.Text = string.IsNullOrWhiteSpace(schedule.People) ? "-" : schedule.People;
            lbl_time.Text = schedule.StartDate.ToString("h:mm tt");
            lbl_location.Text = string.IsNullOrWhiteSpace(schedule.Location) ? "-" : schedule.Location;

            // Client's CalendarScheduleBase has no vehicle field to resolve a name from.
            lbl_vehicle.Text = "-";

            lbl_description.Text = string.IsNullOrWhiteSpace(schedule.Description)
                ? "DESCRIPTION"
                : schedule.Description;

            lbl_notes.Text = string.IsNullOrWhiteSpace(schedule.Notes)
                ? "NOTES"
                : schedule.Notes;
        }

        private static string FormatDateRange(DateTime start, DateTime end) {
            if (end == DateTime.MinValue || end.Date == start.Date)
                return start.ToString("MMM. d, yyyy");

            return start.Month == end.Month && start.Year == end.Year
                ? $"{start:MMM. d} - {end:d, yyyy}"
                : $"{start:MMM. d, yyyy} - {end:MMM. d, yyyy}";
        }

        private void pic_edit_Click(object sender, EventArgs e)
        {

        }
    }
}
