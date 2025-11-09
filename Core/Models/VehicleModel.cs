using Newtonsoft.Json;

namespace smpc_dispatching.Core.Models {
    public class VehicleModel : BaseModel {
        [JsonProperty("type")]
        public string Type { get; set; }

        [JsonProperty("model")]
        public string Model { get; set; }

        [JsonProperty("description")]
        public string Description { get; set; }

        [JsonProperty("plate_no")]
        public string PlateNo { get; set; }

        [JsonProperty("acquisition_year")]
        public string AcquisitionYear { get; set; }

        [JsonProperty("capacity")]
        public uint Capacity { get; set; }

        [JsonProperty("status")]
        public string Status { get; set; }

        [JsonProperty("last_maintenance")]
        public string LastMaintenance { get; set; }

        [JsonProperty("notes")]
        public string Notes { get; set; }
    }
}
