using ACC.Data;
using LFS.Helpers;
using Microsoft.Reporting.WinForms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Windows.Forms;

namespace LFS.Views.Reports.ConsolidatedReceipts
{
    public partial class frmConsolidatedReceipts : Form
    {
        public frmConsolidatedReceipts()
        {
            InitializeComponent();
            Helper.LoadFormIcon(this);

            reportViewer1 = new ReportViewer();
            reportViewer1.Dock = DockStyle.Fill;
            panel1.Controls.Add(reportViewer1);
        }

        private void btnRetrieve_Click(object sender, EventArgs e)
        {
            try
            {
                LoadReport();
            }
            catch (Exception ex) { Helper.MessageBoxError(ex.Message); }
        }

        private void ToogleRunButton(bool isGenerated)
        {
            btnRunReport.Text = isGenerated ? "Run Report" : "Generating Report...";
            btnRunReport.Enabled = isGenerated;
        }

        private void LoadReport()
        {
            if (!backgroundWorker1.IsBusy)
            {
                progressBar1.Value = 0;
                ToogleRunButton(false);
                var endDate = Convert.ToDateTime(dtpEndingDate.Value);
                backgroundWorker1.RunWorkerAsync(endDate);
            }
        }

        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
            try
            {
                var endDate = (DateTime)e.Argument;
                var dtConsolidatedReceipts = new dsLFS.dtConsolidatedReceiptsDataTable().Clone();
                DataTable dtConsolidatedReceiptsFromDB = AccFactory.ReceiptsIssuedRepository().GetAccountabilityForAccountableForms(endDate);

                int totalProgressCount = dtConsolidatedReceiptsFromDB.Rows.Count;
                int progressCount = 0;

                foreach (DataRow item in dtConsolidatedReceiptsFromDB.Rows)
                {
                    DataRow row = dtConsolidatedReceipts.NewRow();
                    var lastIssued = string.IsNullOrEmpty(item["last_issued"].ToString()) ? 0 : Convert.ToInt32(item["last_issued"]);
                    string accountableForm = $"AF - {item["acc_form_no"]}";
                    int quantity = Convert.ToInt32(item["quantity"]);
                    var receiptIssuedFrom = Convert.ToInt32(item["receipt_issued_from"]);
                    var receiptIssuedTo = Convert.ToInt32(item["receipt_issued_to"]);

                    int collectingOfficerID = Convert.ToInt32(item["collecting_officer_id"]);
                    int accountableFormID = Convert.ToInt32(item["accountable_form_id"]);

                    int totalUsedByCollectingOfficer = AccFactory.PaymentCollectionsRepository().GetTotalUsedAccountableFormByCollectingOfficerID(collectingOfficerID, accountableFormID);
                    var collectingOfficer = $"{item["collecting_officers_first_name"]} {item["collecting_officers_mid_initial"]}. {item["collecting_officers_last_name"]}";

                    row["form"] = accountableForm;

                    //BEGINNING BALANCE
                    row["beginning_quantity"] = quantity;
                    row["receiptfrom"] = receiptIssuedFrom;
                    row["receiptto"] = receiptIssuedTo;

                    //ISSUED RECEIPTS
                    row["issued_quantity"] = totalUsedByCollectingOfficer;
                    row["issuefrom"] = receiptIssuedFrom;
                    row["issueto"] = lastIssued;

                    //ENDING BALANCE
                    row["ending_quantity"] = quantity - totalUsedByCollectingOfficer;
                    row["usedfrom"] = lastIssued;
                    row["usedto"] = receiptIssuedTo;
                    row["officers"] = collectingOfficer;

                    dtConsolidatedReceipts.Rows.Add(row);
                    progressCount++;
                    Helper.ProgressCounter(backgroundWorker1, totalProgressCount, progressCount);
                }

                e.Result = dtConsolidatedReceipts;
            }
            catch (Exception ex) { Helper.MessageBoxError(ex.Message); }
        }

        private void backgroundWorker1_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            progressBar1.Value = e.ProgressPercentage;
        }

        private void backgroundWorker1_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            try
            {
                if (e.Result is not DataTable dataTable)
                {
                    progressBar1.Value = 100;
                    return;
                }

                if (dataTable.Rows.Count < 1)
                    progressBar1.Value = 100;

                var localReport = reportViewer1.LocalReport;
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

                var dictPreparedBySignatory = AccFactory.SignatoriesHasReferencesRepository().GetSignatoryBy_Reference_DocumentName("Prepared By", "Consolidated Report of Accountability for Accountable Forms");

                string preparedBySignatory = string.Empty;
                string preparedBySignatoryTitle = string.Empty;

                ParseSignatory(dictCertifiedCorrect, ref certifiedCorrectSignatory, ref certifiedCorrectSignatoryTitle);
                ParseSignatory(dictTreasurer, ref treasurer, ref treasurerTitle);
                ParseSignatory(dictPreparedBySignatory, ref preparedBySignatory, ref preparedBySignatoryTitle);

                string lguName = $"{ServerHelper.selectedServer.MunicipalityName} - {ServerHelper.selectedServer.ProvinceName}";

                var parameters = new ReportParameter[]
                {
                    new("paramLGUName", lguName),
                    new("paramForTheMonthOf", dtpEndingDate.Value.ToString("MMMM, yyyy")),
                    new("paramCertifiedCorrectSignatory", certifiedCorrectSignatory),
                    new("paramCertifiedCorrectSignatoryTitle", certifiedCorrectSignatoryTitle),
                    new("paramTreasurer", treasurer),
                    new("paramPreparedBySignatory", Helper.LoggedInUserData()["user_full_name"]),
                    new("paramPreparedBySignatoryTitle", preparedBySignatoryTitle)
                };

                localReport.ReportPath = $"{Application.StartupPath}Reports\\consolidated-receipts.rdlc";
                localReport.DataSources.Clear();
                localReport.DataSources.Add(new ReportDataSource("dtConsolidatedReceipts", dataTable));
                localReport.SetParameters(parameters);
                localReport.Refresh();
                reportViewer1.SetDisplayMode(DisplayMode.PrintLayout);
                reportViewer1.ZoomMode = ZoomMode.FullPage;
                reportViewer1.RefreshReport();
                ToogleRunButton(true);
            }
            catch (Exception ex) { Helper.MessageBoxError(ex.Message); }
        }
    }
}