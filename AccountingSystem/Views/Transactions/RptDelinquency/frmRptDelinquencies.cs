using ACC.Data;
using ACC.Domain.Models;
using AccountingSystem.Views.Reports.RptDelinquency;
using AccountingSystem.Views.Shared;
using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;

namespace AccountingSystem.Views.Reports.RptDeliquency
{
    public partial class frmRptDelinquencies : Form
    {
        public frmRptDelinquencies()
        {
            InitializeComponent();
            Helper.LoadFormIcon(this);
            Helper.DatagridFullRowSelectStyle(dgDeliquentProperties, true);
        }

        private void OnLoad()
        {
            LoadDeliquentProperties();
            Helper.EnableDisableToolStripButtons(dgDeliquentProperties, btnEdit, btnDelete);
        }

        internal void LoadDeliquentProperties()
        {
            try
            {

                if (!bgwRealPropertyTaxDeliquencies.IsBusy)
                {
                    progressBar1.Value = 0;
                    bgwRealPropertyTaxDeliquencies.RunWorkerAsync();
                }
            }
            catch (Exception ex) { Helper.MessageBoxError(ex.Message); }
        }

        private void frmRptDeliquencies_Load(object sender, EventArgs e)
        {
            OnLoad();
        }

        private DataColumn[] RptDelinquenciesColumns()
        {
            var dataColumns = new DataColumn[]
            {
                new DataColumn("id", typeof(int)),
                new DataColumn("rpt_assessment_posts_id", typeof(int)),
                new DataColumn("complete_arp_no", typeof(string)),
                new DataColumn("taxpayer_name", typeof(string)),
                new DataColumn("property_kind", typeof(string)),
                new DataColumn("property_pin", typeof(string)),
                new DataColumn("tax_due", typeof(decimal)),
                new DataColumn("delinquency_status", typeof(string)),
                new DataColumn("created_at", typeof(string)),
                new DataColumn("created_by", typeof(int)),
                new DataColumn("updated_at", typeof(string)),
                new DataColumn("updated_by", typeof(string)),
            };

            return dataColumns;
        }



        private void bgwRealPropertyTaxDeliquencies_DoWork(object sender, System.ComponentModel.DoWorkEventArgs e)
        {
            try
            {
                var dataTable = new DataTable();
                dataTable.Columns.AddRange(RptDelinquenciesColumns());

                var dtViewDelinquentRealProperties = AccFactory.RptDelinquenciesRepository().GetViewRptDelinquencies();
                int totalProgressCount = dtViewDelinquentRealProperties.Rows.Count;
                int progressCount = 0;

                if (totalProgressCount < 1) { e.Result = dataTable; bgwRealPropertyTaxDeliquencies.ReportProgress(100); return; }

                foreach (DataRow row in dtViewDelinquentRealProperties.Rows)
                {
                    var newRow = dataTable.NewRow();

                    newRow["id"] = Convert.ToInt32(row["id"]);
                    newRow["rpt_assessment_posts_id"] = Convert.ToInt32(row["rpt_assessment_posts_id"]);
                    newRow["complete_arp_no"] = row["complete_arp_no"].ToString();
                    newRow["taxpayer_name"] = row["taxpayer_name"].ToString();
                    newRow["property_kind"] = row["property_kind"].ToString();
                    newRow["property_pin"] = row["property_pin"].ToString();
                    newRow["tax_due"] = GetTaxDue(row);
                    newRow["delinquency_status"] = row["delinquency_status"].ToString();
                    newRow["created_at"] = row["created_at"].ToString();
                    newRow["created_by"] = Convert.ToInt32(row["created_by"]);
                    newRow["updated_at"] = row["updated_at"].ToString();
                    newRow["updated_by"] = row["updated_by"].ToString();

                    progressCount++;
                    dataTable.Rows.Add(newRow);
                    Helper.ProgressCounter(bgwRealPropertyTaxDeliquencies, totalProgressCount, progressCount);
                    e.Result = dataTable;
                }

            }
            catch (Exception ex) { Helper.MessageBoxError(ex.Message); }
        }

        private void bgwRealPropertyTaxDeliquencies_ProgressChanged(object sender, System.ComponentModel.ProgressChangedEventArgs e)
        {
            progressBar1.Value = e.ProgressPercentage;
        }

        private void bgwRealPropertyTaxDeliquencies_RunWorkerCompleted(object sender, System.ComponentModel.RunWorkerCompletedEventArgs e)
        {
            if (e.Cancelled)
                return;

            if (e.Result is not DataTable dataTable)
                return;

            HelperLoadRecords.RptDelinquenciesDatagridView(dataTable, dgDeliquentProperties);
        }


        private void btnAdd_Click(object sender, EventArgs e)
        {
            _ = new frmAddRptDelinquencies(this).ShowDialog();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            int deletedRecordCount;

            if (DeleteData(out deletedRecordCount))
            {
                Helper.MessageBoxSuccess($"{deletedRecordCount} record/s has been deleted.");
                LoadDeliquentProperties();
            }
        }

        private bool DeleteData(out int deletedRecordCount)
        {
            try
            {
                var rptDelinquenciesModelList = new List<RptDelinquenciesModel>();
                int rowCount = dgDeliquentProperties.SelectedRows.Count;

                if (Helper.MessageBoxConfirmDelete(rowCount))
                {
                    foreach (DataGridViewRow row in dgDeliquentProperties.SelectedRows)
                    {
                        int rptDelinquenciesId = Convert.ToInt32(row.Cells["id"].Value);
                        var model = new RptDelinquenciesModel() { Id = rptDelinquenciesId };
                        rptDelinquenciesModelList.Add(model);
                    }

                    deletedRecordCount = rowCount;
                    return AccFactory.RptDelinquenciesRepository().Delete(rptDelinquenciesModelList);
                }
            }
            catch (Exception ex) { Helper.MessageBoxError(ex.Message); }

            deletedRecordCount = 0;
            return false;
        }


        #region TaxDue

        private decimal GetTaxDue(DataRow row)
        {
            var postedAt = Convert.ToDateTime(row["posted_at"]);
            decimal sefRate = Convert.ToDecimal(row["sef_rate"]);
            decimal basicRate = Convert.ToDecimal(row["basic_rate"]);
            decimal penaltyRate = Convert.ToDecimal(row["penalty_rate"]);
            int effectivityYear = Convert.ToInt32(row["effectivity_year"]);
            int effectivityQuarter = Convert.ToInt32(row["effectivity_quarterly"]);
            int assessmentPostYear = Convert.ToInt32(row["year"]);

            decimal sefTaxDue = RealPropertyTaxComputations.GetSefTaxDue(sefRate, Convert.ToDecimal(row["assessed_value"]));
            decimal basicTaxDue = RealPropertyTaxComputations.GetBasicTaxDue(basicRate, Convert.ToDecimal(row["assessed_value"]));

            Dictionary<string, string> dictPreviousAssessmentPost = AccFactory.RptAssessmentPostsRepository().GetViewRecentAssessmentRecord(row["complete_arp_no"].ToString(), assessmentPostYear);

            int? prevAssmntYear = null;

            if (dictPreviousAssessmentPost.Count > 1)
                prevAssmntYear = Convert.ToInt32(dictPreviousAssessmentPost["year"]);

            Dictionary<string, string> dictAssessmentPost = new Dictionary<string, string>();
            dictAssessmentPost.Add("posted_at", postedAt.ToString());
            dictAssessmentPost.Add("effectivity_year", effectivityYear.ToString());
            dictAssessmentPost.Add("year", assessmentPostYear.ToString());

            int monthsDelinquent = RealPropertyTaxComputations.GetMonthsDelinquent(Helper.GetCurrentDate(), (assessmentPostYear, effectivityQuarter, effectivityYear), prevAssmntYear.HasValue ? prevAssmntYear : null);

            decimal basicPenalty = RealPropertyTaxComputations.GetPenalty(penaltyRate, monthsDelinquent, basicTaxDue);
            decimal sefPenalty = RealPropertyTaxComputations.GetPenalty(penaltyRate, monthsDelinquent, sefTaxDue);

            //Get discount rate
            var discountParameters = (postedAt, assessmentPostYear);
            decimal discountRate = RealPropertyTaxComputations.GetDiscountRate(Helper.GetCurrentDate(), discountParameters);

            //Apply Discounts
            decimal basicDiscount = RealPropertyTaxComputations.GetDiscount(discountRate, basicTaxDue);
            decimal sefDiscount = RealPropertyTaxComputations.GetDiscount(discountRate, sefTaxDue);

            decimal basicPenaltyDiscount = basicDiscount < 1 ? basicPenalty : -basicDiscount;
            decimal sefPenaltyDiscount = sefDiscount < 1 ? sefPenalty : -sefDiscount;

            decimal totalBasicPayment = (basicTaxDue + basicPenalty) - basicDiscount;
            decimal totalSefPayment = (sefTaxDue + sefPenalty) - sefDiscount;

            decimal rowTaxDue = totalBasicPayment + totalSefPayment;

            return rowTaxDue;
        }



        #endregion

        private void btnEdit_Click(object sender, EventArgs e)
        {
            try
            {
                int index = dgDeliquentProperties.CurrentCell.RowIndex;
                int delinquencyId = Convert.ToInt32(dgDeliquentProperties.Rows[index].Cells["id"].Value);

                _ = new frmEditRptDelinquencies(delinquencyId, this).ShowDialog();
            }
            catch (Exception ex) { Helper.MessageBoxError(ex.Message); }

        }

        private void dgDeliquentProperties_SelectionChanged(object sender, EventArgs e)
        {
            try
            {
                Helper.EnableDisableToolStripButtons(dgDeliquentProperties, btnEdit, btnDelete);
            }
            catch (Exception ex) { Helper.MessageBoxError(ex.Message); }
        }
    }
}
