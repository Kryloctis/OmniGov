using System;
using System.Windows.Forms;
using Microsoft.Reporting.WinForms;
using System.Data;

namespace AccountingSystem.Views.Reports.JEV
{
    public partial class frmJEVReport : Form
    {
        private readonly ReportViewer reportViewer;
        private string _jevNo;

        public frmJEVReport(string jevNo)
        {
            InitializeComponent();
            reportViewer = new ReportViewer();
            reportViewer.Dock = DockStyle.Fill;
            panel1.Controls.Add(reportViewer);

            _jevNo = jevNo;
        }


        private void LoadReport(LocalReport report)
        {
            try
            {
                var data = Factory.JEVRepository().GetRecordByJEV(_jevNo);

                var parameters = new[] {
                    new ReportParameter("paramLGU", "BUUG"),
                    new ReportParameter("paramFund", data["fund_name"]),
                    new ReportParameter("paramJournalType", data["journal_name"]),
                    new ReportParameter("paramJEVNo", data["jev_no"]),
                    new ReportParameter("paramJEVDate", Convert.ToDateTime(data["date_entry"]).ToString("MM/dd/yy")),

                    new ReportParameter("paramPayee", data["payee"]),
                    new ReportParameter("paramExplanation", data["explanation"])


                };

                report.ReportPath = $"{Application.StartupPath}\\Reports\\journal-entry-voucher.rdlc";
                report.DataSources.Clear();


                report.DataSources.Add(new ReportDataSource("dtJournalVoucher", DataTableJournalEntryVoucherAccount()));
                report.SetParameters(parameters);


            }
            catch (Exception ex)
            {
                Helper.MessageBoxError(ex.Message);
            }
        }

        private DataTable DataTableJournalEntryVoucherAccount()
        {
            var dtJEVAccounts = new dsLFS.dtJournalVoucherDataTable();
            var dtJEVAccountsFromDB = Factory.JEVAccountsRepository().GetViewRecordsByJevId(57);

            byte i = 0;

            foreach (DataRow item in dtJEVAccountsFromDB.Rows)
            {
                DataRow row = dtJEVAccounts.NewRow();

                row["fpp"] = item["fpp_code"];
                row["account_and_explanation"] = item["ledger_name"];
                row["account_code"] = item["account_code"];


                if (Convert.ToBoolean(item["is_debit"]))
                    row["debit"] = item["amount"];
                else
                    row["credit"] = item["amount"];
              
                dtJEVAccounts.Rows.Add(row);

                i++;
            }
            return dtJEVAccounts;
        }

        private void frmJEVReport_Load(object sender, EventArgs e)
        {
            Helper.LoadFormIcon(this);
        }

        private void btnRetrieve_Click(object sender, EventArgs e)
        {
            LoadReport(reportViewer.LocalReport);
            reportViewer.SetDisplayMode(DisplayMode.PrintLayout);
            reportViewer.ZoomMode = ZoomMode.Percent;
            reportViewer.ZoomPercent = 100;
            reportViewer.RefreshReport();
        }

        private void listBox1_SelectedValueChanged(object sender, EventArgs e)
        {
            //LoadJEVs
        }
    }
}
