using ACC.Domain.Models;
using AccountingSystem.Views.Manage.AllotmentRelease;
using BudgetSystem.Views.BudgetAppropriations;
using BudgetSystem.Views.Manage.BudgetAppropriations;
using MySql.Data.MySqlClient;
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
            btnAllotmentRelease.Click += new EventHandler(btnAllotmentRelease_Click);
        }

        internal void RecordLocator(int fppID, int allotmentClassID, int fundID, Int16 year) 
        {
            dgFPP.ClearSelection();

            //Update FPP datagrid, Appropriations datagrid and Combobox Year before reseting user control
            HelperLoadRecords.FPPBudgetAppropriationsDatagridView(Factory.FunctionProgramProjectRepository().GetRecords(), dgFPP);

            foreach (DataGridViewRow row in dgFPP.Rows)
            {
                if (Convert.ToInt32(row.Cells["id"].Value) == fppID)
                {
                    dgFPP.CurrentCell = dgFPP.Rows[row.Index].Cells["fpp_code"];
                }
            }

            HelperLoadRecords.BudgetAppropriationsYearToolStripCombobox(Factory.BudgetAppropriationsRepository().GetYearsBudgetAppropriations(), cmbxYear, "year", "year");

            HelperLoadRecords.BudgetAppropriationsDatagridView(dgBudgetAppropriations, fppID, allotmentClassID, fundID, year, txtTotal);
        }

        internal void LoadBudgetAppropriationRecords()
        {
            int fppID = Convert.ToInt32(dgFPP.SelectedCells[0].Value);
            int allotmentClassID = Convert.ToInt32(cmbxAllotmentClass.ComboBox.SelectedValue);
            int typeOfFundID = Convert.ToInt32(cmbxFundType.ComboBox.SelectedValue);
            short year = Convert.ToInt16(cmbxYear.ComboBox.SelectedValue);

            HelperLoadRecords.BudgetAppropriationsDatagridView(dgBudgetAppropriations, fppID, allotmentClassID, typeOfFundID, year, txtTotal);
        }

        internal void LoadComboboxes()
        {
            try
            {
                HelperLoadRecords.BudgetAppropriationsAllomentToolStripCombobox(Factory.AllotmentClassesRepository().GetRecords(), cmbxAllotmentClass, "allotment_code", "id");
                HelperLoadRecords.BudgetAppropriationsTypeOfFundsToolStripCombobox(Factory.FundsRepository().GetRecords(), cmbxFundType, "fund_name", "id");
                HelperLoadRecords.BudgetAppropriationsYearToolStripCombobox(Factory.BudgetAppropriationsRepository().GetYearsBudgetAppropriations(), cmbxYear, "year", "year");
            }
            catch (Exception ex)
            {

                Helper.MessageBoxError(ex.Message);

            }
        }

        internal void EnableDisableButtonsLocal(DataGridView dgv, ToolStripButton btnEdit, ToolStripButton btnDelete)
        {
            int SelectedRows = dgv.SelectedRows.Count;

            if (SelectedRows == 1 && dgv.SelectedCells[0].Value != null)
            {
                btnEdit.Enabled = true;
                btnAllotmentRelease.Enabled = true;
                btnDelete.Enabled = true;
                btnDelete.Text = "Delete (" + SelectedRows + ")";

            }
            else if (SelectedRows > 1 && dgv.SelectedCells[0].Value != null)
            {
                btnEdit.Enabled = false;
                btnAllotmentRelease.Enabled = false;
                btnDelete.Enabled = true;
                btnDelete.Text = "Delete (" + SelectedRows + ")";
            }
            else
            {
                btnEdit.Enabled = false;
                btnAllotmentRelease.Enabled = false;
                btnDelete.Enabled = false;
                btnDelete.Text = "Delete";
            }

            foreach (DataGridViewRow row in dgBudgetAppropriations.SelectedRows)
            {
                if (row.Cells[0].Value == null)
                {
                    btnDelete.Enabled = false;
                    btnDelete.Text = "Delete";
                }
            }

        }

        private void ShowAllotmentRelease()
        {
            var frmAllotmentReleaseForm = new frmAllotmentRelease(this);

            var budgetAppId = Convert.ToInt32(dgBudgetAppropriations.SelectedCells[0].Value);
            var fppId = Convert.ToInt32(dgBudgetAppropriations.SelectedCells[1].Value);
            var dgothersFPPId = dgBudgetAppropriations.SelectedCells[2].Value;
            int? othersFPPId = string.IsNullOrEmpty(dgothersFPPId.ToString()) ? null : Convert.ToInt32(dgothersFPPId);
            var allotmentClassesId = Convert.ToInt32(dgBudgetAppropriations.SelectedCells[3].Value);
            var genLedgerAccId = Convert.ToInt32(dgBudgetAppropriations.SelectedCells[4].Value);

            frmAllotmentReleaseForm.budgetAppropriationID = budgetAppId;
            frmAllotmentReleaseForm.fppID = fppId;
            frmAllotmentReleaseForm.othersFPPID = othersFPPId;
            frmAllotmentReleaseForm.allotmentClassesID = allotmentClassesId;
            frmAllotmentReleaseForm.generalLedgerAccID = genLedgerAccId;

            frmAllotmentReleaseForm.ShowDialog();
        }

        #region Events Method

        private void cmbxAllotmentClass_SelectedValueChanged(object sender, EventArgs e) 
        {
            if(dgFPP.SelectedRows.Count == 1)
            LoadBudgetAppropriationRecords();
        }

        private void cmbxFundType_SelectedValueChanged(object sender, EventArgs e) 
        {
            if (dgFPP.SelectedRows.Count == 1)
                LoadBudgetAppropriationRecords();
        }

        private void cmbxYear_SelectedValueChanged(object sender, EventArgs e) 
        {
            if (dgFPP.SelectedRows.Count == 1)
                LoadBudgetAppropriationRecords();
        }

        private void btnAdd_Click(object sender, EventArgs e) 
        {
            _ = new frmBudgetAppropriationsAdd(this).ShowDialog();
        }

        private void btnEdit_Click(object sender, EventArgs e) 
        {
            var frmBudgetAppropriationEdit = new frmBudgetAppropriationsEdit(this);

            var uc = frmBudgetAppropriationEdit.ucBudgetAppropriations1;
            var budgetAppId = dgBudgetAppropriations.SelectedCells[0].Value;
            var fppId = dgBudgetAppropriations.SelectedCells[1].Value;
            var dgothersFPPId = dgBudgetAppropriations.SelectedCells[2].Value;
            int? othersFPPId;
            var allotmentClassesId = dgBudgetAppropriations.SelectedCells[3].Value;
            var genLedgerAccId = dgBudgetAppropriations.SelectedCells[4].Value;

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
                            int budgetAppID = int.Parse(row.Cells[0].Value.ToString());
                            var budgetAppropriationsModel = new BudgetAppropriationsModel()
                            {
                                ID = budgetAppID
                            };

                            budgetAppropriationsModelList.Add(budgetAppropriationsModel);
                        }

                        _ = Factory.BudgetAppropriationsRepository().Delete(budgetAppropriationsModelList);
                        LoadBudgetAppropriationRecords();
                        HelperLoadRecords.FPPBudgetAppropriationsDatagridView(Factory.FunctionProgramProjectRepository().GetRecords(), dgFPP);
                        HelperLoadRecords.BudgetAppropriationsYearToolStripCombobox(Factory.BudgetAppropriationsRepository().GetYearsBudgetAppropriations(), cmbxYear, "year", "year");
                    }
                }
            }
            catch (MySqlException ex) 
            {
                switch (ex.Number)
                {
                    case 1451:
                        Helper.MessageBoxError("Cannot Delete Budget Appropriation");
                        break;
                }
            }

            catch (Exception ex)
            {
                Helper.MessageBoxError(ex.Message);
            }
        }

        private void btnAllotmentRelease_Click(object sender, EventArgs e) 
        {
            ShowAllotmentRelease();
        }

        private void frmBudgetAppropriationsNew_Load(object sender, EventArgs e)
        {
            LoadComboboxes();

            Helper.DatagridFullRowSelectStyle(dgFPP, true);
            Helper.DatagridFullRowSelectStyle(dgBudgetAppropriations, true);

            HelperLoadRecords.FPPBudgetAppropriationsDatagridView(Factory.FunctionProgramProjectRepository().GetRecords(), dgFPP);       

            cmbxAllotmentClass.ComboBox.SelectedValueChanged += new EventHandler(cmbxAllotmentClass_SelectedValueChanged);
            cmbxFundType.ComboBox.SelectedValueChanged += new EventHandler(cmbxFundType_SelectedValueChanged);
            cmbxYear.ComboBox.SelectedValueChanged += new EventHandler(cmbxYear_SelectedValueChanged);
        }

        private void dataGridView1_ColumnAdded(object sender, DataGridViewColumnEventArgs e)
        {
            dgBudgetAppropriations.Columns[e.Column.Index].SortMode = DataGridViewColumnSortMode.NotSortable;
        }

        private void dgFPP_SelectionChanged(object sender, EventArgs e)
        {
            int selectedRows = dgFPP.SelectedRows.Count;
            if (selectedRows > 0)
                LoadBudgetAppropriationRecords();

            EnableDisableButtonsLocal(dgBudgetAppropriations, btnEdit, btnDelete);
        }

        private void dgFPP_RowHeaderMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            LoadBudgetAppropriationRecords();
        }

        #endregion Events Method

        private void dgBudgetAppropriations_SelectionChanged(object sender, EventArgs e)
        {
            EnableDisableButtonsLocal(dgBudgetAppropriations, btnEdit, btnDelete);
        }
    }
}
