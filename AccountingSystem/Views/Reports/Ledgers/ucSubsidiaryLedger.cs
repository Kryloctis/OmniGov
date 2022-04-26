using Microsoft.Reporting.WinForms;
using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;

namespace AccountingSystem.Views.Reports.Ledgers
{
    public partial class ucSubsidiaryLedger : UserControl
    {
        private readonly ReportViewer reportViewer;
        private decimal beginningBalance;

        public ucSubsidiaryLedger()
        {
            InitializeComponent();
            reportViewer = new ReportViewer();
            reportViewer.Dock = DockStyle.Fill;
            panel1.Controls.Add(reportViewer);
        }

        private void ucSubsidiaryLedger_Load(object sender, EventArgs e)
        {
            if (!DesignMode)
            {
                //ACCOUNTS
                LoadAccounts();
                cmbAccount.SelectedIndex = -1;
                cmbAccount.TextChanged += new EventHandler(CmbxLedgerAccout_TextChanged);

                LoadFunds();
                LoadYear();
            }
        }

        private void LoadFunds()
        {
            cmbFunds.DataSource = Factory.FundsRepository().GetRecords();
            cmbFunds.ValueMember = "id";
            cmbFunds.DisplayMember = "fund_name";
        }

        private void LoadYear()
        {
            HelperLoadRecords.YearComboBox(cmbYear);
        }

        private void LoadSubsidiaryAccounts(byte fundId, ushort generalLedgerId)
        {
            var dtSubsidiaryLedger = Factory.SubsidiaryLedgerAccountsRepository().GetRecordsByFundAndGeneralLedger(fundId, generalLedgerId);
            HelperLoadRecords.SubsidiaryLedgerComboBox(dtSubsidiaryLedger, cmbSubsidiaryLedger, "sub_name", "id");
        }

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

        private DataTable DataTableSubsidiaryLedger()
        {
            int fundId = Convert.ToInt32(cmbFunds.SelectedValue);
            int generalLedgerId = Convert.ToInt32(cmbAccount.SelectedValue);
            int subsidiaryLedgerId = Convert.ToInt32(cmbSubsidiaryLedger.SelectedValue);
            short year = Convert.ToInt16(cmbYear.Text);

            var dtSubsidiaryLedger = new dsLFS.SubsidiaryLedgerDataTable();
            var dtSubsidiaryLedgerFromDB = Factory.JEVAccountsRepository().GetViewRecordsByFundAndSubsidiaryLedgerAndSubsidiaryLedgerAndYear(fundId, generalLedgerId, subsidiaryLedgerId, year);

            string particulars;
            foreach (DataRow item in dtSubsidiaryLedgerFromDB.Rows)
            {
                particulars = item["explanation"].ToString();

                DataRow row = dtSubsidiaryLedger.NewRow();
                row["date"] = item["date_entry"];
                row["ref"] = item["jev_no"];

                ValidateDebitCreditRow(particulars, item, row, ref beginningBalance);

                dtSubsidiaryLedger.Rows.Add(row);
            }

            return dtSubsidiaryLedger;
        }

        private void BeginningBalanceRow(byte fundId, short year, ushort generalLedgerId, out string balanceDate, out string balanceDebit, out string balanceCredit, out string balance)
        {
            beginningBalance = 0;
            ushort subsidiaryLedgerId = Convert.ToUInt16(cmbSubsidiaryLedger.SelectedValue);
            var DebitBeginningBalance = Factory.BeginningBalancesRepository().GetSumBalances(fundId, generalLedgerId, year, 1, subsidiaryLedgerId);
            var CreditBeginningBalance = Factory.BeginningBalancesRepository().GetSumBalances(fundId, generalLedgerId, year, 0, subsidiaryLedgerId);

            beginningBalance = (DebitBeginningBalance - CreditBeginningBalance);
            balance = beginningBalance.ToString();
            balanceDebit = DebitBeginningBalance > CreditBeginningBalance ? Math.Abs(beginningBalance).ToString() : string.Empty;
            balanceCredit = DebitBeginningBalance < CreditBeginningBalance ? Math.Abs(beginningBalance).ToString() : string.Empty;

            var dateDict = Factory.BeginningBalancesRepository().GetRecordByFundsAndGeneralLedgerID(fundId, generalLedgerId, year, subsidiaryLedgerId);
            balanceDate = string.IsNullOrEmpty(dateDict["date_entry"]) ? string.Empty : Convert.ToDateTime(dateDict["date_entry"]).ToString("MMM,dd,yyyy");
        }

        private void LoadReport(LocalReport report)
        {
            try
            {
                Cursor.Current = Cursors.WaitCursor;
                byte fundId = (byte)cmbFunds.SelectedValue;
                short year = Convert.ToInt16(cmbYear.Text);
                ushort generalLedgerId = (ushort)cmbAccount.SelectedValue;
                int subsidiaryLedgerId = (int)cmbSubsidiaryLedger.SelectedValue;

                string balanceDate, balanceDebit, balanceCredit, balance;
                BeginningBalanceRow(fundId, year, generalLedgerId, out balanceDate, out balanceDebit, out balanceCredit, out balance);

                var lguDict = Helper.LGUDetails();
                var generalLedgerDict = Factory.GeneralLedgerAccountsRepository().GetViewRecordByID(generalLedgerId);
                var subsidiaryLedgerDict = Factory.SubsidiaryLedgerAccountsRepository().GetRecordByID(subsidiaryLedgerId);
                var fundName = cmbFunds.Text;
                report.ReportPath = $"{Application.StartupPath}\\Reports\\subsidiary-ledger.rdlc";
                report.DataSources.Clear();

                report.DataSources.Add(new ReportDataSource("SubsidiaryLedger", DataTableSubsidiaryLedger()));

                var parameters = new[] {
                    new ReportParameter("paramLGUName", lguDict["lgu_name"]),
                    new ReportParameter("paramFund", fundName),
                    new ReportParameter("paramGLCode", generalLedgerDict["account_code"]),
                    new ReportParameter("paramSLCode", subsidiaryLedgerDict["sub_code"]),
                    new ReportParameter("paramAccountOf", generalLedgerDict["ledger_name"]),
                    new ReportParameter("paramAddress", subsidiaryLedgerDict["address"]),
                    new ReportParameter("paramContactPerson", subsidiaryLedgerDict["contact_person"]),
                    new ReportParameter("paramContactNoEmail", subsidiaryLedgerDict["contact"]),
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
                Helper.MessageBoxError($"{ex.Message} /////// {ex.StackTrace}");
            }
        }

        private void cmbAccount_SelectionChangeCommitted(object sender, EventArgs e)
        {
            byte fundId = (byte)cmbFunds.SelectedValue;
            ushort generalLedgerId = (ushort)cmbAccount.SelectedValue;
            LoadSubsidiaryAccounts(fundId, Convert.ToUInt16(generalLedgerId));
        }

        //ACCOUNT COMBOBOX
        private DataTable DatatableAccounts()
        {
            DataTable dtAccounts;

            if (string.IsNullOrEmpty(cmbAccount.Text))
            {
                dtAccounts = Factory.GeneralLedgerAccountsRepository().GetViewRecords();
            }
            else
            {
                dtAccounts = Factory.GeneralLedgerAccountsRepository().GetViewRecordsBySearch(cmbAccount.Text);
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

        private void cmbAccount_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F1 && cmbAccount.FindStringExact(cmbAccount.Text) == -1 && !string.IsNullOrEmpty(cmbAccount.Text))
            {
                LoadAccounts();
                cmbAccount.DroppedDown = true;
            }
        }

        private void btnRetrieve_Click_1(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(cmbAccount.Text) || string.IsNullOrWhiteSpace(cmbSubsidiaryLedger.Text))
            {
                Helper.MessageBoxError("Please select a subsidiary ledger account.");
                return;
            }

            LoadReport(reportViewer.LocalReport);
            reportViewer.SetDisplayMode(DisplayMode.PrintLayout);
            reportViewer.ZoomMode = ZoomMode.Percent;
            reportViewer.ZoomPercent = 100;
            reportViewer.RefreshReport();
        }

    }
}
