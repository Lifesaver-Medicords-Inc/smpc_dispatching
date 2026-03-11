
using smpc_dispatching.Core.Interfaces;
using smpc_dispatching.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace smpc_dispatching.Core.Services {
    public class DeliveryReceiptService : IDeliveryReceiptService {
        private readonly IHttpService _httpService;

        public DeliveryReceiptService(IHttpService httpService) {
            _httpService = httpService;
        }

        public async Task<HttpResponseModel<DeliveryReceiptModel>> CreateAsync(DeliveryReceiptModel entity) {
            var res = await _httpService.Post<HttpResponseModel<DeliveryReceiptModel>>("delivery-receipts", entity);
            return res;
        }

        public async Task<HttpResponseModel<IEnumerable<DeliveryReceiptModel>>> GetAllAsync(Dictionary<string, string> query) {

            var queryParams = string.Empty;

            if (query != null && query.Any()) {
                queryParams = "?" + string.Join("&", query
                    .Where(kv => !string.IsNullOrWhiteSpace(kv.Value))
                    .Select(kv => $"{Uri.EscapeDataString(kv.Key)}={Uri.EscapeDataString(kv.Value)}"));
            }

            var res = await _httpService.Get<HttpResponseModel<IEnumerable<DeliveryReceiptModel>>>($"/api/delivery-receipts{queryParams}");
            return res;
        }

        public async Task<HttpResponseModel<DeliveryReceiptModel>> GetAsync(int Id) {
            var res = await _httpService.Get<HttpResponseModel<DeliveryReceiptModel>>($"delivery-receipts/{Id}");
            return res;
        }
        public async Task<HttpResponseModel<DeliveryReceiptModel>> UpdateAsync(DeliveryReceiptModel entity) {
            var res = await _httpService.Put<HttpResponseModel<DeliveryReceiptModel>>($"delivery-receipts/{entity.id}", entity);
            return res;
        }


        public async Task<HttpResponseModel<DeliveryReceiptModel>> RemoveAsync(int Id) {
            var res = await _httpService.Delete<HttpResponseModel<DeliveryReceiptModel>>($"delivery-receipts/{Id}");
            return res;
        }

    }
}
