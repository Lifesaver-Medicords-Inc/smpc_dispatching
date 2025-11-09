using smpc_dispatching.Core.Models;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace smpc_dispatching.Core.Interfaces {
    public interface IDrawFolderTreeService<T> {

        TreeView DrawFolderTree(List<FolderTreeModel<T>> folder, EventHandler<TreeNodeMouseClickEventArgs> onNodeClick = null);
    }
}
