
using Newtonsoft.Json;

namespace smpc_dispatching.Core.Models {
    public class DeliveryItemModel : BaseModel {

        [JsonProperty("sales_order_id")]
        public int SalesOrderId { get; set; }
        [JsonProperty("item_code")]
        public string ItemCode { get; set; }
        [JsonProperty("description")]
        public string Description { get; set; }
        [JsonProperty("quantity")]
        public double Quantity { get; set; }
        [JsonProperty("deliverd_qty")]
        public double DeliveredQty { get; set; }
        [JsonProperty("delivery_cost")]
        public double DeliveryCost { get; set; }
        [JsonProperty("status")]
        public string Status { get; set; }
    }
}
