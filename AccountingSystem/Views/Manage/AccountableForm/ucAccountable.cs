using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
            errorArray[0] = errorProvider.GetError(txtformno);
            errorArray[1] = errorProvider.GetError(txtformdesc);

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
            e.Cancel = Helper.ShowErrorTextBoxEmpty(errorProvider, txtformno, "Form No.!");
            var banksrepository = Factory.AccountableRepository();
            string formno = txtformno.Text.Trim();
            bool formNoexist;

            if (accId == 0)
                formNoexist = banksrepository.CodeExist(formno);
            else
                formNoexist = banksrepository.CodeExist(formno, accId);
            if (formNoexist)
            {
                errorProvider.SetError(txtformno, "Accountable Form Number already exist in your records!");
                e.Cancel = true;
            }
        }

        private void txtformno_Validated(object sender, EventArgs e)
        {
            Helper.ClearErrorTextBox(errorProvider, txtformno);
        }

        private void txtformdesc_Validating(object sender, CancelEventArgs e)
        {
            e.Cancel = Helper.ShowErrorTextBoxEmpty(errorProvider, txtformdesc, "Form Description!");
        }

        private void txtformdesc_Validated(object sender, EventArgs e)
        {
            Helper.ClearErrorTextBox(errorProvider, txtformdesc);
        }
    }
}
