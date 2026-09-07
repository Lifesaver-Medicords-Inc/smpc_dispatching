using smpc_dispatching.Core.Interfaces;
using smpc_dispatching.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace smpc_dispatching.Core.Services
{
    // Dispatch people (drivers / helpers) - /api/dispatch-people.
    //
    // GetAllAsync passes its query through, so a schedule picker can ask for only the
    // people it can still assign with { "active", "1" }, and optionally narrow to one
    // role with { "role", "DRIVER" }. Setup calls it with no query so it can show
    // inactive people too - they are deactivated, never deleted.
    class DispatchPersonService : IDispatchPersonService
    {
        private const string Endpoint = "dispatch-people";

        private readonly IHttpService _httpService;

        public DispatchPersonService(IHttpService httpService)
        {
            _httpService = httpService;
        }

        public async Task<HttpResponseModel<DispatchPersonModel>> CreateAsync(DispatchPersonModel entity)
        {
            return await _httpService.Post<HttpResponseModel<DispatchPersonModel>>(Endpoint, entity);
        }

        public async Task<HttpResponseModel<IEnumerable<DispatchPersonModel>>> GetAllAsync(Dictionary<string, string> query)
        {
            var queryParams = string.Empty;

            if (query != null && query.Any())
            {
                queryParams = "?" + string.Join("&", query
                    .Where(kv => !string.IsNullOrWhiteSpace(kv.Value))
                    .Select(kv => $"{Uri.EscapeDataString(kv.Key)}={Uri.EscapeDataString(kv.Value)}"));
            }

            return await _httpService.Get<HttpResponseModel<IEnumerable<DispatchPersonModel>>>($"/api/{Endpoint}{queryParams}");
        }

        public async Task<HttpResponseModel<DispatchPersonModel>> GetAsync(int Id)
        {
            return await _httpService.Get<HttpResponseModel<DispatchPersonModel>>($"{Endpoint}/{Id}");
        }

        public async Task<HttpResponseModel<DispatchPersonModel>> UpdateAsync(DispatchPersonModel entity)
        {
            return await _httpService.Put<HttpResponseModel<DispatchPersonModel>>($"{Endpoint}/{entity.id}", entity);
        }

        // The API deactivates rather than deletes - past schedules keep the person's
        // name. Named RemoveAsync only because IApiService<T> defines it that way.
        public async Task<HttpResponseModel<DispatchPersonModel>> RemoveAsync(int Id)
        {
            return await _httpService.Delete<HttpResponseModel<DispatchPersonModel>>($"{Endpoint}/{Id}");
        }
    }
}
