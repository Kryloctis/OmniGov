using ACC.Data;
using AccountingSystem.Views.Shared;
using Microsoft.Reporting.WinForms;
using System;
using System.ComponentModel;
using System.Data;
using System.Windows.Forms;

namespace AccountingSystem.Views.Reports.RptReports
{
    public partial class frmListOfRealPropertyTaxDelinquenciesReport : Form
    {
        private ReportViewer reportViewer;
        private DataTable dataTable;
        internal string _ownerName = string.Empty;

        public frmListOfRealPropertyTaxDelinquenciesReport()
        {
            InitializeComponent();
            Helper.LoadFormIcon(this);
            reportViewer = new ReportViewer();
            panel2.Controls.Add(reportViewer);
            reportViewer.Dock = DockStyle.Fill;
            cmbxLoadBy.SelectedIndex = 0;
        }

        private void LoadBarangays()
        {
            var dtBarangays = AccFactory.RptAssessmentPostsRepository().GetBarangayRecords();
            cmbxLoadBy.DataSource = dtBarangays;
            cmbxLoadBy.ValueMember = "id";
            cmbxLoadBy.DisplayMember = "barangay_name";
        }

        private void LoadTaxpayers()
        {
            var dtTaxpayers = AccFactory.TaxpayersRepository().GetRecords();
            cmbxLoadBy.DataSource = dtTaxpayers;
            cmbxLoadBy.ValueMember = "id";
            cmbxLoadBy.DisplayMember = "name";
        }

        private void frmListOfRealPropertyTaxDelinquenciesReport_Load(object sender, EventArgs e)
        {
        }

        private bool LoadReport(LocalReport localReport)
        {
            try
            {
                string lguName = Helper.LGUDetails()["lgu_name"];
                DateTime asOfDate = dtTo.Value.Date;

                var reportParameters = new ReportParameter[]
                {
                    new ReportParameter("paramLGUName", lguName),
                    new ReportParameter("paramAsOf", asOfDate.ToString())
                };

                localReport.ReportPath = $"{Application.StartupPath}\\Reports\\list_of_real-property-tax-delinquencies.rdlc";
                localReport.SetParameters(reportParameters);

                localReport.DataSources.Clear();
                localReport.DataSources.Add(new ReportDataSource("dtListOfRealPropertyTaxDelinquencies", dataTable));

                reportViewer.SetDisplayMode(DisplayMode.PrintLayout);
                reportViewer.ZoomMode = ZoomMode.PageWidth;
                reportViewer.ZoomPercent = 100;

                reportViewer.RefreshReport();

                return true;
            }
            catch (Exception ex)
            {
                Helper.MessageBoxError(ex.StackTrace);
            }
            return false;
        }

        private decimal GetPenalty(string completeArpNo, int assessmentYear, DateTime assessmentPostedAt, DateTime paymentPostedAt, int effectivityYear, decimal penaltyRate, decimal taxDueAmount)
        {
            var paymenPostDate = Convert.ToDateTime(paymentPostedAt);
            int previousAssessmentCount = 0;
            //int delinquentMonths = RealPropertyTaxComputations.GetSelectedMonthsDelinquent(assessmentYear, assessmentPostedAt, paymenPostDate, effectivityYear, previousAssessmentCount);

            return RealPropertyTaxComputations.GetPenalty(penaltyRate, 0, taxDueAmount);
        }

        private void LoadReports()
        {
            var dataSet = new dsLFS.dtListOfRealPropertyTaxDelinquenciesDataTable();

            var dataTable = new DataTable();

            int recordCount = dataTable.Rows.Count;
            int rowsCount = 0;

            foreach (DataRow row in dataTable.Rows)
            {
                var newRow = dataSet.NewRow();
                string rowOwnerName = row["taxpayer_name"].ToString();
                string rowLotNo = row["lot_no"].ToString();
                string rowArpNo = row["complete_arp_no"].ToString();
                decimal rowAssessedValue = Convert.ToDecimal(row["assessed_value"]);
                DateTime rowPostedAt = Convert.ToDateTime(row["posted_at"]);
                int rowEffectivityYear = Convert.ToInt32(row["effectivity_year"]);
                decimal rowPenaltyRate = Convert.ToDecimal(row["penalty_rate"]);
                string rowRptPaymentPostId = row["rpt_payments_id"].ToString();
                int rowYear = Convert.ToInt32(row["year"]);

                decimal basicPenalty = 0;
                decimal sefPenalty = 0;

                string rowClassificationCode = row["classification_code"].ToString();

                decimal rowBasicRate = Convert.ToDecimal(row["basic_rate"]);
                decimal rowSefRate = Convert.ToDecimal(row["sef_rate"]);
                decimal basicTaxDueAmount = RealPropertyTaxComputations.GetBasicTaxDue(rowBasicRate, rowAssessedValue);
                decimal sefTaxDueAmount = RealPropertyTaxComputations.GetSefTaxDue(rowSefRate, rowAssessedValue);

                decimal total = basicTaxDueAmount + sefTaxDueAmount + basicPenalty + sefPenalty;

                //If there's a payment
                if (!string.IsNullOrEmpty(rowRptPaymentPostId))
                {
                    var rowPaymentPostsDate = Convert.ToDateTime(row["rpt_payments_posted_at"]);

                    basicPenalty = GetPenalty(rowArpNo, rowYear, rowPostedAt, rowPaymentPostsDate, rowEffectivityYear, rowPenaltyRate, basicTaxDueAmount);
                    sefPenalty = GetPenalty(rowArpNo, rowYear, rowPostedAt, rowPaymentPostsDate, rowEffectivityYear, rowPenaltyRate, sefTaxDueAmount);
                }

                newRow["declarant"] = rowOwnerName;
                newRow["lot_no"] = rowLotNo;
                newRow["arp_no"] = rowArpNo;
                newRow["assessed_value"] = rowAssessedValue;
                newRow["start_year"] = rowYear;
                newRow["basic_tax_due"] = basicTaxDueAmount;
                newRow["basic_penalty"] = basicPenalty;
                newRow["sef_tax_due"] = sefTaxDueAmount;
                newRow["sef_penalty"] = sefPenalty;
                newRow["total"] = total;
                newRow["remarks"] = rowClassificationCode;

                rowsCount++;
                int progressBarPercentage = (rowsCount * 100) / recordCount;
                backgroundWorker1.ReportProgress(progressBarPercentage);

                dataSet.Rows.Add(newRow);
            }
        }

        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
            try
            {
                Invoke((MethodInvoker)delegate
                  {
                      LoadReports();
                  });
            }
            catch (Exception ex) { Helper.MessageBoxError(ex.Message); }
        }

        private void backgroundWorker1_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            pbLoadRecords.Value = e.ProgressPercentage;
        }

        private void backgroundWorker1_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            LoadReport(reportViewer.LocalReport);
        }

        private void btnRetrieve_Click(object sender, EventArgs e)
        {
            try
            {
                if (!backgroundWorker1.IsBusy)
                {
                    pbLoadRecords.Value = 0;
                    backgroundWorker1.RunWorkerAsync();
                }
            }
            catch (Exception ex) { Helper.MessageBoxError(ex.Message); }
        }

        private void dtAsOf_ValueChanged(object sender, EventArgs e)
        {
        }
    }
}