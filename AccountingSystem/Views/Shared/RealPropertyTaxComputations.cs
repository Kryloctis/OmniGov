using ACC.Data;
using System;

namespace AccountingSystem.Views.Shared
{
    public static class RealPropertyTaxComputations
    {
        public static int GetMonthsBetweenYears(int startYear, int endYear)
        {
            return (endYear - startYear) * 12;
        }

        public static int GetMonthsDelinquent(DateTime transactionDate, (int assessmentYear, int effectivityQuarter, int effectivityYear) currentAssmntParameters, int? recentAssmntYear)
        {
            if (currentAssmntParameters.assessmentYear! > transactionDate.Year)
            {
                return 0;
            }
            else if (recentAssmntYear is not null && transactionDate.Month > 3)
            {
                return GetMonthsBetweenYears(recentAssmntYear.Value, transactionDate.Year) + transactionDate.Month;
            }
            else if (recentAssmntYear is null || currentAssmntParameters.assessmentYear < transactionDate.Year)
            {
                int monthsFromStartOfYear = GetMonthsBetweenYears(currentAssmntParameters.effectivityYear, transactionDate.Year);
                int monthsFromEffectivityQuarter = (currentAssmntParameters.effectivityQuarter - 1) * 3;

                return monthsFromStartOfYear + transactionDate.Month - monthsFromEffectivityQuarter;
            }
            else if (currentAssmntParameters.assessmentYear == transactionDate.Year && transactionDate.Month > 3)
            {
                return transactionDate.Month;
            }

            return 0;
        }

        public static decimal GetPenalty(decimal penaltyRate, int monthsDelinquent, decimal taxDue)
        {
            decimal totalPenaltyRate = penaltyRate * monthsDelinquent;
            decimal penalty = taxDue * totalPenaltyRate;
            return penalty;
        }

        public static decimal GetDiscountRate(DateTime transactionDate, (DateTime postedDate, int assmntYear) currentAssmntParameters)
        {
            var annualDiscountRate = AccFactory.RptDiscountRepository().GetRecordByMonth(10, true);
            var monthlyDiscountRate = AccFactory.RptDiscountRepository().GetRecordByMonth(transactionDate.Month, false);

            if (currentAssmntParameters.assmntYear > transactionDate.Year)
            {
                return annualDiscountRate == null ? 0 : Convert.ToDecimal(annualDiscountRate["rate"]);
            }
            else if (currentAssmntParameters.postedDate.Year == transactionDate.Year && transactionDate.Month < 3)
            {
                return monthlyDiscountRate == null ? 0 : Convert.ToDecimal(monthlyDiscountRate["rate"]);
            }
            else
                return 0;
        }

        public static decimal GetDiscount(decimal discountRate, decimal taxDue)
        {
            decimal discount = taxDue * discountRate;
            return discount;
        }

        public static decimal GetSefTaxDue(decimal sefTaxRate, decimal assessedValue)
        {
            decimal sef = assessedValue * sefTaxRate;
            return sef;
        }

        public static decimal GetBasicTaxDue(decimal basicTaxRate, decimal assessedValue)
        {
            decimal basic = assessedValue * basicTaxRate;
            return basic;
        }

        public static decimal GetSefBasicTotalTaxDue(decimal basicTaxRate, decimal sefTaxRate, decimal assessedValue)
        {
            decimal basicTaxDue = GetBasicTaxDue(basicTaxRate, assessedValue);
            decimal sefTaxDue = GetSefTaxDue(sefTaxRate, assessedValue);

            return basicTaxDue + sefTaxDue;
        }
    }
}