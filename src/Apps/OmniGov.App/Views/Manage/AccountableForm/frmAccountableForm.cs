using MySql.Data.MySqlClient;
using OmniGov.App.Helpers;
using OmniGov.Core.Entities;
using OmniGov.Core.Factories;
using OmniGov.Treasury.Data.Factories;
using OmniGov.Treasury.Domain.Entities;
using System.ComponentModel;
using System.Data;

namespace OmniGov.App.Views.Manage.AccountableForm
{
    public partial class frmAccountableForm : Form
    {
        public frmAccountableForm()
        {
            InitializeComponent();
            Helper.LoadFormIcon(this);
            Helper.DatagridFullRowSelectStyle(dgAccountableForm, true);
            Helper.DatagridFullRowSelectStyle(dgfacevalue, true);
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
                if (DeleteData())
                {
                    LoadRecords();
                }
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

        private bool DeleteData()
        {
            int selectedrowscount = dgAccountableForm.SelectedRows.Count;

            if (Helper.MessageBoxConfirmDelete(selectedrowscount))
            {
                var accModelList = new List<AccountableFormsModel>();
                foreach (DataGridViewRow row in dgAccountableForm.SelectedRows)
                {
                    int rowId = Convert.ToInt16(row.Cells["id"].Value.ToString());
                    accModelList.Add(new AccountableFormsModel() { Id = rowId });
                }

                return TreasuryFactory.AccountableFormsRepository().Delete(accModelList);
            }
            return false;
        }

        private void EnableDisableContent()
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

        private void dgAccountableForm_SelectionChanged(object sender, EventArgs e)
        {
            try
            {
                EnableDisableContent();
            }
            catch (Exception ex) { Helper.MessageBoxError(ex.Message); }
        }

        private void frmAccountable_Load(object sender, EventArgs e)
        {
            try
            {
                LoadRecords();
                EnableDisableContent();
                Helper.EnableDisableToolStripButtons(dgfacevalue, btnEditFV, btnDeleteFV);
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

                DataTable dtAccountableFormsFromDb = TreasuryFactory.AccountableFormsRepository().GetRecordsBySearch(searchText); ;

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

        private DataColumn[] FaceValueDataColumns()
        {
            return new DataColumn[]
            {
                new DataColumn(Name = "id", typeof(int)),
                new DataColumn(Name = "accountable_forms_id", typeof(int)),
                new DataColumn(Name = "date_effective", typeof(DateTime)),
                new DataColumn(Name = "amount", typeof(decimal)),
                new DataColumn(Name = "is_default", typeof(bool))
            };
        }

        internal void LoadFaceValues(int accountableFormId)
        {
            var dataTable = new DataTable();
            dataTable.Columns.AddRange(FaceValueDataColumns());

            var dtFaceValue = Factory.FaceValueRepository().GetRecordsByAccountableFormId(accountableFormId);

            foreach (DataRow row in dtFaceValue.Rows)
            {
                var newRow = dataTable.NewRow();
                int id = Convert.ToInt32(row["id"]);
                int accFormId = Convert.ToInt32(row["accountable_forms_id"]);
                DateTime date = Convert.ToDateTime(row["date_effective"]);
                decimal amount = Convert.ToDecimal(row["amount"]);
                bool isDefault = Convert.ToBoolean(row["is_default"]);

                newRow["id"] = id;
                newRow["accountable_forms_id"] = accFormId;
                newRow["date_effective"] = date;
                newRow["amount"] = amount;
                newRow["is_default"] = isDefault;

                dataTable.Rows.Add(newRow);
            }

            HelperLoadRecords.FaceValueDatagridView(dataTable, dgfacevalue);
        }

        private void btnAddFV_Click(object sender, EventArgs e)
        {
            try
            {
                int index = dgAccountableForm.CurrentCell.RowIndex;
                int accountableFormId = Convert.ToInt32(dgAccountableForm.Rows[index].Cells["id"].Value);

                _ = new frmAddFaceValue(this, accountableFormId).ShowDialog();
            }
            catch (Exception ex) { Helper.MessageBoxError(ex.Message); }
        }

        private void btnEditFV_Click(object sender, EventArgs e)
        {
            try
            {
                int indexFaceValue = dgfacevalue.CurrentCell.RowIndex;
                int indexAccForm = dgAccountableForm.CurrentCell.RowIndex;
                int accountableFormId = Convert.ToInt32(dgAccountableForm.Rows[indexAccForm].Cells["id"].Value);
                int faceValueId = Convert.ToInt32(dgfacevalue.Rows[indexFaceValue].Cells["id"].Value);

                _ = new frmEditFaceValue(this, accountableFormId, faceValueId).ShowDialog();
            }
            catch (Exception ex) { Helper.MessageBoxError(ex.Message); }
        }

        private bool DeleteFaceValue()
        {
            int selectedRowsCount = dgfacevalue.SelectedRows.Count;

            if (Helper.MessageBoxConfirmDelete(selectedRowsCount))
            {
                var modelList = new List<FaceValueModel>();
                foreach (DataGridViewRow row in dgfacevalue.SelectedRows)
                {
                    int rowId = Convert.ToInt16(row.Cells["id"].Value.ToString());
                    modelList.Add(new FaceValueModel() { id = rowId });
                }

                return Factory.FaceValueRepository().Delete(modelList);
            }

            return false;
        }

        private void btnDeleteFV_Click(object sender, EventArgs e)
        {
            if (DeleteFaceValue())
            {
                int index = dgAccountableForm.CurrentCell.RowIndex;
                int accountableFormId = Convert.ToInt32(dgAccountableForm.Rows[index].Cells["id"].Value);

                Helper.MessageBoxSuccess("Face Value/s has been deleted");
                LoadFaceValues(accountableFormId);
            }
        }

        private void dgfacevalue_SelectionChanged(object sender, EventArgs e)
        {
            try
            {
                Helper.EnableDisableToolStripButtons(dgfacevalue, btnEditFV, btnDeleteFV);
            }
            catch (Exception ex) { Helper.MessageBoxError(ex.Message); }
        }
    }
}