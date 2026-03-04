using OmniGov.Accounting.Data.Factories;
using OmniGov.Accounting.Domain.Entities;
using OmniGov.App.Helpers;
using OmniGov.App.Views.Manage.AmortizationSchedule;

namespace OmniGov.App.Views.Manage.Amortization
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
            var dtAmortizationRecords = AccountingFactory.AmortizationRepository().GetRecords();
            HelperLoadRecords.AmortizationDataGridView(dtAmortizationRecords, dgAmortization);
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            _ = new frmAddAmortization(this).ShowDialog();
        }

        private void btnAmortizationSched_Click(object sender, EventArgs e)
        {
            int rowIndex = dgAmortization.CurrentRow.Index;
            var frmAmortizationSchedule = new frmAmortizationSchedule();
            frmAmortizationSchedule.amortizationId = Convert.ToInt32(dgAmortization.Rows[rowIndex].Cells["id"].Value);
            frmAmortizationSchedule.amortizationTerm = dgAmortization.Rows[rowIndex].Cells["amortization_term"].Value.ToString();
            frmAmortizationSchedule.ShowDialog();
        }

        private void btnDelete_Click(object sender, EventArgs e)
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

        private void btnEdit_Click(object sender, EventArgs e)
        {
            int amortizationId = Convert.ToInt32(dgAmortization.CurrentRow.Cells["id"].Value);

            var frmEditAmortization = new frmEditAmortization(this);
            frmEditAmortization.amortizationId = amortizationId;
            frmEditAmortization.ShowDialog();
        }

        private bool DeleteAmortizationRecords()
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

            return AccountingFactory.AmortizationRepository().Delete(amortizationModelList);
        }

        private void dgAmortization_ColumnAdded(object sender, DataGridViewColumnEventArgs e)
        {
            foreach (DataGridViewColumn column in dgAmortization.Columns)
            {
                column.SortMode = DataGridViewColumnSortMode.NotSortable;
            }
        }

        private void dgAmortization_SelectionChanged(object sender, EventArgs e)
        {
            EnableDisableButons();
        }

        private void EnableDisableButons()
        {
            Helper.EnableDisableToolStripButtons(dgAmortization, btnEdit, btnDelete);

            if (dgAmortization.SelectedRows.Count == 1)
                btnAmortizationSched.Enabled = true;
            else
                btnAmortizationSched.Enabled = false;
        }

        private void frmAmortization_Load(object sender, EventArgs e)
        {
            if (!DesignMode)
            {
                LoadAmortizationRecords();
                EnableDisableButons();
            }
        }
    }
}