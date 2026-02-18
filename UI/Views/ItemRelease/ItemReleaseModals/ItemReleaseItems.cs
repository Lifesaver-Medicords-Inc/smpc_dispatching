using smpc_dispatching.Core.Helpers;
using smpc_dispatching.Core.Models;
using smpc_dispatching.Core.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.Extensions.DependencyInjection;
using smpc_dispatching.Core.Interfaces;

namespace smpc_dispatching.UI.Views.ItemRelease.ItemReleaseModals
{
    public partial class ItemReleaseItems : Form
    {
        public ItemListModel SelectedItem { get; private set; }
        private readonly IItemListService<ItemListModel> _itemListService;
        private string placeHolderText = "Item List Search...";
        private static class ItemDGV
        {
            public const string ItemId = "item_id";
            public const string ItemName = "general_name";
            public const string ItemCode = "item_code";
            public const string ItemModel = "item_model";
            public const string Description = "short_desc";
            public const string UomName = "uom_name";
            public const string Price = "price";
        };
        public ItemReleaseItems(IServiceProvider serviceProvider)
        {
            InitializeComponent();
            _itemListService = serviceProvider.GetRequiredService<IItemListService<ItemListModel>>();
            this.StartPosition = FormStartPosition.CenterParent;

            // Set properties programatically
            dgv_all_item.AutoGenerateColumns = false;
            dgv_all_item.ReadOnly = true;
            dgv_all_item.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            
        }

        private async void ItemReleaseItems_Load(object sender, EventArgs e)
        {
            try
            {
                Helpers.Loading.ShowLoading(dgv_all_item, "Fetching data...");
                await LoadItemLists();
            }
            catch (Exception ex)
            {
                Helpers.ShowDialogMessage("error", $"Failed to load: {ex.Message}");
            }
            finally
            {
                Helpers.Loading.HideLoading(dgv_all_item);
            }
        }
        private async Task LoadItemLists()
        {
            var response = await _itemListService.GetAllAsync(null);

            if (response?.Data == null)
            {
                dgv_all_item.DataSource = null;
                Helpers.ShowDialogMessage("error", "No items found.");
                return;
            }

            var list = response.Data.ToList();

            if (!list.Any())
            {
                dgv_all_item.DataSource = null;
                Helpers.ShowDialogMessage("error", "No items found.");
                return;
            }

            DataTable dt = Helpers.ToDataTable(list);

            dgv_all_item.AutoGenerateColumns = true;
            dgv_all_item.DataSource = dt;
        }
        private void dgv_all_item_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return; // Ignore header row

            DataGridViewRow row = dgv_all_item.Rows[e.RowIndex];

            SelectedItem = new ItemListModel
            {
                item_id = Convert.ToInt32(row.Cells[ItemDGV.ItemId].Value),
                general_name = row.Cells[ItemDGV.ItemName].Value.ToString(),
                short_desc = row.Cells[ItemDGV.Description].Value.ToString(),
                uom_name = row.Cells[ItemDGV.UomName].Value.ToString(),
            };

            this.DialogResult = DialogResult.OK;
            this.Close();
        }
    }
}
