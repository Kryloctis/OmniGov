using ACC.Domain.Models;
using System;
using System.Windows.Forms;

namespace AccountingSystem.Views.Manage.Receipts
{
    public partial class frmReceiptsAdd : Form
    {
        private readonly frmReceipts frmReceipts;
        private readonly int userId;
        private static ucReceipts uc;

        public frmReceiptsAdd(frmReceipts _frmReceipts)
        {
            InitializeComponent();

            frmReceipts = _frmReceipts;
            userId = Helper.UserId;
            uc = ucReceipts;
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

                var serialNumberFrom = Convert.ToInt32(string.IsNullOrEmpty(uc.txtReceiptNumberFrom.Text.Trim()) ? 0 : uc.txtReceiptNumberFrom.Text);
                var serialNumberTo = Convert.ToInt32(string.IsNullOrEmpty(uc.txtReceiptNumberTo.Text.Trim()) ? 0 : uc.txtReceiptNumberTo.Text);
                var accountableFormId = Convert.ToInt32(uc.cmbAccountableForms.SelectedValue.ToString());
                var receiptDate = uc.dtpReceivedDate.Value;
                var quantity = Convert.ToInt32(uc.txtQuantity.Text.Trim());
                var remark = uc.txtRemark.Text.Trim();
                var userId = this.userId;

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

                var receiptRepository = Factory.ReceiptsRepository();
                return receiptRepository.Insert(receiptModel);
            }
            catch (Exception ex)
            {
                Helper.MessageBoxError(ex.Message);
            }

            return false;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (SaveData())
            {
                Helper.MessageBoxSuccess("Receipt has been saved.");
                frmReceipts.LoadRecords();
                uc.ResetForm();
            }
        }
    }
}
