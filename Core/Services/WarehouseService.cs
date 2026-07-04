using smpc_dispatching.Core.Interfaces;
using smpc_dispatching.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace smpc_dispatching.Core.Services
{
    public class WarehouseService : IWarehouseService
    {
        private readonly IHttpService _httpService;

        public WarehouseService(IHttpService httpService)
        {
            _httpService = httpService;
        }

        public async Task<HttpResponseModel<IEnumerable<WarehouseModel>>> GetAllAsync(Dictionary<string, string> query)
        {
            var queryParams = string.Empty;

            if (query != null && query.Any())
            {
                queryParams = "?" + string.Join("&", query
                    .Where(kv => !string.IsNullOrWhiteSpace(kv.Value))
                    .Select(kv => $"{Uri.EscapeDataString(kv.Key)}={Uri.EscapeDataString(kv.Value)}"));
            }

            var res = await _httpService.Get<HttpResponseModel<IEnumerable<WarehouseModel>>>($"warehouses{queryParams}");
            return res;
        }
    }
}
