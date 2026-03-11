using smpc_dispatching.Core.Interfaces;
using smpc_dispatching.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace smpc_dispatching.Core.Services
{
    class ShipTypeService : IShipTypeService<ShipTypeModel>
    {
        private readonly IHttpService _httpService;

        public ShipTypeService(IHttpService httpService)
        {
            _httpService = httpService;
        }
        public async Task<HttpResponseModel<IEnumerable<ShipTypeModel>>> GetAllAsync(Dictionary<string, string> query)
        {
            var queryParams = string.Empty;

            if (query != null && query.Any())
            {
                queryParams = "?" + string.Join("&", query
                    .Where(kv => !string.IsNullOrWhiteSpace(kv.Value))
                    .Select(kv => $"{Uri.EscapeDataString(kv.Key)}={Uri.EscapeDataString(kv.Value)}"));
            }

            var res = await _httpService.Get<HttpResponseModel<IEnumerable<ShipTypeModel>>>($"/api/setup/shiptype/{queryParams}");
            return res;
        }
    }
}
