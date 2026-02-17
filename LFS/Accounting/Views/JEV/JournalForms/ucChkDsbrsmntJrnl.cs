using Accounting.Data;
using Accounting.Domain.Entities;
using LFS.Helpers;
using System;
using System.Windows.Forms;

namespace LFS.Views.Transactions.JEV.JournalForms
{
    public partial class ucChkDsbrsmntJrnl : UserControl
    {
        private bool isEdit;
        private int? jevId;

        public ucChkDsbrsmntJrnl()
        {
            InitializeComponent();
        }

        internal void OnLoad(bool isEdit, int? jevId)
        {
            this.isEdit = isEdit;

            if (isEdit)
            {
                this.jevId = jevId;
                LoadChkDsbrsmntsDataIfExist(jevId.Value);
            }

            dtChkDate.Value = Helper.GetCurrentDate();
        }

        private void LoadChkDsbrsmntsDataIfExist(int jevId)
        {
            var chkDsbrsmntsDict = AccountingFactory.CheckDisbursementsJournalRepository().GetRecordByJevID(jevId);

            if (chkDsbrsmntsDict is not null && chkDsbrsmntsDict.Count > 0)
            {
                dtChkDate.Value = Convert.ToDateTime(chkDsbrsmntsDict["check_date"]);
                txtChkNo.Text = chkDsbrsmntsDict["check_no"];
                txtDvNo.Text = chkDsbrsmntsDict["dv_no"];
                txtRciNo.Text = chkDsbrsmntsDict["rci_no"];
            }
        }

        internal void ResetForm()
        {
            if (isEdit)
            {
                jevId = null;
            }

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

            if (isEdit) model.JevId = jevId.Value;

            return model;
        }
    }
}
