using ACC.Domain.Models;
using AccountingSystem.Views.Transactions.ReceiptsIssued;
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
    public partial class frmReturnReceipts : Form
    {
        private frmReceiptsIssued frmr;
        private int receiptId = 0;
        public frmReturnReceipts(frmReceiptsIssued _frmr, int id, int receiptNumberFrom, int receiptNumberTo)
        {
            InitializeComponent();
            frmr = _frmr;

            receiptId = id;
            txtReceiptNumberFrom.Text = receiptNumberFrom.ToString();
            txtReceiptNumberTo.Text = receiptNumberTo.ToString();

        }

        private bool SaveData()
        {
            try
            {
                var riRepository = Factory.ReceiptsIssuedRepository();
                var riModel = new ReceiptsIssuedModel()
                {
                    Id = receiptId,
                    Is_returned = 1,
                    Returned_date = dtpreturn.Value
                };
                return riRepository.UpdateReturnedReceipt(riModel);
            }
            catch (Exception ex) { Helper.MessageBoxError(ex.Message); }
            return false;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (SaveData())
            {
                Helper.MessageBoxSuccess("Receipt returned saved!");
                frmr.LoadRecords();
                this.Close();
            }
        }

        private void frmReturn_Load(object sender, EventArgs e)
        {

        }
    }
}
