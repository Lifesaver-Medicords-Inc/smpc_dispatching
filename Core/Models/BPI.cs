using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace smpc_dispatching.Core.Models
{

    public class BPIGeneral
    {
        [JsonProperty("bpi")]
        public List<BPI> Bpi { get; set; }

        [JsonProperty("general")]
        public List<General> General { get; set; }

        [JsonProperty("contacts")]
        public List<Contacts> Contacts { get; set; }

        [JsonProperty("address")]
        public List<Address> Address { get; set; }

        [JsonProperty("items")]
        public List<Items> Items { get; set; }

        [JsonProperty("finance")]
        public List<Finance> Finance { get; set; }

        [JsonProperty("finance_pending")]
        public List<FinancePending> FinancePending { get; set; }

        [JsonProperty("accreditations")]
        public List<Accreditations> Accreditations { get; set; }

        [JsonProperty("history")]
        public List<History> History { get; set; }
    }

    public class BPI
    {
        [JsonProperty("id")]
        public int Id { get; set; }
        [JsonProperty("sales_id")]
        public string SalesId { get; set; } 
        [JsonProperty("name")]
        public string Name { get; set; }
        [JsonProperty("main_website")]
        public string MainWebsite { get; set; }
        [JsonProperty("tin")]
        public string Tin { get; set; }
        [JsonProperty("main_tel_no")]
        public string MainTelNo { get; set; }
        [JsonProperty("industry_ids")]
        public string IndustryIds { get; set; }
        [JsonProperty("industry_names")]
        public string IndustryNames { get; set; }
    }

    public class General
    {
        [JsonProperty("general_id")]
        public int GeneralId { get; set; }

        [JsonProperty("general_based_id")]
        public int GeneralBasedId { get; set; }

        [JsonProperty("branch_sales_id")]
        public string BranchSalesId { get; set; }

        [JsonProperty("branch_name")]
        public string BranchName { get; set; }

        [JsonProperty("is_main")]
        public bool IsMain { get; set; }

        [JsonProperty("social_id")]
        public int SocialId { get; set; }

        [JsonProperty("transaction_type")]
        public string TransactionType { get; set; }

        [JsonProperty("class_name")]
        public string ClassName { get; set; }

        [JsonProperty("branch_tel_no")]
        public string BranchTelNo { get; set; }

        [JsonProperty("branch_website")]
        public string BranchWebsite { get; set; }

        [JsonProperty("customer_code")]
        public string CustomerCode { get; set; }

        [JsonProperty("supplier_code")]
        public string SupplierCode { get; set; }

        [JsonProperty("fax_no")]
        public string FaxNo { get; set; }

        [JsonProperty("notes")]
        public string Notes { get; set; }

        [JsonProperty("branch_industry_ids")]
        public string BranchIndustryIds { get; set; }

        [JsonProperty("branch_industry_names")]
        public string BranchIndustryNames { get; set; }

        [JsonProperty("entity_ids")]
        public string EntityIds { get; set; }

        [JsonProperty("entity_names")]
        public string EntityNames { get; set; }
    }

    public class Contacts
    {
        [JsonProperty("contacts_id")]
        public int ContactsId { get; set; }

        [JsonProperty("contacts_based_id")]
        public int ContactsBasedId { get; set; }

        [JsonProperty("branch_id")]
        public int BranchId { get; set; }

        [JsonProperty("number")]
        public string Number { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("email")]
        public string Email { get; set; }

        [JsonProperty("preferences")]
        public string Preferences { get; set; }

        [JsonProperty("position")]
        public int Position { get; set; }

        [JsonProperty("is_default_contact")]
        public bool IsDefaultContact { get; set; }

        [JsonProperty("contact_notes")]
        public string ContactNotes { get; set; }
    }

    public class Address
    {
        [JsonProperty("address_ids")]
        public int AddressIds { get; set; }

        [JsonProperty("address_based_id")]
        public int AddressBasedId { get; set; }

        [JsonProperty("address_branch_id")]
        public int AddressBranchId { get; set; }

        [JsonProperty("location")]
        public string Location { get; set; }

        [JsonProperty("address_is_deleted")]
        public bool AddressIsDeleted { get; set; }
    }

    public class Items
    {
        [JsonProperty("bpi_item_id")]
        public int BpiItemId { get; set; }

        [JsonProperty("bpi_item_based_id")]
        public int BpiItemBasedId { get; set; }

        [JsonProperty("bpi_item_branch_id")]
        public int BpiItemBranchId { get; set; }

        [JsonProperty("payment_terms_id")]
        public string PaymentTermsId { get; set; }

        [JsonProperty("item_account_id")]
        public string ItemAccountId { get; set; }

        [JsonProperty("tax_code")]
        public string TaxCode { get; set; }

        [JsonProperty("item_tax_code")]
        public string ItemTaxCode { get; set; }

        [JsonProperty("price")]
        public decimal Price { get; set; }

        [JsonProperty("notes")]
        public string Notes { get; set; }

        [JsonProperty("item_id")]
        public int ItemId { get; set; }

        [JsonProperty("item_code")]
        public string ItemCode { get; set; }

        [JsonProperty("short_desc")]
        public string ShortDesc { get; set; }

        [JsonProperty("status_tangible")]
        public string StatusTangible { get; set; }

        [JsonProperty("status_trade")]
        public string StatusTrade { get; set; }

        [JsonProperty("item_is_deleted")]
        public bool ItemIsDeleted { get; set; }
    }

    public class Finance
    {
        [JsonProperty("finance_id")]
        public int FinanceId { get; set; }

        [JsonProperty("finance_based_id")]
        public int FinanceBasedId { get; set; }

        [JsonProperty("finance_account_id")]
        public int FinanceAccountId { get; set; }

        [JsonProperty("finance_payment_terms_id")]
        public int FinancePaymentTermsId { get; set; }

        [JsonProperty("finance_branch_id")]
        public int FinanceBranchId { get; set; }

        [JsonProperty("finance_tax_code")]
        public string FinanceTaxCode { get; set; }

        [JsonProperty("finance_tax")]
        public string FinanceTax { get; set; }
    }

    public class FinancePending
    {
        [JsonProperty("customer_id")]
        public int CustomerId { get; set; }

        [JsonProperty("finance_pending_branch_id")]
        public int FinancePendingBranchId { get; set; }

        [JsonProperty("date")]
        public string Date { get; set; }

        [JsonProperty("qoute_ref")]
        public string QuoteRef { get; set; }

        [JsonProperty("total_price")]
        public decimal TotalPrice { get; set; }

        [JsonProperty("stage")]
        public string Stage { get; set; }

        [JsonProperty("status")]
        public string Status { get; set; }
    }

    public class Accreditations
    {
        [JsonProperty("bpi_accreditation_id")]
        public int BpiAccreditationId { get; set; }

        [JsonProperty("bpi_accreditation_based_id")]
        public int BpiAccreditationBasedId { get; set; }

        [JsonProperty("bpi_accreditation_branch_id")]
        public int BpiAccreditationBranchId { get; set; }

        [JsonProperty("date_added")]
        public string DateAdded { get; set; }

        [JsonProperty("file_name")]
        public string FileName { get; set; }

        [JsonProperty("file_path")]
        public string FilePath { get; set; }

        [JsonProperty("accreditation_added_by")]
        public string AccreditationAddedBy { get; set; }
    }

    public class History
    {
        [JsonProperty("branch_id")]
        public int BranchId { get; set; }

        [JsonProperty("date")]
        public string Date { get; set; }

        [JsonProperty("actions")]
        public string Actions { get; set; }

        [JsonProperty("edit_by")]
        public string EditBy { get; set; }

        [JsonProperty("edit_history")]
        public string EditHistory { get; set; }
    }
}
