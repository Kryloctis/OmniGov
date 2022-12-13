using ACC.Domain.Interfaces;
using AccountingSystem.Views.Shared;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace AccountingSystem.Views.Transactions.Payments.RealProperty
{
    public partial class ucRptTaxDues : UserControl
    {
        internal int taxpayersId;
        private readonly string decimalFormat = "#,###,###,###.00 ;(#,###,###,###.00)";

        public ucRptTaxDues()
        {
            InitializeComponent();
        }

        internal string GetFormErrors()
        {
            var errorStrings = new string[]
            {
                dgTaxDues.Tag.ToString(),
            };

            IError errors = AccFactory.CreateErrors(errorStrings);
            return errors.GenerateErrorMessage();
        }

        private void OnLoad()
        {
            Helper.DatagridFullRowSelectStyle(dgProperties, false, false);
            Helper.DatagridFullRowSelectStyle(dgTaxDues, false, false);
        }

        private void ucRptTaxDues_Load(object sender, EventArgs e)
        {
            try
            {
                OnLoad();
            }
            catch (Exception ex) { Helper.MessageBoxError(ex.Message); }
        }

        //Properties DatagridView

        private DataColumn[] DataColumnsPostedProperties()
        {
            return new DataColumn[]
            {
                new DataColumn("is_selected", typeof(bool)),
                new DataColumn("id", typeof(int)),
                 new DataColumn("kind", typeof(string)),
                new DataColumn("real_taxpayers_id", typeof(int)),
                new DataColumn("complete_arp_no", typeof(string)),
                new DataColumn("property_pin", typeof(string)),
                new DataColumn("full_address", typeof(string))
            };
        }

        private DataTable DataTablePostedProperties()
        {
            bool showCancelled = chckBxCancelled.Checked;
            var dtAssessmentPosts = AccFactory.RptAssessmentPostsRepository().GetRecordsByRealTaxpayersId(taxpayersId, showCancelled);
            var dataTable = new DataTable();
            dataTable.Columns.AddRange(DataColumnsPostedProperties());

            foreach (DataRow row in dtAssessmentPosts.Rows)
            {
                var newRow = dataTable.NewRow();

                newRow["is_selected"] = false;
                newRow["id"] = row["id"];
                newRow["real_taxpayers_id"] = row["real_taxpayers_id"];
                newRow["complete_arp_no"] = row["complete_arp_no"];
                newRow["property_pin"] = row["property_pin"];
                newRow["full_address"] = Helper.GenerateFullAddress(row["street"].ToString(), row["barangay_name"].ToString(), row["municipality_name"].ToString(), row["province_name"].ToString());
                newRow["kind"] = row["property_kind"];
                dataTable.Rows.Add(newRow);
            }
            return dataTable;
        }

        internal void LoadPostedProperties()
        {
            try
            {
                HelperLoadRecords.DatagridViewPaymentTaxpayerProperties(dgProperties, DataTablePostedProperties());
                chckBoxProperties.Checked = false;
                LoadTaxDues(dgTaxDues);
            }
            catch (Exception ex) { Helper.MessageBoxError(ex.Message); }
        }

        private void chckBoxProperties_MouseClick(object sender, MouseEventArgs e)
        {
            try
            {
                bool isChecked = chckBoxProperties.Checked;
                Helper.CheckUncheckCheckBoxRows(dgProperties, "is_selected", isChecked);
            }
            catch (Exception ex) { Helper.MessageBoxError(ex.Message); }
        }

        private void dgProperties_CurrentCellDirtyStateChanged(object sender, EventArgs e)
        {
            if (dgProperties.CurrentCell is DataGridViewCheckBoxCell)
                dgProperties.CommitEdit(DataGridViewDataErrorContexts.Commit);
        }

        private void dgProperties_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                Helper.CheckUncheckCheckBoxHeader(dgProperties, "is_selected", chckBoxProperties);
                LoadTaxDues(dgTaxDues);
            }
            catch (Exception ex) { Helper.MessageBoxError(ex.Message); }
        }

        private void dgProperties_ColumnAdded(object sender, DataGridViewColumnEventArgs e)
        {
            try
            {
                if (e.Column.Name != "is_selected")
                    e.Column.ReadOnly = true;
            }
            catch (Exception ex) { Helper.MessageBoxError(ex.Message); }
        }

        private void chckBxCancelled_CheckedChanged(object sender, EventArgs e)
        {
            LoadPostedProperties();
        }

        #region Validations

        private bool TaxDuesValidated()
        {
            var skippedTaxDues = new List<string>();
            int selectedTaxDuesCount = 0;
            List<string> completeArpNoList = new List<string>();

            //ArpNos
            foreach (DataGridViewRow row in dgProperties.Rows)
            {
                bool isSelected = Convert.ToBoolean(row.Cells["is_selected"].Value);
                string completeArpNo = row.Cells["complete_arp_no"].Value.ToString();
                if (isSelected)
                    completeArpNoList.Add(completeArpNo);
            }

            //Check for skipped Years
            foreach (string completeArpNo in completeArpNoList)
            {
                var selectedYears = new List<int>();
                var notSelectedYears = new List<int>();

                foreach (DataGridViewRow row in dgTaxDues.Rows)
                {
                    int year = Convert.ToInt32(row.Cells["year"].Value);
                    bool isSelected = Convert.ToBoolean(row.Cells["is_selected"].Value);
                    string rowcompleteArpNo = row.Cells["complete_arp_no"].Value.ToString();
                    if (rowcompleteArpNo == completeArpNo)
                    {
                        if (isSelected)
                        {
                            selectedYears.Add(year);
                            selectedTaxDuesCount++;
                        }
                        else
                            notSelectedYears.Add(year);
                    }
                }

                foreach (int notSelectedYear in notSelectedYears)
                {
                    foreach (int selectedYear in selectedYears)
                    {
                        if (notSelectedYear < selectedYear)
                            skippedTaxDues.Add(completeArpNo);
                    }
                }
            }

            if (selectedTaxDuesCount < 1)
            {
                dgTaxDues.Tag = "No tax due/s has been selected";
                return false;
            }

            if (skippedTaxDues.Count > 0)
            {
                var sb = new StringBuilder();
                sb.AppendLine("Skipped tax due years of properties:");
                skippedTaxDues.Distinct();
                skippedTaxDues.ForEach(x => sb.AppendLine($"  {x}"));
                dgTaxDues.Tag = sb;
                return false;
            }

            dgTaxDues.Tag = string.Empty;
            return true;
        }

        #endregion Validations

        private DataColumn[] DataColumnsTaxDues()
        {
            return new DataColumn[]
            {
                new DataColumn("is_selected", typeof(bool)),
                new DataColumn("assessment_posts_id", typeof(int)),
                new DataColumn("year", typeof(int)),
                new DataColumn("complete_arp_no", typeof(string)),
                new DataColumn("type", typeof(string)),
                new DataColumn("tax_due_amount", typeof(string)),
                new DataColumn("penalty_discount", typeof(string)),
                new DataColumn("total_payment", typeof(string)),
                new DataColumn("total_payment_consolidated", typeof(string))
            };
        }

        private DataTable DataTableTaxDues(int taxPayersId, List<string> completeArpNoList)
        {
            var dataTable = new DataTable();
            dataTable.Columns.AddRange(DataColumnsTaxDues());

            foreach (string completeArpNo in completeArpNoList)
            {
                var dtAssessmentPosting = AccFactory.RptAssessmentPostsRepository().GetViewRptPropertyAssessmentsRecords_By_RealTaxpayersId_CompleteArpNo(taxPayersId, completeArpNo);
                foreach (DataRow row in dtAssessmentPosting.Rows)
                {
                    decimal assessedValue = Convert.ToDecimal(row["assessed_value"]);
                    decimal sefRate = Convert.ToDecimal(row["sef_rate"]);
                    decimal basicRate = Convert.ToDecimal(row["basic_rate"]);
                    decimal penaltyRate = Convert.ToDecimal(row["penalty_rate"]);
                    DateTime postedAt = Convert.ToDateTime(row["posted_at"]);
                    int assessmentPostYear = Convert.ToInt32(row["year"]);
                    int effectivityYear = Convert.ToInt32(row["effectivity_year"]);
                    bool discountIsAdvance = false;
                    decimal currentDiscountRate = RealPropertyTaxComputations.GetCurrentDiscountRate(postedAt, assessmentPostYear, ref discountIsAdvance);
                    int previousAssessmentCount = AccFactory.RptAssessmentPostsRepository().PreviousAssessmentPostCount(completeArpNo, assessmentPostYear);
                    decimal sefTaxDue = RealPropertyTaxComputations.GetSefTaxDue(sefRate, assessedValue);
                    decimal basicTaxDue = RealPropertyTaxComputations.GetBasicTaxDue(basicRate, assessedValue);
                    int monthsDelinquent = RealPropertyTaxComputations.GetCurrentMonthsDelinquent(assessmentPostYear, postedAt, effectivityYear, previousAssessmentCount);
                    decimal basicPenalty = RealPropertyTaxComputations.GetPenalty(penaltyRate, monthsDelinquent, basicTaxDue);
                    decimal sefPenalty = RealPropertyTaxComputations.GetPenalty(penaltyRate, monthsDelinquent, sefTaxDue);

                    decimal basicDiscount = RealPropertyTaxComputations.GetDiscount(currentDiscountRate, basicTaxDue);
                    decimal sefDiscount = RealPropertyTaxComputations.GetDiscount(currentDiscountRate, sefTaxDue);

                    decimal basicPenaltyDiscount = basicDiscount < 1 ? basicPenalty : -basicDiscount;
                    decimal sefPenaltyDiscount = sefDiscount < 1 ? sefPenalty : -sefDiscount;
                    decimal totalBasicPayment = (basicTaxDue + basicPenalty) - basicDiscount;
                    decimal totalSefPayment = (sefTaxDue + sefPenalty) - sefDiscount;

                    var newRow = dataTable.NewRow();
                    newRow["is_selected"] = false;
                    newRow["assessment_posts_id"] = row["rpt_assessment_posts_id"];
                    newRow["year"] = row["year"];
                    newRow["complete_arp_no"] = completeArpNo;
                    newRow["type"] = "BSC\nSEF";

                    newRow["tax_due_amount"] = $"{basicTaxDue.ToString("N2")}\n{sefTaxDue.ToString("N2")}";
                    newRow["penalty_discount"] = $"{basicPenaltyDiscount.ToString(decimalFormat)}\n{sefPenaltyDiscount.ToString(decimalFormat)}";
                    newRow["total_payment"] = $"{totalBasicPayment.ToString(decimalFormat)}\n{totalSefPayment.ToString(decimalFormat)}";
                    newRow["total_payment_consolidated"] = totalBasicPayment + totalSefPayment;
                    dataTable.Rows.Add(newRow);
                }
            }
            return dataTable;
        }

        private void LoadTaxDues(DataGridView dataGridView)
        {
            try
            {
                List<string> completeArpNoList = new List<string>();

                foreach (DataGridViewRow row in dgProperties.Rows)
                {
                    if (Convert.ToBoolean(row.Cells["is_selected"].Value))
                        completeArpNoList.Add(row.Cells["complete_arp_no"].Value.ToString());
                }

                HelperLoadRecords.DatagridViewPaymentTaxpayerTaxDues(dataGridView, DataTableTaxDues(taxpayersId, completeArpNoList));
                chckBxTaxDues.Checked = false;
                txtTotalDue.Text = GetTotalTaxDue().ToString("N2");
            }
            catch (Exception ex) { Helper.MessageBoxError(ex.Message); }
        }

        internal decimal GetTotalTaxDue()
        {
            decimal totalPayment = 0;
            foreach (DataGridViewRow row in dgTaxDues.Rows)
            {
                bool isSelected = Convert.ToBoolean(row.Cells["is_selected"].Value);
                if (isSelected)
                    totalPayment += Convert.ToDecimal(row.Cells["total_payment_consolidated"].Value);
            }
            return totalPayment;
        }

        private void dgTaxDues_ColumnAdded(object sender, DataGridViewColumnEventArgs e)
        {
            if (e.Column.Name != "is_selected")
                e.Column.ReadOnly = true;
        }

        private void dgTaxDues_CurrentCellDirtyStateChanged(object sender, EventArgs e)
        {
            if (dgTaxDues.CurrentCell is DataGridViewCheckBoxCell)
                dgTaxDues.CommitEdit(DataGridViewDataErrorContexts.Commit);
        }

        private void dgTaxDues_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                Helper.CheckUncheckCheckBoxHeader(dgTaxDues, "is_selected", chckBxTaxDues);
                txtTotalDue.Text = GetTotalTaxDue().ToString("N2");
            }
            catch (Exception ex) { Helper.MessageBoxError(ex.Message); }
        }

        private void chckBxTaxDues_MouseClick(object sender, MouseEventArgs e)
        {
            try
            {
                bool isChecked = chckBxTaxDues.Checked;
                Helper.CheckUncheckCheckBoxRows(dgTaxDues, "is_selected", isChecked);
            }
            catch (Exception ex) { Helper.MessageBoxError(ex.Message); }
        }

        private void dgTaxDues_Validating(object sender, CancelEventArgs e)
        {
            try
            {
                e.Cancel = !TaxDuesValidated();
            }
            catch (Exception ex) { Helper.MessageBoxError(ex.Message); }
        }

        private void txtTotalDue_Validating(object sender, CancelEventArgs e)
        {
        }

        private void btnPrintTaxDue_Click(object sender, EventArgs e)
        {
            if (!ValidateChildren())
            {
                Helper.MessageBoxError(GetFormErrors());
                return;
            }
        }
    }
}