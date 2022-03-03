using ACC.Domain.Interfaces;
using System;
using System.ComponentModel;
using System.Windows.Forms;

namespace AccountingSystem.Views.Manage.BeginningBalances
{
    public partial class UcBeginningBalances : UserControl
    {
        internal int beginningBalanceId;
        internal byte fundId;
        internal ushort generalLedgerId;
        internal ushort subsidiaryLedgerId;
        internal short year;

        public UcBeginningBalances()
        {
            InitializeComponent();
        }

        internal string GetFormErrors()
        {
            var errorArray = new string[2];
            errorArray[0] = epYear.GetError(dtpDateEntry);
            errorArray[1] = epAmount.GetError(nudAmount);

            IError _errors = Factory.CreateErrors(errorArray);
            return _errors.GenerateErrorMessage();
        }

        internal void ResetForm()
        {
            nudAmount.Value = 0;
        }

        internal void LoadSelectedGeneralLedger()
        {
            try
            {
                var generalLedgerAccount = Factory.GeneralLedgerAccountsRepository().GetViewRecordByID(generalLedgerId);

                txtAccountCode.Text = generalLedgerAccount["account_code"];
                txtAccountName.Text = generalLedgerAccount["ledger_name"];
            }
            catch (Exception ex)
            {
                Helper.MessageBoxError(ex.Message);
            }
        }

        internal void LoadSelectedSubsidiaryAccount()
        {
            if (subsidiaryLedgerId != 0)
            {
                var subsidiaryDict = Factory.SubsidiaryLedgerAccountsRepository().GetRecordByID(subsidiaryLedgerId);
                txtSubsidiaryCode.Text = subsidiaryDict["sub_code"];
                txtSubsidiaryName.Text = subsidiaryDict["sub_name"];

            }
        }

        private void nudAmount_Validating(object sender, CancelEventArgs e)
        {
            e.Cancel = Helper.ShowErrorNumericUpDownEmpty(epAmount, nudAmount, "amount");

            if (nudAmount.Value == 0)
            {
                epAmount.SetError(nudAmount, "Please enter a non-zero balance.");
                e.Cancel = true;
            }
        }

        private void nudAmount_Validated(object sender, EventArgs e)
        {
            Helper.ClearErrorNumericUpDown(epAmount, nudAmount);
        }

        private void UcBeginningBalances_Load(object sender, EventArgs e)
        {
            if (!DesignMode)
            {
                var dtFund = Factory.FundsRepository().GetRecordByID(fundId);
                txtFunName.Text = dtFund["fund_name"];
                txtYear.Text = year.ToString();
                dtpDateEntry.MaxDate = new DateTime(year, 12, DateTime.DaysInMonth(year, 12));
                dtpDateEntry.MinDate = new DateTime(year, 1, 1);
            }
        }
    }
}
