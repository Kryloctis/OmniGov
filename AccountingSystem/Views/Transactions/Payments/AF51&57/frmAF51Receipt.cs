using AccountingSystem.DataSets;
using AccountingSystem.Properties;
using Microsoft.Reporting.WinForms;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AccountingSystem.Views.Transactions.Payments.AF51_57
{
    public partial class frmAF51Receipt : Form
    {
        private ReportViewer reportViewerReceipt;

        public frmAF51Receipt()
        {
            InitializeComponent();
            Helper.LoadFormIcon(this);
            reportViewerPreview.ShowFindControls = false;
            reportViewerPreview.ShowExportButton = false;
            reportViewerPreview.ShowPrintButton = false;
            reportViewerPreview.ShowDocumentMapButton = false;
            reportViewerPreview.ShowStopButton = false;
            reportViewerPreview.Dock = DockStyle.Fill;
            reportViewerReceipt = new ReportViewer();
            reportViewerReceipt.Dock = DockStyle.Fill;
            panel1.Controls.Add(reportViewerPreview);
            panel1.Controls.Add(reportViewerReceipt);
        }

        internal class AF51Parameters
        {
            internal string Municipality { get; set; }
            internal DateTime TransactionDate { get; set; }
            internal string Agency { get; set; }
            internal string Payee { get; set; }
            internal string Fund { get; set; }
            internal decimal TotalPayment { get; set; }
            internal string TotalPaymentWords { get; set; }
            internal string ChequeBank { get; set; }
            internal string ChequeNo { get; set; }
            internal string ChequeDate { get; set; }
            internal string CollectingOfficerName { get; set; }
            internal bool IsCash { get; set; }
            internal bool IsCheck { get; set; }
            internal bool IsMoneyOrder { get; set; }
            internal dsTreasury.dtAF51DataTable dtAF51DataTable { get; set; }
        }

        internal async void OnLoad(AF51Parameters aF51Parameters)
        {
            await LoadReceiptAsync(aF51Parameters);
        }

        private async Task LoadReceiptAsync(AF51Parameters aF51Parameters)
        {
            await Task.Run(() =>
            {
                var localReportPreview = reportViewerPreview.LocalReport;
                var localReportPrint = reportViewerReceipt.LocalReport;
                localReportPreview.EnableExternalImages = true;
                var backgroundImage = new Bitmap(Resources.AF51);

                var reportParameters = new List<ReportParameter>
                {
                    new ReportParameter("paramMunicipality", aF51Parameters.Municipality),
                    new ReportParameter("paramTransactionDate", aF51Parameters.TransactionDate.ToString()),
                    new ReportParameter("paramAgency", aF51Parameters.Agency),
                    new ReportParameter("paramPayee", aF51Parameters.Payee),
                    new ReportParameter("paramFund", aF51Parameters.Fund),
                    new ReportParameter("paramTotalPayment", aF51Parameters.TotalPayment.ToString()),
                    new ReportParameter("paramTotalPaymentWords", aF51Parameters.TotalPaymentWords),
                    new ReportParameter("paramChequeBank", aF51Parameters.ChequeBank),
                    new ReportParameter("paramChequeNo", aF51Parameters.ChequeNo),
                    new ReportParameter("paramChequeDate", aF51Parameters.ChequeDate.ToString()),
                    new ReportParameter("paramCollectingOfficerName", aF51Parameters.CollectingOfficerName),
                    new ReportParameter("paramIsCash", aF51Parameters.IsCash.ToString()),
                    new ReportParameter("paramIsCheck", aF51Parameters.IsCheck.ToString()),
                    new ReportParameter("paramIsMoneyOrder", aF51Parameters.IsMoneyOrder.ToString()),
                    new ReportParameter("paramBackground", Convert.ToBase64String(Helper.ImageToByteArray(backgroundImage)))
                };

                localReportPreview.DataSources.Clear();
                localReportPreview.DataSources.Add(new ReportDataSource("dtAF51", (DataTable)aF51Parameters.dtAF51DataTable));
                localReportPreview.ReportPath = $"{Application.StartupPath}\\Receipts\\AF51.rdlc";
                localReportPreview.SetParameters(reportParameters);

                localReportPrint.DataSources.Clear();
                localReportPrint.DataSources.Add(new ReportDataSource("dtAF51", (DataTable)aF51Parameters.dtAF51DataTable));
                localReportPrint.ReportPath = $"{Application.StartupPath}\\Receipts\\AF51.rdlc";
                reportParameters.RemoveAll(param => param.Name == "paramBackground");
                localReportPrint.SetParameters(reportParameters);
            });

            reportViewerPreview.RefreshReport();
            reportViewerPreview.ZoomPercent = 100;
            reportViewerPreview.SetDisplayMode(DisplayMode.PrintLayout);

            reportViewerReceipt.RefreshReport();
            reportViewerReceipt.ZoomPercent = 100;
            reportViewerReceipt.SetDisplayMode(DisplayMode.PrintLayout);
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            try
            {
                reportViewerReceipt.PrintDialog();
            }
            catch (Exception ex) { Helper.MessageBoxError(ex.Message); }
        }
    }
}