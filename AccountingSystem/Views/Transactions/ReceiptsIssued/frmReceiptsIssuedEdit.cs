using ACC.Domain.Models;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace AccountingSystem.Views.Transactions.ReceiptsIssued
{
    public partial class frmReceiptsIssuedEdit : Form
    {
        private frmReceiptsIssued _frmReceiptsIssued;
        private int _receiptIssuedID;
        private readonly ucReceiptsIssued uc;

        public frmReceiptsIssuedEdit(frmReceiptsIssued frmReceiptsIssued, int receiptIssuedID)
        {
            InitializeComponent();
            _frmReceiptsIssued = frmReceiptsIssued;
            _receiptIssuedID = receiptIssuedID;
            uc = ucReceipts1;
            uc.isUpdate = true;
        }

        internal void LoadSelectedValue()
        {
            Dictionary<string, string> receiptIssuedDict = AccFactory.ReceiptsIssuedRepository().GetRecordByID(_receiptIssuedID);
            uc.receiptId = Convert.ToInt32(receiptIssuedDict["receipts_id"]);

            string jobOrderID = receiptIssuedDict["job_orders_id"];
            var collectingOfficerID = Convert.ToInt32(receiptIssuedDict["collecting_officers_id"]);
            int collector = string.IsNullOrEmpty(jobOrderID) ? collectingOfficerID : Convert.ToInt32(jobOrderID);
            int receiptID = Convert.ToInt32(receiptIssuedDict["receipts_id"]);
            DateTime dateIssued = Convert.ToDateTime(receiptIssuedDict["date_issued"]);
            int receiptNumberFrom = Convert.ToInt32(receiptIssuedDict["receipt_issued_from"]);
            int receiptNumberTo = Convert.ToInt32(receiptIssuedDict["receipt_issued_to"]);
            int quantity = Convert.ToInt32(receiptIssuedDict["quantity"]);

            if (!string.IsNullOrEmpty(jobOrderID))
                uc.cbCollectingOfficerTypeJO.Checked = true;

            uc.cmbCollector.SelectedValue = collector;
            uc.cmbReceipt.SelectedValue = receiptID;
            uc.dtpDateIssued.Value = dateIssued;
            uc.txtReceiptIssuedFrom.Text = receiptNumberFrom == 0 ? string.Empty : receiptNumberFrom.ToString("D7");
            uc.txtReceiptIssuedTo.Text = receiptNumberTo == 0 ? string.Empty : receiptNumberTo.ToString("D7");
            uc.txtReceiptQuantity.Text = quantity.ToString();
        }

        internal void ReceiptsIssuedStatus()
        {
            bool isUsed = false;

            int receiptID = Convert.ToInt32(uc.cmbReceipt.SelectedValue);
            var receiptDict = AccFactory.ReceiptsRepository().GetRecordByID(receiptID);

            int accountableFormID = Convert.ToInt32(receiptDict["accountable_forms_id"]);
            int receiptNumberFrom = Convert.ToInt32(uc.txtReceiptIssuedFrom.Text);
            int receiptNumberTo = Convert.ToInt32(uc.txtReceiptIssuedTo.Text);

            while (receiptNumberFrom <= receiptNumberTo)
            {
                isUsed = AccFactory.PaymentCollectionsRepository().ReceiptAlreadyUsed(accountableFormID, receiptNumberFrom);

                receiptNumberFrom++;
                if (isUsed)
                    break;
            }

            uc.cmbReceipt.Enabled = !isUsed;
            uc.txtReceiptIssuedFrom.Enabled = !isUsed;
            uc.txtReceiptIssuedTo.Enabled = !isUsed;
        }

        private void frmReceiptsEdit_Load(object sender, EventArgs e)
        {
            try
            {
                LoadSelectedValue();
                ReceiptsIssuedStatus();
                uc.ControlsConfiguration();
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

            var receiptIssuedRepository = AccFactory.ReceiptsIssuedRepository();

            int collectorID = Convert.ToInt32(uc.cmbCollector.SelectedValue);
            int receiptID = Convert.ToInt32(uc.cmbReceipt.SelectedValue);
            var serialNumberFrom = Convert.ToInt32(string.IsNullOrEmpty(uc.txtReceiptIssuedFrom.Text) ? 0 : uc.txtReceiptIssuedFrom.Text);
            var serialNumberTo = Convert.ToInt32(string.IsNullOrEmpty(uc.txtReceiptIssuedTo.Text) ? 0 : uc.txtReceiptIssuedTo.Text);
            DateTime dateIssued = uc.dtpDateIssued.Value;
            int quantity = Convert.ToInt32(uc.txtReceiptQuantity.Text);

            var receiptIssuedModel = new ReceiptsIssuedModel()
            {
                Id = _receiptIssuedID,
                CollectorId = collectorID,
                ReceiptId = receiptID,
                IssuedDate = dateIssued,
                IssuedFrom = serialNumberFrom,
                IssuedTo = serialNumberTo,
                Quantity = quantity
            };

            return receiptIssuedRepository.Update(receiptIssuedModel);
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                if (SaveData())
                {
                    Helper.MessageBoxSuccess("Receipt Issued has been updated.");
                    _frmReceiptsIssued.bgwLoadIssuedReceipts.RunWorkerAsync();
                    Close();
                }
            }

            catch (Exception ex) { Helper.MessageBoxError(ex.Message); }
        }
    }
}