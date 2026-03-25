using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace smpc_dispatching.Core.Enum
{
    public static class ReportPath
    {
        private static string Base =>
            Path.Combine(Application.StartupPath, "Printing");

        public static string DeliveryReceipt =>
            Path.Combine(Base, "DeliveryReceiptReport.rdlc");

        public static string ItemRelease =>
            Path.Combine(Base, "ItemReleaseReport.rdlc");
    }
}
