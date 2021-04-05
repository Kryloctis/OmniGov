using ACC.Domain.Models;
using AccountingSystem.Views.Manage.BeginningBalances;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AccountingSystem.Views.Manage.ChartOfAccounts.BeginningBalances
{
    public partial class frmBeginningBalanceEdit : Form
    {
        private readonly UcBeginningBalances uc;
        private readonly byte fundId;
        private readonly short year;

        public frmBeginningBalanceEdit(byte fundId, ushort generalLedgerId, short year)
        {
            InitializeComponent();
            uc = ucBeginningBalances1;
            this.fundId = fundId;
            uc.generalLedgerId = generalLedgerId;
            this.year = year;
        }


        private void LoadSelectedRecord()
        {
            try
            {
                var beginningBalanceDict = Factory.BeginningBalancesRepository().GetRecordByGeneralLedgerAndFundsID(fundId, uc.generalLedgerId, year);

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
                    FundsId = uc.fundId,
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
            }
        }
    }
}
