using Microsoft.Reporting.WinForms;
using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;

namespace AccountingSystem.Views.Reports.Financial_Statements
{
    public partial class ucStatementOfChangesInNetAssetsEquity : UserControl
    {
        private readonly ReportViewer reportViewer;

        public ucStatementOfChangesInNetAssetsEquity()
        {
            InitializeComponent();
            reportViewer = new ReportViewer();
            reportViewer.Dock = DockStyle.Fill;
            panel1.Controls.Add(reportViewer);
        }

        private decimal GetBeginningBalance(byte fundId, ushort genLedgerId, DateTime date)
        {
            var dictBeginningBalance = Factory.BeginningBalancesRepository().GetSumBalancesBy_FundId_GenLedgId_Date_SubLedgId(fundId, genLedgerId, date);
            decimal beginningBalanceDebit = dictBeginningBalance["beginning_balance_debit"];
            decimal beginningBalanceCredit = dictBeginningBalance["beginning_balance_credit"];
            decimal beginningBalance = beginningBalanceDebit - beginningBalanceCredit;

            return beginningBalance;
        }

        private DataTable StatementOfChangesInNetAssetsEquityDatatable()
        {
            var dataSet = new dsLFS();
            var dtStatementOfChangesInNetAssetsEquity = dataSet.dtStatementOfChangesInNetAssetsEquity;

            try
            {
                byte fundId = Convert.ToByte(cmbxFunds.SelectedValue);
                var presentYear = dtPickerDateEnds.Value;
                var previousYear = new DateTime(year: presentYear.Year - 1, month: 12, DateTime.DaysInMonth(presentYear.Year, 12));
                decimal presentBeginningBalance = GetBeginningBalance(fundId, 331, presentYear);
                decimal previousBeginningBalance = GetBeginningBalance(fundId, 331, previousYear);

                var records = new object[] { presentBeginningBalance, 0, 0, 0, 0, 0, previousBeginningBalance, 0, 0, 0, 0, 0 };

                dtStatementOfChangesInNetAssetsEquity.Rows.Add(records);
            }
            catch (Exception ex)
            {
                Helper.MessageBoxError(ex.Message);
            }

            return dtStatementOfChangesInNetAssetsEquity;
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

                var dictSignatory = Helper.GetSignatoryDataBy_Reference_DocumentName("Certified Correct", "Statement of Changes in Assets/Equity");
                string certifiedCorrectSignatory = string.Empty;
                string certifiedCorrectSignatoryTitle = string.Empty;
                ParseSignatory(dictSignatory, ref certifiedCorrectSignatory, ref certifiedCorrectSignatoryTitle);

                int fundId = Convert.ToInt32(cmbxFunds.SelectedValue);
                DateTime dateEnded = dtPickerDateEnds.Value;

                report.ReportPath = $"{Application.StartupPath}\\Reports\\statement-of-changes-in-net-assets-equity.rdlc";
                report.DataSources.Clear();
                report.DataSources.Add(new ReportDataSource("dtStatementOfChangesInNetAssetsEquity", StatementOfChangesInNetAssetsEquityDatatable()));

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

        private void ucStatementOfChangesInNetAssetsquity_Load(object sender, EventArgs e)
        {
            if (!DesignMode)
            {
                LoadFunds();
            }
        }

        private void btnRetrieve_Click(object sender, EventArgs e)
        {
            LoadReport(reportViewer.LocalReport);
        }
    }
}
