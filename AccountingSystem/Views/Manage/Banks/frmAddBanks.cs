using ACC.Domain.Models;
using DocumentFormat.OpenXml.Office.Word;
using System;
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
            LoadBanks();
        }

        private void LoadBanks()
        {
        }

        private bool SaveData()
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

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                if (SaveData())
                {
                    Helper.MessageBoxSuccess("Bank has been saved.");
                    _frmBanks.LoadRecords();
                    ucBanks1.ResetForm();
                }
            }
            catch (Exception ex) { Helper.MessageBoxError(ex.Message); }
        }
    }
}