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

        public static decimal GetCurrentPenaltyRate(int effectivityYear, int effectivityQuarter)
        {
            DateTime currentDate = DateTime.Now;
            var dictRptPenalty = AccFactory.rptPenaltiesRepository().GetRecordByID(9);
            var penaltyRate = dictRptPenalty == null ? 0 : Convert.ToDecimal(dictRptPenalty["rate"]);

            if (effectivityYear >= currentDate.Year && effectivityQuarter < 4)
                return 0;

            int quarter = effectivityQuarter - 1;
            decimal monthsDelignquent = GetMonthsBetweenYears(effectivityYear, currentDate.Year) - (quarter * 3);
            decimal totalPenaltyRate = penaltyRate * monthsDelignquent;
            return totalPenaltyRate;
        }

        public static decimal GetPenalty(decimal penaltyRate, decimal taxDue)
        {
            decimal penalty = taxDue * penaltyRate;
            return 0;
        }

        public static decimal GetCurrentDiscountRate(DateTime assessmentPostDate, int effectivityYear, int effectivityQuarter)
        {
            DateTime currentDate = DateTime.Now;
            int postYear = assessmentPostDate.Year;
            int postMonth = assessmentPostDate.Month;
            decimal discountRate = 0;

            if (postYear < currentDate.Year)
            {
                var dictDiscount = AccFactory.rptDiscountRepository().GetRecordByMonth(10, true);
                discountRate = dictDiscount == null ? 0 : Convert.ToDecimal(dictDiscount["rate"]);
            }

            if (postYear == currentDate.Year && (postMonth == 1 || postMonth == 2 || postMonth == 3))
            {
                var dictDiscount = AccFactory.rptDiscountRepository().GetRecordByMonth(postMonth, false);
                discountRate = dictDiscount == null ? 0 : Convert.ToDecimal(dictDiscount["rate"]);
            }

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


        public static decimal GetTotalBasic(decimal taxDue, decimal discount, decimal penalty)
        {
            decimal totalBasic = (taxDue + penalty) - discount;
            return totalBasic;
        }

        public static decimal GetTotalSef(decimal taxDue, decimal discount, decimal penalty)
        {
            decimal totalSef = (taxDue + penalty) - discount;
            return totalSef;
        }


        public static decimal GetSefBasicTotalTaxDue(decimal basicTaxRate, decimal sefTaxRate, decimal assessedValue)
        {
            decimal basicTaxDue = GetBasicTaxDue(basicTaxRate, assessedValue);
            decimal sefTaxDue = GetSefTaxDue(sefTaxRate, assessedValue);

            return basicTaxDue + sefTaxDue;
        }

        public static decimal GetTotalTaxDue(decimal basicTaxRate, decimal sefTaxRate, decimal discountRate, decimal penaltyRate, decimal assessedValue)
        {

            decimal basicTaxDue = GetBasicTaxDue(basicTaxRate, assessedValue);
            decimal basicDiscount = GetDiscount(discountRate, basicTaxDue);
            decimal basicPenalty = 0;

            decimal sefTaxDue = GetSefTaxDue(sefTaxRate, assessedValue);
            decimal sefDiscount = GetDiscount(discountRate, sefTaxDue);
            decimal sefPenalty = 0;

            decimal totalBasic = GetTotalBasic(basicTaxDue, basicDiscount, basicPenalty);
            decimal totalSef = GetTotalSef(sefTaxDue, sefDiscount, sefPenalty);
            decimal totalTaxDue = totalBasic + totalSef;

            return totalTaxDue;
        }
    }
}
