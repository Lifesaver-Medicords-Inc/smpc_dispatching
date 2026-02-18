

using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace smpc_dispatching.Core.Models {
    public class ItemReleaseModel : BaseModel
    {
        public uint id { get; set; }
        public string request_date { get; set; }
        public string required_date { get; set; }
        public string released_date { get; set; }
        public string reference_doc_no { get; set; }
        public string doc_no { get; set; }
        public string requested_by { get; set; }
        public string received_by { get; set; }
        public string approved_by { get; set; }
        public string issued_by { get; set; }
        public bool? is_forward { get; set; }
        public List<ItemReleaseDetailsModel> item_release_details { get; set; }
    }

    public class ItemReleaseDetailsModel
    {
        public uint id { get; set; }
        public uint item_release_id { get; set; }
        public uint sales_order_id { get; set; }
        public uint sales_order_details_id { get; set; }
        public uint item_id { get; set; }
        public string item_description { get; set; }
        public uint required_qty { get; set; }
        public string required_uom { get; set; }
        public uint released_qty { get; set; }
        public string released_uom { get; set; }
        public string serial_no { get; set; }
        public string delivery_preference { get; set; }
    }
    public class ItemReleaseList
    {
        public List<ItemReleaseModel> item_release { get; set; }
    }
}
