using ACC.Domain.Models;
using System;
using System.Windows.Forms;

namespace AccountingSystem.Views.Transactions.BankDeposits
{
    public partial class frmBankDepositsEdit : Form
    {
        private frmBankDeposits _frmbd;
        public frmBankDepositsEdit(frmBankDeposits frmbd,int Id)
        {
            InitializeComponent();
            _frmbd = frmbd;
            ucbd1.Id = Id;
            ucbd1.userid = Helper.UserId;
        }

        private void frmBankDepositsEdit_Load(object sender, EventArgs e)
        {
            ucbd1.LoadBanks();
            LoadSelectedValue();
        }
        private void LoadSelectedValue()
        {
            try
            {
                var uc = ucbd1;
                var bdRepository = Factory.BankDepositsRepository();
                var bdData = bdRepository.GetRecordByID(uc.Id);
                uc.cmbbanks.SelectedValue = bdData["banks_id"];
                uc.txtreference.Text = bdData["reference"];
                uc.dtdate.Value = Convert.ToDateTime(bdData["date"]);
                uc.txtamount.Value = Convert.ToDecimal(bdData["amount"]);
            }
            catch (Exception ex) { Helper.MessageBoxError(ex.Message); }
        }
        private bool SaveData()
        {
            try
            {
                var uc = ucbd1;
                if (!uc.ValidateChildren())
                {
                    Helper.MessageBoxError(uc.GetFormErrors());
                    return false;
                }

                var bdModel = new BankDepositsModel()
                {
                    Id = uc.Id,
                    bankId = Convert.ToInt16(uc.cmbbanks.SelectedValue),
                    Reference = uc.txtreference.Text.Trim(),
                    Date = Convert.ToDateTime(uc.dtdate.Text.Trim()),
                    Amount = Convert.ToDecimal(uc.txtamount.Value),
                    UpdatedBy = uc.userid,
                };

                var bdrepository = Factory.BankDepositsRepository();
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
