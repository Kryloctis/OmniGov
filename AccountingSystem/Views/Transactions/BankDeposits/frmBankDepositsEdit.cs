using ACC.Data;
using ACC.Domain.Models;
using System;
using System.Windows.Forms;

namespace AccountingSystem.Views.Transactions.BankDeposits
{
    public partial class frmBankDepositsEdit : Form
    {
        private frmBankDeposits _frmBankDeposits;
        private int _bankDepositID;
        private readonly ucBankDeposits uc;

        public frmBankDepositsEdit(frmBankDeposits frmBankDeposits, int bankDepositID)
        {
            InitializeComponent();
            _frmBankDeposits = frmBankDeposits;
            _bankDepositID = bankDepositID;

            uc = ucBankDeposit1;
            uc.userid = Helper.userId;
        }

        private void OnLoad()
        {
            LoadSelectedValue();
        }

        private void frmBankDepositsEdit_Load(object sender, EventArgs e)
        {
            try
            {
                OnLoad();
            }
            catch (Exception ex) { Helper.MessageBoxError(ex.Message); }
        }

        private void LoadSelectedValue()
        {
            var bdRepository = AccFactory.BankDepositsRepository();
            var bdData = bdRepository.GetRecordByID(_bankDepositID);

            uc.cmbBank.SelectedValue = bdData["banks_id"];
            uc.cmbFund.SelectedValue = bdData["funds_id"];
            uc.txtReferenceNumber.Text = bdData["reference"];
            uc.dtDate.Value = Convert.ToDateTime(bdData["date"]);
            uc.nudAmount.Value = Convert.ToDecimal(bdData["amount"]);
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
                Id = _bankDepositID,
                BankAccountsID = Convert.ToInt16(uc.cmbBankAccounts.SelectedValue),
                fundId = Convert.ToInt16(uc.cmbFund.SelectedValue),
                Reference = uc.txtReferenceNumber.Text.Trim(),
                Date = Convert.ToDateTime(uc.dtDate.Text.Trim()),
                Amount = Convert.ToDecimal(uc.nudAmount.Value),
                UpdatedBy = uc.userid,
            };

            return AccFactory.BankDepositsRepository().Update(bankDepositModel);
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                if (SaveData())
                {
                    Helper.MessageBoxSuccess("Bank Deposit has been updated.");
                    _frmBankDeposits.LoadRecords();
                }
            }
            catch (Exception ex) { Helper.MessageBoxError(ex.Message); }
        }
    }
}