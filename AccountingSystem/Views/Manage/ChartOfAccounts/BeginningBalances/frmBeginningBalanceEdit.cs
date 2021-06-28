using ACC.Domain.Models;
using AccountingSystem.Views.Manage.BeginningBalances;
using AccountingSystem.Views.Manage.ChartOfAccounts.Subsidiary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace AccountingSystem.Views.Manage.ChartOfAccounts.BeginningBalances
{
    public partial class frmBeginningBalanceEdit : Form
    {
        private readonly UcBeginningBalances uc;
        private readonly byte fundId;
        private readonly short year;
        frmSubsidiary _frmSubsidiary;

        public frmBeginningBalanceEdit(frmSubsidiary frmSubsidiary, byte fundId, ushort generalLedgerId, short year, ushort subsidiaryLedgerId = 0)
        {
            InitializeComponent();
            _frmSubsidiary = frmSubsidiary;
            uc = ucBeginningBalances1;
            this.fundId = fundId;
            uc.generalLedgerId = generalLedgerId;
            uc.subsidiaryLedgerId = subsidiaryLedgerId;
            this.year = year;
        }

        private void LoadSelectedRecord()
        {
            try
            {
                Dictionary<string, string> beginningBalanceDict = new();
                if (uc.subsidiaryLedgerId == 0)
                    beginningBalanceDict = Factory.BeginningBalancesRepository().GetRecordByFundsAndGeneralLedgerID(fundId, uc.generalLedgerId, year);
                else
                    beginningBalanceDict = Factory.BeginningBalancesRepository().GetRecordByFundsAndGeneralLedgerID(fundId, uc.generalLedgerId, year, uc.subsidiaryLedgerId);

                uc.beginningBalanceId = int.Parse(beginningBalanceDict["id"]);
                CheckedFund();
                CheckedDebitCredit(beginningBalanceDict["is_debit"]);
                uc.dtpDateEntry.Value = Convert.ToDateTime(beginningBalanceDict["date_entry"]);
                uc.nudAmount.Value = Convert.ToDecimal(beginningBalanceDict["amount"]);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void CheckedFund()
        {
            var fundDict = Factory.FundsRepository().GetRecordByID(fundId);
            _ = uc.flowLayoutPanelFunds.Controls.OfType<RadioButton>().FirstOrDefault(r => (r.Text == fundDict["fund_name"]) ? r.Checked = true : r.Checked = false);
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
                    Id = uc.beginningBalanceId,
                    FundsId = fundId,
                    GeneralLedgerId = uc.generalLedgerId,
                    SubsidiaryLedgerId = subsidiaryId != 0 ? subsidiaryId : null,
                    IsDebit = uc.radioDebit.Checked,
                    DateEntry = uc.dtpDateEntry.Value,
                    Amount = uc.nudAmount.Value
                };

                return Factory.BeginningBalancesRepository().Update(beginningBalanceModel);
            }
            catch (Exception ex)
            {
                Helper.MessageBoxError(ex.Message);
            }

            return false;
        }

        private void frmBeginningBalanceEdit_Load(object sender, EventArgs e)
        {
            Helper.LoadFormIcon(this);
            uc.LoadFunds();
            uc.LoadSelectedGeneralLedger();
            uc.LoadSelectedSubsidiaryAccount();

            LoadSelectedRecord();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (UpdateData())
            {
                Helper.MessageBoxSuccess("Balance has been saved.");

                if(_frmSubsidiary != null)
                    _frmSubsidiary.LoadSubsidiaryRecordsByFundAndGeneralLedger();
            }
        }
    }
}
