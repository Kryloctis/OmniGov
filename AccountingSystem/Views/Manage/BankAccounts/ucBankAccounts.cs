using ACC.Domain.Interfaces;
using Org.BouncyCastle.Utilities.Collections;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AccountingSystem.Views.Manage.BankAccounts
{
    public partial class ucBankAccounts : UserControl
    {
        internal int bankAccountID;

        public ucBankAccounts()
        {
            InitializeComponent();
        }

        internal void ResetForm()
        {
            txtAccountNo.Clear();
        }

        internal string GetFormErrors()
        {
            var errorArray = new string[2]
            {
                errorProvider1.GetError(cmbxBank),
                errorProvider1.GetError(txtAccountNo)
            };

            IError error = AccFactory.CreateErrors(errorArray);
            return error.GenerateErrorMessage();
        }


        private void ucBankAccounts_Load(object sender, EventArgs e)
        {
            if (!DesignMode)
            {
                LoadBanks();
            }
        }

        private void LoadBanks()
        {
            var dtBanks = AccFactory.BanksRepository().GetRecords();
            cmbxBank.DataSource = dtBanks;
            cmbxBank.ValueMember = "id";
            cmbxBank.DisplayMember = "bank_name";

        }

        private void txtAccountNo_Validating(object sender, CancelEventArgs e)
        {
            e.Cancel = Helper.ShowErrorTextBoxEmpty(errorProvider1, txtAccountNo, "Account Number");
        }

        private void txtAccountNo_Validated(object sender, EventArgs e)
        {
            Helper.ClearErrorTextBox(errorProvider1, txtAccountNo);
        }

        private void cmbxBank_Validating(object sender, CancelEventArgs e)
        {

        }

        private void cmbxBank_Validated(object sender, EventArgs e)
        {

        }
    }
}
