using ACC.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AccountingSystem.Views.Transactions.ObligationRequest
{
    public partial class ucObligationRequest : UserControl
    {
        internal int fundId = 0;
        internal int fppId = 0;
        internal int? otherFPPId = null;
        internal int allotmentClassId = 0;
        internal DateTime dateIssued = DateTime.Now;
        ucObligationRequestMain _ucObligationRequestMain;

        public ucObligationRequest()
        {
            InitializeComponent();
        }

        internal void LoadReference(ucObligationRequestMain ucObligationRequestMain)
        {
            _ucObligationRequestMain = ucObligationRequestMain;
        }

        internal string GetFormErrors()
        {
            var errorArray = new string[2];
            errorArray[0] = epAccount.GetError(cmbxAccount);
            errorArray[1] = epAmount.GetError(nudAmount);

            IError _errors = Factory.CreateErrors(errorArray);
            return _errors.GenerateErrorMessage();
        }

        private void LoadAccounts()
        {
            try
            {
                var allotmentClassRepo = Factory.AllotmentClassesRepository().GetRecordByID(allotmentClassId);

                string allotmentClassName = allotmentClassRepo["allotment_name"];

                DataTable dtAccounts;

                if (allotmentClassId == 4)
                    dtAccounts = Factory.GeneralLedgerAccountsRepository().GetAllViewRecordsBySearch(cmbxAccount.Text);
                else
                    dtAccounts = Factory.GeneralLedgerAccountsRepository().GetViewRecordsByMajAccGroupNameSearch(allotmentClassName, cmbxAccount.Text);

                var accountDict = new Dictionary<int, string>();
                foreach (DataRow item in dtAccounts.Rows)
                {
                    int accountId = Convert.ToInt32(item["general_ledger_accounts_id"]);
                    string accountName = $"{item["account_code"]} - {item["ledger_name"]}";

                    accountDict.Add(accountId, accountName);
                }

                cmbxAccount.DataSource = new BindingSource(accountDict, null);
                cmbxAccount.DisplayMember = "value";
                cmbxAccount.ValueMember = "key";
                cmbxAccount.SelectedIndex = -1;
                cmbxAccount.SelectedValueChanged += new EventHandler(cmbxAccount_SelectedValueChanged);

                Helper.ClearErrorComboBox(epAccount, cmbxAccount);
            }
            catch (Exception ex)
            {
                Helper.MessageBoxError(ex.Message);
            }
        }


        private void cmbxAccount_SelectedValueChanged(object sender, EventArgs e)
        {
            txtAllotmentBalance.Text = GetTotalAllotmentBalanceAmount()["totalAllotmentBalanceAmount"].ToString("N2");
            txtTotalAllotmentRelease.Text = GetTotalAllotmentBalanceAmount()["totalAllotmentAmount"].ToString("N2");
        }


        private void ucObligationRequest_Load(object sender, EventArgs e)
        {
            if (!DesignMode) 
            {
                LoadAccounts();
            }
        }

        private Dictionary<string,decimal> GetTotalAllotmentBalanceAmount()
        {
            var record = new Dictionary<string, decimal>();

            if (cmbxAccount.SelectedIndex > -1) 
            {
                int accountId = Convert.ToInt32(cmbxAccount.SelectedValue);

                decimal totalAllotmentAmount = Factory.AllotmentReleaseRepository().GetViewTotalAllotmentReleaseAmount(fundId, fppId, otherFPPId, allotmentClassId, accountId, dateIssued);

                var totalObligationAmountByYear = Factory.ObligationRequestRepository().GetTotalObligationAmount(fundId, fppId, otherFPPId, allotmentClassId, accountId, dateIssued);

                var totalAllotmentBalanceAmount = totalAllotmentAmount - Convert.ToDecimal(totalObligationAmountByYear["total_obligation_amount"]);

                record.Add("totalAllotmentAmount", totalAllotmentAmount);
                record.Add("totalAllotmentBalanceAmount", totalAllotmentBalanceAmount);

                return record;
            }
            return record;
        }

        #region Validations

        private bool AccountExistOnList() 
        {
            try
            {
                int accountId = Convert.ToInt32(cmbxAccount.SelectedValue);

                foreach (DataGridViewRow row in _ucObligationRequestMain.dgObligationRequests.Rows)
                {
                    int cellAccountId = Convert.ToInt32(row.Cells["accountId"].Value);
                    bool accountExist = cellAccountId == accountId ? true : false;

                    if (accountExist)
                    {
                        epAccount.SetError(cmbxAccount, "Account is already on the list.");
                        return true;
                    }
                }
            }
            catch (Exception ex)
            {
                Helper.MessageBoxError(ex.Message);
            }
            return false;
        }

        private bool AccountObligationRequestExist() 
        {
            try
            {
                int accountId = Convert.ToInt32(cmbxAccount.SelectedValue);
                bool AccountExist = Factory.ObligationRequestRepository().AccountExist(accountId, dateIssued);

                if (AccountExist && !string.IsNullOrEmpty(cmbxAccount.Text))
                {
                    epAccount.SetError(cmbxAccount, "Account you entered has an obligation request already exist on the date it was issued.");
                    return true;
                }
            }
            catch (Exception ex)
            {
                Helper.MessageBoxError(ex.Message);
            }
            return false;
        }

        private bool AccountNotExist() 
        {
            try
            {
                if (cmbxAccount.FindStringExact(cmbxAccount.Text) < 0 && !string.IsNullOrEmpty(cmbxAccount.Text)) 
                {
                    epAccount.SetError(cmbxAccount, "Account Doesn't exist on the list.");
                    return true;
                }
            }
            catch (Exception ex)
            {
                Helper.MessageBoxError(ex.Message);
            }
            return false;
        }

        private void cmbxAccount_Validating(object sender, CancelEventArgs e)
        {
            if(string.IsNullOrEmpty(cmbxAccount.Text))
            e.Cancel = Helper.ShowErrorComboBoxEmpty(epAccount, cmbxAccount, "Account");
            else if (AccountNotExist())
            e.Cancel = AccountNotExist();
            else if (AccountExistOnList())
            e.Cancel = AccountExistOnList();
            else
            e.Cancel = AccountObligationRequestExist();
        }

        private void cmbxAccount_Validated(object sender, EventArgs e)
        {
            Helper.ClearErrorComboBox(epAccount, cmbxAccount);
        }

        private bool AmmountIsZero(ErrorProvider ep, NumericUpDown numericUpDown)
        {
            try
            {
                if (nudAmount.Value == 0)
                {
                    ep.SetError(numericUpDown, "Valuable amount is required.");
                    return true;
                }
            }
            catch (Exception ex)
            {
                Helper.MessageBoxError(ex.Message);
            }
            return false;
        }

        private bool AmountExceeds(ErrorProvider ep, NumericUpDown numericUpDown) 
        {
            try
            {
                if (nudAmount.Value > GetTotalAllotmentBalanceAmount()["totalAllotmentBalanceAmount"])
                {
                    ep.SetError(numericUpDown, "Amount you entered exceeds to the allotment balance");
                    return true;
                }
            }
            catch (Exception ex)
            {
                Helper.MessageBoxError(ex.Message);
            }
            return false;
        }

        private void nudAmount_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrEmpty(nudAmount.Text))
                e.Cancel = Helper.ShowErrorNumericUpDownEmpty(epAmount, nudAmount, "Amount");
            else if (AmmountIsZero(epAmount, nudAmount))
                e.Cancel = AmmountIsZero(epAmount, nudAmount);
            else
                e.Cancel = AmountExceeds(epAmount, nudAmount);
        }

        private void nudAmount_Validated(object sender, EventArgs e)
        {
            Helper.ClearErrorNumericUpDown(epAmount, nudAmount);
        }

        #endregion Validations

        private void cmbxAccount_KeyDown(object sender, KeyEventArgs e)
        {
            if (cmbxAccount.Text.Length < 4) return;

            if (e.KeyCode == Keys.F1)
            {
                try
                {
                    var allotmentClassRepo = Factory.AllotmentClassesRepository().GetRecordByID(allotmentClassId);

                    string allotmentClassName = allotmentClassRepo["allotment_name"];

                    DataTable dtAccounts;

                    if (allotmentClassId == 4)
                        dtAccounts = Factory.GeneralLedgerAccountsRepository().GetAllViewRecordsBySearch(cmbxAccount.Text);
                    else
                        dtAccounts = Factory.GeneralLedgerAccountsRepository().GetViewRecordsByMajAccGroupNameSearch(allotmentClassName, cmbxAccount.Text);

                    if (dtAccounts.Rows.Count == 0 || string.IsNullOrWhiteSpace(cmbxAccount.Text.Trim())) return;

                    var accountDict = new Dictionary<int, string>();
                    foreach (DataRow item in dtAccounts.Rows)
                    {
                        int accountId = Convert.ToInt32(item["general_ledger_accounts_id"]);
                        string accountName = $"{item["account_code"]} - {item["ledger_name"]}";

                        accountDict.Add(accountId, accountName);
                    }

                    cmbxAccount.DataSource = new BindingSource(accountDict, null);
                    cmbxAccount.DisplayMember = "value";
                    cmbxAccount.ValueMember = "key";
                    cmbxAccount.DroppedDown = true;

                    Helper.ClearErrorComboBox(epAccount, cmbxAccount);
                }
                catch (Exception ex)
                {
                    Helper.MessageBoxError(ex.Message);
                }
            }
        }
    }
}
