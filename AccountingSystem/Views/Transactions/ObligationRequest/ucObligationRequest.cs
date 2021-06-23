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

        internal int _budgetAppropriationsId = 0;
        internal decimal _amount = 0;

        public ucObligationRequest()
        {
            InitializeComponent();
        }

        private decimal GetCurrentBalance() 
        {
            decimal currentBalance = 0;
            
            decimal currentAmount = nudAmount.Value;
            decimal unobligatedBalance = GetAllotmentReleaseBalance();

            currentBalance = unobligatedBalance - currentAmount;

            return currentBalance < 0? 0 : currentBalance;
        }

        internal void LoadSelected()
        {

        }

        internal void LoadReferences(ucObligationRequestMain ucObligationRequestMain)
        {
            _ucObligationRequestMain = ucObligationRequestMain;
        }

        internal string GetFormErrors()
        {
            var errorArray = new string[2];
            errorArray[0] = epObjectOfExpenditure.GetError(cmbxObjectOfExpenditure);
            errorArray[1] = epAmount.GetError(nudAmount);

            IError _errors = Factory.CreateErrors(errorArray);
            return _errors.GenerateErrorMessage();
        }

        internal void ResetForm()
        {
            LoadObjectOfExpenditures();
            cmbxObjectOfExpenditure.SelectedIndex = -1;
            cmbxObjectOfExpenditure.Text = string.Empty;
            nudAmount.Value = 0;
        }


        private void ucObligationRequest_Load(object sender, EventArgs e)
        {
            if (!DesignMode)
            {
                LoadObjectOfExpenditures();
                txtUnobligatedBalance.Text = GetAllotmentReleaseBalance().ToString("N2");
                txtRemainingBalance.Text = GetCurrentBalance().ToString("N2");
            }
        }


        private void nudAmount_ValueChanged(object sender, EventArgs e)
        {
            txtRemainingBalance.Text = GetCurrentBalance().ToString("N2");
        }



        //OBJECT OF EXPENDITURE COMBOBOX

        private DataTable DatatableObjectOfExpenditures()
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

            string searchTxt = cmbxObjectOfExpenditure.Text.Trim();

            if (string.IsNullOrEmpty(cmbxObjectOfExpenditure.Text))
                dtBudgetAppropriation = Factory.BudgetAppropriationsRepository().GetViewRecordsByIds(budgetAppropriationsModel);
            else
                dtBudgetAppropriation = Factory.BudgetAppropriationsRepository().GetViewRecordsByIdsSearch(budgetAppropriationsModel, searchTxt);


            return dtBudgetAppropriation;
        }

        private void LoadObjectOfExpenditures()
        {
            try
            {
                cmbxObjectOfExpenditure.DroppedDown = false;
                Cursor.Current = Cursors.Default;

                if (DatatableObjectOfExpenditures().Rows.Count == 0) return;

                var accountDict = new Dictionary<int, string>();
                foreach (DataRow item in DatatableObjectOfExpenditures().Rows)
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

                cmbxObjectOfExpenditure.DataSource = accountDict.Count == 0 ? null : new BindingSource(accountDict, null);
                cmbxObjectOfExpenditure.DisplayMember = "value";
                cmbxObjectOfExpenditure.ValueMember = "key";


                cmbxObjectOfExpenditure.TextChanged -= new EventHandler(CmbxObjectOfExpenditure_TextChanged);
                cmbxObjectOfExpenditure.SelectedValue = _budgetAppropriationsId;
                cmbxObjectOfExpenditure.TextChanged += new EventHandler(CmbxObjectOfExpenditure_TextChanged);
                cmbxObjectOfExpenditure.SelectedValueChanged += new EventHandler(cmbxObjectOfExpenditure_SelectedValueChanged);
            }
            catch (Exception ex)
            {
                Helper.MessageBoxError(ex.StackTrace);
            }

        }

        private void cmbxObjectOfExpenditure_SelectedValueChanged(object sender, EventArgs e)
        {
            txtUnobligatedBalance.Text = GetAllotmentReleaseBalance().ToString("N2");
            txtRemainingBalance.Text = GetCurrentBalance().ToString("N2");
        }

        private decimal GetAllotmentReleaseBalance()
        {
            decimal allotmentReleaseBalance = 0;

            if (cmbxObjectOfExpenditure.SelectedIndex > -1)
            {
                int budgetAppropriationId = Convert.ToInt32(cmbxObjectOfExpenditure.SelectedValue);
                var dtAllotmentRelease = Factory.AllotmentReleaseRepository().GetViewRecordsByBudgetAppropriationId(budgetAppropriationId);

                decimal totalAllotmentRelease = Convert.ToDecimal(dtAllotmentRelease.Rows.Count == 0 ? 0 : dtAllotmentRelease.Compute("Sum(amount)", string.Empty));

                allotmentReleaseBalance = totalAllotmentRelease;
            }

            return allotmentReleaseBalance;
        }

        private void CmbxObjectOfExpenditure_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(cmbxObjectOfExpenditure.Text))
            {
                LoadObjectOfExpenditures();
            }
        }

        private void cmbxObjectOfExpenditure_KeyDown(object sender, KeyEventArgs e)
        {
            string searchTxt = cmbxObjectOfExpenditure.Text;

            if (e.KeyCode == Keys.F1 && cmbxObjectOfExpenditure.FindStringExact(searchTxt) == -1 && !string.IsNullOrEmpty(searchTxt))
            {
                LoadObjectOfExpenditures();
                cmbxObjectOfExpenditure.SelectedIndex = 0;
                cmbxObjectOfExpenditure.DroppedDown = true;
            }
        }



        //VALIDATIONS

        private bool ShowErrorObjectExpenditureNotExist()
        {
            try
            {
                if (cmbxObjectOfExpenditure.FindStringExact(cmbxObjectOfExpenditure.Text) < 0 && !string.IsNullOrEmpty(cmbxObjectOfExpenditure.Text))
                {
                    epObjectOfExpenditure.SetError(cmbxObjectOfExpenditure, "Object of Expenditure you entered doesn't exist on your record.");
                    return true;
                }
            }
            catch (Exception ex)
            {
                Helper.MessageBoxError(ex.Message);
            }
            return false;
        }

        private bool ShowErrorObjectExpenditureExistOnList() 
        {
            try
            {
                foreach (DataGridViewRow item in _ucObligationRequestMain.dgObligationRequests.Rows) 
                {
                    int budgetAppriationId = Convert.ToInt32(cmbxObjectOfExpenditure.SelectedValue);
                    int rowBudgetAppropriationId = Convert.ToInt32(item.Cells["budget_appropriation_id"].Value);


                    if (budgetAppriationId == rowBudgetAppropriationId && _ucObligationRequestMain.obligationRequestId == 0 && rowBudgetAppropriationId  != _budgetAppropriationsId) 
                    {
                        epObjectOfExpenditure.SetError(cmbxObjectOfExpenditure, "Object of Expenditure already exist on the List");
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

        private void cmbxObjectOfExpenditure_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrEmpty(cmbxObjectOfExpenditure.Text))
                e.Cancel = Helper.ShowErrorComboBoxEmpty(epObjectOfExpenditure, cmbxObjectOfExpenditure, "Object of Expenditure.");
            else if (ShowErrorObjectExpenditureNotExist())
                e.Cancel = ShowErrorObjectExpenditureNotExist();
            else
                e.Cancel = ShowErrorObjectExpenditureExistOnList();
        }

        private void cmbxObjectOfExpenditure_Validated(object sender, EventArgs e)
        {
            Helper.ClearErrorComboBox(epObjectOfExpenditure, cmbxObjectOfExpenditure);
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
                if (nudAmount.Value > GetAllotmentReleaseBalance())
                {
                    epAmount.SetError(nudAmount, "Amount you entered exceeds the unobligated balance.");
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
