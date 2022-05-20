using Microsoft.Reporting.WinForms;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
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

        private object[] Records(StatementOfFinancialPerformanceData entity)
        {
            var records = new object[]
            {
                entity.GetTaxRevenue(),
                entity.GetShareIntervalRevenue(),
                entity.GetOtherShareNationalTaxes(),
                entity.GetServicesBusinessIncome(),
                entity.GetSharesGrantsDonations(),
                entity.GetGains(),
                entity.GetOtherIncome(),
                entity.GetTotalRevenue(),
                entity.GetPersonnelServices(),
                entity.GetMaintenanceOtherOperatingExpenses(),
                entity.GetNonCashExpenses(),
                entity.GetFinancialExpenses(),
                entity.GetCurrentOperatingExpenses(),
                entity.GetSurplusDeficitFromCurrentOperation(),
                entity.GetTransferSubsidyFrom(),
                entity.GetTransferSubsidyTo(),
                entity.SurplusDeficitPeriod()
            };

            return records;
        }


        private DataTable StatementOfFinancialPerformanceDatatable()
        {
            var dataSet = new dsLFS();
            var dtStatementOfFinancialPerformance = dataSet.dtStatementOfFinancialPerformance;

            try
            {
                byte fundsId = (byte)cmbxFunds.SelectedValue;
                var presentDate = dtPickerDateEnds.Value;
                var previousDate = new DateTime(year: presentDate.Year - 1, month: 12, DateTime.DaysInMonth(presentDate.Year, 12));
                var presentRecord = new StatementOfFinancialPerformanceData(fundsId, presentDate);
                var previousRecord = new StatementOfFinancialPerformanceData(fundsId, previousDate);

                var concatenatedArrays = Records(presentRecord).Concat(Records(previousRecord)).ToArray();

                dtStatementOfFinancialPerformance.Rows.Add(concatenatedArrays);
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

                var fundRepo = Factory.FundsRepository().GetRecordByID(fundId);
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
                var dtFunds = Factory.FundsRepository().GetRecords();

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
