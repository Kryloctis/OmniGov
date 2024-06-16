using ACC.Data;
using AccountingSystem.DataSets;
using Microsoft.Reporting.WinForms;
using System;
using System.Data;
using System.Windows.Forms;


namespace AccountingSystem.Views.Transactions.Biddings.BiddingReports
{
    public partial class ucUnderTakingAndWaiverOfBidders : UserControl
    {
        private int auctionId;
        private int bidderId;

        public ucUnderTakingAndWaiverOfBidders()
        {
            InitializeComponent();
            panel1.Controls.Add(reportViewer1);

        }

        internal void OnLoad(int auctionId, int bidderId)
        {
            LoadReport();
            this.auctionId = auctionId;
            this.bidderId = bidderId;
        }

        private void LoadReport()
        {
            if (!backgroundWorker1.IsBusy)
            {
                progressBar1.Value = 0;
                backgroundWorker1.RunWorkerAsync((auctionId, bidderId));
            }
        }

        private void backgroundWorker1_DoWork(object sender, System.ComponentModel.DoWorkEventArgs e)
        {
            try
            {
                var parameters = ((int auctionId, int bidderId))e.Argument;

                var dbRegisteredBidders = AccFactory.BiddersRepository().GetViewRecordsByAuctionIdAndBiddersId(parameters.auctionId, parameters.bidderId);
                var dtRegisteredBidders = new dsTreasury.dtLtom26_27_28DataTable();

                int totalProgressCount = dbRegisteredBidders.Rows.Count;
                int progressCount = 0;

                foreach (DataRow row in dbRegisteredBidders.Rows)
                {
                    var newRow = dtRegisteredBidders.NewRow();

                    newRow["assigned_bidder_no"] = row["assigned_bidder_no"];
                    newRow["name_of_bidders_representative"] = row["name_of_bidders_representative"];
                    newRow["complete_address_or_business_address"] = row["complete_address_or_business_address"];
                    newRow["contact_no"] = row["contact_no"];
                    newRow["official_receipts_no"] = row["official_receipts_no"];


                    progressCount++;
                }

                Helper.ProgressCounter(backgroundWorker1, totalProgressCount, progressCount);
                e.Result = dtRegisteredBidders;

            }
            catch (Exception ex) { Helper.MessageBoxError(ex.Message); }
        }

        private void backgroundWorker1_ProgressChanged(object sender, System.ComponentModel.ProgressChangedEventArgs e)
        {
            progressBar1.Value = e.ProgressPercentage;
        }

        private void backgroundWorker1_RunWorkerCompleted(object sender, System.ComponentModel.RunWorkerCompletedEventArgs e)
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
                report.ReportPath = $"{Application.StartupPath}Reports\\LTOM\\ltom-27-undertaking-and-waver-of-bidders.rdlc";
                report.DataSources.Clear();

                string lguName = Helper.LGUDetails()["lgu_name"];
                var signatory = Helper.GetSignatoryDataBy_Reference_DocumentName("Treasurer", "LTOM");

                var reportParameters = new ReportParameter[]
                {
                    new ReportParameter("paramLGU", lguName),
                    new ReportParameter("paramSignatoryTitle", signatory["signatories_title"]),
                    new ReportParameter("paramSignatory", signatory["signatories_full_name"]),

                    new ReportParameter("paramNameOfBidder", "Bidder Name"),
                    new ReportParameter("paramCompleteAddressOfBidder", "Complete address"),
                    new ReportParameter("paramPlaceOfPublicAuction", "Place public auction"),

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
