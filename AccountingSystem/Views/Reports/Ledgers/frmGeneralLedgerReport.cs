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
    public partial class frmGeneralLedgerReport : Form
    {
        private readonly ReportViewer reportViewer;
        private decimal beginningBalance;

        public frmGeneralLedgerReport()
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

        private void LoadGeneralLedgerAccounts()
        {
            var dtGeneralLedger = Factory.GeneralLedgerAccountsRepository().GetRecords();
            HelperLoadRecords.GeneralLedgerComboBox(dtGeneralLedger, cmbAccount, "ledger_name", "id");
        }

        private void LoadYear()
        {
            HelperLoadRecords.YearComboBox(cmbYear);
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

        private string ParseParticulars(DataRow item)
        {
            string particulars;
            if (item["journal_name"].ToString() == "General Journal")
                particulars = item["explanation"].ToString();
            else
                particulars = $"{GetJournalAcronym(item["journal_name"].ToString())} Total";

            return particulars;
        }

        private DataTable DataTableGeneralLedger()
        {
            byte fundId = (byte)cmbFunds.SelectedValue;
            ushort generalLedgerId = (ushort)cmbAccount.SelectedValue;
            short year = Convert.ToInt16(cmbYear.Text);

            var dtGeneralLedger = new dsLFS.GeneralLedgerDataTable();
            var dtGeneralLedgerFromDB = Factory.JEVAccountsRepository().GetViewRecordsByFundAndGeneralLedger(fundId, generalLedgerId, year);

            string particulars;
            foreach (DataRow item in dtGeneralLedgerFromDB.Rows)
            {
                particulars = ParseParticulars(item);

                DataRow row = dtGeneralLedger.NewRow();
                row["date"] = item["date_entry"];
                row["ref"] = GetJournalAcronym(item["journal_name"].ToString());

                ValidateDebitCreditRow(particulars, item, row, ref beginningBalance);

                dtGeneralLedger.Rows.Add(row);
            }

            return dtGeneralLedger;
        }

        private void BeginningBalanceRow(byte fundId, short year, ushort generalLedgerId, out string balanceDate, out string balanceDebit, out string balanceCredit, out string balance)
        {
            balanceDate = string.Empty;
            balanceDebit = string.Empty;
            balanceCredit = string.Empty;
            balance = string.Empty;

            bool generalLedgerBalanceExist = Factory.BeginningBalancesRepository().GeneralLedgerBalanceExist(fundId, generalLedgerId, year);
            if (generalLedgerBalanceExist)
            {
                var beginningBalanceDict = Factory.BeginningBalancesRepository().GetRecordByFundsAndGeneralLedgerID(fundId, generalLedgerId, year);

                balanceDate = beginningBalanceDict["date_entry"];

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
                ushort generalLedgerId = (ushort)cmbAccount.SelectedValue;

                string balanceDate, balanceDebit, balanceCredit, balance;
                BeginningBalanceRow(fundId, year, generalLedgerId, out balanceDate, out balanceDebit, out balanceCredit, out balance);

                var lguDict = Helper.LGUDetails();
                var generalLedgerDict = Factory.GeneralLedgerAccountsRepository().GetViewRecordByID(generalLedgerId);
                var fundName = cmbFunds.Text;
                report.ReportPath = $"{Application.StartupPath}\\Reports\\general-ledger.rdlc";
                report.DataSources.Clear();

                report.DataSources.Add(new ReportDataSource("GeneralLedger", DataTableGeneralLedger()));

                var parameters = new[] {
                    new ReportParameter("paramLGUName", lguDict["lgu_name"]),
                    new ReportParameter("paramFund", fundName),
                    new ReportParameter("paramAccountName", generalLedgerDict["ledger_name"]),
                    new ReportParameter("paramAccountCode", generalLedgerDict["account_code"]),
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

        private void frmGeneralLedgerReport_Load(object sender, EventArgs e)
        {
            Helper.LoadFormIcon(this);
            LoadFunds();
            LoadGeneralLedgerAccounts();
            LoadYear();
        }

        private void btnRetrieve_Click(object sender, EventArgs e)
        {
            LoadReport(reportViewer.LocalReport);
            reportViewer.SetDisplayMode(DisplayMode.PrintLayout);
            reportViewer.ZoomMode = ZoomMode.Percent;
            reportViewer.ZoomPercent = 100;
            reportViewer.RefreshReport();
        }
    }
}
