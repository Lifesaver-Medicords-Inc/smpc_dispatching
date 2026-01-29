using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace smpc_dispatching.Core.Interfaces
{
    public interface ICalendarScheduleModel
    {
        string Department { get; set; }
        string Title { get; set; }
        DateTime StartDate { get; set; }
        DateTime EndDate { get; set; }
        object Content { get; set; }
    }
}
