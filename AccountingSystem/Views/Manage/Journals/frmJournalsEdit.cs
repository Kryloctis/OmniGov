using ACC.Data;
using ACC.Domain.Models;
using AccountingSystem.Views.Manage.JobOrders;
using System;
using System.Windows.Forms;

namespace AccountingSystem.Views.Manage.Journals
{
    public partial class frmJournalsEdit : Form
    {
        private frmJournals _frmJournals;
        private ucJournals uc;

        public frmJournalsEdit(frmJournals frmJournals, int journalId)
        {
            InitializeComponent();
            Helper.LoadFormIcon(this);

            _frmJournals = frmJournals;
            uc = ucJournals1;
            uc.journalId = journalId;
        }

        private void LoadSelectedRecord()
        {
            var journalData = AccFactory.JournalsRepository().GetRecordByID(uc.journalId);

            uc.txtName.Text = journalData["journal_name"];
            uc.chkSpecialJournal.Checked = journalData["is_special"] == "0" ? false : true;
        }

        private bool SaveData()
        {
            // if error occurs, show messagebox error
            if (!uc.ValidateChildren())
            {
                Helper.MessageBoxError(uc.GetFormErrors());
                return false;
            }

            // proceed to update
            var journalModel = new JournalsModel()
            {
                Id = uc.journalId,
                JournalName = uc.txtName.Text.Trim(),
                IsSpecialJournal = uc.chkSpecialJournal.Checked
            };

            return AccFactory.JournalsRepository().Update(journalModel);
        }

        private void frmJournalsEdit_Load(object sender, EventArgs e)
        {
            try
            {
                OnLoad();
            }
            catch (Exception ex) { Helper.MessageBoxError(ex.Message); }
        }

        private void OnLoad()
        {
            LoadSelectedRecord();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                if (SaveData())
                {
                    Helper.MessageBoxSuccess("Journal has been saved.");
                    _frmJournals.LoadRecords();
                }
            }
            catch (Exception ex) { Helper.MessageBoxError(ex.Message); }
        }
    }
}