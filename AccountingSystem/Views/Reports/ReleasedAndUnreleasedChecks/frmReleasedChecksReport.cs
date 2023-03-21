using DocumentFormat.OpenXml.Spreadsheet;
using Microsoft.Reporting.WinForms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AccountingSystem.Views.Reports.ReleasedAndUnreleasedCheques
{
    public partial class frmReleasedChecksReport : Form
    {
        private readonly ReportViewer reportViewer;

        public frmReleasedChecksReport()
        {
            InitializeComponent();
            Helper.LoadFormIcon(this);

            reportViewer = new ReportViewer();
            reportViewer.Dock = DockStyle.Fill;
            panel1.Controls.Add(reportViewer);
        }

        private void btnRetrieve_Click(object sender, EventArgs e)
        {
            LoadReport(reportViewer.LocalReport);
        }

        private void LoadReport(LocalReport report)
        {

            try
            {
                Cursor = Cursors.WaitCursor;

                var lguDetails = Helper.LGUDetails();
                int bankAccountId = Convert.ToInt32(cmbBankAccounts.SelectedValue);
                var dictBankAccount = AccFactory.BankAccountsRepository().GetViewRecordById(bankAccountId);
                string bankDetails = string.Format("{0} - {1}", dictBankAccount["bank_name"], dictBankAccount["account_no"]);

                string certifiedCorrectSignatory = string.Empty;
                string certifiedCorrectSignatoryTitle = string.Empty;

                string receivedBySignatory = string.Empty;
                string receivedBySignatoryTitle = string.Empty;

                var dictCertifiedCorrect = AccFactory.SignatoriesHasReferencesRepository().GetSignatoryBy_Reference_DocumentName("Certified Correct", "Schedule of UnReleased Checks");

                var dictReceivedBy = AccFactory.SignatoriesHasReferencesRepository().GetSignatoryBy_Reference_DocumentName("Received By", "Schedule of UnReleased Checks");

                ParseSignatory(dictCertifiedCorrect, ref certifiedCorrectSignatory, ref certifiedCorrectSignatoryTitle);
                ParseSignatory(dictReceivedBy, ref receivedBySignatory, ref receivedBySignatoryTitle);

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

                var parameters = new[] {
                    new ReportParameter("paramPeriodCovered", dtpPeriodCovered.Value.ToString()),
                    new ReportParameter("paramFund", "General Fund"),
                    new ReportParameter("paramLGUName", lguDetails["lgu_name"]),
                    new ReportParameter("paramBankAccount", bankDetails),

                    new ReportParameter("paramCertifiedCorrectSignatory", certifiedCorrectSignatory),
                    new ReportParameter("paramCertifiedCorrectSignatoryTitle", certifiedCorrectSignatoryTitle),

                    new ReportParameter("paramReceivedBySignatory", receivedBySignatory),
                    new ReportParameter("paramReceivedBySignatoryTitle", receivedBySignatoryTitle)
                };

                report.ReportPath = $"{Application.StartupPath}Reports\\schedule-of-released-cheques.rdlc";
                report.DataSources.Clear();

                report.DataSources.Add(new ReportDataSource("dtSchedulesOfReleasedCheque", DataTableRCI()));
                report.SetParameters(parameters);
                reportViewer.SetDisplayMode(DisplayMode.PrintLayout);
                reportViewer.ZoomMode = ZoomMode.PageWidth;
                reportViewer.ZoomPercent = 100;
                reportViewer.RefreshReport();

                Cursor = Cursors.Default;
            }
            catch (Exception ex)
            {
                Helper.MessageBoxError(ex.Message);
            }
        }

        private DataTable DataTableRCI()
        {
            int bankAccountID = Convert.ToInt32(cmbBankAccounts.SelectedValue);
            string periodCovered = dtpPeriodCovered.Value.ToString();

            var dtReleasedCheques = new dsLFS.dtSchedulesOfReleasedChequeDataTable();
            DataTable dtReleasedChequesFromDB = AccFactory.ReleasedChequesRepository().GetViewRecordsByBankAccountIDAndPeriodCoveredReleased(bankAccountID, periodCovered);

            if (dtReleasedChequesFromDB.Rows.Count == 0)
                return dtReleasedCheques;

            foreach (DataRow item in dtReleasedChequesFromDB.Rows)
            {
                DataRow row = dtReleasedCheques.NewRow();

                var chequeDate = item["cheque_date"].ToString();
                string chequeNumber = item["cheque_no"].ToString();
                string dvNumber = item["dv_no"].ToString();
                string payee = item["payee"].ToString();
                string natureOfPayment = item["nature_of_payment"].ToString();
                decimal amount = Convert.ToDecimal(item["cheque_amount"]);
                string dateReleased = string.IsNullOrEmpty(item["date_released"].ToString()) ? "" : item["date_released"].ToString();

                row["cheque_date"] = chequeDate;
                row["cheque_serial_number"] = chequeNumber;
                row["dv_number"] = dvNumber;
                row["cafoa_number"] = string.Empty;
                row["payee"] = payee;
                row["nature_of_payment"] = natureOfPayment;
                row["amount"] = amount;
                row["date_released"] = dateReleased;

                dtReleasedCheques.Rows.Add(row);
            }

            return dtReleasedCheques;
        }

        private void frmReleasedChequesReport_Load(object sender, EventArgs e)
        {
            LoadBanks();
            LoadBankAccounts();
        }

        internal void LoadBanks()
        {
            try
            {
                var bankRepository = AccFactory.BanksRepository();
                var dtBank = bankRepository.GetRecords();
                cmbBank.DataSource = dtBank;
                cmbBank.ValueMember = "id";
                cmbBank.DisplayMember = "bank_name";
            }
            catch (Exception ex)
            {
                Helper.MessageBoxError(ex.Message);
            }
        }

        private void LoadBankAccounts()
        {
            int bankID = Convert.ToInt32(cmbBank.SelectedValue);
            DataTable dtBankAccounts = AccFactory.BankAccountsRepository().GetBankAccountsByBankID(bankID);

            cmbBankAccounts.DataSource = dtBankAccounts;
            cmbBankAccounts.ValueMember = "id";
            cmbBankAccounts.DisplayMember = "account_no";
        }

        private void cmbBank_SelectionChangeCommitted(object sender, EventArgs e)
        {
            LoadBankAccounts();
        }


    }
}
