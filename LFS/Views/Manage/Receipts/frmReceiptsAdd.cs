using LFS.Helpers;
using System;
using System.Windows.Forms;
using Treasury.Domain.Entities;

namespace LFS.Views.Manage.Receipts
{
    public partial class frmReceiptsAdd : Form
    {
        private readonly frmReceipts _frmReceipts;
        private readonly int userId;
        private static ucReceipts uc;

        public frmReceiptsAdd(frmReceipts frmReceipts)
        {
            InitializeComponent();

            _frmReceipts = frmReceipts;
            userId = UserHelper.loggedUser.Id;
            uc = ucReceipts;
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

            return AccFactory.ReceiptsRepository().Insert(receiptModel);
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                if (SaveData())
                {
                    Helper.MessageBoxSuccess("Receipt has been saved.");
                    _frmReceipts.LoadReceipts();
                    uc.ResetForm();
                }
            }
            catch (Exception ex) { Helper.MessageBoxError(ex.Message); }
        }

        private void frmReceiptsAdd_Load(object sender, EventArgs e)
        {
            try
            {
                uc.OnLoad();
            }
            catch (Exception ex) { Helper.MessageBoxError(ex.Message); }
        }
    }
}