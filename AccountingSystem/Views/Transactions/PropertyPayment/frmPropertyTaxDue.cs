using AccountingSystem.Views.Transactions.PaymentPosting;
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
            HelperLoadRecords.TaxPayerDues(dataGridView2);
        }

        private DataTable DataTableProperties() 
        {
            bool isCancelled = chckBxCancelled.Checked;
            var dtAssessmentPosting = AccFactory.AssessmentPostsRepository().GetRecordsByOwnerName_IsCancelled(_ownerName, isCancelled);
            var dataTable = new DataTable();

            var dataColumns= new DataColumn[]
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

        private void frmRptTaxDue_Load(object sender, EventArgs e)
        {
            LoadProperties();
        }

        #region Properties

        private void LoadProperties()
        {
            try
            {
                HelperLoadRecords.TaxPayerProperties(dataGridView1, DataTableProperties());
                Helper.CheckUncheckCheckBoxHeader(dataGridView1, "is_checked", chckBoxProperties);
                dataGridView2.Rows.Clear();
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

        #region Tax Dues

        private void LoadTaxDues(DataGridView dgvProperties, DataGridView dgvTaxDues)
        {
            if (dgvProperties.Rows.Count < 1)
                return;

            dgvTaxDues.Rows.Clear();
            chckBxTaxDues.Checked = false;

            foreach (DataGridViewRow row in dgvProperties.Rows)
            {
                string arpNo = row.Cells["complete_arp_no"].Value.ToString();
                bool isChecked = Convert.ToBoolean(row.Cells["is_checked"].Value);

                if (isChecked)
                    GetTaxDues(arpNo);
            }
        }

        private void RecalculateDiscountPenalties(DataGridView dgvTaxDues, string arpNo) 
        {
            if (dgvTaxDues.Rows.Count < 1)
                return;



            foreach (DataGridViewRow row in dgvTaxDues.Rows)
            {
                string rowArpNo = row.Cells["complete_arp_no"].Value.ToString();
                bool isChecked = Convert.ToBoolean(row.Cells["is_checked"].Value);

                if (isChecked)
                    GetTaxDues(rowArpNo);
            }
        }

        private int GetQuarterByMonth(int month)
        {
            switch (month)
            {
                case 1:
                case 2:
                case 3:
                    return 1;
                case 4:
                case 5:
                case 6:
                    return 2;
                case 7:
                case 8:
                case 9:
                    return 3;
                case 10:
                case 11:
                case 12:
                    return 4;

                default:
                    return 0;
            }
        }

        private int GetMonthsBetweenYears(int fromYear, int toYear)
        {
            int months = 0;

            for (int i = fromYear; i <= toYear; i++)
            {
                months += 12;
            }

            return months;
        }


        private decimal GetCurrentPenaltyRate(int effectivityYear, int effectivityQuarter)
        {
            DateTime currentDate = DateTime.Now;
            //var dictRptPenalty = AccFactory.rptPenaltiesRepository().GetRecordByID(9);
            //var penaltyRate = dictRptPenalty == null ? 0 : Convert.ToDecimal(dictRptPenalty);

            if (effectivityYear >= currentDate.Year)
                return 0;

            int quarter = effectivityQuarter - 1;
            double totalPenaltyRate = GetMonthsBetweenYears(effectivityYear, currentDate.Year) - quarter * 3;
            return Convert.ToDecimal(totalPenaltyRate);
        }

        private decimal GetPenalty(decimal penaltyRate, decimal taxDue)
        {          
            decimal penalty = taxDue * penaltyRate;
            return penalty;
        }

        private decimal GetCurrentDiscountRate(DateTime assessmentPostDate, int effectivityYear, int effectivityQuarter)
        {
            DateTime currentDate = DateTime.Now;
            int postYear = assessmentPostDate.Year;
            int postMonth = assessmentPostDate.Month;
            decimal discountRate;

            if (effectivityYear < currentDate.Year)
                return 0;

            if (postYear <= currentDate.Year && effectivityYear > currentDate.Year)
            {
                var dictDiscount = AccFactory.rptDiscountRepository().GetRecordByMonth(10, true);
                discountRate = dictDiscount == null ? 0 : Convert.ToDecimal(dictDiscount["rate"]);
            }
            else if (postYear == currentDate.Year && (postMonth == 1 || postMonth == 2 || postMonth == 3))
            {
                var dictDiscount = AccFactory.rptDiscountRepository().GetRecordByMonth(postMonth, false);
                discountRate = dictDiscount == null ? 0 : Convert.ToDecimal(dictDiscount["rate"]);
            }
            else
                discountRate = 0;

            return discountRate;
        }

        private decimal GetDiscount(decimal discountRate, decimal taxDue)
        {
            decimal discount = taxDue * discountRate;
            return discount;
        }

        private decimal GetSefTaxDue(decimal sefTaxRate, decimal assessedValue)
        {           
            decimal sef = assessedValue * sefTaxRate;
            return sef;
        }

        private decimal GetBasicTaxDue(decimal basicTaxRate, decimal assessedValue) 
        {
            decimal basic = assessedValue * basicTaxRate;
            return basic;   
        }


        private decimal GetTotalBasic(decimal taxDue, decimal discount, decimal penalty)
        {
            decimal totalBasic = (taxDue + penalty) - discount;
            return totalBasic;
        }

        private decimal GetTotalSef(decimal taxDue, decimal discount, decimal penalty)
        {
            decimal totalSef = (taxDue + penalty) - discount;
            return totalSef;
        }


        private decimal GetSefBasicTotalTaxDue(decimal basicTaxRate, decimal sefTaxRate, decimal assessedValue)
        {
            decimal basicTaxDue = GetBasicTaxDue(basicTaxRate, assessedValue);
            decimal sefTaxDue = GetSefTaxDue(sefTaxRate, assessedValue);

            return basicTaxDue + sefTaxDue;
        }

        private decimal GetTotalTaxDue(decimal basicTaxRate, decimal sefTaxRate, decimal discountRate, decimal penaltyRate, decimal assessedValue)
        {
          
            decimal basicTaxDue = GetBasicTaxDue(basicTaxRate, assessedValue);
            decimal basicDiscount = GetDiscount(discountRate, basicTaxDue);
            decimal basicPenalty = 0;

            decimal sefTaxDue = GetSefTaxDue(sefTaxRate, assessedValue);
            decimal sefDiscount = GetDiscount(discountRate, sefTaxDue);
            decimal sefPenalty = 0;

            decimal totalBasic = GetTotalBasic(basicTaxDue, basicDiscount, basicPenalty);
            decimal totalSef = GetTotalSef(sefTaxDue, sefDiscount, sefPenalty);
            decimal totalTaxDue = totalBasic + totalSef;

            return totalTaxDue;
        }

        private void GetTaxDues(string completeArpNo)
        {
            var dtAssessmentPosting = AccFactory.AssessmentPostsRepository().GetRecordsByArpNo(completeArpNo);

            foreach (DataRow row in dtAssessmentPosting.Rows)
            {
                int year = Convert.ToDateTime(row["posted_at"]).Year;
                string arpNo = row["complete_arp_no"].ToString();
                DateTime postedAt = Convert.ToDateTime(row["posted_at"]);
                decimal assessedValue = Convert.ToDecimal(row["assessed_value"]);
                int effectivityYear = Convert.ToInt32(row["effectivity_year"]);
                int effectivityQuarter = Convert.ToInt32(row["effectivity_quarterly"]);

                decimal penaltyRate = Convert.ToDecimal(row["penalty_rate"]);
                decimal basicRate = Convert.ToDecimal(row["basic_rate"]);
              
                decimal sefRate = Convert.ToDecimal(row["sef_rate"]);
                decimal basicSefTotalTaxDue = GetSefBasicTotalTaxDue(basicRate, sefRate, assessedValue);
                decimal discountRate = GetCurrentDiscountRate(postedAt, effectivityYear, effectivityQuarter);

                dataGridView2.Rows.Add(false,
                                        effectivityYear, 
                                        arpNo, 
                                        assessedValue,
                                        basicSefTotalTaxDue, 
                                        GetDiscount(discountRate, basicSefTotalTaxDue), 
                                        GetCurrentPenaltyRate(effectivityYear, effectivityQuarter), 
                                        GetTotalTaxDue(basicRate, sefRate, discountRate, penaltyRate, assessedValue));
            }
        }

        private void chckBxTaxDues_MouseClick(object sender, MouseEventArgs e)
        {
            if (chckBxTaxDues.Checked)
                Helper.CheckUncheckCheckBoxRows(dataGridView2, "is_checked", true);
            else
                Helper.CheckUncheckCheckBoxRows(dataGridView2, "is_checked", false);
        }

        private void dataGridView2_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            Helper.CheckUncheckCheckBoxHeader(dataGridView2, "is_checked", chckBxTaxDues);
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

        private void btnRecalculate_Click(object sender, EventArgs e)
        {

        }
    }
}
