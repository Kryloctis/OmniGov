using Microsoft.Reporting.WinForms;
using OmniGov.App.Helpers;
using OmniGov.Core.Factories;
using System.Data;

namespace OmniGov.App.Accounting.Views.Reports.FinancialStatements
{
    public partial class ucStatementOfFinancialPerformance : UserControl
    {
        private readonly ReportViewer reportViewer;

        public ucStatementOfFinancialPerformance()
        {
            InitializeComponent();
            reportViewer = new ReportViewer();
            reportViewer.Dock = DockStyle.Fill;
            panel1.Controls.Add(reportViewer);
        }

        private object[] StatementOfFinancialPerformanceData()
        {
            byte fundsId = (byte)cmbxFunds.SelectedValue;
            var presentDate = dtPickerDateEnds.Value;
            var previousDate = new DateTime(year: presentDate.Year - 1, month: 12, DateTime.DaysInMonth(presentDate.Year, 12));

            var dict = new StatementOfFinancialPerformanceData().GetStatementOfFiancialPerformanceData(fundsId, presentDate, previousDate);

            var records = new object[]
            {
                dict["present_tax_revenue"],
                dict["present_share_from_internal_revenue_collections"],
                dict["present_other_share_from_national_taxes"],
                dict["present_service_and_business_income"],
                dict["present_shares_grants_and_donations"],
                dict["present_gains"],
                dict["present_other_income"],
                dict["present_total_revenue"],
                dict["present_personnel_services"],
                dict["present_maintenance_and_other_operating_expenses"],
                dict["present_non_cash_expenses"],
                dict["present_financial_expenses"],
                dict["present_current_operating_expenses"],
                dict["present_surplus_deficit_from_current_operation"],
                dict["present_transfers_and_subsidy_from"],
                dict["present_transfers_and_subsidy_to"],
                dict["present_surplus_deficit_for_the_period"],
                dict["previous_tax_revenue"],
                dict["previous_share_from_internal_revenue_collections"],
                dict["previous_other_share_from_national_taxes"],
                dict["previous_service_and_business_income"],
                dict["previous_shares_grants_and_donations"],
                dict["previous_gains"],
                dict["previous_other_income"],
                dict["previous_total_revenue"],
                dict["previous_personnel_services"],
                dict["previous_maintenance_and_other_operating_expenses"],
                dict["previous_non_cash_expenses"],
                dict["previous_financial_expenses"],
                dict["previous_current_operating_expenses"],
                dict["previous_surplus_deficit_from_current_operation"],
                dict["previous_transfers_and_subsidy_from"],
                dict["previous_transfers_and_subsidy_to"],
                dict["previous_surplus_deficit_for_the_period"]
            };

            return records;
        }

        private DataTable StatementOfFinancialPerformanceDatatable()
        {
            var dataSet = new dsLFS();
            var dtStatementOfFinancialPerformance = dataSet.dtStatementOfFinancialPerformance;

            dtStatementOfFinancialPerformance.Rows.Add(StatementOfFinancialPerformanceData());

            return dtStatementOfFinancialPerformance;
        }

        private void ParseSignatory(Dictionary<string, string> dictSignatory, ref string signatoryName, ref string signatoryTitle)
        {
            if (dictSignatory.Count > 0)
            {
                signatoryName = dictSignatory["signatories_full_name"];
                signatoryTitle = dictSignatory["signatories_title"];
            }
        }

        private void LoadReport(LocalReport report)
        {
            Cursor.Current = Cursors.WaitCursor;
            var dictSignatory = Helper.GetSigtryByRefDoc("Certified Correct", "Statement of Financial Performance");
            string certifiedCorrectSignatory = string.Empty;
            string certifiedCorrectSignatoryTitle = string.Empty;
            ParseSignatory(dictSignatory, ref certifiedCorrectSignatory, ref certifiedCorrectSignatoryTitle);

            int fundId = Convert.ToInt32(cmbxFunds.SelectedValue);
            DateTime dateEnded = dtPickerDateEnds.Value;

            report.ReportPath = $"{Application.StartupPath}\\Reports\\statement-of-financial-performance.rdlc";
            report.DataSources.Clear();
            report.DataSources.Add(new ReportDataSource("dtStatementOfFinancialPerformance", StatementOfFinancialPerformanceDatatable()));

            var parameters = new[]
            {
                new ReportParameter("paramCertifiedCorrectSignatory", certifiedCorrectSignatory),
                new ReportParameter("paramCertifiedCorrectSignatoryTitle", certifiedCorrectSignatoryTitle),
                new ReportParameter("paramFund",  Factory.FundsRepository().GetRecordByID(fundId)["fund_name"]),
                new ReportParameter("paramDateEnded", dateEnded.ToString("MMMM dd, yyyy")),
            };

            report.SetParameters(parameters);

            reportViewer.SetDisplayMode(DisplayMode.PrintLayout);
            reportViewer.ZoomMode = ZoomMode.PageWidth;
            reportViewer.RefreshReport();
            Cursor.Current = Cursors.Default;
        }

        private void LoadFunds()
        {
            var dtFunds = Factory.FundsRepository().GetRecords();
            HelperLoadRecords.FundsComboBox(dtFunds, cmbxFunds, "id", "fund_name");
        }

        private void btnRetrieve_Click(object sender, EventArgs e)
        {
            LoadReport(reportViewer.LocalReport);
        }

        internal void OnLoad()
        {
            LoadFunds();
        }
    }
}