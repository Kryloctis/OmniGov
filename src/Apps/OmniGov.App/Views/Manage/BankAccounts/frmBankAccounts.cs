using OmniGov.App.Helpers;
using OmniGov.Treasury.Data.Factories;
using OmniGov.Treasury.Domain.Entities;
using System.ComponentModel;
using System.Data;

namespace OmniGov.App.Views.Manage.BankAccounts
{
    public partial class frmBankAccounts : Form
    {
        public frmBankAccounts()
        {
            InitializeComponent();
            Helper.LoadFormIcon(this);
            Helper.DatagridFullRowSelectStyle(dgBankAccounts, true, true);
        }

        internal void LoadRecords()
        {
            if (!backgroundWorker1.IsBusy)
            {
                pbLoadRecords.Value = 0;
                int rowLimit = Convert.ToInt32(cmbxRowLimit.SelectedValue);
                string searchKey = txtSearch.Text.Trim();
                backgroundWorker1.RunWorkerAsync((rowLimit, searchKey));
            }
        }

        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
            var parameters = ((int rowLimit, string searchKey))e.Argument;

            var dtBankAccount = TreasuryFactory.BankAccountsRepository().GetViewRecordsBySearch(parameters.rowLimit, parameters.searchKey.Trim());
            int totalProgressCount = dtBankAccount.Rows.Count;
            int progressCount = 0;

            dtBankAccount.Rows.Cast<DataRow>().ToList().ForEach(x =>
            {
                progressCount++;
                Helper.ProgressCounter(backgroundWorker1, totalProgressCount, progressCount);
            });

            e.Result = dtBankAccount;
        }

        private void backgroundWorker1_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            pbLoadRecords.Value = e.ProgressPercentage;
        }

        private void backgroundWorker1_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (e.Result is not DataTable dataTable)
                return;

            if (dataTable.Rows.Count < 1)
                pbLoadRecords.Value = 100;

            HelperLoadRecords.DatagridViewBankAccounts(dataTable, dgBankAccounts);
            dgBankAccounts.CurrentCell = dgBankAccounts.FirstDisplayedCell;
            toolStripStatusLabelRecordCount.Text = dgBankAccounts.Rows.Count.ToString();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            _ = new frmAddBankAccounts(this).ShowDialog();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (DeleteData())
            {
                Helper.MessageBoxError($"{dgBankAccounts.SelectedRows.Count} record/s has been deleted.");
                LoadRecords();
            }
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            int rowIndex = dgBankAccounts.CurrentRow.Index;
            int bankAccountId = Convert.ToInt32(dgBankAccounts.Rows[rowIndex].Cells["id"].Value);
            _ = new frmEditBankAccounts(this, bankAccountId).ShowDialog();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            LoadRecords();
        }

        private void cmbxRowLimit_SelectionChangeCommitted(object sender, EventArgs e)
        {
            LoadRecords();
        }

        private bool DeleteData()
        {
            int selectedRowsCount = dgBankAccounts.SelectedRows.Count;

            if (Helper.MessageBoxConfirmDelete(selectedRowsCount))
            {
                var bankAccountsModelList = new List<BankAccountsModel>();
                foreach (DataGridViewRow row in dgBankAccounts.SelectedRows)
                {
                    int bankAccountID = Convert.ToInt16(row.Cells["id"].Value.ToString());
                    bankAccountsModelList.Add(new BankAccountsModel() { Id = bankAccountID });
                }

                return TreasuryFactory.BankAccountsRepository().Delete(bankAccountsModelList);
            }
            return false;
        }

        private void dgBankAccounts_SelectionChanged(object sender, EventArgs e)
        {
            var columnIndex = new byte[] { 6, 7 };
            Helper.ShowRecordTimestamp(dgBankAccounts, columnIndex, lblCreatedAt, lblUpdatedAt);

            Helper.EnableDisableToolStripButtons(dgBankAccounts, btnEdit, btnDelete);
        }

        private void frmBankAccounts_Load(object sender, EventArgs e)
        {
            HelperLoadRecords.ComboboxRowLimitFilter(cmbxRowLimit);
            LoadRecords();
        }
    }
}