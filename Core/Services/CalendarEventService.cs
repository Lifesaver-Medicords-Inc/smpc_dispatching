using System;
using smpc_dispatching.Core.Interfaces;
using smpc_dispatching.Core.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace smpc_dispatching.Core.Services {
   public class CalendarEventService : ICalendarEventService {
        private readonly IHttpService _httpService;

        public CalendarEventService(IHttpService httpService) {
            _httpService = httpService;
        }

        public async Task<HttpResponseModel<CalendarEventModel>> CreateAsync(CalendarEventModel entity) {
            var res = await _httpService.Post<HttpResponseModel<CalendarEventModel>>("calendar-event", entity);
            return res;
        }

        public async Task<HttpResponseModel<IEnumerable<CalendarEventModel>>> GetAllAsync(Dictionary<string, string> query) {
            var queryParams = string.Empty;

            if (query != null && query.Any()) {
                queryParams = "?" + string.Join("&", query
                    .Where(kv => !string.IsNullOrWhiteSpace(kv.Value))
                    .Select(kv => $"{Uri.EscapeDataString(kv.Key)}={Uri.EscapeDataString(kv.Value)}"));
            }

            var res = await _httpService.Get<HttpResponseModel<IEnumerable<CalendarEventModel>>>($"calendar-event{queryParams}");
            return res;
        }

        public async Task<HttpResponseModel<CalendarEventModel>> GetAsync(int Id) {
            var res = await _httpService.Get<HttpResponseModel<CalendarEventModel>>($"calendar-event/{Id}");
            return res;
        }

        public async Task<HttpResponseModel<CalendarEventModel>> RemoveAsync(int Id) {
            var res = await _httpService.Delete<HttpResponseModel<CalendarEventModel>>($"calendar-event/{Id}");
            return res;
        }

        public async Task<HttpResponseModel<CalendarEventModel>> UpdateAsync(CalendarEventModel entity) {
            var res = await _httpService.Put<HttpResponseModel<CalendarEventModel>>($"calendar-event/{entity.Id}", entity);
            return res;
        }
    }
}
