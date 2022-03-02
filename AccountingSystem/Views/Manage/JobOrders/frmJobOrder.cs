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

        private readonly int collectingOfficerId;

        public frmJobOrder(int collectingOfficerId)
        {
            InitializeComponent();
            Helper.DatagridFullRowSelectStyle(dgJobOrders);
            this.collectingOfficerId = collectingOfficerId;
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            _ = new frmJobOrderAdd().ShowDialog();
        }

        private void frmJobOrder_Load(object sender, EventArgs e)
        {
            LoadRecords();
        }

        internal void LoadRecords()
        {
            try
            {
                var jobOrderRepo = Factory.JobOrderRepository();
                var dt = jobOrderRepo.GetViewRecordsByCollectingOfficerId(collectingOfficerId);

                HelperLoadRecords.JobOrdersDatagridView(dt, dgJobOrders);
                lblRecordCount.Text = dgJobOrders.Rows.Count.ToString();
            }
            catch (Exception ex)
            {
                Helper.MessageBoxError(ex.Message);
            }
        }
    }
}
