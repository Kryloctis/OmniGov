using ACC.Domain.Models;
using AccountingSystem.Views.Manage.AllotmentRelease;
using AccountingSystem.Views.Manage.Augmentation;
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

        private void ShowRecordTimeStamp() 
        {

            int rowIndex = dgBudgetAppropriations.CurrentCell.RowIndex;

            var dateEntry = dgBudgetAppropriations.Rows[rowIndex].Cells["date_entry"].Value;
            var createdAt = dgBudgetAppropriations.Rows[rowIndex].Cells["created_at"].Value;
            var updatedAt = dgBudgetAppropriations.Rows[rowIndex].Cells["updated_at"].Value;

            lblDateEntry.Text = createdAt == null ? null : dateEntry.ToString();
            lblCreatedAt.Text = createdAt == null ? null : createdAt.ToString();
            lblUpdatedAt.Text = updatedAt == null ? null : updatedAt.ToString();

        }

        private void dgBudgetAppropriations_SelectionChanged(object sender, EventArgs e)
        {
            ShowRecordTimeStamp();
            EnableDisableButtonsLocal(dgBudgetAppropriations);
        }

        internal void LoadBudgetAppropriationRecords()
        {
            if (!DesignMode)
            {
                Cursor.Current = Cursors.WaitCursor;
                dgBudgetAppropriations.SelectionChanged -= new System.EventHandler(dgBudgetAppropriations_SelectionChanged);

                int recordCount = 0;
                int fppID = Convert.ToInt32(cmbxFPP.SelectedValue);
                int allotmentClassID = Convert.ToInt32(cmbxAllotmentClass.SelectedValue);
                int fundId = Convert.ToInt32(cmbxFunds.SelectedValue);
                short year = Convert.ToInt16(nudYear.Value);

                HelperLoadRecords.BudgetAppropriationsDatagridView(dgBudgetAppropriations, fppID, allotmentClassID, fundId, year, txtTotal);

                dgBudgetAppropriations.SelectionChanged += new System.EventHandler(dgBudgetAppropriations_SelectionChanged);
                EnableDisableButtonsLocal(dgBudgetAppropriations);

                foreach (DataGridViewRow item in dgBudgetAppropriations.Rows)
                {
                    if (item.Cells["id"].Value != null)
                    {
                        recordCount += 1;
                    }
                }

                lblRecords.Text = recordCount.ToString();
                lblDateEntry.Text = string.Empty;
                lblCreatedAt.Text = string.Empty;
                lblUpdatedAt.Text = string.Empty;
                Cursor.Current = Cursors.Default;
            }
          
        }

        internal void LoadComboboxes()
        {
            try
            {
                var dtAllotmentClasses = Factory.AllotmentClassesRepository().GetRecords();
                HelperLoadRecords.BudgetAppropriationsAllotmentCombobox(dtAllotmentClasses, cmbxAllotmentClass, "allotment_code", "id");

                var dtFunds = Factory.FundsRepository().GetRecords();
                HelperLoadRecords.BudgetAppropriationsTypeOfFundsCombobox(dtFunds, cmbxFunds, "fund_name", "id");

                LoadFPP();
                cmbxFPP.TextChanged += new EventHandler(CmbxFPP_TextChanged);
                cmbxFPP.SelectedValueChanged += new EventHandler(CmbxFPP_SelectedValueChanged);
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
                    row.Selected = false;
            }

            if (SelectedRows == 1 && dgv.SelectedCells[0].Value != null)
            {
                btnEdit.Enabled = true;
                btnDelete.Enabled = true;
                btnDelete.Text = "Delete (" + SelectedRows + ")";
                btnSupplementalAppropriations.Enabled = true;
                btnAugmentation.Enabled = true;

            }
            else if (SelectedRows > 1 && dgv.SelectedCells[0].Value != null)
            {
                btnEdit.Enabled = false;
                btnDelete.Enabled = true;
                btnDelete.Text = "Delete (" + SelectedRows + ")";
                btnSupplementalAppropriations.Enabled = false;
                btnAugmentation.Enabled = false;
            }
            else
            {
                btnEdit.Enabled = false;
                btnDelete.Enabled = false;
                btnDelete.Text = "Delete";
                btnSupplementalAppropriations.Enabled = false;
                btnAugmentation.Enabled = false;
            }

            if (cmbxFPP.SelectedIndex == -1 || cmbxAllotmentClass.SelectedIndex == -1 || cmbxFunds.SelectedIndex == -1)
                btnAdd.Enabled = false;
            else
                btnAdd.Enabled = true;

        }

        private void cmbxAllotmentClass_SelectedValueChanged(object sender, EventArgs e) 
        {
            if (Convert.ToInt32(cmbxFPP.SelectedValue) != 0)
            {
                LoadBudgetAppropriationRecords();
                EnableDisableButtonsLocal(dgBudgetAppropriations);
            }
        }

        private void cmbxFundType_SelectedValueChanged(object sender, EventArgs e) 
        {
            if (Convert.ToInt32(cmbxFPP.SelectedValue) != 0)
            {
                LoadBudgetAppropriationRecords();
                EnableDisableButtonsLocal(dgBudgetAppropriations);
            }
        }

        private void btnAdd_Click(object sender, EventArgs e) 
        {
            var frmBudgetAppropriationsAdd = new frmBudgetAppropriationsAdd(this);
            var ucBudgetAppropriationsAdd = frmBudgetAppropriationsAdd.ucBudgetAppropriations1;

            ucBudgetAppropriationsAdd.fppId = Convert.ToInt32(cmbxFPP.SelectedValue);
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
            int selectedRows = 0;

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
                        Helper.MessageBoxError($"Cannot Delete Budget Appropriation.");
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

        private void frmBudgetAppropriations_Load(object sender, EventArgs e)
        {
            Helper.DatagridFullRowSelectStyle(dgBudgetAppropriations, true);
            LoadComboboxes();
        }

        private void dataGridView_ColumnAdded(object sender, DataGridViewColumnEventArgs e)
        {
            dgBudgetAppropriations.Columns[e.Column.Index].SortMode = DataGridViewColumnSortMode.NotSortable;
        }


        //FPP
        private DataTable DataTableFPP() 
        {
            DataTable dtFPP;

            if (string.IsNullOrEmpty(cmbxFPP.Text))
                dtFPP = Factory.FunctionProgramProjectRepository().GetRecords();
            else
                dtFPP = Factory.FunctionProgramProjectRepository().GetRecordsByCodeName(cmbxFPP.Text);

            return dtFPP;
        }

        internal void LoadFPP()
        {
            try
            {
                cmbxFPP.DroppedDown = false;
                Cursor.Current = Cursors.Default;

                if (DataTableFPP().Rows.Count == 0) return;

                var fppDict = new Dictionary<int, string>();
                foreach (DataRow item in DataTableFPP().Rows)
                {
                    int fppId = Convert.ToInt32(item["id"]);
                    string fppName = $"{item["fpp_code"]} - {item["fpp_name"]}";

                    fppDict.Add(fppId, fppName);
                }

                cmbxFPP.DataSource = new BindingSource(fppDict, null);
                cmbxFPP.DisplayMember = "value";
                cmbxFPP.ValueMember = "key";
                cmbxFPP.DropDownHeight = 400;

                LoadBudgetAppropriationRecords();
            }
            catch (Exception ex)
            {
                Helper.MessageBoxError(ex.Message);
            }
        }

        private void CmbxFPP_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(cmbxFPP.Text))
            {
                cmbxFPP.TextChanged -= new EventHandler(CmbxFPP_TextChanged);
                LoadFPP();
                cmbxFPP.SelectedIndex = -1;
                cmbxFPP.TextChanged += new EventHandler(CmbxFPP_TextChanged);
            }
        }

        private void CmbxFPP_SelectedValueChanged(object sender, EventArgs e)
        {
            LoadBudgetAppropriationRecords();
            EnableDisableButtonsLocal(dgBudgetAppropriations);
        }

        private void cmbxFPP_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F1 && cmbxFPP.FindStringExact(cmbxFPP.Text) == -1 && !string.IsNullOrEmpty(cmbxFPP.Text))
            {
                LoadFPP();
                cmbxFPP.DroppedDown = true;
            } 
        }


        private void btnSupplementalAppropriations_Click(object sender, EventArgs e)
        {
            int rowIndex = dgBudgetAppropriations.CurrentCell.RowIndex;
            int budgetAppropriationsId = Convert.ToInt32(dgBudgetAppropriations.Rows[rowIndex].Cells["id"].Value);

            var frmSupplementalAppropriations = new frmSupplementalAppropriations(this);

            frmSupplementalAppropriations.budgetAppropriationsId = budgetAppropriationsId;
            frmSupplementalAppropriations.ShowDialog();
        }

        private void btnAugmentation_Click(object sender, EventArgs e)
        {
            _ = new frmAugmentation().ShowDialog();
        }
    }
}
