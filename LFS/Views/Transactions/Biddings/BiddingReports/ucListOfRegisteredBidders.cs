using LFS.DataSets;
using LFS.Helpers;
using Microsoft.Reporting.WinForms;
using System;
using System.ComponentModel;
using System.Data;
using System.Windows.Forms;
using Treasury.Data;
using Treasury.Domain.Entities;

namespace LFS.Views.Transactions.Biddings.BiddingReports
{
    public partial class ucListOfRegisteredBidders : UserControl
    {
        private int auctionId;

        public ucListOfRegisteredBidders()
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
                backgroundWorker1.RunWorkerAsync(this.auctionId);
            }
        }

        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
            try
            {
                int auctionId = (int)e.Argument;

                var auctionModel = new AuctionModel() { Id = auctionId };
                var rptAuctionModel = new RptAuctionModel() { AuctionId = auctionId };

                var dbRegisteredBidders = TreasuryFactory.BiddersRepository().GetViewRecords();
                var dtRegisteredBidders = new dsTreasury.dtLtom26_27_28DataTable();

                int totalProgressCount = dbRegisteredBidders.Rows.Count;
                int progressCount = 0;

                foreach (DataRow dataRow in dbRegisteredBidders.Rows)
                {
                    var newRow = dtRegisteredBidders.NewRow();

                    newRow["assigned_bidders_no"] = dataRow["bidder_no"];
                    newRow["name_of_bidders_or_representative"] = dataRow["name"];
                    newRow["complete_address_or_business_address"] = dataRow["address"];
                    newRow["contact_no"] = dataRow["contact_info"];
                    newRow["official_receipts_no"] = dataRow["receipt_no"];

                    dtRegisteredBidders.Rows.Add(newRow);
                    progressCount++;
                    Helper.ProgressCounter(backgroundWorker1, totalProgressCount, progressCount);
                }
                e.Result = dtRegisteredBidders;
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
                report.ReportPath = $"{Application.StartupPath}Reports\\LTOM\\Ltom26ListOfRegisteredBidders.rdlc";
                report.DataSources.Clear();

                var reportParameters = new ReportParameter[]
                {
                    new("paramLGU", ServerHelper.selectedServer.MunicipalityName),
                    new("paramSignatoryTitle", string.Empty),
                    new("paramSignatory", string.Empty),
                };

                report.DataSources.Add(new ReportDataSource("dtLtom26_27_28", dataTable));
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
