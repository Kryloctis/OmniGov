using ACC.Domain.Models;
using System;
using System.Windows.Forms;

namespace AccountingSystem.Views.Transactions.ReceiptsIssued
{
    public partial class frmReceiptsIssuedAdd : Form
    {
        private readonly frmReceiptsIssued _frmReceiptIssued;
        private readonly ucReceiptsIssued uc;

        public frmReceiptsIssuedAdd(frmReceiptsIssued frmReceiptsIssued)
        {
            InitializeComponent();

            _frmReceiptIssued = frmReceiptsIssued;
            uc = ucReceipts1;
        }

        private void frmReceiptsAdd_Load(object sender, EventArgs e)
        {
            try
            {
                uc.LoadCollectors();
            }
            catch (Exception ex) { Helper.MessageBoxError(ex.Message); }
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
            int userId = Helper.UserId;

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

            var receiptIssuedRepository = AccFactory.ReceiptsIssuedRepository();
            return receiptIssuedRepository.Insert(receiptIssuedModel);
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                if (SaveData())
                {
                    Helper.MessageBoxSuccess("Receipt issued has been saved.");
                    _frmReceiptIssued.bgwLoadIssuedReceipts.RunWorkerAsync();
                    uc.ResetForm();
                }

            }
            catch (Exception ex)
            {
                Helper.MessageBoxError(ex.Message);
            }
        }

    }
}