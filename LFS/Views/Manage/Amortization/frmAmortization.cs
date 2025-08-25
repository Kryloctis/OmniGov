using ACC.Data;
using ACC.Domain.Models;
using LFS.Helpers;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace LFS.Views.Manage.Amortization
{
    public partial class frmAmortization : Form
    {
        public frmAmortization()
        {
            InitializeComponent();
            Helper.LoadFormIcon(this);
            Helper.DatagridFullRowSelectStyle(dgAmortization, true);
        }

        internal void LoadAmortizationRecords()
        {
            try
            {
                var dtAmortizationRecords = AccFactory.AmortizationRepository().GetRecords();
                HelperLoadRecords.AmortizationDataGridView(dtAmortizationRecords, dgAmortization);
            }
            catch (Exception ex)
            {
                Helper.MessageBoxError(ex.Message);
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            _ = new frmAddAmortization(this).ShowDialog();
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            int amortizationId = Convert.ToInt32(dgAmortization.CurrentRow.Cells["id"].Value);

            var frmEditAmortization = new frmEditAmortization(this);
            frmEditAmortization.amortizationId = amortizationId;
            frmEditAmortization.ShowDialog();
        }

        private void btnAmortizationSched_Click(object sender, EventArgs e)
        {
            int rowIndex = dgAmortization.CurrentRow.Index;
            var frmAmortizationSchedule = new frmAmortizationSchedule();
            frmAmortizationSchedule.amortizationId = Convert.ToInt32(dgAmortization.Rows[rowIndex].Cells["id"].Value);
            frmAmortizationSchedule.amortizationTerm = dgAmortization.Rows[rowIndex].Cells["amortization_term"].Value.ToString();
            frmAmortizationSchedule.ShowDialog();
        }

        private void frmAmortization_Load(object sender, EventArgs e)
        {
            if (!DesignMode)
            {
                LoadAmortizationRecords();
                EnableDisableButons();
            }
        }

        private void dgAmortization_ColumnAdded(object sender, DataGridViewColumnEventArgs e)
        {
            foreach (DataGridViewColumn column in dgAmortization.Columns)
            {
                column.SortMode = DataGridViewColumnSortMode.NotSortable;
            }
        }

        private void EnableDisableButons()
        {
            Helper.EnableDisableToolStripButtons(dgAmortization, btnEdit, btnDelete);

            if (dgAmortization.SelectedRows.Count == 1)
                btnAmortizationSched.Enabled = true;
            else
                btnAmortizationSched.Enabled = false;
        }

        private void dgAmortization_SelectionChanged(object sender, EventArgs e)
        {
            EnableDisableButons();
        }

        private bool DeleteAmortizationRecords()
        {
            try
            {
                var amortizationModelList = new List<AmortizationModel>();

                foreach (DataGridViewRow row in dgAmortization.SelectedRows)
                {
                    int amortizationId = int.Parse(row.Cells[0].Value.ToString());
                    var amortizationModel = new AmortizationModel()
                    {
                        Id = amortizationId
                    };

                    amortizationModelList.Add(amortizationModel);
                }

                return AccFactory.AmortizationRepository().Delete(amortizationModelList);
            }
            catch (Exception ex)
            {
                Helper.MessageBoxError(ex.Message);
            }
            return false;
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                int selectedRowsCount = dgAmortization.SelectedRows.Count;

                if (selectedRowsCount > 0)
                {
                    if (Helper.MessageBoxConfirmDelete(selectedRowsCount))
                    {
                        if (DeleteAmortizationRecords())
                        {
                            LoadAmortizationRecords();
                            Helper.MessageBoxSuccess("Amortization/s has been deleted.");
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Helper.MessageBoxError(ex.Message);
            }
        }
    }
}