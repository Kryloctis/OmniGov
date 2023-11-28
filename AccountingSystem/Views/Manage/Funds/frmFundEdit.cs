using ACC.Data;
using ACC.Domain.Models;
using System;
using System.Windows.Forms;

namespace AccountingSystem.Views.Manage.Funds
{
    public partial class frmFundEdit : Form
    {
        private frmFunds _frmFunds;
        private ucFunds uc;

        public frmFundEdit(frmFunds frmFunds, int fundId)
        {
            InitializeComponent();
            Helper.LoadFormIcon(this);

            _frmFunds = frmFunds;
            uc = ucFunds1;
            uc.fundId = fundId;
        }

        private void LoadSelectedRecord()
        {
            var fundData = AccFactory.FundsRepository().GetRecordByID(uc.fundId);
            uc.txtCode.Text = fundData["fund_code"];
            uc.txtName.Text = fundData["fund_name"];
        }

        private bool SaveData()
        {
            // if error occurs, show messagebox error
            if (!uc.ValidateChildren())
            {
                Helper.MessageBoxError(uc.GetFormErrors());
                return false;
            }

            // proceed to update
            var fundModel = new FundsModel()
            {
                Id = uc.fundId,
                FundCode = uc.txtCode.Text.Trim(),
                FundName = uc.txtName.Text.Trim()
            };

            return AccFactory.FundsRepository().Update(fundModel);
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                if (SaveData())
                {
                    Helper.MessageBoxSuccess("Fund has been saved.");
                    _frmFunds.LoadRecords();
                    Close();
                }
            }
            catch (Exception ex) { Helper.MessageBoxError(ex.Message); }
        }

        private void frmFundEdit_Load(object sender, EventArgs e)
        {
            try
            {
                OnLoad();
            }
            catch (Exception ex) { Helper.MessageBoxError(ex.Message); }
        }

        private void OnLoad()
        {
            LoadSelectedRecord();
        }
    }
}