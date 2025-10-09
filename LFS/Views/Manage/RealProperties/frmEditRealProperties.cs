using ACC.Data;
using LFS.Helpers;
using LFS.Views.Manage.RealProperties;
using System;
using System.Windows.Forms;

namespace LFS.Views.Manage.TaxPayers
{
    public partial class frmEditRealProperties : Form
    {
        private readonly ucRealProperties uc;
        private readonly int rptId;
        private readonly frmRealProperties frmRealProperties;

        public frmEditRealProperties(frmRealProperties frmRealProperties, int rptId)
        {
            InitializeComponent();
            Helper.LoadFormIcon(this);
            this.frmRealProperties = frmRealProperties;
            this.rptId = rptId;
            uc = ucRealProperties1;
        }

        private bool UpdateRpt()
        {
            if (!uc.ValidateChildren())
            {
                Helper.MessageBoxError(uc.GetFormError());
                return false;
            }

            var rptModel = uc.RealPropertiesModel();
            rptModel.Id = rptId;
            rptModel.UpdatedBy = UserHelper.loggedUser.Id;

            return AccFactory.RealPropertiesRepository().UpdateWithPreviousAssessements(rptModel);
        }

        private void frmEditRealProperties_Load(object sender, EventArgs e)
        {
            try
            {
                uc.OnLoad(true, rptId);
                ActiveControl = uc;
            }
            catch (Exception ex) { Helper.MessageBoxError(ex.Message); }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            try
            {
                if (UpdateRpt())
                {
                    Helper.MessageBoxSuccess("Real property has been updated");
                    frmRealProperties.LoadProperties();
                    Close();
                }
            }
            catch (Exception ex) { Helper.MessageBoxError(ex.Message); }
        }

        private void frmEditRealProperties_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.S && e.Control)
                {
                    if (UpdateRpt())
                    {
                        Helper.MessageBoxSuccess("Real property has been updated.");
                        frmRealProperties.LoadProperties();
                        Close();
                    }
                }
            }
            catch (Exception ex) { Helper.MessageBoxError(ex.Message); }
        }
    }
}