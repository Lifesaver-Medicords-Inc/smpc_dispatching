using System;
using System.Windows.Forms;

namespace smpc_dispatching.Core.Models {
    public class ViewControlModel {
        public string Code { get; set; }
        public string Parent { get; set; }
        public string Title { get; set; }

        // Lazy factory for creating the view. Returns a UserControl to be docked
        // into a tab, or a Form (e.g. SetupModal) to be shown as a dialog.
        public Func<Control> ViewFactory { get; set; }

        // Optional: If you need to cache one instance per session, you can keep:
        public UserControl CachedView { get; set; }
    }
}
