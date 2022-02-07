using System;
using System.Windows.Forms;
using ACC.Domain.Models;

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
            {
                uc.nudAmount.Value = generalCollectionAmount;
                uc.nudAmount.Enabled = false;
            }

            uc.txtReferenceNumber.Text = _referenceNumber;
            uc.nudAmount.Value = _amount;
        }

        private bool SaveData()
        {
            try
            {
                if (!uc.ValidateChildren())
                {
                    Helper.MessageBoxError(uc.GetFormErrors());
                    return false;
                }

                var bankDepositModel = new BankDepositsModel()
                {
                    bankId = Convert.ToInt16(uc.cmbBank.SelectedValue),
                    fundId = Convert.ToInt16(uc.cmbFund.SelectedValue),                     
                    Reference = uc.txtReferenceNumber.Text.Trim(),
                    Date = Convert.ToDateTime(uc.dtDate.Text.Trim()),
                    Amount = Convert.ToDecimal(uc.nudAmount.Value),
                    CreatedBy = uc.userid,
                };

                var bankDepositRepo = Factory.BankDepositsRepository();

                if (generalCollectionId > 0)
                {
                    int insertId = bankDepositRepo.Deposits(bankDepositModel);

                if (insertId > 0)  //IF SUCCESS DAW ANG PAG SAVE SA BANK DEPOSIT
                {
                    var generalCollectionDepositsRepo = Factory.GeneralCollectionsDepositsRepository();
                    var generalCollectionDepositModel = new GeneralCollectionsDepositsModel()
                    {
                        BankDepositId = insertId,
                        GeneralCollectionId = generalCollectionId
                    };

                    if (!generalCollectionDepositsRepo.IdExist(generalCollectionId))
                    {
                        return generalCollectionDepositsRepo.Insert(generalCollectionDepositModel);
                    }
                    else
                    {
                        Helper.MessageBoxSuccess("General Collection has already been deposited!");
                    }
                    }
                }
                else
                {
                    return bankDepositRepo.Insert(bankDepositModel);
                }
            }
            catch (Exception ex)
            {
                Helper.MessageBoxError(ex.Message);
            }
            return false;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (SaveData())
            {
                if(generalCollectionId > 0)
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
    }
}
