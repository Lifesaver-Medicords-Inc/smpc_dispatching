using Microsoft.Reporting.WinForms;
using smpc_dispatching.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace smpc_dispatching.UI.Shared
{
    public partial class PrintPreview : Form
    {
        public PrintPreview(string reportPath, List<ReportDataSource> dataSources,
        List<ReportParameter> parameters = null)
        {
            InitializeComponent();

            reportViewer1.LocalReport.ReportPath = reportPath;
            reportViewer1.LocalReport.DataSources.Clear();

            foreach (var ds in dataSources)
                reportViewer1.LocalReport.DataSources.Add(ds);

            if (parameters?.Count > 0)
                reportViewer1.LocalReport.SetParameters(parameters);

            reportViewer1.ZoomMode = ZoomMode.PageWidth;
            reportViewer1.RefreshReport();
        }

        public void ExportPdf(string path)
        {
            byte[] pdf = reportViewer1.LocalReport.Render("PDF");
            File.WriteAllBytes(path, pdf);
        }
    }
}
