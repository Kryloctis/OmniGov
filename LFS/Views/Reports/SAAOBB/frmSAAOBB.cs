using ACC.Data;
using LFS.Helpers;
using Microsoft.Reporting.WinForms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Windows.Forms;

namespace LFS.Views.Reports.Saaobb
{
    public partial class frmSaaobb : Form
    {
        public frmSaaobb()
        {
            InitializeComponent();
            Helper.LoadFormIcon(this);
            panelReport.Controls.Add(reportViewer1);
            dtAsOf.Value = DateTime.Now;
        }

        private void ParseSignatory(Dictionary<string, string> dictSignatory, ref string signatoryName, ref string signatoryTitle)
        {
            if (dictSignatory.Count > 0)
            {
                signatoryName = dictSignatory["signatories_full_name"];
                signatoryTitle = dictSignatory["signatories_title"];
            }
        }

        private void LoadReport()
        {
            int fundId = Convert.ToInt32(cmbxFund.SelectedValue);
            DateTime AsOf = dtAsOf.Value;
            var workerArgs = (FundId: fundId, dtAsOf: AsOf);
            lblProgress.Text = "0%";
            backgroundWorker1.RunWorkerAsync(workerArgs);
        }

        private void LoadFunds()
        {
            var dtFunds = AccFactory.FundsRepository().GetRecords();
            HelperLoadRecords.FundsComboBox(dtFunds, cmbxFund, "id", "fund_name");
        }

        private void frmSAAOBB_Load(object sender, EventArgs e)
        {
            try
            {
                LoadFunds();
            }
            catch (Exception ex) { Helper.MessageBoxError(ex.Message); }
        }

        private void btnRetrieve_Click(object sender, EventArgs e)
        {
            try
            {
                LoadReport();
            }
            catch (Exception ex) { Helper.MessageBoxError(ex.StackTrace); }
        }

        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
            try
            {
                var args = ((int fundId, DateTime dtAsOf))e.Argument;

                DataTable dtSAAOBB = new dsLFS().dtSAAOBB;
                int ffpIsSpecial = chkbxSpecialAccounts.Checked ? 1 : 0;
                var dtBudgetAppropriations = AccFactory.BudgetAppropriationsRepository().GetViewRecords(args.fundId, args.dtAsOf, (byte)ffpIsSpecial);

                int totalProgress = dtBudgetAppropriations.AsEnumerable().Count(row => Convert.ToBoolean(row["continuing"]) || Convert.ToInt16(row["year"]) == args.dtAsOf.Year); ;

                int progressCount = 0;

                #region Data

                foreach (DataRow item in dtBudgetAppropriations.Rows)
                {
                    // Extract the Budget Appropriation ID from the data row
                    int rowBudgetAppropriationId = Convert.ToInt32(item["id"]);

                    // ================= FUND INFORMATION =================
                    // Extract fund-related data
                    int rowFundId = Convert.ToInt32(item["funds_id"]);
                    string rowFundCode = item["fund_code"].ToString();
                    string rowFundName = item["fund_name"].ToString();

                    // ================= FUNCTIONAL CLASSIFICATION =================
                    // Extract main classification information (sector)
                    int rowFunctionalClassificationId = Convert.ToInt32(item["functional_classification_id"]);
                    string rowFunctionalClassificationSectorCode = item["functional_classification_sector_code"].ToString();
                    string rowFunctionalClassificationSectorName = item["functional_classification_sector_name"].ToString();

                    // Extract functional service classification
                    int rowFunctionalClassificationServiceId = Convert.ToInt32(item["functional_classification_service_id"]);
                    string rowFunctionalClassificationServiceName = item["functional_classification_service_name"].ToString();

                    // ================= FPP INFORMATION =================
                    // FPP = Function, Programs, and Projects
                    int rowFPPId = Convert.ToInt32(item["fpp_id"]);
                    string rowFPPCode = item["fpp_code"].ToString();
                    string rowFPPName = item["fpp_name"].ToString();
                    byte rowFPPSpecial = Convert.ToByte(item["fpp_is_special"]); // 1 if special purpose, 0 otherwise

                    // ================= SUB-FPP INFORMATION =================
                    // Sub-categorization of FPP
                    string rowSubFPPId = item["others_fpp_id"] == null ? string.Empty : item["others_fpp_id"].ToString();
                    string rowSubFPPCode = item["others_fpp_code"].ToString();
                    string rowSubFPPName = item["others_fpp_name"].ToString();

                    // ================= ALLOTMENT CLASS =================
                    // Classifies the type of fund use: PS, MOOE, CO
                    int rowAllotmentClassId = Convert.ToInt32(item["allotment_class_id"]);
                    string rowAllotmentClassCode = item["allotment_class_code"].ToString();
                    string rowAllotmentClassName = item["allotment_class_name"].ToString();

                    // ================= ACCOUNT INFORMATION =================
                    // General ledger account details
                    int rowAccountId = Convert.ToInt32(item["general_ledger_accounts_id"]);
                    string rowAccountCode = item["account_code"].ToString();
                    string rowAccountName = item["general_ledger_accounts_name"].ToString();

                    // ================= OTHER BASIC DETAILS =================
                    short rowYear = Convert.ToInt16(item["year"]); // Year of the appropriation
                    string rowRemarks = item["remarks"].ToString(); // Additional notes
                    bool rowIsContinuing = Convert.ToBoolean(item["continuing"]); // True if continuing appropriation

                    // ================= SUPPLEMENTAL APPROPRIATIONS =================
                    // Fetch additional budget via supplemental appropriations
                    var dtSupplemtedAmount = AccFactory.SupplementalAppropriationsRepository()
                        .GetRecordsByBudgetAppropriationIdDateEntry(rowBudgetAppropriationId, args.dtAsOf);
                    decimal supplementedAmount = Convert.ToDecimal(
                        dtSupplemtedAmount.Rows.Count == 0 ? 0 : dtSupplemtedAmount.Compute("SUM(amount)", string.Empty)
                    );

                    // Original budget appropriation
                    decimal rowBudgetAppropriation = Convert.ToDecimal(item["amount"]);

                    // Total = original + supplemental
                    decimal TotalBudgetAppropraition = rowBudgetAppropriation + supplementedAmount;

                    // ================= ALLOTMENT RELEASE =================
                    // Fetch released allotment amounts (actual release)
                    var dtAllotmentRelease = AccFactory.AllotmentReleaseRepository()
                        .GetViewRecordsByBudgetAppropriationIdDateIssued(rowBudgetAppropriationId, args.dtAsOf);
                    decimal allotmentReleaseAmount = Convert.ToDecimal(
                        dtAllotmentRelease.Rows.Count == 0 ? 0 : dtAllotmentRelease.Compute("SUM(amount)", string.Empty)
                    );

                    // ================= OBLIGATIONS =================
                    // Fetch actual obligated amount (used budget)
                    var dtObligation = AccFactory.ObligationRequestRepository()
                        .GetViewRecords(rowBudgetAppropriationId, args.dtAsOf);
                    decimal obligationRequestAmount = Convert.ToDecimal(
                        dtObligation.Rows.Count == 0 ? 0 : dtObligation.Compute("SUM(amount)", string.Empty)
                    );

                    // ================= BALANCES =================
                    // Budget left after obligations
                    decimal balancesOfAppropriationsAmount = TotalBudgetAppropraition - obligationRequestAmount;

                    // Allotment left after obligations
                    decimal balancesOfAllotments = allotmentReleaseAmount - obligationRequestAmount;

                    // ================= AGGREGATE INTO ARRAY =================
                    // Package all extracted and calculated values into an array to be added as a row in DataTable
                    var items = new object[] { rowFundId, rowFundCode, rowFundName, rowFunctionalClassificationId, rowFunctionalClassificationSectorCode, rowFunctionalClassificationSectorName, rowFunctionalClassificationServiceId, rowFunctionalClassificationServiceName, rowFPPId, rowFPPCode, rowFPPName, rowFPPSpecial, rowSubFPPId, rowSubFPPCode, rowSubFPPName, rowAllotmentClassId, rowAllotmentClassCode, rowAllotmentClassName, rowAccountId, rowAccountCode, rowAccountName, rowYear, rowRemarks, rowIsContinuing, TotalBudgetAppropraition, balancesOfAppropriationsAmount, allotmentReleaseAmount, obligationRequestAmount, balancesOfAllotments };

                    // ================= DATA INSERTION =================
                    // Add to the DataTable (dtSAAOBB) only if:
                    // - The appropriation is marked as "continuing"
                    // OR
                    // - The appropriation belongs to the selected year
                    if (rowIsContinuing == true)
                    {
                        dtSAAOBB.Rows.Add(items);
                        progressCount++;
                        Helper.ProgressCounter(backgroundWorker1, totalProgress, progressCount); // Update UI progress
                    }
                    else if (rowYear == args.dtAsOf.Year)
                    {
                        dtSAAOBB.Rows.Add(items);
                        progressCount++;
                        Helper.ProgressCounter(backgroundWorker1, totalProgress, progressCount); // Update UI progress
                    }
                }

                #endregion Data

                ///Parameters
                var dictSignatory = Helper.GetSigtryByRefDoc("Certified Correct", "SAAOBB");
                string certifiedCorrectSignatory = string.Empty;
                string certifiedCorrectSignatoryTitle = string.Empty;
                ParseSignatory(dictSignatory, ref certifiedCorrectSignatory, ref certifiedCorrectSignatoryTitle);

                var fundRepo = AccFactory.FundsRepository().GetRecordByID(args.fundId);
                var parameters = new[]
                {
                    new ReportParameter("paramMunicipality", ServerHelper.selectedServer.MunicipalityName),
                    new ReportParameter("paramProvince", ServerHelper.selectedServer.ProvinceName),
                    new ReportParameter("paramFundName", fundRepo["fund_name"]),
                    new ReportParameter("paramFundCode", fundRepo["fund_code"]),
                    new ReportParameter("paramDate", args.dtAsOf.ToString("MMMM dd, yyyy")),
                    new ReportParameter("paramCertifiedCorrectSignatory", certifiedCorrectSignatory),
                    new ReportParameter("paramCertifiedCorrectSignatoryTitle", certifiedCorrectSignatoryTitle),
                };

                e.Result = (parameters, dtSAAOBB);
            }
            catch (Exception ex)
            {
                Helper.MessageBoxError($"An error occurred: {ex.Message}{Environment.NewLine}{ex.StackTrace}");
            }
        }

        private void backgroundWorker1_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            progressBar1.Value = e.ProgressPercentage;
            lblProgress.Text = $"{e.ProgressPercentage}%";
        }

        private void backgroundWorker1_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            try
            {
                // Cast the result of the background worker to a tuple:
                // - parameters: array of ReportParameter for filtering or headers
                // - dataTable: the actual data to be displayed in the report
                var result = ((ReportParameter[] parameters, DataTable dataTable))e.Result;

                // Reference the LocalReport instance of the ReportViewer control
                var localReport = reportViewer1.LocalReport;

                // Set the path to the RDLC report definition file (.rdlc)
                localReport.ReportPath = $"{Application.StartupPath}\\Reports\\statement-of-appropriations-allotments-obligations-and-balances.rdlc";

                // Clear any existing data sources attached to the report to avoid conflicts or duplication
                localReport.DataSources.Clear();

                // Add the new data source that contains the appropriation data (from result.dataTable)
                localReport.DataSources.Add(new ReportDataSource("dtSAAOBB", result.dataTable));

                // Set report parameters (e.g., filters like date range, fund, etc.)
                localReport.SetParameters(result.parameters);

                // Configure the display mode of the ReportViewer:
                // - Show the report in print layout
                // - Zoom to fit the page width
                reportViewer1.SetDisplayMode(DisplayMode.PrintLayout);
                reportViewer1.ZoomMode = ZoomMode.PageWidth;

                // Refresh the report to apply changes and display it
                reportViewer1.RefreshReport();

                // Update the progress label if all success conditions are met:
                // - Data table exists and has rows
                // - ReportViewer has data sources
                // - Report path is correctly pointing to the expected report
                if (result.dataTable != null &&
                    result.dataTable.Rows.Count > 0 &&
                    reportViewer1.LocalReport.DataSources.Count > 0 &&
                    reportViewer1.LocalReport.ReportPath != null &&
                    reportViewer1.LocalReport.ReportPath.EndsWith("statement-of-appropriations-allotments-obligations-and-balances.rdlc", StringComparison.OrdinalIgnoreCase))
                {
                    lblProgress.Text = "Done";
                }
            }
            catch (Exception ex)
            {
                // Handle any exceptions and show an error message box with the exception message and stack trace
                Helper.MessageBoxError($"An error occurred: {ex.Message}{Environment.NewLine}{ex.StackTrace}");
            }
        }
    }
}