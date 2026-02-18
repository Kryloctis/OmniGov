using OmniGov.App.Helpers;
using OmniGov.Core.Factories;
using System;
using System.Windows.Forms;

namespace OmniGov.App.Views.Manage.Journals
{
    public partial class frmJournalsEdit : Form
    {
        private frmJournals frmJournals;
        private ucJournals uc;
        private readonly int journalId;

        public frmJournalsEdit(frmJournals frmJournals, int journalId)
        {
            InitializeComponent();
            Helper.LoadFormIcon(this);

            uc = ucJournals1;
            this.frmJournals = frmJournals;
            this.journalId = journalId;
        }

        private void LoadSelectedRecord()
        {
            var journalData = Factory.JournalsRepository().GetRecordByID(journalId);

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

            var model = uc.JournalsModel();
            model.Id = journalId;
            return Factory.JournalsRepository().Update(model);
        }

        private void frmJournalsEdit_Load(object sender, EventArgs e)
        {
            try
            {
                uc.OnLoad(true, journalId);
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
                    Helper.MessageBoxSuccess("Journal has been updated.");
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

