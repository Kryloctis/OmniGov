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
        private int fundId = 0;
        private int allotmentClassId = 0;

        public ucAllotmentReleaseMain()
        {
            InitializeComponent();
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

                // making general fund as default
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

                // making general fund as default
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

            HelperLoadRecords.OthersFPPCombobox(Factory.OthersFPPRepository().GetRecordsByFPPID(fppId), cmbxOthersFPP,"name","id");
            cmbxOthersFPP.SelectedIndex = -1;
            cmbxOthersFPP.Text = string.Empty;
            cmbxOthersFPP.Enabled  = true;
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

                cmbxOthersFPP.Enabled = false;  
            }
        }

        private void BtnAdd_Click(object sender, EventArgs e)
        {
            var allotmentReleaseAddForm = new frmAllotmentReleaseAdd();
            allotmentReleaseAddForm.ShowDialog();
        }


        //Combobox FPP

        private void CmbxFPP_SelectedValueChanged(object sender, EventArgs e) 
        {
            LoadOthersFPPByFPPIdCombobox();
        }

        private void CmbxFPP_TextChanged(object sender, EventArgs e) 
        {
            if (ShowErrorFPPNameExist(epFPP, cmbxFPP)) 
            {
                cmbxOthersFPP.Enabled = false;
                cmbxOthersFPP.SelectedIndex = -1;
                cmbxOthersFPP.Text = string.Empty;
            }
        }

        #region Custom Validation Controls

        private bool ShowErrorFPPNameExist(ErrorProvider ep, ComboBox comboBox) 
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

        private bool ShowErrorOtherFPPNameExist(ErrorProvider ep, ComboBox comboBox) 
        {
            try
            {
                if (cmbxOthersFPP.FindStringExact(cmbxOthersFPP.Text) < 0 && !string.IsNullOrEmpty(comboBox.Text)) 
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

        #endregion Custom Validation Controls


        #region Validations

        private void cmbxFPP_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrEmpty(cmbxFPP.Text))
                e.Cancel = Helper.ShowErrorComboBoxEmpty(epFPP, cmbxFPP, "FPP");
            else
                e.Cancel = ShowErrorFPPNameExist(epFPP, cmbxFPP);
        }

        private void cmbxFPP_Validated(object sender, EventArgs e)
        {
            Helper.ClearErrorComboBox(epFPP, cmbxFPP);
        }


        private void cmbxOthersFPP_Validating(object sender, CancelEventArgs e)
        {
             e.Cancel = ShowErrorOtherFPPNameExist(epOthersFPP, cmbxOthersFPP);
        }

        private void cmbxOthersFPP_Validated(object sender, EventArgs e)
        {
            Helper.ClearErrorComboBox(epOthersFPP, cmbxOthersFPP);
        }


        private void mskSeriesNo_Validating(object sender, CancelEventArgs e)
        {
            e.Cancel = ShowErrorSeriesNo(epARONo, mskSeriesNo, mskYear);
        }

        private void mskSeriesNo_Validated(object sender, EventArgs e)
        {
            Helper.ClearMaskedTextboxError(epARONo, mskYear);
        }

        #endregion Validations
    }
}
