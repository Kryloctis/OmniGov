using AccountingSystem.Views.Transactions.PaymentPostings.RPT_PaymentPosting;
using Microsoft.Reporting.WinForms;
using System;
using System.ComponentModel;
using System.Data;
using System.Windows.Forms;

namespace AccountingSystem.Views.Reports.RealPropertyTaxReports.CertifiedListOfPropertyTaxDelinquences
{
    public partial class frmCertifiedListOfTaxDelinquences : Form
    {
        private ReportViewer reportViewer;
        private DataTable dataTable;

        public frmCertifiedListOfTaxDelinquences()
        {
            InitializeComponent();
            Helper.LoadFormIcon(this);
            reportViewer = new ReportViewer();
            panel2.Controls.Add(reportViewer);
            reportViewer.Dock = DockStyle.Fill;
        }

        private void LoadBarangays()
        {
            var dtBarangays = AccFactory.RptAssessmentPostsRepository().Get_Grouped_Barangay_Records();
            cmbxBarangays.DataSource = dtBarangays;
            cmbxBarangays.DisplayMember = "barangay_name";
        }

        private void frmCertifiedListOfTaxDelinquences_Load(object sender, EventArgs e)
        {
            LoadBarangays();
            dtAsOf.Value = Helper.GetCurrentDate();
        }

        private bool LoadReport(LocalReport localReport)
        {
            try
            {
                string lguName = Helper.LGUDetails()["lgu_name"];
                string barangayName = cmbxBarangays.Text.Trim();
                var asOfDate = dtAsOf.Value;

                var reportParameters = new ReportParameter[]
                {
                    new ReportParameter("paramLGUName", lguName),
                    new ReportParameter("paramAsOf", asOfDate.ToString()),
                    new ReportParameter("paramBarangay", barangayName)
                };

                localReport.ReportPath = $"{Application.StartupPath}\\Reports\\certified-list-of-all-real-property-tax-delinquences-report.rdlc";
                localReport.SetParameters(reportParameters);

                localReport.DataSources.Clear();
                localReport.DataSources.Add(new ReportDataSource("dtCertListOfAllRptDelinquences", dataTable));

                reportViewer.SetDisplayMode(DisplayMode.PrintLayout);
                reportViewer.ZoomMode = ZoomMode.PageWidth;
                reportViewer.ZoomPercent = 100;

                reportViewer.RefreshReport();

                return true;
            }
            catch (Exception ex)
            {
                Helper.MessageBoxError(ex.Message);
            }
            return false;
        }

        private decimal GetPenalty(string completeArpNo, int assessmentYear, DateTime assessmentPostedAt, DateTime paymentPostedAt, int effectivityYear, decimal penaltyRate, decimal taxDueAmount)
        {
            var paymenPostDate = Convert.ToDateTime(paymentPostedAt);
            int previousAssessmentCount = AccFactory.RptAssessmentPostsRepository().PreviousAssessmentPostCount(completeArpNo, assessmentYear);
            int delinquentMonths = taxDueComputations.GetSelectedMonthsDelinquent(assessmentYear, assessmentPostedAt, paymenPostDate, effectivityYear, previousAssessmentCount);

            return taxDueComputations.GetPenalty(penaltyRate, delinquentMonths, taxDueAmount);
        }

        private void GetParameters(out string barangayName, out DateTime asOfDate)
        {
            barangayName = cmbxBarangays.Text.Trim();
            asOfDate = dtAsOf.Value;
        }

        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
            dataTable = new dsLFS.dtCertListOfAllRptDelinquencesDataTable();

            string barangayName = string.Empty;
            DateTime asOfDate = DateTime.Now;

            Invoke((MethodInvoker)delegate
           {
               GetParameters(out barangayName, out asOfDate);
           });

            var referenceDataTable = AccFactory.RptAssessmentPostsRepository().Get_View_CertListOfAllRptDelinquences_By_BarangayName_AsOfDate(barangayName, asOfDate);

            foreach (DataRow row in referenceDataTable.Rows)
            {
                var newRow = dataTable.NewRow();
                string rowRptPaymentPostId = row["rpt_payment_posts_id"].ToString();
                string rowCompleteArpNo = row["complete_arp_no"].ToString();
                string rowOwnerName = row["owner_name"].ToString();
                string rowOwnerAdress = row["owner_address"].ToString();
                string rowClassification = row["classification_code"].ToString();
                string rowPropertyKind = row["property_kind"].ToString();
                int rowEffectivityYear = Convert.ToInt32(row["effectivity_year"]);
                decimal rowPenaltyRate = Convert.ToDecimal(row["penalty_rate"]);
                DateTime rowPostedAt = Convert.ToDateTime(row["posted_at"]);
                decimal rowAssessedValue = Convert.ToDecimal(row["assessed_value"]);
                decimal rowOtherImprovements = Convert.ToDecimal(row["other_improvements"]);
                string remarks = string.Empty;
                int rowYear = Convert.ToInt32(row["year"]);

                decimal basicPenalty = 0;
                decimal sefPenalty = 0;

                #region Tax Due

                decimal rowBasicRate = Convert.ToDecimal(row["basic_rate"]);
                decimal rowSefRate = Convert.ToDecimal(row["sef_rate"]);
                decimal basicTaxDueAmount = taxDueComputations.GetBasicTaxDue(rowBasicRate, rowAssessedValue);
                decimal sefTaxDueAmount = taxDueComputations.GetSefTaxDue(rowSefRate, rowAssessedValue);

                #endregion Tax Due

                #region Penalty

                //If there's a payment
                if (!string.IsNullOrEmpty(rowRptPaymentPostId))
                {
                    var rowPaymentPostsDate = Convert.ToDateTime(row["rpt_payment_posts_posted_at"]);

                    basicPenalty = GetPenalty(rowCompleteArpNo, rowYear, rowPostedAt, rowPaymentPostsDate, rowEffectivityYear, rowPenaltyRate, basicTaxDueAmount);
                    sefPenalty = GetPenalty(rowCompleteArpNo, rowYear, rowPostedAt, rowPaymentPostsDate, rowEffectivityYear, rowPenaltyRate, sefTaxDueAmount);
                }

                #endregion Penalty

                #region Assesses Values

                decimal landAssessedValue = 0;
                decimal machineryAssessedValue = 0;
                switch (rowPropertyKind)
                {
                    case "L":
                        landAssessedValue = rowAssessedValue * 2;
                        break;

                    case "M":
                        machineryAssessedValue = rowAssessedValue * 2;
                        break;
                }

                #endregion Assesses Values

                decimal basicTotal = basicTaxDueAmount + basicPenalty;
                decimal sefTotal = sefTaxDueAmount + sefPenalty;
                decimal grandTotal = basicTotal + sefTotal;
                decimal annualTax = (basicTaxDueAmount + sefTaxDueAmount) * 2;

                newRow["arp_no"] = rowCompleteArpNo;
                newRow["owner_name"] = rowOwnerName;
                newRow["owner_address"] = rowOwnerAdress;
                newRow["classification"] = rowClassification;
                newRow["land_assessed_value"] = landAssessedValue;
                newRow["other_improvement_assessed_value"] = rowOtherImprovements;
                newRow["machinery_assessed_value"] = machineryAssessedValue;
                newRow["annual_tax"] = annualTax;
                newRow["year"] = rowYear;
                newRow["basic_tax"] = basicTaxDueAmount;
                newRow["basic_penalty"] = basicPenalty;
                newRow["basic_total"] = basicTotal;
                newRow["sef_tax"] = sefTaxDueAmount;
                newRow["sef_penalty"] = sefPenalty;
                newRow["sef_total"] = sefTotal;
                newRow["grand_total"] = grandTotal;
                newRow["remarks"] = remarks;

                dataTable.Rows.Add(newRow);
            }
        }

        private void backgroundWorker1_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
        }

        private void backgroundWorker1_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            LoadReport(reportViewer.LocalReport);
        }

        private void btnRetrieve_Click(object sender, EventArgs e)
        {
            if (!backgroundWorker1.IsBusy)
                backgroundWorker1.RunWorkerAsync();
        }
    }
}