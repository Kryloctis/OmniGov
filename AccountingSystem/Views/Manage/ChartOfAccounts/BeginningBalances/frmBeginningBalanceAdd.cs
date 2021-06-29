using System;
using System.Linq;
using System.Windows.Forms;
using ACC.Domain.Models;
using AccountingSystem.Views.Manage.ChartOfAccounts;
using AccountingSystem.Views.Manage.ChartOfAccounts.Subsidiary;

namespace AccountingSystem.Views.Manage.BeginningBalances
{
    public partial class frmBeginningBalanceAdd : Form
    {
        private readonly UcBeginningBalances uc;
        frmSubsidiary _frmSubsidiary;

        public frmBeginningBalanceAdd(frmSubsidiary frmSubsidiary,ushort generalLedgerId, ushort subsidiaryLedgerId = 0)
        {
            InitializeComponent();
            _frmSubsidiary = frmSubsidiary;
            uc = ucBeginningBalances1;
            uc.generalLedgerId = generalLedgerId;
            uc.subsidiaryLedgerId = subsidiaryLedgerId;
        }

        private bool SaveData()
        {
            try
            {
                if (!uc.ValidateChildren())
                {
                    Helper.MessageBoxError(uc.GetFormErrors());
                    return false;
                }

                ushort subsidiaryId = uc.subsidiaryLedgerId;
                var beginningBalanceModel = new BeginningBalancesModel()
                {
                    FundsId = uc.fundId,
                    GeneralLedgerId = uc.generalLedgerId,
                    SubsidiaryLedgerId = subsidiaryId != 0 ? subsidiaryId : null,
                    IsDebit = uc.radioDebit.Checked,
                    DateEntry = uc.dtpDateEntry.Value,
                    Amount = uc.nudAmount.Value
                };

                return Factory.BeginningBalancesRepository().Insert(beginningBalanceModel);
            }
            catch (Exception ex)
            {
                Helper.MessageBoxError(ex.Message);
            }

            return false;
        }

        private void CheckedFund()
        {
            if (uc.subsidiaryLedgerId != 0)
            {
                var subsidiaryDict = Factory.SubsidiaryLedgerAccountsRepository().GetRecordByID(uc.subsidiaryLedgerId);
                byte fundId = Convert.ToByte(subsidiaryDict["funds_id"]);
                uc.fundId = fundId;
                var fundDict = Factory.FundsRepository().GetRecordByID(fundId);

                _ = ucBeginningBalances1.flowLayoutPanelFunds.Controls.OfType<RadioButton>().FirstOrDefault(
                    r => (r.Text == fundDict["fund_name"]) ? r.Checked = true : r.Checked = false);

                uc.flowLayoutPanelFunds.Enabled = false;
            }
        }

        private void frmBeginningBalanceAdd_Load(object sender, EventArgs e)
        {
            Helper.LoadFormIcon(this);
            uc.LoadFunds();
            uc.LoadSelectedGeneralLedger();
            uc.LoadSelectedSubsidiaryAccount();
            uc.radioDebit.Checked = true;

            CheckedFund();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (SaveData())
            {
                Helper.MessageBoxSuccess("Beginning balance has been saved.");

                if(_frmSubsidiary != null) _frmSubsidiary.LoadSubsidiaryRecordsByFundAndGeneralLedger();

                uc.ResetForm();
            }
        }
    }
}
