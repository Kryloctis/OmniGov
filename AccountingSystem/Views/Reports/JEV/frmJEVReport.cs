using System;
using System.Windows.Forms;
using Microsoft.Reporting.WinForms;
using System.Data;

namespace AccountingSystem.Views.Reports.JEV
{
    public partial class frmJEVReport : Form
    {
        private readonly ReportViewer reportViewer;
        private int _jevId;
        private string _jevNo;

        public frmJEVReport(int jevId, string jevNo)
        {
            InitializeComponent();
            reportViewer = new ReportViewer();
            reportViewer.Dock = DockStyle.Fill;
            panel1.Controls.Add(reportViewer);

            _jevId = jevId;
            _jevNo = jevNo;
        }


        private void LoadReport(LocalReport report)
        {
            try
            {
                var data = Factory.JEVRepository().GetRecordByJEV(_jevNo);

                var lguDetails = Helper.LGUDetails();
                var signatory = "MARY MAGDALYN T. REGANION, CPA";
                var preparedBy = "JOHN CENA";
                var full_jev = $"{data["fund_code"]}-{Convert.ToDateTime(data["date_entry"]).Year}-{Convert.ToDateTime(data["date_entry"]).Month}-{data["jev_no"]}";


                var parameters = new[] {
                    new ReportParameter("paramLGU",  lguDetails["lgu_name"]),
                    new ReportParameter("paramFund", data["fund_name"]),
                    new ReportParameter("paramJournalType", data["journal_name"]),
                    new ReportParameter("paramJEVNo", full_jev),
                    new ReportParameter("paramJEVDate", Convert.ToDateTime(data["date_entry"]).ToString("MM/dd/yy")),

                    new ReportParameter("paramPayee", data["payee"]),
                    new ReportParameter("paramExplanation", data["explanation"]),

                    new ReportParameter("paramPreparedBy",preparedBy),
                    new ReportParameter("paramCertifiedBy", signatory)


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
            var dtJEVAccountsFromDB = Factory.JEVAccountsRepository().GetViewRecordsByJevId(_jevId);

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
            Helper.DatagridDefaultStyle(dgJEV);

            if (_jevId != 0)
            {
                LoadReport(reportViewer.LocalReport);
                reportViewer.SetDisplayMode(DisplayMode.PrintLayout);
                reportViewer.ZoomMode = ZoomMode.Percent;
                reportViewer.ZoomPercent = 100;
                reportViewer.RefreshReport();
            }
        }

        private void btnRetrieve_Click(object sender, EventArgs e)
        {
            var dtJEV = Factory.JEVRepository().GetRecordsBySearch(textBox1.Text.Trim());
            HelperLoadRecords.JEVDatagridView(dtJEV, dgJEV);
        }

        private void dgJEV_SelectionChanged(object sender, EventArgs e)
        {
            if (dgJEV.SelectedCells.Count > 0)
            {
                int selectedIndex = dgJEV.SelectedCells[0].RowIndex;

                DataGridViewRow selectedRow = dgJEV.Rows[selectedIndex];

                _jevNo = Convert.ToString(selectedRow.Cells["jev_no"].Value);
                _jevId = Convert.ToInt32(selectedRow.Cells["id"].Value);

                LoadReport(reportViewer.LocalReport);
                reportViewer.SetDisplayMode(DisplayMode.PrintLayout);
                reportViewer.ZoomMode = ZoomMode.Percent;
                reportViewer.ZoomPercent = 100;
                reportViewer.RefreshReport();
            }
        }
    }
}
