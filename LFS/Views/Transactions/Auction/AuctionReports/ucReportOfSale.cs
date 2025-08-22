using ACC.Data;
using ACC.Domain.Models;
using LFS.Helpers;
using Microsoft.Reporting.WinForms;
using System;
using System.ComponentModel;
using System.Data;
using System.Windows.Forms;

namespace LFS.Views.Transactions.Auction
{
    public partial class ucReportOfSale : UserControl
    {
        private int auctionId;

        public ucReportOfSale()
        {
            InitializeComponent();
            panel1.Controls.Add(reportViewer1);
        }

        internal void OnLoad(int auctionId)
        {
            this.auctionId = auctionId;
            LoadReport();
        }

        private void LoadReport()
        {
            if (!backgroundWorker1.IsBusy)
            {
                progressBar1.Value = 0;
                backgroundWorker1.RunWorkerAsync(auctionId);
            }
        }

        private DataTable ReportData()
        {
            return new DataTable();
        }

        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
            try
            {
                int auctionId = (int)e.Argument;
                var rptAuctionModel = new RptAuctionModel() { AuctionId = auctionId };

                int totalProgressCount = 0;
                int progressCount = 0;

                progressCount++;
                Helper.ProgressCounter(backgroundWorker1, totalProgressCount, progressCount);
                e.Result = ReportData();
            }
            catch (Exception ex) { Helper.MessageBoxError(ex.Message); }
        }

        private void backgroundWorker1_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            progressBar1.Value = e.ProgressPercentage;
        }

        private void backgroundWorker1_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            try
            {
                if (e.Cancelled)
                    return;
                if (e.Result is not DataTable dataTable)
                    return;

                if (dataTable.Rows.Count < 1)
                    progressBar1.Value = 100;

                var report = reportViewer1.LocalReport;
                report.ReportPath = $"{Application.StartupPath}Reports\\LTOM\\Ltom31ReportOfSale.rdlc";
                report.DataSources.Clear();

                var dtAuction = AccFactory.AuctionRepository().GetRecordById(auctionId);

                string location = dtAuction["location"];
                string date = dtAuction["start_date"];

                var reportParameters = new ReportParameter[]
                {
                    new("paramLGU", ServerHelper.selectedServer.MunicipalityName),
                    new("paramDateOfPublicAuction", date)
                };

                report.DataSources.Add(new ReportDataSource(dataTable.TableName, dataTable));
                report.SetParameters(reportParameters);

                reportViewer1.SetDisplayMode(DisplayMode.PrintLayout);
                reportViewer1.ZoomMode = ZoomMode.PageWidth;
                reportViewer1.ZoomPercent = 100;
                reportViewer1.RefreshReport();
            }
            catch (Exception ex) { Helper.MessageBoxError(ex.Message); }
        }
    }
}