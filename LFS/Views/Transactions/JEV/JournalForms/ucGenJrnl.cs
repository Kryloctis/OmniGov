using ACC.Domain.Models;
using System.Windows.Forms;

namespace LFS.Views.Transactions.JEV
{
    public partial class ucGenJrnl : UserControl
    {
        private bool isEdit;
        private int? jevId;

        public ucGenJrnl(bool isEdit, int? jevId)
        {
            InitializeComponent();
            this.isEdit = isEdit;
            this.jevId = jevId;
        }

        internal void OnLoad()
        {
        }

        internal void ResetForm()
        {
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