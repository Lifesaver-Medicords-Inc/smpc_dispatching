using Newtonsoft.Json;
using System;

namespace smpc_dispatching.Core.Models {
    public class BaseModel {
        [JsonProperty("id")]
        public uint? Id { get; set; }
        [JsonProperty("created_at")]
        public DateTime? CreatedAt { get; set; }
        [JsonProperty("updated_at")]
        public DateTime? UpdatedAt { get; set; }
    }
}
