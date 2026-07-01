using smpc_dispatching.Core.Interfaces;
using smpc_dispatching.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace smpc_dispatching.Core.Services
{
    public class BPIService : IBpiService
    {
        private readonly IHttpService _httpService;

        public BPIService(IHttpService httpService)
        {
            _httpService = httpService;
        }

        public async Task<HttpResponseModel<BPIGeneral>> GetAllAsync(Dictionary<string, string> query)
        {
            var queryParams = string.Empty;

            if (query != null && query.Any())
            {
                queryParams = "?" + string.Join("&", query
                    .Where(kv => !string.IsNullOrWhiteSpace(kv.Value))
                    .Select(kv => $"{Uri.EscapeDataString(kv.Key)}={Uri.EscapeDataString(kv.Value)}"));
            }

            return await _httpService.Get<HttpResponseModel<BPIGeneral>>($"bpi/{queryParams}");
        }
    }
}
