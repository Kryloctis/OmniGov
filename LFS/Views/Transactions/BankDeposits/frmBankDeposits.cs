using LFS.Helpers;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Windows.Forms;
using Treasury.Data;
using Treasury.Domain.Entities;

namespace LFS.Views.Transactions.BankDeposits
{
    public partial class frmBankDeposits : Form
    {
        private ucBankDeposits uc;

        public frmBankDeposits()
        {
            InitializeComponent();
            Helper.LoadFormIcon(this);
            Helper.DatagridFullRowSelectStyle(dgbankdeposits, true);
            uc = ucBankDeposits1;
        }

        private void frmBankDeposits_Load(object sender, EventArgs e)
        {
            try
            {
                LoadRowFilter();
                LoadRecords();
            }
            catch (Exception ex) { Helper.MessageBoxError(ex.Message); }
        }

        private bool DeleteRecords()
        {
            int selectedRowsCount = dgbankdeposits.SelectedRows.Count;
            if (Helper.MessageBoxConfirmDelete(selectedRowsCount))
            {
                var modelList = new List<BankDepositsModel>();
                foreach (DataGridViewRow row in dgbankdeposits.SelectedRows)
                {
                    int id = Convert.ToInt16(row.Cells["id"].Value.ToString());
                    modelList.Add(new BankDepositsModel() { Id = id });
                }

                return TreasuryFactory.BankDepositsRepository().Delete(modelList);
            }
            return false;
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                if (DeleteRecords())
                {
                    Helper.MessageBoxSuccess($"{dgbankdeposits.SelectedRows.Count} has been deleted.");
                    LoadRecords();
                }
            }
            catch (Exception ex) { Helper.MessageBoxError(ex.Message); }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                uc.OnLoad(false, null);
                uc.ResetForm();
                tabControl1.SelectedTab = tabPageForm;
            }
            catch (Exception ex) { Helper.MessageBoxError(ex.Message); }
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            try
            {
                int rowIndex = dgbankdeposits.CurrentRow.Index;
                int id = Convert.ToInt32(dgbankdeposits.Rows[rowIndex].Cells["id"].Value);
                uc.OnLoad(true, id);
                tabControl1.SelectedTab = tabPageForm;
            }
            catch (Exception ex) { Helper.MessageBoxError(ex.Message); }
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            try
            {
                LoadRecords();
            }
            catch (Exception ex) { Helper.MessageBoxError(ex.Message); }
        }

        private void LoadRowFilter()
        {
            HelperLoadRecords.ComboboxRowLimitFilter(cmbxRowFilter);
        }

        internal void LoadRecords()
        {
            if (!backgroundWorker1.IsBusy)
            {
                string searchKey = txtSearch.Text.Trim();
                DateTime date = dtDate.Value;
                int filterRow = Convert.ToInt32(cmbxRowFilter.SelectedValue);
                backgroundWorker1.RunWorkerAsync((date, filterRow, searchKey));
            }
        }

        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
            try
            {
                var parameters = ((DateTime date, int filterRow, string searchKey))e.Argument;
                var dbDataTable = TreasuryFactory.BankDepositsRepository().GetViewRecordBySearch(parameters.searchKey, parameters.date, parameters.filterRow);
                var dataTable = new DataTable();
                var dataColumns = new List<DataColumn>()
                {
                    new DataColumn("id", typeof(int)),
                    new DataColumn("created_by_id", typeof(string)),
                    new DataColumn("created_by_name", typeof(string)),
                    new DataColumn("updated_by_id", typeof(string)),
                    new DataColumn("updated_by_name", typeof(string)),
                    new DataColumn("account_no", typeof(string)),
                    new DataColumn("bank_name", typeof(string)),
                    new DataColumn("reference", typeof(string)),
                    new DataColumn("amount", typeof(decimal)),
                    new DataColumn("created_at", typeof(string)),
                    new DataColumn("updated_at",typeof(string))
                };
                dataTable.Columns.AddRange(dataColumns.ToArray());

                int totalProgressCount = dbDataTable.Rows.Count;
                int progressCount = 0;

                foreach (DataRow dataRow in dbDataTable.Rows)
                {
                    var newRow = dataTable.NewRow();

                    int id = Convert.ToInt32(dataRow["id"]);
                    string createdById = dataRow["created_by"].ToString();
                    string updatedById = dataRow["updated_by"].ToString();

                    string createdByName = Helper.GetUserDataById(Convert.ToInt32(createdById))["user_full_name"];
                    string updatedByName = string.IsNullOrWhiteSpace(updatedById) ? string.Empty : Helper.GetUserDataById(Convert.ToInt32(updatedById))["user_full_name"];

                    string accountNo = dataRow["account_no"].ToString();
                    string bankName = dataRow["bank_name"].ToString();
                    string reference = dataRow["reference"].ToString();
                    decimal amount = Convert.ToDecimal(dataRow["amount"]);
                    string updatedAt = dataRow["updated_at"].ToString();
                    string createdAt = dataRow["created_at"].ToString();

                    newRow["id"] = id;
                    newRow["created_by_id"] = createdById;
                    newRow["created_by_name"] = createdByName;
                    newRow["updated_by_id"] = updatedById;
                    newRow["updated_by_name"] = updatedByName;
                    newRow["account_no"] = accountNo;
                    newRow["bank_name"] = bankName;
                    newRow["reference"] = reference;
                    newRow["amount"] = amount;
                    newRow["created_at"] = createdAt;
                    newRow["updated_at"] = updatedAt;

                    dataTable.Rows.Add(newRow);
                    progressCount++;
                    Helper.ProgressCounter(backgroundWorker1, totalProgressCount, progressCount);
                }

                e.Result = dataTable;
            }
            catch (Exception ex) { Helper.MessageBoxError(ex.Message); }
        }

        private void backgroundWorker1_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            progressBar1.Value = e.ProgressPercentage;
        }

        private void backgroundWorker1_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            try
            {
                if (e.Result is not DataTable dataTable)
                {
                    progressBar1.Value = 100;
                    return;
                }

                HelperLoadRecords.DepositsDatagridView(dataTable, dgbankdeposits);
                dgbankdeposits.CurrentCell = dgbankdeposits.FirstDisplayedCell;
                lblRecordCount.Text = dgbankdeposits.Rows.Count.ToString();
            }
            catch (Exception ex) { Helper.MessageBoxError(ex.Message); }
        }

        private void cmbxRowFilter_SelectionChangeCommitted(object sender, EventArgs e)
        {
            try
            {
                LoadRecords();
            }
            catch (Exception ex) { Helper.MessageBoxError(ex.Message); }
        }

        private void dtDate_ValueChanged(object sender, EventArgs e)
        {
            try
            {
                LoadRecords();
            }
            catch (Exception ex) { Helper.MessageBoxError(ex.Message); }
        }

        private void dgbankdeposits_SelectionChanged(object sender, EventArgs e)
        {
            try
            {
                Helper.EnableDisableToolStripButtons(dgbankdeposits, btnEdit, btnDelete);
            }
            catch (Exception ex) { Helper.MessageBoxError(ex.Message); }
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            try
            {
                tabControl1.SelectedTab = tabPageList;
            }
            catch (Exception ex) { Helper.MessageBoxError(ex.Message); }
        }

        private void frmBankDeposits_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.S && e.Control && tabControl1.SelectedTab == tabPageForm)
                {
                    bool isEdit = false;

                    if (uc.Save(ref isEdit))
                    {
                        if (isEdit)
                        {
                            Helper.MessageBoxSuccess("Bank deposit has been updated.");
                            LoadRecords();
                            tabControl1.SelectedTab = tabPageList;
                        }
                        else
                        {
                            Helper.MessageBoxSuccess("Bank deposit has been saved.");
                            LoadRecords();
                            uc.ResetForm();
                        }
                    }
                }
            }
            catch (Exception ex) { Helper.MessageBoxError(ex.Message); }
        }
    }
}
