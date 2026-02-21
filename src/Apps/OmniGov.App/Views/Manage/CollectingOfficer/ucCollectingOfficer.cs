using OmniGov.App.Helpers;
using OmniGov.Core.Factories;
using OmniGov.Treasury.Data.Factories;
using System.ComponentModel;

namespace OmniGov.App.Views.Manage.CollectingOfficer
{
    public partial class ucCollectingOfficer : UserControl
    {
        internal int Id;

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
                errorProvider1.GetError(txtJobtitle),
                errorProvider1.GetError(chckLinkAcc)
            };

            return Factory.CreateErrors(errorArray).GenerateErrorMessage();
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

        private void OnLoad()
        {
            if (!DesignMode)
            {
                LoadUsers();
            }
        }

        internal void ResetForm()
        {
            txtPrefix.Clear();
            txtFirstName.Clear();
            txtMiddleInitial.Clear();
            txtLastName.Clear();
            txtSuffix.Clear();
            txtJobtitle.Clear();
        }

        private void txtFname_Validated(object sender, EventArgs e)
        {
            Helper.ClearErrorTextBox(errorProvider1, txtFirstName);
        }

        private bool CollectorNameValidated(TextBox textBox, ErrorProvider errorProvider, string message)
        {
            string firstName = txtFirstName.Text.Trim();
            string midInitial = txtMiddleInitial.Text.Trim();
            string lastName = txtLastName.Text.Trim();

            if (Helper.ShowErrorTextBoxEmpty(errorProvider, textBox, message))
                return false;

            bool fullNameExist = TreasuryFactory.CollectingOfficerRepository().FullNameExist(firstName, midInitial, lastName, Id);
            if (fullNameExist)
            {
                errorProvider.SetError(textBox, "Name already exist.");
                return false;
            }
            return true;
        }

        private void txtFname_Validating(object sender, CancelEventArgs e)
        {
            e.Cancel = !CollectorNameValidated(txtFirstName, errorProvider1, "first name");
        }

        private void txtLname_Validated(object sender, EventArgs e)
        {
            Helper.ClearErrorTextBox(errorProvider1, txtLastName);
        }

        private void txtLname_Validating(object sender, CancelEventArgs e)
        {
            e.Cancel = !CollectorNameValidated(txtLastName, errorProvider1, "last name");
        }

        private void txtMI_Validated(object sender, EventArgs e)
        {
            Helper.ClearErrorTextBox(errorProvider1, txtMiddleInitial);
        }

        private void txtMI_Validating(object sender, CancelEventArgs e)
        {
            e.Cancel = !CollectorNameValidated(txtMiddleInitial, errorProvider1, "middle initial");
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

        private void ucCollectingOfficer_Load(object sender, EventArgs e)
        {
            try
            {
                OnLoad();
            }
            catch (Exception ex) { Helper.MessageBoxError(ex.Message); }
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

        internal void LoadSelectedRecord()
        {
            var dictCollectingOfficer = TreasuryFactory.CollectingOfficerRepository().GetRecordByID(Id);

            txtPrefix.Text = dictCollectingOfficer["prefix"];
            txtFirstName.Text = dictCollectingOfficer["first_name"];
            txtMiddleInitial.Text = dictCollectingOfficer["mid_initial"];
            txtLastName.Text = dictCollectingOfficer["last_name"];
            txtSuffix.Text = dictCollectingOfficer["suffix"];
            txtJobtitle.Text = dictCollectingOfficer["job_title"];
            var linkedUserId = dictCollectingOfficer["users_id"];

            if (string.IsNullOrWhiteSpace(linkedUserId))
                chckLinkAcc.Checked = false;
            else
            {
                chckLinkAcc.Checked = true;
                cmbxLinkedAcc.SelectedValue = linkedUserId;
            }
        }

        private bool LinkedUserValidated(ErrorProvider errorProvider, string message, Control source)
        {
            var linkedUserId = cmbxLinkedAcc.SelectedValue;

            if (string.IsNullOrWhiteSpace(cmbxLinkedAcc.Text.Trim()) || linkedUserId == null)
            {
                errorProvider.SetError(source, message);
                return false;
            }
            else if (!Factory.UsersRepository().IdExist(Convert.ToInt32(linkedUserId)))
            {
                errorProvider.SetError(source, message);
                return false;
            }

            return true;
        }

        private void cmbxLinkedAcc_Validating(object sender, CancelEventArgs e)
        {
            try
            {
                if (chckLinkAcc.Checked)
                    e.Cancel = !LinkedUserValidated(errorProvider1, "Invalid linked user", chckLinkAcc);
            }
            catch (Exception ex) { Helper.MessageBoxError(ex.Message); }
        }

        private void cmbxLinkedAcc_Validated(object sender, EventArgs e)
        {
            errorProvider1.SetError(chckLinkAcc, string.Empty);
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
            txtMiddleInitial.Text = dtUser["mid_initial"];
            txtSuffix.Text = dtUser["suffix"];
            txtJobtitle.Text = dtUser["role_name"];
        }
    }
}

