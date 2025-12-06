using ACC.Data;
using LFS.Helpers;
using Microsoft.Reporting.WinForms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Windows.Forms;

namespace LFS.Views.Transactions.JEV
{
    public partial class ucJevAud : UserControl
    {
        private int jevId;
        private byte journalId;

        internal string checkDate;
        internal string checkNo;
        internal string orNo;
        internal string dv;
        internal string officer;

        internal string paramCheckDate;
        internal string paramCheckNo;
        internal string paramORNo;
        internal string paramDVNo;
        internal string paramOfficer;

        public ucJevAud()
        {
            InitializeComponent();
            pnlRprt.Controls.Add(reportViewer1);
            reportViewer1.Dock = DockStyle.Fill;

            reportViewer1.SetDisplayMode(DisplayMode.PrintLayout);
            reportViewer1.ZoomMode = ZoomMode.PageWidth;
            reportViewer1.ZoomPercent = 100;
        }

        internal void OnLoad(int jevId, byte journalId)
        {
            this.jevId = jevId;
            this.journalId = journalId;

            if (!DesignMode && !backgroundWorker1.IsBusy)
            {
                backgroundWorker1.RunWorkerAsync();
                progressBar1.Value = 0;
            }
        }

        private void SetJournalData(string checkDate, string checkNo, string orNo, string dv, string officer)
        {
            this.checkDate = checkDate;
            this.checkNo = checkNo;
            this.orNo = orNo;
            this.dv = dv;
            this.officer = officer;
        }

        private void SetJournalCustomFields(int jevId, int journalId)
        {
            var journalDict = new Dictionary<string, string>();

            switch (journalId)
            {
                case 1:

                    journalDict = AccFactory.GeneralJournalRepository().GetViewRecordByJevID(jevId);

                    paramCheckDate = "";
                    paramOfficer = "";
                    paramCheckNo = journalDict["check_no"];
                    paramORNo = journalDict["or_no"];
                    paramDVNo = journalDict["dv_no"];

                    SetJournalData("", "Check No. :", "OR No. :", "DV No. :", "");

                    return;

                case 2:

                    journalDict = AccFactory.CashReceiptsJournalRepository().GetViewRecordByJevID(jevId);

                    paramCheckDate = Convert.ToDateTime(journalDict["or_date"]).ToString("MM/dd/yy");

                    paramORNo = journalDict["or_no"];
                    paramCheckNo = "";
                    paramDVNo = journalDict["rcd_no"];
                    paramOfficer = journalDict["full_name"];

                    SetJournalData("OR Date :", "", "OR No. :", "RCD No. :", "Collecting Officer: ");

                    return;

                case 3:     //NO OTHER FIELDS ASIDE FROM DATE OF ENTRY
                    return;

                case 4:

                    journalDict = AccFactory.CashDisbursementsJournalRepository().GetViewRecordByJevID(jevId);

                    paramCheckDate = Convert.ToDateTime(journalDict["date_paid"]).ToString("MM/dd/yy");
                    paramCheckNo = "";
                    paramORNo = "";
                    paramDVNo = journalDict["dv_no"];
                    paramOfficer = journalDict["full_name"];

                    SetJournalData("Date Paid:", "", "", "DV No. ", "Disburse officer: ");

                    return;

                case 5:

                    journalDict = AccFactory.CheckDisbursementsJournalRepository().GetRecordByJevID(jevId);

                    paramCheckDate = Convert.ToDateTime(journalDict["check_date"]).ToString("MM/dd/yy");
                    paramCheckNo = journalDict["check_no"];
                    paramORNo = journalDict["rci_no"];
                    paramDVNo = journalDict["dv_no"];

                    SetJournalData("Check Date: ", "Check No: ", "RCI No. : ", "DV No. :", "");
                    return;

                case 6:

                    journalDict = AccFactory.ADADisbursementsJournalRepository().GetViewRecordByJevID(jevId);

                    SetJournalData("", "", "ADA No. :", "DV No. :", "");
                    return;

                default:
                    break;
            }
        }

        private void ParseSignatory(out string signatoryName, out string signatoryTitle)
        {
            var dictSignatory = Helper.GetSignatoryDataBy_Reference_DocumentName("Certified Correct", "Journal Entry Voucher");

            if (dictSignatory.Count > 0)
            {
                signatoryName = dictSignatory["signatories_full_name"];
                signatoryTitle = dictSignatory["signatories_title"];
            }
            else
            {
                signatoryName = string.Empty;
                signatoryTitle = string.Empty;
            }
        }

        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
            try
            {
                int totalCount = 0;
                int progressCount = 0;

                var dtJevAccEntries = new dsLFS.dtJournalVoucherDataTable().Clone();
                var dtJevAccEntriesDb = AccFactory.JEVAccountsRepository().GetViewRecordsByJevId(jevId);
                totalCount = dtJevAccEntriesDb.Rows.Count;

                ParseSignatory(out string CertSignatory, out string CertSignatoryTitle);

                var dictJev = AccFactory.JEVRepository().GetViewRecordByJEVId(jevId);
                int jrnlId = Convert.ToInt32(dictJev["journals_id"]);
                SetJournalCustomFields(jevId, jrnlId);

                foreach (DataRow item in dtJevAccEntriesDb.Rows)
                {
                    DataRow row = dtJevAccEntries.NewRow();

                    row["fpp"] = item["fpp_code"];
                    row["account_and_explanation"] = item["general_ledger_accounts_name"];
                    row["account_code"] = item["account_code"];

                    if (Convert.ToBoolean(item["is_debit"]))
                        row["debit"] = item["amount"];
                    else
                        row["credit"] = item["amount"];

                    dtJevAccEntries.Rows.Add(row);
                    progressCount++;
                    Helper.ProgressCounter(backgroundWorker1, totalCount, progressCount);
                }

                e.Result = (dictJev, dtJevAccEntries, CertSignatory, CertSignatoryTitle);
            }
            catch (Exception ex) { Helper.MessageBoxError(ex.StackTrace); }
        }

        private void backgroundWorker1_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            try
            {
                progressBar1.Value = e.ProgressPercentage;
            }
            catch (Exception ex) { Helper.MessageBoxError(ex.Message); }
        }

        private void backgroundWorker1_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            try
            {
                var rprtParams = ((Dictionary<string, string> dictJev,
                                DataTable dtJevAccEntries,
                                string certSigntry,
                                string certSigntryTitle))e.Result;

                DateTime dateEntry = Convert.ToDateTime(rprtParams.dictJev["date_entry"]);
                string fundCode = rprtParams.dictJev["fund_code"];
                string month = dateEntry.ToString("MM");
                string year = dateEntry.Year.ToString();
                string jevNo = rprtParams.dictJev["jev_no"];
                string fullJevNo = string.IsNullOrWhiteSpace(jevNo) ? "_ - _ - _ - _ " : $"{fundCode}-{year}-{month}-{jevNo}";

                string lguName = $"{ServerHelper.selectedServer.MunicipalityName} - {ServerHelper.selectedServer.ProvinceName}";

                var parameters = new ReportParameter[]
                {
                    new("paramLGU",  lguName),
                    new("paramFund", rprtParams.dictJev["fund_name"]),
                    new("paramJournalType", rprtParams.dictJev["journal_name"]),
                    new("paramJEVNo", fullJevNo),
                    new("paramJEVDate", dateEntry.ToString("MM/dd/yy")),
                    new("paramPayee", rprtParams.dictJev["payee"]),
                    new("paramExplanation", rprtParams.dictJev["explanation"]),
                    new("paramPreparedBy",rprtParams.dictJev["created_by_name"].ToUpper()),
                    new("paramPreparedByRole", "NEED TO BE FIXED"),
                    new("paramCertifiedBySignatory", rprtParams.certSigntry),
                    new("paramCertifiedBySignatoryTitle", rprtParams.certSigntryTitle),

                    //For fields label
                    new("paramAsTextCheckDate", checkDate),
                    new("paramAsTextCheckNo", checkNo),
                    new("paramAsTextOR", orNo),
                    new("paramAsTextDV", dv),
                    new("paramAsTextOfficer", officer),

                    //for fields values
                    new("paramCheckDate", paramCheckDate),
                    new("paramCheckNo", paramCheckNo),
                    new("paramORNumber", paramORNo),
                    new("paramDVNo", paramDVNo),
                    new("paramDisbursementOfficer", paramOfficer)
                };

                var localReport = reportViewer1.LocalReport;
                localReport.ReportPath = $"{Application.StartupPath}\\Reports\\journal-entry-voucher.rdlc";
                localReport.DataSources.Clear();

                localReport.DataSources.Add(new ReportDataSource("dtJournalVoucher", rprtParams.dtJevAccEntries));
                localReport.SetParameters(parameters);

                reportViewer1.RefreshReport();
            }
            catch (Exception ex) { Helper.MessageBoxError(ex.Message); }
        }
    }
}