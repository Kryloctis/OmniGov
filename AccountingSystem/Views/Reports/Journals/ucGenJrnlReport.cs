using ACC.Data;
using Microsoft.Reporting.WinForms;
using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;

namespace AccountingSystem.Views.Reports.Journals
{
    public partial class ucGenJrnlReport : UserControl
    {
        private readonly ReportViewer reportViewer;

        public ucGenJrnlReport()
        {
            InitializeComponent();
            reportViewer = new ReportViewer();
            reportViewer.Dock = DockStyle.Fill;
            panel1.Controls.Add(reportViewer);
        }

        internal void OnLoad()
        {
            LoadFunds();
        }

        private void LoadFunds()
        {
            var dtFunds = AccFactory.FundsRepository().GetRecords();
            HelperLoadRecords.FundsComboBox(dtFunds, cmbxFunds, "fund_name", "id");
        }

        private static void ValidateDebitCreditRow(string particulars, DataRow item, DataRow row)
        {
            if (Convert.ToBoolean(item["is_debit"]))
            {
                row["particulars"] = particulars;
                row["debit"] = item["amount"];
                row["credit"] = 0;
            }
            else
            {
                row["particulars"] = $"     {particulars}";
                row["debit"] = 0;
                row["credit"] = item["amount"];
            }
        }

        private static void AddExplanationRow(dsLFS.dtGeneralJournalDataTable dtGeneralJournal, string jevNo, ref string particulars, int jevId, ref byte i, DataRow item)
        {
            var countJevAccounts = AccFactory.JEVAccountsRepository().CountByJevId(jevId);
            if (i == countJevAccounts)
            {
                particulars = $"          {item["explanation"]}";

                DataRow explanationRow = dtGeneralJournal.NewRow();
                explanationRow["date_entry"] = item["date_entry"];
                explanationRow["jev_no"] = jevNo;
                explanationRow["particulars"] = particulars;
                explanationRow["debit"] = 0;
                explanationRow["credit"] = 0;

                i = 0;
                dtGeneralJournal.Rows.Add(explanationRow);
            }
        }

        private void ParseSignatory(Dictionary<string, string> dictSignatory, ref string signatoryName, ref string signatoryTitle)
        {
            if (dictSignatory.Count > 0)
            {
                signatoryName = dictSignatory["signatories_full_name"];
                signatoryTitle = dictSignatory["signatories_title"];
            }
        }

        private void LoadReport(ReportViewer reportViewer)
        {
            var localReport = reportViewer.LocalReport;
            int fundId = Convert.ToInt32(cmbxFunds.SelectedValue);
            string journalName = "General Journal";
            var date = dateTimePicker1.Value;

            var dtGeneralJournal = new dsLFS.dtGeneralJournalDataTable();
            var dictFund = AccFactory.FundsRepository().GetRecordByID(fundId);
            var dtGeneralJournalFromDB = AccFactory.JEVAccountsRepository().GetViewRecordsByFundJournalDate(dictFund["fund_name"], journalName, date);

            string jevNo;
            string particulars;
            int jevId;
            byte i = 0;

            foreach (DataRow item in dtGeneralJournalFromDB.Rows)
            {
                jevNo = item["full_jev_no"].ToString();
                particulars = item["general_ledger_accounts_name"].ToString();

                DataRow row = dtGeneralJournal.NewRow();
                row["date_entry"] = item["date_entry"];
                row["jev_no"] = jevNo;
                row["account_code"] = item["account_code"];

                ValidateDebitCreditRow(particulars, item, row);

                dtGeneralJournal.Rows.Add(row);

                i++;
                jevId = Convert.ToInt32(item["jev_id"]);
                AddExplanationRow(dtGeneralJournal, jevNo, ref particulars, jevId, ref i, item);
            }

            var dictSignatory = Helper.GetSignatoryDataBy_Reference_DocumentName("Certified Correct", "General Journal");
            Cursor.Current = Cursors.WaitCursor;
            var lguDetails = Helper.LGUDetails();
            string certifiedCorrectSignatory = string.Empty;
            string certifiedCorrectSignatoryTitle = string.Empty;
            ParseSignatory(dictSignatory, ref certifiedCorrectSignatory, ref certifiedCorrectSignatoryTitle);

            ReportParameter[] parameters = new[]
            {
                new ReportParameter("paramDate", date.ToString()),
                new ReportParameter("paramLGUName", lguDetails["lgu_name"]),
                new ReportParameter("paramFund", $"{dictFund["fund_code"]} - {dictFund["fund_name"]}"),
                new ReportParameter("paramCertifiedCorrectSignatory", certifiedCorrectSignatory),
                new ReportParameter("paramCertifiedCorrectSignatoryTitle", certifiedCorrectSignatoryTitle)
            };

            localReport.ReportPath = $"{Application.StartupPath}\\Reports\\general-journal.rdlc";
            localReport.DataSources.Clear();

            localReport.DataSources.Add(new ReportDataSource("dtGeneralJournal", dtGeneralJournal.Clone()));
            localReport.SetParameters(parameters);
            reportViewer.SetDisplayMode(DisplayMode.PrintLayout);
            reportViewer.ZoomMode = ZoomMode.PageWidth;
            reportViewer.RefreshReport();
            Cursor.Current = Cursors.Default;
        }

        private void btnRunReport_Click(object sender, EventArgs e)
        {
            try
            {
                LoadReport(reportViewer);
            }
            catch (Exception ex) { Helper.MessageBoxError(ex.Message); }
        }
    }
}