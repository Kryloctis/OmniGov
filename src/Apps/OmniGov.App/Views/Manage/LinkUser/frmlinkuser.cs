using OmniGov.App.Helpers;

using OmniGov.Core.Factories;

using System.Data;

namespace OmniGov.App.Views.Manage.LinkUser

{
    public partial class frmLinkUser : Form

    {
        internal string firstName = string.Empty;
        internal string lastName = string.Empty;
        internal string middleInitial = string.Empty;
        internal string prefix = string.Empty;
        internal string suffix = string.Empty;
        internal int UserId;

        internal string userName = string.Empty;
        internal string userType = string.Empty;

        public frmLinkUser()

        {
            InitializeComponent();

            Helper.DatagridFullRowSelectStyle(dgUsers, true);
        }

        internal void LoadRecords()

        {
            string textSearch = txtSearch.Text.Trim();

            var dataTableUsers = new DataTable();

            switch (userType)

            {
                case "collector":

                    dataTableUsers = Factory.UsersRepository().GetLinksCollectingOfficers(textSearch);

                    break;

                case "disburser":

                    dataTableUsers = Factory.UsersRepository().GetLinksDisbursingOfficers();

                    break;

                case "JO":

                    dataTableUsers = Factory.UsersRepository().GetLinksJOCollectingOfficers();

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

        private void dgvusers_CellDoubleClick(object sender, DataGridViewCellEventArgs e)

        {
            if (e.RowIndex != -1)
            {
                this.DialogResult = DialogResult.OK;
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

        private void frmlinkuser_Load(object sender, EventArgs e)

        {
            OnLoad();
        }

        private void OnLoad()

        {
            if (!string.IsNullOrEmpty(userType))

                LoadRecords();
        }
    }
}