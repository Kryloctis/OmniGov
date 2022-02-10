using ACC.Domain.Models;
using System;
using System.Windows.Forms;

namespace AccountingSystem.Views.Manage.Receipts
{
    public partial class frmReceiptsAdd : Form
    {
        private readonly frmReceipts frmReceipts;
        private int UserId = 0;

        public frmReceiptsAdd(frmReceipts _frmReceipts)
        {
            InitializeComponent();
            frmReceipts = _frmReceipts;
            UserId = Helper.UserId;
        }

        private void frmAccFormsAdd_Load(object sender, EventArgs e)
        {
            ucReceipts.LoadForms();
        }

        private bool SaveData()
        {
            try
            {
                var uc = ucReceipts;
                if (!uc.ValidateChildren())
                {
                    Helper.MessageBoxError(uc.GetFormErrors());
                    return false;
                }


                int receiptNumberFrom;
                int receiptNumberTo;

                if (string.IsNullOrEmpty(uc.txtReceiptNumberFrom.Text) || string.IsNullOrEmpty(uc.txtReceiptNumberTo.Text))
                {
                    receiptNumberFrom = 0;
                    receiptNumberTo = 0;
                }
                else
                {
                    receiptNumberFrom = Convert.ToInt32(uc.txtReceiptNumberFrom.Text.Trim());
                    receiptNumberTo = Convert.ToInt32(uc.txtReceiptNumberTo.Text.Trim());
                }

                var accountableFormId = Convert.ToInt32(uc.cmbAccountableForms.SelectedValue.ToString());
                var receiptDate = uc.dtpReceivedDate.Value;
                var quantity = Convert.ToInt32(uc.txtQuantity.Text.Trim());
                var remark = uc.txtRemark.Text.Trim();
                var userId = UserId;


                var receiptModel = new ReceiptsModel()
                {
                    AccId = accountableFormId,
                    SerialNoFrom = receiptNumberFrom,
                    SerialNoTo = receiptNumberTo,
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
                ucReceipts.ResetForm();
            }
        }


    }
}
