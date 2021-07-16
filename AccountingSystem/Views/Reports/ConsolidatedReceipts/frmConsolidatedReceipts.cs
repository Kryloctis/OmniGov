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

namespace AccountingSystem.Views.Reports.ConsolidatedReceipts
{
    public partial class frmConsolidatedReceipts : Form
    {
        private readonly ReportViewer reportViewer = new ReportViewer();
        public frmConsolidatedReceipts()
        {
            InitializeComponent();
            reportViewer.Dock = DockStyle.Fill;
            panel1.Controls.Add(reportViewer);
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

        private void frmConsolidatedReceipts_Load(object sender, EventArgs e)
        {

        }

        private DataTable DataTableReceipts(string date)
        {

            var dtRC = new dsLFS.dtReceiptsConsolidatedDataTable();
            var dt = Factory.GeneralCollectionsRepository().GetRecordByReceiptsConsolidated(date);
            if (dt.Rows.Count > 0)
            {
                foreach (DataRow item in dt.Rows)
                {
                    DataRow row = dtRC.NewRow();
                    row["form"] = item["form"];
                    row["receiptfrom"] = item["receiptsfrom"];
                    row["receiptto"] = item["receiptsto"];
                    row["issuefrom"] = item["issuefrom"];
                    row["issueto"] = item["issueto"];
                    row["usedfrom"] = item["ifrom"];
                    row["usedto"] = item["ito"];
                    row["officers"] = item["officers"];
                    dtRC.Rows.Add(row);
                }
            }

            return dtRC;
        }

        private void LoadReport(LocalReport report)
        {
            try
            {
                var lguDetails = Helper.LGUDetails();
                var date = String.Format("{0:yyyy-MM-dd}", dtto.Value);
                var parameters = new[] {
                            new ReportParameter("paramLGUName", lguDetails["lgu_name"]),
                            new ReportParameter("paramTreasurer", "ENSIGN S. UBA"),
                            new ReportParameter("paramLRCO", "FE F. HAMOY")
                    };
                report.ReportPath = $"{Application.StartupPath}Reports\\consolidated-receipts.rdlc";
                report.DataSources.Clear();
                report.DataSources.Add(new ReportDataSource("dtReceiptsConsolidated", DataTableReceipts(date)));

                report.SetParameters(parameters);
                report.Refresh();
            }
            catch (Exception ex)
            {
                Helper.MessageBoxError(ex.Message);
            }

        }
    }
}
