using ACC.Data;
using ACC.Domain.Models;
using System;
using System.Windows.Forms;

namespace AccountingSystem.Views.Manage.Journals
{
    public partial class frmJournalsAdd : Form
    {
        private frmJournals _frmJournals;

        public frmJournalsAdd(frmJournals frmJournals)
        {
            InitializeComponent();
            Helper.LoadFormIcon(this);
            _frmJournals = frmJournals;
        }

        private bool SaveData()
        {
            var uc = ucJournals1;
            // if error occurs, show messagebox error
            if (!uc.ValidateChildren())
            {
                Helper.MessageBoxError(uc.GetFormErrors());
                return false;
            }

            // proceed to insert
            var journalModel = new JournalsModel()
            {
                JournalName = uc.txtName.Text.Trim(),
                IsSpecialJournal = uc.chkSpecialJournal.Checked
            };

            return AccFactory.JournalsRepository().Insert(journalModel);
        }

        private void frmJournalsAdd_Load(object sender, EventArgs e)
        {
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            Save();
        }

        private void Save()
        {
            try
            {
                if (SaveData())
                {
                    Helper.MessageBoxSuccess("Journal has been saved.");
                    _frmJournals.LoadRecords();
                    ucJournals1.ResetForm();
                }
            }
            catch (Exception ex) { Helper.MessageBoxError(ex.Message); }
        }

        private void ucJournals1_Load(object sender, EventArgs e)
        {

        }

        private void frmJournalsAdd_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Modifiers == Keys.Control && e.KeyCode == Keys.S)
            {
                Save();
            }
        }
    }
}