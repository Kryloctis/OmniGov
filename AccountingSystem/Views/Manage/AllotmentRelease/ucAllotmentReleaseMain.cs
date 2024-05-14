using ACC.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Windows.Forms;

namespace AccountingSystem.Views.Manage.AllotmentRelease
{
    public partial class ucAllotmentReleaseMain : UserControl
    {
        internal int allotmentClassId = 0;
        internal int allotmentReleaseId = 0;
        internal int fundId = 0;
        internal bool isEdit = false;

        public ucAllotmentReleaseMain()
        {
            InitializeComponent();
        }

        internal void AutoGenerateSeriesNo()
        {
            mskSeriesNo.Text = AccFactory.AllotmentReleaseRepository().GetLeastAllotmentReleaseNumber();
        }

        internal void CheckedAllotmentClass(int radAllotmentClassId)
        {
            flowLayoutPanelAllotmentClass.Controls.OfType<RadioButton>().FirstOrDefault(r => (Convert.ToInt32(r.Tag) == radAllotmentClassId) ? r.Checked = true : r.Checked = false);
            allotmentClassId = radAllotmentClassId;
        }

        internal void CheckedFund(int radFundId)
        {
            flowLayoutPanelFunds.Controls.OfType<RadioButton>().FirstOrDefault(r => (Convert.ToInt32(r.Tag) == radFundId) ? r.Checked = true : r.Checked = false);
            fundId = radFundId;
        }

        #region FPP Combobox

        internal void LoadFPP()
        {
            try
            {
                cmbxFPP.DroppedDown = false;
                Cursor.Current = Cursors.Default;

                var fppDict = new Dictionary<int, string>();
                foreach (DataRow item in DataTableFPP().Rows)
                {
                    int fppId = Convert.ToInt32(item["id"]);
                    string fppName = $"{item["fpp_code"]} - {item["fpp_name"]}";

                    fppDict.Add(fppId, fppName);
                }

                cmbxFPP.DataSource = DataTableFPP().Rows.Count == 0 ? null : new BindingSource(fppDict, null);
                cmbxFPP.DisplayMember = "value";
                cmbxFPP.ValueMember = "key";

                LoadSubFPPCombobox();
            }
            catch (Exception ex)
            {
                Helper.MessageBoxError(ex.Message);
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

        private void cmbxFPP_SelectedValueChanged(object sender, EventArgs e)
        {
            LoadSubFPPCombobox();
        }

        private void cmbxFPP_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(cmbxFPP.Text))
            {
                LoadFPPCombobox();
                cmbxSubFPP.Enabled = false;
            }

            if (cmbxFPP.FindStringExact(cmbxFPP.Text.Trim()) == -1)
            {
                cmbxSubFPP.Enabled = false;
            }
        }

        private DataTable DataTableFPP()
        {
            DataTable dtFPP;

            if (string.IsNullOrWhiteSpace(cmbxFPP.Text))
                dtFPP = AccFactory.FunctionProgramProjectRepository().GetViewRecords();
            else
                dtFPP = AccFactory.FunctionProgramProjectRepository().GetRecordsByCodeName(cmbxFPP.Text.Trim());

            return dtFPP;
        }

        private void LoadFPPCombobox()
        {
            cmbxFPP.TextChanged -= new EventHandler(cmbxFPP_TextChanged);
            LoadFPP();
            cmbxFPP.Text = string.Empty;
            cmbxFPP.SelectedIndex = -1;
            cmbxFPP.TextChanged += new EventHandler(cmbxFPP_TextChanged);
        }

        #endregion FPP Combobox

        #region Sub FPP Combobox

        internal void LoadSubFPP()
        {
            cmbxSubFPP.DroppedDown = false;
            Cursor.Current = Cursors.Default;

            var subFPPDict = new Dictionary<int, string>();
            foreach (DataRow item in DataTableSubFPP().Rows)
            {
                int subFPPId = Convert.ToInt32(item["id"]);
                string subFPPName = $"{item["others_fpp_code"]} - {item["name"]}";

                subFPPDict.Add(subFPPId, subFPPName);
            }

            cmbxSubFPP.DataSource = subFPPDict.Count == 0 ? null : new BindingSource(subFPPDict, null);
            cmbxSubFPP.DisplayMember = "value";
            cmbxSubFPP.ValueMember = "key";
        }

        internal void LoadSubFPPCombobox()
        {
            LoadSubFPP();

            cmbxSubFPP.TextChanged -= new EventHandler(cmbxSubFPP_TextChanged);
            cmbxSubFPP.Text = string.Empty;
            cmbxSubFPP.SelectedIndex = -1;
            errorProvider1.SetError(cmbxSubFPP, string.Empty);
            cmbxSubFPP.TextChanged += new EventHandler(cmbxSubFPP_TextChanged);
            cmbxSubFPP.Enabled = true;
        }

        private void cmbxSubFPP_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F1 && cmbxSubFPP.FindStringExact(cmbxSubFPP.Text) == -1 && !string.IsNullOrEmpty(cmbxSubFPP.Text))
            {
                LoadSubFPP();
                cmbxSubFPP.SelectedIndex = cmbxSubFPP.Items.Count == 0 ? -1 : 0;
                cmbxSubFPP.DroppedDown = true;
            }
        }

        private void cmbxSubFPP_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(cmbxSubFPP.Text)) LoadSubFPPCombobox();
        }

        private DataTable DataTableSubFPP()
        {
            var dtSubFPP = new DataTable();
            var fppId = Convert.ToInt32(cmbxFPP.SelectedValue);

            if (string.IsNullOrWhiteSpace(cmbxSubFPP.Text))
                dtSubFPP = AccFactory.SubFPPRepository().GetRecordsByFppId(fppId);
            else
                dtSubFPP = AccFactory.SubFPPRepository().GetRecordsByFPPIdCodeName(fppId, cmbxSubFPP.Text);

            return dtSubFPP;
        }

        #endregion Sub FPP Combobox

        internal void ClearErrors()
        {
            errorProvider1.SetError(mskYear, string.Empty);
            errorProvider1.SetError(cmbxFPP, string.Empty);
            errorProvider1.SetError(cmbxSubFPP, string.Empty);
            errorProvider1.SetError(txtPurpose, string.Empty);
        }

        internal void DisplayTotalAllotmentRelease()
        {
            decimal totalAllotmentRelease = 0;

            foreach (DataGridViewRow row in dgAllotmentRelease.Rows)
            {
                totalAllotmentRelease += Convert.ToDecimal(row.Cells["allotment_amount"].Value);
            }

            txtTotal.Text = totalAllotmentRelease.ToString("N2");
        }

        internal string GetFormErrors()
        {
            var errorArray = new string[]
            {
                errorProvider1.GetError(cmbxFPP),
                errorProvider1.GetError(cmbxSubFPP),
                errorProvider1.GetError(mskYear),
                errorProvider1.GetError(txtPurpose),
                dgAllotmentRelease.Tag.ToString()
            };

            return AccFactory.CreateErrors(errorArray).GenerateErrorMessage();
        }

        internal void LoadAllotmentClasses()
        {
            var allotmentClasses = AccFactory.AllotmentClassesRepository().GetRecords();

            flowLayoutPanelAllotmentClass.Controls.Clear();

            foreach (DataRow allotmentClass in allotmentClasses.Rows)
            {
                var radAllotmentClass = new RadioButton
                {
                    Text = allotmentClass["allotment_code"].ToString(),
                    Tag = allotmentClass["id"],
                    AutoSize = true,
                    Appearance = Appearance.Button,
                    TextImageRelation = TextImageRelation.ImageBeforeText
                };

                //making general fund as default
                if (Convert.ToInt32(allotmentClass["id"]) == 1)
                {
                    radAllotmentClass.Checked = true;
                    allotmentClassId = Convert.ToByte(allotmentClass["id"]);
                    ShowCheckIcon(radAllotmentClass);
                }

                flowLayoutPanelAllotmentClass.Controls.Add(radAllotmentClass);

                radAllotmentClass.Click += new EventHandler(RadioAllotmentClass_Click);
                radAllotmentClass.CheckedChanged += new EventHandler(RadioAllotmentClass_CheckedChanged);
            }
        }

        internal void LoadFunds()
        {
            var funds = AccFactory.FundsRepository().GetRecords();

            flowLayoutPanelFunds.Controls.Clear();

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

                //making general fund as default
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

        internal void ResetForm()
        {
            try
            {
                if (isEdit)
                {
                    allotmentReleaseId = 0;
                    isEdit = false;
                }

                cmbxFPP.Text = string.Empty;
                cmbxFPP.SelectedIndex = -1;
                panel1.Enabled = true;
                mskSeriesNo.Text = string.Empty;
                dtDateIssued.Value = DateTime.Now;
                dtDateIssued.Enabled = true;
                dgAllotmentRelease.Rows.Clear();
                txtPurpose.Text = string.Empty;

                LoadFPPCombobox();
                LoadFunds();
                LoadAllotmentClasses();
                ClearErrors();
                DisplayTotalAllotmentRelease();
            }
            catch (Exception ex) { Helper.MessageBoxError(ex.Message); }
        }

        internal bool ShowErrorAllotmentReleaseListEmpty()
        {
            try
            {
                if (dgAllotmentRelease.Rows.Count < 1)
                {
                    dgAllotmentRelease.Tag = "Allotment release list is empty.";
                    return true;
                }
            }
            catch (Exception ex)
            {
                Helper.MessageBoxError(ex.Message);
            }
            return false;
        }

        private bool AllotmentReleaseNoValidated()
        {
            string allotmentReleaseNo = mskSeriesNo.Text.Trim();
            short dateIssued = (short)dtDateIssued.Value.Year;
            bool allotmentReleaseNoExist;

            if (!isEdit)
                allotmentReleaseNoExist = AccFactory.AllotmentReleaseRepository().AllotmentReleaseNoExist(allotmentReleaseNo, dateIssued);
            else
                allotmentReleaseNoExist = AccFactory.AllotmentReleaseRepository().AllotmentReleaseNoExist(allotmentReleaseId, allotmentReleaseNo, dateIssued);

            if (allotmentReleaseNoExist)
            {
                errorProvider1.SetError(mskYear, "ARO No. is already exist.");
                return false;
            }
            return true;
        }

        private bool SeriesNoValidated()
        {
            if (!mskSeriesNo.MaskCompleted)
            {
                errorProvider1.SetError(mskYear, "Series No. is required.");
                return false;
            }
            return true;
        }

        private bool AllotmentReleaseValidated()
        {
            if (!SeriesNoValidated())
                return false;
            else if (!AllotmentReleaseNoValidated())
                return false;

            return true;
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                if (RequiredFieldsValidated())
                {
                    Helper.MessageBoxError(GetRequiredFieldErrors());
                    return;
                }

                var allotmentReleaseAddForm = new frmAllotmentReleaseAdd(this);
                var uc = allotmentReleaseAddForm.ucAllotmentRelease1;
                uc.fppId = Convert.ToInt32(cmbxFPP.SelectedValue);
                uc.othersFPPId = string.IsNullOrEmpty(cmbxSubFPP.Text) ? null : Convert.ToInt32(cmbxSubFPP.SelectedValue);
                uc.fundId = fundId;
                uc.allotmentClassId = Convert.ToInt32(allotmentClassId);
                uc.dateIssued = dtDateIssued.Value;

                allotmentReleaseAddForm.ShowDialog();
            }
            catch (Exception ex) { Helper.MessageBoxError(ex.Message); }
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            try
            {
                if (RequiredFieldsValidated())
                {
                    Helper.MessageBoxError(GetRequiredFieldErrors());
                    return;
                }

                int rowIndex = dgAllotmentRelease.CurrentCell.RowIndex;
                short year = Convert.ToInt16(dgAllotmentRelease.Rows[rowIndex].Cells["year"].Value);
                int budgetAppropriationId = Convert.ToInt32(dgAllotmentRelease.Rows[rowIndex].Cells["budget_appropriation_id"].Value);
                decimal amount = Convert.ToDecimal(dgAllotmentRelease.Rows[rowIndex].Cells["allotment_amount"].Value);
                frmAllotmentReleaseEdit allotmentReleaseEditForm = new frmAllotmentReleaseEdit(this);
                ucAllotmentRelease uc = allotmentReleaseEditForm.ucAllotmentRelease1;
                uc.fppId = Convert.ToInt32(cmbxFPP.SelectedValue);
                uc.othersFPPId = string.IsNullOrEmpty(cmbxSubFPP.Text) ? null : Convert.ToInt32(cmbxSubFPP.SelectedValue);
                uc.fundId = fundId;
                uc.allotmentClassId = Convert.ToInt32(allotmentClassId);
                uc.dateIssued = dtDateIssued.Value;

                uc._budgetAppropriationId = budgetAppropriationId;
                uc._amount = amount;

                uc.nudYear.Value = year;
                uc.nudAmount.Value = amount;

                allotmentReleaseEditForm.ShowDialog();
            }
            catch (Exception ex) { Helper.MessageBoxError(ex.Message); }
        }

        private void btnRemove_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow row in dgAllotmentRelease.SelectedRows)
            {
                dgAllotmentRelease.Rows.Remove(row);
            }

            if (dgAllotmentRelease.Rows.Count == 0 && allotmentReleaseId == 0)
            {
                panel1.Enabled = true;
                dtDateIssued.Enabled = true;
            }
        }

        private void cmbxFPP_Validated(object sender, EventArgs e)
        {
            Helper.ClearErrorComboBox(errorProvider1, cmbxFPP);
        }

        private void cmbxFPP_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrEmpty(cmbxFPP.Text))
                e.Cancel = Helper.ShowErrorComboBoxEmpty(errorProvider1, cmbxFPP, "FPP");
            else
                e.Cancel = ShowErrorFPPNameNotExist(errorProvider1, cmbxFPP);
        }

        private void cmbxSubFPP_Validated(object sender, EventArgs e)
        {
            Helper.ClearErrorComboBox(errorProvider1, cmbxSubFPP);
        }

        private void cmbxSubFPP_Validating(object sender, CancelEventArgs e)
        {
            e.Cancel = ShowErrorOtherFPPNameNotExist(errorProvider1, cmbxSubFPP);
        }

        private void dgAllotmentRelease_SelectionChanged(object sender, EventArgs e)
        {
            try
            {
                EnableDisableButtons();
            }
            catch (Exception ex) { Helper.MessageBoxError(ex.Message); }
        }

        private void dgAllotmentRelease_Validated(object sender, EventArgs e)
        {
            dgAllotmentRelease.Tag = string.Empty;
        }

        private void dgAllotmentRelease_Validating(object sender, CancelEventArgs e)
        {
            e.Cancel = ShowErrorAllotmentReleaseListEmpty();
        }

        private void dtDateIssued_ValueChanged(object sender, EventArgs e)
        {
            mskYear.Text = dtDateIssued.Value.Year.ToString();
        }

        private void EnableDisableButtons()
        {
            int selectedRowCount = dgAllotmentRelease.SelectedRows.Count;

            if (selectedRowCount == 1)
            {
                btnEdit.Enabled = true;
                btnRemove.Enabled = true;
                btnRemove.Text = selectedRowCount.ToString();
            }
            else if (selectedRowCount > 1)
            {
                btnEdit.Enabled = false;
                btnRemove.Enabled = true;
                btnRemove.Text = selectedRowCount.ToString();
            }
        }

        private string GetRequiredFieldErrors()
        {
            var errorArray = new string[]
            {
                errorProvider1.GetError(cmbxFPP),
                errorProvider1.GetError(cmbxSubFPP)
            };

            return AccFactory.CreateErrors(errorArray).GenerateErrorMessage();
        }

        private void LoadDatagridFormat()
        {
            dgAllotmentRelease.Columns.Add("year", "Year");
            dgAllotmentRelease.Columns.Add("budget_appropriation_id", "Budget Appropriations ID");
            dgAllotmentRelease.Columns.Add("account_name", "Account Name");
            dgAllotmentRelease.Columns.Add("account_code", "Account Code");
            dgAllotmentRelease.Columns.Add("allotment_amount", "Amount");

            //Cell Format
            dgAllotmentRelease.Columns["year"].Visible = false;
            dgAllotmentRelease.Columns["budget_appropriation_id"].Visible = false;
            dgAllotmentRelease.Columns["account_name"].Width = 300;
            dgAllotmentRelease.Columns["account_code"].SortMode = DataGridViewColumnSortMode.NotSortable;
            dgAllotmentRelease.Columns["account_name"].SortMode = DataGridViewColumnSortMode.NotSortable;
            dgAllotmentRelease.Columns["allotment_amount"].SortMode = DataGridViewColumnSortMode.NotSortable;
            dgAllotmentRelease.Columns["allotment_amount"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dgAllotmentRelease.Columns["allotment_amount"].DefaultCellStyle.Format = "N2";
        }

        private void mskSeriesNo_Validated(object sender, EventArgs e)
        {
            Helper.ClearMaskedTextboxError(errorProvider1, mskYear);
        }

        private void mskSeriesNo_Validating(object sender, CancelEventArgs e)
        {
            e.Cancel = !AllotmentReleaseValidated();
        }

        private void OnLoad()
        {
            if (!DesignMode)
            {
                LoadFunds();
                LoadAllotmentClasses();
                mskYear.Text = dtDateIssued.Value.Year.ToString();
                Helper.DatagridFullRowSelectStyle(dgAllotmentRelease, true);

                //FPP
                LoadFPP();
                cmbxFPP.SelectedIndex = -1;
                cmbxFPP.TextChanged += new EventHandler(cmbxFPP_TextChanged);
                cmbxFPP.SelectedValueChanged += new EventHandler(cmbxFPP_SelectedValueChanged);

                LoadDatagridFormat();

                cmbxSubFPP.Enabled = false;
                btnRemove.Enabled = false;
                btnEdit.Enabled = false;

                AutoGenerateSeriesNo();
                DisplayTotalAllotmentRelease();
            }
        }

        private void RadioAllotmentClass_CheckedChanged(object sender, EventArgs e)
        {
            var radAllotmentClass = sender as RadioButton;
            ShowCheckIcon(radAllotmentClass);
        }

        private void RadioAllotmentClass_Click(object sender, EventArgs e)
        {
            var radAllotmentClass = sender as RadioButton;
            allotmentClassId = Convert.ToInt32(radAllotmentClass.Tag);
        }

        private void radioFunds_CheckedChanged(object sender, EventArgs e)
        {
            var radFund = sender as RadioButton;
            ShowCheckIcon(radFund);
        }

        private void radioFunds_Click(object sender, EventArgs e)
        {
            var radFund = sender as RadioButton;
            fundId = Convert.ToInt32(radFund.Tag);
        }

        private bool RequiredFieldsValidated()
        {
            if (Helper.ShowErrorComboBoxEmpty(errorProvider1, cmbxFPP, "FPP") || ShowErrorFPPNameNotExist(errorProvider1, cmbxFPP) || ShowErrorOtherFPPNameNotExist(errorProvider1, cmbxSubFPP))
                return true;
            return false;
        }

        private void ShowCheckIcon(RadioButton radioButton)
        {
            if (radioButton.Checked)
                radioButton.Image = Properties.Resources.ok14px;
            else
                radioButton.Image = null;
        }

        private bool ShowErrorFPPNameNotExist(ErrorProvider ep, ComboBox comboBox)
        {
            try
            {
                if (cmbxFPP.FindStringExact(cmbxFPP.Text) < 0 && !string.IsNullOrEmpty(comboBox.Text))
                {
                    ep.SetError(comboBox, "FPP you entered, Doesn't exist in yout record.");
                    return true;
                }
            }
            catch (Exception ex)
            {
                Helper.MessageBoxError(ex.Message);
            }
            return false;
        }

        private bool ShowErrorOtherFPPNameNotExist(ErrorProvider ep, ComboBox comboBox)
        {
            try
            {
                if (cmbxSubFPP.FindStringExact(cmbxSubFPP.Text) < 0 && !string.IsNullOrEmpty(comboBox.Text))
                {
                    ep.SetError(comboBox, "Other FPP you entered doesn't exist on your record.");
                    return true;
                }
            }
            catch (Exception ex)
            {
                Helper.MessageBoxError(ex.Message);
            }
            return false;
        }

        private void txtPurpose_Validated(object sender, EventArgs e)
        {
            Helper.ClearErrorTextBox(errorProvider1, txtPurpose);
        }

        private void txtPurpose_Validating(object sender, CancelEventArgs e)
        {
            e.Cancel = Helper.ShowErrorTextBoxEmpty(errorProvider1, txtPurpose, "Purpose");
        }

        private void ucAllotmentReleaseMain_Load(object sender, EventArgs e)
        {
            try
            {
                OnLoad();
            }
            catch (Exception ex) { Helper.MessageBoxError(ex.Message); }
        }
    }
}