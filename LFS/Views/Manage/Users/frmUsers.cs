using ACC.Data;
using ACC.Domain.Models;
using LFS.Helpers;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Windows.Forms;

namespace LFS.Views.Manage.Users
{
    public partial class frmUsers : Form
    {
        private bool isEdit;
        private ucUsers uc;

        public frmUsers()
        {
            InitializeComponent();
            Helper.LoadFormIcon(this);
            Helper.DatagridFullRowSelectStyle(dgUsers, true);
            uc = ucUsers1;
        }

        private void frmUsers_Load(object sender, EventArgs e)
        {
            try
            {
                OnLoad();
            }
            catch (Exception ex) { Helper.MessageBoxError(ex.Message); }
        }

        private void ToggleCrud(bool isEdit)
        {
            this.isEdit = isEdit;
            uc.ResetForm();

            if (this.isEdit)
            {
                int rowIndex = dgUsers.CurrentRow.Index;
                bool isValid = sbyte.TryParse(dgUsers.Rows[rowIndex].Cells["id"].Value.ToString(), out sbyte roleId);

                lblTitle.Text = "Update User";

                if (isValid)
                    uc.OnLoad(true, (byte)roleId);
            }
            else
            {
                lblTitle.Text = "Create User";
                uc.OnLoad(false);
            }

            tabControl1.SelectedTab = tbPgCrud;
            uc.ToggleButtons(btnBack, btnNext, btnSave);
        }

        private void OnLoad()
        {
            HelperLoadRecords.ComboboxRowLimitFilter(cmbxFilter);
            LoadRecords();
            uc.ToggleButtons(btnBack, btnNext, btnSave);
        }

        private void dgUsers_SelectionChanged(object sender, EventArgs e)
        {
            try
            {
                Helper.ShowRecordTimestampMod(dgUsers, lblCreatedAt, lblUpdatedAt);
                Helper.EnableDisableToolStripButtons(dgUsers, btnEdit, btnDelete);
            }
            catch (Exception ex) { Helper.MessageBoxError(ex.Message); }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                ToggleCrud(false);
            }
            catch (Exception ex) { Helper.MessageBoxError(ex.Message); }
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            try
            {
                ToggleCrud(true);
            }
            catch (Exception ex) { Helper.MessageBoxError(ex.Message); }
        }

        private bool DeleteData()
        {
            int selectedRowsCount = dgUsers.SelectedRows.Count;

            if (selectedRowsCount > 0)
            {
                if (Helper.MessageBoxConfirmDelete(selectedRowsCount))
                {
                    var usersModelList = new List<UsersModel>();
                    foreach (DataGridViewRow row in dgUsers.SelectedRows)
                    {
                        int userId = Convert.ToInt16(row.Cells["id"].Value.ToString());
                        usersModelList.Add(new UsersModel() { Id = userId });
                    }
                    return AccFactory.UsersRepository().Delete(usersModelList);
                }
            }
            return false;
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                if (DeleteData())
                {
                    Helper.MessageBoxSuccess($"{dgUsers.SelectedRows.Count} record/s has beend deleted.");
                    LoadRecords();
                }
            }
            catch (MySqlException mysqlEx)
            {
                switch (mysqlEx.Number)
                {
                    case 1451:
                        Helper.MessageBoxError("Cannot delete user because it is referenced to another record.");
                        break;
                }
            }
            catch (Exception ex) { Helper.MessageBoxError(ex.Message); }
        }

        private void searchTstrpBtn_Click(object sender, EventArgs e)
        {
            try
            {
                LoadRecords();
            }
            catch (Exception ex) { Helper.MessageBoxError(ex.Message); }
        }

        internal void LoadRecords()
        {
            if (!backgroundWorker1.IsBusy)
            {
                int rowLimit = int.Parse(cmbxFilter.SelectedValue.ToString());
                string searchKey = searchTstrpTxt.Text.Trim();
                progressBar1.Value = 0;
                backgroundWorker1.RunWorkerAsync((rowLimit, searchKey));
            }
        }

        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
            try
            {
                var parameters = ((int rowLimit, string searchKey))e.Argument;
                var dbDataTable = AccFactory.UsersRepository().GetViewRecordsBySearch(parameters.rowLimit, parameters.searchKey);
                var dataTable = new DataTable();
                var dataColumns = new DataColumn[]
                {
                    new DataColumn("id", typeof(int)),
                    new DataColumn("full_name", typeof(string)),
                    new DataColumn("role", typeof(string)),
                    new DataColumn("is_active", typeof(bool)),
                    new DataColumn("created_at", typeof(string)),
                    new DataColumn("updated_at", typeof(string)),
                };

                dataTable.Columns.AddRange(dataColumns);
                int totalProgressCount = dbDataTable.Rows.Count;
                int progressCount = 0;

                foreach (DataRow dataRow in dbDataTable.Rows)
                {
                    var newRow = dataTable.NewRow();
                    int userId = Convert.ToInt32(dataRow["id"]);
                    string userFullName = Helper.GenerateFullName(dataRow["prefix"].ToString(), dataRow["first_name"].ToString(), dataRow["mid_initial"].ToString(), dataRow["last_name"].ToString(), dataRow["suffix"].ToString());
                    string role = dataRow["role_name"].ToString();

                    newRow["id"] = dataRow["id"];
                    newRow["is_active"] = Convert.ToByte(dataRow["is_deleted"]) == 0;
                    newRow["full_name"] = userFullName;
                    newRow["role"] = role;
                    newRow["created_at"] = dataRow["created_at"];
                    newRow["updated_at"] = dataRow["updated_at"];

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
                    return;

                if (dataTable.Rows.Count < 1)
                    progressBar1.Value = 100;

                HelperLoadRecords.UsersDatagridView(dataTable, dgUsers);
                dgUsers.CurrentCell = dgUsers.FirstDisplayedCell;
                lblRecordCount.Text = dgUsers.Rows.Count.ToString();
            }
            catch (Exception ex) { Helper.MessageBoxError(ex.Message); }
        }

        private void cmbxFilter_SelectionChangeCommitted(object sender, EventArgs e)
        {
            try
            {
                LoadRecords();
            }
            catch (Exception ex) { Helper.MessageBoxError(ex.Message); }
        }

        private void tlStrpBtnBck_Click(object sender, EventArgs e)
        {
            try
            {
                tabControl1.SelectedTab = tbPgUsrLst;
            }
            catch (Exception ex) { Helper.MessageBoxError(ex.Message); }
        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            try
            {
                uc.TogglePages(true);
                uc.ToggleButtons(btnBack, btnNext, btnSave);
            }
            catch (Exception ex) { Helper.MessageBoxError(ex.Message); }
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            try
            {
                uc.TogglePages(false);
                uc.ToggleButtons(btnBack, btnNext, btnSave);
            }
            catch (Exception ex) { Helper.MessageBoxError(ex.Message); }
        }

        private void SaveUser(bool isEdit)
        {
            if (!uc.ValidateChildren())
            {
                Helper.MessageBoxError(uc.GetFormErrors());
                return;
            }

            bool isSaved = isEdit ?
                AccFactory.UsersRepository().Update(uc.UsersModel()) :
                AccFactory.UsersRepository().Insert(uc.UsersModel());

            if (isSaved)
            {
                uc.ResetForm();
                uc.ToggleButtons(btnBack, btnNext, btnSave);
                LoadRecords();

                if (isEdit)
                {
                    tabControl1.SelectedTab = tbPgUsrLst;
                    Helper.MessageBoxSuccess("User has been updated");
                }
                else
                {
                    Helper.MessageBoxSuccess("User has been saved");
                }
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                SaveUser(isEdit);
            }
            catch (Exception ex) { Helper.MessageBoxError(ex.StackTrace); }
        }
    }
}