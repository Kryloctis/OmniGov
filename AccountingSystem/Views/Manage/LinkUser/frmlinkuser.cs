using System;
using System.Data;
using System.Windows.Forms;

namespace AccountingSystem.Views.Manage.LinkUser
{
    public partial class frmLinkUser : Form
    {
        internal int UserId;
        internal string userName = string.Empty;
        internal string prefix = string.Empty;
        internal string lastName = string.Empty;
        internal string firstName = string.Empty;
        internal string middleInitial = string.Empty;
        internal string suffix = string.Empty;
        internal string userType = string.Empty;

        public frmLinkUser()
        {
            InitializeComponent();
            Helper.DatagridFullRowSelectStyle(dgUsers, true);
        }

        private void frmlinkuser_Load(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(userType))
                LoadRecords();
        }

        internal void LoadRecords()
        {
            try
            {
                string textSearch = txtSearch.Text.Trim();
                var userRepository = AccFactory.UsersRepository();
                var dataTableUsers = new DataTable();

                switch (userType)
                {
                    case "collector":
                        dataTableUsers = userRepository.GetLinksCollectingOfficers(textSearch);
                        break;
                    case "disburser":
                        dataTableUsers = userRepository.GetLinksDisbursingOfficers();
                        break;
                    case "JO":
                        dataTableUsers = userRepository.GetLinksJOCollectingOfficers();
                        break;
                }

                foreach (DataRow row in dataTableUsers.Rows)
                {
                    int userId = Convert.ToInt32(row["id"]);
                    var dictUser = Helper.GetUserDataById(userId);
                    row["user_full_name"] = dictUser["user_full_name"];
                }

                HelperLoadRecords.UsersDatagridView(dataTableUsers, dgUsers);
            }
            catch (Exception ex)
            {
                Helper.MessageBoxError(ex.Message);
            }
        }

        private void dgvusers_SelectionChanged(object sender, EventArgs e)
        {
            if (dgUsers.SelectedRows.Count != 0)
            {
                UserId = int.Parse(dgUsers.CurrentRow.Cells[0].Value.ToString());
                userName = dgUsers.CurrentRow.Cells["username"].Value.ToString();
                prefix = dgUsers.CurrentRow.Cells["prefix"].Value.ToString();
                firstName = dgUsers.CurrentRow.Cells["first_name"].Value.ToString();
                middleInitial = dgUsers.CurrentRow.Cells["mid_initial"].Value.ToString();
                lastName = dgUsers.CurrentRow.Cells["last_name"].Value.ToString();
                suffix = dgUsers.CurrentRow.Cells["suffix"].Value.ToString();
            }
        }

        private void dgvusers_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex != -1)
            {
                this.DialogResult = DialogResult.OK;
            }
        }

    }
}