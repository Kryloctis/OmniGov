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
        internal int aroId;
        internal int fppID;
        internal int? othersFPPId;
        internal int allotmentClassId;
        internal int fundId;
        internal short year;
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

        internal string GetFormErrors()
        {
            var errorArray = new string[3];
            errorArray[0] = epAccount.GetError(cmbxAccount);
            errorArray[1] = epAmount.GetError(nudAmount);
            errorArray[2] = AllotmentReleaseExist() ? Tag.ToString() : string.Empty;

            return Factory.CreateErrors(errorArray).GenerateErrorMessage();
        }

        private void DisplayBudgetAppropriationsDetails()
        {
            try
            {
                int generalLedgerAccountId = Convert.ToInt32(cmbxAccount.SelectedValue);

                var budgetAppropriationRepo = Factory.BudgetAppropriationsRepository().GetViewRecord(fppID, othersFPPId, fundId, allotmentClassId, generalLedgerAccountId, dateIssued, year);

                decimal appropriationAmount = budgetAppropriationRepo.Count == 0 ? 0 : Convert.ToDecimal(budgetAppropriationRepo["amount"]);

                decimal supplementalAppropriationAmount = budgetAppropriationRepo.Count == 0 ? 0 : Factory.SupplementalAppropriationsRepository().GetTotalSupplementalAmountByIdAndDateEntry(Convert.ToInt32(budgetAppropriationRepo["id"]), dateIssued);

                decimal totalAllotmentReleaseAmount = budgetAppropriationRepo.Count == 0 ? 0 : Factory.AllotmentReleaseRepository().GetViewTotalAllotmentReleaseAmountById(Convert.ToInt32(budgetAppropriationRepo["id"]));


                decimal totalAppropriation = appropriationAmount + supplementalAppropriationAmount;

                decimal appropriationBalance = totalAppropriation - totalAllotmentReleaseAmount;

                txtAppropriation.Text = totalAppropriation.ToString("N2");
                txtBalance.Text = appropriationBalance.ToString("N2");

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
                int budgetAppropriationId = Convert.ToInt32(cmbxAccount.SelectedValue);
                DateTime dateIssued = ucAllotmentMain.dtDateIssued.Value;

                var allotmentReleaseExist = Factory.AllotmentReleaseRepository().allotmentReleaseExist(budgetAppropriationId, dateIssued.ToString("yyyy-MM-dd"));

                if (allotmentReleaseExist)
                {
                    Tag = "Allotment Release already exist on the date it was issued.";
                    return true;
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
                    epAccount.SetError(cmbxAccount, "Account you entered. Doesn't exist in your record.");
                    return false;
                }
            }
            catch (Exception ex)
            {
                Helper.MessageBoxError(ex.Message);
            }
            return true;
        }

        private void cmbxAccount_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrEmpty(cmbxAccount.Text))
                e.Cancel = Helper.ShowErrorComboBoxEmpty(epAccount, cmbxAccount, "Account.");
            else if (!ShowErrorAccountNotExist())
                e.Cancel = !ShowErrorAccountNotExist();
            //else
            //    e.Cancel = ShowErrorAppropriationExistOnList();
        }

        private void cmbxAccount_Validated(object sender, EventArgs e)
        {
            Helper.ClearErrorComboBox(epAccount, cmbxAccount);
        }


        private bool ShowErrorAmountExceeds(ErrorProvider ep, NumericUpDown numericUpDown)
        {
            try
            {
                int generalLedgerAccountId = Convert.ToInt32(cmbxAccount.SelectedValue);

                var budgetAppropriationRepo = Factory.BudgetAppropriationsRepository().GetViewRecord(fppID, othersFPPId, fundId, allotmentClassId, generalLedgerAccountId, dateIssued, year);

                decimal appropriationAmount = budgetAppropriationRepo.Count == 0 ? 0 : Convert.ToDecimal(budgetAppropriationRepo["amount"]);

                decimal supplementalAppropriationAmount = budgetAppropriationRepo.Count == 0 ? 0 : Factory.SupplementalAppropriationsRepository().GetTotalSupplementalAmountByIdAndDateEntry(Convert.ToInt32(budgetAppropriationRepo["id"]), dateIssued);

                decimal totalAllotmentReleaseAmount = budgetAppropriationRepo.Count == 0 ? 0 : Factory.AllotmentReleaseRepository().GetViewTotalAllotmentReleaseAmountById(Convert.ToInt32(budgetAppropriationRepo["id"]));


                decimal totalAppropriation = appropriationAmount + supplementalAppropriationAmount;

                decimal appropriationBalance = totalAppropriation - totalAllotmentReleaseAmount;

                if (aroId == 0)
                {
                    if (numericUpDown.Value > appropriationBalance)
                    {
                        ep.SetError(numericUpDown, "The amount you entered exceeds the appropriate balance.");
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
            }
        }
    }
}
