using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace smpc_dispatching.Core.Models {
    public class DeliveryReceiptModel {

        public int id { get; set; }
        public int customer_id { get; set; }
        public string customer_code { get; set; }
        public string customer_name { get; set; }
        public string address { get; set; }
        public string tin_no { get; set; }
        public int? ship_type_id { get; set; }
        public string deliver_to { get; set; }
        public string ship_via { get; set; }
        public string payment_terms { get; set; }
        public string att { get; set; }
        public string date { get; set; }
        public string delivery_date { get; set; }
        public int doc_no { get; set; }
        public int? sales_order_id { get; set; }
        public int? item_release_id { get; set; }
        public string sales_executive { get; set; }
        public List<DeliveryReceiptItemModel> delivery_receipt_items { get; set; }
        public List<DeliveryReceiptCostModel> delivery_receipt_costs { get; set; }
    }
}
