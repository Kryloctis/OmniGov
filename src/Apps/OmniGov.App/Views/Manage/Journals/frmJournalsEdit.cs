using OmniGov.App.Helpers;

using OmniGov.Core.Factories;

namespace OmniGov.App.Views.Manage.Journals

{
    public partial class frmJournalsEdit : Form

    {
        private readonly int journalId;
        private frmJournals frmJournals;

        private ucJournals uc;

        public frmJournalsEdit(frmJournals frmJournals, int journalId)

        {
            InitializeComponent();

            Helper.LoadFormIcon(this);

            uc = ucJournals1;

            this.frmJournals = frmJournals;

            this.journalId = journalId;
        }

        private void btnSave_Click(object sender, EventArgs e)

        {
            if (UpdateData())
            {
                Helper.MessageBoxSuccess("Journal has been updated.");
                frmJournals.LoadRecords();
            }
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

        private void frmJournalsEdit_Load(object sender, EventArgs e)

        {
            uc.OnLoad(true, journalId);
            LoadSelectedRecord();
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
    }
}