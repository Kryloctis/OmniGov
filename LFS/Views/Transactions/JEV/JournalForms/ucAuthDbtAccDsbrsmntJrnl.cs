using ACC.Domain.Models;
using LFS.Helpers;
using System.Windows.Forms;

namespace LFS.Views.Transactions.JEV.JournalForms
{
    public partial class ucAuthDbtAccDsbrsmntJrnl : UserControl
    {
        public ucAuthDbtAccDsbrsmntJrnl()
        {
            InitializeComponent();
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
            return new ADADisbursementsJournalModel
            {
                ADANumber = txtAdaNo.Text.Trim(),
                DVNo = txtDvNo.Text.Trim(),
            };
        }
    }
}