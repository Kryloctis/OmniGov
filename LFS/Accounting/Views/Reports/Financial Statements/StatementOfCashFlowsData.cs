using System;
using System.Collections.Generic;

namespace LFS.Views.Reports.Financial_Statements
{
    public partial class StatementOfCashFlowsData
    {
        #region Cashflows from Operating Activities

        //Cash Inflows
        internal static decimal Get_Collection_from_Taxpayers(byte fundId, DateTime date)
        {
            return 0;
        }

        internal static decimal Get_Share_from_Internal_Revenue_Allotment(byte fundId, DateTime date)
        {
            return 0;
        }

        internal static decimal Get_Receipts_from_Business_Services_Income(byte fundId, DateTime date)
        {
            return new StatementOfFinancialPerformanceData().GetServicesBusinessIncome(fundId, date);
        }

        internal static decimal Get_Interest_Income(byte fundId, DateTime date)
        {
            return 0;
        }

        internal static decimal Get_Dividend_Income(byte fundId, DateTime date)
        {
            return 0;
        }

        internal static decimal Get_Other_Receipts(byte fundId, DateTime date)
        {
            return 0;
        }

        //Cash Outflows

        internal static decimal Get_Payment_of_Expenses(byte fundId, DateTime date)
        {
            return 0;
        }

        internal static decimal Get_Payments_to_Suppliers_and_Creditors(byte fundId, DateTime date)
        {
            return 0;
        }

        internal static decimal Get_Payments_to_Employees(byte fundId, DateTime date)
        {
            return 0;
        }

        internal static decimal Get_Interest_Expense(byte fundId, DateTime date)
        {
            return 0;
        }

        internal static decimal Get_Other_Expenses(byte fundId, DateTime date)
        {
            return 0;
        }

        #endregion Cashflows from Operating Activities

        #region Cashflows from Investing Activities

        //Cash Inflows
        internal decimal Get_Proceeds_from_Sale_if_Investment_Property(byte fundId, DateTime date)
        {
            return 0;
        }

        internal decimal Get_Proceeds_from_Sale_Disposal_of_Property_Plant_and_Equipment(byte fundId, DateTime date)
        {
            return 0;
        }

        internal decimal Get_Proceeds_from_Sale_of_Non_Current_Investments(byte fundId, DateTime date)
        {
            return 0;
        }

        internal decimal Get_Collection_of_Principal_on_Loans_to_other_entities(byte fundId, DateTime date)
        {
            return 0;
        }

        //Cash Outflows
        internal decimal Get_Purchase_Construction_of_Investment_Property(byte fundId, DateTime date)
        {
            return 0;
        }

        internal decimal Get_Purchase_Construction_of_Property_Plant_and_Equipment(byte fundId, DateTime date)
        {
            return 0;
        }

        internal decimal Get_Investment(byte fundId, DateTime date)
        {
            return 0;
        }

        internal decimal Get_Purchase_of_Bearer_Biological_Assets(byte fundId, DateTime date)
        {
            return 0;
        }

        internal decimal Get_Purchase_of_Intangible_Assets(byte fundId, DateTime date)
        {
            return 0;
        }

        internal decimal Get_Grant_of_Loans(byte fundId, DateTime date)
        {
            return 0;
        }

        #endregion Cashflows from Investing Activities

        #region Cashflows from Financing Activities

        //Cash Inflows
        internal decimal Get_Proceeds_from_Issuance_of_Bonds(byte fundId, DateTime date)
        {
            return 0;
        }

        internal decimal Get_Proceeds_from_Loans(byte funds_Id, DateTime date)
        {
            return 0;
        }

        //Cash Outflows
        internal decimal Get_Payment_of_Long_Term_Liabilities(byte fundId, DateTime date)
        {
            return 0;
        }

        internal decimal Get_Retirement_Redemption_of_Debt_Securities(byte fundId, DateTime date)
        {
            return 0;
        }

        internal decimal Get_Payment_of_Loan_Amortization(byte fundId, DateTime date)
        {
            return 0;
        }

        #endregion Cashflows from Financing Activities

        internal decimal Get_cash_at_the_end_of_month(byte fundId, DateTime date)
        {
            return 0;
        }

        internal Dictionary<string, dynamic> GetStatementOfCashFlowsData(byte fundId, DateTime date)
        {
            var dict = new Dictionary<string, dynamic>();

            dict.Add("collection_from_taxpayers", Get_Collection_from_Taxpayers(fundId, date));
            dict.Add("share_from_internal_revenue_allotment", Get_Share_from_Internal_Revenue_Allotment(fundId, date));
            dict.Add("receipts_from_business_services_income", Get_Receipts_from_Business_Services_Income(fundId, date));
            dict.Add("interest_income", Get_Interest_Income(fundId, date));
            dict.Add("dividend_income", Get_Dividend_Income(fundId, date));
            dict.Add("other_receipts", Get_Other_Receipts(fundId, date));
            dict.Add("payment_of_expenses", Get_Payment_of_Expenses(fundId, date));
            dict.Add("payments_to_suppliers_and_creditors", Get_Payments_to_Suppliers_and_Creditors(fundId, date));
            dict.Add("payments_to_employees", Get_Payments_to_Employees(fundId, date));
            dict.Add("interest_expense", Get_Interest_Expense(fundId, date));
            dict.Add("other_expenses", Get_Other_Expenses(fundId, date));
            dict.Add("proceeds_from_sale_if_investment_property", Get_Proceeds_from_Sale_if_Investment_Property(fundId, date));
            dict.Add("proceeds_from_sale_disposal_of_property_plant_and_equipment", Get_Proceeds_from_Sale_Disposal_of_Property_Plant_and_Equipment(fundId, date));
            dict.Add("proceeds_from_sale_of_non_current_investments", Get_Proceeds_from_Sale_of_Non_Current_Investments(fundId, date));
            dict.Add("collection_of_principal_on_loans_to_other_entities", Get_Collection_of_Principal_on_Loans_to_other_entities(fundId, date));
            dict.Add("purchase_construction_of_investment_property", Get_Purchase_Construction_of_Investment_Property(fundId, date));
            dict.Add("purchase_construction_of_property_plant_and_equipment", Get_Purchase_Construction_of_Property_Plant_and_Equipment(fundId, date));
            dict.Add("investment", Get_Investment(fundId, date));
            dict.Add("purchase_of_bearer_biological_assets", Get_Purchase_of_Bearer_Biological_Assets(fundId, date));
            dict.Add("purchase_of_intangible_assets", Get_Purchase_of_Intangible_Assets(fundId, date));
            dict.Add("grant_of_loans", Get_Grant_of_Loans(fundId, date));
            dict.Add("proceeds_from_issuance_of_bonds", Get_Proceeds_from_Issuance_of_Bonds(fundId, date));
            dict.Add("proceeds_from_loans", Get_Proceeds_from_Loans(fundId, date));
            dict.Add("payment_of_long_term_liabilities", Get_Payment_of_Long_Term_Liabilities(fundId, date));
            dict.Add("retirement_redemption_of_debt_securities", Get_Retirement_Redemption_of_Debt_Securities(fundId, date));
            dict.Add("payment_of_loan_amortization", Get_Payment_of_Loan_Amortization(fundId, date));
            dict.Add("cash_at_the_end_of_month", Get_cash_at_the_end_of_month(fundId, date));

            return dict;
        }
    }
}
