

using smpc_dispatching.Core.Interfaces;
using smpc_dispatching.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace smpc_dispatching.Core.Services {
    public class SalesOrderService : ISalesOrderService {

        private readonly IHttpService _httpService;

        public SalesOrderService(IHttpService httpService) {
            _httpService = httpService;
        }


        public async Task<HttpResponseModel<SalesOrderModel>> CreateAsync(SalesOrderModel entity) {
            var res = await _httpService.Post<HttpResponseModel<SalesOrderModel>>("sales-orders", entity);
            return res;
        }

        public async Task<HttpResponseModel<IEnumerable<SalesOrderModel>>> GetAllAsync(Dictionary<string, string> query) {
            var queryParams = string.Empty;

            if (query != null && query.Any()) {
                queryParams = "?" + string.Join("&", query
                    .Where(kv => !string.IsNullOrWhiteSpace(kv.Value))
                    .Select(kv => $"{Uri.EscapeDataString(kv.Key)}={Uri.EscapeDataString(kv.Value)}"));
            }

            var res = await _httpService.Get<HttpResponseModel<IEnumerable<SalesOrderModel>>>($"sales-orders{queryParams}");
            return res;
        }

        public async Task<HttpResponseModel<SalesOrderModel>> GetAsync(int Id) {
            var res = await _httpService.Get<HttpResponseModel<SalesOrderModel>>($"sales-orders/{Id}");
            return res;
        }

        public async Task<HttpResponseModel<SalesOrderModel>> RemoveAsync(int Id) {
            var res = await _httpService.Delete<HttpResponseModel<SalesOrderModel>>($"sales-orders/{Id}");
            return res;
        }

        public async Task<HttpResponseModel<SalesOrderModel>> UpdateAsync(SalesOrderModel entity) {
            var res = await _httpService.Put<HttpResponseModel<SalesOrderModel>>($"sales-orders/{entity.Id}", entity);
            return res;
        }
    }
}
