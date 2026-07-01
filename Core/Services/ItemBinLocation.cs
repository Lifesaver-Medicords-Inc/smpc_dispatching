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
            var res = await _httpService.Get<HttpResponseModel<List<ItemBinLocationModel>>>($"/api/engineering/bin_location/{itemId}");
            return res;
        }
    } 
}
