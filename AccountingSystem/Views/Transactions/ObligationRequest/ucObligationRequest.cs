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

        public ucObligationRequest()
        {
            InitializeComponent();
        }


        private void GetTotalAllotmentRelease()
        {
            int accountId = Convert.ToInt32(cmbxAccount.SelectedValue);

            decimal  totalAllotmentRelease = Factory.AllotmentReleaseRepository().GetTotalAllotmentReleaseByDateYear(fundId, fppId, otherFPPId, allotmentClassId, accountId, dateRequested ,Convert.ToInt16(dateRequested.Year));

            txtAllotmentAmount.Text = totalAllotmentRelease.ToString("N2");
            
        }

        private void GetTotalAllotmentBalance() 
        {
            int accountId = Convert.ToInt32(cmbxAccount.SelectedValue);

            decimal totalAllotmentReleaseByYear = Factory.AllotmentReleaseRepository().GetTotalAllotmentReleaseByYear(fundId, fppId, otherFPPId, allotmentClassId, accountId, Convert.ToInt16(dateRequested.Year));

            decimal totalAllotmentReleaseByDate = Factory.AllotmentReleaseRepository().GetTotalAllotmentReleaseByDateYear(fundId, fppId, otherFPPId, allotmentClassId, accountId, dateRequested, Convert.ToInt16(dateRequested.Year));

            decimal totalObligations = Factory.ObligationRequestRepository().TotalObligationRequestByYear(fundId, fppId, otherFPPId, allotmentClassId, Convert.ToInt16(dateRequested.Year));

            decimal totalAllotmentReleaseBalanceByYear = totalAllotmentReleaseByYear - totalObligations;

            decimal finalAllotmentReleaseBalance = totalAllotmentReleaseBalanceByYear > totalAllotmentReleaseByDate ? totalAllotmentReleaseByDate : totalAllotmentReleaseBalanceByYear;

            txtBalance.Text = finalAllotmentReleaseBalance.ToString("N2");

            txtAllotmentAmount.Text = totalAllotmentReleaseByDate.ToString("N2");

            //decimal totalObligations = Factory.ObligationAccountRepository().
        }

        private void LoadAccounts()
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
            if (AccountNameNotExist() || string.IsNullOrEmpty(cmbxAccount.Text))
                txtAllotmentAmount.Text = "0.00";

        }

        private bool AccountNameNotExist()
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

        private void cmbxAccount_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrEmpty(cmbxAccount.Text))
                e.Cancel = Helper.ShowErrorComboBoxEmpty(epAccount, cmbxAccount, "Account");
            else if (AccountNameNotExist())
                e.Cancel = AccountNameNotExist();
        }

        private void cmbxAccount_Validated(object sender, EventArgs e)
        {
            Helper.ClearErrorComboBox(epAccount, cmbxAccount);
        }



        private bool AmountIsZero() 
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

        private void nudAmount_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrEmpty(nudAmount.Text))
                e.Cancel = Helper.ShowErrorNumericUpDownEmpty(epAmount, nudAmount, "Amount");
            else if (AmountIsZero())
                e.Cancel = AmountIsZero();
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
    }
}
