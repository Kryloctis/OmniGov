using OmniGov.App.Helpers;

using OmniGov.Treasury.Data.Factories;

using OmniGov.Treasury.Domain.Entities;

namespace OmniGov.App.Views.Manage.Receipts

{
    public partial class frmReceiptsAdd : Form

    {
        private static ucReceipts uc;
        private readonly frmReceipts _frmReceipts;

        private readonly int userId;

        public frmReceiptsAdd(frmReceipts frmReceipts)

        {
            InitializeComponent();

            _frmReceipts = frmReceipts;

            userId = UserHelper.loggedUser.Id;

            uc = ucReceipts;
        }

        private void btnSave_Click(object sender, EventArgs e)

        {
            if (SaveData())
            {
                Helper.MessageBoxSuccess("Receipt has been saved.");
                _frmReceipts.LoadReceipts();
                uc.ResetForm();
            }
        }

        private void frmReceiptsAdd_Load(object sender, EventArgs e)

        {
            uc.OnLoad();
        }

        private bool SaveData()

        {
            if (!uc.ValidateChildren())

            {
                Helper.MessageBoxError(uc.GetFormErrors());

                return false;
            }

            var serialNumberFrom = Convert.ToInt32(string.IsNullOrEmpty(uc.txtReceiptNumberFrom.Text) ? 0 : uc.txtReceiptNumberFrom.Text);

            var serialNumberTo = Convert.ToInt32(string.IsNullOrEmpty(uc.txtReceiptNumberTo.Text) ? 0 : uc.txtReceiptNumberTo.Text);

            int accountableFormId = Convert.ToInt32(uc.cmbAccountableForms.SelectedValue);

            DateTime receiptDate = uc.dtpReceivedDate.Value;

            int quantity = Convert.ToInt32(uc.txtQuantity.Text);

            string remark = uc.txtRemark.Text.Trim();

            int userId = this.userId;

            var receiptModel = new ReceiptsModel()

            {
                AccountableFormId = accountableFormId,

                SerialNoFrom = serialNumberFrom,

                SerialNoTo = serialNumberTo,

                ReceiptDate = receiptDate,

                Quantity = quantity,

                Remarks = remark,

                UserId = userId
            };

            return TreasuryFactory.ReceiptsRepository().Insert(receiptModel);
        }
    }
}