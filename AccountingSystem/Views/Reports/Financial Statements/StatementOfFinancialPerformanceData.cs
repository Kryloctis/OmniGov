using System;

namespace AccountingSystem.Views.Reports.Financial_Statements
{
    public static class StatementOfFinancialPerformanceData
    {
        internal static decimal GetTaxRevenue(int fundId, DateTime date)
        {
            var dictBeginningBalance = Factory.BeginningBalancesRepository().GetSumBeginningBalanceBy_FundId_MajAccGrpId_Date_SubLedgeId((byte)fundId, 33, date);
            var dictTransaction = Factory.JEVAccountsRepository().GetSumTransactionsByMajAccGrpId(fundId, 22, date);
            decimal totalBeginningAndTransDebit = dictBeginningBalance["beginning_balance_debit"] + dictTransaction["debit"];
            decimal totalBeginningAndTransCredit = dictBeginningBalance["beginning_balance_credit"] + dictTransaction["credit"];
            decimal shareIntervalRevenue = GetShareIntervalRevenue(fundId, date);
            decimal endingBalance = totalBeginningAndTransDebit - totalBeginningAndTransCredit;
            decimal sum = Math.Abs(endingBalance) - shareIntervalRevenue;

            return Math.Abs(sum);
        }

        internal static decimal GetShareIntervalRevenue(int fundId, DateTime date)
        {
            var dictBeginningBalance = Factory.BeginningBalancesRepository().GetSumBalancesBy_FundId_GenLedgId_Date_SubLedgId((byte)fundId, 381, date);
            var dictTransaction = Factory.JEVAccountsRepository().GetSumTransactionsByGenLedgerId(fundId, 381, date);

            decimal totalBeginningAndTransDebit = dictBeginningBalance["beginning_balance_debit"] + dictTransaction["debit"];
            decimal totalBeginningAndTransCredit = dictBeginningBalance["beginning_balance_credit"] + dictTransaction["credit"];
            decimal balance = totalBeginningAndTransDebit - totalBeginningAndTransCredit;

            return Math.Abs(balance);
        }
    }
}
