using ACC.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
            var errorArray = new string[1];
            errorArray[0] = epName.GetError(txtName);

            IError _errors = Factory.CreateErrors(errorArray);
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

            var journalsRepository = Factory.JournalsRepository();
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
    }
}
