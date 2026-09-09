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

        // §2.5 gives every document type a prefix - DR# for the Delivery Receipt, SO# for
        // the Sales Order it fulfils - and the house format pads to four digits: DR#0002.
        //
        // The screen already renders both that way (ComboBoxDocumentFormat, DeliveryReceiptUC
        // line 140) but the printed DR did not: the RDLC bound doc_no and sales_order_id
        // straight off this model, and both are integers, so the same receipt read "SO#0006"
        // on screen and "6" on paper.
        //
        // Formatted here rather than with a VB expression inside the .rdlc so there is one
        // implementation of the rule - FormatDocumentNo already knows not to double the
        // prefix and to render 0 as blank rather than DR#0000, and re-stating that in report
        // markup, in a second language, in two report files, is how the two drift apart.
        //
        // JsonIgnore because these are display projections, not fields: without it they
        // would be serialised into the payload on every save.
        [Newtonsoft.Json.JsonIgnore]
        public string doc_no_formatted =>
            smpc_dispatching.Core.Helpers.Helpers.ComboBoxDocumentFormatter.FormatDocumentNo("DR#", doc_no.ToString());

        [Newtonsoft.Json.JsonIgnore]
        public string sales_order_id_formatted =>
            smpc_dispatching.Core.Helpers.Helpers.ComboBoxDocumentFormatter.FormatDocumentNo("SO#", sales_order_id?.ToString());
        public List<DeliveryReceiptItemModel> delivery_receipt_items { get; set; }
        public List<DeliveryReceiptCostModel> delivery_receipt_costs { get; set; }
    }
}
