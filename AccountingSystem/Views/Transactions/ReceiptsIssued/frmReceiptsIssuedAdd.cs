using ACC.Domain.Models;
using System;
using System.Windows.Forms;

namespace AccountingSystem.Views.Transactions.ReceiptsIssued
{
    public partial class frmReceiptsIssuedAdd : Form
    {
        private readonly frmReceiptsIssued _frmReceiptIssued;
        private readonly int _receiptId = 0;
        private readonly ucReceiptsIssued uc;

        public frmReceiptsIssuedAdd(frmReceiptsIssued frmReceiptsIssued, int receiptId)
        {
            InitializeComponent();

            _frmReceiptIssued = frmReceiptsIssued;
            _receiptId = receiptId;
            uc = ucReceipts1;
        }

        private void frmReceiptsAdd_Load(object sender, EventArgs e)
        {
            if(_receiptId > 0)
            {
                uc.LoadCollectors(_receiptId);
                uc.cmbReceipt.SelectedValue = _receiptId;
                uc.cmbReceipt.Enabled = false;
            }
            else
            {
                uc.LoadCollectors();
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

                var collectorId = Convert.ToInt32(uc.cmbCollector.SelectedValue);
                var receiptId = Convert.ToInt32(uc.cmbReceipt.SelectedValue);
                var dateIssued = uc.dtpIssued.Value;
                var issueFrom = Convert.ToInt32(uc.nudReceiptIssuedFrom.Text.Trim());
                var issueTo = Convert.ToInt32(uc.nudReceiptIssuedTo.Text.Trim());
                var quantity = Convert.ToInt32(uc.txtReceiptQuantity.Text.Trim());
                var userId = Helper.UserId;

                var receiptIssuedModel = new ReceiptsIssuedModel()
                {
                    CollectorId = collectorId,
                    ReceiptId = receiptId,
                    Issued = dateIssued,
                    IssuedFrom = issueFrom,
                    IssuedTo = issueTo,
                    Quantity = quantity,
                    IssuedByUserId = userId
                };

                var receiptIssuedRepository = Factory.ReceiptsIssuedRepository();

                if (!uc.isTickets)
                {
                    //if (receiptIssuedRepository.IssuedExist(receiptIssuedModel))
                    //{
                    //    Helper.MessageBoxError("Receipt already issued!");
                    //    return false;
                    //}

                    //if (Convert.ToInt32(uc.txtfrom.Text.Trim()) > Convert.ToInt32(uc.txtto.Text.Trim()))
                    //{
                    //    Helper.MessageBoxError("Invalid Receipt!");
                    //    return false;
                    //}

                    //if (int.Parse(uc.txtquantity.Text.Trim()) <= 0)
                    //{
                    //    Helper.MessageBoxError("Quantity Empty!");
                    //    return false;
                    //}

                    return receiptIssuedRepository.Insert(receiptIssuedModel);
                }

                else
                {
                    return receiptIssuedRepository.Insert(receiptIssuedModel);
                }
               

            }
            catch (Exception ex) { Helper.MessageBoxError(ex.Message); }
            return false;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (SaveData())
            {
                Helper.MessageBoxSuccess("Receipt Issued has been saved.");
                uc.ResetForm();
                _frmReceiptIssued.LoadRecords();

                if (_receiptId > 0)
                {
                    this.Close();
                }
            }
        }

        private void frmReceiptsIssuedAdd_FormClosing(object sender, FormClosingEventArgs e)
        {
            _frmReceiptIssued.LoadRecords();
        }

    }
}
