using ACC.Data;
using System;
using System.Collections.Generic;

namespace LFS.Views.Reports.Financial_Statements
{
    public partial class StatementOfChangesInNetAssetsEquityData
    {
        internal decimal GetSurplusDeficitForThePeriod(byte fundId, DateTime date)
        {
            decimal statementOfFinancialPerformanceData = new StatementOfFinancialPerformanceData().SurplusDeficitPeriod(fundId, date);

            return statementOfFinancialPerformanceData;
        }

        private decimal GetStartingBalance(byte fundId, DateTime date)
        {
            var dictBeginningBalance = AccFactory.BeginningBalancesRepository().GetSumBalancesBy_FundId_GenLedgId_Date_SubLedgId(fundId, 331, date);
            decimal beginningBalanceDebit = dictBeginningBalance["beginning_balance_debit"];
            decimal beginningBalanceCredit = dictBeginningBalance["beginning_balance_credit"];
            decimal beginningBalance = beginningBalanceDebit - beginningBalanceCredit;

            return Math.Abs(beginningBalance);
        }

        internal Dictionary<string, dynamic> GetStatementOfChangesOfAssetsEquity(byte fundId, DateTime present, DateTime previous)
        {
            var dict = new Dictionary<string, dynamic>();

            dict.Add("present_starting_balance", GetStartingBalance(fundId, present));
            dict.Add("previous_starting_balance", GetStartingBalance(fundId, previous));
            dict.Add("present_surplus_deficits_for_the_period", GetSurplusDeficitForThePeriod(fundId, present));
            dict.Add("previous_surplus_deficits_for_the_period", GetSurplusDeficitForThePeriod(fundId, previous));

            return dict;
        }
    }
}