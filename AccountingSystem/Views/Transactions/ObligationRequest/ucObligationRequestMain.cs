using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AccountingSystem.Views.Transactions.ObligationRequest
{
    public partial class ucObligationRequestMain : UserControl
    {
        internal int fundId = 0;
        internal int allotmentClassId = 0;

        public ucObligationRequestMain()
        {
            InitializeComponent();
        }

        internal string GetFormErrors()
        {
            var errorArray = new string[6];

            errorArray[0] = epFPP.GetError(cmbxFPP);
            errorArray[1] = epOtherFPP.GetError(cmbxOthersFPP);
            errorArray[2] = epObligationNo.GetError(mskTxtObligationNoTemplate);
            errorArray[3] = epPayee.GetError(txtPayee);
            errorArray[4] = epExplanation.GetError(txtExplanation);
            errorArray[5] = epReferenceNo.GetError(txtReferenceNo);

            return Factory.CreateErrors(errorArray).GenerateErrorMessage();
        }

        internal void LoadOthersFPPByFPPIdCombobox()
        {
            var fppId = Convert.ToInt32(cmbxFPP.SelectedValue);

            HelperLoadRecords.OthersFPPCombobox(Factory.OthersFPPRepository().GetRecordsByFPPID(fppId), cmbxOthersFPP, "name", "id");
            cmbxOthersFPP.SelectedIndex = -1;
            cmbxOthersFPP.Text = string.Empty;
            cmbxOthersFPP.Enabled = true;
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

        private void CmbxFPP_TextChanged(object sender, EventArgs e)
        {
            if (FPPNameExist(epFPP, cmbxFPP) || string.IsNullOrEmpty(cmbxFPP.Text))
            {
                cmbxOthersFPP.Enabled = false;
                cmbxOthersFPP.SelectedIndex = -1;
                cmbxOthersFPP.Text = string.Empty;
            }
        }

        private void CmbxFPP_SelectedValueChanged(object sender, EventArgs e)
        {
            LoadOthersFPPByFPPIdCombobox();
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

                radFund.Click += new EventHandler(RadioFunds_Click);
                radFund.CheckedChanged += new EventHandler(RadioFunds_CheckedChanged);
            }
        }

        internal void LoadAllotmentClasses()
        {
            var allotmentClasses = Factory.AllotmentClassesRepository().GetRecords();

            flowLayoutPanelAllotment.Controls.Clear();

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

                flowLayoutPanelAllotment.Controls.Add(radAllotmentClass);

                radAllotmentClass.Click += new EventHandler(RadioAllotmentClass_Click);
                radAllotmentClass.CheckedChanged += new EventHandler(RadioAllotmentClass_CheckedChanged);
            }
        }

        private void ShowCheckIcon(RadioButton radioButton)
        {
            if (radioButton.Checked)
                radioButton.Image = Properties.Resources.ok14px;
            else
                radioButton.Image = null;
        }

        private void RadioAllotmentClass_CheckedChanged(object sender, EventArgs e)
        {
            var radAllotment = sender as RadioButton;
            ShowCheckIcon(radAllotment);
        }

        private void RadioAllotmentClass_Click(object sender, EventArgs e)
        {
            var radAllotment = sender as RadioButton;
            allotmentClassId = Convert.ToInt32(radAllotment.Tag);
        }

        private void RadioFunds_CheckedChanged(object sender, EventArgs e)
        {
            var radFund = sender as RadioButton;
            ShowCheckIcon(radFund);
        }

        private void RadioFunds_Click(object sender, EventArgs e)
        {
            var radFund = sender as RadioButton;
            fundId = Convert.ToInt32(radFund.Tag);
            GenerateObligationNo(mskTxtObligationNoTemplate);
        }

        private void GenerateObligationNo(MaskedTextBox maskedTextBox) 
        {
            string month = dtDateRequested.Value.ToString("MM");
            string year = dtDateRequested.Value.ToString("yy");
            string fundCode = Factory.FundsRepository().GetRecordByID(fundId)["fund_code"].ToString();

            string obligationNoTemplate = $"{month}-{year}-{fundCode}0";

            maskedTextBox.Text = obligationNoTemplate;
        }

        #region Validations

        private bool FPPNameExist(ErrorProvider ep, ComboBox comboBox)
        {
            try
            {
                string fppName = comboBox.Text;
                bool fppNameExist = Factory.FunctionProgramProjectRepository().NameExist(fppName);

                if (!fppNameExist && !string.IsNullOrEmpty(fppName))
                {
                    ep.SetError(comboBox, "FPP you entered. Doesn't exist in yout record.");
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
                e.Cancel = FPPNameExist(epFPP, cmbxFPP);
        }

        private void cmbxFPP_Validated(object sender, EventArgs e)
        {
            Helper.ClearErrorComboBox(epFPP, cmbxFPP);
        }

        private bool OthersFPPNameExist(ErrorProvider ep, ComboBox comboBox)
        {
            try
            {
                string otherFPPName = comboBox.Text;
                bool otherFPPExist = Factory.OthersFPPRepository().NameExist(otherFPPName);

                if (!otherFPPExist && !string.IsNullOrEmpty(otherFPPName))
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
            e.Cancel = OthersFPPNameExist(epOtherFPP, cmbxOthersFPP);
        }

        private void cmbxOthersFPP_Validated(object sender, EventArgs e)
        {
            Helper.ClearErrorComboBox(epOtherFPP, cmbxOthersFPP);
        }

        private void dtDateRequested_ValueChanged(object sender, EventArgs e)
        {
            GenerateObligationNo(mskTxtObligationNoTemplate);
        }

        private void ucObligationRequestMain_Load(object sender, EventArgs e)
        {
            if (!DesignMode)
            {
                Helper.DatagridDefaultStyle(dgObligationRequests, true);
                LoadFPPCombobox();
                LoadFunds();
                LoadAllotmentClasses();
                GenerateObligationNo(mskTxtObligationNoTemplate);
                cmbxOthersFPP.Enabled = false;
            }
        }

        private void txtPayee_Validating(object sender, CancelEventArgs e)
        {
            e.Cancel = Helper.ShowErrorTextBoxEmpty(epPayee, txtPayee, "Payee");
        }

        private void txtPayee_Validated(object sender, EventArgs e)
        {
            Helper.ClearErrorTextBox(epPayee, txtPayee);
        }

        private void txtExplanation_Validating(object sender, CancelEventArgs e)
        {
            e.Cancel = Helper.ShowErrorTextBoxEmpty(epExplanation, txtExplanation, "Explanation");
        }

        private void txtExplanation_Validated(object sender, EventArgs e)
        {
            Helper.ClearErrorTextBox(epExplanation, txtExplanation);
        }

        private bool ObligationSeriesNo(ErrorProvider ep, MaskedTextBox mskTxtSeriesNo, MaskedTextBox mskTxtObligationNoTemplate)
        {
            try
            {
                if (!mskTxtSeriesNo.MaskCompleted)
                {
                    ep.SetError(mskTxtObligationNoTemplate, "Obligation Series No. is required.");
                    return true;
                }
            }
            catch (Exception ex)
            {
                Helper.MessageBoxError(ex.Message);
            }
            return false;
        }

        private void mskObligationSeriesNo_Validating(object sender, CancelEventArgs e)
        {
            e.Cancel = ObligationSeriesNo(epObligationNo, mskObligationSeriesNo, mskTxtObligationNoTemplate);
        }

        private void mskObligationSeriesNo_Validated(object sender, EventArgs e)
        {
            Helper.ClearMaskedTextboxError(epObligationNo, mskTxtObligationNoTemplate);
        }

        private void txtReferenceNo_Validating(object sender, CancelEventArgs e)
        {
            e.Cancel = Helper.ShowErrorTextBoxEmpty(epReferenceNo, txtReferenceNo, "Reference No.");
        }

        private void txtReferenceNo_Validated(object sender, EventArgs e)
        {
            Helper.ClearErrorTextBox(epReferenceNo, txtReferenceNo);
        }

        #endregion Validations

        private void ShowObligationRequestAdd()
        {
            var frmObligationRequestAdd = new frmObligationRequestAdd();
            var ucObligationRequestAdd = frmObligationRequestAdd.ucObligationRequest1;

            ucObligationRequestAdd.allotmentClassId = allotmentClassId;

            frmObligationRequestAdd.ShowDialog();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            ShowObligationRequestAdd();
        }   


    }   
}
