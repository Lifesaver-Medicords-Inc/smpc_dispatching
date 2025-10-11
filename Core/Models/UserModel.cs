using Newtonsoft.Json;


namespace smpc_dispatching.Core.Models {
    public class UserModel {
        [JsonProperty("id")]
        public int Id { get; set; }

        [JsonProperty("employee_id")]
        public string EmployeeId { get; set; }

        [JsonProperty("first_name")]
        public string FirstName { get; set; }

        [JsonProperty("last_name")]
        public string LastName { get; set; }


        [JsonProperty("position_id")]
        public int PositionId { set; get; }

    }
}
