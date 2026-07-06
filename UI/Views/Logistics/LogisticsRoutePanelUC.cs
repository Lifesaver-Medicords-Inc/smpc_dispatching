using smpc_dispatching.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace smpc_dispatching.UI.Views.Logistics
{
    public partial class LogisticsRoutePanelUC : UserControl
    {
        private static readonly string[] TemplateCostTypes = new[]
        {
            "Labor", "Vehicle", "Fuel", "Toll Gate", "Insurance", "Penalty", "Others"
        };

        public event EventHandler RemoveRequested;
        public event EventHandler PinLocationRequested;

        public string LocationText
        {
            get => txt_location.Text;
            set => txt_location.Text = value;
        }

        public LogisticsRoutePanelUC()
        {
            InitializeComponent();
            cmb_ship_type.Items.AddRange(new object[] { "Delivery", "Pickup", "Return", "Other" });
            AddTemplateCostRows();
        }

        public void SetRouteNumber(int number)
        {
            lbl_header.Text = $"ROUTE #{number}";
        }

        public void SetClientSupplierOptions(IEnumerable<BPI> options)
        {
            var selected = cmb_client_supplier.Text;

            cmb_client_supplier.DataSource = options?.ToList() ?? new List<BPI>();
            cmb_client_supplier.DisplayMember = "Name";
            cmb_client_supplier.ValueMember = "Name";

            cmb_client_supplier.Text = selected;
        }

        public void HideRemoveButton()
        {
            //btn_remove.Visible = false;
        }

        private static void SetTime(DateTimePicker picker, string time)
        {
            if (!string.IsNullOrWhiteSpace(time) && DateTime.TryParse(time, out var parsed))
                picker.Value = parsed;
        }

        private void AddTemplateCostRows()
        {
            foreach (var type in TemplateCostTypes)
            {
                dg_costs.Rows.Add(type, string.Empty, "1", "0.00", string.Empty);
            }
        }

        private void btn_remove_Click(object sender, EventArgs e)
        {
            RemoveRequested?.Invoke(this, EventArgs.Empty);
        }

        private void btn_pin_location_Click(object sender, EventArgs e)
        {
            PinLocationRequested?.Invoke(this, EventArgs.Empty);
        }

        private void btn_add_cost_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            dg_costs.Rows.Add(string.Empty, string.Empty, "1", "0.00", string.Empty);
        }

        public void LoadRoute(LogisticsRouteModel route)
        {
            cmb_ship_type.Text = route.ShipType;
            txt_reference_doc.Text = route.ReferenceDoc;
            txt_delivery_receipt.Text = route.DeliveryReceiptDoc;
            txt_sales_invoice.Text = route.SalesInvoiceDoc;
            cmb_client_supplier.Text = route.ClientSupplier;
            txt_location.Text = route.Location;
            txt_receiver.Text = route.Receiver;
            txt_contact_no.Text = route.ContactNo;
            SetTime(dtp_departed, route.DepartedAt);
            SetTime(dtp_arrived, route.ArrivedAt);
            SetTime(dtp_returned, route.ReturnedAt);
            txt_notes.Text = route.Notes;

            dg_costs.Rows.Clear();
            if (route.Costs != null && route.Costs.Count > 0)
            {
                foreach (var cost in route.Costs)
                {
                    dg_costs.Rows.Add(cost.CostType, cost.Description, cost.Multiplier.ToString(), cost.Amount.ToString("0.00"), cost.ReceiptPath);
                }
            }
            else
            {
                AddTemplateCostRows();
            }
        }

        public LogisticsRouteModel BuildRoute(int sortOrder)
        {
            var route = new LogisticsRouteModel
            {
                SortOrder = sortOrder,
                ShipType = cmb_ship_type.Text,
                ReferenceDoc = txt_reference_doc.Text,
                DeliveryReceiptDoc = txt_delivery_receipt.Text,
                SalesInvoiceDoc = txt_sales_invoice.Text,
                ClientSupplier = cmb_client_supplier.Text,
                Location = txt_location.Text,
                Receiver = txt_receiver.Text,
                ContactNo = txt_contact_no.Text,
                DepartedAt = dtp_departed.Value.ToString("hh:mm tt"),
                ArrivedAt = dtp_arrived.Value.ToString("hh:mm tt"),
                ReturnedAt = dtp_returned.Value.ToString("hh:mm tt"),
                Notes = txt_notes.Text
            };

            foreach (DataGridViewRow row in dg_costs.Rows)
            {
                if (row.IsNewRow) continue;

                var costType = row.Cells["col_cost_type"].Value?.ToString() ?? string.Empty;
                var description = row.Cells["col_description"].Value?.ToString() ?? string.Empty;
                var multiplierText = row.Cells["col_multiplier"].Value?.ToString() ?? "0";
                var amountText = row.Cells["col_amount"].Value?.ToString() ?? "0";
                var receiptPath = row.Cells["col_receipt"].Value?.ToString() ?? string.Empty;

                if (string.IsNullOrWhiteSpace(costType) && string.IsNullOrWhiteSpace(amountText))
                    continue;

                decimal.TryParse(multiplierText, out var multiplier);
                decimal.TryParse(amountText, out var amount);

                route.Costs.Add(new LogisticsRouteCostModel
                {
                    CostType = costType,
                    Description = description,
                    Multiplier = multiplier,
                    Amount = amount,
                    ReceiptPath = receiptPath
                });
            }

            return route;
        }
    }
}
