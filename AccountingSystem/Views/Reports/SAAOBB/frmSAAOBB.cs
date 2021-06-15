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

namespace AccountingSystem.Views.Reports.SAAOBB
{
    public partial class frmSAAOBB : Form
    {
        private readonly ReportViewer reportViewer;

        public frmSAAOBB()
        {
            InitializeComponent();
            Helper.LoadFormIcon(this);
            reportViewer = new ReportViewer();
            reportViewer.Dock = DockStyle.Fill;
            panelReport.Controls.Add(reportViewer);
            dtAsOf.Value = DateTime.Now;
        }

        private DataTable DatatableSAAOBB()
        {

            var dataSet = new dsLFS();  
            DataTable dtSAAOBB = dataSet.dtSAAOBB;

            int fundId = Convert.ToInt32(cmbxFund.SelectedValue);
            DateTime date = dtAsOf.Value;
            short year = Convert.ToInt16(dtAsOf.Value.Year);


            //Get Current Records
            var dtCurrentBudgetAppropriations = Factory.BudgetAppropriationsRepository().GetViewRecordsByFundIdDate(fundId, date);

           foreach (DataRow item in dtCurrentBudgetAppropriations.Rows)
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
                string rowOtherFPPId = item["others_fpp_id"] == null ? string.Empty : item["others_fpp_id"].ToString();
                string rowOtherFPPName = item["others_fpp_name"].ToString();
                int rowAllotmentClassId = Convert.ToInt32(item["allotment_class_id"]);
                string rowAllotmentClassCode = item["allotment_class_code"].ToString();
                string rowAllotmentClassName = item["allotment_class_name"].ToString();
                string rowAccountCode = item["account_code"].ToString();
                string rowAccountName = item["general_ledger_accounts_name"].ToString();
                short rowYear = Convert.ToInt16(item["year"]);
                int rowAccountId = Convert.ToInt32(item["general_ledger_accounts_id"]);
                bool isContinuing = Convert.ToBoolean(item["continuing"]);


  
                //Total budget Appropriation Amount
                decimal budgetAppropriationAmount = Convert.ToDecimal(item["amount"]);
                decimal totalSupplementalAmount = Factory.SupplementalAppropriationsRepository().GetTotalSupplementalAmountByIdAndDateEntry(rowBudgetAppropriationId, date);

                decimal totalBudetAppropriations = budgetAppropriationAmount + totalSupplementalAmount;

                //Total Allotment Release
                decimal totalAllotmentRelease = 0;


                //Total Obligations
                decimal totalObligations = Factory.ObligationRequestRepository().TotalObligationRequestByDateYear(rowFundId, rowFPPId, string.IsNullOrEmpty(rowOtherFPPId) ? null : Convert.ToInt32(rowOtherFPPId), rowAllotmentClassId, rowAccountId, date, year);

                //Budget Appropriation Balance
                decimal budgetAppropriationBalance = totalBudetAppropriations - totalObligations;

                //Allotment Release Balance   
                decimal allotmentReleaseBalance = totalAllotmentRelease - totalObligations;

                var items = new object[]
                {
                    rowFundId, rowFundCode, rowFundName, rowFunctionalClassificationId, rowFunctionalClassificationSectorCode, rowFunctionalClassificationSectorName, rowFunctionalClassificationServiceId, rowFunctionalClassificationServiceName, rowFPPId, rowFPPCode, rowFPPName, rowOtherFPPId, rowOtherFPPName, rowAllotmentClassId, rowAllotmentClassCode, rowAllotmentClassName, rowAccountCode, rowAccountName, rowYear, totalBudetAppropriations, budgetAppropriationBalance, totalAllotmentRelease, totalObligations, allotmentReleaseBalance, isContinuing
                };


                if (isContinuing == true)
                    dtSAAOBB.Rows.Add(items);
                else if(rowYear == dtAsOf.Value.Year)
                    dtSAAOBB.Rows.Add(items);
            }

            return dtSAAOBB;
        }


        private bool LoadReport(LocalReport report)
        {
            try
            {
                int fundId = Convert.ToInt32(cmbxFund.SelectedValue);
                DateTime AsOf = dtAsOf.Value;


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
                };

                report.ReportPath = $"{Application.StartupPath}\\Reports\\statement-of-appropriations-allotments-obligations-and-balances.rdlc";
                report.DataSources.Clear();
                report.DataSources.Add(new ReportDataSource("dtSAAOBB", DatatableSAAOBB()));
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

        private void frmSAAOBB_Load(object sender, EventArgs e)
        {
            LoadFunds();
        }

        private void btnRetrieve_Click(object sender, EventArgs e)
        {
            LoadReport(reportViewer.LocalReport);
        }
    }
}
