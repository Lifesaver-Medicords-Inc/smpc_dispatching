using Newtonsoft.Json;
using System.Text.Json;

namespace smpc_dispatching.Core.Models {
    public class FileModel : BaseModel {

        [JsonProperty("file_name")]
        public string Name { get; set; }
        [JsonProperty("path")]
        public string Path { get; set; }
        [JsonProperty("type")]
        public string Type { get; set; }
        [JsonProperty("size")]
        public string Size { get; set; }
    }
}
