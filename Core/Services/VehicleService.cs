using smpc_dispatching.Core.Interfaces;
using smpc_dispatching.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace smpc_dispatching.Core.Services
{
    class VehicleService : IVehicleService
    {
        private readonly IHttpService _httpService;

        public VehicleService(IHttpService httpService)
        {
            _httpService = httpService;
        }
        public async Task<HttpResponseModel<VehicleModel>> CreateAsync(VehicleModel entity)
        {
            var res = await _httpService.Post<HttpResponseModel<VehicleModel>>("vehicles", entity);
            return res;
        }

        public async Task<HttpResponseModel<IEnumerable<VehicleModel>>> GetAllAsync(Dictionary<string, string> query)
        {
            var queryParams = string.Empty;

            if (query != null && query.Any())
            {
                queryParams = "?" + string.Join("&", query
                    .Where(kv => !string.IsNullOrWhiteSpace(kv.Value))
                    .Select(kv => $"{Uri.EscapeDataString(kv.Key)}={Uri.EscapeDataString(kv.Value)}"));
            }

            var res = await _httpService.Get<HttpResponseModel<IEnumerable<VehicleModel>>>($"vehicles{queryParams}");
            return res;
        }

        public async Task<HttpResponseModel<VehicleModel>> GetAsync(int Id)
        {
            var res = await _httpService.Get<HttpResponseModel<VehicleModel>>($"vehicles/{Id}");
            return res;
        }

        public async Task<HttpResponseModel<VehicleModel>> RemoveAsync(int Id)
        {
            var res = await _httpService.Delete<HttpResponseModel<VehicleModel>>($"vehicles/{Id}");
            return res;
        }

        public async Task<HttpResponseModel<VehicleModel>> UpdateAsync(VehicleModel entity)
        {
            var res = await _httpService.Put<HttpResponseModel<VehicleModel>>($"vehicles/{entity.Id}", entity);
            return res;
        }
    }
}

