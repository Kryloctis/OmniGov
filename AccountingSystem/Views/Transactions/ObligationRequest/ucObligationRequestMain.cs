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
        internal int fundId;
        internal int allotmentClassId;

        private frmObligationRequestMain _frmObligationRequestMain;

        public ucObligationRequestMain()
        {
            InitializeComponent();
        }


        internal void LoadReferenceObligationRequestMain(frmObligationRequestMain frmObligationRequestMain) 
        {
            _frmObligationRequestMain = frmObligationRequestMain;
        }

        internal string GetFormErrors()
        {
            var errorArray = new string[3];
            errorArray[0] = epFPP.GetError(cmbxFPP);
            errorArray[1] = epOthersFPP.GetError(cmbxOthersFPP);
            errorArray[2] = epAccount.GetError(cmbxAccount);

            return Factory.CreateErrors(errorArray).GenerateErrorMessage();
        }

        private decimal GetTotalObligations() 
        {
            decimal totalObligation = 0;

            foreach (DataGridViewRow item in dgObligationRequests.Rows) 
            {
                totalObligation += Convert.ToDecimal(item.Cells["obligation_amount"].Value);
            }

            return totalObligation;
        }

        internal void LoadObligationRequestRecords() 
        {

            int fppId = Convert.ToInt32(cmbxFPP.SelectedValue);
            int? otherFPPId = string.IsNullOrEmpty(cmbxOthersFPP.Text) ? null : Convert.ToInt32(cmbxOthersFPP.SelectedValue);
            int accountId = Convert.ToInt32(cmbxAccount.SelectedValue);
            byte month = Convert.ToByte(cmbxMonths.SelectedValue);
            short year = Convert.ToInt16(nudYear.Value);

            dgObligationRequests.Rows.Clear();
            dgObligationRequests.Columns.Clear();

            dgObligationRequests.Columns.Add("obligation_request_id", "Obligation Request ID");
            dgObligationRequests.Columns.Add("obligation_no", "Obligation No.");
            dgObligationRequests.Columns.Add("account_code", "Account Code");
            dgObligationRequests.Columns.Add("account_name", "Account Name");
            dgObligationRequests.Columns.Add("date_requested", "Date of Request");
            dgObligationRequests.Columns.Add("obligation_amount", "Amount");
            dgObligationRequests.Columns.Add("created_at", "Created at");
            dgObligationRequests.Columns.Add("updated_at", "Updated at");


            dgObligationRequests.Columns["created_at"].Visible = false;
            dgObligationRequests.Columns["updated_at"].Visible = false;
            dgObligationRequests.Columns["obligation_request_id"].Visible = false;
            dgObligationRequests.Columns["obligation_no"].Width = 100;
            dgObligationRequests.Columns["obligation_no"].Resizable = DataGridViewTriState.False;
            dgObligationRequests.Columns["account_code"].Width = 100;
            dgObligationRequests.Columns["account_code"].Resizable = DataGridViewTriState.False;
            dgObligationRequests.Columns["date_requested"].DefaultCellStyle.Format = "MMM/dd/yyyy";
            dgObligationRequests.Columns["date_requested"].Width = 100;
            dgObligationRequests.Columns["date_requested"].Resizable = DataGridViewTriState.False;
            dgObligationRequests.Columns["obligation_amount"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dgObligationRequests.Columns["obligation_amount"].DefaultCellStyle.Format = "N2";


            var dtObligationRequestRecords = Factory.ObligationRequestRepository().GetViewRecordsByIdsAndMonthAndYear(fppId, otherFPPId, fundId, allotmentClassId, accountId, month, year);
            
            HelperLoadRecords.ObligationRequestDatagridView(dtObligationRequestRecords,dgObligationRequests);

            txtTotalObligation.Text = GetTotalObligations().ToString("N2");

            _frmObligationRequestMain.lblRecordCount.Text = dgObligationRequests.Rows.Count.ToString(); 
        }

        private void LoadFPP()
        {
            cmbxFPP.TextChanged -= new EventHandler(CmbxFPP_TextChanged);
            cmbxFPP.SelectedValueChanged -= new EventHandler(CmmbxFPP_SelectedValueChanged);

            var fppRepo = Factory.FunctionProgramProjectRepository().GetRecords();
            HelperLoadRecords.FPPComboBox(fppRepo, cmbxFPP, "fpp_name", "id");
            cmbxFPP.SelectedIndex = -1;

            cmbxFPP.TextChanged += new EventHandler(CmbxFPP_TextChanged);
            cmbxFPP.SelectedValueChanged += new EventHandler(CmmbxFPP_SelectedValueChanged);
        }

        private void CmbxFPP_TextChanged(object sender, EventArgs e)
        {
            var fppNameExist = Factory.FunctionProgramProjectRepository().NameExist(cmbxFPP.Text);

            if (!fppNameExist)
            {
                cmbxOthersFPP.DataSource = null;
                cmbxOthersFPP.Text = string.Empty;
                cmbxOthersFPP.Enabled = false;
            }
            else
                LoadOthersFPP();
        }

        private void CmmbxFPP_SelectedValueChanged(object sender, EventArgs e)
        {
            LoadOthersFPP();
        }


        private void LoadOthersFPP()
        {
            int fppId = Convert.ToInt32(cmbxFPP.SelectedValue);

            var othersFPPRepo = Factory.OthersFPPRepository().GetRecordsByFPPID(fppId);
            HelperLoadRecords.OthersFPPCombobox(othersFPPRepo, cmbxOthersFPP, "name", "id");
            cmbxOthersFPP.SelectedIndex = -1;
            cmbxOthersFPP.Enabled = true;
        }


        private void LoadAccounts()
        {
            try
            {

                var allotmentClassRepo = Factory.AllotmentClassesRepository().GetRecordByID(allotmentClassId);

                string allotmentClassName = allotmentClassRepo["allotment_name"];

                DataTable dtAccounts;

                cmbxAccount.TextChanged -= new EventHandler(CmbxAccount_TextChanged);

                if (allotmentClassId == 4)
                    dtAccounts = Factory.GeneralLedgerAccountsRepository().GetAllViewRecordsBySearch(cmbxAccount.Text);
                else
                    dtAccounts = Factory.GeneralLedgerAccountsRepository().GetViewRecordsByMajAccGroupNameSearch(allotmentClassName, cmbxAccount.Text);

                var accountDict = new Dictionary<int, string>();
                foreach (DataRow item in dtAccounts.Rows)
                {
                    int accountId = Convert.ToInt32(item["general_ledger_accounts_id"]);
                    string accountName = $"{item["account_code"]} - {item["ledger_name"]}";

                    accountDict.Add(accountId, accountName);
                }

                cmbxAccount.DataSource = new BindingSource(accountDict, null);
                cmbxAccount.DisplayMember = "value";
                cmbxAccount.ValueMember = "key";
                cmbxAccount.SelectedIndex = -1;
                cmbxAccount.DropDownHeight = 300;

                cmbxAccount.TextChanged += new EventHandler(CmbxAccount_TextChanged);

                Helper.ClearErrorComboBox(epAccount, cmbxAccount);
            }
            catch (Exception ex)
            {
                Helper.MessageBoxError(ex.Message);
            }
        }

        private void CmbxAccount_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(cmbxAccount.Text))
                LoadAccounts();
        }

        private void cmbxAccount_KeyDown(object sender, KeyEventArgs e)
        {
            if (cmbxAccount.Text.Length < 4) return;

            if (e.KeyCode == Keys.F1)
            {
                try
                {
                    var allotmentClassRepo = Factory.AllotmentClassesRepository().GetRecordByID(allotmentClassId);

                    string allotmentClassName = allotmentClassRepo["allotment_name"];

                    DataTable dtAccounts;

                    if (allotmentClassId == 4)
                        dtAccounts = Factory.GeneralLedgerAccountsRepository().GetAllViewRecordsBySearch(cmbxAccount.Text);
                    else
                        dtAccounts = Factory.GeneralLedgerAccountsRepository().GetViewRecordsByMajAccGroupNameSearch(allotmentClassName, cmbxAccount.Text);

                    if (dtAccounts.Rows.Count == 0 || string.IsNullOrWhiteSpace(cmbxAccount.Text.Trim())) return;

                    var accountDict = new Dictionary<int, string>();
                    foreach (DataRow item in dtAccounts.Rows)
                    {
                        int accountId = Convert.ToInt32(item["general_ledger_accounts_id"]);
                        string accountName = $"{item["account_code"]} - {item["ledger_name"]}";

                        accountDict.Add(accountId, accountName);
                    }

                    cmbxAccount.DataSource = new BindingSource(accountDict, null);
                    cmbxAccount.DisplayMember = "value";
                    cmbxAccount.ValueMember = "key";
                    cmbxAccount.DroppedDown = true;

                    Helper.ClearErrorComboBox(epAccount, cmbxAccount);
                }
                catch (Exception ex)
                {
                    Helper.MessageBoxError(ex.Message);
                }
            }
        }


        private void LoadMonths() 
        {

            var months = new Dictionary<int, string>() 
            {
                { 1,"January"},
                { 2,"February"},
                { 3,"March"},
                { 4,"April"},
                { 5,"May"},
                { 6,"June"},
                { 7,"July"},
                { 8,"August"},
                { 9,"September"},
                { 10,"October"},
                { 11,"November"},
                { 12,"December"}
            };

            cmbxMonths.DataSource = new BindingSource(months, null);
            cmbxMonths.DisplayMember = "Value";
            cmbxMonths.ValueMember = "Key";
        }


        internal void LoadAllotmentClasses()
        {
            var funds = Factory.AllotmentClassesRepository().GetRecords();

            foreach (DataRow allotmentClass in funds.Rows)
            {
                var radAllotment = new RadioButton
                {
                    Text = allotmentClass["allotment_code"].ToString(),
                    Tag = allotmentClass["id"],
                    AutoSize = true,
                    Appearance = Appearance.Button,
                    TextImageRelation = TextImageRelation.ImageBeforeText
                };

                // making general fund as default
                int radAllotmentClassId = Convert.ToInt32(allotmentClass["id"]);

                if (radAllotmentClassId == 1)
                {
                    radAllotment.Checked = true;
                    allotmentClassId = Convert.ToByte(allotmentClass["id"]);
                    ShowCheckIcon(radAllotment);
                }


                flowLayoutPanelAllotment.Controls.Add(radAllotment);

                radAllotment.Click += new EventHandler(radioAllotment_Click);
                radAllotment.CheckedChanged += new EventHandler(radioAllotment_CheckedChanged);
            }
        }

        private void radioAllotment_Click(object sender, EventArgs e)
        {
            var radAllotment = sender as RadioButton;
            allotmentClassId = Convert.ToByte(radAllotment.Tag);
            LoadAccounts();
            LoadAccounts();
        }

        private void radioAllotment_CheckedChanged(object sender, EventArgs e)
        {
            var radAllotment = sender as RadioButton;
            ShowCheckIcon(radAllotment);
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
                if (fund["fund_name"].ToString() == "General Fund")
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
        }

        private void radioFunds_CheckedChanged(object sender, EventArgs e)
        {
            var radFund = sender as RadioButton;
            ShowCheckIcon(radFund);
        }


        private void ShowCheckIcon(RadioButton radioButton)
        {
            if (radioButton.Checked)
                radioButton.Image = Properties.Resources.ok14px;
            else
                radioButton.Image = null;
        }




        private void ucObligationRequestMain_Load(object sender, EventArgs e)
        {
            if (!DesignMode)
            {
                cmbxOthersFPP.Enabled = false;

                LoadFunds();
                LoadAllotmentClasses();
                LoadMonths();
                LoadFPP();
                LoadAccounts();

                LoadObligationRequestRecords();
                nudYear.Value = Convert.ToInt16(DateTime.Now.Year);
                Helper.DatagridDefaultStyle(dgObligationRequests, true);
            }
        }

        private void dgObligationRequests_ColumnAdded(object sender, DataGridViewColumnEventArgs e)
        {
            e.Column.SortMode = DataGridViewColumnSortMode.NotSortable;
        }




        private bool FPPNameNotExist() 
        {
            try
            {
                var fppNameExist = Factory.FunctionProgramProjectRepository().NameExist(cmbxFPP.Text);

                if (!fppNameExist && !string.IsNullOrEmpty(cmbxFPP.Text))
                {
                    epFPP.SetError(cmbxFPP, "FPP Name you entered doesn't exist on you record");
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
            else if (FPPNameNotExist())
                e.Cancel = FPPNameNotExist();
        }

        private void cmbxFPP_Validated(object sender, EventArgs e)
        {
            Helper.ClearErrorComboBox(epFPP, cmbxFPP);
        }




        private bool OtherFPPNameNotExist() 
        {
            try
            {

                bool otherFPPName = Factory.OthersFPPRepository().NameExist(cmbxOthersFPP.Text);

                if (!otherFPPName && !string.IsNullOrEmpty(cmbxOthersFPP.Text))
                {
                    epOthersFPP.SetError(cmbxOthersFPP, "Other FPP you entered doesn't exist on your record.");
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
            e.Cancel = OtherFPPNameNotExist();
        }

        private void cmbxOthersFPP_Validated(object sender, EventArgs e)
        {
            Helper.ClearErrorComboBox(epOthersFPP, cmbxOthersFPP);
        }



        private bool ShowErrorAccountNotExist()
        {
            try
            {
                if (cmbxAccount.FindStringExact(cmbxAccount.Text) < 0 && !string.IsNullOrEmpty(cmbxAccount.Text))
                {
                    epAccount.SetError(cmbxAccount, "Account you entered doesn't exist on your record.");
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
                e.Cancel = Helper.ShowErrorComboBoxEmpty(epAccount, cmbxAccount, "Account.");
            else if (ShowErrorAccountNotExist())
                e.Cancel = ShowErrorAccountNotExist();
        }

        private void cmbxAccount_Validated(object sender, EventArgs e)
        {
            Helper.ClearErrorComboBox(epAccount, cmbxAccount);
        }


        private bool ValidateRequirements() 
        {
            if (!ValidateChildren())
            {
                Helper.MessageBoxError(GetFormErrors());
                return false;
            }
            return true;
 
        }


        private void btnLoadRecords_Click(object sender, EventArgs e)
        {
            if (ValidateRequirements()) 
            {
                LoadObligationRequestRecords();
            }
        }


        internal void dgObligationRequests_SelectionChanged(object sender, EventArgs e)
        {
            byte[] columnIndexTimestamp = { 6, 7 };
            Helper.ShowRecordTimestamp(dgObligationRequests, columnIndexTimestamp, _frmObligationRequestMain.lblCreatedAt, _frmObligationRequestMain.lblUpdatedAt);
            Helper.EnableDisableToolStripButtons(dgObligationRequests, _frmObligationRequestMain.btnEdit, _frmObligationRequestMain.btnDelete);
        }
    }
}
