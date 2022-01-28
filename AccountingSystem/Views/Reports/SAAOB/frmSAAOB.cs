using Microsoft.Reporting.WinForms;
using System;
using System.Collections.Generic;
using System.Data;
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
            var dtSAAOB = dataSet.dtSAAOB;
            int fundId = Convert.ToInt32(cmbxFund.SelectedValue);
            DateTime date = dtAsOf.Value;
            short year = Convert.ToInt16(dtAsOf.Value.Year);
            int fppSpecial = chkbxSpecialFPP.Checked ? 1 : 0;

            try
            {
                var dtBudgetAppropriations = Factory.BudgetAppropriationsRepository().GetViewRecords(fundId, date, year, 0, (byte)fppSpecial);


                foreach (DataRow row in dtBudgetAppropriations.Rows)
                {
                    int rowBudgetAppropriationId = Convert.ToInt32(row["id"]);
                    int rowfundId = Convert.ToInt32(row["funds_id"]);
                    string rowFundCode = row["fund_code"].ToString();
                    string rowFundName = row["fund_name"].ToString();
                    int rowFunctionClassificationId = Convert.ToInt32(row["functional_classification_id"]);
                    string rowFunctionClassificationSectorCode = row["functional_classification_sector_code"].ToString();
                    string rowFunctionClassificationSectorName = row["functional_classification_sector_name"].ToString();
                    int rowFunctionClassificationServicesId = Convert.ToInt32(row["functional_classification_service_id"]);
                    string rowFunctionClassificationServicesName = row["functional_classification_service_name"].ToString();
                    int rowFPPId = Convert.ToInt32(row["fpp_id"]);
                    string rowFPPCode = row["fpp_code"].ToString();
                    string rowFPPName = row["fpp_name"].ToString();
                    var dictFPP = Factory.FunctionProgramProjectRepository().GetRecordByID(rowFPPId);
                    byte rowFPPIsSpecial = Convert.ToByte(dictFPP["is_special"]);
                    byte rowIsContinuing = Convert.ToByte(row["continuing"]);
                    string rowSubFPPId = row["others_fpp_id"].ToString();
                    string rowSubFPPCode = row["others_fpp_code"].ToString();
                    string rowSubFPPName = row["others_fpp_name"].ToString();
                    int rowAllotmentClassId = Convert.ToInt32(row["allotment_class_id"]);
                    string rowAllotmentClassCode = row["allotment_class_code"].ToString();
                    string rowAllotmentClassName = row["allotment_class_name"].ToString();
                    string rowAccountCode = row["account_code"].ToString();
                    string rowAccountName = row["general_ledger_accounts_name"].ToString();
                    short rowYear = Convert.ToInt16(row["year"]);
                    string rowRemarks = row["remarks"].ToString();
                    decimal rowAppropriation = Convert.ToDecimal(row["amount"]);

                    //SUPPLEMENTED AMOUNT
                    var dtSupplemtedAmount = Factory.SupplementalAppropriationsRepository().GetRecordsByBudgetAppropriationIdDateEntry(rowBudgetAppropriationId, date);
                    decimal supplementedAmount = Convert.ToDecimal(dtSupplemtedAmount.Rows.Count == 0 ? 0 : dtSupplemtedAmount.Compute("SUM(amount)", string.Empty));

                    decimal TotalBudgetAppropraition = rowAppropriation + supplementedAmount;

                    //ALLOTMENT RELEASE
                    var dtAllotmentRelease = Factory.AllotmentReleaseRepository().GetViewRecordsByBudgetAppropriationIdDateIssued(rowBudgetAppropriationId, date);
                    decimal allotmentReleaseAmount = Convert.ToDecimal(dtAllotmentRelease.Rows.Count == 0 ? 0 : dtAllotmentRelease.Compute("SUM(amount)", string.Empty));


                    //OBLIGATIONS
                    var dtObligation = Factory.ObligationRequestRepository().GetViewRecords(rowBudgetAppropriationId, date);
                    decimal obligationRequestAmount = Convert.ToDecimal(dtObligation.Rows.Count == 0 ? 0 : dtObligation.Compute("SUM(amount)", string.Empty));

                    //UNOBLIGATED BALANCE
                    decimal unobligatedBalance = allotmentReleaseAmount - obligationRequestAmount;

                    var items = new object[]
                    {
                    rowfundId,
                    rowFundCode,
                    rowFundName,
                    rowFunctionClassificationId,
                    rowFunctionClassificationSectorCode,
                    rowFunctionClassificationSectorName,
                    rowFunctionClassificationServicesId,
                    rowFunctionClassificationServicesName,
                    rowFPPId,
                    rowFPPCode,
                    rowFPPName,
                    rowFPPIsSpecial,
                    rowSubFPPId,
                    rowSubFPPCode,
                    rowSubFPPName,
                    rowAllotmentClassId,
                    rowAllotmentClassCode,
                    rowAllotmentClassName,
                    rowAccountCode,
                    rowAccountName,
                    rowYear,
                    rowRemarks,
                    TotalBudgetAppropraition,
                    allotmentReleaseAmount,
                    obligationRequestAmount,
                    unobligatedBalance
                    };

                    dtSAAOB.Rows.Add(items);
                }


            }
            catch (Exception ex)
            {
                Helper.MessageBoxError(ex.Message);
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

        private void ParseSignatory(Dictionary<string, string> dictSignatory, ref string signatory, ref string signatoryTitle)
        {
            if (dictSignatory.Count > 0)
            {
                signatory = dictSignatory["signatories_full_name"];
                signatoryTitle = dictSignatory["signatories_title"];
            }
        }

        private bool LoadReport(LocalReport report)
        {
            try
            {
                Cursor = Cursors.WaitCursor;

                var dictSignatory = Helper.GetSignatoryDataBy_Reference_DocumentName("Certified Correct", "SAAOB");
                string certifiedCorrectSignatory = string.Empty;
                string certifiedCorrectSignatoryTitle = string.Empty;
                ParseSignatory(dictSignatory, ref certifiedCorrectSignatory, ref certifiedCorrectSignatoryTitle);

                int fundId = Convert.ToInt32(cmbxFund.SelectedValue);
                DateTime AsOf = dtAsOf.Value;

                var fundRepo = Factory.FundsRepository().GetRecordByID(fundId);

                var parameters = new[] {
                    new ReportParameter("paramFundName", fundRepo["fund_name"]),
                    new ReportParameter("paramFundCode", fundRepo["fund_code"]),
                    new ReportParameter("paramDate", AsOf.ToString("MMMM dd, yyyy")),
                    new ReportParameter("paramCertifiedCorrectSignatory", certifiedCorrectSignatory),
                    new ReportParameter("paramCertifiedCorrectSignatoryTitle", certifiedCorrectSignatoryTitle),
                    new ReportParameter("paramFilterLevel","5"),
                    new ReportParameter("paramFPPIsSpecial", (chkbxSpecialFPP.Checked? 1 : 0).ToString())
                };

                report.ReportPath = $"{Application.StartupPath}\\Reports\\status-of-appropriations-allotments-and-obligation.rdlc";
                report.DataSources.Clear();
                report.DataSources.Add(new ReportDataSource("dtSAAOB", DatatableSAAOB()));
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


        //FILTER
        private void radBtn1_CheckedChanged(object sender, EventArgs e)
        {
            FilterReport(1, reportViewer.LocalReport);
        }

        private void radBtn2_CheckedChanged(object sender, EventArgs e)
        {
            FilterReport(2, reportViewer.LocalReport);
        }
        private void radBtn3_CheckedChanged(object sender, EventArgs e)
        {
            FilterReport(3, reportViewer.LocalReport);
        }

        private void radBtn4_CheckedChanged(object sender, EventArgs e)
        {
            FilterReport(4, reportViewer.LocalReport);
        }

        private void radBtn5_CheckedChanged(object sender, EventArgs e)
        {
            FilterReport(5, reportViewer.LocalReport);
        }

    }
}
