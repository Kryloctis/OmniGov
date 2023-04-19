using AccountingSystem.Views.Manage.LinkUser;
using System;
using System.ComponentModel;
using System.Windows.Forms;

namespace AccountingSystem.Views.Manage.DisbursingOfficer
{
    public partial class ucDisbursingOfficer : UserControl
    {
        internal int disbursingOfficerId = 0;
        internal int UserId = 0;

        public ucDisbursingOfficer()
        {
            InitializeComponent();
        }

        internal string GetFormErrors()
        {
            var errorArray = new string[]
            {
                errorProvider1.GetError(txtFirstName),
                errorProvider1.GetError(txtMidInitial),
                errorProvider1.GetError(txtLastName),
                errorProvider1.GetError(txtJobTitle)
            };

            return AccFactory.CreateErrors(errorArray).GenerateErrorMessage();
        }

        internal void ResetForm()
        {
            txtFirstName.Clear();
            txtMidInitial.Clear();
            txtLastName.Clear();
            txtJobTitle.Clear();
        }

        private void txtFirstName_Validating(object sender, CancelEventArgs e)
        {
            e.Cancel = Helper.ShowErrorTextBoxEmpty(errorProvider1, txtFirstName, lblFirstName.Text);
        }

        private void txtFirstName_Validated(object sender, EventArgs e)
        {
            Helper.ClearErrorTextBox(errorProvider1, txtFirstName);
        }

        private void txtMidInitial_Validating(object sender, CancelEventArgs e)
        {
            e.Cancel = Helper.ShowErrorTextBoxEmpty(errorProvider1, txtMidInitial, lblMidInitial.Text);
        }

        private void txtMidInitial_Validated(object sender, EventArgs e)
        {
            Helper.ClearErrorTextBox(errorProvider1, txtMidInitial);
        }

        private void txtLastName_Validating(object sender, CancelEventArgs e)
        {
            e.Cancel = Helper.ShowErrorTextBoxEmpty(errorProvider1, txtLastName, lblLastName.Text);
        }

        private void txtLastName_Validated(object sender, EventArgs e)
        {
            Helper.ClearErrorTextBox(errorProvider1, txtLastName);
        }

        private void txtJobTitle_Validating(object sender, CancelEventArgs e)
        {
            e.Cancel = Helper.ShowErrorTextBoxEmpty(errorProvider1, txtJobTitle, lblJobTitle.Text);
        }

        private void txtJobTitle_Validated(object sender, EventArgs e)
        {
            Helper.ClearErrorTextBox(errorProvider1, txtJobTitle);
        }

        private void linkuser_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (UserId > 0)
            {
                UserId = 0;
                linkuser.Text = "+ Link User";
            }
            else
            {
                frmLinkUser fuser = new frmLinkUser();
                fuser.userType = "disburser";
                if (fuser.ShowDialog() == DialogResult.OK)
                {
                    UserId = fuser.UserId;
                    linkuser.Text = String.Format("@{0}", fuser.Username);
                    if (txtLastName.Text == string.Empty && txtFirstName.Text == string.Empty && txtMidInitial.Text == string.Empty)
                    {
                        txtPrefix.Text = fuser.prefix;
                        txtLastName.Text = fuser.lastName;
                        txtFirstName.Text = fuser.firstName;
                        txtMidInitial.Text = fuser.middleInitial;
                        txtSuffix.Text = fuser.suffix;
                    }
                }
            }
        }

        internal void LoadLink(int id)
        {
            try
            {
                var data = AccFactory.UsersRepository().GetUserByID(id);
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
            catch (Exception ex) { Helper.MessageBoxError(ex.Message); }
        }
    }
}