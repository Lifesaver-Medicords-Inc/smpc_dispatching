using Microsoft.Reporting.WinForms;
using smpc_dispatching.UI.Shared;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace smpc_dispatching.Core.Services
{
    public class PrintService
    {
        public void Show(string reportPath, List<ReportDataSource> dataSources,
        List<ReportParameter> parameters = null)
        {
            if (!File.Exists(reportPath))
            {
                Console.WriteLine("REPORT PATH"+reportPath);
                MessageBox.Show("RDLC not found:\n" + reportPath, "Print Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;

            }

            using (var preview = new PrintPreview(reportPath, dataSources, parameters))
                preview.ShowDialog();
        }

        public void Export(string reportPath, List<ReportDataSource> dataSources,
            string outputPath, List<ReportParameter> parameters = null)
        {
            if (!File.Exists(reportPath))
            {
                MessageBox.Show("RDLC not found:\n" + reportPath, "Export Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            using (var preview = new PrintPreview(reportPath, dataSources, parameters))
                preview.ExportPdf(outputPath);
        }
    }
}
