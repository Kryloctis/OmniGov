using Microsoft.Reporting.WinForms;
using OmniGov.App.Helpers;
using System.ComponentModel;
using System.Data;
using Treasury.Data.Factories;
using Treasury.Domain.Entities;

namespace OmniGov.App.Views.Reports.Ltoms
{
    public partial class frmLtom32 : Form
    {
        public frmLtom32()
        {
            InitializeComponent();
            panel1.Controls.Add(reportViewer1);
        }

        private void ToogleRunButton(bool isGenerated)
        {
            btnRunReport.Text = isGenerated ? "Run Report" : "Generating Report...";
            btnRunReport.Enabled = isGenerated;
        }

        private void frmLtom32_Load(object sender, EventArgs e)
        {
            try
            {
                OnLoad();
            }
            catch (Exception ex) { Helper.MessageBoxError(ex.Message); }
        }

        private void OnLoad()
        {
            cmbxProperty.ResetText();
            cmbxProperty.SelectedIndex = -1;

            cmbxAuctionSchedule.ResetText();
            cmbxAuctionSchedule.SelectedIndex = -1;

            LoadAuctionSchedule();
            LoadProperties();
        }

        private void LoadAuctionSchedule()
        {
            DataTable dtAuctionSchedule = TreasuryFactory.AuctionRepository().GetAuctionSchedule();
            HelperLoadRecords.AuctionScheduleCombobox(dtAuctionSchedule, cmbxAuctionSchedule, "date", "id");
        }

        private void LoadProperties()
        {
            int auctionId = Convert.ToInt32(cmbxAuctionSchedule.SelectedValue);
            var rptAuctionModel = new RptAuctionModel() { AuctionId = auctionId };
            var auctionProperties = TreasuryFactory.RptAuctionRepository().GetAuctionProperties(rptAuctionModel);

            cmbxProperty.ValueMember = "real_properties_id";
            cmbxProperty.DisplayMember = "complete_arp_no";
            cmbxProperty.DataSource = auctionProperties;
        }

        private void ucCertificateOfRedemption1_Load(object sender, EventArgs e)
        {
            OnLoad();
        }

        private void btnRunReport_Click(object sender, EventArgs e)
        {
            try
            {
                if (cmbxAuctionSchedule.SelectedIndex == -1 || cmbxProperty.SelectedIndex == -1)
                    return;

                LoadReport();
            }
            catch (Exception ex) { Helper.MessageBoxError(ex.Message); }
        }

        private void LoadReport()
        {
            if (!backgroundWorker1.IsBusy)
            {
                int auctionId = Convert.ToInt32(cmbxAuctionSchedule.SelectedValue);
                int rptId = Convert.ToInt32(cmbxProperty.SelectedValue);

                progressBar1.Value = 0;
                ToogleRunButton(false);

                backgroundWorker1.RunWorkerAsync((auctionId, rptId));
            }
        }

        private void cmbxAuctionSchedule_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadProperties();
        }

        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
            try
            {
                var parameters = ((int rptAuctionId, int rptId))e.Argument;

                // Define tasks and their progress weights
                var tasks = new Dictionary<string, int>
                {
                    { "Fetch LGU Details", 10 },
                    { "Generate Bidder and Bidding Information", 20 },
                    { "Initialize Parameters", 30 },
                    { "Set Parameter Values", 40 }
                };

                int totalProgressCount = tasks.Sum(t => t.Value);
                int progressCount = 0;

                progressCount += tasks["Fetch LGU Details"];
                Helper.ProgressCounter(backgroundWorker1, totalProgressCount, progressCount);

                var dictBiddingResult = TreasuryFactory.BidRepository().GetHighestBidderByAuctionIdAndRptId(parameters.rptAuctionId, parameters.rptId);
                string nameOfBidder = dictBiddingResult["name"];
                decimal bidAmount = Convert.ToDecimal(dictBiddingResult["bid_amount"].ToString());
                var dateOfAuction = $"{Convert.ToDateTime(dictBiddingResult["start_date"]).ToString("MMMM dd yyyy")} - {Convert.ToDateTime(dictBiddingResult["end_date"]).ToString("MMMM dd yyyy")}";
                string receiptNumber = dictBiddingResult["receipt_no"];

                var dictRpt = TreasuryFactory.RealPropertiesRepository().GetViewRecordById(parameters.rptId);

                string declaredOwner = dictRpt["taxpayer_name"];
                string completeArp = dictRpt["complete_arp_no"];
                string tctNumber = string.Empty; ;
                var propertyLocation = Helper.GenerateFullAddress(string.Empty, dictRpt["barangay_name"], dictRpt["municipality_name"], dictRpt["province_name"]);
                string kindOfProperty = dictRpt["property_kind"];
                decimal assessedValue = Convert.ToDecimal(dictRpt["assessed_value"]);

                progressCount += tasks["Generate Bidder and Bidding Information"];
                Helper.ProgressCounter(backgroundWorker1, totalProgressCount, progressCount);

                List<ReportParameter> reportParameters = new List<ReportParameter>();
                progressCount += tasks["Initialize Parameters"];
                Helper.ProgressCounter(backgroundWorker1, totalProgressCount, progressCount);

                reportParameters.Add(new ReportParameter("paramLGU", (ServerHelper.SelectedProfile?.Name ?? "")));
                reportParameters.Add(new ReportParameter("paramNameOfHighestBidder", nameOfBidder));
                reportParameters.Add(new ReportParameter("paramDateOfAuction", dateOfAuction));
                reportParameters.Add(new ReportParameter("paramOfficialReceiptNumber", receiptNumber));
                reportParameters.Add(new ReportParameter("paramDeclaredOwner", declaredOwner));
                reportParameters.Add(new ReportParameter("paramBidAmount", bidAmount.ToString("N2")));
                reportParameters.Add(new ReportParameter("paramTaxDeclarationNo", completeArp));
                reportParameters.Add(new ReportParameter("paramTCTNo", tctNumber));
                reportParameters.Add(new ReportParameter("paramLocationOfProperty", propertyLocation));
                reportParameters.Add(new ReportParameter("paramKindOfProperty", kindOfProperty));
                reportParameters.Add(new ReportParameter("paramAssessedValue", assessedValue.ToString("N2")));
                reportParameters.Add(new ReportParameter("paramSignatoryTitle", string.Empty));
                reportParameters.Add(new ReportParameter("paramSignatory", string.Empty));

                progressCount += tasks["Set Parameter Values"];
                Helper.ProgressCounter(backgroundWorker1, totalProgressCount, progressCount);

                e.Result = reportParameters;
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
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
                {
                    reportViewer1.Clear();
                    progressBar1.Value = 100;
                    return;
                }

                var parameters = (List<ReportParameter>)e.Result;
                reportViewer1.Clear();
                var localReport = reportViewer1.LocalReport;
                localReport.ReportPath = $"{Application.StartupPath}Reports\\Ltoms\\Ltom32CertificateOfRedemption.rdlc";
                localReport.SetParameters(parameters);
                localReport.Refresh();

                reportViewer1.SetDisplayMode(DisplayMode.PrintLayout);
                reportViewer1.ZoomMode = ZoomMode.FullPage;
                reportViewer1.Refresh();
                ToogleRunButton(true);
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
        }
    }
}

