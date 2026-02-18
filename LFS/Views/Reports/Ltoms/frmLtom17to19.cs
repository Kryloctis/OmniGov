using LFS.DataSets;
using LFS.Helpers;
using LFS.Views.Shared;
using Microsoft.Reporting.WinForms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Windows.Forms;
using Treasury.Data.Factories;

namespace LFS.Views.Reports.Ltoms
{
    public partial class frmLtom17to19 : Form
    {
        private DataTable dtDelinquentNotice;

        public frmLtom17to19()
        {
            InitializeComponent();
            Helper.LoadFormIcon(this);
            panel3.Controls.Add(reportViewer1);
            txtRpt.AutoCompleteSource = AutoCompleteSource.CustomSource;
            txtRpt.AutoCompleteMode = AutoCompleteMode.Suggest;
        }

        private void frmLtom17to19_Load(object sender, EventArgs e)
        {
            try
            {
                LoadRealProperties();
            }
            catch (Exception ex) { Helper.MessageBoxError(ex.Message); }
        }

        private void LoadRealProperties()
        {
            dtDelinquentNotice = TreasuryFactory.RealPropertiesRepository().GetViewRecords();

            var autoCompleteSrc = dtDelinquentNotice.AsEnumerable().Select(row => row.Field<string>("complete_arp_no")).ToList();
            var autoCom = new AutoCompleteStringCollection();
            autoCom.Clear();
            autoCom.AddRange(autoCompleteSrc.ToArray());
            txtRpt.AutoCompleteCustomSource = autoCom;
        }

        private void LoadDelinquencyNoticeRecords()
        {
            var rptId = dtDelinquentNotice.AsEnumerable()
                               .Where(row => row.Field<string>("complete_arp_no") == txtRpt.Text)
                               .Select(row => row["real_property_id"])
                               .FirstOrDefault();

            var checkedRadioButton = flwLayoutType.Controls
                                      .OfType<RadioButton>()
                                      .FirstOrDefault(rb => rb.Checked);
            string noticeType;

            switch (checkedRadioButton.Name)
            {
                case "rad1stNotice":
                    noticeType = "1st Notice";
                    break;

                case "rad2ndNotice":
                    noticeType = "2nd Notice";
                    break;

                case "rad3rdNotice":
                    noticeType = "3rd Notice";
                    break;

                default:
                    noticeType = string.Empty;
                    break;
            }

            if (rptId is not null)
            {
                var dtNoticeDelinquencies = TreasuryFactory.DelinquentNoticeRepository().GetViewRecordsByRptId(Convert.ToInt32(rptId), noticeType);
                cmbxDelinquentNoticeRecord.DataSource = dtNoticeDelinquencies;
                cmbxDelinquentNoticeRecord.ValueMember = "delinquent_notice_id";
                cmbxDelinquentNoticeRecord.DisplayMember = "notice_date";
            }
            else { cmbxDelinquentNoticeRecord.SelectedIndex = -1; }
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
                var rptDelinquencyNoticeId = cmbxDelinquentNoticeRecord.SelectedValue;
                backgroundWorker1.RunWorkerAsync(rptDelinquencyNoticeId);
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
                var rptDelinquencyNoticeId = e.Argument;

                if (rptDelinquencyNoticeId is null)
                {
                    backgroundWorker1.CancelAsync();
                    e.Cancel = true;
                    return;
                }

                var dictDelinquentNotice = TreasuryFactory.DelinquentNoticeRepository().GetViewRecordById(Convert.ToInt32(rptDelinquencyNoticeId));
                var noticeDate = Convert.ToDateTime(dictDelinquentNotice["notice_date"]);
                var completeArpNo = dictDelinquentNotice["complete_arp_no"];

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

                e.Result = (dtLtom17to19, dictDelinquentNotice);
            }
            catch (Exception ex) { Helper.MessageBoxError(ex.Message); }
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

                var checkedRadioButton = flwLayoutType.Controls
                                     .OfType<RadioButton>()
                                     .FirstOrDefault(rb => rb.Checked);
                string reportPath;
                var propertyLocation = Helper.GenerateFullAddress(string.Empty, result.dictDelinquentNotice["barangay_name"], result.dictDelinquentNotice["municipalities_name"], result.dictDelinquentNotice["provinces_name"]);

                string lguName = ServerHelper.selectedServer.MunicipalityName;

                var parameters = new ReportParameter[]
                {
                    new("paramLgu", lguName),
                    new("paramNoticeDate", result.dictDelinquentNotice["notice_date"]),
                    new("paramDeclaredOwners", result.dictDelinquentNotice["taxpayers_name"]),
                    new("paramSignatory", string.Empty),
                    new("paramSignatoryTitle", string.Empty),
                    new("paramTaxDecNo", result.dictDelinquentNotice["complete_arp_no"]),
                    new("paramTctNo", string.Empty),
                    new("paramPropertyLocation", propertyLocation),
                    new("paramPropertyKind", result.dictDelinquentNotice["complete_arp_no"]),
                    new("paramAssessedValue", result.dictDelinquentNotice["assessed_value"])
                };

                switch (checkedRadioButton.Name)
                {
                    case "rad1stNotice":
                        reportPath = "Ltom17NoticeRptDelinq.rdlc";
                        break;

                    case "rad2ndNotice":
                        reportPath = "Ltom18NoticeRptDelinq.rdlc";
                        break;

                    case "rad3rdNotice":
                        reportPath = "Ltom19NoticeRptDelinq.rdlc";
                        break;

                    default:
                        reportPath = string.Empty;
                        break;
                }

                reportViewer1.Clear();
                var localReport = reportViewer1.LocalReport;
                localReport.ReportPath = $"{Application.StartupPath}Reports\\Ltoms\\{reportPath}";
                localReport.DataSources.Clear();
                localReport.DataSources.Add(new ReportDataSource("dtLtom17_19", result.dataTable));
                localReport.SetParameters(parameters);
                localReport.Refresh();

                reportViewer1.SetDisplayMode(DisplayMode.PrintLayout);
                reportViewer1.ZoomMode = ZoomMode.FullPage;
                reportViewer1.Refresh();
                ToogleRunButton(true);
            }
            catch (Exception ex) { Helper.MessageBoxError(ex.Message); }
        }

        private void rad1stNotice_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                LoadDelinquencyNoticeRecords();
            }
            catch (Exception ex) { Helper.MessageBoxError(ex.Message); }
        }

        private void rad2ndNotice_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                LoadDelinquencyNoticeRecords();
            }
            catch (Exception ex) { Helper.MessageBoxError(ex.Message); }
        }

        private void rad3rdNotice_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                LoadDelinquencyNoticeRecords();
            }
            catch (Exception ex) { Helper.MessageBoxError(ex.Message); }
        }

        private void txtRpt_TextChanged(object sender, EventArgs e)
        {
            try
            {
                LoadDelinquencyNoticeRecords();
            }
            catch (Exception ex) { Helper.MessageBoxError(ex.Message); }
        }

        private void splitContainer1_SplitterMoved(object sender, SplitterEventArgs e)
        {
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
