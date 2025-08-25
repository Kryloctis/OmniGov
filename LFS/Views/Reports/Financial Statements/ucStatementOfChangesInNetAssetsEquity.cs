using ACC.Data;
using LFS.Helpers;
using Microsoft.Reporting.WinForms;
using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;

namespace LFS.Views.Reports.Financial_Statements
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

        private DataTable StatementOfChangesInNetAssetsEquityDatatable()
        {
            var dtStatementOfChangesInNetAssetsEquity = new dsLFS().dtStatementOfChangesInNetAssetsEquity;
            byte fundId = Convert.ToByte(cmbxFunds.SelectedValue);
            var presentYear = dtPickerDateEnds.Value;
            var previousYear = new DateTime(year: presentYear.Year - 1, month: 12, DateTime.DaysInMonth(presentYear.Year, 12));

            var dictStatementOfChanges = new StatementOfChangesInNetAssetsEquityData().GetStatementOfChangesOfAssetsEquity(fundId, presentYear, previousYear);

            var records = new object[]
            {
                dictStatementOfChanges["present_starting_balance"], 0, 0, 0, 0,
                dictStatementOfChanges["present_surplus_deficits_for_the_period"],
                dictStatementOfChanges["previous_starting_balance"], 0, 0, 0, 0,
                dictStatementOfChanges["previous_surplus_deficits_for_the_period"]
            };

            dtStatementOfChangesInNetAssetsEquity.Rows.Add(records);

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

            var parameters = new[]
            {
                new ReportParameter("paramCertifiedCorrectSignatory", certifiedCorrectSignatory),
                new ReportParameter("paramCertifiedCorrectSignatoryTitle", certifiedCorrectSignatoryTitle),
                new ReportParameter("paramFund", AccFactory.FundsRepository().GetRecordByID(fundId)["fund_name"]),
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
            var dtFunds = AccFactory.FundsRepository().GetRecords();
            HelperLoadRecords.FundsComboBox(dtFunds, cmbxFunds, "fund_name", "id");
        }

        internal void OnLoad()
        {
            LoadFunds();
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