using Microsoft.Reporting.WinForms;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace smpc_dispatching.Core.Interfaces
{
    public interface IReportProvider
    {
        string ReportPath { get; }
        Task InitializeAsync();
        IEnumerable<ReportDataSource> GetDataSources();

        IEnumerable<ReportParameter> GetParameters();
    }
}
