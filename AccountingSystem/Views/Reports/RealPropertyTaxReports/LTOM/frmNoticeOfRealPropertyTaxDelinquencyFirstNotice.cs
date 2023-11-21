using ACC.Data;
using AccountingSystem.Views.Shared;
using Microsoft.Reporting.WinForms;
using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;

namespace AccountingSystem.Views.Reports.RealPropertyTaxReports.LTOM
{
    public partial class frmNoticeOfRealPropertyTaxDelinquencyFirstNotice : Form
    {
        private readonly ReportViewer reportViewer;
        private DataTable dataTable;

        internal int taxpayerID;
        private string declaredOwnerAddress;
        private string declaredOwners;
        private string taxDeclarationNo;
        private string TCTNo;
        private string locationOfProperty;
        private char kindOfProperty;
        private decimal assessedValue;

        public frmNoticeOfRealPropertyTaxDelinquencyFirstNotice()
        {
            InitializeComponent();
            Helper.LoadFormIcon(this);
            reportViewer = new ReportViewer();
            panel2.Controls.Add(reportViewer);
            reportViewer.Dock = DockStyle.Fill;
        }

        private void btnRetrieve_Click(object sender, System.EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtTaxpayerName.Text) && cmbxDelinquentProperties.SelectedIndex == -1)
                return;

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

                string signatoryName = string.Empty;
                string signatoryTitle = string.Empty;
                ParseSignatory(dictSignatory, ref signatoryName, ref signatoryTitle);

                var reportParameters = new ReportParameter[]
                {
                    new ReportParameter("paramLGU", lguName),
                    new ReportParameter("paramSignatory", signatoryName),
                    new ReportParameter("paramSignatoryTitle", signatoryTitle),
                    new ReportParameter("paramDeclaredOwner", declaredOwners),
                    new ReportParameter("paramCompleteAddress", declaredOwnerAddress),
                    new ReportParameter("paramDeclaredOwners", declaredOwners),
                    new ReportParameter("paramTaxDeclarationNo", taxDeclarationNo),
                    new ReportParameter("paramTCTNo", TCTNo),
                    new ReportParameter("paramLocationOfProperty", locationOfProperty),
                    new ReportParameter("paramKindOfProperty", kindOfProperty.ToString()),
                    new ReportParameter("paramAssessedValue", assessedValue.ToString("N"))
                };

                localReport.ReportPath = $"{Application.StartupPath}\\Reports\\LTOMs\\ltom-17-notice-of-real-property-tax-delinquency-first-notice.rdlc";
                localReport.SetParameters(reportParameters);

                localReport.DataSources.Clear();
                localReport.DataSources.Add(new ReportDataSource("dsNoticeOfRealPropertyTaxDelinquencyFirstNotice", dataTable));

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

        internal void PopulateDelinquentProperty()
        {
            try
            {
                var dtDeliquentProperties = AccFactory.RptAssessmentPostsRepository().Get_View_List_Of_Real_Property_Tax_Delinquences_By_TaxpayerID(taxpayerID);

                cmbxDelinquentProperties.DataSource = dtDeliquentProperties;
                cmbxDelinquentProperties.ValueMember = "rpt_assessment_posts_id";
                cmbxDelinquentProperties.DisplayMember = "complete_arp_no";

            }
            catch (Exception ex)
            {
                Helper.MessageBoxError(ex.Message);
            }

        }

        private DataTable ReferenceDataTable()
        {
            DataTable dataTable = new();

            try
            {
                int realPropertyID = Convert.ToInt32(cmbxDelinquentProperties.SelectedValue);
                var dtViewListOfRealPropertyTaxDelinquences = AccFactory.RptAssessmentPostsRepository().Get_View_List_Of_Real_Property_Tax_Delinquences_By_ID(realPropertyID);

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
                dataTable = new dsLTOM.dtNoticeOfRealPropertyTaxDelinquencyFirstNoticeDataTable();

                DataTable referenceDataTable = new DataTable();
                Invoke((MethodInvoker)delegate { referenceDataTable = ReferenceDataTable(); });

                int recordCount = referenceDataTable.Rows.Count;
                int rowsCount = 0;

                foreach (DataRow row in referenceDataTable.Rows)
                {
                    var newRow = dataTable.NewRow();

                    string rowOwnerName = row["taxpayer_name"].ToString();
                    string rowARPNo = row["complete_arp_no"].ToString();
                    string rowTCT = string.Empty;

                    string rowOwnerAddress = row["taxpayer_address"].ToString();
                    string rowPropertyStreet = row["street"].ToString();
                    string rowPropertyBarangay = row["barangay_name"].ToString();
                    string rowPropertyMunicipality = row["municipality_name"].ToString();
                    string rowPropertyProvince = row["province_name"].ToString();
                    string rowPropertyLocation = $"{rowPropertyStreet} {rowPropertyBarangay}, {rowPropertyMunicipality}, {rowPropertyProvince}";
                    string rowKindOfProperty = row["property_kind"].ToString();
                    int rowTaxYear = Convert.ToInt32(row["year"]);
                    decimal rowAssessedValue = Convert.ToDecimal(row["assessed_value"]);


                    decimal penaltyRate = Convert.ToDecimal(row["penalty_rate"]);
                    int effectivityYear = Convert.ToInt32(row["effectivity_year"]);
                    var postedAt = Convert.ToDateTime(row["posted_at"]);

                    //tax due
                    decimal sefRate = Convert.ToDecimal(row["sef_rate"]);
                    decimal basicRate = Convert.ToDecimal(row["basic_rate"]);

                    decimal sefTaxDue = RealPropertyTaxComputations.GetSefTaxDue(sefRate, rowAssessedValue);
                    decimal basicTaxDue = RealPropertyTaxComputations.GetBasicTaxDue(basicRate, rowAssessedValue);

                    //Apply Penalties
                    Dictionary<string, string> dictPreviousAssessmentPost = AccFactory.RptAssessmentPostsRepository().GetViewPreviousAssessmentPostRecord(row["complete_arp_no"].ToString(), rowTaxYear);

                    Dictionary<string, string> dictAssessmentPost = new Dictionary<string, string>();
                    dictAssessmentPost.Add("posted_at", postedAt.ToString());
                    dictAssessmentPost.Add("effectivity_year", effectivityYear.ToString());
                    dictAssessmentPost.Add("year", rowTaxYear.ToString());

                    int monthsDelinquent = RealPropertyTaxComputations.GetCurrentMonthsDelinquent(dictAssessmentPost, Helper.GetCurrentDate(), dictPreviousAssessmentPost);
                    decimal basicPenalty = RealPropertyTaxComputations.GetPenalty(penaltyRate, monthsDelinquent, basicTaxDue);
                    decimal sefPenalty = RealPropertyTaxComputations.GetPenalty(penaltyRate, monthsDelinquent, sefTaxDue);


                    declaredOwnerAddress = rowOwnerAddress;
                    declaredOwners = rowOwnerName;
                    taxDeclarationNo = rowARPNo;
                    TCTNo = rowTCT;
                    locationOfProperty = rowPropertyLocation;
                    kindOfProperty = Convert.ToChar(rowKindOfProperty);
                    assessedValue = rowAssessedValue;
                    decimal totalAmount = sefTaxDue + basicTaxDue + basicPenalty + sefPenalty;

                    newRow["tax_year"] = rowTaxYear;
                    newRow["basic_tax"] = basicTaxDue;
                    newRow["basic_penalty"] = basicPenalty;
                    newRow["sef_tax"] = sefTaxDue;
                    newRow["sef_penalty"] = sefPenalty;
                    newRow["total_amount"] = totalAmount;


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

        private void btnFindTaxPayer_Click(object sender, EventArgs e)
        {
            _ = new frmTaxPayerList(this).ShowDialog();
        }

    }
}
