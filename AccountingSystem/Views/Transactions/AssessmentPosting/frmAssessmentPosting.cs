using RPT.Data;
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
            var dtViewRealProperties = RptFactory.RealPropertiesRepository().GetProperties();
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
                string arpNo = row["complete_arp_no"].ToString();
                string ownerName = row["owner_name"].ToString();
                string barangayName = row["barangay_name"].ToString();
                string pin = row["pin"].ToString();

                bool isTaxable = Convert.ToBoolean(row["is_taxable"]);
                Image isTaxableImg = isTaxable ? Properties.Resources.symbol_ok_18px : null;
                 
                dataTable.Rows.Add(id, arpNo, ownerName, barangayName, pin, isTaxableImg, null);
            }

            return dataTable;
        }

        private void LoadProperties()
        {
            HelperLoadRecords.RealPropertiesSearchDatagridView(DataTableAssessmentPosting(), dgProperties);
        }

        #endregion

    }
}
