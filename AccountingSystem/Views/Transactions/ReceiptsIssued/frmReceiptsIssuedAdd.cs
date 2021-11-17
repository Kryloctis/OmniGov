using ACC.Domain.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AccountingSystem.Views.Transactions.ReceiptsIssued
{
    public partial class frmReceiptsIssuedAdd : Form
    {
        private readonly frmReceiptsIssued _frmReceiptIssued;
        private readonly int _receiptId = 0;
        public frmReceiptsIssuedAdd(frmReceiptsIssued frmReceiptsIssued, int receiptId)
        {
            InitializeComponent();

            _frmReceiptIssued = frmReceiptsIssued;
            _receiptId = receiptId;
        }

        private void frmReceiptsAdd_Load(object sender, EventArgs e)
        {
            if(_receiptId > 0)
            {
                ucReceipts1.LoadCollectors(_receiptId);
                ucReceipts1.cmbreceipt.SelectedValue = _receiptId;
                ucReceipts1.cmbreceipt.Enabled = false;
            }
            else
            {
                ucReceipts1.LoadCollectors();
            }
        }


        private bool SaveData()
        {
            try
            {
                var uc = ucReceipts1;
                if (!uc.ValidateChildren())
                {
                    Helper.MessageBoxError(uc.GetFormErrors());
                    return false;
                }

                var receiptIssuedModel = new ReceiptsIssuedModel()
                {
                   CollectorId = Convert.ToInt32(uc.cmbcollector.SelectedValue),
                   ReceiptId = Convert.ToInt32(uc.cmbreceipt.SelectedValue),
                   Issued = uc.dtpissued.Value,
                   IssuedFrom = Convert.ToInt32(uc.txtfrom.Text.Trim()),
                   IssuedTo = Convert.ToInt32(uc.txtto.Text.Trim()),
                   Quantity = Convert.ToInt32(uc.txtquantity.Text.Trim())
                   
                };

                var receiptIssuedRepository = Factory.ReceiptsIssuedRepository();

                if (!uc.istickets)
                {
                    if (receiptIssuedRepository.IssuedExist(receiptIssuedModel))
                    {
                        Helper.MessageBoxError("Receipt already issued!");
                        return false;
                    }

                    if (Convert.ToInt32(uc.txtfrom.Text.Trim()) > Convert.ToInt32(uc.txtto.Text.Trim()))
                    {
                        Helper.MessageBoxError("Invalid Receipt!");
                        return false;
                    }

                    if (int.Parse(uc.txtquantity.Text.Trim()) <= 0)
                    {
                        Helper.MessageBoxError("Quantity Empty!");
                        return false;
                    }

                    return receiptIssuedRepository.Insert(receiptIssuedModel);
                }
                else
                {

                    if (int.Parse(uc.txtquantity.Text.Trim()) <= 0)
                    {
                        Helper.MessageBoxError("Quantity Empty!");
                        return false;
                    }
                    else return receiptIssuedRepository.Insert(receiptIssuedModel);
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
                _frmReceiptIssued.LoadRecords();
                ucReceipts1.ResetForm();
                if (_receiptId > 0)
                {
                    this.Close();
                }
            }
        }
    }
}
