using OmniGov.App.Helpers;

using OmniGov.Core.Factories;

namespace OmniGov.App.Views.Manage.Journals

{
    public partial class frmJournalsAdd : Form

    {
        private frmJournals frmJournals;

        private ucJournals uc;

        public frmJournalsAdd(frmJournals frmJournals)

        {
            InitializeComponent();

            Helper.LoadFormIcon(this);

            uc = ucJournals1;

            this.frmJournals = frmJournals;
        }

        private void btnSave_Click(object sender, EventArgs e)

        {
            if (SaveData())
            {
                Helper.MessageBoxSuccess("Journal has been saved.");
                frmJournals.LoadRecords();
                ucJournals1.ResetForm();
            }
        }

        private void frmJournalsAdd_KeyDown(object sender, KeyEventArgs e)

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

        private void frmJournalsAdd_Load(object sender, EventArgs e)

        {
            uc.OnLoad(false);
        }

        private bool SaveData()

        {
            if (!uc.ValidateChildren())

            {
                Helper.MessageBoxError(uc.GetFormErrors());

                return false;
            }

            return Factory.JournalsRepository().Insert(uc.JournalsModel());
        }
    }
}