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
            var errorArray = new string[]
            {
                errorProvider1.GetError(txtAccountNo)
            };

            IError error = AccFactory.CreateErrors(errorArray);
            return error.GenerateErrorMessage();
        }


        private void ucBankAccounts_Load(object sender, EventArgs e)
        {
            LoadBanks();
        }

        private void LoadBanks()
        {
            var dtBanks = AccFactory.BanksRepository().GetRecords();
            cmbxBank.DataSource = dtBanks;
            cmbxBank.ValueMember = "id";
            cmbxBank.DisplayMember = "bank_name";

        }
    }
}
