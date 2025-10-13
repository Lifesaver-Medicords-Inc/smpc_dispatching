using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace smpc_dispatching.Core.Models {
    public class SalesOrderModel : BaseModel {

        [JsonProperty("order_number")]
        public string OrderNumber { get; set; }
        [JsonProperty("customer_name")]
        public string CustomerName { get; set; }
        [JsonProperty("status")]
        public string Status { get; set; }
        [JsonProperty("total_cost")]
        public double TotalCost { get; set; }
        [JsonProperty("delivery_date")]
        public DateTime? DeliveryDate { get; set; }
        [JsonProperty("delivery_items")]
        public List<DeliveryItemModel> DeliveryItems { get; set; } = new List<DeliveryItemModel>();
    }
}
