using AccountingSystem.Views.Shared;
using Microsoft.Reporting.WinForms;
using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;

namespace AccountingSystem.Views.Reports.RealPropertyTaxReports.LTOM
{
    public partial class frmNoticeOfDelinquencyInThePaymentOfRPT : Form
    {

        private readonly ReportViewer reportViewer;
        private DataTable dataTable;

        public frmNoticeOfDelinquencyInThePaymentOfRPT()
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
            DataTable dataTable = new();

            try
            {
                var dtViewListOfRealPropertyTaxDelinquences = AccFactory.RptAssessmentPostsRepository().Get_View_List_Of_Real_Property_Tax_Delinquences();

                dataTable = dtViewListOfRealPropertyTaxDelinquences;

                return dataTable;
            }
            catch (Exception ex)
            {
                Helper.MessageBoxError(ex.Message);
            }

            return dataTable;
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
                    decimal rowTotalAssessedValue = Convert.ToDecimal(row["assessed_value"]);
                    var postedAt = Convert.ToDateTime(row["posted_at"]);
                    var asOfDate = dtAsOf.Value.Date;
                    var rowYearsOfDelinquency = (asOfDate - postedAt).Days / 30;


                    decimal sefRate = Convert.ToDecimal(row["sef_rate"]);
                    decimal basicRate = Convert.ToDecimal(row["basic_rate"]);
                    decimal penaltyRate = Convert.ToDecimal(row["penalty_rate"]);
                    int effectivityYear = Convert.ToInt32(row["effectivity_year"]);
                    int assessmentPostYear = Convert.ToInt32(row["year"]);


                    decimal sefTaxDue = RealPropertyTaxComputations.GetSefTaxDue(sefRate, rowTotalAssessedValue);
                    decimal basicTaxDue = RealPropertyTaxComputations.GetBasicTaxDue(basicRate, rowTotalAssessedValue);

                    //Apply Penalties
                    Dictionary<string, string> dictPreviousAssessmentPost = AccFactory.RptAssessmentPostsRepository().GetViewPreviousAssessmentPostRecord(rowARPNo, assessmentPostYear);

                    Dictionary<string, string> dictAssessmentPost = new Dictionary<string, string>();
                    dictAssessmentPost.Add("posted_at", postedAt.ToString());
                    dictAssessmentPost.Add("effectivity_year", effectivityYear.ToString());
                    dictAssessmentPost.Add("year", assessmentPostYear.ToString());

                    int monthsDelinquent = RealPropertyTaxComputations.GetCurrentMonthsDelinquent(dictAssessmentPost, asOfDate, dictPreviousAssessmentPost);
                    decimal basicPenalty = RealPropertyTaxComputations.GetPenalty(penaltyRate, monthsDelinquent, basicTaxDue);
                    decimal sefPenalty = RealPropertyTaxComputations.GetPenalty(penaltyRate, monthsDelinquent, sefTaxDue);

                    //Get discount rate
                    bool discountIsAdvance = false;
                    decimal discountRate = RealPropertyTaxComputations.GetDiscountRate(dictAssessmentPost, dictPreviousAssessmentPost, asOfDate, ref discountIsAdvance);

                    //Apply Discounts
                    decimal basicDiscount = RealPropertyTaxComputations.GetDiscount(discountRate, basicTaxDue);
                    decimal sefDiscount = RealPropertyTaxComputations.GetDiscount(discountRate, sefTaxDue);

                    decimal basicPenaltyDiscount = basicDiscount < 1 ? basicPenalty : -basicDiscount;
                    decimal sefPenaltyDiscount = sefDiscount < 1 ? sefPenalty : -sefDiscount;

                    decimal totalBasicPayment = (basicTaxDue + basicPenalty) - basicDiscount;
                    decimal totalSefPayment = (sefTaxDue + sefPenalty) - sefDiscount;

                    decimal rowTaxDue = totalBasicPayment + totalSefPayment;

                    newRow["declared_owner"] = rowOwnerName;
                    newRow["tax_declaration_number"] = rowARPNo;
                    newRow["location_of_property"] = rowPropertyLocation;
                    newRow["kind_of_property"] = rowKindOfProperty;
                    newRow["total_assessed_value"] = rowTotalAssessedValue;
                    //newRow["years_of_delinquence"] = rowYearsOfDelinquency;
                    newRow["years_of_delinquence"] = monthsDelinquent;
                    newRow["tax_due"] = rowTaxDue;

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

        private bool LoadReport(LocalReport localReport)
        {
            try
            {
                string lguName = Helper.LGUDetails()["lgu_name"];
                DateTime asOfDate = dtAsOf.Value.Date;

                var reportParameters = new ReportParameter[]
                {
                    new ReportParameter("paramLGU", lguName),
                    new ReportParameter("paramAsOf", asOfDate.ToString())
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
