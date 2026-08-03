using Newtonsoft.Json;

namespace smpc_dispatching.Core.Models
{
    // Backs GET /api/purchasing/purchase_active_po (vw_get_purchasing_active_po).
    // "Active" here means the PO still has an outstanding balance (total_amount_due > 0)
    // - i.e. open/pending, not yet fully received - matching the RED BOX mockup's
    // "INCOMING" section, which should only ever show POs still waiting on delivery.
    public class PurchasingActivePOModel
    {
        public uint id { get; set; }
        public string doc_no { get; set; }
        public string supplier_name { get; set; }
        public string total_amount_due { get; set; }

        // NOTE: despite the column name, vw_get_purchasing_active_po computes this as
        // FORMAT(DATEADD(DAY, 30, po.date), 'MM/dd/yyyy') - i.e. it is already a
        // ready-to-display EXPECTED DATE string (PO date + a fixed 30-day default lead
        // time), not the raw canvass-sheet lead time text the mockup describes ("kailan
        // darating based sa ilalagay na lead time ni purchaser sa canvass sheet ng
        // chosen supplier"). The view does not currently look up the per-supplier lead
        // time from the canvass sheet, so every PO shows the same 30-day estimate. Flagging
        // this rather than trying to re-derive a "real" per-supplier lead time client-side,
        // since that linkage isn't cleanly exposed by any existing endpoint - if a more
        // accurate expected date is needed, vw_get_purchasing_active_po is the place to fix it.
        [JsonProperty("lead_time")]
        public string ExpectedDateRaw { get; set; }
    }
}
