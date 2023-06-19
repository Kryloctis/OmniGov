using Microsoft.Reporting.WinForms;
using Org.BouncyCastle.Cms;
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

        private void OnLoad()
        {
            if (!DesignMode)
            {
                LoadAccounts();
                LoadFunds();
                LoadYear();
                cmbxFunds.Tag = string.Empty;
                cmbxAccount.Tag = string.Empty;
                cmbxSubsidiaryLedger.Tag = string.Empty;
            }
        }

        private void ucTransactionLog_Load(object sender, System.EventArgs e)
        {
            OnLoad();
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

        private DataColumn[] DataColumnsAccounts()
        {
            return new DataColumn[]
            {
                new DataColumn(Name = "id", typeof(int)),
                new DataColumn(Name = "account_name", typeof(string))
            };
        }

        private DataTable DatatableAccounts()
        {
            DataTable dtAccounts = AccFactory.GeneralLedgerAccountsRepository().GetViewRecords();
            var dataTable = new DataTable();
            dataTable.Columns.AddRange(DataColumnsAccounts());

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
            cmbxAccount.SelectedValueChanged -= new EventHandler(cmbxAccount_SelectedValueChanged);
            HelperLoadRecords.SearchableCombobox(cmbxAccount, DatatableAccounts(), "id", "account_name", "account_name", searchText, isSearch);
            cmbxAccount.TextChanged += new EventHandler(cmbxAccount_TextChanged);
            cmbxAccount.SelectedValueChanged += new EventHandler(cmbxAccount_SelectedValueChanged);
        }

        private void cmbxAccount_SelectedValueChanged(object sender, EventArgs e)
        {
            try
            {
                LoadSubsidiaryAccounts();
            }
            catch (Exception ex) { Helper.MessageBoxError(ex.Message); }
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

        #region Subsidiary Ledgers

        private DataColumn[] DataColumnSubsidiaryLedgers()
        {
            return new DataColumn[]
            {
                new DataColumn(Name = "id", typeof(int)),
                new DataColumn(Name = "sub_name", typeof(string))
            };
        }

        private DataTable SubsidiaryLedgerDataTable()
        {
            DataTable dataTable = new DataTable();
            dataTable.Columns.AddRange(DataColumnSubsidiaryLedgers());

            int fundId = Convert.ToInt32(cmbxFunds.SelectedValue);
            int generalLedgerId = Convert.ToInt32(cmbxAccount.SelectedValue);

            DataTable dtSubsidiaryLedger = AccFactory.SubsidiaryLedgerAccountsRepository().GetRecordsByFundAndGeneralLedger((byte)fundId, (ushort)generalLedgerId);

            foreach (DataRow dataRow in dtSubsidiaryLedger.Rows)
            {
                var newRow = dataTable.NewRow();
                string subsidiaryName = $"{dataRow["sub_code"]} - {dataRow["sub_name"]}";
                int subId = Convert.ToInt32(dataRow["id"]);

                newRow["id"] = subId;
                newRow["sub_name"] = subsidiaryName;
                dataTable.Rows.Add(newRow);
            }

            return dataTable;
        }

        private void LoadSubsidiaryAccounts(string searchText = "", bool isSearch = false)
        {
            cmbxSubsidiaryLedger.TextChanged -= new EventHandler(cmbxSubsidiaryLedger_TextChanged);
            cmbxSubsidiaryLedger.Text = string.Empty;
            HelperLoadRecords.SearchableCombobox(cmbxSubsidiaryLedger, SubsidiaryLedgerDataTable(), "id", "sub_name", "sub_name", searchText, isSearch);
            cmbxSubsidiaryLedger.TextChanged += new EventHandler(cmbxSubsidiaryLedger_TextChanged);
        }

        private void cmbxSubsidiaryLedger_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                string searchText = cmbxSubsidiaryLedger.Text.Trim();
                if (e.KeyCode == Keys.Enter)
                {
                    LoadSubsidiaryAccounts(searchText, true);
                    e.Handled = true;
                    e.SuppressKeyPress = true;
                }
            }
            catch (Exception ex) { Helper.MessageBoxError(ex.Message); }
        }

        private void cmbxSubsidiaryLedger_TextChanged(object sender, EventArgs e)
        {
            try
            {
                string subsidiaryLedger = cmbxSubsidiaryLedger.Text.Trim();

                if (string.IsNullOrWhiteSpace(subsidiaryLedger))
                    LoadSubsidiaryAccounts();
            }
            catch (Exception ex) { Helper.MessageBoxError(ex.Message); }
        }

        #endregion Subsidiary Ledgers

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
            int fundId = Convert.ToInt32(cmbxFunds.SelectedValue);
            int generalLedgerId = Convert.ToInt32(cmbxAccount.SelectedValue);
            int subsidiaryLedgerId = Convert.ToInt32(cmbxSubsidiaryLedger.SelectedValue);
            short year = Convert.ToInt16(nudYear.Value);

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
            ushort subsidiaryLedgerId = Convert.ToUInt16(cmbxSubsidiaryLedger.SelectedValue);
            var DebitBeginningBalance = AccFactory.BeginningBalancesRepository().GetSumBalancesBy_FundId_GenLedgId_IsDebit_SubLedgId(fundId, generalLedgerId, year, true, subsidiaryLedgerId);
            var CreditBeginningBalance = AccFactory.BeginningBalancesRepository().GetSumBalancesBy_FundId_GenLedgId_IsDebit_SubLedgId(fundId, generalLedgerId, year, false, subsidiaryLedgerId);

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
                byte fundId = (byte)cmbxFunds.SelectedValue;
                short year = Convert.ToInt16(nudYear.Value);
                ushort generalLedgerId = (ushort)cmbxAccount.SelectedValue;
                int subsidiaryLedgerId = (int)cmbxSubsidiaryLedger.SelectedValue;

                string balanceDate, balanceDebit, balanceCredit, balance;
                BeginningBalanceRow(fundId, year, generalLedgerId, out balanceDate, out balanceDebit, out balanceCredit, out balance);

                var lguDict = Helper.LGUDetails();
                var generalLedgerDict = AccFactory.GeneralLedgerAccountsRepository().GetViewRecordByID(generalLedgerId);
                var subsidiaryLedgerDict = AccFactory.SubsidiaryLedgerAccountsRepository().GetRecordByID(subsidiaryLedgerId);
                var fundName = cmbxFunds.Text;
                report.ReportPath = $"{Application.StartupPath}\\Reports\\Ledgers\\transaction_log.rdlc";
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

        private void btnRetrieve_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(cmbxAccount.Text) || string.IsNullOrWhiteSpace(cmbxSubsidiaryLedger.Text))
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