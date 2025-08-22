using ACC.Data;
using ACC.Domain.Models;
using LFS.DataSets;
using LFS.Helpers;
using LFS.Views.Shared;
using Microsoft.Reporting.WinForms;
using System;
using System.ComponentModel;
using System.Data;
using System.Windows.Forms;

namespace LFS.Views.Transactions.Auction
{
    public partial class ucDeclarationOfForfeitureOfDelinquentProperty : UserControl
    {
        private int auctionId;
        private int rptId;

        public ucDeclarationOfForfeitureOfDelinquentProperty()
        {
            InitializeComponent();
            panel1.Controls.Add(reportViewer1);
        }

        internal void OnLoad(int auctionId, int rptId)
        {
            this.auctionId = auctionId;
            this.rptId = rptId;
            LoadReport();
        }

        private void LoadReport()
        {
            if (!backgroundWorker1.IsBusy)
            {
                progressBar1.Value = 0;
                backgroundWorker1.RunWorkerAsync((auctionId, rptId));
            }
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

        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
            try
            {
                var parameters = ((int auctionId, int rptId))e.Argument;
                var rptAuctionModel = new RptAuctionModel() { AuctionId = parameters.auctionId };

                int progressCount = 0;
                var dictRpt = AccFactory.RealPropertiesRepository().GetRecordByID(parameters.rptId);
                string completeArp = dictRpt["complete_arp_no"].ToString();

                var dtDelinquentProperty = AccFactory.RptAssessmentPostsRepository().GetViewDeliquentRecords();
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
                report.ReportPath = $"{Application.StartupPath}Reports\\LTOM\\Ltom30DeclarationOfForfeitureOfDelinquentRpt.rdlc";
                report.DataSources.Clear();

                var dictAuctionProperty = AccFactory.RptAuctionRepository().GetAuctionPropertiesByAuctionIdAndRptId(auctionId, rptId);

                var reportParameters = new ReportParameter[]
                {
                    new("paramLGU", ServerHelper.selectedServer.MunicipalityName),
                    new("paramSignatoryTitle", string.Empty),
                    new("paramSignatory", string.Empty),

                    new("paramPlaceOfAuction", dictAuctionProperty["location"]),
                    new("paramDeclaredOwner", dictAuctionProperty["taxpayer_name"]),
                    new("paramPropertyLocation", dictAuctionProperty["taxpayer_address"]),
                    new("paramTaxDec", dictAuctionProperty["complete_arp_no"]),
                    new("paramTCT", string.Empty),
                    new("paramKindOfProperty", dictAuctionProperty["property_kind"]),
                };

                report.DataSources.Add(new ReportDataSource("dsLtom30", dataTable));
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