using ACC.Data;
using Microsoft.Reporting.WinForms;
using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;

namespace AccountingSystem.Views.Reports.Financial_Statements
{
    public partial class ucStatementOfCashFlows : UserControl
    {
        private readonly ReportViewer reportViewer;

        public ucStatementOfCashFlows()
        {
            InitializeComponent();
            reportViewer = new ReportViewer();
            reportViewer.Dock = DockStyle.Fill;
            panel1.Controls.Add(reportViewer);
        }

        private DataTable SCFDatatable()
        {
            byte fundId = Convert.ToByte(cmbxFunds.SelectedValue);
            DateTime date = dtPickerDate.Value;

            var dataTable = new dsLFS.dtStatementOfCashFlowsDataTable();
            var dict = new StatementOfCashFlowsData().GetStatementOfCashFlowsData(fundId, date);

            var records = new object[]
            {
                dict["collection_from_taxpayers"],
                dict["share_from_internal_revenue_allotment"],
                dict["receipts_from_business_services_income"],
                dict["interest_income"],
                dict["dividend_income"],
                dict["other_receipts"],
                dict["payment_of_expenses"],
                dict["payments_to_suppliers_and_creditors"],
                dict["payments_to_employees"],
                dict["interest_expense"],
                dict["other_expenses"],
                dict["proceeds_from_sale_if_investment_property"],
                dict["proceeds_from_sale_disposal_of_property_plant_and_equipment"],
                dict["proceeds_from_sale_of_non_current_investments"],
                dict["collection_of_principal_on_loans_to_other_entities"],
                dict["purchase_construction_of_investment_property"],
                dict["purchase_construction_of_property_plant_and_equipment"],
                dict["investment"],
                dict["purchase_of_bearer_biological_assets"],
                dict["purchase_of_intangible_assets"],
                dict["grant_of_loans"],
                dict["proceeds_from_issuance_of_bonds"],
                dict["proceeds_from_loans"],
                dict["payment_of_long_term_liabilities"],
                dict["retirement_redemption_of_debt_securities"],
                dict["payment_of_loan_amortization"],
                dict["cash_at_the_end_of_month"]
            };

            dataTable.Rows.Add(records);

            return dataTable;
        }

        private void ParseSignatory(Dictionary<string, string> dictSignatory, ref string signatoryName, ref string signatoryTitle)
        {
            if (dictSignatory.Count > 0)
            {
                signatoryName = dictSignatory["signatories_full_name"];
                signatoryTitle = dictSignatory["signatories_title"];
            }
        }

        private void LoadReport(LocalReport localReport)
        {
            Cursor.Current = Cursors.WaitCursor;

            var dictSignatory = Helper.GetSignatoryDataBy_Reference_DocumentName("Certified Correct", "Statement of Cash Flows");
            string certifiedCorrectSignatory = string.Empty;
            string certifiedCorrectSignatoryTitle = string.Empty;
            ParseSignatory(dictSignatory, ref certifiedCorrectSignatory, ref certifiedCorrectSignatoryTitle);

            int fundId = Convert.ToInt32(cmbxFunds.SelectedValue);
            DateTime date = dtPickerDate.Value;

            localReport.ReportPath = $"{Application.StartupPath}\\Reports\\statement_of_cash_flows.rdlc";
            localReport.DataSources.Clear();
            localReport.DataSources.Add(new ReportDataSource("dtStatementOfCashFlows", SCFDatatable()));

            var dictFund = AccFactory.FundsRepository().GetRecordByID(fundId);

            var parameters = new[]
            {
                new ReportParameter("paramCertifiedCorrectSignatory", ""),
                new ReportParameter("paramCertifiedCorrectSignatoryTitle", ""),
                new ReportParameter("paramFund", dictFund["fund_name"]),
                new ReportParameter("paramDate", date.ToString("MMMM dd, yyyy")),
            };

            localReport.SetParameters(parameters);

            reportViewer.SetDisplayMode(DisplayMode.PrintLayout);
            reportViewer.ZoomMode = ZoomMode.Percent;
            reportViewer.ZoomPercent = 100;
            reportViewer.RefreshReport();
            Cursor.Current = Cursors.Default;
        }

        private void LoadFunds()
        {
            var dtFunds = AccFactory.FundsRepository().GetRecords();
            HelperLoadRecords.FundsComboBox(dtFunds, cmbxFunds, "fund_name", "id");
        }

        private void OnLoad()
        {
            if (!DesignMode)
            {
                LoadFunds();
            }
        }

        private void ucStatementOfCashFlows_Load(object sender, EventArgs e)
        {
            try
            {
                OnLoad();
            }
            catch (Exception ex) { Helper.MessageBoxError(ex.Message); }
        }

        private void btnRetrieve_Click(object sender, EventArgs e)
        {
            try
            {
                LoadReport(reportViewer.LocalReport);
            }
            catch (Exception ex) { Helper.MessageBoxError(ex.Message); }
        }
    }
}