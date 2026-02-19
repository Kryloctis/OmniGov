using OmniGov.App.Helpers;
using OmniGov.Core.Factories;

namespace OmniGov.App.Views.Manage.Funds
{
    public partial class frmFundAdd : Form
    {
        private frmFunds frmFunds;
        private ucFunds uc;

        public frmFundAdd(frmFunds frmFunds)
        {
            InitializeComponent();
            Helper.LoadFormIcon(this);
            uc = ucFunds1;
            this.frmFunds = frmFunds;
        }

        private bool SaveData()
        {
            if (!uc.ValidateChildren())
            {
                Helper.MessageBoxError(uc.GetFormErrors());
                return false;
            }

            return Factory.FundsRepository().Insert(uc.FundsModel());
        }

        private void frmFundAdd_Load(object sender, EventArgs e)
        {
            try
            {
                uc.OnLoad(false, null);
            }
            catch (Exception ex) { Helper.MessageBoxError(ex.Message); }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                if (SaveData())
                {
                    Helper.MessageBoxSuccess("Fund has been saved.");
                    frmFunds.LoadRecords();
                    uc.ResetForm();
                }
            }
            catch (Exception ex) { Helper.MessageBoxError(ex.Message); }
        }

        private void frmFundAdd_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (SaveData())
                {
                    Helper.MessageBoxSuccess("Fund has been saved.");
                    frmFunds.LoadRecords();
                    uc.ResetForm();
                }
            }
            catch (Exception ex) { Helper.MessageBoxError(ex.Message); }
        }
    }
}

