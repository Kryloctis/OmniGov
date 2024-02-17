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
        private ReportViewer reportViewer2;

        public frmAF51Receipt()
        {
            InitializeComponent();
            Helper.LoadFormIcon(this);
            reportViewer1.ShowFindControls = false;
            reportViewer1.ShowExportButton = false;
            reportViewer1.ShowPrintButton = false;
            reportViewer1.ShowDocumentMapButton = false;
            reportViewer1.ShowStopButton = false;
            reportViewer1.Dock = DockStyle.Fill;
            reportViewer2 = new ReportViewer();
            reportViewer2.Dock = DockStyle.Fill;
            panel1.Controls.Add(reportViewer1);
            panel1.Controls.Add(reportViewer2);
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
                var localReportPreview = reportViewer1.LocalReport;
                var localReportPrint = reportViewer2.LocalReport;
                localReportPreview.EnableExternalImages = true;
                var bg = new Bitmap(Resources.AF51);

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
                    new ReportParameter("paramBackground", Convert.ToBase64String(Helper.ImageToByteArray(bg)))
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

            reportViewer1.RefreshReport();
            reportViewer1.ZoomPercent = 100;
            reportViewer1.SetDisplayMode(DisplayMode.PrintLayout);


            reportViewer2.RefreshReport();
            reportViewer2.ZoomPercent = 100;
            reportViewer2.SetDisplayMode(DisplayMode.PrintLayout);
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            try
            {
                reportViewer2.PrintDialog();
            }
            catch (Exception ex) { Helper.MessageBoxError(ex.Message); }
        }
    }
}