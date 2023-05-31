using Microsoft.Reporting.WinForms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AccountingSystem.Views.Reports.Ledgers
{
    public partial class ucSummarySubsidiaryLedger : UserControl
    {
        private readonly ReportViewer reportViewer;

        public ucSummarySubsidiaryLedger()
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

        private void ucSummarySubsidiaryLedger_Load(object sender, EventArgs e)
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
            HelperLoadRecords.FundsComboBox(dtFunds, cmbxFunds, "fund_name", "id");
        }

        private DataColumn[] DataColumnsSummarySubsidiaryLedger()
        {
            return new DataColumn[]
            {
                new DataColumn(Name = "funds_id", typeof(int)),
                new DataColumn(Name = "fund_code", typeof(string)),
                new DataColumn(Name = "fund_name", typeof(string)),
                new DataColumn(Name = "general_ledger_accounts_id", typeof(int)),
                new DataColumn(Name = "general_ledger_accounts_code", typeof(string)),
                new DataColumn(Name = "general_ledger_accounts_name", typeof(string)),
                new DataColumn(Name = "subsidiary_ledger_accounts_id", typeof(int)),
                new DataColumn(Name = "subsidiary_ledger_accounts_code", typeof(string)),
                new DataColumn(Name = "subsidiary_ledger_accounts_name", typeof(string)),
                new DataColumn(Name = "balance", typeof(decimal))
            };
        }

        private decimal GetBeginningBalance(int fundId, short year, int generalLedgerId, ushort subsidiaryLedgerId)
        {
            Dictionary<string, string> dateDict = AccFactory.BeginningBalancesRepository().GetRecordBy_FundId_GenLedgId_Year_SubLedgId((byte)fundId, (ushort)generalLedgerId, year,
            subsidiaryLedgerId);
            decimal DebitBeginningBalance = AccFactory.BeginningBalancesRepository().GetSumBalancesBy_FundId_GenLedgId_IsDebit_SubLedgId((byte)fundId, (ushort)generalLedgerId, year, true, subsidiaryLedgerId);
            decimal CreditBeginningBalance = AccFactory.BeginningBalancesRepository().GetSumBalancesBy_FundId_GenLedgId_IsDebit_SubLedgId((byte)fundId, (ushort)generalLedgerId, year, false, subsidiaryLedgerId);
            decimal balance = DebitBeginningBalance - CreditBeginningBalance;
            return balance;
        }

        private DataTable DataTableSummarySubsidiaryLedger()
        {
            int fundId = Convert.ToInt32(cmbxFunds.SelectedValue);
            int generalLedgerId = Convert.ToInt32(cmbxAccount.SelectedValue);
            short year = Convert.ToInt16(nudYear.Value);

            DataTable dataTable = new DataTable();
            dataTable.Columns.AddRange(DataColumnsSummarySubsidiaryLedger());
            DataTable dtSubsidiaryLedgers = AccFactory.SubsidiaryLedgerAccountsRepository().GetViewRecordsByFundId_GenAccId(fundId, generalLedgerId);
            int totalProgressCount = dtSubsidiaryLedgers.Rows.Count;
            int runningProgressCount = 0;

            foreach (DataRow row in dtSubsidiaryLedgers.Rows)
            {
                var newRow = dataTable.NewRow();

                int rowSubsidiaryLedgerAccId = Convert.ToInt32(row["subsidiary_ledger_accounts_id"]);
                string rowSubsidiaryAccountCode = row["sub_code"].ToString();
                string rowSubsidiaryAccountName = row["sub_name"].ToString();
                int rowFundId = Convert.ToInt32(row["funds_id"]);
                string rowFundCode = row["fund_code"].ToString();
                string rowFundName = row["fund_name"].ToString();
                int rowAccountId = Convert.ToInt32(row["general_ledger_accounts_id"]);
                string rowAccountCode = row["ledger_code"].ToString();
                string rowAccountName = row["ledger_name"].ToString();

                var dictJevSubsidiaryLedgers = AccFactory.JEVAccountsRepository().GetViewSummarySubidiaryRecord(fundId, generalLedgerId, rowSubsidiaryLedgerAccId, year);

                decimal begginingBalance = GetBeginningBalance(fundId, year, generalLedgerId, (ushort)rowSubsidiaryLedgerAccId);
                decimal rowTotalDebit = Convert.ToDecimal(dictJevSubsidiaryLedgers["total_debit"]);
                decimal rowTotalCredit = Convert.ToDecimal(dictJevSubsidiaryLedgers["total_credit"]);
                decimal rowBalance = begginingBalance + (rowTotalDebit - rowTotalCredit);

                newRow["funds_id"] = rowFundId;
                newRow["fund_code"] = rowFundCode;
                newRow["fund_name"] = rowFundName;
                newRow["general_ledger_accounts_id"] = rowAccountId;
                newRow["general_ledger_accounts_code"] = rowAccountCode;
                newRow["general_ledger_accounts_name"] = rowAccountName;
                newRow["subsidiary_ledger_accounts_id"] = rowSubsidiaryLedgerAccId;
                newRow["subsidiary_ledger_accounts_code"] = rowSubsidiaryAccountCode;
                newRow["subsidiary_ledger_accounts_name"] = rowSubsidiaryAccountName;
                newRow["balance"] = rowBalance;
                dataTable.Rows.Add(newRow);

                runningProgressCount++;
                int progressPercentage = (runningProgressCount * 100) / totalProgressCount;
                backgroundWorker1.ReportProgress(progressPercentage);
            };

            return dataTable;
        }

        private void LoadReport(LocalReport localReport)
        {
            Dictionary<string, string> lguDict = Helper.LGUDetails();
            ushort generalLedgerId = Convert.ToUInt16(cmbxAccount.SelectedValue);
            string fundName = cmbxFunds.Text;
            Dictionary<string, string> generalLedgerDict = AccFactory.GeneralLedgerAccountsRepository().GetViewRecordByID(generalLedgerId);

            localReport.ReportPath = $"{Application.StartupPath}\\Reports\\Ledgers\\summary-subsidiary-ledger.rdlc";
            localReport.DataSources.Clear();

            localReport.DataSources.Add(new ReportDataSource("dtSummarySubsidiaryLedger", DataTableSummarySubsidiaryLedger()));

            var reportParameters = new ReportParameter[]
            {
                new ReportParameter("paramLgu", $"{lguDict["municipality"]} - {lguDict["lgu_province"]}"),
                new ReportParameter("paramAccountName", generalLedgerDict["ledger_name"]),
                new ReportParameter("paramAccountCode", generalLedgerDict["account_code"]),
                new ReportParameter("paramYear", nudYear.Value.ToString()),
                new ReportParameter("paramFund", fundName)
            };

            localReport.SetParameters(reportParameters);
            reportViewer.SetDisplayMode(DisplayMode.PrintLayout);
            reportViewer.ZoomMode = ZoomMode.Percent;
            reportViewer.ZoomPercent = 100;
            reportViewer.RefreshReport();
        }

        private void LoadYear()
        {
            nudYear.Value = Helper.GetCurrentDate().Year;
            nudYear.Maximum = Helper.GetCurrentDate().Year;
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
            DataTable dtAccounts;
            var dataTable = new DataTable();
            dataTable.Columns.AddRange(DataColumnsAccounts());

            if (string.IsNullOrEmpty(cmbxAccount.Text))
                dtAccounts = AccFactory.GeneralLedgerAccountsRepository().GetViewRecords();
            else
                dtAccounts = AccFactory.GeneralLedgerAccountsRepository().GetViewRecordsBySearch(cmbxAccount.Text);

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

        private void btnRetrieve_Click(object sender, EventArgs e)
        {
            try
            {
                if (!backgroundWorker1.IsBusy)
                    LoadReport(reportViewer.LocalReport);
            }
            catch (Exception ex) { Helper.MessageBoxError(ex.Message); }
        }

        private void cmbxAccount_KeyDown(object sender, KeyEventArgs e)
        {
            string searchText = cmbxAccount.Text.Trim();

            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    e.Handled = true;
                    e.SuppressKeyPress = true;
                    LoadAccounts(searchText, true);
                }
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

        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
            Invoke((MethodInvoker)delegate { LoadReport(reportViewer.LocalReport); });
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