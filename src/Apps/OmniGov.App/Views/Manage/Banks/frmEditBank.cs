using OmniGov.App.Helpers;
using OmniGov.Treasury.Data.Factories;

namespace OmniGov.App.Views.Manage.Banks
{
    public partial class frmEditBank : Form
    {
        private int bankId;
        private readonly frmBanks frmBanks;
        private readonly ucBanks uc;

        public frmEditBank(frmBanks frmBanks, int bankId)
        {
            InitializeComponent();
            Helper.LoadFormIcon(this);
            this.frmBanks = frmBanks;
            this.bankId = bankId;
            uc = ucBanks1;
        }

        private void frmBankEdit_Load(object sender, EventArgs e)
        {
            try
            {
                uc.OnLoad(true, bankId);
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

            var banksModel = uc.BanksModel();
            banksModel.Id = bankId;

            return TreasuryFactory.BanksRepository().Update(banksModel);
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

        private void frmEditBank_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.S && e.Control)
                {
                    if (UpdateData())
                    {
                        Helper.MessageBoxSuccess("Bank has been updated.");
                        frmBanks.LoadRecords();
                        uc.ResetForm();
                        Close();
                    }
                }
            }
            catch (Exception ex) { Helper.MessageBoxError(ex.Message); }
        }
    }
}