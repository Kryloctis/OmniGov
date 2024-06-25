using ACC.Data;
using ACC.Domain.Models;
using Microsoft.Reporting.WinForms;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows.Forms;

namespace AccountingSystem.Views.Reports.Ltom
{
    public partial class frmLtom25 : Form
    {
        int auctionId;
        int bidderId;
        int rptAuctionId;
        private DataTable dtAuctionRpt;

        public frmLtom25()
        {
            InitializeComponent();
            panel1.Controls.Add(reportViewer1);
        }

        private void ToogleRunButton(bool isGenerated)
        {
            btnRunReport.Text = isGenerated ? "Run Report" : "Generating Report...";
            btnRunReport.Enabled = isGenerated;
        }

        private void frmLtom25_Load(object sender, System.EventArgs e)
        {
            OnLoad();
        }

        private void OnLoad()
        {
            LoadAuctionSchedule();
        }

        private void LoadAuctionSchedule()
        {
            DataTable dtAuctionSchedule = AccFactory.AuctionRepository().GetAuctionSchedule();
            HelperLoadRecords.AuctionScheduleCombobox(dtAuctionSchedule, cmbxAuctionSchedule, "date", "id");
        }

        private void cmbxAuctionSchedule_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadProperties();
        }

        private void LoadProperties()
        {
            int auctionId = Convert.ToInt32(cmbxAuctionSchedule.SelectedValue);
            dtAuctionRpt = AccFactory.RptAuctionRepository().GetAuctionProperties(new RptAuctionModel() { AuctionId = auctionId });

            var autoCompleteSrc = dtAuctionRpt.AsEnumerable().Select(row => row.Field<string>("complete_arp_no")).ToList();
            var autoCom = new AutoCompleteStringCollection();
            autoCom.Clear();
            autoCom.AddRange(autoCompleteSrc.ToArray());
            txtRpt.AutoCompleteCustomSource = autoCom;
        }


        private void btnRunReport_Click(object sender, System.EventArgs e)
        {
            try
            {
                bool inValidFilter = cmbxAuctionSchedule.SelectedIndex == -1 || string.IsNullOrWhiteSpace(txtRpt.Text.Trim()) || cmbxBidders.SelectedIndex == -1;

                if (inValidFilter)
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

                int auctionId = Convert.ToInt32(cmbxAuctionSchedule.SelectedValue);
                int bidderId = Convert.ToInt32(cmbxBidders.SelectedValue);

                auctionId = Convert.ToInt32(cmbxAuctionSchedule.SelectedValue);
                backgroundWorker1.RunWorkerAsync((auctionId, bidderId));
            }
        }


        private void backgroundWorker1_DoWork(object sender, System.ComponentModel.DoWorkEventArgs e)
        {
            var parameters = ((int auctionId, int bidderId))e.Argument;

            var tasks = new Dictionary<string, int>
            {
                { "Fetch Bidder", 30},
                { "Initialize Parameters", 20 },
                { "Set Parameter Values", 40 },
            };

            int totalProgressCount = tasks.Sum(t => t.Value);
            int progressCount = 0;

            var dictBidder = AccFactory.BiddersRepository().GetViewRecordByAuctionIdAndBidderId(parameters.auctionId, parameters.bidderId);
            progressCount += tasks["Fetch Bidder"];
            Helper.ProgressCounter(backgroundWorker1, totalProgressCount, progressCount);

            var lguDetails = Helper.LGUDetails();
            List<ReportParameter> reportParameters = new List<ReportParameter>();
            progressCount += tasks["Initialize Parameters"];
            Helper.ProgressCounter(backgroundWorker1, totalProgressCount, progressCount);

            var isRepresentative = !string.IsNullOrEmpty(dictBidder["representative_registry_id"]);



            reportParameters.Add(new ReportParameter("paramIsRepresentative", isRepresentative.ToString()));
            reportParameters.Add(new ReportParameter("paramLGU", lguDetails["municipality"]));
            reportParameters.Add(new ReportParameter("paramCompleteAddress", dictBidder["address"]));
            reportParameters.Add(new ReportParameter("paramAssignedBidderNo", dictBidder["bidder_no"]));
            reportParameters.Add(new ReportParameter("paramOfficialReceiptNoForIndividualBidder", dictBidder["receipt_no"]));
            reportParameters.Add(new ReportParameter("paramBidderName", dictBidder["name"]));
            reportParameters.Add(new ReportParameter("paramTelephoneNo", dictBidder["contact_info"]));
            reportParameters.Add(new ReportParameter("paramEmail", string.Empty));

            if (isRepresentative)
            {
                var dictRegistry = AccFactory.RegistryRepository().GetRecordByID(Convert.ToInt32(dictBidder["representative_registry_id"]));
                reportParameters.Add(new ReportParameter("paramCitizenship", dictRegistry["nationality"]));
                reportParameters.Add(new ReportParameter("paramSex", dictRegistry["sex"]));
            }



            progressCount += tasks["Set Parameter Values"];
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
                    ToogleRunButton(true);
                    return;
                }

                var parameters = (List<ReportParameter>)e.Result;
                reportViewer1.Clear();
                var localReport = reportViewer1.LocalReport;
                localReport.ReportPath = $"{Application.StartupPath}Reports\\Ltom\\Ltom25PublicAuctionRegFrm.rdlc";
                localReport.SetParameters(parameters);
                localReport.Refresh();

                reportViewer1.SetDisplayMode(DisplayMode.PrintLayout);
                reportViewer1.ZoomMode = ZoomMode.FullPage;
                reportViewer1.Refresh();

                ToogleRunButton(true);
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
        }

        private void txtRpt_TextChanged(object sender, EventArgs e)
        {
            LoadBidder();
        }

        private void LoadBidder()
        {
            rptAuctionId = Convert.ToInt32(dtAuctionRpt.AsEnumerable()
                                   .Where(row => row.Field<string>("complete_arp_no") == txtRpt.Text)
                                   .Select(row => row["rpt_auction_id"])
                                   .FirstOrDefault());

            if (rptAuctionId is not 0)
            {
                int auctionId = Convert.ToInt32(cmbxAuctionSchedule.SelectedValue);
                var dtBidders = AccFactory.BiddersRepository().GetBiddersByAuctionIdAndRptId(auctionId, rptAuctionId);

                cmbxBidders.DisplayMember = "name";
                cmbxBidders.ValueMember = "id";
                cmbxBidders.DataSource = dtBidders;
            }
        }

        private void cmbxBidders_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
