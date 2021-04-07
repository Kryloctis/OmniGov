using System;
using System.ComponentModel;
using System.Data;
using System.Windows.Forms;
using ACC.Domain.Interfaces;

namespace AccountingSystem.Views.Manage.BeginningBalances
{
    public partial class UcBeginningBalances : UserControl
    {
        internal int beginningBalanceId;
        internal byte fundId;
        internal ushort generalLedgerId;
        internal ushort subsidiaryLedgerId;

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

        private void ShowCheckIcon(RadioButton radioButton)
        {
            if (radioButton.Checked)
                radioButton.Image = Properties.Resources.ok14px;
            else
                radioButton.Image = null;
        }

        internal void LoadFunds()
        {
            var funds = Factory.FundsRepository().GetRecords();

            foreach (DataRow fund in funds.Rows)
            {
                var radFund = new RadioButton
                {
                    Text = fund["fund_name"].ToString(),
                    Tag = fund["id"],
                    AutoSize = true,
                    Appearance = Appearance.Button,
                    TextImageRelation = TextImageRelation.ImageBeforeText
                };

                // making general fund as default
                if (fund["fund_name"].ToString() == "General Fund")
                {
                    radFund.Checked = true;
                    fundId = Convert.ToByte(fund["id"]);
                    ShowCheckIcon(radFund);
                }


                flowLayoutPanelFunds.Controls.Add(radFund);

                radFund.Click += new EventHandler(radioFunds_Click);
                radFund.CheckedChanged += new EventHandler(radioFunds_CheckedChanged);
            }
        }

        private void radioFunds_Click(object sender, EventArgs e)
        {
            var radFund = sender as RadioButton;
            fundId = Convert.ToByte(radFund.Tag);
            LoadSelectedSubsidiaryAccount();
        }

        private void radioFunds_CheckedChanged(object sender, EventArgs e)
        {
            var radFund = sender as RadioButton;
            ShowCheckIcon(radFund);
        }

        internal void LoadSelectedGeneralLedger()
        {
            var generalLedgerAccount = Factory.GeneralLedgerAccountsRepository().GetViewRecordByID(generalLedgerId);

            txtAccountCode.Text = generalLedgerAccount["account_code"];
            txtAccountName.Text = generalLedgerAccount["ledger_name"];
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

        private void cmbSubsidiaryAccount_Validating(object sender, CancelEventArgs e)
        {

        }

        private void cmbSubsidiaryAccount_Validated(object sender, EventArgs e)
        {

        }

        private void nudAmount_Validating(object sender, CancelEventArgs e)
        {
            e.Cancel = Helper.ShowErrorNumericUpDownEmpty(epAmount, nudAmount, "amount");

            if (nudAmount.Value < 1)
            {
                epAmount.SetError(nudAmount, "Please enter a non-zero balance.");
                e.Cancel = true;
            }
        }

        private void nudAmount_Validated(object sender, EventArgs e)
        {
            Helper.ClearErrorNumericUpDown(epAmount, nudAmount);
        }

        private void lstBoxGeneralAccount_SelectedValueChanged(object sender, EventArgs e)
        {
            LoadSelectedSubsidiaryAccount();
        }
    }
}
