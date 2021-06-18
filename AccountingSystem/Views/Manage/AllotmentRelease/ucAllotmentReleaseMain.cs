using MySql.Data.MySqlClient;
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
    public partial class ucAllotmentReleaseMain : UserControl
    {

        internal int allotmentReleaseId = 0;
        internal int fppId = 0;
        internal int fundId = 0;
        internal int allotmentClassId = 0;

        public ucAllotmentReleaseMain()
        {
            InitializeComponent();
        }


        private void CheckedFund(int radFundId)
        {
            flowLayoutPanelFunds.Controls.OfType<RadioButton>().FirstOrDefault(r => (Convert.ToInt32(r.Tag) == radFundId) ? r.Checked = true : r.Checked = false);
            fundId = radFundId;
        }

        private void CheckedAllotmentClass(int radAllotmentClassId)
        {
            flowLayoutPanelAllotmentClass.Controls.OfType<RadioButton>().FirstOrDefault(r => (Convert.ToInt32(r.Tag) == radAllotmentClassId) ? r.Checked = true : r.Checked = false);
            allotmentClassId = radAllotmentClassId;
        }

        internal void LoadSearched(string aroNo) 
        {
            try
            {
                var dtAllotmentRelease = Factory.AllotmentReleaseRepository().GetViewRecordsByARONo(aroNo);
                allotmentReleaseId = Convert.ToInt32(dtAllotmentRelease.Rows[0]["allotment_release_id"]);
                int fppId = Convert.ToInt32(dtAllotmentRelease.Rows[0]["function_program_project_id"]);
                var subFPPId = dtAllotmentRelease.Rows[0]["others_fpp_id"];
                int fundId = Convert.ToInt32(dtAllotmentRelease.Rows[0]["funds_id"]);
                int allotmentClassId = Convert.ToInt32(dtAllotmentRelease.Rows[0]["allotment_classes_id"]);
                var dateIssued = Convert.ToDateTime(dtAllotmentRelease.Rows[0]["date_issued"]);
                string purpose = dtAllotmentRelease.Rows[0]["purpose"].ToString();

                cmbxFPP.SelectedValue = fppId;
                cmbxSubFPP.SelectedValue = subFPPId == null? 0 : subFPPId;
                CheckedFund(fundId);
                CheckedAllotmentClass(allotmentClassId);
                mskSeriesNo.Text = aroNo;
                dtDateIssued.Value = dateIssued;
                txtPurpose.Text = purpose;

                dgAllotmentRelease.Rows.Clear();

                panel1.Enabled = false;
                dtDateIssued.Enabled = false;


                foreach (DataRow row in dtAllotmentRelease.Rows) 
                {
                    int budgetAppropriationId = Convert.ToInt32(row["budget_appropriations_id"]);
                    string accountName = row["ledger_name"].ToString();
                    string accountCode = row["account_code"].ToString();
                    decimal amount = Convert.ToDecimal(row["amount"]);

                    var records = new object[]
                    {
                        budgetAppropriationId,
                        accountName,
                        accountCode,
                        amount
                    };

                    dgAllotmentRelease.Rows.Add(records);
                }
            }
            catch (MySqlException Mysqlex)
            {
                Helper.MessageBoxError(Mysqlex.Message);
            }
            catch (Exception ex)
            {
                Helper.MessageBoxError(ex.StackTrace);
            }
        }


        //FPP COMBOBOX

        private DataTable DataTableFPP()
        {
            DataTable dtFPP;

            if (string.IsNullOrWhiteSpace(cmbxFPP.Text))
                dtFPP = Factory.FunctionProgramProjectRepository().GetRecords();
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

                LoadSubFPPCombobox();
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

        private void cmbxFPP_SelectedValueChanged(object sender, EventArgs e)
        {
            LoadSubFPPCombobox();
        }


        //SUB FPP COMBOBOX

        private DataTable DataTableSubFPP() 
        {
            var dtSubFPP = new DataTable();
            var fppId = Convert.ToInt32(cmbxFPP.SelectedValue);

            if (string.IsNullOrWhiteSpace(cmbxSubFPP.Text))
                dtSubFPP = Factory.OthersFPPRepository().GetRecordsByFPPId(fppId);
            else
                dtSubFPP = Factory.OthersFPPRepository().GetRecordsByFPPIdCodeName(fppId , cmbxSubFPP.Text);

            return dtSubFPP;
        }

        internal void LoadSubFPP()
        {
            try
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

                cmbxSubFPP.DataSource = new BindingSource(subFPPDict.Count == 0? null : subFPPDict, null);
                cmbxSubFPP.DisplayMember = "value";
                cmbxSubFPP.ValueMember = "key";
            }
            catch (Exception ex)
            {
                Helper.MessageBoxError(ex.Message);
            }
        }

        internal void LoadSubFPPCombobox()
        {
            if (cmbxFPP.SelectedIndex > -1)
            {
                LoadSubFPP();

                cmbxSubFPP.TextChanged -= new EventHandler(cmbxSubFPP_TextChanged);
                cmbxSubFPP.SelectedIndex = -1;
                cmbxSubFPP.Text = string.Empty;
                epSubFPP.SetError(cmbxSubFPP, string.Empty);
                cmbxSubFPP.TextChanged += new EventHandler(cmbxSubFPP_TextChanged);
                cmbxSubFPP.Enabled = true;
            }
            else
            {
                cmbxSubFPP.SelectedIndex = -1;
                cmbxSubFPP.Text = string.Empty;
                cmbxSubFPP.Enabled = false;
            }
        }

        private void cmbxSubFPP_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(cmbxSubFPP.Text))
            {
                cmbxSubFPP.TextChanged -= new EventHandler(cmbxFPP_TextChanged);
                LoadSubFPPCombobox();
                cmbxSubFPP.SelectedIndex = -1;
                cmbxSubFPP.TextChanged += new EventHandler(cmbxFPP_TextChanged);
            }
        }

        private void cmbxSubFPP_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F1 && cmbxSubFPP.FindStringExact(cmbxSubFPP.Text) == -1 && !string.IsNullOrEmpty(cmbxSubFPP.Text))
            {
                LoadSubFPPCombobox();
                cmbxSubFPP.SelectedIndex = 0;
                cmbxSubFPP.DroppedDown = true;
            }
        }



        internal void ResetForm()
        {
            panel1.Enabled = true;
    
            mskSeriesNo.Text = string.Empty;
            dtDateIssued.Value = DateTime.Now;
            dtDateIssued.Enabled = true;

            //FPP
            cmbxFPP.TextChanged -= new EventHandler(cmbxFPP_TextChanged);
            cmbxFPP.SelectedValueChanged -= new EventHandler(cmbxFPP_SelectedValueChanged);
            LoadFPP();
            cmbxFPP.SelectedIndex = -1;
            cmbxFPP.TextChanged += new EventHandler(cmbxFPP_TextChanged);
            cmbxFPP.SelectedValueChanged += new EventHandler(cmbxFPP_SelectedValueChanged);

            LoadAllotmentClasses();
            dgAllotmentRelease.Rows.Clear();
            txtPurpose.Text = string.Empty;
            allotmentReleaseId = 0;
            epARONo.SetError(mskYear, string.Empty);
            epFPP.SetError(cmbxFPP, string.Empty);
            epSubFPP.SetError(cmbxSubFPP, string.Empty);
        }

        internal string GetFormErrors()
        {
            var errorArray = new string[5];

            errorArray[0] = epFPP.GetError(cmbxFPP);
            errorArray[1] = epSubFPP.GetError(cmbxSubFPP);
            errorArray[2] = epARONo.GetError(mskYear);
            errorArray[3] = epPurpose.GetError(txtPurpose);
            errorArray[4] = dgAllotmentRelease.Tag.ToString();

            return Factory.CreateErrors(errorArray).GenerateErrorMessage();
        }

        internal void LoadFunds()
        {
            var funds = Factory.FundsRepository().GetRecords();

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

        internal void LoadAllotmentClasses()
        {
            var allotmentClasses = Factory.AllotmentClassesRepository().GetRecords();

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

        private void LoadDatagridFormat()
        {
            try
            {
                dgAllotmentRelease.Columns.Add("budget_appropriation_id", "Budget Appropriations ID");
                dgAllotmentRelease.Columns.Add("account_name", "Account Name");
                dgAllotmentRelease.Columns.Add("account_code", "Account Code");
                dgAllotmentRelease.Columns.Add("allotment_amount", "Amount");

                //Cell Format
                dgAllotmentRelease.Columns["budget_appropriation_id"].Visible = false;
                dgAllotmentRelease.Columns["account_name"].Width = 300;
                dgAllotmentRelease.Columns["account_code"].SortMode = DataGridViewColumnSortMode.NotSortable;
                dgAllotmentRelease.Columns["account_name"].SortMode = DataGridViewColumnSortMode.NotSortable;
                dgAllotmentRelease.Columns["allotment_amount"].SortMode = DataGridViewColumnSortMode.NotSortable;
                dgAllotmentRelease.Columns["allotment_amount"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                dgAllotmentRelease.Columns["allotment_amount"].DefaultCellStyle.Format = "N2";

            }
            catch (Exception ex)
            {
                Helper.MessageBoxError(ex.Message);
            }
        }

        private void ShowCheckIcon(RadioButton radioButton)
        {
            if (radioButton.Checked)
                radioButton.Image = Properties.Resources.ok14px;
            else
                radioButton.Image = null;
        }

        private void radioFunds_Click(object sender, EventArgs e)
        {
            var radFund = sender as RadioButton;
            fundId = Convert.ToInt32(radFund.Tag);
        }

        private void radioFunds_CheckedChanged(object sender, EventArgs e)
        {
            var radFund = sender as RadioButton;
            ShowCheckIcon(radFund);
        }

        private void RadioAllotmentClass_Click(object sender, EventArgs e)
        {
            var radAllotmentClass = sender as RadioButton;
            allotmentClassId = Convert.ToInt32(radAllotmentClass.Tag);
        }

        private void RadioAllotmentClass_CheckedChanged(object sender, EventArgs e)
        {
            var radAllotmentClass = sender as RadioButton;
            ShowCheckIcon(radAllotmentClass);
        }

        private void dtDateIssued_ValueChanged(object sender, EventArgs e)
        {
            mskYear.Text = dtDateIssued.Value.Year.ToString();
        }

        private void ucAllotmentReleaseMain_Load(object sender, EventArgs e)
        {
            if (!DesignMode)
            {
                LoadFunds();
                LoadAllotmentClasses();
                mskYear.Text = dtDateIssued.Value.Year.ToString();
                Helper.DatagridDefaultStyle(dgAllotmentRelease, true);


                //FPP
                LoadFPP();
                cmbxFPP.SelectedIndex = -1;
                cmbxFPP.TextChanged += new EventHandler(cmbxFPP_TextChanged);
                cmbxFPP.SelectedValueChanged += new EventHandler(cmbxFPP_SelectedValueChanged);
             
                LoadDatagridFormat();

                cmbxSubFPP.Enabled = false;
                btnRemove.Enabled = false;
            }
        }


        private void EnableDisableButtons()
        {
            int selectedRowCount = dgAllotmentRelease.SelectedRows.Count;

            if (selectedRowCount == 1)
            {
                btnRemove.Enabled = true;
                btnRemove.Text = "Remove (" + selectedRowCount + ")";
            }
            else if (selectedRowCount > 1)
            {
                btnRemove.Enabled = true;
                btnRemove.Text = "Remove (" + selectedRowCount + ")";
            }
            else
            {
                btnRemove.Enabled = false;
                btnRemove.Text = "Remove";
            }
        }

        private void dgAllotmentRelease_SelectionChanged(object sender, EventArgs e)
        {
            EnableDisableButtons();
        }

        private void btnRemove_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow row in dgAllotmentRelease.SelectedRows)
            {
                dgAllotmentRelease.Rows.Remove(row);
            }

            if (dgAllotmentRelease.Rows.Count == 0)
            {
                panel1.Enabled = true;
                dtDateIssued.Enabled = true;
            }
        }




        //VALIDATIONS BEFORE SHOWING ADD WINDOW
        private string GetFormErrorsOnAdd() 
        {
            var errorArray = new string[2];

            errorArray[0] = epFPP.GetError(cmbxFPP);
            errorArray[1] = epSubFPP.GetError(cmbxSubFPP);

            return Factory.CreateErrors(errorArray).GenerateErrorMessage();
        }

        private bool validateOnAdd()
        {
            try
            {
                if (Helper.ShowErrorComboBoxEmpty(epFPP, cmbxFPP, "FPP") || ShowErrorFPPNameNotExist(epFPP,cmbxFPP) || ShowErrorOtherFPPNameNotExist(epSubFPP,cmbxSubFPP)) 
                {


                    return true;
                }
            }
            catch (Exception ex)
            {
                Helper.MessageBoxError(ex.Message);
            }
            return false;
        }

        private bool ShowAllotmentReleaseAdd()
        {
            try
            {
                if (validateOnAdd())
                {
                    Helper.MessageBoxError(GetFormErrorsOnAdd());
                    return false;
                }

                var allotmentReleaseAddForm = new frmAllotmentReleaseAdd(this);
                var uc = allotmentReleaseAddForm.ucAllotmentRelease1;
                uc.fppId = Convert.ToInt32(cmbxFPP.SelectedValue);
                uc.othersFPPId = string.IsNullOrEmpty(cmbxSubFPP.Text) ? null : Convert.ToInt32(cmbxSubFPP.SelectedValue);
                uc.fundId = fundId;
                uc.allotmentClassId = Convert.ToInt32(allotmentClassId);
                uc.dateIssued = dtDateIssued.Value;

                allotmentReleaseAddForm.ShowDialog();

                return true;
            }
            catch (Exception ex)
            {
                Helper.MessageBoxError(ex.Message);
            }
            return false;

        }

        private void BtnAdd_Click(object sender, EventArgs e)
        {
            ShowAllotmentReleaseAdd();
        }
  


        //VALIDATIONS

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

        private void cmbxFPP_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrEmpty(cmbxFPP.Text))
                e.Cancel = Helper.ShowErrorComboBoxEmpty(epFPP, cmbxFPP, "FPP");
            else
                e.Cancel = ShowErrorFPPNameNotExist(epFPP, cmbxFPP);
        }

        private void cmbxFPP_Validated(object sender, EventArgs e)
        {
            Helper.ClearErrorComboBox(epFPP, cmbxFPP);
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

        private void cmbxSubFPP_Validating(object sender, CancelEventArgs e)
        {
            e.Cancel = ShowErrorOtherFPPNameNotExist(epSubFPP, cmbxSubFPP);
        }

        private void cmbxSubFPP_Validated(object sender, EventArgs e)
        {
            Helper.ClearErrorComboBox(epSubFPP, cmbxSubFPP);
        }



        private bool AllotmentNotReleaseExist() 
        {
            try
            {
                string allotmentReleaseNo = $"{mskSeriesNo.Text}-{mskYear.Text}";
                bool allotmentReleaseNoExist;

                if (allotmentReleaseId == 0)
                    allotmentReleaseNoExist = Factory.AllotmentReleaseRepository().AllotmentReleaseNoExist(allotmentReleaseNo);
                else
                    allotmentReleaseNoExist = Factory.AllotmentReleaseRepository().AllotmentReleaseNoExist(allotmentReleaseId, allotmentReleaseNo);


                if (allotmentReleaseNoExist) 
                {
                    epARONo.SetError(mskYear, "ARO No. is already exist.");
                    return true;
                }

            }
            catch (Exception ex)
            {
                Helper.MessageBoxError(ex.Message);
            }

            return false;
        }

        private bool ShowErrorSeriesNo()
        {
            try
            {
                if (!mskSeriesNo.MaskCompleted)
                {
                    epARONo.SetError(mskYear, "Series No. is required.");
                    return true;
                }
            }
            catch (Exception ex)
            {
                Helper.MessageBoxError(ex.Message);
            }
            return false;
        }


        private bool AllotmentReleaseValidation() 
        {
            if (ShowErrorSeriesNo())
                return true;
            else if (AllotmentNotReleaseExist())
                return true;

            return false;
        }

        private void mskSeriesNo_Validating(object sender, CancelEventArgs e)
        {
            e.Cancel = AllotmentReleaseValidation();
        }

        private void mskSeriesNo_Validated(object sender, EventArgs e)
        {
            Helper.ClearMaskedTextboxError(epARONo, mskYear);
        }

        private void txtPurpose_Validating(object sender, CancelEventArgs e)
        {
            e.Cancel = Helper.ShowErrorTextBoxEmpty(epPurpose, txtPurpose, "Purpose");
        }

        private void txtPurpose_Validated(object sender, EventArgs e)
        {
            Helper.ClearErrorTextBox(epPurpose, txtPurpose);
        }

        private void dgAllotmentRelease_Validating(object sender, CancelEventArgs e)
        {
            e.Cancel = ShowErrorAllotmentReleaseListEmpty();
        }

        private void dgAllotmentRelease_Validated(object sender, EventArgs e)
        {
            dgAllotmentRelease.Tag = string.Empty;
        }
    }
}
