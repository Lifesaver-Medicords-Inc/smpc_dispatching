using Newtonsoft.Json;
using System.Collections.Generic;

namespace smpc_dispatching.Core.Models {
    public class SalesOrderModel : BaseModel {
        [JsonProperty("order_id")]
        public uint OrderID { get; set; }

        [JsonProperty("ship_type_id")]
        public uint ShipTypeID { get; set; }

        [JsonProperty("bill_to_id")]
        public uint BillToID { get; set; }

        [JsonProperty("ship_to_id")]
        public uint ShipToID { get; set; }

        [JsonProperty("customer_id")]
        public uint CustomerID { get; set; }

        [JsonProperty("quotation_id")]
        public uint QuotationID { get; set; }

        [JsonProperty("payment_terms_id")]
        public uint PaymentTermsID { get; set; }

        [JsonProperty("approved_by")]
        public string ApprovedBy { get; set; }

        [JsonProperty("approved_by_id")]
        public uint ApprovedByID { get; set; }

        [JsonProperty("doc")]
        public string Doc { get; set; }

        [JsonProperty("ref_po")]
        public uint RefPO { get; set; }

        [JsonProperty("date")]
        public string Date { get; set; }

        [JsonProperty("delivery_date")]
        public string DeliveryDate { get; set; }

        [JsonProperty("document_no")]
        public string DocumentNo { get; set; }

        [JsonProperty("status")]
        public string Status { get; set; }

        [JsonProperty("receiver")]
        public string Receiver { get; set; }

        [JsonProperty("sales_executive")]
        public string SalesExecutive { get; set; }

        [JsonProperty("contact_no")]
        public string ContactNo { get; set; }

        [JsonProperty("remarks")]
        public string Remarks { get; set; }

        [JsonProperty("purchaser")]
        public string Purchaser { get; set; }

        [JsonProperty("project_name")]
        public string ProjectName { get; set; }

        [JsonProperty("gross_sales")]
        public double GrossSales { get; set; }

        [JsonProperty("vat_amount")]
        public double VatAmount { get; set; }

        [JsonProperty("total_amount_due")]
        public double TotalAmountDue { get; set; }

        [JsonProperty("customer_name")]
        public string CustomerName { get; set; }

        [JsonProperty("customer_code")]
        public string CustomerCode { get; set; }

        [JsonProperty("ship_to")]
        public string ShipTo { get; set; }

        [JsonProperty("bill_to")]
        public string BillTo { get; set; }

        [JsonProperty("tin")]
        public string Tin { get; set; }

        [JsonProperty("items")]
        public List<SalesOrderDetailsModel> Items { get; set; }

        [JsonProperty("delivery_receipts")]
        public List<DeliveryReceiptModel> DeliveryReceipts { get; set; }
    }


    public class SalesOrderDetailsModel : BaseModel {
        [JsonProperty("based_id")]
        public uint BasedId { get; set; }

        [JsonProperty("quotation_quick_id")]
        public uint QuotationQuickId { get; set; }

        [JsonProperty("item_id")]
        public uint ItemId { get; set; }

        [JsonProperty("delivery_preference")]
        public string DeliveryPreference { get; set; }

        [JsonProperty("status")]
        public string Status { get; set; }

        [JsonProperty("has_stocks")]
        public bool HasStocks { get; set; }

        [JsonProperty("qty")]
        public int Qty { get; set; }

        [JsonProperty("numbering")]
        public string Numbering { get; set; }

        [JsonProperty("item_code")]
        public string ItemCode { get; set; }

        [JsonProperty("item_description")]
        public string ItemDescription { get; set; }

        [JsonProperty("list_price")]
        public double ListPrice { get; set; }

        [JsonProperty("percent_discount")]
        public float PercentDiscount { get; set; }

        [JsonProperty("total_price")]
        public double TotalPrice { get; set; }

        [JsonProperty("allocated_qty")]
        public int? AllocatedQty { get; set; }

        [JsonProperty("order_type")]
        public string OrderType { get; set; }

        [JsonProperty("bom_id")]
        public uint BomId { get; set; }

        [JsonProperty("order")]
        public SalesOrderModel Order { get; set; }

        [JsonProperty("item")]
        public ItemModel Item { get; set; }

        [JsonProperty("releases")]
        public List<ItemReleaseModel> Releases { get; set; }
    }
}
