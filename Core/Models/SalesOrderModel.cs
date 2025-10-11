using System;
using System.Collections.Generic;

namespace smpc_dispatching.Core.Models {
   public class SalesOrderModel {
        public int Id { get; set; }
        public string OrderNumber { get; set; }
        public string CustomerName { get; set; }
        public string Status { get; set; }
        public double TotalCost { get; set; }
        public DateTime? DeliveryDate { get; set; }
        public List<DeliveryItemModel> DeliveryItems { get; set; } = new List<DeliveryItemModel>();
    }
}
