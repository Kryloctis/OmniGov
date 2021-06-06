using ACC.Domain.Models;
using AccountingSystem.Views.Manage.AllotmentRelease;
using AccountingSystem.Views.Manage.SupplementalAppropriations;
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
            Helper.LoadFormIcon(this);
            nudYear.Value = DateTime.Now.Year;
        }

        private void dgBudgetAppropriations_SelectionChanged(object sender, EventArgs e)
        {
            EnableDisableButtonsLocal(dgBudgetAppropriations);
        }

        internal void LoadBudgetAppropriationRecords()
        {
            dgBudgetAppropriations.SelectionChanged -= new System.EventHandler(dgBudgetAppropriations_SelectionChanged);

            var rowIndex = dgFPP.CurrentCell.RowIndex;

            int fppID = Convert.ToInt32(dgFPP.Rows[rowIndex].Cells["id"].Value);
            int allotmentClassID = Convert.ToInt32(cmbxAllotmentClass.SelectedValue);
            int fundId = Convert.ToInt32(cmbxFunds.SelectedValue);
            short year = Convert.ToInt16(nudYear.Value);

            HelperLoadRecords.BudgetAppropriationsDatagridView(dgBudgetAppropriations, fppID, allotmentClassID, fundId, year, txtTotal);

            dgBudgetAppropriations.SelectionChanged += new System.EventHandler(dgBudgetAppropriations_SelectionChanged);
            EnableDisableButtonsLocal(dgBudgetAppropriations);
        }

        internal void LoadComboboxes()
        {
            try
            {
                HelperLoadRecords.BudgetAppropriationsAllotmentCombobox(Factory.AllotmentClassesRepository().GetRecords(), cmbxAllotmentClass, "allotment_code", "id");
                HelperLoadRecords.BudgetAppropriationsTypeOfFundsCombobox(Factory.FundsRepository().GetRecords(), cmbxFunds, "fund_name", "id");
            }
            catch (Exception ex)
            {

                Helper.MessageBoxError(ex.Message);

            }
        }

        internal void EnableDisableButtonsLocal(DataGridView dgv)
        {
            int SelectedRows = 0;

            foreach (DataGridViewRow row in dgv.SelectedRows)
            {
                if (row.Cells["fpp_id"].Value != null)
                    SelectedRows += 1;
                else
                    row.Cells["fpp_id"].Selected = false;
            }

            if (SelectedRows == 1 && dgv.SelectedCells[0].Value != null)
            {
                btnEdit.Enabled = true;
                btnDelete.Enabled = true;
                btnDelete.Text = "Delete (" + SelectedRows + ")";

            }
            else if (SelectedRows > 1 && dgv.SelectedCells[0].Value != null)
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

        private void btnAdd_Click(object sender, EventArgs e) 
        {
            var frmBudgetAppropriationsAdd = new frmBudgetAppropriationsAdd(this);
            var ucBudgetAppropriationsAdd = frmBudgetAppropriationsAdd.ucBudgetAppropriations1;
            int rowIndex = dgFPP.CurrentCell.RowIndex;

            ucBudgetAppropriationsAdd.fppId = Convert.ToInt32(dgFPP.Rows[rowIndex].Cells["id"].Value);
            ucBudgetAppropriationsAdd.fundId = Convert.ToInt32(cmbxFunds.SelectedValue);
            ucBudgetAppropriationsAdd.allotmentClassId = Convert.ToInt32(cmbxAllotmentClass.SelectedValue);
            ucBudgetAppropriationsAdd.year = Convert.ToInt16(nudYear.Value);
            
            frmBudgetAppropriationsAdd.ShowDialog();
        }

        private void ShowBudgetAppropriationsEdit()
        {
            var frmBudgetAppropriationEdit = new frmBudgetAppropriationsEdit(this);
            var uc = frmBudgetAppropriationEdit.ucBudgetAppropriations1;
            var rowIndex = dgBudgetAppropriations.CurrentCell.RowIndex;

            int budgetAppId = Convert.ToInt32(dgBudgetAppropriations.Rows[rowIndex].Cells["id"].Value);
            int fundId = Convert.ToInt32(dgBudgetAppropriations.Rows[rowIndex].Cells["funds_id"].Value);
            int fppId = Convert.ToInt32(dgBudgetAppropriations.Rows[rowIndex].Cells["fpp_id"].Value);
            short year = Convert.ToInt16(dgBudgetAppropriations.Rows[rowIndex].Cells["year"].Value);
            int? othersFPPId = dgBudgetAppropriations.Rows[rowIndex].Cells["others_fpp_id"].Value == null? null: Convert.ToInt32(dgBudgetAppropriations.Rows[rowIndex].Cells["others_fpp_id"].Value);
            int allotmentClassesId = Convert.ToInt32(dgBudgetAppropriations.Rows[rowIndex].Cells["allotment_class_id"].Value);
            int genLedgerAccId = Convert.ToInt32(dgBudgetAppropriations.Rows[rowIndex].Cells["general_ledger_accounts_id"].Value);
            decimal totalAllotmentRelease = Convert.ToDecimal(dgBudgetAppropriations.Rows[rowIndex].Cells["totalAllotmentRelease"].Value);

            uc.budgetAppropriationId = budgetAppId;
            uc.fundId = fundId;
            uc.fppId = fppId;
            uc.year = year;
            uc.othersFPPId = othersFPPId;
            uc.allotmentClassId = allotmentClassesId;
            uc.generalLedgerAccountId = genLedgerAccId;
            uc.totalAllotmentRelease = totalAllotmentRelease;

            frmBudgetAppropriationEdit.ShowDialog();
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            ShowBudgetAppropriationsEdit();
        }

        private void btnDelete_Click(object sender, EventArgs e) 
        {
            int selectedRows =0;

            var budgetAppropriationsModelList = new List<BudgetAppropriationsModel>();

     
            foreach (DataGridViewRow row in dgBudgetAppropriations.SelectedRows)
            {
                if (row.Cells[0].Value != null)
                    selectedRows += 1;
            }

            try
            {
                if (selectedRows > 0)
                {
                    if (Helper.MessageBoxConfirmDelete(selectedRows))
                    {
                        foreach (DataGridViewRow row in dgBudgetAppropriations.SelectedRows)
                        {
                            if (row.Cells[0].Value != null)
                            {
                                int budgetAppID = int.Parse(row.Cells[0].Value.ToString());
                                var budgetAppropriationsModel = new BudgetAppropriationsModel()
                                {
                                    Id = budgetAppID
                                };

                                budgetAppropriationsModelList.Add(budgetAppropriationsModel);
                            }
                        }

                        _ = Factory.BudgetAppropriationsRepository().Delete(budgetAppropriationsModelList);
                        LoadBudgetAppropriationRecords();
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

        private void NudYear_ValueChanged(object sender, EventArgs e)
        {
            LoadBudgetAppropriationRecords();
        }

        private void frmBudgetAppropriationsNew_Load(object sender, EventArgs e)
        {
            LoadComboboxes();

            Helper.DatagridFullRowSelectStyle(dgFPP, true);
            Helper.DatagridFullRowSelectStyle(dgBudgetAppropriations, true);

            HelperLoadRecords.FPPBudgetAppropriationsDatagridView(Factory.FunctionProgramProjectRepository().GetRecords(), dgFPP);
            dgFPP.MultiSelect = false;

            cmbxAllotmentClass.SelectedValueChanged += new EventHandler(cmbxAllotmentClass_SelectedValueChanged);
            cmbxFunds.SelectedValueChanged += new EventHandler(cmbxFundType_SelectedValueChanged);
            nudYear.ValueChanged += new EventHandler(NudYear_ValueChanged);
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

            EnableDisableButtonsLocal(dgBudgetAppropriations);
        }

        private void dgFPP_RowHeaderMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            LoadBudgetAppropriationRecords();
        }

        #endregion Events Methods

    }
}
