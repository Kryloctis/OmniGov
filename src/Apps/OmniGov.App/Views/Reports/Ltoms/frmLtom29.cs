using Microsoft.Reporting.WinForms;
using OmniGov.App.DataSets;
using OmniGov.App.Helpers;
using OmniGov.App.Views.Shared;
using OmniGov.Treasury.Data.Factories;
using OmniGov.Treasury.Domain.Entities;
using System.ComponentModel;
using System.Data;

namespace OmniGov.App.Views.Reports.Ltoms
{
    public partial class frmLtom29 : Form
    {
        private int auctionId;
        private int rptId;

        private int rptAuctionId;
        private DataTable dtAuctionRpt;

        public frmLtom29()
        {
            InitializeComponent();
            Helper.LoadFormIcon(this);
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
                if (cmbxAuctionSchedule.SelectedIndex == -1 || string.IsNullOrWhiteSpace(txtRpt.Text.Trim()))
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
                backgroundWorker1.RunWorkerAsync((auctionId, rptId));
            }
        }

        private (decimal basicPenalty, decimal sefPenalty) GetPenalties(DateTime transactionDate,
                                                        (int assessmentYear, string compelteArpNo, int effectivityQuarter, int effectivityYear) currentAssmntParameters,
                                                        decimal penaltyRate,
                                                        decimal basicTaxDue,
                                                        decimal sefTaxDue)
        {
            var dictPrevAssmnt = TreasuryFactory.RptAssessmentPostsRepository().GetViewRecentAssessmentRecord(currentAssmntParameters.compelteArpNo, currentAssmntParameters.assessmentYear);

            int? prevAssmntYear = null;

            if (dictPrevAssmnt.Count > 1)
                prevAssmntYear = Convert.ToInt32(dictPrevAssmnt["year"]);

            int monthsDelinquent = RealPropertyTaxComputations.GetMonthsDelinquent(transactionDate, (currentAssmntParameters.assessmentYear, currentAssmntParameters.effectivityQuarter, currentAssmntParameters.effectivityYear), prevAssmntYear.HasValue ? prevAssmntYear : null);
            decimal basicPenalty = RealPropertyTaxComputations.GetPenalty(penaltyRate, monthsDelinquent, basicTaxDue);
            decimal sefPenalty = RealPropertyTaxComputations.GetPenalty(penaltyRate, monthsDelinquent, sefTaxDue);

            return (basicPenalty, sefPenalty);
        }

        private void cmbxAuctionSchedule_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadProperties();
        }

        private void frmLtom29_Load(object sender, EventArgs e)
        {
            try
            {
                OnLoad();
            }
            catch (Exception ex) { Helper.MessageBoxError(ex.Message); }
        }

        private void LoadAuctionSchedule()
        {
            DataTable dtAuctionSchedule = TreasuryFactory.AuctionRepository().GetAuctionSchedule();
            HelperLoadRecords.AuctionScheduleCombobox(dtAuctionSchedule, cmbxAuctionSchedule, "date", "id");
        }

        private void LoadProperties()
        {
            int auctionId = Convert.ToInt32(cmbxAuctionSchedule.SelectedValue);
            dtAuctionRpt = TreasuryFactory.RptAuctionRepository().GetAuctionProperties(new RptAuctionModel() { AuctionId = auctionId });

            var autoCompleteSrc = dtAuctionRpt.AsEnumerable().Select(row => row.Field<string>("complete_arp_no")).ToList();
            var autoCom = new AutoCompleteStringCollection();
            autoCom.Clear();
            autoCom.AddRange(autoCompleteSrc.ToArray());
            txtRpt.AutoCompleteCustomSource = autoCom;
        }

        private void OnLoad()
        {
            cmbxAuctionSchedule.ResetText();
            cmbxAuctionSchedule.SelectedIndex = -1;

            LoadAuctionSchedule();
            LoadProperties();
        }

        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
            try
            {
                var parameters = ((int auctionId, int rptId))e.Argument;
                var rptAuctionModel = new RptAuctionModel() { AuctionId = parameters.auctionId };

                int progressCount = 0;
                var dictRpt = TreasuryFactory.RealPropertiesRepository().GetRecordByID(parameters.rptId);
                string completeArp = dictRpt["complete_arp_no"].ToString();

                var dtDelinquentProperty = TreasuryFactory.RptAssessmentPostsRepository().GetViewDeliquentRecords();
                var dtRptAuctionProperties = new dsTreasury.dtLtom29DataTable();
                int totalProgressCount = dtDelinquentProperty.Rows.Count;

                foreach (DataRow drDelinquentProperty in dtDelinquentProperty.Rows)
                {
                    string completeArpNo = drDelinquentProperty["complete_arp_no"].ToString();

                    var newRow = dtRptAuctionProperties.NewRow();

                    decimal assessedValue = Convert.ToDecimal(drDelinquentProperty["assessed_value"]);
                    decimal basicRate = Convert.ToDecimal(drDelinquentProperty["basic_rate"]);
                    decimal sefRate = Convert.ToDecimal(drDelinquentProperty["sef_rate"]);
                    int assessmentYear = Convert.ToInt32(drDelinquentProperty["year"]);
                    int effectivityQuarter = Convert.ToInt32(drDelinquentProperty["effectivity_quarterly"]);
                    int effectivityYear = Convert.ToInt32(drDelinquentProperty["effectivity_year"]);
                    decimal basicTaxDue = RealPropertyTaxComputations.GetBasicTaxDue(basicRate, assessedValue);
                    decimal sefTaxDue = RealPropertyTaxComputations.GetSefTaxDue(sefRate, assessedValue);
                    decimal penaltyRate = Convert.ToDecimal(drDelinquentProperty["penalty_rate"]);

                    var penaltyParameters = (assessmentYear, completeArpNo, effectivityQuarter, effectivityYear);
                    var penalties = GetPenalties(DateTime.Now, penaltyParameters, penaltyRate, basicTaxDue, sefTaxDue);
                    var total = (penalties.basicPenalty + penalties.sefPenalty).ToString("N2");

                    newRow["tax_year"] = assessmentYear;
                    newRow["assessed_value"] = assessedValue;
                    newRow["basic_tax"] = basicTaxDue;
                    newRow["basic_penalty"] = penalties.basicPenalty;
                    newRow["sef_tax"] = sefTaxDue;
                    newRow["sef_penalty"] = penalties.sefPenalty;
                    newRow["expenses_of_sale"] = 0.0;
                    newRow["total_amount"] = total;

                    progressCount++;
                    Helper.ProgressCounter(backgroundWorker1, totalProgressCount, progressCount);

                    if (completeArp == completeArpNo)
                        dtRptAuctionProperties.Rows.Add(newRow);
                    else
                        continue;
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

                var report = reportViewer1.LocalReport;
                report.ReportPath = $"{Application.StartupPath}Reports\\Ltoms\\Ltom29CertificateOfSale.rdlc";
                report.DataSources.Clear();

                var dictAuctionProperty = TreasuryFactory.RptAuctionRepository().GetAuctionPropertiesByAuctionIdAndRptId(auctionId, rptId);
                string date = $"{Convert.ToDateTime(dictAuctionProperty["start_date"]):MMMM dd, yyyy} - {Convert.ToDateTime(dictAuctionProperty["end_date"]):MMMM dd, yyyy}";

                var dictBid = TreasuryFactory.BidRepository().GetHighestBidderByAuctionIdAndRptId(auctionId, rptId);

                if (dictBid.Count == 0)
                    return;

                var reportParameters = new ReportParameter[]
                {
                    new("paramLGU", (ServerHelper.SelectedProfile?.Name ?? "")),
                    new("paramSignatoryTitle", string.Empty),
                    new("paramSignatory", string.Empty),
                    new("paramDeclaredOwner", dictAuctionProperty["taxpayer_name"]),
                    new("paramTaxDec", dictAuctionProperty["complete_arp_no"]),
                    new("paramARPNo", dictAuctionProperty["complete_arp_no"]),
                    new("paramTCT", string.Empty),
                    new("paramPIN", string.Empty),
                    new("paramPropertyLocation", dictAuctionProperty["location"]),
                    new("paramKindOfProperty", dictAuctionProperty["property_kind"]),

                    new("paramDateOfPublicAuction", date),
                    new("paramBuyer",  dictBid["name"]),
                    new("paramBuyerAddress",  dictBid["address"]),
                    new("paramSoldPrice",  dictBid["bid_amount"]),
                    new("paramOfficialReceiptNo",  dictBid["receipt_no"]),
                    new("paramSoldDate",  dictBid["date"]),
                };

                report.DataSources.Add(new ReportDataSource("dtLtom29", dataTable));
                report.SetParameters(reportParameters);

                reportViewer1.SetDisplayMode(DisplayMode.PrintLayout);
                reportViewer1.ZoomMode = ZoomMode.FullPage;
                reportViewer1.RefreshReport();

                ToogleRunButton(true);
            }
            catch (Exception ex) { Helper.MessageBoxError(ex.Message); }
        }

        private void txtRpt_TextChanged(object sender, EventArgs e)
        {
            try
            {
                rptId = Convert.ToInt32(dtAuctionRpt.AsEnumerable()
                                         .Where(row => row.Field<string>("complete_arp_no") == txtRpt.Text)
                                         .Select(row => row["real_properties_id"])
                                         .FirstOrDefault());
            }
            catch (Exception ex) { Helper.MessageBoxError(ex.Message); }
        }
    }
}

