using ACC.Domain.Models;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
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


        internal void LoadAccountableForms()
        {
            string searchText = txtSearch.Text.Trim();
            DataTable dtAccountableFormsFromDB;
            DataTable dtAccountableForms = new();
            dtAccountableForms.Columns.AddRange(AccountableFormColumns());

            if (string.IsNullOrWhiteSpace(searchText) || searchText.Length < 2)
                dtAccountableFormsFromDB = AccFactory.AccountableFormsRepository().GetRecords();
            else
                dtAccountableFormsFromDB = AccFactory.AccountableFormsRepository().GetRecordsBySearch(searchText);

            int rowCount = 0;
            int recordCount = dtAccountableFormsFromDB.Rows.Count;

            foreach (DataRow row in dtAccountableFormsFromDB.Rows)
            {
                var newRow = dtAccountableForms.NewRow();
                int id = Convert.ToInt32(row["id"]);
                string accountableFormCode = row["acc_form_no"].ToString();
                string accountableFormDesc = row["acc_form_desc"].ToString();
                decimal accountableFormFaceValue = row.IsNull("amount") ? 0 : Convert.ToDecimal(row["amount"]);

                rowCount++;
                int progressBarPercentage = (rowCount * 100) / recordCount;
                backgroundWorker1.ReportProgress(progressBarPercentage);

                dtAccountableForms.Rows.Add(newRow);
            }

            HelperLoadRecords.AccFormDatagridView(dtAccountableFormsFromDB, dgAccountableForm);

            lblRecordCount.Text = dgAccountableForm.Rows.Count.ToString();
        }

        internal void LoadRecords()
        {
            if (!backgroundWorker1.IsBusy)
            {
                pbLoadRecords.Value = 0;
                backgroundWorker1.RunWorkerAsync();
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            _ = new frmAddAccountableForm(this).ShowDialog();
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
            catch (Exception ex)
            {
                Helper.MessageBoxError(ex.Message);
            }
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

            if (selectedRowCount > 0 && selectedRowCount == 1)
                btnFaceValue.Enabled = true;
            else
                btnFaceValue.Enabled = false;
        }

        private void frmAccountable_Load(object sender, EventArgs e)
        {
            try
            {
                LoadRecords();
            }
            catch (Exception ex) { Helper.MessageBoxError(ex.Message); }
        }


        private void backgroundWorker1_DoWork(object sender, System.ComponentModel.DoWorkEventArgs e)
        {
            Invoke((MethodInvoker)delegate
            {
                LoadAccountableForms();
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