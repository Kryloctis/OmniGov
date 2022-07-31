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

        private void GetAssessedValues(DataGridView dataGridView)
        {
            foreach (DataGridViewRow row in dataGridView.Rows) 
            {

            }
        }

        private void DataTableAssessmentPosting()
        {
            int year = (int)nudYear.Value;
            int barangayId = int.Parse(((DataRowView)cmbxBarangays.ComboBox.SelectedItem)["id"].ToString());
            string searchText = txtSearch.Text.Trim();
            dgProperties.Rows.Clear();
            dgProperties.Columns.Clear();
            var dtViewRealProperties = RptFactory.RealPropertiesRepository().GetPropertiesBy_Quarter_Year_BarangayId_Search(year, barangayId, searchText);

            #region Populate columns for new datagridView

            var rptColumns = new DataGridViewColumn[]
            {
                new DataGridViewCheckBoxColumn()
                {
                    Name = "is_checked",
                    HeaderText = string.Empty,
                    MinimumWidth = 20,
                    AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
                },

                new DataGridViewTextBoxColumn()
                {
                    Name = "posting_status",
                    HeaderText = "Posting Status"
                },

                new DataGridViewTextBoxColumn()
                {
                    Name = "complete_arp_no",
                    HeaderText = "ARP No."
                },

                new DataGridViewTextBoxColumn()
                {
                    Name = "pin",
                    HeaderText = "PIN"
                },

                new DataGridViewTextBoxColumn()
                {
                    Name = "owner_name",
                    HeaderText = "Owner Name"
                },

                new DataGridViewTextBoxColumn()
                {
                    Name = "owner_tin",
                    HeaderText = "Local TIN"
                },

                new DataGridViewTextBoxColumn()
                {
                    Name = "owner_contact",
                    HeaderText = "Owner Contact",
                    Visible = false
                },

                new DataGridViewTextBoxColumn()
                {
                    Name = "owner_address",
                    HeaderText = "Owner Address",
                    Visible = false
                },

                new DataGridViewTextBoxColumn()
                {
                    Name = "barangay_name",
                    HeaderText = "Barangay"
                },

                new DataGridViewTextBoxColumn()
                {
                    Name = "municipality_name",
                    HeaderText = "Municipality",
                    Visible = false
                },

                new DataGridViewTextBoxColumn()
                {
                    Name = "province_name",
                    HeaderText = "Province",
                    Visible = false
                },

                new DataGridViewTextBoxColumn()
                {
                    Name = "property_kind",
                    HeaderText = "Property Kind",
                    Visible = false
                },

                new DataGridViewTextBoxColumn()
                {
                    Name = "effectivity_quarter",
                    HeaderText = "Effectivity Quarter",
                    Visible = false
                },

                new DataGridViewTextBoxColumn()
                {
                    Name = "effectivity_year",
                    HeaderText = "Effectivity Year",
                    Visible = false
                },

                new DataGridViewTextBoxColumn()
                {
                    Name = "assessed_value",
                    HeaderText = "Assessed Value"
                },

                new DataGridViewCheckBoxColumn()
                {
                    Name = "is_taxable",
                    HeaderText = "Taxable",
                    Visible = false
                },

                new DataGridViewCheckBoxColumn()
                {
                    Name = "is_cancelled",
                    HeaderText = "Cancelled",
                    Visible = false
                },

                new DataGridViewTextBoxColumn()
                {
                    Name = "penalty_rate",
                    HeaderText = "Penalty Rate",
                    Visible = false
                },

                new DataGridViewTextBoxColumn()
                {
                    Name = "penalty_frequency",
                    HeaderText = "Penalty Frequency",
                    Visible = false
                },

                new DataGridViewTextBoxColumn()
                {
                    Name = "basic_rate",
                    HeaderText = "Basic Rate",
                    Visible = false
                },

                new DataGridViewTextBoxColumn()
                {
                    Name = "sef_rate",
                    HeaderText = "SEF Rate",
                    Visible = false
                },

                new DataGridViewTextBoxColumn() 
                { 
                    Name = "posted_at", 
                    HeaderText = "Posted at", 
                    Visible = false
                },

                new DataGridViewTextBoxColumn() 
                { 
                    Name = "posted_by", 
                    HeaderText = "Posted By",
                    Visible = false
                }

            };
            dgProperties.Columns.AddRange(rptColumns);
            dgProperties.Columns["assessed_value"].DefaultCellStyle.Format = "N2";

            #endregion

            foreach (DataRow row in dtViewRealProperties.Rows)
            {
                string rowPostingStatus = string.Empty;
                string rowCompleteArpNo = row["complete_arp_no"].ToString();
                string rowPin = row["pin"].ToString();
                string rowOwnerName = row["owner_name"].ToString();
                string rowOwnerTin = row["owner_tin"].ToString();
                string rowOwnerContact = row["owner_contact"].ToString();
                string rowOwnerAddress = row["owner_address"].ToString();
                string rowBarangayName = row["barangay_name"].ToString();
                string rowMunicipalityName = row["municipality_name"].ToString();
                string rowProvinceName = row["province_name"].ToString();
                string rowPropertyKind = row["property_kind"].ToString();
                int rowEffectivityQuarter = Convert.ToInt32(row["effectivity_quarter"]);
                int rowEffectivityYear = Convert.ToInt32(row["effectivity_year"]);
           
                bool rowIsTaxable = Convert.ToBoolean(row["is_taxable"]);
                bool rowIsCancelled = Convert.ToBoolean(row["is_cancelled"]);
                decimal rowAssessedValue = 0;
                string rowIsPostedAt = string.Empty;
                decimal rowPenaltyRate = 0;
                string rowPenaltyFrequency = string.Empty;
                decimal rowBasicRate = 0;
                decimal rowSefRate = 0;
                string rowPostedBy = string.Empty;
                
                dgProperties.Rows.Add(false, 
                                   rowPostingStatus, 
                                   rowCompleteArpNo, 
                                   rowPin, 
                                   rowOwnerName, 
                                   rowOwnerTin, 
                                   rowOwnerContact, 
                                   rowOwnerAddress, 
                                   rowBarangayName, 
                                   rowMunicipalityName, 
                                   rowProvinceName, 
                                   rowPropertyKind, 
                                   rowEffectivityQuarter, 
                                   rowEffectivityYear, 
                                   rowAssessedValue,
                                   rowIsTaxable, 
                                   rowIsCancelled, 
                                   rowIsPostedAt,
                                   rowPenaltyRate,
                                   rowPenaltyFrequency, 
                                   rowBasicRate, 
                                   rowSefRate, 
                                   rowPostedBy);
            }

        }

        private void LoadProperties()
        {
            try
            {
                DataTableAssessmentPosting();
                //HelperLoadRecords.RealPropertiesSearchDatagridView(DataTableAssessmentPosting(), dgProperties);
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

        private void chckShowCancelled_CheckedChanged(object sender, EventArgs e)
        {
            LoadProperties();
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

        private bool SaveData()
        {
            foreach (DataGridViewRow dgvRow in dgProperties.Rows)
            {
                bool isChecked = Convert.ToBoolean(dgvRow.Cells["checkbox"].Value);
                if (isChecked)
                {
                    string completeArpNo = GetDatagridViewValue(dgProperties, dgvRow.Index, "complete_arp_no");
                    string propertyPin = GetDatagridViewValue(dgProperties, dgvRow.Index, "pin");
                    string ownerName = GetDatagridViewValue(dgProperties, dgvRow.Index, "owner_name");
                    string ownerTin = GetDatagridViewValue(dgProperties, dgvRow.Index, "owner_tin");
                    string ownerContact = GetDatagridViewValue(dgProperties, dgvRow.Index, "owner_contact");
                    string ownerAddress = GetDatagridViewValue(dgProperties, dgvRow.Index, "owner_address");
                    string barangayName = GetDatagridViewValue(dgProperties, dgvRow.Index, "barangay_name");
                    string municipalityName = GetDatagridViewValue(dgProperties, dgvRow.Index, "municipality_name");
                    string provinceName = GetDatagridViewValue(dgProperties, dgvRow.Index, "province_name");
                    string propertyKind = GetDatagridViewValue(dgProperties, dgvRow.Index, "property_kind");
                    int effectiviyQuarter = GetDatagridViewValue(dgProperties, dgvRow.Index, "effectivity_quarter");
                    int effectivityYear = GetDatagridViewValue(dgProperties, dgvRow.Index, "effectivity_year");
                    decimal assessedValue = GetDatagridViewValue(dgProperties, dgvRow.Index, "assessed_value");
                    bool isTaxable = GetDatagridViewValue(dgProperties, dgvRow.Index, "is_taxable");
                    bool isCancelled = GetDatagridViewValue(dgProperties, dgvRow.Index, "is_cancelled");
                    DateTime postedAt = GetDatagridViewValue(dgProperties, dgvRow.Index, "posted_at");  
                    decimal penaltyRate = GetDatagridViewValue(dgProperties, dgvRow.Index, "penalty_rate");
                    string penaltyFrequency = GetDatagridViewValue(dgProperties, dgvRow.Index, "penalty_frequency");
                    decimal basicRate = GetDatagridViewValue(dgProperties, dgvRow.Index, "basic_rate");
                    decimal sefRate = GetDatagridViewValue(dgProperties, dgvRow.Index, "sef_rate");

                    var assessmentPostingModel = new AssessmentPostingModel()
                    {
                        CompleteArpNo = completeArpNo,
                        PropertyPin = propertyPin,
                        OwnerName = ownerName,
                        OwnerTin = ownerTin,
                        OwnerContact = ownerContact,
                        OwnerAddress = ownerAddress,
                        BarangayName = barangayName,
                        MunicipalityName = municipalityName,
                        ProvinceName = provinceName,
                        PropertyKind = propertyKind,
                        EffectivityQuarter = effectiviyQuarter,
                        EffectivityYear = effectivityYear,
                        AssessedValue = assessedValue,
                        IsTaxable = isTaxable,
                        IsCancelled = isCancelled,
                        PostedAt = postedAt,
                        PenaltyRate = penaltyRate,
                        PenaltyFrequency = penaltyFrequency,
                        BasicRate = basicRate,
                        SefRate = sefRate,
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

        }

        private void nudYear_ValueChanged(object sender, EventArgs e)
        {
            LoadProperties();
        }
    }
}
