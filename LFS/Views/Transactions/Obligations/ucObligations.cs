using ACC.Data;
using LFS.Helpers;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Windows.Forms;

namespace LFS.Views.Transactions.ObligationRequest
{
    public partial class ucObligations : UserControl
    {
        private bool isEdit = false;
        private int oblgtnRqstId;
        private int fundId;
        private int allotmentClassId;

        public ucObligations()
        {
            InitializeComponent();
        }

        private void OnLoad(bool isEdit, int? oblgtnRqstId)
        {
            LoadFPP();
            cmbxFPP.SelectedIndex = -1;
            cmbxFPP.TextChanged += new EventHandler(cmbxFPP_TextChanged);

            LoadFunds();
            LoadAllotmentClasses();
            LoadDatagridFormat();
            GetTotalObligations();
            GenerateSeriesNo();
        }

        internal void ResetForm()
        {
            if (isEdit)
            {
                isEdit = false;
                oblgtnRqstId = 0;
                fundId = 0;
                allotmentClassId = 0;
            }

            cmbxFPP.SelectedValue = 0;
            cmbxFPP.Text = string.Empty;
            mskTxtOblgtnNo.Text = string.Empty;
            dtDateRequest.Value = DateTime.Now;
            txtReferenceNo.Text = string.Empty;
            txtPayee.Text = string.Empty;
            txtExplanation.Text = string.Empty;
            dgObligationRequests.Rows.Clear();
            txtTotalObligations.Text = "0.00";
            GenerateSeriesNo();
            SetFieldsReadOnly(false);
        }

        internal string GetFormErrors()
        {
            var errorArray = new string[]
            {
                errorProvider1.GetError(cmbxFPP),
                errorProvider1.GetError(txtReferenceNo),
                errorProvider1.GetError(txtPayee),
                errorProvider1.GetError(txtExplanation),
            };

            return AccFactory.CreateErrors(errorArray).GenerateErrorMessage();
        }

        internal void GenerateSeriesNo()
        {
            try
            {
                mskTxtOblgtnNo.Text = AccFactory.ObligationRequestRepository().GetLeastAllotmentReleaseNumber();
            }
            catch (Exception ex)
            {
                Helper.MessageBoxError(ex.Message);
            }
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
            mskTxtOblgtnNo.ReadOnly = isReadOnly;
            dtDateRequest.Enabled = !isReadOnly;
            txtReferenceNo.ReadOnly = isReadOnly;
            txtPayee.ReadOnly = isReadOnly;
            txtExplanation.ReadOnly = isReadOnly;

            if (isReadOnly)
                dgObligationRequests.SelectionChanged -= new EventHandler(dgObligationRequests_SelectionChanged);
            else
                dgObligationRequests.SelectionChanged += new EventHandler(dgObligationRequests_SelectionChanged);
        }

        internal void EnableDisableComponents(bool enableComponents)
        {
            cmbxFPP.Enabled = enableComponents;
            dtDateRequest.Enabled = enableComponents;
        }

        private void dgObligationRequests_SelectionChanged(object sender, EventArgs e)
        {
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

        private void ShowCheckIcon(RadioButton radioButton)
        {
            if (radioButton.Checked)
                radioButton.Image = Properties.Resources.ok14px;
            else
                radioButton.Image = null;
        }

        internal void LoadFunds()
        {
            var funds = AccFactory.FundsRepository().GetRecords();

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

                radFund.Click += new EventHandler(radioFunds_Click);
                radFund.CheckedChanged += new EventHandler(radioFunds_CheckedChanged);
            }
        }

        private void radioFunds_Click(object sender, EventArgs e)
        {
            var radFund = sender as RadioButton;
            fundId = Convert.ToByte(radFund.Tag);
        }

        private void radioFunds_CheckedChanged(object sender, EventArgs e)
        {
            var radFund = sender as RadioButton;
            ShowCheckIcon(radFund);
        }

        internal void LoadAllotmentClasses()
        {
            var dtAllotmentClass = AccFactory.AllotmentClassesRepository().GetRecords();

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
            string fundCode = AccFactory.FundsRepository().GetRecordByID(fundId)["fund_code"];

            string obligationNoTemplate = $"{dtDateRequest.Value.ToString("MM")}-{dtDateRequest.Value.ToString("yy")}-{fundCode}";

            return obligationNoTemplate;
        }

        private void dtDateRequest_ValueChanged(object sender, EventArgs e)
        {
        }

        internal string GetFormErrorsAdd()
        {
            var errorArray = new string[]
            {
                errorProvider1.GetError(cmbxFPP)
            };

            return AccFactory.CreateErrors(errorArray).GenerateErrorMessage();
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
    }
}