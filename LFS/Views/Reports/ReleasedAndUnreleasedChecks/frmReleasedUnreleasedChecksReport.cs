using LFS.Helpers;
using Microsoft.Reporting.WinForms;
using OmniGov.Core.Repositories;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Windows.Forms;
using Treasury.Data;

namespace LFS.Views.Reports.ReleasedAndUnreleasedCheques
{
    public partial class frmReleasedUnreleasedChecksReport : Form
    {
        public frmReleasedUnreleasedChecksReport()
        {
            InitializeComponent();
            Helper.LoadFormIcon(this);

            reportViewer1 = new ReportViewer();
            reportViewer1.Dock = DockStyle.Fill;
            panel1.Controls.Add(reportViewer1);
        }

        internal void LoadBanks()
        {
            var dtBank = TreasuryFactory.BanksRepository().GetRecords();
            cmbBank.DataSource = dtBank;
            cmbBank.ValueMember = "id";
            cmbBank.DisplayMember = "bank_name";
        }

        private void LoadBankAccounts()
        {
            int bankID = Convert.ToInt32(cmbBank.SelectedValue);
            DataTable dtBankAccounts = TreasuryFactory.BankAccountsRepository().GetBankAccountsByBankID(bankID);
            cmbBankAccounts.DataSource = dtBankAccounts;
            cmbBankAccounts.ValueMember = "id";
            cmbBankAccounts.DisplayMember = "account_no";
        }

        private void frmReleasedChequesReport_Load(object sender, EventArgs e)
        {
            try
            {
                LoadBanks();
                LoadBankAccounts();
            }
            catch (Exception ex) { Helper.MessageBoxError(ex.Message); }
        }

        private void cmbBank_SelectionChangeCommitted(object sender, EventArgs e)
        {
            try
            {
                LoadBankAccounts();
            }
            catch (Exception ex) { Helper.MessageBoxError(ex.Message); }
        }

        private void ToogleRunButton(bool isGenerated)
        {
            btnRunReport.Text = isGenerated ? "Run Report" : "Generating Report...";
            btnRunReport.Enabled = isGenerated;
        }

        private void btnRunReport_Click(object sender, EventArgs e)
        {
            try
            {
                LoadReport();
            }
            catch (Exception ex) { Helper.MessageBoxError(ex.Message); }
        }

        private void LoadReport()
        {
            if (!backgroundWorker1.IsBusy)
            {
                progressBar1.Value = 0;
                bool isRealeased = radReleased.Checked;
                int bankAccountId = Convert.ToInt32(cmbBankAccounts.SelectedValue);
                string periodCovered = dtpPeriodCovered.Value.ToString();
                ToogleRunButton(false);
                backgroundWorker1.RunWorkerAsync((isRealeased, bankAccountId, periodCovered));
            }
        }

        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
            try
            {
                var parameters = ((bool isReleased, int bankAccountId, string periodCovered))e.Argument;
                var dtReleasedCheques = new dsLFS.dtSchedulesOfReleasedChequeDataTable().Clone();
                DataTable dtDb =
                    parameters.isReleased ?
                    TreasuryFactory.ReleasedChequesRepository().GetViewRecordsByBankAccountIDAndPeriodCoveredReleased(parameters.bankAccountId, parameters.periodCovered) :
                    TreasuryFactory.ReleasedChequesRepository().GetViewRecordsByBankAccountIDAndPeriodCoveredUnReleased(parameters.bankAccountId, parameters.periodCovered);

                foreach (DataRow item in dtDb.Rows)
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

                e.Result = dtReleasedCheques;
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
                int bankAccountId = Convert.ToInt32(cmbBankAccounts.SelectedValue);
                var dictBankAccount = TreasuryFactory.BankAccountsRepository().GetViewRecordById(bankAccountId);
                string bankDetails = string.Format("{0} - {1}", dictBankAccount["bank_name"], dictBankAccount["account_no"]);

                (string reportPath, string dtName) localReportParam;
                if (radReleased.Checked)
                {
                    localReportParam.reportPath = $"{Application.StartupPath}Reports\\schedule-of-released-cheques.rdlc";
                    localReportParam.dtName = "dtSchedulesOfReleasedCheque";
                }
                else
                {
                    localReportParam.reportPath = $"{Application.StartupPath}Reports\\schedule-of-unreleased-cheques.rdlc";
                    localReportParam.dtName = "dtSchedulesOfUnreleasedCheque";
                }

                var dictCertifiedCorrect =
                    radReleased.Checked ?
                    Factory.SignatoriesHasReferencesRepository().GetSigntryByRefDoc("Certified Correct", "Schedule of Released Checks") :
                    Factory.SignatoriesHasReferencesRepository().GetSigntryByRefDoc("Certified Correct", "Schedule of UnReleased Checks");

                var dictReceivedBy =
                    radReleased.Checked ?
                    Factory.SignatoriesHasReferencesRepository().GetSigntryByRefDoc("Received By", "Schedule of Released Checks") :
                    Factory.SignatoriesHasReferencesRepository().GetSigntryByRefDoc("Received By", "Schedule of UnReleased Checks");

                var certifiedCorrectSig = ParseSignatory(dictCertifiedCorrect);
                var receivedBySig = ParseSignatory(dictReceivedBy);

                static (string signatoryName, string signatoryTitle) ParseSignatory(Dictionary<string, string> dictSignatory)
                {
                    if (dictSignatory.Count > 0)
                    {
                        string prefix = dictSignatory["signatories_prefix"].ToString();
                        string firstName = dictSignatory["signatories_first_name"].ToString();
                        char middleInitial = Convert.ToChar(dictSignatory["signatories_middle_initial"]);
                        string lastName = dictSignatory["signatories_last_name"].ToString();
                        string suffix = dictSignatory["signatories_suffix"].ToString();

                        string signatoryName = $"{(string.IsNullOrEmpty(prefix) ? string.Empty : $"{prefix}.")} {firstName} {middleInitial}. {lastName}{(string.IsNullOrEmpty(suffix) ? string.Empty : $", {suffix}")}";

                        return (signatoryName, dictSignatory["signatories_title"]);
                    }

                    return (string.Empty, string.Empty);
                }

                var parameters = new ReportParameter[]
                {
                    new("paramPeriodCovered", dtpPeriodCovered.Value.ToString()),
                    new("paramFund", "General Fund"),
                    new("paramLGUName", ServerHelper.selectedServer.MunicipalityName),
                    new("paramBankAccount", bankDetails),
                    new("paramCertifiedCorrectSignatory", certifiedCorrectSig.signatoryName),
                    new("paramCertifiedCorrectSignatoryTitle", certifiedCorrectSig.signatoryTitle),
                    new("paramReceivedBySignatory", receivedBySig.signatoryName),
                    new("paramReceivedBySignatoryTitle", receivedBySig.signatoryTitle)
                };

                localReport.ReportPath = localReportParam.reportPath;
                localReport.DataSources.Clear();
                localReport.DataSources.Add(new ReportDataSource(localReportParam.dtName, dataTable));
                localReport.SetParameters(parameters);
                reportViewer1.SetDisplayMode(DisplayMode.PrintLayout);
                reportViewer1.ZoomMode = ZoomMode.FullPage;
                reportViewer1.ZoomPercent = 100;
                reportViewer1.RefreshReport();
                ToogleRunButton(true);
            }
            catch (Exception ex) { Helper.MessageBoxError(ex.Message); }
        }
    }
}