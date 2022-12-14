using Microsoft.Reporting.WinForms;
using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;

namespace AccountingSystem.Views.Reports.Financial_Statements
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

            try
            {
                dtStatementOfFinancialPerformance.Rows.Add(StatementOfFinancialPerformanceData());
            }
            catch (Exception ex) { Helper.MessageBoxError(ex.Message); }

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
            try
            {
                Cursor.Current = Cursors.WaitCursor;
                var dictSignatory = Helper.GetSignatoryDataBy_Reference_DocumentName("Certified Correct", "Statement of Financial Performance");
                string certifiedCorrectSignatory = string.Empty;
                string certifiedCorrectSignatoryTitle = string.Empty;
                ParseSignatory(dictSignatory, ref certifiedCorrectSignatory, ref certifiedCorrectSignatoryTitle);

                int fundId = Convert.ToInt32(cmbxFunds.SelectedValue);
                DateTime dateEnded = dtPickerDateEnds.Value;

                report.ReportPath = $"{Application.StartupPath}\\Reports\\statement-of-financial-performance.rdlc";
                report.DataSources.Clear();
                report.DataSources.Add(new ReportDataSource("dtStatementOfFinancialPerformance", StatementOfFinancialPerformanceDatatable()));

                var fundRepo = AccFactory.FundsRepository().GetRecordByID(fundId);
                var parameters = new[] {
                    new ReportParameter("paramCertifiedCorrectSignatory", certifiedCorrectSignatory),
                    new ReportParameter("paramCertifiedCorrectSignatoryTitle", certifiedCorrectSignatoryTitle),
                    new ReportParameter("paramFund", fundRepo["fund_name"]),
                    new ReportParameter("paramDateEnded", dateEnded.ToString("MMMM dd, yyyy")),
                };
                report.SetParameters(parameters);

                reportViewer.SetDisplayMode(DisplayMode.PrintLayout);
                reportViewer.ZoomMode = ZoomMode.Percent;
                reportViewer.ZoomPercent = 100;
                reportViewer.RefreshReport();
                Cursor.Current = Cursors.Default;
            }
            catch (Exception ex)
            {
                Helper.MessageBoxError(ex.Message);
            }
        }

        private void LoadFunds()
        {
            try
            {
                var dtFunds = AccFactory.FundsRepository().GetRecords();

                HelperLoadRecords.FundsComboBox(dtFunds, cmbxFunds, "fund_name", "id");
            }
            catch (Exception ex)
            {
                Helper.MessageBoxError(ex.Message);
            }
        }

        private void btnRetrieve_Click(object sender, EventArgs e)
        {
            LoadReport(reportViewer.LocalReport);
        }

        private void ucStatementOfFinancialPerformance_Load(object sender, EventArgs e)
        {
            if (!DesignMode)
            {
                LoadFunds();
            }
        }
    }
}