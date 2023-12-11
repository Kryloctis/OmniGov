using ACC.Data;
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

        private bool DeleteRegistry()
        {
            return false;
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
                _ = new frmEditRegistry().ShowDialog();
            }
            catch (Exception ex) { Helper.MessageBoxError(ex.Message); }
        }

        internal void LoadRegistryList()
        {
            if (!backgroundWorker1.IsBusy)
            {
                progressBar1.Value = 0;
                backgroundWorker1.RunWorkerAsync(RegistryParameters());
            }
        }

        private string RegistryParameters()
        {
            return txtSearch.Text.Trim();
        }

        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
            try
            {
                string searchKey = (string)e.Argument;

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
                var dtRegistry = AccFactory.RegistryRepository().GetRecordsBySearch(searchKey);
                int progressCount = 0;
                int totalProgressCount = dtRegistry.Rows.Count;

                if (dtRegistry.Rows.Count < 1) { e.Result = dataTable; backgroundWorker1.ReportProgress(100); return; }


                foreach (DataRow row in dtRegistry.Rows)
                {
                    var newRow = dataTable.NewRow();
                    int Id = Convert.ToInt32(row["id"]);
                    string name = $"{row["first_name"]} {row["middle_name"].ToString().Substring(0)} {row["last_name"]}";
                    string sex = $"{row["sex"]}";
                    string nationality = $"{row["nationality"]}";
                    string birthPlace = $"{row["street"]}, {row["barangay"]}, {row["municipality"]}, {row["province"]}, {row["country"]}";
                    var birthDate = Convert.ToDateTime(row["birth_date"]);
                    string contactInfo = $"{row["contact_info"]}";

                    newRow["id"] = Id;
                    newRow["name"] = name;
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

        private void OnLoad()
        {
            LoadRegistryList();
            Helper.EnableDisableToolStripButtons(dataGridView1, btnEdit, btnDelete);
        }

        private void frmRegistry_Load(object sender, EventArgs e)
        {
            try
            {
                OnLoad();
            }
            catch (Exception ex) { Helper.MessageBoxError(ex.Message); }
        }
    }
}