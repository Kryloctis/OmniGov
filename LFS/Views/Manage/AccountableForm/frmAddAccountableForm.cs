using ACC.Data;
using ACC.Domain.Models;
using LFS.Helpers;
using System;
using System.Windows.Forms;

namespace LFS.Views.Manage.AccountableForm
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
                AccFormDesc = uc.txtFormDescription.Text.Trim(),
                IsCashTicket = uc.cbIsCashTickets.Checked
            };

            return AccFactory.AccountableFormsRepository().Insert(accModel);
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            SaveAccountableForm();
        }

        private void SaveAccountableForm()
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

        private void frmAddAccountableForm_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Modifiers == Keys.Control && e.KeyCode == Keys.S)
            {
                SaveAccountableForm();
            }
        }
    }
}