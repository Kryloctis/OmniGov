using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
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
            var dtBarangays = Factory.RealPropertiesRepository().GetBarangays();
            HelperLoadRecords.BarangayCombobox(dtBarangays, cmbBarangays, "name", "id");
        }

        internal void LoadEffectivityQuarter()
        {
            cmbEffectivityQuarter.DataSource = Helper.QuarterDataTable();
            cmbEffectivityQuarter.DisplayMember = "quarter";
            cmbEffectivityQuarter.ValueMember = "id";
        }

        private void LoadProperties()
        {
            var dtProperties = Factory.RealPropertiesRepository().GetProperties();
            HelperLoadRecords.RealPropertiesSearchDatagridView(dtProperties, dgProperties);
        }

        #endregion

    }
}
