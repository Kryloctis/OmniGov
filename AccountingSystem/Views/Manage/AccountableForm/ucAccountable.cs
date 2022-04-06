using System;
using System.ComponentModel;
using System.Windows.Forms;
using ACC.Domain.Interfaces;

namespace AccountingSystem.Views.Manage.AccountableForm
{
    public partial class ucAccountable : UserControl
    {
        internal int accId = 0;
        public ucAccountable()
        {
            InitializeComponent();
        }
        internal string GetFormErrors()
        {
            var errorArray = new string[2];
            errorArray[0] = epFormNo.GetError(txtformno);
            errorArray[1] = epFormDescription.GetError(txtformdesc);

            IError _errors = Factory.CreateErrors(errorArray);
            return _errors.GenerateErrorMessage();
        }
        internal void ResetForm()
        {
            txtformno.Clear();
            txtformdesc.Clear();
            txtformno.Focus();
        }

        private void txtformno_Validating(object sender, CancelEventArgs e)
        {
            e.Cancel = Helper.ShowErrorTextBoxEmpty(epFormNo, txtformno, "Form No.");

            var accountableFormRepository = Factory.AccountableFormsRepository();
            string formNumber = txtformno.Text.Trim();

            bool formNumberExist;

            if (accId == 0)
                formNumberExist = accountableFormRepository.CodeExist(formNumber);
            else
                formNumberExist = accountableFormRepository.CodeExist(formNumber, accId);

            if (formNumberExist)
            {
                epFormNo.SetError(txtformno, "Accountable Form Number already exist in your records.");
                e.Cancel = true;
            }
        }

        private void txtformno_Validated(object sender, EventArgs e)
        {
            Helper.ClearErrorTextBox(epFormNo, txtformno);
        }

        private void txtformdesc_Validating(object sender, CancelEventArgs e)
        {
            e.Cancel = Helper.ShowErrorTextBoxEmpty(epFormDescription, txtformdesc, "Form Description.");
        }

        private void txtformdesc_Validated(object sender, EventArgs e)
        {
            Helper.ClearErrorTextBox(epFormDescription, txtformdesc);
        }
    }
}
