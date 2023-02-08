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
            DataTable dtConsolidatedReceiptsFromDB = AccFactory.ReceiptsIssuedRepository().GetAccountabilityForAccountableForms(Convert.ToDateTime(date));

            if (dtConsolidatedReceiptsFromDB.Rows.Count == 0) return dtConsolidatedReceipts;

            foreach (DataRow item in dtConsolidatedReceiptsFromDB.Rows)
            {
                DataRow row = dtConsolidatedReceipts.NewRow();
                
                var lastIssued = string.IsNullOrEmpty(item["last_issued"].ToString()) ? 0 : Convert.ToInt32(item["last_issued"]);
                var accountableForm = $"AF - {item["acc_form_no"]}";
                //var beginningQuantity = Convert.ToInt32(item["quantity"]);
                var receiptBeginningBalanceFrom = Convert.ToInt32(item["receipt_issued_from"]);
                var receiptBeginningBalanceTo = Convert.ToInt32(item["receipt_issued_to"]);
                var totalUsedByCollectingOfficer = (Convert.ToInt32(receiptBeginningBalanceFrom) - (Convert.ToInt32(lastIssued)) - Convert.ToInt32(item["quantity"]));
                var collectingOfficer = $"{item["collecting_officers_first_name"]} {item["collecting_officers_mid_initial"]}. {item["collecting_officers_last_name"]}";

                string nameOfForm = $"AF - {item["acc_form_no"]}";
                var beginningQuantity = Convert.ToInt32(item["quantity"]);
                int receiptNumberFrom = Convert.ToInt32(item["receipt_issued_from"]);
                int receiptNumberTo = Convert.ToInt32(item["receipt_issued_to"]);



                row["form"] = nameOfForm;

                row["beginning_quantity"] = beginningQuantity;
                row["receiptfrom"] = receiptNumberFrom;
                row["receiptto"] = receiptNumberTo;

                ////ISSUED RECEIPTS
                //row["issued_quantity"] = totalUsedByCollectingOfficer;
                //row["issuefrom"] = receiptBeginningBalanceFrom;
                //row["issueto"] = lastIssued;

                ////ENDING BALANCE
                //row["ending_quantity"] = Convert.ToInt32(receiptBeginningBalanceTo) - Convert.ToInt32(lastIssued);
                //row["usedfrom"] = lastIssued;
                //row["usedto"] = receiptBeginningBalanceTo;
                //row["officers"] = collectingOfficer;

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
                var date = string.Format("{0:yyyy-MM-dd}", dtpEndingDate.Value);

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
                            new ReportParameter("paramForTheMonthOf", dtpEndingDate.Value.ToString("MMMM, yyyy")),
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