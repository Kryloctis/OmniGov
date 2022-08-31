using RPT.Data;
using RPT.Domain.Models;
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

namespace AccountingSystem.Views.Transactions.AssessmentPosting
{
    public partial class frmAssessmentPosting : Form
    {
        private DataTable assessmentPostsDataTable;

        public frmAssessmentPosting()
        {
            InitializeComponent();
            Helper.DatagridFullRowSelectStyle(dgProperties, true, false);
            Helper.LoadFormIcon(this);
            lblPostedAt.Text = string.Empty;
            lblPostingAssessments.Visible = false;
            prgrsBarPostingAssessments.Visible = false;        
        }

        private void frmAssessmentPosting_Load(object sender, EventArgs e)
        {
            LoadBarangays();
            nudYear.Value = Helper.GetCurrentDate().Year;
            LoadProperties();
            EnableDisableToolStripButton(dgProperties, btnPostSelected);
        }

        internal void LoadBarangays()
        {
            try
            {
                var dtBarangays = RptFactory.RealPropertiesRepository().GetBarangays();
                HelperLoadRecords.BarangaysCombobox(dtBarangays, cmbxBarangays, "name", "id");
            }
            catch (Exception ex)
            {
                Helper.MessageBoxError(ex.StackTrace);
            }
        }

        #region Load AssessmentPosts

        private DataColumn[] AssessmentPostsDataColumns() 
        {
            var dataColumns = new DataColumn[]
            {
                new DataColumn("is_checked", typeof(bool)),
                new DataColumn("posting_status", typeof(string)),
                new DataColumn("real_properties_id", typeof(int)),
                new DataColumn("complete_arp_no", typeof(string)),
                new DataColumn("owner_name", typeof(string)),
                new DataColumn("owner_address", typeof(string)),
                new DataColumn("property_kind", typeof(string)),
                new DataColumn("effectivity_quarter", typeof(int)),
                new DataColumn("effectivity_year", typeof(int)),
                new DataColumn("assessed_value", typeof(decimal)),
                new DataColumn("area", typeof(decimal)),
                new DataColumn("lot_no", typeof(string)),
                new DataColumn("other_improvements", typeof(decimal)),
                new DataColumn("classification_code", typeof(string)),
                new DataColumn("classification_name", typeof(string)),
                new DataColumn("actual_use_code", typeof(string)),
                new DataColumn("actual_use_name", typeof(string)),
                new DataColumn("gr_year", typeof(int)),
                new DataColumn("is_taxable", typeof(bool)),
                new DataColumn("penalty_rate", typeof(decimal)),
                new DataColumn("penalty_frequency", typeof(string)),
                new DataColumn("basic_rate", typeof(decimal)),
                new DataColumn("sef_rate", typeof(decimal)),
                new DataColumn("posted_at", typeof(string)),
                new DataColumn("posted_by", typeof(string))
            };

            return dataColumns;
        }

        private string PostedBy(string completeArpNo)
        {
            int year = (int)nudYear.Value;
            string postedById = GetAssessmentPostingRecord(completeArpNo, year, "posted_by");

            if (string.IsNullOrEmpty(postedById))
                return string.Empty;

            return Helper.GetUserDataById(Convert.ToInt32(postedById))["user_full_name"];
        }

        private void Miscellaneous()
        {
            chckBxAll.Checked = false;
            txtYear.Text = nudYear.Value.ToString();
            txtBarangay.Text = cmbxBarangays.Text;
        }

        private void LoadProperties()
        {
            try
            {
                if (!bgwLoadAsessmentPosts.IsBusy)
                    bgwLoadAsessmentPosts.RunWorkerAsync();

                lblRecordCount.Text = Helper.GetDatagridViewRecordCount(dgProperties).ToString();
                EnableDisableToolStripButton(dgProperties, btnPostSelected);
                Miscellaneous();
            }
            catch (Exception ex)
            {
                Helper.MessageBoxError(ex.StackTrace);
            }
        }

        private void GetParameters(ref int year, ref int barangayId, ref string searchText)
        {
            year = (int)nudYear.Value;
            barangayId = Convert.ToInt32(cmbxBarangays.SelectedValue);
            searchText = txtSearch.Text.Trim();
        }

        private string GetAssessmentPostingRecord(string arpNo, int year, string parameter)
        {
            var dtAssessment = AccFactory.RptAssessmentPostsRepository().GetRecordBy_ArpNo_Year(arpNo, year);

            if (dtAssessment.Values.Count == 0)
                return string.Empty;

            return dtAssessment[parameter];
        }

        private void bgwLoadAsessmentPosts_DoWork(object sender, DoWorkEventArgs e)
        {
            try
            {
                int totalRowCount = 0;
                int rowCount = 0;
                int year = 0;
                int barangayId = 0;
                string searchText = string.Empty;

                assessmentPostsDataTable = new DataTable();
                assessmentPostsDataTable.Columns.AddRange(AssessmentPostsDataColumns());

                Invoke((MethodInvoker)delegate
                {
                    GetParameters(ref year, ref barangayId, ref searchText);
                });

                var dtViewRealProperties = RptFactory.RealPropertiesRepository().GetPropertiesBy_Quarter_Year_BarangayId_Search(year, barangayId, searchText);

                foreach (DataRow row in dtViewRealProperties.Rows)
                {
                    string rowCompleteArpNo = row["complete_arp_no"].ToString();
                    int leastAssessedYear = AccFactory.RptAssessmentPostsRepository().GetMinAssessmentPostYear(rowCompleteArpNo);
                    if (leastAssessedYear > year && leastAssessedYear != 0)
                        continue;

                    totalRowCount += 1;
                }


                foreach (DataRow row in dtViewRealProperties.Rows)
                {
                    var newRow = assessmentPostsDataTable.NewRow();

                    int rowId = Convert.ToInt32(row["real_properties_id"]);
                    string rowCompleteArpNo = row["complete_arp_no"].ToString();
                    int leastAssessedYear = AccFactory.RptAssessmentPostsRepository().GetMinAssessmentPostYear(rowCompleteArpNo);
                    if (leastAssessedYear > year && leastAssessedYear != 0)
                        continue;

                    string rowOwnerName = row["owner_name"].ToString();
                    string rowOwnerAddress = row["owner_address"].ToString();
                    string rowPropertyKind = row["property_kind"].ToString();
                    int landBldgMachPropertiesId = Convert.ToInt32(row["land_bldg_mach_properties_id"]);
                    int rowEffectivityQuarter = Convert.ToInt32(row["effectivity_quarter"]);
                    int rowEffectivityYear = Convert.ToInt32(row["effectivity_year"]);
                    bool rowIsTaxable = Convert.ToBoolean(row["is_taxable"]);
                    decimal rowAssessedValue = Convert.ToDecimal(row["assessed_value"]);
                    decimal area = Convert.ToDecimal(row["land_area"]);
                    string lotNo = row["land_lot_no"].ToString();
                    decimal otherImprovements = Convert.ToDecimal(row["other_improvements"]);
                    string rowClassificationCode = row["classification_code"].ToString();
                    string rowClassificationName = row["classification_name"].ToString();
                    string rowActualCode = row["actual_use_code"].ToString();
                    string rowActualName = row["actual_use_name"].ToString();
                    int rowGrYear = Convert.ToInt32(row["gryear"]);

                    var dictAssessmentPosts = AccFactory.RptAssessmentPostsRepository().GetRecordBy_ArpNo_Year(rowCompleteArpNo, year);
                    string rowPostingStatus = dictAssessmentPosts.Keys.Count != 0 ? "Posted" : string.Empty;
                    string rowPostedAt = GetAssessmentPostingRecord(rowCompleteArpNo, year, "posted_at");


                    decimal rowPenaltyRate = 0;
                    string rowPenaltyFrequency = string.Empty;
                    decimal rowBasicRate = 0;
                    decimal rowSefRate = 0;
                    string rowPostedBy = PostedBy(rowCompleteArpNo);

                    newRow["is_checked"] = false;
                    newRow["posting_status"] = rowPostingStatus;
                    newRow["real_properties_id"] = rowId;
                    newRow["complete_arp_no"] = rowCompleteArpNo;
                    newRow["owner_name"] = rowOwnerName;
                    newRow["owner_address"] = rowOwnerAddress;
                    newRow["property_kind"] = rowPropertyKind;
                    newRow["effectivity_quarter"] = rowEffectivityQuarter;
                    newRow["effectivity_year"] = rowEffectivityYear;
                    newRow["assessed_value"] = rowAssessedValue;
                    newRow["area"] = area;
                    newRow["lot_no"] = lotNo;
                    newRow["other_improvements"] = otherImprovements;
                    newRow["classification_code"] = rowClassificationCode;
                    newRow["classification_name"] = rowClassificationName;
                    newRow["actual_use_code"] = rowActualCode;
                    newRow["actual_use_name"] = rowActualName;
                    newRow["gr_year"] = rowGrYear;
                    newRow["is_taxable"] = rowIsTaxable;
                    newRow["penalty_rate"] = rowPenaltyRate;
                    newRow["penalty_frequency"] = rowPenaltyFrequency;
                    newRow["basic_rate"] = rowBasicRate;
                    newRow["sef_rate"] = rowSefRate;
                    newRow["posted_at"] = rowPostedAt;
                    newRow["posted_by"] = rowPostedBy;

                    rowCount += 1;
                    bgwLoadAsessmentPosts.ReportProgress(((rowCount * 100) / totalRowCount), rowCount);
                    assessmentPostsDataTable.Rows.Add(newRow);
                }
            }
            catch (Exception ex)
            {
                Helper.MessageBoxError(ex.Message);
                e.Cancel = true;
            }
        }

        private void bgwLoadAsessmentPosts_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            Cursor = Cursors.WaitCursor;
            progressBarLoadRecords.Visible = true;
            lblRecordCount.Text = e.UserState.ToString();
            progressBarLoadRecords.Value = e.ProgressPercentage;
        }

        private void bgwLoadAsessmentPosts_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (progressBarLoadRecords.Value == 100)
                progressBarLoadRecords.Visible = false;

            HelperLoadRecords.RealPropertiesSearchDatagridView(assessmentPostsDataTable, dgProperties);
            Cursor = Cursors.Default;
        }

        #endregion

        private void dgProperties_ColumnAdded(object sender, DataGridViewColumnEventArgs e)
        {
            if (e.Column.Name != "is_checked")
                e.Column.ReadOnly = true;
            else
                e.Column.ReadOnly = false;
        }

        private void checkAll_MouseClick(object sender, MouseEventArgs e)
        {
            if (chckBxAll.Checked)
                Helper.CheckUncheckCheckBoxRows(dgProperties, "is_checked", true);
            else
                Helper.CheckUncheckCheckBoxRows(dgProperties, "is_checked", false);
        }

        private void dgProperties_CurrentCellDirtyStateChanged(object sender, EventArgs e)
        {
            if (dgProperties.CurrentCell is DataGridViewCheckBoxCell)
                dgProperties.CommitEdit(DataGridViewDataErrorContexts.Commit);
        }

        private void dgProperties_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            Helper.CheckUncheckCheckBoxHeader(dgProperties, "is_checked", chckBxAll);
            EnableDisableToolStripButton(dgProperties, btnPostSelected);
        }

        private dynamic GetDatagridViewValue(DataGridView dataGridView, int rowIndex, string columnName)
        {
            return dataGridView.Rows[rowIndex].Cells[columnName].Value;
        }

        private decimal GetTaxRate(string description) 
        {
            var dicTaxRate = AccFactory.RptTaxRatesRepository().GetRecordByDescription(description);
            decimal taxRate = 0;

            if (dicTaxRate != null)
                taxRate = Convert.ToDecimal(dicTaxRate["rate"]);

            return taxRate;
        }

        private void EnableDisableToolStripButton(DataGridView dataGridView, ToolStripButton post) 
        {
            try
            {
                int postedCount = 0;
                int unpostedCount = 0;

                foreach (DataGridViewRow row in dataGridView.Rows)
                {
                    bool isChecked = Convert.ToBoolean(row.Cells["is_checked"].Value);
                    string postingStatus = row.Cells["posting_status"].Value.ToString();

                    if (!isChecked)
                        continue;

                    if (postingStatus == "Posted")
                        postedCount += 1;
                    else
                        unpostedCount += 1;

                }

                if (unpostedCount > 0)
                {
                    post.Enabled = true;
                    post.Text = $"Post({unpostedCount})";
                }
                else
                {
                    post.Enabled = false;
                    post.Text = $"Post({0})";
                }
            }
            catch (Exception ex)
            {
                Helper.MessageBoxError(ex.Message);    
            }
        }

        private void btnPostSelected_Click(object sender, EventArgs e)
        {
            if (!backgroundWorker1.IsBusy)
            {
                backgroundWorker1.RunWorkerAsync();
            }
        }

        #region Posting

        private string GetViewRealPropertyRecord(int realPropertiesId, string parameter)
        {
            var dictViewRealProperty = RptFactory.RealPropertiesRepository().GetViewRealPropertiesById(realPropertiesId);

            if (dictViewRealProperty.Values.Count == 0)
                return string.Empty;

            return dictViewRealProperty[parameter];
        }

        private string GetRealPropertyRecord(int realPropertiesId, string parameter)
        {
            var dictRealProperties = RptFactory.RealPropertiesRepository().GetRecordByID(realPropertiesId);

            if (dictRealProperties.Values.Count == 0)
                return string.Empty;

            return dictRealProperties[parameter];
        }

        private string GetPenaltyRecord(string description, string parameters)
        {
            var dictPenaltyRecord = AccFactory.RptPenaltiesRepository().GetRecordByDescription(description);

            if (dictPenaltyRecord.Values.Count < 1)
                return string.Empty;

            return dictPenaltyRecord[parameters];
        }

        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
            try
            {
                var assessmentPostingModels = new List<RptAssessmentPostsModel>();

                int progressCount = 0;
                int totalCheckedRowCount = 0;

                foreach (DataGridViewRow row in dgProperties.Rows)
                {
                    bool isChecked = Convert.ToBoolean(row.Cells["is_checked"].Value);
                    string postingStatus = row.Cells["posting_status"].Value.ToString();

                    if (isChecked && string.IsNullOrEmpty(postingStatus))
                        totalCheckedRowCount += 1;
                }

                foreach (DataGridViewRow dgvRow in dgProperties.Rows)
                {
                    bool isChecked = Convert.ToBoolean(dgvRow.Cells["is_checked"].Value);
                    string postingStatus = dgvRow.Cells["posting_status"].Value.ToString();
                    if (isChecked && string.IsNullOrEmpty(postingStatus))
                    {
                        int realPropertiesId = GetDatagridViewValue(dgProperties, dgvRow.Index, "real_properties_id");
                        string completeArpNo = GetDatagridViewValue(dgProperties, dgvRow.Index, "complete_arp_no");
                        string ownerName = GetDatagridViewValue(dgProperties, dgvRow.Index, "owner_name");
                        string ownerAddress = GetDatagridViewValue(dgProperties, dgvRow.Index, "owner_address");
                        string propertyKind = GetDatagridViewValue(dgProperties, dgvRow.Index, "property_kind");
                        int effectiviyQuarter = GetDatagridViewValue(dgProperties, dgvRow.Index, "effectivity_quarter");
                        int effectivityYear = GetDatagridViewValue(dgProperties, dgvRow.Index, "effectivity_year");
                        decimal otherImprovements = GetDatagridViewValue(dgProperties, dgvRow.Index, "other_improvements");
                        decimal assessedValue = GetDatagridViewValue(dgProperties, dgvRow.Index, "assessed_value");
                        decimal totalArea = GetDatagridViewValue(dgProperties, dgvRow.Index, "area");
                        string LotNo = GetDatagridViewValue(dgProperties, dgvRow.Index, "lot_no");
                        string classificationCode = GetDatagridViewValue(dgProperties, dgvRow.Index, "classification_code");
                        string classificationName = GetDatagridViewValue(dgProperties, dgvRow.Index, "classification_name");
                        string actualUseCode = GetDatagridViewValue(dgProperties, dgvRow.Index, "actual_use_code");
                        string actualUseName = GetDatagridViewValue(dgProperties, dgvRow.Index, "actual_use_name");
                        int grYear = GetDatagridViewValue(dgProperties, dgvRow.Index, "gr_year");
                        bool isTaxable = GetDatagridViewValue(dgProperties, dgvRow.Index, "is_taxable");
                        int year = Convert.ToInt32(txtYear.Text);

                        //Get Penalty and Tax Rates
                        var dictRptPenalties = AccFactory.RptPenaltiesRepository().GetRecordByID(9);


                        decimal penaltyRate = string.IsNullOrEmpty(GetPenaltyRecord("RPT monthly penalty", "rate")) ? 0 :
                                                                   Convert.ToDecimal(GetPenaltyRecord("RPT monthly penalty", "rate"));
                        string penaltyFrequency = GetPenaltyRecord("RPT monthly penalty", "frequency");
                        decimal basicRate = GetTaxRate("Basic");
                        decimal sefRate = GetTaxRate("Special Educational Fund");
                        DateTime postedAt = DateTime.Now;
                        bool isCancelled = Convert.ToBoolean(Convert.ToInt32((GetRealPropertyRecord(realPropertiesId, "is_cancelled"))));

                        var assessmentPostingModel = new RptAssessmentPostsModel()
                        {
                            propertyIdentifier = GetRealPropertyRecord(realPropertiesId, "property_identifier"),
                            CompleteArpNo = completeArpNo,
                            PropertyPin = GetViewRealPropertyRecord(realPropertiesId, "pin"),
                            OwnerName = ownerName,
                            OwnerTin = GetRealPropertyRecord(realPropertiesId, "owner_tin"),
                            OwnerAddress = ownerAddress,
                            OwnerContact = GetRealPropertyRecord(realPropertiesId, "owner_contact"),
                            BarangayName = GetViewRealPropertyRecord(realPropertiesId, "barangay_name"),
                            MunicipalityName = GetViewRealPropertyRecord(realPropertiesId, "municipality_name"),
                            ProvinceName = GetViewRealPropertyRecord(realPropertiesId, "province_name"),
                            PropertyKind = propertyKind,
                            EffectivityQuarter = effectiviyQuarter,
                            EffectivityYear = effectivityYear,
                            AssessedValue = assessedValue,
                            Area = totalArea,
                            LotNo = LotNo,
                            OtherImprovements = otherImprovements,
                            ClassificationCode = classificationCode,
                            ClassificationName = classificationName,
                            ActualUseCode = actualUseCode,
                            ActualUseName = actualUseName,
                            GrYear = grYear,
                            IsTaxable = isTaxable,
                            IsCancelled = isCancelled,
                            PenaltyRate = penaltyRate,
                            PenaltyFrequency = penaltyFrequency,
                            BasicRate = basicRate,
                            SefRate = sefRate,
                            Year = year,
                            PostedAt = postedAt,
                            PostedBy = Helper.UserId
                        };

                        assessmentPostingModels.Add(assessmentPostingModel);
                        progressCount += 1;
                        backgroundWorker1.ReportProgress((progressCount * 100) / totalCheckedRowCount);
                    }
                }

                AccFactory.RptAssessmentPostsRepository().BulkInsert(assessmentPostingModels);
            }
            catch (Exception ex)
            {
                Helper.MessageBoxError(ex.Message);
            }
        }

        private void backgroundWorker1_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            lblPostingAssessments.Visible = true;
            prgrsBarPostingAssessments.Visible = true;
            prgrsBarPostingAssessments.Value = e.ProgressPercentage;
        }

        private void backgroundWorker1_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (prgrsBarPostingAssessments.Value == 100)
            {
                Helper.MessageBoxSuccess("Assessments has been posted.");
                LoadProperties();
                lblPostingAssessments.Visible = false;
                prgrsBarPostingAssessments.Visible = false;
            }
            else
            {
                Helper.MessageBoxError("Assessments failed to post.");
                lblPostingAssessments.Visible = false;
                prgrsBarPostingAssessments.Visible = false;
            }

        } 

        #endregion

        private void dgProperties_SelectionChanged(object sender, EventArgs e)
        {
            int selectedRowCount = dgProperties.SelectedRows.Count;
            if (selectedRowCount > 0)
            {
                int rowIndex = dgProperties.CurrentRow.Index;

                string postedAt = GetDatagridViewValue(dgProperties, rowIndex, "posted_at");
                string postedBy = GetDatagridViewValue(dgProperties, rowIndex, "posted_by");

                if (selectedRowCount == 1)
                {
                    lblPostedAt.Text = postedAt;
                    lblPostedBy.Text = postedBy;
                }
                else
                {
                    lblPostedAt.Text = "-";
                    lblPostedBy.Text = "-";
                }
            }
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {         
            LoadProperties();
        }
    }
}
