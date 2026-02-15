using LFS.Helpers;
using OmniGov.Core.Entities;
using OmniGov.Core.Repositories;
using System;
using System.ComponentModel;
using System.Windows.Forms;

namespace LFS.Views.Manage.Journals
{
    public partial class ucJournals : UserControl
    {
        private int? journalId;
        private bool isEdit;

        public ucJournals()
        {
            InitializeComponent();
        }

        internal JournalsModel JournalsModel()
        {
            return new JournalsModel()
            {
                JournalName = txtName.Text.Trim(),
                IsSpecialJournal = chkSpecialJournal.Checked
            };
        }

        internal string GetFormErrors()
        {
            var errorArray = new string[]
            {
                 epName.GetError(txtName)
            };

            return Factory.CreateErrors(errorArray).GenerateErrorMessage();
        }

        internal void ResetForm()
        {
            txtName.Clear();
            chkSpecialJournal.Checked = false;
        }

        internal void OnLoad(bool isEdit, int? journalId = null)
        {
            if (!DesignMode)
            {
                this.isEdit = isEdit;
                this.journalId = journalId;
            }
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

        private void txtName_Validating(object sender, CancelEventArgs e)
        {
            try
            {
                e.Cancel = !JournalNameValidated();
            }
            catch (Exception ex) { Helper.MessageBoxError(ex.Message); }
        }

        private void txtName_Validated(object sender, EventArgs e)
        {
            Helper.ClearErrorTextBox(epName, txtName);
        }
    }
}