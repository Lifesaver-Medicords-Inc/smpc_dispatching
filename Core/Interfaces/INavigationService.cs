
using System.Windows.Forms;

namespace smpc_dispatching.Core.Interfaces {
    public interface INavigationService {
        void Initialize(TreeView treeView, Panel contentPanel);
        void BuildNavigation();
    }
}
