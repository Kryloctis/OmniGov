using LFS.Helpers;
using OmniGov.Core.Repositories;
using System;
using System.ComponentModel;
using System.Windows.Forms;
using Treasury.Data;

namespace LFS.Views.Manage.AccountableForm
{
    public partial class ucAccountableForm : UserControl
    {
        internal int accountableFormId;
        internal bool isEdit;

        public ucAccountableForm()
        {
            InitializeComponent();
        }

        internal string GetFormErrors()
        {
            var errorArray = new string[]
            {
                errorProvider1.GetError(txtFormNo),
                errorProvider1.GetError(txtFormDescription)
            };

            return Factory.CreateErrors(errorArray).GenerateErrorMessage();
        }

        internal void ResetForm()
        {
            txtFormNo.Clear();
            txtFormDescription.Clear();
            txtFormNo.Focus();
        }

        private bool FormNoValidated()
        {
            string formNumber = txtFormNo.Text.Trim();

            bool formNumberExist;
            if (Helper.ShowErrorTextBoxEmpty(errorProvider1, txtFormNo, "Form No."))
                return false;

            if (!isEdit)
                formNumberExist = TreasuryFactory.AccountableFormsRepository().CodeExist(formNumber);
            else
                formNumberExist = TreasuryFactory.AccountableFormsRepository().CodeExist(formNumber, accountableFormId);

            if (formNumberExist)
            {
                errorProvider1.SetError(txtFormNo, "Accountable Form Number already exist in your records.");
                return !formNumberExist;
            }
            return true;
        }

        private void txtformno_Validating(object sender, CancelEventArgs e)
        {
            e.Cancel = !FormNoValidated();
        }

        private void txtformno_Validated(object sender, EventArgs e)
        {
            Helper.ClearErrorTextBox(errorProvider1, txtFormNo);
        }

        private void txtformdesc_Validating(object sender, CancelEventArgs e)
        {
            e.Cancel = Helper.ShowErrorTextBoxEmpty(errorProvider1, txtFormDescription, "Form Description.");
        }

        private void txtformdesc_Validated(object sender, EventArgs e)
        {
            Helper.ClearErrorTextBox(errorProvider1, txtFormDescription);
        }
    }
}