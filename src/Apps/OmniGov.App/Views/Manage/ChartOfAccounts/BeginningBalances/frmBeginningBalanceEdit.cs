using Accounting.Data.Factories;
using Accounting.Domain.Entities;
using OmniGov.App.Helpers;
using OmniGov.App.Views.Manage.ChartOfAccounts.Subsidiary;

namespace OmniGov.App.Views.Manage.ChartOfAccounts.BeginningBalances
{
    public partial class frmBeginningBalanceEdit : Form
    {
        private readonly UcBeginningBalances uc;
        private readonly byte fundId;
        private readonly short year;
        private frmSubsidiary _frmSubsidiary;
        private frmChartOfAccounts _frmChartOfAccounts;

        public frmBeginningBalanceEdit(frmChartOfAccounts frmChartOfAccounts, frmSubsidiary frmSubsidiary, byte fundId, ushort generalLedgerId, short year, ushort subsidiaryLedgerId = 0)
        {
            InitializeComponent();
            _frmChartOfAccounts = frmChartOfAccounts;
            _frmSubsidiary = frmSubsidiary;
            uc = ucBeginningBalances1;
            this.fundId = fundId;
            uc.fundId = fundId;
            uc.generalLedgerId = generalLedgerId;
            uc.subsidiaryLedgerId = subsidiaryLedgerId;
            this.year = year;
            uc.year = year;
        }

        private void LoadSelectedRecord()
        {
            Dictionary<string, string> beginningBalanceDict = new();
            if (uc.subsidiaryLedgerId == 0)
                beginningBalanceDict = AccountingFactory.BeginningBalancesRepository().GetRecordBy_FundId_GenLedgId_Year_SubLedgId(fundId, uc.generalLedgerId, year);
            else
                beginningBalanceDict = AccountingFactory.BeginningBalancesRepository().GetRecordBy_FundId_GenLedgId_Year_SubLedgId(fundId, uc.generalLedgerId, year, uc.subsidiaryLedgerId);

            uc.beginningBalanceId = int.Parse(beginningBalanceDict["id"]);
            CheckedDebitCredit(beginningBalanceDict["is_debit"]);
            uc.dtpDateEntry.Value = Convert.ToDateTime(beginningBalanceDict["date_entry"]);
            uc.nudAmount.Value = Convert.ToDecimal(beginningBalanceDict["amount"]);
        }

        private void CheckedDebitCredit(string isDebit)
        {
            if (isDebit == "1")
            {
                uc.radioDebit.Checked = true;
                return;
            }

            uc.radioCredit.Checked = true;
        }

        private bool UpdateData()
        {
            if (!uc.ValidateChildren())
            {
                Helper.MessageBoxError(uc.GetFormErrors());
                return false;
            }

            ushort subsidiaryId = uc.subsidiaryLedgerId;
            var beginningBalanceModel = new BeginningBalancesModel()
            {
                Id = uc.beginningBalanceId,
                FundsId = fundId,
                GeneralLedgerId = uc.generalLedgerId,
                SubsidiaryLedgerId = subsidiaryId != 0 ? subsidiaryId : null,
                IsDebit = uc.radioDebit.Checked,
                DateEntry = uc.dtpDateEntry.Value,
                Amount = uc.nudAmount.Value
            };

            return AccountingFactory.BeginningBalancesRepository().Update(beginningBalanceModel);
        }

        private void OnLoad()
        {
            Helper.LoadFormIcon(this);
            uc.LoadSelectedGeneralLedger();
            uc.LoadSelectedSubsidiaryAccount();

            LoadSelectedRecord();
        }

        private void frmBeginningBalanceEdit_Load(object sender, EventArgs e)
        {
            try
            {
                OnLoad();
            }
            catch (Exception ex) { Helper.MessageBoxError(ex.Message); }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                if (UpdateData())
                {
                    Helper.MessageBoxSuccess("Balance has been saved.");

                    if (_frmSubsidiary != null) _frmSubsidiary.LoadSubsidiaryRecordsByFundAndGeneralLedger();
                    if (_frmChartOfAccounts != null) _frmChartOfAccounts.LoadGeneralLedgers(30);
                    Close();
                }
            }
            catch (Exception ex) { Helper.MessageBoxError(ex.Message); }
        }

        private bool Delete()
        {
            string message = "Are you sure you want to delete the balance?";
            if (MessageBox.Show(message, "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                return AccountingFactory.BeginningBalancesRepository().DeleteById(uc.beginningBalanceId);

            return false;
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                if (Delete())
                {
                    Helper.MessageBoxSuccess($"Balance has been deleted.");
                    if (_frmSubsidiary != null) _frmSubsidiary.LoadSubsidiaryRecordsByFundAndGeneralLedger();
                    if (_frmChartOfAccounts != null) _frmChartOfAccounts.LoadGeneralLedgers(30);
                }
                Close();
            }
            catch (Exception ex) { Helper.MessageBoxError(ex.Message); }
        }
    }
}
