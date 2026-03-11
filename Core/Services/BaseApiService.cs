using smpc_dispatching.Core.Interfaces;
using smpc_dispatching.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace smpc_dispatching.Core.Services
{
    public abstract class BaseApiService<T>: IApiService<T>
    {
        protected readonly IHttpService _httpService;
        protected readonly string _endpoint;

        protected BaseApiService(IHttpService httpService, string endpoint)
        {
            _httpService = httpService;
            _endpoint = endpoint;
        }

        public async Task<HttpResponseModel<IEnumerable<T>>> GetAllAsync(Dictionary<string, string> query)
        {
            var queryParams = string.Empty;
            if (query != null && query.Any())
                queryParams = "?" + string.Join("&", query
                    .Where(kv => !string.IsNullOrWhiteSpace(kv.Value))
                    .Select(kv => $"{Uri.EscapeDataString(kv.Key)}={Uri.EscapeDataString(kv.Value)}"));

            return await _httpService.Get<HttpResponseModel<IEnumerable<T>>>($"{_endpoint}{queryParams}");
        }

        public async Task<HttpResponseModel<T>> CreateAsync(T entity)
            => await _httpService.Post<HttpResponseModel<T>>(_endpoint, entity);

        public async Task<HttpResponseModel<T>> GetAsync(int id)
            => await _httpService.Get<HttpResponseModel<T>>($"{_endpoint}/{id}");

        public async Task<HttpResponseModel<T>> UpdateAsync(T entity)
            => await _httpService.Put<HttpResponseModel<T>>(_endpoint, entity);

        public async Task<HttpResponseModel<T>> RemoveAsync(int id)
            => await _httpService.Delete<HttpResponseModel<T>>($"{_endpoint}/{id}");
    }
}
