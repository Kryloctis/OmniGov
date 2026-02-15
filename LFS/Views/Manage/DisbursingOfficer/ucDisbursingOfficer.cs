using LFS.Helpers;
using LFS.Views.Manage.LinkUser;
using OmniGov.Core.Repositories;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Windows.Forms;

namespace LFS.Views.Manage.DisbursingOfficer
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

            return Factory.CreateErrors(errorArray).GenerateErrorMessage();
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
            try
            {
                if (UserId > 0)
                {
                    UserId = 0;
                }
                else
                {
                    frmLinkUser fuser = new frmLinkUser();
                    fuser.userType = "disburser";
                    if (fuser.ShowDialog() == DialogResult.OK)
                    {
                        UserId = fuser.UserId;
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
            catch (Exception ex) { Helper.MessageBoxError(ex.Message); }
        }

        internal void LoadLink(int id)
        {
            var data = Factory.UsersRepository().GetViewRecordById(id);
            if (data.Count > 0)
            {
                UserId = id;
            }
            else
            {
                UserId = 0;
            }
        }

        private void chckLinkAcc_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                if (!chckLinkAcc.Checked)
                {
                    chckLinkAcc.Image = Properties.Resources.link_14px;
                    cmbxLinkedAcc.Enabled = false;
                    cmbxLinkedAcc.SelectedIndex = -1;
                    cmbxLinkedAcc.Text = string.Empty;
                    errorProvider1.SetError(chckLinkAcc, string.Empty);
                    ResetForm();
                }
                else
                {
                    chckLinkAcc.Image = Properties.Resources.link_cancel_2_14px;
                    cmbxLinkedAcc.Enabled = true;
                }
            }
            catch (Exception ex) { Helper.MessageBoxError(ex.Message); }
        }

        private void ucDisbursingOfficer_Load(object sender, EventArgs e)
        {
            try
            {
                OnLoad();
            }
            catch (Exception ex) { Helper.MessageBoxError(ex.Message); }
        }

        private void OnLoad()
        {
            if (!DesignMode)
            {
                LoadUsers();
            }
        }

        private void LoadUsers(bool isSearch = false)
        {
            string searchKey = cmbxLinkedAcc.Text.Trim();
            var dtUsers = Factory.UsersRepository().GetViewRecords();
            HelperLoadRecords.UsersComboBox(dtUsers, cmbxLinkedAcc, "id", "first_name");

            var searchSources = new List<string>
            {
                "first_name",
                "last_name",
                "role_name"
            };

            HelperLoadRecords.SearchableComboboxParameters(cmbxLinkedAcc, dtUsers, "id", "first_name", searchSources, searchKey, isSearch);
        }

        private void cmbxLinkedAcc_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter && ActiveControl == cmbxLinkedAcc)
                {
                    LoadUsers(true);
                    e.Handled = true;
                    e.SuppressKeyPress = true;
                }

                if (e.KeyData == (Keys.Control | Keys.V))
                    LoadUsers(true);
            }
            catch (Exception ex) { Helper.MessageBoxError(ex.Message); }
        }

        private void cmbxLinkedAcc_SelectionChangeCommitted(object sender, EventArgs e)
        {
            LoadUserDetails();
        }

        private void LoadUserDetails()
        {
            int userId = Convert.ToInt32(cmbxLinkedAcc.SelectedValue);
            var dtUser = Factory.UsersRepository().GetViewRecordById(userId);

            txtPrefix.Text = dtUser["prefix"];
            txtFirstName.Text = dtUser["first_name"];
            txtLastName.Text = dtUser["last_name"];
            txtMidInitial.Text = dtUser["mid_initial"];
            txtSuffix.Text = dtUser["suffix"];
            txtJobTitle.Text = dtUser["role_name"];
        }
    }
}