using ACC.Data;
using ACC.Domain.Models;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Windows.Forms;

namespace AccountingSystem.Views.Manage.Users.List
{
    public partial class frmUsers : Form
    {
        public frmUsers()
        {
            InitializeComponent();
            Helper.LoadFormIcon(this);

            //Removes tabs to tabcontrol
            tabControl1.Padding = new Point(0, 0);
            tabControl1.ItemSize = new Size(0, 1);
            tabControl1.SizeMode = TabSizeMode.Fixed;
            tabControl1.Appearance = TabAppearance.FlatButtons;
            tabControl1.DrawMode = TabDrawMode.OwnerDrawFixed;

            Helper.DatagridFullRowSelectStyle(dgUsers, true);
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                _ = new frmUsersAdd(this).ShowDialog();
            }
            catch (Exception ex) { Helper.MessageBoxError(ex.Message); }
        }

        private void frmUsers_Load(object sender, EventArgs e)
        {
            try
            {
                OnLoad();
            }
            catch (Exception ex) { Helper.MessageBoxError(ex.Message); }
        }

        private void OnLoad()
        {
            HelperLoadRecords.RowFilterCombobox(cmbxFilter);
            LoadRecords();
        }

        private void dgUsers_SelectionChanged(object sender, EventArgs e)
        {
            try
            {
                byte[] columnIndexTimestamp = { 4, 5 };
                Helper.ShowRecordTimestamp(dgUsers, columnIndexTimestamp, lblCreatedAt, lblUpdatedAt);
                Helper.EnableDisableToolStripButtons(dgUsers, btnEdit, btnDelete);
            }
            catch (Exception ex) { Helper.MessageBoxError(ex.Message); }
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            int userId = int.Parse(dgUsers.SelectedCells[0].Value.ToString());
            _ = new frmUsersEdit(this, userId).ShowDialog();
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
                        int userId = Convert.ToInt16(row.Cells[0].Value.ToString());
                        usersModelList.Add(new UsersModel() { Id = userId });
                    }

                    var usersRepository = AccFactory.UsersRepository();
                    return usersRepository.Delete(usersModelList);
                }
            }
            return false;
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                if (DeleteData())
                    LoadRecords();
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
                string userOffice = Helper.LoggedInUserData()["office"];
                string searchKey = searchTstrpTxt.Text.Trim();
                backgroundWorker1.RunWorkerAsync((rowLimit, userOffice, searchKey));
            }
        }

        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
            try
            {
                var parameters = ((int rowLimit, string userOffice, string searchKey))e.Argument;
                var dbDataTable = AccFactory.UsersRepository().GetViewRecordsBySearch(parameters.rowLimit, parameters.userOffice, parameters.searchKey);
                var dataTable = new DataTable();
                var dataColumns = new DataColumn[]
                {
                    new DataColumn("id", typeof(int)),
                    new DataColumn("full_name", typeof(string)),
                    new DataColumn("role", typeof(string)),
                    new DataColumn("office", typeof(string)),
                    new DataColumn("created_at", typeof(string)),
                    new DataColumn("updated_at", typeof(string))
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
                    newRow["full_name"] = userFullName;
                    newRow["office"] = dataRow["office"];
                    newRow["role"] = role;
                    newRow["created_at"] = string.IsNullOrWhiteSpace(dataRow["created_at"].ToString()) ? string.Empty : DateTime.Parse(dataRow["created_at"].ToString()).ToShortDateString();
                    newRow["updated_at"] = string.IsNullOrWhiteSpace(dataRow["updated_at"].ToString()) ? string.Empty : DateTime.Parse(dataRow["updated_at"].ToString()).ToShortDateString();

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
    }
}