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

namespace AccountingSystem.Views.Reports.PaymentCollection
{
    public partial class frmPCReport : Form
    {
        private readonly ReportViewer reportViewer;
        public frmPCReport()
        {
            InitializeComponent();
            reportViewer = new ReportViewer();
            reportViewer.Dock = DockStyle.Fill;
            panel1.Controls.Add(reportViewer);
            Helper.LoadFormIcon(this);
        }

        private void frmPCReport_Load(object sender, EventArgs e)
        {

        }

        private DataTable DataTablePC()
        {
            var dateYearMonth = String.Format("{0:MMMM}-{0:yyyy}", Convert.ToDateTime(dtpMonth.Value));
            var dtPC = new dsLFS.dtPCDataTable();
            var dt = Factory.PaymentCollectionRepository().GetRecordByLedger(dateYearMonth);
            if(dt.Rows.Count > 0)
            {
                foreach (DataRow item in dt.Rows)
                {
                    DataRow row = dtPC.NewRow();
                    row["rcdno"] = item["id"];
                    row["payee"] = item["payee"];
                    row["acc_form_desc"] = item["acc_form_desc"];
                    row["ledger_name"] = item["ledger_name"];
                    row["payment_date"] = item["payment_date"];
                    row["receipt_no"] = item["receipt_no"];
                    row["amount"] = item["amount"];
                    row["collector"] = item["collector"];                    
                    dtPC.Rows.Add(row);
                }
            }

            return dtPC;
        }

        private void LoadReport(LocalReport report)
        {

            try
            {
                var lguDetails = Helper.LGUDetails();
                var signatory = "FELIX A. TRAPA";

                var pcrepo = Factory.PaymentCollectionRepository();
                var parameters = new[] {
                    new ReportParameter("paramLGUName", lguDetails["lgu_name"]),
                    new ReportParameter("paramMonth", dtpMonth.Value.ToString()),
                    new ReportParameter("paramSignatory", signatory)
                };
                report.ReportPath = $"{Application.StartupPath}\\Reports\\payment-collection.rdlc";
                report.DataSources.Clear();

                report.DataSources.Add(new ReportDataSource("dtPC", DataTablePC()));
                report.SetParameters(parameters);

            }
            catch (Exception ex)
            {
                Helper.MessageBoxError(ex.Message);
            }
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
