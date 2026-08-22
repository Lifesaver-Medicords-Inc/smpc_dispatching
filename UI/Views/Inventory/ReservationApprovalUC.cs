using smpc_dispatching.Core.Interfaces;
using smpc_dispatching.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace smpc_dispatching.UI.Views.Inventory {
    // Approval queue for stock reservations placed from Sales Quotation's stock-check
    // modal (Quick Quote and Project Quotation both land here - see source_type). A
    // reservation already holds stock the moment a sales rep checks RESERVE (Pending
    // counts the same as Approved against available stock - see the server-side Status
    // doc comment), so Approve here doesn't change availability at all; it just signs
    // off on who's allowed to promise that stock. Reject is the one action that actually
    // frees it back up.
    //
    // The server re-checks the acting user's Position against the RESERVATION_APPROVAL
    // access code on every Approve/Reject call regardless of what this screen shows, so
    // there's no separate "can I even see this button" check needed here - a 403 just
    // surfaces as a normal error message if someone without that access code lands on
    // this screen anyway.
    //
    // Rows are picked with the tick box in the leftmost column, and Approve/Reject act
    // on every ticked row. There's no bulk endpoint on the API - each decision is still
    // its own call, looped here - so a batch can come back partly applied; the summary
    // dialog names whatever failed rather than rolling the successful ones back, since
    // an approval that already landed is a real, correct decision.
    public partial class ReservationApprovalUC : UserControl {
        private readonly IReservationApprovalService _reservationApprovalService;
        private List<PendingReservationModel> _pending = new List<PendingReservationModel>();

        public ReservationApprovalUC(IReservationApprovalService reservationApprovalService) {
            InitializeComponent();
            _reservationApprovalService = reservationApprovalService;
        }

        private async void ReservationApprovalUC_Load(object sender, EventArgs e) {
            await LoadPendingReservations();
        }

        private async void btn_refresh_Click(object sender, EventArgs e) {
            await LoadPendingReservations();
        }

        private async System.Threading.Tasks.Task LoadPendingReservations() {
            SetButtonsEnabled(false);
            try {
                var response = await _reservationApprovalService.GetPendingAsync();

                if (response == null || !response.Success) {
                    MessageBox.Show(response?.Message ?? "Failed to load pending reservations.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    _pending = new List<PendingReservationModel>();
                } else {
                    _pending = response.Data?.ToList() ?? new List<PendingReservationModel>();
                }

                BindGrid();
            } finally {
                SetButtonsEnabled(true);
            }
        }

        private void BindGrid() {
            dg_pending_reservations.Rows.Clear();

            foreach (var r in _pending) {
                dg_pending_reservations.Rows.Add(
                    false,
                    r.Id,
                    r.DocumentNo,
                    string.IsNullOrWhiteSpace(r.CustomerName) ? "-" : r.CustomerName,
                    string.IsNullOrWhiteSpace(r.ProjectName) ? "-" : r.ProjectName,
                    r.ItemName,
                    r.ItemModel,
                    r.ItemCode,
                    r.Qty,
                    r.RequestedBy,
                    r.ReservedAt == default ? string.Empty : r.ReservedAt.ToString("MMM dd, yyyy h:mm tt"),
                    r.ExpiresAt.HasValue ? r.ExpiresAt.Value.ToString("MMM dd, yyyy") : "-",
                    r.Status
                );
            }

            UpdateSelectedCount();
        }

        // A DataGridViewCheckBoxColumn doesn't push its new value into the cell until the
        // row loses focus, so a tick made and acted on in the same click would still read
        // as false. Committing on the dirty-state change closes that gap.
        private void dg_pending_reservations_CurrentCellDirtyStateChanged(object sender, EventArgs e) {
            if (dg_pending_reservations.IsCurrentCellDirty) {
                dg_pending_reservations.CommitEdit(DataGridViewDataErrorContexts.Commit);
            }
        }

        private void dg_pending_reservations_CellContentClick(object sender, DataGridViewCellEventArgs e) {
            if (e.RowIndex < 0) return;
            if (dg_pending_reservations.Columns[e.ColumnIndex].Name != "col_select") return;

            UpdateSelectedCount();
        }

        private void btn_select_all_Click(object sender, EventArgs e) {
            // One button that flips the whole list: ticks everything unless everything is
            // already ticked, in which case it clears.
            bool anyUnchecked = dg_pending_reservations.Rows
                .Cast<DataGridViewRow>()
                .Any(row => !IsRowChecked(row));

            foreach (DataGridViewRow row in dg_pending_reservations.Rows) {
                row.Cells["col_select"].Value = anyUnchecked;
            }

            UpdateSelectedCount();
        }

        private static bool IsRowChecked(DataGridViewRow row) {
            var value = row.Cells["col_select"].Value;
            return value != null && Convert.ToBoolean(value);
        }

        private void UpdateSelectedCount() {
            int count = dg_pending_reservations.Rows
                .Cast<DataGridViewRow>()
                .Count(IsRowChecked);

            lbl_selected_count.Text = count == 1 ? "1 selected" : count + " selected";

            btn_select_all.Text = count > 0 && count == dg_pending_reservations.Rows.Count
                ? "CLEAR ALL"
                : "SELECT ALL";
        }

        // Ticked rows are the selection. If nothing is ticked, fall back to whatever row
        // is merely highlighted, so the old single-row habit still works.
        private List<PendingReservationModel> GetTargetReservations() {
            var ids = dg_pending_reservations.Rows
                .Cast<DataGridViewRow>()
                .Where(IsRowChecked)
                .Select(row => Convert.ToUInt32(row.Cells["col_id"].Value))
                .ToList();

            if (ids.Count == 0 && dg_pending_reservations.CurrentRow != null) {
                ids.Add(Convert.ToUInt32(dg_pending_reservations.CurrentRow.Cells["col_id"].Value));
            }

            if (ids.Count == 0) {
                MessageBox.Show("Tick at least one reservation first.", "No Selection", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return null;
            }

            var targets = _pending.Where(r => ids.Contains(r.Id)).ToList();

            if (targets.Count == 0) {
                MessageBox.Show("Tick at least one reservation first.", "No Selection", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return null;
            }

            return targets;
        }

        private static string DescribeTargets(List<PendingReservationModel> targets) {
            if (targets.Count == 1) {
                var only = targets[0];
                return string.Format("{0} x {1} ({2})", only.Qty, only.ItemName, only.DocumentNo);
            }

            return targets.Count + " reservations";
        }

        private async void btn_approve_Click(object sender, EventArgs e) {
            var targets = GetTargetReservations();
            if (targets == null) return;

            if (MessageBox.Show(
                string.Format("Approve {0}?", DescribeTargets(targets)),
                "Confirm Approve", MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.Yes) {
                return;
            }

            await RunDecision(targets, true);
        }

        private async void btn_reject_Click(object sender, EventArgs e) {
            var targets = GetTargetReservations();
            if (targets == null) return;

            if (MessageBox.Show(
                string.Format("Reject {0}? This frees the stock back up.", DescribeTargets(targets)),
                "Confirm Reject", MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.Yes) {
                return;
            }

            await RunDecision(targets, false);
        }

        private async System.Threading.Tasks.Task RunDecision(List<PendingReservationModel> targets, bool approve) {
            SetButtonsEnabled(false);
            try {
                int succeeded = 0;
                var failures = new List<string>();

                foreach (var reservation in targets) {
                    var response = approve
                        ? await _reservationApprovalService.ApproveAsync(reservation.Id)
                        : await _reservationApprovalService.RejectAsync(reservation.Id);

                    if (response == null || !response.Success) {
                        failures.Add(string.Format("{0} ({1}): {2}",
                            reservation.DocumentNo,
                            reservation.ItemName,
                            response?.Message ?? "unknown error"));
                        continue;
                    }

                    succeeded++;
                }

                ReportOutcome(succeeded, failures, approve);
                await LoadPendingReservations();
            } finally {
                SetButtonsEnabled(true);
            }
        }

        private static void ReportOutcome(int succeeded, List<string> failures, bool approve) {
            string verb = approve ? "Approved" : "Rejected";

            if (failures.Count == 0) {
                // A single successful decision used to close silently, so keep it that
                // way and only speak up once a batch is involved.
                if (succeeded > 1) {
                    MessageBox.Show(string.Format("{0} {1} reservations.", verb, succeeded),
                        "Done", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                return;
            }

            var message = new StringBuilder();
            message.AppendLine(string.Format("{0} {1} of {2}.", verb, succeeded, succeeded + failures.Count));
            message.AppendLine();
            message.AppendLine("Failed:");
            foreach (var failure in failures) {
                message.AppendLine("  - " + failure);
            }

            MessageBox.Show(message.ToString(), "Partly Applied", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }

        private void SetButtonsEnabled(bool enabled) {
            btn_approve.Enabled = enabled;
            btn_reject.Enabled = enabled;
            btn_refresh.Enabled = enabled;
            btn_select_all.Enabled = enabled;
        }
    }
}
