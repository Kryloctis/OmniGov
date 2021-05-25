using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AccountingSystem.Views.Manage.AllotmentRelease
{
    public partial class ucAllotmentRelease : UserControl
    {
        internal int fppID;
        internal int? othersFPPId;
        internal int allotmentClassId;
        internal int fundId;
        internal DateTime dateIssued;
        private ucAllotmentReleaseMain ucAllotmentMain;

        public ucAllotmentRelease()
        {
            InitializeComponent();
        }

        internal void LoadReference(ucAllotmentReleaseMain ucAllotmentReleaseMain)
        {
            ucAllotmentMain = ucAllotmentReleaseMain;
        }

        internal void ResetForm() 
        {
            LoadAccounts();
            DisplayBudgetAppropriationsDetails();
            nudAmount.Value = 0;
        }

        internal string GetFormErrors()
        {
            var errorArray = new string[2];
            errorArray[0] = epAccount.GetError(cmbxAccount);
            errorArray[1] = epAmount.GetError(nudAmount);

            return Factory.CreateErrors(errorArray).GenerateErrorMessage();
        }

        private Dictionary<string, decimal> ShowAmounts() 
        {
           
            short year = Convert.ToInt16(nudYear.Value);

            int generalLedgerAccountId = Convert.ToInt32(cmbxAccount.SelectedValue);

            var budgetAppropriationRepo = Factory.BudgetAppropriationsRepository().GetViewRecord(fppID, othersFPPId, fundId, allotmentClassId, generalLedgerAccountId, dateIssued, year);

            decimal appropriationAmount = budgetAppropriationRepo.Count == 0 || (Convert.ToByte(budgetAppropriationRepo["continuing"]) == 0 && dateIssued.Year > year) ? 0 : Convert.ToDecimal(budgetAppropriationRepo["amount"]);

            decimal supplementalAppropriationAmount = budgetAppropriationRepo.Count == 0 || (Convert.ToByte(budgetAppropriationRepo["continuing"]) == 0 && dateIssued.Year > year) ? 0 : Factory.SupplementalAppropriationsRepository().GetTotalSupplementalAmountByIdAndDateEntry(Convert.ToInt32(budgetAppropriationRepo["id"]), dateIssued);

            decimal totalAllotmentReleaseAmount = budgetAppropriationRepo.Count == 0 || (Convert.ToByte(budgetAppropriationRepo["continuing"]) == 0 && dateIssued.Year > year) ? 0 : Factory.AllotmentReleaseRepository().GetViewTotalAllotmentReleaseAmountById(Convert.ToInt32(budgetAppropriationRepo["id"]));


            decimal totalAppropriation = appropriationAmount + supplementalAppropriationAmount;

            decimal appropriationBalance = totalAppropriation - totalAllotmentReleaseAmount;

            var record = new Dictionary<string, decimal>()
            {
                {"totalAppropriation", totalAppropriation},
                {"appropriationBalance", appropriationBalance}
            };

            return record;
        }

        private void DisplayBudgetAppropriationsDetails()
        {
            try
            {
                txtAppropriation.Text = ShowAmounts()["totalAppropriation"].ToString("N2");
                txtBalance.Text = ShowAmounts()["appropriationBalance"].ToString("N2");
            }
            catch (Exception ex)
            {
                Helper.MessageBoxError(ex.Message);
            }
        }

        internal bool AllotmentReleaseExist()
        {
            try
            {

                short year = (short)nudYear.Value;

                int generalLedgerAccountId = Convert.ToInt32(cmbxAccount.SelectedValue);

                var budgetAppropriationRepo = Factory.BudgetAppropriationsRepository().GetViewRecord(fppID, othersFPPId, fundId, allotmentClassId, generalLedgerAccountId, dateIssued, year);

                if (budgetAppropriationRepo.Count > 0)
                {
                    int budgetAppropriationId = Convert.ToInt32(budgetAppropriationRepo["id"]);


                    var allotmentReleaseExist = Factory.AllotmentReleaseRepository().allotmentReleaseExist(budgetAppropriationId, dateIssued.ToString("yyyy-MM-dd"));

                    if (allotmentReleaseExist)
                    {
                        epAccount.SetError(cmbxAccount, "Account you entered has a allotment Release already exist on the date it was issued.");
                        return true;
                    }
                }
                else
                    return false;

            }
            catch (Exception ex)
            {
                Helper.MessageBoxError(ex.Message);
            }
            return false;
        }

        internal bool AccountExistOnList() 
        {
            try
            {
                int accountId = Convert.ToInt32(cmbxAccount.SelectedValue);

                foreach (DataGridViewRow item in ucAllotmentMain.dgAllotmentRelease.Rows) 
                {
                    if (Convert.ToInt32(item.Cells["account_id"].Value) == accountId) 
                    {
                        epAccount.SetError(cmbxAccount, "Can't add account to the list. Account you entered was already on the List.");
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


        private void LoadAccounts()
        {
            try
            {
                cmbxAccount.DataSource = null;

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

                Helper.ClearErrorComboBox(epAccount, cmbxAccount);
            }
            catch (Exception ex)
            {
                Helper.MessageBoxError(ex.Message);
            }
        }

        private void nudYear_ValueChanged(object sender, EventArgs e)
        {
            DisplayBudgetAppropriationsDetails();
        }

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
                    DisplayBudgetAppropriationsDetails();

                    Helper.ClearErrorComboBox(epAccount, cmbxAccount);
                }
                catch (Exception ex)
                {
                    Helper.MessageBoxError(ex.Message);
                }
            }
        }

        private void cmbxAccount_SelectionChangeCommitted(object sender, EventArgs e)
        {
            DisplayBudgetAppropriationsDetails();
        }

        private bool ShowErrorAccountNotExist()
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
                e.Cancel = Helper.ShowErrorComboBoxEmpty(epAccount, cmbxAccount, "Account.");
            else if (ShowErrorAccountNotExist())
                e.Cancel = ShowErrorAccountNotExist();
            else if (AllotmentReleaseExist())
                e.Cancel = AllotmentReleaseExist();
            else
                e.Cancel = AccountExistOnList();
        }

        private void cmbxAccount_Validated(object sender, EventArgs e)
        {
            Helper.ClearErrorComboBox(epAccount, cmbxAccount);
        }


        private bool ShowErrorAmountExceeds(ErrorProvider ep, NumericUpDown numericUpDown)
        {
            try
            {
                if (numericUpDown.Value > ShowAmounts()["appropriationBalance"])
                {
                    ep.SetError(numericUpDown, "The amount you entered exceeds the appropriate balance.");
                    return true;
                }

            }
            catch (Exception ex)
            {
                Helper.MessageBoxError(ex.Message);
            }
            return false;
        }

        private bool ShowErrorAmountIsZero(ErrorProvider ep, NumericUpDown numericUpDown)
        {
            try
            {
                if (numericUpDown.Value == 0)
                {
                    ep.SetError(numericUpDown, "Valuable Amount is required.");
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
                e.Cancel = Helper.ShowErrorNumericUpDownEmpty(epAmount, nudAmount);
            else if (nudAmount.Value == 0)
                e.Cancel = ShowErrorAmountIsZero(epAmount, nudAmount);
            else
                e.Cancel = ShowErrorAmountExceeds(epAmount, nudAmount);
        }

        private void nudAmount_Validated(object sender, EventArgs e)
        {
            Helper.ClearErrorNumericUpDown(epAmount, nudAmount);
        }

        private void ucAllotmentRelease_Load(object sender, EventArgs e)
        {
            if (!DesignMode)
            {
                LoadAccounts();
                nudYear.Value = DateTime.Now.Year;
            }
        }

    }
}
