using smpc_dispatching.Core.Helpers;
using smpc_dispatching.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace smpc_dispatching.UI.Views.ItemRelease
{
    // Search for the Item Release list - btn_search_Click was previously an empty stub
    // (did nothing at all when clicked). Modeled on SalesOrder\SalesOrderListForm's
    // live-filter list pattern, but returns the picked id via DialogResult (the
    // picker-modal convention used elsewhere in this codebase, e.g. the Sales app's
    // RequestForEngrModal) since ItemReleaseUC shows this with ShowDialog().
    //
    // Filters the list ItemReleaseUC already has loaded in memory (_itemReleases) - it is
    // already correctly scoped (LoadItemReleases restricts a Warehouse user to
    // is_forward == true records), so no separate API call is needed here.
    public partial class ItemReleaseSearchModal : Form
    {
        private readonly List<ItemReleaseModel> _all;

        public uint? SelectedId { get; private set; }

        public ItemReleaseSearchModal(List<ItemReleaseModel> itemReleases)
        {
            InitializeComponent();
            _all = itemReleases ?? new List<ItemReleaseModel>();
            LoadRows(_all);
        }

        private void LoadRows(IEnumerable<ItemReleaseModel> rows)
        {
            dgv_results.Rows.Clear();
            foreach (var r in rows)
            {
                dgv_results.Rows.Add(
                    r.id,
                    r.doc_no.HasValue ? Helpers.DocNoFormatter(r.doc_no.Value, "IREL#") : string.Empty,
                    r.reference_doc_no,
                    r.requested_by,
                    r.received_by,
                    (r.is_forward ?? false) ? "FORWARDED" : "DRAFT"
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
                Matches(r.doc_no?.ToString(), text) ||
                Matches(r.reference_doc_no, text) ||
                Matches(r.requested_by, text) ||
                Matches(r.received_by, text) ||
                Matches(r.approved_by, text) ||
                Matches(r.issued_by, text));

            LoadRows(filtered);
        }

        private static bool Matches(string field, string text) =>
            !string.IsNullOrEmpty(field) && field.IndexOf(text, StringComparison.OrdinalIgnoreCase) >= 0;

        // Same single-click-selects convention as SalesOrderListForm's
        // OrderListDataGridView_CellContentClick.
        private void dgv_results_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            var idValue = dgv_results.Rows[e.RowIndex].Cells["col_id"].Value;
            if (idValue == null) return;

            SelectedId = Convert.ToUInt32(idValue);
            DialogResult = DialogResult.OK;
            Close();
        }
    }
}
