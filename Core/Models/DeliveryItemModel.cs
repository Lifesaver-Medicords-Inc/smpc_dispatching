
namespace smpc_dispatching.Core.Models {
    public class DeliveryItemModel {
        public int Id { get; set; }
        public int SalesOrderId { get; set; }
        public string ItemCode { get; set; }
        public string Description { get; set; }
        public double Quantity { get; set; }
        public double DeliveredQty { get; set; }
        public double DeliveryCost { get; set; }
        public string Status { get; set; }
    }
}
