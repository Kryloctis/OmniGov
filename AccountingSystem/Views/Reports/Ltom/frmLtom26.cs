using ACC.Data;
using ACC.Domain.Models;
using AccountingSystem.DataSets;
using Microsoft.Reporting.WinForms;
using System;
using System.Data;
using System.Windows.Forms;

namespace AccountingSystem.Views.Reports.Ltom
{
    public partial class frmLtom26 : Form
    {
        int auctionId;

        public frmLtom26()
        {
            InitializeComponent();
            panel1.Controls.Add(reportViewer1);
        }

        private void ToogleRunButton(bool isGenerated)
        {
            btnRunReport.Text = isGenerated ? "Run Report" : "Generating Report...";
            btnRunReport.Enabled = isGenerated;
        }

        private void btnRunReport_Click(object sender, System.EventArgs e)
        {
            try
            {
                ToogleRunButton(false);
                int auctionId = Convert.ToInt32(cmbxAuctionSchedule.SelectedValue);
                if (cmbxAuctionSchedule.SelectedIndex == -1)
                    return;

                LoadReport();
            }
            catch (Exception ex) { Helper.MessageBoxError(ex.Message); }
        }

        private void LoadReport()
        {
            if (!backgroundWorker1.IsBusy)
            {
                progressBar1.Value = 0;
                ToogleRunButton(false);
                auctionId = Convert.ToInt32(cmbxAuctionSchedule.SelectedValue);
                backgroundWorker1.RunWorkerAsync(auctionId);
            }
        }

        private void OnLoad()
        {
            cmbxAuctionSchedule.ResetText();
            cmbxAuctionSchedule.SelectedIndex = -1;

            LoadAuctionSchedule();
        }

        private void LoadAuctionSchedule()
        {
            DataTable dtAuctionSchedule = AccFactory.AuctionRepository().GetAuctionSchedule();
            HelperLoadRecords.AuctionScheduleCombobox(dtAuctionSchedule, cmbxAuctionSchedule, "date", "id");
        }


        private void frmLtom26_Load(object sender, EventArgs e)
        {
            try
            {
                OnLoad();
            }
            catch (Exception ex) { Helper.MessageBoxError(ex.Message); }
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

                string lguName = Helper.LGUDetails()["lgu_name"]; ;

                var reportParameters = new ReportParameter[]
                {
                    new ReportParameter("paramLGU", lguName),
                    new ReportParameter("paramSignatoryTitle", string.Empty),
                    new ReportParameter("paramSignatory", string.Empty),
                };

                reportViewer1.Clear();
                var report = reportViewer1.LocalReport;
                report.ReportPath = $"{Application.StartupPath}Reports\\LTOM\\Ltom26ListOfRegisteredBidders.rdlc";
                report.DataSources.Clear();
                report.DataSources.Add(new ReportDataSource("dtLtom26_27_28", dataTable));
                report.SetParameters(reportParameters);
                report.Refresh();

                reportViewer1.SetDisplayMode(DisplayMode.PrintLayout);
                reportViewer1.ZoomMode = ZoomMode.FullPage;
                reportViewer1.Refresh();
                ToogleRunButton(true);

            }

            catch (Exception ex) { Helper.MessageBoxError(ex.Message); }
        }

        private void backgroundWorker1_ProgressChanged(object sender, System.ComponentModel.ProgressChangedEventArgs e)
        {
            progressBar1.Value = e.ProgressPercentage;
        }

        private void backgroundWorker1_DoWork(object sender, System.ComponentModel.DoWorkEventArgs e)
        {
            try
            {
                int auctionId = (int)e.Argument;

                var auctionModel = new AuctionModel() { Id = auctionId };
                var rptAuctionModel = new RptAuctionModel() { AuctionId = auctionId };

                var dbRegisteredBidders = AccFactory.BiddersRepository().GetViewRecords();
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
    }
}
