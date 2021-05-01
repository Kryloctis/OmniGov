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
    public partial class frmBankAdd : Form
    {
        private frmBanks _frmBanks;
        public frmBankAdd(frmBanks frmBanks)
        {
            InitializeComponent();
            _frmBanks = frmBanks;
        }

        private void frmBankAdd_Load(object sender, EventArgs e)
        {
            
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
                    AccountNo = uc.txtacode.Text.Trim(),
                    BankName = uc.txtbankname.Text.Trim()

                };

                var banksrepository = Factory.BanksRepository();
                return banksrepository.Insert(banksModel);
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
                Helper.MessageBoxSuccess("Account has been saved.");
                _frmBanks.LoadRecords();
                ucBanks1.ResetForm();
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
           
        }
    }
}
