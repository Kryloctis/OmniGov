using ACC.Data;
using ACC.Domain.Models;
using AccountingSystem.DataSets;
using AccountingSystem.Views.Shared;
using Microsoft.Reporting.WinForms;
using System;
using System.Data;
using System.Windows.Forms;

namespace AccountingSystem.Views.Transactions.Auction
{
    public partial class ucNoticeOfAuctionSaleOfDelinquentRealProperties : UserControl
    {
        private int auctionId;
        private string auctionLocation;

        public ucNoticeOfAuctionSaleOfDelinquentRealProperties()
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
                var dtRptAuctionProperties = new dsTreasury.dtLtom23DataTable();

                int totalProgressCount = dbRptAuctionProperties.Rows.Count;
                int progressCount = 0;

                foreach (DataRow dataRow in dbRptAuctionProperties.Rows)
                {
                    var newRow = dtRptAuctionProperties.NewRow();

                    int taxpayerID = Convert.ToInt32(dataRow["taxpayers_id"]);
                    string taxPayer = dataRow["taxpayer_name"].ToString();
                    string completeArpNo = dataRow["complete_arp_no"].ToString();
                    string locationOfProperty = dataRow["location"].ToString();
                    string propertyKind = dataRow["property_kind"].ToString();
                    decimal assessedValue = Convert.ToDecimal(dataRow["assessed_value"]);

                    int monthsDelinquent = 0;
                    decimal basicTaxDue = 0;
                    decimal sefTaxDue = 0;
                    decimal penaltyRate = 0;
                    decimal totalTaxDue = 0;
                    decimal total = 0;

                    #region Computation
                    var dtDelinquentRpt = AccFactory.RptAssessmentPostsRepository().Get_View_List_Of_Real_Property_Tax_Delinquences_By_TaxpayerID(taxpayerID);

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
                    }
                    #endregion

                    newRow["declared_owner"] = taxPayer;
                    newRow["tax_declaration_number"] = completeArpNo;
                    newRow["location_of_property"] = locationOfProperty;
                    newRow["kind_of_property"] = propertyKind;
                    newRow["assessed_value"] = assessedValue;
                    newRow["years_delinquent"] = monthsDelinquent / 12;
                    newRow["total_delinquency_as_of"] = total;
                    newRow["cost_of_sale"] = 0;

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
                report.ReportPath = $"{Application.StartupPath}Reports\\LTOM\\ltom-23-notice-of-auction-sale-of-delinquent-real-properties.rdlc";
                report.DataSources.Clear();


                var dtAuction = AccFactory.AuctionRepository().GetRecordById(auctionId);

                string lguName = Helper.LGUDetails()["lgu_name"];
                string location = dtAuction["location"];
                string date = dtAuction["start_date"];

                var signatory = Helper.GetSignatoryDataBy_Reference_DocumentName("Treasurer", "LTOM");

                var reportParameters = new ReportParameter[]
                {
                    new ReportParameter("paramLGU", lguName),
                    new ReportParameter("paramTimeOfAuction", date),
                    new ReportParameter("paramPlaceOfAuction", location),
                    new ReportParameter("paramSignatoryTitle", signatory["signatories_title"]),
                    new ReportParameter("paramSignatory", signatory["signatories_full_name"]),


                };

                report.DataSources.Add(new ReportDataSource("dsNoticeOfAuctionSaleOfDelinquentProperty", dataTable));
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
