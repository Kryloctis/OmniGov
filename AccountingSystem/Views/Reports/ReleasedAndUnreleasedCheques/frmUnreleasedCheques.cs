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

namespace AccountingSystem.Views.Reports.ReleasedAndUnreleasedCheques
{
    public partial class frmUnreleasedChequesReport : Form
    {
        private readonly ReportViewer reportViewer;

        public frmUnreleasedChequesReport()
        {
            InitializeComponent();
            Helper.LoadFormIcon(this);

            reportViewer = new ReportViewer();
            reportViewer.Dock = DockStyle.Fill;
            panel1.Controls.Add(reportViewer);
        }

        private void frmUnreleasedChequesReport_Load(object sender, EventArgs e)
        {
            LoadBanks();
            LoadBankAccounts();
        }

        private void btnRetrieve_Click(object sender, EventArgs e)
        {
            LoadReport(reportViewer.LocalReport);
        }

        private void LoadReport(LocalReport report)
        {

            try
            {
                Cursor = Cursors.WaitCursor;

                var lguDetails = Helper.LGUDetails();
                int bankAccountId = Convert.ToInt32(cmbBankAccounts.SelectedValue);
                var dictBankAccount = AccFactory.BankAccountsRepository().GetViewRecordById(bankAccountId);

                string bankDetails = string.Format("{0} - {1}", dictBankAccount["bank_name"], dictBankAccount["account_no"]);
                var parameters = new[] {
                    new ReportParameter("paramFund", "General Fund"),
                    new ReportParameter("paramLGUName", lguDetails["lgu_name"]),
                    new ReportParameter("paramBankAccount", bankDetails),
                };

                report.ReportPath = $"{Application.StartupPath}Reports\\schedule-of-unreleased-cheques.rdlc";
                report.DataSources.Clear();

                report.DataSources.Add(new ReportDataSource("dtSchedulesOfUnreleasedCheque", DataTableRCI()));
                report.SetParameters(parameters);
                reportViewer.SetDisplayMode(DisplayMode.PrintLayout);
                reportViewer.ZoomMode = ZoomMode.Percent;
                reportViewer.ZoomPercent = 100;
                reportViewer.RefreshReport();

                Cursor = Cursors.Default;
            }
            catch (Exception ex)
            {
                Helper.MessageBoxError(ex.Message);
            }
        }

        private DataTable DataTableRCI()
        {
            int bankAccountIDID = Convert.ToInt32(cmbBankAccounts.SelectedValue);

            var dtReleasedCheques = new dsLFS.dtSchedulesOfReleasedChequeDataTable();
            DataTable dtReleasedChequesFromDB = AccFactory.ReleasedChequesRepository().GetViewRecordsByBankAccountID(bankAccountIDID);

            if (dtReleasedChequesFromDB.Rows.Count == 0)
                return dtReleasedCheques;

            foreach (DataRow item in dtReleasedChequesFromDB.Rows)
            {
                DataRow row = dtReleasedCheques.NewRow();

                var chequeDate = Convert.ToDateTime(item["cheque_date"]);
                string chequeNumber = item["cheque_no"].ToString();
                string dvNumber = item["dv_no"].ToString();
                string payee = item["payee"].ToString();
                string natureOfPayment = item["nature_of_payment"].ToString();
                decimal amount = Convert.ToDecimal(item["cheque_amount"]);

                row["cheque_date"] = chequeDate.ToString("yyyy-MM-dd");
                row["cheque_serial_number"] = chequeNumber;
                row["dv_number"] = dvNumber;
                row["cafoa_number"] = string.Empty;
                row["payee"] = payee;
                row["nature_of_payment"] = natureOfPayment;
                row["amount"] = amount;

                dtReleasedCheques.Rows.Add(row);
            }

            return dtReleasedCheques;
        }

        internal void LoadBanks()
        {
            try
            {
                var bankRepository = AccFactory.BanksRepository();
                var dtBank = bankRepository.GetRecords();
                cmbBank.DataSource = dtBank;
                cmbBank.ValueMember = "id";
                cmbBank.DisplayMember = "bank_name";
            }
            catch (Exception ex)
            {
                Helper.MessageBoxError(ex.Message);
            }
        }

        private void LoadBankAccounts()
        {
            int bankID = Convert.ToInt32(cmbBank.SelectedValue);
            DataTable dtBankAccounts = AccFactory.BankAccountsRepository().GetBankAccountsByBankID(bankID);

            cmbBankAccounts.DataSource = dtBankAccounts;
            cmbBankAccounts.ValueMember = "id";
            cmbBankAccounts.DisplayMember = "account_no";
        }
    }
}
