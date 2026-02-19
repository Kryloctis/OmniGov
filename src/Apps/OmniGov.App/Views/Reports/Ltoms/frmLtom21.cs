using Microsoft.Reporting.WinForms;
using OmniGov.App.Helpers;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Windows.Forms;
using Treasury.Data.Factories;

namespace OmniGov.App.Views.Reports.Ltoms
{
    public partial class frmLtom21 : Form
    {
        private DataTable dtRpt;

        public frmLtom21()
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

        private void frmLtom21_Load(object sender, EventArgs e)
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
            try
            {
                if (!backgroundWorker1.IsBusy)
                {
                    object rptId = dtRpt.AsEnumerable()
                                      .Where(row => row.Field<string>("complete_arp_no") == txtRpt.Text)
                                      .Select(row => row.Field<object>("real_property_id"))
                                      .FirstOrDefault();
                    var date = dateTimePicker1.Value;

                    pbReport.Value = 0;

                    if (!ValidateChildren())
                    {
                        backgroundWorker1.CancelAsync();
                        pbReport.Value = 100;
                        reportViewer1.Clear();
                        return;
                    }

                    ToogleRunButton(false);
                    backgroundWorker1.RunWorkerAsync((rptId, date));
                }
            }
            catch (Exception ex) { Helper.MessageBoxError(ex.StackTrace); }
        }

        private void LoadWarrants()
        {
            var date = dateTimePicker1.Value;
            int rptId = dtRpt.AsEnumerable()
                                   .Where(row => row.Field<string>("complete_arp_no") == txtRpt.Text)
                                   .Select(row => row.Field<int>("real_property_id"))
                                   .FirstOrDefault();
            var dtRptLevy = TreasuryFactory.RptLevyRepository().GetViewRecords(rptId, date);
            var listBxItems = new List<string>();

            foreach (DataRow row in dtRptLevy.Rows)
            {
                string status = (sbyte)row["is_cancelled"] != 0 ? "- Cancelled" : "";
                string rowDate = Convert.ToDateTime(row["date_issued"]).ToString("MMM dd, yyyy");
                string item = $"{rowDate}{status}";
                listBxItems.Add(item);
            }

            listBox1.DataSource = listBxItems;
            listBox1.DisplayMember = "ToString";
        }

        private void txtRpt_TextChanged(object sender, EventArgs e)
        {
            try
            {
                LoadWarrants();
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

        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
            try
            {
                var parameters = ((object rptId, DateTime date))e.Argument;

                var dictRptAssessmentPost = TreasuryFactory.RealPropertiesRepository().GetViewRecordById(Convert.ToInt32(parameters.rptId));

                // Define tasks and their progress weights
                var tasks = new Dictionary<string, int>
                {
                    { "Fetch LGU Details", 10 },
                    { "Generate Property Location", 20 },
                    { "Initialize Parameters", 30 },
                    { "Set Parameter Values", 40 }
                };

                int totalProgressCount = tasks.Sum(t => t.Value);
                int progressCount = 0;

                progressCount += tasks["Fetch LGU Details"];
                Helper.ProgressCounter(backgroundWorker1, totalProgressCount, progressCount);

                var propertyLocation = Helper.GenerateFullAddress(string.Empty, dictRptAssessmentPost["barangay_name"], dictRptAssessmentPost["municipality_name"], dictRptAssessmentPost["province_name"]);
                progressCount += tasks["Generate Property Location"];
                Helper.ProgressCounter(backgroundWorker1, totalProgressCount, progressCount);

                List<ReportParameter> reportParameters = new List<ReportParameter>();
                progressCount += tasks["Initialize Parameters"];
                Helper.ProgressCounter(backgroundWorker1, totalProgressCount, progressCount);

                reportParameters.Add(new ReportParameter("paramLgu", (ServerHelper.SelectedProfile?.Name ?? "")));
                reportParameters.Add(new ReportParameter("paramDeclaredOwners", dictRptAssessmentPost["taxpayer_name"]));
                reportParameters.Add(new ReportParameter("paramSignatory", string.Empty));
                reportParameters.Add(new ReportParameter("paramSignatoryTitle", string.Empty));
                reportParameters.Add(new ReportParameter("paramTaxDecNo", dictRptAssessmentPost["complete_arp_no"]));
                reportParameters.Add(new ReportParameter("paramTctNo", string.Empty));
                reportParameters.Add(new ReportParameter("paramPropertyLocation", propertyLocation));
                reportParameters.Add(new ReportParameter("paramPropertyKind", dictRptAssessmentPost["complete_arp_no"]));
                reportParameters.Add(new ReportParameter("paramAssessedValue", dictRptAssessmentPost["assessed_value"]));
                reportParameters.Add(new ReportParameter("paramNoticeDate", parameters.date.ToString()));
                progressCount += tasks["Set Parameter Values"];
                Helper.ProgressCounter(backgroundWorker1, totalProgressCount, progressCount);

                e.Result = reportParameters;
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
                if (e.Cancelled)
                {
                    reportViewer1.Clear();
                    pbReport.Value = 100;
                    ToogleRunButton(true);
                    return;
                }

                reportViewer1.Clear();
                var parameters = (List<ReportParameter>)e.Result;
                var localReport = reportViewer1.LocalReport;
                localReport.ReportPath = $"{Application.StartupPath}Reports\\Ltoms\\Ltom21NoticeOfLevy.rdlc";
                localReport.SetParameters(parameters);
                localReport.Refresh();

                reportViewer1.SetDisplayMode(DisplayMode.PrintLayout);
                reportViewer1.ZoomMode = ZoomMode.FullPage;
                reportViewer1.Refresh();
                ToogleRunButton(true);
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
        }

        private bool ArpNoValidated(ErrorProvider errorProvider, TextBox textBox)
        {
            object rptId = dtRpt.AsEnumerable()
                                    .Where(row => row.Field<string>("complete_arp_no") == textBox.Text)
                                    .Select(row => row.Field<object>("real_property_id"))
                                    .FirstOrDefault();

            if (rptId is null)
            {
                errorProvider.SetError(textBox, "Invalid Arp No.");
                return false;
            }

            return true;
        }

        private void txtRpt_Validating(object sender, CancelEventArgs e)
        {
            try
            {
                e.Cancel = !ArpNoValidated(errorProvider1, txtRpt);
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
        }

        private void txtRpt_Validated(object sender, EventArgs e)
        {
            Helper.ClearErrorTextBox(errorProvider1, txtRpt);
        }

        private bool PropertHasWarrantLevy(ErrorProvider errorProvider, ListBox listBox)
        {
            int nonCancelledCount = listBox1.Items.Cast<object>()
                                       .Count(item => !item.ToString().Contains("Cancelled"));
            if (nonCancelledCount < 1)
            {
                errorProvider.SetIconAlignment(listBox1, ErrorIconAlignment.TopRight);
                errorProvider.SetError(listBox, "No active warrant of levy found");
                return true;
            }

            return false;
        }

        private void listBox1_Validating(object sender, CancelEventArgs e)
        {
            try
            {
                e.Cancel = PropertHasWarrantLevy(errorProvider1, listBox1);
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
        }

        private void listBox1_Validated(object sender, EventArgs e)
        {
            errorProvider1.SetError(listBox1, string.Empty);
        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            try
            {
                LoadWarrants();
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
        }
    }
}

