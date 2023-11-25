using ACC.Data;
using ACC.Domain.Models;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace AccountingSystem.Views.Manage.BankAccounts
{
    public partial class frmEditBankAccounts : Form
    {
        private readonly frmBankAccounts frmBankAccounts;
        private int bankAccountID;
        private readonly ucBankAccounts uc;

        public frmEditBankAccounts(frmBankAccounts frmBankAccounts, int bankAccountID)
        {
            InitializeComponent();
            Helper.LoadFormIcon(this);
            this.frmBankAccounts = frmBankAccounts;
            this.bankAccountID = bankAccountID;
            uc = ucBankAccounts1;
            uc.bankAccountID = bankAccountID;
        }

        private void frmEditBankAccounts_Load(object sender, EventArgs e)
        {
            try
            {
                uc.isEdit = true;
                LoadSelectedRecord();
            }
            catch (Exception ex) { Helper.MessageBoxError(ex.Message); }
        }

        private void LoadSelectedRecord()
        {
            Dictionary<string, string> dictBankAccounts = AccFactory.BankAccountsRepository().GetRecordByID(bankAccountID);

            uc.cmbxBank.SelectedValue = dictBankAccounts["banks_id"];
            uc.txtAccountNo.Text = dictBankAccounts["account_no"];
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            try
            {
                if (UpdateData())
                {
                    Helper.MessageBoxSuccess("Bank account has been updated.");
                    frmBankAccounts.LoadBankAccounts();
                    Close();
                }
            }
            catch (Exception ex) { Helper.MessageBoxError(ex.Message); }
        }

        private bool UpdateData()
        {
            if (!uc.ValidateChildren())
            {
                Helper.MessageBoxError(uc.GetFormErrors());
                return false;
            }

            var bankAccountID = this.bankAccountID;
            var bankID = Convert.ToInt32(uc.cmbxBank.SelectedValue);
            var bankAccountNumber = uc.txtAccountNo.Text.Trim();

            var bankAccountsModel = new BankAccountsModel()
            {
                ID = bankAccountID,
                BankID = bankID,
                AccountNumber = bankAccountNumber
            };

            return AccFactory.BankAccountsRepository().Update(bankAccountsModel);
        }
    }
}