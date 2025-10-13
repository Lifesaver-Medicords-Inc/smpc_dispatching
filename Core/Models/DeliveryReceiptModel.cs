using Newtonsoft.Json;
using System;
using System.Collections.Generic;


namespace smpc_dispatching.Core.Models {
    public class DeliveryReceiptModel : BaseModel {

        [JsonProperty("receipt_number")]
        public string ReceiptNumber { get; set; }
        [JsonProperty("sales_order_id")]
        public uint SalesOrderId { get; set; }
        [JsonProperty("sales_order")]
        public SalesOrderModel SalesOrder { get; set; }
        [JsonProperty("released_items")]
        public List<ItemReleaseModel> ReleasedItems { get; set; }
        [JsonProperty("recipient_name")]
        public string RecipientName { get; set; }
        [JsonProperty("recipient_address")]
        public string RecipientAddress { get; set; }
        [JsonProperty("delivery_date")]
        public DateTime DeliveryDate { get; set; }
        [JsonProperty("total_cost")]
        public double TotalCost { get; set; }
        //[JsonProperty("file_attachment")]
        //public string FileAttachment { get; set; }
        [JsonProperty("remarks")]
        public string Remarks { get; set; }
        [JsonProperty("status")]
        public string Status { get; set; }  // Pending, Delivered, Cancelled

    }
}
