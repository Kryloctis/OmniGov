using ACC.Data;
using ACC.Domain.Models;
using System;
using System.Windows.Forms;

namespace AccountingSystem.Views.Manage.Journals
{
    public partial class frmJournalsAdd : Form
    {
        private frmJournals frmJournals;
        private ucJournals uc;

        public frmJournalsAdd(frmJournals frmJournals)
        {
            InitializeComponent();
            Helper.LoadFormIcon(this);
            this.frmJournals = frmJournals;
        }

        private bool SaveData()
        {
            if (!uc.ValidateChildren())
            {
                Helper.MessageBoxError(uc.GetFormErrors());
                return false;
            }

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
            try
            {
                if (SaveData())
                {
                    Helper.MessageBoxSuccess("Journal has been saved.");
                    frmJournals.LoadRecords();
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
            try
            {
                if (e.Modifiers == Keys.Control && e.KeyCode == Keys.S)
                {
                    if (SaveData())
                    {
                        Helper.MessageBoxSuccess("Journal has been saved.");
                        frmJournals.LoadRecords();
                        ucJournals1.ResetForm();
                    }
                }
            }
            catch (Exception ex) { Helper.MessageBoxError(ex.Message); }
        }
    }
}