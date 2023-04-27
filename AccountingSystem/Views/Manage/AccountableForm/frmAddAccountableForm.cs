using ACC.Domain.Models;
using System;
using System.Windows.Forms;

namespace AccountingSystem.Views.Manage.AccountableForm
{
    public partial class frmAddAccountableForm : Form
    {
        private frmAccountableForm frmAccountable;
        private ucAccountableForm uc;

        public frmAddAccountableForm(frmAccountableForm frmacc)
        {
            InitializeComponent();
            Helper.LoadFormIcon(this);
            frmAccountable = frmacc;
            uc = ucAccountable1;
        }

        private void frmAccountableAdd_Load(object sender, EventArgs e)
        {
            uc.isEdit = false;
        }

        private bool SaveData()
        {
            if (!uc.ValidateChildren())
            {
                Helper.MessageBoxError(uc.GetFormErrors());
                return false;
            }

            var accModel = new AccountableModel()
            {
                AccFormNo = uc.txtformno.Text.Trim(),
                AccFormDesc = uc.txtformdesc.Text.Trim()
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
                    frmAccountable.LoadRecords();
                    uc.ResetForm();
                }
            }
            catch (Exception ex) { Helper.MessageBoxError(ex.Message); }
        }
    }
}