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
        private DataTable _itemTable;
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

            // Event Subscriptions
            txt_search.TextChanged += txt_search_TextChanged;

            // Set properties programatically
            dgv_all_item.AutoGenerateColumns = false;
            dgv_all_item.ReadOnly = true;
            dgv_all_item.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            
        }

        private async void ItemReleaseItems_Load(object sender, EventArgs e)        {
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

            if (response?.Data == null || !response.Data.Any())
            {
                dgv_all_item.DataSource = null;
                Helpers.ShowDialogMessage("error", "No items found.");
                return;
            }

            _itemTable = Helpers.ToDataTable(response.Data.ToList());

            dgv_all_item.AutoGenerateColumns = true;
            dgv_all_item.DataSource = _itemTable;
        }
        private void dgv_all_item_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return; // Ignore header row

            DataGridViewRow row = dgv_all_item.Rows[e.RowIndex];

            SelectedItem = new ItemListModel
            {
                item_id = Convert.ToUInt32(row.Cells[ItemDGV.ItemId].Value),
                general_name = row.Cells[ItemDGV.ItemName].Value.ToString(),
                short_desc = row.Cells[ItemDGV.Description].Value.ToString(),
                uom_name = row.Cells[ItemDGV.UomName].Value.ToString(),
            };

            this.DialogResult = DialogResult.OK;
            this.Close();
        }
        private void txt_search_TextChanged(object sender, EventArgs e)
        {
            if (_itemTable == null) return;

            string search = txt_search.Text.Trim().Replace("'", "''");

            DataView dv = _itemTable.DefaultView;

            if (string.IsNullOrWhiteSpace(search))
            {
                dv.RowFilter = string.Empty;
                return;
            }

            dv.RowFilter = $@"
                general_name LIKE '%{search}%' OR
                item_code LIKE '%{search}%' OR
                item_model LIKE '%{search}%' OR
                short_desc LIKE '%{search}%'
             ";
        }
    }
}
