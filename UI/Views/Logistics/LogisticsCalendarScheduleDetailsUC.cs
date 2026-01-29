using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace smpc_dispatching.UI.Views.Logistics
{
    public partial class LogisticsCalendarScheduleDetailsUC : UserControl
    {
        public string DepartmentType { get; set; } = "LOGISTICS";

        public LogisticsCalendarScheduleDetailsUC()
        {
            InitializeComponent();
        }

        public void LoadDetails(object model)
        {
            // map model to controls
        }

        public object GetDetails()
        {
            return new { };
        }
    }
}
