using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace smpc_dispatching.Core.Models
{
    public class SetupModel
    {
        public int id { get; set; }
        public string code { get; set; }
        public string name { get; set; }
        public string ship_name { get; set; }
    }
}
