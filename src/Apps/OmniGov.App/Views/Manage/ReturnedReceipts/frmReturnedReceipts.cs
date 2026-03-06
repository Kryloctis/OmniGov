using OmniGov.App.Helpers;

using OmniGov.Treasury.Data.Factories;

namespace OmniGov.App.Views.Manage.ReturnedReceipts

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
            OnLoad();
        }

        private void LoadRecords()

        {
            var returnedReceiptDt = TreasuryFactory.ReceiptsIssuedRepository().GetReturnedReceipts();

            HelperLoadRecords.ReturnedReceiptsDatagridView(returnedReceiptDt, dgReturnedReceipts);

            lblRecordCounts.Text = dgReturnedReceipts.Rows.Count.ToString();
        }

        private void OnLoad()

        {
            LoadRecords();
        }

        private void txtsearch_TextChanged(object sender, EventArgs e)

        {
            var searchKey = txtSearch.Text.Trim();

            var receiptIssuedRepo = TreasuryFactory.ReceiptsIssuedRepository();
            var returnedReceiptDt = receiptIssuedRepo.GetReturnedReceiptsBySearch(searchKey);

            HelperLoadRecords.ReturnedReceiptsDatagridView(returnedReceiptDt, dgReturnedReceipts);
            lblRecordCounts.Text = dgReturnedReceipts.Rows.Count.ToString();
        }
    }
}