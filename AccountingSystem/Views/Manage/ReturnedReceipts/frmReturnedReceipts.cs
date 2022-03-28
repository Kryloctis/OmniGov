using System;
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

        private void txtsearch_TextChanged(object sender, EventArgs e)
        {
            try
            {
                var searchKey = txtSearch.Text.Trim();

                var receiptIssuedRepo = Factory.ReceiptsIssuedRepository();
                var returnedReceiptDt = receiptIssuedRepo.GetReturnedReceiptsBySearch(searchKey);

                HelperLoadRecords.ReturnedReceiptsDatagridView(returnedReceiptDt, dgReturnedReceipts);
                lblRecordCounts.Text = dgReturnedReceipts.Rows.Count.ToString();
             }
            catch (Exception ex) 
            {
                Helper.MessageBoxError(ex.Message); 
            }
        }
    }
}
