using Newtonsoft.Json;

namespace smpc_dispatching.Core.Models {
    public class ItemModel : BaseModel {

        [JsonProperty("item_name_id")]
        public string Name { get; set; }

        [JsonProperty("item_class_id")]
        public string ItemClassID { get; set; }

        [JsonProperty("item_brand_id")]
        public string ItemBrandID { get; set; }

        [JsonProperty("item_description")]
        public string Description { get; set; }

        [JsonProperty("unit_of_measure_id")]
        public string UnitOfMeaserID { get; set; }

        [JsonProperty("item_model")]
        public string ModelItem { get; set; }

        [JsonProperty("catalogue_year")]
        public string CatalogueYear { get; set; }

        [JsonProperty("item_code")]
        public string ItemCode { get; set; }

        [JsonProperty("short_desc")]
        public string ShortDesc { get; set; }

        [JsonProperty("item_tangibility_type")]
        public string ItemTangibility { get; set; }

        [JsonProperty("is_top_selling")]
        public bool IsTopSelling { get; set; }

        [JsonProperty("price")]
        public float Price { get; set; }
    }
}
