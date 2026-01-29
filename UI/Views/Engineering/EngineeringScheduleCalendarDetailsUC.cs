using smpc_dispatching.Core.Helpers;
using smpc_dispatching.Core.Interfaces;
using smpc_dispatching.Core.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace smpc_dispatching.UI.Views.Engineering
{
    public partial class EngineeringScheduleCalendarDetailsUC : UserControl
    {
        private readonly IServiceProvider _serviceProvider;
        private readonly ICalendarCategoryService _calendarCategoryService;
        private readonly IVehicleService _vehicleService;
        private readonly ICalendarScheduleService<SalesCalendarScheduleContent> _calendarScheduleService;
        private List<CalendarCategoryModel> _categories;
        private List<VehicleModel> _vehicles;
        public EngineeringScheduleCalendarDetailsUC(ICalendarScheduleService<SalesCalendarScheduleContent> calendarSchedule, ICalendarCategoryService calendarCategoryService, IVehicleService vehicleService, IServiceProvider serviceProvider)
        {
            InitializeComponent();
            _serviceProvider = serviceProvider;
            _calendarCategoryService = calendarCategoryService;
            _vehicleService = vehicleService;
            _calendarScheduleService = calendarSchedule;
        }

        public async Task LoadDetails(int id)
        {
            var response = await _calendarScheduleService.GetAsync(id);

            if (response == null || response.Data == null)
                return;

            DataTable dt = ConvertToDataTable(response.Data);
            Helpers.BindControls(new FlowLayoutPanel[] { flowLayoutPanel3 }, dt);
        }

        public object GetDetails()
        {
            // read controls and return model
            return new { };
        }
        private DataTable ConvertToDataTable<T>(T item)
        {
            DataTable dt = new DataTable(typeof(T).Name);

            // Get all properties
            var props = typeof(T).GetProperties(System.Reflection.BindingFlags.Public |
                                                System.Reflection.BindingFlags.Instance);

            foreach (var prop in props)
            {
                dt.Columns.Add(prop.Name, Nullable.GetUnderlyingType(prop.PropertyType) ?? prop.PropertyType);
            }

            // Create row
            var values = new object[props.Length];
            for (int i = 0; i < props.Length; i++)
            {
                values[i] = props[i].GetValue(item, null);
            }

            dt.Rows.Add(values);

            return dt;
        }
    }
}
