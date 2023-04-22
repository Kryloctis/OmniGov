using ACC.Domain.Models;
using DocumentFormat.OpenXml.Office.Word;
using System;
using System.Windows.Forms;

namespace AccountingSystem.Views.Manage.Banks
{
    public partial class frmAddBanks : Form
    {
        private readonly frmBanks frmBanks;
        private readonly ucBanks uc;

        public frmAddBanks(frmBanks frmBanks)
        {
            InitializeComponent();
            Helper.LoadFormIcon(this);
            this.frmBanks = frmBanks;
            uc = ucBanks1;
        }

        private bool SaveData()
        {
            if (!uc.ValidateChildren())
            {
                Helper.MessageBoxError(uc.GetFormErrors());
                return false;
            }

            BanksModel banksModel = new BanksModel()
            {
                BankCode = uc.txtBankCode.Text.Trim(),
                BankName = uc.txtBankName.Text.Trim(),
                BankBranch = uc.txtBankBranch.Text.Trim(),
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
                    frmBanks.LoadRecords();
                    ucBanks1.ResetForm();
                }
            }
            catch (Exception ex) { Helper.MessageBoxError(ex.Message); }
        }
    }
}