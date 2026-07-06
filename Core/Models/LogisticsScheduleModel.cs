using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace smpc_dispatching.Core.Models
{
    // Flat model matching the server's actual (unwrapped) JSON shape for a
    // Logistics calendar schedule — unlike CalendarScheduleModel<TContent>,
    // which expects a nested "content" property the server never sends.
    public class LogisticsScheduleModel
    {
        [JsonProperty("id")]
        public int Id { get; set; }

        [JsonProperty("department")]
        public string Department { get; set; } = "LOGISTICS";

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

        [JsonProperty("is_external")]
        public bool IsExternal { get; set; }

        [JsonProperty("reference_doc_no")]
        public string ReferenceDocNo { get; set; }

        [JsonProperty("sales_order_id")]
        public int SalesOrderId { get; set; }

        [JsonProperty("delivery_receipt_doc_no")]
        public string DeliveryReceiptDocNo { get; set; }

        [JsonProperty("delivery_receipt_id")]
        public int DeliveryReceiptId { get; set; }

        [JsonProperty("sales_invoice_doc_no")]
        public string SalesInvoiceDocNo { get; set; }

        [JsonProperty("category")]
        public string Category { get; set; }

        [JsonProperty("client_supplier")]
        public string ClientSupplier { get; set; }

        [JsonProperty("driver_name")]
        public string DriverName { get; set; }

        [JsonProperty("vehicle_id")]
        public int VehicleId { get; set; }

        [JsonProperty("trucking")]
        public string Trucking { get; set; }

        [JsonProperty("courier")]
        public string Courier { get; set; }

        [JsonProperty("pickup_time")]
        public string PickupTime { get; set; }

        [JsonProperty("arrival_time")]
        public string ArrivalTime { get; set; }

        [JsonProperty("routes")]
        public List<LogisticsRouteModel> Routes { get; set; } = new List<LogisticsRouteModel>();
    }

    public class LogisticsRouteModel
    {
        [JsonProperty("id")]
        public int Id { get; set; }

        [JsonProperty("schedule_id")]
        public int ScheduleId { get; set; }

        [JsonProperty("sort_order")]
        public int SortOrder { get; set; }

        [JsonProperty("ship_type")]
        public string ShipType { get; set; }

        [JsonProperty("reference_doc")]
        public string ReferenceDoc { get; set; }

        [JsonProperty("delivery_receipt_doc")]
        public string DeliveryReceiptDoc { get; set; }

        [JsonProperty("sales_invoice_doc")]
        public string SalesInvoiceDoc { get; set; }

        [JsonProperty("client_supplier")]
        public string ClientSupplier { get; set; }

        [JsonProperty("location")]
        public string Location { get; set; }

        [JsonProperty("receiver")]
        public string Receiver { get; set; }

        [JsonProperty("contact_no")]
        public string ContactNo { get; set; }

        [JsonProperty("departed_at")]
        public string DepartedAt { get; set; }

        [JsonProperty("arrived_at")]
        public string ArrivedAt { get; set; }

        [JsonProperty("returned_at")]
        public string ReturnedAt { get; set; }

        [JsonProperty("notes")]
        public string Notes { get; set; }

        [JsonProperty("costs")]
        public List<LogisticsRouteCostModel> Costs { get; set; } = new List<LogisticsRouteCostModel>();
    }

    public class LogisticsRouteCostModel
    {
        [JsonProperty("id")]
        public int Id { get; set; }

        [JsonProperty("route_id")]
        public int RouteId { get; set; }

        [JsonProperty("cost_type")]
        public string CostType { get; set; }

        [JsonProperty("description")]
        public string Description { get; set; }

        [JsonProperty("multiplier")]
        public decimal Multiplier { get; set; }

        [JsonProperty("amount")]
        public decimal Amount { get; set; }

        [JsonProperty("receipt_path")]
        public string ReceiptPath { get; set; }
    }
}
