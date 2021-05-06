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
            btnSupplemental.Click += new EventHandler(BtnSupplemental_Click);
            btnARODetails.Click += new EventHandler(BtnARODetails_Click);
            btnARO.Click += new EventHandler(BtnARO_Click);
            Helper.LoadFormIcon(this);
        }

        private void ShowSupplementalAppropriationsForm() 
        {
            var frmSupplementalAppropriations = new frmSupplementalAppropriations(this);
            var rowIndex = dgBudgetAppropriations.CurrentCell.RowIndex;

            int budgetAppId = Convert.ToInt32(dgBudgetAppropriations.Rows[rowIndex].Cells["id"].Value);
            DateTime dateEntry = Convert.ToDateTime(dgBudgetAppropriations.Rows[rowIndex].Cells["date_entry"].Value);

            frmSupplementalAppropriations.budgetAppropriationsId = budgetAppId;
            frmSupplementalAppropriations.dateEntry = dateEntry;

            frmSupplementalAppropriations.ShowDialog();
        }

        private void BtnSupplemental_Click(object sender, EventArgs e)
        {
            ShowSupplementalAppropriationsForm();
        }

        internal void RecordLocator(int fppID, int allotmentClassID, int fundID, short year) 
        {
            dgFPP.ClearSelection();

            //Update FPP datagrid, Appropriations datagrid and Combobox Year before reseting user control
            HelperLoadRecords.FPPBudgetAppropriationsDatagridView(Factory.FunctionProgramProjectRepository().GetRecords(), dgFPP);

            foreach (DataGridViewRow row in dgFPP.Rows)
            {
                if (Convert.ToInt32(row.Cells["id"].Value) == fppID)
                {
                    dgFPP.CurrentCell = dgFPP.Rows[row.Index].Cells["fpp_code"];
                    dgFPP.Rows[row.Index].Selected = true;
                }
            }

            HelperLoadRecords.BudgetAppropriationsYearToolStripCombobox(Factory.BudgetAppropriationsRepository().GetYearsBudgetAppropriations(), cmbxYear, "year", "year");

            HelperLoadRecords.BudgetAppropriationsDatagridView(dgBudgetAppropriations, fppID, allotmentClassID, fundID, year, txtTotal);
        }

        internal void LoadBudgetAppropriationRecords()
        {
            var rowIndex = dgFPP.CurrentCell.RowIndex;

            int fppID = Convert.ToInt32(dgFPP.Rows[rowIndex].Cells["id"].Value);
            int allotmentClassID = Convert.ToInt32(cmbxAllotmentClass.ComboBox.SelectedValue);
            int fundId = Convert.ToInt32(cmbxFundType.ComboBox.SelectedValue);
            short year = Convert.ToInt16(cmbxYear.ComboBox.SelectedValue);

            HelperLoadRecords.BudgetAppropriationsDatagridView(dgBudgetAppropriations, fppID, allotmentClassID, fundId, year, txtTotal);
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

        internal void EnableDisableButtonsLocal(DataGridView dgv)
        {
            int SelectedRows = dgv.SelectedRows.Count;

            if (SelectedRows == 1 && dgv.SelectedCells[0].Value != null)
            {
                btnSupplemental.Enabled = true;
                btnEdit.Enabled = true;
                btnARODetails.Enabled = true;
                btnDelete.Enabled = true;
                btnDelete.Text = "Delete (" + SelectedRows + ")";

            }
            else if (SelectedRows > 1 && dgv.SelectedCells[0].Value != null)
            {
                btnSupplemental.Enabled = false;
                btnEdit.Enabled = false;
                btnARODetails.Enabled = false;
                btnDelete.Enabled = true;
                btnDelete.Text = "Delete (" + SelectedRows + ")";
            }
            else
            {
                btnSupplemental.Enabled = false;
                btnEdit.Enabled = false;
                btnARODetails.Enabled = false;
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

        private void ShowAllotmentReleaseDetails()
        {
            var frmAllotmentReleaseDetailsForm = new frmAllotmentReleaseDetails(this);
            var rowIndex = dgBudgetAppropriations.CurrentCell.RowIndex;

            int budgetAppId = Convert.ToInt32(dgBudgetAppropriations.Rows[rowIndex].Cells["id"].Value);
            int fppId = Convert.ToInt32(dgBudgetAppropriations.Rows[rowIndex].Cells["fpp_id"].Value);
            int? othersFPPId = dgBudgetAppropriations.Rows[rowIndex].Cells["others_fpp_id"].Value == null ? null: Convert.ToInt32(dgBudgetAppropriations.Rows[rowIndex].Cells["others_fpp_id"].Value);
            int allotmentClassesId = Convert.ToInt32(dgBudgetAppropriations.Rows[rowIndex].Cells["allotment_class_id"].Value);
            int genLedgerAccId = Convert.ToInt32(dgBudgetAppropriations.Rows[rowIndex].Cells["general_ledger_accounts_id"].Value);

            frmAllotmentReleaseDetailsForm.budgetAppropriationId = budgetAppId;
            frmAllotmentReleaseDetailsForm.fppId = fppId;
            frmAllotmentReleaseDetailsForm.othersFPPId = othersFPPId;
            frmAllotmentReleaseDetailsForm.allotmentClassId = allotmentClassesId;
            frmAllotmentReleaseDetailsForm.generalLedgerAccountsId = genLedgerAccId;

            frmAllotmentReleaseDetailsForm.ShowDialog();
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

        private void BtnARO_Click(object sender, EventArgs e) 
        {
            _ = new frmAllotmentReleaseMain(this).ShowDialog();
        }

        private void BtnARODetails_Click(object sender, EventArgs e) 
        {
            ShowAllotmentReleaseDetails();
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

            EnableDisableButtonsLocal(dgBudgetAppropriations);
        }

        private void dgFPP_RowHeaderMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            LoadBudgetAppropriationRecords();
        }

        private void dgBudgetAppropriations_SelectionChanged(object sender, EventArgs e)
        {
            EnableDisableButtonsLocal(dgBudgetAppropriations);
        }

        #endregion Events Method

    }
}
