using Microsoft.Extensions.DependencyInjection;
using Serilog;
using smpc_dispatching.Core.Interfaces;
using smpc_dispatching.Core.Models;
using smpc_dispatching.Printing;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace smpc_dispatching.UI.Views.SalesOrder {

    // Dispatching's read-only view of a Sales Order (spec 3.2's Dispatching row).
    //
    // The whole class was commented out, so the screen was a shell and its buttons
    // had nothing to act on. It could not simply be uncommented: it had been
    // written against an older object model that no longer exists. The old code
    // read order.DeliveryReceipts (the API's Go model has that field commented
    // out, so it is never sent), release.Vehicle / .Peoples / .DepartedAt (fields
    // ItemReleaseModel no longer carries), receipt.TripCost and
    // receipt.AttachedFile (DeliveryReceiptModel now carries
    // delivery_receipt_costs and DeliveryReceiptFileModel instead), and a
    // FileModel class that no longer exists at all.
    //
    // So it is rebuilt here against what the models and endpoints actually hold
    // today, and the three tables are sourced where that data really lives now:
    //
    //   Items          <- the order's own lines, with serials and the DR reference
    //                     filled in from the item releases raised against it
    //   Dispatch       <- the logistics schedules naming this SO, one row per route
    //                     (departed / arrived / returned are route events, 13.3)
    //   Delivery cost  <- the delivery receipts for this SO and their cost rows
    //
    // Read-only throughout. Dispatching may cite an order, never change one
    // (CLAUDE.md invariant 16), which is why SAVE is hidden rather than wired.
    public partial class SalesOrderViewUC : UserControl {

        private readonly ISalesOrderService _salesOrderService;
        private readonly IItemReleaseService _itemReleaseService;
        private readonly ILogisticsScheduleService _logisticsScheduleService;
        private readonly IDeliveryReceiptService _deliveryReceiptService;
        private readonly IVehicleService _vehicleService;
        private readonly IDrawFolderTreeService<DeliveryReceiptFileModel> _drawFolderTreeService;
        private readonly SalesOrderListForm _salesOrderListForm;

        private List<SalesOrderModel> _salesOrders = new List<SalesOrderModel>();
        private List<VehicleModel> _vehicles = new List<VehicleModel>();
        private SalesOrderModel _currentOrder;
        private int _currentOrderIndex = -1;

        private readonly List<DeliveryReceiptFileModel> _files = new List<DeliveryReceiptFileModel>();
        private DeliveryReceiptFileModel _currentFile;

        public SalesOrderViewUC(
            ISalesOrderService salesOrderService,
            IItemReleaseService itemReleaseService,
            ILogisticsScheduleService logisticsScheduleService,
            IVehicleService vehicleService,
            IServiceProvider serviceProvider,
            IDrawFolderTreeService<DeliveryReceiptFileModel> drawFolderTreeService) {

            if (LicenseManager.UsageMode == LicenseUsageMode.Designtime) {
                InitializeComponent();
                return;
            }

            InitializeComponent();

            this.AutoScroll = true;
            _salesOrderService = salesOrderService;
            _itemReleaseService = itemReleaseService;
            _logisticsScheduleService = logisticsScheduleService;
            // IDeliveryReceiptService is internal, so it is resolved from the provider
            // rather than taken as a constructor parameter - the same way
            // DeliveryReceiptUC does it, and what keeps this constructor public.
            _deliveryReceiptService = serviceProvider.GetRequiredService<IDeliveryReceiptService>();
            _vehicleService = vehicleService;
            _drawFolderTreeService = drawFolderTreeService;
            _salesOrderListForm = serviceProvider.GetRequiredService<SalesOrderListForm>();

            ShowOrderListFormPanel.Cursor = Cursors.Hand;
            ShowOrderListFormPanel.Click += ShowOrderListFormPanel_Click;
            _salesOrderListForm.SetCurrentOrderID = value => SetCurrentOrder(value);

            // Dispatching's access to an order is read-only (3.2, invariant 16).
            // The button was never wired to anything; hidden rather than left as a
            // control that looks like it saves.
            SaveButton.Visible = false;

            MakeReadOnly();
            ClearCurrentFile();
            DrawTreeView();

            LoadSalesOrders();
        }

        // Every field on this screen reports an order that belongs to sales. None of
        // it is editable here, so the text boxes are locked rather than merely left
        // alone - an editable-looking box invites someone to type into it and lose
        // the edit on the next Prev/Next.
        private void MakeReadOnly() {
            foreach (var box in new[] {
                CustomerTextBox, CodeTextBox, DeliverToTextBox, BillToTextBox, ReceiverTextBox,
                ContactNoTextBox, TinTextBox, DocNoTextBox, DateTextBox, DeliveryDateTextBox,
                ReferenceDocTextBox, StatusTextBox, ExecutiveTextBox, DeliveryStatusTextBox }) {
                if (box != null) box.ReadOnly = true;
            }

            ItemListDataGridView.ReadOnly = true;
            DispatchItemsListDataGridView.ReadOnly = true;
            OrdersDeliveryCostataGridView.ReadOnly = true;
            ItemListDataGridView.AllowUserToAddRows = false;
            DispatchItemsListDataGridView.AllowUserToAddRows = false;
            OrdersDeliveryCostataGridView.AllowUserToAddRows = false;
        }

        protected override Point ScrollToControl(Control activeControl) {
            if (activeControl != null) {
                Rectangle visible = new Rectangle(
                    -this.AutoScrollPosition.X,
                    -this.AutoScrollPosition.Y,
                    this.ClientSize.Width,
                    this.ClientSize.Height);

                if (visible.Contains(activeControl.Bounds))
                    return this.AutoScrollPosition;
            }

            return base.ScrollToControl(activeControl);
        }

        private async void LoadSalesOrders() {
            try {
                // Vehicles are fetched once: a schedule carries only vehicle_id, and the
                // dispatch table shows the plate number.
                var vehicles = await _vehicleService.GetAllAsync(null);
                if (vehicles != null && vehicles.Success && vehicles.Data != null) {
                    _vehicles = vehicles.Data.ToList();
                }

                var res = await _salesOrderService.GetAllAsync(null);

                if (res != null && res.Success && res.Data != null) {
                    _salesOrders = res.Data.ToList();
                    _salesOrderListForm.InitOrders(_salesOrders);

                    var latestOrder = _salesOrders.LastOrDefault();
                    if (latestOrder != null) {
                        _currentOrderIndex = _salesOrders.Count - 1;
                        await ShowOrder(latestOrder);
                    }
                }
            } catch (Exception ex) {
                Log.Error(ex, "Error getting all sales orders");
                MessageBox.Show("Could not load the sales orders: " + ex.Message, "Sales Order",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async void SetCurrentOrder(uint id) {
            var index = _salesOrders.FindIndex(o => o.OrderID == id);
            if (index < 0) return;

            _currentOrderIndex = index;
            await ShowOrder(_salesOrders[index]);
        }

        private async System.Threading.Tasks.Task ShowOrder(SalesOrderModel order) {
            if (order == null) return;

            _currentOrder = order;
            _files.Clear();
            ClearCurrentFile();

            CustomerTextBox.Text = order.CustomerName;
            CodeTextBox.Text = order.CustomerCode;
            DeliverToTextBox.Text = order.ShipTo;
            BillToTextBox.Text = order.BillTo;
            ReceiverTextBox.Text = order.Receiver;
            ContactNoTextBox.Text = order.ContactNo;
            TinTextBox.Text = order.Tin;
            DocNoTextBox.Text = order.DocumentNo;
            DateTextBox.Text = order.Date;
            DeliveryDateTextBox.Text = order.DeliveryDate;
            ReferenceDocTextBox.Text = order.RefPO == 0 ? "" : order.RefPO.ToString();
            StatusTextBox.Text = order.Status;
            ExecutiveTextBox.Text = order.SalesExecutive;

            var releases = await LoadReleases(order);
            var receipts = await LoadReceipts(order);
            var schedules = await LoadSchedules(order);

            PopulateItemList(order, releases);
            PopulateDispatchList(schedules);
            PopulateOrderCostList(receipts);

            // The dispatch status is the furthest point the order has actually
            // reached, which lives on the routes - not on the order, whose status is
            // sales' own vocabulary (7.2). A route that departed and returned with no
            // arrival is a failed delivery and says so (5.4).
            DeliveryStatusTextBox.Text = DispatchStatusOf(schedules);

            DrawTreeView();
        }

        private async System.Threading.Tasks.Task<List<ItemReleaseModel>> LoadReleases(SalesOrderModel order) {
            try {
                var res = await _itemReleaseService.GetAllAsync(null);
                if (res == null || !res.Success || res.Data == null) return new List<ItemReleaseModel>();

                return res.Data
                    .Where(r => r.sales_order_id.HasValue && r.sales_order_id.Value == order.OrderID)
                    .ToList();
            } catch (Exception ex) {
                Log.Error(ex, "Error getting item releases for order {OrderId}", order.OrderID);
                return new List<ItemReleaseModel>();
            }
        }

        private async System.Threading.Tasks.Task<List<DeliveryReceiptModel>> LoadReceipts(SalesOrderModel order) {
            try {
                var res = await _deliveryReceiptService.GetAllAsync(null);
                if (res == null || !res.Success || res.Data == null) return new List<DeliveryReceiptModel>();

                return res.Data
                    .Where(r => r.sales_order_id.HasValue && r.sales_order_id.Value == (int)order.OrderID)
                    .ToList();
            } catch (Exception ex) {
                Log.Error(ex, "Error getting delivery receipts for order {OrderId}", order.OrderID);
                return new List<DeliveryReceiptModel>();
            }
        }

        // A schedule names its order either by id or by the SO number typed into
        // REFERENCE DOC - nothing auto-generates a calendar entry, a dispatcher
        // schedules the route and names the SO (13.3), so both are checked.
        private async System.Threading.Tasks.Task<List<LogisticsScheduleModel>> LoadSchedules(SalesOrderModel order) {
            try {
                var res = await _logisticsScheduleService.GetAllAsync(null);
                if (res == null || !res.Success || res.Data == null) return new List<LogisticsScheduleModel>();

                string docNo = Digits(order.DocumentNo);

                return res.Data.Where(s =>
                        s.SalesOrderId == (int)order.OrderID ||
                        (docNo.Length > 0 && Digits(s.ReferenceDocNo) == docNo))
                    .ToList();
            } catch (Exception ex) {
                Log.Error(ex, "Error getting logistics schedules for order {OrderId}", order.OrderID);
                return new List<LogisticsScheduleModel>();
            }
        }

        // "SO#0006", "0006" and "6" all name the same order; compare on the number.
        private static string Digits(string value) {
            if (string.IsNullOrWhiteSpace(value)) return "";
            string digits = new string(value.Where(char.IsDigit).ToArray()).TrimStart('0');
            return digits;
        }

        private static string DispatchStatusOf(List<LogisticsScheduleModel> schedules) {
            var routes = schedules.SelectMany(s => s.Routes ?? new List<LogisticsRouteModel>()).ToList();
            if (routes.Count == 0) return "NOT SCHEDULED";

            if (routes.Any(r => !string.IsNullOrWhiteSpace(r.ArrivedAt))) return "DELIVERED";
            // Departed and back again with no arrival in between is a failed delivery
            // (5.4), and it must not read as still en route.
            if (routes.Any(r => !string.IsNullOrWhiteSpace(r.ReturnedAt))) return "UNSUCCESSFUL";
            if (routes.Any(r => !string.IsNullOrWhiteSpace(r.DepartedAt))) return "EN ROUTE";
            return "SCHEDULED";
        }

        private void PopulateItemList(SalesOrderModel order, List<ItemReleaseModel> releases) {
            ItemListDataGridView.Rows.Clear();

            var items = order.Items;
            if (items == null || items.Count == 0) return;

            var releaseLines = releases
                .SelectMany(r => (r.item_release_details ?? new List<ItemReleaseDetailsModel>())
                    .Select(d => new { Release = r, Detail = d }))
                .ToList();

            for (int i = 0; i < items.Count; i++) {
                var line = items[i];
                if (line == null) continue;

                // Serials are read off the releases, and a missing one is normal -
                // 10.7 is prompt-and-proceed, so a blank here is not an error.
                var matched = releaseLines
                    .Where(x => x.Detail != null && x.Detail.sales_order_details_id == line.id)
                    .ToList();

                string serials = string.Join(", ", matched
                    .Select(x => x.Detail.serial_no)
                    .Where(s => !string.IsNullOrWhiteSpace(s)));

                string deliveryReference = string.Join(", ", matched
                    .Select(x => x.Release.doc_no_formatted)
                    .Where(s => !string.IsNullOrWhiteSpace(s))
                    .Distinct());

                ItemListDataGridView.Rows.Add(
                    i + 1,
                    line.Qty,
                    string.IsNullOrWhiteSpace(line.ItemCode) ? line.Item?.ModelItem : line.ItemCode,
                    string.IsNullOrWhiteSpace(line.ItemDescription) ? line.Item?.ShortDesc : line.ItemDescription,
                    deliveryReference,
                    line.Status,
                    serials);
            }
        }

        // One row per route: a schedule may run several drops in one trip, and the
        // departed / arrived / returned stamps belong to the route, not the trip.
        private void PopulateDispatchList(List<LogisticsScheduleModel> schedules) {
            DispatchItemsListDataGridView.Rows.Clear();
            if (schedules == null || schedules.Count == 0) return;

            foreach (var schedule in schedules) {
                string plate = _vehicles.FirstOrDefault(v => v.id == schedule.VehicleId)?.PlateNo ?? "";

                string people = schedule.People;
                if (string.IsNullOrWhiteSpace(people) && schedule.AssignedPeople != null) {
                    people = string.Join(", ", schedule.AssignedPeople
                        .Select(p => p?.full_name)
                        .Where(n => !string.IsNullOrWhiteSpace(n)));
                }

                var routes = schedule.Routes;
                if (routes == null || routes.Count == 0) {
                    DispatchItemsListDataGridView.Rows.Add(
                        schedule.StartDate.ToString("yyyy-MM-dd"), "SCHEDULED", plate, people,
                        "", schedule.DeliveryReceiptDocNo, "", "", "", "");
                    continue;
                }

                foreach (var route in routes.OrderBy(r => r.SortOrder)) {
                    decimal cost = route.Costs == null ? 0 : route.Costs.Sum(c => c.Amount * c.Multiplier);

                    DispatchItemsListDataGridView.Rows.Add(
                        schedule.StartDate.ToString("yyyy-MM-dd"),
                        RouteStatus(route),
                        plate,
                        people,
                        // Pick Activity is a warehouse document; dispatching has no
                        // endpoint for it, so the column stays blank rather than
                        // showing something that is not one.
                        "",
                        string.IsNullOrWhiteSpace(route.DeliveryReceiptDoc)
                            ? schedule.DeliveryReceiptDocNo : route.DeliveryReceiptDoc,
                        route.DepartedAt,
                        route.ArrivedAt,
                        route.ReturnedAt,
                        cost == 0 ? "" : cost.ToString("N2"));
                }
            }
        }

        private static string RouteStatus(LogisticsRouteModel route) {
            if (!string.IsNullOrWhiteSpace(route.ArrivedAt)) return "DELIVERED";
            if (!string.IsNullOrWhiteSpace(route.ReturnedAt)) return "UNSUCCESSFUL";
            if (!string.IsNullOrWhiteSpace(route.DepartedAt)) return "EN ROUTE";
            return "SCHEDULED";
        }

        private void PopulateOrderCostList(List<DeliveryReceiptModel> receipts) {
            OrdersDeliveryCostataGridView.Rows.Clear();
            if (receipts == null || receipts.Count == 0) return;

            decimal total = 0;

            foreach (var receipt in receipts) {
                var costs = receipt.delivery_receipt_costs;
                if (costs == null || costs.Count == 0) continue;

                foreach (var cost in costs) {
                    string receiptName = cost.delivery_receipt_file != null && cost.delivery_receipt_file.Count > 0
                        ? cost.delivery_receipt_file[0].original_name
                        : "";

                    OrdersDeliveryCostataGridView.Rows.Add(
                        receipt.delivery_date,
                        receipt.ship_via,
                        cost.costs_cost_type_id == 0 ? "" : cost.costs_cost_type_id.ToString(),
                        cost.costs_description,
                        cost.costs_total_cost.ToString("N2"),
                        receiptName,
                        receipt.att);

                    total += cost.costs_total_cost;

                    if (cost.delivery_receipt_file != null) {
                        foreach (var file in cost.delivery_receipt_file) {
                            if (file != null) _files.Add(file);
                        }
                    }
                }
            }

            if (OrdersDeliveryCostataGridView.Rows.Count == 0) return;

            // Total row, computed from the rows that were actually added rather than
            // re-read out of the grid's own cells.
            int totalRowIndex = OrdersDeliveryCostataGridView.Rows.Add();
            var totalRow = OrdersDeliveryCostataGridView.Rows[totalRowIndex];
            foreach (DataGridViewCell cell in totalRow.Cells) cell.Value = string.Empty;
            totalRow.Cells[OrdersDeliveryCostataGridView.Columns["Description"].Index].Value = "TOTAL";
            totalRow.Cells[OrdersDeliveryCostataGridView.Columns["Amount"].Index].Value = total.ToString("N2");
            totalRow.DefaultCellStyle.Font = new Font(OrdersDeliveryCostataGridView.Font, FontStyle.Bold);
            totalRow.Tag = "TotalRow";
        }

        private void ShowOrderListFormPanel_Click(object sender, EventArgs e) {
            _salesOrderListForm.ShowDialog();
        }

        private async void NextBtn_Click(object sender, EventArgs e) {
            if (_salesOrders == null || _currentOrderIndex >= _salesOrders.Count - 1) return;

            _currentOrderIndex++;
            await ShowOrder(_salesOrders[_currentOrderIndex]);
        }

        private async void PrevBtn_Click(object sender, EventArgs e) {
            if (_salesOrders == null || _currentOrderIndex <= 0) return;

            _currentOrderIndex--;
            await ShowOrder(_salesOrders[_currentOrderIndex]);
        }

        private void DrawTreeView() {
            TreeViewPanel.Controls.Clear();

            var deliveryReceiptFolder = new FolderTreeModel<DeliveryReceiptFileModel> {
                Name = "Delivery Receipts",
                IsFolder = true,
                Param = new DeliveryReceiptFileModel(),
                Children = new List<FolderTreeModel<DeliveryReceiptFileModel>>(),
            };

            foreach (var file in _files) {
                deliveryReceiptFolder.Children.Add(new FolderTreeModel<DeliveryReceiptFileModel> {
                    Name = string.IsNullOrWhiteSpace(file.original_name) ? file.file_name : file.original_name,
                    IsFolder = false,
                    Param = file,
                });
            }

            var pickupReceiptFolder = new FolderTreeModel<DeliveryReceiptFileModel> {
                Name = "Pick-up Receipts",
                IsFolder = true,
                Param = new DeliveryReceiptFileModel(),
                Children = new List<FolderTreeModel<DeliveryReceiptFileModel>>(),
            };

            var folders = new List<FolderTreeModel<DeliveryReceiptFileModel>> {
                new FolderTreeModel<DeliveryReceiptFileModel> {
                    Name = "Benched",
                    IsFolder = true,
                    Param = new DeliveryReceiptFileModel(),
                    Children = new List<FolderTreeModel<DeliveryReceiptFileModel>> {
                        deliveryReceiptFolder,
                        pickupReceiptFolder,
                    },
                },
                new FolderTreeModel<DeliveryReceiptFileModel> {
                    Name = "Active",
                    IsFolder = true,
                    Param = new DeliveryReceiptFileModel(),
                },
            };

            var folderTree = _drawFolderTreeService.DrawFolderTree(folders, FolderTree_NodeClick);
            TreeViewPanel.Controls.Add(folderTree);
        }

        private void FolderTree_NodeClick(object sender, TreeNodeMouseClickEventArgs e) {
            if (e.Node?.Tag is FolderTreeModel<DeliveryReceiptFileModel> model && !model.IsFolder) {
                var file = _files.FirstOrDefault(f => f.id == model.Param.id);
                if (file != null) SetCurrentFile(file);
            }
        }

        private void SetCurrentFile(DeliveryReceiptFileModel file) {
            _currentFile = file;
            FileNameLabel.Text = string.IsNullOrWhiteSpace(file.original_name) ? file.file_name : file.original_name;
            FileNameLabel.Visible = true;
            CurrenFIleImagePanel.Visible = true;
        }

        private void ClearCurrentFile() {
            _currentFile = null;
            FileNameLabel.Text = "";
            FileNameLabel.Visible = false;
            CurrenFIleImagePanel.Visible = false;
        }

        // Prints the order as dispatching reads it - the header, then the line items
        // with their delivery reference and serials - on the Class A house template
        // (2.10). Not the sales copy of the SO: this is the dispatcher's working
        // sheet, and it carries no prices.
        private void PrintButton_Click(object sender, EventArgs e) {
            if (_currentOrder == null) {
                MessageBox.Show("Open an order first.", "Sales Order",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            var report = new HouseTemplateReport { Title = "SALES ORDER - DISPATCH COPY" };

            report.LeftBlock.Add(HouseTemplateReport.Pair("CUSTOMER", _currentOrder.CustomerName));
            report.LeftBlock.Add(HouseTemplateReport.Pair("DELIVER TO", _currentOrder.ShipTo));
            report.LeftBlock.Add(HouseTemplateReport.Pair("RECEIVER", _currentOrder.Receiver));
            report.LeftBlock.Add(HouseTemplateReport.Pair("CONTACT NO.", _currentOrder.ContactNo));

            report.RightBlock.Add(HouseTemplateReport.Pair("SO NO.", _currentOrder.DocumentNo));
            report.RightBlock.Add(HouseTemplateReport.Pair("DOC DATE", _currentOrder.Date));
            report.RightBlock.Add(HouseTemplateReport.Pair("DELIVERY DATE", _currentOrder.DeliveryDate));
            report.RightBlock.Add(HouseTemplateReport.Pair("DISPATCH STATUS", DeliveryStatusTextBox.Text));

            report.Columns.Add(new HouseTemplateColumn("#", 'R'));
            report.Columns.Add(new HouseTemplateColumn("QTY", 'R'));
            report.Columns.Add(new HouseTemplateColumn("ITEM CODE"));
            report.Columns.Add(new HouseTemplateColumn("ITEM DESCRIPTION"));
            report.Columns.Add(new HouseTemplateColumn("DELIVERY REFERENCE"));
            report.Columns.Add(new HouseTemplateColumn("STATUS"));
            report.Columns.Add(new HouseTemplateColumn("SERIAL NO."));

            foreach (DataGridViewRow row in ItemListDataGridView.Rows) {
                if (row.IsNewRow) continue;
                report.Rows.Add(row.Cells.Cast<DataGridViewCell>()
                    .Take(7)
                    .Select(c => c.FormattedValue?.ToString() ?? "")
                    .ToArray());
            }

            report.Signatures.Add(HouseTemplateReport.Pair("PREPARED BY", ""));
            report.Signatures.Add(HouseTemplateReport.Pair("RECEIVED BY", ""));

            try {
                report.ShowPreview();
            } catch (Exception ex) {
                Log.Error(ex, "Error printing the dispatch copy of order {OrderId}", _currentOrder.OrderID);
                MessageBox.Show("Could not open the print preview: " + ex.Message, "Sales Order",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
