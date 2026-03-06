using OmniGov.App.Helpers;
using OmniGov.Treasury.Data.Factories;
using OmniGov.Treasury.Domain.Entities;

namespace OmniGov.App.Views.Transactions.ReceiptsIssued
{
    public partial class frmReceiptsIssuedEdit : Form
    {
        private readonly ucReceiptsIssued uc;
        private frmReceiptsIssued frmReceiptsIssued;
        private int receiptIssuedID;

        public frmReceiptsIssuedEdit(frmReceiptsIssued frmReceiptsIssued, int receiptIssuedID)
        {
            InitializeComponent();
            Helper.LoadFormIcon(this);
            this.frmReceiptsIssued = frmReceiptsIssued;
            uc = ucReceipts1;
            this.receiptIssuedID = receiptIssuedID;
        }

        internal void CheckReceiptsIssuedStatus()
        {
            var receiptDict = TreasuryFactory.ReceiptsRepository().GetRecordByID(uc.selectedReceiptID);
            bool isUsed = false;

            int accountableFormID = Convert.ToInt32(receiptDict["accountable_forms_id"]);
            int receiptNumberFrom = Convert.ToInt32(uc.txtReceiptIssuedFrom.Text);
            int receiptNumberTo = Convert.ToInt32(uc.txtReceiptIssuedTo.Text);

            while (receiptNumberFrom <= receiptNumberTo)
            {
                isUsed = TreasuryFactory.PaymentCollectionsRepository().ReceiptAlreadyUsed(accountableFormID, receiptNumberFrom);
                receiptNumberFrom++;

                if (isUsed)
                    break;
            }

            uc.cmbReceipt.Enabled = !isUsed;
            uc.txtReceiptIssuedFrom.Enabled = !isUsed;
            uc.txtReceiptIssuedTo.Enabled = !isUsed;
        }

        internal void LoadSelectedValue()
        {
            Dictionary<string, string> receiptIssuedDict = TreasuryFactory.ReceiptsIssuedRepository().GetRecordByID(receiptIssuedID);

            string jobOrderID = receiptIssuedDict["job_orders_id"];
            var collectingOfficerID = Convert.ToInt32(receiptIssuedDict["collecting_officer_id"]);
            int collector = string.IsNullOrEmpty(jobOrderID) ? collectingOfficerID : Convert.ToInt32(jobOrderID);
            int receiptID = Convert.ToInt32(receiptIssuedDict["receipts_id"]);
            DateTime dateIssued = Convert.ToDateTime(receiptIssuedDict["date_issued"]);
            int receiptNumberFrom = Convert.ToInt32(receiptIssuedDict["receipt_issued_from"]);
            int receiptNumberTo = Convert.ToInt32(receiptIssuedDict["receipt_issued_to"]);
            int quantity = Convert.ToInt32(receiptIssuedDict["quantity"]);

            if (!string.IsNullOrEmpty(jobOrderID))
                uc.cbCollectingOfficerTypeJO.Checked = true;

            uc.selectedReceiptID = receiptID;
            uc.cmbCollector.SelectedValue = collector;
            uc.cmbReceipt.SelectedValue = receiptID;
            uc.dtpDateIssued.Value = dateIssued;
            uc.txtReceiptIssuedFrom.Text = receiptNumberFrom == 0 ? string.Empty : receiptNumberFrom.ToString("D7");
            uc.txtReceiptIssuedTo.Text = receiptNumberTo == 0 ? string.Empty : receiptNumberTo.ToString("D7");
            uc.txtReceiptQuantity.Text = quantity.ToString();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (SaveData())
            {
                Helper.MessageBoxSuccess("Receipt Issued has been updated.");
                frmReceiptsIssued.LoadRecords();
                Close();
            }
        }

        private void frmReceiptsEdit_Load(object sender, EventArgs e)
        {
            uc.isEdit = true;
            uc.receiptIssuedId = receiptIssuedID;
            uc.LoadReceipts();
            uc.ControlsConfiguration();
            LoadSelectedValue();
            CheckReceiptsIssuedStatus();
        }

        private bool SaveData()
        {
            if (!uc.ValidateChildren())
            {
                Helper.MessageBoxError(uc.GetFormErrors());
                return false;
            }

            var receiptIssuedRepository = TreasuryFactory.ReceiptsIssuedRepository();

            int collectorID = Convert.ToInt32(uc.cmbCollector.SelectedValue);
            int receiptID = Convert.ToInt32(uc.cmbReceipt.SelectedValue);
            var serialNumberFrom = Convert.ToInt32(string.IsNullOrEmpty(uc.txtReceiptIssuedFrom.Text) ? 0 : uc.txtReceiptIssuedFrom.Text);
            var serialNumberTo = Convert.ToInt32(string.IsNullOrEmpty(uc.txtReceiptIssuedTo.Text) ? 0 : uc.txtReceiptIssuedTo.Text);
            DateTime dateIssued = uc.dtpDateIssued.Value;
            int quantity = Convert.ToInt32(uc.txtReceiptQuantity.Text);

            var receiptIssuedModel = new ReceiptsIssuedModel()
            {
                Id = uc.receiptIssuedId,
                CollectorId = collectorID,
                ReceiptId = receiptID,
                IssuedDate = dateIssued,
                IssuedFrom = serialNumberFrom,
                IssuedTo = serialNumberTo,
                Quantity = quantity
            };

            return receiptIssuedRepository.Update(receiptIssuedModel);
        }
    }
}