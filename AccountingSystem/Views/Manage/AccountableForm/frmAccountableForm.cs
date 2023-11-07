using ACC.Domain.Models;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Windows.Forms;

namespace AccountingSystem.Views.Manage.AccountableForm
{
    public partial class frmAccountableForm : Form
    {
        public frmAccountableForm()
        {
            InitializeComponent();
            Helper.LoadFormIcon(this);
            Helper.DatagridFullRowSelectStyle(dgAccountableForm, true);
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                _ = new frmAddAccountableForm(this).ShowDialog();
            }
            catch (Exception ex) { Helper.MessageBoxError(ex.Message); }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                DeleteData();
            }
            catch (MySqlException ex)
            {
                if (ex.Number == 1451)
                    Helper.MessageBoxError("Can't delete accountable form/s. The record/s has been used as reference to different record.");
            }
            catch (Exception ex) { Helper.MessageBoxError(ex.Message); }
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            int rowIndex = dgAccountableForm.CurrentRow.Index;
            int accountableFormId = Convert.ToInt32(dgAccountableForm.Rows[rowIndex].Cells["id"].Value.ToString());

            _ = new frmEditAccountableForm(this, accountableFormId).ShowDialog();
        }

        private void btnFaceValue_Click(object sender, EventArgs e)
        {
            int rowIndex = dgAccountableForm.CurrentRow.Index;
            int accountableFormId = Convert.ToInt32(dgAccountableForm.Rows[rowIndex].Cells["id"].Value);
            _ = new frmFaceValue(accountableFormId).ShowDialog();
            LoadRecords();
        }

        private void DeleteData()
        {
            int selectedrowscount = dgAccountableForm.SelectedRows.Count;

            if (selectedrowscount > 0)
            {
                if (Helper.MessageBoxConfirmDelete(selectedrowscount))
                {
                    var accModelList = new List<AccountableModel>();
                    foreach (DataGridViewRow row in dgAccountableForm.SelectedRows)
                    {
                        int rowId = Convert.ToInt16(row.Cells["id"].Value.ToString());
                        accModelList.Add(new AccountableModel() { Id = rowId });
                    }

                    _ = AccFactory.AccountableFormsRepository().Delete(accModelList);
                    LoadRecords();
                }
            }
        }

        private void dgAccountableForm_SelectionChanged(object sender, EventArgs e)
        {
            Helper.EnableDisableToolStripButtons(dgAccountableForm, btnEdit, btnDelete);
            int selectedRowCount = dgAccountableForm.SelectedRows.Count;


            if (selectedRowCount == 1)
            {
                int index = dgAccountableForm.CurrentCell.RowIndex;
                int accountableFormId = Convert.ToInt32(dgAccountableForm.Rows[index].Cells["id"].Value);
                groupBox2.Enabled = true;

                LoadFaceValues(accountableFormId);
            }
            else
            {
                groupBox2.Enabled = false;
            }
        }

        private void frmAccountable_Load(object sender, EventArgs e)
        {
            try
            {
                LoadRecords();
            }
            catch (Exception ex) { Helper.MessageBoxError(ex.Message); }
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            try
            {
                LoadRecords();
            }
            catch (Exception ex) { Helper.MessageBoxError(ex.Message); }
        }

        private DataColumn[] AccountableFormColumns()
        {
            var dataColumns = new DataColumn[]
            {
                new DataColumn("id", typeof(int)),
                new DataColumn("form_code", typeof(string)),
                new DataColumn("form_description", typeof(string)),
                new DataColumn("form_face_value", typeof(decimal)),
            };

            return dataColumns;
        }

        internal void LoadRecords()
        {
            if (!backgroundWorker1.IsBusy)
            {
                pbLoadRecords.Value = 0;
                string searchKey = txtSearch.Text.Trim();
                backgroundWorker1.RunWorkerAsync(searchKey);
            }
        }

        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
            try
            {
                if (e.Argument is not string searchText)
                    return;

                var dataTable = new DataTable();
                dataTable.Columns.AddRange(AccountableFormColumns());

                DataTable dtAccountableFormsFromDb = AccFactory.AccountableFormsRepository().GetRecordsBySearch(searchText); ;

                if (dtAccountableFormsFromDb.Rows.Count < 1)
                {
                    backgroundWorker1.ReportProgress(100);
                    e.Result = dataTable;
                    return;
                }

                int totalProgressCount = dtAccountableFormsFromDb.Rows.Count;
                int progressCount = 0;

                foreach (DataRow row in dtAccountableFormsFromDb.Rows)
                {
                    var newRow = dataTable.NewRow();
                    int id = Convert.ToInt32(row["id"]);
                    string accountableFormCode = row["acc_form_no"].ToString();
                    string accountableFormDesc = row["acc_form_desc"].ToString();
                    decimal accountableFormFaceValue = row.IsNull("amount") ? 0 : Convert.ToDecimal(row["amount"]);

                    newRow["id"] = id;
                    newRow["form_code"] = accountableFormCode;
                    newRow["form_description"] = accountableFormDesc;
                    newRow["form_face_value"] = accountableFormFaceValue;

                    progressCount++;
                    dataTable.Rows.Add(newRow);

                    Helper.ProgressCounter(backgroundWorker1, totalProgressCount, progressCount);
                }

                e.Result = dataTable;
            }
            catch (Exception ex) { Helper.MessageBoxError(ex.Message); }
        }

        private void backgroundWorker1_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            pbLoadRecords.Value = e.ProgressPercentage;
        }

        private void backgroundWorker1_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (e.Cancelled)
                return;

            if (e.Result is not DataTable dataTable)
                return;

            HelperLoadRecords.AccFormDatagridView(dataTable, dgAccountableForm);
            dgAccountableForm.CurrentCell = dgAccountableForm.FirstDisplayedCell;
            lblRecordCount.Text = dgAccountableForm.RowCount.ToString();
        }

        //Face Value
        private void LoadFaceValues(int accountableFormId)
        {

            var dtFaceValue = AccFactory.FaceValueRepository().GetRecordsByAccountableFormId(accountableFormId);
            HelperLoadRecords.FaceValueDatagridView(dtFaceValue, dgfacevalue);
        }
    }
}