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
        }

        #region Loaddata

        internal void LoadBarangays()
        {
            var dtBarangays = RptFactory.RealPropertiesRepository().GetBarangays();
            HelperLoadRecords.BarangayCombobox(dtBarangays, cmbBarangays, "name", "id");
        }

        private DataTable DataTableAssessmentPosting()
        {
            var currentDate = Convert.ToSByte(1);
            var barangay = cmbBarangays.Text.ToString();
            var searchKey = txtSearch.Text.Trim();

            var dtViewRealProperties = RptFactory.RealPropertiesRepository().GetProperties(barangay, searchKey);
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
            dataTable.Columns.Add("discount_rate", typeof(string));
            dataTable.Columns.Add("penalty_rate", typeof(string));
            dataTable.Columns.Add("penalty_frequency", typeof(string));
            dataTable.Columns.Add("basic_rate", typeof(string));
            dataTable.Columns.Add("sef_rate", typeof(string));
            dataTable.Columns.Add("is_posted", typeof(Image));

            foreach (DataRow row in dtViewRealProperties.Rows)
            {
                int id = Convert.ToInt32(row["id"]);
                string completeArpNo = row["complete_arp_no"].ToString();
                decimal assessedValue = RptFactory.RealPropertiesRepository().GetAssessedValueByARPNo(completeArpNo);
                string ownerName = row["owner_name"].ToString();
                string barangayName = row["barangay_name"].ToString();
                string pin = row["pin"].ToString();
                bool isTaxable = Convert.ToBoolean(row["is_taxable"]);
                bool isCancelled = Convert.ToBoolean(row["is_cancelled"]);
                bool isPosted = AccFactory.AssessmentPostsRepository().IsPropertyPosted(completeArpNo);
                
                decimal discountRate = AccFactory.rptDiscountRepository().GetDiscountRateByMonth(currentDate);
                decimal penaltyRate = AccFactory.rptPenaltiesRepository().GetPenaltyRate();
                string penaltyFrequency = "Monthly";
                decimal basicRate = AccFactory.rptTaxRatesRepository().GetTaxRateByCode("BSC");
                decimal sefRate = AccFactory.rptTaxRatesRepository().GetTaxRateByCode("SEF");
                
                Image isTaxableImg = isTaxable ? Properties.Resources.symbol_ok_18px : null;
                Image isCancelledImg = isCancelled ? Properties.Resources.symbol_ok_18px : null;
                Image isPostedImg = isPosted ? Properties.Resources.symbol_ok_18px : null;

                dataTable.Rows.Add(false, id, completeArpNo, ownerName, barangayName, pin, isTaxableImg, isCancelledImg, assessedValue, discountRate.ToString("P0"), penaltyRate.ToString("P0"), penaltyFrequency, basicRate.ToString("P0"), sefRate.ToString("P0"), isPostedImg);

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
                    string barangayCode = "code";
                    string barangayName = dgvRow.Cells["barangay_name"].Value.ToString();
                    string municipalityCode = "code";
                    string municipalityName = "name";
                    string provinceCode = "code";
                    string provinceName = "name";
                    string propertyKind = "L";
                    int effectivityQuarter = 1;
                    int effectivityYear = 2022;
                    bool isTaxable = string.IsNullOrEmpty(dgvRow.Cells["is_taxable"].ToString());
                    bool isCancelled = string.IsNullOrEmpty(dgvRow.Cells["is_cancelled"].ToString());
                    DateTime postedAt = DateTime.Now;
                    decimal discountRate = Convert.ToDecimal(dgvRow.Cells["discount_rate"].Value);
                    decimal penaltyRate = 0m;
                    string penaltyFrequency = string.Empty;
                    decimal basicRate = 0m;
                    decimal sefRate = 0m;

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
                        IsTaxable = isTaxable,
                        IsCancelled = isCancelled,
                        PostedAt = postedAt,
                        DiscountRate = discountRate,
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
    }
}
