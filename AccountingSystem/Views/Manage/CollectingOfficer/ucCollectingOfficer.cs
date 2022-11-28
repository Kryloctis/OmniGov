using ACC.Domain.Interfaces;
using AccountingSystem.Views.Manage.LinkUser;
using System;
using System.ComponentModel;
using System.Windows.Forms;

namespace AccountingSystem.Views.Manage.CollectingOfficer
{
    public partial class ucCollectingOfficer : UserControl
    {
        internal int OfficerId = 0;
        internal int UserId = 0;

        public ucCollectingOfficer()
        {
            InitializeComponent();
        }

        internal string GetFormErrors()
        {
            var errorArray = new string[4];
            errorArray[0] = epFirstName.GetError(txtFirstName);
            errorArray[1] = epMiddleInitial.GetError(txtMiddleInitial);
            errorArray[2] = epLastName.GetError(txtLastName);
            errorArray[3] = epJobtitle.GetError(txtJobtitle);

            IError _errors = AccFactory.CreateErrors(errorArray);
            return _errors.GenerateErrorMessage();
        }

        internal void linkuser_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (UserId > 0)
            {
                UserId = 0;
                linkuser.Text = "+ Link User";
            }
            else
            {
                frmLinkUser fuser = new();
                fuser.userType = "collector";

                if (fuser.ShowDialog() == DialogResult.OK)
                {
                    UserId = fuser.UserId;
                    linkuser.Text = string.Format("@{0}", fuser.Username);
                    if (txtLastName.Text == string.Empty && txtFirstName.Text == string.Empty && txtMiddleInitial.Text == string.Empty)
                    {
                        SetReadOnlyConrol(true);
                        txtPrefix.Text = fuser.prefix;
                        txtLastName.Text = fuser.lastName;
                        txtFirstName.Text = fuser.firstName;
                        txtMiddleInitial.Text = fuser.middleInitial;
                        txtSuffix.Text = fuser.suffix;
                    }
                }
            }
        }

        internal void LoadLink(int id)
        {
            try
            {
                var userRepository = AccFactory.UsersRepository();
                var data = userRepository.GetUserByID(id);
                if (data.Count > 0)
                {
                    UserId = id;
                    linkuser.Text = String.Format("@{0}", data["username"]);
                }
                else
                {
                    UserId = 0;
                    linkuser.Text = "+ Link User";
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
            UserId = 0;
            linkuser.Text = "+ Link User";
        }

        internal void SetReadOnlyConrol(bool reaonly)
        {
            txtPrefix.ReadOnly = reaonly;
            txtLastName.ReadOnly = reaonly;
            txtFirstName.ReadOnly = reaonly;
            txtMiddleInitial.ReadOnly = reaonly;
            txtSuffix.ReadOnly = reaonly;
        }

        private void txtFname_Validated(object sender, EventArgs e)
        {
            Helper.ClearErrorTextBox(epFirstName, txtFirstName);
        }

        private void txtFname_Validating(object sender, CancelEventArgs e)
        {
            e.Cancel = Helper.ShowErrorTextBoxEmpty(epFirstName, txtFirstName, "first name");

            var collectingOfficerRepository = AccFactory.CollectingOfficerRepository();
            string fName = txtFirstName.Text.Trim();
            string midInitial = txtMiddleInitial.Text.Trim();
            string lname = txtLastName.Text.Trim();
            bool fullNameExist;

            fullNameExist = collectingOfficerRepository.FullNameExist(fName, midInitial, lname, OfficerId); // add form

            if (fullNameExist)
            {
                epFirstName.SetError(txtFirstName, "Validation");
                e.Cancel = true;
            }
        }

        private void txtLname_Validated(object sender, EventArgs e)
        {
            Helper.ClearErrorTextBox(epLastName, txtLastName);
        }

        private void txtLname_Validating(object sender, CancelEventArgs e)
        {
            e.Cancel = Helper.ShowErrorTextBoxEmpty(epLastName, txtLastName, "last name");

            string firstName = txtFirstName.Text.Trim();
            string middleInitial = txtMiddleInitial.Text.Trim();
            string lastName = txtLastName.Text.Trim();
            bool fullNameExist;

            var collectingOfficerRepository = AccFactory.CollectingOfficerRepository();
            fullNameExist = collectingOfficerRepository.FullNameExist(firstName, middleInitial, lastName, OfficerId);

            if (fullNameExist)
            {
                epLastName.SetError(txtLastName, "Fullname Details already exist in your records. ");
                e.Cancel = true;
            }
        }

        private void txtMI_Validated(object sender, EventArgs e)
        {
            Helper.ClearErrorTextBox(epMiddleInitial, txtMiddleInitial);
        }

        private void txtMI_Validating(object sender, CancelEventArgs e)
        {
            e.Cancel = Helper.ShowErrorTextBoxEmpty(epMiddleInitial, txtMiddleInitial, "middle initial");

            var collectingOfficerRepository = AccFactory.CollectingOfficerRepository();
            string fName = txtFirstName.Text.Trim();
            string midInitial = txtMiddleInitial.Text.Trim();
            string lname = txtLastName.Text.Trim();
            bool fullNameExist;

            fullNameExist = collectingOfficerRepository.FullNameExist(fName, midInitial, lname, OfficerId); // add form

            if (fullNameExist)
            {
                epMiddleInitial.SetError(txtMiddleInitial, "Officer's Fullname");
                e.Cancel = true;
            }
        }

        private void ucCollectingOfficer_Load(object sender, EventArgs e)
        {
        }
    }
}