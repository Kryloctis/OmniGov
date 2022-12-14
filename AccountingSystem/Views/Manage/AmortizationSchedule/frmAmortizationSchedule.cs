using ACC.Domain.Models;
using AccountingSystem.Views.Manage.AmortizationSchedule;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace AccountingSystem.Views.Manage.Amortization
{
    public partial class frmAmortizationSchedule : Form
    {
        internal int amortizationId;
        internal string amortizationTerm;

        public frmAmortizationSchedule()
        {
            InitializeComponent();
            Helper.LoadFormIcon(this);
            Helper.DatagridFullRowSelectStyle(dgAmortizationSched, true);
        }

        internal void LoadRecords()
        {
            var dtAmortizationSheduleRecords = AccFactory.AmortizationScheduleRepository().GetRecordsByAmortizationId(amortizationId);

            HelperLoadRecords.DatagridViewAmortizationSchedule(dtAmortizationSheduleRecords, amortizationTerm, dgAmortizationSched);
        }

        private void frmAmortizationSchedule_Load(object sender, EventArgs e)
        {
            LoadRecords();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            var frmAddAmortizationSchedule = new frmAddAmortizationSchedule(this);
            frmAddAmortizationSchedule.amortizationId = amortizationId;
            frmAddAmortizationSchedule.amortizationTerm = amortizationTerm;
            frmAddAmortizationSchedule.ShowDialog();
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            int rowIndex = dgAmortizationSched.CurrentRow.Index;

            var frmEditAmortizationSchedule = new frmEditAmortizationSchedule(this);
            frmEditAmortizationSchedule.amortizationId = amortizationId;
            frmEditAmortizationSchedule.amortizationTerm = amortizationTerm;
            frmEditAmortizationSchedule.amortizationScheduleId = Convert.ToInt32(dgAmortizationSched.Rows[rowIndex].Cells["id"].Value);
            frmEditAmortizationSchedule.ShowDialog();
        }

        private void dgAmortizationSched_ColumnAdded(object sender, DataGridViewColumnEventArgs e)
        {
            foreach (DataGridViewColumn column in dgAmortizationSched.Columns)
            {
                column.SortMode = DataGridViewColumnSortMode.NotSortable;
            }
        }

        private void dgAmortizationSched_SelectionChanged(object sender, EventArgs e)
        {
            Helper.EnableDisableToolStripButtons(dgAmortizationSched, btnEdit, btnDelete);
        }

        private bool DeleteAmortizationScheduleRecords()
        {
            try
            {
                var amortizationScheduleModelList = new List<AmortizationScheduleModel>();

                foreach (DataGridViewRow row in dgAmortizationSched.SelectedRows)
                {
                    int amortizationId = int.Parse(row.Cells[0].Value.ToString());
                    var amortizationScheduleModel = new AmortizationScheduleModel()
                    {
                        Id = amortizationId
                    };

                    amortizationScheduleModelList.Add(amortizationScheduleModel);
                }

                return AccFactory.AmortizationScheduleRepository().Delete(amortizationScheduleModelList);
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
                int selectedRowsCount = dgAmortizationSched.SelectedRows.Count;

                if (selectedRowsCount > 0)
                {
                    if (Helper.MessageBoxConfirmDelete(selectedRowsCount))
                    {
                        if (DeleteAmortizationScheduleRecords())
                        {
                            LoadRecords();
                            Helper.MessageBoxSuccess("Amortization Schedule/s has been deleted.");
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