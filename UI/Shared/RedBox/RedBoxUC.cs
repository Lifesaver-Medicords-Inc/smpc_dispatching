using smpc_dispatching.Core.Interfaces;
using smpc_dispatching.Core.Models;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace smpc_dispatching.UI.Shared.RedBox
{
    // Warehouse "RED BOX" performance-metrics panel, mounted permanently inside
    // MainLayout's right-side red panel (innerContainer.Panel2) - see MainLayout.cs.
    // Same idea as the RedBox dashboards already in the Sales/Purchasing/Engineering
    // apps: everything shown here is DERIVED (read-only) from existing data, there is
    // no new "red box" table. Two sections, matching the mockup:
    //
    //   RELEASE  - open Item Release requests (approved, not yet fully released) that
    //              the warehouse still needs to pick/reserve/release against.
    //   INCOMING - open Purchase Orders (not yet fully received) the warehouse is
    //              waiting to receive.
    //
    // Scope note: the mockup's RELEASE examples show three different request-document
    // types feeding the warehouse queue - IREL# (item release, from the dispatcher),
    // PA#/"PURCHASE ADVICE" (from purchasing), and IREQ# (from engineering). Only the
    // IREL# flow is wired up here - it's the one this app already has a client-side
    // data source for (ISalesOrderWithApprovedIRService). Surfacing PA#/IREQ# releases
    // here would need a client service hitting the Purchasing/Engineering APIs first;
    // deliberately left out rather than guessed at.
    //
    // Read-only by design (confirmed with the requester): the mockup's checkbox
    // ("items to be reserved", uncheck = cancel reservation) and "X" (remove row) are
    // NOT wired to any write action here - those happen in the existing Item
    // Release / Purchasing screens. This panel only reflects current status.
    public partial class RedBoxUC : UserControl
    {
        private readonly ISalesOrderWithApprovedIRService<SalesOrderWithApprovedIRModel> _releaseService;
        private readonly ISalesOrderWithApprovedIRDetailsService _releaseDetailsService;
        private readonly ISalesOrderService _salesOrderService;
        private readonly IPurchasingActivePOService<PurchasingActivePOModel> _activePoService;
        private readonly IPurchasingPurchaseOrderService<PurchasingPurchaseOrderModel> _purchaseOrderService;

        public RedBoxUC(
            ISalesOrderWithApprovedIRService<SalesOrderWithApprovedIRModel> releaseService,
            ISalesOrderWithApprovedIRDetailsService releaseDetailsService,
            ISalesOrderService salesOrderService,
            IPurchasingActivePOService<PurchasingActivePOModel> activePoService,
            IPurchasingPurchaseOrderService<PurchasingPurchaseOrderModel> purchaseOrderService)
        {
            InitializeComponent();
            _releaseService = releaseService;
            _releaseDetailsService = releaseDetailsService;
            _salesOrderService = salesOrderService;
            _activePoService = activePoService;
            _purchaseOrderService = purchaseOrderService;
        }

        private class ReleaseEntry
        {
            public string ItemReleaseNoDisplay;
            public string SalesOrderNoDisplay;
            public string ClientName;
            public string ProjectName;
            public string SalesExecutive;
            public int ItemsToReserveCount;
            public DateTime? DeliveryDate;
        }

        private class IncomingEntry
        {
            public string PoNoDisplay;
            public string SupplierName;
            public string ReceiveVia;
            public DateTime? ExpectedDate;
        }

        // MainLayout resolves this control via DI and adds it to the panel only after
        // LoginForm has already succeeded (unlike the Sales app's RedBox, which has to
        // guard against loading before login because it lives on the always-visible
        // main window from the start) - so there's no login-race guard needed here;
        // this can just be called from the control's own Load event.
        private async void RedBoxUC_Load(object sender, EventArgs e)
        {
            await LoadData();
        }

        // Named after its control (btn_refresh), matching the snake_case
        // control-naming convention this event-handler follows throughout the rest of
        // the app (see e.g. SetupModal.btn_save_Click, VehicleDetailsModal.btn_save_Click) -
        // suppressing IDE1006 here rather than renaming it out of step with those.
#pragma warning disable IDE1006 // Naming Styles
        private async void btn_refresh_Click(object sender, EventArgs e)
#pragma warning restore IDE1006 // Naming Styles
        {
            await LoadData();
        }

        private async Task LoadData()
        {
            btn_refresh.Enabled = false;
            lbl_status.Text = "Loading...";
            try
            {
                var releaseTask = _releaseService.GetAllAsync(null);
                var salesOrdersTask = _salesOrderService.GetAllAsync(null);
                var activePoTask = _activePoService.GetAllAsync(null);
                var purchaseOrderTask = _purchaseOrderService.GetAllAsync(null);

                await Task.WhenAll(releaseTask, salesOrdersTask, activePoTask, purchaseOrderTask);

                var releaseEntries = await BuildReleaseEntries(releaseTask.Result?.Data, salesOrdersTask.Result?.Data);
                RenderReleaseSection(releaseEntries);

                var incomingEntries = BuildIncomingEntries(activePoTask.Result?.Data, purchaseOrderTask.Result?.Data);
                RenderIncomingSection(incomingEntries);

                lbl_status.Text = $"Updated {DateTime.Now:h:mm tt} - Release {releaseEntries.Count} / Incoming {incomingEntries.Count}";
            }
            catch (Exception ex)
            {
                lbl_status.Text = "Failed to load: " + ex.Message;
            }
            finally
            {
                btn_refresh.Enabled = true;
            }
        }

        // ------------------------------------------------------------------
        // RELEASE
        // ------------------------------------------------------------------
        //
        //  - Source: ISalesOrderWithApprovedIRService, which already scopes to
        //    approved-but-not-fully-released item releases - so no extra
        //    open/pending filtering is applied client-side here.
        //  - PROJECT NAME isn't part of that view, so it's looked up from the sales
        //    order list by sales_order_id (one bulk fetch, joined client-side).
        //  - "ITEMS TO RESERVE" = count of DISTINCT items on the release's approved
        //    IR detail lines (per the mockup note: "Count of unique items"), fetched
        //    per-row via ISalesOrderWithApprovedIRDetailsService.
        //  - Sorted soonest delivery-date first; releases with no delivery date sink
        //    to the bottom. (The mockup doesn't specify a RELEASE sort rule the way it
        //    does for INCOMING - this mirrors that rule since it's the closest
        //    equivalent "what needs attention soonest" signal available here.)
        private async Task<List<ReleaseEntry>> BuildReleaseEntries(
            IEnumerable<SalesOrderWithApprovedIRModel> releases,
            IEnumerable<SalesOrderModel> salesOrders)
        {
            var result = new List<ReleaseEntry>();
            var releaseList = releases?.ToList() ?? new List<SalesOrderWithApprovedIRModel>();
            if (releaseList.Count == 0)
                return result;

            var projectNames = new Dictionary<uint, string>();
            foreach (var order in salesOrders ?? Enumerable.Empty<SalesOrderModel>())
            {
                if (!projectNames.ContainsKey(order.OrderID))
                    projectNames[order.OrderID] = order.ProjectName;
            }

            var detailTasks = releaseList
                .Select(r => _releaseDetailsService.GetAsync((int)r.item_release_id))
                .ToList();
            var detailResults = await Task.WhenAll(detailTasks);

            for (int i = 0; i < releaseList.Count; i++)
            {
                var r = releaseList[i];
                var details = detailResults[i]?.Data ?? new List<SalesOrderWithApprovedIRDetailsModel>();
                int itemCount = details.Select(d => d.items_item_id).Distinct().Count();

                DateTime? deliveryDate = null;
                if (DateTime.TryParse(r.delivery_date, out var parsedDelivery))
                    deliveryDate = parsedDelivery;

                projectNames.TryGetValue(r.sales_order_id, out var projectName);

                result.Add(new ReleaseEntry
                {
                    ItemReleaseNoDisplay = EnsurePrefix(r.item_release_no, "IREL#"),
                    SalesOrderNoDisplay = EnsurePrefix(r.sales_order_no, "SO#"),
                    ClientName = string.IsNullOrWhiteSpace(r.customer_name) ? "-" : r.customer_name,
                    ProjectName = string.IsNullOrWhiteSpace(projectName) ? "-" : projectName,
                    SalesExecutive = string.IsNullOrWhiteSpace(r.sales_executive) ? "-" : r.sales_executive,
                    ItemsToReserveCount = itemCount,
                    DeliveryDate = deliveryDate
                });
            }

            return result
                .OrderBy(en => en.DeliveryDate ?? DateTime.MaxValue)
                .ToList();
        }

        // ------------------------------------------------------------------
        // INCOMING
        // ------------------------------------------------------------------
        //
        //  - Source: vw_get_purchasing_active_po (total_amount_due > 0, i.e. still
        //    open/pending) joined to the raw PO record by id for deliver_via
        //    ("RECEIVE VIA").
        //  - EXPECTED DATE comes from the active-PO view's "lead_time" column, which
        //    is really a pre-formatted PO-date-plus-30-days estimate (see the comment
        //    on PurchasingActivePOModel.ExpectedDateRaw) - not a genuine per-supplier
        //    canvass-sheet lead time. Left blank if it doesn't parse, per the mockup's
        //    "if walang lead time then blank ing" note.
        //  - Sorted by nearest expected date first, per the mockup.
        private List<IncomingEntry> BuildIncomingEntries(
            IEnumerable<PurchasingActivePOModel> activePos,
            IEnumerable<PurchasingPurchaseOrderModel> purchaseOrders)
        {
            var result = new List<IncomingEntry>();
            var activeList = activePos?.ToList() ?? new List<PurchasingActivePOModel>();
            if (activeList.Count == 0)
                return result;

            var poById = new Dictionary<uint, PurchasingPurchaseOrderModel>();
            foreach (var po in purchaseOrders ?? Enumerable.Empty<PurchasingPurchaseOrderModel>())
            {
                if (!poById.ContainsKey(po.id))
                    poById[po.id] = po;
            }

            foreach (var active in activeList)
            {
                poById.TryGetValue(active.id, out var matchedPo);

                DateTime? expectedDate = null;
                if (DateTime.TryParseExact(active.ExpectedDateRaw, "MM/dd/yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out var exact))
                    expectedDate = exact;
                else if (DateTime.TryParse(active.ExpectedDateRaw, out var loose))
                    expectedDate = loose;

                result.Add(new IncomingEntry
                {
                    PoNoDisplay = EnsurePrefix(active.doc_no, "PO#"),
                    SupplierName = string.IsNullOrWhiteSpace(active.supplier_name) ? "-" : active.supplier_name,
                    ReceiveVia = string.IsNullOrWhiteSpace(matchedPo?.DeliverVia) ? "-" : matchedPo.DeliverVia,
                    ExpectedDate = expectedDate
                });
            }

            return result
                .OrderBy(en => en.ExpectedDate ?? DateTime.MaxValue)
                .ToList();
        }

        // ------------------------------------------------------------------
        // Rendering
        // ------------------------------------------------------------------

        private void RenderReleaseSection(List<ReleaseEntry> entries)
        {
            pnl_release.SuspendLayout();
            pnl_release.Controls.Clear();
            if (entries.Count == 0)
            {
                pnl_release.Controls.Add(MakeEmptyLabel("Nothing pending release."));
            }
            else
            {
                foreach (var entry in entries)
                    pnl_release.Controls.Add(BuildReleaseCard(entry));
            }
            pnl_release.ResumeLayout();
        }

        private void RenderIncomingSection(List<IncomingEntry> entries)
        {
            pnl_incoming.SuspendLayout();
            pnl_incoming.Controls.Clear();
            if (entries.Count == 0)
            {
                pnl_incoming.Controls.Add(MakeEmptyLabel("Nothing incoming right now."));
            }
            else
            {
                foreach (var entry in entries)
                    pnl_incoming.Controls.Add(BuildIncomingCard(entry));
            }
            pnl_incoming.ResumeLayout();
        }

        // Narrow (~300px) panel - fields laid out 2-per-row like the mockup, built out
        // of nested FlowLayoutPanels (card -> row -> field block), matching the pattern
        // already proven in smpc_sales_system's RedBox control.
        private static readonly Color CardBackColor = Color.MistyRose;
        private static readonly Color HeaderColor = Color.FromArgb(150, 20, 20);
        private static readonly int CardWidth = 264;
        private static readonly int CardColumnWidth = (CardWidth - 16) / 2 - 4;

        private FlowLayoutPanel BuildReleaseCard(ReleaseEntry entry)
        {
            var card = StartCard();
            AddFieldRow(card, "DOCUMENT REQUEST", MakeValueLabel(entry.ItemReleaseNoDisplay), "DOCUMENT", MakeValueLabel(entry.SalesOrderNoDisplay));
            AddFieldRow(card, "CLIENT NAME", MakeValueLabel(entry.ClientName), "PROJECT NAME", MakeValueLabel(entry.ProjectName));
            AddFieldRow(card, "SALES EXECUTIVE", MakeValueLabel(entry.SalesExecutive), "ITEMS TO RESERVE", MakeValueLabel(entry.ItemsToReserveCount.ToString()));
            AddFieldRow(card, "COMMITMENT DATE", MakeValueLabel(entry.DeliveryDate?.ToString("M/d/yy") ?? "-"));
            return card;
        }

        private FlowLayoutPanel BuildIncomingCard(IncomingEntry entry)
        {
            var card = StartCard();
            AddFieldRow(card, "EXPECTED DATE", MakeValueLabel(entry.ExpectedDate?.ToString("M/d/yy") ?? "-"), "PURCHASE ORDER", MakeValueLabel(entry.PoNoDisplay));
            AddFieldRow(card, "SUPPLIER NAME", MakeValueLabel(entry.SupplierName), "RECEIVE VIA", MakeValueLabel(entry.ReceiveVia));
            return card;
        }

        private FlowLayoutPanel StartCard()
        {
            return new FlowLayoutPanel
            {
                FlowDirection = FlowDirection.TopDown,
                WrapContents = false,
                AutoSize = true,
                AutoSizeMode = AutoSizeMode.GrowAndShrink,
                BackColor = CardBackColor,
                BorderStyle = BorderStyle.FixedSingle,
                Padding = new Padding(8),
                Margin = new Padding(4),
                MinimumSize = new Size(CardWidth, 0),
                MaximumSize = new Size(CardWidth, 0)
            };
        }

        private void AddFieldRow(FlowLayoutPanel card, string header1, Control value1, string header2 = null, Control value2 = null)
        {
            var row = new FlowLayoutPanel
            {
                FlowDirection = FlowDirection.LeftToRight,
                WrapContents = false,
                AutoSize = true,
                AutoSizeMode = AutoSizeMode.GrowAndShrink,
                Margin = new Padding(0, 0, 0, 4)
            };
            row.Controls.Add(BuildFieldBlock(header1, value1));
            if (header2 != null)
                row.Controls.Add(BuildFieldBlock(header2, value2));

            card.Controls.Add(row);
        }

        private FlowLayoutPanel BuildFieldBlock(string header, Control valueControl)
        {
            var block = new FlowLayoutPanel
            {
                FlowDirection = FlowDirection.TopDown,
                WrapContents = false,
                AutoSize = true,
                AutoSizeMode = AutoSizeMode.GrowAndShrink,
                MinimumSize = new Size(CardColumnWidth, 0),
                MaximumSize = new Size(CardColumnWidth, 0),
                Margin = new Padding(0, 0, 4, 0),
                Padding = new Padding(0)
            };

            var lbl = new Label
            {
                Text = header,
                AutoSize = true,
                Font = new Font("Segoe UI", 7F, FontStyle.Bold),
                ForeColor = HeaderColor,
                Margin = new Padding(0)
            };
            valueControl.Margin = new Padding(0);
            valueControl.MaximumSize = new Size(CardColumnWidth, 0);

            block.Controls.Add(lbl);
            block.Controls.Add(valueControl);
            return block;
        }

        private Label MakeValueLabel(string text)
        {
            return new Label
            {
                Text = string.IsNullOrWhiteSpace(text) ? "-" : text,
                AutoSize = true,
                Font = new Font("Segoe UI", 9F)
            };
        }

        private Label MakeEmptyLabel(string text)
        {
            return new Label
            {
                Text = text,
                AutoSize = true,
                Margin = new Padding(10),
                ForeColor = Color.Gray,
                Font = new Font("Segoe UI", 9F, FontStyle.Italic)
            };
        }

        private static string EnsurePrefix(string raw, string prefix)
        {
            if (string.IsNullOrWhiteSpace(raw))
                return "-";
            return raw.StartsWith(prefix, StringComparison.OrdinalIgnoreCase) ? raw : prefix + raw;
        }
    }
}
