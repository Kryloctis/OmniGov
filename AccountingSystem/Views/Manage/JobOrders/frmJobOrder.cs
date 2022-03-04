using System;
using System.Collections.Generic;
using System.Transactions;
using System.Windows.Forms;
using ACC.Domain.Models;

namespace AccountingSystem.Views.Manage.JobOrders
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

        private void btnAdd_Click(object sender, EventArgs e)
        {
            _ = new frmJobOrderAdd(this).ShowDialog();
        }

        private void frmJobOrder_Load(object sender, EventArgs e)
        {
            LoadRecords();
        }

        internal void LoadRecords()
        {
            try
            {
                var collectingOfficerHasJORepo = Factory.CollectingOfficerHasJobOrdersRepository();
                var collectingOfficerHasJODT = collectingOfficerHasJORepo.GetJobOrdersByCollectingOfficerId(collectingOfficerId);

                HelperLoadRecords.JobOrdersDatagridView(collectingOfficerHasJODT, dgJobOrders);
                lblRecordCount.Text = dgJobOrders.Rows.Count.ToString();
            }
            catch (Exception ex)
            {
                Helper.MessageBoxError(ex.Message);
            }
        }

        private void dgJobOrders_SelectionChanged(object sender, EventArgs e)
        {
            Helper.EnableDisableToolStripButtons(dgJobOrders, btnEdit, btnDelete);
        }

        private void txtsearch_TextChanged(object sender, EventArgs e)
        {
            string searchText = txtSearch.Text.Trim();
            var collectingOfficerHasJORepo = Factory.CollectingOfficerHasJobOrdersRepository();
            var collectingOfficerHasJODt = collectingOfficerHasJORepo.GetRecordsBySearch(collectingOfficerId, searchText);

            HelperLoadRecords.JobOrdersDatagridView(collectingOfficerHasJODt, dgJobOrders);
            lblRecordCount.Text = dgJobOrders.Rows.Count.ToString();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            int selectedRowsCount = dgJobOrders.SelectedRows.Count;
            try
            {
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

                    var collectingOfficerHasJORepo = Factory.CollectingOfficerHasJobOrdersRepository();

                    var jobOrderRepo = Factory.JobOrderRepository();

                    if (collectingOfficerHasJORepo.Delete(collectingOfficerHasJOModel) == true && jobOrderRepo.Delete(jobOrderModel) == true)
                    {
                        LoadRecords();
                    }
                }
            }
            catch (Exception ex)
            {
                Helper.MessageBoxError(ex.Message);
            }
        }

    }
}
