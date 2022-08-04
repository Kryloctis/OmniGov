using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccountingSystem.Views.Transactions.PaymentPostings.RPT_PaymentPosting
{
    public static class taxDueComputations
    {
        public static int GetMonthsBetweenYears(int fromYear, int toYear)
        {
            int months = 0;

            for (int i = fromYear; i <= toYear; i++)
            {
                months += 12;
            }

            return months;
        }

        public static int GetCountMonthsDelinquent(int year, DateTime postedDate)
        {
            var currentDate = Helper.GetCurrentDate();
            var currentMonth = currentDate.Month;
            var currentYear = currentDate.Year;
            int months;

            if (year == currentDate.Year && postedDate.Month > 3)
                return currentDate.Month;
            else if (year < currentYear)
                months = (GetMonthsBetweenYears(year, currentYear) - 12) + currentMonth;
            else
                months = 0;

            return months;
        }

        public static decimal GetPenalty(decimal penaltyRate, int monthsDelinquent, decimal taxDue)
        {
            decimal totalPenaltyRate = penaltyRate * monthsDelinquent;
            decimal penalty = taxDue * totalPenaltyRate;
            return penalty;
        }

        public static decimal GetCurrentDiscountRate(DateTime assessmentPostDate, int effectivityYear, int effectivityQuarter)
        {
            DateTime currentDate = DateTime.Now;
            int postYear = assessmentPostDate.Year;
            int postMonth = assessmentPostDate.Month;
            decimal discountRate;

            if (effectivityYear < currentDate.Year)
                return 0;

            if (postYear <= currentDate.Year && effectivityYear > currentDate.Year)
            {
                var dictDiscount = AccFactory.rptDiscountRepository().GetRecordByMonth(10, true);
                discountRate = dictDiscount == null ? 0 : Convert.ToDecimal(dictDiscount["rate"]);
            }
            else if (postYear == currentDate.Year && (postMonth == 1 || postMonth == 2 || postMonth == 3))
            {
                var dictDiscount = AccFactory.rptDiscountRepository().GetRecordByMonth(postMonth, false);
                discountRate = dictDiscount == null ? 0 : Convert.ToDecimal(dictDiscount["rate"]);
            }
            else
                discountRate = 0;

            return discountRate;
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
