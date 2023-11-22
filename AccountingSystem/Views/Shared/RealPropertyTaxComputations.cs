using ACC.Data;
using DocumentFormat.OpenXml.VariantTypes;
using DocumentFormat.OpenXml.Wordprocessing;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Security;

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

        //Method for getting delinquent
        public static int GetCurrentMonthsDelinquent(Dictionary<string, string> dictAssessmentPost, DateTime paymentDate, Dictionary<string, string> dictPreviousAssessment)
        {
            var assessmentPostedAt = Convert.ToDateTime(dictAssessmentPost["posted_at"]);
            var assessmentEffectivityYear = Convert.ToInt32(dictAssessmentPost["effectivity_year"]);
            int monthsDelinguent;

            //If assessment year is same as current year -> Apply selected year's delinquent months
            if (assessmentPostedAt.Year == paymentDate.Year && assessmentPostedAt.Month > 3)
                return paymentDate.Month;

            //If no previous assessment post found -> Apply deliquent months from effectivity date to the selected date
            else if (dictPreviousAssessment.Count < 1)
                monthsDelinguent = GetMonthsBetweenYears(assessmentEffectivityYear, paymentDate.Year) + paymentDate.Month;

            //If there is nearest previous assessment
            else if (dictPreviousAssessment.Count > 0)
            {
                var previousAssessmentPaymentId = dictPreviousAssessment["rpt_payments_id"].ToString();
                int previousAssessmentPostYear = Convert.ToInt32(dictPreviousAssessment["year"]);
                if (string.IsNullOrEmpty(previousAssessmentPaymentId))
                    monthsDelinguent = GetMonthsBetweenYears(previousAssessmentPostYear, paymentDate.Year) + paymentDate.Month;
                else
                    monthsDelinguent = 0;
            }
            else
                monthsDelinguent = 0;

            return monthsDelinguent;
        }

        //Method for getting delinquent months of paid assessment
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

        public static decimal GetDiscountRate(Dictionary<string, string> dictAssessmentPost, Dictionary<string, string> dictPreviousAssessment, DateTime paymentDate, ref bool isAdvance)
        {
            decimal discountRate = 0;
            DateTime assessmentPostedAt = Convert.ToDateTime(dictAssessmentPost["posted_at"]);
            int assessmentPostYear = Convert.ToInt32(dictAssessmentPost["year"]);
            var annualDiscountRate = AccFactory.RptDiscountRepository().GetRecordByMonth(10, true);
            var monthlyDiscountRate = AccFactory.RptDiscountRepository().GetRecordByMonth(paymentDate.Month, false);

            if (dictPreviousAssessment.Count > 0)
            {
                var previousAssessmentPaymentId = dictPreviousAssessment["rpt_payments_id"].ToString();
                if (string.IsNullOrEmpty(previousAssessmentPaymentId))
                    return discountRate;
            }

            if (assessmentPostedAt.Year < assessmentPostYear && assessmentPostedAt.Year > paymentDate.Year)
            {
                discountRate = annualDiscountRate == null ? 0 : Convert.ToDecimal(annualDiscountRate["rate"]);
                isAdvance = true;
            }
            else if (assessmentPostYear == paymentDate.Year && (paymentDate.Month == 1 || paymentDate.Month == 2 || paymentDate.Month == 3))
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