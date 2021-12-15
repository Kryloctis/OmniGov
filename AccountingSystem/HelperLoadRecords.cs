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
            try
            {
                _ = dataTable.Columns.Add("Debit", typeof(decimal));
                _ = dataTable.Columns.Add("Credit", typeof(decimal));

                foreach (DataRow item in dataTable.Rows)
                {
                    ushort generalLedgerId = (ushort)item["general_ledger_accounts_id"];

                    var beginningBalanceRepository = Factory.BeginningBalancesRepository();
                    decimal debit = beginningBalanceRepository.GetSumBalances(fundsId, generalLedgerId, year, 1);
                    decimal credit = beginningBalanceRepository.GetSumBalances(fundsId, generalLedgerId, year, 0);

                    item["Debit"] = debit > credit ? debit - credit : 0;
                    item["Credit"] = credit > debit ? credit - debit : 0;
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
                datagrid.Columns["Credit"].DefaultCellStyle.Format = "N2";
                datagrid.Columns["Credit"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            }
            catch (Exception ex)
            {
                Helper.MessageBoxError(ex.StackTrace);
            }
        }

        internal static string ValidateDebitOrCreditType(Dictionary<string, string> beginningBalanceDict, string debitCreditType)
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
        internal static void JournalsDatagridView(DataGridView datagrid)
        {
            datagrid.Columns.Clear();
            datagrid.Rows.Clear();

            var dtJournals = Factory.JournalsRepository().GetRecords();

            //Image Column
            Image continuingIcon = Properties.Resources.ok14px;

            DataGridViewImageColumn imgColumn = new DataGridViewImageColumn();
            imgColumn.HeaderText = "Special";
            imgColumn.Name = "is_special";

            datagrid.Columns.Add("id", "id");
            datagrid.Columns.Add("journal_name", "Name");
            datagrid.Columns.Add(imgColumn);
            datagrid.Columns["is_special"].DefaultCellStyle.NullValue = null;
            datagrid.Columns.Add("created_at", "created_at");
            datagrid.Columns.Add("updated_at", "updated_at");


            datagrid.Columns["id"].Visible = false;
            datagrid.Columns["journal_name"].SortMode = DataGridViewColumnSortMode.NotSortable;
            datagrid.Columns["is_special"].SortMode = DataGridViewColumnSortMode.NotSortable;
            datagrid.Columns["is_special"].AutoSizeMode = DataGridViewAutoSizeColumnMode.ColumnHeader;
            datagrid.Columns["created_at"].Visible = false;
            datagrid.Columns["updated_at"].Visible = false;

            foreach (DataRow row in dtJournals.Rows)
            {
                int Id = Convert.ToInt32(row["id"]);
                string journalName = row["journal_name"].ToString();
                bool is_special = Convert.ToBoolean(row["is_special"]);

                var items = new object[]
                {
                    Id,
                    journalName,
                    is_special? continuingIcon : null,
                    row["created_at"],
                    row["updated_at"]
                };
                datagrid.Rows.Add(items);
            }

        }
        #endregion

        #region ReceiptsIssued
        internal static void ReceiptsIssuedDatagridView(DataTable dataTable, DataGridView datagrid)
        {
            datagrid.DataSource = dataTable;
            datagrid.Columns[0].Visible = false;
            datagrid.Columns[1].HeaderText = "Collector";
            datagrid.Columns[2].HeaderText = "Receipt (Form)";
            datagrid.Columns[3].HeaderText = "Series No. From";
            datagrid.Columns[4].HeaderText = "Series No. To";
            datagrid.Columns[5].HeaderText = "Date Issued";
            datagrid.Columns[5].DefaultCellStyle.Format = "yyyy-MM-dd";
            datagrid.Columns[6].HeaderText = "Quantity";
            datagrid.Columns[7].HeaderText = "Last Issued No.";
            datagrid.Columns[8].HeaderText = "Is Returned";
            datagrid.Columns[9].HeaderText = "Returned Date";
            datagrid.Columns[9].DefaultCellStyle.Format = "yyyy-MM-dd";
            datagrid.Columns[10].HeaderText = "User/Officer";

            datagrid.Columns[3].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            datagrid.Columns[4].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            datagrid.Columns[5].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            datagrid.Columns[6].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            datagrid.Columns[7].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            datagrid.Columns[9].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

            datagrid.Columns[3].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            datagrid.Columns[4].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            datagrid.Columns[6].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            datagrid.Columns[7].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            datagrid.Columns[8].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            datagrid.Columns[10].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;

            float fontSize = 9f;
            datagrid.DefaultCellStyle.Font = new Font("Segoe UI", fontSize);
            datagrid.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }
        #endregion

        #region Receipts
        internal static void ReceiptsDatagridView(DataTable dataTable, DataGridView datagrid)
        {
            datagrid.DataSource = dataTable;
            datagrid.Columns[0].Visible = false;
            datagrid.Columns[1].HeaderText = "Receipt (Form)";
            datagrid.Columns[2].HeaderText = "Series No. From";
            datagrid.Columns[3].HeaderText = "Series No. To";
            datagrid.Columns[4].HeaderText = "Received Date";
            datagrid.Columns[4].DefaultCellStyle.Format = "yyyy-MM-dd";
            datagrid.Columns[5].HeaderText = "Quantity";
            datagrid.Columns[6].HeaderText = "User/Officer";

            datagrid.Columns[2].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            datagrid.Columns[3].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            datagrid.Columns[5].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;

            float fontSize = 9f;
            datagrid.DefaultCellStyle.Font = new Font("Segoe UI", fontSize);
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
        #region FaceValue
        internal static void FaceValueDatagridView(DataTable dataTable, DataGridView datagrid)
        {
            Helper.DatagridFullRowSelectStyle(datagrid, true);
            datagrid.Rows.Clear();
            datagrid.Columns.Clear();

            datagrid.Columns.Add("id", "ID");
            datagrid.Columns.Add("accountable_forms_id", "Accountable Form ID");
            datagrid.Columns.Add("date", "Date");
            datagrid.Columns.Add("amount", "Amount");
            datagrid.Columns.Add("created_at", "Created at");
            datagrid.Columns.Add("updated_at", "Updated at");

            datagrid.Columns["id"].Visible = false;
            datagrid.Columns["accountable_forms_id"].Visible = false;
            datagrid.Columns["created_at"].Visible = false;
            datagrid.Columns["updated_at"].Visible = false;

            datagrid.Columns["date"].Width = 230;
            datagrid.Columns["amount"].Width = 100;

            datagrid.Columns["date"].DefaultCellStyle.Format = "MMMM-dd-yyyy";
            datagrid.Columns["amount"].DefaultCellStyle.Format = "N2";
            datagrid.Columns["amount"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;

            datagrid.Columns["date"].SortMode = DataGridViewColumnSortMode.NotSortable;
            datagrid.Columns["amount"].SortMode = DataGridViewColumnSortMode.NotSortable;

            foreach (DataRow drFaceValue in dataTable.Rows)
            {
                datagrid.Rows.Add(new object[]
                {
                    drFaceValue["id"],
                    drFaceValue["accountable_forms_id"],
                    drFaceValue["date"],
                    drFaceValue["amount"],
                    drFaceValue["created_at"],
                    drFaceValue["updated_at"]
                });
            }

            datagrid.ClearSelection();

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
            datagrid.Columns[5].DefaultCellStyle.Format = "N2";
            datagrid.Columns[5].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            datagrid.Columns[6].Visible = false;
            datagrid.Columns[7].Visible = false;
            datagrid.Columns[8].Visible = false;
            datagrid.Columns[9].Visible = false;

            datagrid.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }
        #endregion

        #region RCD 
        internal static void RCDSearchDatagridView(DataTable dataTable, DataGridView datagrid)
        {

            datagrid.Rows.Clear();
            datagrid.Columns.Clear();

            datagrid.Columns.Add("id", "Id");
            datagrid.Columns.Add("rcd_no", "RCD No. ");
            datagrid.Columns.Add("date", "Date");
            datagrid.Columns.Add("report_no", "Date");
            datagrid.Columns.Add("users_id", "User Id");
            datagrid.Columns.Add("user", "Liquidating Officer");
            datagrid.Columns.Add("amount", "Total Amount");

            datagrid.Columns["id"].Visible = false;
            datagrid.Columns["users_id"].Visible = false;
            datagrid.Columns["report_no"].Visible = false;


            datagrid.Columns["amount"].Resizable = DataGridViewTriState.False;
            datagrid.Columns["amount"].Width = 100;
            datagrid.Columns["amount"].MinimumWidth = 100;
            datagrid.Columns["amount"].DefaultCellStyle.Format = "N2";
            datagrid.Columns["amount"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;

            datagrid.Columns["date"].DefaultCellStyle.Format = "MMMM-dd-yyyy";


            foreach (DataRow drRCD in dataTable.Rows)
            {
                datagrid.Rows.Add(new object[]
                {
                    drRCD["id"],
                    drRCD["rcd_no"],
                    drRCD["date"],
                    drRCD["report_no"],
                    drRCD["users_id"],
                    drRCD["user"],
                    drRCD["amount"]
                });
            }

            datagrid.DefaultCellStyle.Font = new Font("Segoe UI", 9f);
            datagrid.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }

        internal static void RCDDatagridView(DataTable dataTable, DataGridView datagrid)
        {

            datagrid.Rows.Clear();
            datagrid.Columns.Clear();

            datagrid.Columns.Add("id", "Id");
            datagrid.Columns.Add("collecting_officers_id", "Collector Id");
            datagrid.Columns.Add("collecting_officer", "Collector");
            datagrid.Columns.Add("report_no", "Report No.");
            datagrid.Columns.Add("amount", "Amount");

            datagrid.Columns["id"].Visible = false;
            datagrid.Columns["collecting_officers_id"].Visible = false;


            datagrid.Columns["amount"].Resizable = DataGridViewTriState.False;
            datagrid.Columns["amount"].Width = 100;
            datagrid.Columns["amount"].MinimumWidth = 100;
            datagrid.Columns["amount"].DefaultCellStyle.Format = "N2";
            datagrid.Columns["amount"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;


            foreach (DataRow drRCD in dataTable.Rows)
            {

                datagrid.Rows.Add(new object[]
                {
                    drRCD["id"],
                    drRCD["collecting_officers_id"],
                    drRCD["collecting_officer"],
                    drRCD["report_no"],
                    drRCD["amount"]
                });
            }

            datagrid.DefaultCellStyle.Font = new Font("Segoe UI", 9f);


            datagrid.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }
        #endregion

        #region Collector Report
        internal static void CollectorReportDatagridView(DataTable dataTable, DataGridView datagrid)
        {

            datagrid.Rows.Clear();
            datagrid.Columns.Clear();

            datagrid.Columns.Add("id", "Id");
            datagrid.Columns.Add("report_no", "Report No. ");
            datagrid.Columns.Add("collecting_officers_id", "Collecting Officer Id");
            datagrid.Columns.Add("collector_officer", "Collecting Officer");
            datagrid.Columns.Add("fund_id", "Fund Id");
            datagrid.Columns.Add("fund_name", "Fund");
            datagrid.Columns.Add("date", "Date");
            datagrid.Columns.Add("is_approved", "is_approved");
            datagrid.Columns.Add("is_disapproved", "is_disapproved");
            datagrid.Columns.Add("amount", "Amount");
            datagrid.Columns.Add("status", "Status");


            datagrid.Columns["id"].Visible = false;
            datagrid.Columns["collecting_officers_id"].Visible = false;
            datagrid.Columns["collector_officer"].Visible = false;
            datagrid.Columns["fund_id"].Visible = false;
            datagrid.Columns["is_approved"].Visible = false;
            datagrid.Columns["is_disapproved"].Visible = false;

            datagrid.Columns["status"].Width = 90;
            datagrid.Columns["status"].MinimumWidth = 90;
            datagrid.Columns["status"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;


            datagrid.Columns["amount"].Resizable = DataGridViewTriState.False;
            datagrid.Columns["amount"].Width = 80;
            datagrid.Columns["amount"].MinimumWidth = 80;
            datagrid.Columns["amount"].DefaultCellStyle.Format = "N2";
            datagrid.Columns["amount"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;

            datagrid.Columns["date"].DefaultCellStyle.Format = "MMMM-dd-yyyy";


            foreach (DataRow drCollectionReport in dataTable.Rows)
            {
                var status = Convert.ToInt16(drCollectionReport["is_approved"].ToString()) == 1 ? " Approved" :
                             Convert.ToInt16(drCollectionReport["is_disapproved"].ToString()) == 1 ? " Disapproved": " Pending"; 
                            

                datagrid.Rows.Add(new object[]
                {
                    drCollectionReport["id"],
                    drCollectionReport["report_no"],
                    drCollectionReport["collecting_officers_id"],
                    drCollectionReport["collecting_officer"],
                    drCollectionReport["fund_id"],
                    drCollectionReport["fund_name"],
                    drCollectionReport["date"],
                    drCollectionReport["is_approved"],
                    drCollectionReport["is_disapproved"],
                    drCollectionReport["amount"],
                    status
                });
            }

            datagrid.DefaultCellStyle.Font = new Font("Segoe UI", 9f);
            

            datagrid.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }
        #endregion

        #region General Collection
        internal static void GeneralCollectionDatagridView(DataTable dataTable, DataGridView datagrid)
        {
            datagrid.Columns.Clear();
            datagrid.Rows.Clear();

            datagrid.DataSource = dataTable;

            datagrid.Columns[0].Visible = false;
            datagrid.Columns[1].HeaderText = "RCD Number";
            datagrid.Columns[2].HeaderText = "Date";
            datagrid.Columns[3].HeaderText = "Liquidating Officer";
            datagrid.Columns[4].HeaderText = "Total Amount";
            datagrid.Columns[4].DefaultCellStyle.Format = "N2";
            datagrid.Columns[4].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            datagrid.Columns[5].Visible = false;
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

            datagrid.Columns[0].HeaderText = "Id ";
            datagrid.Columns[1].HeaderText = "Bank Id ";
            datagrid.Columns[2].HeaderText = "Account No.";
            datagrid.Columns[3].HeaderText = "Bank Name";
            datagrid.Columns[4].HeaderText = "Fund Id";
            datagrid.Columns[5].HeaderText = "Fund";
            datagrid.Columns[6].HeaderText = "Check Date";
            datagrid.Columns[7].HeaderText = "Check No.";
            datagrid.Columns[8].HeaderText = "DV No.";
            datagrid.Columns[9].HeaderText = "Payee";
            datagrid.Columns[10].HeaderText = "Nature of Payment";
            datagrid.Columns[11].HeaderText = "Obligation No.";
            datagrid.Columns[12].HeaderText = "FPP Id";
            datagrid.Columns[13].HeaderText = "Functional Code";
            datagrid.Columns[14].HeaderText = "Amount";
            datagrid.Columns[14].DefaultCellStyle.Format = "N2";
            datagrid.Columns[14].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            datagrid.Columns[15].HeaderText = "Created at";
            datagrid.Columns[16].HeaderText = "Updated at";



            datagrid.Columns[0].Visible = false;
            datagrid.Columns[1].Visible = false;
            datagrid.Columns[4].Visible = false;
            datagrid.Columns[12].Visible = false;
            datagrid.Columns[11].Visible = false;
            datagrid.Columns[15].Visible = false;
            datagrid.Columns[16].Visible = false;



            datagrid.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }
        #endregion

        internal static void CollectionDataGridColumns(DataGridView datagrid) 
        {

            datagrid.Columns.Add("payment_collection_id", "Payment Collection ID");
            datagrid.Columns.Add("fund_id", "Fund Id");
            datagrid.Columns.Add("fund", "Fund");
            datagrid.Columns.Add("accountable_form_id", "Accountable Form ID");
            datagrid.Columns.Add("accountable_form", "Accountable Form");
            datagrid.Columns.Add("abstract_of_general_collection_id", "Abstract Of General Collection ID");
            datagrid.Columns.Add("abstract_of_general_collection", "Abstract Of General Collection");
            datagrid.Columns.Add("payee", "Payee");
            datagrid.Columns.Add("receipt_no", "Receipt No.");
            datagrid.Columns.Add("quantity", "Quantity");
            datagrid.Columns.Add("payment_date", "Payment Date");
            datagrid.Columns.Add("amount", "Amount");
            datagrid.Columns.Add("created_at", "Created at");
            datagrid.Columns.Add("created_by", "Created by");
            datagrid.Columns.Add("updated_at", "Updated at");
            datagrid.Columns.Add("updated_by", "Updated by");


            datagrid.Columns["payment_collection_id"].Visible = false;
            datagrid.Columns["fund"].Visible = false;
            datagrid.Columns["fund_id"].Visible = false;
            datagrid.Columns["accountable_form_id"].Visible = false;
            datagrid.Columns["abstract_of_general_collection_id"].Visible = false;
            datagrid.Columns["payment_date"].Visible = false;
            datagrid.Columns["created_at"].Visible = false;
            datagrid.Columns["created_by"].Visible = false;
            datagrid.Columns["updated_at"].Visible = false;
            datagrid.Columns["updated_by"].Visible = false;


            datagrid.Columns["accountable_form"].Width = 150;
            datagrid.Columns["abstract_of_general_collection"].Width = 350;
            datagrid.Columns["payee"].Width = 200;
            datagrid.Columns["receipt_no"].Width = 80;
            datagrid.Columns["quantity"].Width = 60;

            datagrid.Columns["amount"].Resizable = DataGridViewTriState.False;
            datagrid.Columns["amount"].Width = 80;
            datagrid.Columns["amount"].MinimumWidth = 80;
            datagrid.Columns["amount"].DefaultCellStyle.Format = "N2";
            datagrid.Columns["amount"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;

            datagrid.Columns["payment_date"].DefaultCellStyle.Format = "MMMM-dd-yyyy";
        }

        #region CollectionDataGridView
        internal static void CollectionDataGridView(DataTable dataTable, DataGridView datagrid)
        {
            datagrid.Rows.Clear();
            datagrid.Columns.Clear();

            CollectionDataGridColumns(datagrid);

            foreach (DataRow drPaymentCollection in dataTable.Rows)
            {
                var abstractOfGeneralCollection = $"{drPaymentCollection["account_code"]} - {drPaymentCollection["ledger_name"]}";
                datagrid.Rows.Add(new object[]
                {
                    drPaymentCollection["id"],
                    drPaymentCollection["funds_id"],
                    drPaymentCollection["fund_name"],
                    drPaymentCollection["accountable_form_id"],
                    drPaymentCollection["accountable_forms"],
                    drPaymentCollection["general_ledger_accounts_id"],
                    abstractOfGeneralCollection,
                    drPaymentCollection["payee"],
                    drPaymentCollection["receipt_no"],
                    drPaymentCollection["quantity"],
                    drPaymentCollection["payment_date"],
                    drPaymentCollection["amount"],
                    drPaymentCollection["created_at"],
                    drPaymentCollection["created_by"],
                    drPaymentCollection["updated_at"],
                    drPaymentCollection["updated_by"]
                });
            }

            datagrid.ClearSelection();
            Helper.DatagridFullRowSelectStyle(datagrid, true);

        }
        #endregion

        #region PaymentCollection

        internal static void PaymentDatagridView(DataTable dataTable, DataGridView datagrid)
        {

            datagrid.Rows.Clear();
            datagrid.Columns.Clear();

            datagrid.Columns.Add("payment_collection_id", "Payment Collection ID");
            datagrid.Columns.Add("fund_id", "Fund Id");
            datagrid.Columns.Add("fund_name", "Fund");
            datagrid.Columns.Add("accountable_form_id", "Accountable Form ID");
            datagrid.Columns.Add("accountable_form", "Accountable Form");
            datagrid.Columns.Add("abstract_of_general_collection_id", "Abstract Of General Collection ID");
            datagrid.Columns.Add("abstract_of_general_collection", "Abstract Of General Collection");
            datagrid.Columns.Add("payee", "Payee");
            datagrid.Columns.Add("receipt_no", "Receipt No.");
            datagrid.Columns.Add("quantity", "Quantity");
            datagrid.Columns.Add("payment_date", "Payment Date");
            datagrid.Columns.Add("amount", "Amount");


            datagrid.Columns["payment_collection_id"].Visible = false;
            datagrid.Columns["fund_id"].Visible = false;
            datagrid.Columns["fund_name"].Visible = false;
            datagrid.Columns["accountable_form_id"].Visible = false;
            datagrid.Columns["abstract_of_general_collection_id"].Visible = false;


            datagrid.Columns["accountable_form"].Width = 200;
            datagrid.Columns["abstract_of_general_collection"].Width = 300;
            datagrid.Columns["payee"].Width = 200;
            datagrid.Columns["receipt_no"].Width = 80;
            datagrid.Columns["quantity"].Width = 60;

            datagrid.Columns["payment_date"].DefaultCellStyle.Format = "MMMM-dd-yyyy";
            datagrid.Columns["payment_date"].Width = 120;
            datagrid.Columns["payment_date"].MinimumWidth = 120;


            datagrid.Columns["amount"].Resizable = DataGridViewTriState.False;
            datagrid.Columns["amount"].Width = 80;
            datagrid.Columns["amount"].MinimumWidth = 80;
            datagrid.Columns["amount"].DefaultCellStyle.Format = "N2";
            datagrid.Columns["amount"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;


            foreach (DataRow drPaymentCollection in dataTable.Rows)
            {
                var abstractOfGeneralCollection = $"{drPaymentCollection["account_code"]} - {drPaymentCollection["ledger_name"]}";

                datagrid.Rows.Add(new object[]
                {
                    drPaymentCollection["id"],
                    drPaymentCollection["funds_id"],
                    drPaymentCollection["fund_name"],
                    drPaymentCollection["accountable_form_id"],
                    drPaymentCollection["accountable_forms"],
                    drPaymentCollection["general_ledger_accounts_id"],
                    abstractOfGeneralCollection,
                    drPaymentCollection["payee"],
                    drPaymentCollection["receipt_no"],
                    drPaymentCollection["quantity"],
                    drPaymentCollection["payment_date"],
                    drPaymentCollection["amount"]
                });
            }

            datagrid.ClearSelection();
            Helper.DatagridFullRowSelectStyle(datagrid, true);

        }
        #endregion

        #region AccountableForm
        internal static void AccFormDatagridView(DataTable dataTable, DataGridView datagrid)
        {
            datagrid.DataSource = dataTable;
            datagrid.Columns[0].Visible = false;
            datagrid.Columns[1].HeaderText = "Form Number";
            datagrid.Columns[2].HeaderText = "Form Description";
            datagrid.Columns[3].HeaderText = "Face Value";


            datagrid.Columns[1].MinimumWidth = 90;
            datagrid.Columns[1].Width = 90;

            datagrid.Columns[2].MinimumWidth = 500;
            datagrid.Columns[2].Width = 500;

            datagrid.Columns[3].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;

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


            datagrid.Columns[1].Width = 100;
            datagrid.Columns[2].Width = 325;

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
            datagrid.Columns["is_special"].Visible = false;
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

            //a.id, a.first_name, a.mid_initial, a.last_name, a.username, b.role_name, a.created_at, a.updated_at
            datagrid.DataSource = dataTable;
            datagrid.Columns[0].Visible = false;
            datagrid.Columns[1].Visible = false;
            datagrid.Columns[2].HeaderText = "Firstname";
            datagrid.Columns[3].HeaderText = "MI";
            datagrid.Columns[4].HeaderText = "Lastname";
            datagrid.Columns[5].HeaderText = "Username";
            datagrid.Columns[6].Visible = false;
            datagrid.Columns[7].Visible = false;
            datagrid.Columns[8].Visible = false;
            datagrid.Columns[9].Visible = false;
            datagrid.Columns[10].HeaderText = "Office";
            datagrid.Columns[11].HeaderText = "Role";
            datagrid.Columns[12].Visible = false;
            datagrid.Columns[13].Visible = false;


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

        #region BUDGET APPROPRIATIONS

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
                #region Datagrid Format
                //Image Column
                dgvBudgetAppropriations.ShowCellToolTips = false;
                Image continuingIcon = Properties.Resources.ok14px;
                Image realignmentIcon = Properties.Resources.ok14px;

                DataGridViewImageColumn imgColumn = new DataGridViewImageColumn();
                DataGridViewImageColumn imgRealignedColumn = new DataGridViewImageColumn();

                imgColumn.HeaderText = "Continuing";
                imgColumn.Name = "continuing";

                imgRealignedColumn.HeaderText = "Realigned";
                imgRealignedColumn.Name = "realigned";


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
                dgvBudgetAppropriations.Columns.Add(imgRealignedColumn);
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

                dgvBudgetAppropriations.Columns["realigned"].Resizable = DataGridViewTriState.False;
                dgvBudgetAppropriations.Columns["realigned"].DefaultCellStyle.NullValue = null;
                dgvBudgetAppropriations.Columns["realigned"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dgvBudgetAppropriations.Columns["realigned"].Width = 80;
                dgvBudgetAppropriations.Columns["realigned"].MinimumWidth = 80; 
                #endregion

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
                    FieldData(dgvBudgetAppropriations, continuingIcon, realignmentIcon, drGetViewRecordsByIds);
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
                        FieldData(dgvBudgetAppropriations, continuingIcon, realignmentIcon, drGetViewRecordsByIds);
                    }
                }

                static void FieldData(DataGridView dgvBudgetAppropriations, Image continuingIcon, Image realignmentIcon, DataRow drGetViewRecordsByIds)
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
                    byte rowRealignment = Convert.ToByte(Factory.BudgetRealignmentRepository().BudgetHasRealignment(rowId));
                    string remarks = drGetViewRecordsByIds["remarks"].ToString();

                    //GET TOTAL SUPPLEMENTAL APPROPRIATIONS
                    var dtSupplementalAppropriation = Factory.SupplementalAppropriationsRepository().GetRecordsByBudgetAppropriationId(rowId);
                    decimal totalSupplementalAppropriation = Convert.ToDecimal(dtSupplementalAppropriation.Rows.Count == 0 ? 0 : dtSupplementalAppropriation.Compute("Sum(amount)", string.Empty));


                    //GET TOTAL ALLOTMENT RELEASE
                    var dtAllotmentRelease = Factory.AllotmentReleaseRepository().GetViewRecordsByBudgetAppropriationId(rowId);
                    decimal totalAllotmentRelease = Convert.ToDecimal(dtAllotmentRelease.Rows.Count == 0 ? 0 : dtAllotmentRelease.Compute("SUM(amount)", string.Empty));


                    //GET TOTAL REALIGNMENT
                    var totalRealignmentTo = Factory.BudgetRealignmentRepository().GetAmountOfBudgetRealignedToByBudgetId(rowId);

                    var totalRealignmentFrom = Factory.BudgetRealignmentRepository().GetAmountOfBudgetRealignedFromByBudgetId(rowId);

                    //GET TOTAL APPROPRIATION
                    decimal totalAppropriationAmount = (totalSupplementalAppropriation + rowAppropriationAmount + totalRealignmentTo) - totalRealignmentFrom;

                    decimal appropriationBalance = (totalSupplementalAppropriation + rowAppropriationAmount - totalAllotmentRelease + totalRealignmentTo) - totalRealignmentFrom;


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
                        rowRealignment == 1? continuingIcon : null,
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

        #endregion BUDGET APPROPRIATIONS

        #region DASHBOARD

        internal static void DashboardDetailedDatagridView(DataGridView dgvBudgetAppropriations, string fppID, int allotmentClassID, int fundId, DateTime dateAsOf)
        {
            #region DATAGRID FORMAT

            Helper.DatagridFullRowSelectStyle(dgvBudgetAppropriations, true);

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
            dgvBudgetAppropriations.Columns.Add("totalAllotmentRelease", "Allotments");
            dgvBudgetAppropriations.Columns.Add("totalObligations", "Obligations");
            dgvBudgetAppropriations.Columns.Add("totalAllotmentBalance", "Allotment Balance");
            dgvBudgetAppropriations.Columns.Add("appropriationBalance", "Appropriation Balance");
            dgvBudgetAppropriations.Columns.Add("year", "Year");
            dgvBudgetAppropriations.Columns.Add(imgColumn);
            dgvBudgetAppropriations.Columns.Add("remarks", "Remarks");
            dgvBudgetAppropriations.Columns.Add("created_at", "Created at");
            dgvBudgetAppropriations.Columns.Add("updated_at", "Updated at");

            //DISABLE SORT MODES
            dgvBudgetAppropriations.Columns["id"].SortMode = DataGridViewColumnSortMode.NotSortable;
            dgvBudgetAppropriations.Columns["funds_id"].SortMode = DataGridViewColumnSortMode.NotSortable;
            dgvBudgetAppropriations.Columns["fpp_id"].SortMode = DataGridViewColumnSortMode.NotSortable;
            dgvBudgetAppropriations.Columns["others_fpp_id"].SortMode = DataGridViewColumnSortMode.NotSortable;
            dgvBudgetAppropriations.Columns["allotment_class_id"].SortMode = DataGridViewColumnSortMode.NotSortable;
            dgvBudgetAppropriations.Columns["general_ledger_accounts_id"].SortMode = DataGridViewColumnSortMode.NotSortable;
            dgvBudgetAppropriations.Columns["general_ledger_accounts_name"].SortMode = DataGridViewColumnSortMode.NotSortable;
            dgvBudgetAppropriations.Columns["account_code"].SortMode = DataGridViewColumnSortMode.NotSortable;
            dgvBudgetAppropriations.Columns["date_entry"].SortMode = DataGridViewColumnSortMode.NotSortable;
            dgvBudgetAppropriations.Columns["amount"].SortMode = DataGridViewColumnSortMode.NotSortable;
            dgvBudgetAppropriations.Columns["totalAllotmentRelease"].SortMode = DataGridViewColumnSortMode.NotSortable;
            dgvBudgetAppropriations.Columns["totalObligations"].SortMode = DataGridViewColumnSortMode.NotSortable;
            dgvBudgetAppropriations.Columns["totalAllotmentBalance"].SortMode = DataGridViewColumnSortMode.NotSortable;
            dgvBudgetAppropriations.Columns["appropriationBalance"].SortMode = DataGridViewColumnSortMode.NotSortable;
            dgvBudgetAppropriations.Columns["year"].SortMode = DataGridViewColumnSortMode.NotSortable;
            dgvBudgetAppropriations.Columns["continuing"].SortMode = DataGridViewColumnSortMode.NotSortable;
            dgvBudgetAppropriations.Columns["remarks"].SortMode = DataGridViewColumnSortMode.NotSortable;
            dgvBudgetAppropriations.Columns["created_at"].SortMode = DataGridViewColumnSortMode.NotSortable;
            dgvBudgetAppropriations.Columns["updated_at"].SortMode = DataGridViewColumnSortMode.NotSortable;

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
            int amountColumWidth = 140;
            dgvBudgetAppropriations.Columns["general_ledger_accounts_name"].Width = 300;

            dgvBudgetAppropriations.Columns["account_code"].Resizable = DataGridViewTriState.False;
            dgvBudgetAppropriations.Columns["account_code"].Width = 95;
            dgvBudgetAppropriations.Columns["account_code"].MinimumWidth = 95;


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

            dgvBudgetAppropriations.Columns["totalObligations"].Resizable = DataGridViewTriState.False;
            dgvBudgetAppropriations.Columns["totalObligations"].Width = amountColumWidth;
            dgvBudgetAppropriations.Columns["totalObligations"].MinimumWidth = amountColumWidth;
            dgvBudgetAppropriations.Columns["totalObligations"].DefaultCellStyle.Format = "N2";
            dgvBudgetAppropriations.Columns["totalObligations"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;

            dgvBudgetAppropriations.Columns["totalAllotmentBalance"].Resizable = DataGridViewTriState.False;
            dgvBudgetAppropriations.Columns["totalAllotmentBalance"].Width = amountColumWidth;
            dgvBudgetAppropriations.Columns["totalAllotmentBalance"].MinimumWidth = amountColumWidth;
            dgvBudgetAppropriations.Columns["totalAllotmentBalance"].DefaultCellStyle.Format = "N2";
            dgvBudgetAppropriations.Columns["totalAllotmentBalance"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;

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

            #endregion

            int? sub_fpp;
            sub_fpp = null;

            var dtGetViewRecordsByFFPIDByAllotmentClass = Factory.BudgetAppropriationsRepository().GetViewRecordsByFPPIdAndFundIdAndAllotmentClassIdAndDateEntry(fppID, sub_fpp, fundId, allotmentClassID, dateAsOf);


            //Load by loop All Budget Appropriations Records without Others FPP 
            foreach (DataRow drGetViewRecordsByIds in dtGetViewRecordsByFFPIDByAllotmentClass.Rows)
            {
                FieldData(dgvBudgetAppropriations, continuingIcon, drGetViewRecordsByIds, dateAsOf);
            }


            //Initialize Repository Method for others fpp records
            DataTable dtGetRecordsOthersFPP = Factory.BudgetAppropriationsRepository().GetHeaderOthersFPP(fppID, allotmentClassID, fundId, Convert.ToInt16(dateAsOf.Year));

            //Load by loop All Budget Appropriations Records with Others FPP 
            foreach (DataRow drGetRecordsOthersFPP in dtGetRecordsOthersFPP.Rows)
            {
                string othersFPPName = drGetRecordsOthersFPP["others_fpp_name"].ToString();
                int othersFPPID = Convert.ToInt32(drGetRecordsOthersFPP["others_fpp_id"]);

                //Set Header for Others FPP 
                dgvBudgetAppropriations.Rows.Add(new object[] { null, null, null, null, null, null, othersFPPName });


                sub_fpp = othersFPPID;
                DataTable dtGetViewRecordsByIds = Factory.BudgetAppropriationsRepository().GetViewRecordsByFPPIdAndFundIdAndAllotmentClassIdAndDateEntry(fppID, sub_fpp, fundId, allotmentClassID, dateAsOf);

                foreach (DataRow drGetViewRecordsByIds in dtGetViewRecordsByIds.Rows)
                {
                    FieldData(dgvBudgetAppropriations, continuingIcon, drGetViewRecordsByIds, dateAsOf);
                }
            }

            static void FieldData(DataGridView dgvBudgetAppropriations, Image continuingIcon, DataRow drGetViewRecordsByIds, DateTime dateAsOf)
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
                decimal supplementalAppropriation = Factory.SupplementalAppropriationsRepository().GetSumSupplementalAppropriations(rowId, dateAsOf);

                //GET TOTAL ALLOTMENT RELEASE
                decimal allotments = Factory.AllotmentReleaseRepository().GetSumAllotments(rowId, dateAsOf);

                decimal obligations = Factory.ObligationRequestRepository().GetSumObligationsByAppropriationId(rowId, dateAsOf);

                //GET TOTAL APPROPRIATION
                decimal totalAppropriationAmount = supplementalAppropriation + rowAppropriationAmount;

                decimal appropriationBalance = (supplementalAppropriation + rowAppropriationAmount) - obligations;

                decimal allotmentBalance = allotments - obligations;

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
                    allotments,
                    obligations,
                    allotmentBalance,
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

            dgvBudgetAppropriations.ShowCellToolTips = false;

            dgvBudgetAppropriations.ClearSelection();

        }


        internal static void ComboboxJournals(DataTable dataTable, ComboBox comboBox, string valueMember, string displayMember)
        {
            comboBox.DataSource = dataTable;
            comboBox.DisplayMember = displayMember;
            comboBox.ValueMember = valueMember;
            comboBox.AutoCompleteSource = AutoCompleteSource.ListItems;
            comboBox.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
        }

        #endregion DASHBOARD

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
                Helper.DatagridFullRowSelectStyle(dgv, true);
                dgv.ShowCellToolTips = false;
            }
            catch (Exception ex)
            {
                Helper.MessageBoxError(ex.Message);
            }
        }

        #endregion Supplemental Appropriations

        #region BudgetRealignment

        internal static void BudgetRealignmentDatagridView(DataTable dataTable, DataGridView dgv)
        {
            try
            {
                Helper.DatagridDefaultStyle(dgv, true);

                //Clearing Datagrid View  Rows & Columns before Loading new one
                dgv.Rows.Clear();
                dgv.Columns.Clear();

                //Set up new Columns to Datagrid View
                dgv.Columns.Add("id", "ID");
                dgv.Columns.Add("fpp_name", "FPP");
                dgv.Columns.Add("allotment_name", "Allotment Class");
                dgv.Columns.Add("ledger_name", "Budget Appropriation");
                dgv.Columns.Add("date_entry", "Date Entry");
                dgv.Columns.Add("total_amount", "Total Amount");
                dgv.Columns.Add("remarks", "Remarks");

                dgv.Columns["fpp_name"].Width = 120;

                //Set up Column Format
                dgv.Columns["id"].Visible = false;
                dgv.Columns["fpp_name"].Width = 100;
                dgv.Columns["ledger_name"].Width = 230;
                dgv.Columns["date_entry"].DefaultCellStyle.Format = "MMMM-dd-yyyy";
                dgv.Columns["total_amount"].DefaultCellStyle.Format = "N2";
                dgv.Columns["total_amount"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;


                dgv.Columns["fpp_name"].SortMode = DataGridViewColumnSortMode.NotSortable;
                dgv.Columns["allotment_name"].SortMode = DataGridViewColumnSortMode.NotSortable;
                dgv.Columns["ledger_name"].SortMode = DataGridViewColumnSortMode.NotSortable;
                dgv.Columns["date_entry"].SortMode = DataGridViewColumnSortMode.NotSortable;
                dgv.Columns["total_amount"].SortMode = DataGridViewColumnSortMode.NotSortable;
                dgv.Columns["remarks"].SortMode = DataGridViewColumnSortMode.NotSortable;

                //Load by loop All Budget Appropriations Records with Others FPP 
                foreach (DataRow drRealignment in dataTable.Rows)
                {
                    dgv.Rows.Add(new object[]
                    {
                        drRealignment["id"],
                        drRealignment["fpp_name"],
                        drRealignment["allotment_name"],
                        drRealignment["ledger_name"],
                        drRealignment["date_entry"],
                        drRealignment["total_amount"],
                        drRealignment["remarks"] 
                    });
                }

                dgv.ClearSelection();
                Helper.DatagridFullRowSelectStyle(dgv, true);
            }
            catch (Exception ex)
            {
                Helper.MessageBoxError(ex.Message);
            }
        }

        internal static void BudgetRealignmentAccountsDatagridView(DataTable dataTable, DataGridView dgv)
        {
            try
            {
                //Helper.DatagridDefaultStyle(dgv, true);

                //Clearing Datagrid View  Rows & Columns before Loading new one
                dgv.Rows.Clear();
                dgv.Columns.Clear();

                //Set up new Columns to Datagrid View
                dgv.Columns.Add("to_budget_appropriations_id", "To Budget ID");
                dgv.Columns.Add("to_ledger_id", "Ledger Id");
                dgv.Columns.Add("to_budget", "Budget Appropriation");
                dgv.Columns.Add("amount", "Amount");

                dgv.Columns["to_budget"].Width = 300;
                dgv.Columns["amount"].Width = 100;

                //Set up Column Format
                dgv.Columns["to_budget_appropriations_id"].Visible = false;
                dgv.Columns["to_ledger_id"].Visible = false;
                dgv.Columns["to_budget"].ReadOnly = true;
                dgv.Columns["amount"].DefaultCellStyle.Format = "N2";
                dgv.Columns["amount"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;


                dgv.Columns["to_budget"].SortMode = DataGridViewColumnSortMode.NotSortable;
                dgv.Columns["amount"].SortMode = DataGridViewColumnSortMode.NotSortable;

                //Load by loop All Budget Appropriations Records with Others FPP 
                foreach (DataRow drRealignment in dataTable.Rows)
                {
                    dgv.Rows.Add(new object[]
                    {
                        drRealignment["to_budget_appropriations_id"],
                        drRealignment["to_ledger_id"],
                        drRealignment["to_budget"],
                        drRealignment["amount"],
                    });
                }

                dgv.ClearSelection();
            }
            catch (Exception ex)
            {
                Helper.MessageBoxError(ex.Message);
            }
        }


        #endregion

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

        internal static void JEVREportDataGridView(DataTable dataTable, DataGridView datagrid)
        {
            datagrid.DataSource = dataTable;
            datagrid.Columns["full_jev_no"].HeaderText = "JEV No.";
            datagrid.Columns["date_entry"].HeaderText = "Date";

            datagrid.Columns["id"].Visible = false;
            datagrid.Columns["fund_code"].Visible = false;
            datagrid.Columns["explanation"].Visible = false;
            datagrid.Columns["payee"].Visible = false;
            datagrid.Columns["ref_no"].Visible = false;
            datagrid.Columns["jev_no"].Visible = false;
            datagrid.Columns["fund_code"].Visible = false;
            datagrid.Columns["is_approved"].Visible = false;
            datagrid.Columns["is_disapproved"].Visible = false;
            datagrid.Columns["is_cancelled"].Visible = false;
            datagrid.Columns["created_at"].Visible = false;
            datagrid.Columns["created_by"].Visible = false;
            datagrid.Columns["updated_at"].Visible = false;
            datagrid.Columns["updated_by"].Visible = false;
            datagrid.Columns["funds_id"].Visible = false;
            datagrid.Columns["journals_id"].Visible = false;
        }

        internal static void JEVDatagridView(DataGridView datagrid)
        {
            datagrid.Columns.Clear();
            datagrid.Columns.Add("id", "ID");
            datagrid.Columns.Add("funds_id", "Funds ID");
            datagrid.Columns.Add("journals_id", "Journals ID");
            datagrid.Columns.Add("jev_no", "JEV No.");
            datagrid.Columns.Add("full_jev_no", "JEV No.");
            datagrid.Columns.Add("date_entry", "Date Entry");
            datagrid.Columns.Add("ref_no", "Ref No.");
            datagrid.Columns.Add("payee", "Payee");
            datagrid.Columns.Add("explanation", "Explanation");
            datagrid.Columns.Add("fund_code", "Fund Code");
            datagrid.Columns.Add("created_at", "Created At");
            datagrid.Columns.Add("created_by_id", "Created By ID");
            datagrid.Columns.Add("created_by_name", "Created By");
            datagrid.Columns.Add("updated_at", "Updated At");
            datagrid.Columns.Add("updated_by_id", "Updated By ID");
            datagrid.Columns.Add("updated_by_name", "Updated By");
            datagrid.Columns.Add("status", "Status");


            datagrid.Columns["id"].Visible = false;
            datagrid.Columns["funds_id"].Visible = false;
            datagrid.Columns["journals_id"].Visible = false;
            datagrid.Columns["full_jev_no"].Width = 120;
            datagrid.Columns["ref_no"].Width = 60;
            datagrid.Columns["date_entry"].Width = 120;
            datagrid.Columns["status"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            datagrid.Columns["created_by_name"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            datagrid.ShowCellToolTips = false;
            datagrid.Columns["payee"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill; 
            datagrid.Columns["date_entry"].DefaultCellStyle.Format = "MMMM, dd, yyyy";
            datagrid.Columns["jev_no"].Visible = false;
            datagrid.Columns["fund_code"].Visible = false;
            datagrid.Columns["created_at"].Visible = false;
            datagrid.Columns["updated_at"].Visible = false;
            datagrid.Columns["created_by_id"].Visible = false;
            datagrid.Columns["updated_by_id"].Visible = false;
            datagrid.Columns["updated_by_name"].Visible = false;    
            datagrid.Columns["explanation"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            datagrid.Columns["status"].SortMode = DataGridViewColumnSortMode.Automatic;

        }

        #endregion

        #region Amortization

        internal static void AmortizationDataGridView(DataTable dataTable, DataGridView dataGridView) 
        {
            dataGridView.DataSource = dataTable;

            dataGridView.Columns["id"].Visible = false;
            dataGridView.Columns["bank_name"].HeaderText = "Bank";
            dataGridView.Columns["amortization_term"].HeaderText = "Term";
            dataGridView.Columns["amortization_term"].AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
            dataGridView.Columns["amortization_term"].Width = 100;
            dataGridView.Columns["interest"].HeaderText = "Interest";
            dataGridView.Columns["interest"].AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
            dataGridView.Columns["interest"].Width = 100;
            dataGridView.Columns["amount_released"].HeaderText = "Amount Released";
            dataGridView.Columns["amount_released"].AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
            dataGridView.Columns["amount_released"].Width = 200;
            dataGridView.Columns["interest"].DefaultCellStyle.Format = "0.00\\%";
            dataGridView.Columns["amount_released"].DefaultCellStyle.Format = "#,0.00###";         
        }

        #endregion

        #region Amortization Schedule

        public static void DatagridViewAmortizationSchedule(DataTable dataTable, string amortizationTerm, DataGridView dataGridView) 
        {

            dataGridView.DataSource = dataTable;

            dataGridView.Columns["id"].Visible = false;
            dataGridView.Columns["amortization_id"].Visible = false;

            switch (amortizationTerm)
            {
                case "Annually":
                    dataGridView.Columns["date"].HeaderText = "Year";
                    dataGridView.Columns["date"].DefaultCellStyle.Format = "yyyy";
                    break;

                case "Monthly":
                    dataGridView.Columns["date"].HeaderText = "Month";
                    dataGridView.Columns["date"].DefaultCellStyle.Format = "MMMMM, yyyy";
                    break;

                case "Daily":
                    dataGridView.Columns["date"].HeaderText = "Date";
                    dataGridView.Columns["date"].DefaultCellStyle.Format = "ddd. dd, MMMMM yyyy";
                    break;

                default:
                    dataGridView.Columns["date"].HeaderText = "Date";
                    dataGridView.Columns["date"].DefaultCellStyle.Format = "ddd. dd, MMMMM yyyy";
                    break;
            }

          
            dataGridView.Columns["principal_amount"].DefaultCellStyle.Format = "#,0.00###";
            dataGridView.Columns["principal_amount"].HeaderText = "Principal";
            dataGridView.Columns["interest_amount"].DefaultCellStyle.Format = "#,0.00###";
            dataGridView.Columns["interest_amount"].HeaderText = "Interest";
            dataGridView.Columns["grt_amount"].DefaultCellStyle.Format = "#,0.00###";
            dataGridView.Columns["grt_amount"].HeaderText = "GRT";
        }

        #endregion
    }
}
