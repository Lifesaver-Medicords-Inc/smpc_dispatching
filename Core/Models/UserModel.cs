using Newtonsoft.Json;
using System.Collections.Generic;

namespace smpc_dispatching.Core.Models {
    public class UserModel {
        public int id { get; set; }
        public string employee_id { get; set; }
        public string first_name { get; set; }
        public string last_name { get; set; }
        public string department { get; set; }
        public int position_id { set; get; }
         public UserPermissionModel permissions { get; set; }
        public PositionModel position { get; set; }

        [JsonIgnore]
        public string FullName => $"{first_name} {last_name}".Trim();
    }
    public class UserPermissionModel
    {
        public int id { get; set; }
        public int user_id { get; set; }
        public bool can_create { get; set; }
        public bool can_update { get; set; }
        public bool can_delete { get; set; }
    }

    public class PositionModel
    {
        public int id { get; set; }
        public string name { get; set; }
        public ICollection<PositionAccessModel> access { get; set; } = new List<PositionAccessModel>();
        public ICollection<UserModel> users { get; set; } = new List<UserModel>();
    }

    public class PositionAccessModel
    {
        public int id { get; set; }
        public int position_id { get; set; }
        public string code { get; set; }
    }
}
