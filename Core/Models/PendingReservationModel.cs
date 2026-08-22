using Newtonsoft.Json;
using System;

namespace smpc_dispatching.Core.Models {
    // Mirrors ERP_API's inventory_models.PendingReservationView - one row in the
    // dispatcher/inventory manager's approval queue for a Sales Quotation's stock
    // reservation (Quick Quote or Project Quotation - see source_type).
    public class PendingReservationModel {
        [JsonProperty("id")]
        public uint Id { get; set; }

        [JsonProperty("item_id")]
        public uint ItemId { get; set; }

        [JsonProperty("item_name")]
        public string ItemName { get; set; }

        [JsonProperty("item_model")]
        public string ItemModel { get; set; }

        [JsonProperty("item_code")]
        public string ItemCode { get; set; }

        [JsonProperty("qty")]
        public uint Qty { get; set; }

        [JsonProperty("source_type")]
        public string SourceType { get; set; }

        [JsonProperty("source_id")]
        public uint SourceId { get; set; }

        [JsonProperty("quotation_id")]
        public uint QuotationId { get; set; }

        [JsonProperty("document_no")]
        public string DocumentNo { get; set; }

        // Off the parent quotation - who the stock is promised to, and for which
        // project. ProjectName is empty for Quick Quotes (they have no project).
        [JsonProperty("customer_name")]
        public string CustomerName { get; set; }

        [JsonProperty("project_name")]
        public string ProjectName { get; set; }

        [JsonProperty("requested_by")]
        public string RequestedBy { get; set; }

        [JsonProperty("reserved_at")]
        public DateTime ReservedAt { get; set; }

        [JsonProperty("expires_at")]
        public DateTime? ExpiresAt { get; set; }

        [JsonProperty("status")]
        public string Status { get; set; }
    }
}
