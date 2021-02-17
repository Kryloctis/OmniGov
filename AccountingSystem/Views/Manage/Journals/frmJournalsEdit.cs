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
    public partial class frmJournalsEdit : Form
    {
        private frmJournals _frmJournals;

        public frmJournalsEdit(frmJournals frmJournals, int journalId)
        {
            InitializeComponent();
            _frmJournals = frmJournals;
            ucJournals1.journalId = journalId;
        }

        private void LoadSelectedRecord()
        {
            try
            {
                var uc = ucJournals1;
                var journalsRepository = Factory.JournalsRepository();
                var journalData = journalsRepository.GetRecordByID(uc.journalId);

                uc.txtName.Text = journalData["journal_name"];
                uc.chkSpecialJournal.Checked = journalData["is_special"] == "0" ? false : true;
            }
            catch (Exception ex)
            {

                Helper.MessageBoxError(ex.Message);
            }
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

                // proceed to update
                var journalModel = new JournalsModel()
                {
                    Id = uc.journalId,
                    JournalName = uc.txtName.Text.Trim(),
                    IsSpecialJournal = uc.chkSpecialJournal.Checked
                };

                var journalsRepository = Factory.JournalsRepository();
                return journalsRepository.Update(journalModel);
            }
            catch (Exception ex)
            {
                Helper.MessageBoxError(ex.Message);
            }

            return false;
        }

        private void frmJournalsEdit_Load(object sender, EventArgs e)
        {
            Helper.LoadFormIcon(this);
            LoadSelectedRecord();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (SaveData())
            {
                Helper.MessageBoxSuccess("Journal has been saved.");
                _frmJournals.LoadRecords();
            }
        }
    }
}
