using OmniGov.App.Helpers;
using OmniGov.Treasury.Data.Factories;

namespace OmniGov.App.Views.Manage.Banks
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

            return TreasuryFactory.BanksRepository().Insert(uc.BanksModel());
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (SaveData())
            {
                Helper.MessageBoxSuccess("Bank has been saved.");
                frmBanks.LoadRecords();
                ucBanks1.ResetForm();
            }
        }

        private void frmAddBanks_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.S && e.Control)
            {
                if (SaveData())
                {
                    Helper.MessageBoxSuccess("Bank has been saved.");
                    frmBanks.LoadRecords();
                    ucBanks1.ResetForm();
                }
            }
        }

        private void frmAddBanks_Load(object sender, EventArgs e)
        {
            uc.OnLoad(false, null);
        }
    }
}