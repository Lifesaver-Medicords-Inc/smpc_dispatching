using System;


namespace smpc_dispatching.Core.Models {
    public class CalendarEventModel {
        public uint Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public string Department { get; set; }  // "Sales", "Engineering", "Logistics"
        public uint CreatedById { get; set; }
        public UserModel CreatedBy { get; set; }
        public string Color { get; set; }
        public double Cost { get; set; }
        public string Location { get; set; }
        public bool IsAllDay { get; set; }
        public bool IsCancelled { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
    }
}
