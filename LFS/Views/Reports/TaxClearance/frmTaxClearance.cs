using LFS.Helpers;
using Microsoft.Reporting.WinForms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Windows.Forms;
using Treasury.Data;

namespace LFS.Views.Reports.TaxClearance
{
    public partial class frmTaxClearance : Form
    {
        private DataTable dtRealProperties;

        private int year;
        private decimal assessedValue;
        private string completeARPNo;
        private string receiptNo;
        private string dateOfPayment;
        private string locationOfProperty;
        private string owner;
        private string ownerAddress;

        public frmTaxClearance()
        {
            InitializeComponent();
            Helper.LoadFormIcon(this);

            panel3.Controls.Add(reportViewer1);
            txtPropertyOwner.AutoCompleteSource = AutoCompleteSource.CustomSource;
            txtPropertyOwner.AutoCompleteMode = AutoCompleteMode.Suggest;
        }

        private void LoadRealProperties()
        {
            dtRealProperties = TreasuryFactory.RealPropertiesRepository().GetViewRecords();

            var autoCompleteSrc = dtRealProperties.AsEnumerable().Select(row => row.Field<string>("taxpayer_name")).ToList();
            var autoCom = new AutoCompleteStringCollection();
            autoCom.Clear();
            autoCom.AddRange(autoCompleteSrc.ToArray());
            txtPropertyOwner.AutoCompleteCustomSource = autoCom;
        }

        private void frmTaxClearance_Load(object sender, System.EventArgs e)
        {
            LoadRealProperties();
        }

        private void btnRunReport_Click(object sender, System.EventArgs e)
        {
            try
            {
                LoadReport();
            }
            catch (Exception ex) { Helper.MessageBoxError(ex.Message); }
        }

        private void LoadReport()
        {
            if (!backgroundWorker1.IsBusy)
            {
                var completeARPNo = cmbxProperty.Text;
                CheckProperty(completeARPNo);
                pbReport.Value = 0;
                ToogleRunButton(false);
                backgroundWorker1.RunWorkerAsync();
            }
        }

        private void ToogleRunButton(bool isGenerated)
        {
            btnRunReport.Text = isGenerated ? "Run Report" : "Generating Report...";
            btnRunReport.Enabled = isGenerated;
        }

        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
            try
            {
                if (txtPropertyOwner.Text == string.Empty)
                {
                    backgroundWorker1.CancelAsync();
                    e.Cancel = true;
                    return;
                }

                // Define tasks and their progress weights
                var tasks = new Dictionary<string, int>
                {
                    { "Fetch LGU Details", 10 },
                    { "Fetch Record", 20 },
                    { "Initialize Parameters", 30 },
                    { "Set Parameter Values", 40 },
                };

                int totalProgressCount = tasks.Sum(t => t.Value);
                int progressCount = 0;

                progressCount += tasks["Fetch LGU Details"];
                Helper.ProgressCounter(backgroundWorker1, totalProgressCount, progressCount);

                progressCount += tasks["Fetch Record"];
                Helper.ProgressCounter(backgroundWorker1, totalProgressCount, progressCount);

                List<ReportParameter> reportParameters = new List<ReportParameter>();
                progressCount += tasks["Initialize Parameters"];
                Helper.ProgressCounter(backgroundWorker1, totalProgressCount, progressCount);

                reportParameters.Add(new ReportParameter("paramOwner", owner));
                reportParameters.Add(new ReportParameter("paramOwnerAddress", ownerAddress));
                reportParameters.Add(new ReportParameter("paramTaxPaidFrom", "-"));
                reportParameters.Add(new ReportParameter("paramTaxPaidTo", year.ToString()));
                reportParameters.Add(new ReportParameter("paramOfficialReceipt", receiptNo));

                reportParameters.Add(new ReportParameter("paramYear", year.ToString()));
                reportParameters.Add(new ReportParameter("paramCompleteARPNo", completeARPNo));
                reportParameters.Add(new ReportParameter("paramAssessedValue", assessedValue.ToString("N2")));
                reportParameters.Add(new ReportParameter("paramOfficialReceiptNo", receiptNo));
                reportParameters.Add(new ReportParameter("paramDateOfPayment", dateOfPayment));
                reportParameters.Add(new ReportParameter("paramLocationOfProperty", locationOfProperty));

                reportParameters.Add(new ReportParameter("paramCertificateNo", string.Empty));
                reportParameters.Add(new ReportParameter("paramCertificateIssuedAt", string.Empty));
                reportParameters.Add(new ReportParameter("paramCertificateDateIssued", string.Empty));
                reportParameters.Add(new ReportParameter("paramCertificateTaxpayerTIN", string.Empty));

                progressCount += tasks["Set Parameter Values"];
                Helper.ProgressCounter(backgroundWorker1, totalProgressCount, progressCount);

                e.Result = reportParameters;
            }
            catch (Exception ex) { MessageBox.Show(ex.StackTrace); }
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
                    return;
                }

                var parameters = (List<ReportParameter>)e.Result;
                reportViewer1.Clear();
                var localReport = reportViewer1.LocalReport;
                localReport.ReportPath = $"{Application.StartupPath}Reports\\certificate-of-tax-clearance.rdlc";
                localReport.SetParameters(parameters);
                localReport.Refresh();

                reportViewer1.SetDisplayMode(DisplayMode.PrintLayout);
                reportViewer1.ZoomMode = ZoomMode.FullPage;
                reportViewer1.Refresh();
                ToogleRunButton(true);
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
        }

        private void txtPropertyOwner_TextChanged(object sender, EventArgs e)
        {
            try
            {
                LoadProperties();
            }
            catch (Exception ex) { Helper.MessageBoxError(ex.Message); }
        }

        private void LoadProperties()
        {
            var taxPayerId = dtRealProperties.AsEnumerable()
                        .Where(row => row.Field<string>("taxpayer_name") == txtPropertyOwner.Text)
                        .Select(row => row["taxpayers_id"])
                        .FirstOrDefault();

            if (taxPayerId is not null)
            {
                DataTable dtProperty = TreasuryFactory.RealPropertiesRepository().GetPropertiesByOwnerId(Convert.ToInt32(taxPayerId));

                cmbxProperty.DataSource = dtProperty;
                cmbxProperty.ValueMember = "real_property_id";
                cmbxProperty.DisplayMember = "complete_arp_no";
            }
            else { cmbxProperty.SelectedIndex = -1; }
        }

        private void CheckProperty(string completeArpNo)
        {
            int year = DateTime.Now.Year;
            var dictAssessmentPost = TreasuryFactory.RptAssessmentPostsRepository().GetRecordBy_ArpNo_Year(completeArpNo, year);
            int assessmentPostId = 0;

            if (dictAssessmentPost.Count != 0)
            {
                assessmentPostId = Convert.ToInt32(dictAssessmentPost["id"]);

                var rptPayment = TreasuryFactory.RptPaymentepository().GetRecordByAssessmentPostId(assessmentPostId);

                if (rptPayment.Count != 0)
                {
                    int paymentId = Convert.ToInt32(rptPayment["payment_collections_id"]);
                    var paymentColllection = TreasuryFactory.PaymentCollectionsRepository().GetRecordByID(paymentId);

                    owner = dictAssessmentPost["taxpayer_name"];
                    ownerAddress = dictAssessmentPost["taxpayer_address"];
                    this.year = Convert.ToInt32(dictAssessmentPost["year"]);
                    this.assessedValue = Convert.ToDecimal(dictAssessmentPost["assessed_value"]);
                    this.completeARPNo = dictAssessmentPost["complete_arp_no"];
                    this.receiptNo = rptPayment["payment_collections_receipt_no"];
                    this.dateOfPayment = rptPayment["payment_collections_payment_date"];
                    this.locationOfProperty = dictAssessmentPost["province_name"];
                }
                else
                    Helper.MessageBoxError("Failed to generate Tax Clearance. Property May be delinquent.");
            }
            return;
        }

        private void cmbxProperty_SelectionChangeCommitted(object sender, EventArgs e)
        {
            try
            {
                string completeArpNo = cmbxProperty.Text;
                CheckProperty(completeArpNo);
            }
            catch (Exception ex) { Helper.MessageBoxError(ex.Message); }
        }
    }
}
