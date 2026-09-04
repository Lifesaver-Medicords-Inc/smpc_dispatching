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
        // Route costs and delivery costs are one table now (spec §13.3): a cost row
        // carries route_id when it was entered on a logistics route. It is never shown,
        // but it MUST round-trip - BuildModelsFromData reads the grid, so without a
        // (hidden) column here a DR save would write the row back with route_id 0 and
        // silently detach it from its route.
        [JsonProperty("route_id")]
        public int costs_route_id { get; set; }
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
