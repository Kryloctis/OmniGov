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
        internal int obligationRequestId = 0;
        internal int fundId;
        internal int  allotmentClassId;

        public ucObligationRequestMain()
        {
            InitializeComponent();
        }


        private void LoadDatagridFormat()
        {
            dataGridView1.Columns.Add("account_id", "Account ID");
            dataGridView1.Columns.Add("account_name", "Account Name");
            dataGridView1.Columns.Add("amount", "Amount");

            dataGridView1.Columns["account_id"].SortMode = DataGridViewColumnSortMode.NotSortable;
            dataGridView1.Columns["account_name"].SortMode = DataGridViewColumnSortMode.NotSortable;
            dataGridView1.Columns["amount"].SortMode = DataGridViewColumnSortMode.NotSortable;

            dataGridView1.Columns["account_id"].Visible = false;
            Helper.DatagridDefaultStyle(dataGridView1, true);
        }


        internal string GenerateObligationRequestNoTemplate() 
        {
            string fundCode = Factory.FundsRepository().GetRecordByID(fundId)["fund_code"];

            string obligationNoTemplate = $"{dtDateRequest.Value.ToString("MM")}-{dtDateRequest.Value.ToString("yy")}-{fundCode}";

            return obligationNoTemplate;
        }


        private void LoadFPP() 
        {
            try
            {
                var dtFPP = Factory.FunctionProgramProjectRepository().GetRecords();

                cmbxFPP.TextChanged -= new EventHandler(CmbxFPP_TextChanged);
                HelperLoadRecords.FPPComboBox(dtFPP, cmbxFPP , "fpp_name", "id");
                cmbxFPP.SelectedIndex = -1;
                cmbxOtherFPP.Text = string.Empty;
                cmbxFPP.SelectedValueChanged += new EventHandler(CmbxFPP_SelectedValueChanged);
                cmbxFPP.TextChanged += new EventHandler(CmbxFPP_TextChanged);
            }
            catch (Exception ex)
            {
                Helper.MessageBoxError(ex.Message);
            }
        }

        private void CmbxFPP_TextChanged(object sender, EventArgs e)
        {
            var fppNameExist = Factory.FunctionProgramProjectRepository().NameExist(cmbxFPP.Text);

            if (fppNameExist)
            {
                LoadOtherFPP();
                cmbxOtherFPP.Enabled = true;
            }
            else
                cmbxOtherFPP.Enabled = false;
        }

        private void CmbxFPP_SelectedValueChanged(object sender, EventArgs e)
        {
            LoadOtherFPP();
        }

        private void LoadOtherFPP() 
        {
            try
            {
                var dtOtherFPP = Factory.OthersFPPRepository().GetRecordsByFPPID(Convert.ToInt32(cmbxFPP.SelectedValue));

                HelperLoadRecords.OthersFPPCombobox(dtOtherFPP, cmbxOtherFPP, "name", "id");
                cmbxOtherFPP.SelectedIndex = -1;
                cmbxOtherFPP.Text = string.Empty;
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
                if (Convert.ToInt32(fund["id"])  == 1)
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



        private void ucObligationRequestMain_Load(object sender, EventArgs e)
        {
            if (!DesignMode) 
            {
                LoadFPP();
                LoadFunds();
                LoadAllotmentClasses();
                LoadDatagridFormat();
                mskTxtObligationNoTemplate.Text = GenerateObligationRequestNoTemplate();
                cmbxOtherFPP.Enabled = false;
            }
        }

        private void dtDateRequest_ValueChanged(object sender, EventArgs e)
        {
            mskTxtObligationNoTemplate.Text = GenerateObligationRequestNoTemplate();
        }



        private bool FPPNameNotExist() 
        {
            try
            {
                string fppName = cmbxFPP.Text;

                bool fppNameExist = Factory.FunctionProgramProjectRepository().NameExist(fppName);

                if (!fppNameExist && !string.IsNullOrEmpty(fppName))
                {
                    epFPP.SetError(cmbxFPP, "FPP you entered doesn't exist on your record");
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
                e.Cancel = FPPNameNotExist();
        }

        private void cmbxFPP_Validated(object sender, EventArgs e)
        {
            Helper.ClearErrorComboBox(epFPP, cmbxFPP);
        }




        private bool OthersFPPNameNotExist()
        {
            try
            {
                string otherFPPName = cmbxOtherFPP.Text;

                bool otherFPPNameExist = Factory.OthersFPPRepository().NameExist(otherFPPName);

                if (!otherFPPNameExist && !string.IsNullOrEmpty(otherFPPName))
                {
                    epOtherFPP.SetError(cmbxOtherFPP, "Other FPP you entered doesn't exist on your record");
                    return true;
                }

            }
            catch (Exception ex)
            {
                Helper.MessageBoxError(ex.Message);
            }
            return false;
        }

        private void cmbxOtherFPP_Validating(object sender, CancelEventArgs e)
        {
                e.Cancel = OthersFPPNameNotExist();
        }

        private void cmbxOtherFPP_Validated(object sender, EventArgs e)
        {
            Helper.ClearErrorComboBox(epOtherFPP, cmbxOtherFPP);
        }




        private bool ObligationRequestNoEmpty() 
        {
            if (!mskTxtObligationNoSeries.MaskCompleted)
            {
                epObligationNo.SetError(mskTxtObligationNoTemplate, "Please enter an Obligation No.");
                return true;
            }
            else
                return false;
        }

        private bool ObligationRequestNoExist() 
        {
            try
            {
                string obligationNo = $"{mskTxtObligationNoSeries.Text}-{GenerateObligationRequestNoTemplate()}";

                bool obligationRequestNoExist;

                if (obligationRequestId == 0)
                    obligationRequestNoExist = Factory.ObligationRequestRepository().ObligationRequestNoExist(obligationNo);
                else
                    obligationRequestNoExist = Factory.ObligationRequestRepository().ObligationRequestNoExist(obligationRequestId, obligationNo);


                if (obligationRequestNoExist)
                {
                    epObligationNo.SetError(mskTxtObligationNoTemplate, "Obligation Request No. is already exist on your record");
                    return true;
                }
            }
            catch (Exception ex)
            {
                Helper.MessageBoxError(ex.Message);
            }
            return false;
        }

        private void mskTxtObligationNoSeries_Validating(object sender, CancelEventArgs e)
        {
            if (ObligationRequestNoEmpty())
                e.Cancel = ObligationRequestNoEmpty();
            else if (ObligationRequestNoExist())
                e.Cancel = ObligationRequestNoExist();

        }

        private void mskTxtObligationNoSeries_Validated(object sender, EventArgs e)
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



        private void btnAdd_Click(object sender, EventArgs e)
        {
            ShowObligationRequestAdd();
        }

        private void ShowObligationRequestAdd()
        {
            var frmObligationRequestAdd = new frmObligationRequestAdd();
            var ucObligationRequestAdd = frmObligationRequestAdd.ucObligationRequest1;

            ucObligationRequestAdd.fppId = Convert.ToInt32(cmbxFPP.SelectedValue);
            ucObligationRequestAdd.otherFPPId = string.IsNullOrEmpty(cmbxOtherFPP.Text)? null : Convert.ToInt32(cmbxOtherFPP.SelectedValue);
            ucObligationRequestAdd.fundId = fundId;
            ucObligationRequestAdd.allotmentClassId = allotmentClassId;
            ucObligationRequestAdd.dateRequested = dtDateRequest.Value;

            frmObligationRequestAdd.ShowDialog();
        }
    }
}
