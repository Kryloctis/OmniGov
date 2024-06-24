using ACC.Data;
using ACC.Domain.Models;
using AccountingSystem.Views.Transactions.Biddings.BiddingReports;
using Microsoft.Reporting.WinForms;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows.Forms;

namespace AccountingSystem.Views.Reports.Ltom
{
    public partial class frmLtom28 : Form
    {
        private ucRulesAndRegulation ucRulesAndRegulation;
        public frmLtom28()
        {
            InitializeComponent();
            panel1.Controls.Add(reportViewer1);
        }

        private void ToogleRunButton(bool isGenerated)
        {
            btnRunReport.Text = isGenerated ? "Run Report" : "Generating Report...";
            btnRunReport.Enabled = isGenerated;
        }

        private void LoadReport()
        {
            if (!backgroundWorker1.IsBusy)
            {
                progressBar1.Value = 0;
                ToogleRunButton(false);
                int rptAuctionId = Convert.ToInt32(cmbxProperty.SelectedValue);
                int biddersId = Convert.ToInt32(cmbxBidders.SelectedValue);

                backgroundWorker1.RunWorkerAsync((rptAuctionId, biddersId));
            }
        }
        private void OnLoad()
        {
            LoadAuctionSchedule();
        }

        private void LoadProperties()
        {
            int auctionId = Convert.ToInt32(cmbxAuctionSchedule.SelectedValue);
            var rptAuctionModel = new RptAuctionModel() { AuctionId = auctionId };
            var auctionProperties = AccFactory.RptAuctionRepository().GetAuctionProperties(rptAuctionModel);

            cmbxProperty.ValueMember = "rpt_auction_id";
            cmbxProperty.DisplayMember = "complete_arp_no";
            cmbxProperty.DataSource = auctionProperties;
        }

        private void LoadAuctionSchedule()
        {
            DataTable dtAuctionSchedule = AccFactory.AuctionRepository().GetAuctionSchedule();
            HelperLoadRecords.AuctionScheduleCombobox(dtAuctionSchedule, cmbxAuctionSchedule, "date", "id");
        }

        private void LoadBidders()
        {
            int auctionId = Convert.ToInt32(cmbxAuctionSchedule.SelectedValue);
            int rptAuctionId = Convert.ToInt32(cmbxProperty.SelectedValue);

            var dtBidders = AccFactory.BiddersRepository().GetBiddersByAuctionIdAndRptId(auctionId, rptAuctionId);

            HelperLoadRecords.BiddersCombobox(dtBidders, cmbxBidders, "name", "id");
        }

        private void cmbxAuctionSchedule_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadProperties();
        }

        private void btnRunReport_Click(object sender, EventArgs e)
        {
            try
            {
                ToogleRunButton(false);
                int auctionId = Convert.ToInt32(cmbxAuctionSchedule.SelectedValue);
                int biddersId = Convert.ToInt32(cmbxBidders.SelectedValue);

                if (cmbxAuctionSchedule.SelectedIndex == -1 || cmbxBidders.SelectedIndex == -1)
                    return;

                LoadReport();

            }
            catch (Exception ex) { Helper.MessageBoxError(ex.Message); }
        }

        private void frmLtom28_Load(object sender, EventArgs e)
        {
            try
            {
                OnLoad();
            }
            catch (Exception ex) { Helper.MessageBoxError(ex.Message); }
        }

        private void cmbxProperty_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadBidders();
        }


        private void backgroundWorker1_DoWork(object sender, System.ComponentModel.DoWorkEventArgs e)
        {
            var parameters = ((int rptAuctionId, int bidderId))e.Argument;

            var tasks = new Dictionary<string, int>
            {
                { "Initialize Parameters", 50 },
                { "Fetch LGU Details", 50 }
            };

            int totalProgressCount = tasks.Sum(t => t.Value);
            int progressCount = 0;

            // Fetch LGU Details
            var lguDetails = Helper.LGUDetails();
            progressCount += tasks["Fetch LGU Details"];
            Helper.ProgressCounter(backgroundWorker1, totalProgressCount, progressCount);

            List<ReportParameter> reportParameters = new List<ReportParameter>();

            reportParameters.Add(new ReportParameter("paramLGU", "Titay"));
            reportParameters.Add(new ReportParameter("paramLGU", lguDetails["municipality"]));

            progressCount += tasks["Initialize Parameters"];
            Helper.ProgressCounter(backgroundWorker1, totalProgressCount, progressCount);
            e.Result = reportParameters;
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
                {
                    reportViewer1.Clear();
                    progressBar1.Value = 100;
                    return;
                }

                var parameters = (List<ReportParameter>)e.Result;
                reportViewer1.Clear();
                var localReport = reportViewer1.LocalReport;
                localReport.ReportPath = $"{Application.StartupPath}Reports\\Ltom\\Ltom28RulesAndRegulationOfPublicAuction.rdlc";
                localReport.SetParameters(parameters);
                localReport.Refresh();

                reportViewer1.SetDisplayMode(DisplayMode.PrintLayout);
                reportViewer1.ZoomMode = ZoomMode.FullPage;
                reportViewer1.Refresh();

            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
        }
    }
}
