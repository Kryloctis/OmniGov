using ACC.Domain.Models;
using AccountingSystem.Views.Reports.RealPropertyTaxReports;
using AccountingSystem.Views.Transactions.PaymentPosting;
using AccountingSystem.Views.Transactions.PropertyPayment.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static AccountingSystem.Views.Transactions.PaymentPosting.frmPropertyPayment;

namespace AccountingSystem.Views.Transactions.PaymentPostings.RPT_PaymentPosting
{
    public partial class frmPropertyTaxDue : Form
    {
        private readonly frmPropertyPayment _frmPropertyPayment;
        private readonly string _ownerName;
        public frmPropertyTaxDue(string ownerName, frmPropertyPayment frmPropertyPayment)
        {
            InitializeComponent();
            _ownerName = ownerName;
            _frmPropertyPayment = frmPropertyPayment;
            Helper.LoadFormIcon(this);
            Helper.DatagridFullRowSelectStyle(dataGridView1, true, false);
            Helper.DatagridFullRowSelectStyle(dataGridView2, true, false);
        }

        private void frmRptTaxDue_Load(object sender, EventArgs e)
        {
            LoadProperties();
        }

        #region Properties

        private DataTable DataTableProperties()
        {
            bool isCancelled = chckBxCancelled.Checked;
            var dtAssessmentPosting = AccFactory.RptAssessmentPostsRepository().GetRecordsByOwnerName_IsCancelled(_ownerName, isCancelled);
            var dataTable = new DataTable();

            var dataColumns = new DataColumn[]
            {
                new ("is_checked", typeof(bool)),
                new ("id", typeof(int)),
                new ("complete_arp_no", typeof(string)),
                new ("property_pin", typeof(string)),
                new ("barangay_name",typeof(string)),
                new ("property_kind",typeof(string)),
                new ("is_cancelled", typeof(Image))
            };
            dataTable.Columns.AddRange(dataColumns);

            foreach (DataRow dataRow in dtAssessmentPosting.Rows)
            {
                int rowId = Convert.ToInt32(dataRow["id"]);
                string rowCompleteArpNo = dataRow["complete_arp_no"].ToString();
                string rowPropertyPin = dataRow["property_pin"].ToString();
                string rowBarangayName = dataRow["barangay_name"].ToString();
                string rowPropertyKind = dataRow["property_kind"].ToString();
                bool rowIsCancelled = Convert.ToBoolean(dataRow["is_cancelled"]);
                Image rowIsCancelledImg = rowIsCancelled ? Properties.Resources.ok14px : null;

                dataTable.Rows.Add(false, rowId, rowCompleteArpNo, rowPropertyPin, rowBarangayName, rowPropertyKind, rowIsCancelledImg);
            }

            return dataTable;
        }

        private void LoadProperties()
        {
            try
            {
                Cursor = Cursors.WaitCursor;
                HelperLoadRecords.TaxPayerProperties(dataGridView1, DataTableProperties());
                Helper.CheckUncheckCheckBoxHeader(dataGridView1, "is_checked", chckBoxProperties);
                LoadTaxDues(dataGridView1, dataGridView2);
                Cursor = Cursors.Default;
            }
            catch (Exception ex)
            {
                Helper.MessageBoxError(ex.Message);
            }
        }

        private void chckBxCancelled_CheckedChanged(object sender, EventArgs e)
        {
            LoadProperties();
        }

        private void chckBoxProperties_MouseClick(object sender, MouseEventArgs e)
        {
            if (chckBoxProperties.Checked)
                Helper.CheckUncheckCheckBoxRows(dataGridView1, "is_checked", true);
            else
                Helper.CheckUncheckCheckBoxRows(dataGridView1, "is_checked", false);
        }

        private void dataGridView1_CurrentCellDirtyStateChanged(object sender, EventArgs e)
        {
            if (dataGridView1.CurrentCell is DataGridViewCheckBoxCell)
                dataGridView1.CommitEdit(DataGridViewDataErrorContexts.Commit);
        }

        private void dataGridView1_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            Helper.CheckUncheckCheckBoxHeader(dataGridView1, "is_checked", chckBoxProperties);
            LoadTaxDues(dataGridView1, dataGridView2);
        }

        private void dataGridView1_ColumnAdded(object sender, DataGridViewColumnEventArgs e)
        {
            if (e.Column.Name != "is_checked")
                e.Column.ReadOnly = true;
        }

        #endregion

        #region Get Current Consolidated Tax Dues

        private DataTable TaxDuesDataTable(List<string> arpNoList)
        {
            var dataTable = new DataTable();

            //Create data columns
            var columns = new DataColumn[]
            {
                new DataColumn("is_checked", typeof(bool)),
                new DataColumn("id", typeof(int)),
                new DataColumn("year", typeof(int)),
                new DataColumn("complete_arp_no", typeof(string)),
                new DataColumn("assessed_value", typeof(decimal)),
                new DataColumn("tax_due", typeof(decimal)),
                new DataColumn("discount_rate", typeof(decimal)),
                new DataColumn("discount_is_advance", typeof(bool)),
                new DataColumn("discount", typeof(decimal)),
                new DataColumn("penalty", typeof(decimal)),
                new DataColumn("total_tax_due", typeof(decimal))
            };

            dataTable.Columns.AddRange(columns);

            foreach (var arpNo in arpNoList)
            {
                foreach (var taxDues in GetTaxDues(arpNo))
                {
                    bool isChecked = taxDues.IsChecked;
                    int id = taxDues.Id;
                    int year = taxDues.Year;
                    string completeArpNo = taxDues.CompleteArpNo;
                    decimal assessedValue = taxDues.AssessedValue;
                    decimal taxDue = taxDues.TaxDue;
                    decimal discountRate = taxDues.DiscountRate;
                    bool discountIsAdvance = taxDues.DiscountIsAdvance;
                    decimal discount = taxDues.Discount;
                    decimal penalty = taxDues.Penalty;
                    decimal totalTaxDue = taxDues.TotalTaxDue;

                    dataTable.Rows.Add(isChecked, id, year, completeArpNo, assessedValue, taxDue, discountRate, discountIsAdvance, discount, penalty, totalTaxDue);
                }
            }

            return dataTable;
        }

        private List<rptConslidatedTaxDuesModel> GetTaxDues(string completeArpNo)
        {
            var taxDuesList = new List<rptConslidatedTaxDuesModel>();
            var dtAssessmentPosting = AccFactory.RptAssessmentPostsRepository().GetRecordsByArpNo(completeArpNo);

            foreach (DataRow row in dtAssessmentPosting.Rows)
            {
                int rowId = Convert.ToInt32(row["id"]);
                string rowCompleteArpNo = row["complete_arp_no"].ToString();
                DateTime assessmentPostsDate = Convert.ToDateTime(row["posted_at"]);
                decimal assessedValue = Convert.ToDecimal(row["assessed_value"]);
                int assessmentYear = Convert.ToInt32(row["year"]);
                int effectivityYear = Convert.ToInt32(row["effectivity_year"]);
                int effectivityQuarter = Convert.ToInt32(row["effectivity_quarterly"]);

                decimal basicRate = Convert.ToDecimal(row["basic_rate"]);

                decimal sefRate = Convert.ToDecimal(row["sef_rate"]);
                decimal basicSefTotalTaxDue = taxDueComputations.GetSefBasicTotalTaxDue(basicRate, sefRate, assessedValue);

                #region Getting Discount

                bool discountIsAdvance = false;
                decimal discountRate = taxDueComputations.GetCurrentDiscountRate(assessmentPostsDate, assessmentYear, ref discountIsAdvance);
                decimal discountAmount = taxDueComputations.GetDiscount(discountRate, basicSefTotalTaxDue);

                #endregion

                #region Getting Penalties

                int previousAssessmentCount = AccFactory.RptAssessmentPostsRepository().PreviousAssessmentPostCount(rowCompleteArpNo, assessmentYear);
                int delinquentMonths = taxDueComputations.GetCurrentMonthsDelinquent(assessmentYear, assessmentPostsDate, effectivityYear, previousAssessmentCount);
                decimal penaltyRate = Convert.ToDecimal(row["penalty_rate"]);
                decimal penaltyAmount = taxDueComputations.GetPenalty(penaltyRate, delinquentMonths, basicSefTotalTaxDue);

                #endregion

                #region Getting Total Tax Due

                decimal totalTaxDue = (basicSefTotalTaxDue + penaltyAmount) - discountAmount;

                #endregion

                var model = new rptConslidatedTaxDuesModel()
                {
                    IsChecked = true,
                    Id = rowId,
                    Year = assessmentYear,
                    CompleteArpNo = completeArpNo,
                    AssessedValue = assessedValue,
                    TaxDue = basicSefTotalTaxDue,
                    DiscountRate = discountRate,
                    DiscountIsAdvance = discountIsAdvance,
                    Discount = discountAmount,
                    Penalty = penaltyAmount,
                    TotalTaxDue = totalTaxDue
                };

                taxDuesList.Add(model);
            }

            return taxDuesList;
        }

        private void LoadTaxDues(DataGridView dgvProperties, DataGridView dgvTaxDues)
        {
            try
            {
                Cursor = Cursors.WaitCursor;

                if (dgvProperties.Rows.Count < 1)
                    return;

                var arpNoList = new List<string>();

                foreach (DataGridViewRow row in dgvProperties.Rows)
                {
                    string arpNo = row.Cells["complete_arp_no"].Value.ToString();
                    bool isChecked = Convert.ToBoolean(row.Cells["is_checked"].Value);

                    if (isChecked)
                        arpNoList.Add(arpNo);
                }

                HelperLoadRecords.PropertiesTaxDuesDatagridView(TaxDuesDataTable(arpNoList), dataGridView2);

                chckBxTaxDues.Checked = false;
                txtTotalDue.Text = GetSelectedTotalTaxDues(dgvTaxDues).ToString("N2");
                txtTotalAvgTaxDue.Text = GetTotalTaxDues(dgvTaxDues).ToString("N2");
                Helper.CheckUncheckCheckBoxHeader(dataGridView2, "is_checked", chckBxTaxDues);
                EnableDisableButtons(btnPrintTaxBill, btnApply, dataGridView2);

                Cursor = Cursors.Default;
            }
            catch (Exception ex)
            {
                Helper.MessageBoxError(ex.Message);
                Cursor = Cursors.Default;
            }
        }

        private decimal GetSelectedTotalTaxDues(DataGridView dataGridView)
        {
            decimal totalTaxDues = 0;

            foreach (DataGridViewRow row in dataGridView.Rows)
            {
                bool isChecked = Convert.ToBoolean(row.Cells["is_checked"].Value);

                if (isChecked)
                    totalTaxDues += Convert.ToDecimal(row.Cells["total_tax_due"].Value);
            }

            return totalTaxDues;
        }

        private decimal GetTotalTaxDues(DataGridView dataGridView)
        {
            decimal totalTaxDues = 0;

            foreach (DataGridViewRow row in dataGridView.Rows)
            {
                totalTaxDues += Convert.ToDecimal(row.Cells["total_tax_due"].Value);
            }

            return totalTaxDues;
        }

        private void chckBxTaxDues_MouseClick(object sender, MouseEventArgs e)
        {
            if (chckBxTaxDues.Checked)
                Helper.CheckUncheckCheckBoxRows(dataGridView2, "is_checked", true);
            else
                Helper.CheckUncheckCheckBoxRows(dataGridView2, "is_checked", false);
        }

        private void EnableDisableButtons(ToolStripButton btnTaxBill, Button btnApply, DataGridView dataGridView)
        {
            try
            {
                int checkedItemCount = 0;

                foreach (DataGridViewRow row in dataGridView.Rows)
                {
                    bool isChecked = Convert.ToBoolean(row.Cells["is_checked"].Value);

                    if (isChecked)
                        checkedItemCount += 1;
                }


                if (checkedItemCount > 0)
                {
                    btnTaxBill.Enabled = true;
                    btnApply.Enabled = true;
                }
                else
                {
                    btnTaxBill.Enabled = false;
                    btnApply.Enabled = false;
                }
            }
            catch (Exception ex)
            {
                Helper.MessageBoxError(ex.Message);
            }
        }

        private void dataGridView2_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            Helper.CheckUncheckCheckBoxHeader(dataGridView2, "is_checked", chckBxTaxDues);
            txtTotalDue.Text = GetSelectedTotalTaxDues(dataGridView2).ToString("N2");
            EnableDisableButtons(btnPrintTaxBill, btnApply, dataGridView2);
        }

        private void dataGridView2_CurrentCellDirtyStateChanged(object sender, EventArgs e)
        {
            if (dataGridView2.CurrentCell is DataGridViewCheckBoxCell)
                dataGridView2.CommitEdit(DataGridViewDataErrorContexts.Commit);
        }

        private void dataGridView2_ColumnAdded(object sender, DataGridViewColumnEventArgs e)
        {
            if (e.Column.Name != "is_checked")
                e.Column.ReadOnly = true;
        }

        #endregion

        #region Skipped TaxDue Validations
        private int GetGreatestCheckedYear(DataGridView dataGridView)
        {
            var years = new List<int>();

            foreach (DataGridViewRow row in dataGridView.Rows)
            {
                bool isChecked = Convert.ToBoolean(row.Cells["is_checked"].Value);

                if (isChecked)
                    years.Add(Convert.ToInt32(row.Cells["year"].Value));
            }

            return years.Max();
        }

        private bool ValidateSkipped(DataGridView dataGridView)
        {
            try
            {
                foreach (DataGridViewRow row in dataGridView.Rows)
                {
                    string arpNo = row.Cells["complete_arp_no"].Value.ToString();
                    bool isChecked = Convert.ToBoolean(row.Cells["is_checked"].Value);
                    int year = Convert.ToInt32(row.Cells["year"].Value);

                    if (!isChecked && (year < GetGreatestCheckedYear(dataGridView)))
                        return false;
                }
                return true;
            }
            catch (Exception ex)
            {
                Helper.MessageBoxError(ex.Message);
            }

            return false;
        }
        #endregion

        #region Get Current Detailed Tax Dues

        private List<RptDetailedTaxDuesModel> GetCurrentDetailedTaxDues(string completeArpNo, int year)
        {
            var list = new List<RptDetailedTaxDuesModel>();

            var dictAssessmentPosts = AccFactory.RptAssessmentPostsRepository().GetRecordBy_ArpNo_Year(completeArpNo, year);

            int rowId = Convert.ToInt32(dictAssessmentPosts["id"]);
            string rowCompleteArpNo = dictAssessmentPosts["complete_arp_no"].ToString();
            DateTime rowAssessmentPostsDate = Convert.ToDateTime(dictAssessmentPosts["posted_at"]);
            decimal rowAssessedValue = Convert.ToDecimal(dictAssessmentPosts["assessed_value"]);
            int rowAssessmentYear = Convert.ToInt32(dictAssessmentPosts["year"]);
            int rowEffectivityYear = Convert.ToInt32(dictAssessmentPosts["effectivity_year"]);
            int rowEffectivityQuarter = Convert.ToInt32(dictAssessmentPosts["effectivity_quarterly"]);

            #region Tax Due

            decimal basicRate = Convert.ToDecimal(dictAssessmentPosts["basic_rate"]);
            decimal sefRate = Convert.ToDecimal(dictAssessmentPosts["sef_rate"]);
            decimal basicTaxDueAmount = taxDueComputations.GetBasicTaxDue(basicRate, rowAssessedValue);
            decimal sefTaxDueAmount = taxDueComputations.GetSefTaxDue(sefRate, rowAssessedValue);

            #endregion

            #region Discount

            bool discountIsAdvance = false;
            decimal discountRate = taxDueComputations.GetCurrentDiscountRate(rowAssessmentPostsDate, rowAssessmentYear, ref discountIsAdvance);

            decimal basicDiscountAmount = taxDueComputations.GetDiscount(discountRate, basicTaxDueAmount);
            decimal sefDiscountAmount = taxDueComputations.GetDiscount(discountRate, sefTaxDueAmount);

            #endregion

            #region  Penalty

            int previousAssessmentCount = AccFactory.RptAssessmentPostsRepository().PreviousAssessmentPostCount(rowCompleteArpNo, rowAssessmentYear);
            int delinquentMonths = taxDueComputations.GetCurrentMonthsDelinquent(rowAssessmentYear, rowAssessmentPostsDate, rowEffectivityYear, previousAssessmentCount);
            decimal penaltyRate = Convert.ToDecimal(dictAssessmentPosts["penalty_rate"]);


            decimal basicPenaltyAmount = taxDueComputations.GetPenalty(penaltyRate, delinquentMonths, basicTaxDueAmount);
            decimal sefPenaltyAmount = taxDueComputations.GetPenalty(penaltyRate, delinquentMonths, sefTaxDueAmount);

            #endregion

            #region Total Tax Due

            decimal totalBasicTaxDue = (basicTaxDueAmount + basicPenaltyAmount) - basicDiscountAmount;
            decimal totalSefTaxDue = (sefTaxDueAmount + sefPenaltyAmount) - sefDiscountAmount;

            #endregion


            var basicModel = new RptDetailedTaxDuesModel()
            {
                AssessmentPostId = rowId,
                Year = rowAssessmentYear,
                CompleteArpNo = rowCompleteArpNo,
                TaxType = "Basic",
                TaxDue = basicTaxDueAmount,
                Discount = basicDiscountAmount,
                Penalty = basicPenaltyAmount,
                TotalTaxDue = totalBasicTaxDue
            };

            var sefModel = new RptDetailedTaxDuesModel()
            {
                AssessmentPostId = rowId,
                Year = rowAssessmentYear,
                CompleteArpNo = rowCompleteArpNo,
                TaxType = "SEF",
                TaxDue = sefTaxDueAmount,
                Discount = sefDiscountAmount,
                Penalty = sefPenaltyAmount,
                TotalTaxDue = totalSefTaxDue
            };

            list.Add(basicModel);
            list.Add(sefModel);


            return list;
        }

        private void LoadCurrentDetailedTaxDues()
        {
            try
            {
                var list = new List<RptDetailedTaxDuesModel>();

                foreach (DataGridViewRow row in dataGridView2.Rows)
                {
                    bool isChecked = Convert.ToBoolean(row.Cells["is_checked"].Value);
                    string completeArpNo = row.Cells["complete_arp_no"].Value.ToString();
                    int year = Convert.ToInt32(row.Cells["year"].Value);

                    if (isChecked)
                        list.AddRange(GetCurrentDetailedTaxDues(completeArpNo, year));
                }

                _frmPropertyPayment.LoadRptDetailedTaxDues(list);
            }
            catch (Exception ex)
            {
                Helper.MessageBoxError(ex.Message);
            }
        }

        #endregion

        //Tax Dues for Saving
        private void ApplyTaxDues()
        {
            var rptTaxDuesModelList = new List<RptTaxDuesModel>();
            var dtDgvTaxDues = (DataTable)dataGridView2.DataSource;

            foreach (DataRow row in dtDgvTaxDues.Rows)
            {
                bool isChecked = Convert.ToBoolean(row["is_checked"]);
                int assessmentPostsId = Convert.ToInt32(row["id"]);
                decimal discountRate = Convert.ToDecimal(row["discount_rate"]);
                bool discountIsAdvance = Convert.ToBoolean(row["discount_is_advance"]);

                var rptTaxDuesModel = new RptTaxDuesModel()
                {
                    RptAssessmentPostId = assessmentPostsId,
                    DiscountRate = discountRate,
                    IsAdvance = discountIsAdvance
                };

                if (isChecked)
                    rptTaxDuesModelList.Add(rptTaxDuesModel);
            }

            _frmPropertyPayment.rptTaxDuesModels = rptTaxDuesModelList;
        }

        private void btnApply_Click(object sender, EventArgs e)
        {
            if (!ValidateSkipped(dataGridView2))
            {
                Helper.MessageBoxError("Skipped Tax Due/s.");
                return;
            }

            LoadCurrentDetailedTaxDues();
            ApplyTaxDues();
            Close();
        }

        #region Report Tax Dues

        private rptTaxDueBillReportModel GetRptTaxDueBillData(string completeArpNo, int assessmentYear) 
        {
            var rptTaxDueBillReport = new List<rptTaxDueBillReportModel>();
            var dictAssessmentPosts = AccFactory.RptAssessmentPostsRepository().GetRecordBy_ArpNo_Year(completeArpNo, assessmentYear);

                int rowId = Convert.ToInt32(dictAssessmentPosts["id"]);
                string rowCompleteArpNo = dictAssessmentPosts["complete_arp_no"].ToString();
                DateTime rowAssessmentPostsDate = Convert.ToDateTime(dictAssessmentPosts["posted_at"]);
                decimal rowAssessedValue = Convert.ToDecimal(dictAssessmentPosts["assessed_value"]);
                int rowAssessmentYear = Convert.ToInt32(dictAssessmentPosts["year"]);
                int rowEffectivityYear = Convert.ToInt32(dictAssessmentPosts["effectivity_year"]);
                int rowEffectivityQuarter = Convert.ToInt32(dictAssessmentPosts["effectivity_quarterly"]);
                decimal rowArea = Convert.ToDecimal(dictAssessmentPosts["area"]);
                string rowActualUseName = dictAssessmentPosts["actual_use_name"].ToString();
                string rowPropertyKind = dictAssessmentPosts["property_kind"].ToString();
                string rowBarangayName = dictAssessmentPosts["barangay_name"].ToString();

                #region Tax Due

                decimal rowBasicRate = Convert.ToDecimal(dictAssessmentPosts["basic_rate"]);
                decimal rowSefRate = Convert.ToDecimal(dictAssessmentPosts["sef_rate"]);
                decimal basicTaxDueAmount = taxDueComputations.GetBasicTaxDue(rowBasicRate, rowAssessedValue);
                decimal sefTaxDueAmount = taxDueComputations.GetSefTaxDue(rowSefRate, rowAssessedValue);
                decimal rowBasicSefTotalTaxDue = taxDueComputations.GetSefBasicTotalTaxDue(rowBasicRate, rowSefRate, rowAssessedValue); 

                #endregion

                #region Getting Discount

                bool discountIsAdvance = false;
                decimal discountRate = taxDueComputations.GetCurrentDiscountRate(rowAssessmentPostsDate, rowAssessmentYear, ref discountIsAdvance);
                decimal discountAmount = taxDueComputations.GetDiscount(discountRate, rowBasicSefTotalTaxDue);

                #endregion

                #region Getting Penalties

                int previousAssessmentCount = AccFactory.RptAssessmentPostsRepository().PreviousAssessmentPostCount(rowCompleteArpNo, rowAssessmentYear);
                int delinquentMonths = taxDueComputations.GetCurrentMonthsDelinquent(rowAssessmentYear, rowAssessmentPostsDate, rowEffectivityYear, previousAssessmentCount);
                decimal rowPenaltyRate = Convert.ToDecimal(dictAssessmentPosts["penalty_rate"]);
                decimal penaltyAmount = taxDueComputations.GetPenalty(rowPenaltyRate, delinquentMonths, rowBasicSefTotalTaxDue);

                #endregion

                #region Getting Total Tax Due

                decimal totalTaxDue = (rowBasicSefTotalTaxDue + penaltyAmount) - discountAmount;

                #endregion

                var model = new rptTaxDueBillReportModel()
                {
                    CompleteArpNo = rowCompleteArpNo,
                    AssessedValue = rowAssessedValue,
                    Area = rowArea,
                    Classification = rowActualUseName,
                    Kind = rowPropertyKind,
                    Location = rowBarangayName,
                    BasicTax = basicTaxDueAmount,
                    SefTax = sefTaxDueAmount,
                    LotNo = string.Empty,
                    Discount = discountAmount,
                    Penalty = penaltyAmount,
                    TaxYear = rowAssessmentYear,
                    netTaxDue = totalTaxDue
                };


            return model;
        }

        private DataTable RptTaxDueBillDataTable() 
        {
            var dataTable = new dsLFS.dtRPTDueBillDataTable();

            foreach (DataGridViewRow row in dataGridView2.Rows)
            {
                bool isChecked = Convert.ToBoolean(row.Cells["is_checked"].Value);
                string completeArpNo = row.Cells["complete_arp_no"].Value.ToString();
                int assessmentYear = Convert.ToInt32(row.Cells["year"].Value);
                var getTaxDueBillData = GetRptTaxDueBillData(completeArpNo, assessmentYear);
                var newRow = dataTable.NewRow();

                if (!isChecked)
                    continue;

                newRow["arp_no"] = getTaxDueBillData.CompleteArpNo;
                newRow["kind"] = getTaxDueBillData.Kind;
                newRow["classification"] = getTaxDueBillData.Classification;
                newRow["lot_no"] = getTaxDueBillData.LotNo;
                newRow["location"] = getTaxDueBillData.Location;
                newRow["tax_year"] = getTaxDueBillData.TaxYear;
                newRow["area"] = getTaxDueBillData.Area;
                newRow["assessed_value"] = getTaxDueBillData.AssessedValue;
                newRow["basic_tax"] = getTaxDueBillData.BasicTax;
                newRow["sef_tax"] = getTaxDueBillData.SefTax;
                newRow["discount"] = getTaxDueBillData.Discount;
                newRow["penalty"] = getTaxDueBillData.Penalty;
                newRow["net_tax_due"] = getTaxDueBillData.netTaxDue;

                dataTable.Rows.Add(newRow);
            }

            return dataTable;
        }        

        private void btnPrintTaxBill_Click(object sender, EventArgs e)
        {

            _ = new frmRptTaxDueBillReport(RptTaxDueBillDataTable(), _frmPropertyPayment.paymentTaxPayerInfoModel).ShowDialog();
        }
        
        #endregion
    }
}
