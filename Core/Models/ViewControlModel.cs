using System;
using System.Windows.Forms;

namespace smpc_dispatching.Core.Models {
    public class ViewControlModel {
        public string Code { get; set; }
        public string Parent { get; set; }
        public string Title { get; set; }

        // Lazy factory for creating UserControl
        public Func<UserControl> ViewFactory { get; set; }

        // Optional: If you need to cache one instance per session, you can keep:
        public UserControl CachedView { get; set; }
    }
}
