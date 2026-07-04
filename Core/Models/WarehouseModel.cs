using Newtonsoft.Json;

namespace smpc_dispatching.Core.Models {
    public class WarehouseModel : BaseModel {
        [JsonProperty("code")]
        public string Code { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("warehouse_manager")]
        public string WarehouseManager { get; set; }
    }
}
