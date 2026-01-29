using smpc_dispatching.Core.Interfaces;
using smpc_dispatching.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace smpc_dispatching.Core.Services {
    public class CalendarScheduleService<TContent> : ICalendarScheduleService<TContent>
    {
        private readonly IHttpService _httpService;

        public CalendarScheduleService(IHttpService httpService)
        {
            _httpService = httpService;
        }

        public Task<HttpResponseModel<CalendarScheduleModel<TContent>>> CreateAsync(CalendarScheduleModel<TContent> entity)
        {
            return _httpService.Post<HttpResponseModel<CalendarScheduleModel<TContent>>>("calendar-schedules", entity);
        }

        public Task<HttpResponseModel<IEnumerable<CalendarScheduleModel<TContent>>>> GetAllAsync(Dictionary<string, string> query)
        {
            var queryParams = string.Empty;

            if (query != null && query.Any())
            {
                queryParams = "?" + string.Join("&", query
                    .Where(kv => !string.IsNullOrWhiteSpace(kv.Value))
                    .Select(kv => $"{Uri.EscapeDataString(kv.Key)}={Uri.EscapeDataString(kv.Value)}"));
            }

            return _httpService.Get<HttpResponseModel<IEnumerable<CalendarScheduleModel<TContent>>>>($"calendar-schedules{queryParams}");
        }

        public Task<HttpResponseModel<CalendarScheduleModel<TContent>>> GetAsync(int Id)
        {
            return _httpService.Get<HttpResponseModel<CalendarScheduleModel<TContent>>>($"calendar-schedules/{Id}");
        }

        public Task<HttpResponseModel<CalendarScheduleModel<TContent>>> UpdateAsync(CalendarScheduleModel<TContent> entity)
        {
            return _httpService.Put<HttpResponseModel<CalendarScheduleModel<TContent>>>($"calendar-schedules/{entity.Id}", entity);
        }

        public Task<HttpResponseModel<CalendarScheduleModel<TContent>>> RemoveAsync(string department, int Id)
        {
            return _httpService.Delete<HttpResponseModel<CalendarScheduleModel<TContent>>>($"calendar-schedules/{department}/{Id}");
        }
    }

}
