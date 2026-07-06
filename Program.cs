using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using smpc_dispatching.Config;
using smpc_dispatching.Core.Interfaces;
using smpc_dispatching.Core.Models;
using smpc_dispatching.Core.Services;
using smpc_dispatching.UI.Forms;
using smpc_dispatching.UI.Layout;
using smpc_dispatching.UI.Shared;
using smpc_dispatching.UI.Shared.Calendar;
using smpc_dispatching.UI.Shared.CalendarEvent;
using smpc_dispatching.UI.Views.Delivery_Receipt;
using smpc_dispatching.UI.Views.Engineering;
using smpc_dispatching.UI.Views.ItemRelease;
using smpc_dispatching.UI.Views.ItemRelease.ItemReleaseModals;
using smpc_dispatching.UI.Views.Logistics;
using smpc_dispatching.UI.Views.Sales;
using smpc_dispatching.UI.Views.SalesOrder;
using System;
using System.Globalization;
using System.Reflection;
using System.Threading;
using System.Windows.Forms;
using System.Windows.Forms.Design;

namespace smpc_dispatching {
    static class Program {

        public static IConfiguration Configuration { get; private set; }
        public static IServiceProvider ServiceProvider { get; private set; }
        
       


        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main() {

            LoggerConfig.Configure();

            // change else for Development and Production
            var env = Environment.GetEnvironmentVariable("DOTNET_ENVIRONMENT") ?? "Development";

            // Build configuration
            Configuration = new ConfigurationBuilder()
               .SetBasePath(AppDomain.CurrentDomain.BaseDirectory)
               .AddJsonFile($"appsettings.{env}.json", optional: true, reloadOnChange: true)
               .AddEnvironmentVariables()
               .Build();

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            var culture = new CultureInfo("en-PH");

            Thread.CurrentThread.CurrentCulture = culture;
            Thread.CurrentThread.CurrentUICulture = culture;

            // Create a service collection
            var services = new ServiceCollection();

            // Register your services
            ConfigureServices(services);

            // Build the provider
            using (var serviceProvider = services.BuildServiceProvider()) {
                // Resolve the startup form (with dependencies)
                var loginForm = serviceProvider.GetRequiredService<LoginForm>();
                Application.Run(loginForm);
            }
        }
        private static void ConfigureServices(ServiceCollection services) {


            services.AddSingleton<IConfiguration>(Configuration);
            services.AddSingleton<PrintService>();

            //Services
            services.AddScoped<IHttpService, HttpService>();
            services.AddScoped<IAuthService, AuthService>();
            services.AddScoped<INavigationService, NavigationService>();
            services.AddScoped<IRouteService, RouteService>();

            services.AddScoped<ICalendarScheduleService<SalesCalendarScheduleContent>, CalendarScheduleService<SalesCalendarScheduleContent>>();
            services.AddScoped<ICalendarCategoryService, CalendarCategoryService>();
            services.AddScoped<IVehicleService, VehicleService>();
            services.AddScoped<IWarehouseService, WarehouseService>();
            services.AddScoped<IUserService, UserService>();
            services.AddScoped<ILogisticsScheduleService, LogisticsScheduleService>();
            services.AddScoped<IDeliveryReceiptService, DeliveryReceiptService>();
            services.AddScoped<ISalesOrderWithApprovedIRService<SalesOrderWithApprovedIRModel>, SalesOrderWithApprovedIRService>();
            services.AddScoped<ISalesOrderWithApprovedIRDetailsService, SalesOrderWithApprovedIRDetailsService>();
            services.AddScoped<ICostTypeService<SetupModel>, CostTypeService>();
            services.AddScoped<IShipTypeService<ShipTypeModel>, ShipTypeService>();
            services.AddScoped<IItemReleaseService, ItemReleaseService>();
            services.AddScoped<IItemListService<ItemListModel>, ItemListService>();
            services.AddScoped<IItemStockAndLocationService<ItemStockAndLocationModel>, ItemStockAndLocationService>();
            services.AddScoped<ISalesOrderIRViewService<SalesOrderViewModel>, SalesOrderIRViewService>();
            services.AddScoped<ISalesOrderService, SalesOrderService>();
            services.AddScoped<IBpiService, BPIService>();
            services.AddScoped<IItemBinLocation<ItemBinLocationModel>, ItemBinLocation>();
            services.AddScoped<IHttpService, HttpService>();

            services.AddScoped<IGeoService, GeoService>();
            services.AddScoped(typeof(IDrawFolderTreeService<>), typeof(DrawFolderTreeService<>));

            //Forms
            services.AddTransient<LoginForm>();
            services.AddTransient<MainLayout>();
            services.AddTransient<ScheduleCalendarUC>();
            services.AddTransient<LogisticsViewUC>();
            services.AddTransient<EngineeringViewUC>();
            services.AddTransient<SalesViewUserControl>();
            services.AddTransient<CalendarScheduleControllerUC>();
            services.AddTransient<ScheduleListUserControl>();
            services.AddTransient<ScheduleDetailsUserControl>();
            services.AddTransient<SalesCalendarScheduleDetailsUC>();
            services.AddTransient<EngineeringScheduleCalendarDetailsUC>();
            services.AddTransient<LogisticsCalendarScheduleDetailsUC>();
            services.AddTransient<MapLocPinForm>();
            services.AddTransient<SalesOrderViewUC>();
            services.AddTransient<SalesOrderListForm>();
            services.AddTransient<ItemReleaseUC>();
            services.AddTransient<ItemReleaseItems>();
            services.AddTransient<PickActivity>();
            services.AddTransient<DeliveryReceiptUC>();
            services.AddTransient<VehicleSetupUC>();

        }
    }
}
