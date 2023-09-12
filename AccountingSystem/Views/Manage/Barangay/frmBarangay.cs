using ACC.Domain.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;

namespace AccountingSystem.Views.Manage.Barangay
{
    public partial class frmBarangay : Form
    {
        public frmBarangay()
        {
            InitializeComponent();
            Helper.LoadFormIcon(this);
            Helper.DatagridFullRowSelectStyle(dgBarangay, true);
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            _ = new frmAddBarangay(this).ShowDialog();
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            int rowIndex = dgBarangay.CurrentRow.Index;
            int barangayId = Convert.ToInt32(dgBarangay.Rows[rowIndex].Cells["id"].Value);

            _ = new frmEditBarangay(barangayId, this).ShowDialog();
        }

        private void frmBarangay_Load(object sender, EventArgs e)
        {
            try
            {
                LoadRecords();
            }
            catch (Exception ex) { Helper.MessageBoxError(ex.Message); }
        }

        private DataColumn[] BarangayDataColumns()
        {
            var dataColumns = new DataColumn[]
            {
                new DataColumn("id", typeof(int)),
                new DataColumn("code", typeof(string)),
                new DataColumn("name", typeof(string)),
            };

            return dataColumns;
        }

        internal void LoadBarangay()
        {
            DataTable dtBarangay = new();
            DataTable dtBarangayFromDB;
            var searchText = txtSearch.Text.Trim();
            dtBarangay.Columns.AddRange(BarangayDataColumns());

            if (searchText.Length > 2)
                dtBarangayFromDB = AccFactory.BarangayRepository().GetRecordsBySearch(searchText);
            else
                dtBarangayFromDB = AccFactory.BarangayRepository().GetRecords();

            int recordCount = dtBarangayFromDB.Rows.Count;
            int rowCount = 0;

            foreach (DataRow row in dtBarangayFromDB.Rows)
            {
                var newRow = dtBarangay.NewRow();

                int id = Convert.ToInt32(row["id"]);
                string code = row["code"].ToString();
                string name = row["name"].ToString();

                newRow["id"] = id;
                newRow["code"] = code;
                newRow["name"] = name;

                rowCount++;
                int progressBarPercentage = (rowCount * 100) / recordCount;
                backgroundWorker1.ReportProgress(progressBarPercentage);
                dtBarangay.Rows.Add(newRow);
            }

            HelperLoadRecords.BarangaysDatagridView(dgBarangay, dtBarangay);
        }

        private void toolStripTextBoxSearch_TextChanged(object sender, EventArgs e)
        {
            try
            {
                LoadRecords();
            }
            catch (Exception ex) { Helper.MessageBoxError(ex.Message); }
        }

        private void dgBarangay_SelectionChanged(object sender, EventArgs e)
        {
            Helper.EnableDisableToolStripButtons(dgBarangay, btnEdit, btnDelete);
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            int deletedRecordCount;

            if (DeleteData(out deletedRecordCount))
            {
                Helper.MessageBoxSuccess($"{deletedRecordCount} record/s has been deleted.");
                LoadRecords();
            }
        }

        private bool DeleteData(out int deletedCount)
        {
            try
            {
                var barangayModelList = new List<BarangayModel>();
                int rowCount = dgBarangay.SelectedRows.Count;

                if (Helper.MessageBoxConfirmDelete(rowCount))
                {
                    foreach (DataGridViewRow row in dgBarangay.SelectedRows)
                    {
                        int barangayId = Convert.ToInt32(row.Cells["id"].Value);
                        var model = new BarangayModel() { Id = barangayId };
                        barangayModelList.Add(model);
                    }

                    deletedCount = rowCount;
                    return AccFactory.BarangayRepository().Delete(barangayModelList);
                }
            }
            catch (Exception ex)
            {
                Helper.MessageBoxError(ex.Message);
            }

            deletedCount = 0;
            return false;
        }

        internal void LoadRecords()
        {
            if (!backgroundWorker1.IsBusy)
            {
                pbLoadRecords.Value = 0;
                backgroundWorker1.RunWorkerAsync();
            }
        }


        private void backgroundWorker1_DoWork(object sender, System.ComponentModel.DoWorkEventArgs e)
        {
            Invoke((MethodInvoker)delegate
            {
                LoadBarangay();
            });
        }

        private void backgroundWorker1_ProgressChanged(object sender, System.ComponentModel.ProgressChangedEventArgs e)
        {
            pbLoadRecords.Value = e.ProgressPercentage;
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            LoadRecords();
        }
    }
}