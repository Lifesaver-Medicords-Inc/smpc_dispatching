using Microsoft.Extensions.DependencyInjection;
using smpc_dispatching.Core.Interfaces;
using smpc_dispatching.Core.Models;
using smpc_dispatching.UI.Views.Engineering;
using smpc_dispatching.UI.Views.Logistics;
using smpc_dispatching.UI.Views.Sales;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace smpc_dispatching.Core.Services {

    public class RouteService : IRouteService {


        private readonly IServiceProvider _serviceProvider;

        private readonly Dictionary<string, ViewControlModel> _pages = new Dictionary<string, ViewControlModel>();
        private string _selectedCode;

        public RouteService(IServiceProvider serviceProvider) {
            _serviceProvider = serviceProvider ?? throw new ArgumentNullException(nameof(serviceProvider));
            RegisterRoutes();
        }

        /// <summary>
        /// Registers all forms or user controls used for navigation.
        /// </summary>
        private void RegisterRoutes() {
            // Example routes — replace these with your actual forms

            _pages["SALES_CALENDAR"] = new ViewControlModel {
                Code = "SALES_CALENDAR",
                Parent = null,
                Title = "Sales Calendar",
                View = _serviceProvider.GetRequiredService<SalesViewUserControl>(),
            };

            _pages["ENGINEERING_CALENDAR"] = new ViewControlModel {
                Code = "ENGINEERING_CALENDAR",
                Parent = null,
                Title = "Engineering Calendar",
                View = _serviceProvider.GetRequiredService<EngineeringViewUserControl>(),
            };

            _pages["LOGISTICS_CALENDAR"] = new ViewControlModel {
                Code = "LOGISTICS_CALENDAR",
                Parent = null,
                Title = "Logistics Calendar",
                View = _serviceProvider.GetRequiredService<LogisticsViewUserControl>(),
            };

        }

        // --- Public Methods ---

        public Dictionary<string, ViewControlModel> GetAllRoutes() => _pages;

        public Control GetForm(string code) {
            return _pages.TryGetValue(code, out var page)
                ? page.View
                : null;
        }

        public string GetTitle(string code) {
            return _pages.TryGetValue(code, out var page)
                ? page.Title
                : string.Empty;
        }

        public IEnumerable<string> GetParents() {
            return _pages.Values
                .Select(p => p.Parent)
                .Distinct();
        }

        public IEnumerable<ViewControlModel> GetChildren(string parent) {
            return _pages.Values
                .Where(p => p.Parent == parent);
        }

        public void SelectRoute(string code) {
            _selectedCode = code;
        }

        public string GetTitle() {
            if (string.IsNullOrEmpty(_selectedCode)) return string.Empty;
            return GetTitle(_selectedCode);
        }

        public Control GetForm() {
            if (string.IsNullOrEmpty(_selectedCode)) return null;
            return GetForm(_selectedCode);
        }
    }
}
