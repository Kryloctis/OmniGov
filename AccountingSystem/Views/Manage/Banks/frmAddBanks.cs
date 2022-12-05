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
    public partial class frmAddBanks : Form
    {
        private readonly frmBanks _frmBanks;
        private readonly ucBanks _ucBanks;

        public frmAddBanks(frmBanks frmBanks)
        {
            InitializeComponent();
            _frmBanks = frmBanks;
            _ucBanks = ucBanks1;
        }

        private void frmBankAdd_Load(object sender, EventArgs e)
        {
            
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

                return AccFactory.BanksRepository().Insert(banksModel);
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
                Helper.MessageBoxSuccess("Bank has been saved.");
                _frmBanks.LoadRecords();
                ucBanks1.ResetForm();
            }
        }

    }
}
