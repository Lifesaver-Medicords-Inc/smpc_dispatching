using smpc_dispatching.Core.Helpers;
using smpc_dispatching.Core.Models;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace smpc_dispatching.UI.Views.Delivery_Receipt
{
    // One released line, paired with how much of it earlier delivery receipts have
    // already taken. The caller computes AlreadyDelivered - this modal only presents
    // it and enforces the remaining ceiling.
    public class DeliveryReceiptPickerRow
    {
        public ItemReleaseDetailsModel Item { get; set; }
        public uint AlreadyDelivered { get; set; }

        public uint ReleasedQty => Item?.released_qty ?? 0u;
        public uint Remaining => ReleasedQty > AlreadyDelivered ? ReleasedQty - AlreadyDelivered : 0u;
    }

    // User decision, 2026-09-03: a released Item Release may cover more than one
    // truckload - previously the reference-doc handler dumped every released item
    // straight onto dg_items with no selection step, forcing a single DR to cover the
    // whole release even when part of it doesn't fit and the rest needs to go out on a
    // later DR. This lets the user pick which released items go on THIS delivery
    // receipt, and how many of each.
    //
    // User decision, 2026-09-03 (second pass): the earlier version re-offered the full
    // released list on every DR, so a line already delivered on DR-001 could be picked
    // again on DR-002 and double-count against the SO's RELEASED qty (the same failure
    // §14.9 guards against for RR-vs-PO, which the spec never wrote down for the DR).
    // The caller now passes what earlier receipts already took; a line is offered only
    // for its REMAINING quantity, and drops off the list entirely once that reaches 0.
    public partial class DeliveryReceiptItemPickerModal : Form
    {
        private readonly List<DeliveryReceiptPickerRow> _rows;

        public DeliveryReceiptItemPickerModal(List<DeliveryReceiptPickerRow> rows)
        {
            InitializeComponent();
            _rows = rows ?? new List<DeliveryReceiptPickerRow>();

            StyleGrid();
            LoadRows();

            btn_select_all.Click += (s, e) => SetAll(true);
            btn_clear_all.Click += (s, e) => SetAll(false);
            btn_ok.Click += btn_ok_Click;
            btn_cancel.Click += (s, e) => { DialogResult = DialogResult.Cancel; Close(); };

            // Re-validate as the user types rather than only on OK, so the red cell
            // appears where the mistake is instead of in a dialog after the fact.
            dgv_items.CellValueChanged += (s, e) =>
            {
                if (e.RowIndex >= 0 && dgv_items.Columns[e.ColumnIndex].Name == "col_qty")
                    PaintQtyCell(dgv_items.Rows[e.RowIndex]);
            };
            // Without this a checkbox edit isn't committed until the cell loses focus,
            // so SELECT ALL / OK can read a stale value.
            dgv_items.CurrentCellDirtyStateChanged += (s, e) =>
            {
                if (dgv_items.IsCurrentCellDirty)
                    dgv_items.CommitEdit(DataGridViewDataErrorContexts.Commit);
            };
        }

        // §1.4: headers centre-aligned and bold, descriptions left-indented,
        // single values centre-aligned.
        private void StyleGrid()
        {
            dgv_items.EnableHeadersVisualStyles = false;
            dgv_items.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgv_items.ColumnHeadersDefaultCellStyle.Font =
                new Font(dgv_items.Font, FontStyle.Bold);
            dgv_items.ColumnHeadersDefaultCellStyle.WrapMode = DataGridViewTriState.True;

            foreach (DataGridViewColumn col in dgv_items.Columns)
                col.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

            dgv_items.Columns["col_item_description"].DefaultCellStyle.Alignment =
                DataGridViewContentAlignment.MiddleLeft;
            dgv_items.Columns["col_item_description"].DefaultCellStyle.Padding =
                new Padding(6, 0, 0, 0);
            dgv_items.Columns["col_item_description"].DefaultCellStyle.WrapMode =
                DataGridViewTriState.True;
            dgv_items.Columns["col_serial_no"].DefaultCellStyle.WrapMode =
                DataGridViewTriState.True;
        }

        private void LoadRows()
        {
            dgv_items.Rows.Clear();
            foreach (var row in _rows)
            {
                if (row?.Item == null) continue;
                // Fully delivered by earlier receipts - nothing left to put on this one.
                if (row.Remaining == 0) continue;

                int rowIndex = dgv_items.Rows.Add();
                var gridRow = dgv_items.Rows[rowIndex];

                // Defaults to checked at the full remaining quantity - the common case is
                // "deliver whatever is left", while still letting the user cut it down to
                // what actually fits on this truck.
                gridRow.Cells["col_select"].Value = true;
                gridRow.Cells["col_item_code"].Value = row.Item.item_code;
                gridRow.Cells["col_item_description"].Value = row.Item.item_description;
                gridRow.Cells["col_released"].Value = row.ReleasedQty;
                gridRow.Cells["col_delivered"].Value = row.AlreadyDelivered;
                gridRow.Cells["col_remaining"].Value = row.Remaining;
                gridRow.Cells["col_qty"].Value = row.Remaining;
                gridRow.Cells["col_uom"].Value = row.Item.released_uom;
                gridRow.Cells["col_serial_no"].Value = row.Item.serial_no;
                gridRow.Tag = row;
            }
        }

        private void SetAll(bool value)
        {
            foreach (DataGridViewRow row in dgv_items.Rows)
            {
                row.Cells["col_select"].Value = value;
                PaintQtyCell(row);
            }
        }

        private static bool IsChecked(DataGridViewRow row)
            => row.Cells["col_select"].Value is bool b && b;

        // Returns 0 when the cell is blank or not a number, which TryGetQty below
        // treats as invalid for a checked row.
        private static uint ReadQty(DataGridViewRow row)
        {
            var raw = row.Cells["col_qty"].Value?.ToString();
            return uint.TryParse(raw, out uint qty) ? qty : 0u;
        }

        private static bool IsRowValid(DataGridViewRow row)
        {
            if (!IsChecked(row)) return true;              // unchecked rows aren't validated
            if (!(row.Tag is DeliveryReceiptPickerRow src)) return false;

            uint qty = ReadQty(row);
            return qty > 0 && qty <= src.Remaining;
        }

        // §1.4: red is the invalid-input colour.
        private void PaintQtyCell(DataGridViewRow row)
        {
            var cell = row.Cells["col_qty"];
            bool ok = IsRowValid(row);
            cell.Style.BackColor = ok ? Color.Empty : Color.FromArgb(255, 205, 205);
            cell.Style.ForeColor = ok ? Color.Empty : Color.FromArgb(140, 0, 0);
        }

        public List<ItemReleaseDetailsModel> GetSelectedItems()
        {
            var result = new List<ItemReleaseDetailsModel>();
            foreach (DataGridViewRow row in dgv_items.Rows)
            {
                if (!IsChecked(row)) continue;
                if (!(row.Tag is DeliveryReceiptPickerRow src)) continue;

                var item = src.Item;
                // Copy rather than mutate: released_qty carries the quantity for THIS
                // receipt, and the source row still has to report what the release
                // actually held if the picker is reopened.
                result.Add(new ItemReleaseDetailsModel
                {
                    id = item.id,
                    item_release_id = item.item_release_id,
                    sales_order_id = item.sales_order_id,
                    sales_order_details_id = item.sales_order_details_id,
                    item_id = item.item_id,
                    item_code = item.item_code,
                    item_description = item.item_description,
                    required_qty = item.required_qty,
                    required_uom = item.required_uom,
                    released_qty = ReadQty(row),
                    released_uom = item.released_uom,
                    serial_no = item.serial_no,
                    delivery_preference = item.delivery_preference,
                });
            }
            return result;
        }

        private void btn_ok_Click(object sender, System.EventArgs e)
        {
            dgv_items.EndEdit();

            var invalid = new List<string>();
            int checkedCount = 0;

            foreach (DataGridViewRow row in dgv_items.Rows)
            {
                PaintQtyCell(row);
                if (!IsChecked(row)) continue;
                checkedCount++;

                if (!IsRowValid(row) && row.Tag is DeliveryReceiptPickerRow src)
                    invalid.Add($"{src.Item.item_code} — enter 1 to {src.Remaining}");
            }

            if (checkedCount == 0)
            {
                Helpers.ShowDialogMessage("error", "Select at least one item for this delivery receipt.");
                return;
            }

            if (invalid.Count > 0)
            {
                Helpers.ShowDialogMessage("error",
                    "DELIVER NOW must be between 1 and the remaining quantity:\n\n" +
                    string.Join("\n", invalid));
                return;
            }

            DialogResult = DialogResult.OK;
            Close();
        }
    }
}
