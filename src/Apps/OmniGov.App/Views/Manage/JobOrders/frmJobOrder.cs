using OmniGov.App.Helpers;

using OmniGov.Treasury.Data.Factories;

using OmniGov.Treasury.Domain.Entities;

namespace OmniGov.App.Views.Manage.JobOrders

{
    public partial class frmJobOrder : Form

    {
        internal readonly int collectingOfficerId;

        public frmJobOrder(int collectingOfficerId)

        {
            InitializeComponent();

            Helper.DatagridFullRowSelectStyle(dgJobOrders);

            this.collectingOfficerId = collectingOfficerId;
        }

        internal void LoadRecords()

        {
            var collectingOfficerHasJODT = TreasuryFactory.CollectingOfficerHasJobOrdersRepository().GetJobOrdersByCollectingOfficerId(collectingOfficerId);

            HelperLoadRecords.JobOrdersDatagridView(collectingOfficerHasJODT, dgJobOrders);

            lblRecordCount.Text = dgJobOrders.Rows.Count.ToString();
        }

        private void btnAdd_Click(object sender, EventArgs e)

        {
            _ = new frmJobOrderAdd(this).ShowDialog();
        }

        private void btnDelete_Click(object sender, EventArgs e)

        {
            int selectedRowsCount = dgJobOrders.SelectedRows.Count;

            if (Helper.MessageBoxConfirmDelete(selectedRowsCount))
            {
                var jobOrderModel = new List<JobOrderModel>();
                var collectingOfficerHasJOModel = new List<CollectingOfficerHasJobOrdersModel>();

                foreach (DataGridViewRow row in dgJobOrders.SelectedRows)
                {
                    int jobOrderId = Convert.ToInt32(row.Cells[0].Value.ToString());

                    collectingOfficerHasJOModel.Add(new CollectingOfficerHasJobOrdersModel()
                    {
                        CollectingOfficerId = collectingOfficerId,
                        JobOrdersId = jobOrderId
                    });

                    jobOrderModel.Add(new JobOrderModel() { Id = jobOrderId });
                }

                if (TreasuryFactory.CollectingOfficerHasJobOrdersRepository().Delete(collectingOfficerHasJOModel) == true && TreasuryFactory.JobOrderRepository().Delete(jobOrderModel) == true)
                    LoadRecords();
            }
        }

        private void dgJobOrders_SelectionChanged(object sender, EventArgs e)

        {
            Helper.EnableDisableToolStripButtons(dgJobOrders, btnEdit, btnDelete);

            int id = int.Parse(dgJobOrders.CurrentRow.Cells[0].Value.ToString());
            btnDelete.Enabled = TreasuryFactory.ReceiptsIssuedRepository().CollectingOfficerHasReceiptAssigned(id) ? false : true;
        }

        private void frmJobOrder_Load(object sender, EventArgs e)

        {
            OnLoad();
        }

        private void OnLoad()

        {
            LoadRecords();
        }

        private void txtsearch_TextChanged(object sender, EventArgs e)

        {
            string searchText = txtSearch.Text.Trim();
            var collectingOfficerHasJODt = TreasuryFactory.CollectingOfficerHasJobOrdersRepository().GetRecordsBySearch(collectingOfficerId, searchText);

            HelperLoadRecords.JobOrdersDatagridView(collectingOfficerHasJODt, dgJobOrders);
            lblRecordCount.Text = dgJobOrders.Rows.Count.ToString();
        }
    }
}