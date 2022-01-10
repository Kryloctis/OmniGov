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


namespace AccountingSystem.Views.Manage.ReturnedReceipts
{
    public partial class frmReturnedReceipts : Form
    {

        
        public frmReturnedReceipts()
        {
            InitializeComponent();
            Helper.DatagridFullRowSelectStyle(dgReturnedReceipts, true);
            Helper.LoadFormIcon(this);

        }

        private void frmReturnedReceipts_Load(object sender, EventArgs e)
        {
           LoadRecords();
        }

        private void LoadRecords()
        {
            try
            {
                var receiptIssuedRepo = Factory.ReceiptsIssuedRepository();
                var returnedReceiptDt = receiptIssuedRepo.GetReturnedReceipts();

                HelperLoadRecords.ReturnedReceiptsDatagridView(returnedReceiptDt, dgReturnedReceipts);
                lblRecordCounts.Text = dgReturnedReceipts.Rows.Count.ToString();

            }
            catch (Exception)
            {
                throw;
            }
        }

        private void toolStripStatusLabel2_Click(object sender, EventArgs e)
        {

        }
    }
}
