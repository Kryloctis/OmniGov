using OmniGov.Core.Repositories;
using OmniGov.Core.Factories;
using System.Collections.Generic;
using System.Data;
using System.Linq;

namespace LFS.Helpers
{
    public enum Privileges
    {
        DashAccounting, DashBudget, DashTreasury, MngAccForms, MngAllotClasses, MngAllotReleases, MngAmortization, MngBankAccounts, MngBanks, MngBarangays, MngBudgetApprops, MngBizAddOnCharges, MngBizCategories, MngChartAccounts, MngCollOfficer, MngDbSync, MngDisbOfficer, MngFeesChargesCfg, MngFuncProgProj, MngFunds, MngJournals, MngPreferences, MngRealProps, MngReceipts, MngReturnedReceipts, MngRoles, MngSignatories, MngSubsidiaryAcct, MngTaxpayers, MngUsers, RptAbsGenColl, RptAuthDebitAcctDJ, RptBankCashbook, RptCashDisbJournal, RptCashRecvJournal, RptChkDisbJournal, RptCollRCD, RptConsPropTaxDues, RptConsReceipts, RptDailyCashPos, RptGenJournal, RptGenLedger, RptJEVs, RptDelinqAccts, RptPostTrialBal, RptPreTrialBal, RptProcRecvJournal, RptRPTAR, RptChkIssued, RptCollDeposits, RptSAAOB, RptSAAOBB, RptSchedReleasedChk, RptSchedUnreleasedChk, RptCashFlows, RptChangesNetAssets, RptBudgetVsActual, RptFinPerformance, RptFinPosition, RptSubsidiaryLedger, RptSummarySubLedger, RptTaxDueBill, RptTransLog, TransAssessPosting, TransBankDeposits, TransEditApprJEV, TransGenRCD, TransIssueChk, TransIssueReceipt, TransJEV, TransJEVApproval, TransJEVApproved, TransObligationReq, TransObligationAppr, TransObligationApproved, TransPayments, TransRCDApproval, TransReleaseChk,
    }

    public static class PrivilegesHelper
    {
        private static Dictionary<Privileges, string> DictPriviledges()
        {
            return new Dictionary<Privileges, string>()
            {
                {Privileges.DashAccounting, "Dashboard > Accounting"},
                {Privileges.DashBudget, "Dashboard > Budget"},
                {Privileges.DashTreasury, "Dashboard > Treasury"},

                {Privileges.MngAccForms, "Manage > Accountable Forms"},
                {Privileges.MngAllotClasses, "Manage > Allotment Classes"},
                {Privileges.MngAllotReleases, "Manage > Allotment Releases"},
                {Privileges.MngAmortization, "Manage > Amortization"},
                {Privileges.MngBankAccounts, "Manage > Bank Accounts"},
                {Privileges.MngBanks, "Manage > Banks"},
                {Privileges.MngBarangays, "Manage > Barangays"},
                {Privileges.MngBudgetApprops, "Manage > Budget Appropriations"},
                {Privileges.MngBizAddOnCharges, "Manage > Business Add-on Charges"},
                {Privileges.MngBizCategories, "Manage > Business Categories"},
                {Privileges.MngChartAccounts, "Manage > Chart of Accounts"},
                {Privileges.MngCollOfficer, "Manage > Collecting Officer"},
                {Privileges.MngDbSync, "Manage > Database Synchronization"},
                {Privileges.MngDisbOfficer, "Manage > Disbursing Officer"},
                {Privileges.MngFeesChargesCfg, "Manage > Fees & Charges Config."},
                {Privileges.MngFuncProgProj, "Manage > Function/Program/Project"},
                {Privileges.MngFunds, "Manage > Funds"},
                {Privileges.MngJournals, "Manage > Journals"},
                {Privileges.MngPreferences, "Manage > Preferences"},
                {Privileges.MngRealProps, "Manage > Real Properties"},
                {Privileges.MngReceipts, "Manage > Receipts"},
                {Privileges.MngReturnedReceipts, "Manage > Returned Receipts"},
                {Privileges.MngRoles, "Manage > Roles"},
                {Privileges.MngSignatories, "Manage > Signatories"},
                {Privileges.MngSubsidiaryAcct, "Manage > Subsidiary Ledger Account"},
                {Privileges.MngTaxpayers, "Manage > Taxpayers"},
                {Privileges.MngUsers, "Manage > Users"},

                {Privileges.RptAbsGenColl, "Report > Abstract of General Collections"},
                {Privileges.RptAuthDebitAcctDJ, "Report > Authority to Debit Account Disbursements Journal"},
                {Privileges.RptBankCashbook, "Report > Bank Cashbook"},
                {Privileges.RptCashDisbJournal, "Report > Cash Disbursements Journal"},
                {Privileges.RptCashRecvJournal, "Report > Cash Receipts Journal"},
                {Privileges.RptChkDisbJournal, "Report > Check Disbursements Journal"},
                {Privileges.RptCollRCD, "Report > Collector's RCD"},
                {Privileges.RptConsPropTaxDues, "Report > Consolidated Real Property Tax Dues"},
                {Privileges.RptConsReceipts, "Report > Consolidated Receipts"},
                {Privileges.RptDailyCashPos, "Report > Daily Cash Position"},
                {Privileges.RptGenJournal, "Report > General Journal"},
                {Privileges.RptGenLedger, "Report > General Ledger"},
                {Privileges.RptJEVs, "Report > JEVs"},
                {Privileges.RptDelinqAccts, "Report > List of Delinquent Accounts"},
                {Privileges.RptPostTrialBal, "Report > Post Trial Balance"},
                {Privileges.RptPreTrialBal, "Report > Pre Trial Balance"},
                {Privileges.RptProcRecvJournal, "Report > Procurement Received Journal"},
                {Privileges.RptRPTAR, "Report > Real Property Tax Account Register (RPTAR)"},
                {Privileges.RptChkIssued, "Report > Report of Checks Issued"},
                {Privileges.RptCollDeposits, "Report > Report of Collections and Deposits"},
                {Privileges.RptSAAOB, "Report > SAAOB"},
                {Privileges.RptSAAOBB, "Report > SAAOBB"},
                {Privileges.RptSchedReleasedChk, "Report > Schedule of Released Cheques"},
                {Privileges.RptSchedUnreleasedChk, "Report > Schedule of Unreleased Cheques"},
                {Privileges.RptCashFlows, "Report > Statement of Cash Flows"},
                {Privileges.RptChangesNetAssets, "Report > Statement of Changes in Net Assets Equity"},
                {Privileges.RptBudgetVsActual, "Report > Statement of Comparisons of Budget and Actual Amounts"},
                {Privileges.RptFinPerformance, "Report > Statement of Financial Performance"},
                {Privileges.RptFinPosition, "Report > Statement of Financial Position"},
                {Privileges.RptSubsidiaryLedger, "Report > Subsidiary Ledger"},
                {Privileges.RptSummarySubLedger, "Report > Summary Subsidiary Ledger"},
                {Privileges.RptTaxDueBill, "Report > Tax Due Bill"},
                {Privileges.RptTransLog, "Report > Transaction Log"},

                {Privileges.TransAssessPosting, "Transaction > Assessment Posting"},
                {Privileges.TransBankDeposits, "Transaction > Bank Deposits"},
                {Privileges.TransEditApprJEV, "Transaction > Edit Approved JEV"},
                {Privileges.TransGenRCD, "Transaction > Generate RCD"},
                {Privileges.TransIssueChk, "Transaction > Issue Check"},
                {Privileges.TransIssueReceipt, "Transaction > Issue Receipt"},
                {Privileges.TransJEV, "Transaction > JEV"},
                {Privileges.TransJEVApproval, "Transaction > JEV Approval"},
                {Privileges.TransJEVApproved, "Transaction > JEV Approved"},
                {Privileges.TransObligationReq, "Transaction > Obligation Request"},
                {Privileges.TransObligationAppr, "Transaction > Obligation Request Approval"},
                {Privileges.TransObligationApproved, "Transaction > Obligation Request Approved"},
                {Privileges.TransPayments, "Transaction > Payments"},
                {Privileges.TransRCDApproval, "Transaction > RCD Approval"},
                {Privileges.TransReleaseChk, "Transaction > Release / Unreleased Checks"},
            };
        }

        internal static bool HasPrivilege(Privileges privileges)
        {
            string privilegeVal = DictPriviledges()[privileges];

            var userPrivileges = UserHelper.loggedUser.UserPriviledges
                                .Select(p => p.Trim().ToLower())
                                .ToList();

            return UserHelper.loggedUser.isSuper ? true : userPrivileges.Contains(privilegeVal.Trim().ToLower());
        }

        internal static string[] UserPrivileges(int rolesId)
        {
            var dtUserPriviledges = Factory.RolesPermissionsRepository().GetViewRecordsByRoleId(rolesId);
            return dtUserPriviledges.AsEnumerable()
                                    .Select(row => row.Field<string>("permission_name"))
                                    .ToArray();
        }
    }
}

