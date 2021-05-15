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

        public ucObligationRequestMain()
        {
            InitializeComponent();
        }


        private void LoadDatagridFormat() 
        {
            dgObligationRequests.Rows.Clear();


            dgObligationRequests.Columns.Add("obligation_no", "Obligation No.");
            dgObligationRequests.Columns.Add("account_code", "Account Code");
            dgObligationRequests.Columns.Add("account_name", "Account Name");
            dgObligationRequests.Columns.Add("date_requested", "Date of Request");
            dgObligationRequests.Columns.Add("obligation_amount", "Amount");

            dgObligationRequests.Columns["obligation_no"].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
            dgObligationRequests.Columns["account_code"].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
            dgObligationRequests.Columns["date_requested"].DefaultCellStyle.Format = "dd/MMM/yyyy";
            dgObligationRequests.Columns["obligation_amount"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dgObligationRequests.Columns["obligation_amount"].DefaultCellStyle.Format = "N2";
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

                LoadDatagridFormat();
                nudYear.Value = Convert.ToInt16(DateTime.Now.Year);
                Helper.DatagridDefaultStyle(dgObligationRequests, true);
            }
        }

        private void dgObligationRequests_ColumnAdded(object sender, DataGridViewColumnEventArgs e)
        {
            e.Column.SortMode = DataGridViewColumnSortMode.NotSortable;
        }
    }
}
