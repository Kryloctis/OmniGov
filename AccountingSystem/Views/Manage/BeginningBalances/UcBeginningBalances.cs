using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ACC.Domain.Interfaces;

namespace AccountingSystem.Views.Manage.BeginningBalances
{
    public partial class UcBeginningBalances : UserControl
    {
        internal byte fundId = 0;

        public UcBeginningBalances()
        {
            InitializeComponent();
        }

        internal string GetFormErrors()
        {
            var errorArray = new string[4];
            errorArray[0] = epGeneralAccount.GetError(lstBoxGeneralAccount);
            errorArray[1] = epSubsidiaryAccount.GetError(cmbSubsidiaryAccount);
            errorArray[2] = epYear.GetError(nudYear);
            errorArray[3] = epAmount.GetError(nudAmount);

            IError _errors = Factory.CreateErrors(errorArray);
            return _errors.GenerateErrorMessage();
        }

        internal void ResetForm()
        {
            txtGeneralAccount.Clear();

            lstBoxGeneralAccount.DataSource = null;
            lstBoxGeneralAccount.Items.Clear();

            cmbSubsidiaryAccount.DataSource = null;
            cmbSubsidiaryAccount.Items.Clear();
            
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
        }

        private void radioFunds_CheckedChanged(object sender, EventArgs e)
        {
            var radFund = sender as RadioButton;
            ShowCheckIcon(radFund);
        }

        private void LoadGeneralLedgerAccount()
        {
            var dtGeneralLedgerAccount = Factory.GeneralLedgerAccountsRepository().GetViewRecordsBySearch(txtGeneralAccount.Text);

            HelperLoadRecords.GeneralLedgerListBox(dtGeneralLedgerAccount, lstBoxGeneralAccount);
        }

        private void LoadSubsidiaryAccount()
        {
            lstBoxGeneralAccount.SelectedValueChanged -= new EventHandler(lstBoxGeneralAccount_SelectedValueChanged);

            var generalLedgerId = Convert.ToUInt16(lstBoxGeneralAccount.SelectedValue);
            var dtSubsidiaryAccount = Factory.SubsidiaryLedgerAccountsRepository().GetRecordsByFundAndGeneralLedger(fundId, generalLedgerId);

            HelperLoadRecords.SubsidiaryLedgerComboBox(dtSubsidiaryAccount, cmbSubsidiaryAccount, "sub_name", "id");

            lstBoxGeneralAccount.SelectedValueChanged += new EventHandler(lstBoxGeneralAccount_SelectedValueChanged);
        }

        private void lstBoxGeneralAccount_Validating(object sender, CancelEventArgs e)
        {
            if (lstBoxGeneralAccount.SelectedItems.Count == 0)
            {
                epGeneralAccount.SetError(lstBoxGeneralAccount, "General ledger account is required.");
                e.Cancel = true;
            }
        }

        private void lstBoxGeneralAccount_Validated(object sender, EventArgs e)
        {
            epGeneralAccount.SetError(lstBoxGeneralAccount, string.Empty);
        }

        private void cmbSubsidiaryAccount_Validating(object sender, CancelEventArgs e)
        {

        }

        private void cmbSubsidiaryAccount_Validated(object sender, EventArgs e)
        {

        }

        private void nudYear_Validating(object sender, CancelEventArgs e)
        {
            e.Cancel = Helper.ShowErrorNumericUpDownEmpty(epYear, nudYear, "year");
        }

        private void nudYear_Validated(object sender, EventArgs e)
        {
            Helper.ClearErrorNumericUpDown(epYear, nudYear);
        }

        private void nudAmount_Validating(object sender, CancelEventArgs e)
        {
            e.Cancel = Helper.ShowErrorNumericUpDownEmpty(epAmount, nudAmount, "year");
        }

        private void nudAmount_Validated(object sender, EventArgs e)
        {
            Helper.ClearErrorNumericUpDown(epAmount, nudAmount);
        }

        private void txtGeneralAccount_TextChanged(object sender, EventArgs e)
        {
            if (txtGeneralAccount.Text.Length > 2)
            {
                LoadGeneralLedgerAccount();
                return;
            }

            lstBoxGeneralAccount.DataSource = null;
            lstBoxGeneralAccount.Items.Clear();
            
        }

        private void lstBoxGeneralAccount_SelectedValueChanged(object sender, EventArgs e)
        {
            LoadSubsidiaryAccount();
        }
    }
}
