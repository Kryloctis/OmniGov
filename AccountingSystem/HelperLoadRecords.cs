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
                var beginningBalanceDict = beginningBalanceRepository.GetRecordByGeneralLedgerAndFundsID(fundsId, generalLedgerId, year);
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
                var beginningBalanceDict = beginningBalanceRepository.GetRecordByGeneralLedgerAndFundsID(fundsId, generalLedgerId, year, subsidiaryLedgerId);

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

        internal static void BudgetAppropriationsDgV(DataGridView dgvBudgetAppropriations, int fppID, int allotmentClassID, int typeOfFundsID, Int16 year, TextBox txtTotalAppropriation)
        {
            try
            {
                //Clearing Datagrid View  Rows & Columns before Loading new one
                dgvBudgetAppropriations.Rows.Clear();
                dgvBudgetAppropriations.Columns.Clear();

                //Set up new Columns to Datagrid View
                dgvBudgetAppropriations.Columns.Add("budget_appropriations_id", "Budget Appropriation ID");
                dgvBudgetAppropriations.Columns.Add("fpp_id", "FPP ID");
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

                //Set up Column Format 
                dgvBudgetAppropriations.Columns[0].Visible = false;
                dgvBudgetAppropriations.Columns[1].Visible = false;
                dgvBudgetAppropriations.Columns[2].Visible = false;
                dgvBudgetAppropriations.Columns[3].Visible = false;
                dgvBudgetAppropriations.Columns[4].Visible = false;
                dgvBudgetAppropriations.Columns[7].DefaultCellStyle.Format = "N2";
                dgvBudgetAppropriations.Columns[7].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                dgvBudgetAppropriations.Columns[8].DefaultCellStyle.Format = "N2";
                dgvBudgetAppropriations.Columns[8].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                dgvBudgetAppropriations.Columns[9].DefaultCellStyle.Format = "N2";
                dgvBudgetAppropriations.Columns[9].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                dgvBudgetAppropriations.Columns[10].Visible = false;
                dgvBudgetAppropriations.Columns[11].Visible = false;

                //Initialize Repository Method
                DataTable dtGetViewRecordsByFFPIDByAllotmentClass = Factory.BudgetAppropriationsRepository().GetViewRecordsByIds(fppID, allotmentClassID, null, typeOfFundsID, year);

                //Load by loop All Budget Appropriations Records without Others FPP 
                foreach (DataRow drGetViewRecordsByIds in dtGetViewRecordsByFFPIDByAllotmentClass.Rows)
                {
                    dgvBudgetAppropriations.Rows.Add(new object[] {
                        drGetViewRecordsByIds["budget_appropriations_id"],
                        drGetViewRecordsByIds["fpp_id"],
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
               
                    dgvBudgetAppropriations.Rows.Add(new object[] { null, null, null, null, null, othersFPPName });

                    DataTable dtGetViewRecordsByIds = Factory.BudgetAppropriationsRepository().GetViewRecordsByIds(fppID, allotmentClassID, othersFPPID, typeOfFundsID, year);
                    foreach (DataRow drGetViewRecordsByIds in dtGetViewRecordsByIds.Rows)
                    {
                        dgvBudgetAppropriations.Rows.Add(new object[] {
                        drGetViewRecordsByIds["budget_appropriations_id"],
                        drGetViewRecordsByIds["fpp_id"],
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
                    if (row.Cells[1].Value == null)
                    {
                        dgvBudgetAppropriations.Rows[row.Index].DefaultCellStyle.Font = new Font(DataGridView.DefaultFont, FontStyle.Bold);
                    }
                }

                //Show Total Value s
                decimal totalAppropriation = 0;
                for (int i = 0; i < dgvBudgetAppropriations.Rows.Count; i++)
                {
                    totalAppropriation += Convert.ToDecimal(dgvBudgetAppropriations.Rows[i].Cells[7].Value);
                }

                txtTotalAppropriation.Text = totalAppropriation.ToString("N2");

                dgvBudgetAppropriations.ClearSelection();
                Helper.DatagridDefaultStyle(dgvBudgetAppropriations, true);
            }
            catch (Exception ex)
            {
                Helper.MessageBoxError(ex.Message);
            }
        }

        internal static void OthersFPPCmbx(DataTable dataTable, ComboBox comboBox, string displayMember, string valueMember) 
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

        internal static void AllotmentCmbx(DataTable dataTable, ComboBox comboBox, string displayMember, string valueMember) 
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
        internal static void AllomentToolStripCmbx(DataTable dataTable, ToolStripComboBox toolStripComboBox, string displayMember, string valueMember)
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

        internal static void TypeOfFundsCmbx(DataTable dataTable, ComboBox comboBox, string displayMember, string valueMember)
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
        internal static void TypeOfFundsToolStripCmbx(DataTable dataTable, ToolStripComboBox comboBox, string displayMember, string valueMember) 
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

        internal static void YearToolStripCmbx(DataTable dataTable, ToolStripComboBox toolStripComboBox, string displayMember, string valueMember)
        {
            toolStripComboBox.ComboBox.DataSource = dataTable;
            toolStripComboBox.ComboBox.DisplayMember = displayMember;
            toolStripComboBox.ComboBox.ValueMember = valueMember;
        }

        internal static void GeneralLedgerAccountsCmbx(DataTable dataTable, ComboBox comboBox, string displayMember, string valueMember) 
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

        internal static void FPPDgVBudgetAppropriations(DataGridView dataGridView) 
        {
            try
            {
                dataGridView.DataSource = Factory.BudgetAppropriationsRepository().GetViewRecordsFPPWithBudgetAppropriations();
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

        internal static void FPPDgVObligationRequest(DataGridView dataGridView, DataTable dataTable) 
        {
            try
            {
                dataGridView.DataSource = dataTable;
                dataGridView.Columns[0].Visible = false;
                dataGridView.Columns[1].HeaderText = "FPP Code";
                dataGridView.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
                dataGridView.Columns[2].HeaderText = "FPP Name";
                dataGridView.ClearSelection();
            }

            catch (Exception ex)
            {
                Helper.MessageBoxError(ex.Message);
            }
        }

        internal static void AllotmentReleaseDgvObligationRequest(DataGridView dataGridView, int fppId, int fundsId, int allotmentClassId, short year) 
        {
            try
            {
                dataGridView.Columns.Clear();
                dataGridView.Rows.Clear();

                //Set up new Columns to Datagrid View
                dataGridView.Columns.Add("total_allotment_release_amount", " Total Allotment Release Amount");
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
                dataGridView.Columns.Add("gen_ledger_acc_id", "Gen. Ledger Acc. ID");
                dataGridView.Columns.Add("gen_ledger_code", "Gen. Ledger Acc. Code");
                dataGridView.Columns.Add("account_code", "Account Code");
                dataGridView.Columns.Add("gen_ledger_name", "Gen. Ledger Acc. Name");


                dataGridView.Columns[0].DefaultCellStyle.Format = "N2";
                dataGridView.Columns[1].Visible = false;
                dataGridView.Columns[2].Visible = false;
                dataGridView.Columns[3].Visible = false;
                dataGridView.Columns[4].Visible = false;
                dataGridView.Columns[5].Visible = false;
                dataGridView.Columns[6].Visible = false;
                dataGridView.Columns[7].Visible = false;
                dataGridView.Columns[8].Visible = false;
                dataGridView.Columns[9].Visible = false;
                dataGridView.Columns[10].Visible = false;
                dataGridView.Columns[11].Visible = false;
                dataGridView.Columns[12].Visible = false;
                dataGridView.Columns[13].Visible = false;
                dataGridView.Columns[14].Visible = false;
                dataGridView.Columns[15].Visible = false;
                dataGridView.Columns[16].Visible = false;


                //Initialize Repository Method
                DataTable dtGetViewRecordsAllotmentRelease = Factory.AllotmentReleaseRepository().GetViewRecords(fppId, null, fundsId, allotmentClassId, year);


                //Load by loop All Budget Appropriations Records without Others FPP 
                foreach (DataRow drGetViewRecords in dtGetViewRecordsAllotmentRelease.Rows)
                {
                    dataGridView.Rows.Add(new object[] 
                    {
                        drGetViewRecords["total_allotment_release_amount"],
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
                        drGetViewRecords["gen_ledger_acc_id"],
                        drGetViewRecords["gen_ledger_code"],
                        drGetViewRecords["account_code"],
                        drGetViewRecords["gen_ledger_name"],
                    });
                }



                //Initialize Repository Method
                DataTable dtGetOthersFPPRecords = Factory.AllotmentReleaseRepository().GetOthersFPPRecords(fppId ,allotmentClassId, fundsId, year);

                //Load by loop All Budget Appropriations Records with Others FPP 
                foreach (DataRow drGetOthersFPPRecords in dtGetOthersFPPRecords.Rows)
                {
                    string othersFPPName = drGetOthersFPPRecords["others_fpp_name"].ToString();
                    int othersFPPID = Convert.ToInt32(drGetOthersFPPRecords["others_fpp_id"]);

                    dataGridView.Rows.Add(new object[] { othersFPPName });

                    //Initialize Repository Method for w Others FPP Records
                    DataTable dtGetViewRecordsAllotmentReleaseOthersFPP = Factory.AllotmentReleaseRepository().GetViewRecords(fppId, othersFPPID, fundsId, allotmentClassId, year);


                    //Load by loop All Budget Appropriations Records without Others FPP 
                    foreach (DataRow drGetViewRecordsAllotmentReleaseOthersFPP in dtGetViewRecordsAllotmentReleaseOthersFPP.Rows)
                    {
                        dataGridView.Rows.Add(new object[]
                        {
                        drGetViewRecordsAllotmentReleaseOthersFPP["total_allotment_release_amount"],
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
                        drGetViewRecordsAllotmentReleaseOthersFPP["gen_ledger_acc_id"],
                        drGetViewRecordsAllotmentReleaseOthersFPP["gen_ledger_code"],
                        drGetViewRecordsAllotmentReleaseOthersFPP["account_code"],
                        drGetViewRecordsAllotmentReleaseOthersFPP["gen_ledger_name"],
                        });
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
