using ACC.Domain.Models;
using System;
using System.Windows.Forms;

namespace AccountingSystem.Views.Transactions.ReceiptsIssued
{
    public partial class frmReceiptsIssuedAdd : Form
    {
        private readonly frmReceiptsIssued _frmReceiptIssued;
        private readonly int _receiptId = 0;
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
                if (_receiptId != 0)
                {
                    uc.isUpdate = false;
                    uc.LoadCollectorsWithReceiptIssued(_receiptId);
                    uc.cmbReceipt.SelectedValue = _receiptId;
                    uc.cmbReceipt.Enabled = false;
                }
                else
                    uc.LoadCollectors();
            }
            catch (Exception ex) { Helper.MessageBoxError(ex.Message); }
        }

        private bool SaveData()
        {
            try
            {
                if (!uc.ValidateChildren())
                {
                    Helper.MessageBoxError(uc.GetFormErrors());
                    return false;
                }

                var collectorId = Convert.ToInt32(uc.cmbCollector.SelectedValue);
                var receiptId = Convert.ToInt32(uc.cmbReceipt.SelectedValue);
                var dateIssued = uc.dtpDateIssued.Value;
                var issueFrom = string.IsNullOrEmpty(uc.txtReceiptIssuedFrom.Text) ? 0 : Convert.ToInt32(uc.txtReceiptIssuedFrom.Text.Trim());
                var issueTo = string.IsNullOrEmpty(uc.txtReceiptIssuedTo.Text) ? 0 : Convert.ToInt32(uc.txtReceiptIssuedTo.Text.Trim());
                var quantity = Convert.ToInt32(uc.txtReceiptQuantity.Text.Trim());
                var userId = Helper.UserId;

                var receiptIssuedModel = new ReceiptsIssuedModel()
                {
                    CollectorId = collectorId,
                    ReceiptId = receiptId,
                    Issued = dateIssued,
                    IssuedFrom = issueFrom,
                    IssuedTo = issueTo,
                    Quantity = quantity,
                    IssuedByUserId = userId
                };

                if (uc.isCollectorJO == true)
                {
                    receiptIssuedModel.JobOrderId = collectorId;
                    receiptIssuedModel.CollectorId = AccFactory.CollectingOfficerHasJobOrdersRepository().GetCollectingOfficerIDByJobOrderId(collectorId);
                }

                var receiptIssuedRepository = AccFactory.ReceiptsIssuedRepository();
                return receiptIssuedRepository.Insert(receiptIssuedModel);
            }
            catch (Exception ex) { Helper.MessageBoxError(ex.Message); }
            return false;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (SaveData())
            {
                Helper.MessageBoxSuccess("Receipt Issued has been saved.");
                uc.ResetForm();
                _frmReceiptIssued.LoadRecords();
            }
        }

        private void frmReceiptsIssuedAdd_FormClosing(object sender, FormClosingEventArgs e)
        {
            _frmReceiptIssued.LoadRecords();
        }
    }
}