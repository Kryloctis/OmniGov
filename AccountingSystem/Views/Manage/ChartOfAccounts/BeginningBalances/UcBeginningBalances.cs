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
            var errorArray = new string[]
            {
                epYear.GetError(dtpDateEntry),
                epAmount.GetError(nudAmount)
            };

            return AccFactory.CreateErrors(errorArray).GenerateErrorMessage();
        }

        internal void LoadSelectedGeneralLedger()
        {
            try
            {
                var generalLedgerAccount = AccFactory.GeneralLedgerAccountsRepository().GetViewRecordByID(generalLedgerId);

                txtAccountCode.Text = generalLedgerAccount["account_code"];
                txtAccountName.Text = generalLedgerAccount["ledger_name"];
            }
            catch (Exception ex)
            { Helper.MessageBoxError(ex.Message); }
        }

        internal void LoadSelectedSubsidiaryAccount()
        {
            try
            {
                if (subsidiaryLedgerId != 0)
                {
                    var subsidiaryDict = AccFactory.SubsidiaryLedgerAccountsRepository().GetRecordByID(subsidiaryLedgerId);
                    txtSubsidiaryCode.Text = subsidiaryDict["sub_code"];
                    txtSubsidiaryName.Text = subsidiaryDict["sub_name"];
                }
            }
            catch (Exception ex)
            {
                Helper.MessageBoxError(ex.Message);
            }
        }

        internal void ResetForm()
        {
            nudAmount.Value = 0;
        }

        private void nudAmount_Validated(object sender, EventArgs e)
        {
            Helper.ClearErrorNumericUpDown(epAmount, nudAmount);
        }

        private void nudAmount_Validating(object sender, CancelEventArgs e)
        {
            e.Cancel = Helper.ShowErrorNumericUpDownZero(epAmount, nudAmount, "Amount") || Helper.ShowErrorNumericUpDownEmpty(epAmount, nudAmount, "amount");
        }

        private void OnLoad()
        {
            try
            {
                var dtFund = AccFactory.FundsRepository().GetRecordByID(fundId);
                txtFunName.Text = dtFund["fund_name"];
                txtYear.Text = year.ToString();
                dtpDateEntry.MaxDate = new DateTime(year, 12, DateTime.DaysInMonth(year, 12));
                dtpDateEntry.MinDate = new DateTime(year, 1, 1);
            }
            catch (Exception ex)
            {
                Helper.MessageBoxError(ex.Message);
            }
        }

        private void UcBeginningBalances_Load(object sender, EventArgs e)
        {
            if (!DesignMode)
            {
                OnLoad();
            }
        }
    }
}