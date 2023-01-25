using ACC.Domain.Models;
using System;
using System.Windows.Forms;

namespace AccountingSystem.Views.Transactions.BankDeposits
{
    public partial class frmBankDepositsEdit : Form
    {
        private frmBankDeposits _frmbd;

        public frmBankDepositsEdit(frmBankDeposits frmbd, int Id)
        {
            InitializeComponent();
            _frmbd = frmbd;
            ucBankDeposit1.Id = Id;
            ucBankDeposit1.userid = Helper.UserId;
        }

        private void frmBankDepositsEdit_Load(object sender, EventArgs e)
        {
            LoadSelectedValue();
        }

        private void LoadSelectedValue()
        {
            try
            {
                var uc = ucBankDeposit1;
                var bdRepository = AccFactory.BankDepositsRepository();
                var bdData = bdRepository.GetRecordByID(uc.Id);
                uc.cmbBank.SelectedValue = bdData["banks_id"];
                uc.cmbFund.SelectedValue = bdData["funds_id"];
                uc.txtReferenceNumber.Text = bdData["reference"];
                uc.dtDate.Value = Convert.ToDateTime(bdData["date"]);
                uc.nudAmount.Value = Convert.ToDecimal(bdData["amount"]);
            }
            catch (Exception ex) { Helper.MessageBoxError(ex.Message); }
        }

        private bool SaveData()
        {
            try
            {
                var uc = ucBankDeposit1;
                if (!uc.ValidateChildren())
                {
                    Helper.MessageBoxError(uc.GetFormErrors());
                    return false;
                }

                var bdModel = new BankDepositsModel()
                {
                    Id = uc.Id,
                    BankID = Convert.ToInt16(uc.cmbBank.SelectedValue),
                    fundId = Convert.ToInt16(uc.cmbFund.SelectedValue),
                    Reference = uc.txtReferenceNumber.Text.Trim(),
                    Date = Convert.ToDateTime(uc.dtDate.Text.Trim()),
                    Amount = Convert.ToDecimal(uc.nudAmount.Value),
                    UpdatedBy = uc.userid,
                };

                var bdrepository = AccFactory.BankDepositsRepository();
                return bdrepository.Update(bdModel);
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
                Helper.MessageBoxSuccess("Bank Deposit has been updated.");
                _frmbd.LoadRecords();
            }
        }
    }
}