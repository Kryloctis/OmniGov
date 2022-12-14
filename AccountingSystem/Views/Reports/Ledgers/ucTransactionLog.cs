using Microsoft.Reporting.WinForms;
using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;

namespace AccountingSystem.Views.Reports.Ledgers
{
    public partial class ucTransactionLog : UserControl
    {
        private readonly ReportViewer reportViewer;
        private decimal beginningBalance;

        public ucTransactionLog()
        {
            InitializeComponent();
            reportViewer = new ReportViewer();
            reportViewer.Dock = DockStyle.Fill;
            panel1.Controls.Add(reportViewer);
        }

        private void ucTransactionLog_Load(object sender, System.EventArgs e)
        {
            if (!DesignMode)
            {
                LoadAccounts();
                cmbAccount.SelectedIndex = -1;
                cmbAccount.TextChanged += new EventHandler(CmbxLedgerAccout_TextChanged);

                LoadFunds();
                LoadYear();
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

        private DataTable SubsidiaryLegerAccountsDataTable()
        {
            var dataTable = new DataTable();
            dataTable.Columns.Add("id", typeof(Int32));
            dataTable.Columns.Add("sub_name");

            byte fundId = (byte)cmbFunds.SelectedValue;
            ushort generalLedgerId = (ushort)cmbAccount.SelectedValue;

            var dtSubsidiaryLedger = AccFactory.SubsidiaryLedgerAccountsRepository().GetRecordsByFundAndGeneralLedger(fundId, generalLedgerId);

            foreach (DataRow dataRow in dtSubsidiaryLedger.Rows)
            {
                string subsidiaryName = $"{dataRow["sub_code"]} - {dataRow["sub_name"]}";
                int subId = Convert.ToInt32(dataRow["id"]);

                dataTable.Rows.Add(subId, subsidiaryName);
            }

            return dataTable;
        }

        private void LoadSubsidiaryAccounts()
        {
            try
            {
                HelperLoadRecords.SubsidiaryLedgerComboBox(SubsidiaryLegerAccountsDataTable(), cmbSubsidiaryLedger, "sub_name", "id");
            }
            catch (Exception ex)
            {
                Helper.MessageBoxError(ex.Message);
            }
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

        private static void GetJEVCreatedByAndUpdatedBy(int jevId, ref string createdBy, ref string updatedBy)
        {
            var dictJev = AccFactory.JEVRepository().GetViewRecordByJEVId(jevId);

            int createdById = Convert.ToInt32(dictJev["created_by"]);
            createdBy = Helper.GetUserDataById(createdById)["user_full_name"];
            //int updatedById = Convert.ToInt32(dictJev["updated_by"]);
            updatedBy = "";
        }

        private DataTable TransactionLogDataTable()
        {
            int fundId = Convert.ToInt32(cmbFunds.SelectedValue);
            int generalLedgerId = Convert.ToInt32(cmbAccount.SelectedValue);
            int subsidiaryLedgerId = Convert.ToInt32(cmbSubsidiaryLedger.SelectedValue);
            short year = Convert.ToInt16(cmbYear.Text);

            var dtSubsidiaryLedger = new dsLFS.dtTransactionLogDataTable();
            var dtSubsidiaryLedgerFromDB = AccFactory.JEVAccountsRepository().GetViewRecords(fundId, generalLedgerId, subsidiaryLedgerId, year);
            string particulars = string.Empty;

            foreach (DataRow item in dtSubsidiaryLedgerFromDB.Rows)
            {
                particulars = item["explanation"].ToString();
                int jevId = Convert.ToInt32(item["jev_id"]);
                string createBy = string.Empty;
                string updatedBy = string.Empty;

                GetJEVCreatedByAndUpdatedBy(jevId, ref createBy, ref updatedBy);

                DataRow row = dtSubsidiaryLedger.NewRow();
                row["date"] = item["date_entry"];
                row["ref"] = item["full_jev_no"];
                row["proxy"] = createBy;

                ValidateDebitCreditRow(particulars, item, row, ref beginningBalance);

                dtSubsidiaryLedger.Rows.Add(row);
            }

            return dtSubsidiaryLedger;
        }

        private void BeginningBalanceRow(byte fundId, short year, ushort generalLedgerId, out string balanceDate, out string balanceDebit, out string balanceCredit, out string balance)
        {
            beginningBalance = 0;
            ushort subsidiaryLedgerId = Convert.ToUInt16(cmbSubsidiaryLedger.SelectedValue);
            var DebitBeginningBalance = AccFactory.BeginningBalancesRepository().GetSumBalancesBy_FundId_GenLedgId_IsDebit_SubLedgId(fundId, generalLedgerId, year, 1, subsidiaryLedgerId);
            var CreditBeginningBalance = AccFactory.BeginningBalancesRepository().GetSumBalancesBy_FundId_GenLedgId_IsDebit_SubLedgId(fundId, generalLedgerId, year, 0, subsidiaryLedgerId);

            beginningBalance = (DebitBeginningBalance - CreditBeginningBalance);
            balance = beginningBalance.ToString();
            decimal debit = DebitBeginningBalance > CreditBeginningBalance ? Math.Abs(beginningBalance) : 0;
            decimal credit = DebitBeginningBalance < CreditBeginningBalance ? Math.Abs(beginningBalance) : 0;

            balanceDebit = debit.ToString();
            balanceCredit = credit.ToString();

            var dateDict = AccFactory.BeginningBalancesRepository().GetRecordBy_FundId_GenLedgId_Year_SubLedgId(fundId, generalLedgerId, year, subsidiaryLedgerId);
            balanceDate = string.IsNullOrEmpty(dateDict["date_entry"]) ? string.Empty : Convert.ToDateTime(dateDict["date_entry"]).ToString("dd/MM/yyyy");
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
                var generalLedgerDict = AccFactory.GeneralLedgerAccountsRepository().GetViewRecordByID(generalLedgerId);
                var subsidiaryLedgerDict = AccFactory.SubsidiaryLedgerAccountsRepository().GetRecordByID(subsidiaryLedgerId);
                var fundName = cmbFunds.Text;
                report.ReportPath = $"{Application.StartupPath}\\Reports\\transaction_log.rdlc";
                report.DataSources.Clear();

                report.DataSources.Add(new ReportDataSource("dtTransactionLog", TransactionLogDataTable()));

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
                Helper.MessageBoxError(ex.StackTrace);
            }
        }

        private void cmbAccount_SelectionChangeCommitted(object sender, EventArgs e)
        {
            LoadSubsidiaryAccounts();
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

        private void cmbAccount_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F1 && cmbAccount.FindStringExact(cmbAccount.Text) == -1 && !string.IsNullOrEmpty(cmbAccount.Text))
            {
                LoadAccounts();
                cmbAccount.DroppedDown = true;
            }
        }

        private void btnRetrieve_Click(object sender, EventArgs e)
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