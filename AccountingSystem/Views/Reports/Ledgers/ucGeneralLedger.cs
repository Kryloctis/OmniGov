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
            cmbxAccount.TextChanged -= new EventHandler(CmbxLedgerAccout_TextChanged);
            HelperLoadRecords.SearchableCombobox(cmbxAccount, DatatableAccounts(), "id", "account_name", "account_name", searchText, isSearch);
            cmbxAccount.TextChanged += new EventHandler(CmbxLedgerAccout_TextChanged);
        }

        private void CmbxLedgerAccout_TextChanged(object sender, EventArgs e)
        {
            try
            {
                string accountName = cmbxAccount.Text.Trim();

                if (string.IsNullOrWhiteSpace(accountName))
                    LoadAccounts();
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
            nudYear.Maximum = Helper.GetCurrentDate().Year;
            nudYear.Value = Helper.GetCurrentDate().Year;
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
            int generalLedgerId = Convert.ToInt32(cmbxAccount.SelectedValue);
            int year = Convert.ToInt16(nudYear.Value);

            dsLFS.dtGeneralLedgerDataTable dtGeneralLedger = new dsLFS.dtGeneralLedgerDataTable();
            DataTable dtGeneralLedgerFromDB = AccFactory.JEVAccountsRepository().GetViewRecords(fundId, generalLedgerId, (short)year);
            DataRow dataRowBeginningBalance = BeginningBalanceRow(fundId, year, generalLedgerId, dtGeneralLedger);

            int totalRecordCount = dtGeneralLedgerFromDB.Rows.Count;
            int runningRecordCount = 0;

            if (!string.IsNullOrWhiteSpace(dataRowBeginningBalance["date"].ToString()))
            {
                dtGeneralLedger.Rows.Add(dataRowBeginningBalance);
                totalRecordCount++;
                runningRecordCount++;
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
                int progressPercentage = (runningRecordCount * 100) / totalRecordCount;
                backgroundWorker1.ReportProgress(progressPercentage);
            }
            return dtGeneralLedger;
        }

        private void LoadReport(LocalReport report)
        {
            short year = Convert.ToInt16(nudYear.Value);
            ushort generalLedgerId = Convert.ToUInt16(cmbxAccount.SelectedValue);

            var lguDict = Helper.LGUDetails();
            var generalLedgerDict = AccFactory.GeneralLedgerAccountsRepository().GetViewRecordByID(generalLedgerId);
            var fundName = cmbFunds.Text;
            report.ReportPath = $"{Application.StartupPath}\\Reports\\Ledgers\\general-ledger.rdlc";
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
        }

        private void OnLoad()
        {
            if (!DesignMode)
            {
                LoadFunds();
                LoadAccounts();
                LoadYear();
                cmbxAccount.Tag = string.Empty;
                cmbFunds.Tag = string.Empty;
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

                if (e.KeyData == (Keys.Control | Keys.V))
                    LoadAccounts(searchText, true);
            }
            catch (Exception ex) { Helper.MessageBoxError(ex.Message); }
        }

        private void backgroundWorker1_DoWork(object sender, System.ComponentModel.DoWorkEventArgs e)
        {
            Invoke((MethodInvoker)delegate
            {
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

        #region Validations

        private string GetFormErrors()
        {
            var errorArray = new string[]
            {
                cmbxAccount.Tag.ToString(),
                cmbFunds.Tag.ToString()
            };

            return AccFactory.CreateErrors(errorArray).GenerateErrorMessage();
        }

        private bool AccountValidated()
        {
            string accountName = cmbxAccount.Text.Trim();

            if (cmbxAccount.FindStringExact(accountName) == -1 || string.IsNullOrWhiteSpace(accountName))
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

        private void cmbxAccount_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            e.Cancel = !AccountValidated();
        }

        private void cmbxAccount_Validated(object sender, EventArgs e)
        {
            cmbxAccount.Tag = string.Empty;
        }

        private void cmbFunds_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            e.Cancel = !FundValidated();
        }

        private void cmbFunds_Validated(object sender, EventArgs e)
        {
            cmbFunds.Tag = string.Empty;
        }

        #endregion Validations
    }
}