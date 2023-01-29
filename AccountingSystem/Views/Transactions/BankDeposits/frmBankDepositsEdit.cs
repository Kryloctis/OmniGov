using ACC.Domain.Models;
using System;
using System.Windows.Forms;

namespace AccountingSystem.Views.Transactions.BankDeposits
{
    public partial class frmBankDepositsEdit : Form
    {
        private frmBankDeposits _frmBankDeposits;
        private int _bankDepositID;
        private readonly ucBankDeposits _ucBankDeposits;


        public frmBankDepositsEdit(frmBankDeposits frmBankDeposits, int bankDepositID)
        {
            InitializeComponent();
            _frmBankDeposits = frmBankDeposits;
            _bankDepositID = bankDepositID;

            _ucBankDeposits = ucBankDeposit1;
            _ucBankDeposits.userid = Helper.UserId;
        }

        private void frmBankDepositsEdit_Load(object sender, EventArgs e)
        {
            LoadSelectedValue();
        }

        private void LoadSelectedValue()
        {
            try
            {
                var bdRepository = AccFactory.BankDepositsRepository();
                var bdData = bdRepository.GetRecordByID(_bankDepositID);

                _ucBankDeposits.cmbBank.SelectedValue = bdData["banks_id"];
                _ucBankDeposits.cmbFund.SelectedValue = bdData["funds_id"];
                _ucBankDeposits.txtReferenceNumber.Text = bdData["reference"];
                _ucBankDeposits.dtDate.Value = Convert.ToDateTime(bdData["date"]);
                _ucBankDeposits.nudAmount.Value = Convert.ToDecimal(bdData["amount"]);
            }
            catch (Exception ex) { Helper.MessageBoxError(ex.Message); }
        }

        private bool SaveData()
        {
            var uc = ucBankDeposit1;
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

            var bdrepository = AccFactory.BankDepositsRepository();
            return bdrepository.Update(bankDepositModel);
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (SaveData())
            {
                Helper.MessageBoxSuccess("Bank Deposit has been updated.");
                _frmBankDeposits.LoadRecords();
            }
        }
    }
}