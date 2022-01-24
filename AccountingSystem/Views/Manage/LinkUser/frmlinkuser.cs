using System;
using System.Windows.Forms;

namespace AccountingSystem.Views.Manage.LinkUser
{
    public partial class frmLinkUser : Form
    {
        internal int UserId = 0;
        internal string Username = string.Empty;
        internal string lname = string.Empty;
        internal string fname = string.Empty;
        internal string mname = string.Empty;
        internal string table = string.Empty;
        public frmLinkUser()
        {
            InitializeComponent();
            Helper.DatagridFullRowSelectStyle(dgvusers, true);
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
                        HelperLoadRecords.UsersDatagridView(dtusers, dgvusers);
                    }

                    if (table.Equals("disburser"))
                    {
                        var userRepository = Factory.UsersRepository();
                        var dtusers = userRepository.GetLinksDisbursingOfficers();
                        HelperLoadRecords.UsersDatagridView(dtusers, dgvusers);
                    }

                }
                 
            }
            catch (Exception ex) { Helper.MessageBoxError(ex.Message); }
        }

        private void dgvusers_SelectionChanged(object sender, EventArgs e)
        {
            if(dgvusers.SelectedRows.Count > 0)
            {
                UserId = int.Parse(dgvusers.CurrentRow.Cells[0].Value.ToString());
                Username = dgvusers.CurrentRow.Cells["username"].Value.ToString();
                fname = dgvusers.CurrentRow.Cells["first_name"].Value.ToString();
                mname = dgvusers.CurrentRow.Cells["mid_initial"].Value.ToString();
                lname = dgvusers.CurrentRow.Cells["last_name"].Value.ToString();
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
