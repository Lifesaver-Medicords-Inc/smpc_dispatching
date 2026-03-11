using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace smpc_dispatching.Core.Models
{
    public class DeliveryReceiptFileModel
    {
        public int id { get; set; }
        public int delivery_receipt_id { get; set; }
        public string file_name { get; set; }
        public string original_name { get; set; }
        public string file_path { get; set; }
        public string type { get; set; }
        public string size { get; set; }
    }
}
