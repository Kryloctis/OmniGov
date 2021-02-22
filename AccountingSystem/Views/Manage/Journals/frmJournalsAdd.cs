using ACC.Domain.Models;
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
    public partial class frmJournalsAdd : Form
    {
        private frmJournals _frmJournals;

        public frmJournalsAdd(frmJournals frmJournals)
        {
            InitializeComponent();
            _frmJournals = frmJournals;
        }

        private bool SaveData()
        {
            try
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

                var journalsRepository = Factory.JournalsRepository();
                return journalsRepository.Insert(journalModel);
            }
            catch (Exception ex)
            {
                Helper.MessageBoxError(ex.Message);
            }

            return false;
        }

        private void frmJournalsAdd_Load(object sender, EventArgs e)
        {
            Helper.LoadFormIcon(this);
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (SaveData())
            {
                Helper.MessageBoxSuccess("Journal has been saved.");
                _frmJournals.LoadRecords();
                ucJournals1.ResetForm();
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {

        }
    }
}
