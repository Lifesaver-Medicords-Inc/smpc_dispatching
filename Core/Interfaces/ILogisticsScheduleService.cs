using smpc_dispatching.Core.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace smpc_dispatching.Core.Interfaces
{
    public interface ILogisticsScheduleService
    {
        Task<HttpResponseModel<IEnumerable<LogisticsScheduleModel>>> GetAllAsync(Dictionary<string, string> query);
        Task<HttpResponseModel<LogisticsScheduleModel>> GetByIdAsync(int id);
        Task<HttpResponseModel<LogisticsScheduleModel>> CreateAsync(LogisticsScheduleModel entity);
        Task<HttpResponseModel<LogisticsScheduleModel>> UpdateAsync(LogisticsScheduleModel entity);
        Task<HttpResponseModel<LogisticsScheduleModel>> RemoveAsync(int id);
    }
}
