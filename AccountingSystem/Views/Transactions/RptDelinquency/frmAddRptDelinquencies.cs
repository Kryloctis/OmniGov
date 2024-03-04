using ACC.Data;
using ACC.Domain.Models;
using AccountingSystem.Views.Reports.RptDeliquency;
using System;
using System.Windows.Forms;

namespace AccountingSystem.Views.Reports.RptDelinquency
{
    public partial class frmAddRptDelinquencies : Form
    {
        internal readonly frmRptDelinquencies _frmRptDelinquencies;
        internal readonly ucRptDelinquency uc;

        public frmAddRptDelinquencies(frmRptDelinquencies frmRptDelinquencies)
        {
            InitializeComponent();
            _frmRptDelinquencies = frmRptDelinquencies;
            uc = ucRptDelinquency1;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                if (SaveData())
                {
                    Helper.MessageBoxSuccess("Record has been saved.");
                    _frmRptDelinquencies.LoadDeliquentProperties();
                }
            }

            catch (Exception ex) { Helper.MessageBoxError(ex.Message); }
        }

        private bool SaveData()
        {
            if (!uc.ValidateChildren())
            {
                Helper.MessageBoxError(uc.GetFormErrors());
                return false;
            }


            var rptAssessmentPostId = Convert.ToInt32(uc.cmbxDelinquentPropertiesArpNo.SelectedValue);
            var delinquencyStatus = uc.cmbxDelinquentStatus.Text.Trim();

            var rptDelinquenciesModel = new RptDelinquenciesModel()
            {
                RptAssessmentPostId = rptAssessmentPostId,
                DelinquenciesStatus = delinquencyStatus,
                CreatedBy = Helper.userId
            };


            return AccFactory.RptDelinquenciesRepository().Insert(rptDelinquenciesModel);
        }

        private void frmAddRptDelinquencies_Load(object sender, EventArgs e)
        {
            try
            {
                uc.OnLoad(false);
            }
            catch (Exception ex) { Helper.MessageBoxError(ex.Message); }
        }
    }
}
