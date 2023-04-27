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
            try
            {
                LoadBankAccounts();
            }
            catch (Exception ex) { Helper.MessageBoxError(ex.Message); }
        }

        internal void LoadBankAccounts()
        {
            var searchText = txtSearch.Text.Trim();
            DataTable dtBankAccount;

            if (searchText.Length > 2)
                dtBankAccount = AccFactory.BankAccountsRepository().GetViewRecordsBySearch(searchText);
            else
                dtBankAccount = AccFactory.BankAccountsRepository().GetViewRecords();

            HelperLoadRecords.DatagridViewBankAccounts(dtBankAccount, dgBankAccounts);

            toolStripStatusLabelRecordCount.Text = dgBankAccounts.Rows.Count.ToString();
        }

        private void dgBankAccounts_SelectionChanged(object sender, EventArgs e)
        {
            Helper.EnableDisableToolStripButtons(dgBankAccounts, btnEdit, btnDelete);
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            try
            {
                LoadBankAccounts();
            }
            catch (Exception ex) { Helper.MessageBoxError(ex.Message); }
        }

        private void DeleteData()
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

        private void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                DeleteData();
            }
            catch (Exception ex) { Helper.MessageBoxError(ex.Message); }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            _ = new frmAddBankAccounts(this).ShowDialog();
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            int rowIndex = dgBankAccounts.CurrentRow.Index;
            int bankAccountId = Convert.ToInt32(dgBankAccounts.Rows[rowIndex].Cells["id"].Value);
            _ = new frmEditBankAccounts(this, bankAccountId).ShowDialog();
        }
    }
}