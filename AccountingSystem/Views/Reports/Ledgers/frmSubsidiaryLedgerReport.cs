using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.Reporting.WinForms;

namespace AccountingSystem.Views.Reports.Ledgers
{
    public partial class frmSubsidiaryLedgerReport : Form
    {
        private readonly ReportViewer reportViewer;
        private decimal beginningBalance;

        public frmSubsidiaryLedgerReport()
        {
            InitializeComponent();
            reportViewer = new ReportViewer();
            reportViewer.Dock = DockStyle.Fill;
            panel1.Controls.Add(reportViewer);
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

        private void frmSubsidiaryLedgerReport_Load(object sender, EventArgs e)
        {
            Helper.LoadFormIcon(this);
            LoadFunds();
            LoadYear();
        }

        private void cmbAccount_KeyDown(object sender, KeyEventArgs e)
        {
            if (cmbAccount.Text.Length < 4) return;

            if (e.KeyCode == Keys.F1)   
            {
                try
                {
                    DataTable dtAccounts = Factory.GeneralLedgerAccountsRepository().GetViewRecordsBySearch(cmbAccount.Text.Trim());

                    if (dtAccounts.Rows.Count == 0 || string.IsNullOrWhiteSpace(cmbAccount.Text.Trim())) return;

                    var accountDict = new Dictionary<int, string>();
                    foreach (DataRow item in dtAccounts.Rows)
                    {
                        int accountId = Convert.ToInt32(item["general_ledger_accounts_id"]);
                        string accountName = $"{item["account_code"]} - {item["ledger_name"]}";

                        accountDict.Add(accountId, accountName);
                    }

                    cmbAccount.DataSource = new BindingSource(accountDict, null);
                    cmbAccount.DisplayMember = "value";
                    cmbAccount.ValueMember = "key";
                    cmbAccount.DroppedDown = true;
                    Cursor.Current = Cursors.Default;

                }
                catch (Exception ex)
                {
                    Helper.MessageBoxError(ex.Message);
                }
            }
        }

        private string ParseParticulars(DataRow item)
        {
            string particulars;
            if (item["journal_name"].ToString() == "General Journal")
                particulars = item["explanation"].ToString();
            else
                particulars = $"{item["journal_name"]}";

            return particulars;
        }

        private static void ValidateDebitCreditRow(string particulars, DataRow item, DataRow row, ref decimal balance)
        {
            decimal amount = (decimal)item["amount"];
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
            byte fundId = (byte)cmbFunds.SelectedValue;
            int generalLedgerId = (int)cmbAccount.SelectedValue;
            int subsidiaryLedgerId = (int)cmbSubsidiaryLedger.SelectedValue;
            short year = Convert.ToInt16(cmbYear.Text);

            var dtSubsidiaryLedger = new dsLFS.SubsidiaryLedgerDataTable();
            var dtSubsidiaryLedgerFromDB = Factory.JEVAccountsRepository().GetViewRecordsByFundAndGeneralLedger(fundId, (ushort)generalLedgerId, year);

            string particulars;
            foreach (DataRow item in dtSubsidiaryLedgerFromDB.Rows)
            {
                //particulars = ParseParticulars(item);
                particulars = item["explanation"].ToString();

                DataRow row = dtSubsidiaryLedger.NewRow();
                row["date"] = item["month_name"];
                row["ref"] = item["jev_no"].ToString();

                ValidateDebitCreditRow(particulars, item, row, ref beginningBalance);

                dtSubsidiaryLedger.Rows.Add(row);
            }

            return dtSubsidiaryLedger;
        }

        private void BeginningBalanceRow(byte fundId, short year, int generalLedgerId, out string balanceDate, out string balanceDebit, out string balanceCredit, out string balance)
        {
            balanceDate = string.Empty;
            balanceDebit = string.Empty;
            balanceCredit = string.Empty;
            balance = string.Empty;

            bool generalLedgerBalanceExist = Factory.BeginningBalancesRepository().GeneralLedgerBalanceExist(fundId, (ushort)generalLedgerId, year);
            if (generalLedgerBalanceExist)
            {
                var beginningBalanceDict = Factory.BeginningBalancesRepository().GetRecordByFundsAndGeneralLedgerID(fundId, (ushort)generalLedgerId, year);

                balanceDate = Convert.ToDateTime(beginningBalanceDict["date_entry"]).ToShortDateString();

                if (beginningBalanceDict["is_debit"] == "1")
                    balanceDebit = Convert.ToDecimal(beginningBalanceDict["amount"]).ToString("N2");
                else
                    balanceCredit = Convert.ToDecimal(beginningBalanceDict["amount"]).ToString("N2");

                balance = Convert.ToDecimal(beginningBalanceDict["amount"]).ToString("N2");
                beginningBalance = Convert.ToDecimal(beginningBalanceDict["amount"]);
            }
        }

        private void LoadReport(LocalReport report)
        {
            try
            {
                byte fundId = (byte)cmbFunds.SelectedValue;
                short year = Convert.ToInt16(cmbYear.Text);
                int generalLedgerId = (int)cmbAccount.SelectedValue;
                int subsidiaryLedgerId = (int)cmbSubsidiaryLedger.SelectedValue;

                string balanceDate, balanceDebit, balanceCredit, balance;
                BeginningBalanceRow(fundId, year, generalLedgerId, out balanceDate, out balanceDebit, out balanceCredit, out balance);

                var lguDict = Helper.LGUDetails();
                var generalLedgerDict = Factory.GeneralLedgerAccountsRepository().GetViewRecordByID((ushort)generalLedgerId);
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
                    new ReportParameter("paramAccountOf", "Sample account of"),
                    new ReportParameter("paramAddress", "Sample Address"),
                    new ReportParameter("paramContactPerson", "Sample Contact Person"),
                    new ReportParameter("paramContactNoEmail", "Sample Contact Email"),
                    new ReportParameter("paramBalanceDate", balanceDate),
                    new ReportParameter("paramBalanceDebit", balanceDebit),
                    new ReportParameter("paramBalanceCredit", balanceCredit),
                    new ReportParameter("paramBalance", balance)
                };
                report.SetParameters(parameters);

            }
            catch (Exception ex)
            {
                Helper.MessageBoxError(ex.Message);
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

        private void cmbAccount_SelectionChangeCommitted(object sender, EventArgs e)
        {
            byte fundId = (byte)cmbFunds.SelectedValue;
            int generalLedgerId = (int)cmbAccount.SelectedValue;
            LoadSubsidiaryAccounts(fundId, (ushort)generalLedgerId);
        }
    }
}
