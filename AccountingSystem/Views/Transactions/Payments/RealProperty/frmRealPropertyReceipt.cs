using ACC.Data;
using AccountingSystem.DataSets;
using AccountingSystem.Properties;
using Microsoft.Reporting.WinForms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Windows.Forms;

namespace AccountingSystem.Views.Transactions.Payments.RealProperty
{
    public partial class frmRealPropertyReceipt : Form
    {
        private ReportViewer reportViewerReceipt;

        public frmRealPropertyReceipt()
        {
            InitializeComponent();
            Helper.LoadFormIcon(this);

            reportViewerPreview.ShowFindControls = false;
            reportViewerPreview.ShowExportButton = false;
            reportViewerPreview.ShowPrintButton = false;
            reportViewerPreview.ShowDocumentMapButton = false;
            reportViewerPreview.ShowStopButton = false;
            reportViewerPreview.Dock = DockStyle.Fill;
            panel1.Controls.Add(reportViewerPreview);

            reportViewerReceipt = new ReportViewer();
            reportViewerReceipt.Dock = DockStyle.Fill;
            panel1.Controls.Add(reportViewerReceipt);
        }

        private void bgwAf56_DoWork(object sender, DoWorkEventArgs e)
        {
            try
            {
                var parameters = (AF56Parameters)e.Argument;
                var dataTable = new dsTreasury.dtAF56DataTable();
                var filteredRows = parameters.DataSource.AsEnumerable().Where(row => row.Field<bool>("is_selected")).CopyToDataTable();
                var dictTaxpayer = AccFactory.TaxpayersRepository().GetRecordByID(parameters.TaxpayerId);

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

                e.Result = (dataTable, parameters);
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

                var localReportPreview = reportViewerPreview.LocalReport;
                var localReportReceipt = reportViewerReceipt.LocalReport;
                localReportPreview.EnableExternalImages = true;
                var backgroundImage = new Bitmap(Resources.AF56);

                localReportPreview.ReportPath = $"{Application.StartupPath}\\Receipts\\AF56.rdlc";
                localReportPreview.SetParameters(reportParameters);
                localReportPreview.DataSources.Clear();
                localReportPreview.DataSources.Add(new ReportDataSource("dtAF56", dataTable));
                reportViewerPreview.RefreshReport();
                reportViewerPreview.ZoomPercent = 100;
                reportViewerPreview.SetDisplayMode(DisplayMode.PrintLayout);
            }
            catch (Exception ex) { Helper.MessageBoxError(ex.Message); }
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