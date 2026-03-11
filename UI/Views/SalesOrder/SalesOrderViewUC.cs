using Microsoft.Extensions.DependencyInjection;
using Serilog;
using smpc_dispatching.Core.Interfaces;
using smpc_dispatching.Core.Models;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using System.ComponentModel;

namespace smpc_dispatching.UI.Views.SalesOrder {
    public partial class SalesOrderViewUC : UserControl {

        //private readonly ISalesOrderService _salesOrderService;
        //private List<SalesOrderModel> _salesOrders;
        //private readonly SalesOrderListForm _salesOrderListForm;
        //private int currentOrderIndex = 0;
        //private readonly IDrawFolderTreeService<FileModel> _drawFolderTreeService;
        //private List<FileModel> _files = new List<FileModel>();
        //private FileModel _currentFile = new FileModel();


        //public SalesOrderViewUC(ISalesOrderService salesOrderService, IServiceProvider serviceProvider, IDrawFolderTreeService<FileModel> drawFolderTreeService) {

        //    if (LicenseManager.UsageMode == LicenseUsageMode.Designtime)
        //    {
        //        InitializeComponent();
        //        return;
        //    }

        //    InitializeComponent();

        //    this.AutoScroll = true;
        //    _drawFolderTreeService = drawFolderTreeService;
        //    _salesOrderService = salesOrderService;
        //    _salesOrderListForm = serviceProvider.GetRequiredService<SalesOrderListForm>();

        //    LoadSalesOrders();

        //    ShowOrderListFormPanel.Cursor = Cursors.Hand;
        //    ShowOrderListFormPanel.Click += ShowOrderListFormPanel_Click;

        //    _salesOrderListForm.SetCurrentOrderID = value => SetCurrentOrder(value);

        //    DrawTreeView();
        //}


        //protected override Point ScrollToControl(Control activeControl) {

        //    if (activeControl != null) {
        //        Rectangle visible = new Rectangle(
        //            -this.AutoScrollPosition.X,
        //            -this.AutoScrollPosition.Y,
        //            this.ClientSize.Width,
        //            this.ClientSize.Height);

        //        if (visible.Contains(activeControl.Bounds))
        //            return this.AutoScrollPosition;
        //    }

        //    return base.ScrollToControl(activeControl);
        //}


        //private async void LoadSalesOrders() {
        //    try {

        //        var res = await _salesOrderService.GetAllAsync(null);

        //        if (res != null && res.Success) {
        //            _salesOrders = res.Data.ToList();
        //            _salesOrderListForm.InitOrders(_salesOrders);

        //            var latestOrder = _salesOrders.LastOrDefault();

        //            if (latestOrder != null) {
        //                SetCurrentOrder(latestOrder.OrderID);
        //                currentOrderIndex = _salesOrders.Count - 1;
        //            }
        //        }

        //    } catch (Exception ex) {
        //        Log.Error("Error getting all sales order: ", ex.Message);
        //    }
        //}


        //private void SetCurrentOrder(uint id) {
        //    _files = new List<FileModel>();

        //    var order = _salesOrders.Where(o => o.OrderID == id).First();

        //    if (order == null) return;

        //    CustomerTextBox.Text = order.CustomerName;
        //    CodeTextBox.Text = order.CustomerCode;
        //    DeliverToTextBox.Text = order.ShipTo;
        //    BillToTextBox.Text = order.BillTo;
        //    ReceiverTextBox.Text = order.ShipTo;
        //    ContactNoTextBox.Text = order.ContactNo;
        //    TinTextBox.Text = order.Tin;
        //    DocNoTextBox.Text = order.DocumentNo;
        //    DateTextBox.Text = order.Date.ToString();
        //    DeliveryDateTextBox.Text = order.DeliveryDate.ToString();
        //    ReferenceDocTextBox.Text = order.RefPO.ToString();
        //    StatusTextBox.Text = order.Status;
        //    ExecutiveTextBox.Text = order.SalesExecutive;
        //    DeliveryStatusTextBox.Text = order.Status;



        //    var items = order.Items;
        //    if (items != null && items.Count > 0) {
        //        //PopulateItemList(items);
        //    }


        //    var receipts = order.DeliveryReceipts;
        //    if (receipts != null && receipts.Count > 0) {
        //        PopulateOrderCostList(receipts);


        //        foreach (var receipt in receipts) {
        //            _files.Add(new FileModel {
        //                Name = receipt.AttachedFile.Name,
        //                Path = receipt.AttachedFile.Path,
        //            });
        //        }
        //    }
        //    DrawTreeView();

        //}

        //private void PopulateItemList(List<SalesOrderDetailsModel> orderItems) {
        //    ItemListDataGridView.Rows.Clear();
        //    ItemListDataGridView.Rows.Clear();

        //    if (orderItems == null || orderItems.Count <= 0) return;

        //    List<ItemReleaseModel> releases = new List<ItemReleaseModel>();
        //    List<DeliveryReceiptModel> receipts = new List<DeliveryReceiptModel>();

        //    for (var i = 0; i < orderItems.Count; i++) {
        //        var order = orderItems[i];

        //        if (order != null) {

        //            var serialNumbers = "";

        //            if (order.Releases != null && order.Releases.Count() > 0) {
        //                serialNumbers = String.Join("-", order.Releases.Select(x => x.SerialNumber));
        //            }
        //            ItemListDataGridView.Rows.Add(i + 1, order.Qty, order.Item.ModelItem, order.Item.ShortDesc, order.Releases[0]?.DeliveryReceipt?.DeliveryReference, order.Status, serialNumbers);
        //            releases.AddRange(order.Releases);
        //        }
        //    }

        //    PopulateDispatchList(releases);

        //}



        //private void PopulateDispatchList(List<ItemReleaseModel> releases) {

        //    DispatchItemsListDataGridView.Rows.Clear();

        //    if (releases == null || releases.Count <= 0) return;

        //    for (int i = 0; i < releases.Count; i++) {
        //        var release = releases[i];
        //        var pickActivity = "";

        //        DispatchItemsListDataGridView.Rows.Add(release.CreatedAt, release.Status,
        //            release.Vehicle?.PlateNo, release.Peoples, pickActivity, release.DeliveryReceipt?.DeliveryReceiptNumber, release.DepartedAt,
        //            release.ArrivedAt, release.ReturnedAt, release.DeliveryReceipt?.TripCost?.TotalCost);
        //    }


        //}


        //    private void PopulateOrderCostList(List<DeliveryReceiptModel> receipts) {
        //        OrdersDeliveryCostataGridView.Rows.Clear();

        //        if (receipts == null || receipts.Count <= 0) return;

        //        for (int i = 0; i < receipts.Count; i++) {
        //            var receipt = receipts[i];
        //            OrdersDeliveryCostataGridView.Rows.Add(receipt.DeliveryDate, receipt.DeliveryType, receipt?.TripCost?.CostType, receipt?.TripCost?.Remarks, receipt.TripCost?.TotalCost, receipt.AttachedFile?.Name, receipt.TripCost?.Remarks);
        //        }

        //        //Total amount

        //        // Calculate total from the Amount column
        //        decimal total = 0;
        //        foreach (DataGridViewRow row in OrdersDeliveryCostataGridView.Rows) {
        //            if (row.IsNewRow) continue; // skip the last blank input row
        //            if (row.Cells["Amount"].Value != null &&
        //                decimal.TryParse(row.Cells["Amount"].Value.ToString(), out decimal val)) {
        //                total += val;
        //            }
        //        }

        //        // Add new total row
        //        int totalRowIndex = OrdersDeliveryCostataGridView.Rows.Add();
        //        var totalRow = OrdersDeliveryCostataGridView.Rows[totalRowIndex];

        //        // Make all cells empty first
        //        foreach (DataGridViewCell cell in totalRow.Cells)
        //            cell.Value = string.Empty;

        //        // Set total text and value

        //        totalRow.Cells["Amount"].Value = $"Total: {total}";

        //        // Mark this row as "Total"
        //        totalRow.Tag = "TotalRow";

        //    }


        //    private void ShowOrderListFormPanel_Click(object sender, EventArgs e) {
        //        _salesOrderListForm.ShowDialog();
        //    }

        private void NextBtn_Click(object sender, EventArgs e)
        {

            //if (currentOrderIndex >= _salesOrders.Count - 1) return;

            //currentOrderIndex++;
            //var found = _salesOrders[currentOrderIndex];

            //if (found == null) return;
            //SetCurrentOrder(found.OrderID);

        }

        private void PrevBtn_Click(object sender, EventArgs e)
        {

            //if (currentOrderIndex <= 0) return;
            //currentOrderIndex--;
            //var found = _salesOrders[currentOrderIndex];

            //if (found == null) return;
            //SetCurrentOrder(found.OrderID);

        }

        //    private void DrawTreeView() {
        //        TreeViewPanel.Controls.Clear();
        //        ClearCurrentFile();

        //        var deliveryReceiptFolder = new FolderTreeModel<FileModel> {
        //            Name = "Delivery Receipts",
        //            IsFolder = true,
        //            Param = new FileModel(),
        //            Children = new List<FolderTreeModel<FileModel>>(),
        //        };

        //        if (_files.Count > 0) {
        //            foreach (var recipt in _files) {
        //                var receiptFile = new FolderTreeModel<FileModel> {
        //                    Name = recipt.Name,
        //                    IsFolder = false,
        //                    Param = recipt,
        //                };
        //                deliveryReceiptFolder.Children.Add(receiptFile);
        //            }
        //        }

        //        var pickupReceiptFolder = new FolderTreeModel<FileModel> {
        //            Name = "Pick-up Receipts",
        //            IsFolder = true,
        //            Param = new FileModel(),
        //            Children = new List<FolderTreeModel<FileModel>>(),
        //        };


        //        var folders = new List<FolderTreeModel<FileModel>>
        //                {
        //                    new FolderTreeModel<FileModel>
        //                    {
        //                        Name = "Benched",
        //                        IsFolder = true,
        //                        Param =  new FileModel(),
        //                        Children = new List<FolderTreeModel<FileModel>>
        //                        {
        //                           deliveryReceiptFolder,
        //                           pickupReceiptFolder
        //                        }
        //                    },
        //                    new FolderTreeModel<FileModel>
        //                    {
        //                        Name = "Active",
        //                        IsFolder = true,
        //                        Param = new FileModel()
        //                    }
        //                };


        //        var folderTree = _drawFolderTreeService.DrawFolderTree(folders, FolderTree_NodeClick);

        //        TreeViewPanel.Controls.Add(folderTree);
        //    }

        //    private void FolderTree_NodeClick(object sender, TreeNodeMouseClickEventArgs e) {
        //        if (e.Node?.Tag is FolderTreeModel<FileModel> model) {
        //            if (model != null && !model.IsFolder) {
        //                var param = model.Param;

        //                var file = _files.Where(f => f.Name == param.Name).FirstOrDefault();
        //                if (file != null) {
        //                    SetCurrentFile(file);
        //                }
        //            }
        //        }
        //    }

        //    private void SetCurrentFile(FileModel file) {
        //        _currentFile = file;
        //        FileNameLabel.Text = file.Name;
        //        PrintButton.Enabled = true;
        //        FileNameLabel.Visible = true;
        //        CurrenFIleImagePanel.Visible = true;
        //    }

        //    private void ClearCurrentFile() {
        //        _currentFile = null;
        //        FileNameLabel.Text = "";
        //        PrintButton.Enabled = false;
        //        FileNameLabel.Visible = false;
        //        CurrenFIleImagePanel.Visible = false;
        //    }

        private void PrintButton_Click(object sender, EventArgs e)
        {
            ////Printing file

            //if (_currentFile == null) return;


            //MessageBox.Show($"Printing file {_currentFile.Name}");
        }
    }
}
