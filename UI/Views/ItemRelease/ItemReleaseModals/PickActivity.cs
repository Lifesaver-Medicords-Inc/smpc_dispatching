using Microsoft.Extensions.DependencyInjection;
using smpc_dispatching.Core.Helpers;
using smpc_dispatching.Core.Interfaces;
using smpc_dispatching.Core.Models;
using System;
using System.Data;
using System.Linq;
using System.Drawing;
using System.Windows.Forms;
using System.Collections.Generic;

namespace smpc_dispatching.UI.Views.ItemRelease.ItemReleaseModals
{
    public partial class PickActivity : Form
    {
        // 🔹 Returned values
        public decimal IssuedQty { get; private set; }
        public string IssuedUom { get; private set; }
        public Dictionary<string, decimal> IssuedPerBin { get; private set; } = new Dictionary<string, decimal>();

        private readonly int _itemId;
        private readonly IItemStockAndLocationService<ItemStockAndLocationModel> _service;
        private DataTable _itemTable;
        private decimal _alreadyIssuedQty;

        // Tracks remaining stock per bin
        private class BinStock
        {
            public decimal Remaining { get; set; }
            public decimal Issued { get; set; }
        }
        private readonly Dictionary<string, BinStock> _remainingStock = new Dictionary<string, BinStock>();

        private static class DgvCol
        {
            public const string IssuedQty = "issued_qty";
            public const string IssuedUom = "issued_uom";
            public const string StockQty = "stock_qty";
            public const string StockUom = "stock_uom";
            public const string BinLocation = "bin_location";
        }

        public PickActivity(IServiceProvider serviceProvider, int itemId, decimal alreadyIssuedQty = 0, Dictionary<string, decimal> alreadyIssuedPerBin = null)
        {
            InitializeComponent();

            _itemId = itemId;
            _service = serviceProvider.GetRequiredService<IItemStockAndLocationService<ItemStockAndLocationModel>>();
            _alreadyIssuedQty = alreadyIssuedQty;

            // Initialize already issued stock per bin
            if (alreadyIssuedPerBin != null)
            {
                foreach (var kvp in alreadyIssuedPerBin)
                    _remainingStock[kvp.Key] = new BinStock { Remaining = 0, Issued = kvp.Value };
            }

            dgv_item.AllowUserToAddRows = false;
            dgv_item.AutoGenerateColumns = false;
            dgv_item.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.EnableResizing;
            dgv_item.ColumnHeadersHeight = 50;

            dgv_item.Paint += dgv_item_Paint;
            dgv_item.CellPainting += dgv_item_CellPainting;
            dgv_item.CellBeginEdit += dgv_item_CellBeginEdit;
            dgv_item.CellEndEdit += dgv_item_CellEndEdit;
        }

        private async void PickActivity_Load(object sender, EventArgs e)
        {
            try
            {
                Helpers.Loading.ShowLoading(dgv_item, "Fetching data...");

                var response = await _service.GetAsync(_itemId);
                if (response?.Data == null || !response.Data.Any())
                {
                    Helpers.ShowDialogMessage("error", "No stock found.");
                    this.DialogResult = DialogResult.Cancel;
                    this.Close();
                    return;
                }

                // Convert model list to DataTable
                _itemTable = Helpers.ToDataTable(response.Data.ToList());

                // Add UI-only columns for issued quantity
                if (!_itemTable.Columns.Contains(DgvCol.IssuedQty))
                    _itemTable.Columns.Add(DgvCol.IssuedQty, typeof(decimal));
                if (!_itemTable.Columns.Contains(DgvCol.IssuedUom))
                    _itemTable.Columns.Add(DgvCol.IssuedUom, typeof(string));

                // Initialize issued quantity and UOM
                foreach (DataRow row in _itemTable.Rows)
                {
                    row[DgvCol.IssuedQty] = 0m;
                    row[DgvCol.IssuedUom] = row[DgvCol.StockUom]?.ToString() ?? "";
                }

                InitializeRemainingStock();
                SetupColumns();

                dgv_item.DataSource = _itemTable;
            }
            catch (Exception ex)
            {
                Helpers.ShowDialogMessage("error", ex.Message);
            }
            finally
            {
                Helpers.Loading.HideLoading(dgv_item);
            }
        }

        private void InitializeRemainingStock()
        {
            foreach (DataRow row in _itemTable.Rows)
            {
                string bin = row[DgvCol.BinLocation]?.ToString() ?? "";
                decimal stock = Convert.ToDecimal(row[DgvCol.StockQty]);

                if (!_remainingStock.ContainsKey(bin))
                    _remainingStock[bin] = new BinStock { Remaining = stock, Issued = 0 };
                else
                    _remainingStock[bin].Remaining = stock - _remainingStock[bin].Issued;

                // Fill back issued qty
                row[DgvCol.IssuedQty] = _remainingStock[bin].Issued;
                row[DgvCol.StockQty] = Math.Max(0, _remainingStock[bin].Remaining);
            }
        }

        private void SetupColumns()
        {
            dgv_item.Columns.Clear();

            dgv_item.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = DgvCol.IssuedQty,
                HeaderText = "QTY",
                DataPropertyName = DgvCol.IssuedQty
            });

            dgv_item.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = DgvCol.IssuedUom,
                HeaderText = "UOM",
                DataPropertyName = DgvCol.StockUom,
                ReadOnly = true
            });

            dgv_item.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = DgvCol.StockQty,
                HeaderText = "QTY",
                DataPropertyName = DgvCol.StockQty,
                ReadOnly = true
            });

            dgv_item.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = DgvCol.StockUom,
                HeaderText = "UOM",
                DataPropertyName = DgvCol.StockUom,
                ReadOnly = true
            });

            dgv_item.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = DgvCol.BinLocation,
                HeaderText = "BIN LOCATION",
                DataPropertyName = DgvCol.BinLocation,
                ReadOnly = true,
                AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
            });
        }

        private void dgv_item_Paint(object sender, PaintEventArgs e)
        {
            DrawGroupHeader(e, 0, 1, "QTY TO RELEASE");
            DrawGroupHeader(e, 2, 3, "QTY AVAILABLE");
        }

        private void DrawGroupHeader(PaintEventArgs e, int startCol, int endCol, string text)
        {
            if (dgv_item.Columns.Count <= Math.Max(startCol, endCol)) return;

            Rectangle r1 = dgv_item.GetCellDisplayRectangle(startCol, -1, true);
            Rectangle r2 = dgv_item.GetCellDisplayRectangle(endCol, -1, true);
            Rectangle rect = new Rectangle(r1.X, r1.Y, r1.Width + r2.Width, dgv_item.ColumnHeadersHeight / 2);

            using (Brush b = new SolidBrush(dgv_item.ColumnHeadersDefaultCellStyle.BackColor))
            using (Pen p = new Pen(dgv_item.GridColor))
            {
                e.Graphics.FillRectangle(b, rect);
                e.Graphics.DrawRectangle(p, rect);
                TextRenderer.DrawText(
                    e.Graphics,
                    text,
                    dgv_item.ColumnHeadersDefaultCellStyle.Font,
                    rect,
                    dgv_item.ColumnHeadersDefaultCellStyle.ForeColor,
                    TextFormatFlags.HorizontalCenter | TextFormatFlags.VerticalCenter
                );
            }
        }

        private void dgv_item_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {
            if (e.RowIndex == -1 && e.ColumnIndex >= 0)
            {
                e.PaintBackground(e.CellBounds, false);

                Rectangle lower = e.CellBounds;
                lower.Y += dgv_item.ColumnHeadersHeight / 2;
                lower.Height /= 2;

                TextRenderer.DrawText(
                    e.Graphics,
                    e.FormattedValue?.ToString(),
                    e.CellStyle.Font,
                    lower,
                    e.CellStyle.ForeColor,
                    TextFormatFlags.HorizontalCenter | TextFormatFlags.VerticalCenter
                );

                e.Handled = true;
            }
        }

        private void dgv_item_CellBeginEdit(object sender, DataGridViewCellCancelEventArgs e)
        {
            var issuedCol = dgv_item.Columns.Cast<DataGridViewColumn>().FirstOrDefault(c => c.Name == DgvCol.IssuedQty);
            if (issuedCol == null || e.ColumnIndex != issuedCol.Index) return;

            dgv_item.Rows[e.RowIndex].Tag = Convert.ToDecimal(dgv_item.Rows[e.RowIndex].Cells[issuedCol.Index].Value ?? 0);
        }

        private void dgv_item_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            var issuedCol = dgv_item.Columns.Cast<DataGridViewColumn>().FirstOrDefault(c => c.Name == DgvCol.IssuedQty);
            var binCol = dgv_item.Columns.Cast<DataGridViewColumn>().FirstOrDefault(c => c.Name == DgvCol.BinLocation);

            if (issuedCol == null || binCol == null || e.ColumnIndex != issuedCol.Index) return;

            var row = dgv_item.Rows[e.RowIndex];
            string bin = row.Cells[binCol.Index].Value?.ToString() ?? "";
            if (!_remainingStock.ContainsKey(bin)) return;

            decimal oldIssued = Convert.ToDecimal(row.Tag ?? 0);
            decimal newIssued = Convert.ToDecimal(row.Cells[issuedCol.Index].Value ?? 0);

            // Restore previous issued qty
            _remainingStock[bin].Remaining += oldIssued;
            _remainingStock[bin].Issued -= oldIssued;

            // Clamp new issued qty
            if (newIssued > _remainingStock[bin].Remaining)
            {
                Helpers.ShowDialogMessage("error", "Issued quantity cannot exceed available stock.");
                newIssued = 0;
                row.Cells[issuedCol.Index].Value = 0;
            }

            _remainingStock[bin].Remaining -= newIssued;
            _remainingStock[bin].Issued += newIssued;

            // Update stock display for all rows of same bin
            foreach (DataGridViewRow r in dgv_item.Rows)
            {
                string rBin = r.Cells[binCol.Index].Value?.ToString() ?? "";
                if (rBin == bin)
                    r.Cells[dgv_item.Columns[DgvCol.StockQty].Index].Value = Math.Max(0, _remainingStock[bin].Remaining);
            }
        }

        private void btn_save_Click(object sender, EventArgs e)
        {
            var issuedCol = dgv_item.Columns.Cast<DataGridViewColumn>().FirstOrDefault(c => c.Name == DgvCol.IssuedQty);
            var binCol = dgv_item.Columns.Cast<DataGridViewColumn>().FirstOrDefault(c => c.Name == DgvCol.BinLocation);
            var uomCol = dgv_item.Columns.Cast<DataGridViewColumn>().FirstOrDefault(c => c.Name == DgvCol.IssuedUom);

            if (issuedCol == null || binCol == null || uomCol == null) return;

            IssuedPerBin = dgv_item.Rows
                .Cast<DataGridViewRow>()
                .Where(r => Convert.ToDecimal(r.Cells[issuedCol.Index].Value ?? 0) > 0)
                .ToDictionary(
                    r => r.Cells[binCol.Index].Value?.ToString() ?? "",
                    r => Convert.ToDecimal(r.Cells[issuedCol.Index].Value ?? 0)
                );

            IssuedQty = IssuedPerBin.Values.Sum();
            if (IssuedQty <= 0)
            {
                Helpers.ShowDialogMessage("error", "No quantity issued.");
                return;
            }

            IssuedUom = dgv_item.Rows[0].Cells[uomCol.Index].Value?.ToString();
            DialogResult = DialogResult.OK;
            Close();
        }
    }
}