using ACC.Data;
using LFS;
using System;
using System.Windows.Forms;

namespace LFS.Views.Manage.ReturnedReceipts
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
            try
            {
                OnLoad();
            }
            catch (Exception ex) { Helper.MessageBoxError(ex.Message); }
        }

        private void OnLoad()
        {
            LoadRecords();
        }

        private void LoadRecords()
        {
            var returnedReceiptDt = AccFactory.ReceiptsIssuedRepository().GetReturnedReceipts();

            HelperLoadRecords.ReturnedReceiptsDatagridView(returnedReceiptDt, dgReturnedReceipts);
            lblRecordCounts.Text = dgReturnedReceipts.Rows.Count.ToString();
        }

        private void txtsearch_TextChanged(object sender, EventArgs e)
        {
            try
            {
                var searchKey = txtSearch.Text.Trim();

                var receiptIssuedRepo = AccFactory.ReceiptsIssuedRepository();
                var returnedReceiptDt = receiptIssuedRepo.GetReturnedReceiptsBySearch(searchKey);

                HelperLoadRecords.ReturnedReceiptsDatagridView(returnedReceiptDt, dgReturnedReceipts);
                lblRecordCounts.Text = dgReturnedReceipts.Rows.Count.ToString();
            }
            catch (Exception ex) { Helper.MessageBoxError(ex.Message); }
        }
    }
}