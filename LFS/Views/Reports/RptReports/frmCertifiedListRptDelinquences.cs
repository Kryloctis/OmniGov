using LFS.DataSets;
using LFS.Helpers;
using LFS.Views.Shared;
using Microsoft.Reporting.WinForms;
using System;
using System.ComponentModel;
using System.Data;
using System.Windows.Forms;
using Treasury.Data.Factories;

namespace LFS.Views.Reports.RptReports
{
    public partial class frmCertifiedListRptDelinquences : Form
    {
        private ReportViewer reportViewer;

        public frmCertifiedListRptDelinquences()
        {
            InitializeComponent();
            Helper.LoadFormIcon(this);
            reportViewer = new ReportViewer();
            panel2.Controls.Add(reportViewer);
            reportViewer.Dock = DockStyle.Fill;
        }

        private void LoadBarangays()
        {
            var dtBarangays = TreasuryFactory.RptAssessmentPostsRepository().GetBarangayRecords();
            HelperLoadRecords.BarangaysCombobox(dtBarangays, cmbxBarangays, "barangay_name", "id");
        }

        private void frmCertifiedListOfTaxDelinquences_Load(object sender, EventArgs e)
        {
            try
            {
                LoadBarangays();
                dtFrom.Value = Helper.GetCurrentDate();
                dtTo.Value = Helper.GetCurrentDate();
            }
            catch (Exception ex) { Helper.MessageBoxError(ex.Message); }
        }

        private void btnRunReport_Click(object sender, EventArgs e)
        {
            try
            {
                InitializeReport();
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

        private void InitializeReport()
        {
            if (!backgroundWorker1.IsBusy)
            {
                DateTime periodFrom = dtFrom.Value;
                DateTime periodTo = dtTo.Value;
                string barangayName = cmbxBarangays.Text;
                pbLoadRecords.Value = 0;

                backgroundWorker1.RunWorkerAsync((barangayName, periodFrom, periodTo));
            }
        }

        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
            try
            {
                var parameters = ((string barangayName, DateTime periodFrom, DateTime periodTo))e.Argument;

                var dataTable = new dsTreasury.dtCertfiedRptDelinquenciesDataTable();
                var dbDataTable = TreasuryFactory.RptAssessmentPostsRepository().GetViewDelinquentRecordsByBarangayNamePeriod(parameters.barangayName, parameters.periodFrom, parameters.periodTo);

                int totalProgressCount = dbDataTable.Rows.Count;
                int progressCount = 0;

                foreach (DataRow row in dbDataTable.Rows)
                {
                    var newRow = dataTable.NewRow();
                    var rowRptPaymentPostId = row["rpt_payments_id"];
                    string rowCompleteArpNo = row["complete_arp_no"].ToString();
                    string rowOwnerName = row["taxpayer_name"].ToString();
                    string rowOwnerAdress = row["taxpayer_address"].ToString();
                    string rowClassification = row["classification_code"].ToString();
                    string rowPropertyKind = row["property_kind"].ToString();
                    int rowEffectivityQuarter = Convert.ToInt32(row["effectivity_quarterly"]);
                    int rowEffectivityYear = Convert.ToInt32(row["effectivity_year"]);
                    decimal rowPenaltyRate = Convert.ToDecimal(row["penalty_rate"]);
                    DateTime rowPostedAt = Convert.ToDateTime(row["posted_at"]);
                    int rowAssmntYear = Convert.ToInt32(row["year"]);
                    decimal rowAssessedValue = Convert.ToDecimal(row["assessed_value"]);
                    string remarks = string.Empty;
                    decimal rowBasicRate = Convert.ToDecimal(row["basic_rate"]);
                    decimal rowSefRate = Convert.ToDecimal(row["sef_rate"]);

                    decimal basicTaxDue = RealPropertyTaxComputations.GetBasicTaxDue(rowBasicRate, rowAssessedValue);
                    decimal sefTaxDue = RealPropertyTaxComputations.GetSefTaxDue(rowSefRate, rowAssessedValue);

                    var assmntParameters = (rowAssmntYear, rowCompleteArpNo, rowEffectivityQuarter, rowEffectivityYear);
                    var penalties = GetPenalties(parameters.periodTo, assmntParameters, rowPenaltyRate, basicTaxDue, sefTaxDue);

                    if (penalties.basicPenalty == 0 && penalties.sefPenalty == 0)
                    {
                        totalProgressCount--;
                        continue;
                    }

                    decimal rawTotal = basicTaxDue + basicTaxDue;
                    decimal subTotalBasic = basicTaxDue + penalties.basicPenalty;
                    decimal subTotalSef = sefTaxDue + penalties.sefPenalty;
                    decimal grandTotal = subTotalBasic + subTotalSef;

                    newRow["arp_no"] = rowCompleteArpNo;
                    newRow["owner_name"] = rowOwnerName;
                    newRow["owner_address"] = rowOwnerAdress;
                    newRow["classification"] = rowClassification;
                    newRow["land_assessed_value"] = rowPropertyKind == "L" ? rowAssessedValue : 0;
                    newRow["building_assessed_value"] = rowPropertyKind == "B" ? rowAssessedValue : 0;
                    newRow["machinery_assessed_value"] = rowPropertyKind == "M" ? rowAssessedValue : 0;
                    newRow["annual_tax"] = rawTotal;
                    newRow["year"] = rowAssmntYear;
                    newRow["basic_tax"] = basicTaxDue;
                    newRow["basic_penalty"] = penalties.basicPenalty;
                    newRow["basic_sub_total"] = subTotalBasic;
                    newRow["sef_tax"] = sefTaxDue;
                    newRow["sef_penalty"] = penalties.sefPenalty;
                    newRow["sef_sub_total"] = subTotalSef;
                    newRow["grand_total"] = grandTotal;
                    newRow["remarks"] = remarks;

                    progressCount++;
                    dataTable.Rows.Add(newRow);
                    Helper.ProgressCounter(backgroundWorker1, totalProgressCount, progressCount);
                }

                e.Result = dataTable;
            }
            catch (Exception ex) { Helper.MessageBoxError(ex.Message); }
        }

        private void backgroundWorker1_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            pbLoadRecords.Value = e.ProgressPercentage;
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
                    pbLoadRecords.Value = 100;

                string barangayName = cmbxBarangays.Text.Trim();
                string datePeriod = $"{dtFrom.Value.ToString("MMM dd, yyyy")} - {dtTo.Value.ToString("MMM dd, yyyy")}";

                var reportParameters = new ReportParameter[]
                {
                    new("paramLGUName", ServerHelper.selectedServer.MunicipalityName),
                    new("paramDatePeriod", datePeriod),
                    new("paramBarangay", barangayName)
                };

                reportViewer.LocalReport.ReportPath = $"{Application.StartupPath}\\Reports\\CertifiedListRptDelinquences.rdlc";
                reportViewer.LocalReport.SetParameters(reportParameters);

                reportViewer.LocalReport.DataSources.Clear();
                reportViewer.LocalReport.DataSources.Add(new ReportDataSource("dtCertfiedRptDelinquencies", dataTable));

                reportViewer.SetDisplayMode(DisplayMode.PrintLayout);
                reportViewer.ZoomMode = ZoomMode.PageWidth;
                reportViewer.ZoomPercent = 100;

                reportViewer.RefreshReport();
            }
            catch (Exception ex) { Helper.MessageBoxError(ex.Message); }
        }
    }
}
