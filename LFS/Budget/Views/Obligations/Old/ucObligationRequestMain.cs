using Budget.Data;
using LFS.Helpers;
using OmniGov.Core.Repositories;
using OmniGov.Core.Factories;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Windows.Forms;

namespace LFS.Budget.Views.Obligations
{
    public partial class ucObligationRequestMain : UserControl
    {
        internal bool isEdit = false;
        internal int obligationRequestId = 0;
        internal int fundId;
        internal int allotmentClassId;

        public ucObligationRequestMain()
        {
            InitializeComponent();
        }

        private void ucObligationRequestMain_Load(object sender, EventArgs e)
        {
            if (!DesignMode)
            {
                LoadFPP();
                cmbxFPP.SelectedIndex = -1;
                cmbxFPP.TextChanged += new EventHandler(cmbxFPP_TextChanged);

                LoadFunds();
                LoadAllotmentClasses();
                LoadDatagridFormat();
                mskTxtObligationNoTemplate.Text = GenerateObligationRequestNoTemplate();
                GetTotalObligations();
                btnEdit.Enabled = false;
                btnRemove.Enabled = false;
                GenerateSeriesNo();
            }
        }

        internal void GenerateSeriesNo()
        {
            try
            {
                mskTxtObligationNoSeries.Text = BudgetFactory.ObligationRequestRepository().GetLeastOblgtnNo();
            }
            catch (Exception ex)
            {
                Helper.MessageBoxError(ex.Message);
            }
        }

        internal string GetFormErrors()
        {
            var errorArray = new string[]
            {
                errorProvider1.GetError(cmbxFPP),
                errorProvider1.GetError(mskTxtObligationNoTemplate),
                errorProvider1.GetError(txtReferenceNo),
                errorProvider1.GetError(txtPayee),
                errorProvider1.GetError(txtExplanation),
                dgObligationRequests.Tag == null ? string.Empty : dgObligationRequests.Tag.ToString(),
            };

            return Factory.CreateErrors(errorArray).GenerateErrorMessage();
        }

        internal void ResetForm()
        {
            if (isEdit)
            {
                isEdit = false;
                obligationRequestId = 0;
                fundId = 0;
                allotmentClassId = 0;
            }

            cmbxFPP.SelectedValue = 0;
            cmbxFPP.Text = string.Empty;
            CheckedFund(1);
            CheckedAllotmentClass(1);
            mskTxtObligationNoSeries.Text = string.Empty;
            dtDateRequest.Value = DateTime.Now;
            txtReferenceNo.Text = string.Empty;
            txtPayee.Text = string.Empty;
            txtExplanation.Text = string.Empty;
            dgObligationRequests.Rows.Clear();
            txtTotalObligations.Text = "0.00";
            GenerateSeriesNo();
            SetFieldsReadOnly(false);
        }

        internal void GetTotalObligations()
        {
            decimal totalObligation = 0;

            foreach (DataGridViewRow row in dgObligationRequests.Rows)
            {
                totalObligation += Convert.ToDecimal(row.Cells["obligation_amount"].Value);
            }

            txtTotalObligations.Text = totalObligation.ToString("N2");
        }

        private void LoadDatagridFormat()
        {
            dgObligationRequests.Columns.Add("budget_appropriation_id", "Budget Appropriation ID");
            dgObligationRequests.Columns.Add("object_expenditure", "Object Expenditure");
            dgObligationRequests.Columns.Add("account_code", "Account Code");
            dgObligationRequests.Columns.Add("obligation_amount", "Amount");

            dgObligationRequests.Columns["object_expenditure"].SortMode = DataGridViewColumnSortMode.NotSortable;
            dgObligationRequests.Columns["object_expenditure"].Width = 500;
            dgObligationRequests.Columns["account_code"].SortMode = DataGridViewColumnSortMode.NotSortable;
            dgObligationRequests.Columns["account_code"].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
            dgObligationRequests.Columns["obligation_amount"].SortMode = DataGridViewColumnSortMode.NotSortable;
            dgObligationRequests.Columns["obligation_amount"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dgObligationRequests.Columns["obligation_amount"].DefaultCellStyle.Format = "N2";

            dgObligationRequests.Columns["budget_appropriation_id"].Visible = false;
            Helper.DatagridFullRowSelectStyle(dgObligationRequests, true);
        }

        internal void SetFieldsReadOnly(bool isReadOnly)
        {
            cmbxFPP.Enabled = !isReadOnly;
            flowLayoutPanelFunds.Enabled = !isReadOnly;
            flowLayoutPanelAllotmentClass.Enabled = !isReadOnly;
            mskTxtObligationNoSeries.ReadOnly = isReadOnly;
            dtDateRequest.Enabled = !isReadOnly;
            txtReferenceNo.ReadOnly = isReadOnly;
            txtPayee.ReadOnly = isReadOnly;
            txtExplanation.ReadOnly = isReadOnly;
            btnAdd.Enabled = !isReadOnly;
            btnEdit.Enabled = !isReadOnly;
            btnRemove.Enabled = !isReadOnly;

            if (isReadOnly)
                dgObligationRequests.SelectionChanged -= new EventHandler(dgObligationRequests_SelectionChanged);
            else
                dgObligationRequests.SelectionChanged += new EventHandler(dgObligationRequests_SelectionChanged);
        }

        internal void EnableDisableComponents(bool enableComponents)
        {
            cmbxFPP.Enabled = enableComponents;
            flowLayoutPanelFunds.Enabled = enableComponents;
            flowLayoutPanelAllotmentClass.Enabled = enableComponents;
            dtDateRequest.Enabled = enableComponents;
        }

        private void EnableDisableButtons()
        {
            int selectedRowCount = dgObligationRequests.SelectedRows.Count;

            if (selectedRowCount == 1)
            {
                btnEdit.Enabled = true;
                btnRemove.Enabled = true;
                btnRemove.Text = "Remove (" + selectedRowCount + ")";
            }
            else if (selectedRowCount > 1)
            {
                btnEdit.Enabled = false;
                btnRemove.Enabled = true;
                btnRemove.Text = "Remove (" + selectedRowCount + ")";
            }
            else
            {
                btnEdit.Enabled = false;
                btnRemove.Enabled = false;
                btnRemove.Text = "Remove";
            }
        }

        private void dgObligationRequests_SelectionChanged(object sender, EventArgs e)
        {
            EnableDisableButtons();
        }

        private DataTable DataTableFPP()
        {
            DataTable dtFPP;

            if (string.IsNullOrWhiteSpace(cmbxFPP.Text))
                dtFPP = Factory.FunctionProgramProjectRepository().GetViewRecords();
            else
                dtFPP = Factory.FunctionProgramProjectRepository().GetRecordsByCodeName(cmbxFPP.Text.Trim());

            return dtFPP;
        }

        internal void LoadFPP()
        {
            try
            {
                cmbxFPP.DroppedDown = false;
                Cursor.Current = Cursors.Default;

                if (DataTableFPP().Rows.Count == 0) return;

                var fppDict = new Dictionary<int, string>();
                foreach (DataRow item in DataTableFPP().Rows)
                {
                    int fppId = Convert.ToInt32(item["id"]);
                    string fppName = $"{item["fpp_code"]} - {item["fpp_name"]}";

                    fppDict.Add(fppId, fppName);
                }

                cmbxFPP.DataSource = new BindingSource(fppDict, null);
                cmbxFPP.DisplayMember = "value";
                cmbxFPP.ValueMember = "key";
            }
            catch (Exception ex)
            {
                Helper.MessageBoxError(ex.Message);
            }
        }

        private void cmbxFPP_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(cmbxFPP.Text))
            {
                cmbxFPP.TextChanged -= new EventHandler(cmbxFPP_TextChanged);
                LoadFPP();
                cmbxFPP.SelectedIndex = -1;
                cmbxFPP.TextChanged += new EventHandler(cmbxFPP_TextChanged);
            }
        }

        private void cmbxFPP_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F1 && cmbxFPP.FindStringExact(cmbxFPP.Text) == -1 && !string.IsNullOrEmpty(cmbxFPP.Text))
            {
                LoadFPP();
                cmbxFPP.DroppedDown = true;
            }
        }

        internal void CheckedFund(int radFundId)
        {
            flowLayoutPanelFunds.Controls.OfType<RadioButton>().FirstOrDefault(r => (Convert.ToInt32(r.Tag) == radFundId) ? r.Checked = true : r.Checked = false);
            fundId = radFundId;
        }

        internal void CheckedAllotmentClass(int radAllotmentClassId)
        {
            flowLayoutPanelAllotmentClass.Controls.OfType<RadioButton>().FirstOrDefault(r => (Convert.ToInt32(r.Tag) == radAllotmentClassId) ? r.Checked = true : r.Checked = false);
            allotmentClassId = radAllotmentClassId;
        }

        private void ShowCheckIcon(RadioButton radioButton)
        {
            if (radioButton.Checked)
                radioButton.Image = Properties.Resources.ok14px;
            else
                radioButton.Image = null;
        }

        internal void LoadFunds()
        {
            var funds = Factory.FundsRepository().GetRecords();

            foreach (DataRow fund in funds.Rows)
            {
                var radFund = new RadioButton
                {
                    Text = fund["fund_name"].ToString(),
                    Tag = fund["id"],
                    AutoSize = true,
                    Appearance = Appearance.Button,
                    TextImageRelation = TextImageRelation.ImageBeforeText
                };

                if (Convert.ToInt32(fund["id"]) == 1)
                {
                    radFund.Checked = true;
                    fundId = Convert.ToByte(fund["id"]);
                    ShowCheckIcon(radFund);
                }

                flowLayoutPanelFunds.Controls.Add(radFund);

                radFund.Click += new EventHandler(radioFunds_Click);
                radFund.CheckedChanged += new EventHandler(radioFunds_CheckedChanged);
            }
        }

        private void radioFunds_Click(object sender, EventArgs e)
        {
            var radFund = sender as RadioButton;
            fundId = Convert.ToByte(radFund.Tag);
            mskTxtObligationNoTemplate.Text = GenerateObligationRequestNoTemplate();
        }

        private void radioFunds_CheckedChanged(object sender, EventArgs e)
        {
            var radFund = sender as RadioButton;
            ShowCheckIcon(radFund);
        }

        internal void LoadAllotmentClasses()
        {
            var dtAllotmentClass = Factory.AllotmentClassesRepository().GetRecords();

            foreach (DataRow allotmentClass in dtAllotmentClass.Rows)
            {
                var radAllotment = new RadioButton
                {
                    Text = allotmentClass["allotment_code"].ToString(),
                    Tag = allotmentClass["id"],
                    AutoSize = true,
                    Appearance = Appearance.Button,
                    TextImageRelation = TextImageRelation.ImageBeforeText
                };

                if (Convert.ToInt32(allotmentClass["id"]) == 1)
                {
                    radAllotment.Checked = true;
                    allotmentClassId = Convert.ToByte(allotmentClass["id"]);
                    ShowCheckIcon(radAllotment);
                }

                flowLayoutPanelAllotmentClass.Controls.Add(radAllotment);

                radAllotment.Click += new EventHandler(radioAllotmentClass_Click);
                radAllotment.CheckedChanged += new EventHandler(radioAllotmentClass_CheckedChanged);
            }
        }

        private void radioAllotmentClass_Click(object sender, EventArgs e)
        {
            var allotmentClass = sender as RadioButton;
            allotmentClassId = Convert.ToByte(allotmentClass.Tag);
        }

        private void radioAllotmentClass_CheckedChanged(object sender, EventArgs e)
        {
            var allotmentClass = sender as RadioButton;
            ShowCheckIcon(allotmentClass);
        }

        internal string GenerateObligationRequestNoTemplate()
        {
            string fundCode = Factory.FundsRepository().GetRecordByID(fundId)["fund_code"];

            string obligationNoTemplate = $"{dtDateRequest.Value.ToString("MM")}-{dtDateRequest.Value.ToString("yy")}-{fundCode}";

            return obligationNoTemplate;
        }

        private void dtDateRequest_ValueChanged(object sender, EventArgs e)
        {
            mskTxtObligationNoTemplate.Text = GenerateObligationRequestNoTemplate();
        }

        private void btnRemove_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow item in dgObligationRequests.SelectedRows)
            {
                dgObligationRequests.Rows.Remove(item);
            }

            if (dgObligationRequests.Rows.Count == 0)
                EnableDisableComponents(true);
        }

        internal string GetFormErrorsAdd()
        {
            var errorArray = new string[]
            {
                errorProvider1.GetError(cmbxFPP)
            };

            return Factory.CreateErrors(errorArray).GenerateErrorMessage();
        }

        private bool Validation()
        {
            if (ShowErrorFPPNameNotExist() || Helper.ShowErrorComboBoxEmpty(errorProvider1, cmbxFPP, "FPP"))
            {
                Helper.MessageBoxError(GetFormErrorsAdd());
                return false;
            }
            else
            {
                Helper.ClearErrorComboBox(errorProvider1, cmbxFPP);
                return true;
            }
        }

        private void ShowObligationRequestAdd()
        {
            if (Validation())
            {
                var frmObligationRequestAdd = new frmObligationRequestAdd(this);
                var ucObligationRequestAdd = frmObligationRequestAdd.ucObligationRequest1;

                ucObligationRequestAdd.fppId = Convert.ToInt32(cmbxFPP.SelectedValue);
                ucObligationRequestAdd.fundId = fundId;
                ucObligationRequestAdd.allotmentClassId = allotmentClassId;
                ucObligationRequestAdd.dateRequested = dtDateRequest.Value;

                frmObligationRequestAdd.ShowDialog();
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                ShowObligationRequestAdd();
            }
            catch (Exception ex) { Helper.MessageBoxError(ex.Message); }
        }

        private void ShowObligationRequestEdit()
        {
            if (Validation())
            {
                var _frmObligationRequestEdit = new frmObligationRequestEdit(this);
                var ucObligationRequestEdit = _frmObligationRequestEdit.ucObligationRequest1;
                int rowIndex = dgObligationRequests.CurrentCell.RowIndex;

                int budgetAppropriationId = Convert.ToInt32(dgObligationRequests.Rows[rowIndex].Cells["budget_appropriation_id"].Value);
                var budgetAppropriationsDict = BudgetFactory.BudgetAppropriationsRepository().GetRecordByID(budgetAppropriationId);

                var subFPP = budgetAppropriationsDict["others_fpp_id"];
                decimal amount = Convert.ToDecimal(dgObligationRequests.Rows[rowIndex].Cells["obligation_amount"].Value);

                ucObligationRequestEdit.fppId = Convert.ToInt32(cmbxFPP.SelectedValue);
                ucObligationRequestEdit.fundId = fundId;
                ucObligationRequestEdit.allotmentClassId = allotmentClassId;
                ucObligationRequestEdit.dateRequested = dtDateRequest.Value;
                ucObligationRequestEdit._subFPPId = string.IsNullOrWhiteSpace(subFPP) ? null : Convert.ToInt32(subFPP);
                ucObligationRequestEdit._budgetAppropriationsId = budgetAppropriationId;
                ucObligationRequestEdit._amount = amount;
                ucObligationRequestEdit.nudAmount.Value = amount;

                _frmObligationRequestEdit.ShowDialog();
            }
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            try
            {
                ShowObligationRequestEdit();
            }
            catch (Exception ex) { Helper.MessageBoxError(ex.Message); }
        }

        internal bool ShowErrorObligationRequestsListEmpty()
        {
            if (dgObligationRequests.Rows.Count == 0)
            {
                dgObligationRequests.Tag = "Obligation request list is empty.";
                return true;
            }
            else
            {
                return false;
            }
        }

        private void dgObligationRequests_Validating(object sender, CancelEventArgs e)
        {
            try
            {
                e.Cancel = ShowErrorObligationRequestsListEmpty();
            }
            catch (Exception ex) { Helper.MessageBoxError(ex.Message); }
        }

        private void dgObligationRequests_Validated(object sender, EventArgs e)
        {
            dgObligationRequests.Tag = string.Empty;
        }

        private bool ShowErrorFPPNameNotExist()
        {
            string fppName = cmbxFPP.Text;

            if (cmbxFPP.FindStringExact(fppName) < 0 && !string.IsNullOrEmpty(fppName))
            {
                errorProvider1.SetError(cmbxFPP, "FPP you entered doesn't exist on your record.");
                return true;
            }
            else { return false; }
        }

        private void cmbxFPP_Validating(object sender, CancelEventArgs e)
        {
            try
            {
                if (string.IsNullOrEmpty(cmbxFPP.Text))
                    e.Cancel = Helper.ShowErrorComboBoxEmpty(errorProvider1, cmbxFPP, "FPP.");
                else
                    e.Cancel = ShowErrorFPPNameNotExist();
            }
            catch (Exception ex) { Helper.MessageBoxError(ex.Message); }
        }

        private void cmbxFPP_Validated(object sender, EventArgs e)
        {
            Helper.ClearErrorComboBox(errorProvider1, cmbxFPP);
        }

        private bool ShowErrorObligationRequestNoEmpty()
        {
            if (!mskTxtObligationNoSeries.MaskCompleted)
            {
                errorProvider1.SetError(mskTxtObligationNoTemplate, "Please enter an obligation no.");
                return true;
            }
            else
                return false;
        }

        private bool ShowErrorObligationRequestNoExist()
        {
            string obligationNo = $"{mskTxtObligationNoSeries.Text}-{GenerateObligationRequestNoTemplate()}";

            bool obligationRequestNoExist;

            if (obligationRequestId == 0)
                obligationRequestNoExist = BudgetFactory.ObligationRequestRepository().ObligationRequestNoExist(obligationNo);
            else
                obligationRequestNoExist = BudgetFactory.ObligationRequestRepository().ObligationRequestNoExist(obligationRequestId, obligationNo);

            if (obligationRequestNoExist)
            {
                errorProvider1.SetError(mskTxtObligationNoTemplate, "Obligation request no. is already exist on your record.");
                return true;
            }
            else { return false; }
        }

        private void mskTxtObligationNoSeries_Validating(object sender, CancelEventArgs e)
        {
            try
            {
                if (ShowErrorObligationRequestNoEmpty())
                    e.Cancel = ShowErrorObligationRequestNoEmpty();
                else if (ShowErrorObligationRequestNoExist())
                    e.Cancel = ShowErrorObligationRequestNoExist();
            }
            catch (Exception ex) { Helper.MessageBoxError(ex.Message); }
        }

        private void mskTxtObligationNoSeries_Validated(object sender, EventArgs e)
        {
            Helper.ClearMaskedTextboxError(errorProvider1, mskTxtObligationNoTemplate);
        }

        private void txtReferenceNo_Validating(object sender, CancelEventArgs e)
        {
            try
            {
                e.Cancel = Helper.ShowErrorTextBoxEmpty(errorProvider1, txtReferenceNo, "Reference No.");
            }
            catch (Exception ex) { Helper.MessageBoxError(ex.Message); }
        }

        private void txtReferenceNo_Validated(object sender, EventArgs e)
        {
            Helper.ClearErrorTextBox(errorProvider1, txtReferenceNo);
        }

        private void txtPayee_Validating(object sender, CancelEventArgs e)
        {
            try
            {
                e.Cancel = Helper.ShowErrorTextBoxEmpty(errorProvider1, txtPayee, "Payee.");
            }
            catch (Exception ex) { Helper.MessageBoxError(ex.Message); }
        }

        private void txtPayee_Validated(object sender, EventArgs e)
        {
            Helper.ClearErrorTextBox(errorProvider1, txtPayee);
        }

        private void txtExplanation_Validating(object sender, CancelEventArgs e)
        {
            try
            {
                e.Cancel = Helper.ShowErrorTextBoxEmpty(errorProvider1, txtExplanation, "Explanation.");
            }
            catch (Exception ex) { Helper.MessageBoxError(ex.Message); }
        }

        private void txtExplanation_Validated(object sender, EventArgs e)
        {
            Helper.ClearErrorTextBox(errorProvider1, txtExplanation);
        }
    }
}

