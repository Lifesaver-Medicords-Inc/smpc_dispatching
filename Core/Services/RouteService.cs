using Microsoft.Extensions.DependencyInjection;
using smpc_dispatching.Core.Interfaces;
using smpc_dispatching.Core.Models;
using smpc_dispatching.UI.Views.Engineering;
using smpc_dispatching.UI.Views.ItemRelease;
using smpc_dispatching.UI.Views.Logistics;
using smpc_dispatching.UI.Views.Sales;
using smpc_dispatching.UI.Views.SalesOrder;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace smpc_dispatching.Core.Services
{
    public class RouteService : IRouteService
    {
        private readonly IServiceProvider _serviceProvider;

        // Keep factory info, not actual UserControls
        private readonly Dictionary<string, ViewControlModel> _pages = new Dictionary<string, ViewControlModel>();
        private string _selectedCode;

        public RouteService(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider ?? throw new ArgumentNullException(nameof(serviceProvider));
            RegisterRoutes();
        }

        /// <summary>
        /// Registers route metadata (not actual control instances).
        /// </summary>
        private void RegisterRoutes()
        {
            _pages["SALES_CALENDAR"] = new ViewControlModel
            {
                Code = "SALES_CALENDAR",
                Parent = null,
                Title = "Sales Calendar",
                ViewFactory = () => _serviceProvider.GetRequiredService<SalesViewUserControl>()
            };

            _pages["ENGINEERING_CALENDAR"] = new ViewControlModel
            {
                Code = "ENGINEERING_CALENDAR",
                Parent = null,
                Title = "Engineering Calendar",
                ViewFactory = () => _serviceProvider.GetRequiredService<EngineeringViewUC>()
            };

            _pages["LOGISTICS_CALENDAR"] = new ViewControlModel
            {
                Code = "LOGISTICS_CALENDAR",
                Parent = null,
                Title = "Logistics Calendar",
                ViewFactory = () => _serviceProvider.GetRequiredService<LogisticsViewUC>()
            };

            _pages["SALES_ORDER"] = new ViewControlModel
            {
                Code = "SALES_ORDER",
                Parent = null,
                Title = "Sales Order",
                ViewFactory = () => _serviceProvider.GetRequiredService<SalesOrderViewUC>()
            };
            _pages["ITEM_RELEASE"] = new ViewControlModel
            {
                Code = "ITEM_RELEASE",
                Parent = null,
                Title = "Item Release",
                ViewFactory = () => _serviceProvider.GetRequiredService<ItemReleaseUC>()
            };
        }

        // --- Public Methods ---

        public Dictionary<string, ViewControlModel> GetAllRoutes() => _pages;

        public Control GetForm(string code)
        {
            return _pages.TryGetValue(code, out var page)
                ? page.ViewFactory?.Invoke()
                : null;
        }

        public string GetTitle(string code)
        {
            return _pages.TryGetValue(code, out var page)
                ? page.Title
                : string.Empty;
        }

        public IEnumerable<string> GetParents()
        {
            return _pages.Values
                .Select(p => p.Parent)
                .Distinct();
        }

        public IEnumerable<ViewControlModel> GetChildren(string parent)
        {
            return _pages.Values
                .Where(p => p.Parent == parent);
        }

        public void SelectRoute(string code)
        {
            _selectedCode = code;
        }

        public string GetTitle()
        {
            if (string.IsNullOrEmpty(_selectedCode)) return string.Empty;
            return GetTitle(_selectedCode);
        }

        public Control GetForm()
        {
            if (string.IsNullOrEmpty(_selectedCode)) return null;
            return GetForm(_selectedCode);
        }

        public string GetSelectedRoute()
        {
            return _selectedCode ?? string.Empty;
        }
    }
}
