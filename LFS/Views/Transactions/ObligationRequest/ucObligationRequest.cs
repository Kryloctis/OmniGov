using ACC.Data;
using ACC.Domain.Interfaces;
using ACC.Domain.Models;
using LFS;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Windows.Forms;

namespace LFS.Views.Transactions.ObligationRequest
{
    public partial class ucObligationRequest : UserControl
    {
        internal int fppId;
        internal int fundId;
        internal int allotmentClassId;
        internal DateTime dateRequested;
        private ucObligationRequestMain _ucObligationRequestMain;

        internal int? _subFPPId = null;
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

            return currentBalance < 0 ? 0 : currentBalance;
        }

        private decimal GetAllotmentReleaseBalance()
        {
            decimal allotmentReleaseBalance = 0;

            try
            {
                if (cmbxObjectOfExpenditure.SelectedIndex > -1)
                {
                    int budgetAppropriationId = Convert.ToInt32(cmbxObjectOfExpenditure.SelectedValue);
                    var dtAllotmentRelease = AccFactory.AllotmentReleaseRepository().GetViewRecordsByBudgetAppropriationIdDateIssued(budgetAppropriationId, dateRequested);

                    decimal totalAllotmentRelease = Convert.ToDecimal(dtAllotmentRelease.Rows.Count == 0 ? 0 : dtAllotmentRelease.Compute("Sum(amount)", string.Empty));
                    decimal totalObligations = AccFactory.ObligationRequestRepository().GetSumObligationsByBudgetAppropriationAndStatus(budgetAppropriationId);

                    allotmentReleaseBalance = (totalAllotmentRelease - totalObligations) + (budgetAppropriationId == _budgetAppropriationsId ? _amount : 0);
                }
            }
            catch (Exception ex)
            {
                Helper.MessageBoxError(ex.StackTrace);
            }

            return allotmentReleaseBalance < 0 ? 0 : allotmentReleaseBalance;
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

            IError _errors = AccFactory.CreateErrors(errorArray);
            return _errors.GenerateErrorMessage();
        }

        internal void ResetForm()
        {
            _subFPPId = null;
            _budgetAppropriationsId = 0;
            _amount = 0;
            nudAmount.Value = _amount;

            cmbxSubFPP.Text = string.Empty;
            cmbxSubFPP.SelectedValue = _subFPPId == null ? 0 : _subFPPId;

            LoadObjectOfExpendituresCombobox();
        }

        private void ucObligationRequest_Load(object sender, EventArgs e)
        {
            if (!DesignMode)
            {
                //SUB FPP
                LoadSubFPPCombobox();

                txtUnobligatedBalance.Text = GetAllotmentReleaseBalance().ToString("N2");
                txtRemainingBalance.Text = GetCurrentBalance().ToString("N2");
            }
        }

        private void nudAmount_ValueChanged(object sender, EventArgs e)
        {
            txtRemainingBalance.Text = GetCurrentBalance().ToString("N2");
        }

        #region SUB FPP COMBOBOX

        private DataTable DataTableSubFPP()
        {
            DataTable dtSubFPP;

            if (string.IsNullOrWhiteSpace(cmbxSubFPP.Text))
                dtSubFPP = AccFactory.SubFPPRepository().GetRecordsByFppId(fppId);
            else
                dtSubFPP = AccFactory.SubFPPRepository().GetRecordsByFPPIdCodeName(fppId, cmbxSubFPP.Text);

            return dtSubFPP;
        }

        private void LoadSubFPP()
        {
            try
            {
                cmbxSubFPP.DroppedDown = false;
                Cursor.Current = Cursors.Default;
                LoadObjectOfExpendituresCombobox();

                var subFPPDict = new Dictionary<int, string>();
                foreach (DataRow item in DataTableSubFPP().Rows)
                {
                    int subFPPId = Convert.ToInt32(item["id"]);
                    string subFPPName = $"{item["others_fpp_code"]} - {item["name"]}";

                    subFPPDict.Add(subFPPId, subFPPName);
                }

                cmbxSubFPP.DataSource = DataTableSubFPP().Rows.Count == 0 ? null : new BindingSource(subFPPDict, null);
                cmbxSubFPP.DisplayMember = "value";
                cmbxSubFPP.ValueMember = "key";
            }
            catch (Exception ex)
            {
                Helper.MessageBoxError(ex.Message);
            }
        }

        private void LoadSubFPPCombobox()
        {
            LoadSubFPP();
            cmbxSubFPP.TextChanged -= new EventHandler(cmbxSubFPP_TextChanged);
            cmbxSubFPP.Text = string.Empty;
            cmbxSubFPP.SelectedIndex = -1;
            cmbxSubFPP.TextChanged += new EventHandler(cmbxSubFPP_TextChanged);
            cmbxSubFPP.SelectedValueChanged += new EventHandler(cmbxSubFPP_SelectedValueChanged);
            cmbxSubFPP.SelectedValue = _subFPPId == null ? 0 : _subFPPId;
        }

        private void cmbxSubFPP_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(cmbxSubFPP.Text)) LoadSubFPPCombobox();
        }

        private void cmbxSubFPP_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F1 && cmbxSubFPP.FindStringExact(cmbxSubFPP.Text) == -1 && !string.IsNullOrEmpty(cmbxSubFPP.Text))
            {
                LoadSubFPP();
                cmbxSubFPP.DroppedDown = true;
            }
        }

        private void cmbxSubFPP_SelectedValueChanged(object sender, EventArgs e)
        {
            LoadObjectOfExpendituresCombobox();
        }

        #endregion SUB FPP COMBOBOX

        #region OBJECT OF EXPENDITURES COMBOBOX

        private DataTable DatatableObjectOfExpenditures()
        {
            var dtBudgetAppropriation = new DataTable();
            int subFPPId = Convert.ToInt32(cmbxSubFPP.SelectedValue);

            var budgetAppropriationsModel = new BudgetAppropriationsModel()
            {
                FunctionProgramProjectId = fppId,
                OthersFPPId = string.IsNullOrWhiteSpace(cmbxSubFPP.Text) ? null : subFPPId,
                AllotmentClassesId = allotmentClassId,
                FundsId = fundId,
                Year = Convert.ToInt16(dateRequested.Year)
            };

            string searchTxt = cmbxObjectOfExpenditure.Text.Trim();

            if (string.IsNullOrEmpty(cmbxObjectOfExpenditure.Text))
                dtBudgetAppropriation = AccFactory.BudgetAppropriationsRepository().GetViewRecordsByIds(budgetAppropriationsModel);
            else
                dtBudgetAppropriation = AccFactory.BudgetAppropriationsRepository().GetViewRecordsByIdsSearch(budgetAppropriationsModel, searchTxt);

            return dtBudgetAppropriation;
        }

        private void LoadObjectOfExpenditures()
        {
            try
            {
                cmbxObjectOfExpenditure.DroppedDown = false;
                Cursor.Current = Cursors.Default;

                var objectOfExependituresDict = new Dictionary<int, string>();
                foreach (DataRow item in DatatableObjectOfExpenditures().Rows)
                {
                    string remarks = string.IsNullOrEmpty(item["remarks"].ToString()) ? string.Empty : $"({item["remarks"]})";
                    int appropriationId = Convert.ToInt32(item["id"]);
                    string appropriationName = $"{item["account_code"]} - {item["general_ledger_accounts_name"]} {remarks}";

                    bool isContinuing = Convert.ToByte(item["continuing"]) == 1 ? true : false;
                    short year = Convert.ToInt16(item["year"]);

                    if (!isContinuing && year == dateRequested.Year)
                        objectOfExependituresDict.Add(appropriationId, appropriationName);
                    else if (isContinuing && year <= dateRequested.Year)
                        objectOfExependituresDict.Add(appropriationId, appropriationName);
                }

                var dataSource = objectOfExependituresDict.Count == 0 ? null : new BindingSource(objectOfExependituresDict, null);

                cmbxObjectOfExpenditure.DataSource = dataSource;
                cmbxObjectOfExpenditure.DisplayMember = "value";
                cmbxObjectOfExpenditure.ValueMember = "key";
            }
            catch (Exception ex)
            {
                Helper.MessageBoxError(ex.Message);
            }
        }

        internal void LoadObjectOfExpendituresCombobox()
        {
            cmbxObjectOfExpenditure.Text = string.Empty;
            LoadObjectOfExpenditures();
            cmbxObjectOfExpenditure.TextChanged -= new EventHandler(CmbxObjectOfExpenditure_TextChanged);
            cmbxObjectOfExpenditure.Text = string.Empty;

            cmbxObjectOfExpenditure.SelectedIndex = -1;
            epObjectOfExpenditure.SetError(cmbxSubFPP, string.Empty);
            cmbxObjectOfExpenditure.TextChanged += new EventHandler(CmbxObjectOfExpenditure_TextChanged);
            cmbxObjectOfExpenditure.SelectedValueChanged += new EventHandler(cmbxObjectOfExpenditure_SelectedValueChanged);
            cmbxObjectOfExpenditure.Enabled = true;
            cmbxObjectOfExpenditure.SelectedValue = _budgetAppropriationsId;
        }

        private void cmbxObjectOfExpenditure_SelectedValueChanged(object sender, EventArgs e)
        {
            txtUnobligatedBalance.Text = GetAllotmentReleaseBalance().ToString("N2");
            txtRemainingBalance.Text = GetCurrentBalance().ToString("N2");
        }

        private void CmbxObjectOfExpenditure_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(cmbxObjectOfExpenditure.Text)) LoadObjectOfExpendituresCombobox();
        }

        private void cmbxObjectOfExpenditure_KeyDown(object sender, KeyEventArgs e)
        {
            string searchTxt = cmbxObjectOfExpenditure.Text;

            if (e.KeyCode == Keys.F1 && cmbxObjectOfExpenditure.FindStringExact(searchTxt) == -1 && !string.IsNullOrEmpty(searchTxt))
            {
                LoadObjectOfExpenditures();
                cmbxObjectOfExpenditure.SelectedIndex = cmbxObjectOfExpenditure.Items.Count == 0 ? -1 : 0;
                cmbxObjectOfExpenditure.DroppedDown = true;
            }
        }

        #endregion OBJECT OF EXPENDITURES COMBOBOX

        #region VALIDATIONS

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

                    if (_ucObligationRequestMain.obligationRequestId == 0)
                    {
                        if (budgetAppriationId == rowBudgetAppropriationId)
                        {
                            epObjectOfExpenditure.SetError(cmbxObjectOfExpenditure, "Object of Expenditure already exist on the List");
                            return true;
                        }
                    }
                    else
                    {
                        if (budgetAppriationId == rowBudgetAppropriationId && rowBudgetAppropriationId != _budgetAppropriationsId)
                        {
                            epObjectOfExpenditure.SetError(cmbxObjectOfExpenditure, "Object of Expenditure already exist on the List");
                            return true;
                        }
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

        #endregion VALIDATIONS
    }
}