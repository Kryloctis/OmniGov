using OmniGov.App.Helpers;
using OmniGov.Core.Entities;
using OmniGov.Core.Factories;

namespace OmniGov.App.Views.Manage.AccountableForm
{
    public partial class frmAddFaceValue : Form
    {
        private ucFaceValue uc;
        private int accountableFormId;
        private frmAccountableForm frmAccountableForm;

        public frmAddFaceValue(frmAccountableForm frmAccountableForm, int accountableFormId)
        {
            InitializeComponent();
            uc = ucFaceValue1;
            this.accountableFormId = accountableFormId;
            this.frmAccountableForm = frmAccountableForm;
        }

        private bool Save()
        {
            if (!uc.ValidateChildren())
            {
                Helper.MessageBoxError(uc.GetFormErrors());
                return false;
            }

            var model = new FaceValueModel()
            {
                accountable_forms_id = this.accountableFormId,
                facedate = uc.dtDateEffective.Value,
                facevalue = uc.nudAmount.Value,
                isDefault = uc.chckDefault.Checked
            };

            return Factory.FaceValueRepository().Insert(model);
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (Save())
            {
                Helper.MessageBoxSuccess("Face Value has been saved.");
                frmAccountableForm.LoadFaceValues(accountableFormId);
                uc.ResetForm();
            }
        }
    }
}