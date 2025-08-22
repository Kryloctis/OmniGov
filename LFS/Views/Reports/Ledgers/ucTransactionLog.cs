using ACC.Data;
using LFS.Helpers;
using Microsoft.Reporting.WinForms;
using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;

namespace LFS.Views.Reports.Ledgers
{
    public partial class ucTransactionLog : UserControl
    {
        private readonly ReportViewer reportViewer;

        public ucTransactionLog()
        {
            InitializeComponent();
            reportViewer = new ReportViewer();
            reportViewer.Dock = DockStyle.Fill;
            panel1.Controls.Add(reportViewer);
        }

        internal void OnLoad()
        {
            LoadAccounts();
            LoadFunds();
            LoadYear();
            cmbxFunds.Tag = string.Empty;
            cmbxAccount.Tag = string.Empty;
        }

        private void LoadFunds()
        {
            DataTable dtFunds = AccFactory.FundsRepository().GetRecords();
            HelperLoadRecords.FundsComboBox(dtFunds, cmbxFunds, "fund_name", "id");
        }

        private void LoadYear()
        {
            nudYear.Maximum = Helper.GetCurrentDate().Year;
            nudYear.Value = Helper.GetCurrentDate().Year;
        }

        #region Accounts

        private DataTable DatatableAccounts()
        {
            DataTable dtAccounts = AccFactory.GeneralLedgerAccountsRepository().GetViewRecords();
            var dataTable = new DataTable();
            var dtColumns = new DataColumn[]
            {
                new DataColumn(Name = "id", typeof(int)),
                new DataColumn(Name = "account_name", typeof(string))
            };
            dataTable.Columns.AddRange(dtColumns);

            foreach (DataRow row in dtAccounts.Rows)
            {
                var newRow = dataTable.NewRow();
                ushort accountId = Convert.ToUInt16(row["general_ledger_accounts_id"]);
                string accountName = $"{row["account_code"]} - {row["ledger_name"]}";

                newRow["id"] = accountId;
                newRow["account_name"] = accountName;
                dataTable.Rows.Add(newRow);
            }

            return dataTable;
        }

        private void LoadAccounts(string searchText = "", bool isSearch = false)
        {
            cmbxAccount.TextChanged -= new EventHandler(cmbxAccount_TextChanged);
            HelperLoadRecords.SearchableCombobox(cmbxAccount, DatatableAccounts(), "id", "account_name", "account_name", searchText, isSearch);
            cmbxAccount.TextChanged += new EventHandler(cmbxAccount_TextChanged);
        }

        private void cmbxAccount_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(cmbxAccount.Text.Trim()))
                    LoadAccounts();
            }
            catch (Exception ex) { Helper.MessageBoxError(ex.Message); }
        }

        private void cmbAccount_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                string searchText = cmbxAccount.Text.Trim();
                if (e.KeyCode == Keys.Enter)
                {
                    LoadAccounts(searchText, true);
                    e.Handled = true;
                    e.SuppressKeyPress = true;
                }
            }
            catch (Exception ex) { Helper.MessageBoxError(ex.Message); }
        }

        #endregion Accounts

        private static void ValidateDebitCreditRow(string particulars, DataRow item, DataRow row, ref decimal balance)
        {
            decimal amount = Convert.ToDecimal(item["amount"]);

            if (Convert.ToBoolean(item["is_debit"]))
            {
                row["particulars"] = particulars;
                row["debit_amount"] = item["amount"];
                row["credit_amount"] = 0;
                balance += amount;
            }
            else
            {
                row["particulars"] = $"{particulars}";
                row["debit_amount"] = 0;
                row["credit_amount"] = item["amount"];
                balance -= amount;
            }
            row["balance"] = balance;
        }

        private string GetJournalAcronym(string journalName)
        {
            switch (journalName)
            {
                case "General Journal":
                    return "GJ";

                case "Cash Receipts Journal":
                    return "CRJ";

                case "Procurement Received Journal":
                    return "PRJ";

                case "Cash Disbursements Journal":
                    return "CsDJ";

                case "Check Disbursements Journal":
                    return "CkDJ";

                case "Advice to Debit Account Disbursement Journal":
                    return "ADADJ";
            }

            return "";
        }

        private DataTable TransactionLogDataTable()
        {
            //int fundId = Convert.ToInt32(cmbxFunds.SelectedValue);
            //int generalLedgerId = Convert.ToInt32(cmbxAccount.SelectedValue);
            //short year = Convert.ToInt16(nudYear.Value);

            //var dataTable = new dsLFS.dtTransactionLogDataTable();
            //var dtSubsidiaryLedgerFromDB = AccFactory.JEVAccountsRepository().GetViewRecords(fundId, generalLedgerId, year);
            //int totalCount = dataTable.Rows.Count;
            //int runningCount = 0;

            //foreach (DataRow row in dtSubsidiaryLedgerFromDB.Rows)
            //{
            //    DataRow newRow = dataTable.NewRow();
            //    int jevId = Convert.ToInt32(row["jev_id"]);
            //    string jevNo = row["full_jev_no"].ToString();
            //    string journalName = GetJournalAcronym(row["journal_name"].ToString());
            //    string dvNo = row[""]

            //    newRow["jev_no"] = ;
            //    newRow["journal"] = ;
            //    newRow["respond_center"] = ;
            //    newRow["cafoa_no"] = ;
            //    newRow["dv_payroll_no"] = ;
            //    newRow["check_no"] = ;
            //    newRow["other_ref"] = ;
            //    newRow["payee"] = ;
            //    newRow["particulars"] = ;
            //    newRow["account"] = ;
            //    newRow["account_code"] = ;
            //    newRow["sub_account_code"] = ;
            //    newRow["debit_amount"] = ;
            //    newRow["credit_amount"] = ;

            //    ValidateDebitCreditRow(particulars, row, newRow, ref beginningBalance);

            //    runningCount++;
            //    int progressPercentage = (runningCount * 100) / totalCount;
            //    dataTable.Rows.Add(newRow);
            //}

            return new DataTable();
        }

        private DataRow BeginningBalanceRow(int fundId, int year, int generalLedgerId, DataTable dataTable)
        {
            decimal DebitBeginningBalance = AccFactory.BeginningBalancesRepository().GetSumBalancesBy_FundId_GenLedgId_IsDebit_SubLedgId((byte)fundId, (ushort)generalLedgerId, (short)year, true);
            decimal CreditBeginningBalance = AccFactory.BeginningBalancesRepository().GetSumBalancesBy_FundId_GenLedgId_IsDebit_SubLedgId((byte)fundId, (ushort)generalLedgerId, (short)year, false);

            decimal beginningBalance = DebitBeginningBalance - CreditBeginningBalance;
            decimal debit = DebitBeginningBalance > CreditBeginningBalance ? Math.Abs(beginningBalance) : 0;
            decimal credit = DebitBeginningBalance < CreditBeginningBalance ? Math.Abs(beginningBalance) : 0;

            Dictionary<string, string> dateDict = AccFactory.BeginningBalancesRepository().GetRecordBy_FundId_GenLedgId_Year_SubLedgId((byte)fundId, (ushort)generalLedgerId, (short)year);

            object beginningBalanceDate = string.IsNullOrEmpty(dateDict["date_entry"]) ? DBNull.Value : Convert.ToDateTime(dateDict["date_entry"]).ToShortDateString();

            DataRow newRow = dataTable.NewRow();
            newRow["jev_no"] = beginningBalanceDate;
            newRow["particulars"] = "Beginning Balance";
            newRow["ref"] = string.Empty;
            newRow["debit_amount"] = debit;
            newRow["credit_amount"] = credit;
            return newRow;
        }

        private void LoadReport(LocalReport report)
        {
            byte fundId = (byte)cmbxFunds.SelectedValue;
            short year = Convert.ToInt16(nudYear.Value);
            ushort generalLedgerId = (ushort)cmbxAccount.SelectedValue;

            var generalLedgerDict = AccFactory.GeneralLedgerAccountsRepository().GetViewRecordByID(generalLedgerId);
            var fundName = cmbxFunds.Text;
            report.ReportPath = $"{Application.StartupPath}\\Reports\\Ledgers\\transaction_log.rdlc";
            report.DataSources.Clear();

            report.DataSources.Add(new ReportDataSource("dtTransactionLog", TransactionLogDataTable()));

            string lguName = $"{ServerHelper.selectedServer.MunicipalityName} - {ServerHelper.selectedServer.ProvinceName}";

            var parameters = new ReportParameter[]
            {
                new("paramLGUName", lguName),
                new("paramFund", fundName),
                new("paramAccountCode", generalLedgerDict["account_code"]),
                new("paramAccount", generalLedgerDict["ledger_name"]),
                new("paramYear",year.ToString())
            };

            report.SetParameters(parameters);
            reportViewer.SetDisplayMode(DisplayMode.PrintLayout);
            reportViewer.ZoomMode = ZoomMode.Percent;
            reportViewer.ZoomPercent = 100;
            reportViewer.RefreshReport();
        }

        private string GetFormErrors()
        {
            var errorArray = new string[]
            {
                cmbxFunds.Tag.ToString(),
                cmbxAccount.Tag.ToString()
            };

            return AccFactory.CreateErrors(errorArray).GenerateErrorMessage();
        }

        private void btnRetrieve_Click(object sender, EventArgs e)
        {
            try
            {
                if (!this.ValidateChildren())
                {
                    Helper.MessageBoxError(GetFormErrors());
                    return;
                }

                if (!backgroundWorker1.IsBusy)
                    backgroundWorker1.RunWorkerAsync();
            }
            catch (Exception ex) { Helper.MessageBoxError(ex.Message); }
        }

        private void backgroundWorker1_DoWork(object sender, System.ComponentModel.DoWorkEventArgs e)
        {
            try
            {
                Invoke((MethodInvoker)delegate
                 {
                     LoadReport(reportViewer.LocalReport);
                 });
            }
            catch (Exception ex) { Helper.MessageBoxError(ex.Message); }
        }

        private void backgroundWorker1_ProgressChanged(object sender, System.ComponentModel.ProgressChangedEventArgs e)
        {
            progressBar1.Value = e.ProgressPercentage;
        }
    }
}