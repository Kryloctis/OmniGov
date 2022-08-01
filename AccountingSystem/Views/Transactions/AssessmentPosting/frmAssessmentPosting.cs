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
        public frmAssessmentPosting()
        {
            InitializeComponent();
            Helper.DatagridFullRowSelectStyle(dgProperties, true, false);
            Helper.LoadFormIcon(this);
            lblPostedAt.Text = string.Empty;
        }

        private void frmAssessmentPosting_Load(object sender, EventArgs e)
        {
            cmbxBarangays.ComboBox.SelectionChangeCommitted += ComboBoxOnSelectionChangeCommitted;
            LoadBarangays();
            LoadProperties();
            nudYear.Value = Helper.GetCurrentDate().Year;
            EnableDisableToolStripButton(dgProperties, btnPostSelected, btnUnpostSelected);
        }

        private void ComboBoxOnSelectionChangeCommitted(object sender, EventArgs e)
        {       
            LoadProperties();         
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

        private DataTable DataTableAssessmentPosting()
        {
            int year = (int)nudYear.Value;
            int barangayId = int.Parse(((DataRowView)cmbxBarangays.ComboBox.SelectedItem)["id"].ToString());
            string searchText = txtSearch.Text.Trim();
            var dtViewRealProperties = RptFactory.RealPropertiesRepository().GetPropertiesBy_Quarter_Year_BarangayId_Search(year, barangayId, searchText);
            var dataTable = new DataTable();

            #region Populate columns for new datagridView

            var rptColumns = new DataColumn[]
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
                new DataColumn("is_taxable", typeof(bool)),
                new DataColumn("penalty_rate", typeof(decimal)),
                new DataColumn("penalty_frequency", typeof(string)),
                new DataColumn("basic_rate", typeof(decimal)),
                new DataColumn("sef_rate", typeof(decimal)),
                new DataColumn("posted_at", typeof(string)),
                new DataColumn("posted_by", typeof(string))
            };


            dataTable.Columns.AddRange(rptColumns);

            #endregion

            foreach (DataRow row in dtViewRealProperties.Rows)
            {
                string rowPostingStatus = string.Empty;
                int rowId = Convert.ToInt32(row["real_properties_id"]);
                string rowCompleteArpNo = row["complete_arp_no"].ToString();
                string rowOwnerName = row["owner_name"].ToString();
                string rowOwnerAddress = row["owner_address"].ToString();
                string rowPropertyKind = row["property_kind"].ToString();
                int rowEffectivityQuarter = Convert.ToInt32(row["effectivity_quarter"]);
                int rowEffectivityYear = Convert.ToInt32(row["effectivity_year"]);
           
                bool rowIsTaxable = Convert.ToBoolean(row["is_taxable"]);
                decimal rowAssessedValue = Convert.ToDecimal(row["assessed_value"]);
                string rowPostedAt = string.Empty;
                decimal rowPenaltyRate = 0;
                string rowPenaltyFrequency = string.Empty;
                decimal rowBasicRate = 0;
                decimal rowSefRate = 0;
                string rowPostedBy = string.Empty;

                dataTable.Rows.Add(false, 
                                   rowPostingStatus,
                                   rowId,
                                   rowCompleteArpNo, 
                                   rowOwnerName, 
                                   rowOwnerAddress, 
                                   rowPropertyKind, 
                                   rowEffectivityQuarter, 
                                   rowEffectivityYear, 
                                   rowAssessedValue,
                                   rowIsTaxable,                        
                                   rowPenaltyRate,
                                   rowPenaltyFrequency, 
                                   rowBasicRate, 
                                   rowSefRate,
                                   rowPostedAt,
                                   rowPostedBy);
            }

            return dataTable;
        }

        private void LoadProperties()
        {
            try
            {
                HelperLoadRecords.RealPropertiesSearchDatagridView(DataTableAssessmentPosting(), dgProperties);
                lblRecordCount.Text = Helper.GetDatagridViewRecordCount(dgProperties).ToString();
                EnableDisableToolStripButton(dgProperties, btnPostSelected, btnUnpostSelected);
                chckBxAll.Checked = false;
            }
            catch (Exception ex)
            {
                Helper.MessageBoxError(ex.Message);
            }
        }


        private void dgProperties_ColumnAdded(object sender, DataGridViewColumnEventArgs e)
        {
            if (e.Column.Name != "is_checked")
                e.Column.ReadOnly = true;
            else
                e.Column.ReadOnly = false;
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            LoadProperties();
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
            EnableDisableToolStripButton(dgProperties, btnPostSelected, btnUnpostSelected);
        }

        private void btnManualPosting_Click(object sender, EventArgs e)
        {
            _ = new frmManualPosting().ShowDialog();
        }



        private dynamic GetDatagridViewValue(DataGridView dataGridView, int rowIndex, string columnName)
        {
            return dataGridView.Rows[rowIndex].Cells[columnName].Value;
        }

        private decimal GetTaxRate(string description) 
        {
            var dicTaxRate = AccFactory.rptTaxRatesRepository().GetRecordByDescription(description);
            decimal taxRate = 0;

            if (dicTaxRate != null)
                taxRate = Convert.ToDecimal(dicTaxRate["rate"]);

            return taxRate;
        }

        private bool SaveData()
        {
            foreach (DataGridViewRow dgvRow in dgProperties.Rows)
            {
                bool isChecked = Convert.ToBoolean(dgvRow.Cells["is_checked"].Value);
                if (isChecked)
                {
                    int realPropertiesId = GetDatagridViewValue(dgProperties, dgvRow.Index, "real_properties_id");
                    string completeArpNo = GetDatagridViewValue(dgProperties, dgvRow.Index, "complete_arp_no");
                    string ownerName = GetDatagridViewValue(dgProperties, dgvRow.Index, "owner_name");
                    string ownerAddress = GetDatagridViewValue(dgProperties, dgvRow.Index, "owner_address");
                    string propertyKind = GetDatagridViewValue(dgProperties, dgvRow.Index, "property_kind");
                    int effectiviyQuarter = GetDatagridViewValue(dgProperties, dgvRow.Index, "effectivity_quarter");
                    int effectivityYear = GetDatagridViewValue(dgProperties, dgvRow.Index, "effectivity_year");
                    decimal assessedValue = GetDatagridViewValue(dgProperties, dgvRow.Index, "assessed_value");
                    bool isTaxable = GetDatagridViewValue(dgProperties, dgvRow.Index, "is_taxable");

                    //Get Penalty and Tax Rates
                    var dictRptPenalties = AccFactory.rptPenaltiesRepository().GetRecordByID(9);
                    var dictRealProperties = RptFactory.RealPropertiesRepository().GetRecordByID(realPropertiesId);
                    var dictViewRealProperties = RptFactory.RealPropertiesRepository().GetViewRealPropertiesById(realPropertiesId);

                    decimal penaltyRate = dictRptPenalties == null? 0 : Convert.ToDecimal(dictRptPenalties["rate"]);
                    string penaltyFrequency = dictRptPenalties == null? string.Empty : dictRptPenalties["frequency"].ToString();
                    decimal basicRate = GetTaxRate("Basic");
                    decimal sefRate = GetTaxRate("Special Educational Fund");
                    DateTime postedAt = DateTime.Now;
                    int year = (int)nudYear.Value;

                    var assessmentPostingModel = new AssessmentPostingModel()
                    {
                        propertyIdentifier = dictRealProperties == null? null : dictRealProperties["property_identifier"],
                        CompleteArpNo = completeArpNo,
                        PropertyPin = dictViewRealProperties == null? string.Empty : dictViewRealProperties["pin"],
                        OwnerName = ownerName,
                        OwnerTin = dictRealProperties == null? string.Empty : dictRealProperties["owner_tin"],
                        OwnerAddress = ownerAddress,
                        OwnerContact = dictRealProperties == null ? string.Empty : dictRealProperties["owner_contact"],
                        BarangayName =  dictViewRealProperties == null ? string.Empty : dictViewRealProperties["barangay_name"],
                        MunicipalityName =  dictViewRealProperties == null ? string.Empty : dictViewRealProperties["municipality_name"],
                        ProvinceName =  dictViewRealProperties == null ? string.Empty : dictViewRealProperties["province_name"],
                        PropertyKind = propertyKind,
                        EffectivityQuarter = effectiviyQuarter,
                        EffectivityYear = effectivityYear,
                        AssessedValue = assessedValue,
                        IsTaxable = isTaxable,
                        IsCancelled = Convert.ToBoolean(int.Parse(dictRealProperties == null? "0" : dictRealProperties["is_cancelled"])),

                        PenaltyRate = penaltyRate,
                        PenaltyFrequency = penaltyFrequency,
                        BasicRate = basicRate,
                        SefRate = sefRate,
                        Year = year,
                        PostedAt = postedAt,
                        PostedBy = Helper.UserId
                    };

                    AccFactory.AssessmentPostsRepository().Insert(assessmentPostingModel);
                }
            }

            return true;
        }

        private void EnableDisableToolStripButton(DataGridView dataGridView, ToolStripButton post, ToolStripButton unpost) 
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

                if (postedCount > 0)
                {
                    unpost.Enabled = true;
                    unpost.Text = $"Unpost({postedCount})";
                }
                else
                {
                    unpost.Enabled = false;
                    unpost.Text = $"Unpost({0})";
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
            SaveData();
        }

        private void nudYear_ValueChanged(object sender, EventArgs e)
        {
            LoadProperties();
        }
    }
}
