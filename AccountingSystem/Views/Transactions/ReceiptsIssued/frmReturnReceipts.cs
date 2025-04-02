using ACC.Data;
using ACC.Domain.Models;
using LFS;
using System;
using System.Windows.Forms;

namespace AccountingSystem.Views.Transactions.ReceiptsIssued
{
    public partial class frmReturnReceipts : Form
    {
        private readonly frmReceiptsIssued frmReceiptsIssued;
        private readonly int issuanceId;

        public frmReturnReceipts(frmReceiptsIssued frmReceiptsIssued, int issuanceId, int returnSerialNumberFrom, int returnSerialNumberTo)
        {
            InitializeComponent();
            this.frmReceiptsIssued = frmReceiptsIssued;

            this.issuanceId = issuanceId;
            txtReceiptNumberFrom.Text = returnSerialNumberFrom.ToString("D8");
            txtReceiptNumberTo.Text = returnSerialNumberTo.ToString("D8");
        }

        private bool SaveData()
        {
            var receiptIssuedRepository = AccFactory.ReceiptsIssuedRepository();
            var riModel = new ReceiptsIssuedModel()
            {
                Id = issuanceId,
                Is_returned = 1,
                Returned_date = dtpreturn.Value
            };

            return receiptIssuedRepository.UpdateReturnedReceipt(riModel);
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                if (SaveData())
                {
                    Helper.MessageBoxSuccess("Receipt successfully returned.");
                    frmReceiptsIssued.LoadRecords();
                    Close();
                }
            }
            catch (Exception ex) { Helper.MessageBoxError(ex.Message); }
        }
    }
}