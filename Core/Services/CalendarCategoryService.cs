using smpc_dispatching.Core.Interfaces;
using smpc_dispatching.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace smpc_dispatching.Core.Services
{
    class CalendarCategoryService : ICalendarCategoryService
    {
        private readonly IHttpService _httpService;

        public CalendarCategoryService(IHttpService httpService)
        {
            _httpService = httpService;
        }
        public async Task<HttpResponseModel<CalendarCategoryModel>> CreateAsync(CalendarCategoryModel entity)
        {
            var res = await _httpService.Post<HttpResponseModel<CalendarCategoryModel>>("calendar-categories", entity);
            return res;
        }

        public async Task<HttpResponseModel<IEnumerable<CalendarCategoryModel>>> GetAllAsync(Dictionary<string, string> query)
        {
            var queryParams = string.Empty;

            if (query != null && query.Any())
            {
                queryParams = "?" + string.Join("&", query
                    .Where(kv => !string.IsNullOrWhiteSpace(kv.Value))
                    .Select(kv => $"{Uri.EscapeDataString(kv.Key)}={Uri.EscapeDataString(kv.Value)}"));
            }

            var res = await _httpService.Get<HttpResponseModel<IEnumerable<CalendarCategoryModel>>>($"calendar-categories{queryParams}");
            return res;
        }

        public async Task<HttpResponseModel<CalendarCategoryModel>> GetAsync(int Id)
        {
            var res = await _httpService.Get<HttpResponseModel<CalendarCategoryModel>>($"calendar-categories/{Id}");
            return res;
        }

        public async Task<HttpResponseModel<CalendarCategoryModel>> RemoveAsync(int Id)
        {
            var res = await _httpService.Delete<HttpResponseModel<CalendarCategoryModel>>($"calendar-categories/{Id}");
            return res;
        }

        public async Task<HttpResponseModel<CalendarCategoryModel>> UpdateAsync(CalendarCategoryModel entity)
        {
            var res = await _httpService.Put<HttpResponseModel<CalendarCategoryModel>>($"calendar-categories/{entity.Id}", entity);
            return res;
        }
    }
}
