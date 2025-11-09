using Newtonsoft.Json;
using System;
using System.Collections.Generic;


namespace smpc_dispatching.Core.Models {
    public class DeliveryReceiptModel : BaseModel {

        [JsonProperty("delivery_receipt_number")]
        public string DeliveryReceiptNumber { get; set; }

        [JsonProperty("delivery_reference")]
        public string DeliveryReference { get; set; }

        [JsonProperty("order_id")]
        public uint OrderID { get; set; }

        [JsonProperty("delivery_date")]
        public DateTime DeliveryDate { get; set; }

        [JsonProperty("driver_name")]
        public string DriverName { get; set; }

        [JsonProperty("plate_number")]
        public string PlateNumber { get; set; }

        [JsonProperty("status")]
        public string Status { get; set; }

        [JsonProperty("remarks")]
        public string Remarks { get; set; }

        [JsonProperty("created_at")]
        public DateTime CreatedAt { get; set; }

        [JsonProperty("updated_at")]
        public DateTime UpdatedAt { get; set; }

        [JsonProperty("deleted_at")]
        public DateTime? DeletedAt { get; set; }


        [JsonProperty("release_id")]
        public uint ReleaseID { get; set; }

        [JsonProperty("delivery_type")]
        public string DeliveryType { get; set; }

        [JsonProperty("order")]
        public SalesOrderModel Order { get; set; }

        [JsonProperty("item_releases")]
        public List<ItemReleaseModel> ItemReleases { get; set; }

        [JsonProperty("trip_cost")]
        public TripCostModel TripCost { get; set; }
        [JsonProperty("attached_file")]
        public FileModel AttachedFile { get; set; }

    }


    public class TripCostModel : BaseModel {

        [JsonProperty("delivery_receipt_id")]
        public uint DeliveryReceiptID { get; set; }

        [JsonProperty("cost_type")]
        public string CostType { get; set; }

        [JsonProperty("total_cost")]
        public double TotalCost { get; set; }

        [JsonProperty("remarks")]
        public string Remarks { get; set; }

        [JsonProperty("vehicle_plate_no")]
        public string VehiclePlateNo { get; set; }

        [JsonProperty("driver_name")]
        public string DriverName { get; set; }

        [JsonProperty("other_expenses")]
        public double OtherExpenses { get; set; }

        [JsonProperty("delivery_receipt")]
        public DeliveryReceiptModel DeliveryReceipt { get; set; }
    }
}
