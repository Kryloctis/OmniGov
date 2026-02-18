using OmniGov.App.Helpers;
using OmniGov.Core.Factories;
using System;
using System.Windows.Forms;

namespace OmniGov.App.Views.Manage.Funds
{
    public partial class frmFundEdit : Form
    {
        private frmFunds frmFunds;
        private int fundId;
        private ucFunds uc;

        public frmFundEdit(frmFunds frmFunds, int fundId)
        {
            InitializeComponent();
            Helper.LoadFormIcon(this);

            this.frmFunds = frmFunds;
            this.fundId = fundId;
            uc = ucFunds1;
        }

        private bool SaveData()
        {
            if (!uc.ValidateChildren())
            {
                Helper.MessageBoxError(uc.GetFormErrors());
                return false;
            }

            var fundModel = uc.FundsModel();
            fundModel.Id = fundId;

            return Factory.FundsRepository().Update(fundModel);
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                if (SaveData())
                {
                    Helper.MessageBoxSuccess("Fund has been updated.");
                    frmFunds.LoadRecords();
                    Close();
                }
            }
            catch (Exception ex) { Helper.MessageBoxError(ex.Message); }
        }

        private void frmFundEdit_Load(object sender, EventArgs e)
        {
            try
            {
                uc.OnLoad(true, fundId);
            }
            catch (Exception ex) { Helper.MessageBoxError(ex.Message); }
        }

        private void frmFundEdit_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.S && e.Control)
                {
                    if (SaveData())
                    {
                        Helper.MessageBoxSuccess("Fund has been updated.");
                        frmFunds.LoadRecords();
                        Close();
                    }
                }
            }
            catch (Exception ex) { Helper.MessageBoxError(ex.Message); }
        }
    }
}

