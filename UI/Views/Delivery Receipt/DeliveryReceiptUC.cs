using Microsoft.Extensions.DependencyInjection;
using Microsoft.Reporting.WinForms;
using Serilog;
using smpc_dispatching.Core.Enum;
using smpc_dispatching.Core.Helpers;
using smpc_dispatching.Core.Interfaces;
using smpc_dispatching.Core.Models;
using smpc_dispatching.Core.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace smpc_dispatching.UI.Views.Delivery_Receipt
{
    public partial class DeliveryReceiptUC : UserControl
    {
        private readonly PrintService _printService;
        private readonly IServiceProvider _serviceProvider;
        private readonly IDeliveryReceiptService _deliveryReceiptService;
        private readonly ISalesOrderWithApprovedIRService<SalesOrderWithApprovedIRModel> _salesOrderWithApprovedIRService;
        private readonly ISalesOrderWithApprovedIRDetailsService _salesOrderWithApprovedIRDetailsService;
        private readonly ICostTypeService<SetupModel> _costTypeService;
        private readonly IShipTypeService<ShipTypeModel> _shipTypeService;

        private readonly ISalesOrderIRViewService<SalesOrderViewModel> _salesOrderIRViewService;
        private readonly ISalesOrderService _salesOrderService;
        private readonly IBpiService _bpiService;
        private readonly IItemReleaseService _itemReleaseService;

        private Panel[] _pnls;
        private BindingList<DeliveryReceiptItemModel> _bindingListItem;
        private BindingList<DeliveryReceiptCostModel> _bindingListCost/* = new BindingList<DeliveryReceiptCostModel>()*/;
        private List<DeliveryReceiptModel> _deliveryReceipts;
        private List<SalesOrderWithApprovedIRModel> _IrApprovedSo;
        private List<SalesOrderWithApprovedIRDetailsModel> _IrDetailsApprovedSo;
        private DataTable _soirTable;
        private DataTable _soTable;
        private DataTable _bpiTable;
        private DataTable _bpiAddressTable;
        private DataTable _bpiGeneralTable;
        private DataTable _itemReleases;
        private BindingList<ItemReleaseDetailsModel> _detailsBinding;
        private bool isLoading = false;
        private int _currentIndex = 0;
        private int _previousIRIndex = -1;
        private bool _hasError = false;

        private enum DRMode { Create, View, Edit }
        private DRMode _mode;
        private bool _isNewMode => _mode == DRMode.Create;
        private bool _isEditMode => _mode == DRMode.Edit;
        private bool _isViewMode => _mode == DRMode.View;
        private static readonly HashSet<string> _costTypeTemplate = new HashSet<string>
        {
            "LABOR",
            "VEHICLE",
            "FUEL",
            "TOLL GATE",
            "INSURANCE",
            "PENALTY",
            "OTHERS"
        };
        private BindingList<DeliveryReceiptCostModel> _costRows = new BindingList<DeliveryReceiptCostModel>();

        private List<SetupModel> _costTypes;
        private List<ShipTypeModel> _shipTypes;
        public DeliveryReceiptUC( IServiceProvider serviceProvider, PrintService printService)
        {
            InitializeComponent();

            _serviceProvider = serviceProvider;
            _printService = printService;
            _deliveryReceiptService = serviceProvider.GetRequiredService<IDeliveryReceiptService>();
            _costTypeService = serviceProvider.GetRequiredService<ICostTypeService<SetupModel>>();
            _salesOrderWithApprovedIRService = serviceProvider.GetRequiredService<ISalesOrderWithApprovedIRService<SalesOrderWithApprovedIRModel>>();
            _salesOrderWithApprovedIRDetailsService = serviceProvider.GetRequiredService<ISalesOrderWithApprovedIRDetailsService>();
            _shipTypeService = serviceProvider.GetRequiredService<IShipTypeService<ShipTypeModel>>();
            _salesOrderIRViewService = serviceProvider.GetRequiredService<ISalesOrderIRViewService<SalesOrderViewModel>>();
            _salesOrderService = serviceProvider.GetRequiredService<ISalesOrderService>();
            _bpiService = serviceProvider.GetRequiredService<IBpiService>();
            _itemReleaseService = serviceProvider.GetRequiredService<IItemReleaseService>();

            _pnls = new[] { pnl_header };
            ToggleButton();

            isLoading = true;
            cmb_sales_order_id.Enabled = false;
            //SetupGridFormat();
        }
        private async void DeliveryReceiptUC_Load(object sender, EventArgs e)
        {
            InitializeDgCosts();

            await LoadCostType();
            await LoadIRApprovedSO();
            await LoadShipType();
            
            await LoadDeliveryReceipts();
            await LoadReferenceDocument();
            await LoadBPI();
            await LoadSalesOrder();
            await LoadItemRelease();

            //Initial for the combobox
            var uniqueDocs = _itemReleases.AsEnumerable()
                .Select(r => r.Field<string>("reference_doc_no"))
                .Where(d => !string.IsNullOrWhiteSpace(d))
                .Distinct()
                .OrderBy(d => d)
                .ToList();

            cmb_sales_order_id.DataSource = uniqueDocs;
            cmb_sales_order_id.SelectedIndex = -1;
        }

        private async Task LoadItemRelease()
        {
            var response = await _itemReleaseService.GetAllAsync(null);
            _itemReleases = response.Data?.ToList() != null ? Helpers.ToDataTable(response.Data.ToList()) : new DataTable();
        }

        private async Task LoadBPI()
        { 
            var response = await _bpiService.GetAllAsync(null);

            if (response?.Data == null) return;

            _bpiTable = Helpers.ToDataTable(response.Data.Bpi.ToList());
            _bpiAddressTable = Helpers.ToDataTable(response.Data.Address.ToList());
            _bpiGeneralTable = Helpers.ToDataTable(response.Data.General.ToList());
        }

        private async Task LoadSalesOrder()
        {
            var response = await _salesOrderService.GetAllAsync(null);

            if (response?.Data == null) return;

            _soTable = Helpers.ToDataTable(response.Data.ToList());
        }
        private async Task LoadReferenceDocument()
        {
            var response = await _salesOrderIRViewService.GetAllAsync(null);
            if (response?.Data == null) return;

            _soirTable = Helpers.ToDataTable(response.Data.ToList());
        }

        private async Task LoadDeliveryReceipts(int? focusId = null)
        {
            var response = await _deliveryReceiptService.GetAllAsync(null);
            _deliveryReceipts = response?.Data?.ToList() ?? new List<DeliveryReceiptModel>();

            if (_deliveryReceipts.Count == 0)
            {
                _currentIndex = -1;
                dg_items.DataSource = null;
                _costRows.Clear();
                SetMode(DRMode.View);
                return;
            }

            // Land on the record we just created/updated instead of a stale index
            // (which could be -1, clearing the screen without returning to View mode).
            if (focusId.HasValue)
                _currentIndex = _deliveryReceipts.FindIndex(d => d.id == focusId.Value);

            if (_currentIndex < 0 || _currentIndex >= _deliveryReceipts.Count)
                _currentIndex = _deliveryReceipts.Count - 1;

            BindDeliveryReceipt(_currentIndex);
        }
        public async Task LoadCostType()
        {
            var response = await _costTypeService.GetAllAsync(null);
            if (response?.Data == null) return;

            _costTypes = response?.Data?.ToList() ?? new List<SetupModel>();
            costs_cost_type_id.DataSource = AddDefaultValue(_costTypes);
            costs_cost_type_id.DisplayMember = nameof(SetupModel.name);
            costs_cost_type_id.ValueMember = nameof(SetupModel.id);
        }
        public async Task LoadIRApprovedSO()
        {
            isLoading = true;
            var response = await _salesOrderWithApprovedIRService.GetAllAsync(null);
            if (response?.Data == null) return;
            _IrApprovedSo = response.Data.ToList();

            var uniqueDocs = _IrApprovedSo
                .GroupBy(s => s.sales_order_no)
                .Where(g => !string.IsNullOrWhiteSpace(g.Key))
                .Select(g => g.First())
                .OrderBy(s => s.sales_order_no)
                .ToList();

            cmb_sales_order_id.DataSource = null; // reset first to avoid binding conflicts
            cmb_sales_order_id.DataSource = uniqueDocs;
            cmb_sales_order_id.DisplayMember = nameof(SalesOrderWithApprovedIRModel.sales_order_no);
            cmb_sales_order_id.ValueMember = nameof(SalesOrderWithApprovedIRModel.sales_order_id);
            cmb_sales_order_id.SelectedIndex = -1;

            isLoading = false;
        }
        private async Task LoadShipType()
        {
            var response = await _shipTypeService.GetAllAsync(null);

            _shipTypes = response?.Data?.ToList() ?? new List<ShipTypeModel>();
            cmb_ship_type_id.DataSource = AddShipTypeDefaultValue(_shipTypes);
            cmb_ship_type_id.DisplayMember = nameof(ShipTypeModel.ship_name);
            cmb_ship_type_id.ValueMember = nameof(ShipTypeModel.id);

        }
        private void BindDeliveryReceipt(int index)
        {
            if (_deliveryReceipts == null || index < 0 || index >= _deliveryReceipts.Count)
            {
                dg_items.DataSource = null;
                _costRows.Clear(); // clear instead of nulling datasource
                return;
            }

            var current = _deliveryReceipts[index];
            Helpers.BindHelpers.BindParentToPanels(current, _pnls, "DR#");

            // dg_items' fixed columns only resolve ItemReleaseDetailsModel's property
            // names (see GetDetailsFromDataTable) — convert the saved DeliveryReceiptItemModel
            // rows into that shape, otherwise every cell renders blank.
            _detailsBinding = ToItemReleaseDetailsList(current.delivery_receipt_items);
            dg_items.DataSource = _detailsBinding;

            // Update _costRows in-place instead of creating a new BindingList
            _costRows.Clear();
            foreach (var cost in current.delivery_receipt_costs ?? new List<DeliveryReceiptCostModel>())
                _costRows.Add(cost);

            ComputeGrandTotal();
            SetMode(DRMode.View);
        }
        private void BindSalesOrder(string soDocNo)
        {
            var selectedSO = _IrApprovedSo?.FirstOrDefault(x => x.sales_order_no == soDocNo);
            if (selectedSO == null) return;
            Helpers.BindHelpers.BindParentToPanels(selectedSO, _pnls);

            // Correct cmb_ship_type_id if ship_type_id not in data source
            var shipTypeExists = _shipTypes?.Any(x => x.id == selectedSO.ship_type_id) ?? false;
            if (!shipTypeExists)
                cmb_ship_type_id.SelectedValue = 0;

            LoadIRItems((int)selectedSO.item_release_id);
        }
        private async void LoadIRItems(int irId)
        {
             var response = await _salesOrderWithApprovedIRDetailsService.GetAsync(irId);

            if (response?.Data == null) return;

            _IrDetailsApprovedSo = response.Data.ToList();
            dg_items.DataSource = _IrDetailsApprovedSo;
        }
        public void InitializeDgCosts()
        {
            dg_costs.DataSource = _costRows; // bind once on form load
        }
        public void GenerateCostTypeRow()
        {
            _costRows.Clear();

            foreach (var costType in _costTypes)
            {
                if (_costTypeTemplate.Contains(costType.name))
                {
                    _costRows.Add(new DeliveryReceiptCostModel
                    {
                        costs_cost_type_id = costType.id,
                    });
                }
            }
        }
        private void BindItemRelease(int index)
        {
            if (_deliveryReceipts == null || index < 0 || index >= _deliveryReceipts.Count)
            {
                dg_items.DataSource = null;
                return;
            }

            var current = _deliveryReceipts[index];

            // Bind parent fields to panels
            Helpers.BindHelpers.BindParentToPanels(current, _pnls, "IREL#");


            // Bind child details to DataGridView
            _bindingListItem = new BindingList<DeliveryReceiptItemModel>(
                current.delivery_receipt_items ?? new List<DeliveryReceiptItemModel>()
            );

            _bindingListCost = new BindingList<DeliveryReceiptCostModel>(
                    current.delivery_receipt_costs ?? new List<DeliveryReceiptCostModel>()
                );


            dg_items.DataSource = _bindingListItem;
            dg_costs.DataSource = _bindingListCost;

        }
        private async void btn_save_Click(object sender, EventArgs e)
        {
            btn_save.Enabled = false;
            try
            {
                if (!await ValidateInput(_pnls)) return;
                var deliveryReceipt = Helpers.BuildModelFromPanels<DeliveryReceiptModel>(_pnls);
                var deliveryReceiptItem = BuildDeliveryReceiptItemsFromGrid();
                var deliveryReceiptCosts = Helpers.DatagridviewMapper.BuildModelsFromData < DeliveryReceiptCostModel>(dg_costs);

                deliveryReceipt.delivery_receipt_items = deliveryReceiptItem;
                deliveryReceipt.delivery_receipt_costs = deliveryReceiptCosts;


                bool isNew = string.IsNullOrWhiteSpace(txt_id.Text);
                int savedId;

                if (isNew)
                {
                    var response = await _deliveryReceiptService.CreateAsync(deliveryReceipt);
                    if (!response.Success)
                    {
                        Helpers.ShowDialogMessage("error", "Delivery Receipt saving failed.");
                        return;
                    }
                    savedId = response.Data.id;
                }
                else
                {
                    deliveryReceipt.id = int.Parse(txt_id.Text);
                    // ✅ explicitly set is_forward

                    var response = await _deliveryReceiptService.UpdateAsync(deliveryReceipt);
                    if (!response.Success)
                    {
                        Helpers.ShowDialogMessage("error", "Item Release saving failed.");
                        return;
                    }
                    savedId = deliveryReceipt.id;
                }
                Helpers.ShowDialogMessage("success", "Delivery Receipt saved successfully.");

                await LoadDeliveryReceipts(savedId);

            }
            catch (Exception ex)
            {
                Log.Error(ex, "Save failed");
                Helpers.ShowDialogMessage("error", ex.Message);
            }
            finally
            {
                btn_save.Enabled = true;  
            }
        }
        private async void btn_close_Click(object sender, EventArgs e)
        {
            SetMode(DRMode.View);

            cmb_sales_order_id.DropDownStyle = ComboBoxStyle.DropDown;

            if (_previousIRIndex >= 0 && _deliveryReceipts != null && _deliveryReceipts.Count > 0)
            {
                await LoadDeliveryReceipts();
            }
        }
        private void btn_new_Click(object sender, EventArgs e)
        {
            Helpers.ResetControls(_pnls);
            
            SetMode(DRMode.Create);
            GenerateCostTypeRow();

            _bindingListItem = new BindingList<DeliveryReceiptItemModel>();
            dg_items.DataSource = _bindingListItem;

            //_bindingListCost = new BindingList<DeliveryReceiptCostModel>();
            //dg_items.DataSource = _bindingListCost;

        }
        private async Task<bool> ValidateInput(Panel[] pnls)
        {
            _hasError = false;

            foreach (var pnl in pnls)
            {
                if (Helpers.ValidateControlsValues(pnl))
                {
                    _hasError = true;
                    break;
                }
            }

            if (_hasError)
            {
                Helpers.ShowDialogMessage("error", "Please fill in all required fields");
                btn_save.Enabled = true;
                return false;
            }

            if (dtp_date.Value.Date < DateTime.Now.Date)
            {
                Helpers.ShowDialogMessage("error", "Issue Date cannot be later than today.");
                lb_delivery_date.Focus();
                return false;
            }


            string[] columnsToValidate = new[] { "qty" };
            bool dgvHasErrors = await Helpers.ValidateDataGridViewCells(dg_items, columnsToValidate);

            return !dgvHasErrors;
        }
        private void SetMode(DRMode mode)
        {
            try
            {
                _mode = mode;
                bool isView = _isViewMode;
                bool isNew = _isNewMode;
                bool canEdit = _isNewMode || _isEditMode;

                // DataGridView
                dg_items.ReadOnly = !canEdit;
                dg_costs.ReadOnly = !canEdit;


                // Buttons
                SetToolStripButtons(canEdit);
                if (canEdit)
                {
                    Helpers.SetPanelToReadOnly(pnl_header, false);

                    _previousIRIndex = _currentIndex;
                    if (isNew)
                    {
                        txt_doc_no.Text = "DR#0000";
                        txt_doc_no.ReadOnly = true;
                        cmb_sales_order_id.Enabled = true;
                        dg_items.Enabled = false;
                    }
                }

                if (isView)
                {
                    Helpers.SetPanelToReadOnly(pnl_header, true);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Failed to set mode: {ex.Message}\n{ex.StackTrace}");
            }
        }
        private void SetToolStripButtons(bool canEdit)
        {
            Helpers.SetButtonVisibility(
                toolStrip1,
                visibleButtons: canEdit
                    ? new[] { "btn_save", "btn_close" }
                    : new[] { "btn_prev", "btn_next", "btn_search", "btn_new", "btn_edit", "btn_delete", "btn_print" },
                hiddenButtons: canEdit
                    ? new[] { "btn_prev", "btn_next", "btn_search", "btn_new", "btn_edit", "btn_delete", "btn_print" }
                    : new[] { "btn_save", "btn_close" }
            );
        }

        private void SetEditableColumns(bool isEdit)
        {
            var editableColumns = new[]
            {
                nameof(DeliveryReceiptCostModel.costs_cost_type_id),
                nameof(DeliveryReceiptCostModel.costs_description),
                nameof(DeliveryReceiptCostModel.costs_amount),
                nameof(DeliveryReceiptCostModel.costs_multiplier),
            };

            foreach (var colName in editableColumns)
            {
                if (dg_items.Columns.Contains(colName))
                    dg_items.Columns[colName].ReadOnly = !isEdit;
            }
        }

        private void btn_toggle_Click(object sender, EventArgs e)
        {
            bool isExpanded = pnl_footer.Visible = !pnl_footer.Visible;
            ToggleButton();
        }
        private void ToggleButton()
        {
            btn_toggle.Text = pnl_footer.Visible
                ? "DELIVERY COST  ▲"
                : "DELIVERY COST  ▼";

            btn_toggle.BackColor = pnl_footer.Visible
                ? Color.LightCoral 
                : Color.LightGreen;

            btn_toggle.ForeColor = Color.Black;
        }

        
        private void btn_prev_Click(object sender, EventArgs e) => ChangeRecord(-1);
        private void btn_next_Click(object sender, EventArgs e) => ChangeRecord(1);
        private void btn_edit_Click(object sender, EventArgs e) => SetMode(DRMode.Edit);
        private void ChangeRecord(int step)
        {
            if (_deliveryReceipts == null || !_deliveryReceipts.Any())
                return;

            int newIndex = _currentIndex + step;
            if (newIndex < 0 || newIndex >= _deliveryReceipts.Count)
                return;

            _currentIndex = newIndex;
            BindDeliveryReceipt(_currentIndex);

            btn_prev.Enabled = _currentIndex > 0;
            btn_next.Enabled = _currentIndex < _deliveryReceipts.Count - 1;
        }

        private void dg_costs_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            var grid = (DataGridView)sender;
            var columnName = grid.Columns[e.ColumnIndex].DataPropertyName;

            if (e.RowIndex < _costRows.Count)
            {
                var costRow = _costRows[e.RowIndex];

                switch (columnName)
                {
                    case nameof(DeliveryReceiptCostModel.costs_amount):
                        costRow.costs_amount = 0;
                        break;
                    case nameof(DeliveryReceiptCostModel.costs_multiplier):
                        costRow.costs_multiplier = 0;
                        break;
                    case nameof(DeliveryReceiptCostModel.costs_total_cost):
                        costRow.costs_total_cost = 0;
                        break;
                    case nameof(DeliveryReceiptCostModel.costs_id):
                        costRow.costs_id = 0;
                        break;
                }
                var columnFriendlyName = grid.Columns[e.ColumnIndex].HeaderText;
                Helpers.ShowDialogMessage("warning", $"'{columnFriendlyName}' only accepts numbers.");
            }

            e.Cancel = true;
        }

        private void dg_costs_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            var columnName = dg_costs.Columns[e.ColumnIndex].DataPropertyName;

            // CHECK FOR DUPLICATE COST TYPE
            if (columnName == nameof(DeliveryReceiptCostModel.costs_cost_type_id))
            {
                var currentRow = dg_costs.Rows[e.RowIndex];
                var currentValue = currentRow.Cells[e.ColumnIndex].Value;

                if (currentValue != null)
                {
                    int currentCostTypeId = Convert.ToInt32(currentValue);

                    for (int i = 0; i < dg_costs.Rows.Count; i++)
                    {
                        if (i == e.RowIndex) continue;

                        var cellValue = dg_costs.Rows[i]
                            .Cells[nameof(DeliveryReceiptCostModel.costs_cost_type_id)]
                            .Value;

                        if (cellValue != null && Convert.ToInt32(cellValue) == currentCostTypeId)
                        {
                            // Reset duplicate
                            currentRow.Cells[e.ColumnIndex].Value = 0;

                            currentRow.Cells[e.ColumnIndex].ErrorText = "Cost type already exists!";

                            var timer = new System.Windows.Forms.Timer { Interval = 2000 };
                            timer.Tick += (s, args) =>
                            {
                                currentRow.Cells[e.ColumnIndex].ErrorText = string.Empty;
                                timer.Stop();
                                timer.Dispose();
                            };
                            timer.Start();

                            dg_costs.CurrentCell = currentRow.Cells[e.ColumnIndex];
                            return;
                        }
                    }
                }
            }

            // Only validate if editing a column that requires cost type first
            if (columnName != nameof(DeliveryReceiptCostModel.costs_cost_type_id))
            {
                // e.RowIndex can point at the DataGridView's blank "new row" placeholder,
                // which hasn't been committed to _costRows yet — nothing to validate there.
                if (e.RowIndex < 0 || e.RowIndex >= _costRows.Count)
                    return;

                var costRow = _costRows[e.RowIndex];

                if (costRow.costs_cost_type_id == 0)
                {
                    dg_costs.Rows[e.RowIndex].Cells[e.ColumnIndex].Value = 0;

                    dg_costs.Rows[e.RowIndex]
                        .Cells[nameof(DeliveryReceiptCostModel.costs_cost_type_id)]
                        .ErrorText = "Please select a cost type first!";

                    var timer = new System.Windows.Forms.Timer { Interval = 2000 };
                    timer.Tick += (s, args) =>
                    {
                        dg_costs.Rows[e.RowIndex]
                            .Cells[nameof(DeliveryReceiptCostModel.costs_cost_type_id)]
                            .ErrorText = string.Empty;

                        timer.Stop();
                        timer.Dispose();
                    };
                    timer.Start();

                    dg_costs.CurrentCell = dg_costs.Rows[e.RowIndex]
                        .Cells[nameof(DeliveryReceiptCostModel.costs_cost_type_id)];

                    return;
                }
            }

            // Run computation if amount or multiplier changed
            if (columnName == nameof(DeliveryReceiptCostModel.costs_amount) ||
                columnName == nameof(DeliveryReceiptCostModel.costs_multiplier))
            {
                ComputeRowTotal(e.RowIndex);
                ComputeGrandTotal();
            }
        }
        private void cmb_reference_doc_no_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (isLoading) { isLoading = false; return; }

            string selectedDoc = cmb_sales_order_id.SelectedItem?.ToString();

            if (selectedDoc == null) return;

            // Each of these is only populated if its own Load* call succeeded (see
            // LoadReferenceDocument/LoadItemRelease/LoadSalesOrder/LoadBPI) - if any
            // failed or hasn't finished yet, using it here throws ArgumentNullException.
            if (_soirTable == null || _itemReleases == null || _soTable == null
                || _bpiTable == null || _bpiAddressTable == null || _bpiGeneralTable == null)
            {
                Helpers.ShowDialogMessage("success", "Reference data is still loading. Please wait and try again.");
                return;
            }

            var filteredRows = _soirTable.AsEnumerable()
                .Where(r => r.Field<string>("ref_doc_no") == selectedDoc)
                .ToList();

            var selectedItemRelease = _itemReleases.AsEnumerable()
                .FirstOrDefault(r => r.Field<string>("reference_doc_no") == selectedDoc);

            //var selectedSalesOrderDetails = _IrDetailsApprovedSo?.FirstOrDefault(x => x.sales_order_no == selectedDoc);

            // selectedDoc comes from the item release's reference_doc_no, which lines up
            // with the sales order's DocumentNo - not its Doc (a separate, unrelated
            // number) - matching against the wrong column silently resolved to the
            // wrong sales order (or none), corrupting the saved sales_order_id.
            var selectedSalesOrder = _soTable.AsEnumerable()
                .FirstOrDefault(r => r.Field<string>("Doc") == selectedDoc);

            var selectedBPI = _bpiTable.AsEnumerable()
                .FirstOrDefault(r => r.Field<int>("Id") == selectedSalesOrder?.Field<uint>("CustomerID"));

            var selectedBPIAddress = _bpiAddressTable.AsEnumerable()
                .FirstOrDefault(r => r.Field<int>("AddressBasedId") == selectedBPI?.Field<int>("Id"));

            var selectedBPIGeneral = _bpiGeneralTable.AsEnumerable()
                .FirstOrDefault(r => r.Field<int>("GeneralBasedId") == selectedBPI?.Field<int>("Id"));

            txt_customer_name.Text = selectedBPI?.Field<string>("Name");
            txt_customer_code.Text = selectedSalesOrder?.Field<string>("CustomerCode");
            txt_address.Text = selectedBPIAddress?.Field<string>("Location");
            txt_tin_no.Text = selectedBPI?.Field<string>("Tin");

            txt_sales_executive.Text = selectedSalesOrder?.Field<string>("SalesExecutive");
            txt_item_release_no.Text = selectedItemRelease?.Field<int>("doc_no").ToString();

            // cmb_sales_order_id is bound to reference_doc_no strings (see DeliveryReceiptUC_Load),
            // not real sales_order_id values, so BuildModelFromPanels must not read the id from it.
            // Carry the resolved numeric OrderID here instead - txt_ prefix + matching property name
            // makes BuildModelFromPanels<DeliveryReceiptModel> pick this up for sales_order_id.
            txt_sales_order_id.Text = selectedSalesOrder?.Field<uint>("OrderID").ToString() ?? string.Empty;

            // Same story as sales_order_id above - these hidden fields were never wired up,
            // so BuildModelFromPanels was always saving customer_id/item_release_id as 0.
            txt_customer_id.Text = selectedSalesOrder?.Field<uint>("CustomerID").ToString() ?? string.Empty;
            txt_item_release_id.Text = selectedItemRelease?.Field<uint>("id").ToString() ?? string.Empty;

            if (!filteredRows.Any())
            {
                dg_items.DataSource = null;
                return;
            }

            _detailsBinding = GetDetailsFromDataTable(filteredRows);
            dg_items.DataSource = _detailsBinding;
        }
        // dg_items has AutoGenerateColumns = false with columns whose DataPropertyName is
        // hard-wired (in the Designer) to ItemReleaseDetailsModel's property names
        // (item_code, required_qty, released_qty, ...). Binding any other model type here
        // makes every cell resolve to nothing, so this must stay ItemReleaseDetailsModel.
        private BindingList<ItemReleaseDetailsModel> GetDetailsFromDataTable(IEnumerable<DataRow> rows)
        {
            var list = new BindingList<ItemReleaseDetailsModel>();
            foreach (var r in rows)
            {
                list.Add(new ItemReleaseDetailsModel
                {
                    sales_order_details_id = ToUInt32OrDefault(r, "sales_order_details_id"),
                    item_id = ToUInt32OrDefault(r, "item_id"),
                    item_code = r["item_code"].ToString() ?? string.Empty,
                    item_description = r["item_description"]?.ToString() ?? string.Empty,
                    required_qty = ToUInt32OrDefault(r, "required_qty"),
                    required_uom = r["required_uom"]?.ToString() ?? string.Empty,
                    released_qty = ToUInt32OrDefault(r, "released_qty"),
                    released_uom = r["release_uom"]?.ToString() ?? string.Empty,
                    serial_no = r["serial_no"]?.ToString() ?? string.Empty,
                    delivery_preference = r["delivery_preference"]?.ToString() ?? string.Empty,
                });
            }
            return list;
        }

        // DataRow indexers return DBNull.Value (not C# null) for a null column, so
        // "r[col] ?? 0" never actually catches it - Convert.ToUInt32 still throws
        // InvalidCastException on DBNull. This checks for the real DBNull sentinel.
        private static uint ToUInt32OrDefault(DataRow row, string column)
        {
            var value = row[column];
            return value == DBNull.Value ? 0u : Convert.ToUInt32(value);
        }
        // Converts saved DeliveryReceiptItemModel rows (from the API) into the
        // ItemReleaseDetailsModel shape dg_items' fixed columns expect for display.
        private BindingList<ItemReleaseDetailsModel> ToItemReleaseDetailsList(List<DeliveryReceiptItemModel> items)
        {
            var list = new BindingList<ItemReleaseDetailsModel>();
            foreach (var item in items ?? new List<DeliveryReceiptItemModel>())
            {
                list.Add(new ItemReleaseDetailsModel
                {
                    sales_order_details_id = (uint)item.items_sales_order_details_id,
                    item_id = (uint)item.items_item_id,
                    item_code = item.items_item_code ?? string.Empty,
                    item_description = item.items_item_description ?? string.Empty,
                    released_qty = (uint)item.items_qty,
                    released_uom = item.items_unit_of_measure ?? string.Empty,
                    serial_no = item.items_serial_no ?? string.Empty,
                });
            }
            return list;
        }
        // Helpers.DatagridviewMapper.BuildModelsFromData<DeliveryReceiptItemModel> can't be used
        // here: it matches by DataGridView column Name, but dg_items' columns are hard-wired to
        // ItemReleaseDetailsModel's names (item_code, released_qty, ...), never the items_*
        // names DeliveryReceiptItemModel uses. Read the known columns directly instead.
        private List<DeliveryReceiptItemModel> BuildDeliveryReceiptItemsFromGrid()
        {
            var items = new List<DeliveryReceiptItemModel>();

            int ToInt(object value) => value == null || value == DBNull.Value ? 0 : Convert.ToInt32(value);
            string ToStr(object value) => value == null || value == DBNull.Value ? string.Empty : value.ToString();

            foreach (DataGridViewRow row in dg_items.Rows)
            {
                if (row.IsNewRow) continue;

                int itemId = ToInt(row.Cells["item_id"].Value);
                if (itemId == 0) continue;

                items.Add(new DeliveryReceiptItemModel
                {
                    items_item_id = itemId,
                    items_sales_order_details_id = ToInt(row.Cells["sales_order_details_id"].Value),
                    items_item_code = ToStr(row.Cells["item_code"].Value),
                    items_item_description = ToStr(row.Cells["item_description"].Value),
                    items_qty = ToInt(row.Cells["released_qty"].Value),
                    items_unit_of_measure = ToStr(row.Cells["released_uom"].Value),
                    items_serial_no = ToStr(row.Cells["serial_no"].Value),
                });
            }

            return items;
        }
        private static List<ShipTypeModel> AddShipTypeDefaultValue(List<ShipTypeModel> list, string defaultText = "-- SELECT --")
        {
            var result = new List<ShipTypeModel>(list);
            result.Insert(0, new ShipTypeModel { id = 0, ship_name = defaultText });
            return result;
        }
        private static List<SetupModel> AddDefaultValue(List<SetupModel> list, string defaultText = "-- SELECT --")
        {
            var result = new List<SetupModel>(list);
            result.Insert(0, new SetupModel { id = 0, name = defaultText });
            return result;
        }
        //private List<DeliveryReceiptCostModel> GetDRCost(bool isUpdate)
        //{
        //    var costsData = Helpers.ConvertDataGridViewToDataTable(dg_items);
        //    List<DeliveryReceiptCostModel> listOfCost = new List<DeliveryReceiptCostModel>();

        //    DeliveryReceiptItemModel items = null;


        //    return listOfCost;
        //}
        private void ComputeRowTotal(int rowIndex)
        {
            var row = dg_costs.Rows[rowIndex];

            decimal amount = 0;
            decimal multiplier = 0;

            decimal.TryParse(row.Cells[nameof(DeliveryReceiptCostModel.costs_amount)].Value?.ToString(), out amount);
            decimal.TryParse(row.Cells[nameof(DeliveryReceiptCostModel.costs_multiplier)].Value?.ToString(), out multiplier);

            decimal total = amount * multiplier;

            row.Cells[nameof(DeliveryReceiptCostModel.costs_total_cost)].Value = total;

            if (_costRows != null && rowIndex < _costRows.Count)
            {
                _costRows[rowIndex].costs_total_cost = total;
            }
        }
        private void SetupGridFormat()
        {
            // visibility
            dg_items.Columns[nameof(DeliveryReceiptItemModel.items_id)].Visible = false;
            dg_items.Columns[nameof(DeliveryReceiptItemModel.items_delivery_receipt_id)].Visible = false;
            dg_items.Columns[nameof(DeliveryReceiptItemModel.items_item_id)].Visible = false;

            dg_costs.Columns[nameof(DeliveryReceiptCostModel.costs_id)].Visible = false;
            dg_costs.Columns[nameof(DeliveryReceiptCostModel.costs_delivery_receipt_id)].Visible = false;

            // format
            dg_costs.Columns[nameof(DeliveryReceiptCostModel.costs_amount)].DefaultCellStyle.Format = "C2";
            dg_costs.Columns[nameof(DeliveryReceiptCostModel.costs_total_cost)].DefaultCellStyle.Format = "C2";
            dg_costs.Columns[nameof(DeliveryReceiptCostModel.costs_total_cost)].ReadOnly = true;
        }

        private void dg_costs_UserDeletingRow(object sender, DataGridViewRowCancelEventArgs e)
        {
            var result = MessageBox.Show( "Are you sure you want to delete this cost?","Confirm Delete",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Warning);

            if (result == DialogResult.No)
            {
                e.Cancel = true;
                return;
            }

            int rowIndex = e.Row.Index;

            if (_costRows != null && rowIndex < _costRows.Count)
            {
                _costRows.RemoveAt(rowIndex);
            }


            ComputeGrandTotal();
        }
        private void ComputeGrandTotal()
        {
            decimal total = _costRows.Sum(x => x.costs_total_cost);
            txt_total_cost.Text = total.ToString("C2");
        }

        private void btn_print_Click(object sender, EventArgs e)
        {
            if(_currentIndex < 0 || _deliveryReceipts == null) return;

            var current = _deliveryReceipts[_currentIndex];

            // Header — single DR record as a list
            var headerSource = new List<DeliveryReceiptModel> { current };

            // Details — items and already loaded in the current record
            var itemsSource = current.delivery_receipt_items
                ?? new List<DeliveryReceiptItemModel>();

            _printService.Show(ReportPath.DeliveryReceipt, new List<ReportDataSource>
            {
                new ReportDataSource("DataSet1", headerSource),
                new ReportDataSource("DataSet2", itemsSource),
            });
        }
    }
}
