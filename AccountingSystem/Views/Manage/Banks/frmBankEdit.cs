using ACC.Domain.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AccountingSystem.Views.Manage.Banks
{
    public partial class frmBankEdit : Form
    {

        private frmBanks _frmbanks;
        public frmBankEdit(frmBanks frmbanks,int bankId)
        {
            InitializeComponent();
            _frmbanks = frmbanks;
            ucBanks1.bankId = bankId;
        }
        private void LoadSelectedRecord()
        { 
            try
            {
                var uc = ucBanks1;
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
                var uc = ucBanks1;
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
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            
        }
    }
}
