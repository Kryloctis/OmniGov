using ACC.Data;
using Microsoft.Reporting.WinForms;
using System;
using System.Data;
using System.Windows.Forms;

namespace AccountingSystem.Views.Reports.Cashbook
{
    public partial class frmCashbook : Form
    {
        private readonly ReportViewer reportViewer = new();

        public frmCashbook()
        {
            InitializeComponent();
            reportViewer.Dock = DockStyle.Fill;
            panel1.Controls.Add(reportViewer);
            Helper.LoadFormIcon(this);
        }

        private void frmCashbook_Load(object sender, EventArgs e)
        {
            try
            {
                OnLoad();
            }
            catch (Exception ex) { Helper.MessageBoxError(ex.Message); }
        }

        private void OnLoad()
        {
            LoadBanks();
            LoadBankAccounts();
        }

        internal void LoadBanks()
        {
            var dtBanks = AccFactory.BanksRepository().GetRecords();
            HelperLoadRecords.BankComboBox(dtBanks, cmbBank, "id", "bank_name");
        }

        internal void LoadBankAccounts()
        {
            int bankID = Convert.ToInt32(cmbBank.SelectedValue);
            DataTable dtBankAccounts = AccFactory.BankAccountsRepository().GetBankAccountsByBankID(bankID);
            HelperLoadRecords.BankAccountsComboBox(dtBankAccounts, cmbBankAccounts, "id", "account_no");
        }

        private DataTable DataTableCashBook(int bankID, int bankAccountID)
        {
            var dtCashBook = new dsLFS.dtCashbookDataTable();
            var dtCashBookFromDB = AccFactory.BankDepositsRepository().GetRecordsByBankAndAccountID(bankID, bankAccountID);
            var dtRCI = AccFactory.RCIRepository().GetRecordsByBankAndAccountID(bankID, bankAccountID);

            if (dtCashBookFromDB.Rows.Count > 0 || dtRCI.Rows.Count > 0)
            {
                decimal balance = 0;
                decimal debit = 0;
                decimal credit = 0;
                foreach (DataRow item in dtCashBookFromDB.Rows)
                {
                    DataRow row = dtCashBook.NewRow();
                    row["date"] = item["date"];
                    row["particulars"] = string.Format("Deposit - {0} - {1}", item["bank_name"], item["account_no"]);
                    row["reference"] = item["reference"];
                    row["debit"] = item["amount"];
                    row["credit"] = 0;
                    row["balance"] = balance;
                    dtCashBook.Rows.Add(row);
                }

                foreach (DataRow item in dtRCI.Rows)
                {
                    DataRow row = dtCashBook.NewRow();
                    row["date"] = item["cheque_date"];
                    row["particulars"] = string.Format("Check Issued - {0} - {1}", item["payee"], item["nature_of_payment"]);
                    row["reference"] = string.Format("{0} - {1}", item["cheque_no"], item["dv_no"]);
                    row["credit"] = item["amount"];
                    row["debit"] = 0;
                    row["balance"] = balance;
                    dtCashBook.Rows.Add(row);
                }
                dtCashBook.Select(string.Empty, "date ASC");

                if (dtCashBook.Rows.Count > 0)
                {
                    foreach (DataRow item in dtCashBook.Rows)
                    {
                        debit += item["debit"].Equals(DBNull.Value) ? 0 : Convert.ToDecimal(item["debit"]);
                        credit += item["credit"].Equals(DBNull.Value) ? 0 : Convert.ToDecimal(item["credit"]);
                        balance = debit - credit;
                        item["balance"] = balance;
                    }
                }
            }
            return dtCashBook;
        }

        private void LoadReport(LocalReport report)
        {
            int bankID = Convert.ToInt32(cmbBank.SelectedValue);
            int bankAccountID = Convert.ToInt32(cmbBankAccounts.SelectedValue);

            var lguDetails = Helper.LGUDetails();
            var account = cmbBank.Text;
            var parameters = new[]
            {
                new ReportParameter("paramLGUName", lguDetails["lgu_name"]),
                new ReportParameter("paramBankaccount", account)
            };

            report.ReportPath = $"{Application.StartupPath}Reports\\cashbook.rdlc";
            report.DataSources.Clear();
            report.DataSources.Add(new ReportDataSource("dtCashbook", DataTableCashBook(bankID, bankAccountID)));
            report.SetParameters(parameters);
            report.Refresh();
        }

        private void btnretrieve_Click(object sender, EventArgs e)
        {
            try
            {
                if (cmbBank.SelectedIndex == -1 && cmbBankAccounts.SelectedIndex == -1)
                {
                    Helper.MessageBoxError("Please select Bank and Bank Accounts");
                    return;
                }

                LoadReport(reportViewer.LocalReport);
                reportViewer.SetDisplayMode(DisplayMode.PrintLayout);
                reportViewer.ZoomMode = ZoomMode.PageWidth;
                //reportViewer.ZoomPercent = 100;
                reportViewer.RefreshReport();
            }
            catch (Exception ex) { Helper.MessageBoxError(ex.Message); }
        }

        private void cmbBank_SelectionChangeCommitted(object sender, EventArgs e)
        {
            try
            {
                LoadBankAccounts();
            }
            catch (Exception ex) { Helper.MessageBoxError(ex.Message); }
        }
    }
}