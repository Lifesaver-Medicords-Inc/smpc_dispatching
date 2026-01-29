using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace smpc_dispatching.Core.Interfaces
{
    public interface ICalendarScheduleDetails
    {
        string DepartmentType { get; set; }
        void LoadDetails(object model);
        object GetDetails();
    }
}
