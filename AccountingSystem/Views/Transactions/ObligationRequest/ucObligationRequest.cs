using ACC.Domain.Interfaces;
using ACC.Domain.Models;
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
        internal int? subFPPId;
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


        //ACCOUNT COMBOBOX

        private DataTable DatatableBudgetAppropriations()
        {
            var dtBudgetAppropriation = new DataTable();

            var budgetAppropriationsModel = new BudgetAppropriationsModel()
            {
                FunctionProgramProjectId = fppId,
                OthersFPPId = subFPPId,
                AllotmentClassesId = allotmentClassId,
                FundsId = fundId,
                Year = Convert.ToInt16(dateRequested.Year)
            };

            string searchTxt = cmbxBudgetAppropriations.Text.Trim();

            if (string.IsNullOrEmpty(cmbxBudgetAppropriations.Text))
                dtBudgetAppropriation = Factory.BudgetAppropriationsRepository().GetViewRecordsByIds(budgetAppropriationsModel);
            else
                dtBudgetAppropriation = Factory.BudgetAppropriationsRepository().GetViewRecordsByIdsSearch(budgetAppropriationsModel, searchTxt);


            return dtBudgetAppropriation;
        }

        private void LoadBudgetAppropriations()
        {
            try
            {
                cmbxBudgetAppropriations.DroppedDown = false;
                Cursor.Current = Cursors.Default;

                if (DatatableBudgetAppropriations().Rows.Count == 0) return;

                var accountDict = new Dictionary<int, string>();
                foreach (DataRow item in DatatableBudgetAppropriations().Rows)
                {
                    int accountId = Convert.ToInt32(item["id"]);
                    string remarks = string.IsNullOrEmpty(item["remarks"].ToString()) ? string.Empty : $"({item["remarks"]})";
                    string accountName = $"{item["account_code"]} - {item["general_ledger_accounts_name"]} {remarks}";
                    bool isContinuing = Convert.ToByte(item["continuing"]) == 1 ? true : false;
                    short year = Convert.ToInt16(item["year"]);

                    if (!isContinuing && year == dateRequested.Year)
                        accountDict.Add(accountId, accountName);
                    else if (isContinuing && year <= dateRequested.Year)
                        accountDict.Add(accountId, accountName);
                }

                cmbxBudgetAppropriations.DataSource = accountDict.Count == 0 ? null : new BindingSource(accountDict, null);
                cmbxBudgetAppropriations.DisplayMember = "value";
                cmbxBudgetAppropriations.ValueMember = "key";


                cmbxBudgetAppropriations.TextChanged -= new EventHandler(CmbxLedgerAccout_TextChanged);
                cmbxBudgetAppropriations.SelectedIndex = -1;
                cmbxBudgetAppropriations.TextChanged += new EventHandler(CmbxLedgerAccout_TextChanged);
                cmbxBudgetAppropriations.SelectedValueChanged += new EventHandler(cmbxBudgetAppropriations_SelectedValueChanged);

            }
            catch (Exception ex)
            {
                Helper.MessageBoxError(ex.StackTrace);
            }

        }

        private void cmbxBudgetAppropriations_SelectedValueChanged(object sender, EventArgs e)
        {
            txtUnobligatedBalance.Text = GetBudgetAppropriationBalance().ToString("N2");
        }

        private decimal GetBudgetAppropriationBalance()
        {
            decimal appropriationBalance = 0;

            if (cmbxBudgetAppropriations.SelectedIndex > -1)
            {
                int budgetAppropriationId = Convert.ToInt32(cmbxBudgetAppropriations.SelectedValue);
                var budgetAppropriationDict = Factory.BudgetAppropriationsRepository().GetRecordByID(budgetAppropriationId);
                var dtAllotmentRelease = Factory.AllotmentReleaseRepository().GetViewRecordsByBudgetAppropriationId(budgetAppropriationId);
                var dtSupplementalAppropriation = Factory.SupplementalAppropriationsRepository().GetRecordsByBudgetAppropriationId(budgetAppropriationId);

                decimal budgetAppropriation = Convert.ToDecimal(budgetAppropriationDict["amount"]);
                decimal totalAllotmentRelease = Convert.ToDecimal(dtAllotmentRelease.Rows.Count == 0 ? 0 : dtAllotmentRelease.Compute("Sum(amount)", string.Empty));
                decimal totalSupplementalAppropriation = Convert.ToDecimal(dtSupplementalAppropriation.Rows.Count == 0 ? 0 : dtSupplementalAppropriation.Compute("Sum(amount)", string.Empty));

                appropriationBalance = (budgetAppropriation + totalSupplementalAppropriation) - totalAllotmentRelease;

            }

            return appropriationBalance;
        }

        private void CmbxLedgerAccout_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(cmbxBudgetAppropriations.Text))
            {
                LoadBudgetAppropriations();
            }
        }

        private void cmbxBudgetAppropriations_KeyDown(object sender, KeyEventArgs e)
        {
            string searchTxt = cmbxBudgetAppropriations.Text;

            if (e.KeyCode == Keys.F1 && cmbxBudgetAppropriations.FindStringExact(searchTxt) == -1 && !string.IsNullOrEmpty(searchTxt))
            {
                LoadBudgetAppropriations();
                cmbxBudgetAppropriations.SelectedIndex = 0;
                cmbxBudgetAppropriations.DroppedDown = true;
            }
        }




        internal void LoadSelected()
        {
           cmbxBudgetAppropriations.SelectedValue = selectedAccountId;
        }

        internal void LoadReferences(ucObligationRequestMain ucObligationRequestMain) 
        {
            _ucObligationRequestMain = ucObligationRequestMain; 
        }

        internal string GetFormErrors()
        {
            var errorArray = new string[2];
            errorArray[0] = epAccount.GetError(cmbxBudgetAppropriations);
            errorArray[1] = epAmount.GetError(nudAmount);

            IError _errors = Factory.CreateErrors(errorArray);
            return _errors.GenerateErrorMessage();
        }

        internal void ResetForm() 
        {
            nudAmount.Value = 0;
        }


        private void ucObligationRequest_Load(object sender, EventArgs e)
        {
            if (!DesignMode)
            {
                LoadBudgetAppropriations();
            }
        }



        //VALIDATIONS

        private bool ShowErrorAccountNameNotExist()
        {
            try
            {
                if (cmbxBudgetAppropriations.FindStringExact(cmbxBudgetAppropriations.Text) < 0 && !string.IsNullOrEmpty(cmbxBudgetAppropriations.Text))
                {
                    epAccount.SetError(cmbxBudgetAppropriations, "Account you entered doesn't exist on your record.");
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
                foreach (DataGridViewRow item in _ucObligationRequestMain.dgObligationRequests.Rows) 
                {
                    int accountId = Convert.ToInt32(cmbxBudgetAppropriations.SelectedValue);
                    int rowAccountId = Convert.ToInt32(item.Cells["account_id"].Value);


                    if (accountId == rowAccountId && _ucObligationRequestMain.obligationRequestId == 0) 
                    {
                        epAccount.SetError(cmbxBudgetAppropriations, "Account already exist on the List");
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
            if (string.IsNullOrEmpty(cmbxBudgetAppropriations.Text))
                e.Cancel = Helper.ShowErrorComboBoxEmpty(epAccount, cmbxBudgetAppropriations, "Account");
            else if (ShowErrorAccountNameNotExist())
                e.Cancel = ShowErrorAccountNameNotExist();
            else
                e.Cancel = ShowErrorAccountExistOnList();
        }

        private void cmbxAccount_Validated(object sender, EventArgs e)
        {
            Helper.ClearErrorComboBox(epAccount, cmbxBudgetAppropriations);
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

    }
}
