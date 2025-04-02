using ACC.Data;
using ACC.Domain.Models;
using LFS.DataSets;
using LFS.Views.Shared;
using Microsoft.Reporting.WinForms;
using System;
using System.Data;
using System.Windows.Forms;

namespace LFS.Views.Transactions.Auction
{
    public partial class ucNoticeOfSale : UserControl
    {
        private int auctionId;
        private int propertyId;

        public ucNoticeOfSale()
        {
            InitializeComponent();
            panel1.Controls.Add(reportViewer1);
        }

        internal void OnLoad(int auctionId, int propertyId)
        {
            this.auctionId = auctionId;
            this.propertyId = propertyId;
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

        private void backgroundWorker1_DoWork(object sender, System.ComponentModel.DoWorkEventArgs e)
        {
            try
            {
                int auctionId = (int)e.Argument;

                var auctionModel = new AuctionModel() { Id = auctionId };
                var rptAuctionModel = new RptAuctionModel() { AuctionId = auctionId };

                var dbRptAuctionProperties = AccFactory.RptAuctionRepository().GetAuctionProperties(rptAuctionModel);
                var dtRptAuctionProperties = new dsTreasury.dtLtom24DataTable();

                int totalProgressCount = dbRptAuctionProperties.Rows.Count;
                int progressCount = 0;

                foreach (DataRow dataRow in dbRptAuctionProperties.Rows)
                {
                    var newRow = dtRptAuctionProperties.NewRow();

                    string completeArpNo = dataRow["complete_arp_no"].ToString();
                    decimal assessedValue = Convert.ToDecimal(dataRow["assessed_value"]);
                    int monthsDelinquent = 0;
                    decimal basicTaxDue = 0;
                    decimal sefTaxDue = 0;
                    decimal penaltyRate = 0;
                    decimal totalTaxDue = 0;
                    decimal total = 0;

                    #region Computation

                    //var dtDelinquentRpt = AccFactory.RptAssessmentPostsRepository().Get_View_List_Of_Real_Property_Tax_Delinquences_By_ID(propertyId);
                    var dtDelinquentRpt = AccFactory.RptAssessmentPostsRepository().GetViewDeliquentRecords();

                    foreach (DataRow dataRowDeliquency in dtDelinquentRpt.Rows)
                    {
                        int assessmentYear = Convert.ToInt32(dataRowDeliquency["year"]);
                        int effectivityQuarter = Convert.ToInt32(dataRowDeliquency["effectivity_quarterly"]);
                        int effectivityYear = Convert.ToInt32(dataRowDeliquency["effectivity_year"]);
                        var dictPrevAssmnt = AccFactory.RptAssessmentPostsRepository().GetViewRecentAssessmentRecord(completeArpNo, assessmentYear);

                        int? prevAssmntYear = null;

                        if (dictPrevAssmnt.Count > 1)
                            prevAssmntYear = Convert.ToInt32(dictPrevAssmnt["year"]);

                        monthsDelinquent = RealPropertyTaxComputations.GetMonthsDelinquent(Helper.GetCurrentDate(), (assessmentYear, effectivityQuarter, effectivityYear), prevAssmntYear.HasValue ? prevAssmntYear : null);

                        decimal rowBasicRate = Convert.ToDecimal(dataRowDeliquency["basic_rate"]);
                        decimal rowSefRate = Convert.ToDecimal(dataRowDeliquency["sef_rate"]);

                        basicTaxDue = RealPropertyTaxComputations.GetBasicTaxDue(rowBasicRate, assessedValue);
                        sefTaxDue = RealPropertyTaxComputations.GetSefTaxDue(rowSefRate, assessedValue);
                        penaltyRate = Convert.ToDecimal(dataRowDeliquency["penalty_rate"]);

                        var penaltyParameters = (assessmentYear, completeArpNo, effectivityQuarter, effectivityYear);
                        var penalties = GetPenalties(Helper.GetCurrentDate(), penaltyParameters, penaltyRate, basicTaxDue, sefTaxDue);

                        totalTaxDue = basicTaxDue + sefTaxDue;
                        total = totalTaxDue + (penalties.basicPenalty + penalties.sefPenalty);

                        newRow["tax_year"] = assessmentYear;
                        newRow["basic_tax"] = basicTaxDue;
                        newRow["basic_penalty"] = penalties.basicPenalty;
                        newRow["sef_tax"] = sefTaxDue;
                        newRow["sef_penalty"] = penalties.sefPenalty;
                        newRow["total_amount"] = total;
                    }

                    #endregion Computation

                    dtRptAuctionProperties.Rows.Add(newRow);
                    progressCount++;
                    Helper.ProgressCounter(backgroundWorker1, totalProgressCount, progressCount);
                }

                e.Result = dtRptAuctionProperties;
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
                report.ReportPath = $"{Application.StartupPath}Reports\\LTOM\\Ltom24NoticeSale.rdlc";
                report.DataSources.Clear();

                var dtAuction = AccFactory.AuctionRepository().GetRecordById(auctionId);

                string lguName = Helper.LGUDetails()["lgu_name"];
                string location = dtAuction["location"];
                string date = $"{Convert.ToDateTime(dtAuction["start_date"]):MMMM dd, yyyy} - {Convert.ToDateTime(dtAuction["end_date"]):MMMM dd, yyyy}";

                var dictAuctionProperty = AccFactory.RptAuctionRepository().GetAuctionPropertiesByAuctionIdAndRptId(auctionId, propertyId);

                var reportParameters = new ReportParameter[]
                {
                    new ReportParameter("paramLGU", lguName),
                    new ReportParameter("paramDateOfAuction", date),
                    new ReportParameter("paramPlaceOfAuction", location),
                    new ReportParameter("paramDeclaredOwner", dictAuctionProperty["taxpayer_name"]),
                    new ReportParameter("paramCompleteAddress", dictAuctionProperty["taxpayer_address"]),
                    new ReportParameter("paramSignatoryTitle", string.Empty),
                    new ReportParameter("paramSignatory", string.Empty),
                };

                report.DataSources.Add(new ReportDataSource("dtLtom24", dataTable));
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