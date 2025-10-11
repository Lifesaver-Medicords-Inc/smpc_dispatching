using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;



namespace smpc_dispatching.UI.Shared.Calendar {
    public partial class EventCalendar : UserControl {
        private DateTime _currentMonth = DateTime.Now;
        private readonly Func<CalendarCell> _createCell;
        private List<CalendarCell> _cells = new List<CalendarCell>();


        public EventCalendar(IServiceProvider serviceProvider) {
            InitializeComponent();
             _createCell = () => serviceProvider.GetRequiredService<CalendarCell>();
            SetupCalendarLayout();
            SetupCalendarHeader();
            FillCalendar(_currentMonth);
        }

        public DateTime CurrentDate {
            get => _currentMonth;
            set {
                _currentMonth = value;
                FillCalendar(value);
            }
        }


        private void SetupCalendarHeader() {
            HeaderTableLayoutPanel.Controls.Clear();
            HeaderTableLayoutPanel.ColumnCount = 7;
            HeaderTableLayoutPanel.RowCount = 1;
            HeaderTableLayoutPanel.CellBorderStyle = TableLayoutPanelCellBorderStyle.Single;
            HeaderTableLayoutPanel.GrowStyle = TableLayoutPanelGrowStyle.FixedSize;

            // --- Clear styles before adding new ones ---
            HeaderTableLayoutPanel.ColumnStyles.Clear();
            HeaderTableLayoutPanel.RowStyles.Clear();

            // --- Add 7 equal-width columns ---
            for (int i = 0; i < 7; i++) {
                HeaderTableLayoutPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100f / 7));
            }

            // --- Add single header row ---
            HeaderTableLayoutPanel.RowStyles.Add(new RowStyle(SizeType.Percent, 100f));

            // --- Add header labels ---
            string[] days = { "SUN", "MON", "TUE", "WED", "THU", "FRI", "SAT" };
            for (int i = 0; i < days.Length; i++) {
                var lbl = new Label {
                    Text = days[i],
                    TextAlign = ContentAlignment.MiddleCenter,
                    Dock = DockStyle.Fill,
                    Font = new Font("Segoe UI", 10, FontStyle.Bold),
                    BackColor = Color.White
                };
                HeaderTableLayoutPanel.Controls.Add(lbl, i, 0);
            }
        }

        private void SetupCalendarLayout() {
            CalendarTableLayoutPanel.Controls.Clear();
            CalendarTableLayoutPanel.ColumnCount = 7;
            CalendarTableLayoutPanel.RowCount = 6; // 6 weeks (rows)
            CalendarTableLayoutPanel.GrowStyle = TableLayoutPanelGrowStyle.FixedSize;
            CalendarTableLayoutPanel.CellBorderStyle = TableLayoutPanelCellBorderStyle.Single;

            // --- Column Styles (7 equal columns) ---
            CalendarTableLayoutPanel.ColumnStyles.Clear();
            for (int i = 0; i < 7; i++) {
                CalendarTableLayoutPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100f / 7));
            }

            // --- Row Styles (6 equal rows) ---
            CalendarTableLayoutPanel.RowStyles.Clear();
            for (int i = 0; i < 6; i++) {
                CalendarTableLayoutPanel.RowStyles.Add(new RowStyle(SizeType.Percent, 100f / 6));
            }

            // --- Create 6×7 = 42 calendar cells ---
            _cells.Clear();
            for (int row = 0; row < 6; row++) {
                for (int col = 0; col < 7; col++) {
                    var cell = _createCell();
                    cell.Dock = DockStyle.Fill;
                    cell.Margin = Padding.Empty;
                    CalendarTableLayoutPanel.Controls.Add(cell, col, row);
                    _cells.Add(cell);
                }
            }
        }

        private void FillCalendar(DateTime date) {
            DateTime firstDay = new DateTime(_currentMonth.Year, _currentMonth.Month, 1);
            int daysInMonth = DateTime.DaysInMonth(_currentMonth.Year, _currentMonth.Month);
            int startColumn = (int)firstDay.DayOfWeek;

            int dayIndex = 0;

            for (int i = 0; i < _cells.Count; i++) {
                var cell = _cells[i];
                int row = i / 7;
                int col = i % 7;

                if ((row == 0 && col < startColumn) || dayIndex >= daysInMonth) {
                    cell.Visible = false;
                    continue;
                }

                dayIndex++;
                DateTime currentDate = new DateTime(_currentMonth.Year, _currentMonth.Month, dayIndex);
                cell.SetDate(currentDate);
                cell.Visible = true;
            }

        }

        //private void prevBtn_Click(object sender, EventArgs e) {
        //    _currentMonth = _currentMonth.AddMonths(-1);
        //    FillCalendar(_currentMonth);
        //}

        //private void nextBtn_Click(object sender, EventArgs e) {
        //    _currentMonth = _currentMonth.AddMonths(1);
        //    FillCalendar(_currentMonth);
        //}
    }
}
