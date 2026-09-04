using smpc_dispatching.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace smpc_dispatching.UI.Views.Delivery_Receipt
{
    // btn_search on DeliveryReceiptUC had no Click handler wired at all - same
    // empty-stub pattern already found and fixed on Item Release's own Search button
    // this session. Modeled directly on that fix's ItemReleaseSearchModal: filters the
    // in-memory list DeliveryReceiptUC already has loaded (LoadDeliveryReceipts), no
    // separate API call needed, and returns the picked id via DialogResult.
    public partial class DeliveryReceiptSearchModal : Form
    {
        private readonly List<DeliveryReceiptModel> _all;

        public int? SelectedId { get; private set; }

        public DeliveryReceiptSearchModal(List<DeliveryReceiptModel> deliveryReceipts)
        {
            InitializeComponent();
            _all = deliveryReceipts ?? new List<DeliveryReceiptModel>();
            LoadRows(_all);
        }

        private void LoadRows(IEnumerable<DeliveryReceiptModel> rows)
        {
            dgv_results.Rows.Clear();
            foreach (var r in rows)
            {
                dgv_results.Rows.Add(
                    r.id,
                    "DR#" + r.doc_no.ToString("D4"),
                    r.sales_order_id.HasValue ? r.sales_order_id.Value.ToString() : string.Empty,
                    r.customer_name,
                    r.delivery_date,
                    r.sales_executive
                );
            }
        }

        private void txt_search_TextChanged(object sender, EventArgs e)
        {
            string text = txt_search.Text.Trim();

            if (string.IsNullOrEmpty(text))
            {
                LoadRows(_all);
                return;
            }

            var filtered = _all.Where(r =>
                Matches(r.doc_no.ToString(), text) ||
                Matches(r.sales_order_id?.ToString(), text) ||
                Matches(r.customer_name, text) ||
                Matches(r.customer_code, text) ||
                Matches(r.sales_executive, text) ||
                Matches(r.delivery_date, text));

            LoadRows(filtered);
        }

        private static bool Matches(string field, string text) =>
            !string.IsNullOrEmpty(field) && field.IndexOf(text, StringComparison.OrdinalIgnoreCase) >= 0;

        // Same single-click-selects convention as ItemReleaseSearchModal.
        private void dgv_results_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            var idValue = dgv_results.Rows[e.RowIndex].Cells["col_id"].Value;
            if (idValue == null) return;

            SelectedId = Convert.ToInt32(idValue);
            DialogResult = DialogResult.OK;
            Close();
        }
    }
}
