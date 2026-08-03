using Newtonsoft.Json;

namespace smpc_dispatching.Core.Models
{
    // Backs GET /api/purchasing/purchase_order (tbl_purchasing_purchase_order).
    // Only a subset of the full PO record is modeled here - just what the RED BOX
    // "INCOMING" cards need beyond what vw_get_purchasing_active_po already provides
    // (mainly deliver_via, the "RECEIVE VIA" field). Joined to PurchasingActivePOModel
    // client-side by id.
    public class PurchasingPurchaseOrderModel
    {
        public uint id { get; set; }

        [JsonProperty("doc_no")]
        public string DocNo { get; set; }

        [JsonProperty("supplier_name")]
        public string SupplierName { get; set; }

        [JsonProperty("date")]
        public string Date { get; set; }

        // "RECEIVE VIA" on the mockup - how the item is expected to arrive
        // (e.g. Delivery / Pick up).
        [JsonProperty("deliver_via")]
        public string DeliverVia { get; set; }
    }
}
