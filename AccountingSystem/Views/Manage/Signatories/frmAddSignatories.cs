using ACC.Domain.Models;
using System;
using System.Windows.Forms;

namespace AccountingSystem.Views.Manage.Signatories
{
    public partial class frmAddSignatories : Form
    {
        private ucSignatories uc;

        public frmAddSignatories()
        {
            InitializeComponent();
            uc = ucSignatories1;
        }

        private bool SaveData()
        {
            try
            {
                if (!uc.ValidateChildren())
                {
                    Helper.MessageBoxError(uc.GetFormErrors());
                    return false;
                }

                var signatoriesModel = new SignatoriesModel()
                {
                    Prefix = uc.txtPrefix.Text.Trim(),
                    FirstName = uc.txtFirstName.Text.Trim(),
                    MiddleInitial = Convert.ToChar(uc.txtMiddleInitial.Text),
                    LastName = uc.txtMiddleInitial.Text.Trim(),
                    Suffix = uc.txtSuffix.Text.Trim(),
                    Title = uc.txtTitle.Text.Trim()
                };


                return Factory.SignatoriesRepository().Insert(signatoriesModel);
            }
            catch (Exception ex)
            {
                Helper.MessageBoxError(ex.Message);
            }
            return false;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (SaveData())
            {
                Helper.MessageBoxSuccess("Signatory has been saved");
                uc.ResetForm();
            }
        }

        private void frmAddSignatories_Load(object sender, EventArgs e)
        {
            uc.isEdit = false;
        }
    }
}
