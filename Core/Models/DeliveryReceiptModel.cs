using System;
using System.Collections.Generic;


namespace smpc_dispatching.Core.Models {
    public class DeliveryReceiptModel {
        public uint Id { get; set; }
        public string ReceiptNumber { get; set; }
        public uint SalesOrderId { get; set; }
        public SalesOrderModel SalesOrder { get; set; }
        public List<ItemReleaseModel> ReleasedItems { get; set; }
        public string RecipientName { get; set; }
        public string RecipientAddress { get; set; }
        public DateTime DeliveryDate { get; set; }
        public double TotalCost { get; set; }
        public string FileAttachment { get; set; }
        public string Remarks { get; set; }
        public string Status { get; set; }  // Pending, Delivered, Cancelled
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
    }
}
