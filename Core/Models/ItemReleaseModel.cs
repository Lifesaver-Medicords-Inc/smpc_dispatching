

using Newtonsoft.Json;
using System.Collections.Generic;

namespace smpc_dispatching.Core.Models {
    public class ItemReleaseModel : BaseModel {

        [JsonProperty("sales_order_id")]
        public int SalesOrderId { get; set; }
        [JsonProperty("request_number")]
        public string RequestNumber { get; set; }
        [JsonProperty("requested_by")]
        public string RequestedBy { get; set; }
        [JsonProperty("approved_by")]
        public string ApprovedBy { get; set; }
        [JsonProperty("status")]
        public string Status { get; set; }
        [JsonProperty("remarks")]
        public string Remarks { get; set; }
        [JsonProperty("release_items")]
        public List<ItemReleaseDetail> ReleaseItems { get; set; } = new List<ItemReleaseDetail>();
    }

    public class ItemReleaseDetail : BaseModel {

        [JsonProperty("item_release_id")]
        public int ItemReleaseId { get; set; }
        [JsonProperty("item_code")]
        public string ItemCode { get; set; }
        [JsonProperty("description")]
        public string Description { get; set; }
        [JsonProperty("requested_qty")]
        public double RequestedQty { get; set; }
        [JsonProperty("requested_qty")]
        public double ReleasedQty { get; set; }
        [JsonProperty("unit")]
        public string Unit { get; set; }
        [JsonProperty("remarks")]
        public string Remarks { get; set; }
        [JsonProperty("status")]
        public string Status { get; set; }
    }
}
