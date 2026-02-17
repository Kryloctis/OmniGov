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
    public partial class frmRptDuesPayments : Form
    {
        public frmRptDuesPayments()
        {
            InitializeComponent();
            Helper.LoadFormIcon(this);
            panel2.Controls.Add(reportViewer1);
            reportViewer1.Dock = DockStyle.Fill;
        }

        private void LoadTaxpayers()
        {
            var registryColumn = new DataColumn[]
            {
                new DataColumn(Name = "id", typeof(int)),
                new DataColumn(Name = "name", typeof(string))
            };

            var dataTable = new DataTable();
            dataTable.Columns.AddRange(registryColumn);

            var dtRegistry = TreasuryFactory.TaxpayersRepository().GetRecords();

            foreach (DataRow row in dtRegistry.Rows)
            {
                var newRow = dataTable.NewRow();

                int Id = Convert.ToInt32(row["id"]);

                newRow["id"] = Id;
                newRow["name"] = row["name"];

                dataTable.Rows.Add(newRow);
            }

            HelperLoadRecords.SearchableCombobox2(dataTable, cmbxOwners, "id", "name");
        }

        private void frmRealPropertyTaxAccountRegisterReport_Load(object sender, EventArgs e)
        {
            try
            {
                LoadTaxpayers();
            }
            catch (Exception ex) { Helper.MessageBoxError(ex.Message); }
        }

        private void InitializeReport()
        {
            if (!backgroundWorker1.IsBusy)
            {
                string ownerName = cmbxOwners.Text;
                DateTime periodFrom = dtFrom.Value;
                DateTime periodTo = dtTo.Value;
                progressBar1.Value = 0;
                backgroundWorker1.RunWorkerAsync((ownerName, periodFrom, periodTo));
            }
        }

        private void btnRunReport_Click(object sender, EventArgs e)
        {
            try
            {
                InitializeReport();
            }
            catch (Exception ex) { Helper.MessageBoxError(ex.Message); }
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
            try
            {
                var parameters = ((string ownerName, DateTime periodFrom, DateTime periodTo))e.Argument;
                var dataTable = new dsTreasury.dtRptTaxDuesPaymentsDataTable();

                var dtAssessmentPosting = TreasuryFactory.RptAssessmentPostsRepository().GetViewRecordsByOwnerNamePeriod(parameters.ownerName, parameters.periodFrom, parameters.periodTo);
                int totalProgressCount = dtAssessmentPosting.Rows.Count;
                int progressCount = 0;

                foreach (DataRow row in dtAssessmentPosting.Rows)
                {
                    var basicNewRow = dataTable.NewRow();
                    var sefRow = dataTable.NewRow();

                    string rowCompleteArpNo = row["complete_arp_no"].ToString();
                    int rowAssessmntYear = Convert.ToInt32(row["year"]);
                    string rowPin = row["property_pin"].ToString();
                    string rowBarangay = row["barangay_name"].ToString();
                    string rowMunicipality = row["municipality_name"].ToString();
                    string rowProvince = row["province_name"].ToString();
                    string rowPropertyKind = row["property_kind"].ToString();
                    decimal rowAssessedValue = Convert.ToDecimal(row["assessed_value"]);
                    string rowReceiptNo = row["payment_collections_receipt_no"].ToString();
                    string rowPayee = row["payment_collections_payee"].ToString();

                    decimal rowlandAssessedValue = rowPropertyKind == "L" ? rowAssessedValue : 0;
                    decimal totalAssessedValue = rowAssessedValue;
                    string paymentPeriod = "AN";
                    decimal rowDiscountRate = Convert.ToDecimal(row["discount_rate"]);
                    decimal rowPenaltyRate = Convert.ToDecimal(row["penalty_rate"]);
                    DateTime rowPostedAt = Convert.ToDateTime(row["posted_at"]);
                    int rowEffectivityQuarter = Convert.ToInt32(row["effectivity_quarterly"]);
                    int rowEffectivityYear = Convert.ToInt32(row["effectivity_year"]);
                    bool rowIsCancelled = Convert.ToBoolean(Convert.ToByte(row["is_cancelled"]));

                    decimal rowBasicRate = Convert.ToDecimal(row["basic_rate"]);
                    decimal rowSefRate = Convert.ToDecimal(row["sef_rate"]);
                    decimal basicTaxDue = RealPropertyTaxComputations.GetBasicTaxDue(rowBasicRate, rowAssessedValue);
                    decimal sefTaxDue = RealPropertyTaxComputations.GetSefTaxDue(rowSefRate, rowAssessedValue);

                    object datePaidRaw = row["payment_collections_created_at"];
                    bool isPaid = !string.IsNullOrWhiteSpace(datePaidRaw.ToString());
                    string datePaid = isPaid ? Convert.ToDateTime(datePaidRaw).ToShortDateString() : string.Empty;
                    string rowRptPaymentsId = row["rpt_payments_id"].ToString();
                    DateTime transactionDate = isPaid ? Convert.ToDateTime(datePaidRaw) : dtTo.Value;

                    //Get discount rate
                    var discountParameters = (rowPostedAt, rowAssessmntYear);
                    decimal discountRate = isPaid ? rowDiscountRate : RealPropertyTaxComputations.GetDiscountRate(Helper.GetCurrentDate(), discountParameters);

                    //Get penalties
                    var penaltyParameters = (rowAssessmntYear, rowCompleteArpNo, rowEffectivityQuarter, rowEffectivityYear);
                    var penalties = GetPenalties(transactionDate, penaltyParameters, rowPenaltyRate, basicTaxDue, sefTaxDue);

                    //Get discount
                    decimal basicDiscount = penalties.basicPenalty > 0 ? 0 : RealPropertyTaxComputations.GetDiscount(discountRate, basicTaxDue);
                    decimal sefDiscount = penalties.sefPenalty > 0 ? 0 : RealPropertyTaxComputations.GetDiscount(discountRate, sefTaxDue);

                    var paymentCollectionDate = row["payment_collections_payment_date"];

                    //BASIC
                    basicNewRow["date"] = datePaid;
                    basicNewRow["arp_no"] = rowCompleteArpNo;
                    basicNewRow["pin"] = rowPin;
                    basicNewRow["barangay"] = rowBarangay;
                    basicNewRow["municipality"] = rowMunicipality;
                    basicNewRow["province"] = rowProvince;
                    basicNewRow["tax_year"] = rowAssessmntYear;
                    basicNewRow["land_assessed_value"] = rowlandAssessedValue;
                    basicNewRow["total_assessed_value"] = totalAssessedValue;
                    basicNewRow["payment_period"] = paymentPeriod;
                    basicNewRow["tax_type"] = "Basic";
                    basicNewRow["regular_tax_due"] = basicTaxDue;
                    basicNewRow["discount_tax_due"] = basicDiscount;
                    basicNewRow["penalty_tax_due"] = penalties.basicPenalty;
                    basicNewRow["receipt_number"] = rowReceiptNo;
                    basicNewRow["payee"] = rowPayee;
                    basicNewRow["is_cancelled"] = rowIsCancelled;
                    basicNewRow["discount_tax_collected"] = isPaid && basicDiscount > 1 ? basicTaxDue - basicDiscount : 0;
                    basicNewRow["regular_tax_collected"] = isPaid ? basicTaxDue : 0;
                    basicNewRow["penalty_tax_collected"] = isPaid ? penalties.basicPenalty : 0;

                    //SEF
                    sefRow["date"] = datePaid;
                    sefRow["arp_no"] = rowCompleteArpNo;
                    sefRow["pin"] = rowPin;
                    sefRow["barangay"] = rowBarangay;
                    sefRow["municipality"] = rowMunicipality;
                    sefRow["province"] = rowProvince;
                    sefRow["tax_year"] = rowAssessmntYear;
                    sefRow["land_assessed_value"] = rowlandAssessedValue;
                    sefRow["total_assessed_value"] = totalAssessedValue;
                    sefRow["payment_period"] = paymentPeriod;
                    sefRow["tax_type"] = "SEF";
                    sefRow["regular_tax_due"] = sefTaxDue;
                    sefRow["discount_tax_due"] = sefDiscount;
                    sefRow["penalty_tax_due"] = penalties.sefPenalty;
                    sefRow["receipt_number"] = rowReceiptNo;
                    sefRow["payee"] = rowPayee;
                    sefRow["is_cancelled"] = rowIsCancelled;
                    sefRow["regular_tax_collected"] = isPaid ? sefTaxDue : 0;
                    sefRow["discount_tax_collected"] = isPaid && basicDiscount > 1 ? sefTaxDue - sefDiscount : 0;
                    sefRow["penalty_tax_collected"] = isPaid ? penalties.sefPenalty : 0;

                    dataTable.Rows.Add(basicNewRow);
                    dataTable.Rows.Add(sefRow);
                    progressCount++;
                    Helper.ProgressCounter(backgroundWorker1, totalProgressCount, progressCount);
                }

                e.Result = dataTable;
            }
            catch (Exception ex) { Helper.MessageBoxError(ex.Message); }
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

            var localReport = reportViewer1.LocalReport;
            int taxpayerId = Convert.ToInt32(cmbxOwners.SelectedValue);
            var dictTaxpayer = TreasuryFactory.TaxpayersRepository().GetRecordByID(taxpayerId);

            var parameter = new ReportParameter[]
            {
                new("paramLGUName", ServerHelper.selectedServer.MunicipalityName),
                new("paramOwner", dictTaxpayer["name"]),
                new("paramOwerTin", dictTaxpayer["tin"]),
                new("paramOwnerAddress", Helper.GenerateFullAddress(dictTaxpayer["address"], string.Empty,  dictTaxpayer["municipality"],  dictTaxpayer["province"])),
                new("paramDate", dtTo.Value.ToString())
            };

            localReport.ReportPath = $"{Application.StartupPath}\\Reports\\RealPropertyTaxDuesAndPayments.rdlc";
            localReport.DataSources.Clear();

            localReport.DataSources.Add(new ReportDataSource("dtRptTaxDuesPayments", dataTable));
            localReport.SetParameters(parameter);

            reportViewer1.SetDisplayMode(DisplayMode.PrintLayout);
            reportViewer1.ZoomMode = ZoomMode.PageWidth;
            reportViewer1.ZoomPercent = 100;
            reportViewer1.RefreshReport();
        }
    }
}
