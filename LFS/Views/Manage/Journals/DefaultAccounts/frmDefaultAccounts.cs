using ACC.Data;
using ACC.Domain.Models;
using LFS.Helpers;
using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;

namespace LFS.Views.Manage.Journals.DefaultAccounts
{
    public partial class frmDefaultAccounts : Form
    {
        internal int journalId;

        public frmDefaultAccounts()
        {
            InitializeComponent();
            Helper.LoadFormIcon(this);
            Helper.DatagridFullRowSelectStyle(dgAccounts, true);
            Helper.DatagridFullRowSelectStyle(dgDefaultAccounts, true);
            btnRemoveDefaultAccount.Enabled = false;
            btnSetDefaultAccount.Enabled = false;
        }

        internal string GetFormErrors()
        {
            string[] errorArray = new string[]
            {
                cmbxFunds.Tag.ToString()
            };

            return AccFactory.CreateErrors(errorArray).GenerateErrorMessage();
        }

        private int GetMaxNumberOfDefaultAccounts()
        {
            switch (journalId)
            {
                case 2:
                    {
                        return 3;
                    }
                case 3:
                    {
                        return 2;
                    }
                case 4:
                    {
                        return 3;
                    }
                case 5:
                    {
                        return 3;
                    }
                case 6:
                    {
                        return 3;
                    }
                default:
                    return 0;
            }
        }

        private void CreateDatagridViewColumns(DataGridView dataGridView)
        {
            dataGridView.Columns.Clear();
            dataGridView.Rows.Clear();
            dataGridView.Columns.Add("id", "Id");
            dataGridView.Columns.Add("account_code", "Account Code");
            dataGridView.Columns.Add("account_name", "Name");

            dataGridView.Columns["id"].Visible = false;
            dataGridView.Columns["id"].SortMode = DataGridViewColumnSortMode.NotSortable;
            dataGridView.Columns["account_code"].SortMode = DataGridViewColumnSortMode.NotSortable;
            dataGridView.Columns["account_name"].SortMode = DataGridViewColumnSortMode.NotSortable;
            dataGridView.Columns["account_code"].AutoSizeMode = DataGridViewAutoSizeColumnMode.ColumnHeader;
            dataGridView.RowHeadersVisible = false;
        }

        private void LoadFunds()
        {
            var dtFunds = AccFactory.FundsRepository().GetRecords();
            HelperLoadRecords.FundsComboBox(dtFunds, cmbxFunds, "fund_name", "id");
        }

        private void LoadAccounts()
        {
            string searchKey = txtAccounts.Text.Trim();
            CreateDatagridViewColumns(dgAccounts);

            var dtGeneralLedgerAccounts = AccFactory.GeneralLedgerAccountsRepository().GetViewRecordsBySearch(searchKey);

            foreach (DataRow row in dtGeneralLedgerAccounts.Rows)
            {
                int generalLedgerAccountId = Convert.ToInt32(row["general_ledger_accounts_id"]);
                string accountCode = row["account_code"].ToString();
                string generalLedgerAccountName = row["ledger_name"].ToString();
                int fundId = Convert.ToInt32(cmbxFunds.SelectedValue);
                bool isDebit = radDebit.Checked;

                if (AccFactory.JournalsDefaultAccountsRepository().GeneralLedgerAccountExist(journalId, generalLedgerAccountId, fundId, isDebit)) continue;

                dgAccounts.Rows.Add(new object[]
                {
                    generalLedgerAccountId,
                    accountCode,
                    generalLedgerAccountName
                });
            }
        }

        private void LoadDefaultAccounts()
        {
            CreateDatagridViewColumns(dgDefaultAccounts);

            int fundId = Convert.ToInt32(cmbxFunds.SelectedValue);
            bool isDebit = radDebit.Checked;

            var dtDefaultAccounts = AccFactory.JournalsDefaultAccountsRepository().GetViewRecordsByJournalId(journalId, fundId, isDebit);

            foreach (DataRow row in dtDefaultAccounts.Rows)
            {
                int generalLedgerAccountId = Convert.ToInt32(row["general_ledger_accounts_id"]);
                string accountCode = row["account_code"].ToString();
                string generalLedgerAccountName = row["general_ledger_accounts_name"].ToString();

                dgDefaultAccounts.Rows.Add(new object[]
                {
                    generalLedgerAccountId,
                    accountCode,
                    generalLedgerAccountName
                });
            }
        }

        private void frmDefaultAccounts_Load(object sender, System.EventArgs e)
        {
            try
            {
                OnLoad();
            }
            catch (Exception ex) { Helper.MessageBoxError(ex.Message); }
        }

        private void OnLoad()
        {
            var dtJournals = AccFactory.JournalsRepository().GetRecordByID(journalId);
            lblJournalName.Text = dtJournals["journal_name"].ToString();
            LoadFunds();
            LoadDefaultAccounts();
            lblMaxAccounts.Text = $"Max: {GetMaxNumberOfDefaultAccounts()}";
        }

        private void EnableDisableButtons()
        {
            if (dgAccounts.SelectedRows.Count > 0)
                btnSetDefaultAccount.Enabled = true;
            else
                btnSetDefaultAccount.Enabled = false;

            if (dgDefaultAccounts.SelectedRows.Count > 0)
                btnRemoveDefaultAccount.Enabled = true;
            else
                btnRemoveDefaultAccount.Enabled = false;
        }

        private void dgAccounts_SelectionChanged(object sender, System.EventArgs e)
        {
            try
            {
                EnableDisableButtons();
            }
            catch (Exception ex) { Helper.MessageBoxError(ex.Message); }
        }

        private void dgDefaultAccounts_SelectionChanged(object sender, EventArgs e)
        {
            try
            {
                EnableDisableButtons();
            }
            catch (Exception ex) { Helper.MessageBoxError(ex.Message); }
        }

        private void SetDefaultAccounts()
        {
            int numberOfSelectedAccounts = dgAccounts.SelectedRows.Count;

            if (numberOfSelectedAccounts > GetMaxNumberOfDefaultAccounts())
            {
                Helper.MessageBoxError($"Number of accounts you selected exceeds the maximum number of journal's default accounts");
                return;
            }

            if (dgDefaultAccounts.Rows.Count >= GetMaxNumberOfDefaultAccounts())
            {
                Helper.MessageBoxError($"Number of default account has reached to its limit.");
                return;
            }

            foreach (DataGridViewRow row in dgAccounts.SelectedRows)
            {
                int id = Convert.ToInt32(row.Cells["id"].Value);
                string accountCode = row.Cells["account_code"].Value.ToString();
                string accountName = row.Cells["account_name"].Value.ToString();

                dgDefaultAccounts.Rows.Add(new object[]
                {
                    id,
                    accountCode,
                    accountName
                });
                dgAccounts.Rows.Remove(row);
            }
        }

        private void RemoveDefaultAccounts()
        {
            foreach (DataGridViewRow row in dgDefaultAccounts.SelectedRows)
            {
                dgDefaultAccounts.Rows.Remove(row);
            }
        }

        private void btnSetDefaultAccount_Click(object sender, System.EventArgs e)
        {
            try
            {
                SetDefaultAccounts();
            }
            catch (Exception ex) { Helper.MessageBoxError(ex.Message); }
        }

        private void btnRemoveDefaultAccount_Click(object sender, EventArgs e)
        {
            try
            {
                RemoveDefaultAccounts();
            }
            catch (Exception ex) { Helper.MessageBoxError(ex.Message); }
        }

        private bool Save()
        {
            if (!ValidateChildren())
            {
                Helper.MessageBoxError(GetFormErrors());
                return false;
            }

            var journalsDefaulAccountsModelList = new List<JournalsDefaultAccountsModel>();
            int fundId = Convert.ToInt32(cmbxFunds.SelectedValue);
            bool isDebit = radDebit.Checked ? true : false;

            foreach (DataGridViewRow item in dgDefaultAccounts.Rows)
            {
                int accountId = Convert.ToInt32(item.Cells["id"].Value);
                var journalsDefaulAccountsModel = new JournalsDefaultAccountsModel()
                {
                    JournalId = journalId,
                    fundId = fundId,
                    AccountId = accountId,
                    IsDebit = isDebit
                };

                journalsDefaulAccountsModelList.Add(journalsDefaulAccountsModel);
            }

            return AccFactory.JournalsDefaultAccountsRepository().Insert(journalId, fundId, isDebit, journalsDefaulAccountsModelList);
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                if (Save())
                {
                    Helper.MessageBoxSuccess("Default Accounts has been saved.");
                    if (txtAccounts.Text.Length > 3)
                        LoadAccounts();
                    else
                        dgAccounts.Rows.Clear();
                }
            }
            catch (Exception ex) { Helper.MessageBoxError(ex.Message); }
        }

        private void cmbxFunds_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            try
            {
                if (string.IsNullOrEmpty(cmbxFunds.Text))
                {
                    e.Cancel = true;
                    cmbxFunds.Tag = Helper.ErrorMessage("Funds");
                }
                else
                    e.Cancel = false;
            }
            catch (Exception ex) { Helper.MessageBoxError(ex.Message); }
        }

        private void cmbxFunds_Validated(object sender, EventArgs e)
        {
            cmbxFunds.Tag = string.Empty;
        }

        private void cmbxFunds_SelectionChangeCommitted(object sender, EventArgs e)
        {
            try
            {
                LoadDefaultAccounts();
                if (txtAccounts.Text.Length > 3)
                    LoadAccounts();
                else
                    dgAccounts.Rows.Clear();
            }
            catch (Exception ex) { Helper.MessageBoxError(ex.Message); }
        }

        private void txtAccounts_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (txtAccounts.Text.Length > 3)
                    LoadAccounts();
                else
                    dgAccounts.Rows.Clear();
            }
            catch (Exception ex) { Helper.MessageBoxError(ex.Message); }
        }

        private void radDebit_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                LoadDefaultAccounts();
                if (txtAccounts.Text.Length > 3)
                    LoadAccounts();
                else
                    dgAccounts.Rows.Clear();
            }
            catch (Exception ex) { Helper.MessageBoxError(ex.Message); }
        }

        private void radCredit_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                LoadDefaultAccounts();
                if (txtAccounts.Text.Length > 3)
                    LoadAccounts();
                else
                    dgAccounts.Rows.Clear();
            }
            catch (Exception ex) { Helper.MessageBoxError(ex.Message); }
        }
    }
}