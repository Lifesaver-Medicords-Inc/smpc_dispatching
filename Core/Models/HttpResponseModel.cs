

using Newtonsoft.Json;

namespace smpc_dispatching.Core.Models {
   public class HttpResponseModel<T> {
        [JsonProperty("data")]
        public T Data { get; set; }

        [JsonProperty("message")]
        public string Message { get; set; }

        [JsonProperty("success")]
        public bool Success { get; set; }
    }
}
