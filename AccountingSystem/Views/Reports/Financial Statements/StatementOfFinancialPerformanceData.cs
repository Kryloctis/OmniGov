using ACC.Data;
using System;
using System.Collections.Generic;

namespace AccountingSystem.Views.Reports.Financial_Statements
{
    public partial class StatementOfFinancialPerformanceData
    {
        internal decimal GetTaxRevenue(byte fundId, DateTime date)
        {
            var dictBeginningBalance = AccFactory.BeginningBalancesRepository().GetSumBeginningBalanceBy_FundId_MajAccGrpId_Date_SubLedgeId(fundId, 33, date);
            var dictTransaction = AccFactory.JEVAccountsRepository().GetSumTransactionsByMajAccGrpId(fundId, 22, date);
            decimal totalBeginningAndTransDebit = dictBeginningBalance["beginning_balance_debit"] + dictTransaction["debit"];
            decimal totalBeginningAndTransCredit = dictBeginningBalance["beginning_balance_credit"] + dictTransaction["credit"];
            decimal shareIntervalRevenue = GetShareIntervalRevenue(fundId, date);
            decimal endingBalance = totalBeginningAndTransDebit - totalBeginningAndTransCredit;
            decimal sum = Math.Abs(endingBalance) - shareIntervalRevenue;

            return Math.Abs(sum);
        }

        internal decimal GetShareIntervalRevenue(byte fundId, DateTime date)
        {
            var dictBeginningBalance = AccFactory.BeginningBalancesRepository().GetSumBalancesBy_FundId_GenLedgId_Date_SubLedgId(fundId, 381, date);
            var dictTransaction = AccFactory.JEVAccountsRepository().GetSumTransactionsByGenLedgerId(fundId, 381, date);

            decimal totalBeginningAndTransDebit = dictBeginningBalance["beginning_balance_debit"] + dictTransaction["debit"];
            decimal totalBeginningAndTransCredit = dictBeginningBalance["beginning_balance_credit"] + dictTransaction["credit"];
            decimal balance = totalBeginningAndTransDebit - totalBeginningAndTransCredit;

            return Math.Abs(balance);
        }

        internal decimal GetOtherShareNationalTaxes(byte fundId, DateTime date)
        {
            var dictBeginningBalance = AccFactory.BeginningBalancesRepository().GetSumBeginningBalanceBy_FundId_SubMajAccGrpId_Date_SubLedgeId(fundId, 64, date);
            var dictTransaction = AccFactory.JEVAccountsRepository().GetSumTransactionsBySubMajAccGrpId(fundId, 64, date);

            decimal totalBeginningAndTransDebit = dictBeginningBalance["beginning_balance_debit"] + dictTransaction["debit"];
            decimal totalBeginningAndTransCredit = dictBeginningBalance["beginning_balance_credit"] + dictTransaction["credit"];
            decimal balance = totalBeginningAndTransDebit - totalBeginningAndTransCredit;

            return Math.Abs(balance);
        }

        internal decimal GetServicesBusinessIncome(byte fundId, DateTime date)
        {
            var dictBeginningBalance = AccFactory.BeginningBalancesRepository().GetSumBeginningBalanceBy_FundId_MajAccGrpId_Date_SubLedgeId(fundId, 23, date);
            var dictTransaction = AccFactory.JEVAccountsRepository().GetSumTransactionsByMajAccGrpId(fundId, 23, date);

            decimal totalBeginningAndTransDebit = dictBeginningBalance["beginning_balance_debit"] + dictTransaction["debit"];
            decimal totalBeginningAndTransCredit = dictBeginningBalance["beginning_balance_credit"] + dictTransaction["credit"];
            decimal balance = totalBeginningAndTransDebit - totalBeginningAndTransCredit;

            return Math.Abs(balance);
        }

        internal decimal GetSharesGrantsDonations(byte fundId, DateTime date)
        {
            var dictBeginningBalance = AccFactory.BeginningBalancesRepository().GetSumBeginningBalanceBy_FundId_SubMajAccGrpId_Date_SubLedgeId(fundId, 65, date);
            var dictTransaction = AccFactory.JEVAccountsRepository().GetSumTransactionsBySubMajAccGrpId(fundId, 65, date);

            decimal totalBeginningAndTransDebit = dictBeginningBalance["beginning_balance_debit"] + dictTransaction["debit"];
            decimal totalBeginningAndTransCredit = dictBeginningBalance["beginning_balance_credit"] + dictTransaction["credit"];
            decimal balance = totalBeginningAndTransDebit - totalBeginningAndTransCredit;

            return Math.Abs(balance);
        }

        internal decimal GetGains(byte fundId, DateTime date)
        {
            var dictBeginningBalance = AccFactory.BeginningBalancesRepository().GetSumBeginningBalanceBy_FundId_MajAccGrpId_Date_SubLedgeId(fundId, 26, date);
            var dictTransaction = AccFactory.JEVAccountsRepository().GetSumTransactionsByMajAccGrpId(fundId, 26, date);

            decimal totalBeginningAndTransDebit = dictBeginningBalance["beginning_balance_debit"] + dictTransaction["debit"];
            decimal totalBeginningAndTransCredit = dictBeginningBalance["beginning_balance_credit"] + dictTransaction["credit"];
            decimal balance = totalBeginningAndTransDebit - totalBeginningAndTransCredit;

            return Math.Abs(balance);
        }

        internal decimal GetOtherIncome(byte fundId, DateTime date)
        {
            var dictBeginningBalance = AccFactory.BeginningBalancesRepository().GetSumBeginningBalanceBy_FundId_MajAccGrpId_Date_SubLedgeId(fundId, 27, date);
            var dictTransaction = AccFactory.JEVAccountsRepository().GetSumTransactionsByMajAccGrpId(fundId, 27, date);

            decimal totalBeginningAndTransDebit = dictBeginningBalance["beginning_balance_debit"] + dictTransaction["debit"];
            decimal totalBeginningAndTransCredit = dictBeginningBalance["beginning_balance_credit"] + dictTransaction["credit"];
            decimal balance = totalBeginningAndTransDebit - totalBeginningAndTransCredit;

            return Math.Abs(balance);
        }

        internal decimal GetTotalRevenue(byte fundId, DateTime date)
        {
            decimal taxRevenue = GetTaxRevenue(fundId, date);
            decimal shareIntervalRevenue = GetShareIntervalRevenue(fundId, date);
            decimal otherShareNationalTaxes = GetOtherShareNationalTaxes(fundId, date);
            decimal servicesBusinessIncome = GetServicesBusinessIncome(fundId, date);
            decimal shareGrantsDonations = GetSharesGrantsDonations(fundId, date);
            decimal gains = GetGains(fundId, date);
            decimal otherIncome = GetOtherIncome(fundId, date);

            decimal totalRevenue = taxRevenue + shareIntervalRevenue + otherShareNationalTaxes + servicesBusinessIncome + shareGrantsDonations + gains + otherIncome;
            return totalRevenue;
        }

        internal decimal GetPersonnelServices(byte fundId, DateTime date)
        {
            var dictBeginningBalance = AccFactory.BeginningBalancesRepository().GetSumBeginningBalanceBy_FundId_MajAccGrpId_Date_SubLedgeId(fundId, 28, date);
            var dictTransaction = AccFactory.JEVAccountsRepository().GetSumTransactionsByMajAccGrpId(fundId, 28, date);

            decimal totalBeginningAndTransDebit = dictBeginningBalance["beginning_balance_debit"] + dictTransaction["debit"];
            decimal totalBeginningAndTransCredit = dictBeginningBalance["beginning_balance_credit"] + dictTransaction["credit"];
            decimal balance = totalBeginningAndTransDebit - totalBeginningAndTransCredit;

            return Math.Abs(balance);
        }

        internal decimal GetMaintenanceOtherOperatingExpenses(byte fundId, DateTime date)
        {
            var dictBeginningBalance1 = AccFactory.BeginningBalancesRepository().GetSumBeginningBalanceBy_FundId_MajAccGrpId_Date_SubLedgeId(fundId, 29, date);
            var dictTransaction1 = AccFactory.JEVAccountsRepository().GetSumTransactionsByMajAccGrpId(fundId, 29, date);

            var dictBeginningBalance2 = AccFactory.BeginningBalancesRepository().GetSumBeginningBalanceBy_FundId_SubMajAccGrpId_Date_SubLedgeId(fundId, 87, date);
            var dictTransaction2 = AccFactory.JEVAccountsRepository().GetSumTransactionsBySubMajAccGrpId(fundId, 87, date);

            var dictBeginningBalance3 = AccFactory.BeginningBalancesRepository().GetSumBeginningBalanceBy_FundId_SubMajAccGrpId_Date_SubLedgeId(fundId, 88, date);
            var dictTransaction3 = AccFactory.JEVAccountsRepository().GetSumTransactionsBySubMajAccGrpId(fundId, 88, date);

            decimal totalBeginningAndTransDebit =
                (dictBeginningBalance1["beginning_balance_debit"] + dictTransaction1["debit"])
                + (dictBeginningBalance2["beginning_balance_debit"] + dictTransaction2["debit"])
                + (dictBeginningBalance3["beginning_balance_debit"] + dictTransaction3["debit"]);

            decimal totalBeginningAndTransCredit =
                 (dictBeginningBalance1["beginning_balance_credit"] + dictTransaction1["credit"])
                + (dictBeginningBalance2["beginning_balance_credit"] + dictTransaction2["credit"])
                + (dictBeginningBalance3["beginning_balance_credit"] + dictTransaction3["credit"]);

            decimal balance = totalBeginningAndTransDebit - totalBeginningAndTransCredit;

            return Math.Abs(balance);
        }

        internal decimal GetNonCashExpenses(byte fundId, DateTime date)
        {
            var dictBeginningBalance = AccFactory.BeginningBalancesRepository().GetSumBeginningBalanceBy_FundId_MajAccGrpId_Date_SubLedgeId(fundId, 32, date);
            var dictTransaction = AccFactory.JEVAccountsRepository().GetSumTransactionsByMajAccGrpId(fundId, 32, date);

            decimal totalBeginningAndTransDebit = dictBeginningBalance["beginning_balance_debit"] + dictTransaction["debit"];
            decimal totalBeginningAndTransCredit = dictBeginningBalance["beginning_balance_credit"] + dictTransaction["credit"];
            decimal balance = totalBeginningAndTransDebit - totalBeginningAndTransCredit;

            return Math.Abs(balance);
        }

        internal decimal GetFinancialExpenses(byte fundId, DateTime date)
        {
            var dictBeginningBalance = AccFactory.BeginningBalancesRepository().GetSumBeginningBalanceBy_FundId_MajAccGrpId_Date_SubLedgeId(fundId, 30, date);
            var dictTransaction = AccFactory.JEVAccountsRepository().GetSumTransactionsByMajAccGrpId(fundId, 30, date);

            decimal totalBeginningAndTransDebit = dictBeginningBalance["beginning_balance_debit"] + dictTransaction["debit"];
            decimal totalBeginningAndTransCredit = dictBeginningBalance["beginning_balance_credit"] + dictTransaction["credit"];
            decimal balance = totalBeginningAndTransDebit - totalBeginningAndTransCredit;

            return Math.Abs(balance);
        }

        internal decimal GetCurrentOperatingExpenses(byte fundId, DateTime date)
        {
            decimal currentOperatingExpenses = GetPersonnelServices(fundId, date) + GetMaintenanceOtherOperatingExpenses(fundId, date) + GetNonCashExpenses(fundId, date) + GetFinancialExpenses(fundId, date);
            return currentOperatingExpenses;
        }

        internal decimal GetSurplusDeficitFromCurrentOperation(byte fundId, DateTime date)
        {
            decimal SurplusDeficitFromCurrentOperation = GetTotalRevenue(fundId, date) - GetCurrentOperatingExpenses(fundId, date);
            return SurplusDeficitFromCurrentOperation;
        }

        internal decimal GetTransferSubsidyFrom(byte fundId, DateTime date)
        {
            var dictBeginningBalance = AccFactory.BeginningBalancesRepository().GetSumBeginningBalanceBy_FundId_MajAccGrpId_Date_SubLedgeId(fundId, 24, date);
            var dictTransaction = AccFactory.JEVAccountsRepository().GetSumTransactionsByMajAccGrpId(fundId, 24, date);

            decimal totalBeginningAndTransDebit = dictBeginningBalance["beginning_balance_debit"] + dictTransaction["debit"];
            decimal totalBeginningAndTransCredit = dictBeginningBalance["beginning_balance_credit"] + dictTransaction["credit"];
            decimal balance = totalBeginningAndTransDebit - totalBeginningAndTransCredit;

            return Math.Abs(balance);
        }

        internal decimal GetTransferSubsidyTo(byte fundId, DateTime date)
        {
            var dictBeginningBalance1 = AccFactory.BeginningBalancesRepository().GetSumBeginningBalanceBy_FundId_SubMajAccGrpId_Date_SubLedgeId(fundId, 85, date);
            var dictTransaction1 = AccFactory.JEVAccountsRepository().GetSumTransactionsBySubMajAccGrpId(fundId, 85, date);

            var dictBeginningBalance2 = AccFactory.BeginningBalancesRepository().GetSumBeginningBalanceBy_FundId_SubMajAccGrpId_Date_SubLedgeId(fundId, 86, date);
            var dictTransaction2 = AccFactory.JEVAccountsRepository().GetSumTransactionsBySubMajAccGrpId(fundId, 86, date);

            decimal totalBeginningAndTransDebit =
                (dictBeginningBalance1["beginning_balance_debit"] + dictTransaction1["debit"])
                + (dictBeginningBalance2["beginning_balance_debit"] + dictTransaction2["debit"]);

            decimal totalBeginningAndTransCredit = dictBeginningBalance1["beginning_balance_credit"] + dictTransaction1["credit"];
            decimal balance = totalBeginningAndTransDebit - totalBeginningAndTransCredit;

            return Math.Abs(balance);
        }

        internal decimal SurplusDeficitPeriod(byte fundId, DateTime date)
        {
            decimal surplusDeficitPeriod = GetSurplusDeficitFromCurrentOperation(fundId, date) + GetTransferSubsidyFrom(fundId, date) - GetTransferSubsidyTo(fundId, date);
            return surplusDeficitPeriod;
        }

        internal Dictionary<string, dynamic> GetStatementOfFiancialPerformanceData(byte fundId, DateTime present, DateTime previous)
        {
            var dict = new Dictionary<string, dynamic>();

            dict.Add("present_tax_revenue", GetTaxRevenue(fundId, present));
            dict.Add("present_share_from_internal_revenue_collections", GetShareIntervalRevenue(fundId, present));
            dict.Add("present_other_share_from_national_taxes", GetOtherShareNationalTaxes(fundId, present));
            dict.Add("present_service_and_business_income", GetServicesBusinessIncome(fundId, present));
            dict.Add("present_shares_grants_and_donations", GetSharesGrantsDonations(fundId, present));
            dict.Add("present_gains", GetGains(fundId, present));
            dict.Add("present_other_income", GetOtherIncome(fundId, present));
            dict.Add("present_total_revenue", GetTotalRevenue(fundId, present));
            dict.Add("present_personnel_services", GetPersonnelServices(fundId, present));
            dict.Add("present_maintenance_and_other_operating_expenses", GetMaintenanceOtherOperatingExpenses(fundId, present));
            dict.Add("present_non_cash_expenses", GetNonCashExpenses(fundId, present));
            dict.Add("present_financial_expenses", GetFinancialExpenses(fundId, present));
            dict.Add("present_current_operating_expenses", GetCurrentOperatingExpenses(fundId, present));
            dict.Add("present_surplus_deficit_from_current_operation", GetSurplusDeficitFromCurrentOperation(fundId, present));
            dict.Add("present_transfers_and_subsidy_from", GetTransferSubsidyFrom(fundId, present));
            dict.Add("present_transfers_and_subsidy_to", GetTransferSubsidyTo(fundId, present));
            dict.Add("present_surplus_deficit_for_the_period", SurplusDeficitPeriod(fundId, present));

            dict.Add("previous_tax_revenue", GetTaxRevenue(fundId, previous));
            dict.Add("previous_share_from_internal_revenue_collections", GetShareIntervalRevenue(fundId, previous));
            dict.Add("previous_other_share_from_national_taxes", GetOtherShareNationalTaxes(fundId, previous));
            dict.Add("previous_service_and_business_income", GetServicesBusinessIncome(fundId, previous));
            dict.Add("previous_shares_grants_and_donations", GetSharesGrantsDonations(fundId, previous));
            dict.Add("previous_gains", GetGains(fundId, previous));
            dict.Add("previous_other_income", GetOtherIncome(fundId, previous));
            dict.Add("previous_total_revenue", GetTotalRevenue(fundId, previous));
            dict.Add("previous_personnel_services", GetPersonnelServices(fundId, previous));
            dict.Add("previous_maintenance_and_other_operating_expenses", GetMaintenanceOtherOperatingExpenses(fundId, previous));
            dict.Add("previous_non_cash_expenses", GetNonCashExpenses(fundId, previous));
            dict.Add("previous_financial_expenses", GetFinancialExpenses(fundId, previous));
            dict.Add("previous_current_operating_expenses", GetCurrentOperatingExpenses(fundId, previous));
            dict.Add("previous_surplus_deficit_from_current_operation", GetSurplusDeficitFromCurrentOperation(fundId, previous));
            dict.Add("previous_transfers_and_subsidy_from", GetTransferSubsidyFrom(fundId, previous));
            dict.Add("previous_transfers_and_subsidy_to", GetTransferSubsidyTo(fundId, previous));
            dict.Add("previous_surplus_deficit_for_the_period", SurplusDeficitPeriod(fundId, previous));

            return dict;
        }
    }
}