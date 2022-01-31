using ACC.Domain.Models;
using System;
using System.Windows.Forms;

namespace AccountingSystem.Views.Manage.Banks
{
    public partial class frmBankEdit : Form
    {

        private frmBanks _frmbanks;
        private readonly ucBanks uc;

        public frmBankEdit(frmBanks frmbanks, int bankId)
        {
            InitializeComponent();
            _frmbanks = frmbanks;
            ucBanks1.bankId = bankId;
        }
        private void LoadSelectedRecord()
        { 
            try
            {
                var banksRepository = Factory.BanksRepository();
                var bankData = banksRepository.GetRecordByID(uc.bankId);
                uc.txtacode.Text = bankData["account_no"];
                uc.txtbankname.Text = bankData["bank_name"];


            }
            catch (Exception ex) { Helper.MessageBoxError(ex.Message); }
        }
        private void frmBankEdit_Load(object sender, EventArgs e)
        {            
            LoadSelectedRecord();
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

                var banksModel = new BanksModel()
                {
                    Id = uc.bankId,
                    AccountNo = uc.txtacode.Text.Trim(),
                    BankName = uc.txtbankname.Text.Trim()

                };

                var banksrepository = Factory.BanksRepository();
                if (!banksrepository.CodeExist(uc.txtacode.Text.Trim()))
                {
                    return banksrepository.Update(banksModel);
                }
                else
                {
                    Helper.ErrorMessage("Account Number already exists!");
                    uc.txtacode.Focus();
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
                Helper.MessageBoxSuccess("Account has been updated.");
                _frmbanks.LoadRecords();
            }
        }
    }
}
