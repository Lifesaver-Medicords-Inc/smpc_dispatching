using smpc_dispatching.Core.Interfaces;
using smpc_dispatching.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace smpc_dispatching.Core.Services
{
    public class ItemBinLocation : IItemBinLocation<ItemBinLocationModel>
    {

        private readonly IHttpService _httpService;

        public ItemBinLocation(IHttpService httpService)
        {
            {
                _httpService = httpService;
            }
            
        }

        public async Task<HttpResponseModel<List<ItemBinLocationModel>>> GetAsync(int itemId)
        {
            // Item Release's own list: every stocked bin plus every vehicle zone, stocked or not
            // (§5.10 - the Actual Pick Qty modal "includes vehicles by default"). The engineering
            // bin_location list used before returns only bins that currently hold stock.
            var res = await _httpService.Get<HttpResponseModel<List<ItemBinLocationModel>>>($"/api/item-releases/pick-locations/{itemId}");
            return res;
        }
    } 
}
