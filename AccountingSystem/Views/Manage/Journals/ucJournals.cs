using ACC.Data;
using System;
using System.ComponentModel;
using System.Windows.Forms;

namespace AccountingSystem.Views.Manage.Journals
{
    public partial class ucJournals : UserControl
    {
        internal int journalId = 0;

        public ucJournals()
        {
            InitializeComponent();
        }

        internal string GetFormErrors()
        {
            var errorArray = new string[]
            {
                 epName.GetError(txtName)
            };

            return AccFactory.CreateErrors(errorArray).GenerateErrorMessage();
        }

        internal void ResetForm()
        {
            txtName.Clear();
            chkSpecialJournal.Checked = false;
        }

        private void OnLoad()
        {
            if (!DesignMode)
            {
                UserVerification();
            }
        }

        private void txtName_Validated(object sender, EventArgs e)
        {
            Helper.ClearErrorTextBox(epName, txtName);
        }

        private void txtName_Validating(object sender, CancelEventArgs e)
        {
            try
            {
                e.Cancel = Helper.ShowErrorTextBoxEmpty(epName, txtName, "journal name");

                string journalName = txtName.Text.Trim();
                bool journalNameExist;

                if (journalId == 0)
                    journalNameExist = AccFactory.JournalsRepository().NameExist(journalName); // add form
                else
                    journalNameExist = AccFactory.JournalsRepository().NameExist(journalName, journalId); // edit form

                if (journalNameExist)
                {
                    epName.SetError(txtName, "Journal name already exist in your records.");
                    e.Cancel = true;
                }
            }
            catch (Exception ex) { Helper.MessageBoxError(ex.Message); }
        }

        private void ucJournals_Load(object sender, EventArgs e)
        {
            try
            {
                OnLoad();
            }
            catch (Exception ex) { Helper.MessageBoxError(ex.Message); }
        }

        private void UserVerification()
        {
            var dictLoggedInUser = Helper.LoggedInUserData();
            if (dictLoggedInUser["role_name"] != "System Administrator")
                txtName.Enabled = false;
        }

        private void chkSpecialJournal_CheckedChanged(object sender, EventArgs e)
        {

        }
    }
}