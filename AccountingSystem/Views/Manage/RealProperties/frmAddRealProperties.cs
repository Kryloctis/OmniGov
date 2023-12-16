using ACC.Data;
using AccountingSystem.Views.Manage.TaxPayers;
using System;
using System.Windows.Forms;

namespace AccountingSystem.Views.Manage.RealProperties
{
    public partial class frmAddRealProperties : Form
    {
        private readonly frmRealProperties frmRealProperties;
        internal readonly ucRealProperties uc;

        public frmAddRealProperties(frmRealProperties frmRealProperties)
        {
            InitializeComponent();
            this.frmRealProperties = frmRealProperties;
            uc = ucRealProperties1;
        }

        private bool SaveRpt()
        {
            if (!uc.ValidateChildren())
            {
                Helper.MessageBoxError(uc.GetFormError());
                return false;
            }

            var rptModel = uc.RealPropertiesModel();
            rptModel.CreatedBy = Helper.UserId;

            return AccFactory.RealPropertiesRepository().InsertWithPreviousAssessments(rptModel);
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                if (SaveRpt())
                {
                    Helper.MessageBoxSuccess("Real property has been saved.");
                    frmRealProperties.LoadProperties();
                    uc.ResetForm();
                }
            }
            catch (Exception ex) { Helper.MessageBoxError(ex.Message); }
        }

        private void frmAddRealProperties_Load(object sender, EventArgs e)
        {
            try
            {
                uc.OnLoad(false);
            }
            catch (Exception ex) { Helper.MessageBoxError(ex.Message); }
        }
    }
}