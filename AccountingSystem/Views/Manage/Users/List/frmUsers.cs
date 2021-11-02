using ACC.Domain.Models;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace AccountingSystem.Views.Manage.Users.List
{
    public partial class frmUsers : Form
    {
        public frmUsers()
        {
            InitializeComponent();
        }

        internal void LoadRecords()
        {
            try
            {
                var usersRepository = Factory.UsersRepository();
                var dtUsers = usersRepository.GetViewRecordsByUserId();
                HelperLoadRecords.UsersDatagridView(dtUsers, dgUsers);

                lblRecordCount.Text = usersRepository.CountRecords().ToString();
            }
            catch (Exception ex) { Helper.MessageBoxError(ex.Message); }
        }

        internal void LoadDataBySearch()
        {

            try
            {
                string searchkey = Convert.ToString(txtSearch.Text);
                var dtUsers = Factory.UsersRepository().GetRecordsBySearch(searchkey);
                HelperLoadRecords.UsersDatagridView(dtUsers, dgUsers);

                lblRecordCount.Text = dgUsers.Rows.Count.ToString();
            }
            catch (Exception ex) { Helper.MessageBoxError(ex.Message); }

        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            _ = new frmUsersAdd(this).ShowDialog();
        }

        private void frmUsers_Load(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Normal;
            Helper.LoadFormIcon(this);
            Helper.DatagridFullRowSelectStyle(dgUsers, true);
            LoadRecords();
        }

        private void dgUsers_SelectionChanged(object sender, EventArgs e)
        {
            byte[] columnIndexTimestamp = { 6, 7 };
            Helper.ShowRecordTimestamp(dgUsers, columnIndexTimestamp, lblCreatedAt, lblUpdatedAt);
            Helper.EnableDisableToolStripButtons(dgUsers, btnEdit, btnDelete);
        }
        private void btnEdit_Click(object sender, EventArgs e)
        {
            int userId = int.Parse(dgUsers.SelectedCells[0].Value.ToString());
            _ = new frmUsersEdit(this, userId).ShowDialog();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            int selectedRowsCount = dgUsers.SelectedRows.Count;
            try
            {
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

                        var usersRepository = Factory.UsersRepository();
                        _ = usersRepository.Delete(usersModelList);
                        LoadRecords();
                    }
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
            catch (Exception ex)
            {
                Helper.MessageBoxError(ex.Message);
            }
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            LoadDataBySearch();
        }
    }
}
