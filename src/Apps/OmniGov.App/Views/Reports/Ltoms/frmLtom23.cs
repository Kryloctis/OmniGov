using Microsoft.Reporting.WinForms;
using OmniGov.App.DataSets;
using OmniGov.App.Helpers;
using OmniGov.App.Views.Shared;
using System.ComponentModel;
using System.Data;
using Treasury.Data.Factories;
using Treasury.Domain.Entities;

namespace OmniGov.App.Views.Reports.Ltoms
{
    public partial class frmLtom23 : Form
    {
        private int auctionId;
        private string auctionLocation;

        public frmLtom23()
        {
            InitializeComponent();
            panel1.Controls.Add(reportViewer1);
        }

        private void ToogleRunButton(bool isGenerated)
        {
            btnRunReport.Text = isGenerated ? "Run Report" : "Generating Report...";
            btnRunReport.Enabled = isGenerated;
        }

        private void LoadAuctionSchedule()
        {
            var dtAuctionSchedule = TreasuryFactory.AuctionRepository().GetAuctionSchedule();
            HelperLoadRecords.AuctionScheduleCombobox(dtAuctionSchedule, cmbxAuctionSchedule, "date", "id");
        }

        private void btnRunReport_Click(object sender, EventArgs e)
        {
            try
            {
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
                backgroundWorker1.RunWorkerAsync((auctionId));
            }
        }

        private void OnLoad()
        {
            LoadAuctionSchedule();
        }

        private void frmLtom23_Load(object sender, EventArgs e)
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
            var dictPrevAssmnt = TreasuryFactory.RptAssessmentPostsRepository().GetViewRecentAssessmentRecord(currentAssmntParameters.compelteArpNo, currentAssmntParameters.assessmentYear);

            int? prevAssmntYear = null;

            if (dictPrevAssmnt.Count > 1)
                prevAssmntYear = Convert.ToInt32(dictPrevAssmnt["year"]);

            int monthsDelinquent = RealPropertyTaxComputations.GetMonthsDelinquent(transactionDate, (currentAssmntParameters.assessmentYear, currentAssmntParameters.effectivityQuarter, currentAssmntParameters.effectivityYear), prevAssmntYear.HasValue ? prevAssmntYear : null);
            decimal basicPenalty = RealPropertyTaxComputations.GetPenalty(penaltyRate, monthsDelinquent, basicTaxDue);
            decimal sefPenalty = RealPropertyTaxComputations.GetPenalty(penaltyRate, monthsDelinquent, sefTaxDue);

            return (basicPenalty, sefPenalty);
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
                report.ReportPath = $"{Application.StartupPath}Reports\\Ltoms\\Ltom23NoticeAuctionSaleDelinqRpt.rdlc";
                report.DataSources.Clear();

                var dtAuction = TreasuryFactory.AuctionRepository().GetRecordById(auctionId);

                string location = dtAuction["location"];
                string date = $"{Convert.ToDateTime(dtAuction["start_date"]):MMMM dd, yyyy} - {Convert.ToDateTime(dtAuction["end_date"]):MMMM dd, yyyy}";
                string time = $"{Convert.ToDateTime(dtAuction["start_date"]):HH:mm:tt} - {Convert.ToDateTime(dtAuction["start_date"]):HH:mm:tt}";

                var reportParameters = new ReportParameter[]
                {
                    new ReportParameter("paramLGU", (ServerHelper.SelectedProfile?.Name ?? "")),
                    new ReportParameter("paramDateOfAuction", date),
                    new ReportParameter("paramTimeOfAuction", time),
                    new ReportParameter("paramPlaceOfAuction", location),
                    new ReportParameter("paramSignatoryTitle", string.Empty),
                    new ReportParameter("paramSignatory", string.Empty),
                };

                report.DataSources.Add(new ReportDataSource("dsNoticeOfAuctionSaleOfDelinquentProperty", dataTable));
                report.SetParameters(reportParameters);

                reportViewer1.SetDisplayMode(DisplayMode.PrintLayout);
                reportViewer1.ZoomMode = ZoomMode.FullPage;
                reportViewer1.Refresh();
                ToogleRunButton(true);
            }
            catch (Exception ex) { Helper.MessageBoxError(ex.Message); }
        }

        private void backgroundWorker1_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            progressBar1.Value = e.ProgressPercentage;
        }

        private double GetYearsFromMonths(int months)
        {
            return (double)months / 12;
        }

        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
            try
            {
                int auctionId = (int)e.Argument;

                var auctionModel = new AuctionModel() { Id = auctionId };
                var rptAuctionModel = new RptAuctionModel() { AuctionId = auctionId };

                var dbRptAuctionProperties = TreasuryFactory.RptAuctionRepository().GetAuctionProperties(rptAuctionModel);
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

                    var dtDelinquentRpt = TreasuryFactory.RptAssessmentPostsRepository().Get_View_List_Of_Real_Property_Tax_Delinquences_By_TaxpayerID(taxpayerID);

                    foreach (DataRow dataRowDeliquency in dtDelinquentRpt.Rows)
                    {
                        int assessmentYear = Convert.ToInt32(dataRowDeliquency["year"]);
                        int effectivityQuarter = Convert.ToInt32(dataRowDeliquency["effectivity_quarterly"]);
                        int effectivityYear = Convert.ToInt32(dataRowDeliquency["effectivity_year"]);
                        var dictPrevAssmnt = TreasuryFactory.RptAssessmentPostsRepository().GetViewRecentAssessmentRecord(completeArpNo, assessmentYear);

                        int? prevAssmntYear = null;

                        if (dictPrevAssmnt.Count > 1)
                            prevAssmntYear = Convert.ToInt32(dictPrevAssmnt["year"]);

                        var currentDate = Helper.GetCurrentDate();
                        monthsDelinquent = RealPropertyTaxComputations.GetMonthsDelinquent(currentDate, (currentDate.Year, effectivityQuarter, effectivityYear), prevAssmntYear.HasValue ? prevAssmntYear : null);
                        //monthsDelinquent = RealPropertyTaxComputations.GetMonthsDelinquent(currentDate, (currentDate.Year, effectivityQuarter, effectivityYear), null);

                        decimal rowBasicRate = Convert.ToDecimal(dataRowDeliquency["basic_rate"]);
                        decimal rowSefRate = Convert.ToDecimal(dataRowDeliquency["sef_rate"]);

                        basicTaxDue = RealPropertyTaxComputations.GetBasicTaxDue(rowBasicRate, assessedValue);
                        sefTaxDue = RealPropertyTaxComputations.GetSefTaxDue(rowSefRate, assessedValue);
                        penaltyRate = Convert.ToDecimal(dataRowDeliquency["penalty_rate"]);

                        var penaltyParameters = (assessmentYear, completeArpNo, effectivityQuarter, effectivityYear);
                        var penalties = GetPenalties(Helper.GetCurrentDate(), penaltyParameters, penaltyRate, basicTaxDue, sefTaxDue);

                        totalTaxDue = basicTaxDue + sefTaxDue;
                        total = totalTaxDue + (penalties.basicPenalty + penalties.sefPenalty);
                        break;
                    }

                    #endregion Computation

                    newRow["declared_owner"] = taxPayer;
                    newRow["tax_declaration_number"] = completeArpNo;
                    newRow["location_of_property"] = locationOfProperty;
                    newRow["kind_of_property"] = propertyKind;
                    newRow["assessed_value"] = assessedValue;
                    newRow["years_delinquent"] = GetYearsFromMonths(monthsDelinquent);
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
    }
}

