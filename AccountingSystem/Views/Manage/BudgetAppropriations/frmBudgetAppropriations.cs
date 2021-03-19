using ACC.Domain.Models;
using BudgetSystem.Views.BudgetAppropriations;
using BudgetSystem.Views.Manage.BudgetAppropriations;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AccountingSystem.Views.Manage.BudgetAppropriations
{
    public partial class frmBudgetAppropriations : Form
    {
        public frmBudgetAppropriations()
        {
            InitializeComponent();
        }

        internal void LoadRecords()
        {
            HelperLoadRecords.BudgetAppropriationsDataGridView(dgBudgetAppropriations, dgFPP, cmbxAllotmentClass, cmbxFundType, cmbxYear);

            //Show Total Value 
            txtTotal.Text = (from DataGridViewRow row in dgBudgetAppropriations.Rows
                             where !String.IsNullOrEmpty(row.Cells[8].FormattedValue.ToString())
                             select Convert.ToDecimal(row.Cells[8].FormattedValue)).Sum().ToString("N2");
        }

        internal void LoadComboboxes()
        {
            try
            {
                HelperLoadRecords.AllomentToolStripCombobox(Factory.AllotmentClassesRepository().GetRecords(), cmbxAllotmentClass, "allotment_code", "id");
                HelperLoadRecords.TypeOfFundsCombobox(Factory.FundsRepository().GetRecords(), cmbxFundType, "fund_name", "id");
                HelperLoadRecords.YearCombobox(Factory.BudgetAppropriationsRepository().GetYearsBudgetAppropriations(), cmbxYear, "year", "year");
            }
            catch (Exception ex)
            {

                Helper.MessageBoxError(ex.Message);

            }
        }

        internal void EnableDisableButtonsLocal(DataGridView dgv, ToolStripButton btnEdit, ToolStripButton btnDelete)
        {
            int SelectedRows = dgv.SelectedRows.Count;

            if (SelectedRows == 1 && dgv.SelectedCells[1].Value != null)
            {
                btnEdit.Enabled = true;
                btnDelete.Enabled = true;
                btnDelete.Text = "Delete (" + SelectedRows + ")";

            }
            else if (SelectedRows > 1 && dgv.SelectedCells[1].Value != null)
            {
                btnEdit.Enabled = false;
                btnDelete.Enabled = true;
                btnDelete.Text = "Delete (" + SelectedRows + ")";
            }
            else
            {
                btnEdit.Enabled = false;
                btnDelete.Enabled = false;
                btnDelete.Text = "Delete";
            }

            foreach (DataGridViewRow row in dgBudgetAppropriations.SelectedRows)
            {
                if (row.Cells[1].Value == null)
                {
                    btnDelete.Enabled = false;
                    btnDelete.Text = "Delete";
                }
            }

        }

        #region Events Method

        private void cmbxAllotmentClass_SelectedValueChanged(object sender, EventArgs e) 
        {
            if(dgFPP.SelectedRows.Count == 1)
            LoadRecords();
        }

        private void cmbxFundType_SelectedValueChanged(object sender, EventArgs e) 
        {
            if (dgFPP.SelectedRows.Count == 1)
                LoadRecords();
        }

        private void cmbxYear_SelectedValueChanged(object sender, EventArgs e) 
        {
            if (dgFPP.SelectedRows.Count == 1)
                LoadRecords();
        }

        private void btnAdd_Click(object sender, EventArgs e) 
        {
            _ = new frmBudgetAppropriationsAdd(this).ShowDialog();
        }

        private void btnEdit_Click(object sender, EventArgs e) 
        {
            var frmBudgetAppropriationEdit = new frmBudgetAppropriationsEdit(this);

            var uc = frmBudgetAppropriationEdit.ucBudgetAppropriations1;
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
            
            uc.budgetAppropriationId = Convert.ToInt32(budgetAppId);
            uc.fppId = Convert.ToInt32(fppId);
            uc.othersFPPId = othersFPPId;
            uc.allotmentClassesId = Convert.ToInt32(allotmentClassesId);
            uc.generalLedgerAccId = Convert.ToInt32(genLedgerAccId);

            frmBudgetAppropriationEdit.ShowDialog();
        }

        private void btnDelete_Click(object sender, EventArgs e) 
        {
            int selectedRowsCount = dgBudgetAppropriations.SelectedRows.Count;

            var budgetAppropriationsModelList = new List<BudgetAppropriationsModel>();

            try
            {
                if (selectedRowsCount > 0)
                {
                    if (Helper.MessageBoxConfirmDelete(selectedRowsCount))
                    {
                        foreach (DataGridViewRow row in dgBudgetAppropriations.SelectedRows)
                        {
                            int budgetAppID = int.Parse(row.Cells[1].Value.ToString());
                            var budgetAppropriationsModel = new BudgetAppropriationsModel()
                            {
                                ID = budgetAppID
                            };

                            budgetAppropriationsModelList.Add(budgetAppropriationsModel);
                        }

                        _ = Factory.BudgetAppropriationsRepository().Delete(budgetAppropriationsModelList);
                        LoadRecords();
                    }
                }
            }
            catch (Exception ex)
            {
                Helper.MessageBoxError(ex.Message);
            }
        }

        private void frmBudgetAppropriationsNew_Load(object sender, EventArgs e)
        {
            HelperLoadRecords.FPPDatagridViewRecords(dgFPP);
            Helper.DatagridDefaultStyle(dgBudgetAppropriations, true);
            LoadComboboxes();
            cmbxAllotmentClass.ComboBox.SelectedValueChanged += new EventHandler(cmbxAllotmentClass_SelectedValueChanged);
            cmbxFundType.ComboBox.SelectedValueChanged += new EventHandler(cmbxFundType_SelectedValueChanged);
            cmbxYear.ComboBox.SelectedValueChanged += new EventHandler(cmbxYear_SelectedValueChanged);
        }

        private void dataGridView1_ColumnAdded(object sender, DataGridViewColumnEventArgs e)
        {
            dgBudgetAppropriations.Columns[e.Column.Index].SortMode = DataGridViewColumnSortMode.NotSortable;
        }

        private void dgFPP_RowHeaderMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            LoadRecords();
        }

        #endregion Events Method

        private void dgBudgetAppropriations_SelectionChanged(object sender, EventArgs e)
        {
            EnableDisableButtonsLocal(dgBudgetAppropriations, btnEdit, btnDelete);
        }

        private void dgFPP_SelectionChanged(object sender, EventArgs e)
        {
            int selectedRows = dgFPP.SelectedRows.Count;
            if(selectedRows > 0)
                LoadRecords();

            EnableDisableButtonsLocal(dgBudgetAppropriations, btnEdit, btnDelete);
        }
    }
}
