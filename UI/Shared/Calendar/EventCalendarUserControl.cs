using smpc_dispatching.Core.Models;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace smpc_dispatching.UI.Shared.Calendar {
    public partial class EventCalendarUserControl : UserControl {
        private DateTime _currentMonth = DateTime.Now;
        private readonly Dictionary<DateTime, (int Row, int Col, Panel Cell)> _dateCells = new Dictionary<DateTime, (int, int, Panel)>();

        public event Action<CalendarEventModel> OnEventClick;

        private TableLayoutPanel HeaderTableLayoutPanel;
        private TableLayoutPanel CalendarTableLayoutPanel;
        private Panel calendarContainer;
        private Panel eventsOverlay;

        public EventCalendarUserControl() {
            InitializeComponent();
            BuildLayout();
            SetMonth(_currentMonth);
        }

        public DateTime CurrentDate {
            get => _currentMonth;
            set {
                _currentMonth = value;
            }
        }

        private void BuildLayout() {
            this.SuspendLayout();
            this.Dock = DockStyle.Fill;
            this.BackColor = Color.White;

            var mainLayout = new TableLayoutPanel {
                Dock = DockStyle.Fill,
                RowCount = 2,
                ColumnCount = 1
            };
            mainLayout.RowStyles.Add(new RowStyle(SizeType.Absolute, 30F));
            mainLayout.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));

            // Header row
            HeaderTableLayoutPanel = new TableLayoutPanel {
                Dock = DockStyle.Fill,
                RowCount = 1,
                ColumnCount = 7,
                CellBorderStyle = TableLayoutPanelCellBorderStyle.Single,
                BackColor = Color.White
            };
            string[] days = { "SUN", "MON", "TUE", "WED", "THU", "FRI", "SAT" };
            for (int i = 0; i < 7; i++) {
                HeaderTableLayoutPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100f / 7f));
                HeaderTableLayoutPanel.Controls.Add(new Label {
                    Text = days[i],
                    Dock = DockStyle.Fill,
                    TextAlign = ContentAlignment.MiddleCenter,
                    Font = new Font("Segoe UI", 9F, FontStyle.Bold),
                    BackColor = Color.White
                }, i, 0);
            }


            CalendarTableLayoutPanel = new TableLayoutPanel {
                Dock = DockStyle.Fill,
                RowCount = 6,
                ColumnCount = 7,
                CellBorderStyle = TableLayoutPanelCellBorderStyle.None,
                BackColor = Color.White
            };
            for (int i = 0; i < 7; i++)
                CalendarTableLayoutPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100f / 7f));
            for (int i = 0; i < 6; i++)
                CalendarTableLayoutPanel.RowStyles.Add(new RowStyle(SizeType.Percent, 100f / 6f));

            calendarContainer = new Panel { Dock = DockStyle.Fill, BackColor = Color.White };
            calendarContainer.Controls.Add(CalendarTableLayoutPanel);


            eventsOverlay = new Panel {
                Dock = DockStyle.Fill,
                BackColor = Color.Transparent
            };
            eventsOverlay.Paint += (s, e) => { };
            calendarContainer.Controls.Add(eventsOverlay);


            calendarContainer.Paint += CalendarContainer_Paint;

            mainLayout.Controls.Add(HeaderTableLayoutPanel, 0, 0);
            mainLayout.Controls.Add(calendarContainer, 0, 1);
            this.Controls.Add(mainLayout);

            this.ResumeLayout(false);
        }


        private void CalendarContainer_Paint(object sender, PaintEventArgs e) {
            int cellWidth = CalendarTableLayoutPanel.GetColumnWidths()[0];
            int cellHeight = CalendarTableLayoutPanel.GetRowHeights()[0];
            int xOffset = CalendarTableLayoutPanel.Location.X;
            int yOffset = CalendarTableLayoutPanel.Location.Y;

            using (Pen gridPen = new Pen(Color.LightGray, 1))
            using (Brush textBrush = new SolidBrush(Color.Black))
            using (Font textFont = new Font("Segoe UI", 8, FontStyle.Bold)) {

                for (int row = 0; row < 6; row++) {
                    for (int col = 0; col < 7; col++) {
                        int x = xOffset + col * cellWidth;
                        int y = yOffset + row * cellHeight;

                        e.Graphics.DrawRectangle(gridPen, x, y, cellWidth, cellHeight);


                        DateTime firstDay = new DateTime(_currentMonth.Year, _currentMonth.Month, 1);
                        int startCol = (int)firstDay.DayOfWeek;
                        int dayIndex = row * 7 + col - startCol + 1;

                        if (dayIndex >= 1 && dayIndex <= DateTime.DaysInMonth(_currentMonth.Year, _currentMonth.Month)) {
                            string dayText = dayIndex.ToString();


                            e.Graphics.DrawString(
                                dayText,
                                textFont,
                                textBrush,
                                x + cellWidth - 20,
                                y + 5
                            );
                        }
                    }
                }
            }
        }


        private void FillCalendar(DateTime month) {
            CalendarTableLayoutPanel.SuspendLayout();
            CalendarTableLayoutPanel.Controls.Clear();
            _dateCells.Clear();

            DateTime firstDay = new DateTime(month.Year, month.Month, 1);
            int daysInMonth = DateTime.DaysInMonth(month.Year, month.Month);
            int startCol = (int)firstDay.DayOfWeek;
            int day = 1;

            for (int row = 0; row < 6; row++) {
                for (int col = 0; col < 7; col++) {
                    var cell = new Panel {
                        Dock = DockStyle.Fill,
                        BackColor = Color.White,
                        Margin = new Padding(0),
                        Padding = new Padding(0)
                    };
                    CalendarTableLayoutPanel.Controls.Add(cell, col, row);


                    if ((row == 0 && col < startCol) || day > daysInMonth)
                        continue;

                    DateTime currentDate = new DateTime(month.Year, month.Month, day);


                    var lbl = new Label {
                        Text = day.ToString(),
                        Dock = DockStyle.Top,
                        Height = 18,
                        TextAlign = ContentAlignment.TopRight,
                        Font = new Font("Segoe UI", 8.5F, FontStyle.Bold),
                        ForeColor = Color.Black,
                        BackColor = Color.Transparent,
                        Padding = new Padding(0, 2, 4, 0)
                    };
                    if (currentDate.Date == DateTime.Now.Date)
                        lbl.ForeColor = Color.Red;

                    cell.Controls.Add(lbl);
                    _dateCells[currentDate] = (row, col, cell);
                    day++;
                }
            }

            CalendarTableLayoutPanel.ResumeLayout();
            eventsOverlay.Controls.Clear();
            eventsOverlay.BringToFront();
            calendarContainer.Invalidate();
        }




        public void SetMonth(DateTime month) {
            _currentMonth = new DateTime(month.Year, month.Month, 1);
            FillCalendar(_currentMonth);
        }

        public void LoadEvents(List<CalendarEventModel> events) {
            eventsOverlay.Controls.Clear();
            if (events == null) return;


            calendarContainer.PerformLayout();
            calendarContainer.Update();
            Application.DoEvents();

            foreach (var ev in events) DrawEventOnOverlay(ev);

            eventsOverlay.Invalidate();
            calendarContainer.Invalidate();
        }

        private void DrawEventOnOverlay(CalendarEventModel ev) {
            if (ev == null) return;

            Color color = GetColorFromDepartment(ev.DepartmentType);
            DateTime start = ev.StartDate.Date;
            DateTime end = ev.EndDate.Date;
            DateTime monthStart = new DateTime(_currentMonth.Year, _currentMonth.Month, 1);
            DateTime monthEnd = new DateTime(_currentMonth.Year, _currentMonth.Month, DateTime.DaysInMonth(_currentMonth.Year, _currentMonth.Month));

            if (end < monthStart || start > monthEnd) return;
            if (start < monthStart) start = monthStart;
            if (end > monthEnd) end = monthEnd;

            var stackPerRow = new Dictionary<int, int>();

            DateTime cursor = start;
            while (cursor <= end) {
                DateTime weekEnd = cursor.AddDays(6 - (int)cursor.DayOfWeek);
                if (weekEnd > end) weekEnd = end;

                if (!_dateCells.ContainsKey(cursor)) {
                    cursor = weekEnd.AddDays(1);
                    continue;
                }

                var startTuple = _date_cells_get(cursor);
                int row = startTuple.Row;
                int startCol = startTuple.Col;

                int lastCol;
                if (_dateCells.ContainsKey(weekEnd)) lastCol = _dateCells[weekEnd].Col;
                else lastCol = Math.Min(6, startCol + (int)(weekEnd - cursor).TotalDays);

                Rectangle startRect = GetCellRectRelativeToOverlay(row, startCol);
                Rectangle endRect = GetCellRectRelativeToOverlay(row, lastCol);
                if (startRect == Rectangle.Empty || endRect == Rectangle.Empty) {
                    cursor = weekEnd.AddDays(1);
                    continue;
                }

                int stackIndex = 0;
                if (stackPerRow.ContainsKey(row)) stackIndex = stackPerRow[row];
                stackPerRow[row] = stackIndex + 1;

                int barTop = startRect.Top + 18 + (stackIndex * 18);
                int barLeft = startRect.Left;
                int barWidth = endRect.Right - startRect.Left;
                int barHeight = 14;

                Panel bar = new Panel {
                    BackColor = color,
                    Bounds = new Rectangle(barLeft, barTop, barWidth, barHeight),
                    Cursor = Cursors.Hand,
                    Tag = ev
                };

                if (cursor == start) {
                    Label t = new Label {
                        Text = ev.Title,
                        AutoEllipsis = true,
                        Bounds = new Rectangle(4, 0, Math.Max(20, barWidth - 8), barHeight),
                        Font = new Font("Segoe UI", 7F, FontStyle.Bold),
                        BackColor = Color.Transparent,
                        ForeColor = Color.Black
                    };
                    bar.Controls.Add(t);
                }

                CalendarEventModel captured = ev;
                bar.Click += (s, e) => OnEventClick?.Invoke(captured);

                eventsOverlay.Controls.Add(bar);

                cursor = weekEnd.AddDays(1);
            }

            // local helper
            (int Row, int Col, Panel Cell) _date_cells_get(DateTime d) {
                return _dateCells[d];
            }
        }

        private Rectangle GetCellRectRelativeToOverlay(int row, int col) {
            Control ctl = CalendarTableLayoutPanel.GetControlFromPosition(col, row);
            if (ctl == null) return Rectangle.Empty;

            Rectangle cellBounds = ctl.Bounds;
            Point cellScreen = CalendarTableLayoutPanel.PointToScreen(new Point(cellBounds.Left, cellBounds.Top));
            Point overlayClient = eventsOverlay.PointToClient(cellScreen);
            return new Rectangle(overlayClient.X, overlayClient.Y, cellBounds.Width, cellBounds.Height);
        }

        private Color GetColorFromDepartment(string dep) {
            switch (dep) {
                case "Sales": return Color.LightSkyBlue;
                case "Engineering": return Color.MediumPurple;
                case "Logistics": return Color.LightGreen;
                default: return Color.LightGray;
            }
        }
    }
}
