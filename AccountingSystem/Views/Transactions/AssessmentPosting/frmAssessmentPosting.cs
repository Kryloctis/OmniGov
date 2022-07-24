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
            var barangaysId = Convert.ToInt32(cmbBarangays.SelectedValue);
            var effectivityQuarter = Convert.ToInt16(cmbEffectivityQuarter.SelectedValue);
            var effectivityYear = Convert.ToInt32(nudEffectivityYear.Value);
            var searchKey = txtSearch.Text.Trim();

            var dtViewRealProperties = RptFactory.RealPropertiesRepository().GetProperties(barangaysId, effectivityQuarter, effectivityYear, searchKey);
            var dataTable = new DataTable();

            foreach (DataColumn column in dtViewRealProperties.Columns)
            {
                if (column.ColumnName == "is_taxable")
                {
                    dataTable.Columns.Add(column.ToString(), typeof(Image));
                    continue;
                }

                dataTable.Columns.Add(column.ToString(), column.DataType);
            }

            dataTable.Columns.Add("is_posted", typeof(Image));

            foreach (DataRow row in dtViewRealProperties.Rows)
            {
                int id = Convert.ToInt32(row["id"]);
                int ownerId = Convert.ToInt32(row["owners_id"]);
                int barangayId = Convert.ToInt32(row["barangays_id"]);
                string arpNo = row["arp_no"].ToString();

                string completeARP = row["complete_arp_no"].ToString();
                string ownerName = row["owner_name"].ToString();
                string barangayName = row["barangay_name"].ToString();
                string pin = row["pin"].ToString();

                bool isTaxable = Convert.ToBoolean(row["is_taxable"]);
                bool isPosted = AccFactory.AssessmentPostsRepository().IsPropertyPosted(arpNo);

                Image isTaxableImg = isTaxable ? Properties.Resources.symbol_ok_18px : null;
                Image isPostedImg = isPosted ? Properties.Resources.symbol_ok_18px : null;

                dataTable.Rows.Add(id, ownerId, barangayId, arpNo, completeARP, ownerName, barangayName, pin, isTaxableImg, isPostedImg);
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
                string arpNo = dgvRow.Cells["arp_no"].Value.ToString();
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
