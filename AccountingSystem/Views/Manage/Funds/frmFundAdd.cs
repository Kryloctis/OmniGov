using ACC.Data;
using ACC.Domain.Models;
using System;
using System.Windows.Forms;

namespace AccountingSystem.Views.Manage.Funds
{
    public partial class frmFundAdd : Form
    {
        private frmFunds _frmFunds;
        private ucFunds uc;

        public frmFundAdd(frmFunds frmFunds)
        {
            InitializeComponent();
            uc = ucFunds1;
            _frmFunds = frmFunds;
        }

        private bool SaveData()
        {
            // if error occurs, show messagebox error
            if (!uc.ValidateChildren())
            {
                Helper.MessageBoxError(uc.GetFormErrors());
                return false;
            }

            // proceed to insert
            var fundModel = new FundsModel()
            {
                FundCode = uc.txtCode.Text.Trim(),
                FundName = uc.txtName.Text.Trim()
            };

            return AccFactory.FundsRepository().Insert(fundModel);
        }

        private void frmFundAdd_Load(object sender, EventArgs e)
        {
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                if (SaveData())
                {
                    Helper.MessageBoxSuccess("Fund has been saved.");
                    _frmFunds.LoadRecords();
                    uc.ResetForm();
                }
            }
            catch (Exception ex) { Helper.MessageBoxError(ex.Message); }
        }
    }
}