using ACC.Domain.Models;
using AccountingSystem.Views.Manage.JobOrders;
using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;


namespace AccountingSystem.Views.Manage.CollectingOfficer
{
    public partial class frmCollectingOfficer : Form
    {
        public frmCollectingOfficer()
        {
            InitializeComponent();
            Helper.LoadFormIcon(this);
            Helper.DatagridFullRowSelectStyle(dgCollectingOfficer, true);
        }

        internal void LoadRecords()
        {
            try
            {
                var repository = Factory.CollectingOfficerRepository();
                var dt = repository.GetRecords();

                foreach (DataRow row in dt.Rows)
                {
                    int userId = Convert.ToInt32(row["users_id"]);
                    var dictUser = Helper.GetUserDataById(userId);
                    row["fullname"] = dictUser["user_full_name"];
                }

                HelperLoadRecords.CollectingOfficerDatagridView(dt, dgCollectingOfficer);
                lblRecordCount.Text = dgCollectingOfficer.Rows.Count.ToString();
            }
            catch (Exception ex) 
            {
                Helper.MessageBoxError(ex.Message); 
            }
        }

        private void frmCollectingOfficer_Load(object sender, EventArgs e)
        {           
            LoadRecords();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            _ = new frmCollectingOfficerAdd(this).ShowDialog();
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (dgCollectingOfficer.Rows.Count > 0)
            {
                int OfficerId = int.Parse(dgCollectingOfficer.SelectedCells[0].Value.ToString());
                _ = new frmCollectingOfficerEdit(this, OfficerId).ShowDialog();
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            int selectedRowsCount = dgCollectingOfficer.SelectedRows.Count;
            try
            {
                if (selectedRowsCount > 0)
                {
                    if (Helper.MessageBoxConfirmDelete(selectedRowsCount))
                    {
                        var repository = Factory.CollectingOfficerRepository();
                        var modelList = new List<CollectingOfficerModel>();
                        foreach (DataGridViewRow row in dgCollectingOfficer.SelectedRows)
                        {
                            int OfficerID = Convert.ToInt16(row.Cells[0].Value.ToString());
                            if (!repository.CollectingOfficerHasReceiptAssigned(OfficerID))
                            {
                                modelList.Add(new CollectingOfficerModel() { Id = OfficerID });
                            }                            
                        }
                        _ = repository.Delete(modelList);
                        LoadRecords();
                    }
                }
            }
            catch (Exception ex)
            {
                Helper.MessageBoxError(ex.Message);
            }
        }

        private void dgCollectingOfficer_SelectionChanged(object sender, EventArgs e)
        {
            int selectedRowCount = dgCollectingOfficer.SelectedRows.Count;
            if (selectedRowCount == 0)
                return;

            int id = int.Parse(dgCollectingOfficer.CurrentRow.Cells[0].Value.ToString());
            byte[] columnIndexTimestamp = { 3, 4 };

            Helper.ShowRecordTimestamp(dgCollectingOfficer, columnIndexTimestamp, lblCreatedAt, lblUpdatedAt);
            Helper.EnableDisableToolStripButtons(dgCollectingOfficer, btnEdit, btnDelete);

            var collectingOfficerRepo = Factory.CollectingOfficerRepository();

            btnDelete.Enabled = collectingOfficerRepo.CollectingOfficerHasReceiptAssigned(id) ? false : true;
            btnJobOrder.Enabled = selectedRowCount == 1;
        }

        private void txtsearch_TextChanged(object sender, EventArgs e)
        {
            if(txtsearch.Text.Length > 0)
            {
                try
                {
                    var repository = Factory.CollectingOfficerRepository();
                    var dt = repository.GetRecordsBySearch(txtsearch.Text.Trim());
                    HelperLoadRecords.CollectingOfficerDatagridView(dt, dgCollectingOfficer);

                    lblRecordCount.Text = dgCollectingOfficer.Rows.Count.ToString();
                }
                catch (Exception ex)
                {
                    Helper.MessageBoxError(ex.Message);
                }
            }
            else
            {
                LoadRecords();
            }
        }

        private void btnJobOrder_Click(object sender, EventArgs e)
        {
            _ = new frmJobOrder().ShowDialog();
        }
    }
}
