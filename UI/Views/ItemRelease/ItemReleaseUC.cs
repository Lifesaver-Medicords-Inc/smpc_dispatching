using Microsoft.Extensions.DependencyInjection;
using Serilog;
using smpc_dispatching.Core.Models;
using smpc_dispatching.Core.Interfaces;
using smpc_dispatching.UI.Views.ItemRelease.ItemReleaseModals;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Windows.Forms;
using smpc_dispatching.Core.Enum;
using smpc_dispatching.Core.Helpers;
using System.Threading.Tasks;

namespace smpc_dispatching.UI.Views.ItemRelease
{
    public partial class ItemReleaseUC : UserControl
    {
        private readonly ISalesOrderIRViewService<SalesOrderViewModel> _salesOrderIRViewService;
        private readonly IItemReleaseService _itemReleaseService;
        private readonly IServiceProvider _serviceProvider;

        private BindingList<ItemReleaseDetailsModel> _detailsBinding;
        private List<ItemReleaseModel> _itemReleases;
        private DataTable _soTable;
        private Panel[] _pnls;
        private string _userName;
        private bool _isWarehouseUser;
        private int _currentIRIndex = 0;
        private int _previousIRIndex = -1;
        private bool hasError = false;

        private enum IRMode { Create, View, Edit }
        private IRMode _mode;

        private bool _isNewMode => _mode == IRMode.Create;
        private bool _isEditMode => _mode == IRMode.Edit;
        private bool _isViewMode => _mode == IRMode.View;

        private static class DetailsDGV
        {
            public const string Id = "id";
            public const string ItemReleaseId = "item_release_id";
            public const string ItemId = "item_id";
            public const string SalesOrderId = "sales_order_id";
            public const string SalesOrderDetailsId = "sales_order_details_id";
            public const string ItemDescription = "item_description";
            public const string OrderQty = "order_qty";
            public const string RequiredQty = "required_qty";
            public const string RequiredUom = "required_uom";
            public const string ReleasedQty = "released_qty";
            public const string ReleasedUom = "released_uom";
            public const string SerialNo = "serial_no";
            public const string DeliveryPreference = "delivery_preference";
            public const string BinLocation = "bin_location";
        }

        public ItemReleaseUC(IServiceProvider serviceProvider)
        {
            InitializeComponent();

            _serviceProvider = serviceProvider;
            _itemReleaseService = serviceProvider.GetRequiredService<IItemReleaseService>();
            _salesOrderIRViewService = serviceProvider.GetRequiredService<ISalesOrderIRViewService<SalesOrderViewModel>>();

            _pnls = new[] { pnl_header, pnl_footer };
            dgv_details.AutoGenerateColumns = false;
            dgv_details.AllowUserToAddRows = true;

            _isWarehouseUser = CacheData.CurrentUser.department.ToLower() == "warehouse";  
            _userName = CacheData.CurrentUser.first_name + " " + CacheData.CurrentUser.last_name;
            btn_new.Visible = !_isWarehouseUser;
            btn_cancel_request.Visible = !_isWarehouseUser;
            chk_is_forward.Visible = false;

            Helpers.SetControlsReadOnly(new Control[]
            {
                txt_requested_by,
                txt_approved_by,
                txt_issued_by,
            }, true);

            // If warehouse user, allow editing of txt_received_by
            txt_received_by.ReadOnly = !_isWarehouseUser;
        }

        private async void ItemReleaseUC_Load(object sender, EventArgs e)
        {
            
            try
            {
                SetMode(IRMode.View);
                await LoadSalesOrder();
                await LoadItemReleases();
            }
            catch (Exception ex)
            {
                Helpers.ShowDialogMessage("error", $"Failed to load: {ex.Message}");
            }
            finally
            {
                Helpers.Loading.HideLoading(dgv_details);
            }
        }

        #region Load Item Releases & Bind
        private async Task LoadItemReleases()
        {
            var response = await _itemReleaseService.GetAllAsync(null);
            _itemReleases = response?.Data?.ToList() ?? new List<ItemReleaseModel>();

            // Filter for warehouse users (only parents where is_forward is true)
            if (_isWarehouseUser)
            {
                _itemReleases = _itemReleases
                    .Where(x => x.is_forward.HasValue && x.is_forward.Value)
                    .ToList();
            }

            if (_itemReleases.Count == 0)
            {
                dgv_details.DataSource = null;
                _currentIRIndex = -1;
                return;
            }

            _currentIRIndex = 0;
            BindItemRelease(_currentIRIndex);
        }

        private void BindItemRelease(int index)
        {
            if (_itemReleases == null || index < 0 || index >= _itemReleases.Count)
            {
                dgv_details.DataSource = null;
                btn_forward.Visible = false;
                btn_cancel_request.Visible = false;
                return;
            }

            var current = _itemReleases[index];

            // Bind parent fields to panels
            Helpers.BindHelpers.BindParentToPanels(current, _pnls, "IREL#");

            if (current.is_forward == true)
            {
                btn_forward.Visible = false;
                btn_cancel_request.Visible = true;
            }

            // Bind child details to DataGridView
            _detailsBinding = new BindingList<ItemReleaseDetailsModel>(
                current.item_release_details ?? new List<ItemReleaseDetailsModel>()
            );
            dgv_details.DataSource = _detailsBinding;

            // Toggle button visibility: if is_forward is true, show btn_cancel, hide btn_forward; otherwise vice versa
            // Compute button visibility in one place
            bool showButtons = !_isWarehouseUser;
            btn_forward.Visible = showButtons && !(current.is_forward ?? false);
            btn_cancel_request.Visible = showButtons && (current.is_forward ?? false);

            
        }
        #endregion

        #region Load Sales Orders
        private async Task LoadSalesOrder()
        {
            var response = await _salesOrderIRViewService.GetAllAsync(null);
            if (response?.Data == null) return;

            _soTable = Helpers.ToDataTable(response.Data.ToList());

            var uniqueDocs = _soTable.AsEnumerable()
                .Select(r => r.Field<string>("ref_doc_no"))
                .Where(d => !string.IsNullOrWhiteSpace(d))
                .Distinct()
                .OrderBy(d => d)
                .ToList();

            cmb_reference_doc_no.DataSource = uniqueDocs;
            cmb_reference_doc_no.SelectedIndex = -1;
        }

        private void cmb_ReferenceDocNo_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmb_reference_doc_no.SelectedIndex < 0 || _soTable == null)
            {
                dgv_details.DataSource = null;
                return;
            }

            string selectedDoc = cmb_reference_doc_no.SelectedItem.ToString();

            var filteredRows = _soTable.AsEnumerable()
                .Where(r => r.Field<string>("ref_doc_no") == selectedDoc)
                .ToList();

            if (!filteredRows.Any())
            {
                dgv_details.DataSource = null;
                return;
            }

            _detailsBinding = GetDetailsFromDataTable(filteredRows);
            dgv_details.DataSource = _detailsBinding;
            
        }

        private BindingList<ItemReleaseDetailsModel> GetDetailsFromDataTable(IEnumerable<DataRow> rows)
        {
            var list = new BindingList<ItemReleaseDetailsModel>();
            foreach (var r in rows)
            {
                list.Add(new ItemReleaseDetailsModel
                {
                    sales_order_id = Convert.ToUInt32(r["sales_order_id"]),
                    sales_order_details_id = Convert.ToUInt32(r["sales_order_details_id"]),
                    item_id = Convert.ToUInt32(r["item_id"]),
                    item_description = r["item_description"]?.ToString() ?? string.Empty,
                    required_qty = Convert.ToUInt32(r["required_qty"] ?? 0),
                    required_uom = r["required_uom"]?.ToString() ?? string.Empty,
                    released_qty = 0,
                    released_uom = string.Empty,
                    serial_no = string.Empty,
                    delivery_preference = string.Empty
                });
            }
            return list;
        }
        #endregion

        #region CellClick Add/Replace
        private void dgv_details_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0 || e.ColumnIndex < 0)
                return;

            if (!_isNewMode && !_isEditMode)
                return;

            // ────── Handle ReleasedQty click ──────
            if (_isWarehouseUser && dgv_details.Columns[e.ColumnIndex].Name == DetailsDGV.ReleasedQty)
            {
                var row = dgv_details.Rows[e.RowIndex];
                int itemId = Convert.ToInt32(row.Cells[DetailsDGV.ItemId].Value);

                // Get previously released qty for this row
                decimal alreadyReleased = Convert.ToDecimal(row.Cells[DetailsDGV.ReleasedQty].Value ?? 0);

                // Build allocated per-bin from current details grid
                var allocatedPerBin = new Dictionary<string, decimal>();
                foreach (DataGridViewRow r in dgv_details.Rows)
                {
                    int rItemId = Convert.ToInt32(r.Cells[DetailsDGV.ItemId].Value);
                    if (rItemId != itemId) continue;

                    string bin = r.Cells[DetailsDGV.BinLocation]?.Value?.ToString();
                    if (string.IsNullOrEmpty(bin)) continue;

                    decimal released = Convert.ToDecimal(r.Cells[DetailsDGV.ReleasedQty].Value ?? 0);
                    allocatedPerBin[$"{rItemId}_{bin}"] = released;
                }

                using (var modal = new PickActivity(_serviceProvider, itemId, alreadyReleased, allocatedPerBin))
                {
                    if (modal.ShowDialog(this) != DialogResult.OK)
                        return;

                    // Update main row total
                    row.Cells[DetailsDGV.ReleasedQty].Value = modal.IssuedQty;
                    row.Cells[DetailsDGV.ReleasedUom].Value = modal.IssuedUom;

                    // Update per-bin values back into the grid
                    foreach (var kvp in modal.IssuedPerBin) // Dictionary<string, decimal>
                    {
                        string binKey = kvp.Key; // format: "itemId_binLocation"
                        decimal issuedQty = kvp.Value;

                        foreach (DataGridViewRow r in dgv_details.Rows)
                        {
                            int rItemId = Convert.ToInt32(r.Cells[DetailsDGV.ItemId].Value);
                            string rBin = r.Cells[DetailsDGV.BinLocation]?.Value?.ToString();
                            if (rItemId == itemId && $"{rItemId}_{rBin}" == binKey)
                                r.Cells[DetailsDGV.ReleasedQty].Value = issuedQty;
                        }
                    }

                    dgv_details.EndEdit();
                }
            }

            // ────── Handle ItemDescription click ──────
            if (!_isWarehouseUser && dgv_details.Columns[e.ColumnIndex].Name == DetailsDGV.ItemDescription)
            {
                dgv_details.EndEdit();

                if (cmb_reference_doc_no.SelectedIndex == -1)
                {
                    Helpers.ShowDialogMessage("error", "Reference Doc No is required.");
                    return;
                }

                using (var modal = new ItemReleaseItems(_serviceProvider))
                {
                    if (modal.ShowDialog(this) != DialogResult.OK) return;
                    var selectedItem = modal.SelectedItem;
                    if (selectedItem == null) return;

                    var line = _detailsBinding[e.RowIndex];
                    line.item_id = selectedItem.item_id;
                    line.item_description = selectedItem.short_desc;
                    line.required_qty = 0;
                    line.required_uom = selectedItem.uom_name;

                    dgv_details.InvalidateRow(e.RowIndex);

                    // Move focus to 'required_qty' column
                    int colIndex = dgv_details.Columns[DetailsDGV.RequiredQty].Index;
                    dgv_details.CurrentCell = dgv_details.Rows[e.RowIndex].Cells[colIndex];
                    dgv_details.BeginEdit(true);
                }
            }
        }
        #endregion

        #region Save
        private async void btn_save_Click(object sender, EventArgs e)
        {
            btn_save.Enabled = false;                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                          

            try
            {
                if (!await ValidateInput(_pnls)) return;

                dgv_details.EndEdit();

                var parentData = Helpers.BuildModelFromPanels<ItemReleaseModel>(_pnls);
                var childData = _detailsBinding?.Where(d => d.item_id != 0).ToList();

                if (cmb_reference_doc_no.SelectedItem == null || parentData == null || childData == null || !childData.Any())
                {
                    Helpers.ShowDialogMessage("error", "Please select Reference Doc No or at least one item.");
                    return;
                }

                parentData.item_release_details = childData;

                bool isNew = string.IsNullOrWhiteSpace(txt_id.Text);

                if (isNew)
                {
                    parentData.is_forward = false;
                    var response = await _itemReleaseService.CreateAsync(parentData);
                    if (!response.Success)
                    {
                        Helpers.ShowDialogMessage("error", "Item Release saving failed.");
                        return;
                    }
                }
                

                if (!isNew)
                {
                    if (_isWarehouseUser)
                    {
                        if (string.IsNullOrWhiteSpace(txt_received_by.Text))
                        {
                            Helpers.ShowDialogMessage("error", "Receiver name required.");
                            return;
                        }
                    }

                    parentData.id = uint.Parse(txt_id.Text);
                    // ✅ explicitly set is_forward
                    parentData.is_forward = btn_forward.Visible; // or true/false based on your logic

                    var response = await _itemReleaseService.UpdateAsync(parentData);
                    if (!response.Success)
                    {
                        Helpers.ShowDialogMessage("error", "Item Release saving failed.");
                        return;
                    }
                }

                Helpers.ShowDialogMessage("success", "Item Release saved successfully.");

                SetMode(IRMode.View);
                await LoadItemReleases();

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
        #endregion

        #region New Mode
        private void btn_new_Click(object sender, EventArgs e)
        {
            SetMode(IRMode.Create);

            btn_cancel_request.Visible = false;
            btn_forward.Visible = true;

            Helpers.ResetControls(_pnls);

            _detailsBinding = new BindingList<ItemReleaseDetailsModel>();
            dgv_details.DataSource = _detailsBinding;

            SetUserInfo();
        }

        private void SetUserInfo()
        {
            if (_isWarehouseUser)
            {
                txt_approved_by.Text = _userName;
                txt_issued_by.Text = _userName;
            }
            else
            {
                txt_requested_by.Text = _userName;
            }
        }
        #endregion

        private void SetMode(IRMode mode)
        {
            try
            {
                _mode = mode;
                bool canEdit = _isNewMode || _isEditMode;

                

                // DataGridView
                SetEditableColumns(canEdit);
                dgv_details.AllowUserToAddRows = canEdit && !_isWarehouseUser;

                // Buttons
                btn_forward.Enabled = !canEdit;
                btn_cancel_request.Enabled = !canEdit;

                // ToolStrip
                SetToolStripButtons(canEdit);

                // Role-based visibility
                btn_new.Visible = !_isWarehouseUser && !canEdit;
                btn_cancel_request.Visible = !_isWarehouseUser;
                btn_forward.Visible = !_isWarehouseUser;

                // Navigation buttons (optional)
                //SetNavigationButtons(canEdit);

                if (canEdit)
                {
                    SetUserInfo();
                    _previousIRIndex = _currentIRIndex;
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
                    : new[] { "btn_prev", "btn_next", "btn_search", "btn_edit", "btn_delete" },
                hiddenButtons: canEdit
                    ? new[] { "btn_prev", "btn_next", "btn_search", "btn_edit", "btn_delete" }
                    : new[] { "btn_save", "btn_close" }
            );
        }

        private void SetEditableColumns(bool isEdit)
        {
            var editableColumns = !_isWarehouseUser
                ? new[] { DetailsDGV.RequiredQty, DetailsDGV.DeliveryPreference }
                : new[] { DetailsDGV.SerialNo, DetailsDGV.ReleasedQty };

            foreach (var colName in editableColumns)
            {
                if (dgv_details.Columns.Contains(colName))
                    dgv_details.Columns[colName].ReadOnly = !isEdit;
            }
        }

        private async Task<bool> ValidateInput(Panel[] pnls)
        {
            hasError = false;

            foreach (var pnl in pnls)
            {
                if (Helpers.ValidateControlsValues(pnl))
                {
                    hasError = true;
                    break;
                }
            }

            if (hasError)
            {
                Helpers.ShowDialogMessage("error", "Please fill in all required fields");
                btn_save.Enabled = true;
                return false;
            }

            if (dtp_released_date.Value.Date > DateTime.Now.Date)
            {
                Helpers.ShowDialogMessage("error", "Issue Date cannot be later than today.");
                dtp_released_date.Focus();
                return false;
            }

            if (dtp_required_date.Value.Date > DateTime.Now.Date)
            {
                Helpers.ShowDialogMessage("error", "Required Date cannot be later than today.");
                dtp_required_date.Focus();
                return false;
            }

            string[] columnsToValidate = new[] {DetailsDGV.RequiredQty};
            bool dgvHasErrors = await Helpers.ValidateDataGridViewCells(dgv_details, columnsToValidate);

            return !dgvHasErrors;
        }

        private void ChangeRecord(int step)
        {
            if (_itemReleases == null || !_itemReleases.Any())
                return;

            int newIndex = _currentIRIndex + step;
            if (newIndex < 0 || newIndex >= _itemReleases.Count)
                return;

            _currentIRIndex = newIndex;
            BindItemRelease(_currentIRIndex);

            btn_prev.Enabled = _currentIRIndex > 0;
            btn_next.Enabled = _currentIRIndex < _itemReleases.Count - 1;
        }

        private async void btn_close_Click(object sender, EventArgs e)
        {
            SetMode(IRMode.View);
            cmb_reference_doc_no.DropDownStyle = ComboBoxStyle.DropDown;

            if (_previousIRIndex >= 0 && _itemReleases != null && _itemReleases.Count > 0)
            {
                await LoadItemReleases();
            }
        }

        private void btn_prev_Click(object sender, EventArgs e) => ChangeRecord(-1);
        private void btn_next_Click(object sender, EventArgs e) => ChangeRecord(1);
        private void btn_edit_Click(object sender, EventArgs e) => SetMode(IRMode.Edit);
        private async Task ForwardRequestAsync()
        {
            try
            {
                if (!uint.TryParse(txt_id.Text, out uint id))
                {
                    Helpers.ShowDialogMessage("error", "No Item Release selected.");
                    return;
                }

                bool isForward = chk_is_forward.Checked;

                var forwardData = new ItemReleaseModel
                {
                    id = id,
                    is_forward = isForward
                };

                var response = await _itemReleaseService.UpdateAsync(forwardData);

                if (response == null)
                {
                    Helpers.ShowDialogMessage("error", "No response from server.");
                    return;
                }

                if (!response.Success)
                {
                    Helpers.ShowDialogMessage(
                        "error",
                        response.Message ?? "Item Release update failed."
                    );
                    return;
                }

                Helpers.ShowDialogMessage(
                    "success",
                    isForward
                        ? "Item Release forwarded successfully."
                        : "Item Release canceled successfully."
                );

                // Refresh view
                SetMode(IRMode.View);
                await LoadItemReleases();
            }
            catch (Exception ex)
            {
                Helpers.ShowDialogMessage("error", ex.Message);
            }
        }

        private async void btn_forward_Click(object sender, EventArgs e)
        {
            chk_is_forward.Checked = true;
            await ForwardRequestAsync();
        }

        private async void btn_cancel_Click(object sender, EventArgs e)
        {
            chk_is_forward.Checked = false;
            await ForwardRequestAsync();
        }
    }
}