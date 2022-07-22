using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Windows.Forms;

namespace AccountingSystem.Views.Manage.Realignment
{
    public partial class ucRealignment : UserControl
    {
        internal int budgetId;
        internal int fundId;
        internal int fppId;
        internal int? othersFPPId;
        internal int allotmentClassId;
        internal short year;

        public ucRealignment()
        {
            InitializeComponent();
            Helper.DatagridEditableRowStyle(dgBudgetRealignment, true);

        }


        #region Local Methods
        internal string GetFormErrors()
        {
            var errorArray = new string[6];

            errorArray[0] = epFPP.GetError(cmbFPP);
            errorArray[1] = epAllotmentClass.GetError(cmbAllotmentClass);
            errorArray[2] = epAccount.GetError(cmbAccount);
            errorArray[3] = epAmount.GetError(nudAmount);
            errorArray[4] = epRemarks.GetError(txtRemarks);
            errorArray[5] = epDgAccount.GetError(dgBudgetRealignment);

            return AccFactory.CreateErrors(errorArray).GenerateErrorMessage();
        }
        internal void ResetForm()
        {
            nudAmount.Value = 0;
            cmbFPP.SelectedIndex = -1;
            cmbOthersFPP.SelectedIndex = -1;
            cmbAllotmentClass.SelectedIndex = -1;
            cmbAccount.SelectedIndex = -1;
            dtDateIssued.Value = DateTime.Now;
            dgBudgetRealignment.Rows.Clear();
            txtRemarks.Text = string.Empty;
        }
        internal void ComputeTotalRealignment()
        {
            decimal totalRealignedAmount = 0;
            for (int i = 0; i < dgBudgetRealignment.Rows.Count; ++i)
                totalRealignedAmount += Convert.ToDecimal(dgBudgetRealignment.Rows[i].Cells["amount"].Value);

            txtTotalAmountRealigned.Text = totalRealignedAmount.ToString("N2");
        }
        #endregion

        #region Accessing Database Methods

        internal void LoadFunds()
        {
            cmbFunds.DataSource = AccFactory.FundsRepository().GetRecords();
            cmbFunds.DisplayMember = "fund_name";
            cmbFunds.ValueMember = "id";
        }

        private void LoadAllotmentClasses()
        {
            var dtAllotmentClasses = AccFactory.AllotmentClassesRepository().GetRecords();
            HelperLoadRecords.BudgetAppropriationsAllotmentClassCombobox(dtAllotmentClasses, cmbAllotmentClass, "allotment_code", "id");
        }

        internal void LoadFPP(bool isSearch)
        {
            try
            {
                cmbFPP.DroppedDown = false;
                Cursor.Current = Cursors.Default;

                if (DataTableFPP().Rows.Count == 0)
                {
                    cmbFPP.DataSource = null;
                    cmbFPP.DropDownHeight = 100;
                    return;
                };

                var fppDict = new Dictionary<string, string>();

                foreach (DataRow item in DataTableFPP().Rows)
                {
                    string fppId = item["id"].ToString();
                    string fppName = $"{item["fpp_code"]} - {item["fpp_name"]}";

                    fppDict.Add(fppId, fppName);
                }

                cmbFPP.DataSource = new BindingSource(fppDict, null);
                cmbFPP.DisplayMember = "value";
                cmbFPP.ValueMember = "key";
                cmbFPP.DropDownHeight = 400;
            }
            catch (Exception ex)
            {
                Helper.MessageBoxError(ex.Message);
            }
        }

        internal void LoadOthersFPPByFPPIdCombobox()
        {
            byte fppId = Convert.ToByte(cmbFPP.SelectedValue);
            HelperLoadRecords.OthersFPPCombobox(AccFactory.SubFPPRepository().GetRecordsByFPPId(fppId), cmbOthersFPP, "name", "id");
        }

        private DataTable DataTableFPP()
        {
            DataTable dtFPP;

            if (string.IsNullOrEmpty(cmbFPP.Text))
                dtFPP = AccFactory.FunctionProgramProjectRepository().GetViewRecords();
            else
                dtFPP = AccFactory.FunctionProgramProjectRepository().GetRecordsByCodeName(cmbFPP.Text);

            return dtFPP;
        }

        private void LoadBudgetAppropriationAccounts()
        {
            try
            {
                if (DatatableAccounts().Rows.Count == 0)
                {
                    cmbAccount.DataSource = null;
                    cmbAccount.Items.Clear();
                    return;
                }

                var accountDict = new Dictionary<ushort, string>();
                foreach (DataRow item in DatatableAccounts().Rows)
                {
                    ushort accountId = Convert.ToUInt16(item["general_ledger_accounts_id"]);
                    string accountName = $"{item["account_code"]} - {item["general_ledger_accounts_name"]}";

                    accountDict.Add(accountId, accountName);
                }

                cmbAccount.DataSource = new BindingSource(accountDict, null);
                cmbAccount.DisplayMember = "value";
                cmbAccount.ValueMember = "key";
            }
            catch (Exception ex)
            {
                Helper.MessageBoxError(ex.Message);
            }
        }

        private DataTable DatatableAccounts()
        {
            DataTable dtRealignmentAccounts;
            dtRealignmentAccounts = AccFactory.BudgetAppropriationsRepository().GetViewRecordsByFPPIdAndFundIdAndAllotmentClassIdAndDateEntryAndBudgetAppropriationId(fppId.ToString(), othersFPPId, fundId, allotmentClassId, dtDateIssued.Value, budgetId);
            return dtRealignmentAccounts;
        }

        #endregion

        #region Form Events
        private void ucRealignment_Load(object sender, EventArgs e)
        {
            if (!DesignMode)
            {
                LoadBudgetAppropriationAccounts();
                LoadFunds();
                LoadAllotmentClasses();
                LoadFPP(false);
                LoadOthersFPPByFPPIdCombobox();
                ComputeTotalRealignment();
                FilterSearchDetails();
                ResetForm();
            }
        }



        private void btnEdit_Click_1(object sender, EventArgs e)
        {

            int rowIndex = dgBudgetRealignment.CurrentCell.RowIndex;


            object accountId = dgBudgetRealignment.Rows[rowIndex].Cells["to_ledger_id"].Value;
            decimal amount = Convert.ToDecimal(dgBudgetRealignment.Rows[rowIndex].Cells["amount"].Value);

            cmbAccount.SelectedValue = accountId;
            nudAmount.Value = amount;
        }

        private void btnRemove_Click(object sender, EventArgs e)
        {
            RemoveRealignmentFromList();
            ComputeTotalRealignment();
            SetAmountFields();
        }

        private void RemoveRealignmentFromList()
        {
            decimal amount;
            decimal originalAmount;
            int rowIndex = dgBudgetRealignment.CurrentCell.RowIndex;

            amount = Convert.ToDecimal(dgBudgetRealignment.Rows[rowIndex].Cells["amount"].Value);
            originalAmount = Convert.ToDecimal(txtAppropriationBalance.Text);

            txtAppropriationBalance.Text = (originalAmount + amount).ToString("N2");

            foreach (DataGridViewRow row in dgBudgetRealignment.SelectedRows)
                dgBudgetRealignment.Rows.Remove(row);
        }
        private void SetAmountFields()
        {
            decimal appropriationBalance = Convert.ToDecimal(txtAppropriationBalance.Text);

            nudAmount.Maximum = appropriationBalance;
            nudAmount.Value = appropriationBalance;
        }


        private void dgBudgetRealignment_SelectionChanged(object sender, EventArgs e)
        {
            var rowsCount = dgBudgetRealignment.SelectedRows.Count;
            btnRemove.Enabled = rowsCount != 0;
        }

        private void dgBudgetRealignment_CellValidating(object sender, DataGridViewCellValidatingEventArgs e)
        {
            if (e.ColumnIndex == 3)
            {
                decimal i;
                if (!decimal.TryParse(Convert.ToString(e.FormattedValue), out i))
                {
                    Helper.MessageBoxError("Invalid input. ");
                    e.Cancel = true;
                }
                else
                {
                    e.Cancel = false;
                }
            }
            dgBudgetRealignment.Columns[2].ValueType = typeof(Double);
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            bool zeroAmount = nudAmount.Value < 1;

            dgBudgetRealignment.Validating -= new CancelEventHandler(dgBudgetRealignment_Validating);

            if (!ValidateChildren())
            {
                Helper.MessageBoxError(GetFormErrors());
                return;
            }

            if (zeroAmount)
            {
                Helper.MessageBoxError("Please enter amount.");
                return;
            }

            dgBudgetRealignment.Validating += new CancelEventHandler(dgBudgetRealignment_Validating);

            InsertRealignmentToList();
            ComputeTotalRealignment();
            SetAmountFields();
        }

        private void InsertRealignmentToList()
        {
            string budgetAppropriationId = GetBudgetIdByGeneralLedgerAccountId(cmbAccount.SelectedValue.ToString());
            string realignmentAccountId = cmbAccount.SelectedValue.ToString();
            string realignmentAccount = cmbAccount.GetItemText(cmbAccount.SelectedItem);
            string realignmentAmount = nudAmount.Value.ToString("N2");
            string realignmentDateEntry = dtDateIssued.Value.ToString("MM/dd/yyyy");

            int rowId = 0;
            foreach (DataGridViewRow row in dgBudgetRealignment.Rows)
            {
                rowId = Convert.ToInt32(row.Cells[0].Value.ToString());

                if (rowId.ToString() == budgetAppropriationId)
                {
                    Helper.MessageBoxError("Account is already on the list.");
                    return;
                }
            }

            object[] accountRow = new object[]
            {
                budgetAppropriationId,
                realignmentAccountId,
                realignmentAccount,
                realignmentAmount
            };

            dgBudgetRealignment.Rows.Add(accountRow);


            decimal amount;
            decimal appropriation;

            amount = nudAmount.Value;
            appropriation = Convert.ToDecimal(txtAppropriationBalance.Text);
            txtAppropriationBalance.Text = (appropriation - amount).ToString("N2");


        }

        private string GetBudgetIdByGeneralLedgerAccountId(string generalLedgerId)
        {
            return AccFactory.BudgetAppropriationsRepository().GetBudgetIdByGeneralLedgerId(generalLedgerId);
        }


        private void CmbxLedgerAccout_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(cmbAccount.Text))
            {
                cmbAccount.TextChanged -= new EventHandler(CmbxLedgerAccout_TextChanged);
                LoadBudgetAppropriationAccounts();
                cmbAccount.SelectedIndex = -1;
                cmbAccount.TextChanged += new EventHandler(CmbxLedgerAccout_TextChanged);
            }
        }

        private void FilterSearchDetails()
        {
            fundId = Convert.ToInt32(cmbFunds.SelectedValue);
            fppId = Convert.ToInt32(cmbFPP.SelectedValue);
            othersFPPId = Convert.ToInt32(cmbOthersFPP.SelectedValue) == 0 ? null : Convert.ToInt32(cmbOthersFPP.SelectedValue);
            allotmentClassId = Convert.ToInt32(cmbAllotmentClass.SelectedValue);
            year = (short)dtDateIssued.Value.Year;

            LoadBudgetAppropriationAccounts();
        }

        private void cmbOthersFPP_TextChanged(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(cmbOthersFPP.Text))
            {
                FilterSearchDetails();
            }
        }

        private void cmbFPP_DropDownClosed(object sender, EventArgs e)
        {
            LoadOthersFPPByFPPIdCombobox();
            FilterSearchDetails();
        }
        private void cmbFunds_DropDownClosed(object sender, EventArgs e)
        {
            FilterSearchDetails();
        }
        private void cmbOthersFPP_DropDownClosed(object sender, EventArgs e)
        {
            FilterSearchDetails();
        }
        private void cmbAllotmentClass_DropDownClosed(object sender, EventArgs e)
        {
            FilterSearchDetails();
        }
        #endregion

        #region Validations
        private void cmbAllotmentClass_Validating(object sender, CancelEventArgs e)
        {
            e.Cancel = Helper.ShowErrorComboBoxEmpty(epAllotmentClass, cmbAllotmentClass, "allotment class");

            if (!string.IsNullOrWhiteSpace(cmbAllotmentClass.Text))
                e.Cancel = false;
        }

        private void cmbAllotmentClass_Validated(object sender, EventArgs e)
        {
            Helper.ClearErrorComboBox(epAllotmentClass, cmbAllotmentClass);
        }

        private void txtRemarks_Validating(object sender, CancelEventArgs e)
        {
            e.Cancel = Helper.ShowErrorTextBoxEmpty(epRemarks, txtRemarks, "Remark");
        }

        private void txtRemarks_Validated(object sender, EventArgs e)
        {
            Helper.ClearErrorTextBox(epRemarks, txtRemarks);
        }

        private void cmbFPP_Validating(object sender, CancelEventArgs e)
        {
            e.Cancel = Helper.ShowErrorComboBoxEmpty(epFPP, cmbFPP, "FPP");

            if (!string.IsNullOrWhiteSpace(cmbFPP.Text))
                e.Cancel = false;
        }

        private void cmbFPP_Validated(object sender, EventArgs e)
        {
            Helper.ClearErrorComboBox(epFPP, cmbFPP);
        }

        private void cmbAccount_Validating(object sender, CancelEventArgs e)
        {
            e.Cancel = Helper.ShowErrorComboBoxEmpty(epAccount, cmbAccount, "accounts");

            if (!string.IsNullOrWhiteSpace(cmbAccount.Text))
                e.Cancel = false;
        }

        private void cmbAccount_Validated(object sender, EventArgs e)
        {
            Helper.ClearErrorComboBox(epAccount, cmbAccount);
        }

        private void nudAmount_Validating(object sender, CancelEventArgs e)
        {
            e.Cancel = Helper.ShowErrorNumericUpDownEmpty(epAmount, nudAmount, "amount");


            decimal appropriationBalance = Convert.ToDecimal(txtAppropriationBalance.Text);
            decimal realignmentAmount = nudAmount.Value;
            decimal remainingBalance = appropriationBalance - realignmentAmount;

            bool isBudgetNotEnough = remainingBalance < 0;


            if (isBudgetNotEnough)
            {
                epAmount.SetError(nudAmount, "insufficient budget appropriation to realign.");
                e.Cancel = true;
            }
        }

        private void nudAmount_Validated(object sender, EventArgs e)
        {
            Helper.ClearErrorNumericUpDown(epAmount, nudAmount);
        }

        private void dgBudgetRealignment_Validating(object sender, CancelEventArgs e)
        {
            e.Cancel = Helper.ShowErrorDatagridView(epDgAccount, dgBudgetRealignment, "Account Realignment");
        }

        private void dgBudgetRealignment_Validated(object sender, EventArgs e)
        {
            Helper.ClearErrorDatagridView(epDgAccount, dgBudgetRealignment);
        }

        #endregion
    }
}
