using ACC.Data;
using ACC.Domain.Models;
using System;
using System.Windows.Forms;

namespace AccountingSystem.Views.Manage.Journals
{
    public partial class frmJournalsEdit : Form
    {
        private frmJournals frmJournals;
        private ucJournals uc;

        public frmJournalsEdit(frmJournals frmJournals, int journalId)
        {
            InitializeComponent();
            Helper.LoadFormIcon(this);

            this.frmJournals = frmJournals;
            uc = ucJournals1;
            uc.journalId = journalId;
        }

        private void LoadSelectedRecord()
        {
            var journalData = AccFactory.JournalsRepository().GetRecordByID(uc.journalId);

            uc.txtName.Text = journalData["journal_name"];
            uc.chkSpecialJournal.Checked = journalData["is_special"] == "0" ? false : true;
        }

        private bool UpdateData()
        {
            if (!uc.ValidateChildren())
            {
                Helper.MessageBoxError(uc.GetFormErrors());
                return false;
            }

            return AccFactory.JournalsRepository().Update(uc.JournalsModel());
        }

        private void frmJournalsEdit_Load(object sender, EventArgs e)
        {
            try
            {
                LoadSelectedRecord();
            }
            catch (Exception ex) { Helper.MessageBoxError(ex.Message); }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                if (UpdateData())
                {
                    Helper.MessageBoxSuccess("Journal has been saved.");
                    frmJournals.LoadRecords();
                }
            }
            catch (Exception ex) { Helper.MessageBoxError(ex.Message); }
        }

        private void frmJournalsEdit_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Modifiers == Keys.Control && e.KeyCode == Keys.S)
            {
                if (UpdateData())
                {
                    Helper.MessageBoxSuccess("Journal has been saved.");
                    frmJournals.LoadRecords();
                }
            }
        }
    }
}