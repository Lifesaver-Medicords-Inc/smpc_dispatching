

using Newtonsoft.Json;

namespace smpc_dispatching.Core.Models {
    public class DeliveryReceiptItemModel
    {
        [JsonProperty("id")]
        public int items_id { get; set; }
        [JsonProperty("delivery_receipt_id")]
        public int items_delivery_receipt_id { get; set; }
        [JsonProperty("item_id")]
        public int items_item_id { get; set; }
        [JsonProperty("qty")]
        public int items_qty { get; set; }
        [JsonProperty("unit_of_measure")]
        public string items_unit_of_measure { get; set; }
        [JsonProperty("item_code")]
        public string items_item_code { get; set; }
        [JsonProperty("item_description")]
        public string items_item_description { get; set; }
        [JsonProperty("serial_no")]
        public string items_serial_no { get; set; }
    }

}
