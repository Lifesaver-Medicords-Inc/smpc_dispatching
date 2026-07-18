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
using System.Linq;
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

            // Catch anything raised on the UI thread once the message loop is
            // pumping (event handlers, etc.) and log + show it instead of
            // letting the app die invisibly.
            Application.ThreadException += (sender, e) => {
                TryLogFatal(e.Exception);
                MessageBox.Show(e.Exception.ToString(), "Unexpected error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            };
            // Catch anything raised off the UI thread, or before the message
            // loop starts, that isn't otherwise caught below.
            AppDomain.CurrentDomain.UnhandledException += (sender, e) => {
                var ex = e.ExceptionObject as Exception;
                TryLogFatal(ex);
                MessageBox.Show(ex?.ToString() ?? e.ExceptionObject?.ToString(),
                    "Fatal error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            };
            Application.SetUnhandledExceptionMode(UnhandledExceptionMode.CatchException);

            try {
                LoggerConfig.Configure();

                // Environment is controlled by the <add key="Environment" .../> setting
                // in App.config. Switch it to "Development" or "Production" there before
                // publishing/deploying. Defaults to "Production" (fail-safe) if missing
                // or blank, so a forgotten/removed setting can't silently point a
                // deployed build at a developer's local API.
                var env = System.Configuration.ConfigurationManager.AppSettings["Environment"];
                if (string.IsNullOrWhiteSpace(env)) {
                    env = "Production";
                }

                // Build configuration. Under ClickOnce, "data files" (which VS can
                // auto-classify certain content files as, shown as "Included (Auto)"
                // in the Application Files dialog) are installed into a separate,
                // persistent Data Directory rather than next to the .exe. So the
                // config file may legitimately live in either location depending on
                // how ClickOnce chose to classify it - check both.
                var fileName = $"appsettings.{env}.json";
                var candidateDirs = new System.Collections.Generic.List<string> {
                    AppDomain.CurrentDomain.BaseDirectory
                };
                try {
                    if (System.Deployment.Application.ApplicationDeployment.IsNetworkDeployed) {
                        var dataDir = System.Deployment.Application.ApplicationDeployment.CurrentDeployment.DataDirectory;
                        if (!string.IsNullOrWhiteSpace(dataDir)) {
                            candidateDirs.Add(dataDir);
                        }
                    }
                } catch {
                    // Not running under ClickOnce (e.g. Debug/F5) - ignore.
                }

                var baseDir = candidateDirs.FirstOrDefault(d =>
                    System.IO.File.Exists(System.IO.Path.Combine(d, fileName))) ?? candidateDirs[0];

                Configuration = new ConfigurationBuilder()
                   .SetBasePath(baseDir)
                   .AddJsonFile(fileName, optional: true, reloadOnChange: true)
                   .AddEnvironmentVariables()
                   .Build();

                // Fail loud, with every path checked, instead of letting a
                // missing/undeployed config file surface later as a cryptic null
                // reference deep inside DI-resolved services.
                if (string.IsNullOrWhiteSpace(Configuration["AppSettings:ApiBaseUrl"])) {
                    var checkedPaths = string.Join("\n", candidateDirs.Select(d =>
                        $"  {System.IO.Path.Combine(d, fileName)} (exists: {System.IO.File.Exists(System.IO.Path.Combine(d, fileName))})"));
                    throw new InvalidOperationException(
                        "AppSettings:ApiBaseUrl could not be loaded.\n" +
                        $"Environment (from App.config): \"{env}\"\n" +
                        $"Checked:\n{checkedPaths}\n" +
                        "If none exist, this file was not deployed - check the ClickOnce " +
                        "\"Application Files\" publish settings. If one exists, check its " +
                        "JSON structure matches { \"AppSettings\": { \"ApiBaseUrl\": \"...\" } }.");
                }

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
            } catch (Exception ex) {
                // Startup failed before (or while) the message loop could take
                // over - without this, the process would just exit and the
                // app would appear to "not open" with no explanation.
                TryLogFatal(ex);
                MessageBox.Show(ex.ToString(), "Failed to start",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private static void TryLogFatal(Exception ex) {
            try {
                Serilog.Log.Logger?.Fatal(ex, "Unhandled exception");
            } catch {
                // Logging itself must never throw out of a crash handler.
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
            services.AddScoped<IReceiptUploadService, ReceiptUploadService>();
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
