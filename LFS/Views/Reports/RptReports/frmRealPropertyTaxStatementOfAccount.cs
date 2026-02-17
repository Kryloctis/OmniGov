using LFS.DataSets;
using LFS.Helpers;
using LFS.Views.Shared;
using Microsoft.Reporting.WinForms;
using System;
using System.ComponentModel;
using System.Data;
using System.Windows.Forms;
using Treasury.Data;

namespace LFS.Views.Reports.RptReports
{
    public partial class frmRealPropertyTaxStatementOfAccount : Form
    {
        public frmRealPropertyTaxStatementOfAccount()
        {
            InitializeComponent();
            Helper.LoadFormIcon(this);
            panel1.Controls.Add(reportViewer1);
            reportViewer1.Dock = DockStyle.Fill;
        }

        private void frmRealPropertyTaxStatementOfAccount_Load(object sender, EventArgs e)
        {
            try
            {
                LoadOwners();
            }
            catch (Exception ex) { Helper.MessageBoxError(ex.Message); }
        }

        private void LoadProperties(int ownerId)
        {
            var dataTable = TreasuryFactory.RptAssessmentPostsRepository().GetViewRecordsByOwnerId(ownerId);
            cmbxProperty.DataSource = dataTable;
            cmbxProperty.ValueMember = "rpt_assessment_posts_id";
            cmbxProperty.DisplayMember = "complete_arp_no";
            cmbxProperty.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            cmbxProperty.AutoCompleteSource = AutoCompleteSource.ListItems;
        }

        private void LoadOwners()
        {
            var dataTable = TreasuryFactory.TaxpayersRepository().GetRecords();
            HelperLoadRecords.SearchableCombobox2(dataTable, cmbxOwner, "id", "name");
        }

        private (decimal basicPenalty, decimal sefPenalty) GetPenalties(DateTime transactionDate,
                                                                  (int assessmentYear, string compelteArpNo, int effectivityQuarter, int effectivityYear) currentAssmntParameters,
                                                                  decimal penaltyRate,
                                                                  decimal basicTaxDue,
                                                                  decimal sefTaxDue)
        {
            var dictPrevAssmnt = TreasuryFactory.RptAssessmentPostsRepository().GetViewRecentAssessmentRecord(currentAssmntParameters.compelteArpNo, currentAssmntParameters.assessmentYear);

            int? prevAssmntYear = null;

            if (dictPrevAssmnt.Count > 1)
                prevAssmntYear = Convert.ToInt32(dictPrevAssmnt["year"]);

            int monthsDelinquent = RealPropertyTaxComputations.GetMonthsDelinquent(transactionDate, (currentAssmntParameters.assessmentYear, currentAssmntParameters.effectivityQuarter, currentAssmntParameters.effectivityYear), prevAssmntYear.HasValue ? prevAssmntYear : null);
            decimal basicPenalty = RealPropertyTaxComputations.GetPenalty(penaltyRate, monthsDelinquent, basicTaxDue);
            decimal sefPenalty = RealPropertyTaxComputations.GetPenalty(penaltyRate, monthsDelinquent, sefTaxDue);

            return (basicPenalty, sefPenalty);
        }

        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
            var parameters = ((string completeArpNo, DateTime periodFrom, DateTime periodTo))e.Argument;

            DataTable dataTable = new dsTreasury.dtRptStamentOfAccountsDataTable();
            var dtSourceDb = TreasuryFactory.RptAssessmentPostsRepository().GetViewRecordsByArpNoPeriod(parameters.completeArpNo, parameters.periodFrom, parameters.periodTo);

            int totalProgressCount = dtSourceDb.Rows.Count;
            int progressCount = 0;
            decimal propertyAssessedValue = 0;

            foreach (DataRow row in dtSourceDb.Rows)
            {
                var newRow = dataTable.NewRow();

                string rowCompleteArpNo = row["complete_arp_no"].ToString();
                int rowAssessmntYear = Convert.ToInt32(row["year"]);
                decimal rowAssessedValue = Convert.ToDecimal(row["assessed_value"]);
                decimal rowBasicRate = Convert.ToDecimal(row["basic_rate"]);
                decimal rowSefRate = Convert.ToDecimal(row["sef_rate"]);
                decimal basicTaxDue = RealPropertyTaxComputations.GetBasicTaxDue(rowBasicRate, rowAssessedValue);
                decimal sefTaxDue = RealPropertyTaxComputations.GetSefTaxDue(rowSefRate, rowAssessedValue);
                decimal rowDiscountRate = Convert.ToDecimal(row["discount_rate"]);
                decimal rowPenaltyRate = Convert.ToDecimal(row["penalty_rate"]);
                DateTime rowPostedAt = Convert.ToDateTime(row["posted_at"]);
                int rowEffectivityQuarter = Convert.ToInt32(row["effectivity_quarterly"]);
                int rowEffectivityYear = Convert.ToInt32(row["effectivity_year"]);
                decimal paymentAmount = Convert.ToDecimal(row["payment_collections_amount"]);

                object datePaidRaw = row["payment_collections_created_at"];
                bool isPaid = !string.IsNullOrWhiteSpace(datePaidRaw.ToString());
                string datePaid = isPaid ? Convert.ToDateTime(datePaidRaw).ToShortDateString() : string.Empty;
                string rowRptPaymentsId = row["rpt_payments_id"].ToString();
                DateTime transactionDate = isPaid ? Convert.ToDateTime(datePaidRaw) : dtPeriodTo.Value;

                //Get discount rate
                var discountParameters = (rowPostedAt, rowAssessmntYear);
                decimal discountRate = isPaid ? rowDiscountRate : RealPropertyTaxComputations.GetDiscountRate(Helper.GetCurrentDate(), discountParameters);

                //Get penalties
                var penaltyParameters = (rowAssessmntYear, rowCompleteArpNo, rowEffectivityQuarter, rowEffectivityYear);
                var penalties = GetPenalties(transactionDate, penaltyParameters, rowPenaltyRate, basicTaxDue, sefTaxDue);

                //Get discount
                decimal basicDiscount = penalties.basicPenalty > 0 ? 0 : RealPropertyTaxComputations.GetDiscount(discountRate, basicTaxDue);
                decimal sefDiscount = penalties.sefPenalty > 0 ? 0 : RealPropertyTaxComputations.GetDiscount(discountRate, sefTaxDue);

                decimal basicPenaltyDiscount = penalties.basicPenalty > 0 ? penalties.basicPenalty : -basicDiscount;
                decimal sefPenaltyDiscount = penalties.sefPenalty > 1 ? penalties.sefPenalty : -sefDiscount;

                //Previous Year
                int previousYear;
                var dictPrevAssmnt = TreasuryFactory.RptAssessmentPostsRepository().GetViewRecentAssessmentRecord(rowCompleteArpNo, rowAssessmntYear);
                if (dictPrevAssmnt.Count < 1)
                    previousYear = rowEffectivityYear;
                else
                    previousYear = Convert.ToInt32(dictPrevAssmnt["year"]);

                //Basic
                newRow["basic_taxdue"] = basicTaxDue;
                newRow["penalty_discount_basic"] = basicPenaltyDiscount;
                newRow["total_basic"] = basicTaxDue + basicPenaltyDiscount;

                //SEF
                newRow["sef_taxdue"] = sefTaxDue;
                newRow["penalty_discount_sef"] = sefPenaltyDiscount;
                newRow["total_sef"] = sefTaxDue + sefPenaltyDiscount;

                //Common
                newRow["prev_assessment_year"] = previousYear;
                newRow["assessment_year"] = rowAssessmntYear;
                newRow["percentage"] = rowBasicRate;
                newRow["total_paid"] = paymentAmount;

                progressCount++;
                dataTable.Rows.Add(newRow);
                propertyAssessedValue = rowAssessedValue;

                Helper.ProgressCounter(backgroundWorker1, totalProgressCount, progressCount);
            }

            var result = (dataTable, parameters.completeArpNo, propertyAssessedValue);
            e.Result = result;
        }

        private void backgroundWorker1_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            progressBar1.Value = e.ProgressPercentage;
        }

        private void backgroundWorker1_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            try
            {
                var result = ((DataTable dataTable, string completeArpNo, decimal propertyAssessedValue))e.Result;

                if (e.Cancelled)
                    return;
                if (result.dataTable is not DataTable dataTable)
                    return;

                if (dataTable.Rows.Count < 1)
                    progressBar1.Value = 100;

                var dictTaxpayer = TreasuryFactory.TaxpayersRepository().GetRecordByID(Convert.ToInt32(cmbxOwner.SelectedValue));
                var taxpayerAddress = Helper.GenerateFullAddress(dictTaxpayer["address"], string.Empty, dictTaxpayer["municipality"], dictTaxpayer["province"]);

                var reportParameters = new ReportParameter[]
                {
                    new("paramLGUName", ServerHelper.selectedServer.MunicipalityName),
                    new("paramAssessedValue", result.propertyAssessedValue.ToString("N2")),
                    new("paramARPNo", result.completeArpNo),
                    new("paramOwner", dictTaxpayer["name"]),
                    new("paramOwnerAddress", taxpayerAddress),
                    new("paramDate", $"{dtPeriodFrom.Value.ToString("MMM dd, yyyy")} - {dtPeriodTo.Value.ToString("MMM dd, yyyy")}"),
                };

                reportViewer1.LocalReport.ReportPath = $"{Application.StartupPath}\\Reports\\RptStatementOfAccounts.rdlc";
                reportViewer1.LocalReport.DataSources.Clear();
                reportViewer1.LocalReport.DataSources.Add(new ReportDataSource("dtRptStamentOfAccounts", dataTable));

                reportViewer1.LocalReport.SetParameters(reportParameters);

                reportViewer1.SetDisplayMode(DisplayMode.PrintLayout);
                reportViewer1.ZoomMode = ZoomMode.PageWidth;
                reportViewer1.ZoomPercent = 100;

                reportViewer1.RefreshReport();
            }
            catch (Exception ex) { Helper.MessageBoxError(ex.Message); }
        }

        private void cmbxOwner_SelectedValueChanged(object sender, EventArgs e)
        {
            try
            {
                if (cmbxOwner.SelectedValue is int taxpayerId)
                    LoadProperties(taxpayerId);
            }
            catch (Exception ex) { Helper.MessageBoxError(ex.Message); }
        }

        private void LoadReport()
        {
            if (!backgroundWorker1.IsBusy)
            {
                progressBar1.Value = 0;
                string arpNo = cmbxProperty.Text;
                DateTime periodFrom = dtPeriodFrom.Value;
                DateTime periodTo = dtPeriodTo.Value;

                backgroundWorker1.RunWorkerAsync((arpNo, periodFrom, periodTo));
            }
        }

        private void btnRunReport_Click(object sender, EventArgs e)
        {
            try
            {
                LoadReport();
            }
            catch (Exception ex) { Helper.MessageBoxError(ex.Message); }
        }
    }
}
