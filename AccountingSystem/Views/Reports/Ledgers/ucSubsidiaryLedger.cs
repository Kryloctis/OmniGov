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
                cmbAccount.SelectedIndex = -1;
                cmbAccount.TextChanged += new EventHandler(cmbxLedgerAccout_TextChanged);

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

        private DataTable SubsidiaryLedgerDataTable()
        {
            var dataTable = new DataTable();
            dataTable.Columns.Add("id", typeof(int));
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
            Cursor.Current = Cursors.WaitCursor;
            short year = Convert.ToInt16(cmbYear.Text);
            ushort generalLedgerId = (ushort)cmbAccount.SelectedValue;
            int subsidiaryLedgerId = (int)cmbSubsidiaryLedger.SelectedValue;

            Dictionary<string, string> generalLedgerDict = AccFactory.GeneralLedgerAccountsRepository().GetViewRecordByID(generalLedgerId);
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
            Cursor.Current = Cursors.Default;
        }

        private void cmbAccount_SelectionChangeCommitted(object sender, EventArgs e)
        {
            try
            {
                LoadSubsidiaryAccounts();
            }
            catch (Exception ex) { Helper.MessageBoxError(ex.Message); }
        }

        private DataTable DatatableAccounts()
        {
            DataTable dtAccounts;

            if (string.IsNullOrEmpty(cmbAccount.Text))
                dtAccounts = AccFactory.GeneralLedgerAccountsRepository().GetViewRecords();
            else
                dtAccounts = AccFactory.GeneralLedgerAccountsRepository().GetViewRecordsBySearch(cmbAccount.Text);

            return dtAccounts;
        }

        private void LoadAccounts()
        {
            cmbAccount.DroppedDown = false;

            if (DatatableAccounts().Rows.Count == 0) return;

            Dictionary<ushort, string> accountDict = new Dictionary<ushort, string>();
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

        private void cmbxLedgerAccout_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrEmpty(cmbAccount.Text))
                {
                    cmbAccount.TextChanged -= new EventHandler(cmbxLedgerAccout_TextChanged);
                    LoadAccounts();
                    cmbAccount.SelectedIndex = -1;
                    cmbAccount.TextChanged += new EventHandler(cmbxLedgerAccout_TextChanged);
                }
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

        private void btnRetrieve_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(cmbAccount.Text) || string.IsNullOrWhiteSpace(cmbSubsidiaryLedger.Text))
                {
                    Helper.MessageBoxError("Please select a subsidiary ledger account.");
                    return;
                }

                if (!backgroundWorker1.IsBusy)
                {
                    progressBar1.Style = ProgressBarStyle.Marquee;
                    progressBar1.MarqueeAnimationSpeed = 1;
                    backgroundWorker1.RunWorkerAsync();
                }
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
            progressBar1.Style = ProgressBarStyle.Blocks;
        }

        private void backgroundWorker1_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
        }
    }
}