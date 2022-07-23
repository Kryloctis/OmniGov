using Microsoft.Reporting.WinForms;
using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;

namespace AccountingSystem.Views.Reports.ConsolidatedReceipts
{
    public partial class frmConsolidatedReceipts : Form
    {
        private readonly ReportViewer reportViewer = new();
        public frmConsolidatedReceipts()
        {
            InitializeComponent();
            Helper.LoadFormIcon(this);

            reportViewer.Dock = DockStyle.Fill;
            panel1.Controls.Add(reportViewer);
        }

        private void btnRetrieve_Click(object sender, EventArgs e)
        {
            LoadReport(reportViewer.LocalReport);
        }

        private DataTable DataTableConsilatedReceipts(string date)
        {

            var dtConsolidatedReceipts = new dsLFS.dtConsolidatedReceiptsDataTable();
            var dtConsolidatedReceiptsFromDB = AccFactory.GeneralCollectionsRepository().GetRecordsOfConsolidatedReceiptsByEndingDate(date);

            if (dtConsolidatedReceiptsFromDB.Rows.Count == 0) return dtConsolidatedReceipts;
        
            foreach (DataRow item in dtConsolidatedReceiptsFromDB.Rows)
            {
                DataRow row = dtConsolidatedReceipts.NewRow();
                row["form"] = item["form"].ToString();
                row["receiptfrom"] = Convert.ToInt32(item["receipt_number_from"]);
                row["receiptto"] = Convert.ToInt32(item["receipt_number_to"]);
                row["issuefrom"] = string.IsNullOrEmpty(item["receipt_issued_from"].ToString()) ? 0 : Convert.ToInt32(item["receipt_issued_from"]);
                row["issueto"] = string.IsNullOrEmpty(item["receipt_issued_to"].ToString()) ? 0 :  Convert.ToInt32(item["receipt_issued_to"].ToString());
                row["usedfrom"] = string.IsNullOrEmpty(item["ifrom"].ToString()) ? 0 : Convert.ToInt32(item["ifrom"].ToString());
                row["usedto"] = string.IsNullOrEmpty(item["ito"].ToString()) ? 0 : Convert.ToInt32(item["ito"].ToString());
                row["officers"] = item["officers"].ToString();
                dtConsolidatedReceipts.Rows.Add(row);
            }
           
            return dtConsolidatedReceipts;
        }

        private void LoadReport(LocalReport report)
        {
            try
            {
                Cursor = Cursors.WaitCursor;

                var lguDetails = Helper.LGUDetails();
                var date = string.Format("{0:yyyy-MM-dd}", dtto.Value);

                string certifiedCorrectSignatory = string.Empty;
                string certifiedCorrectSignatoryTitle = string.Empty;
                string treasurer = string.Empty;
                string treasurerTitle = string.Empty;

                var dictCertifiedCorrect = AccFactory.SignatoriesHasReferencesRepository().GetSignatoryBy_Reference_DocumentName("Certified Correct", "Consolidated Report of Accountability for Accountable Forms");

                var dictTreasurer = AccFactory.SignatoriesHasReferencesRepository().GetSignatoryBy_Reference_DocumentName("Treasurer", "Consolidated Report of Accountability for Accountable Forms");

                static void ParseSignatory(Dictionary<string, string> dictSignatory, ref string signatory, ref string signatoryTitle)
                {
                    if (dictSignatory.Count > 0)
                    {
                        string prefix = dictSignatory["signatories_prefix"].ToString();
                        string firstName = dictSignatory["signatories_first_name"].ToString();
                        char middleInitial = Convert.ToChar(dictSignatory["signatories_middle_initial"]);
                        string lastName = dictSignatory["signatories_last_name"].ToString();
                        string suffix = dictSignatory["signatories_suffix"].ToString();

                        string signatoryName = $"{(string.IsNullOrEmpty(prefix) ? string.Empty : $"{prefix}.")} {firstName} {middleInitial}. {lastName}{(string.IsNullOrEmpty(suffix) ? string.Empty : $", {suffix}")}";

                        signatory = signatoryName;
                        signatoryTitle = dictSignatory["signatories_title"];
                    }
                }

                ParseSignatory(dictCertifiedCorrect, ref certifiedCorrectSignatory, ref certifiedCorrectSignatoryTitle);
                ParseSignatory(dictTreasurer, ref treasurer, ref treasurerTitle);

                var parameters = new[] {
                            new ReportParameter("paramLGUName", lguDetails["lgu_name"]),
                            new ReportParameter("paramCertifiedCorrectSignatory", certifiedCorrectSignatory),
                            new ReportParameter("paramCertifiedCorrectSignatoryTitle", certifiedCorrectSignatoryTitle),
                            new ReportParameter("paramTreasurer", treasurer),
                            new ReportParameter("paramPreparedBySignatory", "Please put current user who's generating this report."),
                            new ReportParameter("paramPreparedBySignatoryTitle", "Please put current user who's generating this report.")
                    };
                report.ReportPath = $"{Application.StartupPath}Reports\\consolidated-receipts.rdlc";
                report.DataSources.Clear();
                report.DataSources.Add(new ReportDataSource("dtConsolidatedReceipts", DataTableConsilatedReceipts(date)));

                report.SetParameters(parameters);
                report.Refresh();

                reportViewer.SetDisplayMode(DisplayMode.PrintLayout);
                reportViewer.ZoomMode = ZoomMode.Percent;
                reportViewer.ZoomPercent = 100;
                reportViewer.RefreshReport();

                Cursor = Cursors.Default;
            }
            catch (Exception ex)
            {
                Helper.MessageBoxError(ex.StackTrace);
            }

        }
    }
}
