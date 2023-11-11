using ACC.Domain.Models;
using System;
using System.Windows.Forms;

namespace AccountingSystem.Views.Manage.Banks
{
    public partial class frmEditBank : Form
    {
        private readonly frmBanks frmBanks;
        private readonly ucBanks uc;

        public frmEditBank(frmBanks frmBanks, int bankId)
        {
            InitializeComponent();
            Helper.LoadFormIcon(this);
            this.frmBanks = frmBanks;
            uc = ucBanks1;
            uc.bankId = bankId;
        }

        private void LoadSelectedRecord()
        {
            var dictBank = AccFactory.BanksRepository().GetRecordByID(uc.bankId);
            uc.txtBankCode.Text = dictBank["bank_code"];
            uc.txtBankName.Text = dictBank["bank_name"];
            uc.txtBankBranch.Text = dictBank["bank_branch"];
        }

        private void frmBankEdit_Load(object sender, EventArgs e)
        {
            try
            {
                LoadSelectedRecord();
            }
            catch (Exception ex) { Helper.MessageBoxError(ex.Message); }
        }

        private bool UpdateData()
        {
            if (!uc.ValidateChildren())
            {
                Helper.MessageBoxError(uc.GetFormErrors());
                return false;
            }

            BanksModel banksModel = new BanksModel()
            {
                Id = uc.bankId,
                BankCode = uc.txtBankCode.Text.Trim(),
                BankName = uc.txtBankName.Text.Trim(),
                BankBranch = uc.txtBankBranch.Text.Trim(),
            };

            return AccFactory.BanksRepository().Update(banksModel);
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            try
            {
                if (UpdateData())
                {
                    Helper.MessageBoxSuccess("Bank has been updated.");
                    frmBanks.LoadRecords();
                    uc.ResetForm();
                    Close();
                }
            }
            catch (Exception ex) { Helper.MessageBoxError(ex.Message); }
        }
    }
}