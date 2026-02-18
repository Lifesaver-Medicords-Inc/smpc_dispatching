using smpc_dispatching.Core.Interfaces;
using smpc_dispatching.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace smpc_dispatching.Core.Services
{
    public class ItemListService : IItemListService<ItemListModel>
    {
        private readonly IHttpService _httpService;

        public ItemListService(IHttpService httpService)
        {
            _httpService = httpService;
        }
        public async Task<HttpResponseModel<IEnumerable<ItemListModel>>> GetAllAsync(Dictionary<string, string> query)
        {
            var queryParams = string.Empty;

            if (query != null && query.Any())
            {
                queryParams = "?" + string.Join("&", query
                    .Where(kv => !string.IsNullOrWhiteSpace(kv.Value))
                    .Select(kv => $"{Uri.EscapeDataString(kv.Key)}={Uri.EscapeDataString(kv.Value)}"));
            }

            var res = await _httpService.Get<HttpResponseModel<IEnumerable<ItemListModel>>>($"/api/setup/item/all_item/{queryParams}");
            return res;
        }
    }
}
