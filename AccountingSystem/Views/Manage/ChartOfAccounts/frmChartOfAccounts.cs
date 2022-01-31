using ACC.Domain.Models;
using AccountingSystem.Views.Manage.BeginningBalances;
using AccountingSystem.Views.Manage.ChartOfAccounts.AccountGroup;
using AccountingSystem.Views.Manage.ChartOfAccounts.BeginningBalances;
using AccountingSystem.Views.Manage.ChartOfAccounts.MajorAccountGroup;
using AccountingSystem.Views.Manage.ChartOfAccounts.Subsidiary;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;

namespace AccountingSystem.Views.Manage.ChartOfAccounts
{
    public partial class frmChartOfAccounts : Form
    {
        private byte fundId;
        private short year;

        public frmChartOfAccounts()
        {
            InitializeComponent();
            Helper.LoadFormIcon(this);

            // validate if it has permission
            if (!Helper.HasPermission("Manage Subsidiary Ledger Account"))
                BtnSubsidiary.Visible = false;
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
            try
            {
                var dtAccountGroup = Factory.AccountGroupRepository().GetRecords();
                HelperLoadRecords.AccountGroupDatagridView(dtAccountGroup, dgAccountGroup);

                lblRecordCount.Text = Factory.AccountGroupRepository()
                                             .CountRecords()
                                             .ToString();
            }
            catch (Exception ex) { Helper.MessageBoxError(ex.Message); }
        }

        internal void LoadMajorAccountGroup()
        {
            try
            {
                byte accountGroupId = Convert.ToByte(cmbAccountGroup.SelectedValue);
                var dtMajorAccountGroup = Factory.MajorAccountGroupRepository().GetViewRecordsByAccountGroupId(accountGroupId);
                HelperLoadRecords.MajorAccountGroupDatagridView(dtMajorAccountGroup, dgMajorAccountGroup);

                lblRecordCount.Text = dgMajorAccountGroup.Rows.Count.ToString();
            }
            catch (Exception ex) { Helper.MessageBoxError(ex.Message); }
        }

        private void LoadSubMajorAccountGroup()
        {
            try
            {
                if (!string.IsNullOrWhiteSpace(cmbMajorAccount.Text))
                {
                    short majorAccountGroupId = short.Parse(cmbMajorAccount.SelectedValue.ToString());
                    DataTable dtSubMajorAccountGroup = Factory.SubMajorAccountGroupRepository().GetViewRecordsByMajorAccountId(majorAccountGroupId);
                    HelperLoadRecords.SubMajorAccountGroupDatagridView(dtSubMajorAccountGroup, dgSubMajorAccount);
                }
            }
            catch (Exception ex)
            {
                Helper.MessageBoxError(ex.Message);
            }
        }

        private DataTable GeneralLedgersDataTable()
        {
            var dataTable = new DataTable();
            fundId = Convert.ToByte(cmbFund.SelectedValue);
            year = Convert.ToInt16(cmbYear.Text);
            int accountGroupId = Convert.ToInt32(cmbAccountGroup.SelectedValue);

            if (string.IsNullOrWhiteSpace(txtSearch.Text.Trim()))
                dataTable = Factory.GeneralLedgerAccountsRepository().GetViewRecordsBy_AccountGroupId(accountGroupId);
            else
                dataTable = Factory.GeneralLedgerAccountsRepository().GetViewRecordsBy_AccountGroupId_Search(accountGroupId, txtSearch.Text.Trim());

            dataTable.Columns.Add("Debit", typeof(decimal));
            dataTable.Columns.Add("Credit", typeof(decimal));

            foreach (DataRow item in dataTable.Rows)
            {
                ushort generalLedgerId = Convert.ToUInt16(item["general_ledger_accounts_id"]);
                var beginningBalanceRepository = Factory.BeginningBalancesRepository();
                decimal debit = beginningBalanceRepository.GetSumBalances(fundId, generalLedgerId, year, 1);
                decimal credit = beginningBalanceRepository.GetSumBalances(fundId, generalLedgerId, year, 0);

                item["Debit"] = debit > credit ? debit - credit : 0;
                item["Credit"] = credit > debit ? credit - debit : 0;
            }

            return dataTable;
        }

        internal void LoadGeneralLedgers()
        {
            try
            {
                if (txtSearch.Text.Length > 3 || string.IsNullOrWhiteSpace(txtSearch.Text.Trim()))
                {
                    Cursor.Current = Cursors.WaitCursor;
                    HelperLoadRecords.GeneralLedgerAccountsWithBalancesDatagridView(GeneralLedgersDataTable(), dgGeneralLedgerAccounts);
                    lblRecordCount.Text = dgGeneralLedgerAccounts.Rows.Count.ToString();
                    Cursor.Current = Cursors.Default;
                }
            }
            catch (Exception ex) { Helper.MessageBoxError(ex.Message); }
        }

        private void LoadAccountGroupComboBox()
        {
            try
            {
                DataTable dtAccountGroup = Factory.AccountGroupRepository().GetRecords();
                HelperLoadRecords.AccountGroupComboBox(dtAccountGroup, cmbAccountGroup, "account_group_name", "id");
                HelperLoadRecords.AccountGroupComboBox(dtAccountGroup, cmbxGenLedgAccountGroup, "account_group_name", "id");
            }
            catch (Exception ex)
            {
                Helper.MessageBoxError(ex.Message);
            }
        }

        private void LoadMajorAccountGroupComboBox()
        {
            try
            {
                DataTable dtAccountGroup = Factory.MajorAccountGroupRepository().GetRecords();
                HelperLoadRecords.MajorAccountGroupComboBox(dtAccountGroup, cmbMajorAccount, "maj_acc_group_name", "id");
            }
            catch (Exception ex)
            {
                Helper.MessageBoxError(ex.Message);
            }
        }

        private void LoadFunds()
        {
            var dtFunds = Factory.FundsRepository().GetRecords();
            HelperLoadRecords.FundsComboBox(dtFunds, cmbFund, "fund_name", "id");
        }

        private void LoadYear()
        {
            HelperLoadRecords.YearComboBox(cmbYear);
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

                        var accountGroupRepository = Factory.AccountGroupRepository();
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

                        _ = Factory.MajorAccountGroupRepository().Delete(majorAccountGroupModelList);
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

        private void frmChartOfAccounts_Load(object sender, EventArgs e)
        {
            Helper.DatagridFullRowSelectStyle(dgGeneralLedgerAccounts);
            Helper.DatagridFullRowSelectStyle(dgAccountGroup);
            Helper.DatagridFullRowSelectStyle(dgMajorAccountGroup);
            Helper.DatagridFullRowSelectStyle(dgSubMajorAccount);

            LoadAccountGroupComboBox();
            LoadMajorAccountGroupComboBox();
            LoadFunds();
            LoadYear();
            UserVerfication();
        }

        private void BtnAdd_Click(object sender, EventArgs e)
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

        private void BtnEdit_Click(object sender, EventArgs e)
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
            if (dgGeneralLedgerAccounts.SelectedRows.Count == 1)
            {
                ushort generalLedgerId = Convert.ToUInt16(dgGeneralLedgerAccounts.SelectedCells[0].Value);
                _ = new frmSubsidiary(this, fundId, generalLedgerId, year).ShowDialog();
            }
        }

        private void BtnSubsidiary_Click(object sender, EventArgs e)
        {
            ShowSubsidiaryForm();
        }

        private void BtnSetBalance_Click(object sender, EventArgs e)
        {
            if (dgGeneralLedgerAccounts.SelectedRows.Count == 1)
            {
                ushort generalLedgerId = Convert.ToUInt16(dgGeneralLedgerAccounts.SelectedCells[0].Value);
                year = Convert.ToInt16(cmbYear.Text);

                bool hasSubsidiary = Factory.SubsidiaryLedgerAccountsRepository().HasSubsidiary(generalLedgerId);
                if (hasSubsidiary)
                {
                    ShowSubsidiaryForm();
                    return;
                }

                var generalLedgerBalanceExist = Factory.BeginningBalancesRepository().GeneralLedgerBalanceExist(fundId, generalLedgerId, year);

                if (generalLedgerBalanceExist)
                {
                    _ = new frmBeginningBalanceEdit(this, null, fundId, generalLedgerId, year).ShowDialog();
                    return;
                }

                _ = new frmBeginningBalanceAdd(this, null, fundId, generalLedgerId, year).ShowDialog();
            }
        }

        private void DisableEditDeleteButtons()
        {
            btnEdit.Enabled = false;
            btnDelete.Enabled = false;
        }

        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (tabControl1.SelectedTab == tabControl1.TabPages["tabGeneralLedgers"])
            {
                DisableEditDeleteButtons();
            }
            else if (tabControl1.SelectedTab == tabControl1.TabPages["tabSubMajorAccount"])
            {
                LoadSubMajorAccountGroup();
                DisableEditDeleteButtons();
                BtnSubsidiary.Enabled = false;
                BtnSetBalance.Enabled = false;
            }
            else if (tabControl1.SelectedTab == tabControl1.TabPages["tabMajorAccount"])
            {
                LoadMajorAccountGroup();
                DisableEditDeleteButtons();
                BtnSubsidiary.Enabled = false;
                BtnSetBalance.Enabled = false;
            }
            else
            {
                LoadAccountGroup();
                DisableEditDeleteButtons();
                BtnSubsidiary.Enabled = false;
                BtnSetBalance.Enabled = false;
            }

        }

        private void SetActionControls(DataGridView dataGrid, byte[] columnIndexTimestamp)
        {
            Helper.ShowRecordTimestamp(dataGrid, columnIndexTimestamp, lblCreatedAt, lblUpdatedAt);
            Helper.EnableDisableToolStripButtons(dataGrid, btnEdit, btnDelete);

            UserVerfication();
        }

        private void EnableDisableSubsidiaryButton()
        {
            byte fundId = Convert.ToByte(cmbFund.SelectedValue);
            ushort generalLedgerId = Convert.ToUInt16(dgGeneralLedgerAccounts.SelectedCells[0].Value);
            short year = Convert.ToInt16(cmbYear.Text);
            bool generalLedgerBalanceExist = Factory.BeginningBalancesRepository().GeneralLedgerBalanceExist(fundId, generalLedgerId, year);

            if (generalLedgerBalanceExist)
                BtnSubsidiary.Enabled = false;
            else
                BtnSubsidiary.Enabled = true;
        }

        private void dgGeneralLedgerAccounts_SelectionChanged(object sender, EventArgs e)
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

        private void dgAccountGroup_SelectionChanged(object sender, EventArgs e)
        {
            byte[] columnIndexTimestamp = { 3, 4 };
            SetActionControls(dgAccountGroup, columnIndexTimestamp);
        }

        private void dgMajorAccountGroup_SelectionChanged(object sender, EventArgs e)
        {
            byte[] columnIndexTimestamp = { 4, 5 };
            SetActionControls(dgMajorAccountGroup, columnIndexTimestamp);
        }

        private void cmbAccountGroup_SelectionChangeCommitted(object sender, EventArgs e)
        {
            LoadMajorAccountGroup();
        }

        private void cmbMajorAccount_SelectionChangeCommitted(object sender, EventArgs e)
        {
            LoadSubMajorAccountGroup();
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            LoadGeneralLedgers();
        }

        private void btnRetrieve_Click(object sender, EventArgs e)
        {
            LoadGeneralLedgers();
        }
    }
}
