using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace smpc_dispatching.Core.Models
{
    public class ItemListModel
    {
        public uint item_id { get; set; }
        public string short_desc { get; set; }
        public string item_code { get; set; }
        public string general_name { get; set; }
        public string item_model { get; set; }
        public string uom_name { get; set; }
        public string size { get; set; }
    }
    public class ItemStockAndLocationModel
    {
        public uint item_id { get; set; }
        public string bin_location { get; set; }
        public int stock_qty { get; set; }
        public string stock_uom { get; set; }
        public uint warehouse_id { get; set; }
    }
}
