using ACC.Data;
using ACC.Domain.Models;
using LFS.Helpers;
using System;
using System.Windows.Forms;

namespace LFS.Views.Transactions.ReceiptsIssued
{
    public partial class frmReceiptsIssuedAdd : Form
    {
        private readonly frmReceiptsIssued frmReceiptIssued;
        private readonly ucReceiptsIssued uc;

        public frmReceiptsIssuedAdd(frmReceiptsIssued frmReceiptsIssued)
        {
            InitializeComponent();
            Helper.LoadFormIcon(this);
            frmReceiptIssued = frmReceiptsIssued;
            uc = ucReceipts1;
        }

        private void frmReceiptsAdd_Load(object sender, EventArgs e)
        {
        }

        private bool SaveData()
        {
            if (!uc.ValidateChildren())
            {
                Helper.MessageBoxError(uc.GetFormErrors());
                return false;
            }

            int collectorId = Convert.ToInt32(uc.cmbCollector.SelectedValue);
            int receiptId = Convert.ToInt32(uc.cmbReceipt.SelectedValue);
            DateTime dateIssued = uc.dtpDateIssued.Value;
            int receiptNumberFrom = string.IsNullOrEmpty(uc.txtReceiptIssuedFrom.Text) ? 0 : Convert.ToInt32(uc.txtReceiptIssuedFrom.Text);
            int receiptNumberToTo = string.IsNullOrEmpty(uc.txtReceiptIssuedTo.Text) ? 0 : Convert.ToInt32(uc.txtReceiptIssuedTo.Text);
            int quantity = Convert.ToInt32(uc.txtReceiptQuantity.Text);
            int userId = UserHelper.loggedUser.Id;

            var receiptIssuedModel = new ReceiptsIssuedModel()
            {
                CollectorId = collectorId,
                ReceiptId = receiptId,
                IssuedDate = dateIssued,
                IssuedFrom = receiptNumberFrom,
                IssuedTo = receiptNumberToTo,
                Quantity = quantity,
                IssuedByUserId = userId
            };

            if (uc.isCollectorJO)
            {
                receiptIssuedModel.JobOrderId = collectorId;
                receiptIssuedModel.CollectorId = AccFactory.CollectingOfficerHasJobOrdersRepository().GetCollectingOfficerIDByJobOrderId(collectorId);
            }
            return AccFactory.ReceiptsIssuedRepository().Insert(receiptIssuedModel);
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                if (SaveData())
                {
                    Helper.MessageBoxSuccess("Receipt issued has been saved.");
                    frmReceiptIssued.LoadRecords();
                    uc.ResetForm();
                }
            }
            catch (Exception ex) { Helper.MessageBoxError(ex.Message); }
        }
    }
}