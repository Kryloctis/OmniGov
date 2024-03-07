using ACC.Data;
using AccountingSystem.Views.Shared;
using Microsoft.Reporting.WinForms;
using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;

namespace AccountingSystem.Views.Reports.RealPropertyTaxReports.LTOM
{
    public partial class frmLtom16 : Form
    {
        private readonly ReportViewer reportViewer;
        private DataTable dataTable;

        public frmLtom16()
        {
            InitializeComponent();
            Helper.LoadFormIcon(this);
            reportViewer = new ReportViewer();
            panel2.Controls.Add(reportViewer);
            reportViewer.Dock = DockStyle.Fill;
        }

        private void frmNoticeOfDelinquencyInThePaymentOfRPT_Load(object sender, System.EventArgs e)
        {
        }

        private DataTable ReferenceDataTable()
        {
            return new DataTable();
        }

        private decimal GetTaxDue(DataRow row, ref int yearsDelinquent)
        {
            //var postedAt = Convert.ToDateTime(row["posted_at"]);
            //var asOfDate = dtAsOf.Value.Date;
            //decimal sefRate = Convert.ToDecimal(row["sef_rate"]);
            //decimal basicRate = Convert.ToDecimal(row["basic_rate"]);
            //decimal penaltyRate = Convert.ToDecimal(row["penalty_rate"]);
            //int effectivityYear = Convert.ToInt32(row["effectivity_year"]);
            //int assessmentPostYear = Convert.ToInt32(row["year"]);

            //decimal sefTaxDue = RealPropertyTaxComputations.GetSefTaxDue(sefRate, Convert.ToDecimal(row["assessed_value"]));
            //decimal basicTaxDue = RealPropertyTaxComputations.GetBasicTaxDue(basicRate, Convert.ToDecimal(row["assessed_value"]));

            ////Apply Penalties
            //Dictionary<string, string> dictPreviousAssessmentPost = AccFactory.RptAssessmentPostsRepository().GetViewPreviousAssessmentPostRecord(row["complete_arp_no"].ToString(), assessmentPostYear);

            //Dictionary<string, string> dictAssessmentPost = new Dictionary<string, string>();
            //dictAssessmentPost.Add("posted_at", postedAt.ToString());
            //dictAssessmentPost.Add("effectivity_year", effectivityYear.ToString());
            //dictAssessmentPost.Add("year", assessmentPostYear.ToString());

            //int monthsDelinquent = RealPropertyTaxComputations.GetCurrentMonthsDelinquent(dictAssessmentPost, asOfDate, dictPreviousAssessmentPost);
            //decimal basicPenalty = RealPropertyTaxComputations.GetPenalty(penaltyRate, monthsDelinquent, basicTaxDue);
            //decimal sefPenalty = RealPropertyTaxComputations.GetPenalty(penaltyRate, monthsDelinquent, sefTaxDue);

            ////Get discount rate
            //bool discountIsAdvance = false;
            //decimal discountRate = RealPropertyTaxComputations.GetDiscountRate(dictAssessmentPost, dictPreviousAssessmentPost, asOfDate, ref discountIsAdvance);

            ////Apply Discounts
            //decimal basicDiscount = RealPropertyTaxComputations.GetDiscount(discountRate, basicTaxDue);
            //decimal sefDiscount = RealPropertyTaxComputations.GetDiscount(discountRate, sefTaxDue);

            //decimal basicPenaltyDiscount = basicDiscount < 1 ? basicPenalty : -basicDiscount;
            //decimal sefPenaltyDiscount = sefDiscount < 1 ? sefPenalty : -sefDiscount;

            //decimal totalBasicPayment = (basicTaxDue + basicPenalty) - basicDiscount;
            //decimal totalSefPayment = (sefTaxDue + sefPenalty) - sefDiscount;

            //decimal rowTaxDue = totalBasicPayment + totalSefPayment;

            //yearsDelinquent = monthsDelinquent;

            //return rowTaxDue;
            return 0;
        }

        private void LoadReports()
        {
            try
            {
                dataTable = new dsLTOM.dtNoticeOfDelinquenceInThePaymentOfRPTDataTable();

                DataTable referenceDataTable = new DataTable();
                Invoke((MethodInvoker)delegate { referenceDataTable = ReferenceDataTable(); });

                int recordCount = referenceDataTable.Rows.Count;
                int rowsCount = 0;

                foreach (DataRow row in referenceDataTable.Rows)
                {
                    var newRow = dataTable.NewRow();

                    string rowOwnerName = row["taxpayer_name"].ToString();
                    string rowARPNo = row["complete_arp_no"].ToString();
                    string rowPropertyStreet = row["street"].ToString();
                    string rowPropertyBarangay = row["barangay_name"].ToString();
                    string rowPropertyMunicipality = row["municipality_name"].ToString();
                    string rowPropertyProvince = row["province_name"].ToString();
                    string rowPropertyLocation = $"{rowPropertyStreet} {rowPropertyBarangay}, {rowPropertyMunicipality}, {rowPropertyProvince}";
                    string rowKindOfProperty = row["property_kind"].ToString();
                    decimal rowAssessedValue = Convert.ToDecimal(row["assessed_value"]);
                    int yearsDelinquent = 0;

                    newRow["declared_owner"] = rowOwnerName;
                    newRow["tax_declaration_number"] = rowARPNo;
                    newRow["location_of_property"] = rowPropertyLocation;
                    newRow["kind_of_property"] = rowKindOfProperty;
                    newRow["total_assessed_value"] = rowAssessedValue;
                    newRow["tax_due"] = Convert.ToDecimal(GetTaxDue(row, ref yearsDelinquent));
                    newRow["years_of_delinquence"] = yearsDelinquent;

                    rowsCount++;
                    int progressBarPercentage = (rowsCount * 100) / recordCount;
                    backgroundWorker1.ReportProgress(progressBarPercentage);

                    dataTable.Rows.Add(newRow);
                }
            }
            catch (Exception ex)
            {
                Helper.MessageBoxError(ex.Message);
            }
        }

        private void ParseSignatory(Dictionary<string, string> dictSignatory, ref string signatoryName, ref string signatoryTitle)
        {
            if (dictSignatory.Count > 0)
            {
                signatoryName = dictSignatory["signatories_full_name"];
                signatoryTitle = dictSignatory["signatories_title"];
            }
        }

        private bool LoadReport(LocalReport localReport)
        {
            try
            {
                string lguName = Helper.LGUDetails()["lgu_name"];
                var dictSignatory = Helper.GetSignatoryDataBy_Reference_DocumentName("Treasurer", "Notice of Delinquency in the Payment of Real Property Tax");
                DateTime asOfDate = dtAsOf.Value.Date;

                string signatoryName = string.Empty;
                string signatoryTitle = string.Empty;
                ParseSignatory(dictSignatory, ref signatoryName, ref signatoryTitle);

                var reportParameters = new ReportParameter[]
                {
                    new ReportParameter("paramLGU", lguName),
                    new ReportParameter("paramAsOf", asOfDate.ToString()),
                    new ReportParameter("paramDate", asOfDate.ToString()),
                    new ReportParameter("paramSignatory", signatoryName),
                    new ReportParameter("paramSignatoryTitle", signatoryTitle)
                };

                localReport.ReportPath = $"{Application.StartupPath}\\Reports\\LTOMs\\notice-delinquency-in-the-payment-of-rpt.rdlc";
                localReport.SetParameters(reportParameters);

                localReport.DataSources.Clear();
                localReport.DataSources.Add(new ReportDataSource("dsNoticeOfRealPropertyTaxDelinquence", dataTable));

                reportViewer.SetDisplayMode(DisplayMode.PrintLayout);
                reportViewer.ZoomMode = ZoomMode.Percent;
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

        private void backgroundWorker1_DoWork(object sender, System.ComponentModel.DoWorkEventArgs e)
        {
            Invoke((MethodInvoker)delegate
            {
                LoadReports();
            });
        }

        private void backgroundWorker1_ProgressChanged(object sender, System.ComponentModel.ProgressChangedEventArgs e)
        {
            pbLoadRecords.Value = e.ProgressPercentage;
        }

        private void backgroundWorker1_RunWorkerCompleted(object sender, System.ComponentModel.RunWorkerCompletedEventArgs e)
        {
            LoadReport(reportViewer.LocalReport);
        }

        private void btnRetrieve_Click(object sender, System.EventArgs e)
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
    }
}