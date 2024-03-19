using ACC.Data;
using ACC.Domain.Models;
using AccountingSystem.Views.Reports.RptDeliquency;
using System;
using System.Windows.Forms;

namespace AccountingSystem.Views.Reports.RptDelinquency
{
    public partial class frmEditRptDelinquencies : Form
    {
        internal readonly frmRptDelinquencies frmRptDelinquencies;
        private int delinquencyId;
        internal readonly ucRptDelinquency uc;

        public frmEditRptDelinquencies(int delinquencyId, frmRptDelinquencies frmRptDelinquencies)
        {
            InitializeComponent();
            Helper.LoadFormIcon(this);
            this.delinquencyId = delinquencyId;
            this.frmRptDelinquencies = frmRptDelinquencies;
            uc = ucRptDelinquency1;
        }

        private void frmEditRptDelinquencies_Load(object sender, EventArgs e)
        {
            try
            {
                uc.OnLoad(true, delinquencyId);
                ActiveControl = uc;
            }
            catch (Exception ex) { Helper.MessageBoxError(ex.Message); }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            try
            {
                if (UpdateDelinquencyStatus())
                {
                    Helper.MessageBoxSuccess("Delinquency status has been updated");
                    frmRptDelinquencies.LoadDeliquentProperties();
                    Close();
                };
            }
            catch (Exception ex) { Helper.MessageBoxError(ex.Message); }
        }

        private bool UpdateDelinquencyStatus()
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
                Id = delinquencyId,
                RptAssessmentPostId = rptAssessmentPostId,
                DelinquenciesStatus = delinquencyStatus,
                CreatedBy = Helper.userId
            };

            return AccFactory.RptDelinquenciesRepository().Update(rptDelinquenciesModel);
        }
    }
}