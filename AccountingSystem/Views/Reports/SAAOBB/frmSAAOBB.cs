using Microsoft.Reporting.WinForms;
using System;
using System.Collections.Generic;
using System.Data;
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
            int ffpIsSpecial = chkbxSpecialAccounts.Checked ? 1 : 0;

            //Get Current Records
            var dtBudgetAppropriations = AccFactory.BudgetAppropriationsRepository().GetViewRecords(fundId, date, (byte)ffpIsSpecial);

            foreach (DataRow item in dtBudgetAppropriations.Rows)
            {
                int rowBudgetAppropriationId = Convert.ToInt32(item["id"]);

                //FUND
                int rowFundId = Convert.ToInt32(item["funds_id"]);
                string rowFundCode = item["fund_code"].ToString();
                string rowFundName = item["fund_name"].ToString();

                //FUNCTION CLASSIFICATION
                int rowFunctionalClassificationId = Convert.ToInt32(item["functional_classification_id"]);
                string rowFunctionalClassificationSectorCode = item["functional_classification_sector_code"].ToString();
                string rowFunctionalClassificationSectorName = item["functional_classification_sector_name"].ToString();

                //FUNCTION CLASSIFICATION SERVICE
                int rowFunctionalClassificationServiceId = Convert.ToInt32(item["functional_classification_service_id"]);
                string rowFunctionalClassificationServiceName = item["functional_classification_service_name"].ToString();

                //FPP
                int rowFPPId = Convert.ToInt32(item["fpp_id"]);
                string rowFPPCode = item["fpp_code"].ToString();
                string rowFPPName = item["fpp_name"].ToString();
                byte rowFPPSpecial = Convert.ToByte(item["fpp_is_special"]);

                //SUB FPP
                string rowSubFPPId = item["others_fpp_id"] == null ? string.Empty : item["others_fpp_id"].ToString();
                string rowSubFPPCode = item["others_fpp_code"].ToString();
                string rowSubFPPName = item["others_fpp_name"].ToString();

                //ALLOTMENT CLASS
                int rowAllotmentClassId = Convert.ToInt32(item["allotment_class_id"]);
                string rowAllotmentClassCode = item["allotment_class_code"].ToString();
                string rowAllotmentClassName = item["allotment_class_name"].ToString();

                //ACCOUNT
                int rowAccountId = Convert.ToInt32(item["general_ledger_accounts_id"]);
                string rowAccountCode = item["account_code"].ToString();
                string rowAccountName = item["general_ledger_accounts_name"].ToString();

                short rowYear = Convert.ToInt16(item["year"]);
                string rowRemarks = item["remarks"].ToString();
                bool rowIsContinuing = Convert.ToBoolean(item["continuing"]);

                //TOTAL APPROPRIATIONS
                var dtSupplemtedAmount = AccFactory.SupplementalAppropriationsRepository().GetRecordsByBudgetAppropriationIdDateEntry(rowBudgetAppropriationId, date);
                decimal supplementedAmount = Convert.ToDecimal(dtSupplemtedAmount.Rows.Count == 0 ? 0 : dtSupplemtedAmount.Compute("SUM(amount)", string.Empty));

                decimal rowBudgetAppropriation = Convert.ToDecimal(item["amount"]);

                decimal TotalBudgetAppropraition = rowBudgetAppropriation + supplementedAmount;

                //ALLOTMENT RELEASE
                var dtAllotmentRelease = AccFactory.AllotmentReleaseRepository().GetViewRecordsByBudgetAppropriationIdDateIssued(rowBudgetAppropriationId, date);
                decimal allotmentReleaseAmount = Convert.ToDecimal(dtAllotmentRelease.Rows.Count == 0 ? 0 : dtAllotmentRelease.Compute("SUM(amount)", string.Empty));

                //OBLIGATIONS
                var dtObligation = AccFactory.ObligationRequestRepository().GetViewRecords(rowBudgetAppropriationId, date);
                decimal obligationRequestAmount = Convert.ToDecimal(dtObligation.Rows.Count == 0 ? 0 : dtObligation.Compute("SUM(amount)", string.Empty));

                //BALANCES OF APPROPRIATIONS
                decimal balancesOfAppropriationsAmount = TotalBudgetAppropraition - obligationRequestAmount;

                //BALANCES OF ALLOTMENTS
                decimal balancesOfAllotments = allotmentReleaseAmount - obligationRequestAmount;


                var items = new object[]
                {
                    rowFundId,
                    rowFundCode,
                    rowFundName,
                    rowFunctionalClassificationId,
                    rowFunctionalClassificationSectorCode,
                    rowFunctionalClassificationSectorName,
                    rowFunctionalClassificationServiceId,
                    rowFunctionalClassificationServiceName,
                    rowFPPId,
                    rowFPPCode,
                    rowFPPName,
                    rowFPPSpecial,
                    rowSubFPPId,
                    rowSubFPPCode,
                    rowSubFPPName,
                    rowAllotmentClassId,
                    rowAllotmentClassCode,
                    rowAllotmentClassName,
                    rowAccountId,
                    rowAccountCode,
                    rowAccountName,
                    rowYear,
                    rowRemarks,
                    rowIsContinuing,
                    TotalBudgetAppropraition,
                    balancesOfAppropriationsAmount,
                    allotmentReleaseAmount,
                    obligationRequestAmount,
                    balancesOfAllotments
                };

                if (rowIsContinuing == true)
                    dtSAAOBB.Rows.Add(items);
                else if (rowYear == dtAsOf.Value.Year)
                    dtSAAOBB.Rows.Add(items);
            }

            return dtSAAOBB;
        }

        private void ParseSignatory(Dictionary<string, string> dictSignatory, ref string signatoryName, ref string signatoryTitle)
        {
            if (dictSignatory.Count > 0)
            {
                signatoryName = dictSignatory["signatories_full_name"];
                signatoryTitle = dictSignatory["signatories_title"];
            }
        }

        private bool LoadReport(LocalReport report)
        {
            try
            {
                Cursor = Cursors.WaitCursor;
                var dictSignatory = Helper.GetSignatoryDataBy_Reference_DocumentName("Certified Correct", "SAAOBB");
                int fundId = Convert.ToInt32(cmbxFund.SelectedValue);
                DateTime AsOf = dtAsOf.Value;
                string certifiedCorrectSignatory = string.Empty;
                string certifiedCorrectSignatoryTitle = string.Empty;
                ParseSignatory(dictSignatory, ref certifiedCorrectSignatory, ref certifiedCorrectSignatoryTitle);

                var fundRepo = AccFactory.FundsRepository().GetRecordByID(fundId);

                var parameters = new[] {

                    new ReportParameter("paramFundName", fundRepo["fund_name"]),
                    new ReportParameter("paramFundCode", fundRepo["fund_code"]),
                    new ReportParameter("paramDate", AsOf.ToString("MMMM dd, yyyy")),
                    new ReportParameter("paramCertifiedCorrectSignatory", certifiedCorrectSignatory),
                    new ReportParameter("paramCertifiedCorrectSignatoryTitle", certifiedCorrectSignatoryTitle),
                };

                report.ReportPath = $"{Application.StartupPath}\\Reports\\statement-of-appropriations-allotments-obligations-and-balances.rdlc";
                report.DataSources.Clear();
                report.DataSources.Add(new ReportDataSource("dtSAAOBB", DatatableSAAOBB()));
                report.SetParameters(parameters);

                reportViewer.SetDisplayMode(DisplayMode.PrintLayout);
                reportViewer.ZoomMode = ZoomMode.Percent;
                reportViewer.ZoomPercent = 100;

                reportViewer.RefreshReport();
                Cursor = Cursors.Default;
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
                var dtFunds = AccFactory.FundsRepository().GetRecords();

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
