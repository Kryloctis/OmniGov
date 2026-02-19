using Microsoft.Reporting.WinForms;
using OmniGov.App.DataSets;
using OmniGov.App.Helpers;
using OmniGov.App.Views.Shared;
using System;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Windows.Forms;
using Treasury.Data.Factories;

namespace OmniGov.App.Views.Reports.Ltoms
{
    public partial class frmLtom16 : Form
    {
        public frmLtom16()
        {
            InitializeComponent();
            Helper.LoadFormIcon(this);
            panel3.Controls.Add(reportViewer1);
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
                var date = dateTimePicker1.Value;
                pbReport.Value = 0;
                ToogleRunButton(false);
                backgroundWorker1.RunWorkerAsync(date);
            }
        }

        private double GetYearsFromMonths(int months)
        {
            return (double)months / 12;
        }

        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
            try
            {
                var parameter = (DateTime)e.Argument;
                var dtLtom16 = new dsTreasury.dtLtom16DataTable().Clone();
                var dtAssessmentPost = TreasuryFactory.RptAssessmentPostsRepository().GetViewRecords(parameter);
                var groupedData = dtAssessmentPost.AsEnumerable()
                                                  .GroupBy(row => row.Field<string>("complete_arp_no"))
                                                  .SelectMany(grp => grp.Select(row =>
                                                  {
                                                      var fullAddress = Helper.GenerateFullAddress
                                                      (
                                                          row.Field<string>("street"),
                                                          row.Field<string>("barangay_name"),
                                                          row.Field<string>("municipality_name"),
                                                          row.Field<string>("province_name")
                                                      );

                                                      var monthsDelinquent = RealPropertyTaxComputations.GetMonthsDelinquent(parameter, (parameter.Year, (int)row["effectivity_quarterly"], (int)row["effectivity_year"]), null);

                                                      decimal totalTaxDue = RealPropertyTaxComputations.GetSefBasicTotalTaxDue((decimal)row["basic_rate"], (decimal)row["sef_rate"], (decimal)row["assessed_value"]);
                                                      decimal totalPenalty = RealPropertyTaxComputations.GetPenalty((decimal)row["penalty_rate"], monthsDelinquent, totalTaxDue);
                                                      string taxDecNo = row["complete_arp_no"].ToString();

                                                      return new
                                                      {
                                                          Owner = row["taxpayer_name"],
                                                          TaxDecNo = taxDecNo,
                                                          PropertyLocation = fullAddress,
                                                          PropertyKind = row["property_kind"],
                                                          AssessedValue = row["assessed_value"],
                                                          YearsOfDelinquency = GetYearsFromMonths(monthsDelinquent),
                                                          TaxDue = totalTaxDue + totalPenalty
                                                      };
                                                  })).Distinct();

                int totalProgressCount = groupedData.Count();
                int progressCount = 0;

                foreach (var item in groupedData)
                {
                    var newRow = dtLtom16.NewRow();
                    newRow["owner"] = item.Owner;
                    newRow["tax_dec_no"] = item.TaxDecNo;
                    newRow["property_location"] = item.PropertyLocation;
                    newRow["property_kind"] = item.PropertyKind;
                    newRow["assessed_value"] = item.AssessedValue;
                    newRow["years_of_delinquence"] = item.YearsOfDelinquency;
                    newRow["tax_due"] = item.TaxDue;

                    progressCount++;
                    dtLtom16.Rows.Add(newRow);
                    Helper.ProgressCounter(backgroundWorker1, totalProgressCount, progressCount);
                }

                var reportParameters = new ReportParameter[]
                {
                    new("paramLgu", (ServerHelper.SelectedProfile?.Name ?? "")),
                    new("paramAsOf", parameter.ToString()),
                    new("paramDate", parameter.ToString()),
                    new("paramSignatory", ""),
                    new("paramSignatoryTitle", "")
                };

                e.Result = (reportParameters, dtLtom16);
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
        }

        private void backgroundWorker1_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            pbReport.Value = e.ProgressPercentage;
        }

        private void backgroundWorker1_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            try
            {
                var results = ((ReportParameter[] parameters, DataTable dataTable))e.Result;

                // Default code here
                reportViewer1.Clear();
                var localReport = reportViewer1.LocalReport;
                localReport.ReportPath = $"{Application.StartupPath}Reports\\Ltoms\\Ltom16NoticeDelinqPymntRpt.rdlc";
                localReport.DataSources.Clear();
                localReport.DataSources.Add(new ReportDataSource("dtLtom16", results.dataTable));
                localReport.SetParameters(results.parameters);
                localReport.Refresh();

                reportViewer1.SetDisplayMode(DisplayMode.PrintLayout);
                reportViewer1.ZoomMode = ZoomMode.FullPage;
                reportViewer1.Refresh();
                ToogleRunButton(true);
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
        }

        private void btnRunReport_Click(object sender, EventArgs e)
        {
            try
            {
                LoadReport();
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
        }
    }
}

