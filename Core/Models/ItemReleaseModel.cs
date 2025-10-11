

using System.Collections.Generic;

namespace smpc_dispatching.Core.Models {
    public class ItemReleaseModel {
      
            public int Id { get; set; }
            public int SalesOrderId { get; set; }
            public string RequestNumber { get; set; }
            public string RequestedBy { get; set; }
            public string ApprovedBy { get; set; }
            public string Status { get; set; }
            public string Remarks { get; set; }
            public List<ItemReleaseDetail> ReleaseItems { get; set; } = new List<ItemReleaseDetail>();
    }

    public class ItemReleaseDetail {
        public int Id { get; set; }
        public int ItemReleaseId { get; set; }
        public string ItemCode { get; set; }
        public string Description { get; set; }
        public double RequestedQty { get; set; }
        public double ReleasedQty { get; set; }
        public string Unit { get; set; }
        public string Remarks { get; set; }
        public string Status { get; set; }
    }
}
