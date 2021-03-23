using System;
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

        internal static void FuntionProjectProgramDatagridView(DataTable dataTable, DataGridView datagrid)
        {
            datagrid.DataSource = dataTable;
            datagrid.Columns[0].Visible = false;
            datagrid.Columns[1].HeaderText = "Service Name";
            datagrid.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            datagrid.Columns[2].HeaderText = "Code";
            datagrid.Columns[3].HeaderText = "Name";
            datagrid.Columns[3].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            datagrid.Columns[4].Visible = false;
            datagrid.Columns[5].Visible = false;
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


        //BUDGET SYSTEM

        #region BudgetAppropriations

        public static void BudgetAppropriationsDataGridView(DataGridView dgvBudgetAppropriations, int fppID, int allotmentClassID, int typeOfFundsID, Int16 year)
        {
            try
            {
                //Clearing Datagrid View  Rows & Columns before Loading new one
                dgvBudgetAppropriations.Rows.Clear();
                dgvBudgetAppropriations.Columns.Clear();

                //Set up new Columns to Datagrid View
                dgvBudgetAppropriations.Columns.Add(null, null);
                dgvBudgetAppropriations.Columns.Add("budget_appropriations_id", "Budget Appropriation ID");
                dgvBudgetAppropriations.Columns.Add("fpp_id", "FPP ID");
                dgvBudgetAppropriations.Columns.Add("others_fpp_id", "Others FPP ID");
                dgvBudgetAppropriations.Columns.Add("allotment_classes_id", "Allotment Classes ID");
                dgvBudgetAppropriations.Columns.Add("general_ledger_acc_id", "Gen. Ledger Acc. ID");
                dgvBudgetAppropriations.Columns.Add("ledger_name", "Object of Expenditures");
                dgvBudgetAppropriations.Columns.Add("account_code", "Account Code");
                dgvBudgetAppropriations.Columns.Add("amount", "Amount");
                dgvBudgetAppropriations.Columns.Add("created_at", "Created at");
                dgvBudgetAppropriations.Columns.Add("updated_at", "Updated at");

                //Set up Column Format 
                dgvBudgetAppropriations.Columns[0].DefaultCellStyle.Font = new Font(dgvBudgetAppropriations.Font, FontStyle.Bold);
                dgvBudgetAppropriations.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
                dgvBudgetAppropriations.Columns[1].Visible = false;
                dgvBudgetAppropriations.Columns[2].Visible = false;
                dgvBudgetAppropriations.Columns[3].Visible = false;
                dgvBudgetAppropriations.Columns[4].Visible = false;
                dgvBudgetAppropriations.Columns[5].Visible = false;
                dgvBudgetAppropriations.Columns[8].DefaultCellStyle.Format = "N2";
                dgvBudgetAppropriations.Columns[8].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                dgvBudgetAppropriations.Columns[9].Visible = false;
                dgvBudgetAppropriations.Columns[10].Visible = false;

                //Initialize Repository Method
                DataTable dtGetViewRecordsByFFPIDByAllotmentClass = Factory.BudgetAppropriationsRepository().GetViewRecordsByIds(fppID, allotmentClassID, null, typeOfFundsID, year);

                //Load by loop All Budget Appropriations Records without Others FPP 
                foreach (DataRow drGetViewRecordsByFFPIDByAllotmentClass in dtGetViewRecordsByFFPIDByAllotmentClass.Rows)
                {
                    dgvBudgetAppropriations.Rows.Add(new object[] { null,
                        drGetViewRecordsByFFPIDByAllotmentClass["budget_appropriations_id"],
                        drGetViewRecordsByFFPIDByAllotmentClass["fpp_id"],
                        drGetViewRecordsByFFPIDByAllotmentClass["others_fpp_id"],
                        drGetViewRecordsByFFPIDByAllotmentClass["allotment_classes_id"],
                        drGetViewRecordsByFFPIDByAllotmentClass["general_ledger_acc_id"],
                        drGetViewRecordsByFFPIDByAllotmentClass["ledger_name"],
                        drGetViewRecordsByFFPIDByAllotmentClass["account_code"],
                        drGetViewRecordsByFFPIDByAllotmentClass["amount"],
                        drGetViewRecordsByFFPIDByAllotmentClass["created_at"],
                        drGetViewRecordsByFFPIDByAllotmentClass["updated_at"] });
                }

                //Initialize Repository Method
                DataTable dtGetRecordsOthersFPP = Factory.BudgetAppropriationsRepository().GetExistedOthersFPPrecordsByFPPID(fppID, allotmentClassID, typeOfFundsID, year);

                //If FPP Record doesn't have Others FPP at all Column Others Name Indication will be hidden
                if (dtGetRecordsOthersFPP.Rows.Count < 1)
                    dgvBudgetAppropriations.Columns[0].Visible = false;

                //Load by loop All Budget Appropriations Records with Others FPP 
                foreach (DataRow drGetRecordsOthersFPP in dtGetRecordsOthersFPP.Rows)
                {
                    string othersFPPName = drGetRecordsOthersFPP["others_fpp_name"].ToString();
                    int othersFPPID = Convert.ToInt32(drGetRecordsOthersFPP["others_fpp_id"]);

                    dgvBudgetAppropriations.Rows.Add(othersFPPName);

                    DataTable dtGetViewRecordsByIds = Factory.BudgetAppropriationsRepository().GetViewRecordsByIds(fppID, allotmentClassID, othersFPPID, typeOfFundsID, year);
                    foreach (DataRow drGetViewRecordsByIds in dtGetViewRecordsByIds.Rows)
                    {
                        dgvBudgetAppropriations.Rows.Add(new object[] { null,
                            drGetViewRecordsByIds["budget_appropriations_id"],
                            drGetViewRecordsByIds["fpp_id"],
                            drGetViewRecordsByIds["others_fpp_id"],
                            drGetViewRecordsByIds["allotment_classes_id"],
                            drGetViewRecordsByIds["general_ledger_acc_id"],
                            drGetViewRecordsByIds["ledger_name"],
                            drGetViewRecordsByIds["account_code"],
                            drGetViewRecordsByIds["amount"],
                            drGetViewRecordsByIds["created_at"],
                            drGetViewRecordsByIds["updated_at"] });
                    }
                }

                dgvBudgetAppropriations.ClearSelection();
                Helper.DatagridDefaultStyle(dgvBudgetAppropriations, true);
            }
            catch (Exception ex)
            {
                Helper.MessageBoxError(ex.Message);
            }
        }

        public static void FPPCombobox(DataTable dataTable, ComboBox comboBox, string displayMember, string valueMember)
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

        public static void OthersFPPCombobox(DataTable dataTable, ComboBox comboBox, string displayMember, string valueMember) 
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

        public static void AllotmentCombobox(DataTable dataTable, ComboBox comboBox, string displayMember, string valueMember) 
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
        public static void AllomentToolStripCombobox(DataTable dataTable, ToolStripComboBox toolStripComboBox, string displayMember, string valueMember)
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

        public static void TypeOfFundsCombobox(DataTable dataTable, ComboBox comboBox, string displayMember, string valueMember)
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
        public static void TypeOfFundsToolStripCombobox(DataTable dataTable, ToolStripComboBox comboBox, string displayMember, string valueMember) 
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


        public static void YearCombobox(DataTable dataTable, ComboBox comboBox, string displayMember, string valueMember)
        {
            comboBox.DataSource = dataTable;
            comboBox.DisplayMember = displayMember;
            comboBox.ValueMember = valueMember;
        }
        public static void YearToolStripCombobox(DataTable dataTable, ToolStripComboBox toolStripComboBox, string displayMember, string valueMember)
        {
            toolStripComboBox.ComboBox.DataSource = dataTable;
            toolStripComboBox.ComboBox.DisplayMember = displayMember;
            toolStripComboBox.ComboBox.ValueMember = valueMember;
        }

        public static void GeneralLedgerAccountsCombobox(DataTable dataTable, ComboBox comboBox, string displayMember, string valueMember) 
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

        public static void FPPDatagridViewRecords(DataGridView dataGridView) 
        {
            try
            {
                dataGridView.DataSource = Factory.BudgetAppropriationsRepository().GetViewRecordsFPP();
                dataGridView.Columns[0].Visible = false;
                dataGridView.Columns[1].HeaderText = "FPP Code";
                dataGridView.Columns[2].HeaderText = "FPP Name";
                dataGridView.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
                dataGridView.Columns[1].SortMode = DataGridViewColumnSortMode.NotSortable;
                dataGridView.Columns[2].SortMode = DataGridViewColumnSortMode.NotSortable;

                Helper.DatagridDefaultStyle(dataGridView, true);
            }
            catch (Exception ex) 
            {
                Helper.MessageBoxError(ex.Message);
            }
        }

        public static void LoadBudgetAppropriationDetailsLabels(int budgetAppropriationID, int fppID, int? othersFPPID, int allotmentClassesID, int generalLedgerAccID, Label lblFPPCode, Label lblFPP, Label lblOtherFPP, Label lblAccountCode, Label lblAllotmentClass, Label lblGenLedgerAcc, Label lblYear, Label lblAmount) 
        {
            try
            {
                var selectedBudgetAppropriation = Factory.BudgetAppropriationsRepository().GetViewRecordByIDs(budgetAppropriationID, fppID, othersFPPID, allotmentClassesID, generalLedgerAccID);

                lblFPPCode.Text = selectedBudgetAppropriation["fpp_code"].ToString();
                lblFPP.Text = selectedBudgetAppropriation["fpp_name"].ToString();

                //if others fpp was null
                if (string.IsNullOrEmpty(selectedBudgetAppropriation["others_fpp_name"]))
                    lblOtherFPP.Text = string.Empty;
                else
                    lblOtherFPP.Text = selectedBudgetAppropriation["others_fpp_name"];

                lblAccountCode.Text = selectedBudgetAppropriation["account_code"].ToString();
                lblAllotmentClass.Text = selectedBudgetAppropriation["allotment_code"].ToString();
                lblGenLedgerAcc.Text = selectedBudgetAppropriation["ledger_name"].ToString();
                lblYear.Text = selectedBudgetAppropriation["year"].ToString();
                lblAmount.Text = Convert.ToDecimal(selectedBudgetAppropriation["amount"]).ToString("N2");

            }
            catch (Exception ex)
            {
                Helper.MessageBoxError(ex.Message);
            }
        }

        public static void dgAllotmentRelease(DataTable dataTable, DataGridView dgv, int budgetAppropriationID) 
        {
            try
            {
                //Clearing Datagrid View  Rows & Columns before Loading new one
                dgv.Rows.Clear();
                dgv.Columns.Clear();

                //Set up new Columns to Datagrid View
                dgv.Columns.Add("id","id");
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

        #endregion BudgetAppropriations

    }
}
