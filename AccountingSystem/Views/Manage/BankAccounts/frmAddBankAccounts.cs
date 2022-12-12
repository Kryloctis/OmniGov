using ACC.Domain.Models;
using AccountingSystem.Views.Manage.Banks;
using DocumentFormat.OpenXml.Wordprocessing;
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
    public partial class frmAddBankAccounts : Form
    {
        private readonly ucBankAccounts _ucBankAccounts;
        private readonly frmBankAccounts _frmBankAccounts;

        public frmAddBankAccounts(frmBankAccounts frmBankAccounts)
        {
            InitializeComponent();
            _ucBankAccounts = ucBankAccounts1;
            _frmBankAccounts = frmBankAccounts;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (SaveData())
            {
                Helper.MessageBoxSuccess("Account has been saved.");
                _frmBankAccounts.LoadBankAccounts();
                _ucBankAccounts.ResetForm();
            }
        }

        private bool SaveData()
        {
            try
            {
                if (!_ucBankAccounts.ValidateChildren())
                {
                    Helper.MessageBoxError(_ucBankAccounts.GetFormErrors());
                    return false;
                }

                var bankAccountsModel = new BankAccountsModel()
                {
                    BankID = Convert.ToInt32(_ucBankAccounts.cmbxBank.SelectedValue),
                    AccountNumber = _ucBankAccounts.txtAccountNo.Text
                };

                var bankAccountRepository = AccFactory.BankAccountsRepository();
                return bankAccountRepository.Insert(bankAccountsModel);
             
            }
            catch (Exception ex)
            {
                Helper.MessageBoxError(ex.Message);
            }
            return false;
        }

    }
}
