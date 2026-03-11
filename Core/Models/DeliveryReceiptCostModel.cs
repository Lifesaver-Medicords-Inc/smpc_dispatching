using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace smpc_dispatching.Core.Models
{
    public class DeliveryReceiptCostModel
    {
        [JsonProperty("id")]
        public int costs_id { get; set; }
        [JsonProperty("delivery_receipt_id")]
        public int costs_delivery_receipt_id { get; set; }
        [JsonProperty("cost_type_id")]
        public int costs_cost_type_id { get; set; }
        [JsonProperty("description")]
        public string costs_description { get; set; }
        [JsonProperty("amount")]
        public decimal costs_amount { get; set; }
        [JsonProperty("multiplier")]
        public decimal costs_multiplier { get; set; }
        [JsonProperty("total_cost")]
        public decimal costs_total_cost { get; set; }
        public List<DeliveryReceiptFileModel> delivery_receipt_file { get; set; }
    }
}
