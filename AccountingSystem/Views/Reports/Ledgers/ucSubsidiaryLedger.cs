using ACC.Domain.Interfaces;
using Microsoft.Reporting.WinForms;
using Microsoft.ReportingServices.RdlExpressions.ExpressionHostObjectModel;
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

        private void OnLoad()
        {
            if (!DesignMode)
            {
                LoadAccounts();
                LoadFunds();
                LoadYear();
            }
        }

        private void ucSubsidiaryLedger_Load(object sender, EventArgs e)
        {
            try
            {
                OnLoad();
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

            int fundId = Convert.ToInt32(cmbFunds.SelectedValue);
            int generalLedgerId = Convert.ToInt32(cmbAccount.SelectedValue);

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

        private void LoadSubsidiaryAccounts()
        {
            HelperLoadRecords.SubsidiaryLedgerComboBox(SubsidiaryLedgerDataTable(), cmbSubsidiaryLedger, "sub_name", "id");
        }

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
            int generalLedgerId = Convert.ToInt32(cmbAccount.SelectedValue);
            int subsidiaryLedgerId = Convert.ToInt32(cmbSubsidiaryLedger.SelectedValue);
            short year = Convert.ToInt16(cmbYear.Text);
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
            ushort subsidiaryLedgerId = Convert.ToUInt16(cmbSubsidiaryLedger.SelectedValue);
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
            short year = Convert.ToInt16(cmbYear.Text);
            int generalLedgerId = Convert.ToInt32(cmbAccount.SelectedValue);
            int subsidiaryLedgerId = Convert.ToInt32(cmbSubsidiaryLedger.SelectedValue);

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
            cmbAccount.TextChanged -= new EventHandler(cmbLedgerAccout_TextChanged);
            cmbAccount.SelectedValueChanged -= new EventHandler(cmbAccount_SelectedValueChanged);
            HelperLoadRecords.SearchableCombobox(cmbAccount, DatatableAccounts(), "id", "account_name", "account_name", searchText, isSearch);
            cmbAccount.TextChanged += new EventHandler(cmbLedgerAccout_TextChanged);
            cmbAccount.SelectedValueChanged += new EventHandler(cmbAccount_SelectedValueChanged);
        }

        private void cmbAccount_SelectedValueChanged(object sender, EventArgs e)
        {
            try
            {
                LoadSubsidiaryAccounts();
            }
            catch (Exception ex) { Helper.MessageBoxError(ex.Message); }
        }

        private void cmbLedgerAccout_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(cmbAccount.Text.Trim()))
                    LoadAccounts();
            }
            catch (Exception ex) { Helper.MessageBoxError(ex.Message); }
        }

        private void cmbAccount_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                string searchText = cmbAccount.Text.Trim();
                if (e.KeyCode == Keys.Enter)
                {
                    LoadAccounts(searchText, true);
                    e.Handled = true;
                    e.SuppressKeyPress = true;
                }
            }
            catch (Exception ex) { Helper.MessageBoxError(ex.Message); }
        }

        private string GetFormErrors()
        {
            var errorArray = new string[]
            {
                AccountValidated(),
                SubsidiaryLedgerValidated()
            };

            return AccFactory.CreateErrors(errorArray).GenerateErrorMessage();
        }

        private string AccountValidated()
        {
            string accountName = cmbAccount.Text.Trim();

            if (string.IsNullOrWhiteSpace(accountName) || cmbAccount.FindStringExact(accountName) == -1)
                return "Invalid account, Please select on the list";
            else
                return string.Empty;
        }

        private string SubsidiaryLedgerValidated()
        {
            string subsidiaryLedgerName = cmbSubsidiaryLedger.Text.Trim();
            if (string.IsNullOrWhiteSpace(subsidiaryLedgerName) || cmbSubsidiaryLedger.FindStringExact(subsidiaryLedgerName) == -1)
                return "Invalid subsidiary ledger, Please select on the list";
            else
                return string.Empty;
        }

        private void btnRetrieve_Click(object sender, EventArgs e)
        {
            try
            {
                if (!string.IsNullOrWhiteSpace(GetFormErrors()))
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
    }
}