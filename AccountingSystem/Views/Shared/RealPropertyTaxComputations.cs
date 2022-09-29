using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccountingSystem.Views.Shared
{
    public static class RealPropertyTaxComputations
    {
        public static int GetMonthsBetweenYears(int fromYear, int toYear)
        {
            int years = toYear - fromYear;
            int months = 12 * years;

            return months;
        }

        //For current tax dues use only
        public static int GetCurrentMonthsDelinquent(int assessmentYear, DateTime assessmentPostsDate, int effectivityYear, int previousAssessmentCount)
        {
            var currentDate = Helper.GetCurrentDate();
            var currentMonth = currentDate.Month;
            var currentYear = currentDate.Year;
            int months;

            //If assessment year is same as current year
            if (assessmentYear == currentYear && assessmentPostsDate.Month > 3)
                return currentMonth;

            //If previous assessements are paid
            else if (assessmentYear < currentYear && previousAssessmentCount > 0)
                months = GetMonthsBetweenYears(assessmentYear, currentYear) + currentMonth;

            //If no previous years of assessments
            else if (previousAssessmentCount < 1)
                months = GetMonthsBetweenYears(effectivityYear, currentYear) + currentMonth;
            else
                months = 0;

            return months;
        }


        //For selected tax dues use only
        public static int GetSelectedMonthsDelinquent(int assessmentYear, DateTime assessmentPostsDate, DateTime paymentPostsDate, int effectivityYear, int previousAssessmentCount)
        {
            var paymentPostsMonth = paymentPostsDate.Month;
            var paymentPostsYear = paymentPostsDate.Year;
            int months;

            //If assessment year is same as current year
            if (assessmentYear == paymentPostsYear && assessmentPostsDate.Month > 3)
                return paymentPostsMonth;

            //If previous assessements are paid
            else if (assessmentYear < paymentPostsYear && previousAssessmentCount > 0)
                months = GetMonthsBetweenYears(assessmentYear, paymentPostsYear) + paymentPostsMonth;

            //If no previous years of assessments
            else if (previousAssessmentCount < 1)
                months = GetMonthsBetweenYears(effectivityYear, paymentPostsYear) + paymentPostsMonth;
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

        public static decimal GetDiscountPenaltyRate(decimal penaltyRate, decimal discountRate, int monthOfDelinquent)
        {
            if (discountRate > 0)
                return discountRate;
            else
                return penaltyRate * monthOfDelinquent;
        }

        public static decimal GetCurrentDiscountRate(DateTime postedDate, int year, ref bool isAdvance)
        {
            decimal discountRate;
            DateTime currentDate = DateTime.Now;
            int postYear = postedDate.Year;
            int postMonth = postedDate.Month;
            var annualDiscountRate = AccFactory.RptDiscountRepository().GetRecordByMonth(10, true);
            var monthlyDiscountRate = AccFactory.RptDiscountRepository().GetRecordByMonth(postMonth, false);

            if (postYear < year && year > currentDate.Year)
            {
                discountRate = annualDiscountRate == null ? 0 : Convert.ToDecimal(annualDiscountRate["rate"]);
                isAdvance = true;
            }

            else if (postYear == currentDate.Year && year == postYear && (postMonth == 1 || postMonth == 2 || postMonth == 3))
            {
                discountRate = monthlyDiscountRate == null ? 0 : Convert.ToDecimal(monthlyDiscountRate["rate"]);
                isAdvance = false;
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

        private static int GetQuarterByMonth(int month)
        {
            switch (month)
            {
                case 1:
                case 2:
                case 3:
                    return 1;
                case 4:
                case 5:
                case 6:
                    return 2;
                case 7:
                case 8:
                case 9:
                    return 3;
                case 10:
                case 11:
                case 12:
                    return 4;

                default:
                    return 0;
            }
        }
    }
}
