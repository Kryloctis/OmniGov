using ACC.Data;
using ACC.Domain.Models;
using System;
using System.Windows.Forms;

namespace AccountingSystem.Views.Manage.AccountableForm
{
    public partial class frmAddAccountableForm : Form
    {
        private readonly frmAccountableForm _frmAccountableForm;
        private readonly ucAccountableForm uc;

        public frmAddAccountableForm(frmAccountableForm frmAccountableForm)
        {
            InitializeComponent();
            Helper.LoadFormIcon(this);
            _frmAccountableForm = frmAccountableForm;
            uc = ucAccountable1;
        }

        private bool SaveData()
        {
            if (!uc.ValidateChildren())
            {
                Helper.MessageBoxError(uc.GetFormErrors());
                return false;
            }

            var accModel = new AccountableFormsModel()
            {
                AccFormNo = uc.txtFormNo.Text.Trim(),
                AccFormDesc = uc.txtFormDescription.Text.Trim()
            };

            return AccFactory.AccountableFormsRepository().Insert(accModel);
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                if (SaveData())
                {
                    Helper.MessageBoxSuccess("Accountable Form has been saved.");
                    _frmAccountableForm.LoadRecords();
                    uc.ResetForm();
                }
            }
            catch (Exception ex) { Helper.MessageBoxError(ex.Message); }
        }
    }
}