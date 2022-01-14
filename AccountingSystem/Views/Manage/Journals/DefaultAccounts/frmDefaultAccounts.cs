using ACC.Domain.Interfaces;
using ACC.Domain.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;

namespace AccountingSystem.Views.Manage.Journals.DefaultAccounts
{
    public partial class frmDefaultAccounts : Form
    {
        internal int journalId;

        public frmDefaultAccounts()
        {
            InitializeComponent();
            btnRemoveDefaultAccount.Enabled = false;
            btnSetDefaultAccount.Enabled = false;
        }


        internal string GetFormErrors()
        {
            var errorArray = new string[]
            {
                cmbxFunds.Tag.ToString()
            };

            IError _errors = Factory.CreateErrors(errorArray);
            return _errors.GenerateErrorMessage();
        }

        private int NumberOfDefaultAccounts()
        {
            switch (journalId)
            {
                case 2:
                    {
                        int noOfmaxDefaultAccount = 3;
                        int noOfExistedDefaultAccounts = dgDefaultAccounts.Rows.Count;

                        int remaining = noOfmaxDefaultAccount - noOfExistedDefaultAccounts;

                        return remaining;
                    }
                case 3:
                    {
                        int noOfmaxDefaultAccount = 2;
                        int noOfExistedDefaultAccounts = dgDefaultAccounts.Rows.Count;

                        int remaining = noOfmaxDefaultAccount - noOfExistedDefaultAccounts;

                        return remaining;
                    }
                case 4:
                    {
                        int noOfmaxDefaultAccount = 3;
                        int noOfExistedDefaultAccounts = dgDefaultAccounts.Rows.Count;

                        int remaining = noOfmaxDefaultAccount - noOfExistedDefaultAccounts;

                        return remaining;
                    }
                case 5:
                    {
                        int noOfmaxDefaultAccount = 3;
                        int noOfExistedDefaultAccounts = dgDefaultAccounts.Rows.Count;

                        int remaining = noOfmaxDefaultAccount - noOfExistedDefaultAccounts;

                        return remaining;
                    }
                case 6:
                    {
                        int noOfmaxDefaultAccount = 3;
                        int noOfExistedDefaultAccounts = dgDefaultAccounts.Rows.Count;

                        int remaining = noOfmaxDefaultAccount - noOfExistedDefaultAccounts;

                        return remaining;
                    }
                default:
                    return 0;
            }
        }

        private void CreateDatagridViewColumns(DataGridView dataGridView)
        {
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

        private void LoadAccounts()
        {
            CreateDatagridViewColumns(dgAccounts);

            var dtGeneralLedgerAccounts = Factory.GeneralLedgerAccountsRepository().GetViewRecords();

            foreach (DataRow row in dtGeneralLedgerAccounts.Rows)
            {
                int generalLedgerAccountId = Convert.ToInt32(row["general_ledger_accounts_id"]);
                string accountCode = row["account_code"].ToString();
                string generalLedgerAccountName = row["ledger_name"].ToString();

                if (Factory.JournalsDefaultAccountsRepository().GeneralLedgerAccountExist(journalId, generalLedgerAccountId)) continue;

                dgAccounts.Rows.Add(new object[]
                {
                    generalLedgerAccountId,
                    accountCode,
                    generalLedgerAccountName
                });

            }

        }

        private void LoadFunds()
        {
            try
            {
                var dtFunds = Factory.FundsRepository().GetRecords();
                HelperLoadRecords.FundsComboBox(dtFunds, cmbxFunds, "fund_name", "id");
            }
            catch (Exception ex)
            {
                Helper.MessageBoxError(ex.Message);
            }
        }

        private void LoadDefaultAccounts()
        {
            CreateDatagridViewColumns(dgDefaultAccounts);

            var dtDefaultAccounts = Factory.JournalsDefaultAccountsRepository().GetViewRecordsByJournalId(journalId);

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
            if (!DesignMode)
            {
                Helper.DatagridFullRowSelectStyle(dgAccounts, true);
                Helper.DatagridFullRowSelectStyle(dgDefaultAccounts, true);
                var dtJournals = Factory.JournalsRepository().GetRecordByID(journalId);
                lblJournalName.Text = dtJournals["journal_name"].ToString();
                LoadFunds();
                LoadAccounts();
                LoadDefaultAccounts();
                lblAccountCounter.Text = NumberOfDefaultAccounts().ToString();
            }
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
            EnableDisableButtons();
        }

        private void dgDefaultAccounts_SelectionChanged(object sender, EventArgs e)
        {
            EnableDisableButtons();
        }

        private void SetDefaultAccounts()
        {
            int numberOfSelectedAccounts = dgAccounts.SelectedRows.Count;
            if (numberOfSelectedAccounts > NumberOfDefaultAccounts())
            {
                Helper.MessageBoxError($"Number of accounts you selected exceeds the maximum number of journal's default accounts");
                return;
            }

            if (dgDefaultAccounts.Rows.Count == NumberOfDefaultAccounts())
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

            lblAccountCounter.Text = NumberOfDefaultAccounts().ToString();
        }

        private void RemoveDefaultAccounts()
        {
            foreach (DataGridViewRow row in dgDefaultAccounts.SelectedRows)
            {
                int id = Convert.ToInt32(row.Cells["id"].Value);
                string accountCode = row.Cells["account_code"].Value.ToString();
                string accountName = row.Cells["account_name"].Value.ToString();

                int rowIndex = 0;
                foreach (DataGridViewRow item in dgAccounts.Rows)
                {
                    if (Convert.ToInt32(item.Cells["id"].Value) <= id)
                        rowIndex = item.Index + 1;
                }

                dgAccounts.Rows.Insert(rowIndex, new object[]
                {
                    id,
                    accountCode,
                    accountName
                });
                dgDefaultAccounts.Rows.Remove(row);
            }

            lblAccountCounter.Text = NumberOfDefaultAccounts().ToString();
        }

        private void btnSetDefaultAccount_Click(object sender, System.EventArgs e)
        {
            SetDefaultAccounts();
        }

        private void btnRemoveDefaultAccount_Click(object sender, EventArgs e)
        {
            RemoveDefaultAccounts();
        }

        private bool Save()
        {
            try
            {
                if (!ValidateChildren())
                {
                    Helper.MessageBoxError(GetFormErrors());
                    return false;
                }


                var journalsDefaulAccountsModelList = new List<JournalsDefaultAccountsModel>();

                foreach (DataGridViewRow item in dgDefaultAccounts.Rows)
                {
                    int accountId = Convert.ToInt32(item.Cells["id"].Value);
                    int fundId = Convert.ToInt32(cmbxFunds.SelectedValue);

                    var journalsDefaulAccountsModel = new JournalsDefaultAccountsModel()
                    {
                        JournalId = journalId,
                        fundId = fundId,
                        AccountId = accountId
                    };

                    journalsDefaulAccountsModelList.Add(journalsDefaulAccountsModel);
                }

                return Factory.JournalsDefaultAccountsRepository().Insert(journalsDefaulAccountsModelList);
            }
            catch (Exception ex)
            {
                Helper.MessageBoxError(ex.StackTrace);
            }

            return false;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (Save())
            {
                Helper.MessageBoxSuccess("Default Accounts has been saved.");
            }
        }


        private void cmbxFunds_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (string.IsNullOrEmpty(cmbxFunds.Text))
            {
                cmbxFunds.Tag = Helper.ErrorMessage("Fund");
                e.Cancel = true;
            }
            else
                e.Cancel = false;
        }

        private void cmbxFunds_Validated(object sender, EventArgs e)
        {
            cmbxFunds.Tag = string.Empty;
        }
    }
}
