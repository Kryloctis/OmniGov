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
        private decimal beginningBalance;

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

            if (string.IsNullOrEmpty(cmbAccount.Text))
            {
                dtAccounts = AccFactory.GeneralLedgerAccountsRepository().GetViewRecords();
            }
            else
            {
                dtAccounts = AccFactory.GeneralLedgerAccountsRepository().GetViewRecordsBySearch(cmbAccount.Text);
            }

            return dtAccounts;
        }

        private void LoadAccounts()
        {
            try
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
                Cursor.Current = Cursors.Default;
            }
            catch (Exception ex)
            {
                Helper.MessageBoxError(ex.Message);
            }
        }

        private void CmbxLedgerAccout_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(cmbAccount.Text))
            {
                cmbAccount.TextChanged -= new EventHandler(CmbxLedgerAccout_TextChanged);
                LoadAccounts();
                cmbAccount.SelectedIndex = -1;
                cmbAccount.TextChanged += new EventHandler(CmbxLedgerAccout_TextChanged);
            }
        }

        private void LoadFunds()
        {
            cmbFunds.DataSource = AccFactory.FundsRepository().GetRecords();
            cmbFunds.ValueMember = "id";
            cmbFunds.DisplayMember = "fund_name";
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

        private void ValidateDebitCreditRow(int fundId, int generalLedgerId, short year, string particulars, DataRow item, DataRow row, ref decimal balance)
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

        private string ParseParticulars(DataRow item)
        {
            string particulars;
            if (item["journal_name"].ToString() == "General Journal")
                particulars = item["explanation"].ToString();
            else
                particulars = $"{GetJournalAcronym(item["journal_name"].ToString())} Total";

            return particulars;
        }

        private DataTable DataTableGeneralLedger()
        {
            int fundId = Convert.ToInt32(cmbFunds.SelectedValue);
            int generalLedgerId = Convert.ToInt32(cmbAccount.SelectedValue);
            short year = Convert.ToInt16(cmbYear.Text);

            var dtGeneralLedger = new dsLFS.GeneralLedgerDataTable();
            var dtGeneralLedgerFromDB = AccFactory.JEVAccountsRepository().GetViewRecords(fundId, generalLedgerId, year);

            string particulars;
            foreach (DataRow item in dtGeneralLedgerFromDB.Rows)
            {
                particulars = ParseParticulars(item);

                DataRow row = dtGeneralLedger.NewRow();
                row["date"] = item["date_entry"];
                row["ref"] = GetJournalAcronym(item["journal_name"].ToString());

                ValidateDebitCreditRow(fundId, generalLedgerId, year, particulars, item, row, ref beginningBalance);

                dtGeneralLedger.Rows.Add(row);
            }

            return dtGeneralLedger;
        }

        private void BeginningBalanceRow(byte fundId, short year, ushort generalLedgerId, out string balanceDate, out string balanceDebit, out string balanceCredit, out string balance)
        {
            beginningBalance = 0;
            var DebitBeginningBalance = AccFactory.BeginningBalancesRepository().GetSumBalancesBy_FundId_GenLedgId_IsDebit_SubLedgId(fundId, generalLedgerId, year, 1);
            var CreditBeginningBalance = AccFactory.BeginningBalancesRepository().GetSumBalancesBy_FundId_GenLedgId_IsDebit_SubLedgId(fundId, generalLedgerId, year, 0);

            beginningBalance = (DebitBeginningBalance - CreditBeginningBalance);
            balance = beginningBalance.ToString();
            decimal debit = DebitBeginningBalance > CreditBeginningBalance ? Math.Abs(beginningBalance) : 0;
            decimal credit = DebitBeginningBalance < CreditBeginningBalance ? Math.Abs(beginningBalance) : 0;

            balanceDebit = debit.ToString();
            balanceCredit = debit.ToString();

            var dateDict = AccFactory.BeginningBalancesRepository().GetRecordBy_FundId_GenLedgId_Year_SubLedgId(fundId, generalLedgerId, year);
            balanceDate = string.IsNullOrEmpty(dateDict["date_entry"]) ? string.Empty : Convert.ToDateTime(dateDict["date_entry"]).ToString("MM/dd/yyyy");
        }

        private void LoadReport(LocalReport report)
        {
            try
            {
                Cursor.Current = Cursors.WaitCursor;
                byte fundId = (byte)cmbFunds.SelectedValue;
                short year = Convert.ToInt16(cmbYear.Text);
                ushort generalLedgerId = (ushort)cmbAccount.SelectedValue;

                string balanceDate, balanceDebit, balanceCredit, balance;
                BeginningBalanceRow(fundId, year, generalLedgerId, out balanceDate, out balanceDebit, out balanceCredit, out balance);
                var lguDict = Helper.LGUDetails();
                var generalLedgerDict = AccFactory.GeneralLedgerAccountsRepository().GetViewRecordByID(generalLedgerId);
                var fundName = cmbFunds.Text;
                report.ReportPath = $"{Application.StartupPath}\\Reports\\general-ledger.rdlc";
                report.DataSources.Clear();

                report.DataSources.Add(new ReportDataSource("GeneralLedger", DataTableGeneralLedger()));

                var parameters = new[] {
                    new ReportParameter("paramLGUName", lguDict["lgu_name"]),
                    new ReportParameter("paramFund", fundName),
                    new ReportParameter("paramAccountName", generalLedgerDict["ledger_name"]),
                    new ReportParameter("paramAccountCode", generalLedgerDict["account_code"]),
                    new ReportParameter("paramBalanceDate", balanceDate),
                    new ReportParameter("paramBalanceDebit", balanceDebit),
                    new ReportParameter("paramBalanceCredit", balanceCredit),
                    new ReportParameter("paramBalance", balance),
                    new ReportParameter("paramYear",year.ToString())
                };
                report.SetParameters(parameters);
                Cursor.Current = Cursors.Default;
            }
            catch (Exception ex)
            {
                Helper.MessageBoxError(ex.Message);
            }
        }

        //VALIDATIONS
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

        private void ucGeneralLedger_Load(object sender, EventArgs e)
        {
            if (!DesignMode)
            {
                LoadFunds();

                //ACCOUNTS
                LoadAccounts();
                cmbAccount.SelectedIndex = -1;
                cmbAccount.TextChanged += new EventHandler(CmbxLedgerAccout_TextChanged);

                LoadYear();
            }
        }

        private void btnRetrieve_Click(object sender, EventArgs e)
        {
            if (AccountComboboxEmpty() || !AccountExist() || FundsComboboxEmpty() || !FundExist())
            {
                Helper.MessageBoxError($"{cmbAccount.Tag}");
                return;
            }

            LoadReport(reportViewer.LocalReport);
            reportViewer.SetDisplayMode(DisplayMode.PrintLayout);
            reportViewer.ZoomMode = ZoomMode.Percent;
            reportViewer.ZoomPercent = 100;
            reportViewer.RefreshReport();
        }

        private void cmbAccount_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F1 && cmbAccount.FindStringExact(cmbAccount.Text) == -1 && !string.IsNullOrEmpty(cmbAccount.Text))
            {
                LoadAccounts();
                cmbAccount.DroppedDown = true;
            }
        }
    }
}