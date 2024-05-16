using ACC.Data;
using Microsoft.Reporting.WinForms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Windows.Forms;

namespace AccountingSystem.Views.Reports.Ledgers
{
    public partial class ucSubsidiaryLedger : UserControl
    {
        private readonly ReportViewer reportViewer;

        public ucSubsidiaryLedger()
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
            cmbFunds.Tag = string.Empty;
            cmbxAccount.Tag = string.Empty;
            cmbxSubsidiaryLedger.Tag = string.Empty;
        }

        private void LoadFunds()
        {
            DataTable dtFunds = AccFactory.FundsRepository().GetRecords();
            HelperLoadRecords.FundsComboBox(dtFunds, cmbFunds, "fund_name", "id");
        }

        private void LoadYear()
        {
            int currentYear = Helper.GetCurrentDate().Year;

            nudYear.Maximum = currentYear;
            nudYear.Value = currentYear;
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

        private void cmbxAccount_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                string searchText = cmbxAccount.Text.Trim();
                if (e.KeyCode == Keys.Enter && cmbxAccount.Focused)
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

        private DataTable SubsidiaryLedgerDataTable()
        {
            DataTable dataTable = new DataTable();
            var dtColumns = new DataColumn[]
            {
                    new DataColumn(Name = "id", typeof(int)),
                    new DataColumn(Name = "sub_name", typeof(string))
            };

            dataTable.Columns.AddRange(dtColumns);

            int fundId = Convert.ToInt32(cmbFunds.SelectedValue);
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
            cmbxSubsidiaryLedger.TextChanged -= new EventHandler(cmbSubsidiaryLedger_TextChanged);
            cmbxSubsidiaryLedger.Text = string.Empty;
            HelperLoadRecords.SearchableCombobox(cmbxSubsidiaryLedger, SubsidiaryLedgerDataTable(), "id", "sub_name", "sub_name", searchText, isSearch);
            cmbxSubsidiaryLedger.TextChanged += new EventHandler(cmbSubsidiaryLedger_TextChanged);
        }

        private void cmbxSubsidiaryLedger_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                string searchText = cmbxSubsidiaryLedger.Text.Trim();
                if (e.KeyCode == Keys.Enter && cmbxSubsidiaryLedger.Focused)
                {
                    LoadSubsidiaryAccounts(searchText, true);
                    e.Handled = true;
                    e.SuppressKeyPress = true;
                }
            }
            catch (Exception ex) { Helper.MessageBoxError(ex.Message); }
        }

        private void cmbSubsidiaryLedger_TextChanged(object sender, EventArgs e)
        {
            try
            {
                string searchText = cmbxSubsidiaryLedger.Text.Trim();

                if (string.IsNullOrWhiteSpace(searchText))
                    LoadSubsidiaryAccounts();
            }
            catch (Exception ex) { Helper.MessageBoxError(ex.Message); }
        }

        #endregion Subsidiary Ledgers

        private static void ValidateDebitCreditRow(DataRow item, DataRow row)
        {
            if (Convert.ToBoolean(item["is_debit"]))
            {
                row["debit_amount"] = item["amount"];
                row["credit_amount"] = 0;
            }
            else
            {
                row["debit_amount"] = 0;
                row["credit_amount"] = item["amount"];
            }
        }

        private DataTable DataTableSubsidiaryLedgerReport()
        {
            int fundId = Convert.ToInt32(cmbFunds.SelectedValue);
            int generalLedgerId = Convert.ToInt32(cmbxAccount.SelectedValue);
            int subsidiaryLedgerId = Convert.ToInt32(cmbxSubsidiaryLedger.SelectedValue);
            short year = Convert.ToInt16(nudYear.Value);
            DataTable dtSubsidiaryLedger = new dsLFS.dtSubsidiaryLedgerDataTable();

            DataTable dtSubsidiaryLedgerFromDB = AccFactory.JEVAccountsRepository().GetViewRecords(fundId, generalLedgerId, subsidiaryLedgerId, year);
            DataRow dataRowBeginningBalance = BeginningBalanceRow(fundId, year, generalLedgerId, dtSubsidiaryLedger);

            int totalRowCount = dtSubsidiaryLedgerFromDB.Rows.Count;
            int runningRecordCount = 0;

            if (!string.IsNullOrWhiteSpace(dataRowBeginningBalance["date"].ToString()))
            {
                dtSubsidiaryLedger.Rows.Add(dataRowBeginningBalance);
                totalRowCount++;
                runningRecordCount++;
            }

            foreach (DataRow item in dtSubsidiaryLedgerFromDB.Rows)
            {
                DataRow newRow = dtSubsidiaryLedger.NewRow();
                newRow["date"] = item["date_entry"];
                newRow["ref"] = item["full_jev_no"];
                newRow["particulars"] = item["explanation"];

                ValidateDebitCreditRow(item, newRow);
                dtSubsidiaryLedger.Rows.Add(newRow);

                runningRecordCount++;
                int progressPercentage = (runningRecordCount * 100) / totalRowCount;
                backgroundWorker1.ReportProgress(progressPercentage);
            }

            return dtSubsidiaryLedger;
        }

        private DataRow BeginningBalanceRow(int fundId, short year, int generalLedgerId, DataTable dataTable)
        {
            ushort subsidiaryLedgerId = Convert.ToUInt16(cmbxSubsidiaryLedger.SelectedValue);
            Dictionary<string, string> dateDict = AccFactory.BeginningBalancesRepository().GetRecordBy_FundId_GenLedgId_Year_SubLedgId((byte)fundId, (ushort)generalLedgerId, year,
            subsidiaryLedgerId);
            decimal DebitBeginningBalance = AccFactory.BeginningBalancesRepository().GetSumBalancesBy_FundId_GenLedgId_IsDebit_SubLedgId((byte)fundId, (ushort)generalLedgerId, year, true, subsidiaryLedgerId);
            decimal CreditBeginningBalance = AccFactory.BeginningBalancesRepository().GetSumBalancesBy_FundId_GenLedgId_IsDebit_SubLedgId((byte)fundId, (ushort)generalLedgerId, year, false, subsidiaryLedgerId);
            DataRow newRow = dataTable.NewRow();
            decimal balance = DebitBeginningBalance - CreditBeginningBalance;
            decimal debit = DebitBeginningBalance > CreditBeginningBalance ? Math.Abs(balance) : 0;
            decimal credit = DebitBeginningBalance < CreditBeginningBalance ? Math.Abs(balance) : 0;

            object beginningBalanceDate = string.IsNullOrEmpty(dateDict["date_entry"]) ? DBNull.Value : Convert.ToDateTime(dateDict["date_entry"]);

            newRow["date"] = beginningBalanceDate;
            newRow["particulars"] = "Beginning Balance";
            newRow["ref"] = string.Empty;
            newRow["debit_amount"] = debit;
            newRow["credit_amount"] = credit;
            return newRow;
        }

        private void LoadReport(LocalReport report)
        {
            short year = Convert.ToInt16(nudYear.Value);
            int generalLedgerId = Convert.ToInt32(cmbxAccount.SelectedValue);
            int subsidiaryLedgerId = Convert.ToInt32(cmbxSubsidiaryLedger.SelectedValue);

            Dictionary<string, string> generalLedgerDict = AccFactory.GeneralLedgerAccountsRepository().GetViewRecordByID((ushort)generalLedgerId);
            Dictionary<string, string> subsidiaryLedgerDict = AccFactory.SubsidiaryLedgerAccountsRepository().GetRecordByID(subsidiaryLedgerId);
            string fundName = cmbFunds.Text;
            report.ReportPath = $"{Application.StartupPath}\\Reports\\Ledgers\\subsidiary-ledger.rdlc";
            report.DataSources.Clear();

            report.DataSources.Add(new ReportDataSource("dtSubsidiaryLedger", DataTableSubsidiaryLedgerReport()));

            ReportParameter[] parameters = new[] {
                new ReportParameter("paramLGUName", $"{Helper.LGUDetails()["municipality"]}, {Helper.LGUDetails()["lgu_province"]}"),
                new ReportParameter("paramFund", fundName),
                new ReportParameter("paramGLCode", generalLedgerDict["account_code"]),
                new ReportParameter("paramSLCode", subsidiaryLedgerDict["sub_code"]),
                new ReportParameter("paramAccountOf", subsidiaryLedgerDict["sub_name"]),
                new ReportParameter("paramAddress", subsidiaryLedgerDict["address"]),
                new ReportParameter("paramContactPerson", subsidiaryLedgerDict["contact_person"]),
                new ReportParameter("paramContactNoEmail", subsidiaryLedgerDict["contact"]),
                new ReportParameter("paramYear",year.ToString())
            };
            report.SetParameters(parameters);
            reportViewer.SetDisplayMode(DisplayMode.PrintLayout);
            reportViewer.ZoomMode = ZoomMode.Percent;
            reportViewer.ZoomPercent = 100;
            reportViewer.RefreshReport();
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

        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
            Invoke((MethodInvoker)delegate
            {
                LoadReport(reportViewer.LocalReport);
            });
        }

        private void backgroundWorker1_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            progressBar1.Value = e.ProgressPercentage;
        }

        private void backgroundWorker1_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
        }

        #region Validations

        private string GetFormErrors()
        {
            var errorArray = new string[]
            {
                cmbFunds.Tag.ToString(),
                cmbxAccount.Tag.ToString(),
                cmbxSubsidiaryLedger.Tag.ToString()
            };

            return AccFactory.CreateErrors(errorArray).GenerateErrorMessage();
        }

        private bool AccountValidated()
        {
            string accountName = cmbxAccount.Text.Trim();

            if (string.IsNullOrWhiteSpace(accountName) || cmbxAccount.FindStringExact(accountName) == -1)
            {
                cmbxAccount.Tag = "Invalid account, Please select on the list";
                return false;
            }
            else
            {
                cmbxAccount.SelectedIndex = cmbxAccount.FindStringExact(accountName);
                return true;
            }
        }

        private bool SubsidiaryAccValidated()
        {
            string subsidiaryAccName = cmbxSubsidiaryLedger.Text.Trim();

            if (string.IsNullOrWhiteSpace(subsidiaryAccName) || cmbxSubsidiaryLedger.FindStringExact(subsidiaryAccName) == -1)
            {
                cmbxSubsidiaryLedger.Tag = "Invalid subsidiary ledger, Please select on the list";
                return false;
            }
            else
            {
                cmbxSubsidiaryLedger.SelectedIndex = cmbxSubsidiaryLedger.FindStringExact(subsidiaryAccName);
                return true;
            }
        }

        private bool FundValidated()
        {
            string fundName = cmbFunds.Text.Trim();

            if (cmbFunds.FindStringExact(fundName) == -1 || string.IsNullOrWhiteSpace(fundName))
            {
                cmbFunds.Tag = "Invalid fund, Please select on the list";
                return false;
            }
            else
            {
                cmbFunds.SelectedIndex = cmbFunds.FindStringExact(fundName);
                return true;
            }
        }

        private void cmbFunds_Validating(object sender, CancelEventArgs e)
        {
            e.Cancel = !FundValidated();
        }

        private void cmbFunds_Validated(object sender, EventArgs e)
        {
            cmbFunds.Tag = string.Empty;
        }

        private void cmbAccount_Validating(object sender, CancelEventArgs e)
        {
            e.Cancel = !AccountValidated();
        }

        private void cmbAccount_Validated(object sender, EventArgs e)
        {
            cmbxAccount.Tag = string.Empty;
        }

        private void cmbSubsidiaryLedger_Validating(object sender, CancelEventArgs e)
        {
            e.Cancel = !SubsidiaryAccValidated();
        }

        private void cmbSubsidiaryLedger_Validated(object sender, EventArgs e)
        {
            cmbxSubsidiaryLedger.Tag = string.Empty;
        }

        #endregion Validations
    }
}