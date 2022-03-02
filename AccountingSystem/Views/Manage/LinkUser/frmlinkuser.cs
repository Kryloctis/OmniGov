using System;
using System.Data;
using System.Windows.Forms;

namespace AccountingSystem.Views.Manage.LinkUser
{
    public partial class frmLinkUser : Form
    {
        internal int UserId = 0;
        internal string Username = string.Empty;
        internal string prefix = string.Empty;
        internal string lname = string.Empty;
        internal string fname = string.Empty;
        internal string mname = string.Empty;
        internal string suffix = string.Empty;
        internal string table = string.Empty;
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
                if (!string.IsNullOrEmpty(table))
                {
                    if(table.Equals("collector")){
                        var userRepository = Factory.UsersRepository();
                        var dtusers = userRepository.GetLinksCollectingOfficers();

                        foreach (DataRow row in dtusers.Rows)
                        {
                            int userId = Convert.ToInt32(row["id"]);
                            var dictUser = Helper.GetUserDataById(userId);
                            row["user_full_name"] = dictUser["user_full_name"];
                        }

                        HelperLoadRecords.UsersDatagridView(dtusers, dgvusers);
                    }

                    if (table.Equals("disburser"))
                    {
                        var userRepository = Factory.UsersRepository();
                        var dtusers = userRepository.GetLinksDisbursingOfficers();


                        foreach (DataRow row in dtusers.Rows)
                        {
                            int userId = Convert.ToInt32(row["id"]);
                            var dictUser = Helper.GetUserDataById(userId);
                            row["user_full_name"] = dictUser["user_full_name"];
                        }

                        HelperLoadRecords.UsersDatagridView(dtusers, dgvusers);
                    }

                    if (table.Equals("JO"))
                    {
                        var userRepository = Factory.UsersRepository();
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
                fname = dgvusers.CurrentRow.Cells["first_name"].Value.ToString();
                mname = dgvusers.CurrentRow.Cells["mid_initial"].Value.ToString();
                lname = dgvusers.CurrentRow.Cells["last_name"].Value.ToString();
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

       
    }
}
