using smpc_dispatching.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace smpc_dispatching.UI.Views.SalesOrder {
    public partial class SalesOrderListForm : Form {

        public Action<uint> SetCurrentOrderID { get; set; }
        private List<SalesOrderModel> _salesOrders;

        public SalesOrderListForm() {
            InitializeComponent();
        }


        public void InitOrders(List<SalesOrderModel> orders) {
            _salesOrders = orders;
            LoadOrders(orders);
        }



        private void LoadOrders(List<SalesOrderModel> orders) {
            OrderListDataGridView.Controls.Clear();
            OrderListDataGridView.Rows.Clear();
            for (var i = 0; i < orders.Count; i++) {
                var order = orders[i];
                OrderListDataGridView.Rows.Add(order.OrderID, order.DocumentNo, order.RefPO.ToString(), order.Status, order.QuotationID);
            }
        }
        private void OrderListDataGridView_CellContentClick(object sender, DataGridViewCellEventArgs e) {

            if (OrderListDataGridView.SelectedRows.Count > 0) {

                DataGridViewRow row = OrderListDataGridView.SelectedRows[0];

                var id = Convert.ToUInt32(row.Cells["ID"].Value);

                SetCurrentOrderID.Invoke(id);
                this.Hide();
            }
        }

        private void SerachTextBox_TextChanged(object sender, EventArgs e) {
            var text = SerachTextBox.Text;

            var filterd = _salesOrders.Where(o => o.DocumentNo.ToString().Contains(text)
            || o.RefPO.ToString().Contains(text)
            || o.Status.Contains(text)
            || o.QuotationID.ToString().Contains(text)).ToList();

            if (filterd != null) {
                LoadOrders(filterd);
            } else {
                LoadOrders(_salesOrders);
            }


        }
    }
}
