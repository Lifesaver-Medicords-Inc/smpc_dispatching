using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace smpc_dispatching.Core.Models
{
    public class ItemBinLocationModel
    {
        [JsonProperty("bin_id")]
        public int BinId { get; set; }

        [JsonProperty("bin_location")]
        public string BinLocation { get; set; }

        [JsonProperty("warehouse_id")]
        public int WarehouseId { get; set; }

        [JsonProperty("item_id")]
        public int ItemId { get; set; }

        [JsonProperty("stock_qty")]
        public int StockQty { get; set; }

        [JsonProperty("stock_uom")]
        public string StockUom { get; set; }

        // Set on every vehicle zone row. Vehicle rows are the only ones Item Release may take
        // below zero (§10.5), so the picker lifts its stock cap for them. BinId is 0 on a
        // vehicle that holds no stock row for this item yet; the API creates it on save.
        [JsonProperty("warehouse_area_id")]
        public int WarehouseAreaId { get; set; }

        [JsonProperty("is_vehicle")]
        public bool IsVehicle { get; set; }
    }
}
