using Microsoft.Reporting.WinForms;

using OmniGov.App.DataSets;

using OmniGov.App.Helpers;

using OmniGov.App.Views.Shared;

using OmniGov.Core.Factories;

using OmniGov.Treasury.Data.Factories;

using System.ComponentModel;

using System.Data;

namespace OmniGov.App.Views.Reports.RptReports

{
    public partial class frmListRptDelinquencies : Form

    {
        public frmListRptDelinquencies()

        {
            InitializeComponent();

            Helper.LoadFormIcon(this);

            panel2.Controls.Add(reportViewer1);

            reportViewer1.Dock = DockStyle.Fill;
        }

        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)

        {
            if (e.Argument is not DataTable dataSource)
                return;

            var dataTable = new dsTreasury.dtRptDelinquenciesDataTable();

            int totalProgressCount = dataSource.Rows.Count;
            int progressCount = 0;

            foreach (DataRow row in dataSource.Rows)
            {
                var newRow = dataTable.NewRow();
                string rowOwnerName = row["taxpayer_name"].ToString();
                string rowLotNo = row["lot_no"].ToString();
                string rowArpNo = row["complete_arp_no"].ToString();
                decimal rowAssessedValue = Convert.ToDecimal(row["assessed_value"]);
                DateTime rowPostedAt = Convert.ToDateTime(row["posted_at"]);

                int rowEffectivityYear = Convert.ToInt32(row["effectivity_year"]);
                int rowEffectivityQuarter = Convert.ToInt32(row["effectivity_quarterly"]);
                decimal rowDiscountRate = Convert.ToDecimal(row["discount_rate"]);
                decimal rowPenaltyRate = Convert.ToDecimal(row["penalty_rate"]);
                string rowRptPaymentPostId = row["rpt_payments_id"].ToString();
                int rowAssessmentYear = Convert.ToInt32(row["year"]);
                string rowClassificationCode = row["classification_code"].ToString();

                decimal rowBasicRate = Convert.ToDecimal(row["basic_rate"]);
                decimal rowSefRate = Convert.ToDecimal(row["sef_rate"]);
                decimal basicTaxDue = RealPropertyTaxComputations.GetBasicTaxDue(rowBasicRate, rowAssessedValue);
                decimal sefTaxDue = RealPropertyTaxComputations.GetSefTaxDue(rowSefRate, rowAssessedValue);

                DateTime transactionDate = string.IsNullOrWhiteSpace(rowRptPaymentPostId) ? dtTo.Value : Convert.ToDateTime(row["payment_collections_created_at"]);

                //Get penalties
                var currentAssessmentParameters = (rowAssessmentYear, rowArpNo, rowEffectivityQuarter, rowEffectivityYear);
                var penalties = GetPenalties(transactionDate, currentAssessmentParameters, rowPenaltyRate, basicTaxDue, sefTaxDue);

                if (penalties.basicPenalty < 1 && penalties.sefPenalty < 1)
                {
                    totalProgressCount--;
                    continue;
                }

                decimal totalTaxDue = basicTaxDue + sefTaxDue;
                decimal total = totalTaxDue + (penalties.basicPenalty + penalties.sefPenalty);

                newRow["declarant"] = rowOwnerName;
                newRow["lot_no"] = rowLotNo;
                newRow["arp_no"] = rowArpNo;
                newRow["assessed_value"] = rowAssessedValue;
                newRow["start_year"] = rowAssessmentYear;
                newRow["basic_tax_due"] = basicTaxDue;
                newRow["basic_penalty"] = penalties.basicPenalty;
                newRow["sef_tax_due"] = sefTaxDue;
                newRow["sef_penalty"] = penalties.sefPenalty;
                newRow["total"] = total;
                newRow["remarks"] = rowClassificationCode;

                dataTable.Rows.Add(newRow);
                progressCount++;
                Helper.ProgressCounter(backgroundWorker1, totalProgressCount, progressCount);
            }

            e.Result = dataTable;
        }

        private void backgroundWorker1_ProgressChanged(object sender, ProgressChangedEventArgs e)

        {
            progressBar1.Value = e.ProgressPercentage;
        }

        private void backgroundWorker1_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)

        {
            if (e.Cancelled)
                return;

            if (e.Result is not DataTable dataTable)
                return;

            if (dataTable.Rows.Count < 1)
                progressBar1.Value = 100;

            string asOfDate = $"{dtFrom.Value.ToString("MMM dd, yyyy")} - {dtTo.Value.ToString("MMM dd, yyyy")}";

            var reportParameters = new ReportParameter[]
            {
                new("paramLGUName", (ServerHelper.SelectedProfile?.Name ?? "")),
                new("paramAsOf", asOfDate)
            };

            reportViewer1.LocalReport.ReportPath = $"{Application.StartupPath}\\Reports\\ListRptDelinquencies.rdlc";
            reportViewer1.LocalReport.SetParameters(reportParameters);

            reportViewer1.LocalReport.DataSources.Clear();
            reportViewer1.LocalReport.DataSources.Add(new ReportDataSource("dtRptDelinquencies", dataTable));

            reportViewer1.SetDisplayMode(DisplayMode.PrintLayout);
            reportViewer1.ZoomMode = ZoomMode.PageWidth;
            reportViewer1.ZoomPercent = 100;
            reportViewer1.RefreshReport();
        }

        private void btnRunReport_Click(object sender, EventArgs e)

        {
            if (!backgroundWorker1.IsBusy)
            {
                progressBar1.Value = 0;
                string loadBy = cmbxLoadBy.Text;
                DateTime periodFrom = dtFrom.Value;
                DateTime periodTo = dtTo.Value;
                DataTable dtSourceDb;

                if (radBarangay.Checked)
                    dtSourceDb = TreasuryFactory.RptAssessmentPostsRepository().GetViewDelinquentRecordsByBarangayNamePeriod(loadBy, periodFrom, periodTo);
                else
                    dtSourceDb = TreasuryFactory.RptAssessmentPostsRepository().GetViewDelinquentRecordsByOwnerNamePeriod(loadBy, periodFrom, periodTo);

                backgroundWorker1.RunWorkerAsync(dtSourceDb);
            }
        }

        private void frmListOfRealPropertyTaxDelinquenciesReport_Load(object sender, EventArgs e)

        {
            dtTo.MaxDate = Helper.GetCurrentDate();
            LoadFilter();
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

        private void LoadBarangays()

        {
            var dtBarangays = Factory.BarangayRepository().GetRecords();

            HelperLoadRecords.BarangaysCombobox(dtBarangays, cmbxLoadBy, "name", "id");
        }

        private void LoadFilter()

        {
            if (radBarangay.Checked)

                LoadBarangays();
            else

                LoadTaxpayers();
        }

        private void LoadTaxpayers()

        {
            var dtTaxpayers = TreasuryFactory.TaxpayersRepository().GetRecords();

            cmbxLoadBy.DataSource = dtTaxpayers;

            cmbxLoadBy.ValueMember = "id";

            cmbxLoadBy.DisplayMember = "name";
        }

        private void radBarangay_CheckedChanged(object sender, EventArgs e)

        {
            LoadFilter();
        }

        private void radOwner_CheckedChanged(object sender, EventArgs e)

        {
            LoadFilter();
        }
    }
}