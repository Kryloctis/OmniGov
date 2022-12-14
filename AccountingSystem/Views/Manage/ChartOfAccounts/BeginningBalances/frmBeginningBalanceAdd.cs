using ACC.Domain.Models;
using AccountingSystem.Views.Manage.ChartOfAccounts;
using AccountingSystem.Views.Manage.ChartOfAccounts.Subsidiary;
using System;
using System.Windows.Forms;

namespace AccountingSystem.Views.Manage.BeginningBalances
{
    public partial class frmBeginningBalanceAdd : Form
    {
        private readonly UcBeginningBalances uc;
        private frmSubsidiary _frmSubsidiary;
        private frmChartOfAccounts _frmChartOfAccounts;

        public frmBeginningBalanceAdd(frmChartOfAccounts frmChartOfAccounts, frmSubsidiary frmSubsidiary, byte fundId, ushort generalLedgerId, short year, ushort subsidiaryLedgerId = 0)
        {
            InitializeComponent();
            _frmChartOfAccounts = frmChartOfAccounts;
            _frmSubsidiary = frmSubsidiary;
            uc = ucBeginningBalances1;
            uc.fundId = fundId;
            uc.generalLedgerId = generalLedgerId;
            uc.year = year;
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

                return AccFactory.BeginningBalancesRepository().Insert(beginningBalanceModel);
            }
            catch (Exception ex)
            {
                Helper.MessageBoxError(ex.Message);
            }

            return false;
        }

        private void frmBeginningBalanceAdd_Load(object sender, EventArgs e)
        {
            Helper.LoadFormIcon(this);
            uc.LoadSelectedGeneralLedger();
            uc.LoadSelectedSubsidiaryAccount();
            uc.radioDebit.Checked = true;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (SaveData())
            {
                Helper.MessageBoxSuccess("Beginning balance has been saved.");

                if (_frmSubsidiary != null) _frmSubsidiary.LoadSubsidiaryRecordsByFundAndGeneralLedger();
                if (_frmChartOfAccounts != null) _frmChartOfAccounts.LoadGeneralLedgers(30);
                Close();
            }
        }
    }
}