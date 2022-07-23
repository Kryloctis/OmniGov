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
        }

        private void frmAssessmentPosting_Load(object sender, EventArgs e)
        {
            //LoadBarangay();
            LoadEffectivityQuarter();
        }



        #region Loaddata

        internal void LoadEffectivityQuarter()
        {
            cmbEffectivityQuarter.DataSource = Helper.QuarterDataTable();
            cmbEffectivityQuarter.DisplayMember = "quarter";
            cmbEffectivityQuarter.ValueMember = "id";
        }


        #endregion

    }
}
