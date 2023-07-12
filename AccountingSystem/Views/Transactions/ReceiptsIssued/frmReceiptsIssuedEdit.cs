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
        }

        private void frmReceiptsEdit_Load(object sender, EventArgs e)
        {
            try
            {
                uc.isUpdate = true;
                LoadSelectedValue();
                uc.ReceiptsIssuedStatus();
                uc.ControlsConfiguration();
            }
            catch (Exception ex) { Helper.MessageBoxError(ex.Message); }
        }

        internal void LoadSelectedValue()
        {
            Dictionary<string, string> receiptIssuedDict = AccFactory.ReceiptsIssuedRepository().GetRecordByID(_receiptIssuedID);

            uc.cmbCollector.SelectedValue = receiptIssuedDict["collecting_officers_id"];
            uc.cmbReceipt.SelectedValue = receiptIssuedDict["receipts_id"];
            uc.dtpDateIssued.Value = Convert.ToDateTime(receiptIssuedDict["date_issued"]);
            uc.txtReceiptIssuedFrom.Text = receiptIssuedDict["receipt_issued_from"];
            uc.txtReceiptIssuedTo.Text = receiptIssuedDict["receipt_issued_to"];
            uc.txtReceiptQuantity.Text = receiptIssuedDict["quantity"];
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
                    _frmReceiptsIssued.LoadRecords();
                    Close();
                }
            }

            catch (Exception ex) { Helper.MessageBoxError(ex.Message); }
        }
    }
}