using Newtonsoft.Json;
using System;


namespace smpc_dispatching.Core.Models {
    public class CalendarScheduleModel<TContent> : CalendarScheduleBase
    {
        [JsonProperty("content")]
        public TContent content { get; set; }
    }
    public class CalendarScheduleBase
    {
        [JsonProperty("id")]
        public int Id { get; set; }

        [JsonProperty("department")]
        public string Department { get; set; }

        [JsonProperty("category_id")]
        public int CategoryId { get; set; }

        [JsonProperty("start_date")]
        public DateTime StartDate { get; set; }

        [JsonProperty("end_date")]
        public DateTime EndDate { get; set; }

        [JsonProperty("title")]
        public string Title { get; set; }

        [JsonProperty("description")]
        public string Description { get; set; }

        [JsonProperty("location")]
        public string Location { get; set; }

        [JsonProperty("people")]
        public string People { get; set; }

        [JsonProperty("notes")]
        public string Notes { get; set; }
    }

    public class EngineeringCalendarScheduleContent
    {
        [JsonProperty("driver")]
        public string Driver { get; set; }

        [JsonProperty("vehicle_id")]
        public int VehicleId { get; set; }
    }

    public class LogisticsCalendarScheduleContent
    {
        [JsonProperty("reference_doc_no")]
        public string SalesOrderDocNo { get; set; }

        [JsonProperty("sales_order_id")]
        public int SalesOrderId { get; set; }

        [JsonProperty("delivery_receipt_doc_no")]
        public string DeliveryReceiptDocNo { get; set; }

        [JsonProperty("delivery_receipt_id")]
        public int DeliveryReceiptId { get; set; }

        [JsonProperty("driver_name")]
        public string DriverName { get; set; }

        [JsonProperty("vehicle_id")]
        public int VehicleId { get; set; }

        [JsonProperty("trucking")]
        public string Trucking { get; set; }

        [JsonProperty("courier")]
        public string Courier { get; set; }
    }

    public class SalesCalendarScheduleContent
    {
        [JsonProperty("reference_doc_no")]
        public string ReferenceDocNo { get; set; }

        [JsonProperty("reference_id")]
        public int ReferenceId { get; set; }
    }

    public class ScheduleGridRow
    {
        // COMMON
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public string Time { get; set; }

        // SALES
        public string Description { get; set; }

        // ENGINEERING
        public string Title { get; set; }
        public string Assigned { get; set; }

        // LOGISTICS
        public string RefDocs { get; set; }
        public string Category { get; set; }
        public string Driver { get; set; }
        public string Status { get; set; }
    }

}
