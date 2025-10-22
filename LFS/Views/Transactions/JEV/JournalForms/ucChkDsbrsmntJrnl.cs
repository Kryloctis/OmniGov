using ACC.Domain.Models;
using LFS.Helpers;
using System.Windows.Forms;

namespace LFS.Views.Transactions.JEV.JournalForms
{
    public partial class ucChkDsbrsmntJrnl : UserControl
    {
        private bool isEdit;
        private int jevId;

        public ucChkDsbrsmntJrnl(bool isEdit, int jevId)
        {
            InitializeComponent();
            this.isEdit = isEdit;
            this.jevId = jevId;
        }

        internal void OnLoad()
        {
            dtChkDate.Value = Helper.GetCurrentDate();
        }

        internal void ResetFields()
        {
            txtChkNo.Clear();
            dtChkDate.Value = Helper.GetCurrentDate();
            txtRciNo.Clear();
            txtDvNo.Clear();
        }

        internal CheckDisbursementsJournalModel CheckDisbursementsJournalModel()
        {
            var model = new CheckDisbursementsJournalModel()
            {
                CheckNo = txtChkNo.Text.Trim(),
                CheckDate = dtChkDate.Value,
                RCINo = txtRciNo.Text.Trim(),
                DVNo = txtDvNo.Text.Trim(),
            };

            if (isEdit) model.JevId = jevId;

            return model;
        }
    }
}