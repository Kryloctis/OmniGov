using System;

namespace AccountingSystem.Views.Reports.Financial_Statements
{
    public partial class StatementOfFinancialPerformanceData
    {
        private byte _fundId;
        private DateTime _date;

        public StatementOfFinancialPerformanceData(byte fundId, DateTime date)
        {
            _date = date;
            _fundId = fundId;
        }

        internal decimal GetTaxRevenue()
        {
            var dictBeginningBalance = Factory.BeginningBalancesRepository().GetSumBeginningBalanceBy_FundId_MajAccGrpId_Date_SubLedgeId(_fundId, 33, _date);
            var dictTransaction = Factory.JEVAccountsRepository().GetSumTransactionsByMajAccGrpId(_fundId, 22, _date);
            decimal totalBeginningAndTransDebit = dictBeginningBalance["beginning_balance_debit"] + dictTransaction["debit"];
            decimal totalBeginningAndTransCredit = dictBeginningBalance["beginning_balance_credit"] + dictTransaction["credit"];
            decimal shareIntervalRevenue = GetShareIntervalRevenue();
            decimal endingBalance = totalBeginningAndTransDebit - totalBeginningAndTransCredit;
            decimal sum = Math.Abs(endingBalance) - shareIntervalRevenue;

            return Math.Abs(sum);
        }

        internal decimal GetShareIntervalRevenue()
        {
            var dictBeginningBalance = Factory.BeginningBalancesRepository().GetSumBalancesBy_FundId_GenLedgId_Date_SubLedgId(_fundId, 381, _date);
            var dictTransaction = Factory.JEVAccountsRepository().GetSumTransactionsByGenLedgerId(_fundId, 381, _date);

            decimal totalBeginningAndTransDebit = dictBeginningBalance["beginning_balance_debit"] + dictTransaction["debit"];
            decimal totalBeginningAndTransCredit = dictBeginningBalance["beginning_balance_credit"] + dictTransaction["credit"];
            decimal balance = totalBeginningAndTransDebit - totalBeginningAndTransCredit;

            return Math.Abs(balance);
        }

        internal decimal GetOtherShareNationalTaxes()
        {
            var dictBeginningBalance = Factory.BeginningBalancesRepository().GetSumBeginningBalanceBy_FundId_SubMajAccGrpId_Date_SubLedgeId(_fundId, 64, _date);
            var dictTransaction = Factory.JEVAccountsRepository().GetSumTransactionsBySubMajAccGrpId(_fundId, 64, _date);

            decimal totalBeginningAndTransDebit = dictBeginningBalance["beginning_balance_debit"] + dictTransaction["debit"];
            decimal totalBeginningAndTransCredit = dictBeginningBalance["beginning_balance_credit"] + dictTransaction["credit"];
            decimal balance = totalBeginningAndTransDebit - totalBeginningAndTransCredit;

            return Math.Abs(balance);
        }

        internal decimal GetServicesBusinessIncome()
        {
            var dictBeginningBalance = Factory.BeginningBalancesRepository().GetSumBeginningBalanceBy_FundId_MajAccGrpId_Date_SubLedgeId(_fundId, 23, _date);
            var dictTransaction = Factory.JEVAccountsRepository().GetSumTransactionsByMajAccGrpId(_fundId, 23, _date);

            decimal totalBeginningAndTransDebit = dictBeginningBalance["beginning_balance_debit"] + dictTransaction["debit"];
            decimal totalBeginningAndTransCredit = dictBeginningBalance["beginning_balance_credit"] + dictTransaction["credit"];
            decimal balance = totalBeginningAndTransDebit - totalBeginningAndTransCredit;

            return Math.Abs(balance);
        }

        internal decimal GetSharesGrantsDonations()
        {
            var dictBeginningBalance = Factory.BeginningBalancesRepository().GetSumBeginningBalanceBy_FundId_SubMajAccGrpId_Date_SubLedgeId(_fundId, 65, _date);
            var dictTransaction = Factory.JEVAccountsRepository().GetSumTransactionsBySubMajAccGrpId(_fundId, 65, _date);

            decimal totalBeginningAndTransDebit = dictBeginningBalance["beginning_balance_debit"] + dictTransaction["debit"];
            decimal totalBeginningAndTransCredit = dictBeginningBalance["beginning_balance_credit"] + dictTransaction["credit"];
            decimal balance = totalBeginningAndTransDebit - totalBeginningAndTransCredit;

            return Math.Abs(balance);
        }

        internal decimal GetGains()
        {
            var dictBeginningBalance = Factory.BeginningBalancesRepository().GetSumBeginningBalanceBy_FundId_MajAccGrpId_Date_SubLedgeId(_fundId, 26, _date);
            var dictTransaction = Factory.JEVAccountsRepository().GetSumTransactionsByMajAccGrpId(_fundId, 26, _date);

            decimal totalBeginningAndTransDebit = dictBeginningBalance["beginning_balance_debit"] + dictTransaction["debit"];
            decimal totalBeginningAndTransCredit = dictBeginningBalance["beginning_balance_credit"] + dictTransaction["credit"];
            decimal balance = totalBeginningAndTransDebit - totalBeginningAndTransCredit;

            return Math.Abs(balance);
        }

        internal decimal GetOtherIncome()
        {
            var dictBeginningBalance = Factory.BeginningBalancesRepository().GetSumBeginningBalanceBy_FundId_MajAccGrpId_Date_SubLedgeId(_fundId, 27, _date);
            var dictTransaction = Factory.JEVAccountsRepository().GetSumTransactionsByMajAccGrpId(_fundId, 27, _date);

            decimal totalBeginningAndTransDebit = dictBeginningBalance["beginning_balance_debit"] + dictTransaction["debit"];
            decimal totalBeginningAndTransCredit = dictBeginningBalance["beginning_balance_credit"] + dictTransaction["credit"];
            decimal balance = totalBeginningAndTransDebit - totalBeginningAndTransCredit;

            return Math.Abs(balance);
        }

        internal decimal TotalRevenue()
        {
            decimal taxRevenue = GetTaxRevenue();
            decimal shareIntervalRevenue = GetShareIntervalRevenue();
            decimal otherShareNationalTaxes = GetOtherShareNationalTaxes();
            decimal servicesBusinessIncome = GetServicesBusinessIncome();
            decimal shareGrantsDonations = GetSharesGrantsDonations();
            decimal gains = GetGains();
            decimal otherIncome = GetOtherIncome();


            decimal totalRevenue = taxRevenue + shareIntervalRevenue + otherShareNationalTaxes + servicesBusinessIncome + shareGrantsDonations + gains + otherIncome;
            return totalRevenue;
        }

        internal decimal PersonnelServices()
        {
            var dictBeginningBalance = Factory.BeginningBalancesRepository().GetSumBeginningBalanceBy_FundId_MajAccGrpId_Date_SubLedgeId(_fundId, 28, _date);
            var dictTransaction = Factory.JEVAccountsRepository().GetSumTransactionsByMajAccGrpId(_fundId, 28, _date);

            decimal totalBeginningAndTransDebit = dictBeginningBalance["beginning_balance_debit"] + dictTransaction["debit"];
            decimal totalBeginningAndTransCredit = dictBeginningBalance["beginning_balance_credit"] + dictTransaction["credit"];
            decimal balance = totalBeginningAndTransDebit - totalBeginningAndTransCredit;

            return Math.Abs(balance);
        }

        internal decimal MaintenanceOtherOperatingExpenses()
        {
            var dictBeginningBalance1 = Factory.BeginningBalancesRepository().GetSumBeginningBalanceBy_FundId_MajAccGrpId_Date_SubLedgeId(_fundId, 29, _date);
            var dictTransaction1 = Factory.JEVAccountsRepository().GetSumTransactionsByMajAccGrpId(_fundId, 29, _date);

            var dictBeginningBalance2 = Factory.BeginningBalancesRepository().GetSumBeginningBalanceBy_FundId_SubMajAccGrpId_Date_SubLedgeId(_fundId, 87, _date);
            var dictTransaction2 = Factory.JEVAccountsRepository().GetSumTransactionsBySubMajAccGrpId(_fundId, 87, _date);

            var dictBeginningBalance3 = Factory.BeginningBalancesRepository().GetSumBeginningBalanceBy_FundId_SubMajAccGrpId_Date_SubLedgeId(_fundId, 88, _date);
            var dictTransaction3 = Factory.JEVAccountsRepository().GetSumTransactionsBySubMajAccGrpId(_fundId, 88, _date);

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

        internal decimal NonCashExpenses()
        {
            var dictBeginningBalance = Factory.BeginningBalancesRepository().GetSumBeginningBalanceBy_FundId_MajAccGrpId_Date_SubLedgeId(_fundId, 32, _date);
            var dictTransaction = Factory.JEVAccountsRepository().GetSumTransactionsByMajAccGrpId(_fundId, 32, _date);

            decimal totalBeginningAndTransDebit = dictBeginningBalance["beginning_balance_debit"] + dictTransaction["debit"];
            decimal totalBeginningAndTransCredit = dictBeginningBalance["beginning_balance_credit"] + dictTransaction["credit"];
            decimal balance = totalBeginningAndTransDebit - totalBeginningAndTransCredit;

            return Math.Abs(balance);
        }

        internal decimal FinancialExpenses()
        {
            var dictBeginningBalance = Factory.BeginningBalancesRepository().GetSumBeginningBalanceBy_FundId_MajAccGrpId_Date_SubLedgeId(_fundId, 30, _date);
            var dictTransaction = Factory.JEVAccountsRepository().GetSumTransactionsByMajAccGrpId(_fundId, 30, _date);

            decimal totalBeginningAndTransDebit = dictBeginningBalance["beginning_balance_debit"] + dictTransaction["debit"];
            decimal totalBeginningAndTransCredit = dictBeginningBalance["beginning_balance_credit"] + dictTransaction["credit"];
            decimal balance = totalBeginningAndTransDebit - totalBeginningAndTransCredit;

            return Math.Abs(balance);
        }

        internal decimal CurrentOperatingExpenses()
        {
            decimal currentOperatingExpenses = PersonnelServices() + MaintenanceOtherOperatingExpenses() + NonCashExpenses() + FinancialExpenses();
            return currentOperatingExpenses;
        }

        internal decimal SurplusDeficitFromCurrentOperation()
        {
            decimal SurplusDeficitFromCurrentOperation = TotalRevenue() - CurrentOperatingExpenses();
            return SurplusDeficitFromCurrentOperation;
        }

        internal decimal TransferSubsidyFrom()
        {
            var dictBeginningBalance = Factory.BeginningBalancesRepository().GetSumBeginningBalanceBy_FundId_MajAccGrpId_Date_SubLedgeId(_fundId, 24, _date);
            var dictTransaction = Factory.JEVAccountsRepository().GetSumTransactionsByMajAccGrpId(_fundId, 24, _date);

            decimal totalBeginningAndTransDebit = dictBeginningBalance["beginning_balance_debit"] + dictTransaction["debit"];
            decimal totalBeginningAndTransCredit = dictBeginningBalance["beginning_balance_credit"] + dictTransaction["credit"];
            decimal balance = totalBeginningAndTransDebit - totalBeginningAndTransCredit;

            return Math.Abs(balance);
        }

        internal decimal TransferSubsidyTo()
        {
            var dictBeginningBalance1 = Factory.BeginningBalancesRepository().GetSumBeginningBalanceBy_FundId_SubMajAccGrpId_Date_SubLedgeId(_fundId, 85, _date);
            var dictTransaction1 = Factory.JEVAccountsRepository().GetSumTransactionsBySubMajAccGrpId(_fundId, 85, _date);

            var dictBeginningBalance2 = Factory.BeginningBalancesRepository().GetSumBeginningBalanceBy_FundId_SubMajAccGrpId_Date_SubLedgeId(_fundId, 86, _date);
            var dictTransaction2 = Factory.JEVAccountsRepository().GetSumTransactionsBySubMajAccGrpId(_fundId, 86, _date);

            decimal totalBeginningAndTransDebit =
                (dictBeginningBalance1["beginning_balance_debit"] + dictTransaction1["debit"])
                + (dictBeginningBalance2["beginning_balance_debit"] + dictTransaction2["debit"]);

            decimal totalBeginningAndTransCredit = dictBeginningBalance1["beginning_balance_credit"] + dictTransaction1["credit"];
            decimal balance = totalBeginningAndTransDebit - totalBeginningAndTransCredit;

            return Math.Abs(balance);
        }

        internal decimal SurplusDeficitPeriod()
        {
            decimal surplusDeficitPeriod = SurplusDeficitFromCurrentOperation() + TransferSubsidyFrom() - TransferSubsidyTo();
            return surplusDeficitPeriod;
        }
    }
}
