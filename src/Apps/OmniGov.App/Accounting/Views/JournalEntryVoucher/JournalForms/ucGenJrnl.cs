using Accounting.Data.Factories;
using Accounting.Domain.Entities;

namespace OmniGov.App.Accounting.Views.JournalEntryVoucher.JournalForms
{
    public partial class ucGenJrnl : UserControl
    {
        private bool isEdit;
        private int? jevId;

        public ucGenJrnl()
        {
            InitializeComponent();
        }

        internal void OnLoad(bool isEdit, int? jevId)
        {
            this.isEdit = isEdit;

            if (isEdit)
            {
                this.jevId = jevId;
                LoadGenJrnlData(jevId.Value);
            }
        }

        private void LoadGenJrnlData(int jevId)
        {
            var generalJournalDict = AccountingFactory.GeneralJournalRepository().GetViewRecordByJevID(jevId);

            if (generalJournalDict is not null && generalJournalDict.Count > 0)
            {
                txtChckNo.Text = generalJournalDict["check_no"];
                txtDvNo.Text = generalJournalDict["dv_no"];
                txtOrNo.Text = generalJournalDict["or_no"];
            }
        }

        internal void ResetForm()
        {
            if (isEdit)
            {
                jevId = null;
            }

            txtOrNo.Clear();
            txtChckNo.Clear();
            txtDvNo.Clear();
        }

        internal GeneralJournalModel GeneralJournalModel()
        {
            var model = new GeneralJournalModel()
            {
                CheckNo = txtChckNo.Text.Trim(),
                DVNo = txtDvNo.Text.Trim(),
                ORNo = txtOrNo.Text.Trim(),
            };

            if (isEdit) model.JevId = jevId.Value;
            return model;
        }
    }
}
