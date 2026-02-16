using LFS.Helpers;
using LFS.Views.Manage.TaxPayers;
using System;
using System.Windows.Forms;
using Treasury.Data;

namespace LFS.Views.Manage.RealProperties
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
            rptModel.CreatedBy = UserHelper.loggedUser.Id;

            return TreasuryFactory.RealPropertiesRepository().InsertWithPreviousAssessments(rptModel);
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
                ActiveControl = uc;
            }
            catch (Exception ex) { Helper.MessageBoxError(ex.Message); }
        }

        private void frmAddRealProperties_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.S && e.Control)
                {
                    if (SaveRpt())
                    {
                        Helper.MessageBoxSuccess("Real property has been saved.");
                        frmRealProperties.LoadProperties();
                        uc.ResetForm();
                    }
                }
            }
            catch (Exception ex) { Helper.MessageBoxError(ex.Message); }
        }
    }
}