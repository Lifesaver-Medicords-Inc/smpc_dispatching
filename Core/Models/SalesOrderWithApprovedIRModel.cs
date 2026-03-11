using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace smpc_dispatching.Core.Models
{
    public class SalesOrderWithApprovedIRModel
    {
        public uint sales_order_id { get; set; }
        public uint customer_id { get; set; }
        public string customer_name { get; set; }
        public string customer_code { get; set; }
        public string address { get; set; }
        public uint ship_type_id { get; set; }
        public string tin_no { get; set; }
        public string sales_order_no { get; set; }
        public uint item_release_id { get; set; }
        public string item_release_no { get; set; }
        public string deliver_to { get; set; }
        public string delivery_date { get; set; }
        public string sales_executive { get; set; }
    }
    public class SalesOrderWithApprovedIRDetailsModel
    {
        [JsonProperty("item_release_id")]
        public uint items_item_release_id { get; set; }

        [JsonProperty("item_id")]
        public uint items_item_id { get; set; }

        [JsonProperty("released_qty")]
        public int items_qty { get; set; }

        [JsonProperty("released_uom")]
        public string items_unit_of_measure { get; set; } 

        [JsonProperty("item_code")]
        public string items_item_code { get; set; } 
        [JsonProperty("serial_no")]
        public string items_serial_no { get; set; } 
    }
}
