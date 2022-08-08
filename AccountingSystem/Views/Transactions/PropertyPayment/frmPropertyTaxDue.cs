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
        }

        private void frmRptTaxDue_Load(object sender, EventArgs e)
        {
            LoadProperties();
        }

        #region Properties

        private DataTable DataTableProperties()
        {
            bool isCancelled = chckBxCancelled.Checked;
            var dtAssessmentPosting = AccFactory.AssessmentPostsRepository().GetRecordsByOwnerName_IsCancelled(_ownerName, isCancelled);
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
                HelperLoadRecords.TaxPayerProperties(dataGridView1, DataTableProperties());
                Helper.CheckUncheckCheckBoxHeader(dataGridView1, "is_checked", chckBoxProperties);
                LoadTaxDues(dataGridView1, dataGridView2);

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
                new DataColumn("discount", typeof(decimal)),
                new DataColumn("penalty", typeof(decimal)),
                new DataColumn("total_tax_due", typeof(decimal))
            };

            dataTable.Columns.AddRange(columns);

            foreach (var arpNo in arpNoList)
            {
                foreach (var taxDues in GetTaxDues(arpNo))
                {
                    dataTable.Rows.Add(taxDues);
                }
            }

            return dataTable;
        }

        private List<dynamic[]> GetTaxDues(string completeArpNo)
        {
            var taxDuesList = new List<dynamic[]>();
            var dtAssessmentPosting = AccFactory.AssessmentPostsRepository().GetRecordsByArpNo(completeArpNo);

            foreach (DataRow row in dtAssessmentPosting.Rows)
            {
                int rowId = Convert.ToInt32(row["id"]);
                string rowCompleteArpNo = row["complete_arp_no"].ToString();
                DateTime postedAt = Convert.ToDateTime(row["posted_at"]);
                decimal assessedValue = Convert.ToDecimal(row["assessed_value"]);
                int year = Convert.ToInt32(row["year"]);
                int effectivityYear = Convert.ToInt32(row["effectivity_year"]);
                int effectivityQuarter = Convert.ToInt32(row["effectivity_quarterly"]);


                decimal basicRate = Convert.ToDecimal(row["basic_rate"]);

                decimal sefRate = Convert.ToDecimal(row["sef_rate"]);
                decimal basicSefTotalTaxDue = taxDueComputations.GetSefBasicTotalTaxDue(basicRate, sefRate, assessedValue);


                //Discount
                decimal discountRate = taxDueComputations.GetCurrentDiscountRate(postedAt, year, effectivityYear, effectivityQuarter);
                decimal discountAmount = taxDueComputations.GetDiscount(discountRate, basicSefTotalTaxDue);

                //Penalties
                int previousAssessmentCount = AccFactory.AssessmentPostsRepository().PreviousAssessmentPostCount(rowCompleteArpNo, year);
                int delinquentMonths = taxDueComputations.GetCountMonthsDelinquent(year, postedAt, effectivityQuarter, effectivityYear, previousAssessmentCount);
                decimal penaltyRate = Convert.ToDecimal(row["penalty_rate"]);
                decimal penaltyAmount = taxDueComputations.GetPenalty(penaltyRate, delinquentMonths, basicSefTotalTaxDue);

                //TotalTaxDue
                decimal totalTaxDue = (basicSefTotalTaxDue + penaltyAmount) - discountAmount;

                var rowValue = new dynamic[] { true, rowId, year, rowCompleteArpNo, assessedValue, basicSefTotalTaxDue, discountAmount, penaltyAmount, totalTaxDue };

                taxDuesList.Add(rowValue);
            }

            return taxDuesList;
        }

        private void LoadTaxDues(DataGridView dgvProperties, DataGridView dgvTaxDues)
        {
            try
            {
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
            }
            catch (Exception ex)
            {
                Helper.MessageBoxError(ex.Message);
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

        private void dataGridView2_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            Helper.CheckUncheckCheckBoxHeader(dataGridView2, "is_checked", chckBxTaxDues);
            txtTotalDue.Text = GetSelectedTotalTaxDues(dataGridView2).ToString("N2");
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

        private void btnApply_Click(object sender, EventArgs e)
        {
            if (!ValidateSkipped(dataGridView2))
                Helper.MessageBoxError("Skipped Tax Due/s.");
        }
    }
}
