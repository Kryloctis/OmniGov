using AccountingSystem.Views.Reports.RealPropertyTaxReports.RealPropertyTaxAccountRegister;
using AccountingSystem.Views.Shared;
using AccountingSystem.Views.Transactions.PaymentPosting;
using Microsoft.Reporting.WinForms;
using System;
using System.ComponentModel;
using System.Data;
using System.Windows.Forms;

namespace AccountingSystem.Views.Reports.RealPropertyTaxReports.ListOfRealPropertyTaxDelinquencies
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
            nudTaxYear.Value = Helper.GetCurrentDate().Year;
        }

        private void LoadBarangays()
        {
            var dtBarangays = AccFactory.RptAssessmentPostsRepository().Get_Grouped_Barangay_Records();
            cmbxBarangay.DataSource = dtBarangays;
            cmbxBarangay.DisplayMember = "barangay_name";
        }

        private void LoadMunicipalities()
        {
            var dtMunicipalities = AccFactory.RptAssessmentPostsRepository().Get_Grouped_Municipality_Records();
            cmbxMunicipality.DataSource = dtMunicipalities;
            cmbxMunicipality.DisplayMember = "municipality_name";
        }

        private void ShowHideButtons()
        {
            string selectedLoadBy = cmbxLoadBy.Text.Trim();

            switch (selectedLoadBy)
            {
                case "Taxpayer":
                    btnFindTaxPayer.Visible = true;
                    cmbxBarangay.Visible = false;
                    cmbxMunicipality.Visible = false;
                    taxPayerStatusStrip.Visible = true;
                    _ownerName = string.Empty;
                    break;

                case "Municipality":
                    cmbxMunicipality.Visible = true;
                    cmbxBarangay.Visible = false;
                    btnFindTaxPayer.Visible = false;
                    taxPayerStatusStrip.Visible = false;
                    _ownerName = string.Empty;
                    LoadMunicipalities();
                    break;

                case "Barangay":
                    cmbxBarangay.Visible = true;
                    btnFindTaxPayer.Visible = false;
                    cmbxMunicipality.Visible = false;
                    taxPayerStatusStrip.Visible = false;
                    _ownerName = string.Empty;
                    LoadBarangays();
                    break;

                default:
                    btnFindTaxPayer.Visible = false;
                    cmbxBarangay.Visible = false;
                    cmbxMunicipality.Visible = false;
                    taxPayerStatusStrip.Visible = false;
                    _ownerName = string.Empty;
                    break;
            }
        }

        private void chkbxTaxYear_CheckedChanged(object sender, EventArgs e) => nudTaxYear.Enabled = chkbxTaxYear.Checked;

        private void cmbxLoadBy_SelectedValueChanged(object sender, EventArgs e) => ShowHideButtons();

        private void frmListOfRealPropertyTaxDelinquenciesReport_Load(object sender, EventArgs e)
        {
            nudTaxYear.Enabled = chkbxTaxYear.Checked;
        }

        #region LoadReport

        private bool LoadReport(LocalReport localReport)
        {
            try
            {
                lblTaxPayerName.Text = _ownerName;
                string lguName = Helper.LGUDetails()["lgu_name"];
                DateTime asOfDate = dtAsOf.Value.Date;

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

        private DataTable ReferenceDataTable()
        {
            DataTable dataTable = new DataTable();

            try
            {
                string selectedLoadBy = cmbxLoadBy.Text.Trim();
                string barangayName = cmbxBarangay.Text.Trim();
                string municipalityName = cmbxMunicipality.Text.Trim();
                int? taxYear = nudTaxYear.Enabled ? (int)nudTaxYear.Value : null;
                DateTime asOfDate = dtAsOf.Value;

                var dtViewListOfRealPropertyTaxDelinquencesByTaxpayer = AccFactory.RptAssessmentPostsRepository().Get_View_List_Of_Real_Property_Tax_Delinquences_By_Taxpayer_AsOfDate_TaxYear(_ownerName, asOfDate, taxYear);
                var dtViewListOfRealPropertyTaxDelinquencesByBarangayName = AccFactory.RptAssessmentPostsRepository().Get_View_List_Of_Real_Property_Tax_Delinquences_By_BarangayName_AsOfDate_TaxYear(barangayName, asOfDate, taxYear);
                var dtViewListOfRealPropertyTaxDelinquencesByMunicipality = AccFactory.RptAssessmentPostsRepository().Get_View_List_Of_Real_Property_Tax_Delinquences_By_Municipality_AsOfDate_TaxYear(municipalityName, asOfDate, taxYear);

                switch (selectedLoadBy)
                {
                    case "Taxpayer":
                        dataTable = dtViewListOfRealPropertyTaxDelinquencesByTaxpayer;
                        break;

                    case "Municipality":
                        dataTable = dtViewListOfRealPropertyTaxDelinquencesByMunicipality;
                        break;

                    case "Barangay":
                        dataTable = dtViewListOfRealPropertyTaxDelinquencesByBarangayName;
                        break;

                    default:
                        dataTable = null;
                        break;
                }

                return dataTable;
            }
            catch (Exception ex)
            {
                Helper.MessageBoxError(ex.Message);
            }

            return dataTable;
        }

        private decimal GetPenalty(string completeArpNo, int assessmentYear, DateTime assessmentPostedAt, DateTime paymentPostedAt, int effectivityYear, decimal penaltyRate, decimal taxDueAmount)
        {
            var paymenPostDate = Convert.ToDateTime(paymentPostedAt);
            int previousAssessmentCount = AccFactory.RptAssessmentPostsRepository().PreviousAssessmentPostCount(completeArpNo, assessmentYear);
            int delinquentMonths = RealPropertyTaxComputations.GetSelectedMonthsDelinquent(assessmentYear, assessmentPostedAt, paymenPostDate, effectivityYear, previousAssessmentCount);

            return RealPropertyTaxComputations.GetPenalty(penaltyRate, delinquentMonths, taxDueAmount);
        }

        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
            try
            {
                dataTable = new dsLFS.dtListOfRealPropertyTaxDelinquenciesDataTable();

                DataTable referenceDatTable = new DataTable();
                Invoke((MethodInvoker)delegate { referenceDatTable = ReferenceDataTable(); });

                foreach (DataRow row in referenceDatTable.Rows)
                {
                    var newRow = dataTable.NewRow();
                    string rowOwnerName = row["owner_name"].ToString();
                    string rowLotNo = row["lot_no"].ToString();
                    string rowArpNo = row["complete_arp_no"].ToString();
                    decimal rowAssessedValue = Convert.ToDecimal(row["assessed_value"]);
                    DateTime rowPostedAt = Convert.ToDateTime(row["posted_at"]);
                    int rowEffectivityYear = Convert.ToInt32(row["effectivity_year"]);
                    decimal rowPenaltyRate = Convert.ToDecimal(row["penalty_rate"]);
                    string rowRptPaymentPostId = row["rpt_payment_posts_id"].ToString();
                    int rowYear = Convert.ToInt32(row["year"]);

                    decimal basicPenalty = 0;
                    decimal sefPenalty = 0;

                    string rowClassificationCode = row["classification_code"].ToString();

                    #region Tax Due

                    decimal rowBasicRate = Convert.ToDecimal(row["basic_rate"]);
                    decimal rowSefRate = Convert.ToDecimal(row["sef_rate"]);
                    decimal basicTaxDueAmount = RealPropertyTaxComputations.GetBasicTaxDue(rowBasicRate, rowAssessedValue);
                    decimal sefTaxDueAmount = RealPropertyTaxComputations.GetSefTaxDue(rowSefRate, rowAssessedValue);

                    #endregion Tax Due

                    decimal total = basicTaxDueAmount + sefTaxDueAmount + basicPenalty + sefPenalty;

                    //If there's a payment
                    if (!string.IsNullOrEmpty(rowRptPaymentPostId))
                    {
                        var rowPaymentPostsDate = Convert.ToDateTime(row["rpt_payment_posts_posted_at"]);

                        #region Penalty

                        basicPenalty = GetPenalty(rowArpNo, rowYear, rowPostedAt, rowPaymentPostsDate, rowEffectivityYear, rowPenaltyRate, basicTaxDueAmount);
                        sefPenalty = GetPenalty(rowArpNo, rowYear, rowPostedAt, rowPaymentPostsDate, rowEffectivityYear, rowPenaltyRate, sefTaxDueAmount);

                        #endregion Penalty
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

                    dataTable.Rows.Add(newRow);
                }
            }
            catch (Exception ex)
            {
                Helper.MessageBoxError(ex.Message);
            }
        }

        private void backgroundWorker1_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
        }

        private void backgroundWorker1_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            LoadReport(reportViewer.LocalReport);
        }

        #endregion LoadReport

        private void btnRetrieve_Click(object sender, EventArgs e)
        {
            backgroundWorker1.RunWorkerAsync();
        }

        private void dtAsOf_ValueChanged(object sender, EventArgs e)
        {
            nudTaxYear.Maximum = dtAsOf.Value.Year;
            nudTaxYear.Value = dtAsOf.Value.Year;
        }

        private void btnFindTaxPayer_Click(object sender, EventArgs e)
        {
            _ = new frmRptTaxPayerList(null, null, this, null ).ShowDialog();
        }
    }
}