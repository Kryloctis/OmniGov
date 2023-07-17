using ACC.Domain.Models;
using System;
using System.Windows.Forms;

namespace AccountingSystem.Views.Manage.Receipts
{
    public partial class frmReceiptsEdit : Form
    {
        private readonly frmReceipts _frmReceipts;
        private readonly ucReceipts uc;
        private int userId;

        public frmReceiptsEdit(frmReceipts frmReceipts, int receiptId)
        {
            InitializeComponent();
            _frmReceipts = frmReceipts;
            userId = Helper.UserId;

            uc = ucReceipts1;
            uc.receiptId = receiptId;
        }

        private void frmAccFromEdit_Load(object sender, EventArgs e)
        {
            uc.LoadAccountableForms();
            LoadSelectedValue();
        }

        private void LoadSelectedValue()
        {
            try
            {
                var rcRepository = AccFactory.ReceiptsRepository();
                var rcdata = rcRepository.GetRecordByID(uc.receiptId);

                var formatedReceiptNumberFrom =

                uc.cmbAccountableForms.SelectedValue = rcdata["accountable_forms_id"];
                uc.txtReceiptNumberFrom.Text = Convert.ToInt32(rcdata["receipt_number_from"]).ToString("0000000");
                uc.txtReceiptNumberTo.Text = Convert.ToInt32(rcdata["receipt_number_to"]).ToString("0000000");
                uc.dtpReceivedDate.Value = Convert.ToDateTime(rcdata["received_date"]);
                uc.txtQuantity.Text = rcdata["quantity"];
                uc.txtRemark.Text = rcdata["remarks"];

                var receiptIsUsed = AccFactory.ReceiptsIssuedRepository().ReceiptIsUsed(uc.receiptId);
                if (receiptIsUsed)
                {
                    uc.cmbAccountableForms.Enabled = false;
                    uc.txtReceiptNumberFrom.Enabled = false;
                    uc.txtReceiptNumberTo.Enabled = false;
                }
                uc.cmbAccountableForms.Enabled = false;
            }
            catch (Exception ex)
            {
                Helper.MessageBoxError(ex.Message);
            }
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

                var rModel = new ReceiptsModel()
                {
                    Id = uc.receiptId,
                    AccountableFormId = int.Parse(uc.cmbAccountableForms.SelectedValue.ToString()),
                    SerialNoFrom = int.Parse(uc.txtReceiptNumberFrom.Text.Trim()),
                    SerialNoTo = int.Parse(uc.txtReceiptNumberTo.Text.Trim()),
                    ReceiptDate = uc.dtpReceivedDate.Value,
                    Quantity = int.Parse(uc.txtQuantity.Text.Trim()),
                    Remarks = uc.txtRemark.Text.Trim(),
                    UserId = userId
                };

                var rcRepository = AccFactory.ReceiptsRepository();
                if (uc.isCashTicket == false)
                    return rcRepository.Update(rModel);
                else
                    return rcRepository.Update(rModel);
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
                Helper.MessageBoxSuccess("Receipt has been updated.");
                if (!_frmReceipts.bgwLoadReceipts.IsBusy)
                    _frmReceipts.bgwLoadReceipts.RunWorkerAsync();
                this.Close();
            }
        }
    }
}