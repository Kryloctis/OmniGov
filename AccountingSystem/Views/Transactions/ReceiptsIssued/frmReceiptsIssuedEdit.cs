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

            if (!string.IsNullOrEmpty(jobOrderID))
                uc.cbCollectingOfficerTypeJO.Checked = true;


            uc.LoadReceipts();
            uc.ControlsConfiguration();

            uc.cmbCollector.SelectedValue = collector;
            uc.cmbReceipt.SelectedValue = receiptIssuedDict["receipts_id"];
            uc.dtpDateIssued.Value = Convert.ToDateTime(receiptIssuedDict["date_issued"]);
            uc.txtReceiptIssuedFrom.Text = receiptIssuedDict["receipt_issued_from"];
            uc.txtReceiptIssuedTo.Text = receiptIssuedDict["receipt_issued_to"];
            uc.txtReceiptQuantity.Text = receiptIssuedDict["quantity"];
        }

        private void frmReceiptsEdit_Load(object sender, EventArgs e)
        {
            try
            {
                LoadSelectedValue();
                uc.ReceiptsIssuedStatus();
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
            var receiptIssuedModel = new ReceiptsIssuedModel()
            {
                Id = _receiptIssuedID,
                CollectorId = Convert.ToInt32(uc.cmbCollector.SelectedValue),
                ReceiptId = Convert.ToInt32(uc.cmbReceipt.SelectedValue),
                IssuedDate = uc.dtpDateIssued.Value,
                IssuedFrom = Convert.ToInt32(uc.txtReceiptIssuedFrom.Text),
                IssuedTo = Convert.ToInt32(uc.txtReceiptIssuedTo.Text),
                Quantity = Convert.ToInt32(uc.txtReceiptQuantity.Text)
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