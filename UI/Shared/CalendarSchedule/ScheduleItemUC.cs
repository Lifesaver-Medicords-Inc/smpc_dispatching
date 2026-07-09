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

        // Segoe UI Emoji glyphs used as lightweight, asset-free field icons — no icon
        // image files exist in this project, and this avoids adding new resources.
        private const string IconCalendar = "\U0001F4C5"; // 📅
        private const string IconPerson = "\U0001F464"; // 👤
        private const string IconClock = "\U0001F550"; // 🕐
        private const string IconLocation = "\U0001F4CD"; // 📍
        private const string IconVehicle = "\U0001F69A"; // 🚚

        public void Bind(CalendarScheduleModel<SalesCalendarScheduleContent> schedule, string categoryName, Color badgeColor, string vehicleName = null) {
            ScheduleId = schedule.Id;

            lbl_date_range.Text = $"{IconCalendar} {FormatDateRange(schedule.StartDate, schedule.EndDate)}";

            pnl_badge.BackColor = badgeColor;
            lbl_badge.Text = string.IsNullOrWhiteSpace(categoryName)
                ? (string.IsNullOrWhiteSpace(schedule.Title) ? "SCHEDULE" : schedule.Title.ToUpperInvariant())
                : categoryName.ToUpperInvariant();

            lbl_people.Text = $"{IconPerson} {(string.IsNullOrWhiteSpace(schedule.People) ? "-" : schedule.People)}";
            lbl_time.Text = $"{IconClock} {schedule.StartDate:h:mm tt}";

            // Logistics schedules carry a route list (each with its own address); other
            // departments only have the single free-text Location field. One route ->
            // show its address like a normal single-location schedule. Multiple routes ->
            // an address wouldn't be meaningful, so show a count instead.
            int routeCount = schedule.Routes?.Count ?? 0;
            string locationText = routeCount == 1
                ? (string.IsNullOrWhiteSpace(schedule.Routes[0].Location) ? "-" : schedule.Routes[0].Location)
                : routeCount > 1
                    ? $"{routeCount} ROUTES"
                    : (string.IsNullOrWhiteSpace(schedule.Location) ? "-" : schedule.Location);
            lbl_location.Text = $"{IconLocation} {locationText}";

            lbl_vehicle.Text = $"{IconVehicle} {(string.IsNullOrWhiteSpace(vehicleName) ? "-" : vehicleName)}";

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
