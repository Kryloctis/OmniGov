using ACC.Data;
using ACC.Domain.Models;
using LFS.Views.Manage.BeginningBalances;
using LFS.Views.Manage.ChartOfAccounts.AccountGroup;
using LFS.Views.Manage.ChartOfAccounts.BeginningBalances;
using LFS.Views.Manage.ChartOfAccounts.MajorAccountGroup;
using LFS.Views.Manage.ChartOfAccounts.Subsidiary;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;

namespace LFS.Views.Manage.ChartOfAccounts
{
    public partial class frmChartOfAccounts : Form
    {
        public frmChartOfAccounts()
        {
            InitializeComponent();
            Helper.LoadFormIcon(this);

            // validate if it has permission
            if (!Helper.HasPermission("Manage > Subsidiary Ledger Account"))
                BtnSubsidiary.Visible = false;

            btnAdd.Enabled = false;
            btnEdit.Enabled = false;
            btnDelete.Enabled = false;
            BtnSetBalance.Enabled = false;
            BtnSubsidiary.Enabled = false;
        }

        private void UserVerfication()
        {
            if (Helper.LoggedInUserData()["role_name"] != "System Administrator")
            {
                btnAdd.Enabled = false;
                btnEdit.Enabled = false;
                btnDelete.Enabled = false;
            }
        }

        internal void LoadAccountGroup()
        {
            var dtAccountGroup = AccFactory.AccountGroupRepository().GetRecords();
            HelperLoadRecords.AccountGroupDatagridView(dtAccountGroup, dgAccountGroup);
            DisplayRecordCount(dgAccountGroup);
        }

        internal void LoadMajorAccountGroup()
        {
            byte accountGroupId = Convert.ToByte(cmbAccountGroup.SelectedValue);
            var dtMajorAccountGroup = AccFactory.MajorAccountGroupRepository().GetViewRecordsByAccountGroupId(accountGroupId);
            HelperLoadRecords.MajorAccountGroupDatagridView(dtMajorAccountGroup, dgMajorAccountGroup);
            DisplayRecordCount(dgMajorAccountGroup);
        }

        private void LoadSubMajorAccountGroup()
        {
            if (!string.IsNullOrWhiteSpace(cmbMajorAccount.Text))
            {
                short majorAccountGroupId = short.Parse(cmbMajorAccount.SelectedValue.ToString());
                DataTable dtSubMajorAccountGroup = AccFactory.SubMajorAccountGroupRepository().GetViewRecordsByMajorAccountId(majorAccountGroupId);
                HelperLoadRecords.SubMajorAccountGroupDatagridView(dtSubMajorAccountGroup, dgSubMajorAccount);
                DisplayRecordCount(dgSubMajorAccount);
            }
        }

        private void LoadTotalBalances()
        {
            int fundId = Convert.ToInt32(cmbxFund.SelectedValue);
            short year = Convert.ToInt16(cmbxYear.Text);

            decimal totalDebit = AccFactory.BeginningBalancesRepository().GetSumBalancesBy_FundId_Year_Availablility(fundId, year, true);
            decimal totalCredit = AccFactory.BeginningBalancesRepository().GetSumBalancesBy_FundId_Year_Availablility(fundId, year, false);

            txtTotalCredit.Text = totalCredit.ToString("N2");
            txtTotalDebit.Text = totalDebit.ToString("N2");
        }

        private DataTable GeneralLedgersDataTable(int limitSize)
        {
            DataTable dataTable;
            byte fundId = Convert.ToByte(cmbxFund.SelectedValue);
            short year = Convert.ToInt16(cmbxYear.Text);
            int accountGroupId = Convert.ToInt32(cmbAccountGroup.SelectedValue);
            string searchText = txtSearch.Text.Trim();

            if (limitSize > 0)
                dataTable = AccFactory.GeneralLedgerAccountsRepository().GetViewRecordsBy_AccountGroupId_Search_Limited(accountGroupId, searchText, limitSize);
            else
                dataTable = AccFactory.GeneralLedgerAccountsRepository().GetViewRecordsBy_AccountGroupId_Search(accountGroupId, searchText);

            dataTable.Columns.Add("Debit", typeof(decimal));
            dataTable.Columns.Add("Credit", typeof(decimal));

            foreach (DataRow item in dataTable.Rows)
            {
                ushort generalLedgerId = Convert.ToUInt16(item["general_ledger_accounts_id"]);
                var beginningBalanceRepository = AccFactory.BeginningBalancesRepository();
                decimal debit = beginningBalanceRepository.GetSumBalancesBy_FundId_GenLedgId_IsDebit_SubLedgId(fundId, generalLedgerId, year, true);
                decimal credit = beginningBalanceRepository.GetSumBalancesBy_FundId_GenLedgId_IsDebit_SubLedgId(fundId, generalLedgerId, year, false);

                item["Debit"] = debit > credit ? debit - credit : 0;
                item["Credit"] = credit > debit ? credit - debit : 0;
            }

            return dataTable;
        }

        internal void LoadGeneralLedgers(int limitSize)
        {
            Cursor.Current = Cursors.WaitCursor;
            HelperLoadRecords.GeneralLedgerAccountsWithBalancesDatagridView(GeneralLedgersDataTable(limitSize), dgGeneralLedgerAccounts);
            lblRecordCount.Text = dgGeneralLedgerAccounts.Rows.Count.ToString();
            Cursor.Current = Cursors.Default;
            DisplayRecordCount(dgGeneralLedgerAccounts);
            LoadTotalBalances();
        }

        private void LoadAccountGroupComboBox()
        {
            DataTable dtAccountGroup = AccFactory.AccountGroupRepository().GetRecords();
            HelperLoadRecords.AccountGroupComboBox(dtAccountGroup, cmbAccountGroup, "account_group_name", "id");
            HelperLoadRecords.AccountGroupComboBox(dtAccountGroup, cmbxGenLedgAccountGroup, "account_group_name", "id");
        }

        private void LoadMajorAccountGroupComboBox()
        {
            DataTable dtAccountGroup = AccFactory.MajorAccountGroupRepository().GetRecords();
            HelperLoadRecords.MajorAccountGroupComboBox(dtAccountGroup, cmbMajorAccount, "maj_acc_group_name", "id");
        }

        private void LoadFunds()
        {
            var dtFunds = AccFactory.FundsRepository().GetRecords();
            HelperLoadRecords.FundsComboBox(dtFunds, cmbxFund, "fund_name", "id");
        }

        private void LoadYear()
        {
            HelperLoadRecords.YearComboBox(cmbxYear);
        }

        private void DeleteAccountGroupRecords()
        {
            int selectedRowsCount = dgAccountGroup.SelectedRows.Count;

            try
            {
                if (selectedRowsCount > 0)
                {
                    if (Helper.MessageBoxConfirmDelete(selectedRowsCount))
                    {
                        var accountGroupModelList = new List<AccountGroupModel>();
                        foreach (DataGridViewRow row in dgAccountGroup.SelectedRows)
                        {
                            int accountGroupId = Convert.ToInt16(row.Cells[0].Value.ToString());
                            accountGroupModelList.Add(new AccountGroupModel() { Id = accountGroupId });
                        }

                        var accountGroupRepository = AccFactory.AccountGroupRepository();
                        _ = accountGroupRepository.Delete(accountGroupModelList);
                        LoadAccountGroup();
                    }
                }
            }
            catch (MySqlException Mysqlex)
            {
                switch (Mysqlex.Number)
                {
                    case 1451:
                        Helper.MessageBoxError($"Cannot delete selected records. It is referenced by atleast one record.");
                        break;
                }
            }
            catch (Exception ex)
            {
                Helper.MessageBoxError(ex.Message);
            }
        }

        private void DeleteMajorAccountGroupRecords()
        {
            int selectedRowsCount = dgMajorAccountGroup.SelectedRows.Count;

            try
            {
                if (selectedRowsCount > 0)
                {
                    if (Helper.MessageBoxConfirmDelete(selectedRowsCount))
                    {
                        var majorAccountGroupModelList = new List<MajorAccountGroupModel>();
                        foreach (DataGridViewRow row in dgMajorAccountGroup.SelectedRows)
                        {
                            int majorAccountGroupId = Convert.ToInt16(row.Cells[0].Value.ToString());
                            majorAccountGroupModelList.Add(new MajorAccountGroupModel() { Id = majorAccountGroupId });
                        }

                        _ = AccFactory.MajorAccountGroupRepository().Delete(majorAccountGroupModelList);
                        LoadMajorAccountGroup();
                    }
                }
            }
            catch (MySqlException Mysqlex)
            {
                switch (Mysqlex.Number)
                {
                    case 1451:
                        Helper.MessageBoxError($"Cannot delete selected records. It is referenced by atleast one record.");
                        break;
                }
            }
            catch (Exception ex)
            {
                Helper.MessageBoxError(ex.Message);
            }
        }

        private void OnLoad()
        {
            Helper.DatagridFullRowSelectStyle(dgGeneralLedgerAccounts);
            Helper.DatagridFullRowSelectStyle(dgAccountGroup);
            Helper.DatagridFullRowSelectStyle(dgMajorAccountGroup);
            Helper.DatagridFullRowSelectStyle(dgSubMajorAccount);

            LoadAccountGroupComboBox();
            LoadMajorAccountGroupComboBox();
            LoadFunds();
            LoadYear();
        }

        private void frmChartOfAccounts_Load(object sender, EventArgs e)
        {
            try
            {
                OnLoad();
            }
            catch (Exception ex) { Helper.MessageBoxError(ex.Message); }
        }

        private void BtnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                if (tabControl1.SelectedTab == tabControl1.TabPages["tabSubsidiaryLedgers"])
                {
                }
                else if (tabControl1.SelectedTab == tabControl1.TabPages["tabGeneralLedgers"])
                {
                }
                else if (tabControl1.SelectedTab == tabControl1.TabPages["tabSubMajorAccount"])
                {
                }
                else if (tabControl1.SelectedTab == tabControl1.TabPages["tabMajorAccount"])
                {
                    _ = new frmMajorAccountGroupAdd(this).ShowDialog();
                }
                else
                    _ = new frmAccountGroupAdd(this).ShowDialog();
            }
            catch (Exception ex) { Helper.MessageBoxError(ex.Message); }
        }

        private void BtnEdit_Click(object sender, EventArgs e)
        {
            try
            {
                if (tabControl1.SelectedTab == tabControl1.TabPages["tabSubsidiaryLedgers"])
                {
                }
                else if (tabControl1.SelectedTab == tabControl1.TabPages["tabGeneralLedgers"])
                {
                }
                else if (tabControl1.SelectedTab == tabControl1.TabPages["tabSubMajorAccount"])
                {
                }
                else if (tabControl1.SelectedTab == tabControl1.TabPages["tabMajorAccount"])
                {
                    short majorAccountGroupId = short.Parse(dgMajorAccountGroup.SelectedCells[0].Value.ToString());
                    _ = new frmMajorAccountGroupEdit(this, majorAccountGroupId).ShowDialog();
                }
                else
                {
                    byte accountGroupId = byte.Parse(dgAccountGroup.SelectedCells[0].Value.ToString());
                    _ = new frmAccountGroupEdit(this, accountGroupId).ShowDialog();
                }
            }
            catch (Exception ex) { Helper.MessageBoxError(ex.Message); }
        }

        private void BtnDelete_Click(object sender, EventArgs e)
        {
            if (tabControl1.SelectedTab == tabControl1.TabPages["tabSubsidiaryLedgers"])
            {
            }
            else if (tabControl1.SelectedTab == tabControl1.TabPages["tabGeneralLedgers"])
            {
            }
            else if (tabControl1.SelectedTab == tabControl1.TabPages["tabSubMajorAccount"])
            {
            }
            else if (tabControl1.SelectedTab == tabControl1.TabPages["tabMajorAccount"])
            {
                DeleteMajorAccountGroupRecords();
            }
            else
                DeleteAccountGroupRecords();
        }

        private void ShowSubsidiaryForm()
        {
            byte fundId = Convert.ToByte(cmbxFund.SelectedValue);
            short year = Convert.ToInt16(cmbxYear.Text);

            ushort generalLedgerId = Convert.ToUInt16(dgGeneralLedgerAccounts.SelectedCells[0].Value);
            _ = new frmSubsidiary(this, fundId, generalLedgerId, year).ShowDialog();
        }

        private void BtnSubsidiary_Click(object sender, EventArgs e)
        {
            try
            {
                ShowSubsidiaryForm();
            }
            catch (Exception ex) { Helper.MessageBoxError(ex.Message); }
        }

        private void ShowSetBalanceForm()
        {
            int rowIndex = dgGeneralLedgerAccounts.CurrentRow.Index;
            byte fundId = Convert.ToByte(cmbxFund.SelectedValue);
            short year = Convert.ToInt16(cmbxYear.Text);
            ushort generalLedgerId = Convert.ToUInt16(dgGeneralLedgerAccounts.Rows[rowIndex].Cells["general_ledger_accounts_id"].Value);

            bool hasSubsidiary = AccFactory.SubsidiaryLedgerAccountsRepository().HasSubsidiary(generalLedgerId, fundId);
            var generalLedgerBalanceExist = AccFactory.BeginningBalancesRepository().GeneralLedgerBalanceExist(fundId, generalLedgerId, year);

            if (hasSubsidiary)
            {
                ShowSubsidiaryForm();
                return;
            }

            if (generalLedgerBalanceExist)
            {
                _ = new frmBeginningBalanceEdit(this, null, fundId, generalLedgerId, year).ShowDialog();
                return;
            }

            _ = new frmBeginningBalanceAdd(this, null, fundId, generalLedgerId, year).ShowDialog();
        }

        private void BtnSetBalance_Click(object sender, EventArgs e)
        {
            try
            {
                if (dgGeneralLedgerAccounts.Rows.Count < 1)
                    return;

                ShowSetBalanceForm();
            }
            catch (Exception ex) { Helper.MessageBoxError(ex.Message); }
        }

        private void DisableEditDeleteButtons()
        {
            btnEdit.Enabled = false;
            btnDelete.Enabled = false;
        }

        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (tabControl1.SelectedTab == tabControl1.TabPages["tabGeneralLedgers"])
                {
                    byte[] columnIndexTimestamp = { 3, 4 };
                    DisplayRecordCount(dgGeneralLedgerAccounts);
                    DisableEditDeleteButtons();
                    SetActionControls(dgGeneralLedgerAccounts, columnIndexTimestamp);
                    dgGeneralLedgerAccounts_SelectionChanged(dgGeneralLedgerAccounts, null);
                }
                else if (tabControl1.SelectedTab == tabControl1.TabPages["tabSubMajorAccount"])
                {
                    byte[] columnIndexTimestamp = { 3, 4 };
                    LoadSubMajorAccountGroup();
                    DisableEditDeleteButtons();
                    BtnSubsidiary.Enabled = false;
                    BtnSetBalance.Enabled = false;
                    SetActionControls(dgSubMajorAccount, columnIndexTimestamp);
                }
                else if (tabControl1.SelectedTab == tabControl1.TabPages["tabMajorAccount"])
                {
                    byte[] columnIndexTimestamp = { 3, 4 };
                    LoadMajorAccountGroup();
                    DisableEditDeleteButtons();
                    SetActionControls(dgMajorAccountGroup, columnIndexTimestamp);
                    BtnSubsidiary.Enabled = false;
                    BtnSetBalance.Enabled = false;
                }
                else
                {
                    byte[] columnIndexTimestamp = { 3, 4 };
                    LoadAccountGroup();
                    DisableEditDeleteButtons();
                    SetActionControls(dgAccountGroup, columnIndexTimestamp);
                    BtnSubsidiary.Enabled = false;
                    BtnSetBalance.Enabled = false;
                }
            }
            catch (Exception ex) { Helper.MessageBoxError(ex.Message); }
        }

        private void DisplayRecordCount(DataGridView dataGridView)
        {
            lblRecordCount.Text = dataGridView.Rows.Count.ToString();
        }

        private void SetActionControls(DataGridView dataGrid, byte[] columnIndexTimestamp)
        {
            Helper.ShowRecordTimestamp(dataGrid, columnIndexTimestamp, lblCreatedAt, lblUpdatedAt);
            Helper.EnableDisableToolStripButtons(dataGrid, btnEdit, btnDelete);

            UserVerfication();
        }

        private void EnableDisableSubsidiaryButton()
        {
            byte fundId = Convert.ToByte(cmbxFund.SelectedValue);
            ushort generalLedgerId = Convert.ToUInt16(dgGeneralLedgerAccounts.SelectedCells[0].Value);
            short year = Convert.ToInt16(cmbxYear.Text);
            bool generalLedgerBalanceExist = AccFactory.BeginningBalancesRepository().GeneralLedgerBalanceExist(fundId, generalLedgerId, year);

            if (generalLedgerBalanceExist)
                BtnSubsidiary.Enabled = false;
            else
                BtnSubsidiary.Enabled = true;
        }

        private void dgGeneralLedgerAccounts_SelectionChanged(object sender, EventArgs e)
        {
            try
            {
                byte[] columnIndexTimestamp = { 3, 4 };
                SetActionControls(dgGeneralLedgerAccounts, columnIndexTimestamp);

                if (dgGeneralLedgerAccounts.SelectedRows.Count == 1)
                {
                    BtnSubsidiary.Enabled = true;
                    BtnSetBalance.Enabled = true;
                    EnableDisableSubsidiaryButton();
                    return;
                }
                BtnSubsidiary.Enabled = false;
                BtnSetBalance.Enabled = false;
            }
            catch (Exception ex) { Helper.MessageBoxError(ex.Message); }
        }

        private void dgAccountGroup_SelectionChanged(object sender, EventArgs e)
        {
            try
            {
                byte[] columnIndexTimestamp = { 3, 4 };
                SetActionControls(dgAccountGroup, columnIndexTimestamp);
            }
            catch (Exception ex) { Helper.MessageBoxError(ex.Message); }
        }

        private void dgMajorAccountGroup_SelectionChanged(object sender, EventArgs e)
        {
            try
            {
                byte[] columnIndexTimestamp = { 4, 5 };
                SetActionControls(dgMajorAccountGroup, columnIndexTimestamp);
            }
            catch (Exception ex) { Helper.MessageBoxError(ex.Message); }
        }

        private void cmbAccountGroup_SelectionChangeCommitted(object sender, EventArgs e)
        {
            try
            {
                LoadMajorAccountGroup();
            }
            catch (Exception ex) { Helper.MessageBoxError(ex.Message); }
        }

        private void cmbMajorAccount_SelectionChangeCommitted(object sender, EventArgs e)
        {
            try
            {
                LoadSubMajorAccountGroup();
            }
            catch (Exception ex) { Helper.MessageBoxError(ex.Message); }
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (txtSearch.TextLength > 2)
                    LoadGeneralLedgers(0);

                if (string.IsNullOrEmpty(txtSearch.Text))
                {
                    var dataTable = (DataTable)dgGeneralLedgerAccounts.DataSource;
                    dataTable.Rows.Clear();
                }
            }
            catch (Exception ex) { Helper.MessageBoxError(ex.Message); }
        }

        private void btnRetrieveAll_Click(object sender, EventArgs e)
        {
            try
            {
                txtSearch.Clear();
                LoadGeneralLedgers(0);
            }
            catch (Exception ex) { Helper.MessageBoxError(ex.Message); }
        }

        private void dgSubMajorAccount_SelectionChanged(object sender, EventArgs e)
        {
            try
            {
                byte[] columnIndexTimestamp = { 4, 5 };
                SetActionControls(dgSubMajorAccount, columnIndexTimestamp);
            }
            catch (Exception ex) { Helper.MessageBoxError(ex.Message); }
        }
    }
}