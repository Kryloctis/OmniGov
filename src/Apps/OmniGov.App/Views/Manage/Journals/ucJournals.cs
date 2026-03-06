using OmniGov.App.Helpers;

using OmniGov.Core.Entities;

using OmniGov.Core.Factories;

using System.ComponentModel;

namespace OmniGov.App.Views.Manage.Journals

{
    public partial class ucJournals : UserControl

    {
        private bool isEdit;
        private int? journalId;

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

            return Factory.CreateErrors(errorArray).GenerateErrorMessage();
        }

        internal JournalsModel JournalsModel()

        {
            return new JournalsModel()

            {
                JournalName = txtName.Text.Trim(),

                IsSpecialJournal = chkSpecialJournal.Checked
            };
        }

        internal void OnLoad(bool isEdit, int? journalId = null)

        {
            if (!DesignMode)

            {
                this.isEdit = isEdit;

                this.journalId = journalId;
            }
        }

        internal void ResetForm()

        {
            txtName.Clear();

            chkSpecialJournal.Checked = false;
        }

        private bool JournalNameValidated()

        {
            string journalName = txtName.Text.Trim();

            bool journalNameExist;

            var isEmpty = Helper.ShowErrorTextBoxEmpty(epName, txtName, "journal name");

            if (isEmpty)

                return false;

            if (isEdit)

                journalNameExist = Factory.JournalsRepository().NameExist(journalName, journalId.Value);
            else

                journalNameExist = Factory.JournalsRepository().NameExist(journalName);

            if (journalNameExist)

            {
                epName.SetError(txtName, "Journal name is already in your records.");

                return false;
            }

            return true;
        }

        private void txtName_Validated(object sender, EventArgs e)

        {
            Helper.ClearErrorTextBox(epName, txtName);
        }

        private void txtName_Validating(object sender, CancelEventArgs e)

        {
            e.Cancel = !JournalNameValidated();
        }
    }
}