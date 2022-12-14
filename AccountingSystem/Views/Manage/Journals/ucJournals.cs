using ACC.Domain.Interfaces;
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

        private void UserVerification()
        {
            var dictLoggedInUser = Helper.LoggedInUserData();
            if (dictLoggedInUser["role_name"] != "System Administrator")
                txtName.Enabled = false;
        }

        internal string GetFormErrors()
        {
            var errorArray = new string[1];
            errorArray[0] = epName.GetError(txtName);

            IError _errors = AccFactory.CreateErrors(errorArray);
            return _errors.GenerateErrorMessage();
        }

        internal void ResetForm()
        {
            txtName.Clear();
            chkSpecialJournal.Checked = false;
        }

        private void txtName_Validating(object sender, CancelEventArgs e)
        {
            e.Cancel = Helper.ShowErrorTextBoxEmpty(epName, txtName, "journal name");

            var journalsRepository = AccFactory.JournalsRepository();
            string journalName = txtName.Text.Trim();
            bool journalNameExist;

            if (journalId == 0)
                journalNameExist = journalsRepository.NameExist(journalName); // add form
            else
                journalNameExist = journalsRepository.NameExist(journalName, journalId); // edit form

            if (journalNameExist)
            {
                epName.SetError(txtName, "Journal name already exist in your records.");
                e.Cancel = true;
            }
        }

        private void txtName_Validated(object sender, EventArgs e)
        {
            Helper.ClearErrorTextBox(epName, txtName);
        }

        private void ucJournals_Load(object sender, EventArgs e)
        {
            if (!DesignMode)
            {
                UserVerification();
            }
        }
    }
}