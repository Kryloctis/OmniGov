using AccountingSystem.DataSets;
using Microsoft.Reporting.WinForms;
using System;
using System.Data;
using System.Windows.Forms;

namespace AccountingSystem.Views.Transactions.Payments
{
    public partial class frmPreviewReceipt : Form
    {
        public frmPreviewReceipt()
        {
            InitializeComponent();
        }

        public class ReceiptPreviewParameters
        {
            public string Municipality { get; set; }
            public string ReceivedFrom { get; set; }
            public string SumAmountPaidWords { get; set; }
            public decimal SumAmountPaid { get; set; }
            public int CalendarYear { get; set; }
            public DateTime TransactionDate { get; set; }
            public decimal TotalPayment { get; set; }
            public string MunicipalTreasurer { get; set; }
            public string ProvincialTreasurer { get; set; }
            public decimal PaidCash { get; set; }
            public string CheckNo { get; set; }
            public decimal TwPmo { get; set; }
            public decimal TotalPaid { get; set; }
        }

        internal void OnLoad(ReceiptPreviewParameters receiptPreviewParameters, DataTable dataTable)
        {
            reportViewer1.Dock = DockStyle.Fill;
            panel1.Controls.Add(reportViewer1);
            LoadReceipt(receiptPreviewParameters, dataTable);
        }

        private void LoadReceipt(ReceiptPreviewParameters receiptPreviewParameters, DataTable dataTable)
        {
            var localReport = reportViewer1.LocalReport;
            localReport.EnableExternalImages = true;

            var receiptParameters = new ReportParameter[]
            {
                new ReportParameter("paramDate", receiptPreviewParameters.TransactionDate.ToString("MMM dd, yyyy")),
                new ReportParameter("paramReceivedFrom",receiptPreviewParameters.ReceivedFrom),
                new ReportParameter("paramMunicipality",receiptPreviewParameters.Municipality),
                new ReportParameter("paramSumOf", receiptPreviewParameters.SumAmountPaidWords),
                new ReportParameter("paramAmountInFigures",receiptPreviewParameters.SumAmountPaid.ToString("N2")),
                new ReportParameter("paramCalendarYear", receiptPreviewParameters.CalendarYear.ToString()),
                new ReportParameter("paramTotalPayment", receiptPreviewParameters.TotalPayment.ToString("N2")),
                new ReportParameter("paramPaidCash", receiptPreviewParameters.PaidCash.ToString("N2")),
                new ReportParameter("paramCheckNo", receiptPreviewParameters.CheckNo),
                new ReportParameter("paramTwPmo", receiptPreviewParameters.TwPmo.ToString("N2")),
                new ReportParameter("paramTotalPaid", receiptPreviewParameters.TotalPaid.ToString("N2")),
                new ReportParameter("paramMunicipalTreasurer", receiptPreviewParameters.MunicipalTreasurer),
                new ReportParameter("paramProvincialTreasurer", receiptPreviewParameters.ProvincialTreasurer),
            };

            localReport.ReportPath = $"{Application.StartupPath}\\Receipts\\AF56.rdlc";
            localReport.SetParameters(receiptParameters);

            localReport.DataSources.Clear();
            localReport.DataSources.Add(new ReportDataSource("dtAF56", dataTable));
            reportViewer1.RefreshReport();
            reportViewer1.ZoomPercent = 100;
            reportViewer1.SetDisplayMode(DisplayMode.PrintLayout);
        }

        private void frmPreviewReceipt_Load(object sender, EventArgs e)
        {
            try
            {
            }
            catch (Exception ex) { Helper.MessageBoxError(ex.StackTrace); }
        }
    }
}