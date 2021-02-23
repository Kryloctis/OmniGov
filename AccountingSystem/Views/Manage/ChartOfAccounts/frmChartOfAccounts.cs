using System;
using System.Windows.Forms;
using AccountingSystem.Views.Manage.ChartOfAccounts.AccountGroup;
using ACC.Domain.Models;
using System.Collections.Generic;
using MySql.Data.MySqlClient;

namespace AccountingSystem.Views.Manage.ChartOfAccounts
{
    public partial class frmChartOfAccounts : Form
    {

        public frmChartOfAccounts()
        {
            InitializeComponent();
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
                var dtMajorAccountGroup = Factory.MajorAccountGroupRepository().GetViewRecords();
                HelperLoadRecords.MajorAccountGroupDatagridView(dtMajorAccountGroup, dgMajorAccountGroup);

                lblRecordCount.Text = Factory.MajorAccountGroupRepository()
                                             .CountRecords()
                                             .ToString();
            }
            catch (Exception ex) { Helper.MessageBoxError(ex.Message); }
        }

        internal void LoadGeneralLedgers()
        {
            try
            {
                var dtAccounts = Factory.GeneralLedgerAccountsRepository().GetViewRecords();
                HelperLoadRecords.GeneralLedgerAccountsDatagridView(dtAccounts, dgGeneralLedgerAccounts);

                lblRecordCount.Text = Factory.GeneralLedgerAccountsRepository()
                                             .CountRecords()
                                             .ToString();

            }
            catch (Exception ex) { Helper.MessageBoxError(ex.Message); }
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


        private void frmChartOfAccounts_Load(object sender, EventArgs e)
        {
            Helper.LoadFormIcon(this);
            Helper.DatagridDefaultStyle(dgGeneralLedgerAccounts);
            Helper.DatagridDefaultStyle(dgAccountGroup);
            Helper.DatagridDefaultStyle(dgMajorAccountGroup);
        }

        private void BtnAdd_Click(object sender, EventArgs e)
        {
            if (tabControl1.SelectedTab == tabControl1.TabPages["tabAccountGroup"])
            {
                _ = new frmAccountGroupAdd(this).ShowDialog();
            }
        }

        private void BtnEdit_Click(object sender, EventArgs e)
        {
            if (tabControl1.SelectedTab == tabControl1.TabPages["tabAccountGroup"])
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

            }
            else
                DeleteAccountGroupRecords();
        }

        private void DisableEditDeleteButtons()
        {
            btnEdit.Enabled = false;
            btnDelete.Enabled = false;
        }

        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (tabControl1.SelectedTab == tabControl1.TabPages["tabSubsidiaryLedgers"])
            {

            }
            else if (tabControl1.SelectedTab == tabControl1.TabPages["tabGeneralLedgers"])
            {
                LoadGeneralLedgers();
                DisableEditDeleteButtons();
            }
            else if (tabControl1.SelectedTab == tabControl1.TabPages["tabSubMajorAccount"])
            {
                
            } 
            else if (tabControl1.SelectedTab == tabControl1.TabPages["tabMajorAccount"])
            {
                LoadMajorAccountGroup();
                DisableEditDeleteButtons();
            }
            else
            {
                LoadAccountGroup();
                DisableEditDeleteButtons();
            }
                
        }

        private void SetActionControls(DataGridView dataGrid, byte[] columnIndexTimestamp)
        {
            Helper.ShowRecordTimestamp(dataGrid, columnIndexTimestamp, lblCreatedAt, lblUpdatedAt);
            Helper.EnableDisableToolStripButtons(dataGrid, btnEdit, btnDelete);
        }

        private void dgGeneralLedgerAccounts_SelectionChanged(object sender, EventArgs e)
        {
            byte[] columnIndexTimestamp = { 3, 4 };
            SetActionControls(dgGeneralLedgerAccounts, columnIndexTimestamp);
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
    }
}
