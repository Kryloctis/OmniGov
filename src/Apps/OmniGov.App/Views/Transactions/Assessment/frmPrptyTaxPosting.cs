using OmniGov.App.Helpers;
using OmniGov.Core.Factories;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Windows.Forms;
using Treasury.Data.Factories;
using Treasury.Domain.Entities;

namespace OmniGov.App.Views.Transactions.Assessment
{
    public partial class frmPrptyTaxPosting : Form
    {
        public frmPrptyTaxPosting()
        {
            InitializeComponent();
            Helper.LoadFormIcon(this);
            Helper.DatagridFullRowSelectStyle(dgProperties, true, false);
        }

        private void OnLoad()
        {
            HelperLoadRecords.ComboboxRowLimitFilter(cmbxRowFilter);
            LoadBarangays();
            nudYear.Value = Helper.GetCurrentDate().Year;
            ToogleButtons(dgProperties, btnPost);
            LoadProperties();
        }

        private void FrmAssessmentPosting_Load(object sender, EventArgs e)
        {
            try
            {
                OnLoad();
            }
            catch (Exception ex) { Helper.MessageBoxError(ex.Message); }
        }

        internal void LoadBarangays()
        {
            try
            {
                var dataTable = Factory.BarangayRepository().GetRecords();
                HelperLoadRecords.BarangaysCombobox(dataTable, cmbxBarangays, "name", "id");
            }
            catch (Exception ex) { Helper.MessageBoxError(ex.Message); }
        }

        private string GetPenaltyRate(string description, string parameters)
        {
            var dictPenaltyRecord = TreasuryFactory.RptPenaltiesRepository().GetRecordByDescription(description);

            if (dictPenaltyRecord.Values.Count < 1)
                return string.Empty;

            return dictPenaltyRecord[parameters];
        }

        private void ToogleButtons(DataGridView dataGridView, ToolStripButton post)
        {
            var dataTable = (DataTable)dataGridView.DataSource;

            if (dataTable is null)
                return;

            int countCheckedRows = dataTable.AsEnumerable().Count(row => Convert.ToBoolean(row["is_checked"]) && row.Field<string>("posting_status") != "Posted");

            btnPost.Text = $"Post ({countCheckedRows})";

            if (countCheckedRows < 1)
                post.Enabled = false;
            else
                post.Enabled = true;
        }

        private void BtnSearch_Click(object sender, EventArgs e)
        {
            try
            {
                LoadProperties();
            }
            catch (Exception ex) { Helper.MessageBoxError(ex.Message); }
        }

        private DataColumn[] AssessmentPostsDataColumns()
        {
            var dataColumns = new DataColumn[]
            {
                new DataColumn("is_checked", typeof(bool)),
                new DataColumn("posting_status", typeof(string)),
                new DataColumn("real_property_id", typeof(int)),
                new DataColumn("pin", typeof(string)),
                new DataColumn("complete_arp_no", typeof(string)),
                new DataColumn("property_kind", typeof(string)),
                new DataColumn("taxpayers_id", typeof(int)),
                new DataColumn("taxpayer_name", typeof(string)),
                new DataColumn("taxpayer_tin", typeof(string)),
                new DataColumn("taxpayer_contact_info", typeof(string)),
                new DataColumn("taxpayer_address", typeof(string)),
                new DataColumn("property_location", typeof(string)),
                new DataColumn("effectivity", typeof(string)),
                new DataColumn("other_improvements", typeof(decimal)),
                new DataColumn("assessed_value", typeof(decimal)),
                new DataColumn("area", typeof(decimal)),
                new DataColumn("lot_no", typeof(string)),
                new DataColumn("classification_code", typeof(string)),
                new DataColumn("classification_name", typeof(string)),
                new DataColumn("actual_use_code", typeof(string)),
                new DataColumn("actual_use_name", typeof(string)),
                new DataColumn("gr_year", typeof(int)),
                new DataColumn("is_taxable", typeof(bool)),
                new DataColumn("is_cancelled", typeof(bool)),
                new DataColumn("penalty_rate", typeof(decimal)),
                new DataColumn("penalty_frequency", typeof(string)),
                new DataColumn("basic_rate", typeof(decimal)),
                new DataColumn("sef_rate", typeof(decimal)),
                new DataColumn("posted_at", typeof(string)),
                new DataColumn("posted_by", typeof(string))
            };

            return dataColumns;
        }

        private void LoadProperties()
        {
            if (!bgwLoadAsessmentPosts.IsBusy)
            {
                progressBar1.Value = 0;
                chckBxAll.Checked = false;
                int year = (int)nudYear.Value;
                txtYear.Text = $"{year}";
                string barangayName = cmbxBarangays.Text;
                txtBarangay.Text = barangayName;
                string searchKey = txtSearch.Text.Trim();
                int rowFilter = Convert.ToInt32(cmbxRowFilter.SelectedValue);
                bgwLoadAsessmentPosts.RunWorkerAsync((year, barangayName, searchKey, rowFilter));
            }
        }

        private void BgwLoadAsessmentPosts_DoWork(object sender, DoWorkEventArgs e)
        {
            try
            {
                var parameters = ((int year, string barangayName, string searchKey, int rowFilter))e.Argument;

                var dataTable = new DataTable();
                dataTable.Columns.AddRange(AssessmentPostsDataColumns());

                var dtViewRealProperties = TreasuryFactory.RealPropertiesRepository().GetRecordsBy_EffectivivtyYear_Barangay_Search(parameters.year, parameters.barangayName, parameters.searchKey, parameters.rowFilter);
                int totalProgressCount = dtViewRealProperties.Rows.Count;
                int progressCount = 0;

                if (totalProgressCount < 1) { e.Result = dataTable; bgwLoadAsessmentPosts.ReportProgress(100); return; }

                foreach (DataRow row in dtViewRealProperties.Rows)
                {
                    var newRow = dataTable.NewRow();

                    string rowCompleteArpNo = row["complete_arp_no"].ToString();
                    int leastAssessedYear = TreasuryFactory.RptAssessmentPostsRepository().GetMinAssessmentPostYear(rowCompleteArpNo);
                    if (leastAssessedYear > parameters.year && leastAssessedYear != 0)
                        continue;

                    var dictAssessmentPosts = TreasuryFactory.RptAssessmentPostsRepository().GetRecordBy_ArpNo_Year(rowCompleteArpNo, parameters.year);
                    string rowPostingStatus = dictAssessmentPosts.Keys.Count != 0 ? "Posted" : (Convert.ToBoolean(row["is_taxable"]) != true ? "Tax Exempted" : string.Empty);

                    newRow["is_checked"] = false;
                    newRow["real_property_id"] = Convert.ToInt32(row["real_property_id"]);
                    newRow["posting_status"] = rowPostingStatus;
                    newRow["pin"] = row["property_pin"].ToString();
                    newRow["complete_arp_no"] = rowCompleteArpNo;
                    newRow["taxpayers_id"] = Convert.ToInt32(row["taxpayers_id"]);
                    newRow["taxpayer_name"] = row["taxpayer_name"].ToString();
                    newRow["taxpayer_tin"] = row["taxpayer_tin"].ToString();
                    newRow["taxpayer_contact_info"] = row["taxpayer_contact_info"].ToString();
                    newRow["taxpayer_address"] = row["taxpayer_address"].ToString();
                    newRow["property_kind"] = row["property_kind"].ToString();
                    newRow["property_location"] = $"{row["barangay_name"]}, {row["municipality_name"]}, {row["province_name"]}";
                    string effectivityQuarter = Helper.AddOrdinalSuffix(Convert.ToInt32(row["effectivity_quarter"]));
                    newRow["effectivity"] = $"{effectivityQuarter} Qtr. - {row["effectivity_year"]}";
                    newRow["assessed_value"] = Convert.ToDecimal(row["assessed_value"]);
                    newRow["area"] = Convert.ToDecimal(row["area"]);
                    newRow["lot_no"] = row["lot_no"].ToString();
                    newRow["other_improvements"] = Convert.ToDecimal(row["other_improvements"]);
                    newRow["classification_code"] = row["classification_code"].ToString();
                    newRow["classification_name"] = row["classification_name"].ToString();
                    newRow["actual_use_code"] = row["actual_use_code"].ToString();
                    newRow["actual_use_name"] = row["actual_use_name"].ToString();
                    newRow["gr_year"] = Convert.ToInt32(row["gr_year"]);
                    newRow["is_taxable"] = Convert.ToBoolean(row["is_taxable"]);
                    newRow["is_cancelled"] = Convert.ToBoolean(row["is_cancelled"]);
                    newRow["penalty_rate"] = 0;
                    newRow["penalty_frequency"] = string.Empty;
                    newRow["basic_rate"] = 0;
                    newRow["sef_rate"] = 0;
                    newRow["posted_at"] = dictAssessmentPosts.Count < 1 ? string.Empty : dictAssessmentPosts["posted_at"];
                    newRow["posted_by"] = dictAssessmentPosts.Count < 1 ? string.Empty : dictAssessmentPosts["posted_by"];

                    progressCount++;
                    dataTable.Rows.Add(newRow);
                    Helper.ProgressCounter(bgwLoadAsessmentPosts, totalProgressCount, progressCount);
                    e.Result = dataTable;
                }
            }
            catch (Exception ex) { Helper.MessageBoxError(ex.Message); }
        }

        private void BgwLoadAsessmentPosts_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            progressBar1.Value = e.ProgressPercentage;
        }

        private void BgwLoadAsessmentPosts_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (e.Cancelled)
                return;

            if (e.Result is not DataTable dataTable)
                return;

            HelperLoadRecords.RptAssessmentDatagridView(dataTable, dgProperties);
            ToogleButtons(dgProperties, btnPost);
        }

        private void BtnPost_Click(object sender, EventArgs e)
        {
            try
            {
                if (!bgwPost.IsBusy)
                {
                    pbPost.Value = 0;
                    pbPost.Visible = true;
                    lblPost.Visible = true;
                    bgwPost.RunWorkerAsync();
                }
            }
            catch (Exception ex) { Helper.MessageBoxError(ex.Message); }
        }

        private void BgwPost_DoWork(object sender, DoWorkEventArgs e)
        {
            var assessmentPostingModels = new List<RptAssessmentPostsModel>();

            var dataTable = (DataTable)dgProperties.DataSource;
            var filteredDb = dataTable.AsEnumerable().Where(row => Convert.ToBoolean(row["is_checked"]));

            int progressCount = 0;
            int totalCheckedRowCount = filteredDb.Count();

            foreach (DataRow row in filteredDb)
            {
                //Get Penalty and Tax Rates
                var dictRptPenalties = TreasuryFactory.RptPenaltiesRepository().GetRecordByID(9);

                decimal penaltyRate = string.IsNullOrEmpty(GetPenaltyRate("RPT monthly penalty", "rate")) ? 0 : Convert.ToDecimal(GetPenaltyRate("RPT monthly penalty", "rate"));
                string penaltyFrequency = GetPenaltyRate("RPT monthly penalty", "frequency");

                var dictRpt = TreasuryFactory.RealPropertiesRepository().GetViewRecordById(Convert.ToInt32(row["real_property_id"]));

                var assessmentPostingModel = new RptAssessmentPostsModel()
                {
                    CompleteArpNo = dictRpt["complete_arp_no"],
                    PropertyPin = dictRpt["property_pin"],
                    TaxpayerId = Convert.ToInt32(dictRpt["taxpayers_id"]),
                    TaxpayerName = dictRpt["taxpayer_name"],
                    TaxpayerTin = dictRpt["taxpayer_tin"],
                    TaxpayerAddress = $"{dictRpt["taxpayer_address"]}, {dictRpt["taxpayer_municipality"]}, {dictRpt["taxpayer_province"]}",
                    TaxpayerContactInfo = dictRpt["taxpayer_contact_info"],
                    Street = dictRpt["street"],
                    BarangayName = dictRpt["barangay_name"],
                    MunicipalityName = dictRpt["municipality_name"],
                    ProvinceName = dictRpt["province_name"],
                    PropertyKind = dictRpt["property_kind"],
                    EffectivityQuarter = Convert.ToInt32(dictRpt["effectivity_quarter"]),
                    EffectivityYear = Convert.ToInt32(dictRpt["effectivity_year"]),
                    OtherImprovements = Convert.ToDecimal(dictRpt["other_improvements"]),
                    AssessedValue = Convert.ToDecimal(dictRpt["assessed_value"]),
                    Area = Convert.ToDecimal(dictRpt["area"]),
                    LotNo = dictRpt["lot_no"],
                    ClassificationCode = dictRpt["classification_code"],
                    ClassificationName = dictRpt["classification_name"],
                    ActualUseCode = dictRpt["actual_use_code"],
                    ActualUseName = dictRpt["actual_use_name"],
                    GrYear = Convert.ToInt32(dictRpt["gr_year"]),
                    IsTaxable = dictRpt["is_taxable"] == "1" ? true : false,
                    IsCancelled = dictRpt["is_cancelled"] == "1" ? true : false,
                    PenaltyRate = penaltyRate,
                    PenaltyFrequency = penaltyFrequency,
                    BasicRate = TreasuryFactory.RptTaxRatesRepository().GetTaxRateByDescription("Basic"),
                    SefRate = TreasuryFactory.RptTaxRatesRepository().GetTaxRateByDescription("Special Educational Fund"),
                    PostedBy = UserHelper.loggedUser.Id,
                    DueYear = Convert.ToInt32(txtYear.Text)
                };

                assessmentPostingModels.Add(assessmentPostingModel);
                progressCount++;
                Helper.ProgressCounter(bgwPost, totalCheckedRowCount, progressCount);
            }
            e.Result = assessmentPostingModels;
        }

        private void BgwPost_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            pbPost.Value = e.ProgressPercentage;
        }

        private void BgwPost_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (e.Cancelled)
                return;

            if (e.Result is not List<RptAssessmentPostsModel> rptAssessmentPostsModels)
                return;

            bool bulkInsert = TreasuryFactory.RptAssessmentPostsRepository().BulkInsert(rptAssessmentPostsModels);
            if (bulkInsert)
            {
                Helper.MessageBoxSuccess("Assessments has been posted.");
                LoadProperties();
            }
            else
                Helper.MessageBoxError("Assessments failed to post.");

            pbPost.Value = 0;
            pbPost.Visible = false;
            lblPost.Visible = false;
        }

        private void dgProperties_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                int index = dgProperties.CurrentCell.RowIndex;
                bool isPosted = dgProperties.Rows[index].Cells["posting_status"].Value.ToString().ToLower() == "posted";

                dgProperties.Rows[index].Cells["is_checked"].ReadOnly = isPosted;
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
                Helper.CheckUncheckCheckBoxHeader(dgProperties, "is_checked", chckBxAll);
                ToogleButtons(dgProperties, btnPost);
            }
            catch (Exception ex) { Helper.MessageBoxError(ex.Message); }
        }

        private void CheckAll_MouseClick(object sender, MouseEventArgs e)
        {
            try
            {
                if (!bgwAssessmentSelection.IsBusy)
                {
                    var dataTable = (DataTable)dgProperties.DataSource;
                    bool isCheckAll = chckBxAll.Checked;

                    bgwAssessmentSelection.RunWorkerAsync((isCheckAll, dataTable));
                }
            }
            catch (Exception ex) { Helper.MessageBoxError(ex.Message); }
        }

        private void BgwAssessmentSelection_DoWork(object sender, DoWorkEventArgs e)
        {
            try
            {
                var parameters = ((bool isCheckAll, DataTable dataTable))e.Argument;

                int totalCountUnchecked = parameters.dataTable.AsEnumerable().Count(row => !Convert.ToBoolean(row["is_checked"]) && row.Field<string>("posting_status") != "Posted");
                int totalCountChecked = parameters.dataTable.AsEnumerable().Count(row => Convert.ToBoolean(row["is_checked"]) && row.Field<string>("posting_status") != "Posted");

                int progressCount = 0;
                string targetStatus = "posted";

                foreach (DataRow row in parameters.dataTable.Rows)
                {
                    bool isChecked = Convert.ToBoolean(row["is_checked"]);
                    string status = row["posting_status"].ToString();

                    if ((parameters.isCheckAll && !isChecked || !parameters.isCheckAll && isChecked) && status.ToLower() != targetStatus)
                    {
                        row["is_checked"] = parameters.isCheckAll;
                        progressCount++;
                        Helper.ProgressCounter(bgwAssessmentSelection, parameters.isCheckAll ? totalCountUnchecked : totalCountChecked, progressCount);
                    }
                }
            }
            catch (Exception ex) { Helper.MessageBoxError(ex.Message); }
        }

        private void BgwAssessmentSelection_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            progressBar1.Value = e.ProgressPercentage;
        }

        private void bgwAssessmentSelection_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            ToogleButtons(dgProperties, btnPost);
        }

        private void dgProperties_SelectionChanged(object sender, EventArgs e)
        {
            try
            {
            }
            catch (Exception ex) { Helper.MessageBoxError(ex.Message); }
        }
    }
}