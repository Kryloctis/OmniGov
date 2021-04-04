using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Windows.Forms;

namespace AccountingSystem
{
    public class HelperLoadRecords
    {
        #region Account Group
        internal static void AccountGroupDatagridView(DataTable dataTable, DataGridView datagrid)
        {
            datagrid.DataSource = dataTable;
            datagrid.Columns[0].Visible = false;
            datagrid.Columns[1].HeaderText = "Code";
            datagrid.Columns[2].HeaderText = "Name";
            datagrid.Columns[2].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            datagrid.Columns[3].Visible = false;
            datagrid.Columns[4].Visible = false;
        }

        internal static void AccountGroupComboBox(DataTable dataTable, ComboBox comboBox, string displayMember, string valueMember)
        {
            comboBox.DataSource = dataTable;
            comboBox.DisplayMember = displayMember;
            comboBox.ValueMember = valueMember;

            if (comboBox.DropDownStyle == ComboBoxStyle.DropDown)
            {
                // loop datatable to add items in autocompletesource
                foreach (DataRow item in dataTable.Rows)
                    comboBox.AutoCompleteCustomSource.Add(item[displayMember].ToString());

                comboBox.AutoCompleteMode = AutoCompleteMode.Suggest;
                comboBox.AutoCompleteSource = AutoCompleteSource.CustomSource;
            }
        }
        #endregion

        #region Roles & Permissions
        internal static void RolesDatagridView(DataTable dataTable, DataGridView datagrid)
        {
            datagrid.DataSource = dataTable;
            datagrid.Columns[0].Visible = false;
            datagrid.Columns[1].HeaderText = "Role Name";
            datagrid.Columns[2].Visible = false;
            datagrid.Columns[3].Visible = false;

            datagrid.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }

        internal static void RoleNameComboBox(DataTable dataTable, ComboBox comboBox, string displayMember, string valueMember)
        {
            comboBox.DataSource = dataTable;
            comboBox.DisplayMember = displayMember;
            comboBox.ValueMember = valueMember;

            if (comboBox.DropDownStyle == ComboBoxStyle.DropDown)
            {
                // loop datatable to add items in autocompletesource
                foreach (DataRow item in dataTable.Rows)
                    comboBox.AutoCompleteCustomSource.Add(item[displayMember].ToString());

                comboBox.AutoCompleteMode = AutoCompleteMode.Suggest;
                comboBox.AutoCompleteSource = AutoCompleteSource.CustomSource;
            }
        }

        internal static void PermissionsComboBox(DataTable dataTable, ComboBox comboBox, string displayMember, string valueMember)
        {
            comboBox.DataSource = dataTable;
            comboBox.DisplayMember = displayMember;
            comboBox.ValueMember = valueMember;

            if (comboBox.DropDownStyle == ComboBoxStyle.DropDown)
            {
                // loop datatable to add items in autocompletesource
                foreach (DataRow item in dataTable.Rows)
                    comboBox.AutoCompleteCustomSource.Add(item[displayMember].ToString());

                comboBox.AutoCompleteMode = AutoCompleteMode.Suggest;
                comboBox.AutoCompleteSource = AutoCompleteSource.CustomSource;
            }
        }

        internal static void PermissionCheckedListBox(DataTable dataTable, CheckedListBox checkedListBox, string displayMember, string valueMember)
        {
            checkedListBox.DataSource = dataTable;
            checkedListBox.DisplayMember = displayMember;
            checkedListBox.ValueMember = valueMember;
        }

        internal static void AddedPermissionsDatagridView(DataTable dataTable, DataGridView datagrid)
        {
            datagrid.DataSource = dataTable;
            datagrid.Columns[0].HeaderText = "Permission Name";
            datagrid.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }
        #endregion

        #region Major Account Group
        internal static void MajorAccountGroupDatagridView(DataTable dataTable, DataGridView datagrid)
        {
            datagrid.DataSource = dataTable;
            datagrid.Columns[0].Visible = false;
            datagrid.Columns[1].HeaderText = "Code";
            datagrid.Columns[2].HeaderText = "Name";
            datagrid.Columns[2].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            datagrid.Columns[3].HeaderText = "Account Group";
            datagrid.Columns[4].Visible = false;
            datagrid.Columns[5].Visible = false;
        }

        internal static void MajorAccountGroupComboBox(DataTable dataTable, ComboBox comboBox, string displayMember, string valueMember)
        {
            comboBox.DataSource = dataTable;
            comboBox.DisplayMember = displayMember;
            comboBox.ValueMember = valueMember;

            if (comboBox.DropDownStyle == ComboBoxStyle.DropDown)
            {
                // loop datatable to add items in autocompletesource
                foreach (DataRow item in dataTable.Rows)
                    comboBox.AutoCompleteCustomSource.Add(item[displayMember].ToString());

                comboBox.AutoCompleteMode = AutoCompleteMode.Suggest;
                comboBox.AutoCompleteSource = AutoCompleteSource.CustomSource;
            }
        }
        #endregion

        #region Sub Major Account Group
        internal static void SubMajorAccountGroupDatagridView(DataTable dataTable, DataGridView datagrid)
        {
            datagrid.DataSource = dataTable;
            datagrid.Columns[0].Visible = false;
            datagrid.Columns[1].HeaderText = "Code";
            datagrid.Columns[2].HeaderText = "Name";
            datagrid.Columns[2].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            datagrid.Columns[3].HeaderText = "Major Account";
            datagrid.Columns[3].Width = 300;
            datagrid.Columns[4].Visible = false;
            datagrid.Columns[5].Visible = false;
        }
        #endregion

        #region General Ledger Accounts
        internal static void GeneralLedgerAccountsDatagridView(DataTable dataTable, DataGridView datagrid)
        {
            datagrid.DataSource = dataTable;
            datagrid.Columns[0].Visible = false;
            datagrid.Columns[1].HeaderText = "Code";
            datagrid.Columns[2].HeaderText = "Name";
            datagrid.Columns[2].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            datagrid.Columns[3].HeaderText = "Sub Major Account";
            datagrid.Columns[3].Width = 400;
            datagrid.Columns[4].Visible = false;
            datagrid.Columns[5].Visible = false;
        }

        internal static void GeneralLedgerComboBox(DataTable dataTable, ComboBox comboBox, string displayMember, string valueMember)
        {
            comboBox.DataSource = dataTable;
            comboBox.DisplayMember = displayMember;
            comboBox.ValueMember = valueMember;

            if (comboBox.DropDownStyle == ComboBoxStyle.DropDown)
            {
                // loop datatable to add items in autocompletesource
                foreach (DataRow item in dataTable.Rows)
                    comboBox.AutoCompleteCustomSource.Add(item[displayMember].ToString());

                comboBox.AutoCompleteMode = AutoCompleteMode.Suggest;
                comboBox.AutoCompleteSource = AutoCompleteSource.CustomSource;

            }
        }
        #endregion

        #region Subsidiary Ledgers
        internal static void SubsidiaryLedgerAccountsDatagridView(DataTable dataTable, DataGridView datagrid)
        {
            datagrid.DataSource = dataTable;
            datagrid.Columns[0].Visible = false;
            datagrid.Columns[1].Visible = false;
            datagrid.Columns[2].Visible = false;
            datagrid.Columns[3].HeaderText = "Code";
            datagrid.Columns[3].Width = 200;
            datagrid.Columns[4].HeaderText = "Name";
            datagrid.Columns[4].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            datagrid.Columns[5].Visible = false;
            datagrid.Columns[6].Visible = false;
        }

        internal static void SubsidiaryLedgerComboBox(DataTable dataTable, ComboBox comboBox, string displayMember, string valueMember)
        {
            comboBox.DataSource = dataTable;
            comboBox.DisplayMember = displayMember;
            comboBox.ValueMember = valueMember;

            if (comboBox.DropDownStyle == ComboBoxStyle.DropDown)
            {
                // loop datatable to add items in autocompletesource
                foreach (DataRow item in dataTable.Rows)
                    comboBox.AutoCompleteCustomSource.Add(item[displayMember].ToString());

                comboBox.AutoCompleteMode = AutoCompleteMode.Suggest;
                comboBox.AutoCompleteSource = AutoCompleteSource.CustomSource;

            }
        }
        #endregion

        #region Journals
        internal static void JournalsDatagridView(DataTable dataTable, DataGridView datagrid)
        {
            datagrid.DataSource = dataTable;
            datagrid.Columns[0].Visible = false;
            datagrid.Columns[1].HeaderText = "Name";
            datagrid.Columns[2].Visible = false;
            datagrid.Columns[3].Visible = false;
            datagrid.Columns[4].Visible = false;

            datagrid.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }
        #endregion

        #region Funds
        internal static void FundsDatagridView(DataTable dataTable, DataGridView datagrid)
        {
            datagrid.DataSource = dataTable;
            datagrid.Columns[0].Visible = false;
            datagrid.Columns[1].HeaderText = "Code";
            datagrid.Columns[2].HeaderText = "Name";
            datagrid.Columns[3].Visible = false;
            datagrid.Columns[4].Visible = false;

            datagrid.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }
        internal static void FundsComboBox(DataTable dataTable, ComboBox comboBox, string displayMember, string valueMember)
        {
            comboBox.DataSource = dataTable;
            comboBox.DisplayMember = displayMember;
            comboBox.ValueMember = valueMember;

            if (comboBox.DropDownStyle == ComboBoxStyle.DropDown)
            {
                // loop datatable to add items in autocompletesource
                foreach (DataRow item in dataTable.Rows)
                    comboBox.AutoCompleteCustomSource.Add(item[displayMember].ToString());

                comboBox.AutoCompleteMode = AutoCompleteMode.Suggest;
                comboBox.AutoCompleteSource = AutoCompleteSource.CustomSource;
            }
        }

        #endregion

        #region Function/Program/Project
        internal static void FuntionalClassificationDatagridView(DataTable dataTable, DataGridView datagrid)
        {
            datagrid.DataSource = dataTable;
            datagrid.Columns[0].Visible = false;
            datagrid.Columns[1].HeaderText = "Code";
            datagrid.Columns[2].HeaderText = "Sector Name";
            datagrid.Columns[2].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            datagrid.Columns[3].Visible = false;
            datagrid.Columns[4].Visible = false;
        }

        internal static void FuntionalClassificationServiceDatagridView(DataTable dataTable, DataGridView datagrid)
        {
            datagrid.DataSource = dataTable;
            datagrid.Columns[0].Visible = false;
            datagrid.Columns[1].HeaderText = "Sector Name";
            datagrid.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            datagrid.Columns[2].HeaderText = "Service Name";
            datagrid.Columns[2].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            datagrid.Columns[3].Visible = false;
            datagrid.Columns[4].Visible = false;
        }

        internal static void FunctionProjectProgramDatagridView(DataTable dataTable, DataGridView datagrid)
        {
            datagrid.DataSource = dataTable;
            datagrid.Columns["id"].Visible = false;
            datagrid.Columns["service_name"].Visible = false;
            datagrid.Columns["fpp_code"].HeaderText = "Code";
            datagrid.Columns["fpp_code"].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
            datagrid.Columns["fpp_name"].HeaderText = "Name";
            datagrid.Columns["created_at"].Visible = false;
            datagrid.Columns["updated_at"].Visible = false;
            Helper.DatagridDefaultStyle(datagrid, true);
        }

        internal static void FPPComboBox(DataTable dataTable, ComboBox comboBox, string displayMember, string valueMember)
        {
            comboBox.DataSource = dataTable;
            comboBox.DisplayMember = displayMember;
            comboBox.ValueMember = valueMember;

            if (comboBox.DropDownStyle == ComboBoxStyle.DropDown)
            {
                // loop datatable to add items in autocompletesource
                foreach (DataRow item in dataTable.Rows)
                    comboBox.AutoCompleteCustomSource.Add(item[displayMember].ToString());

                comboBox.AutoCompleteMode = AutoCompleteMode.Suggest;
                comboBox.AutoCompleteSource = AutoCompleteSource.CustomSource;

            }
        }

        internal static void SectorNameComboBox(DataTable dataTable, ComboBox comboBox, string displayMember, string valueMember)
        {
            comboBox.DataSource = dataTable;
            comboBox.DisplayMember = displayMember;
            comboBox.ValueMember = valueMember;

            if (comboBox.DropDownStyle == ComboBoxStyle.DropDown)
            {
                // loop datatable to add items in autocompletesource
                foreach (DataRow item in dataTable.Rows)
                    comboBox.AutoCompleteCustomSource.Add(item[displayMember].ToString());

                comboBox.AutoCompleteMode = AutoCompleteMode.Suggest;
                comboBox.AutoCompleteSource = AutoCompleteSource.CustomSource;

            }
        }

        internal static void ServicesNameComboBox(DataTable dataTable, ComboBox comboBox1, string displayMember1, string valueMember1)
        {
            comboBox1.DataSource = dataTable;
            comboBox1.DisplayMember = displayMember1;
            comboBox1.ValueMember = valueMember1;

            if (comboBox1.DropDownStyle == ComboBoxStyle.DropDown)
            {
                // loop datatable to add items in autocompletesource
                foreach (DataRow item in dataTable.Rows)
                    comboBox1.AutoCompleteCustomSource.Add(item[displayMember1].ToString());

                comboBox1.AutoCompleteMode = AutoCompleteMode.Suggest;
                comboBox1.AutoCompleteSource = AutoCompleteSource.CustomSource;
            }
        }
        #endregion

        #region Allotment Classes
        internal static void AllotmentClassesDatagridView(DataTable dataTable, DataGridView datagrid)
        {
            datagrid.DataSource = dataTable;
            datagrid.Columns[0].Visible = false;
            datagrid.Columns[1].HeaderText = "Code";
            datagrid.Columns[2].HeaderText = "Name";
            datagrid.Columns[3].Visible = false;
            datagrid.Columns[4].Visible = false;


            datagrid.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }
        #endregion

        #region Collecting Officer
        internal static void CollectingOfficerDatagridView(DataTable dataTable, DataGridView datagrid)
        {
            datagrid.DataSource = dataTable;
            datagrid.Columns[0].Visible = false;
            datagrid.Columns[1].HeaderText = "Full Name";
            datagrid.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            datagrid.Columns[2].HeaderText = "Job Title";
            datagrid.Columns[2].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            datagrid.Columns[3].Visible = false;
            datagrid.Columns[4].Visible = false;
        }

        internal static void CollectingOfficerComboBox(DataTable dataTable, ComboBox comboBox, string displayMember, string valueMember)
        {
            comboBox.DataSource = dataTable;
            comboBox.DisplayMember = displayMember;
            comboBox.ValueMember = valueMember;

            if (comboBox.DropDownStyle == ComboBoxStyle.DropDown)
            {
                // loop datatable to add items in autocompletesource
                foreach (DataRow item in dataTable.Rows)
                    comboBox.AutoCompleteCustomSource.Add(item[displayMember].ToString());

                comboBox.AutoCompleteMode = AutoCompleteMode.Suggest;
                comboBox.AutoCompleteSource = AutoCompleteSource.CustomSource;
            }
        }
        #endregion

        #region Users
        internal static void UsersDatagridView(DataTable dataTable, DataGridView datagrid)
        {
            datagrid.DataSource = dataTable;
            datagrid.Columns[0].Visible = false;
            datagrid.Columns[1].HeaderText = "Firstname";
            datagrid.Columns[2].HeaderText = "MI";
            datagrid.Columns[3].HeaderText = "Lastname";
            datagrid.Columns[4].HeaderText = "Username";
            datagrid.Columns[5].HeaderText = "Role";
            datagrid.Columns[6].Visible = false;
            datagrid.Columns[7].Visible = false;


            datagrid.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }
        #endregion

        #region Others FPP

        internal static void OthersFPPDatagridView(DataTable dataTable, DataGridView dataGridView) 
        {
            dataGridView.DataSource = dataTable;
            dataGridView.Columns[0].Visible = false;
            dataGridView.Columns[1].Visible = false;
            dataGridView.Columns[2].HeaderText = "Name";
            dataGridView.Columns[3].Visible = false;
            dataGridView.Columns[4].Visible = false;
            Helper.DatagridDefaultStyle(dataGridView, true);
        }

        #endregion Others FPP

        #region BudgetAppropriations

        internal static void BudgetAppropriationsOthersFPPCombobox(DataTable dataTable, ComboBox comboBox, string displayMember, string valueMember) 
        {
            comboBox.DataSource = dataTable;
            comboBox.DisplayMember = displayMember;
            comboBox.ValueMember = valueMember;

            if (comboBox.DropDownStyle == ComboBoxStyle.DropDown)
            {
                // loop datatable to add items in autocompletesource
                foreach (DataRow item in dataTable.Rows)
                    comboBox.AutoCompleteCustomSource.Add(item[displayMember].ToString());

                comboBox.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
                comboBox.AutoCompleteSource = AutoCompleteSource.ListItems;
            }
        }

        internal static void BudgetAppropriationsAllotmentCombobox(DataTable dataTable, ComboBox comboBox, string displayMember, string valueMember) 
        {
            comboBox.DataSource = dataTable;
            comboBox.DisplayMember = displayMember;
            comboBox.ValueMember = valueMember;

            if (comboBox.DropDownStyle == ComboBoxStyle.DropDown)
            {
                // loop datatable to add items in autocompletesource
                foreach (DataRow item in dataTable.Rows)
                    comboBox.AutoCompleteCustomSource.Add(item[displayMember].ToString());

                comboBox.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
                comboBox.AutoCompleteSource = AutoCompleteSource.ListItems;
            }
        }
        internal static void BudgetAppropriationsAllomentToolStripCombobox(DataTable dataTable, ToolStripComboBox toolStripComboBox, string displayMember, string valueMember)
        {
            toolStripComboBox.ComboBox.DataSource = dataTable;
            toolStripComboBox.ComboBox.DisplayMember = displayMember;
            toolStripComboBox.ComboBox.ValueMember = valueMember;

            if (toolStripComboBox.DropDownStyle == ComboBoxStyle.DropDown)
            {
                // loop datatable to add items in autocompletesource
                foreach (DataRow item in dataTable.Rows)
                    toolStripComboBox.AutoCompleteCustomSource.Add(item[displayMember].ToString());

                toolStripComboBox.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
                toolStripComboBox.AutoCompleteSource = AutoCompleteSource.ListItems;
            }
        }

        internal static void BudgetAppropriationsTypeOfFundsCombobox(DataTable dataTable, ComboBox comboBox, string displayMember, string valueMember)
        {
            comboBox.DataSource = dataTable;
            comboBox.DisplayMember = displayMember;
            comboBox.ValueMember = valueMember;

            if (comboBox.DropDownStyle == ComboBoxStyle.DropDown)
            {
                // loop datatable to add items in autocompletesource
                foreach (DataRow item in dataTable.Rows)
                    comboBox.AutoCompleteCustomSource.Add(item[displayMember].ToString());

                comboBox.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
                comboBox.AutoCompleteSource = AutoCompleteSource.ListItems;
            }

        }
        internal static void BudgetAppropriationsTypeOfFundsToolStripCombobox(DataTable dataTable, ToolStripComboBox comboBox, string displayMember, string valueMember) 
        {
            comboBox.ComboBox.DataSource = dataTable;
            comboBox.ComboBox.DisplayMember = displayMember;
            comboBox.ComboBox.ValueMember = valueMember;

            if (comboBox.DropDownStyle == ComboBoxStyle.DropDown)
            {
                // loop datatable to add items in autocompletesource
                foreach (DataRow item in dataTable.Rows)
                    comboBox.AutoCompleteCustomSource.Add(item[displayMember].ToString());

                comboBox.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
                comboBox.AutoCompleteSource = AutoCompleteSource.ListItems;
            }
        }

        internal static void BudgetAppropriationsYearToolStripCombobox(DataTable dataTable, ToolStripComboBox toolStripComboBox, string displayMember, string valueMember)
        {
            toolStripComboBox.ComboBox.DataSource = dataTable;
            toolStripComboBox.ComboBox.DisplayMember = displayMember;
            toolStripComboBox.ComboBox.ValueMember = valueMember;
        }

        internal static void BudgetAppropriationsGeneralLedgerAccountsCombobox(DataTable dataTable, ComboBox comboBox, string displayMember, string valueMember) 
        {
            comboBox.DataSource = dataTable;
            comboBox.DisplayMember = displayMember;
            comboBox.ValueMember = valueMember;

            if (comboBox.DropDownStyle == ComboBoxStyle.DropDown)
            {
                // loop datatable to add items in autocompletesource
                foreach (DataRow item in dataTable.Rows)
                    comboBox.AutoCompleteCustomSource.Add(item[displayMember].ToString());

                comboBox.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
                comboBox.AutoCompleteSource = AutoCompleteSource.ListItems;
                comboBox.DropDownHeight = 200;
            }
        }

        internal static void FPPBudgetAppropriationsDatagridView(DataTable dataTable, DataGridView dataGridView) 
        {
            try
            {
                dataGridView.DataSource = dataTable;
                dataGridView.Columns["id"].Visible = false;
                dataGridView.Columns["service_name"].Visible = false;
                dataGridView.Columns["fpp_code"].HeaderText = "FPP Code";
                dataGridView.Columns["fpp_code"].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
                dataGridView.Columns["fpp_name"].HeaderText = "FPP Name";
                dataGridView.Columns["created_at"].Visible = false;
                dataGridView.Columns["updated_at"].Visible = false;
                dataGridView.ClearSelection();

                dataGridView.Columns["fpp_code"].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
                dataGridView.Columns["fpp_code"].SortMode = DataGridViewColumnSortMode.NotSortable;
                dataGridView.Columns["fpp_name"].SortMode = DataGridViewColumnSortMode.NotSortable;
            }
            catch (Exception ex) 
            {
                Helper.MessageBoxError(ex.Message);
            }
        }

        internal static void BudgetAppropriationsDatagridView(DataGridView dgvBudgetAppropriations, int fppID, int allotmentClassID, int typeOfFundsID, Int16 year, TextBox txtTotalAppropriation)
        {
            try
            {
                //Clearing Datagrid View  Rows & Columns before Loading new one
                dgvBudgetAppropriations.Rows.Clear();
                dgvBudgetAppropriations.Columns.Clear();

                //Set up new Columns to Datagrid View
                dgvBudgetAppropriations.Columns.Add("budget_appropriations_id", "Budget Appropriation ID");
                dgvBudgetAppropriations.Columns.Add("funds_id", "Fund ID");
                dgvBudgetAppropriations.Columns.Add("fpp_id", "FPP ID");
                dgvBudgetAppropriations.Columns.Add("year", "Year");
                dgvBudgetAppropriations.Columns.Add("others_fpp_id", "Others FPP ID");
                dgvBudgetAppropriations.Columns.Add("allotment_classes_id", "Allotment Classes ID");
                dgvBudgetAppropriations.Columns.Add("general_ledger_acc_id", "Gen. Ledger Acc. ID");
                dgvBudgetAppropriations.Columns.Add("ledger_name", "Object of Expenditures");
                dgvBudgetAppropriations.Columns.Add("account_code", "Account Code");
                dgvBudgetAppropriations.Columns.Add("appropriation", "Appropriation");
                dgvBudgetAppropriations.Columns.Add("total_allotment_release", "Total Allotment Release");
                dgvBudgetAppropriations.Columns.Add("appropriation_balance", "Appropriation Balance");
                dgvBudgetAppropriations.Columns.Add("created_at", "Created at");
                dgvBudgetAppropriations.Columns.Add("updated_at", "Updated at");

                //Column's Visibility
                dgvBudgetAppropriations.Columns["budget_appropriations_id"].Visible = false;
                dgvBudgetAppropriations.Columns["funds_id"].Visible = false;
                dgvBudgetAppropriations.Columns["fpp_id"].Visible = false;
                dgvBudgetAppropriations.Columns["year"].Visible = false;
                dgvBudgetAppropriations.Columns["others_fpp_id"].Visible = false;
                dgvBudgetAppropriations.Columns["allotment_classes_id"].Visible = false;
                dgvBudgetAppropriations.Columns["general_ledger_acc_id"].Visible = false;
                dgvBudgetAppropriations.Columns["created_at"].Visible = false;
                dgvBudgetAppropriations.Columns["updated_at"].Visible = false;

                //Column's Format
                dgvBudgetAppropriations.Columns["appropriation"].DefaultCellStyle.Format = "N2";
                dgvBudgetAppropriations.Columns["appropriation"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                dgvBudgetAppropriations.Columns["total_allotment_release"].DefaultCellStyle.Format = "N2";
                dgvBudgetAppropriations.Columns["total_allotment_release"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                dgvBudgetAppropriations.Columns["appropriation_balance"].DefaultCellStyle.Format = "N2";
                dgvBudgetAppropriations.Columns["appropriation_balance"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;

                //Initialize Repository Method
                DataTable dtGetViewRecordsByFFPIDByAllotmentClass = Factory.BudgetAppropriationsRepository().GetViewRecordsByIds(fppID, allotmentClassID, null, typeOfFundsID, year);

                //Load by loop All Budget Appropriations Records without Others FPP 
                foreach (DataRow drGetViewRecordsByIds in dtGetViewRecordsByFFPIDByAllotmentClass.Rows)
                {
                    dgvBudgetAppropriations.Rows.Add(new object[] {
                        drGetViewRecordsByIds["budget_appropriations_id"],
                        drGetViewRecordsByIds["funds_id"],
                        drGetViewRecordsByIds["fpp_id"],
                        drGetViewRecordsByIds["year"],
                        drGetViewRecordsByIds["others_fpp_id"],
                        drGetViewRecordsByIds["allotment_classes_id"],
                        drGetViewRecordsByIds["general_ledger_acc_id"],
                        drGetViewRecordsByIds["ledger_name"],
                        drGetViewRecordsByIds["account_code"],
                        drGetViewRecordsByIds["appropriation"],
                        drGetViewRecordsByIds["total_allotment_release"],
                        drGetViewRecordsByIds["appropriation_balance"],
                        drGetViewRecordsByIds["created_at"],
                        drGetViewRecordsByIds["updated_at"] });
                }

                //Initialize Repository Method
                DataTable dtGetRecordsOthersFPP = Factory.BudgetAppropriationsRepository().GetExistedOthersFPPrecordsByFPPID(fppID, allotmentClassID, typeOfFundsID, year);

                //Load by loop All Budget Appropriations Records with Others FPP 
                foreach (DataRow drGetRecordsOthersFPP in dtGetRecordsOthersFPP.Rows)
                {
                    string othersFPPName = drGetRecordsOthersFPP["others_fpp_name"].ToString();
                    int othersFPPID = Convert.ToInt32(drGetRecordsOthersFPP["others_fpp_id"]);
               
                    dgvBudgetAppropriations.Rows.Add(new object[] { null, null, null, null, null, null, null, othersFPPName });

                    DataTable dtGetViewRecordsByIds = Factory.BudgetAppropriationsRepository().GetViewRecordsByIds(fppID, allotmentClassID, othersFPPID, typeOfFundsID, year);
                    foreach (DataRow drGetViewRecordsByIds in dtGetViewRecordsByIds.Rows)
                    {
                        dgvBudgetAppropriations.Rows.Add(new object[] {
                        drGetViewRecordsByIds["budget_appropriations_id"],
                        drGetViewRecordsByIds["funds_id"],
                        drGetViewRecordsByIds["fpp_id"],
                        drGetViewRecordsByIds["year"],
                        drGetViewRecordsByIds["others_fpp_id"],
                        drGetViewRecordsByIds["allotment_classes_id"],
                        drGetViewRecordsByIds["general_ledger_acc_id"],
                        drGetViewRecordsByIds["ledger_name"],
                        drGetViewRecordsByIds["account_code"],
                        drGetViewRecordsByIds["appropriation"],
                        drGetViewRecordsByIds["total_allotment_release"],
                        drGetViewRecordsByIds["appropriation_balance"],
                        drGetViewRecordsByIds["created_at"],
                        drGetViewRecordsByIds["updated_at"] });
                    }
                }

                //Change Font style for the header of Others FPP
                foreach (DataGridViewRow row in dgvBudgetAppropriations.Rows)
                {
                    if (row.Cells["fpp_id"].Value == null)
                    {
                        dgvBudgetAppropriations.Rows[row.Index].DefaultCellStyle.Font = new Font(DataGridView.DefaultFont, FontStyle.Bold);
                    }
                }

                //Show Total Values
                decimal totalAppropriation = 0;
                for (int i = 0; i < dgvBudgetAppropriations.Rows.Count; i++)
                {
                    totalAppropriation += Convert.ToDecimal(dgvBudgetAppropriations.Rows[i].Cells["appropriation"].Value);
                }

                txtTotalAppropriation.Text = totalAppropriation.ToString("N2");

                dgvBudgetAppropriations.ClearSelection();
            }
            catch (Exception ex)
            {
                Helper.MessageBoxError(ex.Message);
            }
        }

        #endregion BudgetAppropriations

        #region Allotment Release

        internal static void AllotmentReleaseDgV(DataTable dataTable, DataGridView dgv, int budgetAppropriationID)
        {
            try
            {
                //Clearing Datagrid View  Rows & Columns before Loading new one
                dgv.Rows.Clear();
                dgv.Columns.Clear();

                //Set up new Columns to Datagrid View
                dgv.Columns.Add("id", "id");
                dgv.Columns.Add("budget_appropriations_id", "Budget Appropriation ID");
                dgv.Columns.Add("aro_no", "Allotment Release No.");
                dgv.Columns.Add("purpose", "Purpose");
                dgv.Columns.Add("date_issued", " Date Issued");
                dgv.Columns.Add("amount", "Amount");
                dgv.Columns.Add("created_at", "Created at");
                dgv.Columns.Add("updated_at", "Updated at");

                //Set up Column Format
                dgv.Columns[0].Visible = false;
                dgv.Columns[1].Visible = false;
                dgv.Columns[4].Visible = false;
                dgv.Columns[5].DefaultCellStyle.Format = "N2";
                dgv.Columns[5].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                dgv.Columns[6].Visible = false;
                dgv.Columns[7].Visible = false;

                //Load by loop All Budget Appropriations Records with Others FPP 
                foreach (DataRow drAllotmentRelease in dataTable.Rows)
                {
                    dgv.Rows.Add(new object[] {
                            drAllotmentRelease["id"],
                            drAllotmentRelease["budget_appropriations_id"],
                            drAllotmentRelease["aro_no"],
                            drAllotmentRelease["purpose"],
                            drAllotmentRelease["date_issued"],
                            drAllotmentRelease["amount"],
                            drAllotmentRelease["created_at"],
                            drAllotmentRelease["updated_at"] });
                }

                dgv.ClearSelection();
                Helper.DatagridDefaultStyle(dgv, true);
            }
            catch (Exception ex)
            {
                Helper.MessageBoxError(ex.Message);
            }

        }

        internal static void LoadBudgetAppropriationDetailsLabels(int budgetAppropriationID, int fppID, int? othersFPPID, int allotmentClassesID, int generalLedgerAccID, Label lblFPPCode, Label lblFPP, Label lblOtherFPP, Label lblAccountCode, Label lblAllotmentClass, Label lblGenLedgerAcc, Label lblYear, Label lblAmount, Label AppropriationBalance)
        {
            try
            {
                var selectedBudgetAppropriation = Factory.BudgetAppropriationsRepository().GetViewRecordByIDs(budgetAppropriationID, fppID, othersFPPID, allotmentClassesID, generalLedgerAccID);

                lblFPPCode.Text = selectedBudgetAppropriation["fpp_code"].ToString();
                lblFPP.Text = selectedBudgetAppropriation["fpp_name"].ToString();
                lblOtherFPP.Text = string.IsNullOrEmpty(selectedBudgetAppropriation["others_fpp_name"]) ? "-" : selectedBudgetAppropriation["others_fpp_name"];
                lblAccountCode.Text = selectedBudgetAppropriation["account_code"].ToString();
                lblAllotmentClass.Text = selectedBudgetAppropriation["allotment_code"].ToString();
                lblGenLedgerAcc.Text = selectedBudgetAppropriation["ledger_name"].ToString();
                lblYear.Text = selectedBudgetAppropriation["year"].ToString();
                lblAmount.Text = Convert.ToDecimal(selectedBudgetAppropriation["appropriation"]).ToString("N2");
                AppropriationBalance.Text = Convert.ToDecimal(selectedBudgetAppropriation["appropriation_balance"]).ToString("N2");

            }
            catch (Exception ex)
            {
                Helper.MessageBoxError(ex.Message);
            }
        }

        #endregion Allotment Release

        #region Obligation Request

        internal static void FPPAllotmentReleaseDatagridView(DataTable dataTable, DataGridView dataGridView) 
        {
            dataGridView.DataSource = dataTable;
            dataGridView.Columns["id"].Visible = false;
            dataGridView.Columns["service_name"].Visible = false;
            dataGridView.Columns["fpp_code"].HeaderText = "FPP Code";
            dataGridView.Columns["fpp_code"].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
            dataGridView.Columns["fpp_name"].HeaderText = "FPP Name";
            dataGridView.Columns["created_at"].Visible = false;
            dataGridView.Columns["updated_at"].Visible = false;
            dataGridView.ClearSelection();
        }

        internal static void AllotmentReleaseDgvObligationRequest(DataGridView dataGridView, int fppId, int fundID, int allotmentClassId, short year) 
        {
            try
            {
                dataGridView.Columns.Clear();
                dataGridView.Rows.Clear();

                //Set up new Columns to Datagrid View
                dataGridView.Columns.Add("gen_ledger_acc_id", "Ledger ID");
                dataGridView.Columns.Add("gen_ledger_code", "Ledger Code");
                dataGridView.Columns.Add("account_code", "Account Code");
                dataGridView.Columns.Add("gen_ledger_name", "Account Name");
                dataGridView.Columns.Add("total_allotment_release_amount", "Allotment Amount");
                dataGridView.Columns.Add("total_obligation_amount", "Obligated Amount ");
                dataGridView.Columns.Add("unobligated_balance", "Unobligated Balance");
                dataGridView.Columns.Add("budget_appropriations_id", "Budget Appropriation ID");
                dataGridView.Columns.Add("budget_appropriations_year", "Budget Appropriation Year");
                dataGridView.Columns.Add("budget_appropriations_amount", "Budget Appropriation Amount");
                dataGridView.Columns.Add("fund_id", "Fund ID");
                dataGridView.Columns.Add("fund_code", "Fund Code");
                dataGridView.Columns.Add("fund_name", "Fund Name");
                dataGridView.Columns.Add("fpp_id", "FPP ID");
                dataGridView.Columns.Add("fpp_code", "FPP Code");
                dataGridView.Columns.Add("fpp_name", "FPP Name");
                dataGridView.Columns.Add("others_fpp_id", "Others FPP ID");
                dataGridView.Columns.Add("others_fpp_name", "Others FPP Name");
                dataGridView.Columns.Add("allotment_class_id", "Allotment Class ID");
                dataGridView.Columns.Add("allotment_class_code", "Allotment Class Code");
                dataGridView.Columns.Add("allotment_class_name", "Allotment Class Name");

                //Visibility of Columns
                dataGridView.Columns["budget_appropriations_id"].Visible = false;
                dataGridView.Columns["budget_appropriations_year"].Visible = false;
                dataGridView.Columns["budget_appropriations_amount"].Visible = false;
                dataGridView.Columns["fund_id"].Visible = false;
                dataGridView.Columns["fund_code"].Visible = false;
                dataGridView.Columns["fund_name"].Visible = false;
                dataGridView.Columns["fpp_id"].Visible = false;
                dataGridView.Columns["fpp_code"].Visible = false;
                dataGridView.Columns["fpp_name"].Visible = false;
                dataGridView.Columns["others_fpp_id"].Visible = false;
                dataGridView.Columns["others_fpp_name"].Visible = false;
                dataGridView.Columns["allotment_class_id"].Visible = false;
                dataGridView.Columns["allotment_class_code"].Visible = false;
                dataGridView.Columns["allotment_class_name"].Visible = false;
                dataGridView.Columns["gen_ledger_acc_id"].Visible = false;
                dataGridView.Columns["gen_ledger_code"].Visible = false;

                //Formatting of Columns
                dataGridView.Columns["account_code"].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
                dataGridView.Columns["unobligated_balance"].DefaultCellStyle.Format = "N2";
                dataGridView.Columns["unobligated_balance"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                dataGridView.Columns["total_obligation_amount"].DefaultCellStyle.Format = "N2";
                dataGridView.Columns["total_obligation_amount"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                dataGridView.Columns["total_allotment_release_amount"].DefaultCellStyle.Format = "N2";
                dataGridView.Columns["total_allotment_release_amount"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;


                //Initialize Repository Method
                DataTable dtGetViewRecordsAllotmentRelease = Factory.AllotmentReleaseRepository().GetViewRecords(fppId, null, fundID, allotmentClassId, year);

                //Load by loop All Budget Appropriations Records without Others FPP 
                foreach (DataRow drGetViewRecords in dtGetViewRecordsAllotmentRelease.Rows)
                {
                    var totalObligationAmount = Factory.ObligationRequestRepository().GetTotalObligationAmount(
                          Convert.ToInt32(drGetViewRecords["fund_id"]),
                          Convert.ToInt32(drGetViewRecords["fpp_id"]),
                          null,
                          Convert.ToInt32(drGetViewRecords["allotment_class_id"]),
                          Convert.ToInt32(drGetViewRecords["gen_ledger_acc_id"]),
                          year);
                    
                    var totalAllotmentReleaseAmount = Factory.AllotmentReleaseRepository().GetTotalAllotmentReleaseAmount(
                          Convert.ToInt32(drGetViewRecords["fund_id"]),
                          Convert.ToInt32(drGetViewRecords["fpp_id"]),
                          null,
                          Convert.ToInt32(drGetViewRecords["allotment_class_id"]),
                          Convert.ToInt32(drGetViewRecords["gen_ledger_acc_id"]),
                          year);

                    decimal unobligatedBalance = Convert.ToDecimal(totalAllotmentReleaseAmount["total_allotment_release_amount"]) - Convert.ToDecimal(totalObligationAmount["total_obligation_amount"]);

                    var RowData = new object[]
                    {
                        drGetViewRecords["gen_ledger_acc_id"],
                        drGetViewRecords["gen_ledger_code"],
                        drGetViewRecords["account_code"],
                        drGetViewRecords["gen_ledger_name"],
                        Convert.ToDecimal(totalAllotmentReleaseAmount["total_allotment_release_amount"]),
                        Convert.ToDecimal(totalObligationAmount["total_obligation_amount"]),
                        unobligatedBalance,
                        drGetViewRecords["budget_appropriations_id"],
                        drGetViewRecords["budget_appropriations_year"],
                        drGetViewRecords["budget_appropriations_amount"],
                        drGetViewRecords["fund_id"],
                        drGetViewRecords["fund_code"],
                        drGetViewRecords["fund_name"],
                        drGetViewRecords["fpp_id"],
                        drGetViewRecords["fpp_code"],
                        drGetViewRecords["fpp_name"],
                        drGetViewRecords["others_fpp_id"],
                        drGetViewRecords["others_fpp_name"],
                        drGetViewRecords["allotment_class_id"],
                        drGetViewRecords["allotment_class_code"],
                        drGetViewRecords["allotment_class_name"],
                    };

                    dataGridView.Rows.Add(RowData);
                }

                //Initialize Repository Method
                DataTable dtGetOthersFPPRecords = Factory.AllotmentReleaseRepository().GetOthersFPPRecords(fppId ,allotmentClassId, fundID, year);

                //Load by loop All Budget Appropriations Records with Others FPP 
                foreach (DataRow drGetOthersFPPRecords in dtGetOthersFPPRecords.Rows)
                {
                    string othersFPPName = drGetOthersFPPRecords["others_fpp_name"].ToString();
                    int othersFPPID = Convert.ToInt32(drGetOthersFPPRecords["others_fpp_id"]);

                    dataGridView.Rows.Add(new object[] { null, null, othersFPPName });

                    //Initialize Repository Method for w Others FPP Records
                    DataTable dtGetViewRecordsAllotmentReleaseOthersFPP = Factory.AllotmentReleaseRepository().GetViewRecords(fppId, othersFPPID, fundID, allotmentClassId, year);


                    //Load by loop All Budget Appropriations Records without Others FPP 
                    foreach (DataRow drGetViewRecordsAllotmentReleaseOthersFPP in dtGetViewRecordsAllotmentReleaseOthersFPP.Rows)
                    {
                        var obligationRepo = Factory.ObligationRequestRepository().GetTotalObligationAmount(
                                Convert.ToInt32(drGetViewRecordsAllotmentReleaseOthersFPP["fund_id"]),
                                Convert.ToInt32(drGetViewRecordsAllotmentReleaseOthersFPP["fpp_id"]),
                                Convert.ToInt32(drGetViewRecordsAllotmentReleaseOthersFPP["others_fpp_id"]),
                                Convert.ToInt32(drGetViewRecordsAllotmentReleaseOthersFPP["allotment_class_id"]),
                                Convert.ToInt32(drGetViewRecordsAllotmentReleaseOthersFPP["gen_ledger_acc_id"]),
                                year);

                        var totalAllotmentReleaseAmount = Factory.AllotmentReleaseRepository().GetTotalAllotmentReleaseAmount(
                                Convert.ToInt32(drGetViewRecordsAllotmentReleaseOthersFPP["fund_id"]),
                                Convert.ToInt32(drGetViewRecordsAllotmentReleaseOthersFPP["fpp_id"]),
                                Convert.ToInt32(drGetViewRecordsAllotmentReleaseOthersFPP["others_fpp_id"]),
                                Convert.ToInt32(drGetViewRecordsAllotmentReleaseOthersFPP["allotment_class_id"]),
                                Convert.ToInt32(drGetViewRecordsAllotmentReleaseOthersFPP["gen_ledger_acc_id"]),
                                year);

                        decimal unobligatedBalance = Convert.ToDecimal(totalAllotmentReleaseAmount["total_allotment_release_amount"]) - Convert.ToDecimal(obligationRepo["total_obligation_amount"]);

                        var RowData = new object[]
                       {
                            drGetViewRecordsAllotmentReleaseOthersFPP["gen_ledger_acc_id"],
                            drGetViewRecordsAllotmentReleaseOthersFPP["gen_ledger_code"],
                            drGetViewRecordsAllotmentReleaseOthersFPP["account_code"],
                            drGetViewRecordsAllotmentReleaseOthersFPP["gen_ledger_name"],
                            Convert.ToDecimal(totalAllotmentReleaseAmount["total_allotment_release_amount"]),
                            Convert.ToDecimal(obligationRepo["total_obligation_amount"]),
                            unobligatedBalance,
                            drGetViewRecordsAllotmentReleaseOthersFPP["budget_appropriations_id"],
                            drGetViewRecordsAllotmentReleaseOthersFPP["budget_appropriations_year"],
                            drGetViewRecordsAllotmentReleaseOthersFPP["budget_appropriations_amount"],
                            drGetViewRecordsAllotmentReleaseOthersFPP["fund_id"],
                            drGetViewRecordsAllotmentReleaseOthersFPP["fund_code"],
                            drGetViewRecordsAllotmentReleaseOthersFPP["fund_name"],
                            drGetViewRecordsAllotmentReleaseOthersFPP["fpp_id"],
                            drGetViewRecordsAllotmentReleaseOthersFPP["fpp_code"],
                            drGetViewRecordsAllotmentReleaseOthersFPP["fpp_name"],
                            drGetViewRecordsAllotmentReleaseOthersFPP["others_fpp_id"],
                            drGetViewRecordsAllotmentReleaseOthersFPP["others_fpp_name"],
                            drGetViewRecordsAllotmentReleaseOthersFPP["allotment_class_id"],
                            drGetViewRecordsAllotmentReleaseOthersFPP["allotment_class_code"],
                            drGetViewRecordsAllotmentReleaseOthersFPP["allotment_class_name"],
                       };

                        dataGridView.Rows.Add(RowData);
                    }
                }


                //Change Font style for the header of Others FPP
                foreach (DataGridViewRow row in dataGridView.Rows)
                {
                    if (row.Cells[4].Value == null)
                    {
                        dataGridView.Rows[row.Index].DefaultCellStyle.Font = new Font(DataGridView.DefaultFont, FontStyle.Bold);
                    }
                }

                dataGridView.ClearSelection();

            }
            catch (Exception ex)
            {
                Helper.MessageBoxError(ex.Message);
            }
        
        }

        #endregion Obligation Request

    }
}
