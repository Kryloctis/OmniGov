using ACC.Domain.Models;
using LFS.Helpers;
using System.Windows.Forms;

namespace LFS.Views.Transactions.JEV.JournalForms
{
    public partial class ucAuthDbtAccDsbrsmntJrnl : UserControl
    {
        private bool isEdit;
        private int? jevId;

        public ucAuthDbtAccDsbrsmntJrnl(bool isEdit, int? jevId)
        {
            InitializeComponent();
            this.isEdit = isEdit;
            this.jevId = jevId;
        }

        private void OnLoad()
        {
        }

        internal void ResetForm()
        {
            txtAdaNo.Clear();
            txtDvNo.Clear();
        }

        internal ADADisbursementsJournalModel ADADisbursementsJournalModel()
        {
            var model = new ADADisbursementsJournalModel
            {
                ADANumber = txtAdaNo.Text.Trim(),
                DVNo = txtDvNo.Text.Trim(),
            };

            if (isEdit) model.JevId = jevId.Value;
            return model;
        }
    }
}