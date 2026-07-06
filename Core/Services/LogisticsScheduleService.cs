using smpc_dispatching.Core.Interfaces;
using smpc_dispatching.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace smpc_dispatching.Core.Services
{
    public class LogisticsScheduleService : ILogisticsScheduleService
    {
        private readonly IHttpService _httpService;

        public LogisticsScheduleService(IHttpService httpService)
        {
            _httpService = httpService;
        }

        public async Task<HttpResponseModel<IEnumerable<LogisticsScheduleModel>>> GetAllAsync(Dictionary<string, string> query)
        {
            var qp = new Dictionary<string, string>(query ?? new Dictionary<string, string>())
            {
                ["department"] = "LOGISTICS"
            };

            var queryParams = "?" + string.Join("&", qp
                .Where(kv => !string.IsNullOrWhiteSpace(kv.Value))
                .Select(kv => $"{Uri.EscapeDataString(kv.Key)}={Uri.EscapeDataString(kv.Value)}"));

            return await _httpService.Get<HttpResponseModel<IEnumerable<LogisticsScheduleModel>>>($"calendar-schedules{queryParams}");
        }

        public async Task<HttpResponseModel<LogisticsScheduleModel>> GetByIdAsync(int id)
        {
            return await _httpService.Get<HttpResponseModel<LogisticsScheduleModel>>($"calendar-schedules/{id}?department=LOGISTICS");
        }

        public async Task<HttpResponseModel<LogisticsScheduleModel>> CreateAsync(LogisticsScheduleModel entity)
        {
            entity.Department = "LOGISTICS";
            return await _httpService.Post<HttpResponseModel<LogisticsScheduleModel>>("calendar-schedules", entity);
        }

        public async Task<HttpResponseModel<LogisticsScheduleModel>> UpdateAsync(LogisticsScheduleModel entity)
        {
            entity.Department = "LOGISTICS";
            return await _httpService.Put<HttpResponseModel<LogisticsScheduleModel>>($"calendar-schedules/{entity.Id}", entity);
        }

        public async Task<HttpResponseModel<LogisticsScheduleModel>> RemoveAsync(int id)
        {
            return await _httpService.Delete<HttpResponseModel<LogisticsScheduleModel>>($"calendar-schedules/logistics/{id}");
        }
    }
}
