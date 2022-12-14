using ACC.Domain.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;

namespace AccountingSystem.Views.Manage.BankAccounts
{
    public partial class frmBankAccounts : Form
    {
        public frmBankAccounts()
        {
            InitializeComponent();
            Helper.LoadFormIcon(this);
            Helper.DatagridFullRowSelectStyle(dgBankAccounts, true, true);
        }

        private void frmBankAccounts_Load(object sender, EventArgs e)
        {
            LoadBankAccounts();
        }

        internal void LoadBankAccounts()
        {
            var searchKey = txtSearch.Text.Trim();
            DataTable dtBankAccount;

            if (searchKey.Length > 2)
                dtBankAccount = AccFactory.BankAccountsRepository().GetViewRecordsBySearch(searchKey);
            else
                dtBankAccount = AccFactory.BankAccountsRepository().GetViewRecords();

            HelperLoadRecords.DatagridViewBankAccounts(dtBankAccount, dgBankAccounts);

            toolStripStatusLabelRecordCount.Text = dgBankAccounts.Rows.Count.ToString();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            _ = new frmAddBankAccounts(this).ShowDialog();
        }

        private void dgBankAccounts_SelectionChanged(object sender, EventArgs e)
        {
            Helper.EnableDisableToolStripButtons(dgBankAccounts, btnEdit, btnDelete);

            try
            {
                var indexes = new byte[] { 3, 4 };
                Helper.ShowRecordTimestamp(dgBankAccounts, indexes, toolStripStatusLabelCreatedAt, toolStripStatusLabelUpdatedAt);
            }
            catch (Exception ex)
            {
                Helper.MessageBoxError(ex.Message);
            }
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            LoadBankAccounts();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            int selectedRowsCount = dgBankAccounts.SelectedRows.Count;

            if (selectedRowsCount > 0)
            {
                if (Helper.MessageBoxConfirmDelete(selectedRowsCount))
                {
                    var bankAccountsModelList = new List<BankAccountsModel>();
                    foreach (DataGridViewRow row in dgBankAccounts.SelectedRows)
                    {
                        int bankAccountID = Convert.ToInt16(row.Cells[0].Value.ToString());
                        bankAccountsModelList.Add(new BankAccountsModel() { ID = bankAccountID });
                    }

                    var bankAccountsRepository = AccFactory.BankAccountsRepository();
                    _ = bankAccountsRepository.Delete(bankAccountsModelList);
                    LoadBankAccounts();
                }
            }
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            int bankAccountID = int.Parse(dgBankAccounts.SelectedCells[0].Value.ToString());
            _ = new frmEditBankAccounts(this, bankAccountID).ShowDialog();
        }
    }
}