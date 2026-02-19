using Microsoft.Reporting.WinForms;
using OmniGov.App.Helpers;
using System;
using System.ComponentModel;
using System.Data;
using System.Windows.Forms;
using Treasury.Data.Factories;

namespace OmniGov.App.Views.Reports.Cashbook
{
    public partial class frmCashbook : Form
    {
        public frmCashbook()
        {
            InitializeComponent();
            reportViewer1.Dock = DockStyle.Fill;
            panel1.Controls.Add(reportViewer1);
            Helper.LoadFormIcon(this);
        }

        private void frmCashbook_Load(object sender, EventArgs e)
        {
            try
            {
                OnLoad();
            }
            catch (Exception ex) { Helper.MessageBoxError(ex.Message); }
        }

        private void OnLoad()
        {
            LoadBanks();
            LoadBankAccounts();
        }

        internal void LoadBanks()
        {
            var dtBanks = TreasuryFactory.BanksRepository().GetRecords();
            HelperLoadRecords.BankComboBox(dtBanks, cmbxBank, "id", "bank_name");
        }

        internal void LoadBankAccounts()
        {
            int bankID = Convert.ToInt32(cmbxBank.SelectedValue);
            DataTable dtBankAccounts = TreasuryFactory.BankAccountsRepository().GetBankAccountsByBankID(bankID);
            HelperLoadRecords.BankAccountsComboBox(dtBankAccounts, cmbxBankAcc, "id", "account_no");
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
                int bankId = Convert.ToInt32(cmbxBank.SelectedValue);
                int bankAccountId = Convert.ToInt32(cmbxBankAcc.SelectedValue);
                ToogleRunButton(false);
                backgroundWorker1.RunWorkerAsync((bankId, bankAccountId));
            }
        }

        private void cmbxBank_SelectionChangeCommitted(object sender, EventArgs e)
        {
            try
            {
                LoadBankAccounts();
            }
            catch (Exception ex) { Helper.MessageBoxError(ex.Message); }
        }

        private void btnRunReport_Click(object sender, EventArgs e)
        {
            try
            {
                if (cmbxBank.SelectedIndex == -1 && cmbxBankAcc.SelectedIndex == -1)
                {
                    Helper.MessageBoxError("Please select Bank and Bank Accounts");
                    return;
                }

                LoadReport();
            }
            catch (Exception ex) { Helper.MessageBoxError(ex.Message); }
        }

        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
            try
            {
                var parameters = ((int bankId, int bankAccountId))e.Argument;
                var dtCashBook = new dsLFS.dtCashbookDataTable().Clone();
                var dtCashBookFromDb = TreasuryFactory.BankDepositsRepository().GetRecordsByBankAndAccountID(parameters.bankId, parameters.bankAccountId);
                var dtRci = TreasuryFactory.RciRepository().GetRecordsByBankAndAccountID(parameters.bankId, parameters.bankAccountId);

                int totalProgressCount = dtCashBookFromDb.Rows.Count + dtRci.Rows.Count;
                int progressCount = 0;

                if (dtCashBookFromDb.Rows.Count > 0 || dtRci.Rows.Count > 0)
                {
                    decimal balance = 0;
                    decimal debit = 0;
                    decimal credit = 0;
                    foreach (DataRow item in dtCashBookFromDb.Rows)
                    {
                        DataRow row = dtCashBook.NewRow();
                        row["date"] = item["date"];
                        row["particulars"] = string.Format("Deposit - {0} - {1}", item["bank_name"], item["account_no"]);
                        row["reference"] = item["reference"];
                        row["debit"] = item["amount"];
                        row["credit"] = 0;
                        row["balance"] = balance;
                        dtCashBook.Rows.Add(row);
                        progressCount++;
                        Helper.ProgressCounter(backgroundWorker1, totalProgressCount, progressCount);
                    }

                    foreach (DataRow item in dtRci.Rows)
                    {
                        DataRow row = dtCashBook.NewRow();
                        row["date"] = item["cheque_date"];
                        row["particulars"] = string.Format("Check Issued - {0} - {1}", item["payee"], item["nature_of_payment"]);
                        row["reference"] = string.Format("{0} - {1}", item["cheque_no"], item["dv_no"]);
                        row["credit"] = item["amount"];
                        row["debit"] = 0;
                        row["balance"] = balance;
                        dtCashBook.Rows.Add(row);
                        progressCount++;
                        Helper.ProgressCounter(backgroundWorker1, totalProgressCount, progressCount);
                    }
                    dtCashBook.Select(string.Empty, "date ASC");

                    if (dtCashBook.Rows.Count > 0)
                    {
                        foreach (DataRow item in dtCashBook.Rows)
                        {
                            debit += item["debit"].Equals(DBNull.Value) ? 0 : Convert.ToDecimal(item["debit"]);
                            credit += item["credit"].Equals(DBNull.Value) ? 0 : Convert.ToDecimal(item["credit"]);
                            balance = debit - credit;
                            item["balance"] = balance;
                        }
                    }
                }
                e.Result = dtCashBook;
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
                    ToogleRunButton(true);
                    return;
                }

                if (dataTable.Rows.Count < 1)
                    progressBar1.Value = 100;

                var localReport = reportViewer1.LocalReport;
                var account = cmbxBank.Text;
                string lguName = $"{(ServerHelper.SelectedProfile?.Name ?? "")} - {(ServerHelper.SelectedProfile?.ProvinceName ?? "")}";

                var parameters = new ReportParameter[]
                {
                    new("paramLGUName", lguName),
                    new("paramBankaccount", account)
                };

                localReport.ReportPath = $"{Application.StartupPath}Reports\\cashbook.rdlc";
                localReport.DataSources.Clear();
                localReport.DataSources.Add(new ReportDataSource("dtCashbook", dataTable));
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

