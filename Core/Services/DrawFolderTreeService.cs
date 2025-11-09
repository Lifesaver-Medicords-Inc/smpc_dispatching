using smpc_dispatching.Core.Interfaces;
using smpc_dispatching.Core.Models;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace smpc_dispatching.Core.Services {
    public class DrawFolderTreeService<T> : IDrawFolderTreeService<T> {

        private readonly ImageList _treeViewImageList = new ImageList();
        private readonly TreeView _folderTreeView = new TreeView();
        private readonly Action<FolderTreeModel<T>> _onNodeClick;
        public DrawFolderTreeService() {
            string iconsPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Icons");


            string folderIcon = Path.Combine(iconsPath, "folder.png");
            string folderOpenIcon = Path.Combine(iconsPath, "folder_open.png");
            string fileIcon = Path.Combine(iconsPath, "file.png");

            if (File.Exists(folderIcon))
                _treeViewImageList.Images.Add("folder", Image.FromFile(folderIcon));
            if (File.Exists(folderOpenIcon))
                _treeViewImageList.Images.Add("open", Image.FromFile(folderOpenIcon));
            if (File.Exists(fileIcon))
                _treeViewImageList.Images.Add("file", Image.FromFile(fileIcon));

            _treeViewImageList.ImageSize = new Size(24, 24);

        }


        public TreeView DrawFolderTree(List<FolderTreeModel<T>> folders, EventHandler<TreeNodeMouseClickEventArgs> onNodeClick = null) {

            _folderTreeView.Dock = DockStyle.Fill;
            _folderTreeView.Padding = new System.Windows.Forms.Padding(10);
            _folderTreeView.BorderStyle = BorderStyle.None;
            _folderTreeView.BackColor = Color.WhiteSmoke;
            _folderTreeView.ImageList = _treeViewImageList;
            _folderTreeView.Font = new Font("Segoe UI", 10, FontStyle.Regular);
            _folderTreeView.BeforeExpand += FolderTreeView_BeforeExpand;
            _folderTreeView.BeforeCollapse += FolderTreeView_BeforeCollapse;
            _folderTreeView.NodeMouseClick += FolderTreeView_NodeMouseClick;


            if (onNodeClick != null) {
                _folderTreeView.NodeMouseClick += new TreeNodeMouseClickEventHandler(onNodeClick);
            }

            _folderTreeView.Nodes.Clear();

            foreach (var folder in folders) {
                TreeNode node = CreateNode(folder);
                _folderTreeView.Nodes.Add(node);
            }

            return _folderTreeView;
        }

        private TreeNode CreateNode(FolderTreeModel<T> model) {
            TreeNode node = new TreeNode(model.Name) {
                ImageKey = model.IsFolder ? "folder" : "file",
                SelectedImageKey = model.IsFolder ? "open" : "file",
                Tag = model
            };

            if (model.Children != null && model.Children.Count > 0) {
                foreach (var child in model.Children) {
                    node.Nodes.Add(CreateNode(child));
                }
            }

            return node;
        }

        private void FolderTreeView_BeforeExpand(object sender, TreeViewCancelEventArgs e) {
            e.Node.ImageKey = "open";
            e.Node.SelectedImageKey = "open";
        }

        private void FolderTreeView_BeforeCollapse(object sender, TreeViewCancelEventArgs e) {
            e.Node.ImageKey = "folder";
            e.Node.SelectedImageKey = "folder";
        }

        private void FolderTreeView_NodeMouseClick(object sender, TreeNodeMouseClickEventArgs e) {
            if (e.Node.Tag is FolderTreeModel<T> model) {
                _onNodeClick?.Invoke(model);
            }
        }

    }
}
