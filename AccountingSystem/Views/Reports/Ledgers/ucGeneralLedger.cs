using DocumentFormat.OpenXml.Bibliography;
using Microsoft.Reporting.WinForms;
using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;

namespace AccountingSystem.Views.Reports.Ledgers
{
    public partial class ucGeneralLedger : UserControl
    {
        private readonly ReportViewer reportViewer;

        public ucGeneralLedger()
        {
            InitializeComponent();
            reportViewer = new ReportViewer();
            reportViewer.Dock = DockStyle.Fill;
            panel1.Controls.Add(reportViewer);
        }

        private DataTable DatatableAccounts()
        {
            DataTable dtAccounts;

            if (string.IsNullOrWhiteSpace(cmbAccount.Text))

                dtAccounts = AccFactory.GeneralLedgerAccountsRepository().GetViewRecords();
            else

                dtAccounts = AccFactory.GeneralLedgerAccountsRepository().GetViewRecordsBySearch(cmbAccount.Text);

            return dtAccounts;
        }

        private void LoadAccounts()
        {
            cmbAccount.DroppedDown = false;

            if (DatatableAccounts().Rows.Count == 0) return;

            var accountDict = new Dictionary<ushort, string>();
            foreach (DataRow item in DatatableAccounts().Rows)
            {
                ushort accountId = Convert.ToUInt16(item["general_ledger_accounts_id"]);
                string accountName = $"{item["account_code"]} - {item["ledger_name"]}";

                accountDict.Add(accountId, accountName);
            }

            cmbAccount.DataSource = new BindingSource(accountDict, null);
            cmbAccount.DisplayMember = "value";
            cmbAccount.ValueMember = "key";
        }

        private void CmbxLedgerAccout_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrEmpty(cmbAccount.Text))
                {
                    cmbAccount.TextChanged -= new EventHandler(CmbxLedgerAccout_TextChanged);
                    LoadAccounts();
                    cmbAccount.SelectedIndex = -1;
                    cmbAccount.TextChanged += new EventHandler(CmbxLedgerAccout_TextChanged);
                }
            }
            catch (Exception ex) { Helper.MessageBoxError(ex.Message); }
        }

        private void LoadFunds()
        {
            DataTable dtFunds = AccFactory.FundsRepository().GetRecords();
            HelperLoadRecords.FundsComboBox(dtFunds, cmbFunds, "fund_name", "id");
        }

        private void LoadYear()
        {
            HelperLoadRecords.YearComboBox(cmbYear);
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

        private void ValidateDebitCreditRow(string particulars, DataRow item, DataRow row)
        {
            if (Convert.ToBoolean(item["is_debit"]))
            {
                row["particulars"] = particulars;
                row["debit_amount"] = item["amount"];
                row["credit_amount"] = 0;
            }
            else
            {
                row["particulars"] = $"{particulars}";
                row["debit_amount"] = 0;
                row["credit_amount"] = item["amount"];
            }
        }

        private string ParseParticulars(DataRow item)
        {
            string particulars;
            if (item["journal_name"].ToString() == "General Journal")
                particulars = item["explanation"].ToString();
            else
                particulars = $"{GetJournalAcronym(item["journal_name"].ToString())} Total";

            return particulars;
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
            newRow["date"] = beginningBalanceDate;
            newRow["particulars"] = "Beginning Balance";
            newRow["ref"] = string.Empty;
            newRow["debit_amount"] = debit;
            newRow["credit_amount"] = credit;
            return newRow;
        }

        private DataTable DataTableGeneralLedger()
        {
            int fundId = Convert.ToInt32(cmbFunds.SelectedValue);
            int generalLedgerId = Convert.ToInt32(cmbAccount.SelectedValue);
            int year = Convert.ToInt16(cmbYear.Text);

            dsLFS.dtGeneralLedgerDataTable dtGeneralLedger = new dsLFS.dtGeneralLedgerDataTable();
            DataTable dtGeneralLedgerFromDB = AccFactory.JEVAccountsRepository().GetViewRecords(fundId, generalLedgerId, (short)year);
            DataRow dataRowBeginningBalance = BeginningBalanceRow(fundId, year, generalLedgerId, dtGeneralLedger);

            int totalRecords = dtGeneralLedgerFromDB.Rows.Count;
            int runningRecordCount = 0;

            if (!string.IsNullOrWhiteSpace(dataRowBeginningBalance["date"].ToString()))
            {
                dtGeneralLedger.Rows.Add(dataRowBeginningBalance);
                totalRecords++;
            };

            foreach (DataRow item in dtGeneralLedgerFromDB.Rows)
            {
                string particulars = ParseParticulars(item);

                DataRow newRow = dtGeneralLedger.NewRow();
                newRow["date"] = item["date_entry"];
                newRow["ref"] = GetJournalAcronym(item["journal_name"].ToString());

                ValidateDebitCreditRow(particulars, item, newRow);
                dtGeneralLedger.Rows.Add(newRow);

                runningRecordCount++;
                int progressPercentage = (runningRecordCount * 100) / runningRecordCount;
                backgroundWorker1.ReportProgress(progressPercentage);
            }
            return dtGeneralLedger;
        }

        private void LoadReport(LocalReport report)
        {
            Cursor.Current = Cursors.WaitCursor;
            short year = Convert.ToInt16(cmbYear.Text);
            ushort generalLedgerId = Convert.ToUInt16(cmbAccount.SelectedValue);

            var lguDict = Helper.LGUDetails();
            var generalLedgerDict = AccFactory.GeneralLedgerAccountsRepository().GetViewRecordByID(generalLedgerId);
            var fundName = cmbFunds.Text;
            report.ReportPath = $"{Application.StartupPath}\\Reports\\general-ledger.rdlc";
            report.DataSources.Clear();

            report.DataSources.Add(new ReportDataSource("dtGeneralLedger", DataTableGeneralLedger()));

            var parameters = new[] {
                new ReportParameter("paramLGUName", $"{lguDict["municipality"]} - {lguDict["lgu_province"]}"),
                new ReportParameter("paramFund", fundName),
                new ReportParameter("paramAccountName", generalLedgerDict["ledger_name"]),
                new ReportParameter("paramAccountCode", generalLedgerDict["account_code"]),
                new ReportParameter("paramYear",year.ToString())
            };
            report.SetParameters(parameters);
            reportViewer.SetDisplayMode(DisplayMode.PrintLayout);
            reportViewer.ZoomMode = ZoomMode.Percent;
            reportViewer.ZoomPercent = 100;
            reportViewer.RefreshReport();

            Cursor.Current = Cursors.Default;
        }

        private bool AccountComboboxEmpty()
        {
            if (string.IsNullOrEmpty(cmbAccount.Text.Trim()))
            {
                cmbAccount.Tag = "Please enter an account.";
                return true;
            }
            else
                return false;
        }

        private bool AccountExist()
        {
            string accountName = cmbAccount.Text.Trim();

            if (cmbAccount.FindStringExact(accountName) == -1 && !string.IsNullOrEmpty(accountName))
            {
                cmbAccount.Tag = "Account you entered doesn't exist";
                return false;
            }
            return true;
        }

        private bool FundsComboboxEmpty()
        {
            if (string.IsNullOrEmpty(cmbAccount.Text.Trim()))
            {
                cmbAccount.Tag = "Please enter a Fund.";
                return true;
            }
            else
                return false;
        }

        private bool FundExist()
        {
            string fundName = cmbFunds.Text.Trim();

            if (cmbFunds.FindStringExact(fundName) == -1 && !string.IsNullOrEmpty(fundName))
            {
                cmbAccount.Tag = "Fund you entered doesn't exist";
                return false;
            }
            return true;
        }

        private void OnLoad()
        {
            if (!DesignMode)
            {
                LoadFunds();
                LoadAccounts();
                cmbAccount.SelectedIndex = -1;
                cmbAccount.TextChanged += new EventHandler(CmbxLedgerAccout_TextChanged);
                LoadYear();
            }
        }

        private void ucGeneralLedger_Load(object sender, EventArgs e)
        {
            try
            {
                OnLoad();
            }
            catch (Exception ex) { Helper.MessageBoxError(ex.Message); }
        }

        private void btnRetrieve_Click(object sender, EventArgs e)
        {
            try
            {
                if (AccountComboboxEmpty() || !AccountExist() || FundsComboboxEmpty() || !FundExist())
                {
                    Helper.MessageBoxError($"{cmbAccount.Tag}");
                    return;
                }

                if (!backgroundWorker1.IsBusy)
                    backgroundWorker1.RunWorkerAsync();
            }
            catch (Exception ex) { Helper.MessageBoxError(ex.Message); }
        }

        private void cmbAccount_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.F1 && cmbAccount.FindStringExact(cmbAccount.Text) == -1 && !string.IsNullOrEmpty(cmbAccount.Text))
                {
                    LoadAccounts();
                    cmbAccount.DroppedDown = true;
                }
            }
            catch (Exception ex) { Helper.MessageBoxError(ex.Message); }
        }

        private void backgroundWorker1_DoWork(object sender, System.ComponentModel.DoWorkEventArgs e)
        {
            Invoke((MethodInvoker)delegate
            {
                progressBar1.Value = 0;
                LoadReport(reportViewer.LocalReport);
            });
        }

        private void backgroundWorker1_ProgressChanged(object sender, System.ComponentModel.ProgressChangedEventArgs e)
        {
            progressBar1.Value = e.ProgressPercentage;
        }

        private void backgroundWorker1_RunWorkerCompleted(object sender, System.ComponentModel.RunWorkerCompletedEventArgs e)
        {
        }
    }
}