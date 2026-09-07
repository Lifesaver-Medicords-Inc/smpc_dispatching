using Newtonsoft.Json;

namespace smpc_dispatching.Core.Models
{
    // A driver or helper who goes out on deliveries (spec §13.3, "select driver,
    // helper, and vehicle first").
    //
    // Deliberately NOT a system user: these people do not log in, hold no position or
    // module access, and are not HRIS employee records - §15 keeps HRIS out of scope
    // and the ERP is meant to sync with it later rather than duplicate it. The record
    // therefore carries only what dispatch needs to put a name against a trip
    // (user decision, 2026-09-05: name, role and status only).
    public class DispatchPersonModel
    {
        [JsonProperty("id")]
        public int id { get; set; }

        [JsonProperty("full_name")]
        public string full_name { get; set; }

        // "DRIVER" or "HELPER" - the two roles §13.3 names. §17 defines no list for
        // this, and CLAUDE.md forbids inventing dropdown values, so no third option is
        // offered.
        [JsonProperty("role")]
        public string role { get; set; }

        // Inactive people drop out of the schedule pickers but are never deleted - past
        // schedules keep their names, the same rule §4.4.1 applies to an inactive
        // warehouse ("all past data is retained").
        [JsonProperty("is_active")]
        public bool is_active { get; set; } = true;

        public override string ToString() => full_name ?? string.Empty;
    }

    // One person assigned to one logistics schedule, in one capacity. A row per person
    // rather than fixed driver/helper1/helper2 fields, so the normal 1 driver + 1 helper
    // and the occasional 1 driver + 2 helpers are the same shape.
    public class SchedulePersonModel
    {
        [JsonProperty("id")]
        public int id { get; set; }

        [JsonProperty("schedule_id")]
        public int schedule_id { get; set; }

        [JsonProperty("person_id")]
        public int person_id { get; set; }

        [JsonProperty("role")]
        public string role { get; set; }

        [JsonProperty("full_name")]
        public string full_name { get; set; }
    }
}
