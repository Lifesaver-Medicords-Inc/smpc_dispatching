using System.Collections.Generic;

namespace smpc_dispatching.Core.Models {
    public class FolderTreeModel<T> {
        public string Name { get; set; }
        public bool IsFolder { get; set; }
        public T Param { get; set; }
        public List<FolderTreeModel<T>> Children { get; set; }
    }
}
