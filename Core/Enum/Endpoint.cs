using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace smpc_dispatching.Core.Enum
{
    static class Endpoint
    {
        private const string setup = "/setup/";

        public const string SHIP_TYPE = setup + "ship_type";
        public const string ITEM_LIST = setup + "/setup/item/all_item/";
        
        // DELIVERY RECEIPT
        public const string CALENDAR_SCHED = "/calendar-schedules/";
        public const string CALENDAR_CATEGORY = "/calendar-categories/";
        public const string COST_TYPE = "/calendar-cost-types/";
        public const string DR = "/delivery-receipts/";

        // ITEM RELEASE item-releases
        public const string IR = "/item-releases/";
        public const string IR_SO = "/item-releases/sales-order-details/";
        public const string IR_APPROVED = "/delivery-receipts/so-with-approved-ir/";
        public const string IRD_APPROVED = "/api/delivery-receipts/so-with-approved-ir-details/";

        // CALENDAR

        // VEHICLES
        public const string VEHICLE = "vehicles";

        // STOCK RESERVATION APPROVALS
        //
        // Deliberately NO leading "/" - HttpService's HttpClient.BaseAddress already ends
        // in ".../api/" (see appsettings' ApiBaseUrl + how IR/item-releases below is built
        // without a leading slash too), and .NET's URI combining rules treat a relative
        // reference that starts with "/" as an ABSOLUTE PATH FROM THE HOST ROOT, discarding
        // BaseAddress's own "/api" path segment entirely. That's exactly why this was
        // hitting "/inventory/item_stocks/reservations/pending" (404) instead of
        // "/api/inventory/item_stocks/reservations/pending" (the route actually registered
        // by ERP_API's InventoryRoutes, mounted under app.Group("/api") in routes/root.go).
        public const string RESERVATION_PENDING = "inventory/item_stocks/reservations/pending";
        public const string RESERVATION_APPROVE = "inventory/item_stocks/reservations/{0}/approve";
        public const string RESERVATION_REJECT = "inventory/item_stocks/reservations/{0}/reject";

    }
}
