using smpc_dispatching.Core.Interfaces;
using smpc_dispatching.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace smpc_dispatching.UI.Views.Inventory {
    // The Reservations submodule (§10.4.2, §10.4.5): every stock reservation raised from a
    // Sales Quotation's RESERVE checkbox (Quick Quote and Project Quotation both land here -
    // see source_type), whatever its state.
    //   APPROVE       puts a reservation into effect - its units leave available stock
    //   DECLINE       declines a request, or withdraws an approval; the row stays
    //   REMOVE        deletes the row - used when sales advises the quote is off
    //   KEEP ON HOLD  answers a reservation at its quote's VALID UNTIL: a fresh window from today
    //   LET GO        answers it the other way: its units return to stock
    //
    // Rows at their limit sort first and read "AT LIMIT" in STATUS. The owning sales executive
    // gets the same keep/let-go question on their red box, and whichever of the two answers
    // first settles it. The server enforces that, and the RESERVATION_APPROVAL access check, on
    // every call, so a 403 just surfaces as a normal error message.
    //
    // Rows are picked with the tick box in the leftmost column, and every action applies to each
    // ticked row. There's no bulk endpoint on the API - each decision is still its own call,
    // looped here - so a batch can come back partly applied; the summary dialog names whatever
    // failed rather than rolling the successful ones back, since each decision that landed is a
    // real, correct one.
    public partial class ReservationApprovalUC : UserControl {
        private enum ReservationAction { Approve, Decline, Remove, KeepOnHold, LetGo }

        private readonly IReservationApprovalService _reservationApprovalService;
        private List<PendingReservationModel> _reservations = new List<PendingReservationModel>();

        public ReservationApprovalUC(IReservationApprovalService reservationApprovalService) {
            InitializeComponent();
            _reservationApprovalService = reservationApprovalService;
        }

        private async void ReservationApprovalUC_Load(object sender, EventArgs e) {
            await LoadReservations();
        }

        private async void btn_refresh_Click(object sender, EventArgs e) {
            await LoadReservations();
        }

        private async Task LoadReservations() {
            SetButtonsEnabled(false);
            try {
                var response = await _reservationApprovalService.GetQueueAsync();

                if (response == null || !response.Success) {
                    MessageBox.Show(response?.Message ?? "Failed to load reservations.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    _reservations = new List<PendingReservationModel>();
                } else {
                    _reservations = response.Data?.ToList() ?? new List<PendingReservationModel>();
                }

                BindGrid();
            } finally {
                SetButtonsEnabled(true);
            }
        }

        private void BindGrid() {
            dg_pending_reservations.Rows.Clear();

            foreach (var r in _reservations) {
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
                    StatusText(r)
                );
            }

            UpdateSelectedCount();
        }

        // "Rejected" reads DECLINED, the spec's word for it (§10.4.2).
        private static string StatusText(PendingReservationModel r) {
            string status = string.Equals(r.Status, "Rejected", StringComparison.OrdinalIgnoreCase)
                ? "DECLINED"
                : (r.Status ?? string.Empty).ToUpperInvariant();

            return r.LimitReachedAt.HasValue ? status + " - AT LIMIT" : status;
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

            var targets = _reservations.Where(r => ids.Contains(r.Id)).ToList();

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
            await ConfirmAndRun(ReservationAction.Approve, "Approve {0}? Its units leave available stock.", "Confirm Approve");
        }

        private async void btn_reject_Click(object sender, EventArgs e) {
            await ConfirmAndRun(ReservationAction.Decline, "Decline {0}? Anything it holds returns to stock. The row stays.", "Confirm Decline");
        }

        private async void btn_remove_Click(object sender, EventArgs e) {
            await ConfirmAndRun(ReservationAction.Remove, "Remove {0}? Use this when sales advises the quote is off.", "Confirm Remove");
        }

        private async void btn_keep_Click(object sender, EventArgs e) {
            await ConfirmAndRun(ReservationAction.KeepOnHold, "Keep {0} on hold? A fresh window starts today, and the quote's VALID UNTIL moves with it.", "Confirm Keep On Hold");
        }

        private async void btn_let_go_Click(object sender, EventArgs e) {
            await ConfirmAndRun(ReservationAction.LetGo, "Let {0} go? Its units return to stock.", "Confirm Let Go");
        }

        private async Task ConfirmAndRun(ReservationAction action, string question, string title) {
            var targets = GetTargetReservations();
            if (targets == null) return;

            // Keep on hold / let go only answer a reservation that has reached its limit.
            if (action == ReservationAction.KeepOnHold || action == ReservationAction.LetGo) {
                targets = targets.Where(r => r.LimitReachedAt.HasValue).ToList();
                if (targets.Count == 0) {
                    MessageBox.Show("None of the selected reservations has reached its limit.", "Nothing To Answer", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
            }

            if (MessageBox.Show(string.Format(question, DescribeTargets(targets)), title, MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.Yes) {
                return;
            }

            smpc_dispatching.Core.Helpers.Helpers.Loading.ShowLoading(this);
            try {
                await RunAction(targets, action);
            } finally {
                smpc_dispatching.Core.Helpers.Helpers.Loading.HideLoading(this);
            }
        }

        private Task<HttpResponseModel<object>> Send(ReservationAction action, uint reservationId) {
            switch (action) {
                case ReservationAction.Approve: return _reservationApprovalService.ApproveAsync(reservationId);
                case ReservationAction.Decline: return _reservationApprovalService.RejectAsync(reservationId);
                case ReservationAction.Remove: return _reservationApprovalService.RemoveAsync(reservationId);
                case ReservationAction.KeepOnHold: return _reservationApprovalService.KeepOnHoldAsync(reservationId);
                default: return _reservationApprovalService.LetGoAsync(reservationId);
            }
        }

        private async Task RunAction(List<PendingReservationModel> targets, ReservationAction action) {
            SetButtonsEnabled(false);
            try {
                int succeeded = 0;
                var failures = new List<string>();

                foreach (var reservation in targets) {
                    var response = await Send(action, reservation.Id);

                    if (response == null || !response.Success) {
                        failures.Add(string.Format("{0} ({1}): {2}",
                            reservation.DocumentNo,
                            reservation.ItemName,
                            response?.Message ?? "unknown error"));
                        continue;
                    }

                    succeeded++;
                }

                ReportOutcome(succeeded, failures, action);
                await LoadReservations();
            } finally {
                SetButtonsEnabled(true);
            }
        }

        private static string Verb(ReservationAction action) {
            switch (action) {
                case ReservationAction.Approve: return "Approved";
                case ReservationAction.Decline: return "Declined";
                case ReservationAction.Remove: return "Removed";
                case ReservationAction.KeepOnHold: return "Kept on hold";
                default: return "Let go";
            }
        }

        private static void ReportOutcome(int succeeded, List<string> failures, ReservationAction action) {
            string verb = Verb(action);

            if (failures.Count == 0) {
                // A single successful decision closes silently; only a batch is summarised.
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
            btn_remove.Enabled = enabled;
            btn_keep.Enabled = enabled;
            btn_let_go.Enabled = enabled;
            btn_refresh.Enabled = enabled;
            btn_select_all.Enabled = enabled;
        }
    }
}
