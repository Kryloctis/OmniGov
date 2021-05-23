using ACC.Domain.Interfaces;
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

namespace AccountingSystem.Views.Reports.SAAOB
{
    public partial class frmSAAOB : Form
    {
        private readonly ReportViewer reportViewer;

        public frmSAAOB()
        {
            InitializeComponent();
            reportViewer = new ReportViewer();
            reportViewer.Dock = DockStyle.Fill;
            reportViewer.ShowPrintButton = false;
            panel2.Controls.Add(reportViewer);
            panelConfig.Enabled = false;
        }

        private void LoadFunds() 
        {
            try
            {
                var dtFunds = Factory.FundsRepository().GetRecords();

                HelperLoadRecords.FundsComboBox(dtFunds, cmbxFund, "fund_name", "id");

            }
            catch (Exception ex)
            {
                Helper.MessageBoxError(ex.Message);
            }
        }

        private DataTable DatatableSAAOB() 
        {

            var dataSet = new dsLFS();
            DataTable dtSAAOB = dataSet.dtSAAOB;

            int fundId = Convert.ToInt32(cmbxFund.SelectedValue);
            DateTime date = dtAsOf.Value;
            short year = Convert.ToInt16(dtAsOf.Value.Year);

            var dtBudgetAppropriations = Factory.BudgetAppropriationsRepository().GetViewRecordsByFundIdDateYear(fundId, date, year);


            foreach (DataRow item in dtBudgetAppropriations.Rows)
            {
                int rowBudgetAppropriationId = Convert.ToInt32(item["id"]);
                int rowFundId = Convert.ToInt32(item["funds_id"]);
                string rowFundCode = item["fund_code"].ToString();
                string rowFundName = item["fund_name"].ToString();
                int rowFPPId = Convert.ToInt32(item["fpp_id"]);
                string rowFPPCode = item["fpp_code"].ToString();
                string rowFPPName = item["fpp_name"].ToString();
                int rowFunctionalClassificationServiceId = Convert.ToInt32(item["functional_classification_service_id"]);
                string rowFunctionalClassificationServiceName = item["functional_classification_service_name"].ToString();
                int rowFunctionalClassificationId = Convert.ToInt32(item["functional_classification_id"]);
                string rowFunctionalClassificationSectorCode = item["functional_classification_sector_code"].ToString();
                string rowFunctionalClassificationSectorName = item["functional_classification_sector_name"].ToString();
                string rowOtherFPPId = item["others_fpp_id"] == null? string.Empty : item["others_fpp_id"].ToString();
                string rowOtherFPPName = item["others_fpp_name"].ToString();
                int rowAllotmentClassId = Convert.ToInt32(item["allotment_class_id"]);
                string rowAllotmentClassCode = item["allotment_class_code"].ToString();
                string rowAllotmentClassName = item["allotment_class_name"].ToString();
                string rowAccountCode = item["account_code"].ToString();
                string rowAccountName = item["general_ledger_accounts_name"].ToString();
                short rowYear = Convert.ToInt16(item["year"]);
                int rowAccountId = Convert.ToInt32(item["general_ledger_accounts_id"]);



                //Total budget Appropriation Amount
                decimal budgetAppropriationAmount = Convert.ToDecimal(item["amount"]);
                decimal totalSupplementalAmount = Factory.SupplementalAppropriationsRepository().GetTotalSupplementalAmountByIdAndDateEntry(rowBudgetAppropriationId, date);

                decimal totalBudetAppropriations = budgetAppropriationAmount + totalSupplementalAmount;

                //Total Allotment Release
                decimal totalAllotmentRelease = Factory.AllotmentReleaseRepository().GetViewTotalAllotmentReleaseByIdDateYear(rowBudgetAppropriationId, date, year);


                //Total Obligations
                decimal totalObligations = Factory.ObligationRequestRepository().TotalObligationRequestByDateYear(rowFundId, rowFPPId, string.IsNullOrEmpty(rowOtherFPPId)? null : Convert.ToInt32(rowOtherFPPId), rowAllotmentClassId, rowAccountId, date, year);

                //BudgetAppropriation Balance   
                decimal unObligatedBalance = totalAllotmentRelease - totalObligations;

                var items = new object[]
                {
                    rowFundId, rowFundCode, rowFundName, rowFunctionalClassificationId, rowFunctionalClassificationSectorCode, rowFunctionalClassificationSectorName, rowFunctionalClassificationServiceId, rowFunctionalClassificationServiceName, rowFPPId, rowFPPCode, rowFPPName, rowOtherFPPId, rowOtherFPPName, rowAllotmentClassId, rowAllotmentClassCode, rowAllotmentClassName, rowAccountCode, rowAccountName, rowYear, totalBudetAppropriations, totalAllotmentRelease, totalObligations, unObligatedBalance
                };

                dtSAAOB.Rows.Add(items);
            }

            return dtSAAOB;
        }


        private void FilterReport(int filterLevel, LocalReport report) 
        {
            var parameters = new[] {
                    new ReportParameter("paramFilterLevel",filterLevel.ToString())
                };

            report.SetParameters(parameters);

            reportViewer.RefreshReport();
        }

        private bool LoadReport(LocalReport report) 
        {
            try
            {
                int fundId = Convert.ToInt32(cmbxFund.SelectedValue);
                DateTime AsOf = dtAsOf.Value;

                //var dtSAAOB = Factory.BudgetAppropriationsRepository().GetViewRecordsSAAOB(fppID, year);

                reportViewer.SetDisplayMode(DisplayMode.PrintLayout);
                reportViewer.ZoomMode = ZoomMode.Percent;
                reportViewer.ZoomPercent = 100;

                string userName = $"{Helper.LoggedInUserData()["first_name"]} {Helper.LoggedInUserData()["mid_initial"]} {Helper.LoggedInUserData()["last_name"]}";
                string userRoleName = $"{Helper.LoggedInUserData()["role_name"]}";

                var fundRepo = Factory.FundsRepository().GetRecordByID(fundId);

                var parameters = new[] {

                    new ReportParameter("paramFundName", fundRepo["fund_name"]),
                    new ReportParameter("paramFundCode", fundRepo["fund_code"]),
                    new ReportParameter("paramDate", AsOf.ToString("MMM dd, yyyy")),
                    new ReportParameter("paramSignatoryName", userName),
                    new ReportParameter("paramSignatoryPosition", userRoleName),
                    new ReportParameter("paramFilterLevel","6")
                };

                report.ReportPath = $"{Application.StartupPath}\\Reports\\status-of-appropriations-allotments-and-obligation.rdlc";
                report.DataSources.Clear();
                report.DataSources.Add(new ReportDataSource("dtSAAOB", DatatableSAAOB()));
                report.SetParameters(parameters);

                reportViewer.RefreshReport();

                return true;
            }
            catch (Exception ex)
            {
                Helper.MessageBoxError(ex.Message);
            }
            return false;
        }


        private void btnRetrieve_Click(object sender, EventArgs e)
        {
            if (LoadReport(reportViewer.LocalReport)) 
            {
                panelConfig.Enabled = true;
            }
        }

        private void frmSAAOB_Load(object sender, EventArgs e)
        {
            Helper.LoadFormIcon(this);
            LoadFunds();
        }

        private void btnOne_Click(object sender, EventArgs e)
        {
            FilterReport(1, reportViewer.LocalReport);
        }

        private void btnTwo_Click(object sender, EventArgs e)
        {
            FilterReport(2, reportViewer.LocalReport);
        }

        private void btnThree_Click(object sender, EventArgs e)
        {
            FilterReport(3, reportViewer.LocalReport);
        }

        private void btnFour_Click(object sender, EventArgs e)
        {
            FilterReport(4, reportViewer.LocalReport);
        }

        private void btnFive_Click(object sender, EventArgs e)
        {
            FilterReport(5, reportViewer.LocalReport);
        }

        private void chkBxAdvanceMode_CheckedChanged(object sender, EventArgs e)
        {
            if (chkBxAdvanceMode.Checked)
            {
                reportViewer.SetDisplayMode(DisplayMode.Normal);
                reportViewer.ZoomMode = ZoomMode.Percent;
                reportViewer.ZoomPercent = 100;
            }

            else
            {
                reportViewer.SetDisplayMode(DisplayMode.PrintLayout);
                reportViewer.ZoomMode = ZoomMode.Percent;
                reportViewer.ZoomPercent = 100;
            }
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            reportViewer.PrintDialog();
        }
    }
}
