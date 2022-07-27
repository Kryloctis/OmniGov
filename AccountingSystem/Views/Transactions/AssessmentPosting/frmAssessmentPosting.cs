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
            Helper.DatagridFullRowSelectStyle(dgProperties);
            Helper.LoadFormIcon(this);
        }

        private void frmAssessmentPosting_Load(object sender, EventArgs e)
        {
            LoadBarangays();
            LoadProperties();
        }

        #region Loaddata

        internal void LoadBarangays()
        {
            var dtBarangays = RptFactory.RealPropertiesRepository().GetBarangays();
            HelperLoadRecords.BarangayCombobox(dtBarangays, cmbBarangays, "name", "id");
        }

        private DataTable DataTableAssessmentPosting()
        {
            var isCancelledProeprty = checkFilterCancelledProp.Checked;
            var barangay = cmbBarangays.Text.ToString();
            var searchKey = txtSearch.Text.Trim();

            var dtViewRealProperties = RptFactory.RealPropertiesRepository().GetProperties(barangay, searchKey, isCancelledProeprty);
            var dataTable = new DataTable();


            dataTable.Columns.Add("checkbox", typeof(bool));

            foreach (DataColumn column in dtViewRealProperties.Columns)
            {
                if (column.ColumnName == "is_taxable")
                {
                    dataTable.Columns.Add(column.ToString(), typeof(Image));
                    continue;
                }

                if (column.ColumnName == "is_cancelled")
                {
                    dataTable.Columns.Add(column.ToString(), typeof(Image));
                    continue;
                }

                dataTable.Columns.Add(column.ToString(), column.DataType);
            }

            dataTable.Columns.Add("assessed_value", typeof(string));
            dataTable.Columns.Add("penalty_rate", typeof(string));
            dataTable.Columns.Add("penalty_frequency", typeof(string));
            dataTable.Columns.Add("basic_rate", typeof(string));
            dataTable.Columns.Add("sef_rate", typeof(string));
            dataTable.Columns.Add("is_posted", typeof(Image));

            foreach (DataRow row in dtViewRealProperties.Rows)
            {
                int id = Convert.ToInt32(row["id"]);
                string completeArpNo = row["complete_arp_no"].ToString();
                string pin = row["pin"].ToString();
                decimal assessedValue = RptFactory.RealPropertiesRepository().GetAssessedValueByARPNo(completeArpNo);
                string ownerName = row["owner_name"].ToString();
                string barangayCode = row["barangay_code"].ToString();
                string barangayName = row["barangay_name"].ToString();
                string municipalityCode = row["municipality_code"].ToString();
                string municipalityName = row["municipality_name"].ToString();
                string provinceCode = row["province_code"].ToString();
                string provinceName = row["province_name"].ToString();
                string propertyKind = row["property_kind"].ToString();
                int effectivityQuarter = Convert.ToInt32(row["effectivity_quarter"].ToString());
                int effectivityYear = Convert.ToInt32(row["effectivity_year"].ToString());

                bool isTaxable = Convert.ToBoolean(row["is_taxable"]);
                bool isCancelled = Convert.ToBoolean(row["is_cancelled"]);
                bool isPosted = AccFactory.AssessmentPostsRepository().IsPropertyPosted(completeArpNo);
                decimal penaltyRate = AccFactory.rptPenaltiesRepository().GetPenaltyRate();
                string penaltyFrequency = AccFactory.rptPenaltiesRepository().GetPenaltyFrequency();
                decimal basicRate = AccFactory.rptTaxRatesRepository().GetTaxRateByCode("BSC");
                decimal sefRate = AccFactory.rptTaxRatesRepository().GetTaxRateByCode("SEF");
                
                Image isTaxableImg = isTaxable ? Properties.Resources.symbol_ok_18px : null;
                Image isCancelledImg = isCancelled ? Properties.Resources.symbol_ok_18px : null;
                Image isPostedImg = isPosted ? Properties.Resources.symbol_ok_18px : null;

                dataTable.Rows.Add(false, id, completeArpNo, pin, ownerName, barangayCode, barangayName, municipalityCode, municipalityName, provinceCode, provinceName, propertyKind, effectivityQuarter, effectivityYear, isTaxableImg, isCancelledImg, assessedValue, penaltyRate, penaltyFrequency, basicRate, sefRate, isPostedImg);

            }

            return dataTable;
        }

        private void LoadProperties()
        {
            HelperLoadRecords.RealPropertiesSearchDatagridView(DataTableAssessmentPosting(), dgProperties);
        }

        #endregion

        private void btnPost_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Post selected properties?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                if (SaveData())
                {
                    Helper.MessageBoxSuccess("Property successfully posted.");
                    LoadProperties();
                }
            }
            return;
        }

        private bool SaveData()
        {
            foreach (DataGridViewRow dgvRow in dgProperties.Rows)
            {
                if (Convert.ToBoolean(dgvRow.Cells["checkbox"].Value))
                {
                    string completeArpNo = dgvRow.Cells["complete_arp_no"].Value.ToString();
                    string propertyPIN = dgvRow.Cells["pin"].Value.ToString();
                    string ownerName = dgvRow.Cells["owner_name"].Value.ToString();
                    string barangayCode = dgvRow.Cells["barangay_code"].Value.ToString();
                    string barangayName = dgvRow.Cells["barangay_name"].Value.ToString();
                    string municipalityCode = dgvRow.Cells["municipality_code"].Value.ToString();
                    string municipalityName = dgvRow.Cells["municipality_name"].Value.ToString();
                    string provinceCode = dgvRow.Cells["province_code"].Value.ToString();
                    string provinceName = dgvRow.Cells["province_name"].Value.ToString();
                    string propertyKind = dgvRow.Cells["property_kind"].Value.ToString(); 
                    int effectivityQuarter =Convert.ToInt32(dgvRow.Cells["effectivity_quarter"].Value);
                    int effectivityYear = Convert.ToInt32(dgvRow.Cells["effectivity_year"].Value);
                    decimal assessedValue = Convert.ToDecimal(dgvRow.Cells["assessed_value"].Value);
                    bool isTaxable = string.IsNullOrEmpty(dgvRow.Cells["is_taxable"].ToString());
                    bool isCancelled = string.IsNullOrEmpty(dgvRow.Cells["is_cancelled"].ToString());
                    DateTime postedAt = DateTime.Now;
                    decimal penaltyRate = Convert.ToDecimal(dgvRow.Cells["penalty_rate"].Value);
                    string penaltyFrequency = dgvRow.Cells["penalty_frequency"].Value.ToString();
                    decimal basicRate = Convert.ToDecimal(dgvRow.Cells["basic_rate"].Value);
                    decimal sefRate = Convert.ToDecimal(dgvRow.Cells["sef_rate"].Value);


                    var assessmentPostingModel = new AssessmentPostingModel()
                    {
                        ArpNo = completeArpNo,
                        PIN = propertyPIN,
                        Owner = ownerName,
                        BarangayCode = barangayCode,
                        BarangayName = barangayName,
                        MunicipalityCode = municipalityCode,
                        MunicipalityName = municipalityName,
                        ProvinceCode = provinceCode,
                        ProvinceName = provinceName,
                        PropertyKind = propertyKind,
                        EffectivityQuarter = effectivityQuarter,
                        EffectivityYear = effectivityYear,
                        AssessedValue = assessedValue,
                        IsTaxable = isTaxable,
                        IsCancelled = isCancelled,
                        PostedAt = postedAt,
                        PenaltyRate = penaltyRate,
                        PenaltyFrequency = penaltyFrequency,
                        BasicRate = basicRate,
                        SEFRate = sefRate
                    };

                    AccFactory.AssessmentPostsRepository().Insert(assessmentPostingModel);
                }
            }

            return true;
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            LoadProperties();
        }

        private void dgProperties_SelectionChanged(object sender, EventArgs e)
        {
            if (dgProperties.SelectedRows.Count == 0)
                btnPost.Enabled = false;
            else
                btnPost.Enabled = true;
        }

        private void dgProperties_ColumnAdded(object sender, DataGridViewColumnEventArgs e)
        {
            if (e.Column.Name != "checkbox")
                e.Column.ReadOnly = true;
            else
                e.Column.ReadOnly = false;
        }

        private void checkFilterCancelledProp_CheckedChanged(object sender, EventArgs e)
        {
            LoadProperties();
        }

        private void checkAll_CheckedChanged(object sender, EventArgs e)
        {
            foreach (DataGridViewRow row in dgProperties.Rows)
            {
                DataGridViewCheckBoxCell chk = (DataGridViewCheckBoxCell)row.Cells[0];
                chk.Value = !(chk.Value == null ? false : (bool)chk.Value); 
            }
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            var searchCount = txtSearch.Text.Trim().Length;
            if (searchCount >= 2 || searchCount == 0)
                LoadProperties();
            return;
        }

        private void cmbBarangays_SelectionChangeCommitted(object sender, EventArgs e)
        {
            LoadProperties();
        }

        private void btnManualPosting_Click(object sender, EventArgs e)
        {
            _ = new frmManualPosting().ShowDialog();
        }
    }
}
