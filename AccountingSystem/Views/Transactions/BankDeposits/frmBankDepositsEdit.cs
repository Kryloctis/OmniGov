using ACC.Data;
using ACC.Domain.Models;
using System;
using System.Windows.Forms;

namespace AccountingSystem.Views.Transactions.BankDeposits
{
    public partial class frmBankDepositsEdit : Form
    {
        private frmBankDeposits frmBankDeposits;
        private int bankDepositId;
        private readonly ucBankDeposits uc;

        public frmBankDepositsEdit(frmBankDeposits frmBankDeposits, int bankDepositId)
        {
            InitializeComponent();
            this.frmBankDeposits = frmBankDeposits;
            this.bankDepositId = bankDepositId;
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
            var bdData = bdRepository.GetRecordByID(bankDepositId);

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
                Id = bankDepositId,
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
                    frmBankDeposits.LoadRecords();
                    Close();
                }
            }
            catch (Exception ex) { Helper.MessageBoxError(ex.Message); }
        }

        private void frmBankDepositsEdit_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.S && e.Control)
                {
                    if (SaveData())
                    {
                        Helper.MessageBoxSuccess("Bank deposit has been updated.");
                        frmBankDeposits.LoadRecords();
                        Close();
                    }
                }
            }
            catch (Exception ex) { Helper.MessageBoxError(ex.Message); }
        }
    }
}