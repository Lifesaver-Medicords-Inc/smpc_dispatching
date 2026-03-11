

using smpc_dispatching.Core.Interfaces;
using smpc_dispatching.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace smpc_dispatching.Core.Services {
    public class ItemReleaseService : IItemReleaseService {
        private readonly IHttpService _httpService;

        public ItemReleaseService(IHttpService httpService) {
            _httpService = httpService;
        }


        public async Task<HttpResponseModel<ItemReleaseModel>> CreateAsync(ItemReleaseModel entity) {
            var res = await _httpService.Post<HttpResponseModel<ItemReleaseModel>>("item-releases", entity);
            return res;
        }

        public async Task<HttpResponseModel<IEnumerable<ItemReleaseModel>>> GetAllAsync(Dictionary<string, string> query) {
            var queryParams = string.Empty;

            if (query != null && query.Any()) {
                queryParams = "?" + string.Join("&", query
                    .Where(kv => !string.IsNullOrWhiteSpace(kv.Value))
                    .Select(kv => $"{Uri.EscapeDataString(kv.Key)}={Uri.EscapeDataString(kv.Value)}"));
            }

            var res = await _httpService.Get<HttpResponseModel<IEnumerable<ItemReleaseModel>>>($"item-releases{queryParams}");
            return res;
        }

        public async Task<HttpResponseModel<ItemReleaseModel>> GetAsync(int Id) {
            var res = await _httpService.Get<HttpResponseModel<ItemReleaseModel>>($"item-releases/{Id}");
            return res;
        }

        public async Task<HttpResponseModel<ItemReleaseModel>> RemoveAsync(int Id) {
            var res = await _httpService.Delete<HttpResponseModel<ItemReleaseModel>>($"item-releases/{Id}");
            return res;
        }

        public async Task<HttpResponseModel<ItemReleaseModel>> UpdateAsync(ItemReleaseModel entity) {
            var res = await _httpService.Put<HttpResponseModel<ItemReleaseModel>>($"item-releases/{entity.id}", entity);
            return res;
        }
    }
}
