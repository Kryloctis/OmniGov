using Microsoft.Reporting.WinForms;
using OmniGov.App.Helpers;
using OmniGov.Budget.Data.Factories;
using OmniGov.Core.Factories;
using System.ComponentModel;
using System.Data;

namespace OmniGov.App.Budget.Views.Reports;

public partial class frmSAAO : Form
{
    public frmSAAO()
    {
        InitializeComponent();
        Helper.LoadFormIcon(this);
        reportViewer1.Dock = DockStyle.Fill;
        panel2.Controls.Add(reportViewer1);
        flwPnlCoverage.Enabled = false;
    }

    private void LoadFunds()
    {
        var dtFunds = Factory.FundsRepository().GetRecords();

        HelperLoadRecords.FundsComboBox(dtFunds, cmbxFund, "id", "fund_name");
    }

    private void ParseSignatory(Dictionary<string, string> dictSignatory, ref string signatory, ref string signatoryTitle)
    {
        if (dictSignatory.Count > 0)
        {
            signatory = dictSignatory["signatories_full_name"];
            signatoryTitle = dictSignatory["signatories_title"];
        }
    }

    private void RunReport()
    {
        int fundId = Convert.ToInt32(cmbxFund.SelectedValue);
        DateTime dateAsOf = dtAsOf.Value;
        short year = Convert.ToInt16(dtAsOf.Value.Year);
        int fppSpecial = chkbxSpecialFPP.Checked ? 1 : 0;

        if (!backgroundWorker1.IsBusy)
        {
            progressBar1.Value = 0;
            var parameters = (fundId, dateAsOf, year, Convert.ToByte(fppSpecial));
            backgroundWorker1.RunWorkerAsync(parameters);
        }
    }

    private void FilterReport(int filterLevel, LocalReport report)
    {
        var parameters = new[] { new ReportParameter("paramFilterLevel", filterLevel.ToString()) };
        report.SetParameters(parameters);
        reportViewer1.RefreshReport();
    }

    private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
    {
        var parameters = ((int fundId, DateTime dateAsOf, short year, byte fppSpecial))e.Argument;

        var dtSaob = new dsLFS().dtSAAOB;
        var dtBudgetAppropriations = BudgetFactory.BudgetAppropriationsRepository().GetViewRecords(parameters.fundId, parameters.dateAsOf, parameters.year, 0, parameters.fppSpecial);

        int totalProgressCount = dtBudgetAppropriations.Rows.Count;
        int progressCount = 0;

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
            var dtSupplemtedAmount = BudgetFactory.SupplementalAppropriationsRepository().GetRecordsByBudgetAppropriationIdDateEntry(rowBudgetAppropriationId, parameters.dateAsOf);
            decimal supplementedAmount = Convert.ToDecimal(dtSupplemtedAmount.Rows.Count == 0 ? 0 : dtSupplemtedAmount.Compute("SUM(amount)", string.Empty));

            decimal TotalBudgetAppropraition = rowAppropriation + supplementedAmount;

            //ALLOTMENT RELEASE
            var dtAllotmentRelease = BudgetFactory.AllotmentReleaseRepository().GetViewRecordsByBudgetAppropriationIdDateIssued(rowBudgetAppropriationId, parameters.dateAsOf);
            decimal allotmentReleaseAmount = Convert.ToDecimal(dtAllotmentRelease.Rows.Count == 0 ? 0 : dtAllotmentRelease.Compute("SUM(amount)", string.Empty));

            //OBLIGATIONS
            var dtObligation = BudgetFactory.ObligationRequestRepository().GetViewRecords(rowBudgetAppropriationId, parameters.dateAsOf);
            decimal obligationRequestAmount = Convert.ToDecimal(dtObligation.Rows.Count == 0 ? 0 : dtObligation.Compute("SUM(amount)", string.Empty));

            //UNOBLIGATED BALANCE
            decimal unobligatedBalance = allotmentReleaseAmount - obligationRequestAmount;

            var items = new object[] { rowfundId, rowFundCode, rowFundName, rowFunctionClassificationId, rowFunctionClassificationSectorCode, rowFunctionClassificationSectorName, rowFunctionClassificationServicesId, rowFunctionClassificationServicesName, rowFPPId, rowFPPCode, rowFPPName, rowFPPIsSpecial, rowSubFPPId, rowSubFPPCode, rowSubFPPName, rowAllotmentClassId, rowAllotmentClassCode, rowAllotmentClassName, rowAccountCode, rowAccountName, rowYear, rowRemarks, TotalBudgetAppropraition, allotmentReleaseAmount, obligationRequestAmount, unobligatedBalance };

            dtSaob.Rows.Add(items);
            progressCount++;
            Helper.ProgressCounter(backgroundWorker1, totalProgressCount, progressCount);
        }

        e.Result = dtSaob;
    }

    private void backgroundWorker1_ProgressChanged(object sender, ProgressChangedEventArgs e)
    {
        progressBar1.Value = e.ProgressPercentage;
    }

    private void backgroundWorker1_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
    {
        var result = e.Result as DataTable;

        if (result is DataTable)
        {
            var localReport = reportViewer1.LocalReport;
            var dictSignatory = Helper.GetSigtryByRefDoc("Certified Correct", "SAAOB");
            string certifiedCorrectSignatory = string.Empty;
            string certifiedCorrectSignatoryTitle = string.Empty;
            ParseSignatory(dictSignatory, ref certifiedCorrectSignatory, ref certifiedCorrectSignatoryTitle);

            int fundId = Convert.ToInt32(cmbxFund.SelectedValue);
            DateTime AsOf = dtAsOf.Value;

            var parameters = new[] {
                    new ReportParameter("paramFundName", Factory.FundsRepository().GetRecordByID(fundId)["fund_name"]),
                    new ReportParameter("paramFundCode", Factory.FundsRepository().GetRecordByID(fundId)["fund_code"]),
                    new ReportParameter("paramDate", AsOf.ToString("MMMM dd, yyyy")),
                    new ReportParameter("paramCertifiedCorrectSignatory", certifiedCorrectSignatory),
                    new ReportParameter("paramCertifiedCorrectSignatoryTitle", certifiedCorrectSignatoryTitle),
                    new ReportParameter("paramFilterLevel","5"),
                    new ReportParameter("paramFPPIsSpecial", (chkbxSpecialFPP.Checked? 1 : 0).ToString())
                };

            localReport.ReportPath = $"{Application.StartupPath}\\Budget\\Reports\\saao.rdlc";
            localReport.DataSources.Clear();
            localReport.DataSources.Add(new ReportDataSource("dtSAAOB", result));
            localReport.SetParameters(parameters);
            flwPnlCoverage.Enabled = true;
            reportViewer1.SetDisplayMode(DisplayMode.PrintLayout);
            reportViewer1.RefreshReport();
        }
    }

    private void btnRetrieve_Click(object sender, EventArgs e)
    {
        RunReport();
    }

    private void frmSAAOB_Load(object sender, EventArgs e)
    {
        LoadFunds();
    }

    private void radBtn1_CheckedChanged(object sender, EventArgs e)
    {
        FilterReport(1, reportViewer1.LocalReport);
    }

    private void radBtn2_CheckedChanged(object sender, EventArgs e)
    {
        FilterReport(2, reportViewer1.LocalReport);
    }

    private void radBtn3_CheckedChanged(object sender, EventArgs e)
    {
        FilterReport(3, reportViewer1.LocalReport);
    }

    private void radBtn4_CheckedChanged(object sender, EventArgs e)
    {
        FilterReport(4, reportViewer1.LocalReport);
    }

    private void radBtn5_CheckedChanged(object sender, EventArgs e)
    {
        FilterReport(5, reportViewer1.LocalReport);
    }
}