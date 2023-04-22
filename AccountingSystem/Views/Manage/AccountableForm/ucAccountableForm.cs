using ACC.Domain.Interfaces;
using System;
using System.ComponentModel;
using System.Windows.Forms;

namespace AccountingSystem.Views.Manage.AccountableForm
{
    public partial class ucAccountableForm : UserControl
    {
        internal int accountableFormId;
        internal bool isEdit = false;

        public ucAccountableForm()
        {
            InitializeComponent();
        }

        internal string GetFormErrors()
        {
            var errorArray = new string[]
            {
                errorProvider1.GetError(txtformno),
                errorProvider1.GetError(txtformdesc)
            };

            return AccFactory.CreateErrors(errorArray).GenerateErrorMessage();
        }

        internal void ResetForm()
        {
            txtformno.Clear();
            txtformdesc.Clear();
            txtformno.Focus();
        }

        private bool FormNoValidated()
        {
            string formNumber = txtformno.Text.Trim();

            bool formNumberExist;
            if (Helper.ShowErrorTextBoxEmpty(errorProvider1, txtformno, "Form No."))
                return false;

            if (!isEdit)
                formNumberExist = AccFactory.AccountableFormsRepository().CodeExist(formNumber);
            else
                formNumberExist = AccFactory.AccountableFormsRepository().CodeExist(formNumber, accountableFormId);

            if (formNumberExist)
            {
                errorProvider1.SetError(txtformno, "Accountable Form Number already exist in your records.");
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
            Helper.ClearErrorTextBox(errorProvider1, txtformno);
        }

        private void txtformdesc_Validating(object sender, CancelEventArgs e)
        {
            e.Cancel = Helper.ShowErrorTextBoxEmpty(errorProvider1, txtformdesc, "Form Description.");
        }

        private void txtformdesc_Validated(object sender, EventArgs e)
        {
            Helper.ClearErrorTextBox(errorProvider1, txtformdesc);
        }
    }
}