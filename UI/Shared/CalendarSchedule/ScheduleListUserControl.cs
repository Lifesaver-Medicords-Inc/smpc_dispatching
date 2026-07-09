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
        private readonly IVehicleService _vehicleService;

        private Dictionary<int, string> _categoryNames = new Dictionary<int, string>();
        private Dictionary<int, Color> _categoryColors = new Dictionary<int, Color>();
        private Dictionary<int, string> _vehicleNames = new Dictionary<int, string>();

        private static readonly string[] _monthNames =
        {
            "JANUARY", "FEBRUARY", "MARCH", "APRIL", "MAY", "JUNE",
            "JULY", "AUGUST", "SEPTEMBER", "OCTOBER", "NOVEMBER", "DECEMBER"
        };

        private const string AllFilterOption = "ALL";

        private string _department = "SALES";
        private List<CalendarScheduleModel<SalesCalendarScheduleContent>> _currentSchedules =
            new List<CalendarScheduleModel<SalesCalendarScheduleContent>>();

        public event Action<int> OnEditRequested;
        // Raised after a successful delete — the parent owns the authoritative schedule
        // list (used by both the calendar and this list), so it reloads and re-pushes here.
        public event Func<Task> OnScheduleListChanged;

        public ScheduleListUserControl(
            ICalendarScheduleService<SalesCalendarScheduleContent> calendarScheduleService,
            ICalendarCategoryService calendarCategoryService,
            IVehicleService vehicleService)
        {
            InitializeComponent();
            _calendarScheduleService = calendarScheduleService;
            _calendarCategoryService = calendarCategoryService;
            _vehicleService = vehicleService;

            SearchTextBox.TextChanged += (s, e) => RenderScheduleCards();

            cbo_month_filter.Items.Add(AllFilterOption);
            cbo_month_filter.Items.AddRange(_monthNames);
            cbo_month_filter.SelectedIndex = 0;
            cbo_month_filter.SelectedIndexChanged += (s, e) => RenderScheduleCards();

            cbo_year_filter.Items.Add(AllFilterOption);
            cbo_year_filter.SelectedIndex = 0;
            cbo_year_filter.SelectedIndexChanged += (s, e) => RenderScheduleCards();
        }

        public async Task LoadSchedules(string department, List<CalendarScheduleModel<SalesCalendarScheduleContent>> schedules)
        {
            _department = string.IsNullOrWhiteSpace(department) ? "SALES" : department.ToUpperInvariant();

            if (!_categoryNames.Any())
                await LoadCategoriesAsync();

            if (!_vehicleNames.Any())
                await LoadVehiclesAsync();

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
            PopulateYearFilter(null);
            RenderScheduleCards();
        }

        // Rebuilds the year dropdown from the years present in the loaded schedules.
        // Pass ensureYear to force a specific year into the list (e.g. when syncing from
        // the calendar to a month that has no schedules yet) and select it.
        private void PopulateYearFilter(int? ensureYear)
        {
            var years = _currentSchedules.Select(s => s.StartDate.Year).ToList();
            if (ensureYear.HasValue)
                years.Add(ensureYear.Value);
            if (!years.Any())
                years.Add(DateTime.Now.Year);

            string previousSelection = cbo_year_filter.SelectedItem as string;

            cbo_year_filter.Items.Clear();
            cbo_year_filter.Items.Add(AllFilterOption);
            foreach (var year in years.Distinct().OrderByDescending(y => y))
                cbo_year_filter.Items.Add(year.ToString());

            if (ensureYear.HasValue)
                cbo_year_filter.SelectedItem = ensureYear.Value.ToString();
            else if (previousSelection != null && cbo_year_filter.Items.Contains(previousSelection))
                cbo_year_filter.SelectedItem = previousSelection;
            else
                cbo_year_filter.SelectedIndex = 0;
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

        private async Task LoadVehiclesAsync()
        {
            try
            {
                var res = await _vehicleService.GetAllAsync(null);
                var vehicles = res?.Data?.ToList() ?? new List<VehicleModel>();

                _vehicleNames = vehicles
                    .Where(v => v.id.HasValue)
                    .ToDictionary(v => (int)v.id.Value, v => $"{v.Model} - {v.PlateNo}".Trim(' ', '-'));
            }
            catch (Exception ex)
            {
                Log.Error(ex, "Error getting vehicles");
            }
        }

        // Called by the parent calendar whenever its month/week view changes, so the
        // year/month dropdowns default to what's currently visible on the calendar.
        // The user can still change them independently afterwards.
        public void SetDateRangeFilter(DateTime startDate, DateTime endDate)
        {
            PopulateYearFilter(startDate.Year);
            cbo_month_filter.SelectedIndex = startDate.Month;
            RenderScheduleCards();
        }

        private IEnumerable<CalendarScheduleModel<SalesCalendarScheduleContent>> GetFilteredSchedules()
        {
            IEnumerable<CalendarScheduleModel<SalesCalendarScheduleContent>> result = _currentSchedules;

            if (cbo_year_filter.SelectedIndex > 0 && int.TryParse(cbo_year_filter.SelectedItem as string, out var year))
                result = result.Where(schedule => schedule.StartDate.Year == year);

            if (cbo_month_filter.SelectedIndex > 0)
            {
                int month = cbo_month_filter.SelectedIndex;
                result = result.Where(schedule => schedule.StartDate.Month == month);
            }

            string term = SearchTextBox.Text?.Trim();
            if (!string.IsNullOrWhiteSpace(term))
            {
                result = result.Where(schedule =>
                {
                    _categoryNames.TryGetValue((int)schedule.CategoryId, out var categoryName);

                    return MatchesTerm(schedule.Title, term)
                        || MatchesTerm(schedule.Description, term)
                        || MatchesTerm(schedule.Location, term)
                        || MatchesTerm(schedule.People, term)
                        || MatchesTerm(schedule.Notes, term)
                        || MatchesTerm(categoryName, term);
                });
            }

            return result;
        }

        private static bool MatchesTerm(string value, string term) =>
            !string.IsNullOrEmpty(value) && value.IndexOf(term, StringComparison.OrdinalIgnoreCase) >= 0;

        private void RenderScheduleCards()
        {
            flp_schedule_items.SuspendLayout();
            flp_schedule_items.Controls.Clear();

            int cardWidth = Math.Max(flp_schedule_items.ClientSize.Width - 4, 400);

            foreach (var schedule in GetFilteredSchedules())
            {
                var card = new ScheduleItemUC { Width = cardWidth };

                int categoryId = (int)schedule.CategoryId;
                _categoryNames.TryGetValue(categoryId, out var categoryName);
                var badgeColor = _categoryColors.TryGetValue(categoryId, out var color) ? color : _badgePalette[0];
                _vehicleNames.TryGetValue(schedule.VehicleId, out var vehicleName);

                card.Bind(schedule, categoryName, badgeColor, vehicleName);

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
