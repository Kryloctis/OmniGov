using ACC.Data;
using ACC.Domain.Models;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;

namespace AccountingSystem.Views.Manage.Users.List
{
    public partial class frmUsers : Form
    {
        public frmUsers()
        {
            InitializeComponent();
            Helper.LoadFormIcon(this);
            Helper.DatagridFullRowSelectStyle(dgUsers, true);
        }

        private DataTable UsersDataTable()
        {
            string searchkey = txtSearch.Text.Trim();
            string userOffice = Helper.LoggedInUserData()["office"];
            DataTable dataTable;

            if (string.IsNullOrEmpty(searchkey))
                dataTable = AccFactory.UsersRepository().GetViewRecordsByOffice(userOffice);
            else
                dataTable = AccFactory.UsersRepository().GetViewRecordsBySearch(userOffice, searchkey);

            dataTable.Columns.Add("user_full_name").SetOrdinal(7);

            foreach (DataRow row in dataTable.Rows)
            {
                int userId = Convert.ToInt32(row["id"]);
                var dictUser = Helper.GetUserDataById(userId);
                row["user_full_name"] = dictUser["user_full_name"];
            }

            return dataTable;
        }

        internal void LoadRecords()
        {
            HelperLoadRecords.UsersDatagridView(UsersDataTable(), dgUsers);
            lblRecordCount.Text = dgUsers.Rows.Count.ToString();
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
            LoadRecords();
        }

        private void dgUsers_SelectionChanged(object sender, EventArgs e)
        {
            byte[] columnIndexTimestamp = { 11, 12 };
            Helper.ShowRecordTimestamp(dgUsers, columnIndexTimestamp, lblCreatedAt, lblUpdatedAt);
            Helper.EnableDisableToolStripButtons(dgUsers, btnEdit, btnDelete);
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

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            try
            {
                LoadRecords();
            }
            catch (Exception ex) { Helper.MessageBoxError(ex.Message); }
        }
    }
}