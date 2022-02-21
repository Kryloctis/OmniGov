using ACC.Domain.Models;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace AccountingSystem.Views.Manage.DisbursingOfficer
{
    public partial class frmDisbursingOfficer : Form
    {
        public frmDisbursingOfficer()
        {
            InitializeComponent();
            Helper.LoadFormIcon(this);

            btnAdd.Click += new EventHandler(BtnAdd_Click);
            btnEdit.Click += new EventHandler(btnEdit_Click);
            btnDelete.Click += new EventHandler(BtnDelete_Click);

            Helper.DatagridFullRowSelectStyle(dgDisbursingOfficer);
        }

        internal void LoadRecords()
        {
            try
            {
                var dtDisbursingOfficers = Factory.DisbursingOfficerRepository().GetRecords();
                HelperLoadRecords.DisbursingOfficerDatagridView(dtDisbursingOfficers, dgDisbursingOfficer);
            }
            catch (Exception ex)
            {
                Helper.MessageBoxError(ex.Message);
            }
        }

        private void frmDisbursingOfficer_Load(object sender, EventArgs e)
        {
            LoadRecords();
        }

        private void BtnAdd_Click(object sender, EventArgs e)
        {
            _ = new frmDisbursingOfficerAdd(this).ShowDialog();
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (dgDisbursingOfficer.Rows.Count > 0)
            {
                int disbursingOfficerId = int.Parse(dgDisbursingOfficer.SelectedCells[0].Value.ToString());
                _ = new frmDisbursingOfficerEdit(this, disbursingOfficerId).ShowDialog();
            }
        }

        private void BtnDelete_Click(object sender, EventArgs e)
        {
            int selectedRowsCount = dgDisbursingOfficer.SelectedRows.Count;
            try
            {
                if (selectedRowsCount > 0)
                {
                    if (Helper.MessageBoxConfirmDelete(selectedRowsCount))
                    {
                        var modelList = new List<DisbursingOfficerModel>();
                        foreach (DataGridViewRow row in dgDisbursingOfficer.SelectedRows)
                        {
                            int disbursingOfficerId = Convert.ToInt16(row.Cells[0].Value.ToString());
                            modelList.Add(new DisbursingOfficerModel() { Id = disbursingOfficerId });
                        }

                        _ = Factory.DisbursingOfficerRepository().Delete(modelList);
                        LoadRecords();
                    }
                }
            }
            catch (Exception ex)
            {
                Helper.MessageBoxError(ex.Message);
            }
        }

        private void dgDisbursingOfficer_SelectionChanged(object sender, EventArgs e)
        {
            byte[] columnIndexTimestamp = { 3, 4 };
            Helper.ShowRecordTimestamp(dgDisbursingOfficer, columnIndexTimestamp, lblCreatedAt, lblUpdatedAt);
            Helper.EnableDisableToolStripButtons(dgDisbursingOfficer, btnEdit, btnDelete);
        }
    }
}
