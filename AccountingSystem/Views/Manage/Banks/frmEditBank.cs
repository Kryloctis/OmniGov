using ACC.Domain.Models;
using System;
using System.Windows.Forms;

namespace AccountingSystem.Views.Manage.Banks
{
    public partial class frmEditBank : Form
    {

        private readonly frmBanks _frmbanks;
        private readonly ucBanks _ucBanks;

        public frmEditBank(frmBanks frmbanks, int bankId)
        {
            InitializeComponent();

            _frmbanks = frmbanks;
            //_ucBanks = ucBanks1;
            _ucBanks.bankId = bankId;
        }
        private void LoadSelectedRecord()
        { 
            try
            {
                var banksRepository = AccFactory.BanksRepository();
                var bankData = banksRepository.GetRecordByID(_ucBanks.bankId);
                _ucBanks.txtBankBranch.Text = bankData["account_no"];
                _ucBanks.txtBankName.Text = bankData["bank_name"];
            }
            catch (Exception ex) 
            {
                Helper.MessageBoxError(ex.Message); 
            }
        }

        private void frmBankEdit_Load(object sender, EventArgs e)
        {            
            LoadSelectedRecord();
        }

        private bool SaveData()
        {
            try
            {
                if (!_ucBanks.ValidateChildren())
                {
                    Helper.MessageBoxError(_ucBanks.GetFormErrors());
                    return false;
                }

                var banksModel = new BanksModel()
                {
                    BankCode = _ucBanks.txtBankCode.Text.Trim(),
                    BankName = _ucBanks.txtBankName.Text.Trim(),
                    BankBranch = _ucBanks.txtBankBranch.Text.Trim(),
                };

                var banksrepository = AccFactory.BanksRepository();
                return banksrepository.Update(banksModel);
              
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
                _ucBanks.ResetForm();
            }
        }
    }
}
