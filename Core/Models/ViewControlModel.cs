

using System.Windows.Forms;

namespace smpc_dispatching.Core.Models {
    public class ViewControlModel {
        public string Code { get; set; }      // Unique code for route
        public string Title { get; set; }     // Title for UI
        public string Parent { get; set; }    // Parent group (like menu category)
        public UserControl View { get; set; }     // The actual WinForm
    }
}
