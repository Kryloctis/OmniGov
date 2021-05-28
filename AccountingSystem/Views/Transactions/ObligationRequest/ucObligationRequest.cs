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

        internal int fppId;
        internal int? otherFPPId;
        internal int fundId;
        internal int allotmentClassId;
        internal DateTime dateRequested;
        private ucObligationRequestMain _ucObligationRequestMain;
        private decimal totalAllotmentReleaseBalance;
        internal int selectedAccountId = 0;
        internal decimal currentObligationAmount;

        public ucObligationRequest()
        {
            InitializeComponent();
        }


        internal void LoadSelected()
        {
           cmbxAccount.SelectedValue = selectedAccountId;
        }




        internal void LoadReferences(ucObligationRequestMain ucObligationRequestMain) 
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

        internal void ResetForm() 
        {
            nudAmount.Value = 0;
        }

        private void GetTotalAllotmentRelease()
        {
            int accountId = Convert.ToInt32(cmbxAccount.SelectedValue);

            decimal  totalAllotmentRelease = Factory.AllotmentReleaseRepository().GetTotalAllotmentReleaseByDateYear(fundId, fppId, otherFPPId, allotmentClassId, accountId, dateRequested ,Convert.ToInt16(dateRequested.Year));

            txtAllotmentAmount.Text = totalAllotmentRelease.ToString("N2");
            
        }

        internal void GetTotalAllotmentBalance()
        {
            int accountId = Convert.ToInt32(cmbxAccount.SelectedValue);

            //Get Total Allotment Release By Year and has if it is continuing or not
            decimal totalAllotmentReleaseByYear = Factory.AllotmentReleaseRepository().GetTotalAllotmentReleaseByYear(fundId, fppId, otherFPPId, allotmentClassId, accountId, Convert.ToInt16(dateRequested.Year));

            //Get Total Allotment Release By Date and has if it is continuing or not
            decimal totalAllotmentReleaseByDate = Factory.AllotmentReleaseRepository().GetTotalAllotmentReleaseByDateYear(fundId, fppId, otherFPPId, allotmentClassId, accountId, dateRequested, Convert.ToInt16(dateRequested.Year));

            // Get Total Obligations by year
            decimal totalObligations = Factory.ObligationRequestRepository().TotalObligationRequestByYear(fundId, fppId, otherFPPId, allotmentClassId, accountId, Convert.ToInt16(dateRequested.Year));

            //Get Total Allotment Release Balance By Year
            decimal totalAllotmentReleaseBalanceByYear = totalAllotmentReleaseByYear - totalObligations;

            decimal AllotmentReleaseBalanceByDate = totalAllotmentReleaseBalanceByYear > totalAllotmentReleaseByDate ? totalAllotmentReleaseByDate : totalAllotmentReleaseBalanceByYear;

            decimal OnListItemsAmount = GetTotalOnListItemsAmounts(accountId);

            decimal currentBalance = _ucObligationRequestMain.obligationRequestId == 0 ? 0 : currentObligationAmount;

            decimal finalAllotmenReleaseBalance = AllotmentReleaseBalanceByDate - OnListItemsAmount + currentBalance;
            totalAllotmentReleaseBalance = finalAllotmenReleaseBalance;

            txtBalance.Text = finalAllotmenReleaseBalance.ToString("N2");

            txtAllotmentAmount.Text = totalAllotmentReleaseByDate.ToString("N2");

        }

        private decimal GetTotalOnListItemsAmounts(int accountId)
        {
            decimal OnListItemsAmount = 0;

            if (_ucObligationRequestMain.dataGridView1.Rows.Count ==  0 ||  _ucObligationRequestMain.obligationRequestId > 0)
                OnListItemsAmount = 0;
            else
            {
                foreach (DataGridViewRow item in _ucObligationRequestMain.dataGridView1.Rows)
                {
                    int rowAccountId = Convert.ToInt32(item.Cells["account_id"].Value);
                    decimal rowAmount = Convert.ToDecimal(item.Cells["amount"].Value);

                    if (accountId == rowAccountId)
                    {
                        OnListItemsAmount += rowAmount;
                    }
                }
            }
            
            return OnListItemsAmount;
        }



        private void LoadAccounts()
        {
            try
            {
                cmbxAccount.SelectedValueChanged -= new EventHandler(cmbxAccount_SelectedValueChanged);
                cmbxAccount.TextChanged -= new EventHandler(cmbxAccount_TextChanged);

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
                cmbxAccount.TextChanged += new EventHandler(cmbxAccount_TextChanged);

                Helper.ClearErrorComboBox(epAccount, cmbxAccount);
            }
            catch (Exception ex)
            {
                Helper.MessageBoxError(ex.Message);
            }
        }

        private void cmbxAccount_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(cmbxAccount.Text))
            {
                LoadAccounts();
                GetTotalAllotmentRelease();
                GetTotalAllotmentBalance();
            }
            else if ((ShowErrorAccountNameNotExist() && !string.IsNullOrEmpty(cmbxAccount.Text)) || string.IsNullOrEmpty(cmbxAccount.Text))
            {
                txtAllotmentAmount.Text = "0.00";
                txtBalance.Text = "0.00";
            }
        }

        private bool ShowErrorAccountNameNotExist()
        {
            try
            {
                if (cmbxAccount.FindStringExact(cmbxAccount.Text) < 0 && !string.IsNullOrEmpty(cmbxAccount.Text))
                {
                    epAccount.SetError(cmbxAccount, "Account you entered doesn't exist on your record.");
                    return true;
                }
            }
            catch (Exception ex)
            {
                Helper.MessageBoxError(ex.Message);
            }
            return false;
        }

        private bool ShowErrorAccountExistOnList() 
        {
            try
            {
                foreach (DataGridViewRow item in _ucObligationRequestMain.dataGridView1.Rows) 
                {
                    int accountId = Convert.ToInt32(cmbxAccount.SelectedValue);
                    int rowAccountId = Convert.ToInt32(item.Cells["account_id"].Value);


                    if (accountId == rowAccountId && _ucObligationRequestMain.obligationRequestId == 0) 
                    {
                        epAccount.SetError(cmbxAccount, "Account already exist on the List");
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

        private void cmbxAccount_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrEmpty(cmbxAccount.Text))
                e.Cancel = Helper.ShowErrorComboBoxEmpty(epAccount, cmbxAccount, "Account");
            else if (ShowErrorAccountNameNotExist())
                e.Cancel = ShowErrorAccountNameNotExist();
            else
                e.Cancel = ShowErrorAccountExistOnList();
        }

        private void cmbxAccount_Validated(object sender, EventArgs e)
        {
            Helper.ClearErrorComboBox(epAccount, cmbxAccount);
        }

        private void cmbxAccount_KeyDown(object sender, KeyEventArgs e)
        {
            if (cmbxAccount.Text.Length < 4) return;

            if (e.KeyCode == Keys.F1)
            {
                try
                {

                    cmbxAccount.SelectedValueChanged -= new EventHandler(cmbxAccount_SelectedValueChanged);

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

                    cmbxAccount.SelectedValueChanged += new EventHandler(cmbxAccount_SelectedValueChanged);
                    GetTotalAllotmentRelease();
                    GetTotalAllotmentBalance();

                    Helper.ClearErrorComboBox(epAccount, cmbxAccount);
                }
                catch (Exception ex)
                {
                    Helper.MessageBoxError(ex.Message);
                }
            }
        }

        private void cmbxAccount_SelectedValueChanged(object sender, EventArgs e)
        {
            GetTotalAllotmentRelease();
            GetTotalAllotmentBalance();
        }



        private bool ShowErrorAmountIsZero()
        {
            try
            {
                if (nudAmount.Value == 0 && !string.IsNullOrEmpty(nudAmount.Text))
                {
                    epAmount.SetError(nudAmount, "Please enter a valuable amount.");
                    return true;
                }
            }
            catch (Exception ex)
            {
                Helper.MessageBoxError(ex.Message);
            }
            return false;
        }

        private bool ShowErrorAmountExceeds() 
        {
            try
            {
                if (nudAmount.Value > totalAllotmentReleaseBalance)
                {
                    epAmount.SetError(nudAmount, "Amount you entered exceeds to the alloted balance.");
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
            else if (ShowErrorAmountIsZero())
                e.Cancel = ShowErrorAmountIsZero();
            else
                e.Cancel = ShowErrorAmountExceeds();
        }

        private void nudAmount_Validated(object sender, EventArgs e)
        {
            Helper.ClearErrorNumericUpDown(epAmount, nudAmount);
        }



        private void ucObligationRequest_Load(object sender, EventArgs e)
        {
            if (!DesignMode)
            {
                LoadAccounts();
                GetTotalAllotmentRelease();
                GetTotalAllotmentBalance();
            }
        }
    }
}
