using Newtonsoft.Json;

namespace smpc_dispatching.Core.Models
{
    public class ReceiptUploadModel
    {
        [JsonProperty("file_path")]
        public string FilePath { get; set; }

        [JsonProperty("original_name")]
        public string OriginalName { get; set; }

        [JsonProperty("type")]
        public string Type { get; set; }

        [JsonProperty("size")]
        public long Size { get; set; }
    }
}
