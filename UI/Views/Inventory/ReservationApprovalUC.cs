using smpc_dispatching.Core.Interfaces;
using smpc_dispatching.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
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
                string sourceLabel = r.SourceType == "sales_project_item" ? "Project Quotation" : "Quick Quote";

                dg_pending_reservations.Rows.Add(
                    r.Id,
                    r.DocumentNo,
                    sourceLabel,
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
        }

        private PendingReservationModel GetSelectedReservation() {
            if (dg_pending_reservations.SelectedRows.Count == 0) {
                MessageBox.Show("Select a reservation first.", "No Selection", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return null;
            }

            var id = Convert.ToUInt32(dg_pending_reservations.SelectedRows[0].Cells["col_id"].Value);
            return _pending.FirstOrDefault(r => r.Id == id);
        }

        private async void btn_approve_Click(object sender, EventArgs e) {
            var reservation = GetSelectedReservation();
            if (reservation == null) return;

            if (MessageBox.Show(
                $"Approve the reservation for {reservation.Qty} x {reservation.ItemName} ({reservation.DocumentNo})?",
                "Confirm Approve", MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.Yes) {
                return;
            }

            SetButtonsEnabled(false);
            try {
                var response = await _reservationApprovalService.ApproveAsync(reservation.Id);
                if (response == null || !response.Success) {
                    MessageBox.Show(response?.Message ?? "Failed to approve reservation.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                await LoadPendingReservations();
            } finally {
                SetButtonsEnabled(true);
            }
        }

        private async void btn_reject_Click(object sender, EventArgs e) {
            var reservation = GetSelectedReservation();
            if (reservation == null) return;

            if (MessageBox.Show(
                $"Reject the reservation for {reservation.Qty} x {reservation.ItemName} ({reservation.DocumentNo})? This frees the stock back up.",
                "Confirm Reject", MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.Yes) {
                return;
            }

            SetButtonsEnabled(false);
            try {
                var response = await _reservationApprovalService.RejectAsync(reservation.Id);
                if (response == null || !response.Success) {
                    MessageBox.Show(response?.Message ?? "Failed to reject reservation.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                await LoadPendingReservations();
            } finally {
                SetButtonsEnabled(true);
            }
        }

        private void SetButtonsEnabled(bool enabled) {
            btn_approve.Enabled = enabled;
            btn_reject.Enabled = enabled;
            btn_refresh.Enabled = enabled;
        }
    }
}
