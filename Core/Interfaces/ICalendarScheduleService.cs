using smpc_dispatching.Core.Models;
namespace smpc_dispatching.Core.Interfaces {
    public interface ICalendarScheduleService<TContent> : IDepartmentApiService<CalendarScheduleModel<TContent>>
    {
    }

}
