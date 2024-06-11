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
    public partial class ucDeclarationOfForfeitureOfDelinquentProperty : UserControl
    {

        private int auctionId;
        private int taxpayerId;

        public ucDeclarationOfForfeitureOfDelinquentProperty()
        {
            InitializeComponent();
            panel1.Controls.Add(reportViewer1);
        }

        internal void OnLoad(int auctionId, int taxpayerId)
        {
            this.auctionId = auctionId;
            this.taxpayerId = taxpayerId;
            LoadReport();
        }

        private void LoadReport()
        {
            if (!backgroundWorker1.IsBusy)
            {
                progressBar1.Value = 0;
                backgroundWorker1.RunWorkerAsync((auctionId, taxpayerId));
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
                var parameters = ((int auctionId, int taxpayerId))e.Argument;
                var rptAuctionModel = new RptAuctionModel() { AuctionId = parameters.auctionId };

                var dbRptAuctionProperties = AccFactory.RptAuctionRepository().GetAuctionProperties(rptAuctionModel);
                var dtRptAuctionProperties = new dsTreasury.dtLtom29DataTable();

                int totalProgressCount = dbRptAuctionProperties.Rows.Count;
                int progressCount = 0;

                int taxpayerID = parameters.taxpayerId;
                int monthsDelinquent;
                decimal assessedValue;
                decimal basicTaxDue;
                decimal sefTaxDue;
                decimal penaltyRate;
                decimal totalTaxDue;
                decimal total;

                var newRow = dtRptAuctionProperties.NewRow();

                #region Computation
                var dtDelinquentRpt = AccFactory.RptAssessmentPostsRepository().Get_View_List_Of_Real_Property_Tax_Delinquences_By_TaxpayerID(taxpayerID);

                foreach (DataRow dataRowDeliquency in dtDelinquentRpt.Rows)
                {
                    string completeArpNo = dataRowDeliquency["complete_arp_no"].ToString();
                    int assessmentYear = Convert.ToInt32(dataRowDeliquency["year"]);
                    int effectivityQuarter = Convert.ToInt32(dataRowDeliquency["effectivity_quarterly"]);
                    int effectivityYear = Convert.ToInt32(dataRowDeliquency["effectivity_year"]);
                    var dictPrevAssmnt = AccFactory.RptAssessmentPostsRepository().GetViewRecentAssessmentRecord(completeArpNo, assessmentYear);
                    assessedValue = Convert.ToDecimal(dataRowDeliquency["assessed_value"]);

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

                    newRow["basic_tax"] = basicTaxDue;
                    newRow["basic_penalty"] = penalties.basicPenalty;
                    newRow["sef_tax"] = sefTaxDue;
                    newRow["sef_penalty"] = penalties.sefPenalty;
                    newRow["total_amount"] = total;
                    newRow["assessed_value"] = assessedValue;

                    progressCount++;
                    Helper.ProgressCounter(backgroundWorker1, totalProgressCount, progressCount);
                    dtRptAuctionProperties.Rows.Add(newRow);
                }
                #endregion

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

            if (e.Cancelled)
                return;
            if (e.Result is not DataTable dataTable)
                return;

            if (dataTable.Rows.Count < 1)
                progressBar1.Value = 100;

            var report = reportViewer1.LocalReport;
            report.ReportPath = $"{Application.StartupPath}Reports\\LTOM\\ltom-30-declaration-of-forfeiture-of-delinquent-property.rdlc";
            report.DataSources.Clear();


            string lguName = Helper.LGUDetails()["lgu_name"];
            var signatory = Helper.GetSignatoryDataBy_Reference_DocumentName("Treasurer", "LTOM");

            var dictAuctionProperty = AccFactory.RptAuctionRepository().GetAuctionPropertiesByAuctionIdAndTaxpayerId(auctionId, taxpayerId);

            var reportParameters = new ReportParameter[]
            {
                    new ReportParameter("paramLGU", lguName),
                    new ReportParameter("paramSignatoryTitle", signatory["signatories_title"]),
                    new ReportParameter("paramSignatory", signatory["signatories_full_name"]),
                    //new ReportParameter("paramPlaceOfAuction", dictAuctionProperty["location"]),
                    //new ReportParameter("paramDeclaredOwner", dictAuctionProperty["taxpayer_name"]),
                    //new ReportParameter("paramTaxDec", dictAuctionProperty["complete_arp_no"]),
                    //new ReportParameter("paramTCT", string.Empty),
                    //new ReportParameter("paramKindOfProperty", dictAuctionProperty["property_kind"]),

            };

            report.DataSources.Add(new ReportDataSource("dsLtom30", dataTable));
            report.SetParameters(reportParameters);

            reportViewer1.SetDisplayMode(DisplayMode.PrintLayout);
            reportViewer1.ZoomMode = ZoomMode.PageWidth;
            reportViewer1.ZoomPercent = 100;
            reportViewer1.RefreshReport();

            try
            {

            }

            catch (Exception ex) { Helper.MessageBoxError(ex.Message); }
        }
    }
}
