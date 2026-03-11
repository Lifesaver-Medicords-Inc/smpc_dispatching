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

    }
}
