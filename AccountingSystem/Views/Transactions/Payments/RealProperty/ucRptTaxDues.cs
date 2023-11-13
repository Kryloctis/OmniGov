using ACC.Domain.Models;
using AccountingSystem.Views.Shared;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace AccountingSystem.Views.Transactions.Payments.RealProperty
{
    public partial class ucRptTaxDues : UserControl
    {
        internal int taxpayersId;
        internal DateTime paymentDate = Helper.GetCurrentDate();

        public ucRptTaxDues()
        {
            InitializeComponent();
        }

        internal List<RptTaxDuesModel> RptTaxDuesModelList()
        {
            var rptTaxDuesModelList = new List<RptTaxDuesModel>();

            foreach (DataGridViewRow dgRow in dgTaxDues.Rows)
            {
                if (!Convert.ToBoolean(dgRow.Cells["is_selected"].Value))
                    continue;

                int rptAssessmentPostId = Convert.ToInt32(dgRow.Cells["assessment_posts_id"].Value);
                var dictAssessmentPost = AccFactory.RptAssessmentPostsRepository().GetRecordByID(rptAssessmentPostId);
                Dictionary<string, string> dictPreviousAssessmentPost = AccFactory.RptAssessmentPostsRepository().GetViewPreviousAssessmentPostRecord(dictAssessmentPost["complete_arp_no"], Convert.ToInt32(dictAssessmentPost["year"]));
                bool isAdvance = false;
                var model = new RptTaxDuesModel()
                {
                    RptAssessmentPostId = rptAssessmentPostId,
                    DiscountRate = RealPropertyTaxComputations.GetDiscountRate(dictAssessmentPost, dictPreviousAssessmentPost, paymentDate, ref isAdvance),
                    IsAdvance = isAdvance,
                };
                rptTaxDuesModelList.Add(model);
            }
            return rptTaxDuesModelList;
        }

        internal string GetFormErrors()
        {
            var errorStrings = new string[]
            {
                dgTaxDues.Tag.ToString(),
            };

            return AccFactory.CreateErrors(errorStrings).GenerateErrorMessage();
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
                    string status = row.Cells["status"].Value.ToString();

                    if (status.ToLower() == "paid")
                        continue;

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
                new DataColumn("status", typeof(string)),
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
                var dtAssessmentPosting = AccFactory.RptAssessmentPostsRepository().GetViewRecords(taxPayersId, completeArpNo, chckShowPaidUnpaid.Checked);
                foreach (DataRow row in dtAssessmentPosting.Rows)
                {
                    decimal assessedValue = Convert.ToDecimal(row["assessed_value"]);
                    decimal sefRate = Convert.ToDecimal(row["sef_rate"]);
                    decimal basicRate = Convert.ToDecimal(row["basic_rate"]);
                    decimal penaltyRate = Convert.ToDecimal(row["penalty_rate"]);
                    DateTime postedAt = Convert.ToDateTime(row["posted_at"]);
                    int assessmentPostYear = Convert.ToInt32(row["year"]);
                    int effectivityYear = Convert.ToInt32(row["effectivity_year"]);
                    string rptPaymentId = row["rpt_payments_id"].ToString();
                    bool discountIsAdvance = false;

                    //TaxDues
                    decimal sefTaxDue = RealPropertyTaxComputations.GetSefTaxDue(sefRate, assessedValue);
                    decimal basicTaxDue = RealPropertyTaxComputations.GetBasicTaxDue(basicRate, assessedValue);
                    //TaxDues

                    //Apply Penalties
                    Dictionary<string, string> dictPreviousAssessmentPost = AccFactory.RptAssessmentPostsRepository().GetViewPreviousAssessmentPostRecord(completeArpNo, assessmentPostYear);

                    Dictionary<string, string> dictAssessmentPost = new Dictionary<string, string>();
                    dictAssessmentPost.Add("posted_at", postedAt.ToString());
                    dictAssessmentPost.Add("effectivity_year", effectivityYear.ToString());
                    dictAssessmentPost.Add("year", assessmentPostYear.ToString());

                    int monthsDelinquent = RealPropertyTaxComputations.GetCurrentMonthsDelinquent(dictAssessmentPost, paymentDate, dictPreviousAssessmentPost);
                    decimal basicPenalty = RealPropertyTaxComputations.GetPenalty(penaltyRate, monthsDelinquent, basicTaxDue);
                    decimal sefPenalty = RealPropertyTaxComputations.GetPenalty(penaltyRate, monthsDelinquent, sefTaxDue);

                    //Get discount rate
                    decimal discountRate = RealPropertyTaxComputations.GetDiscountRate(dictAssessmentPost, dictPreviousAssessmentPost, paymentDate, ref discountIsAdvance);

                    //Apply Discounts
                    decimal basicDiscount = RealPropertyTaxComputations.GetDiscount(discountRate, basicTaxDue);
                    decimal sefDiscount = RealPropertyTaxComputations.GetDiscount(discountRate, sefTaxDue);

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
                    newRow["status"] = string.IsNullOrEmpty(rptPaymentId) ? "Unpaid" : "Paid";
                    newRow["tax_due_amount"] = $"{basicTaxDue.ToString("N2")}\n{sefTaxDue.ToString("N2")}";
                    newRow["penalty_discount"] =
                        $"{(basicPenaltyDiscount < 1 ? $"({Math.Abs(basicPenaltyDiscount).ToString("N2")})" : basicPenaltyDiscount.ToString("N2"))}" +
                        $"\n" +
                        $"{(sefPenaltyDiscount < 1 ? $"({Math.Abs(sefPenaltyDiscount).ToString("N2")})" : sefPenaltyDiscount.ToString("N2"))}";
                    newRow["total_payment"] = $"{totalBasicPayment.ToString("N2")}\n{totalSefPayment.ToString("N2")}";
                    newRow["total_payment_consolidated"] = totalBasicPayment + totalSefPayment;
                    dataTable.Rows.Add(newRow);
                }
            }
            return dataTable;
        }

        private void LoadColorStatus(DataGridView dataGridView)
        {
            try
            {
                foreach (DataGridViewRow row in dataGridView.Rows)
                {
                    var status = row.Cells["status"].Value;
                    var datagridStatusCell = row.Cells["status"];
                    var datagridIsSelectedCell = row.Cells["is_selected"];

                    switch (status)
                    {
                        case "Unpaid":
                            var unpaidColor = Color.IndianRed;
                            datagridStatusCell.Style.ForeColor = unpaidColor;
                            datagridStatusCell.Style.SelectionForeColor = unpaidColor;
                            datagridIsSelectedCell.ReadOnly = false;
                            break;

                        case "Paid":
                            var paidColor = Color.Green;
                            datagridStatusCell.Style.ForeColor = paidColor;
                            datagridStatusCell.Style.SelectionForeColor = paidColor;
                            datagridIsSelectedCell.ReadOnly = true;
                            break;

                        default:
                            break;
                    }
                }
            }
            catch (Exception ex) { Helper.MessageBoxError(ex.Message); }
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
                LoadColorStatus(dgTaxDues);
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
                if (dgTaxDues.Rows.Count < 1)
                    return;

                int totalRowCount = dgTaxDues.Rows.Count;
                int unpaidRowCount = 0;
                int checkedRowCount = 0;

                foreach (DataGridViewRow row in dgTaxDues.Rows)
                {
                    if (row.Cells["status"].Value.ToString() == "Unpaid")
                        unpaidRowCount += 1;

                    if (Convert.ToBoolean(row.Cells["is_selected"].Value) == true)
                        checkedRowCount += 1;
                }

                if (unpaidRowCount == checkedRowCount)
                    chckBxTaxDues.Checked = true;
                else
                    chckBxTaxDues.Checked = false;

                txtTotalDue.Text = GetTotalTaxDue().ToString("N2");
            }
            catch (Exception ex) { Helper.MessageBoxError(ex.Message); }
        }

        private void chckBxTaxDues_MouseClick(object sender, MouseEventArgs e)
        {
            try
            {
                bool isChecked = chckBxTaxDues.Checked;
                foreach (DataGridViewRow row in dgTaxDues.Rows)
                {
                    if (row.Cells["status"].Value.ToString() == "Unpaid")
                        row.Cells["is_selected"].Value = isChecked;
                }
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

        private void dgTaxDues_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
        {
        }

        private void chckShowPaidUnpaid_CheckedChanged(object sender, EventArgs e)
        {
            LoadTaxDues(dgTaxDues);
        }
    }
}