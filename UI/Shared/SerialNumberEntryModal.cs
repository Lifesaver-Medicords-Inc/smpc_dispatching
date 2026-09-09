using smpc_dispatching.Core.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace smpc_dispatching.UI.Shared
{
    // Per-unit serial number entry for one Item Release line.
    //
    // §5.9 step 4, which §5.10 inherits: "Serial numbers entered for every unit released.
    // If left blank the system MUST prompt before proceeding." A single free-text cell on a
    // line covering N units cannot express that - this gives the warehouse one box per unit.
    //
    // The line still holds them as one delimited value while it is being edited; the split
    // into one stored row per unit happens on save (see ItemReleaseUC.ExpandSerialisedLines),
    // which is the client decision of 2026-09-05: entry stays one line so bins are picked
    // once, and the saved document and its print carry a row per serialised unit.
    public partial class SerialNumberEntryModal : Form
    {
        // Comma-space reads naturally in the grid cell and survives the round trip through
        // nvarchar. SplitSerials parses it back - keep the two in step.
        public const string Separator = ", ";

        public string SerialNumbers { get; private set; }

        private readonly int _quantity;

        public SerialNumberEntryModal(int quantity, string existing, string itemDescription)
        {
            InitializeComponent();

            // A line with no released qty yet still gets one row, rather than an empty modal
            // the user cannot type into.
            _quantity = quantity > 0 ? quantity : 1;

            Text = string.IsNullOrWhiteSpace(itemDescription)
                ? "Serial Numbers"
                : $"Serial Numbers - {itemDescription}";

            lbl_hint.Text =
                $"One serial number per unit ({_quantity} unit{(_quantity == 1 ? "" : "s")} released). " +
                "Leave a line blank if that unit has no serial number.";

            var existingSerials = SplitSerials(existing);

            for (int unit = 0; unit < _quantity; unit++)
            {
                int rowIndex = dg_serials.Rows.Add();
                dg_serials.Rows[rowIndex].Cells["col_unit"].Value = $"Unit {unit + 1}";
                dg_serials.Rows[rowIndex].Cells["col_serial"].Value =
                    unit < existingSerials.Count ? existingSerials[unit] : string.Empty;
            }

            // More serials on record than units on the line - show them rather than drop
            // them silently. Happens when the released qty is reduced after serials were
            // entered.
            for (int extra = _quantity; extra < existingSerials.Count; extra++)
            {
                int rowIndex = dg_serials.Rows.Add();
                dg_serials.Rows[rowIndex].Cells["col_unit"].Value = $"Extra {extra - _quantity + 1}";
                dg_serials.Rows[rowIndex].Cells["col_serial"].Value = existingSerials[extra];
            }

            btn_ok.Click += btn_ok_Click;
            btn_cancel.Click += (s, e) => { DialogResult = DialogResult.Cancel; Close(); };
            CancelButton = btn_cancel;
        }

        public static List<string> SplitSerials(string stored)
        {
            if (string.IsNullOrWhiteSpace(stored)) return new List<string>();

            // Commas and newlines both: a value typed into the old free-text cell may carry
            // either, and both should read back as a list rather than one long serial.
            return stored
                .Split(new[] { ',', '\n', '\r' }, StringSplitOptions.None)
                .Select(s => s.Trim())
                .ToList();
        }

        private void btn_ok_Click(object sender, EventArgs e)
        {
            dg_serials.EndEdit();

            var serials = new List<string>();
            foreach (DataGridViewRow row in dg_serials.Rows)
            {
                if (row.IsNewRow) continue;
                serials.Add(row.Cells["col_serial"].Value?.ToString()?.Trim() ?? string.Empty);
            }

            // Trailing blanks carry nothing - drop them so an untouched line saves as empty
            // rather than as ", , , ". Blanks BETWEEN filled units are kept: position is what
            // ties a serial to its unit, and the split on save relies on that order.
            while (serials.Count > 0 && string.IsNullOrWhiteSpace(serials[serials.Count - 1]))
                serials.RemoveAt(serials.Count - 1);

            // §5.9 step 4 and §10.7: an incomplete serial column prompts, it never blocks.
            int filled = serials.Count(s => !string.IsNullOrWhiteSpace(s));
            if (filled > 0 && filled < _quantity)
            {
                var proceed = MessageBox.Show(
                    $"Serial number column incomplete - {filled} of {_quantity} unit" +
                    $"{(_quantity == 1 ? "" : "s")} entered." + Environment.NewLine + Environment.NewLine +
                    "Proceed?",
                    "Serial Numbers",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question,
                    MessageBoxDefaultButton.Button1);

                if (proceed != DialogResult.Yes) return;
            }

            SerialNumbers = string.Join(Separator, serials);

            DialogResult = DialogResult.OK;
            Close();
        }
    }
}
