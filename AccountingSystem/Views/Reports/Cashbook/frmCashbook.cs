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

namespace AccountingSystem.Views.Reports.Cashbook
{
    public partial class frmCashbook : Form
    {
        private readonly ReportViewer reportViewer = new ReportViewer();
        public frmCashbook()
        {
            InitializeComponent();
            reportViewer.Dock = DockStyle.Fill;
            panel1.Controls.Add(reportViewer);
            Helper.LoadFormIcon(this);
        }

        private void frmCashbook_Load(object sender, EventArgs e)
        {
            LoadBanks();
        }

        internal void LoadBanks()
        {
            try
            {
                var fundRepository = Factory.BanksRepository();
                var dtBank = fundRepository.GetRecords();
                dtBank.Columns.Add("bankdisplay", typeof(string), "bank_name + ' - ' + account_no");
                cmbbank.DataSource = dtBank;
                cmbbank.ValueMember = "id";
                cmbbank.DisplayMember = "bankdisplay";
            }
            catch (Exception ex) { Helper.MessageBoxError(ex.Message); }
        }

        private DataTable DataTableCB(int id)
        {
            var dtCB = new dsLFS.dtCashbookDataTable();
            var dtBD = Factory.BankDepositsRepository().GetRecordsBySearch(id);
            var dtRC = Factory.RCIRepository().GetRecords(id);
            if(dtBD.Rows.Count > 0 || dtRC.Rows.Count > 0)
            {
                decimal balance = 0;
                decimal debit = 0;
                decimal credit = 0;
                foreach (DataRow item in dtBD.Rows)
                {
                    DataRow row = dtCB.NewRow();
                    row["date"] = item["date"];
                    row["particulars"] = String.Format("Deposit - {0} - {1}",item["bank_name"], item["account_no"]);
                    row["reference"] = item["reference"];
                    row["debit"] = item["amount"];
                    debit += Convert.ToDecimal(item["amount"]);
                    balance = debit - credit;
                   // row["credit"] = 0;
                    row["balance"] = balance;
                    dtCB.Rows.Add(row);
                }

                foreach (DataRow item in dtRC.Rows)
                {
                    DataRow row = dtCB.NewRow();
                    row["date"] = item["check_date"];
                    row["particulars"] = String.Format("Check Issued - {0} - {1}", item["payee"], item["nature_of_payment"]);
                    row["reference"] = String.Format("{0} - {1}", item["check_no"], item["dv_no"]);
                    row["credit"] = item["amount"];
                    credit += Convert.ToDecimal(item["amount"]);
                    balance = debit - credit;
                    //  row["debit"] = 0;
                    row["balance"] = balance;
                    dtCB.Rows.Add(row);
                }
            }
            return dtCB;
        }
        private void LoadReport(LocalReport report)
        {
            try
            {
                int id = Convert.ToInt32(cmbbank.SelectedValue);
                var lguDetails = Helper.LGUDetails();
                var account = cmbbank.Text;
                var parameters = new[] {
                            new ReportParameter("paramLGUName", lguDetails["lgu_name"]),
                            new ReportParameter("paramBankaccount", account)
                    };
                report.ReportPath = $"{Application.StartupPath}Reports\\cashbook.rdlc";
                report.DataSources.Clear();
                report.DataSources.Add(new ReportDataSource("dtCashbook", DataTableCB(id)));
                report.SetParameters(parameters);
                report.Refresh();


            }
            catch (Exception ex)
            {
                Helper.MessageBoxError(ex.Message);
            }


        }
        private void btnretrieve_Click(object sender, EventArgs e)
        {
            if(cmbbank.SelectedIndex == -1)
            {
                errorProvider.SetError(cmbbank, "Please select Bank!");
                cmbbank.Focus();
            }
            else
            {
                LoadReport(reportViewer.LocalReport);
                reportViewer.SetDisplayMode(DisplayMode.PrintLayout);
                reportViewer.ZoomMode = ZoomMode.Percent;
                reportViewer.ZoomPercent = 100;
                reportViewer.RefreshReport();
            }
        }
    }
}
