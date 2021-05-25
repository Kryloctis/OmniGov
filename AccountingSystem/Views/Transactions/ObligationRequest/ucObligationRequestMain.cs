using ACC.Domain.Interfaces;
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
        internal string obligationNo;
        internal int fundId;
        internal int allotmentClassId;

        public ucObligationRequestMain()
        {
            InitializeComponent();
        }



        internal void LoadSearched() 
        {
            try
            {
                var dicViewObligationRequest = Factory.ObligationRequestRepository().GetViewRecordByObligationNo(obligationNo);

                int dicobligationRequestId = Convert.ToInt32(dicViewObligationRequest["obligation_request_id"]);
                int fppId = Convert.ToInt32(dicViewObligationRequest["fpp_id"]);
                int othersFPPId = string.IsNullOrEmpty(dicViewObligationRequest["others_fpp_id"]) ? 0 : Convert.ToInt32(dicViewObligationRequest["others_fpp_id"]);
                int fundId = Convert.ToInt32(dicViewObligationRequest["funds_id"]);
                int allotmentClassId = Convert.ToInt32(dicViewObligationRequest["allotment_classes_id"]);
                string obligationNum = dicViewObligationRequest["obligation_no"].ToString();
                DateTime dateRequested = Convert.ToDateTime(dicViewObligationRequest["date_requested"]);
                string referenceNo = dicViewObligationRequest["reference_no"].ToString();
                string payee = dicViewObligationRequest["payee"];
                string explanation = dicViewObligationRequest["explanation"];

                obligationRequestId = dicobligationRequestId;
                cmbxFPP.SelectedValue = fppId;
                cmbxOtherFPP.SelectedValue = othersFPPId;
                CheckedFund(fundId);
                CheckedAllotmentClass(allotmentClassId);
                mskTxtObligationNoSeries.Text = obligationNo;
                dtDateRequest.Value = dateRequested;
                txtReferenceNo.Text = referenceNo;
                txtPayee.Text = payee;
                txtExplanation.Text = explanation;

                LoadObligationRequests(dicobligationRequestId);

            }
            catch (Exception ex)
            {
                Helper.MessageBoxError(ex.Message);
            }
        }

        private void LoadObligationRequests(int dicobligationRequestId)
        {
            dataGridView1.Rows.Clear();

            DataTable dtObligationRequest = Factory.ObligationRequestRepository().GetViewRecordsById(obligationRequestId);

            foreach (DataRow item in dtObligationRequest.Rows)
            {
                var obligationRequest = new object[]
                {
                        item["general_ledger_accounts_id"],
                        item["ledger_accounts_name"],
                        item["obligation_requested_amount"]
                };

                dataGridView1.Rows.Add(obligationRequest);
            }
        }



        private void CheckedFund(int radFundId)
        {
            flowLayoutPanelFunds.Controls.OfType<RadioButton>().FirstOrDefault(r => (Convert.ToInt32(r.Tag) == radFundId) ? r.Checked = true : r.Checked = false);
            fundId = radFundId;
        }

        private void CheckedAllotmentClass (int radAllotmentClassId)
        {
            flowLayoutPanelAllotmentClass.Controls.OfType<RadioButton>().FirstOrDefault(r => (Convert.ToInt32(r.Tag) == radAllotmentClassId) ? r.Checked = true : r.Checked = false);
            allotmentClassId = radAllotmentClassId;
        }

        internal string GetFormErrors()
        {
            var errorArray = new string[7];
            ShowErrorListEmpty();
            errorArray[0] = epFPP.GetError(cmbxFPP);
            errorArray[1] = epOtherFPP.GetError(cmbxOtherFPP);
            errorArray[2] = epObligationNo.GetError(mskTxtObligationNoTemplate);
            errorArray[3] = epReferenceNo.GetError(txtReferenceNo);
            errorArray[4] = epPayee.GetError(txtPayee);
            errorArray[5] = epExplanation.GetError(txtExplanation);
            errorArray[6] = dataGridView1.Tag == null? string.Empty: dataGridView1.Tag.ToString();

            IError _errors = Factory.CreateErrors(errorArray);
            return _errors.GenerateErrorMessage();
        }


        internal bool ShowErrorListEmpty() 
        {
            try
            {
                if (dataGridView1.Rows.Count == 0) 
                {
                    dataGridView1.Tag = "No obligations has been saved. Obligation Request List is empty.";
                    return true;
                }
            }
            catch (Exception ex)
            {
                Helper.MessageBoxError(ex.Message);
            }
            return false;
        }

        internal void ResetForm() 
        {
            cmbxFPP.Enabled = true;
            cmbxOtherFPP.Enabled = true;
            flowLayoutPanelFunds.Enabled = true;
            flowLayoutPanelAllotmentClass.Enabled = true;
            dtDateRequest.Enabled = true;
            cmbxFPP.SelectedIndex = -1;
            cmbxOtherFPP.SelectedIndex = -1;
            CheckedFund(1);
            CheckedAllotmentClass(1);
            mskTxtObligationNoSeries.Text = string.Empty;
            dtDateRequest.Value = DateTime.Now;
            txtReferenceNo.Text = string.Empty;
            txtPayee.Text = string.Empty;
            txtExplanation.Text = string.Empty;
            dataGridView1.Rows.Clear();
            obligationRequestId = 0;
            obligationNo = string.Empty;
        }

        private void LoadDatagridFormat()
        {
            dataGridView1.Columns.Add("account_id", "Account ID");
            dataGridView1.Columns.Add("account_name", "Account Name");
            dataGridView1.Columns.Add("amount", "Amount");

            dataGridView1.Columns["account_id"].SortMode = DataGridViewColumnSortMode.NotSortable;
            dataGridView1.Columns["account_name"].SortMode = DataGridViewColumnSortMode.NotSortable;
            dataGridView1.Columns["account_name"].Width = 400;
            dataGridView1.Columns["amount"].SortMode = DataGridViewColumnSortMode.NotSortable;
            dataGridView1.Columns["amount"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dataGridView1.Columns["amount"].DefaultCellStyle.Format = "N2";

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
            {
                cmbxOtherFPP.Enabled = false;
                cmbxOtherFPP.SelectedIndex = -1;
                cmbxOtherFPP.Text = string.Empty;
            }
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
                btnEdit.Enabled = false;
                btnRemove.Enabled = false;
            }
        }

        private void dtDateRequest_ValueChanged(object sender, EventArgs e)
        {
            mskTxtObligationNoTemplate.Text = GenerateObligationRequestNoTemplate();
        }



        private bool ShowErrorFPPNameNotExist() 
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
                e.Cancel = ShowErrorFPPNameNotExist();
        }

        private void cmbxFPP_Validated(object sender, EventArgs e)
        {
            Helper.ClearErrorComboBox(epFPP, cmbxFPP);
        }




        private bool ShowErrorOthersFPPNameNotExist()
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
                e.Cancel = ShowErrorOthersFPPNameNotExist();
        }

        private void cmbxOtherFPP_Validated(object sender, EventArgs e)
        {
            Helper.ClearErrorComboBox(epOtherFPP, cmbxOtherFPP);
        }




        private bool ShowErrorObligationRequestNoEmpty() 
        {
            if (!mskTxtObligationNoSeries.MaskCompleted)
            {
                epObligationNo.SetError(mskTxtObligationNoTemplate, "Please enter an Obligation No.");
                return true;
            }
            else
                return false;
        }

        private bool ShowErrorObligationRequestNoExist() 
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
            if (ShowErrorObligationRequestNoEmpty())
                e.Cancel = ShowErrorObligationRequestNoEmpty();
            else if (ShowErrorObligationRequestNoExist())
                e.Cancel = ShowErrorObligationRequestNoExist();

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




        internal string GetFormErrorsAdd()
        {
            var errorArray = new string[2];
            errorArray[0] = epFPP.GetError(cmbxFPP);
            errorArray[1] = epOtherFPP.GetError(cmbxOtherFPP);

            IError _errors = Factory.CreateErrors(errorArray);
            return _errors.GenerateErrorMessage();
        }

        private bool ValidateChildrenAdd()
        {
            try
            {
                if (ShowErrorFPPNameNotExist() || Helper.ShowErrorComboBoxEmpty(epFPP, cmbxFPP, "FPP") || ShowErrorOthersFPPNameNotExist())
                {
                    Helper.MessageBoxError(GetFormErrorsAdd());
                    return false;
                }

                Helper.ClearErrorComboBox(epFPP, cmbxFPP);
                Helper.ClearErrorComboBox(epOtherFPP, cmbxOtherFPP);

                return true;
            }
            catch (Exception ex)
            {
                Helper.MessageBoxError(ex.Message);
            }
            return false;
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            ShowObligationRequestAdd();
        }

        private void ShowObligationRequestAdd()
        {
            if (ValidateChildrenAdd()) 
            {
                var frmObligationRequestAdd = new frmObligationRequestAdd(this);
                var ucObligationRequestAdd = frmObligationRequestAdd.ucObligationRequest1;

                ucObligationRequestAdd.fppId = Convert.ToInt32(cmbxFPP.SelectedValue);
                ucObligationRequestAdd.otherFPPId = string.IsNullOrEmpty(cmbxOtherFPP.Text) ? null : Convert.ToInt32(cmbxOtherFPP.SelectedValue);
                ucObligationRequestAdd.fundId = fundId;
                ucObligationRequestAdd.allotmentClassId = allotmentClassId;
                ucObligationRequestAdd.dateRequested = dtDateRequest.Value;

                frmObligationRequestAdd.ShowDialog();
            }
        }

        private void btnRemove_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow item in dataGridView1.SelectedRows)
            {
                dataGridView1.Rows.Remove(item);
            }
        }



        private void EnableDisableButtons()
        {
            int selectedRowCount = dataGridView1.SelectedRows.Count;

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

        private void dataGridView1_SelectionChanged(object sender, EventArgs e)
        {
            EnableDisableButtons();
        }





        private void ShowObligationRequestEdit()
        {
            if (ValidateChildrenAdd())
            {
                var _frmObligationRequestEdit = new frmObligationRequestEdit(this);
                var ucObligationRequestEdit = _frmObligationRequestEdit.ucObligationRequest1;


                int rowIndex = dataGridView1.CurrentCell.RowIndex;
                int accountId = Convert.ToInt32(dataGridView1.Rows[rowIndex].Cells["account_id"].Value);
                decimal amount = Convert.ToDecimal(dataGridView1.Rows[rowIndex].Cells["amount"].Value);

                ucObligationRequestEdit.selectedAccountId = accountId;

                ucObligationRequestEdit.fppId = Convert.ToInt32(cmbxFPP.SelectedValue);
                ucObligationRequestEdit.otherFPPId = string.IsNullOrEmpty(cmbxOtherFPP.Text) ? null : Convert.ToInt32(cmbxOtherFPP.SelectedValue);
                ucObligationRequestEdit.fundId = fundId;
                ucObligationRequestEdit.allotmentClassId = allotmentClassId;
                ucObligationRequestEdit.dateRequested = dtDateRequest.Value;
                ucObligationRequestEdit.currentObligationAmount = amount;
                ucObligationRequestEdit.nudAmount.Value = amount;

                _frmObligationRequestEdit.ShowDialog();
            }
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            ShowObligationRequestEdit();
        }
    }
}
