using ACC.Domain.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Windows.Forms;

namespace AccountingSystem.Views.Manage.AllotmentRelease
{
    public partial class ucAllotmentRelease : UserControl
    {
        internal int fppId;
        internal int? othersFPPId;
        internal int allotmentClassId;
        internal int fundId;
        internal DateTime dateIssued;
        private ucAllotmentReleaseMain _ucAllotmentMain;

        internal int _budgetAppropriationId = 0;
        internal decimal _amount = 0;

        public ucAllotmentRelease()
        {
            InitializeComponent();
        }

        internal void LoadReference(ucAllotmentReleaseMain ucAllotmentReleaseMain)
        {
            _ucAllotmentMain = ucAllotmentReleaseMain;
        }

        private DataTable DatatableBudgetAppropriations()
        {
            var dtBudgetAppropriation = new DataTable();

            var budgetAppropriationsModel = new BudgetAppropriationsModel()
            {
                FunctionProgramProjectId = fppId,
                OthersFPPId = othersFPPId,
                AllotmentClassesId = allotmentClassId,
                FundsId = fundId,
                Year = Convert.ToInt16(nudYear.Value)
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

                    if (!isContinuing && year == nudYear.Value)
                        accountDict.Add(accountId, accountName);
                    else if (isContinuing && year <= nudYear.Value)
                        accountDict.Add(accountId, accountName);
                }

                cmbxBudgetAppropriations.DataSource = accountDict.Count == 0 ? null : new BindingSource(accountDict, null);
                cmbxBudgetAppropriations.DisplayMember = "value";
                cmbxBudgetAppropriations.ValueMember = "key";


                cmbxBudgetAppropriations.TextChanged -= new EventHandler(CmbxLedgerAccout_TextChanged);
                cmbxBudgetAppropriations.SelectedValue = _budgetAppropriationId;
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
            txtBalance.Text = GetBudgetAppropriationBalance().ToString("N2");
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

        private void nudYear_ValueChanged(object sender, EventArgs e)
        {
            cmbxBudgetAppropriations.Text = string.Empty;
            cmbxBudgetAppropriations.DataSource = null;
            LoadBudgetAppropriations();
            cmbxBudgetAppropriations.TextChanged -= new EventHandler(CmbxLedgerAccout_TextChanged);
            cmbxBudgetAppropriations.SelectedIndex = -1;
            cmbxBudgetAppropriations.TextChanged += new EventHandler(CmbxLedgerAccout_TextChanged);
        }

        internal string GetFormErrors()
        {
            var errorArray = new string[3];
            errorArray[0] = epYear.GetError(nudYear);
            errorArray[1] = epBudgetAppropriation.GetError(cmbxBudgetAppropriations);
            errorArray[2] = epAmount.GetError(nudAmount);

            return Factory.CreateErrors(errorArray).GenerateErrorMessage();
        }

        private void ucAllotmentRelease_Load(object sender, EventArgs e)
        {
            if (!DesignMode)
            {
                nudYear.Maximum = dateIssued.Year;
                nudYear.Value = dateIssued.Year;
                LoadBudgetAppropriations();
                txtBalance.Text = GetBudgetAppropriationBalance().ToString("N2");
            }
        }

        internal void ResetForm()
        {
            cmbxBudgetAppropriations.DataSource = null;
            LoadBudgetAppropriations();
            cmbxBudgetAppropriations.SelectedIndex = -1;
            cmbxBudgetAppropriations.Focus();
            nudAmount.Value = 0;
            _budgetAppropriationId = 0;
            _amount = 0;
        }

        private decimal GetBudgetAppropriationBalance()
        {
            decimal appropriationBalance = 0;

            try
            {
                if (cmbxBudgetAppropriations.SelectedIndex > -1)
                {
                    int budgetAppropriationId = Convert.ToInt32(cmbxBudgetAppropriations.SelectedValue);
                    var budgetAppropriationDict = Factory.BudgetAppropriationsRepository().GetViewRecordByIdDateEntry(budgetAppropriationId, dateIssued);
                    var dtAllotmentRelease = Factory.AllotmentReleaseRepository().GetViewRecordsByBudgetAppropriationId(budgetAppropriationId);
                    var dtSupplementalAppropriation = Factory.SupplementalAppropriationsRepository().GetRecordsByBudgetAppropriationIdDateEntry(budgetAppropriationId, dateIssued);

                    decimal budgetAppropriation = budgetAppropriationDict.Values.Count == 0 ? 0 : Convert.ToDecimal(budgetAppropriationDict["amount"]);
                    decimal totalAllotmentRelease = Convert.ToDecimal(dtAllotmentRelease.Rows.Count == 0 ? 0 : dtAllotmentRelease.Compute("Sum(amount)", string.Empty));
                    decimal totalSupplementalAppropriation = Convert.ToDecimal(dtSupplementalAppropriation.Rows.Count == 0 ? 0 : dtSupplementalAppropriation.Compute("Sum(amount)", string.Empty));

                    appropriationBalance = ((budgetAppropriation + totalSupplementalAppropriation) - totalAllotmentRelease) + (budgetAppropriationId == _budgetAppropriationId ? _amount : 0);

                }
            }
            catch (Exception ex)
            {
                Helper.MessageBoxError(ex.Message);
            }

            return appropriationBalance < 0 ? 0 : appropriationBalance;
        }


        #region VALIDATIONS

        private void nudYear_Validating(object sender, CancelEventArgs e)
        {
            e.Cancel = Helper.ShowErrorNumericUpDownEmpty(epYear, nudYear, "Year");
        }

        private void nudYear_Validated(object sender, EventArgs e)
        {
            Helper.ClearErrorNumericUpDown(epYear, nudYear);
        }

        private bool AmountExceeds()
        {

            if (nudAmount.Value > GetBudgetAppropriationBalance())
            {
                epAmount.SetError(nudAmount, "Amount you entered exceeds to the appropriate balance.");
                return true;
            }

            return false;
        }

        private bool AmountNotValidated()
        {
            try
            {
                var isEmpty = Helper.ShowErrorNumericUpDownEmpty(epAmount, nudAmount, "Amount");

                if (isEmpty)
                {
                    return true;
                }
                else if (nudAmount.Value == 0)
                {
                    epAmount.SetError(nudAmount, Helper.ErrorMessage("Amount"));
                    return true;
                }
                else if (AmountExceeds())
                    return AmountExceeds();
            }
            catch (Exception ex)
            {
                Helper.MessageBoxError(ex.StackTrace);
            }
            return false;
        }

        private void nudAmount_Validating(object sender, CancelEventArgs e)
        {
            e.Cancel = AmountNotValidated();
        }

        private void nudAmount_Validated(object sender, EventArgs e)
        {
            Helper.ClearErrorNumericUpDown(epAmount, nudAmount);
        }

        private bool AllotmentReleaseExist()
        {
            try
            {

                bool allotmentReleaseExist;
                int allotmentReleaseId = _ucAllotmentMain.allotmentReleaseId;
                int budgetAppropriationId = Convert.ToInt32(cmbxBudgetAppropriations.SelectedValue);
                var dateIssued = _ucAllotmentMain.dtDateIssued.Value;

                if (allotmentReleaseId == 0)
                    allotmentReleaseExist = Factory.AllotmentReleaseRepository().AllotmentReleaseExist(budgetAppropriationId, dateIssued);
                else
                    allotmentReleaseExist = Factory.AllotmentReleaseRepository().AllotmentReleaseExist(allotmentReleaseId, budgetAppropriationId, dateIssued);

                if (allotmentReleaseExist && budgetAppropriationId != _budgetAppropriationId)
                {
                    epBudgetAppropriation.SetError(cmbxBudgetAppropriations, "Budget appropriation acount you entered has an allotment released on the date it was issued.");
                    return allotmentReleaseExist;
                }

                return false;
            }
            catch (Exception ex)
            {
                Helper.MessageBoxError(ex.Message);
            }
            return false;
        }

        private bool BudgetAppropriationExistOnList()
        {
            int budgetAppropriationId = Convert.ToInt32(cmbxBudgetAppropriations.SelectedValue);

            foreach (DataGridViewRow row in _ucAllotmentMain.dgAllotmentRelease.Rows)
            {
                int rowBudgetAppropriationId = Convert.ToInt32(row.Cells["budget_appropriation_id"].Value);

                if (rowBudgetAppropriationId == budgetAppropriationId && rowBudgetAppropriationId != _budgetAppropriationId)
                {
                    epBudgetAppropriation.SetError(cmbxBudgetAppropriations, "Budget Appropriation Account is already on the list.");
                    return true;
                }
            }

            return false;
        }

        private bool BudgetAppropriationNotValidated()
        {
            try
            {
                var isEmpty = Helper.ShowErrorComboBoxEmpty(epBudgetAppropriation, cmbxBudgetAppropriations, "Budget Appropriation");

                if (isEmpty)
                    return true;
                else if (cmbxBudgetAppropriations.FindStringExact(cmbxBudgetAppropriations.Text) < 0 && !string.IsNullOrEmpty(cmbxBudgetAppropriations.Text))
                {
                    epBudgetAppropriation.SetError(cmbxBudgetAppropriations, "Budget Appropriation doesn't exist in your records");
                    return true;
                }
                else if (BudgetAppropriationExistOnList())
                    return true;
                else if (AllotmentReleaseExist())
                    return true;
            }
            catch (Exception ex)
            {
                Helper.MessageBoxError(ex.StackTrace);
            }
            return false;
        }

        private void cmbxBudgetAppropriations_Validating(object sender, CancelEventArgs e)
        {
            e.Cancel = BudgetAppropriationNotValidated();
        }

        private void cmbxBudgetAppropriations_Validated(object sender, EventArgs e)
        {
            Helper.ClearErrorComboBox(epBudgetAppropriation, cmbxBudgetAppropriations);
        }

        #endregion

    }
}
