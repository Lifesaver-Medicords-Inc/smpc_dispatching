using Microsoft.Extensions.DependencyInjection;
using Serilog;
using smpc_dispatching.Core.Helpers;
using smpc_dispatching.Core.Interfaces;
using smpc_dispatching.Core.Models;
using smpc_dispatching.UI.Shared;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace smpc_dispatching.UI.Views.Logistics
{
    public partial class LogisticsCalendarScheduleDetailsUC : UserControl
    {
        private readonly IServiceProvider _serviceProvider;
        private readonly ILogisticsScheduleService _logisticsScheduleService;
        private readonly ICalendarCategoryService _calendarCategoryService;
        private readonly IVehicleService _vehicleService;
        private readonly IUserService _userService;
        private readonly IBpiService _bpiService;
        private readonly ISalesOrderService _salesOrderService;
        private readonly IReceiptUploadService _receiptUploadService;

        private List<CalendarCategoryModel> _categories;
        private List<VehicleModel> _vehicles;
        private List<UserModel> _people;
        private List<BPI> _bpiOptions;
        private List<SalesOrderModel> _salesOrders;
        private List<string> _salesOrderDocNos;

        private LogisticsScheduleModel _currentSchedule;
        private bool _isExternal;
        private List<LogisticsRouteModel> _routes = new List<LogisticsRouteModel>();

        private Control[] _externalControls;
        private Control[] _internalControls;

        public string DepartmentType { get; set; } = "LOGISTICS";

        public event Func<Task> OnSaved;

        public LogisticsCalendarScheduleDetailsUC(
            ILogisticsScheduleService logisticsScheduleService,
            ICalendarCategoryService calendarCategoryService,
            IVehicleService vehicleService,
            IUserService userService,
            IBpiService bpiService,
            ISalesOrderService salesOrderService,
            IReceiptUploadService receiptUploadService,
            IServiceProvider serviceProvider)
        {
            InitializeComponent();
            _serviceProvider = serviceProvider;
            _logisticsScheduleService = logisticsScheduleService;
            _calendarCategoryService = calendarCategoryService;
            _vehicleService = vehicleService;
            _userService = userService;
            _bpiService = bpiService;
            _salesOrderService = salesOrderService;
            _receiptUploadService = receiptUploadService;

            _externalControls = new Control[]
            {
                lbl_delivery_receipt_doc_no, txt_DeliveryReceiptDocNo,
                lbl_sales_invoice_doc_no, txt_SalesInvoiceDocNo,
                lbl_client_supplier, cmb_ClientSupplier,
                lbl_courier, txt_Courier,
                lbl_pickup_time, dtp_PickupTime,
                lbl_arrival_time, dtp_ArrivalTime
            };

            _internalControls = new Control[] { btn_add_route, flowLayoutPanel_routes };

            ApplyViewMode();
        }

        private async void LogisticsCalendarScheduleDetailsUC_Load(object sender, EventArgs e)
        {
            BtnToggle(false);
            await LoadCategoriesAsync();
            await LoadVehicleAsync();
            await LoadPeopleAsync();
            await LoadBpiAsync();
            await LoadSalesOrdersAsync();
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            LogisticsCalendarScheduleDetailsUC_Load(this, e);
        }

        private void ApplyViewMode()
        {
            foreach (var c in _externalControls) c.Visible = _isExternal;
            foreach (var c in _internalControls) c.Visible = !_isExternal;
            btn_toggle.Text = _isExternal ? "SWITCH TO INTERNAL" : "SWITCH TO EXTERNAL";

            lbl_type_indicator.Text = _isExternal ? "EXTERNAL" : "INTERNAL";
            lbl_type_indicator.ForeColor = _isExternal ? Color.DarkOrange : Color.SeaGreen;

            //Manually toggle visibility of the notes and people controls, since they are not part of the external/internal control arrays.
            lbl_notes.Visible = _isExternal;
            txt_Notes.Visible = _isExternal;

            lbl_people.Visible = !_isExternal;
            cmb_People.Visible = !_isExternal;

            lbl_vehicle.Visible = !_isExternal;
            pnl_vehicle.Visible = !_isExternal;

            lbl_category.Visible = _isExternal;
            pnl_category.Visible = _isExternal;

            lbl_reference_doc_no.Visible = _isExternal;
            cmb_ReferenceDocNo.Visible = _isExternal;

        }

        private void btn_toggle_Click(object sender, EventArgs e)
        {
            _isExternal = !_isExternal;
            ApplyViewMode();
        }

        private void btn_add_route_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            ShowRouteModal(null, null);
        }

        // Opens the route editor in a modal — only the compact list of routes
        // stays visible in Schedule Details itself.
        private void ShowRouteModal(LogisticsRouteModel existingRoute, int? editIndex)
        {
            using (var host = new Form())
            {
                var routePanel = new LogisticsRoutePanelUC { Dock = DockStyle.Top };
                routePanel.HideRemoveButton();
                if (existingRoute != null)
                {
                    routePanel.LoadRoute(existingRoute);
                }
                else
                {
                    // Default a new route's Reference Doc / Delivery Receipt to the
                    // schedule's own sales_order_id / delivery_receipt_doc_no
                    // (straight from tbl_dispatching_logistics_calendar_schedule,
                    // no join needed) — most routes belong to the same order/
                    // receipt as the schedule they're added under. Client/Supplier,
                    // Receiver and Contact No also come from that same sales order.
                    SalesOrderModel salesOrder = null;
                    if (_currentSchedule != null && _currentSchedule.SalesOrderId > 0)
                    {
                        salesOrder = _salesOrders?.FirstOrDefault(so => so.OrderID == (uint)_currentSchedule.SalesOrderId);
                    }

                    // Client/Supplier is derived, not user-selectable: sales order ->
                    // customer_id -> bpi.id -> bpi.name. salesOrder.CustomerName isn't
                    // used since it's a denormalized column that isn't reliably kept in
                    // sync with the BPI record.
                    string clientSupplier = salesOrder != null
                        ? _bpiOptions?.FirstOrDefault(b => b.Id == (int)salesOrder.CustomerID)?.Name ?? string.Empty
                        : string.Empty;

                    routePanel.LoadRoute(new LogisticsRouteModel
                    {
                        // salesOrder.Doc is the sales order's own doc-number sequence,
                        // not the same series as OrderID (the DB primary key) - formatting
                        // OrderID directly as "SO#000X" showed the wrong document number
                        // whenever the two diverged.
                        ReferenceDoc = FormatSalesOrderDocNo(salesOrder?.Doc),
                        DeliveryReceiptDoc = FormatDeliveryReceiptDocNo(_currentSchedule?.DeliveryReceiptDocNo),
                        ClientSupplier = clientSupplier,
                        Receiver = salesOrder?.Receiver ?? string.Empty,
                        ContactNo = salesOrder?.ContactNo ?? string.Empty
                    });
                }

                routePanel.PinLocationRequested += (s, e) =>
                {
                    using (var mapForm = _serviceProvider.GetRequiredService<MapLocPinForm>())
                    {
                        var result = mapForm.ShowDialog(host);
                        if (result == DialogResult.OK && mapForm.SelectedPoint != null)
                        {
                            routePanel.LocationText = mapForm.SelectedAddress;
                        }
                    }
                };

                routePanel.ReceiptUploadRequested += async (s, rowIndex) =>
                {
                    using (var dialog = new OpenFileDialog { Filter = "All Files|*.*", Title = "Select Receipt" })
                    {
                        if (dialog.ShowDialog(host) != DialogResult.OK) return;

                        var res = await _receiptUploadService.UploadAsync(dialog.FileName);
                        if (res == null || !res.Success || res.Data == null)
                        {
                            MessageBox.Show("Failed to upload receipt.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                        }

                        routePanel.SetReceiptUploadResult(rowIndex, res.Data.OriginalName, res.Data.FilePath);
                    }
                };

                var pnl_buttons = new FlowLayoutPanel
                {
                    Dock = DockStyle.Bottom,
                    FlowDirection = FlowDirection.RightToLeft,
                    Height = 45,
                    Padding = new Padding(10)
                };
                var btn_modal_save = new Button { Text = "SAVE", Width = 90, Height = 30 };
                var btn_modal_cancel = new Button { Text = "CANCEL", Width = 90, Height = 30 };
                pnl_buttons.Controls.Add(btn_modal_save);
                pnl_buttons.Controls.Add(btn_modal_cancel);

                btn_modal_save.Click += (s, e) => { host.DialogResult = DialogResult.OK; host.Close(); };
                btn_modal_cancel.Click += (s, e) => { host.DialogResult = DialogResult.Cancel; host.Close(); };

                host.Text = existingRoute == null ? "Add Route" : "Edit Route";
                host.StartPosition = FormStartPosition.CenterParent;
                host.MinimizeBox = false;
                host.MaximizeBox = false;
                host.FormBorderStyle = FormBorderStyle.FixedDialog;
                host.ClientSize = new Size(routePanel.Width + 20, routePanel.Height + pnl_buttons.Height + 20);
                host.Controls.Add(routePanel);
                host.Controls.Add(pnl_buttons);

                if (host.ShowDialog(this) == DialogResult.OK)
                {
                    var order = (editIndex ?? _routes.Count) + 1;
                    var route = routePanel.BuildRoute(order);

                    if (editIndex.HasValue)
                        _routes[editIndex.Value] = route;
                    else
                        _routes.Add(route);

                    RefreshRouteList();
                }
            }
        }

        private void RefreshRouteList()
        {
            flowLayoutPanel_routes.Controls.Clear();
            // FlowLayoutPanel ignores Dock on its children, so each row's width
            // has to be computed against the actual available space up front —
            // a fixed width would just get clipped (and its buttons hidden)
            // whenever the container is narrower than that.
            int rowWidth = Math.Max(flowLayoutPanel_routes.ClientSize.Width - 4, 400);
            for (int i = 0; i < _routes.Count; i++)
            {
                flowLayoutPanel_routes.Controls.Add(BuildRouteRow(_routes[i], i, rowWidth));
            }
        }

        private Panel BuildRouteRow(LogisticsRouteModel route, int index, int width)
        {
            var row = new Panel
            {
                Width = width,
                Height = 40,
                Margin = new Padding(0, 0, 0, 4),
                BorderStyle = BorderStyle.FixedSingle
            };

            var summary = string.Join("   ", new[] { route.ShipType, route.ReferenceDoc, route.ClientSupplier }
                .Where(s => !string.IsNullOrWhiteSpace(s)));

            var btn_row_remove = new Button
            {
                Text = "REMOVE",
                Width = 75,
                Height = 26,
                Anchor = AnchorStyles.Top | AnchorStyles.Right,
                Location = new Point(width - 75 - 8, 6),
                BackColor = Color.IndianRed,
                ForeColor = Color.White,
                FlatStyle = FlatStyle.Flat
            };
            var btn_row_edit = new Button
            {
                Text = "EDIT",
                Width = 60,
                Height = 26,
                Anchor = AnchorStyles.Top | AnchorStyles.Right,
                Location = new Point(btn_row_remove.Location.X - 60 - 6, 6)
            };

            var lbl = new Label
            {
                AutoSize = false,
                AutoEllipsis = true,
                Location = new Point(8, 11),
                Width = Math.Max(btn_row_edit.Location.X - 16, 50),
                Height = 18,
                Font = new Font("Microsoft Sans Serif", 8F, FontStyle.Bold),
                Text = $"ROUTE #{index + 1}   {summary}"
            };

            btn_row_edit.Click += (s, e) => ShowRouteModal(route, index);
            btn_row_remove.Click += (s, e) =>
            {
                _routes.RemoveAt(index);
                RefreshRouteList();
            };

            row.Controls.Add(lbl);
            row.Controls.Add(btn_row_edit);
            row.Controls.Add(btn_row_remove);
            return row;
        }


        private async void btn_add_category_Click(object sender, EventArgs e)
        {
            using (var host = new Form())
            {
                host.Text = "Category Setup";
                host.Size = new Size(650, 500);
                host.StartPosition = FormStartPosition.CenterParent;
                host.MinimizeBox = false;
                host.MaximizeBox = false;

                var setupModal = new SetupModal("Category", "calendar-categories", _serviceProvider.GetRequiredService<IHttpService>())
                {
                    Dock = DockStyle.Fill
                };
                host.Controls.Add(setupModal);

                host.ShowDialog(this);
            }

            await LoadCategoriesAsync();
        }

        private async Task LoadCategoriesAsync()
        {
            try
            {
                var res = await _calendarCategoryService.GetAllAsync(null);
                if (res?.Success == true)
                    _categories = res.Data.ToList();

                cmb_Category.DataSource = null;
                cmb_Category.DataSource = _categories;
                cmb_Category.DisplayMember = "Name";
                cmb_Category.ValueMember = "Id";
            }
            catch (Exception ex)
            {
                Log.Error(ex, "Error getting calendar categories");
                MessageBox.Show("Failed to load calendar categories.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async Task LoadVehicleAsync()
        {
            try
            {
                var res = await _vehicleService.GetAllAsync(null);
                if (res?.Success == true)
                    _vehicles = res.Data.ToList();

                cmb_Vehicle.DataSource = null;
                cmb_Vehicle.DataSource = _vehicles;
                cmb_Vehicle.DisplayMember = "Type";
                cmb_Vehicle.ValueMember = "Id";
            }
            catch (Exception ex)
            {
                Log.Error(ex, "Error getting vehicles");
                MessageBox.Show("Failed to load vehicles.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async Task LoadPeopleAsync()
        {
            try
            {
                var res = await _userService.GetAllAsync(null);
                if (res?.Success == true)
                    _people = res.Data.ToList();

                cmb_People.DataSource = null;
                cmb_People.DataSource = _people;
                cmb_People.DisplayMember = nameof(UserModel.FullName);
                cmb_People.ValueMember = nameof(UserModel.id);
            }
            catch (Exception ex)
            {
                Log.Error(ex, "Error getting users");
                MessageBox.Show("Failed to load users.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async Task LoadBpiAsync()
        {
            try
            {
                var res = await _bpiService.GetAllAsync(null);
                _bpiOptions = res?.Data?.Bpi?.ToList() ?? new List<BPI>();

                cmb_ClientSupplier.DataSource = null;
                cmb_ClientSupplier.DataSource = _bpiOptions;
                cmb_ClientSupplier.DisplayMember = "Name";
                cmb_ClientSupplier.ValueMember = "Name";
            }
            catch (Exception ex)
            {
                Log.Error(ex, "Error getting BPI list");
                MessageBox.Show("Failed to load client/supplier list.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async Task LoadSalesOrdersAsync()
        {
            try
            {
                var res = await _salesOrderService.GetAllAsync(null);
                _salesOrders = res?.Data?.ToList() ?? new List<SalesOrderModel>();
                _salesOrderDocNos = _salesOrders
                    .Where(so => !string.IsNullOrWhiteSpace(so.DocumentNo))
                    .Select(so => $"SO#{so.DocumentNo}")
                    .ToList();

                cmb_ReferenceDocNo.DataSource = null;
                cmb_ReferenceDocNo.DataSource = _salesOrderDocNos;
            }
            catch (Exception ex)
            {
                Log.Error(ex, "Error getting sales orders");
                MessageBox.Show("Failed to load sales order documents.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // The backend stores this as a plain doc number (e.g. "1") — format it
        // the same way delivery receipts are shown elsewhere in the app.
        private static string FormatDeliveryReceiptDocNo(string raw)
        {
            if (string.IsNullOrWhiteSpace(raw)) return string.Empty;
            return int.TryParse(raw, out var docNo) ? Helpers.DocNoFormatter(docNo, "DR#") : raw;
        }

        // The backend's sales-order join (getSalesOrderDocNo) returns the raw,
        // already-zero-padded doc number (e.g. "0003") with no prefix — add one
        // so it matches what's shown in cmb_ReferenceDocNo's dropdown list.
        private static string FormatSalesOrderDocNo(string raw)
        {
            if (string.IsNullOrWhiteSpace(raw)) return string.Empty;
            return raw.StartsWith("SO#") ? raw : $"SO#{raw}";
        }

        private static string StripDocPrefix(string value, string prefix)
        {
            if (string.IsNullOrWhiteSpace(value)) return string.Empty;
            return value.StartsWith(prefix) ? value.Substring(prefix.Length) : value;
        }

        private static void SetTime(DateTimePicker picker, string time)
        {
            if (!string.IsNullOrWhiteSpace(time) && DateTime.TryParse(time, out var parsed))
                picker.Value = parsed;
        }

        private void BtnToggle(bool isEdit)
        {
            btn_new.Visible = !isEdit;
            btn_delete.Visible = !isEdit;
            btn_edit.Visible = !isEdit;

            btn_save.Visible = isEdit;
            btn_close.Visible = isEdit;
            pnl_root.Enabled = isEdit;
            btn_toggle.Enabled = isEdit;
        }

        private void ClearForm()
        {
            txt_Id.Text = string.Empty;
            txt_Title.Text = string.Empty;
            dtp_StartDate.Value = DateTime.Now;
            dtp_EndDate.Value = DateTime.Now;
            cmb_Category.SelectedIndex = -1;
            cmb_People.SelectedIndex = -1;
            cmb_People.Text = string.Empty;
            cmb_Vehicle.SelectedIndex = -1;

            cmb_ClientSupplier.SelectedIndex = -1;
            txt_Trucking.Text = string.Empty;
            txt_Courier.Text = string.Empty;
            txt_DriverName.Text = string.Empty;
            dtp_PickupTime.Value = DateTime.Now;
            dtp_ArrivalTime.Value = DateTime.Now;
            cmb_ReferenceDocNo.SelectedIndex = -1;
            txt_SalesInvoiceDocNo.Text = string.Empty;
            txt_DeliveryReceiptDocNo.Text = string.Empty;
            txt_Notes.Text = string.Empty;

            _routes = new List<LogisticsRouteModel>();
            RefreshRouteList();
            _isExternal = false;
            ApplyViewMode();
        }

        private void btn_new_Click(object sender, EventArgs e)
        {
            _currentSchedule = null;
            ClearForm();
            BtnToggle(true);
        }

        private void btn_close_Click(object sender, EventArgs e)
        {
            _currentSchedule = null;
            BtnToggle(false);
        }

        private void btn_edit_Click(object sender, EventArgs e)
        {
            BtnToggle(true);
        }

        private async void btn_delete_Click(object sender, EventArgs e)
        {
            if (_currentSchedule == null)
            {
                MessageBox.Show("Select a schedule to delete.");
                return;
            }

            var confirm = MessageBox.Show("Delete this schedule?", "Confirm Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (confirm != DialogResult.Yes) return;

            var res = await _logisticsScheduleService.RemoveAsync(_currentSchedule.Id);
            if (res == null || !res.Success)
            {
                MessageBox.Show("Failed to delete schedule.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            _currentSchedule = null;
            ClearForm();
            BtnToggle(false);

            if (OnSaved != null)
                await OnSaved.Invoke();
        }

        private async void btn_save_Click(object sender, EventArgs e)
        {
            var schedule = new LogisticsScheduleModel
            {
                Department = "LOGISTICS",
                Title = txt_Title.Text?.Trim() ?? string.Empty,
                IsExternal = _isExternal,
                CategoryId = cmb_Category.SelectedValue != null ? Convert.ToInt32(cmb_Category.SelectedValue) : 0,
                StartDate = dtp_StartDate.Value,
                EndDate = dtp_EndDate.Value,
                People = (cmb_People.SelectedItem as UserModel)?.FullName ?? cmb_People.Text ?? string.Empty,
                VehicleId = cmb_Vehicle.SelectedValue != null ? Convert.ToInt32(cmb_Vehicle.SelectedValue) : 0,
                ReferenceDocNo = StripDocPrefix(cmb_ReferenceDocNo.Text, "SO#"),
                Notes = txt_Notes.Text
            };

            if (_isExternal)
            {
                schedule.ClientSupplier = cmb_ClientSupplier.Text;
                schedule.Trucking = txt_Trucking.Text;
                schedule.Courier = txt_Courier.Text;
                schedule.DriverName = txt_DriverName.Text;
                schedule.PickupTime = dtp_PickupTime.Value.ToString("hh:mm tt");
                schedule.ArrivalTime = dtp_ArrivalTime.Value.ToString("hh:mm tt");
                schedule.SalesInvoiceDocNo = txt_SalesInvoiceDocNo.Text;
                schedule.DeliveryReceiptDocNo = txt_DeliveryReceiptDocNo.Text;
            }
            else
            {
                for (int i = 0; i < _routes.Count; i++)
                {
                    _routes[i].SortOrder = i + 1;
                    schedule.Routes.Add(_routes[i]);
                }
            }

            HttpResponseModel<LogisticsScheduleModel> res;
            if (_currentSchedule != null)
            {
                schedule.Id = _currentSchedule.Id;
                res = await _logisticsScheduleService.UpdateAsync(schedule);
            }
            else
            {
                res = await _logisticsScheduleService.CreateAsync(schedule);
            }

            if (res == null || !res.Success)
            {
                MessageBox.Show("Saving failed");
                return;
            }

            MessageBox.Show("Success!");
            _currentSchedule = null;
            ClearForm();
            BtnToggle(false);

            if (OnSaved != null)
                await OnSaved.Invoke();
        }

        // Fetches the full schedule (with routes/costs) and populates the form.
        public async Task EnterEditModeAsync(int scheduleId)
        {
            var res = await _logisticsScheduleService.GetByIdAsync(scheduleId);
            if (res == null || !res.Success || res.Data == null)
            {
                MessageBox.Show("Failed to load schedule details.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            var schedule = res.Data;
            _currentSchedule = schedule;
            _isExternal = schedule.IsExternal;

            txt_Id.Text = schedule.Id.ToString();
            txt_Title.Text = schedule.Title;
            dtp_StartDate.Value = schedule.StartDate == DateTime.MinValue ? DateTime.Now : schedule.StartDate;
            dtp_EndDate.Value = schedule.EndDate == DateTime.MinValue ? DateTime.Now : schedule.EndDate;
            cmb_Category.SelectedValue = (uint)schedule.CategoryId;
            cmb_People.Text = schedule.People;
            cmb_Vehicle.SelectedValue = (uint)schedule.VehicleId;

            // Schedules auto-created from a delivery receipt come with the sales
            // order linked (sales_order_id) but no client_supplier of their own —
            // fall back to that sales order's customer so the field isn't blank.
            if (string.IsNullOrWhiteSpace(schedule.ClientSupplier) && schedule.SalesOrderId > 0)
            {
                var salesOrder = _salesOrders?.FirstOrDefault(so => so.OrderID == (uint)schedule.SalesOrderId);
                cmb_ClientSupplier.Text = salesOrder?.CustomerName ?? string.Empty;
            }
            else
            {
                cmb_ClientSupplier.Text = schedule.ClientSupplier;
            }
            txt_Trucking.Text = schedule.Trucking;
            txt_Courier.Text = schedule.Courier;
            txt_DriverName.Text = schedule.DriverName;
            SetTime(dtp_PickupTime, schedule.PickupTime);
            SetTime(dtp_ArrivalTime, schedule.ArrivalTime);
            cmb_ReferenceDocNo.Text = FormatSalesOrderDocNo(schedule.ReferenceDocNo);
            txt_SalesInvoiceDocNo.Text = schedule.SalesInvoiceDocNo;
            txt_DeliveryReceiptDocNo.Text = FormatDeliveryReceiptDocNo(schedule.DeliveryReceiptDocNo);
            txt_Notes.Text = schedule.Notes;

            _routes = schedule.Routes?.OrderBy(r => r.SortOrder).ToList() ?? new List<LogisticsRouteModel>();
            RefreshRouteList();

            ApplyViewMode();
            BtnToggle(true);
        }

        private async void btn_add_vehicle_Click(object sender, EventArgs e)
        {
            using (var host = new Form())
            {
                host.Text = "Vehicle Setup";
                host.Size = new Size(950, 650);
                host.StartPosition = FormStartPosition.CenterParent;
                host.MinimizeBox = false;
                host.MaximizeBox = false;

                var vehicleSetup = _serviceProvider.GetRequiredService<VehicleSetupUC>();
                vehicleSetup.Dock = DockStyle.Fill;
                host.Controls.Add(vehicleSetup);

                host.ShowDialog(this);
            }

            await LoadVehicleAsync();
        }
    }
}
