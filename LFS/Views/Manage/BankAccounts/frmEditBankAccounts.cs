using ACC.Data;
using LFS.Helpers;
using System;
using System.Windows.Forms;

namespace LFS.Views.Manage.BankAccounts
{
    public partial class frmEditBankAccounts : Form
    {
        private int bankAccId;
        private readonly frmBankAccounts frmBankAccounts;
        private readonly ucBankAccounts uc;

        public frmEditBankAccounts(frmBankAccounts frmBankAccounts, int bankAccId)
        {
            InitializeComponent();
            Helper.LoadFormIcon(this);
            this.frmBankAccounts = frmBankAccounts;
            this.bankAccId = bankAccId;
            uc = ucBankAccounts1;
        }

        private void frmEditBankAccounts_Load(object sender, EventArgs e)
        {
            try
            {
                uc.OnLoad(true, bankAccId);
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

            var bankAccModel = uc.BankAccountsModel();
            bankAccModel.Id = bankAccId;

            return AccFactory.BankAccountsRepository().Update(bankAccModel);
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                if (UpdateData())
                {
                    Helper.MessageBoxSuccess("Bank account has been updated.");
                    frmBankAccounts.LoadRecords();
                    Close();
                }
            }
            catch (Exception ex) { Helper.MessageBoxError(ex.Message); }
        }

        private void frmEditBankAccounts_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.S && e.Control)
                {
                    if (UpdateData())
                    {
                        Helper.MessageBoxSuccess("Bank account has been updated.");
                        frmBankAccounts.LoadRecords();
                        Close();
                    }
                }
            }
            catch (Exception ex) { Helper.MessageBoxError(ex.Message); }
        }
    }
}