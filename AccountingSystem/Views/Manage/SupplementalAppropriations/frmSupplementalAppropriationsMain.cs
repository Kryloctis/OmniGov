using ACC.Domain.Models;
using AccountingSystem.Views.Manage.BudgetAppropriations;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Windows.Forms;

namespace AccountingSystem.Views.Manage.SupplementalAppropriations
{
    public partial class frmSupplementalAppropriationsMain : Form
    {
        internal frmBudgetAppropriations _frmBudgetAppropriations;
        internal int budgetAppropriationId = 0;
        internal int fppId;
        internal int fundId;
        internal int allotmentClassId;
        internal int year;

        public frmSupplementalAppropriationsMain(frmBudgetAppropriations frmBudgetAppropriations)
        {
            InitializeComponent();
            Helper.LoadFormIcon(this);
            Helper.DatagridFullRowSelectStyle(dgSupplementalAppropriations, true);
            _frmBudgetAppropriations = frmBudgetAppropriations;
        }

        internal string GetFormErrors()
        {
            var errorArray = new string[]
            {
                errorProvider1.GetError(cmbxSubFPP),
                errorProvider1.GetError(cmbxAccount)
            };

            return Factory.CreateErrors(errorArray).GenerateErrorMessage();
        }

        internal void LoadSubFPPByFPPIdCombobox(int fppId)
        {
            HelperLoadRecords.OthersFPPCombobox(Factory.SubFPPRepository().GetRecordsByFPPId(fppId), cmbxSubFPP, "name", "id");
            cmbxSubFPP.SelectedIndex = -1;
            cmbxSubFPP.Text = string.Empty;
            cmbxSubFPP.Enabled = true;
        }

        #region General Ledger Accounts

        private DataTable DatatableAccounts()
        {
            var allotmentClassRepo = Factory.AllotmentClassesRepository().GetRecordByID(allotmentClassId);
            string accountGroupName = allotmentClassRepo["allotment_name"];

            DataTable dtAccounts;

            if (string.IsNullOrEmpty(cmbxAccount.Text))
            {
                if (Convert.ToInt32(allotmentClassId) == 4)
                    dtAccounts = Factory.GeneralLedgerAccountsRepository().GetViewRecordsByAccountGroupName("Assets");
                else
                    dtAccounts = Factory.GeneralLedgerAccountsRepository().GetViewRecordsByMajorAccGroupName(accountGroupName);
            }
            else
            {
                if (Convert.ToInt32(allotmentClassId) == 4)
                    dtAccounts = Factory.GeneralLedgerAccountsRepository().GetViewRecordsByAccountGroupNameSearch("Assets", cmbxAccount.Text);
                else
                    dtAccounts = Factory.GeneralLedgerAccountsRepository().GetViewRecordsByMajorAccGroupNameSearch(accountGroupName, cmbxAccount.Text);
            }

            return dtAccounts;
        }

        private void LoadAccounts()
        {
            try
            {
                cmbxAccount.DroppedDown = false;

                if (DatatableAccounts().Rows.Count == 0) return;

                var accountDict = new Dictionary<int, string>();
                foreach (DataRow item in DatatableAccounts().Rows)
                {
                    int accountId = Convert.ToInt32(item["general_ledger_accounts_id"]);
                    string accountName = $"{item["account_code"]} - {item["ledger_name"]}";

                    accountDict.Add(accountId, accountName);
                }

                cmbxAccount.DataSource = new BindingSource(accountDict, null);
                cmbxAccount.DisplayMember = "value";
                cmbxAccount.ValueMember = "key";
                Cursor.Current = Cursors.Default;

                Helper.ClearErrorComboBox(errorProvider1, cmbxAccount);
            }
            catch (Exception ex)
            {
                Helper.MessageBoxError(ex.Message);
            }

        }

        private void CmbxLedgerAccount_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(cmbxAccount.Text))
            {
                cmbxAccount.TextChanged -= new EventHandler(CmbxLedgerAccount_TextChanged);
                LoadAccounts();
                cmbxAccount.SelectedIndex = -1;
                cmbxAccount.TextChanged += new EventHandler(CmbxLedgerAccount_TextChanged);
            }
        }

        private void cmbxAccount_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F1 && cmbxAccount.FindStringExact(cmbxAccount.Text) == -1 && !string.IsNullOrEmpty(cmbxAccount.Text))
            {
                LoadAccounts();
                cmbxAccount.DroppedDown = true;
            }
        }

        #endregion

        #region Supplemental Appropriations

        private void EnableDisableButtons(DataGridView dgv, Button btnEdit, Button btnDelete)
        {
            int SelectedRows = dgv.SelectedRows.Count;
            if (SelectedRows == 1)
            {
                btnEdit.Enabled = true;
                btnDelete.Enabled = true;
                btnDelete.Text = "Remove (" + SelectedRows + ")";

            }
            else if (SelectedRows > 1)
            {
                btnEdit.Enabled = false;
                btnDelete.Enabled = true;
                btnDelete.Text = "Remove (" + SelectedRows + ")";
            }
            else
            {
                btnEdit.Enabled = false;
                btnDelete.Enabled = false;
                btnDelete.Text = "Remove";
            }
        }

        internal void GetTotalSupplementalAmount()
        {
            decimal totalSupplementalAmount = 0;

            foreach (DataGridViewRow row in dgSupplementalAppropriations.Rows)
            {
                totalSupplementalAmount += Convert.ToDecimal(row.Cells["amount"].Value);
            }

            txtTotalSupplemental.Text = totalSupplementalAmount.ToString("N2");
        }

        private void LoadSupplementalAppropriationRecords()
        {
            HelperLoadRecords.SupplementalDatagridView(dgSupplementalAppropriations);

            if (budgetAppropriationId != 0)
            {
                var dtSupplementalAppropriation = Factory.SupplementalAppropriationsRepository().GetRecordsByBudgetAppropriationId(budgetAppropriationId);
                foreach (DataRow row in dtSupplementalAppropriation.Rows)
                {
                    var dateEntry = row["date_entry"];
                    var amount = row["amount"];
                    var remarks = row["remarks"];

                    dgSupplementalAppropriations.Rows.Add(dateEntry, amount, remarks);
                }
            }

        }

        private void dgSupplementalAppropriations_SelectionChanged(object sender, EventArgs e)
        {
            EnableDisableButtons(dgSupplementalAppropriations, btnEdit, btnRemove);
        }

        private void lnkSelectAll_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            dgSupplementalAppropriations.SelectAll();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            ShowSupplementalAppropriationAdd();
        }

        private void ShowSupplementalAppropriationAdd()
        {
            var frmSupplementalAppropriationAdd = new frmSupplementalAppropriationsAdd(this);
            var ucSupplementaryAppropriationsAdd = frmSupplementalAppropriationAdd.ucSupplementalAppropriations1;
            var dateEntry = dtpDateEntry.Value;
            var isContinuing = chckbxContinuing.Checked;


            ucSupplementaryAppropriationsAdd.dateEntry = dateEntry;
            ucSupplementaryAppropriationsAdd.isContinuing = isContinuing;
            ucSupplementaryAppropriationsAdd.isEdit = false;
            frmSupplementalAppropriationAdd.ShowDialog();
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            int selectedRowCount = dgSupplementalAppropriations.SelectedRows.Count;
            if (selectedRowCount == 1)
            {
                ShowSupplementalAppropriationEdit();
            }
        }

        private void ShowSupplementalAppropriationEdit()
        {
            var frmSupplementalAppropriationEdit = new frmSupplementalAppropriationsEdit(this);
            var ucSupplementaryAppropriationsEdit = frmSupplementalAppropriationEdit.ucSupplementalAppropriations1;
            int rowIndex = dgSupplementalAppropriations.CurrentRow.Index;

            var supplementalDateEntry = Convert.ToDateTime(dgSupplementalAppropriations.Rows[rowIndex].Cells["date_entry"].Value);
            var supplementalAmount = Convert.ToDecimal(dgSupplementalAppropriations.Rows[rowIndex].Cells["amount"].Value);
            var supplementalRemarks = dgSupplementalAppropriations.Rows[rowIndex].Cells["remarks"].Value.ToString();
            frmSupplementalAppropriationEdit.rowIndex = rowIndex;
            ucSupplementaryAppropriationsEdit.LoadSelected(supplementalDateEntry, supplementalAmount, supplementalRemarks);

            var dateEntry = dtpDateEntry.Value;
            var isContinuing = chckbxContinuing.Checked;

            ucSupplementaryAppropriationsEdit.dateEntry = dateEntry;
            ucSupplementaryAppropriationsEdit.isContinuing = isContinuing;
            ucSupplementaryAppropriationsEdit.isEdit = true;
            frmSupplementalAppropriationEdit.ShowDialog();
        }

        private void btnRemove_Click(object sender, EventArgs e)
        {
            int selectedRowCount = dgSupplementalAppropriations.SelectedRows.Count;

            if (MessageBoxConfirmDelete(selectedRowCount))
            {
                foreach (DataGridViewRow row in dgSupplementalAppropriations.SelectedRows)
                {
                    dgSupplementalAppropriations.Rows.RemoveAt(row.Index);
                }

                GetTotalSupplementalAmount();
            }
        }

        private bool MessageBoxConfirmDelete(int rowCount)
        {
            string message = string.Empty;

            if (rowCount == 1)
                message = "Are you sure you want to remove supplemented appropropriation?";
            else if (rowCount > 1)
                message = $"Are you sure you want to remove {rowCount} supplemented appropropriations?";

            if (MessageBox.Show(message, "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                return true;

            return false;
        }

        private void dgSupplementalAppropriations_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
        {
            SetEnableDisableDetailFields(false);
            GetTotalSupplementalAmount();
        }

        private void dgSupplementalAppropriations_RowsRemoved(object sender, DataGridViewRowsRemovedEventArgs e)
        {
            int rowCount = dgSupplementalAppropriations.RowCount;

            if (rowCount == 0)
                SetEnableDisableDetailFields(true);

            GetTotalSupplementalAmount();
        }

        #endregion

        internal void SetEnableDisableDetailFields(bool isEnabled)
        {
            dtpDateEntry.Enabled = isEnabled;
            chckbxContinuing.Enabled = isEnabled;

            if (budgetAppropriationId == 0)
            {
                cmbxAccount.Enabled = true;
                cmbxSubFPP.Enabled = true;
                txtRemarks.ReadOnly = false;
            }
            else
            {
                cmbxAccount.Enabled = false;
                cmbxSubFPP.Enabled = false;
                txtRemarks.ReadOnly = true;
                dtpDateEntry.Enabled = false;
                chckbxContinuing.Enabled = false;
            }
        }

        private void LoadSelectedRecord(int budgetAppropriationId)
        {
            try
            {
                var selectedBudgetAppropriation = Factory.BudgetAppropriationsRepository().GetRecordByID(budgetAppropriationId);

                int fundId = Convert.ToInt32(selectedBudgetAppropriation["funds_id"]);
                int fppId = Convert.ToInt32(selectedBudgetAppropriation["function_program_project_id"]);
                int? othersFPPId = string.IsNullOrEmpty(selectedBudgetAppropriation["others_fpp_id"]) ? null : Convert.ToInt32(selectedBudgetAppropriation["others_fpp_id"]);
                int allotmentClassId = Convert.ToInt32(selectedBudgetAppropriation["allotment_classes_id"]);
                int generalLedgerAccountId = Convert.ToInt32(selectedBudgetAppropriation["general_ledger_accounts_id"]);
                DateTime dateEntry = Convert.ToDateTime(selectedBudgetAppropriation["date_entry"]);
                short year = Convert.ToInt16(selectedBudgetAppropriation["year"]);
                decimal appropriationAmount = Convert.ToDecimal(selectedBudgetAppropriation["amount"]);

                bool continuing = Convert.ToByte(selectedBudgetAppropriation["continuing"]) == 0 ? false : true;

                if (othersFPPId == null)
                    cmbxSubFPP.SelectedIndex = -1;
                else
                    cmbxSubFPP.SelectedValue = othersFPPId;

                cmbxAccount.SelectedValue = generalLedgerAccountId;
                dtpDateEntry.Value = dateEntry;
                txtYear.Text = year.ToString();
                txtRemarks.Text = selectedBudgetAppropriation["remarks"];
                chckbxContinuing.Checked = continuing;
            }
            catch (Exception ex)
            {
                Helper.MessageBoxError(ex.Message);
            }
        }

        private void LoadFields()
        {
            try
            {
                var dictFPP = Factory.FunctionProgramProjectRepository().GetRecordByID(fppId);
                var dictFund = Factory.FundsRepository().GetRecordByID(fundId);
                var dictAllotmentClass = Factory.AllotmentClassesRepository().GetRecordByID(allotmentClassId);

                string fppName = $"{dictFPP["fpp_code"]} - {dictFPP["fpp_name"]}";
                string fundName = $"{dictFund["fund_code"]} - {dictFund["fund_name"]}";
                string allotmentClassName = $"{dictAllotmentClass["allotment_code"]} - {dictAllotmentClass["allotment_name"]}";
                DateTime maxDate = new DateTime(year, 12, DateTime.DaysInMonth(year, 12));
                DateTime minDate = new DateTime(year, 1, 1);

                txtFPP.Text = fppName;
                txtFund.Text = fundName;
                txtAllotmentClass.Text = allotmentClassName;
                txtYear.Text = year.ToString();
                dtpDateEntry.MaxDate = maxDate;
                dtpDateEntry.MinDate = minDate;


                LoadSubFPPByFPPIdCombobox(fppId);
                LoadAccounts();
                cmbxAccount.SelectedIndex = -1;
                cmbxAccount.TextChanged += new EventHandler(CmbxLedgerAccount_TextChanged);
                LoadSupplementalAppropriationRecords();
                SetEnableDisableDetailFields(true);


                if (budgetAppropriationId != 0)
                {
                    LoadSelectedRecord(budgetAppropriationId);
                    SetEnableDisableDetailFields(false);
                }
            }
            catch (Exception ex) { Helper.MessageBoxError(ex.Message); }
        }

        #region Validations

        #region Sub FPP Validation

        private bool SubFPPNameExist(ErrorProvider ep, ComboBox comboBox, string fieldText)
        {
            try
            {
                if (!Factory.SubFPPRepository().NameExist(cmbxSubFPP.Text) && !string.IsNullOrWhiteSpace(cmbxSubFPP.Text))
                {
                    ep.SetError(comboBox, fieldText);
                    return true;
                }
            }
            catch (Exception ex) { Helper.MessageBoxError(ex.Message); }
            return false;
        }

        private void cmbxSubFPP_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            e.Cancel = SubFPPNameExist(errorProvider1, cmbxSubFPP, "Invalid Sub FPP. Please select on the list.");
        }

        private void cmbxSubFPP_Validated(object sender, EventArgs e)
        {
            Helper.ClearErrorComboBox(errorProvider1, cmbxSubFPP);
        }

        #endregion

        #region Account Validation

        private bool ShowErrorLedgerNameNotExist()
        {
            try
            {
                if (cmbxAccount.FindStringExact(cmbxAccount.Text) < 0 && !string.IsNullOrEmpty(cmbxAccount.Text))
                {
                    errorProvider1.SetError(cmbxAccount, "Invalid General Ledger Account. Please select on the list.");
                    return true;
                }
            }
            catch (Exception ex)
            {
                Helper.MessageBoxError(ex.Message);
            }
            return false;
        }

        private bool ShowErrorBudgetAppropriationContinuing()
        {
            try
            {
                int? othersFPPId = string.IsNullOrEmpty(cmbxSubFPP.Text.ToString()) ? null : Convert.ToInt32(cmbxSubFPP.SelectedValue);
                int generalLedgerAccId = Convert.ToInt32(cmbxAccount.SelectedValue);

                bool budgetAppropriationExist;

                if (budgetAppropriationId == 0)
                    budgetAppropriationExist = Factory.BudgetAppropriationsRepository().BudgetAppropriationContinuing(fundId, fppId, othersFPPId, allotmentClassId, generalLedgerAccId);
                else
                    budgetAppropriationExist = Factory.BudgetAppropriationsRepository().BudgetAppropriationContinuing(budgetAppropriationId, fundId, fppId, othersFPPId, allotmentClassId, generalLedgerAccId);

                if (budgetAppropriationExist)
                {
                    errorProvider1.SetError(cmbxAccount, "Account you entered is not allowed. Account has continuing appropriation already exist on your record.");
                    return true;
                }

            }
            catch (Exception ex)
            {
                Helper.MessageBoxError(ex.Message);
            }
            return false;
        }

        private bool ShowErrorBudgetAppropriationExist()
        {
            try
            {
                int? othersFPPId = string.IsNullOrEmpty(cmbxSubFPP.Text.ToString()) ? null : Convert.ToInt32(cmbxSubFPP.SelectedValue);
                int generalLedgerAccId = Convert.ToInt32(cmbxAccount.SelectedValue);
                string remarks = txtRemarks.Text;

                bool budgetAppropriationExist;

                if (budgetAppropriationId == 0)
                    budgetAppropriationExist = Factory.BudgetAppropriationsRepository().BudgetAppropriationExist(fundId, fppId, othersFPPId, allotmentClassId, generalLedgerAccId, (short)year, remarks);
                else
                    budgetAppropriationExist = Factory.BudgetAppropriationsRepository().BudgetAppropriationExist(budgetAppropriationId, fundId, fppId, othersFPPId, allotmentClassId, generalLedgerAccId, (short)year, remarks);

                if (budgetAppropriationExist)
                {
                    errorProvider1.SetError(cmbxAccount, "Account you entered is not allowed. Budget appropriation already exist on your record.");
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
                e.Cancel = Helper.ShowErrorComboBoxEmpty(errorProvider1, cmbxAccount, "General Ledger Account");
            else if (ShowErrorLedgerNameNotExist())
                e.Cancel = ShowErrorLedgerNameNotExist();
            else if (ShowErrorBudgetAppropriationContinuing())
                e.Cancel = ShowErrorBudgetAppropriationContinuing();
            else
                e.Cancel = ShowErrorBudgetAppropriationExist();
        }

        private void cmbxAccount_Validated(object sender, EventArgs e)
        {
            Helper.ClearErrorComboBox(errorProvider1, cmbxAccount);
        }

        #endregion

        #endregion

        private void frmSupplementalAppropriationsMain_Load(object sender, EventArgs e)
        {
            EnableDisableButtons(dgSupplementalAppropriations, btnEdit, btnRemove);
            LoadFields();
        }

        private bool SaveData()
        {
            try
            {
                if (!this.ValidateChildren())
                {
                    Helper.MessageBoxError(GetFormErrors());
                    return false;
                }

                var budgetAppropriationsModel = new BudgetAppropriationsModel()
                {
                    FundsId = fundId,
                    FunctionProgramProjectId = fppId,
                    OthersFPPId = cmbxSubFPP.SelectedValue == null ? null : Convert.ToInt32(cmbxSubFPP.SelectedValue),
                    AllotmentClassesId = allotmentClassId,
                    GeneralLedgerAccountsId = Convert.ToInt32(cmbxAccount.SelectedValue),
                    Year = (short)year,
                    DateEntry = dtpDateEntry.Value,
                    Continuing = chckbxContinuing.Checked,
                    Remarks = txtRemarks.Text.Trim()
                };

                var SupplementalAppropriationList = new List<SupplementalAppropriationsModel>();

                foreach (DataGridViewRow row in dgSupplementalAppropriations.Rows)
                {
                    var supplementalAppropriationsModel = new SupplementalAppropriationsModel()
                    {
                        date_entry = Convert.ToDateTime(row.Cells["date_entry"].Value),
                        amount = Convert.ToDecimal(row.Cells["amount"].Value),
                        remarks = row.Cells["remarks"].Value.ToString().Trim()
                    };

                    if (budgetAppropriationId != 0)
                        supplementalAppropriationsModel.BudgetAppropriationID = budgetAppropriationId;

                    SupplementalAppropriationList.Add(supplementalAppropriationsModel);
                }

                if (budgetAppropriationId == 0)
                    return Factory.BudgetAppropriationsRepository().Insert(budgetAppropriationsModel, SupplementalAppropriationList);
                else
                    return Factory.SupplementalAppropriationsRepository().Insert(SupplementalAppropriationList, budgetAppropriationId);

            }
            catch (Exception ex) { Helper.MessageBoxSuccess(ex.Message); }
            return false;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (SaveData())
            {
                string generalLedgerAccountName = cmbxAccount.Text;
                string remarks = txtRemarks.Text;
                string objectOfExpenditures = $"   {generalLedgerAccountName}{(string.IsNullOrEmpty(remarks) ? string.Empty : $" → {remarks}")}";
                string subFPP = cmbxSubFPP.Text;
                string message = budgetAppropriationId == 0 ? "Supplemental Appropriation has been saved." : "Changes has been saved.";

                Helper.MessageBoxSuccess(message);
                _frmBudgetAppropriations.LoadBudgetAppropriationRecords();
                _frmBudgetAppropriations.DatagridViewRecordFinder(_frmBudgetAppropriations.dgBudgetAppropriations, objectOfExpenditures, subFPP);
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
