using Microsoft.Reporting.WinForms;
using OmniGov.App.DataSets;
using OmniGov.App.Helpers;
using OmniGov.App.Views.Shared;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Windows.Forms;
using Treasury.Data.Factories;

namespace OmniGov.App.Views.Reports.Ltoms
{
    public partial class frmLtom20 : Form
    {
        private DataTable dtRpt;

        public frmLtom20()
        {
            InitializeComponent();
            Helper.LoadFormIcon(this);
            panel3.Controls.Add(reportViewer1);
            txtRpt.AutoCompleteSource = AutoCompleteSource.CustomSource;
            txtRpt.AutoCompleteMode = AutoCompleteMode.Suggest;
        }

        private void LoadRealProperties()
        {
            dtRpt = TreasuryFactory.RealPropertiesRepository().GetViewRecords();
            var autoCompleteSrc = dtRpt.AsEnumerable().Select(row => row.Field<string>("complete_arp_no")).ToList();
            var autoCom = new AutoCompleteStringCollection();
            autoCom.Clear();
            autoCom.AddRange(autoCompleteSrc.ToArray());
            txtRpt.AutoCompleteCustomSource = autoCom;
        }

        private void LoadIssuedWarrantLevy()
        {
            var rptId = dtRpt.AsEnumerable()
                               .Where(row => row.Field<string>("complete_arp_no") == txtRpt.Text)
                               .Select(row => row["real_property_id"])
                               .FirstOrDefault();

            if (rptId is not null)
            {
                var dtNoticeDelinquencies = TreasuryFactory.RptLevyRepository().GetViewRecords(Convert.ToInt32(rptId));
                cmbxWarrantLevy.DataSource = dtNoticeDelinquencies;
                cmbxWarrantLevy.ValueMember = "rpt_levy_id";
                cmbxWarrantLevy.DisplayMember = "date_issued";
            }
        }

        private void frmLtom20_Load(object sender, EventArgs e)
        {
            try
            {
                LoadRealProperties();
            }
            catch (Exception ex) { Helper.MessageBoxError(ex.Message); }
        }

        private void ToogleRunButton(bool isGenerated)
        {
            btnRunReport.Text = isGenerated ? "Run Report" : "Generating Report...";
            btnRunReport.Enabled = isGenerated;
        }

        private void LoadReport()
        {
            if (!backgroundWorker1.IsBusy)
            {
                pbReport.Value = 0;
                ToogleRunButton(false);
                var warrantLevyId = cmbxWarrantLevy.SelectedValue;
                backgroundWorker1.RunWorkerAsync(warrantLevyId);
            }
        }

        private (decimal basicPenalty, decimal sefPenalty) GetPenalties(DateTime transactionDate, (int assessmentYear, string compelteArpNo, int effectivityQuarter, int effectivityYear) currentAssmntParameters, decimal penaltyRate, decimal basicTaxDue, decimal sefTaxDue)
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

        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
            try
            {
                var warrantLevyId = e.Argument;

                if (warrantLevyId is null)
                {
                    backgroundWorker1.CancelAsync();
                    e.Cancel = true;
                    return;
                }

                var dictWarrantLevy = TreasuryFactory.RptLevyRepository().GetViewRecordById(Convert.ToInt32(warrantLevyId));
                var noticeDate = Convert.ToDateTime(dictWarrantLevy["date_issued"]);
                var completeArpNo = dictWarrantLevy["complete_arp_no"];

                var dtLtom17to19 = new dsTreasury.dtLtom17_19DataTable().Clone();
                var dtAssessmentPostingDb = TreasuryFactory.RptAssessmentPostsRepository().GetViewDelinquentRecords(completeArpNo, noticeDate);

                int totalProgressCount = dtAssessmentPostingDb.Rows.Count;
                int progressCount = 0;

                foreach (DataRow dataRow in dtAssessmentPostingDb.Rows)
                {
                    decimal assessedValue = Convert.ToDecimal(dataRow["assessed_value"]);
                    decimal basicRate = Convert.ToDecimal(dataRow["basic_rate"]);
                    decimal sefRate = Convert.ToDecimal(dataRow["sef_rate"]);
                    int taxYear = Convert.ToInt32(dataRow["year"]);
                    int effectivityQuarter = Convert.ToInt32(dataRow["effectivity_quarterly"]);
                    int effectivityYear = Convert.ToInt32(dataRow["effectivity_year"]);
                    decimal basicTaxDue = RealPropertyTaxComputations.GetBasicTaxDue(basicRate, assessedValue);
                    decimal sefTaxDue = RealPropertyTaxComputations.GetSefTaxDue(sefRate, assessedValue);
                    decimal penaltyRate = Convert.ToDecimal(dataRow["penalty_rate"]);

                    var penaltyParameters = (taxYear, completeArpNo, effectivityQuarter, effectivityYear);
                    var penalties = GetPenalties(noticeDate, penaltyParameters, penaltyRate, basicTaxDue, sefTaxDue);

                    if (penalties.basicPenalty <= 0 && penalties.sefPenalty <= 0)
                    {
                        totalProgressCount--;
                        Helper.ProgressCounter(backgroundWorker1, totalProgressCount, progressCount);
                        continue;
                    }

                    var newRow = dtLtom17to19.NewRow();
                    newRow["tax_year"] = dataRow["year"];
                    newRow["basic_tax"] = basicTaxDue.ToString("N2");
                    newRow["basic_penalty"] = penalties.basicPenalty.ToString("N2");
                    newRow["sef_tax"] = sefTaxDue.ToString("N2");
                    newRow["sef_penalty"] = penalties.sefPenalty.ToString("N2");
                    newRow["total_amount"] = (penalties.basicPenalty + penalties.sefPenalty + basicTaxDue + sefTaxDue).ToString("N2");
                    dtLtom17to19.Rows.Add(newRow);
                    progressCount++;
                    Helper.ProgressCounter(backgroundWorker1, totalProgressCount, progressCount);
                }

                e.Result = (dtLtom17to19, dictWarrantLevy);
            }
            catch (Exception ex) { Helper.MessageBoxError(ex.StackTrace); }
        }

        private void backgroundWorker1_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            pbReport.Value = e.ProgressPercentage;
        }

        private void backgroundWorker1_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            try
            {
                if (e.Cancelled)
                {
                    pbReport.Value = 100;
                    btnRunReport.Text = "Run Report";
                    btnRunReport.Enabled = true;
                    reportViewer1.Clear();
                    return;
                }

                var result = ((DataTable dataTable, Dictionary<string, string> dictDelinquentNotice))e.Result;

                if (result.dataTable.Rows.Count < 1)
                    pbReport.Value = 100;

                var propertyLocation = Helper.GenerateFullAddress(string.Empty, result.dictDelinquentNotice["barangay_name"], result.dictDelinquentNotice["municipalities_name"], result.dictDelinquentNotice["provinces_name"]);

                var parameters = new ReportParameter[]
                {
                    new ReportParameter("paramLgu", ServerHelper.selectedServer.MunicipalityName),
                    new ReportParameter("paramDeclaredOwners", result.dictDelinquentNotice["taxpayers_name"]),
                    new ReportParameter("paramSignatory", string.Empty),
                    new ReportParameter("paramSignatoryTitle", string.Empty),
                    new ReportParameter("paramTaxDecNo", result.dictDelinquentNotice["complete_arp_no"]),
                    new ReportParameter("paramTctNo", string.Empty),
                    new ReportParameter("paramPropertyLocation", propertyLocation),
                    new ReportParameter("paramPropertyKind", result.dictDelinquentNotice["complete_arp_no"]),
                    new ReportParameter("paramAssessedValue", result.dictDelinquentNotice["assessed_value"]),
                    new ReportParameter("paramIssuedDate", result.dictDelinquentNotice["date_issued"])
                };

                reportViewer1.Clear();
                var localReport = reportViewer1.LocalReport;
                localReport.ReportPath = $"{Application.StartupPath}Reports\\Ltoms\\Ltom20WarrantOfLevy.rdlc";
                localReport.DataSources.Clear();
                localReport.DataSources.Add(new ReportDataSource("dtLtom17_19", result.dataTable));
                localReport.SetParameters(parameters);
                localReport.Refresh();

                reportViewer1.SetDisplayMode(DisplayMode.PrintLayout);
                reportViewer1.ZoomMode = ZoomMode.FullPage;
                reportViewer1.Refresh();
                ToogleRunButton(true);
            }
            catch (Exception ex) { Helper.MessageBoxError(ex.StackTrace); }
        }

        private void txtRpt_TextChanged(object sender, EventArgs e)
        {
            try
            {
                LoadIssuedWarrantLevy();
            }
            catch (Exception ex) { Helper.MessageBoxError(ex.Message); }
        }

        private void btnRunReport_Click(object sender, EventArgs e)
        {
            try
            {
                LoadReport();
            }
            catch (Exception ex) { Helper.MessageBoxError(ex.Message); }
        }
    }
}