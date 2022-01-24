using ACC.Domain.Interfaces;
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
            var errorArray = new string[4];
            errorArray[0] = epFirstName.GetError(txtFirstName);
            errorArray[1] = epMidInitial.GetError(txtMidInitial);
            errorArray[2] = epLastName.GetError(txtLastName);
            errorArray[3] = epJobTitle.GetError(txtJobTitle);

            IError _errors = Factory.CreateErrors(errorArray);
            return _errors.GenerateErrorMessage();
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
            e.Cancel = Helper.ShowErrorTextBoxEmpty(epFirstName, txtFirstName, lblFirstName.Text);
        }

        private void txtFirstName_Validated(object sender, EventArgs e)
        {
            Helper.ClearErrorTextBox(epFirstName, txtFirstName);
        }

        private void txtMidInitial_Validating(object sender, CancelEventArgs e)
        {
            e.Cancel = Helper.ShowErrorTextBoxEmpty(epMidInitial, txtMidInitial, lblMidInitial.Text);
        }

        private void txtMidInitial_Validated(object sender, EventArgs e)
        {
            Helper.ClearErrorTextBox(epMidInitial, txtMidInitial);
        }

        private void txtLastName_Validating(object sender, CancelEventArgs e)
        {
            e.Cancel = Helper.ShowErrorTextBoxEmpty(epLastName, txtLastName, lblLastName.Text);
        }

        private void txtLastName_Validated(object sender, EventArgs e)
        {
            Helper.ClearErrorTextBox(epLastName, txtLastName);
        }

        private void txtJobTitle_Validating(object sender, CancelEventArgs e)
        {
            e.Cancel = Helper.ShowErrorTextBoxEmpty(epJobTitle, txtJobTitle, lblJobTitle.Text);
        }

        private void txtJobTitle_Validated(object sender, EventArgs e)
        {
            Helper.ClearErrorTextBox(epJobTitle, txtJobTitle);
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
                fuser.table = "disburser";
                if (fuser.ShowDialog() == DialogResult.OK)
                {
                    UserId = fuser.UserId;
                    linkuser.Text = String.Format("@{0}", fuser.Username);
                    if (txtLastName.Text == string.Empty && txtFirstName.Text == string.Empty && txtMidInitial.Text == string.Empty)
                    {
                        txtLastName.Text = fuser.lname;
                        txtFirstName.Text = fuser.fname;
                        txtMidInitial.Text = fuser.mname;
                    }
                }
            }

        }

        internal void LoadLink(int id)
        {
            try
            {
                var userRepository = Factory.UsersRepository();
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
    }
}
