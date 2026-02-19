using OmniGov.App.Helpers;
using OmniGov.Core.Factories;
using System;
using System.Windows.Forms;

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

        private bool SaveData()
        {
            if (!uc.ValidateChildren())
            {
                Helper.MessageBoxError(uc.GetFormErrors());
                return false;
            }

            return Factory.JournalsRepository().Insert(uc.JournalsModel());
        }

        private void frmJournalsAdd_Load(object sender, EventArgs e)
        {
            try
            {
                uc.OnLoad(false);
            }
            catch (Exception ex) { Helper.MessageBoxError(ex.Message); }
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

