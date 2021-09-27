using ACC.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Linq;
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
            Helper.DatagridFullRowSelectStyle(dgBudgetRealignment);
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
        }

        private void ucRealignment_Load(object sender, EventArgs e)
        {
            if (!DesignMode)
            {
                LoadBudgetAppropriationAccounts();
                LoadFunds();
                LoadAllotmentClasses();
                LoadFPP(false);
                LoadOthersFPPByFPPIdCombobox();
                FilterSearchDetails();
            }

        }



        internal void LoadFunds()
        {
            cmbFunds.DataSource = Factory.FundsRepository().GetRecords();
            cmbFunds.DisplayMember = "fund_name";
            cmbFunds.ValueMember = "id";
        }


        private void LoadAllotmentClasses()
        {
            var dtAllotmentClasses = Factory.AllotmentClassesRepository().GetRecords();
            HelperLoadRecords.BudgetAppropriationsAllotmentCombobox(dtAllotmentClasses, cmbAllotmentClass, "allotment_code", "id");
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
            HelperLoadRecords.OthersFPPCombobox(Factory.SubFPPRepository().GetRecordsByFPPId(fppId), cmbOthersFPP, "name", "id");
            cmbOthersFPP.SelectedIndex = -1;
            cmbOthersFPP.Text = string.Empty;
            cmbOthersFPP.Enabled = true;
          
        }

        private DataTable DataTableFPP()
        {
            DataTable dtFPP;

            if (string.IsNullOrEmpty(cmbFPP.Text))
                dtFPP = Factory.FunctionProgramProjectRepository().GetRecords();
            else
                dtFPP = Factory.FunctionProgramProjectRepository().GetRecordsByCodeName(cmbFPP.Text);

            return dtFPP;
        }





        private void LoadBudgetAppropriationAccounts()
        {
            try
            {
                if (DatatableAccounts().Rows.Count == 0) {
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
            dtRealignmentAccounts = Factory.BudgetAppropriationsRepository().GetViewRecordsByFPPIdAndFundIdAndAllotmentClassIdAndDateEntry(fppId.ToString(), othersFPPId ,fundId, allotmentClassId, dtDateIssued.Value, int.Parse(txtBudgetId.Text));

            return dtRealignmentAccounts;
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (!ValidateChildren())
            {
                Helper.MessageBoxError(GetFormErrors());
                return;
            }

            AddRealignment();
        }

        private void AddRealignment()
        {
            string budgetAppropriationId = GetBudgetIdByGeneralLedgerAccountId(cmbAccount.SelectedValue.ToString());
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
                realignmentAccount,
                realignmentAmount
            };

            dgBudgetRealignment.Rows.Add(accountRow);
            SumRealignment();
        }

        private string GetBudgetIdByGeneralLedgerAccountId(string generalLedgerId)
        {
            return Factory.BudgetAppropriationsRepository().GetBudgetIdByGeneralLedgerId(generalLedgerId);
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


        internal string GetFormErrors()
        {
            var errorArray = new string[5];

            errorArray[0] = epFPP.GetError(cmbFPP);
            errorArray[1] = epAllotmentClass.GetError(cmbAllotmentClass);
            errorArray[2] = epAccount.GetError(cmbAccount);
            errorArray[3] = epAmount.GetError(nudAmount);
            errorArray[4] = epRemarks.GetError(txtRemarks);

            return Factory.CreateErrors(errorArray).GenerateErrorMessage();
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

        private void cmbAccount_Validating(object sender, CancelEventArgs e)
        {
            e.Cancel = Helper.ShowErrorComboBoxEmpty(epAccount, cmbAccount, "account");

            if (!string.IsNullOrWhiteSpace(cmbAccount.Text))
                e.Cancel = false;
        }

        private void SumRealignment()
        {
            decimal realignmentAmount = 0;
            for (int i = 0; i < dgBudgetRealignment.Rows.Count; ++i)
            {
                realignmentAmount += Convert.ToDecimal(dgBudgetRealignment.Rows[i].Cells[2].Value);
            }
            txtTotalAmountRealigned.Text = realignmentAmount.ToString("N2");
        }


        private void txtRemarks_Validating(object sender, CancelEventArgs e)
        {

            e.Cancel = Helper.ShowErrorTextBoxEmpty(epRemarks, txtRemarks, "Remark");
        }

        private void txtRemarks_Validated(object sender, EventArgs e)
        {
            Helper.ClearErrorTextBox(epRemarks, txtRemarks);
        }

        private void cmbAccount_Validated(object sender, EventArgs e)
        {
            Helper.ClearErrorComboBox(epAccount, cmbAccount);
        }

        private void nudAmount_Validating(object sender, CancelEventArgs e)
        {
            e.Cancel = Helper.ShowErrorNumericUpDownEmpty(epAmount, nudAmount, "amount");

            decimal remainingAppropriation = Convert.ToDecimal(nudAppropriationBalance.Text) - Convert.ToDecimal(txtTotalAmountRealigned.Text);

            bool isEnoughBudget = remainingAppropriation >= Convert.ToDecimal(nudAmount.Value);


            if (nudAmount.Value < 1)
            {
                epAmount.SetError(nudAmount, "Plase enter a non-zero amount");
                e.Cancel = true;
            }

            if (!isEnoughBudget)
            {
                epAmount.SetError(nudAmount, "insufficient budget appropriation to be align.");
                e.Cancel = true;
            }
        }

        private void nudAmount_Validated(object sender, EventArgs e)
        {
            Helper.ClearErrorNumericUpDown(epAmount, nudAmount);
        }

        private void btnRemove_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow row in dgBudgetRealignment.SelectedRows)
            {
                dgBudgetRealignment.Rows.Remove(row);
            }
            SumRealignment();
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {

        }
    }
}
