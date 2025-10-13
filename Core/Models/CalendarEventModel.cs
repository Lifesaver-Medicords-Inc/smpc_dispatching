using Newtonsoft.Json;
using System;


namespace smpc_dispatching.Core.Models {
    public class CalendarEventModel : BaseModel {

        [JsonProperty("department_type")]
        public string DepartmentType { get; set; } // Sales, Engineering, Logistics
        [JsonProperty("title")]
        public string Title { get; set; }
        [JsonProperty("description")]
        public string Description { get; set; }
        [JsonProperty("start_date")]
        public DateTime StartDate { get; set; }
        [JsonProperty("end_date")]
        public DateTime EndDate { get; set; }
        [JsonProperty("reference_type")]
        public string ReferenceType { get; set; } // e.g. SalesOrder, DeliveryReceipt
        [JsonProperty("reference_id")]
        public uint ReferenceId { get; set; }
    }
}
