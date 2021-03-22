using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AccountingSystem.Views.Manage.AllotmentRelease
{
    public partial class frmSearchBudgetAppropriation : Form
    {

        private frmAllotmentReleaseAdd  _frmAllotmentReleaseAdd;
        public frmSearchBudgetAppropriation(frmAllotmentReleaseAdd frmAllotmentReleaseAdd)
        {
            InitializeComponent();
            _frmAllotmentReleaseAdd = frmAllotmentReleaseAdd;
            LoadComboboxes();
            HelperLoadRecords.FPPDatagridViewRecords(dgFPP);
            Helper.DatagridDefaultStyle(dgFPP);
            Helper.DatagridDefaultStyle(dgBudgetAppropriations);
            dgBudgetAppropriations.MultiSelect = false;
            dgFPP.MultiSelect = false;
        }

        internal void LoadComboboxes()
        {
            try
            {
                HelperLoadRecords.AllotmentCombobox(Factory.AllotmentClassesRepository().GetRecords(), cmboxAllotmentClass, "allotment_code", "id");
                HelperLoadRecords.TypeOfFundsCombobox(Factory.FundsRepository().GetRecords(), cmbxTypeOfFund, "fund_name", "id");
                HelperLoadRecords.YearCombobox(Factory.BudgetAppropriationsRepository().GetYearsBudgetAppropriations(), cmbxYear, "year", "year");
            }
            catch (Exception ex)
            {

                Helper.MessageBoxError(ex.Message);

            }
        }

        internal void LoadBudgetAppropriationsRecords()
        {
            int fppID = Convert.ToInt32(dgFPP.SelectedCells[0].Value);
            int allotmentClassID = Convert.ToInt32(cmboxAllotmentClass.SelectedValue);
            int typeOfFundID = Convert.ToInt32(cmbxTypeOfFund.SelectedValue);
            short year = Convert.ToInt16(cmbxYear.SelectedValue);

            HelperLoadRecords.BudgetAppropriationsDataGridView(dgBudgetAppropriations, fppID, allotmentClassID, typeOfFundID, year);
        }

        private void SelectedBudgetAppropriationsReferences() 
        {
            var uc = _frmAllotmentReleaseAdd.ucAllotmentRelease1;

            var budgetAppId = dgBudgetAppropriations.SelectedCells[1].Value;
            var fppId = dgBudgetAppropriations.SelectedCells[2].Value;
            var dgothersFPPId = dgBudgetAppropriations.SelectedCells[3].Value;
            int? othersFPPId;
            var allotmentClassesId = dgBudgetAppropriations.SelectedCells[4].Value;
            var genLedgerAccId = dgBudgetAppropriations.SelectedCells[5].Value;

            if (string.IsNullOrEmpty(dgothersFPPId.ToString()))
                othersFPPId = null;
            else
                othersFPPId = Convert.ToInt32(dgothersFPPId);

            uc.budgetAppropriationID = Convert.ToInt32(budgetAppId);
            uc.fppID = Convert.ToInt32(fppId);
            uc.othersFPPID = othersFPPId;
            uc.allotmentClassesID = Convert.ToInt32(allotmentClassesId);
            uc.generalLedgerAccID = Convert.ToInt32(genLedgerAccId);

            uc.LoadSelected();
        }

        private void dgFPP_SelectionChanged(object sender, EventArgs e)
        {
            int selectedRows = dgFPP.SelectedRows.Count;
            if (selectedRows > 0)
                LoadBudgetAppropriationsRecords();
        }

        private void dgBudgetAppropriations_ColumnAdded(object sender, DataGridViewColumnEventArgs e)
        {
            dgBudgetAppropriations.Columns[e.Column.Index].SortMode = DataGridViewColumnSortMode.NotSortable;
        }

        private void cmboxAllotmentClass_SelectedValueChanged(object sender, EventArgs e)
        {
            if (dgFPP.SelectedRows.Count == 1)
                LoadBudgetAppropriationsRecords();
        }

        private void cmbxTypeOfFund_SelectedValueChanged(object sender, EventArgs e)
        {
            if (dgFPP.SelectedRows.Count == 1)
                LoadBudgetAppropriationsRecords();
        }

        private void cmbxYear_SelectedValueChanged(object sender, EventArgs e)
        {
            if (dgFPP.SelectedRows.Count == 1)
                LoadBudgetAppropriationsRecords();
        }

        private void dgBudgetAppropriations_SelectionChanged(object sender, EventArgs e)
        {
            int selectedRows = dgBudgetAppropriations.SelectedRows.Count;

            if (selectedRows == 1 && dgBudgetAppropriations.SelectedCells[1].Value != null)
            {
                btnSelect.Enabled = true;
            }
            else
            {
                btnSelect.Enabled = false;
            }
        }

        private void btnSelect_Click(object sender, EventArgs e)
        {
            SelectedBudgetAppropriationsReferences();
            Close();
        }

        private void dgBudgetAppropriations_RowHeaderMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            SelectedBudgetAppropriationsReferences();
            Close();
        }
    }
}
