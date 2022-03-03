using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

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
    }
}
