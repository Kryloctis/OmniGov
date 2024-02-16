using ACC.Data;
using AccountingSystem.DataSets;
using Microsoft.Reporting.WinForms;
using System;
using System.ComponentModel;
using System.Data;
using System.Windows.Forms;

namespace AccountingSystem.Views.Transactions.Payments.RealProperty
{
    public partial class frmRealPropertyReceipt : Form
    {
        private AF56Parameters af56Parameters;

        public frmRealPropertyReceipt()
        {
            InitializeComponent();
            Helper.LoadFormIcon(this);
            reportViewer1.ShowFindControls = false;
            reportViewer1.ShowExportButton = false;
            reportViewer1.ShowPrintButton = false;
            reportViewer1.ShowDocumentMapButton = false;
            reportViewer1.ShowStopButton = false;
            reportViewer1.Dock = DockStyle.Fill;
            panel1.Controls.Add(reportViewer1);
        }

        internal class AF56Parameters
        {
            internal int TaxpayerId { get; set; }
            internal string Municipality { get; set; }
            internal string ReceivedFrom { get; set; }
            internal string SumAmountPaidWords { get; set; }
            internal decimal SumAmountPaid { get; set; }
            internal int CalendarYear { get; set; }
            internal DateTime TransactionDate { get; set; }
            internal decimal TotalPayment { get; set; }
            internal string MunicipalTreasurer { get; set; }
            internal string ProvincialTreasurer { get; set; }
            internal decimal PaidCash { get; set; }
            internal string CheckNo { get; set; }
            internal decimal TwPmo { get; set; }
            internal decimal TotalPaid { get; set; }
            internal DataTable DataSource { get; set; }
        }

        internal void OnLoad(AF56Parameters af56Parameters)
        {
            this.af56Parameters = af56Parameters;
        }

        private void frmPreviewReceipt_Load(object sender, EventArgs e)
        {
            try
            {
                if (!DesignMode)
                {
                    LoadReceipts();
                }
            }
            catch (Exception ex) { Helper.MessageBoxError(ex.Message); }
        }

        private void LoadReceipts()
        {
            if (!bgwAf56.IsBusy)
            {
                progressBar1.Value = 0;
                bgwAf56.RunWorkerAsync();
            }
        }

        private void bgwAf56_DoWork(object sender, DoWorkEventArgs e)
        {
            try
            {
                var dataTable = new dsTreasury.dtAF56DataTable();
                var filteredRows = af56Parameters.DataSource.AsEnumerable().Where(row => row.Field<bool>("is_selected")).CopyToDataTable();
                var dictTaxpayer = AccFactory.TaxpayersRepository().GetRecordByID(af56Parameters.TaxpayerId);

                int totalProgressCount = filteredRows.Rows.Count;
                int progressCount = 0;

                foreach (DataRow row in filteredRows.Rows)
                {
                    var newRow = dataTable.NewRow();

                    newRow["owner"] = dictTaxpayer["name"];
                    newRow["location"] = "sample";
                    newRow["block_lot_no"] = "sample";
                    newRow["tax_dec_no"] = row["complete_arp_no"];
                    newRow["assessed_value"] = 100;
                    newRow["type"] = row["type"];
                    newRow["tax_due"] = row["tax_due_amount"];
                    newRow["penalt_discount"] = row["penalty_discount"];
                    newRow["total"] = row["total_payment"];

                    dataTable.Rows.Add(newRow);
                    progressCount++;
                    Helper.ProgressCounter(bgwAf56, totalProgressCount, progressCount);
                }

                e.Result = dataTable;
            }
            catch (Exception ex) { Helper.MessageBoxError(ex.Message); }
        }

        private void bgwAf56_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            progressBar1.Value = e.ProgressPercentage;
        }

        private void bgwAf56_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            try
            {
                if (e.Cancelled)
                    return;

                if (e.Result is not DataTable dataTable)
                    return;

                if (dataTable.Rows.Count < 1)
                    bgwAf56.ReportProgress(100);

                var localReport = reportViewer1.LocalReport;
                localReport.EnableExternalImages = true;

                var receiptParameters = new ReportParameter[]
                {
                    new ReportParameter("paramDate", af56Parameters.TransactionDate.ToString("MMM dd, yyyy")),
                    new ReportParameter("paramReceivedFrom",af56Parameters.ReceivedFrom),
                    new ReportParameter("paramMunicipality",af56Parameters.Municipality),
                    new ReportParameter("paramSumOf", af56Parameters.SumAmountPaidWords),
                    new ReportParameter("paramAmountInFigures",af56Parameters.SumAmountPaid.ToString("N2")),
                    new ReportParameter("paramCalendarYear", af56Parameters.CalendarYear.ToString()),
                    new ReportParameter("paramTotalPayment", af56Parameters.TotalPayment.ToString("N2")),
                    new ReportParameter("paramPaidCash", af56Parameters.PaidCash.ToString("N2")),
                    new ReportParameter("paramCheckNo", af56Parameters.CheckNo),
                    new ReportParameter("paramTwPmo", af56Parameters.TwPmo.ToString("N2")),
                    new ReportParameter("paramTotalPaid", af56Parameters.TotalPaid.ToString("N2")),
                    new ReportParameter("paramMunicipalTreasurer", af56Parameters.MunicipalTreasurer),
                    new ReportParameter("paramProvincialTreasurer", af56Parameters.ProvincialTreasurer),
                };

                localReport.ReportPath = $"{Application.StartupPath}\\Receipts\\AF56.rdlc";
                localReport.SetParameters(receiptParameters);

                localReport.DataSources.Clear();
                localReport.DataSources.Add(new ReportDataSource("dtAF56", dataTable));
                reportViewer1.RefreshReport();
                reportViewer1.ZoomPercent = 100;
                reportViewer1.SetDisplayMode(DisplayMode.PrintLayout);
            }
            catch (Exception ex) { Helper.MessageBoxError(ex.Message); }
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            try
            {
                reportViewer1.PrintDialog();
            }
            catch (Exception ex) { Helper.MessageBoxError(ex.Message); }
        }
    }
}