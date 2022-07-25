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
            LoadEffectivityQuarter();
            LoadProperties();
        }

        #region Loaddata

        internal void LoadBarangays()
        {
            var dtBarangays = RptFactory.RealPropertiesRepository().GetBarangays();
            HelperLoadRecords.BarangayCombobox(dtBarangays, cmbBarangays, "name", "id");
        }

        internal void LoadEffectivityQuarter()
        {
            cmbEffectivityQuarter.DataSource = Helper.QuarterDataTable();
            cmbEffectivityQuarter.DisplayMember = "quarter";
            cmbEffectivityQuarter.ValueMember = "id";
        }

        private DataTable DataTableAssessmentPosting()
        {
            var barangay = cmbBarangays.Text.ToString();
            var effectivityQuarter = Convert.ToInt16(cmbEffectivityQuarter.SelectedValue);
            var effectivityYear = Convert.ToInt32(nudEffectivityYear.Value);
            var searchKey = txtSearch.Text.Trim();

            var dtViewRealProperties = RptFactory.RealPropertiesRepository().GetProperties(barangay, effectivityQuarter, effectivityYear, searchKey);
            var dataTable = new DataTable();

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
            dataTable.Columns.Add("discount_rate", typeof(decimal));
            dataTable.Columns.Add("penalty_rate", typeof(decimal));
            dataTable.Columns.Add("penalty_frequency", typeof(decimal));
            dataTable.Columns.Add("basic_rate", typeof(decimal));
            dataTable.Columns.Add("sef_rate", typeof(decimal));
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

                decimal discountRate = (assessedValue * Convert.ToDecimal(0.98));
                decimal penaltyRate = 0m;
                decimal penaltyFrequency = 0m;
                decimal basicRate = 0m;
                decimal sefRate = 0m;
                
                Image isTaxableImg = isTaxable ? Properties.Resources.symbol_ok_18px : null;
                Image isCancelledImg = isCancelled ? Properties.Resources.symbol_ok_18px : null;
                Image isPostedImg = isPosted ? Properties.Resources.symbol_ok_18px : null;

                dataTable.Rows.Add(id, completeArpNo, ownerName, barangayName, pin, isTaxableImg, isCancelledImg, assessedValue, discountRate, penaltyRate, penaltyFrequency, basicRate, sefRate, isPostedImg);

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
            if (SaveData())
            {
                Helper.MessageBoxSuccess("Property successfully posted.");
                LoadProperties();
            }
            
        }

        private bool SaveData()
        {
            foreach (DataGridViewRow dgvRow in dgProperties.SelectedRows)
            {
                string arpNo = dgvRow.Cells["complete_arp_no"].Value.ToString();
                DateTime postedAt = DateTime.Now;

                var assessmentPostsModel = new AssessmentPostingModel() {
                    ArpNo = arpNo,
                    PostedAt = postedAt
                };


                var assessmentPostsRepository = AccFactory.AssessmentPostsRepository();
                return assessmentPostsRepository.Insert(assessmentPostsModel);
            }

            return false;
        }

        private void cmbBarangays_SelectionChangeCommitted(object sender, EventArgs e)
        {
            LoadProperties();
        }

        private void cmbEffectivityQuarter_SelectionChangeCommitted(object sender, EventArgs e)
        {
            LoadProperties();
        }

        private void nudEffectivityYear_ValueChanged(object sender, EventArgs e)
        {
            LoadProperties();
        }
    }
}
