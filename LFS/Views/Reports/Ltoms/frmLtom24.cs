using ACC.Data;
using ACC.Domain.Models;
using LFS.DataSets;
using LFS.Views.Shared;
using Microsoft.Reporting.WinForms;
using System;
using System.ComponentModel;
using System.Data;
using System.Windows.Forms;

namespace LFS.Views.Reports.Ltoms
{
    public partial class frmLtom24 : Form
    {
        private int auctionId;
        private int rptId;

        public frmLtom24()
        {
            InitializeComponent();
            panel1.Controls.Add(reportViewer1);
        }

        private void ToogleRunButton(bool isGenerated)
        {
            btnRunReport.Text = isGenerated ? "Run Report" : "Generating Report...";
            btnRunReport.Enabled = isGenerated;
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

        private void LoadAuctionSchedule()
        {
            DataTable dtAuctionSchedule = AccFactory.AuctionRepository().GetAuctionSchedule();
            HelperLoadRecords.AuctionScheduleCombobox(dtAuctionSchedule, cmbxAuctionSchedule, "date", "id");
        }

        private void LoadProperties()
        {
            int auctionId = Convert.ToInt32(cmbxAuctionSchedule.SelectedValue);
            var rptAuctionModel = new RptAuctionModel() { AuctionId = auctionId };
            var auctionProperties = AccFactory.RptAuctionRepository().GetAuctionProperties(rptAuctionModel);

            cmbxProperty.DataSource = auctionProperties;
            cmbxProperty.ValueMember = "real_properties_id";
            cmbxProperty.DisplayMember = "complete_arp_no";
        }

        private void cmbxAuctionSchedule_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadProperties();
        }

        private void OnLoad()
        {
            cmbxAuctionSchedule.ResetText();
            cmbxProperty.ResetText();
            cmbxAuctionSchedule.SelectedIndex = -1;
            cmbxProperty.SelectedIndex = -1;

            LoadAuctionSchedule();
            LoadProperties();
        }

        private void frmLtom24_Load(object sender, EventArgs e)
        {
            try
            {
                OnLoad();
            }
            catch (Exception ex) { Helper.MessageBoxError(ex.Message); }
        }

        private (decimal basicPenalty, decimal sefPenalty) GetPenalties(DateTime transactionDate,
                                                     (int assessmentYear, string compelteArpNo, int effectivityQuarter, int effectivityYear) currentAssmntParameters,
                                                     decimal penaltyRate,
                                                     decimal basicTaxDue,
                                                     decimal sefTaxDue)
        {
            var dictPrevAssmnt = AccFactory.RptAssessmentPostsRepository().GetViewRecentAssessmentRecord(currentAssmntParameters.compelteArpNo, currentAssmntParameters.assessmentYear);

            int? prevAssmntYear = null;

            if (dictPrevAssmnt.Count > 1)
                prevAssmntYear = Convert.ToInt32(dictPrevAssmnt["year"]);

            int monthsDelinquent = RealPropertyTaxComputations.GetMonthsDelinquent(transactionDate, (currentAssmntParameters.assessmentYear, currentAssmntParameters.effectivityQuarter, currentAssmntParameters.effectivityYear), prevAssmntYear.HasValue ? prevAssmntYear : null);
            decimal basicPenalty = RealPropertyTaxComputations.GetPenalty(penaltyRate, monthsDelinquent, basicTaxDue);
            decimal sefPenalty = RealPropertyTaxComputations.GetPenalty(penaltyRate, monthsDelinquent, sefTaxDue);

            return (basicPenalty, sefPenalty);
        }

        private void LoadReport()
        {
            if (!backgroundWorker1.IsBusy)
            {
                progressBar1.Value = 0;
                ToogleRunButton(false);
                auctionId = Convert.ToInt32(cmbxAuctionSchedule.SelectedValue);
                rptId = Convert.ToInt32(cmbxProperty.SelectedValue);
                backgroundWorker1.RunWorkerAsync((auctionId, rptId));
            }
        }

        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
            try
            {
                var parameters = ((int auctionId, int rptId))e.Argument;

                var dictAuctionProperties = AccFactory.RptAuctionRepository().GetAuctionPropertiesByAuctionIdAndRptId(parameters.auctionId, parameters.rptId);
                string completeArpNo = dictAuctionProperties["complete_arp_no"].ToString();
                int taxPayersId = Convert.ToInt32(dictAuctionProperties["taxpayers_id"]);

                var dtAssessmentPosting = AccFactory.RptAssessmentPostsRepository().GetViewRecordsByTaxpayerIdArpNoShowPaid(taxPayersId, Helper.GetCurrentDate().Year, completeArpNo, true);
                var dtRptAuctionProperties = new dsTreasury.dtLtom24DataTable();
                int totalProgressCount = dtAssessmentPosting.Rows.Count;
                int progressCount = 0;

                foreach (DataRow row in dtAssessmentPosting.Rows)
                {
                    decimal assessedValue = Convert.ToDecimal(row["assessed_value"]);
                    decimal sefRate = Convert.ToDecimal(row["sef_rate"]);
                    decimal basicRate = Convert.ToDecimal(row["basic_rate"]);
                    decimal penaltyRate = Convert.ToDecimal(row["penalty_rate"]);
                    DateTime postedAt = Convert.ToDateTime(row["posted_at"]);
                    int assessmentYear = Convert.ToInt32(row["year"]);
                    int effectivityQuarter = Convert.ToInt32(row["effectivity_quarterly"]);
                    int effectivityYear = Convert.ToInt32(row["effectivity_year"]);
                    string rptPaymentId = row["rpt_payments_id"].ToString();

                    decimal sefTaxDue = RealPropertyTaxComputations.GetSefTaxDue(sefRate, assessedValue);
                    decimal basicTaxDue = RealPropertyTaxComputations.GetBasicTaxDue(basicRate, assessedValue);

                    var penaltyParameters = (assessmentYear, completeArpNo, effectivityQuarter, effectivityYear);
                    var penalties = GetPenalties(Helper.GetCurrentDate(), penaltyParameters, penaltyRate, basicTaxDue, sefTaxDue);

                    //Get discount rate
                    var discountParameters = (postedAt, assessmentYear);
                    decimal discountRate = RealPropertyTaxComputations.GetDiscountRate(Helper.GetCurrentDate(), discountParameters);

                    //Apply Discounts
                    decimal basicDiscount = RealPropertyTaxComputations.GetDiscount(discountRate, basicTaxDue);
                    decimal sefDiscount = RealPropertyTaxComputations.GetDiscount(discountRate, sefTaxDue);

                    decimal basicPenaltyDiscount = penalties.basicPenalty > 0 ? penalties.basicPenalty : -basicDiscount;
                    decimal sefPenaltyDiscount = penalties.sefPenalty > 1 ? penalties.sefPenalty : -sefDiscount;

                    decimal totalBasicPayment = basicTaxDue + basicPenaltyDiscount;
                    decimal totalSefPayment = sefTaxDue + sefPenaltyDiscount;
                    decimal totalTaxDue = totalBasicPayment + totalSefPayment;

                    var newRow = dtRptAuctionProperties.NewRow();

                    newRow["tax_year"] = assessmentYear;
                    newRow["basic_tax"] = basicTaxDue;
                    newRow["basic_penalty"] = penalties.basicPenalty;
                    newRow["sef_tax"] = sefTaxDue;
                    newRow["sef_penalty"] = penalties.sefPenalty;
                    newRow["total_amount"] = totalTaxDue;

                    dtRptAuctionProperties.Rows.Add(newRow);
                    progressCount++;
                    Helper.ProgressCounter(backgroundWorker1, totalProgressCount, progressCount);
                }

                e.Result = dtRptAuctionProperties;
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

                var dtAuction = AccFactory.AuctionRepository().GetRecordById(auctionId);

                string lguName = Helper.LGUDetails()["municipality"];
                string location = dtAuction["location"];
                string date = $"{Convert.ToDateTime(dtAuction["start_date"]):MMMM dd, yyyy} - {Convert.ToDateTime(dtAuction["end_date"]):MMMM dd, yyyy}";

                var dictAuctionProperty = AccFactory.RptAuctionRepository().GetAuctionPropertiesByAuctionIdAndRptId(auctionId, rptId);

                var dictRpt = AccFactory.RealPropertiesRepository().GetViewRecordById(rptId);
                var propertyLocation = Helper.GenerateFullAddress(string.Empty, dictRpt["barangay_name"], dictRpt["municipality_name"], dictRpt["province_name"]);
                var assessedValue = Convert.ToDecimal(dictRpt["assessed_value"]);

                var reportParameters = new ReportParameter[]
                {
                    new ReportParameter("paramLGU", lguName),
                    new ReportParameter("paramDateOfAuction", date),
                    new ReportParameter("paramPlaceOfAuction", location),
                    new ReportParameter("paramDeclaredOwner", dictAuctionProperty["taxpayer_name"]),
                    new ReportParameter("paramCompleteAddress", dictAuctionProperty["taxpayer_address"]),

                    new ReportParameter("paramTaxDeclaractionNo", dictAuctionProperty["complete_arp_no"]),
                    new ReportParameter("paramTCT", string.Empty),
                    new ReportParameter("paramLocationOfProperty", propertyLocation),
                    new ReportParameter("paramPropertyKind", dictAuctionProperty["property_kind"]),
                    new ReportParameter("paramAssessedValue", assessedValue.ToString("N2")),

                    new ReportParameter("paramSignatoryTitle", string.Empty),
                    new ReportParameter("paramSignatory", string.Empty),
                };

                reportViewer1.Clear();
                var report = reportViewer1.LocalReport;
                report.ReportPath = $"{Application.StartupPath}Reports\\Ltoms\\Ltom24NoticeSale.rdlc";
                report.DataSources.Clear();
                report.DataSources.Add(new ReportDataSource("dtLtom24", dataTable));
                report.SetParameters(reportParameters);
                report.Refresh();

                reportViewer1.SetDisplayMode(DisplayMode.PrintLayout);
                reportViewer1.ZoomMode = ZoomMode.FullPage;
                reportViewer1.Refresh();

                ToogleRunButton(true);
            }
            catch (Exception ex) { Helper.MessageBoxError(ex.Message); }
        }
    }
}