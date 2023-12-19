using ACC.Data;
using ACC.Domain.Models;
using DocumentFormat.OpenXml.Office2010.Excel;
using Google.Protobuf.WellKnownTypes;
using Microsoft.CodeAnalysis.VisualBasic.Syntax;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AccountingSystem.Views.Manage.Registry
{
    public partial class frmRegistry : Form
    {
        public frmRegistry()
        {
            InitializeComponent();
            Helper.LoadFormIcon(this);
            Helper.DatagridFullRowSelectStyle(dataGridView1, true);
        }

        internal void LoadRegistryList()
        {
            if (!backgroundWorker1.IsBusy)
            {
                progressBar1.Value = 0;
                backgroundWorker1.RunWorkerAsync(RegistryParameters());
            }
        }

        private void LoadRowFilter()
        {
            HelperLoadRecords.RowFilterCombobox(cmbxRowFilter);
        }

        private void OnLoad()
        {
            LoadRowFilter();
            LoadRegistryList();
            Helper.EnableDisableToolStripButtons(dataGridView1, btnEdit, btnDelete);
        }

        private bool DeleteRegistry(DataGridViewSelectedRowCollection selectedRows)
        {
            if (Helper.MessageBoxConfirmDelete(selectedRows.Count))
            {
                var registryModels = new List<RegistryModel>();

                foreach (DataGridViewRow row in selectedRows)
                    registryModels.Add(new RegistryModel() { Id = Convert.ToInt32(row.Cells["id"].Value) });

                return AccFactory.RegistryRepository().Delete(registryModels);
            }
            return false;
        }

        private (string searchKey, int limitCount) RegistryParameters()
        {
            string searchKey = txtSearch.Text.Trim();
            int limitCount = Convert.ToInt32(cmbxRowFilter.SelectedValue);

            return (searchKey, limitCount);
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                _ = new frmAddRegistry(this).ShowDialog();
            }
            catch (Exception ex) { Helper.MessageBoxError(ex.Message); }
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            try
            {
                int index = dataGridView1.CurrentCell.RowIndex;
                int registryId = Convert.ToInt32(dataGridView1.Rows[index].Cells["id"].Value);

                _ = new frmEditRegistry(registryId, this).ShowDialog();
            }
            catch (Exception ex) { Helper.MessageBoxError(ex.Message); }
        }

        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
            try
            {
                var parameters = ((string searchKey, int limitCount))e.Argument;

                var dataColumns = new DataColumn[]
                {
                    new DataColumn(Name = "id", typeof(int)),
                    new DataColumn(Name = "name", typeof(string)),
                    new DataColumn(Name = "sex", typeof(string)),
                    new DataColumn(Name = "nationality", typeof(string)),
                    new DataColumn(Name = "birth_date", typeof(DateTime)),
                    new DataColumn(Name = "birth_place", typeof(string)),
                    new DataColumn(Name = "contact_info", typeof(string))
                };

                var dataTable = new DataTable();
                dataTable.Columns.AddRange(dataColumns);
                var dtRegistry = AccFactory.RegistryRepository().GetRecordsBySearh_Limit(parameters.searchKey, parameters.limitCount);

                int progressCount = 0;
                int totalProgressCount = dtRegistry.Rows.Count;

                if (dtRegistry.Rows.Count < 1) { e.Result = dataTable; backgroundWorker1.ReportProgress(100); return; }

                foreach (DataRow row in dtRegistry.Rows)
                {
                    var newRow = dataTable.NewRow();
                    int Id = Convert.ToInt32(row["id"]);
                    string middleName = row["middle_name"].ToString();
                    string fullName = $"{row["first_name"]} {(!string.IsNullOrEmpty(middleName) ? $"{middleName.Substring(0, 1)}." : "")} {row["last_name"]}";
                    string sex = $"{row["sex"]}";
                    string nationality = $"{row["nationality"]}";
                    string birthPlace = $"{row["municipality"]}, {row["province"]}, {row["country"]}";
                    var birthDate = Convert.ToDateTime(row["birth_date"]);
                    string contactInfo = $"{row["contact_info"]}";

                    newRow["id"] = Id;
                    newRow["name"] = fullName;
                    newRow["sex"] = sex;
                    newRow["nationality"] = nationality;
                    newRow["birth_place"] = birthPlace;
                    newRow["birth_date"] = birthDate;
                    newRow["contact_info"] = contactInfo;

                    dataTable.Rows.Add(newRow);
                    progressCount++;
                    Helper.ProgressCounter(backgroundWorker1, totalProgressCount, progressCount);
                }

                e.Result = dataTable;
            }
            catch (Exception ex) { Helper.MessageBoxError(ex.Message); }
        }

        private void backgroundWorker1_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            progressBar1.Value = e.ProgressPercentage;
        }

        private void backgroundWorker1_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (e.Cancelled)
                return;
            if (e.Result is not DataTable dataTable)
                return;

            HelperLoadRecords.DatagridViewRegistry(dataTable, dataGridView1);
            dataGridView1.CurrentCell = dataGridView1.FirstDisplayedCell;
            lblRecordCount.Text = dataGridView1.Rows.Count.ToString();
        }

        private void dataGridView1_SelectionChanged(object sender, EventArgs e)
        {
            try
            {
                Helper.EnableDisableToolStripButtons(dataGridView1, btnEdit, btnDelete);
            }
            catch (Exception ex) { Helper.MessageBoxError(ex.Message); }
        }

        private void frmRegistry_Load(object sender, EventArgs e)
        {
            try
            {
                OnLoad();
            }
            catch (Exception ex) { Helper.MessageBoxError(ex.Message); }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                var selectedRows = dataGridView1.SelectedRows;
                if (DeleteRegistry(selectedRows))
                {
                    Helper.MessageBoxSuccess($"{selectedRows.Count} Record/s has been deleted");
                    LoadRegistryList();
                }
            }
            catch (Exception ex) { Helper.MessageBoxError(ex.Message); }
        }

        private void cmbxRowFilter_SelectionChangeCommitted(object sender, EventArgs e)
        {
            try
            {
                LoadRegistryList();
            }
            catch (Exception ex) { Helper.MessageBoxError(ex.Message); }
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            try
            {
                LoadRegistryList();
            }
            catch (Exception ex) { Helper.MessageBoxError(ex.Message); }
        }
    }
}