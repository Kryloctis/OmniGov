using ACC.Domain.Models;
using System;
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
                uc.LoadCollectors();
                LoadSelectedValue();
                uc.ReceiptsIssuedStatus();
            }
            catch (Exception ex) { Helper.MessageBoxError(ex.Message); }
        }

        internal void LoadSelectedValue()
        {
            try
            {
                var receiptIssuedDict = AccFactory.ReceiptsIssuedRepository().GetRecordByID(_receiptIssuedID);

                uc.cmbCollector.SelectedValue = receiptIssuedDict["collecting_officers_id"];
                uc.cmbReceipt.SelectedValue = receiptIssuedDict["receipts_id"];
                uc.dtpDateIssued.Value = Convert.ToDateTime(receiptIssuedDict["date_issued"]);
                uc.txtReceiptIssuedFrom.Text = receiptIssuedDict["receipt_issued_from"];
                uc.txtReceiptIssuedTo.Text = receiptIssuedDict["receipt_issued_to"];
                uc.txtReceiptQuantity.Text = receiptIssuedDict["quantity"];
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

                var receiptIssuedRepository = AccFactory.ReceiptsIssuedRepository();
                var receiptIssuedModel = new ReceiptsIssuedModel()
                {
                    Id = _receiptIssuedID,
                    CollectorId = Convert.ToInt32(uc.cmbCollector.SelectedValue),
                    ReceiptId = Convert.ToInt32(uc.cmbReceipt.SelectedValue),
                    Issued = uc.dtpDateIssued.Value,
                    IssuedFrom = Convert.ToInt32(uc.txtReceiptIssuedFrom.Text.Trim()),
                    IssuedTo = Convert.ToInt32(uc.txtReceiptIssuedTo.Text.Trim()),
                    Quantity = Convert.ToInt32(uc.txtReceiptQuantity.Text.Trim())
                };


                return receiptIssuedRepository.Update(receiptIssuedModel);

            }
            catch (Exception ex) { Helper.MessageBoxError(ex.Message); }
            return false;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (SaveData())
            {
                Helper.MessageBoxSuccess("Receipt Issued has been updated.");
                Close();
                _frmReceiptsIssued.LoadRecords();
            }
        }
    }
}