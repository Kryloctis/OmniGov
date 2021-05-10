using ACC.Domain.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace AccountingSystem.Views.Manage.CollectingOfficer
{
    public partial class frmCollectingOfficer : Form
    {
        public frmCollectingOfficer()
        {
            InitializeComponent();
        }
        internal void LoadRecords()
        {
            try
            {
                var repository = Factory.CollectingOfficerRepository();
                var dt = repository.GetRecords();
                HelperLoadRecords.CollectingOfficerDatagridView(dt, dgCollectingOfficer);

                lblRecordCount.Text = repository.CountRecords().ToString();
            }
            catch (Exception ex) { Helper.MessageBoxError(ex.Message); }
        }
        private void frmCollectingOfficer_Load(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Normal;
            Helper.LoadFormIcon(this);
            Helper.DatagridDefaultStyle(dgCollectingOfficer);
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
                        var modelList = new List<CollectingOfficerModel>();
                        foreach (DataGridViewRow row in dgCollectingOfficer.SelectedRows)
                        {
                            int OfficerID = Convert.ToInt16(row.Cells[0].Value.ToString());
                            modelList.Add(new CollectingOfficerModel() { Id = OfficerID });
                        }

                        var repository = Factory.CollectingOfficerRepository();
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
            byte[] columnIndexTimestamp = { 3, 4 };
            Helper.ShowRecordTimestamp(dgCollectingOfficer, columnIndexTimestamp, lblCreatedAt, lblUpdatedAt);
            Helper.EnableDisableToolStripButtons(dgCollectingOfficer, btnEdit, btnDelete);
        }
    }
}
