using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using smpc_dispatching.Config;
using System;
using System.Windows.Forms;
using smpc_dispatching.UI.Layout;
using smpc_dispatching.Core.Services;
using smpc_dispatching.Core.Interfaces;
using smpc_dispatching.UI.Forms;
using smpc_dispatching.UI.Shared.Calendar;
using smpc_dispatching.UI.Views.Logistics;
using smpc_dispatching.UI.Views.Engineering;
using smpc_dispatching.UI.Shared.CalendarEvent;
using smpc_dispatching.UI.Views.Sales;
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

            var env = Environment.GetEnvironmentVariable("DOTNET_ENVIRONMENT") ?? "Development";

            // Build configuration
            Configuration = new ConfigurationBuilder()
               .SetBasePath(AppDomain.CurrentDomain.BaseDirectory)
               .AddJsonFile($"appsettings.{env}.json", optional: true, reloadOnChange: true)
               .AddEnvironmentVariables()
               .Build();

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);



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

            //Services
            services.AddScoped<IHttpService, HttpService>();
            services.AddScoped<IAuthService, AuthService>();
            services.AddScoped<INavigationService, NavigationService>();
            services.AddScoped<IRouteService, RouteService>();

            services.AddScoped<ICalendarEventService,CalendarEventService>();
            services.AddScoped<IDeliveryReceiptService,DeliveryReceiptService>();
            services.AddScoped<IItemReleaseService, ItemReleaseService>();
            services.AddScoped<ISalesOrderService,SalesOrderService>();

            //Forms
            services.AddTransient<LoginForm>();
            services.AddTransient<MainLayout>();
            services.AddTransient<EventCalendar>();
            services.AddTransient<LogisticsView>();
            services.AddTransient<EngineeringView>();
            services.AddTransient<CalendarCell>();
            services.AddTransient<SalesView>();
            services.AddTransient<CalendarEventController>();
        }
    }
}
