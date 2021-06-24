using ACC.Domain.Models;
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
            datagrid.Columns["id"].Visible = false;
            datagrid.Columns["office"].HeaderText = "Office";
            datagrid.Columns["role_name"].HeaderText = "Role Name";
            datagrid.Columns["created_at"].Visible = false;
            datagrid.Columns["updated_at"].Visible = false;

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

        internal static void PermissionsDatagridView(DataTable dataTable, DataGridView datagrid)
        {
            datagrid.DataSource = dataTable;
            //datagrid.Columns["id"].Visible = false;
            datagrid.Columns["permission_name"].HeaderText = "Permission";

            datagrid.RowHeadersVisible = false;
            datagrid.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
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
            comboBox.DropDownHeight = 150;

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

        internal static void SubsidiaryLedgerAccountsDatagridView(DataTable dataTable, DataGridView datagrid)
        {
            datagrid.DataSource = dataTable;
            datagrid.Columns[0].Visible = false;
            datagrid.Columns[1].Visible = false;
            datagrid.Columns[2].Visible = false;
            datagrid.Columns[3].HeaderText = "Code";
            datagrid.Columns[4].HeaderText = "Name";
            datagrid.Columns[5].Visible = false;
            datagrid.Columns[6].Visible = false;

            datagrid.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
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

        #region Banks
        internal static void BanksDatagridView(DataTable dataTable, DataGridView datagrid)
        {
            datagrid.DataSource = dataTable;
            datagrid.Columns[0].Visible = false;
            datagrid.Columns[1].HeaderText = "Account No.";
            datagrid.Columns[2].HeaderText = "Bank Name";
            datagrid.Columns[3].Visible = false;
            datagrid.Columns[4].Visible = false; 

            datagrid.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }
        #endregion

        #region Banks Deposits
        internal static void DepositsDatagridView(DataTable dataTable, DataGridView datagrid)
        {
            datagrid.DataSource = dataTable;
            datagrid.Columns[0].Visible = false;
            datagrid.Columns[1].HeaderText = "Account No.";
            datagrid.Columns[2].HeaderText = "Bank Name";
            datagrid.Columns[3].HeaderText = "Reference";
            datagrid.Columns[4].HeaderText = "Date";
            datagrid.Columns[5].HeaderText = "Amount";
            datagrid.Columns[6].Visible = false;
            datagrid.Columns[7].Visible = false;
            datagrid.Columns[8].Visible = false;
            datagrid.Columns[9].Visible = false;

            datagrid.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }
        #endregion
        #region Collector Report
        internal static void CollectorReportDatagridView(DataTable dataTable, DataGridView datagrid)
        {
            datagrid.Columns.Clear();
            datagrid.DataSource = dataTable;
           
            datagrid.Columns[0].Visible = false;
            datagrid.Columns[1].HeaderText = "Report No.";
            datagrid.Columns[2].HeaderText = "Date";
            datagrid.Columns[3].HeaderText = "Collector";
            DataGridViewCheckBoxColumn chk = new DataGridViewCheckBoxColumn();
            datagrid.Columns.Add(chk);
            chk.HeaderText = "Print";


            datagrid.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }
        #endregion
        #region RCI
        internal static void RCIDatagridView(DataTable dataTable, DataGridView datagrid)
        {
            datagrid.DataSource = dataTable;
            datagrid.Columns[0].Visible = false;
            datagrid.Columns[1].HeaderText = "Account No.";
            datagrid.Columns[2].HeaderText = "Bank Name";
            datagrid.Columns[3].HeaderText = "Check Date";
            datagrid.Columns[4].HeaderText = "Check Number";
            datagrid.Columns[5].HeaderText = "DV No.";
            datagrid.Columns[6].HeaderText = "Payee";
            datagrid.Columns[7].HeaderText = "Nature of Payment";
            datagrid.Columns[8].HeaderText = "OBR No.";
            datagrid.Columns[9].HeaderText = "Functional Code";
            datagrid.Columns[10].HeaderText = "Trust Liabilities";
            datagrid.Columns[11].HeaderText = "BIR VAT/Non-VAT";
            datagrid.Columns[12].HeaderText = "Amount";
            datagrid.Columns[13].HeaderText = "Net Amount";
            datagrid.Columns[14].Visible = false;
            datagrid.Columns[15].Visible = false;
            datagrid.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }
        #endregion

        #region PaymentCollection
        internal static void PaymentDatagridView(DataTable dataTable, DataGridView datagrid)
        {
            datagrid.DataSource = dataTable;            
            datagrid.Columns[0].Visible = false;
            datagrid.Columns[1].HeaderText = "RCD No.";
            datagrid.Columns[2].HeaderText = "Account Code";
            datagrid.Columns[3].HeaderText = "Accountable Form";
            datagrid.Columns[4].HeaderText = "Ledger";
            datagrid.Columns[5].HeaderText = "Subsidiary";
            datagrid.Columns[6].HeaderText = "Payee";
            datagrid.Columns[7].HeaderText = "Receipt No.";
            datagrid.Columns[8].HeaderText = "Payment Date";
            datagrid.Columns[9].HeaderText = "Amount";
            datagrid.Columns[9].DefaultCellStyle.Format = "N2";
            datagrid.Columns[9].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            datagrid.Columns[10].HeaderText = "Collector";
            datagrid.Columns[11].Visible = false;
            datagrid.Columns[12].Visible = false;
            datagrid.Columns[13].Visible = false;
            datagrid.Columns[14].Visible = false;
            datagrid.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }
        #endregion

        #region AccountableForm
        internal static void AccFormDatagridView(DataTable dataTable, DataGridView datagrid)
        {
            datagrid.DataSource = dataTable;
            datagrid.Columns[0].Visible = false;
            datagrid.Columns[1].HeaderText = "Form No.";
            datagrid.Columns[2].HeaderText = "Form Description";

            datagrid.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }
        #endregion

        #region GeneralLedgerAccountSearch
        internal static void GeneralLedgerSearchDatagridView(DataTable dataTable, DataGridView datagrid)
        {
            datagrid.DataSource = dataTable;
            datagrid.Columns[0].Visible = false;
            datagrid.Columns[1].HeaderText = "Account Code";
            datagrid.Columns[2].HeaderText = "Ledger Name";

            datagrid.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }
        #endregion

        internal static void BanksComboBox(DataTable dataTable, ComboBox comboBox, string displayMember, string valueMember)
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

        internal static void frmFunctionProjectProgramDatagridView(DataTable dataTable, DataGridView datagrid)
        {

            //Clearing Datagrid View  Rows & Columns before Loading new one
            datagrid.Rows.Clear();
            datagrid.Columns.Clear();


            Image continuingIcon = Properties.Resources.ok14px;

            DataGridViewImageColumn imgColumn = new DataGridViewImageColumn();

            imgColumn.HeaderText = "Special";
            imgColumn.Name = "is_special";


            datagrid.Columns.Add("id", "FPP ID");
            datagrid.Columns.Add("service_name", "Service Name");
            datagrid.Columns.Add("fpp_code", "Code");
            datagrid.Columns.Add("fpp_name", "Name");
            datagrid.Columns.Add(imgColumn);
            datagrid.Columns.Add("created_at", "Created at");
            datagrid.Columns.Add("updated_at", "Updated at");


            datagrid.Columns["id"].Visible = false;
            datagrid.Columns["fpp_code"].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
            datagrid.Columns["created_at"].Visible = false;
            datagrid.Columns["updated_at"].Visible = false;

            datagrid.Columns["is_special"].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
            datagrid.Columns["is_special"].DefaultCellStyle.NullValue = null;

            foreach (DataRow item in dataTable.Rows) 
            {
                int fppId = Convert.ToInt32(item["id"]);
                string serviceName = item["service_name"].ToString();
                string fppCode = item["fpp_code"].ToString();
                string fppName = item["fpp_name"].ToString();
                byte isSpecial = Convert.ToByte(item["is_special"]);

                var items = new object[]
                {
                    fppId,
                    serviceName,
                    fppCode,
                    fppName,
                    isSpecial == 0? null :  continuingIcon,
                    item["created_at"],
                    item["updated_at"]
                };

                datagrid.Rows.Add(items);
                Helper.DatagridDefaultStyle(datagrid, true);
                datagrid.ClearSelection();
            }

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
            comboBox1.DropDownHeight = 300;

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

        #region Disbursing Officer

        internal static void DisbursingOfficerDatagridView(DataTable dataTable, DataGridView datagrid)
        {
            datagrid.DataSource = dataTable;
            datagrid.Columns[0].Visible = false;
            datagrid.Columns[1].HeaderText = "Full Name";
            datagrid.Columns[2].HeaderText = "Job Title";
            datagrid.Columns[3].Visible = false;
            datagrid.Columns[4].Visible = false;

            datagrid.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }

        internal static void DisbursingOfficerComboBox(DataTable dataTable, ComboBox comboBox, string displayMember, string valueMember)
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
            dataGridView.Columns["id"].Visible = false;
            dataGridView.Columns["function_program_project_id"].Visible = false;
            dataGridView.Columns["others_fpp_code"].HeaderText = "Code";
            dataGridView.Columns["name"].HeaderText = "Name";
            dataGridView.Columns["created_at"].Visible = false;
            dataGridView.Columns["updated_at"].Visible = false;
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

        internal static void BudgetAppropriationsDatagridView(DataGridView dgvBudgetAppropriations, int fppID, int allotmentClassID, int fundId, short year, TextBox txtTotalAppropriation)
        {
            try
            {
                //Image Column
                Image continuingIcon = Properties.Resources.ok14px; 

                DataGridViewImageColumn imgColumn = new DataGridViewImageColumn();

                imgColumn.HeaderText = "Continuing";
                imgColumn.Name = "continuing";


                //Clearing Datagrid View  Rows & Columns before Loading new one
                dgvBudgetAppropriations.Rows.Clear();
                dgvBudgetAppropriations.Columns.Clear();

                //Set up new Columns to Datagrid View
                dgvBudgetAppropriations.Columns.Add("id", "Budget Appropriation ID");
                dgvBudgetAppropriations.Columns.Add("funds_id", "Fund ID");
                dgvBudgetAppropriations.Columns.Add("fpp_id", "FPP ID");
                dgvBudgetAppropriations.Columns.Add("others_fpp_id", "Others FPP ID");
                dgvBudgetAppropriations.Columns.Add("allotment_class_id", "Allotment Classes ID");
                dgvBudgetAppropriations.Columns.Add("general_ledger_accounts_id", "Gen. Ledger Acc. ID");
                dgvBudgetAppropriations.Columns.Add("general_ledger_accounts_name", "Object of Expenditures");
                dgvBudgetAppropriations.Columns.Add("account_code", "Account Code");
                dgvBudgetAppropriations.Columns.Add("date_entry", "Date Entry");
                dgvBudgetAppropriations.Columns.Add("amount", "Appropriation");
                dgvBudgetAppropriations.Columns.Add("totalAllotmentRelease", "Total Allotment Release");
                dgvBudgetAppropriations.Columns.Add("appropriationBalance", "Appropriation Balance");
                dgvBudgetAppropriations.Columns.Add("year", "Year");
                dgvBudgetAppropriations.Columns.Add(imgColumn);
                dgvBudgetAppropriations.Columns.Add("remarks", "Remarks");
                dgvBudgetAppropriations.Columns.Add("created_at", "Created at");
                dgvBudgetAppropriations.Columns.Add("updated_at", "Updated at");

                //Column's Visibility
                dgvBudgetAppropriations.Columns["id"].Visible = false;
                dgvBudgetAppropriations.Columns["funds_id"].Visible = false;
                dgvBudgetAppropriations.Columns["fpp_id"].Visible = false;
                dgvBudgetAppropriations.Columns["year"].Visible = false;
                dgvBudgetAppropriations.Columns["others_fpp_id"].Visible = false;
                dgvBudgetAppropriations.Columns["allotment_class_id"].Visible = false;
                dgvBudgetAppropriations.Columns["general_ledger_accounts_id"].Visible = false;
                dgvBudgetAppropriations.Columns["date_entry"].Visible = false;
                dgvBudgetAppropriations.Columns["created_at"].Visible = false;
                dgvBudgetAppropriations.Columns["updated_at"].Visible = false;

                //Column's Format
                int amountColumWidth = 145;
                dgvBudgetAppropriations.Columns["general_ledger_accounts_name"].Width = 300;

                dgvBudgetAppropriations.Columns["account_code"].Resizable = DataGridViewTriState.False;
                dgvBudgetAppropriations.Columns["account_code"].Width = 100;
                dgvBudgetAppropriations.Columns["account_code"].MinimumWidth = 100;


                dgvBudgetAppropriations.Columns["amount"].Resizable = DataGridViewTriState.False;
                dgvBudgetAppropriations.Columns["amount"].Width = amountColumWidth;
                dgvBudgetAppropriations.Columns["amount"].MinimumWidth = amountColumWidth;
                dgvBudgetAppropriations.Columns["amount"].DefaultCellStyle.Format = "N2";
                dgvBudgetAppropriations.Columns["amount"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;

                dgvBudgetAppropriations.Columns["totalAllotmentRelease"].Resizable = DataGridViewTriState.False;
                dgvBudgetAppropriations.Columns["totalAllotmentRelease"].Width = amountColumWidth;
                dgvBudgetAppropriations.Columns["totalAllotmentRelease"].MinimumWidth = amountColumWidth;
                dgvBudgetAppropriations.Columns["totalAllotmentRelease"].DefaultCellStyle.Format = "N2";
                dgvBudgetAppropriations.Columns["totalAllotmentRelease"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;

                dgvBudgetAppropriations.Columns["appropriationBalance"].Resizable = DataGridViewTriState.False;
                dgvBudgetAppropriations.Columns["appropriationBalance"].Width = amountColumWidth;
                dgvBudgetAppropriations.Columns["appropriationBalance"].MinimumWidth = amountColumWidth;
                dgvBudgetAppropriations.Columns["appropriationBalance"].DefaultCellStyle.Format = "N2";
                dgvBudgetAppropriations.Columns["appropriationBalance"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;


                dgvBudgetAppropriations.Columns["continuing"].Resizable = DataGridViewTriState.False;
                dgvBudgetAppropriations.Columns["continuing"].DefaultCellStyle.NullValue = null;
                dgvBudgetAppropriations.Columns["continuing"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dgvBudgetAppropriations.Columns["continuing"].Width = 80;
                dgvBudgetAppropriations.Columns["continuing"].MinimumWidth = 80;

                //Initialize Repository Method
                var budgetAppropriationsModel = new BudgetAppropriationsModel()
                {
                    FunctionProgramProjectId = fppID,
                    AllotmentClassesId = allotmentClassID,
                    FundsId = fundId,
                    Year = year
                };

                budgetAppropriationsModel.OthersFPPId = null;
                
                var dtGetViewRecordsByFFPIDByAllotmentClass = Factory.BudgetAppropriationsRepository().GetViewRecordsByIdsYear(budgetAppropriationsModel);


                //Load by loop All Budget Appropriations Records without Others FPP 
                foreach (DataRow drGetViewRecordsByIds in dtGetViewRecordsByFFPIDByAllotmentClass.Rows)
                {
                    FieldData(dgvBudgetAppropriations, continuingIcon, drGetViewRecordsByIds);
                }


                //Initialize Repository Method for others fpp records
                var dtGetRecordsOthersFPP = Factory.BudgetAppropriationsRepository().GetHeaderOthersFPP(fppID, allotmentClassID, fundId, year);

                //Load by loop All Budget Appropriations Records with Others FPP 
                foreach (DataRow drGetRecordsOthersFPP in dtGetRecordsOthersFPP.Rows)
                {
                    string othersFPPName = drGetRecordsOthersFPP["others_fpp_name"].ToString();
                    int othersFPPID = Convert.ToInt32(drGetRecordsOthersFPP["others_fpp_id"]);
               
                    //Set Header for Others FPP 
                    dgvBudgetAppropriations.Rows.Add(new object[] { null, null, null, null, null, null, othersFPPName });


                    budgetAppropriationsModel.OthersFPPId = othersFPPID;
                    DataTable dtGetViewRecordsByIds = Factory.BudgetAppropriationsRepository().GetViewRecordsByIdsYear(budgetAppropriationsModel);

                    foreach (DataRow drGetViewRecordsByIds in dtGetViewRecordsByIds.Rows)
                    {
                        FieldData(dgvBudgetAppropriations, continuingIcon, drGetViewRecordsByIds);
                    }
                }

                static void FieldData(DataGridView dgvBudgetAppropriations, Image continuingIcon, DataRow drGetViewRecordsByIds)
                {
                    int rowId = Convert.ToInt32(drGetViewRecordsByIds["id"]);
                    int rowFundId = Convert.ToInt32(drGetViewRecordsByIds["funds_id"]);
                    int rowFPPId = Convert.ToInt32(drGetViewRecordsByIds["fpp_id"]);
                    int? rowOthersFPPId = string.IsNullOrWhiteSpace(drGetViewRecordsByIds["others_fpp_id"].ToString()) ? null : Convert.ToInt32(drGetViewRecordsByIds["others_fpp_id"]);
                    int rowAllotmentClassId = Convert.ToInt32(drGetViewRecordsByIds["allotment_class_id"]);
                    int rowAccountId = Convert.ToInt32(drGetViewRecordsByIds["general_ledger_accounts_id"]);
                    string rowAccountName = drGetViewRecordsByIds["general_ledger_accounts_name"].ToString();
                    string rowAccountCode = drGetViewRecordsByIds["account_code"].ToString();
                    DateTime rowDateEntry = Convert.ToDateTime(drGetViewRecordsByIds["date_entry"]);
                    decimal rowAppropriationAmount = Convert.ToDecimal(drGetViewRecordsByIds["amount"]);
                    short rowYear = Convert.ToInt16(drGetViewRecordsByIds["year"]);
                    byte rowContinuing = Convert.ToByte(drGetViewRecordsByIds["continuing"]);
                    string remarks = drGetViewRecordsByIds["remarks"].ToString();

                    //GET TOTAL SUPPLEMENTAL APPROPRIATIONS
                    var dtSupplementalAppropriation = Factory.SupplementalAppropriationsRepository().GetRecordsByBudgetAppropriationId(rowId);
                    decimal totalSupplementalAppropriation = Convert.ToDecimal(dtSupplementalAppropriation.Rows.Count == 0? 0 : dtSupplementalAppropriation.Compute("Sum(amount)", string.Empty));

                    //GET TOTAL ALLOTMENT RELEASE
                    var dtAllotmentRelease = Factory.AllotmentReleaseRepository().GetViewRecordsByBudgetAppropriationId(rowId);
                    decimal totalAllotmentRelease = Convert.ToDecimal(dtAllotmentRelease.Rows.Count == 0 ? 0 : dtAllotmentRelease.Compute("SUM(amount)", string.Empty));

                    //GET TOTAL APPROPRIATION
                    decimal totalAppropriationAmount = totalSupplementalAppropriation + rowAppropriationAmount;

                    decimal appropriationBalance = (totalSupplementalAppropriation + rowAppropriationAmount) - totalAllotmentRelease;

                    dgvBudgetAppropriations.Rows.Add(new object[] {
                        rowId,
                        rowFundId,
                        rowFPPId,
                        rowOthersFPPId,
                        rowAllotmentClassId,
                        rowAccountId,
                        $"    {rowAccountName}",
                        rowAccountCode,
                        rowDateEntry,
                        totalAppropriationAmount,
                        totalAllotmentRelease,
                        appropriationBalance,
                        rowYear,
                        rowContinuing == 1? continuingIcon : null,
                        remarks,
                        drGetViewRecordsByIds["created_at"],
                        drGetViewRecordsByIds["updated_at"] });
                }


                //Change Font style for the header of Others FPP
                foreach (DataGridViewRow row in dgvBudgetAppropriations.Rows)
                {
                    if (row.Cells["fpp_id"].Value == null)
                    {
                        Color backgroundColor = Color.White;

                        row.DefaultCellStyle.Font = new Font(DataGridView.DefaultFont, FontStyle.Bold);
                        row.DefaultCellStyle.BackColor = backgroundColor;
                        row.HeaderCell.Style.BackColor = backgroundColor;
                    }
                }

                //Show Total Values
                decimal totalAppropriation = 0;
                for (int i = 0; i < dgvBudgetAppropriations.Rows.Count; i++)
                {
                    totalAppropriation += Convert.ToDecimal(dgvBudgetAppropriations.Rows[i].Cells["amount"].Value);
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

        #region Supplemental Appropriations

        internal static void SupplementalDatagridView(DataTable dataTable, DataGridView dgv) 
        {
            try
            {
                Helper.DatagridDefaultStyle(dgv, true);

                //Clearing Datagrid View  Rows & Columns before Loading new one
                dgv.Rows.Clear();
                dgv.Columns.Clear();

                //Set up new Columns to Datagrid View
                dgv.Columns.Add("id", "id");
                dgv.Columns.Add("budget_appropriations_id", "Budget Appropriation ID");
                dgv.Columns.Add("date_entry", "Date Entry");
                dgv.Columns.Add("amount", "Amount");
                dgv.Columns.Add("remarks", "Remarks");
                dgv.Columns.Add("created_at", "Created at");
                dgv.Columns.Add("updated_at", "Updated at");

                //Set up Column Format
                dgv.Columns["id"].Visible = false;
                dgv.Columns["created_at"].Visible = false;
                dgv.Columns["updated_at"].Visible = false;
                dgv.Columns["budget_appropriations_id"].Visible = false;
                dgv.Columns["date_entry"].Visible = false;
                dgv.Columns["amount"].DefaultCellStyle.Format = "N2";

                dgv.Columns["id"].SortMode = DataGridViewColumnSortMode.NotSortable;
                dgv.Columns["budget_appropriations_id"].SortMode = DataGridViewColumnSortMode.NotSortable;
                dgv.Columns["date_entry"].SortMode = DataGridViewColumnSortMode.NotSortable;
                dgv.Columns["amount"].SortMode = DataGridViewColumnSortMode.NotSortable;
                dgv.Columns["remarks"].SortMode = DataGridViewColumnSortMode.NotSortable;
                dgv.Columns["created_at"].SortMode = DataGridViewColumnSortMode.NotSortable;
                dgv.Columns["updated_at"].SortMode = DataGridViewColumnSortMode.NotSortable;

                //Load by loop All Budget Appropriations Records with Others FPP 
                foreach (DataRow drAllotmentRelease in dataTable.Rows)
                {
                    dgv.Rows.Add(new object[] {
                            drAllotmentRelease["id"],
                            drAllotmentRelease["budget_appropriations_id"],
                            drAllotmentRelease["date_entry"],
                            drAllotmentRelease["amount"],
                            drAllotmentRelease["remarks"],
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

        #endregion Supplemental Appropriations

        #region Obligation Request

        internal static void ObligationRequestDatagridView(DataGridView dataGridView, string searchTxt)
        {
            try
            {
                dataGridView.DataSource = Factory.ObligationRequestRepository().GetRecordsBySearch(searchTxt);

                dataGridView.Columns["obligation_no"].HeaderText = "Obligation No.";
                dataGridView.Columns["payee"].HeaderText = "Payee";
                dataGridView.Columns["explanation"].HeaderText = "Explanation";
                dataGridView.Columns["reference_no"].HeaderText = "Reference No.";
                dataGridView.Columns["id"].Visible = false;
                dataGridView.Columns["date_requested"].Visible = false;
                dataGridView.Columns["created_at"].Visible = false;
                dataGridView.Columns["created_by"].Visible = false;
                dataGridView.Columns["updated_at"].Visible = false;
                dataGridView.Columns["updated_by"].Visible = false;

                dataGridView.Columns["id"].SortMode = DataGridViewColumnSortMode.NotSortable;
                dataGridView.Columns["obligation_no"].SortMode = DataGridViewColumnSortMode.NotSortable;
                dataGridView.Columns["payee"].SortMode = DataGridViewColumnSortMode.NotSortable;
                dataGridView.Columns["explanation"].SortMode = DataGridViewColumnSortMode.NotSortable;
                dataGridView.Columns["reference_no"].SortMode = DataGridViewColumnSortMode.NotSortable;
                dataGridView.Columns["date_requested"].SortMode = DataGridViewColumnSortMode.NotSortable;
                dataGridView.Columns["created_at"].SortMode = DataGridViewColumnSortMode.NotSortable;
                dataGridView.Columns["created_by"].SortMode = DataGridViewColumnSortMode.NotSortable;
                dataGridView.Columns["updated_at"].SortMode = DataGridViewColumnSortMode.NotSortable;
                dataGridView.Columns["updated_by"].SortMode = DataGridViewColumnSortMode.NotSortable;

                dataGridView.ClearSelection();

            }
            catch (Exception ex)
            {
                Helper.MessageBoxError(ex.Message);
            }
        }

        #endregion Obligation Request

        #region JEV
        internal static void JEVDatagridView(DataTable dataTable, DataGridView datagrid)
        {
            datagrid.DataSource = dataTable;
            datagrid.Columns["id"].Visible = false;
            datagrid.Columns["funds_id"].Visible = false;
            datagrid.Columns["journals_id"].Visible = false;
            datagrid.Columns["jev_no"].HeaderText = "JEV No.";
            datagrid.Columns["date_entry"].HeaderText = "Date";
            datagrid.Columns["ref_no"].HeaderText = "Ref No.";
            datagrid.Columns["payee"].HeaderText = "Payee";
            datagrid.Columns["explanation"].HeaderText = "Explanation";
            datagrid.Columns["explanation"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            datagrid.Columns["is_approved"].Visible = false;
            datagrid.Columns["created_at"].Visible = false;
            datagrid.Columns["created_by"].Visible = false;
            datagrid.Columns["updated_at"].Visible = false;
            datagrid.Columns["updated_by"].Visible = false;
        }
        #endregion
    }
}
