using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace AccountingSystem.Views.Manage.LinkUser
{
    public partial class frmLinkUser : Form
    {
        internal int UserId = 0;
        internal string Username = string.Empty;
        internal string prefix = string.Empty;
        internal string lastName = string.Empty;
        internal string firstName = string.Empty;
        internal string middleInitial = string.Empty;
        internal string suffix = string.Empty;
        internal string userType = string.Empty;

        public frmLinkUser()
        {
            InitializeComponent();
            Helper.DatagridFullRowSelectStyle(dgvusers, true);
            dgvusers.MultiSelect = false;
        }

        private void frmlinkuser_Load(object sender, EventArgs e)
        {
            LoadRecords();
        }

        internal void LoadRecords()
        {
            try
            {
                if (!string.IsNullOrEmpty(userType))
                {
                    if (userType.Equals("collector")) {
                        var userRepository = AccFactory.UsersRepository();
                        var dtusers = userRepository.GetLinksCollectingOfficers();

                        foreach (DataRow row in dtusers.Rows)
                        {
                            int userId = Convert.ToInt32(row["id"]);
                            var dictUser = Helper.GetUserDataById(userId);
                            row["user_full_name"] = dictUser["user_full_name"];
                        }

                        HelperLoadRecords.UsersDatagridView(dtusers, dgvusers);
                    }

                    if (userType.Equals("disburser"))
                    {
                        var userRepository = AccFactory.UsersRepository();
                        var dtusers = userRepository.GetLinksDisbursingOfficers();

                        foreach (DataRow row in dtusers.Rows)
                        {
                            int userId = Convert.ToInt32(row["id"]);
                            var dictUser = Helper.GetUserDataById(userId);
                            row["user_full_name"] = dictUser["user_full_name"];
                        }

                        HelperLoadRecords.UsersDatagridView(dtusers, dgvusers);
                    }

                    if (userType.Equals("JO"))
                    {
                        var userRepository = AccFactory.UsersRepository();
                        var dtusers = userRepository.GetLinksJOCollectingOfficers();

                        HelperLoadRecords.UsersDatagridView(dtusers, dgvusers);
                    }

                }
            }
            catch (Exception ex)
            {
                Helper.MessageBoxError(ex.Message);
            }
        }

        private void dgvusers_SelectionChanged(object sender, EventArgs e)
        {
            if(dgvusers.SelectedRows.Count != 0)
            {
                UserId = int.Parse(dgvusers.CurrentRow.Cells[0].Value.ToString());
                Username = dgvusers.CurrentRow.Cells["username"].Value.ToString();
                prefix = dgvusers.CurrentRow.Cells["prefix"].Value.ToString();
                firstName = dgvusers.CurrentRow.Cells["first_name"].Value.ToString();
                middleInitial = dgvusers.CurrentRow.Cells["mid_initial"].Value.ToString();
                lastName = dgvusers.CurrentRow.Cells["last_name"].Value.ToString();
                suffix = dgvusers.CurrentRow.Cells["suffix"].Value.ToString();
            }
        }

        private void dgvusers_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex != -1)
            {
                this.DialogResult = DialogResult.OK;
            }
        }

        private void dgvusers_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
