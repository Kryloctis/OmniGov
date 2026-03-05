using OmniGov.App.Helpers;

using OmniGov.Treasury.Data.Factories;

using OmniGov.Treasury.Domain.Entities;

namespace OmniGov.App.Views.Manage.Receipts

{
    public partial class frmReceiptsEdit : Form

    {
        private readonly frmReceipts _frmReceipts;

        private readonly int _receiptID;

        private readonly ucReceipts uc;

        private readonly int userId = UserHelper.loggedUser.Id;

        public frmReceiptsEdit(frmReceipts frmReceipts, int receiptID)

        {
            InitializeComponent();

            _frmReceipts = frmReceipts;

            _receiptID = receiptID;

            uc = ucReceipts1;

            uc.receiptID = receiptID;
        }

        private void btnSave_Click(object sender, EventArgs e)

        {
            if (SaveData())
            {
                Helper.MessageBoxSuccess("Receipt has been updated.");
                _frmReceipts.LoadReceipts();
                Close();
            }
        }

        private void frmAccFromEdit_Load(object sender, EventArgs e)

        {
            OnLoad();
        }

        private void LoadSelectedValue()

        {
            Dictionary<string, string> dictReceipts = TreasuryFactory.ReceiptsRepository().GetRecordByID(_receiptID);

            int accountableFormID = Convert.ToInt32(dictReceipts["accountable_forms_id"]);

            int receiptNumberFrom = Convert.ToInt32(dictReceipts["receipt_number_from"]);

            int receiptNumberTo = Convert.ToInt32(dictReceipts["receipt_number_to"]);

            DateTime dateReceived = Convert.ToDateTime(dictReceipts["received_date"]);

            int quantity = Convert.ToInt32(dictReceipts["quantity"]);

            string remarks = dictReceipts["remarks"].ToString();

            uc.cmbAccountableForms.SelectedValue = accountableFormID;

            uc.txtReceiptNumberFrom.Text = receiptNumberFrom == 0 ? string.Empty : receiptNumberFrom.ToString("D7");

            uc.txtReceiptNumberTo.Text = receiptNumberTo == 0 ? string.Empty : receiptNumberTo.ToString("D7");

            uc.dtpReceivedDate.Value = dateReceived;

            uc.txtQuantity.Text = quantity.ToString();

            uc.txtRemark.Text = remarks;
        }

        private void OnLoad()

        {
            uc.OnLoad();

            LoadSelectedValue();

            SetUpdateRestrictions();
        }

        private bool SaveData()

        {
            if (!uc.ValidateChildren())

            {
                Helper.MessageBoxError(uc.GetFormErrors());

                return false;
            }

            int accountableFormID = Convert.ToInt32(uc.cmbAccountableForms.SelectedValue);

            var serialNumberFrom = Convert.ToInt32(string.IsNullOrEmpty(uc.txtReceiptNumberFrom.Text) ? 0 : uc.txtReceiptNumberFrom.Text);

            var serialNumberTo = Convert.ToInt32(string.IsNullOrEmpty(uc.txtReceiptNumberTo.Text) ? 0 : uc.txtReceiptNumberTo.Text);

            DateTime receiptReceivedDate = uc.dtpReceivedDate.Value;

            int quantity = Convert.ToInt32(uc.txtQuantity.Text);

            string remark = uc.txtRemark.Text.Trim();

            var receiptModel = new ReceiptsModel()

            {
                Id = _receiptID,

                AccountableFormId = accountableFormID,

                SerialNoFrom = serialNumberFrom,

                SerialNoTo = serialNumberTo,

                ReceiptDate = receiptReceivedDate,

                Quantity = quantity,

                Remarks = remark,

                UserId = userId
            };

            return TreasuryFactory.ReceiptsRepository().Update(receiptModel);
        }

        private void SetUpdateRestrictions()

        {
            //restrict updating series number and set the max date of received date receipts if receipts has been issued.

            bool receiptHasIssuance = TreasuryFactory.ReceiptsIssuedRepository().ReceiptHasIssuance(_receiptID);

            if (receiptHasIssuance)

            {
                uc.cmbAccountableForms.Enabled = false;

                uc.txtReceiptNumberFrom.Enabled = false;

                uc.txtReceiptNumberTo.Enabled = false;

                //set max date of date received.

                Dictionary<string, string> dict = TreasuryFactory.ReceiptsIssuedRepository().GetViewRecordReceiptId(_receiptID);

                if (dict.Count != 0)

                    uc.dtpReceivedDate.MaxDate = Convert.ToDateTime(dict["date_issued"]);
            }
        }
    }
}