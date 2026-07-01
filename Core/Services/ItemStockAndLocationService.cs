using smpc_dispatching.Core.Interfaces;
using smpc_dispatching.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace smpc_dispatching.Core.Services
{
    public class ItemStockAndLocationService : IItemStockAndLocationService<ItemStockAndLocationModel>
    {
        private readonly IHttpService _httpService;

        public ItemStockAndLocationService(IHttpService httpService)
        {
            _httpService = httpService;
        }

        public async Task<HttpResponseModel<List<ItemStockAndLocationModel>>> GetAsync(int itemId)
        {
            return await _httpService.Get<HttpResponseModel<List<ItemStockAndLocationModel>>>($"/api/item-releases/item-stock-and-locations/{itemId}");
        }
    }
}
