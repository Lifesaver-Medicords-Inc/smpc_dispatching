

using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace smpc_dispatching.Core.Models {
    public class ItemReleaseModel : BaseModel
    {
        public string request_date { get; set; }
        public string required_date { get; set; }
        public string released_date { get; set; }
        public uint? sales_order_id { get; set; }
        public string reference_doc_no { get; set; }
        public int? doc_no { get; set; }
        public string requested_by { get; set; }
        public string received_by { get; set; }
        public string approved_by { get; set; }
        public string issued_by { get; set; }
        public bool? is_forward { get; set; }

        // Same §2.5 gap as DeliveryReceiptModel's pair, in the other dispatching report:
        // ItemReleaseReport.rdlc bound doc_no and reference_doc_no raw, so an IREL printed
        // its own number as "1" and its Sales Order as "0006" while the screen showed
        // IREL#0001 and SO#0006.
        //
        // reference_doc_no is stored already padded but unprefixed ("0006" in
        // tbl_inv_item_release), which FormatDocumentNo handles: it parses the number back
        // out and re-pads under the prefix, so the stored padding is neither doubled nor
        // trusted.
        [Newtonsoft.Json.JsonIgnore]
        public string doc_no_formatted =>
            smpc_dispatching.Core.Helpers.Helpers.ComboBoxDocumentFormatter.FormatDocumentNo("IREL#", doc_no?.ToString());

        [Newtonsoft.Json.JsonIgnore]
        public string reference_doc_no_formatted =>
            smpc_dispatching.Core.Helpers.Helpers.ComboBoxDocumentFormatter.FormatDocumentNo("SO#", reference_doc_no);

        public List<ItemReleaseDetailsModel> item_release_details { get; set; }
    }

    public class ItemReleaseDetailsModel
    {
        public uint id { get; set; }
        public uint item_release_id { get; set; }
        public uint sales_order_id { get; set; }
        public uint sales_order_details_id { get; set; }
        public uint item_id { get; set; }
        public string item_code { get; set; }
        public string item_description { get; set; }
        public uint required_qty { get; set; }
        public string required_uom { get; set; }
        public uint released_qty { get; set; }
        public string released_uom { get; set; }
        public string serial_no { get; set; }
        public string delivery_preference { get; set; }

        // Per-bin breakdown behind released_qty, from PickActivity's IssuedPerBinId -
        // ItemReleaseUC used to throw this away and keep only the summed released_qty,
        // which is why Item Release never actually deducted stock. The API now requires
        // this to sum exactly to released_qty whenever released_qty > 0.
        public List<ItemReleaseLocationModel> locations { get; set; } = new List<ItemReleaseLocationModel>();
    }

    public class ItemReleaseLocationModel
    {
        public uint item_release_details_id { get; set; }
        public uint bin_id { get; set; }
        public int selected_qty { get; set; }
    }

    public class ItemReleaseList
    {
        public List<ItemReleaseModel> item_release { get; set; }
    }
}
