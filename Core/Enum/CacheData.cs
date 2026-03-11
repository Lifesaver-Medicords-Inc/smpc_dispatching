using smpc_dispatching.Core.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace smpc_dispatching.Core.Enum
{
    public class CacheData
    {
        public static String SessionToken { get; set; } = "";
        public static UserModel CurrentUser { get; set; } = null;
    }
}
