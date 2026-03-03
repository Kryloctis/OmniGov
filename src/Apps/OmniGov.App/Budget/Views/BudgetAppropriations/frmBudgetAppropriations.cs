using OmniGov.App.Budget.Views.Augmentation;
using OmniGov.App.Budget.Views.Realignment;
using OmniGov.App.Budget.Views.SupplementalAppropriations;
using OmniGov.App.Helpers;
using OmniGov.Budget.Data.Factories;
using OmniGov.Budget.Domain.Entities;
using OmniGov.Core.Factories;
using System.Data;

namespace OmniGov.App.Budget.Views.BudgetAppropriations
{
    public partial class frmBudgetAppropriations : Form
    {
        public frmBudgetAppropriations()
        {
            InitializeComponent();
            Helper.LoadFormIcon(this);
            nudYear.Value = DateTime.Now.Year;
        }

        internal void DatagridViewRecordFinder(DataGridView dataGridView, string objectOfExpendituresValue, string subFPPValue)
        {
            foreach (DataGridViewRow row in dataGridView.Rows)
            {
                bool isFound = row.Cells["object_of_expenditures"].Value.ToString().StartsWith(objectOfExpendituresValue) && row.Cells["object_of_expenditures"].Value.ToString().EndsWith(objectOfExpendituresValue);

                if (isFound)
                {
                    dataGridView.CurrentCell = row.Cells["object_of_expenditures"];
                    row.Selected = true;
                    break;
                }
            }
        }

        private string GetFormErrors()
        {
            var errorArray = new dynamic[]
            {
                cmbxFPP.Tag,
                cmbxAllotmentClass.Tag,
                cmbxFunds.Tag,
                nudYear.Tag
            };

            return Factory.CreateErrors(errorArray).GenerateErrorMessage();
        }

        private void ShowRecordTimeStamp(DataGridView dataGridView)
        {
            if (dataGridView.SelectedRows.Count == 1 && dataGridView.CurrentRow.Cells["fpp_id"].Value != null)
            {
                int rowIndex = dataGridView.CurrentCell.RowIndex;

                var dateEntry = dataGridView.Rows[rowIndex].Cells["date_entry"].Value.ToString();
                var createdAt = dataGridView.Rows[rowIndex].Cells["created_at"].Value.ToString();
                var updatedAt = dataGridView.Rows[rowIndex].Cells["updated_at"].Value.ToString();

                lblDateEntry.Text = dateEntry;
                lblCreatedAt.Text = createdAt;
                lblUpdatedAt.Text = updatedAt;
            }
        }

        private void dgBudgetAppropriations_SelectionChanged(object sender, EventArgs e)
        {
            ShowRecordTimeStamp(dgBudgetAppropriations);
            EnableDisableButtonsLocal(dgBudgetAppropriations);
        }

        private decimal GetTotalApproprations()
        {
            decimal total = 0;

            foreach (DataGridViewRow row in dgBudgetAppropriations.Rows)
            {
                if (row.Cells["fpp_id"].Value != DBNull.Value)
                    total += Convert.ToDecimal(row.Cells["amount"].Value);
            }

            return total;
        }

        private int rowCount()
        {
            int recordCount = 0;

            foreach (DataGridViewRow row in dgBudgetAppropriations.Rows)
            {
                if (row.Cells["fpp_id"].Value != DBNull.Value)
                    recordCount += 1;
            }

            return recordCount;
        }

        private void HighLightHeaders(DataGridView dataGridView)
        {
            foreach (DataGridViewRow row in dataGridView.Rows)
            {
                if (row.Cells["fpp_id"].Value == DBNull.Value)
                    row.DefaultCellStyle.Font = new Font(DefaultFont, FontStyle.Bold);
            }
        }

        private DataColumn[] BudgetAppropriationsDataColumns()
        {
            return new DataColumn[]
            {
                new DataColumn("id", typeof(int)),
                new DataColumn("funds_id", typeof(int)),
                new DataColumn("fpp_id", typeof(int)),
                new DataColumn("others_fpp_id", typeof(int)){ AllowDBNull = true},
                new DataColumn("allotment_class_id", typeof(int)),
                new DataColumn("general_ledger_accounts_id", typeof(int)),
                new DataColumn("object_of_expenditures", typeof(string)),
                new DataColumn("date_entry", typeof(DateTime)),
                new DataColumn("amount", typeof(decimal)),
                new DataColumn("allotment_released", typeof(decimal)),
                new DataColumn("obligations", typeof(decimal)),
                new DataColumn("unobligated_balance", typeof(decimal)),
                new DataColumn("year", typeof(int)),
                new DataColumn("continuing", typeof(Image)),
                new DataColumn("realigned", typeof(Image)),
                new DataColumn("created_at", typeof(DateTime)),
                new DataColumn("updated_at", typeof(DateTime))
            };
        }

        private DataTable BudgetAppropriationsDataTable(int fppId, int allotmentClassId, int fundId, short year)
        {
            var dataTable = new DataTable();
            dataTable.Columns.AddRange(BudgetAppropriationsDataColumns());

            //Initialize Repository Method
            var budgetAppropriationsModel = new BudgetAppropriationsModel()
            {
                FunctionProgramProjectId = fppId,
                AllotmentClassesId = allotmentClassId,
                FundsId = fundId,
                Year = year
            };

            budgetAppropriationsModel.OthersFPPId = null;

            var dtGetViewRecordsByFFPIDByAllotmentClass = BudgetFactory.BudgetAppropriationsRepository().GetViewRecordsByIdsYear(budgetAppropriationsModel);

            //Load by loop All Budget Appropriations Records without Others FPP
            foreach (DataRow drGetViewRecordsByIds in dtGetViewRecordsByFFPIDByAllotmentClass.Rows)
            {
                FieldData(dataTable, drGetViewRecordsByIds);
            }

            //Initialize Repository Method for others fpp records
            var dtGetRecordsOthersFPP = BudgetFactory.BudgetAppropriationsRepository().GetHeaderOthersFPP(fppId, allotmentClassId, fundId, year);

            //Load by loop All Budget Appropriations Records with Others FPP
            foreach (DataRow drGetRecordsOthersFPP in dtGetRecordsOthersFPP.Rows)
            {
                var otherFppRowHeader = dataTable.NewRow();
                string othersFPPName = drGetRecordsOthersFPP["others_fpp_name"].ToString();
                int othersFPPID = Convert.ToInt32(drGetRecordsOthersFPP["others_fpp_id"]);

                //Set Header for Others FPP
                otherFppRowHeader["object_of_expenditures"] = othersFPPName;
                dataTable.Rows.Add(otherFppRowHeader);

                budgetAppropriationsModel.OthersFPPId = othersFPPID;
                DataTable dtGetViewRecordsByIds = BudgetFactory.BudgetAppropriationsRepository().GetViewRecordsByIdsYear(budgetAppropriationsModel);

                foreach (DataRow drGetViewRecordsByIds in dtGetViewRecordsByIds.Rows)
                {
                    FieldData(dataTable, drGetViewRecordsByIds);
                }
            }

            static void FieldData(DataTable dataTable, DataRow dataRow)
            {
                var newRow = dataTable.NewRow();
                int rowId = Convert.ToInt32(dataRow["id"]);
                int rowFundId = Convert.ToInt32(dataRow["funds_id"]);
                int rowFPPId = Convert.ToInt32(dataRow["fpp_id"]);
                object rowOthersFPPId = string.IsNullOrWhiteSpace(dataRow["others_fpp_id"].ToString()) ? DBNull.Value : Convert.ToInt32(dataRow["others_fpp_id"]);
                int rowAllotmentClassId = Convert.ToInt32(dataRow["allotment_class_id"]);
                int rowAccountId = Convert.ToInt32(dataRow["general_ledger_accounts_id"]);
                string rowAccountName = dataRow["general_ledger_accounts_name"].ToString();
                string rowAccountCode = dataRow["account_code"].ToString();
                DateTime rowDateEntry = Convert.ToDateTime(dataRow["date_entry"]);
                decimal rowAppropriationAmount = Convert.ToDecimal(dataRow["amount"]);
                short rowYear = Convert.ToInt16(dataRow["year"]);
                bool rowContinuing = Convert.ToBoolean(Convert.ToByte(dataRow["continuing"]));
                bool rowRealignment = false;
                string remarks = dataRow["remarks"].ToString();

                //Get total supplemental appropriations
                decimal totalSupplementalAppropriation = BudgetFactory.SupplementalAppropriationsRepository().GetSumSupplementalAppropriationsBy_BudgetAppropriationsId(rowId);

                //GET total allotment release
                var dtAllotmentRelease = BudgetFactory.AllotmentReleaseRepository().GetViewRecordsByBudgetAppropriationId(rowId);
                decimal totalAllotmentRelease = Convert.ToDecimal(dtAllotmentRelease.Rows.Count == 0 ? 0 : dtAllotmentRelease.Compute("SUM(amount)", string.Empty));

                //Get total realignment
                //var totalRealignmentTo = BudgetFactory.BudgetRealignmentRepository().GetAmountOfBudgetRealignedToByBudgetId(rowId);

                //var totalRealignmentFrom = BudgetFactory.BudgetRealignmentRepository().GetAmountOfBudgetRealignedFromByBudgetId(rowId);

                //Get total Appropriations
                decimal totalAppropriationAmount = (totalSupplementalAppropriation + rowAppropriationAmount + 0) - 0;

                //Get total Obligations
                var totalObligations = BudgetFactory.ObligationRequestRepository().GetSumObligationsByBudgetAppropriationAndStatus(rowId);
                var unobligatedBalance = totalAppropriationAmount - totalObligations;

                string objectOfExpenditures = $"   {rowAccountCode} - {rowAccountName}{(string.IsNullOrEmpty(remarks) ? string.Empty : $" ? {remarks}")}";

                newRow["id"] = rowId;
                newRow["funds_id"] = rowFundId;
                newRow["fpp_id"] = rowFPPId;
                newRow["others_fpp_id"] = rowOthersFPPId;
                newRow["allotment_class_id"] = rowAllotmentClassId;
                newRow["general_ledger_accounts_id"] = rowAccountId;
                newRow["object_of_expenditures"] = objectOfExpenditures;
                newRow["date_entry"] = rowDateEntry;
                newRow["amount"] = totalAppropriationAmount;
                newRow["allotment_released"] = totalAllotmentRelease;
                newRow["obligations"] = totalObligations;
                newRow["unobligated_balance"] = unobligatedBalance;
                newRow["year"] = rowYear;
                newRow["continuing"] = rowContinuing ? Properties.Resources.ok14px : null;
                newRow["realigned"] = rowRealignment ? Properties.Resources.ok14px : null;
                newRow["created_at"] = dataRow["created_at"];
                newRow["updated_at"] = dataRow["updated_at"];
                dataTable.Rows.Add(newRow);
            }

            ////Change Font style for the header of Others FPP
            //foreach (DataGridViewRow row in dgvBudgetAppropriations.Rows)
            //{
            //    if (row.Cells["fpp_id"].Value == null)
            //    {
            //        Color backgroundColor = Color.White;

            //        row.DefaultCellStyle.Font = new Font(DataGridView.DefaultFont, FontStyle.Bold);
            //        row.DefaultCellStyle.BackColor = backgroundColor;
            //        row.HeaderCell.Style.BackColor = backgroundColor;
            //    }
            //}

            ////Show Total Values
            //decimal totalAppropriation = 0;
            //for (int i = 0; i < dgvBudgetAppropriations.Rows.Count; i++)
            //{
            //    totalAppropriation += Convert.ToDecimal(dgvBudgetAppropriations.Rows[i].Cells["amount"].Value);
            //}

            //txtTotalAppropriation.Text = totalAppropriation.ToString("N2");

            return dataTable;
        }

        internal void LoadBudgetAppropriationRecords()
        {
            Cursor.Current = Cursors.WaitCursor;
            int fppID = Convert.ToInt32(cmbxFPP.SelectedValue);
            int allotmentClassID = Convert.ToInt32(cmbxAllotmentClass.SelectedValue);
            int fundId = Convert.ToInt32(cmbxFunds.SelectedValue);
            short year = (short)nudYear.Value;

            HelperLoadRecords.BudgetAppropriationsDatagridView(dgBudgetAppropriations, BudgetAppropriationsDataTable(fppID, allotmentClassID, fundId, year));
            dgBudgetAppropriations.CurrentCell = dgBudgetAppropriations.FirstDisplayedCell;
            HighLightHeaders(dgBudgetAppropriations);
            EnableDisableButtonsLocal(dgBudgetAppropriations);
            txtTotal.Text = GetTotalApproprations().ToString("N2");
            lblRecords.Text = rowCount().ToString();
            lblDateEntry.Text = string.Empty;
            lblCreatedAt.Text = string.Empty;
            lblUpdatedAt.Text = string.Empty;

            ShowRecordTimeStamp(dgBudgetAppropriations);
            Cursor.Current = Cursors.Default;
        }

        public void LoadComboboxes()
        {
            var dtAllotmentClasses = Factory.AllotmentClassesRepository().GetRecords();
            HelperLoadRecords.BudgetAppropriationsAllotmentClassCombobox(dtAllotmentClasses, cmbxAllotmentClass, "allotment_code", "id");

            var dtFunds = Factory.FundsRepository().GetRecords();
            HelperLoadRecords.BudgetAppropriationsTypeOfFundsCombobox(dtFunds, cmbxFunds, "fund_name", "id");

            LoadFPP();
            cmbxFPP.TextChanged += new EventHandler(CmbxFPP_TextChanged);
            cmbxFPP.SelectedValueChanged += new EventHandler(CmbxFPP_SelectedValueChanged);
        }

        internal void EnableDisableButtonsLocal(DataGridView dgv)
        {
            int SelectedRows = 0;

            foreach (DataGridViewRow row in dgv.SelectedRows)
            {
                if (!string.IsNullOrEmpty(row.Cells["fpp_id"].Value.ToString()))
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
            }
            else if (SelectedRows > 1 && dgv.SelectedCells[0].Value != null)
            {
                btnEdit.Enabled = false;
                btnDelete.Enabled = true;
                btnDelete.Text = "Delete (" + SelectedRows + ")";
                btnSupplementalAppropriations.Enabled = false;
            }
            else
            {
                btnEdit.Enabled = false;
                btnDelete.Enabled = false;
                btnDelete.Text = "Delete";
                btnSupplementalAppropriations.Enabled = true;
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
            if (!ValidateChildren())
            {
                Helper.MessageBoxError(GetFormErrors());
                return;
            }

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
            int? othersFPPId = dgBudgetAppropriations.Rows[rowIndex].Cells["others_fpp_id"].Value == DBNull.Value ? null : Convert.ToInt32(dgBudgetAppropriations.Rows[rowIndex].Cells["others_fpp_id"].Value);
            int allotmentClassesId = Convert.ToInt32(dgBudgetAppropriations.Rows[rowIndex].Cells["allotment_class_id"].Value);
            int genLedgerAccId = Convert.ToInt32(dgBudgetAppropriations.Rows[rowIndex].Cells["general_ledger_accounts_id"].Value);
            decimal totalAllotmentRelease = Convert.ToDecimal(dgBudgetAppropriations.Rows[rowIndex].Cells["allotment_released"].Value);

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

                    _ = BudgetFactory.BudgetAppropriationsRepository().Delete(budgetAppropriationsModelList);
                    LoadBudgetAppropriationRecords();
                }
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

        private void dgBudgetAppropriations_ColumnAdded(object sender, DataGridViewColumnEventArgs e)
        {
            dgBudgetAppropriations.Columns[e.Column.Index].SortMode = DataGridViewColumnSortMode.NotSortable;
        }

        private DataTable DataTableFPP()
        {
            var dataTable = new DataTable();
            dataTable.Columns.Add("id");
            dataTable.Columns.Add("fpp_code_name");

            DataTable dtFPP;

            if (string.IsNullOrEmpty(cmbxFPP.Text))
                dtFPP = Factory.FunctionProgramProjectRepository().GetViewRecords();
            else
                dtFPP = Factory.FunctionProgramProjectRepository().GetRecordsByCodeName(cmbxFPP.Text);

            foreach (DataRow item in dtFPP.Rows)
            {
                int fppId = Convert.ToInt32(item["id"]);
                string fppName = $"{item["fpp_code"]} - {item["fpp_name"]}";

                dataTable.Rows.Add(fppId, fppName);
            }

            return dataTable;
        }

        internal void LoadFPP()
        {
            HelperLoadRecords.FppCombobox(DataTableFPP(), cmbxFPP, "fpp_code_name", "id");
            LoadBudgetAppropriationRecords();
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
            if (cmbxFPP.SelectedIndex > -1)
            {
                LoadBudgetAppropriationRecords();
                EnableDisableButtonsLocal(dgBudgetAppropriations);
            }
        }

        private void cmbxFPP_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F1 && cmbxFPP.FindStringExact(cmbxFPP.Text) == -1 && !string.IsNullOrEmpty(cmbxFPP.Text))
            {
                LoadFPP();
                cmbxFPP.DroppedDown = true;
            }
        }

        private void ShowSupplementalAppropriations()
        {
            var frmSupplementalAppropriationsMain = new frmSupplementalAppropriationsMain(this);

            if (!ValidateChildren())
            {
                Helper.MessageBoxError(GetFormErrors());
                return;
            }

            if (dgBudgetAppropriations.SelectedRows.Count == 1)
            {
                int rowIndex = dgBudgetAppropriations.CurrentRow.Index;
                int budgetAppropriationId = Convert.ToInt32(dgBudgetAppropriations.Rows[rowIndex].Cells["id"].Value);
                frmSupplementalAppropriationsMain.budgetAppropriationId = budgetAppropriationId;
            }

            int fppId = Convert.ToInt32(cmbxFPP.SelectedValue);
            int fundId = Convert.ToInt32(cmbxFunds.SelectedValue);
            int allotmentClassId = Convert.ToInt32(cmbxAllotmentClass.SelectedValue);
            int year = Convert.ToInt16(nudYear.Value);

            frmSupplementalAppropriationsMain.fppId = fppId;
            frmSupplementalAppropriationsMain.fundId = fundId;
            frmSupplementalAppropriationsMain.allotmentClassId = allotmentClassId;
            frmSupplementalAppropriationsMain.year = year;

            frmSupplementalAppropriationsMain.ShowDialog();
        }

        private void btnSupplementalAppropriations_Click(object sender, EventArgs e)
        {
            ShowSupplementalAppropriations();
        }

        private void btnRealignment_Click(object sender, EventArgs e)
        {
            _ = new frmRealignment().ShowDialog();
        }

        private void btnAugmentation_Click(object sender, EventArgs e)
        {
            _ = new frmAugmentation().ShowDialog();
        }

        private void lnkSelectAll_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            dgBudgetAppropriations.SelectAll();
        }

        private void lnkClearSelection_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            dgBudgetAppropriations.ClearSelection();
        }

        private void cmbxFPP_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (cmbxFPP.SelectedIndex == -1)
            {
                cmbxFPP.Tag = "Invalid FPP, please select on the list.";
                e.Cancel = true;
            }
            else
                e.Cancel = false;
        }

        private void cmbxFPP_Validated(object sender, EventArgs e)
        {
            cmbxFPP.Tag = string.Empty;
        }

        private void cmbxAllotmentClass_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (cmbxAllotmentClass.SelectedIndex == -1)
            {
                cmbxAllotmentClass.Tag = "Invalid allotment class, please select on the list";
                e.Cancel = true;
            }
            else
                e.Cancel = false;
        }

        private void cmbxAllotmentClass_Validated(object sender, EventArgs e)
        {
            cmbxAllotmentClass.Tag = string.Empty;
        }

        private void cmbxFunds_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (cmbxFunds.SelectedIndex == -1)
            {
                cmbxFunds.Tag = "Invalid fund, please select on the list";
                e.Cancel = true;
            }
            else
                e.Cancel = false;
        }

        private void cmbxFunds_Validated(object sender, EventArgs e)
        {
            cmbxFunds.Tag = string.Empty;
        }

        private void nudYear_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (nudYear.Value == 0 || nudYear.Value.ToString() == string.Empty)
            {
                nudYear.Tag = "Invalid year, please enter a valid year.";
                e.Cancel = true;
            }
            else
                e.Cancel = false;
        }

        private void nudYear_Validated(object sender, EventArgs e)
        {
            nudYear.Tag = string.Empty;
        }
    }
}