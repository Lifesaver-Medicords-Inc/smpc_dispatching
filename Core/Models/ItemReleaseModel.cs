

using Newtonsoft.Json;
using System;

namespace smpc_dispatching.Core.Models {
    public class ItemReleaseModel : BaseModel {

        [JsonProperty("requested_by_id")]
        public uint RequestedById { get; set; }

        [JsonProperty("requested_by_name")]
        public string RequestedByName { get; set; }

        [JsonProperty("approved_by_id")]
        public uint? ApprovedById { get; set; }

        [JsonProperty("approved_by_name")]
        public string ApprovedByName { get; set; }

        [JsonProperty("release_by_id")]
        public string ReleaseById { get; set; }

        [JsonProperty("release_by_name")]
        public string ReleaseByName { get; set; }

        [JsonProperty("order_id")]
        public uint OrderID { get; set; }

        [JsonProperty("delivery_receipt_id")]
        public uint DeliveryReceiptId { get; set; }

        [JsonProperty("quantity_released")]
        public double QuantityReleased { get; set; }

        [JsonProperty("serial_number")]
        public string SerialNumber { get; set; }

        [JsonProperty("departed_at")]
        public DateTime? DepartedAt { get; set; }

        [JsonProperty("arrived_at")]
        public DateTime? ArrivedAt { get; set; }

        [JsonProperty("returned_at")]
        public DateTime? ReturnedAt { get; set; }

        [JsonProperty("status")]
        public string Status { get; set; }

        [JsonProperty("remarks")]
        public string Remarks { get; set; }

        [JsonProperty("peoples")]
        public string Peoples { get; set; }

        [JsonProperty("created_at")]
        public DateTime CreatedAt { get; set; }

        [JsonProperty("updated_at")]
        public DateTime UpdatedAt { get; set; }

        [JsonProperty("deleted_at")]
        public DateTime? DeletedAt { get; set; }

        [JsonProperty("vehicle_id")]
        public uint VehicleId { get; set; }

        [JsonProperty("order")]
        public SalesOrderDetailsModel Order { get; set; }

        [JsonProperty("delivery_receipt")]
        public DeliveryReceiptModel DeliveryReceipt { get; set; }

        [JsonProperty("vehicle")]
        public VehicleModel Vehicle { get; set; }
    }

}
