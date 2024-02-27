using ACC.Data;
using ACC.Domain.Models;
using System;
using System.Windows.Forms;

namespace AccountingSystem.Views.Transactions.BankDeposits
{
    public partial class frmBankDepositsAdd : Form
    {
        private frmBankDeposits frmBankDeposits;
        private ucBankDeposits uc;
        private int rcdId;
        private decimal generalCollectionAmount;
        private string referenceNumber;
        private decimal amount;

        public frmBankDepositsAdd(frmBankDeposits frmBankDeposits, int rcdId, string referenceNumber, decimal amount)
        {
            InitializeComponent();
            this.rcdId = rcdId;
            this.frmBankDeposits = frmBankDeposits;
            this.referenceNumber = referenceNumber;
            this.amount = amount;
            uc = ucBankDeposit1;
            uc.userid = Helper.userId;
        }

        private void frmBankDepositsAdd_Load(object sender, EventArgs e)
        {
            try
            {
                if (rcdId > 0)
                    uc.nudAmount.Value = generalCollectionAmount;

                uc.txtReferenceNumber.Text = referenceNumber;
                uc.nudAmount.Value = amount;
            }
            catch (Exception ex) { Helper.MessageBoxError(ex.Message); }
        }

        private bool SaveData()
        {
            if (!uc.ValidateChildren())
            {
                Helper.MessageBoxError(uc.GetFormErrors());
                return false;
            }

            var bankDepositModel = new BankDepositsModel()
            {
                BankID = Convert.ToInt32(uc.cmbBank.SelectedValue),
                BankAccountsID = Convert.ToInt32(uc.cmbBankAccounts.SelectedValue),
                fundId = Convert.ToInt32(uc.cmbFund.SelectedValue),
                Reference = uc.txtReferenceNumber.Text.Trim(),
                Date = Convert.ToDateTime(uc.dtDate.Text.Trim()),
                Amount = Convert.ToDecimal(uc.nudAmount.Value),
                CreatedBy = uc.userid,
            };

            return AccFactory.BankDepositsRepository().Insert(bankDepositModel);
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                if (SaveData())
                {
                    if (rcdId > 0)
                    {
                        Helper.MessageBoxSuccess("General Collection Deposits has been saved.");
                        this.DialogResult = DialogResult.OK;
                        this.Close();
                    }
                    else
                    {
                        Helper.MessageBoxSuccess("Bank Deposit has been saved.");
                        frmBankDeposits.LoadRecords();
                        ucBankDeposit1.ResetForm();
                    }
                }
            }
            catch (Exception ex) { Helper.MessageBoxError(ex.Message); }
        }

        private void frmBankDepositsAdd_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.S && e.Control)
                {
                    if (SaveData())
                    {
                        Helper.MessageBoxSuccess("Bank deposit has been saved.");
                        frmBankDeposits.LoadRecords();
                        uc.ResetForm();
                    }
                }
            }
            catch (Exception ex) { Helper.MessageBoxError(ex.Message); }
        }
    }
}