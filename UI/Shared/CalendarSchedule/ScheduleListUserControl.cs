using Serilog;
using smpc_dispatching.Core.Interfaces;
using smpc_dispatching.Core.Models;
using smpc_dispatching.UI.Shared.CalendarSchedule;
using smpc_dispatching.UI.Views.Engineering;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace smpc_dispatching.UI.Shared.CalendarEvent
{
    public partial class ScheduleListUserControl : UserControl
    {
        private static readonly Color[] _badgePalette =
        {
            Color.SteelBlue,
            Color.DarkOrange,
            Color.MediumSeaGreen,
            Color.MediumPurple,
            Color.IndianRed,
            Color.Teal,
        };

        private readonly ICalendarScheduleService<SalesCalendarScheduleContent> _calendarScheduleService;
        private readonly ICalendarCategoryService _calendarCategoryService;

        private Dictionary<int, string> _categoryNames = new Dictionary<int, string>();
        private Dictionary<int, Color> _categoryColors = new Dictionary<int, Color>();

        private string _department = "SALES";
        private List<CalendarScheduleModel<SalesCalendarScheduleContent>> _currentSchedules =
            new List<CalendarScheduleModel<SalesCalendarScheduleContent>>();

        public event Action<int> OnEditRequested;
        // Raised after a successful delete — the parent owns the authoritative schedule
        // list (used by both the calendar and this list), so it reloads and re-pushes here.
        public event Func<Task> OnScheduleListChanged;

        public ScheduleListUserControl(
            ICalendarScheduleService<SalesCalendarScheduleContent> calendarScheduleService,
            ICalendarCategoryService calendarCategoryService)
        {
            InitializeComponent();
            _calendarScheduleService = calendarScheduleService;
            _calendarCategoryService = calendarCategoryService;
        }

        public async Task LoadSchedules(string department, List<CalendarScheduleModel<SalesCalendarScheduleContent>> schedules)
        {
            _department = string.IsNullOrWhiteSpace(department) ? "SALES" : department.ToUpperInvariant();

            if (!_categoryNames.Any())
                await LoadCategoriesAsync();

            var data = schedules ?? new List<CalendarScheduleModel<SalesCalendarScheduleContent>>();

            if (!data.Any())
            {
                var queryParams = new Dictionary<string, string> { { "department", _department } };
                var response = await _calendarScheduleService.GetAllAsync(queryParams);

                if (response == null)
                {
                    Log.Error("Error getting calendar schedules for {department}", _department);
                    MessageBox.Show(
                        "Failed to load calendar schedules.",
                        "Error",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error
                    );
                    data = new List<CalendarScheduleModel<SalesCalendarScheduleContent>>();
                }
                else
                {
                    data = response.Data?.ToList() ?? new List<CalendarScheduleModel<SalesCalendarScheduleContent>>();
                }
            }

            _currentSchedules = data;
            RenderScheduleCards();
        }

        private async Task LoadCategoriesAsync()
        {
            try
            {
                var res = await _calendarCategoryService.GetAllAsync(null);
                var categories = res?.Data?.ToList() ?? new List<CalendarCategoryModel>();

                _categoryNames = new Dictionary<int, string>();
                _categoryColors = new Dictionary<int, Color>();

                for (int i = 0; i < categories.Count; i++)
                {
                    var category = categories[i];
                    if (!category.id.HasValue) continue;

                    int id = (int)category.id.Value;
                    _categoryNames[id] = category.Name;
                    _categoryColors[id] = _badgePalette[i % _badgePalette.Length];
                }
            }
            catch (Exception ex)
            {
                Log.Error(ex, "Error getting calendar categories");
            }
        }

        private void RenderScheduleCards()
        {
            flp_schedule_items.SuspendLayout();
            flp_schedule_items.Controls.Clear();

            int cardWidth = Math.Max(flp_schedule_items.ClientSize.Width - 4, 400);

            foreach (var schedule in _currentSchedules)
            {
                var card = new ScheduleItemUC { Width = cardWidth };

                int categoryId = (int)schedule.CategoryId;
                _categoryNames.TryGetValue(categoryId, out var categoryName);
                var badgeColor = _categoryColors.TryGetValue(categoryId, out var color) ? color : _badgePalette[0];

                card.Bind(schedule, categoryName, badgeColor);

                int scheduleId = schedule.Id;
                card.OnEditClick += () => OnEditRequested?.Invoke(scheduleId);
                card.OnDeleteClick += async () => await DeleteSchedule(scheduleId);

                flp_schedule_items.Controls.Add(card);
            }

            flp_schedule_items.ResumeLayout();
        }

        private async Task DeleteSchedule(int id)
        {
            var confirm = MessageBox.Show(
                "Delete this schedule?",
                "Confirm Delete",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Warning
            );

            if (confirm != DialogResult.Yes) return;

            var response = await _calendarScheduleService.RemoveAsync(_department.ToLowerInvariant(), id);

            if (response == null || !response.Success)
            {
                MessageBox.Show("Failed to delete schedule.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (OnScheduleListChanged != null)
                await OnScheduleListChanged.Invoke();
        }

        private void lbl_view_all_Click(object sender, EventArgs e)
        {

        }
    }
}
