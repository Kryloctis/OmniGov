using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Windows.Forms;

namespace AccountingSystem
{
    public class HelperLoadRecords
    {

        #region Year
        internal static void YearComboBox(ComboBox comboBox)
        {
            _ = comboBox.Items.Add("2021");
            comboBox.SelectedIndex = 0;
        }

        #endregion

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
        internal static void GeneralLedgerAccountsWithBalancesDatagridView(DataTable dataTable, DataGridView datagrid, byte fundsId, short year)
        {
            _ = dataTable.Columns.Add("Balance", typeof(decimal));
            _ = dataTable.Columns.Add("Type", typeof(string));

            foreach (DataRow item in dataTable.Rows)
            {
                ushort generalLedgerId = (ushort)item["general_ledger_accounts_id"];

                var beginningBalanceRepository = Factory.BeginningBalancesRepository();
                decimal generalLedgerBalance = beginningBalanceRepository.GetSumBalanceByGeneralLedgerId(fundsId, generalLedgerId, year);
                var beginningBalanceDict = beginningBalanceRepository.GetRecordByFundsAndGeneralLedgerID(fundsId, generalLedgerId, year);
                string debitCreditType = string.Empty;
                debitCreditType = ValidateDebitOrCreditType(beginningBalanceDict, debitCreditType);

                item["Balance"] = generalLedgerBalance;
                item["Type"] = debitCreditType;
            }

            datagrid.DataSource = dataTable;
            datagrid.Columns[0].Visible = false;
            datagrid.Columns[1].HeaderText = "Code";
            datagrid.Columns[2].HeaderText = "Name";
            datagrid.Columns[2].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            datagrid.Columns[3].Visible = false;
            datagrid.Columns[4].Visible = false;
            datagrid.Columns[5].DefaultCellStyle.Format = "N2";
            datagrid.Columns[5].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
        }

        private static string ValidateDebitOrCreditType(Dictionary<string, string> beginningBalanceDict, string debitCreditType)
        {
            // check if naay sulod ang dictionary
            if (beginningBalanceDict.Count != 0)
            {
                // kung dili empty or null ang is_debit value
                if (!string.IsNullOrWhiteSpace(beginningBalanceDict["is_debit"]))
                {
                    if (beginningBalanceDict["is_debit"] == "1")
                        debitCreditType = "Debit";
                    else
                        debitCreditType = "Credit";
                }
            }

            return debitCreditType;
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

        internal static void GeneralLedgerListBox(DataTable dataTable, ListBox listBox)
        {
            foreach (DataRow item in dataTable.Rows)
            {
                item["ledger_name"] = $"{item["account_code"]} - {item["ledger_name"]}";
            }

            listBox.DisplayMember = "ledger_name";
            listBox.ValueMember = "general_ledger_accounts_id";
            listBox.DataSource = dataTable;
        }
        #endregion

        #region Subsidiary Ledgers
        internal static void SubsidiaryLedgerAccountsDatagridView(DataTable dataTable, DataGridView datagrid, byte fundsId, short year)
        {
            _ = dataTable.Columns.Add("Balance", typeof(decimal));
            _ = dataTable.Columns.Add("Type", typeof(string));

            foreach (DataRow item in dataTable.Rows)
            {
                ushort generalLedgerId = (ushort)item["general_ledger_accounts_id"];
                ushort subsidiaryLedgerId = Convert.ToUInt16(item["id"]);
                string debitCreditType = string.Empty;

                var beginningBalanceRepository = Factory.BeginningBalancesRepository();
                decimal generalLedgerBalance = beginningBalanceRepository.GetSumBalanceByGeneralLedgerId(fundsId, generalLedgerId, year, subsidiaryLedgerId);
                var beginningBalanceDict = beginningBalanceRepository.GetRecordByFundsAndGeneralLedgerID(fundsId, generalLedgerId, year, subsidiaryLedgerId);

                debitCreditType = ValidateDebitOrCreditType(beginningBalanceDict, debitCreditType);


                item["Balance"] = generalLedgerBalance;
                item["Type"] = debitCreditType;

            }

            datagrid.DataSource = dataTable;
            datagrid.Columns["id"].Visible = false;
            datagrid.Columns["funds_id"].Visible = false;
            datagrid.Columns["general_ledger_accounts_id"].Visible = false;
            datagrid.Columns["sub_code"].HeaderText = "Code";
            datagrid.Columns["sub_code"].Width = 200;
            datagrid.Columns["sub_name"].HeaderText = "Name";
            datagrid.Columns["sub_name"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            datagrid.Columns["Balance"].DefaultCellStyle.Format = "N2";
            datagrid.Columns["Balance"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            datagrid.Columns["created_at"].Visible = false;
            datagrid.Columns["updated_at"].Visible = false;
        }

        internal static void SubsidiaryLedgerComboBox(DataTable dataTable, ComboBox comboBox, string displayMember, string valueMember)
        {
            comboBox.DisplayMember = displayMember;
            comboBox.ValueMember = valueMember;
            comboBox.DataSource = dataTable;

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

        internal static void OthersFPPCombobox(DataTable dataTable, ComboBox comboBox, string displayMember, string valueMember) 
        {
            try
            {
                comboBox.DataSource = dataTable;
                comboBox.DisplayMember = displayMember;
                comboBox.ValueMember = valueMember;
                comboBox.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
                comboBox.AutoCompleteSource = AutoCompleteSource.ListItems;
            }
            catch (Exception ex)
            {
                Helper.MessageBoxError(ex.Message);
            }
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

        #region Allotment Release Details

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

        #endregion Allotment Release Details

        #region Allotment Release

        internal static void ObjectExpendituresCombobox(ComboBox comboBox, DataTable dataTable, string displayMember, string valueMember)
        {
            comboBox.DataSource = dataTable;
            comboBox.DisplayMember = displayMember;
            comboBox.ValueMember = valueMember;
            comboBox.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            comboBox.AutoCompleteSource = AutoCompleteSource.ListItems;
        }

        #endregion Allotment Release

        #region Obligation Request

        internal static void ObligationRequestFundsCombobox(DataTable dataTable, ComboBox comboBox, string displayMember, string valueMember) 
        {
            comboBox.DataSource = dataTable;
            comboBox.DisplayMember = displayMember;
            comboBox.ValueMember = valueMember;
            comboBox.DropDownHeight = 200;
        }

        internal static void ObligationRequestFPPCombobox(DataTable dataTable, ComboBox comboBox, string displayMember, string valueMember)
        {
            comboBox.DataSource = dataTable;
            comboBox.DisplayMember = displayMember;
            comboBox.ValueMember = valueMember;
            comboBox.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            comboBox.AutoCompleteSource = AutoCompleteSource.ListItems;
            comboBox.DropDownHeight = 200;
        }

        internal static void ObligationRequestOthersFPPCombobox(DataTable dataTable, ComboBox comboBox, string displayMember, string valueMember) 
        {
            comboBox.DataSource = dataTable;
            comboBox.DisplayMember = displayMember;
            comboBox.ValueMember = valueMember;
            comboBox.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            comboBox.AutoCompleteSource = AutoCompleteSource.ListItems;
            comboBox.DropDownHeight = 200;
        }

        internal static void ObligationRequestAllotmentClassesCombobox(DataTable dataTable, ComboBox comboBox, string displayMember, string valueMember) 
        {
            comboBox.DataSource = dataTable;
            comboBox.DisplayMember = displayMember;
            comboBox.ValueMember = valueMember;
            comboBox.DropDownHeight = 200;
        }

        internal static void ObligationRequestAccountCombobox(DataTable dataTable, ComboBox comboBox, string displayMember, string valueMember) 
        {
            comboBox.DataSource = dataTable;
            comboBox.DisplayMember = displayMember;
            comboBox.ValueMember = valueMember;
            comboBox.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            comboBox.AutoCompleteSource = AutoCompleteSource.ListItems;
            comboBox.DropDownHeight = 200;
        }

        #endregion Obligation Request

    }
}
