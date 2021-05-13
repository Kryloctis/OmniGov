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
        internal int fppId = 0;
        internal int fundId = 0;
        internal int allotmentClassId = 0;

        public ucAllotmentReleaseMain()
        {
            InitializeComponent();
        }

        internal string GetFormErrors()
        {
            var errorArray = new string[5];

            errorArray[0] = epFPP.GetError(cmbxFPP);
            errorArray[1] = epOthersFPP.GetError(cmbxOthersFPP);
            errorArray[2] = epARONo.GetError(mskYear);
            errorArray[3] = dgAllotmentRelease.Tag.ToString();
            errorArray[4] = epPurpose.GetError(txtPurpose);

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

        internal void LoadFPPCombobox()
        {
            try
            {
                HelperLoadRecords.FPPComboBox(Factory.FunctionProgramProjectRepository().GetRecords(), cmbxFPP, "fpp_name", "id");
                cmbxFPP.SelectedValueChanged += new EventHandler(CmbxFPP_SelectedValueChanged);
                cmbxFPP.TextChanged += new EventHandler(CmbxFPP_TextChanged);
                cmbxFPP.SelectedIndex = -1;
            }
            catch (Exception ex)
            {
                Helper.MessageBoxError(ex.Message);
            }
        }

        internal void LoadOthersFPPByFPPIdCombobox()
        {
            var fppId = Convert.ToInt32(cmbxFPP.SelectedValue);

            HelperLoadRecords.OthersFPPCombobox(Factory.OthersFPPRepository().GetRecordsByFPPID(fppId), cmbxOthersFPP, "name", "id");
            cmbxOthersFPP.SelectedIndex = -1;
            cmbxOthersFPP.Text = string.Empty;
            cmbxOthersFPP.Enabled = true;
        }

        private void LoadDatagridFormat()
        {
            try
            {
                dgAllotmentRelease.Columns.Add("budget_appropriation_id", "Budget Appropriations ID");
                dgAllotmentRelease.Columns.Add("account_id", "Account ID");
                dgAllotmentRelease.Columns.Add("account_name", "Account Name");
                dgAllotmentRelease.Columns.Add("account_code", "Account Code");
                dgAllotmentRelease.Columns.Add("allotment_amount", "Amount");

                //Cell Format
                dgAllotmentRelease.Columns["budget_appropriation_id"].Visible = false;
                dgAllotmentRelease.Columns["account_id"].Visible = false;
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
                LoadFPPCombobox();
                LoadDatagridFormat();

                cmbxOthersFPP.Enabled = false;
                btnRemove.Enabled = false;
            }
        }

        private void CmbxFPP_SelectedValueChanged(object sender, EventArgs e)
        {
            LoadOthersFPPByFPPIdCombobox();
        }

        private void CmbxFPP_TextChanged(object sender, EventArgs e)
        {
            if (ShowErrorFPPNameNotExist(epFPP, cmbxFPP))
            {
                cmbxOthersFPP.Enabled = false;
                cmbxOthersFPP.SelectedIndex = -1;
                cmbxOthersFPP.Text = string.Empty;
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
        }


        private string GetFormErrorsOnAdd() 
        {
            var errorArray = new string[2];

            errorArray[0] = epFPP.GetError(cmbxFPP);
            errorArray[1] = epOthersFPP.GetError(cmbxOthersFPP);

            return Factory.CreateErrors(errorArray).GenerateErrorMessage();
        }

        private bool validateOnAdd()
        {
            try
            {
                if (Helper.ShowErrorComboBoxEmpty(epFPP, cmbxFPP, "FPP") || ShowErrorFPPNameNotExist(epFPP,cmbxFPP) || ShowErrorOtherFPPNameNotExist(epOthersFPP,cmbxOthersFPP)) 
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
                uc.fppID = Convert.ToInt32(cmbxFPP.SelectedValue);
                uc.othersFPPId = string.IsNullOrEmpty(cmbxOthersFPP.Text) ? null : Convert.ToInt32(cmbxOthersFPP.SelectedValue);
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
                bool fppNameExist = Factory.FunctionProgramProjectRepository().NameExist(cmbxFPP.Text);

                if (!fppNameExist && !string.IsNullOrEmpty(comboBox.Text))
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
                bool otherFPPName = Factory.OthersFPPRepository().NameExist(cmbxOthersFPP.Text);

                if (!otherFPPName && !string.IsNullOrEmpty(comboBox.Text))
                {
                    ep.SetError(comboBox, "Other FPP you entered. Doesn't exist in yout record.");
                    return true;
                }
            }
            catch (Exception ex)
            {
                Helper.MessageBoxError(ex.Message);
            }
            return false;
        }

        private void cmbxOthersFPP_Validating(object sender, CancelEventArgs e)
        {
            e.Cancel = ShowErrorOtherFPPNameNotExist(epOthersFPP, cmbxOthersFPP);
        }

        private void cmbxOthersFPP_Validated(object sender, EventArgs e)
        {
            Helper.ClearErrorComboBox(epOthersFPP, cmbxOthersFPP);
        }



        private bool ShowErrorSeriesNo(ErrorProvider ep, MaskedTextBox maskedTxtSeriesNo, MaskedTextBox maskedTxtYear)
        {
            try
            {
                if (!maskedTxtSeriesNo.MaskCompleted)
                {
                    ep.SetError(maskedTxtYear, "Series No. is required.");
                    return true;
                }
            }
            catch (Exception ex)
            {
                Helper.MessageBoxError(ex.Message);
            }
            return false;
        }

        private void mskSeriesNo_Validating(object sender, CancelEventArgs e)
        {
            e.Cancel = ShowErrorSeriesNo(epARONo, mskSeriesNo, mskYear);
        }

        private void mskSeriesNo_Validated(object sender, EventArgs e)
        {
            Helper.ClearMaskedTextboxError(epARONo, mskYear);
        }

        private void ucAllotmentReleaseMain_Validating(object sender, CancelEventArgs e)
        {
            e.Cancel = ShowErrorAllotmentReleaseListEmpty();
        }

        private void ucAllotmentReleaseMain_Validated(object sender, EventArgs e)
        {
            dgAllotmentRelease.Tag = string.Empty;
        }

        private void txtPurpose_Validating(object sender, CancelEventArgs e)
        {
            e.Cancel = Helper.ShowErrorTextBoxEmpty(epPurpose, txtPurpose, "Purpose");
        }

        private void txtPurpose_Validated(object sender, EventArgs e)
        {
            Helper.ClearErrorTextBox(epPurpose, txtPurpose);
        }
    }
}
