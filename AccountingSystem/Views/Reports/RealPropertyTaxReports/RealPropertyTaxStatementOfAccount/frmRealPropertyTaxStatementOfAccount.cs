using AccountingSystem.Views.Reports.RealPropertyTaxReports.ListOfRealPropertyTaxDelinquencies;
using AccountingSystem.Views.Reports.RealPropertyTaxReports.RealPropertyTaxAccountRegister;
using Microsoft.Reporting.WinForms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AccountingSystem.Views.Reports.RealPropertyTaxReports.RealPropertyTaxStatementOfAccount
{
    public partial class frmRealPropertyTaxStatementOfAccount : Form
    {
        public string OwnerTin { get; set; }
        public string OwnerName { get; set; }
        public string OwnerAddress { get; set; }

        private DataTable dtRealPropertyTaxStatementOfAccounts;
        internal ReportViewer reportViewer;

        public frmRealPropertyTaxStatementOfAccount()
        {
            InitializeComponent();
            Helper.LoadFormIcon(this);
            reportViewer = new ReportViewer();
            panel1.Controls.Add(reportViewer);
            reportViewer.Dock = DockStyle.Fill;
            //lblReportStatus.Text = string.Empty;
        }

        private void btnFindOwner_Click(object sender, EventArgs e)
        {
            _ = new frmRptTaxPayerList(null, this, null, null).ShowDialog();
        }

        private void frmRealPropertyTaxStatementOfAccount_Load(object sender, EventArgs e)
        {

        }

        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
            dtRealPropertyTaxStatementOfAccounts = new dsLFS.dtRPTStamentOfAccountsDataTable();

            //var dtAssessmentPosting = AccFactory.RptAssessmentPostsRepository().GetViewRptPropertyAssessmentsRecordsBy_OwnerName_Years(OwnerName, yearFrom, yearTo);

            //foreach (DataRow row in dtAssessmentPosting.Rows)
            //{
            //    var basicNewRow = dtRealPropertyTaxAccountRegister.NewRow();
            //    var sefRow = dtRealPropertyTaxAccountRegister.NewRow();

            //    string rowCompleteArpNo = row["complete_arp_no"].ToString();
            //    int rowYear = Convert.ToInt32(row["year"]);
            //    string rowPin = row["property_pin"].ToString();
            //    string rowBarangay = row["barangay_name"].ToString();
            //    string rowMunicipality = row["municipality_name"].ToString();
            //    string rowProvince = row["province_name"].ToString();
            //    string rowPropertyKind = row["property_kind"].ToString();
            //    string rowRptPaymentPostId = row["rpt_payment_posts_id"].ToString();
            //    decimal rowOtherImprovements = Convert.ToDecimal(row["other_improvements"]);
            //    decimal rowAssessedValue = Convert.ToDecimal(row["assessed_value"]);
            //    string rowReceiptNo = row["payment_collections_receipt_no"].ToString();
            //    string rowPayee = row["payment_collections_payee"].ToString();

            //    decimal landAssessdValue = rowPropertyKind == "L" ? (rowAssessedValue - rowOtherImprovements) : 0;
            //    decimal totalAssessedValue = rowAssessedValue;
            //    string paymentPeriod = "AN";
            //    decimal rowDiscountRate = Convert.ToDecimal(row["discount_rate"]);
            //    decimal rowPenaltyRate = Convert.ToDecimal(row["penalty_rate"]);
            //    DateTime rowPostedAt = Convert.ToDateTime(row["posted_at"]);
            //    int rowEffectivityYear = Convert.ToInt32(row["effectivity_year"]);
            //    bool rowIsCancelled = Convert.ToBoolean(Convert.ToByte(row["is_cancelled"]));
            //    decimal basicPenalty = 0;
            //    decimal sefPenalty = 0;

            //    #region Tax Due

            //    decimal rowBasicRate = Convert.ToDecimal(row["basic_rate"]);
            //    decimal rowSefRate = Convert.ToDecimal(row["sef_rate"]);
            //    decimal basicTaxDueAmount = taxDueComputations.GetBasicTaxDue(rowBasicRate, rowAssessedValue);
            //    decimal sefTaxDueAmount = taxDueComputations.GetSefTaxDue(rowSefRate, rowAssessedValue);

            //    #endregion Tax Due

            //    #region Discount

            //    decimal basicDiscount = taxDueComputations.GetDiscount(rowDiscountRate, basicTaxDueAmount);
            //    decimal sefDiscount = taxDueComputations.GetDiscount(rowDiscountRate, sefTaxDueAmount);

            //    #endregion Discount

            //    //If there's a payment
            //    if (!string.IsNullOrEmpty(rowRptPaymentPostId))
            //    {
            //        var rowPaymentPostsDate = Convert.ToDateTime(row["rpt_payment_posts_posted_at"]);

            //        #region Penalty

            //        basicPenalty = GetPenalty(rowCompleteArpNo, rowYear, rowPostedAt, rowPaymentPostsDate, rowEffectivityYear, rowPenaltyRate, basicTaxDueAmount);
            //        sefPenalty = GetPenalty(rowCompleteArpNo, rowYear, rowPostedAt, rowPaymentPostsDate, rowEffectivityYear, rowPenaltyRate, sefTaxDueAmount);

            //        #endregion Penalty

            //        //collection date
            //        var collectionDate = Convert.ToDateTime(row["payment_collections_payment_date"]);
            //        basicNewRow["date"] = collectionDate;
            //        sefRow["date"] = DBNull.Value;

            //        //BASIC
            //        basicNewRow["regular_tax_collected"] = basicTaxDueAmount;
            //        basicNewRow["discount_tax_collected"] = basicDiscount;
            //        basicNewRow["penalty_tax_collected"] = basicPenalty;

            //        //SEF
            //        sefRow["regular_tax_collected"] = sefTaxDueAmount;
            //        sefRow["discount_tax_collected"] = sefDiscount;
            //        sefRow["penalty_tax_collected"] = sefPenalty;
            //    }

            //    //BASIC
            //    basicNewRow["arp_no"] = rowCompleteArpNo;
            //    basicNewRow["pin"] = rowPin;
            //    basicNewRow["barangay"] = rowBarangay;
            //    basicNewRow["municipality"] = rowMunicipality;
            //    basicNewRow["province"] = rowProvince;
            //    basicNewRow["tax_year"] = rowYear;
            //    basicNewRow["land_assessed_value"] = landAssessdValue;
            //    basicNewRow["other_improvements"] = rowOtherImprovements;
            //    basicNewRow["total_assessed_value"] = totalAssessedValue;
            //    basicNewRow["payment_period"] = paymentPeriod;
            //    basicNewRow["tax_type"] = "Basic";
            //    basicNewRow["regular_tax_due"] = basicTaxDueAmount;
            //    basicNewRow["discount_tax_due"] = basicDiscount;
            //    basicNewRow["penalty_tax_due"] = basicPenalty;
            //    basicNewRow["or_number"] = rowReceiptNo;
            //    basicNewRow["payee"] = rowPayee;
            //    basicNewRow["is_cancelled"] = rowIsCancelled;

            //    //SEF
            //    sefRow["arp_no"] = rowCompleteArpNo;
            //    sefRow["pin"] = rowPin;
            //    sefRow["barangay"] = rowBarangay;
            //    sefRow["municipality"] = rowMunicipality;
            //    sefRow["province"] = rowProvince;
            //    sefRow["tax_year"] = rowYear;
            //    sefRow["land_assessed_value"] = landAssessdValue;
            //    sefRow["other_improvements"] = rowOtherImprovements;
            //    sefRow["total_assessed_value"] = totalAssessedValue;
            //    sefRow["payment_period"] = paymentPeriod;
            //    sefRow["tax_type"] = "SEF";
            //    sefRow["regular_tax_due"] = sefTaxDueAmount;
            //    sefRow["discount_tax_due"] = sefDiscount;
            //    sefRow["penalty_tax_due"] = sefPenalty;
            //    sefRow["or_number"] = string.Empty;
            //    sefRow["payee"] = string.Empty;
            //    sefRow["is_cancelled"] = rowIsCancelled;

            //    dtRealPropertyTaxAccountRegister.Rows.Add(basicNewRow);
            //    dtRealPropertyTaxAccountRegister.Rows.Add(sefRow);
            //}
        }

        private void backgroundWorker1_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            //lblReportStatus.Text = "Loading...";
        }

        private void backgroundWorker1_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            LoadReport();
            //if (LoadReport())
            //    lblReportStatus.Text = "Done.";
            //else
            //    lblReportStatus.Text = "Failed to load";
        }

        private bool LoadReport()
        {
            var localReport = reportViewer.LocalReport;
            var lguDetails = Helper.LGUDetails();

            var parameter = new ReportParameter[]
            {
                new ReportParameter("paramLGUName", lguDetails["lgu_name"]),
                new ReportParameter("paramOwner", OwnerName),
                new ReportParameter("paramOwerTin", OwnerTin),
                new ReportParameter("paramOwnerAddress", OwnerAddress),
                new ReportParameter("paramDate", Helper.GetCurrentDate().ToShortDateString())
            };

            localReport.ReportPath = $"{Application.StartupPath}\\Reports\\real-property-tax-statement-of-accounts.rdlc";

            localReport.DataSources.Clear();
            localReport.DataSources.Add(new ReportDataSource("dtRPTStamentOfAccounts", dtRealPropertyTaxStatementOfAccounts));

            localReport.SetParameters(parameter);

            reportViewer.SetDisplayMode(DisplayMode.PrintLayout);
            reportViewer.ZoomMode = ZoomMode.PageWidth;
            reportViewer.ZoomPercent = 100;

            reportViewer.RefreshReport();

            return true;

            try
            {

            }
            catch (Exception ex)
            {
                Helper.MessageBoxError(ex.Message);
            }
            return false;
        }
    }
}
