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
    public partial class frmReturn : Form
    {
        private frmReceipts frmr;
        private int Rid = 0;
        public frmReturn(frmReceipts _frmr,int id)
        {
            InitializeComponent();
            frmr = _frmr;
            Rid = id;
        }

        private bool SaveData()
        {
            try
            {
                var riRepository = Factory.ReceiptsIssuedRepository();
                var riModel = new ReceiptsIssuedModel()
                {
                    Id = Rid,
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
