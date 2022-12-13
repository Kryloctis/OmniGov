using ACC.Domain.Models;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace AccountingSystem.Views.Manage.RptTaxRates
{
    public partial class frmRptTaxRates : Form
    {
        private readonly MainForm _mainForm;

        public frmRptTaxRates(MainForm mainForm)
        {
            InitializeComponent();
            _mainForm = mainForm;
            Helper.LoadFormIcon(this);
            Helper.DatagridFullRowSelectStyle(dataGridView1, true);
        }

        private void UpdateRecordCount(DataGridView dataGridView)
        {
            int recordCount = dataGridView.Rows.Count;
            lblRecordCount.Text = recordCount.ToString();
        }

        internal void LoadTaxRates()
        {
            string searchText = txtSearch.Text.Trim();

            if (searchText.Length < 2)
            {
                var dt = AccFactory.RptTaxRatesRepository().GetRecords();
                HelperLoadRecords.TaxRatesDatagridView(dataGridView1, dt);
            }
            else
            {
                var dt = AccFactory.RptTaxRatesRepository().GetRecordsBySearch(searchText);
                HelperLoadRecords.TaxRatesDatagridView(dataGridView1, dt);
            }

            UpdateRecordCount(dataGridView1);
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            _ = new frmAddRptTaxRate(this).ShowDialog();
        }

        private void ShowEditForm()
        {
            try
            {
                int rowIndex = dataGridView1.CurrentCell.RowIndex;
                int rptTaxRatesId = Convert.ToInt32(dataGridView1.Rows[rowIndex].Cells["id"].Value);

                _ = new frmEditRptTaxRates(rptTaxRatesId, this).ShowDialog();
            }
            catch (Exception ex)
            {
                Helper.MessageBoxError(ex.Message);
            }
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            ShowEditForm();
        }

        private bool Delete(out int deletedCount)
        {
            try
            {
                var rptTaxRatesModelList = new List<RptTaxRatesModel>();
                int rowCount = dataGridView1.SelectedRows.Count;

                if (Helper.MessageBoxConfirmDelete(rowCount))
                {
                    foreach (DataGridViewRow row in dataGridView1.SelectedRows)
                    {
                        int penaltiesId = Convert.ToInt32(row.Cells["id"].Value);
                        var model = new RptTaxRatesModel() { Id = penaltiesId };
                        rptTaxRatesModelList.Add(model);
                    }

                    deletedCount = rowCount;
                    return AccFactory.RptTaxRatesRepository().Delete(rptTaxRatesModelList);
                }
            }
            catch (Exception ex)
            {
                Helper.MessageBoxError(ex.Message);
            }

            deletedCount = 0;
            return false;
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            int deletedRecordCount;

            if (Delete(out deletedRecordCount))
            {
                Helper.MessageBoxSuccess($"{deletedRecordCount} record/s has been deleted.");
                LoadTaxRates();
            }
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            LoadTaxRates();
        }

        private void dataGridView1_SelectionChanged(object sender, EventArgs e)
        {
            Helper.EnableDisableToolStripButtons(dataGridView1, btnEdit, btnDelete);
        }

        private void dataGridView1_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                contextMenuStrip1.Show(Cursor.Position);
            }
        }

        private void frmRptTaxRates_Load(object sender, EventArgs e)
        {
            LoadTaxRates();
            Helper.EnableDisableToolStripButtons(dataGridView1, btnEdit, btnDelete);
        }
    }
}