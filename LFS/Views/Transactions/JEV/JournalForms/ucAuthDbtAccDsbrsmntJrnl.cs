using ACC.Data;
using ACC.Domain.Models;
using System.Windows.Forms;

namespace LFS.Views.Transactions.JEV.JournalForms
{
    public partial class ucAuthDbtAccDsbrsmntJrnl : UserControl
    {
        private bool isEdit;
        private int? jevId;

        public ucAuthDbtAccDsbrsmntJrnl()
        {
            InitializeComponent();
        }

        private void OnLoad(bool isEdit, int? jevId)
        {
            this.isEdit = isEdit;
            if (isEdit)
            {
                this.jevId = jevId;
                LoadADADisbursementDataIfExist(jevId.Value);
            }
        }

        private void LoadADADisbursementDataIfExist(int jevId)
        {
            if (AccFactory.ADADisbursementsJournalRepository().JevIdExist(jevId))
            {
                var adaDisbursementsDict = AccFactory.ADADisbursementsJournalRepository().GetViewRecordByJevID(jevId);

                if (adaDisbursementsDict is not null && adaDisbursementsDict.Count > 0)
                {
                    txtDvNo.Text = adaDisbursementsDict["dv_no"];
                    txtAdaNo.Text = adaDisbursementsDict["ada_no"];
                }
            }
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