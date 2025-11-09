using smpc_dispatching.Core.Interfaces;
using smpc_dispatching.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace smpc_dispatching.Core.Services {
    public class CalendarScheduleService : ICalendarScheduleService {
        private readonly IHttpService _httpService;

        public CalendarScheduleService(IHttpService httpService) {
            _httpService = httpService;
        }

        public async Task<HttpResponseModel<CalendarScheduleModel>> CreateAsync(CalendarScheduleModel entity) {
            var res = await _httpService.Post<HttpResponseModel<CalendarScheduleModel>>("calendar-schedules", entity);
            return res;
        }

        public async Task<HttpResponseModel<IEnumerable<CalendarScheduleModel>>> GetAllAsync(Dictionary<string, string> query) {
            var queryParams = string.Empty;

            if (query != null && query.Any()) {
                queryParams = "?" + string.Join("&", query
                    .Where(kv => !string.IsNullOrWhiteSpace(kv.Value))
                    .Select(kv => $"{Uri.EscapeDataString(kv.Key)}={Uri.EscapeDataString(kv.Value)}"));
            }

            var res = await _httpService.Get<HttpResponseModel<IEnumerable<CalendarScheduleModel>>>($"calendar-schedules{queryParams}");
            return res;
        }

        public async Task<HttpResponseModel<CalendarScheduleModel>> GetAsync(int Id) {
            var res = await _httpService.Get<HttpResponseModel<CalendarScheduleModel>>($"calendar-schedules/{Id}");
            return res;
        }

        public async Task<HttpResponseModel<CalendarScheduleModel>> RemoveAsync(int Id) {
            var res = await _httpService.Delete<HttpResponseModel<CalendarScheduleModel>>($"calendar-schedules/{Id}");
            return res;
        }

        public async Task<HttpResponseModel<CalendarScheduleModel>> UpdateAsync(CalendarScheduleModel entity) {
            var res = await _httpService.Put<HttpResponseModel<CalendarScheduleModel>>($"calendar-schedules/{entity.Id}", entity);
            return res;
        }
    }
}
