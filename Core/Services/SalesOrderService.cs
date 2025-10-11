

using smpc_dispatching.Core.Interfaces;
using smpc_dispatching.Core.Models;
using System.Collections.Generic;
using System;
using System.Threading.Tasks;
using System.Linq;

namespace smpc_dispatching.Core.Services {
   public class SalesOrderService : ISalesOrderService {

        private readonly IHttpService _httpService;

        public SalesOrderService(IHttpService httpService) {
            _httpService = httpService;
        }


        public async Task<HttpResponseModel<SalesOrderModel>> CreateAsync(SalesOrderModel entity) {
            var res = await _httpService.Post<HttpResponseModel<SalesOrderModel>>("sales-order", entity);
            return res;
        }

        public async Task<HttpResponseModel<IEnumerable<SalesOrderModel>>> GetAllAsync(Dictionary<string, string> query) {
            var queryParams = string.Empty;

            if (query != null && query.Any()) {
                queryParams = "?" + string.Join("&", query
                    .Where(kv => !string.IsNullOrWhiteSpace(kv.Value))
                    .Select(kv => $"{Uri.EscapeDataString(kv.Key)}={Uri.EscapeDataString(kv.Value)}"));
            }

            var res = await _httpService.Get<HttpResponseModel<IEnumerable<SalesOrderModel>>>($"sales-order{queryParams}");
            return res;
        }

        public async Task<HttpResponseModel<SalesOrderModel>> GetAsync(int Id) {
            var res = await _httpService.Get<HttpResponseModel<SalesOrderModel>>($"sales-order/{Id}");
            return res;
        }

        public async Task<HttpResponseModel<SalesOrderModel>> RemoveAsync(int Id) {
            var res = await _httpService.Delete<HttpResponseModel<SalesOrderModel>>($"sales-order/{Id}");
            return res;
        }

        public async Task<HttpResponseModel<SalesOrderModel>> UpdateAsync(SalesOrderModel entity) {
            var res = await _httpService.Put<HttpResponseModel<SalesOrderModel>>($"sales-order/{entity.Id}", entity);
            return res;
        }
    }
}
