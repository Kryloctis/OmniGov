using AccountingSystem.Views.Transactions.PaymentPostings.RPT_PaymentPosting;
using AccountingSystem.Views.Transactions.PropertyPayment.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static AccountingSystem.Views.Transactions.PaymentPosting.frmPropertyPayment;

namespace AccountingSystem.Views.Transactions.PaymentPosting
{
    public partial class frmTaxPayerPaymentHistory : Form
    {
        private readonly frmPropertyPayment _frmPropertyPayment;
        private readonly string _taxPayerName;

        public frmTaxPayerPaymentHistory(frmPropertyPayment frmPaymentPosting, string TaxPayerName)
        {
            InitializeComponent();
            _frmPropertyPayment = frmPaymentPosting;
            Helper.LoadFormIcon(this);
            Helper.DatagridFullRowSelectStyle(dataGridView1, true);
            _taxPayerName = TaxPayerName;
        }

        private void LoadPaymentHistory()
        {
            try
            {
                Cursor = Cursors.WaitCursor;
                var dateFrom = dtPckDateFrom.Value;
                var dateTo = dtPckDateTo.Value;

                var dtPaymentPosts = AccFactory.RptPaymentPostsRepository().GetViewRecordsByDateTaxPayerName(dateFrom, dateTo, _taxPayerName);
                HelperLoadRecords.PaymentHistoryDataGridView(dataGridView1, dtPaymentPosts);
                dataGridView1.CurrentCell = dataGridView1.FirstDisplayedCell;

                Cursor = Cursors.Default;
            }
            catch (Exception ex)
            {
                Helper.MessageBoxError(ex.Message);
            }
        }

        private void frmTaxPayerPaymentHistory_Load(object sender, EventArgs e)
        {
            dtPckDateFrom.Value = new DateTime(dtPckDateFrom.Value.Year, dtPckDateFrom.Value.Month, 1);
            LoadPaymentHistory();
            EnableDisableButtons(btnPrintReceipt, btnSelect);
        }

        private void dtPckDateFrom_ValueChanged(object sender, EventArgs e)
        {
            LoadPaymentHistory();
        }

        private void dtPckDateTo_ValueChanged(object sender, EventArgs e)
        {
            LoadPaymentHistory();
        } 

        private void EnableDisableButtons(ToolStripButton btnPrintRecieipt, Button btnSelect)
        {
            int selectedRowCount = dataGridView1.SelectedRows.Count;

            if(selectedRowCount == 0 || selectedRowCount > 1)
            {
                btnPrintRecieipt.Enabled = false;
                btnSelect.Enabled = false;
            }
            else
            {
                btnPrintRecieipt.Enabled = true;
                btnSelect.Enabled = true;
            }
        }

        private void dataGridView1_SelectionChanged(object sender, EventArgs e)
        {
            EnableDisableButtons(btnPrintReceipt, btnSelect);
        }

        #region Get Selected Detailed Tax Dues

        private List<RptDetailedTaxDuesModel> GetSelectedDetailedTaxDues(int paymentPostId)
        {
            var list = new List<RptDetailedTaxDuesModel>();

            var dtRptTaxDues = AccFactory.RptTaxDuesRepository().GetViewRecordsByRptPaymentPostsId(paymentPostId);

            foreach (DataRow row in dtRptTaxDues.Rows)
            {

                int assessmentPostId = Convert.ToInt32(row["rpt_assessment_posts_id"]);
                string rowCompleteArpNo = row["complete_arp_no"].ToString();
                DateTime rowAssessmentPostsDate = Convert.ToDateTime(row["posted_at"]);
                decimal rowAssessedValue = Convert.ToDecimal(row["assessed_value"]);
                int rowAssessmentYear = Convert.ToInt32(row["year"]);
                int rowEffectivityYear = Convert.ToInt32(row["effectivity_year"]);
                int rowEffectivityQuarter = Convert.ToInt32(row["effectivity_quarterly"]);

                #region Tax Due

                decimal basicRate = Convert.ToDecimal(row["basic_rate"]);
                decimal sefRate = Convert.ToDecimal(row["sef_rate"]);
                decimal basicTaxDueAmount = taxDueComputations.GetBasicTaxDue(basicRate, rowAssessedValue);
                decimal sefTaxDueAmount = taxDueComputations.GetSefTaxDue(sefRate, rowAssessedValue);

                #endregion

                #region Discount

                bool discountIsAdvance = Convert.ToBoolean(row["is_advance"]);
                decimal discountRate = Convert.ToDecimal(row["discount_rate"]);

                decimal basicDiscountAmount = taxDueComputations.GetDiscount(discountRate, basicTaxDueAmount);
                decimal sefDiscountAmount = taxDueComputations.GetDiscount(discountRate, sefTaxDueAmount);

                #endregion

                #region  Penalty

                int previousAssessmentCount = AccFactory.RptAssessmentPostsRepository().PreviousAssessmentPostCount(rowCompleteArpNo, rowAssessmentYear);
                int delinquentMonths = taxDueComputations.GetCurrentMonthsDelinquent(rowAssessmentYear, rowAssessmentPostsDate, rowEffectivityYear, previousAssessmentCount);
                decimal penaltyRate = Convert.ToDecimal(row["penalty_rate"]);


                decimal basicPenaltyAmount = taxDueComputations.GetPenalty(penaltyRate, delinquentMonths, basicTaxDueAmount);
                decimal sefPenaltyAmount = taxDueComputations.GetPenalty(penaltyRate, delinquentMonths, sefTaxDueAmount);

                #endregion

                #region Total TaxDue

                decimal totalBasicTaxDue = (basicTaxDueAmount + basicPenaltyAmount) - basicDiscountAmount;
                decimal totalSefTaxDue = (sefTaxDueAmount + sefPenaltyAmount) - sefDiscountAmount;

                #endregion

                var basicModel = new RptDetailedTaxDuesModel()
                {
                    AssessmentPostId = assessmentPostId,
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
                    AssessmentPostId = assessmentPostId,
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
            }

            return list;
        }

        private void LoadSelectedDetailedTaxDues()
        {
            int rowIndex = dataGridView1.CurrentRow.Index;
            int paymentPostsId = Convert.ToInt32(dataGridView1.Rows[rowIndex].Cells["rpt_payment_posts_id"].Value);

            _frmPropertyPayment.CancelTransaction();
            _frmPropertyPayment.LoadSelectedDetailedTaxDues(GetSelectedDetailedTaxDues(paymentPostsId), paymentPostsId);

            Close();
        }

        #endregion

        private void btnSelect_Click(object sender, EventArgs e)
        {            
            LoadSelectedDetailedTaxDues();
        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex > -1)
                LoadSelectedDetailedTaxDues();
        }
    }
}
