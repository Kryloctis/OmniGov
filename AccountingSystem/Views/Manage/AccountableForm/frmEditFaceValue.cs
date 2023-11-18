using ACC.Data;
using ACC.Domain.Models;
using System;
using System.Windows.Forms;

namespace AccountingSystem.Views.Manage.AccountableForm
{
    public partial class frmEditFaceValue : Form
    {
        private ucFaceValue uc;
        private int faceValueId;
        private int accountableFormId;
        private frmAccountableForm frmAccountableForm;

        public frmEditFaceValue(frmAccountableForm frmAccountableForm, int accountableFormId, int faceValueId)
        {
            InitializeComponent();
            uc = ucFaceValue1;
            this.faceValueId = faceValueId;
            this.accountableFormId = accountableFormId;
            this.frmAccountableForm = frmAccountableForm;
        }

        private bool UpdateData()
        {
            if (!uc.ValidateChildren())
            {
                Helper.MessageBoxError(uc.GetFormErrors());
                return false;
            }

            var model = new FaceValueModel()
            {
                accountable_forms_id = accountableFormId,
                facedate = uc.dtDateEffective.Value,
                facevalue = uc.nudAmount.Value,
                id = faceValueId,
                isDefault = uc.chckDefault.Checked
            };

            return AccFactory.FaceValueRepository().Update(model);
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (UpdateData())
            {
                Helper.MessageBoxSuccess("Face Value has been updated.");
                frmAccountableForm.LoadFaceValues(accountableFormId);
                Close();
            }
        }

        private void frmEditFaceValue_Load(object sender, EventArgs e)
        {
            try
            {
                uc.LoadSelectedData(faceValueId);
            }
            catch (Exception ex) { Helper.MessageBoxError(ex.Message); }
        }
    }
}