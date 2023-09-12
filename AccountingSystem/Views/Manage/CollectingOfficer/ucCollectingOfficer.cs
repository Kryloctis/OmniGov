using AccountingSystem.Views.Manage.LinkUser;
using System;
using System.ComponentModel;
using System.Windows.Forms;

namespace AccountingSystem.Views.Manage.CollectingOfficer
{
    public partial class ucCollectingOfficer : UserControl
    {
        internal int officerID = 0;
        internal int userID = 0;

        public ucCollectingOfficer()
        {
            InitializeComponent();
        }

        internal string GetFormErrors()
        {
            var errorArray = new string[]
            {
                errorProvider1.GetError(txtFirstName),
                errorProvider1.GetError(txtMiddleInitial),
                errorProvider1.GetError(txtLastName),
                errorProvider1.GetError(txtJobtitle)
            };

            return AccFactory.CreateErrors(errorArray).GenerateErrorMessage();
        }

        internal void SetReadOnlyConrol(bool reaonly)
        {
            txtPrefix.ReadOnly = reaonly;
            txtLastName.ReadOnly = reaonly;
            txtFirstName.ReadOnly = reaonly;
            txtMiddleInitial.ReadOnly = reaonly;
            txtSuffix.ReadOnly = reaonly;
        }

        private void SelectUser()
        {
            frmLinkUser frmLinkuser = new() { userType = "collector" };

            if (frmLinkuser.ShowDialog() == DialogResult.OK)
            {
                userID = frmLinkuser.UserId;
                linkUser.Text = $"{frmLinkuser.userName}";

                int selectedUserCount = frmLinkuser.dgUsers.SelectedRows.Count;
                if (selectedUserCount == 1)
                {
                    SetReadOnlyConrol(true);
                    txtPrefix.Text = frmLinkuser.prefix;
                    txtLastName.Text = frmLinkuser.lastName;
                    txtFirstName.Text = frmLinkuser.firstName;
                    txtMiddleInitial.Text = frmLinkuser.middleInitial;
                    txtSuffix.Text = frmLinkuser.suffix;
                }
            }
        }

        internal void linkuser_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            SelectUser();
        }

        internal void LoadLink(int id)
        {
            try
            {
                var userRepository = AccFactory.UsersRepository();
                var data = userRepository.GetUserByID(id);
                if (data.Count > 0)
                {
                    userID = id;
                    linkUser.Text = String.Format("@{0}", data["username"]);
                }
                else
                {
                    userID = 0;
                    linkUser.Text = "Link User";
                }
            }
            catch (Exception ex)
            {
                Helper.MessageBoxError(ex.Message);
            }
        }

        internal void ResetForm()
        {
            txtPrefix.Clear();
            txtFirstName.Clear();
            txtMiddleInitial.Clear();
            txtLastName.Clear();
            txtSuffix.Clear();
            txtJobtitle.Text = "Collecting Officer";
            userID = 0;
            linkUser.Text = "Link User";
        }

        private void txtFname_Validated(object sender, EventArgs e)
        {
            Helper.ClearErrorTextBox(errorProvider1, txtFirstName);
        }

        private void txtFname_Validating(object sender, CancelEventArgs e)
        {
            e.Cancel = Helper.ShowErrorTextBoxEmpty(errorProvider1, txtFirstName, "first name");

            var collectingOfficerRepository = AccFactory.CollectingOfficerRepository();
            string firstName = txtFirstName.Text.Trim();
            string midInitial = txtMiddleInitial.Text.Trim();
            string lastName = txtLastName.Text.Trim();
            bool fullNameExist;

            fullNameExist = collectingOfficerRepository.FullNameExist(firstName, midInitial, lastName, officerID);

            if (fullNameExist)
            {
                errorProvider1.SetError(txtFirstName, "Validation");
                e.Cancel = true;
            }
        }

        private void txtLname_Validated(object sender, EventArgs e)
        {
            Helper.ClearErrorTextBox(errorProvider1, txtLastName);
        }

        private void txtLname_Validating(object sender, CancelEventArgs e)
        {
            e.Cancel = Helper.ShowErrorTextBoxEmpty(errorProvider1, txtLastName, "last name");

            string firstName = txtFirstName.Text.Trim();
            string middleInitial = txtMiddleInitial.Text.Trim();
            string lastName = txtLastName.Text.Trim();
            bool fullNameExist;

            var collectingOfficerRepository = AccFactory.CollectingOfficerRepository();
            fullNameExist = collectingOfficerRepository.FullNameExist(firstName, middleInitial, lastName, officerID);

            if (fullNameExist)
            {
                errorProvider1.SetError(txtLastName, "Fullname Details already exist in your records. ");
                e.Cancel = true;
            }
        }

        private void txtMI_Validated(object sender, EventArgs e)
        {
            Helper.ClearErrorTextBox(errorProvider1, txtMiddleInitial);
        }

        private void txtMI_Validating(object sender, CancelEventArgs e)
        {
            e.Cancel = Helper.ShowErrorTextBoxEmpty(errorProvider1, txtMiddleInitial, "middle initial");

            var collectingOfficerRepository = AccFactory.CollectingOfficerRepository();
            string fName = txtFirstName.Text.Trim();
            string midInitial = txtMiddleInitial.Text.Trim();
            string lname = txtLastName.Text.Trim();
            bool fullNameExist;

            fullNameExist = collectingOfficerRepository.FullNameExist(fName, midInitial, lname, officerID);

            if (fullNameExist)
            {
                errorProvider1.SetError(txtMiddleInitial, "Officer's Fullname");
                e.Cancel = true;
            }
        }

        private void ucCollectingOfficer_Load(object sender, EventArgs e)
        {

        }
    }
}