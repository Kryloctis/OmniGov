using ACC.Data;
using ACC.Domain.Models;
using System;
using System.Windows.Forms;

namespace AccountingSystem.Views.Transactions.BankDeposits
{
    public partial class frmBankDepositsAdd : Form
    {
        private frmBankDeposits _frmBankDeposits;
        private ucBankDeposits uc;
        public int generalCollectionId = 0;
        public decimal generalCollectionAmount = 0;
        internal string _referenceNumber;
        internal decimal _amount;

        public frmBankDepositsAdd(frmBankDeposits frmBankDeposits, int rcdId, string referenceNumber, decimal amount)
        {
            InitializeComponent();
            generalCollectionId = rcdId;
            _frmBankDeposits = frmBankDeposits;
            _referenceNumber = referenceNumber;
            _amount = amount;

            uc = ucBankDeposit1;
            uc.userid = Helper.UserId;
        }

        private void frmBankDepositsAdd_Load(object sender, EventArgs e)
        {
            if (generalCollectionId > 0)
                uc.nudAmount.Value = generalCollectionAmount;

            uc.txtReferenceNumber.Text = _referenceNumber;
            uc.nudAmount.Value = _amount;
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
                    if (generalCollectionId > 0)
                    {
                        Helper.MessageBoxSuccess("General Collection Deposits has been saved.");
                        this.DialogResult = DialogResult.OK;
                        this.Close();
                    }
                    else
                    {
                        Helper.MessageBoxSuccess("Bank Deposit has been saved.");
                        _frmBankDeposits.LoadRecords();
                        ucBankDeposit1.ResetForm();
                    }
                }
            }
            catch (Exception ex) { Helper.MessageBoxError(ex.Message); }
        }
    }
}