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
        #region RPT Payment Posting

        public static void TaxPayerListDatagridView(DataGridView dataGridView, DataTable dataTable) 
        {
            dataGridView.DataSource = dataTable;
            dataGridView.Columns["id"].Visible = false;
            dataGridView.Columns["owner_tin"].HeaderText = "Local TIN";
            dataGridView.Columns["barangay_name"].HeaderText = "Barangay";
            dataGridView.Columns["owner_name"].HeaderText = "Name";
            dataGridView.Columns["municipality_name"].HeaderText = "Municipality";
            dataGridView.Columns["province_name"].HeaderText = "Province";
            dataGridView.Columns["owner_address"].HeaderText = "Address";
        }

        public static void TaxPayerProperties(DataGridView dataGridView, DataTable dataTable) 
        {
            dataGridView.DataSource = dataTable;
            dataGridView.ReadOnly = false;
            dataGridView.Columns["id"].Visible = false;
            dataGridView.Columns["is_checked"].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
            dataGridView.Columns["is_checked"].HeaderText = string.Empty;
            dataGridView.Columns["complete_arp_no"].ReadOnly = true;
            dataGridView.Columns["complete_arp_no"].HeaderText = "ARP No.";
            dataGridView.Columns["property_pin"].HeaderText = "PIN";
            dataGridView.Columns["property_pin"].ReadOnly = true;
            dataGridView.Columns["barangay_name"].HeaderText = "Barangay";
            dataGridView.Columns["barangay_name"].ReadOnly = true;
            dataGridView.Columns["property_kind"].HeaderText = "Property Kind";
            dataGridView.Columns["property_kind"].ReadOnly = true;
            dataGridView.Columns["is_cancelled"].HeaderText = "Cancelled";
            dataGridView.Columns["is_cancelled"].ReadOnly = true;
            dataGridView.Columns["is_cancelled"].DefaultCellStyle.NullValue = null;
            dataGridView.Columns["is_cancelled"].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
        }

        #endregion

        #region RPT Tax Rates

        public static void TaxRatesDatagridView(DataGridView dataGridView, DataTable dataTable)
        {
            dataGridView.DataSource = dataTable;

            dataGridView.Columns["id"].Visible = false;
            dataGridView.Columns["code"].HeaderText = "Code";
            dataGridView.Columns["description"].HeaderText = "Description";
            dataGridView.Columns["rate"].HeaderText = "Rate";
            dataGridView.Columns["rate"].DefaultCellStyle.Format = "P";
        }

        #endregion

        #region RPT Penalties

        public static void PenaltiesDatagridView(DataGridView dataGridView, DataTable dataTable)
        {
            dataGridView.DataSource = dataTable;

            dataGridView.Columns["id"].Visible = false;   
            dataGridView.Columns["description"].HeaderText = "Description";
            dataGridView.Columns["rate"].HeaderText = "Rate";
            dataGridView.Columns["rate"].DefaultCellStyle.Format = "P";
            dataGridView.Columns["frequency"].HeaderText = "Frequency";
        }

        #endregion

        #region RPT Discounts

        public static void DiscountsDatagridView(DataGridView dataGridView, DataTable dataTable) 
        {
            dataGridView.DataSource = dataTable;

            dataGridView.Columns["id"].Visible = false;
            dataGridView.Columns["month"].Visible = false;
            dataGridView.Columns["month_name"].HeaderText = "Month";
            dataGridView.Columns["month_name"].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
            dataGridView.Columns["description"].HeaderText = "Description";
            dataGridView.Columns["rate"].HeaderText = "Rate";
            dataGridView.Columns["rate"].DefaultCellStyle.Format = "P";
            dataGridView.Columns["rate"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dataGridView.Columns["rate"].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
            dataGridView.Columns["is_advance"].HeaderText = "Advance";
            dataGridView.Columns["is_advance"].DefaultCellStyle.NullValue = null;
            dataGridView.Columns["is_advance"].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
        }

        #endregion

        #region RPT Posting
        internal static void BarangayCombobox(DataTable dataTable, ComboBox comboBox, string displayMember, string valueMember)
        {
            DataRow dr = dataTable.NewRow();
            dr["id"] = "0";
            dr["name"] = "All";
            dataTable.Rows.InsertAt(dr, 0);

            comboBox.DataSource = dataTable;
            comboBox.DisplayMember = displayMember;
            comboBox.ValueMember = valueMember;
            comboBox.DropDownHeight = 200;
        }

        internal static void RealPropertiesSearchDatagridView(DataTable dataTable, DataGridView datagrid)
        {
            datagrid.DataSource = dataTable;
            datagrid.Columns["id"].Visible = false;
            datagrid.Columns["owners_id"].Visible = false;
            datagrid.Columns["barangays_id"].Visible = false;

            datagrid.Columns["complete_arp_no"].HeaderText = "ARP No.";
            datagrid.Columns["owner_name"].HeaderText = "Owner";
            datagrid.Columns["barangay_name"].HeaderText = "Barangay";
            datagrid.Columns["assessed_value"].HeaderText = "Assessed Value";

            datagrid.Columns["discount_rate"].HeaderText = "Discount Rate";
            datagrid.Columns["penalty_rate"].HeaderText = "Penalty Rate";
            datagrid.Columns["penalty_frequency"].HeaderText = "Penalty Frequency";
            datagrid.Columns["basic_rate"].HeaderText = "Basic Rate";
            datagrid.Columns["sef_rate"].HeaderText = "SEF Rate";



            datagrid.Columns["pin"].HeaderText = "PIN";
            datagrid.Columns["is_taxable"].HeaderText = "Taxable";
            datagrid.Columns["is_cancelled"].DefaultCellStyle.NullValue = null;
            datagrid.Columns["is_cancelled"].HeaderText = "Cancelled";
            datagrid.Columns["is_posted"].DefaultCellStyle.NullValue = null;
            datagrid.Columns["is_posted"].HeaderText = "Posted";

            datagrid.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }
        #endregion

        #region References

        public static void ReferencesDatagridView(DataTable dataTable, DataGridView dataGridView)
        {
            Helper.DatagridFullRowSelectStyle(dataGridView, true);
            dataGridView.Columns.Clear();
            dataGridView.Rows.Clear();
            dataGridView.ShowCellToolTips = false;
            dataGridView.Columns.Add("id", "ID");
            dataGridView.Columns.Add(new DataGridViewCheckBoxColumn() { HeaderText = "", Name = "is_referenced" });
            dataGridView.Columns.Add("document_reference_name", "References");
            dataGridView.Columns.Add("document_name", "Documents");

            dataGridView.Columns["id"].Visible = false;
            dataGridView.Columns["is_referenced"].Width = 30;
            dataGridView.Columns["is_referenced"].MinimumWidth = 30;
            dataGridView.ReadOnly = false;
            dataGridView.MultiSelect = false;
            dataGridView.Columns["document_reference_name"].ReadOnly = true;
            dataGridView.Columns["document_reference_name"].Width = 150;
            dataGridView.Columns["document_name"].ReadOnly = true;
        }

        #endregion

        #region Signatories

        internal static void SignatoriesDatagridView(DataTable dataTable, DataGridView dataGridView)
        {
            dataGridView.DataSource = dataTable;
            dataGridView.Columns["id"].Visible = false;
            dataGridView.Columns["name"].HeaderText = "Name";
            dataGridView.Columns["title"].HeaderText = "Title";
            dataGridView.Columns["created_at"].Visible = false;
            dataGridView.Columns["updated_at"].Visible = false;
        }

        #endregion

        #region Year
        internal static void YearComboBox(ComboBox comboBox)
        {
            _ = comboBox.Items.Add("2022");
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
            datagrid.Columns["maj_acc_group_id"].Visible = false;
            datagrid.Columns["maj_acc_group_code"].HeaderText = "Code";
            datagrid.Columns["maj_acc_group_code"].Width = 100;
            datagrid.Columns["maj_acc_group_name"].HeaderText = "Name";
            datagrid.Columns["maj_acc_group_name"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            datagrid.Columns["account_group_name"].HeaderText = "Account Group";
            datagrid.Columns["created_at"].Visible = false;
            datagrid.Columns["updated_at"].Visible = false;
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

            comboBox.DropDownHeight = 200;
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
        internal static void GeneralLedgerAccountsWithBalancesDatagridView(DataTable dataTable, DataGridView datagrid)
        {
            datagrid.DataSource = dataTable;
            datagrid.Columns["general_ledger_accounts_id"].Visible = false;
            datagrid.Columns["account_code"].HeaderText = "Code";
            datagrid.Columns["account_code"].Width = 150;
            datagrid.Columns["account_code"].MinimumWidth = 100;
            datagrid.Columns["ledger_name"].HeaderText = "Name";
            datagrid.Columns["ledger_name"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            datagrid.Columns["created_at"].Visible = false;
            datagrid.Columns["updated_at"].Visible = false;
            datagrid.Columns["Debit"].DefaultCellStyle.Format = "N2";
            datagrid.Columns["Debit"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            datagrid.Columns["Debit"].Width = 100;
            datagrid.Columns["Debit"].MinimumWidth = 100;
            datagrid.Columns["Credit"].DefaultCellStyle.Format = "N2";
            datagrid.Columns["Credit"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            datagrid.Columns["Credit"].Width = 100;
            datagrid.Columns["Credit"].MinimumWidth = 100;
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

                var beginningBalanceRepository = AccFactory.BeginningBalancesRepository();
                decimal generalLedgerBalance = beginningBalanceRepository.GetSumBalanceBy_FundId_GenLedgId_Year_SubLedgId(fundsId, generalLedgerId, year, subsidiaryLedgerId);
                var beginningBalanceDict = beginningBalanceRepository.GetRecordBy_FundId_GenLedgId_Year_SubLedgId(fundsId, generalLedgerId, year, subsidiaryLedgerId);

                debitCreditType = ValidateDebitOrCreditType(beginningBalanceDict, debitCreditType);


                item["Balance"] = generalLedgerBalance;
                item["Type"] = debitCreditType;

            }

            datagrid.DataSource = dataTable;
            datagrid.Columns["id"].Visible = false;
            datagrid.Columns["funds_id"].Visible = false;
            datagrid.Columns["general_ledger_accounts_id"].Visible = false;
            datagrid.Columns["sub_code"].HeaderText = "Code";
            datagrid.Columns["sub_code"].Width = 100;
            datagrid.Columns["sub_name"].HeaderText = "Name";
            datagrid.Columns["sub_name"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            datagrid.Columns["Balance"].DefaultCellStyle.Format = "N2";
            datagrid.Columns["Balance"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            datagrid.Columns["Balance"].Width = 100;
            datagrid.Columns["address"].HeaderText = "Address";
            datagrid.Columns["contact_person"].HeaderText = "Contact Person";
            datagrid.Columns["contact"].HeaderText = "Contact";
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

            var dtJournals = AccFactory.JournalsRepository().GetRecords();

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
            datagrid.Rows.Clear();
            datagrid.Columns.Clear();

            datagrid.Columns.Add("id", "ID");
            datagrid.Columns.Add("collecting_officer", "Collecting Officer");
            datagrid.Columns.Add("accountable_form", "Accountable Form");
            datagrid.Columns.Add("receipt_number_from", "Receipt No. From");
            datagrid.Columns.Add("receipt_number_to", "Receipt No. To");
            datagrid.Columns.Add("date_issued", "Date Issued");
            datagrid.Columns.Add("quantity", "Quantity");
            datagrid.Columns.Add("last_issued", "Last Issued No.");
            datagrid.Columns.Add("returned", "Returned");
            datagrid.Columns.Add("returned_date", "Returned Date");
            datagrid.Columns.Add("issued_by", "User/Officer");


            datagrid.Columns["id"].Visible = false;

            datagrid.Columns["receipt_number_from"].DefaultCellStyle.Format = "D7";
            datagrid.Columns["receipt_number_to"].DefaultCellStyle.Format = "D7";
            datagrid.Columns["last_issued"].DefaultCellStyle.Format = "D7";


            datagrid.Columns["date_issued"].DefaultCellStyle.Format = "MMMM-dd-yyyy";
            datagrid.Columns["returned_date"].DefaultCellStyle.Format = "MMMM-dd-yyyy";

            datagrid.Columns["receipt_number_from"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            datagrid.Columns["receipt_number_to"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            datagrid.Columns["date_issued"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            datagrid.Columns["quantity"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            datagrid.Columns["last_issued"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            datagrid.Columns["returned"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            datagrid.Columns["returned_date"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

            datagrid.Columns["collecting_officer"].Width = 150;
            datagrid.Columns["quantity"].Width = 80;
            datagrid.Columns["accountable_form"].Width = 300;
            datagrid.Columns["issued_by"].Width = 150;

            string collectingOfficer;

            foreach (DataRow row in dataTable.Rows)
            {
                if (string.IsNullOrEmpty(row["job_orders_id"].ToString()))
                    collectingOfficer = $"{row["collecting_officers_first_name"]} {row["collecting_officers_mid_initial"]}. {row["collecting_officers_last_name"]}";
                else
                    collectingOfficer = $"{row["job_orders_first_name"]} {row["job_orders_mid_initial"]}. {row["job_orders_last_name"]}";

                var issuedSerialNumberFrom = row["receipt_issued_from"].ToString().Equals("0") ? "" : row["receipt_issued_from"];
                var issuedSerialNumberTo = row["receipt_issued_to"].ToString().ToString().Equals("0") ? "" : row["receipt_issued_to"];

                datagrid.Rows.Add(new object[]
                {
                    row["id"],
                    collectingOfficer,
                    row["accountable_forms"],
                    issuedSerialNumberFrom,
                    issuedSerialNumberTo,
                    row["date_issued"],
                    row["quantity"],
                    row["last_issued"],
                    row["returned"],
                    row["returned_date"],
                    row["issued_by"]
                });
            }

            datagrid.ClearSelection();

            float fontSize = 8.5f;
            datagrid.DefaultCellStyle.Font = new Font("Segoe UI", fontSize);

        }
        #endregion

        #region Returned Receipts
        internal static void ReturnedReceiptsDatagridView(DataTable dataTable, DataGridView datagrid)
        {
            datagrid.DataSource = dataTable;

            datagrid.Columns[0].HeaderText = "Receipt ID";
            datagrid.Columns[1].HeaderText = "Accountable Form ID";
            datagrid.Columns[2].HeaderText = "Accountable Form";
            datagrid.Columns[3].HeaderText = "Collecting Officer ID ";
            datagrid.Columns[4].HeaderText = "Collecting Officer";
            datagrid.Columns[5].HeaderText = "Date Issued";
            datagrid.Columns[6].HeaderText = "Receipt Number From";
            datagrid.Columns[7].HeaderText = "Receipt Number To";
            datagrid.Columns[8].HeaderText = "Quantity";
            datagrid.Columns[9].HeaderText = "Last Issued";
            datagrid.Columns[10].HeaderText = "Returned Quantity";
            datagrid.Columns[11].HeaderText = "Date Returned";

            datagrid.Columns[0].Visible = false;
            datagrid.Columns[1].Visible = false;
            datagrid.Columns[3].Visible = false;

            datagrid.Columns[5].DefaultCellStyle.Format = "yyyy-MM-dd";
            datagrid.Columns[11].DefaultCellStyle.Format = "yyyy-MM-dd";

            datagrid.Columns[2].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            datagrid.Columns[3].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            datagrid.Columns[5].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            datagrid.Columns[6].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            datagrid.Columns[7].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            datagrid.Columns[8].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            datagrid.Columns[9].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            datagrid.Columns[10].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            datagrid.Columns[11].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

            datagrid.Columns[2].Width = 300;
            datagrid.Columns[5].Width = 100;
            datagrid.Columns[4].Width = 200;
            datagrid.Columns[6].Width = 90;
            datagrid.Columns[7].Width = 90;
            datagrid.Columns[8].Width = 80;
            datagrid.Columns[9].Width = 90;
            datagrid.Columns[10].Width = 100;
            datagrid.Columns[11].Width = 100;

            float fontSize = 8.5f;
            datagrid.DefaultCellStyle.Font = new Font("Segoe UI", fontSize);
            datagrid.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }
        #endregion

        #region Receipts
        internal static void ReceiptsDatagridView(DataTable dataTable, DataGridView datagrid)
        {
            datagrid.Rows.Clear();
            datagrid.Columns.Clear();

            datagrid.Columns.Add("id", "ID");
            datagrid.Columns.Add("receipt", "Receipt (Form)");
            datagrid.Columns.Add("receipt_number_from", "Receipt No. From");
            datagrid.Columns.Add("receipt_number_to", "Receipt No. To");
            datagrid.Columns.Add("quantity", "Quantity");
            datagrid.Columns.Add("received_date", "Received Date");
            datagrid.Columns.Add("officer", "User/Officer");

            datagrid.Columns["receipt_number_from"].DefaultCellStyle.Format = "D7";
            datagrid.Columns["receipt_number_to"].DefaultCellStyle.Format = "D7";

            datagrid.Columns["id"].Visible = false;
            datagrid.Columns["received_date"].DefaultCellStyle.Format = "MMMM-dd-yyyy";
            datagrid.Columns["receipt_number_from"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            datagrid.Columns["receipt_number_to"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            datagrid.Columns["quantity"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;

            datagrid.Columns["receipt_number_to"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            datagrid.Columns["receipt_number_from"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            datagrid.Columns["quantity"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;

            datagrid.Columns["receipt"].Width = 500;
            datagrid.Columns["received_date"].Width = 150;

            foreach (DataRow row in dataTable.Rows)
            {
                var serialNumberFrom = Convert.ToInt32(row["receipt_number_from"]) == 0 ? "" : row["receipt_number_from"];
                var serialNumberTo = Convert.ToInt32(row["receipt_number_to"]) == 0 ? "" : row["receipt_number_to"];

                datagrid.Rows.Add(new object[]
                {
                    row["id"],
                    $"{row["acc_form_no"]} - {row["acc_form_desc"]}",
                    serialNumberFrom,
                    serialNumberTo,
                    row["quantity"],
                    row["received_date"],
                    row["officer"]
                });
            }

            float fontSize = 8.5f;
            datagrid.DefaultCellStyle.Font = new Font("Segoe UI", fontSize);

        }
        #endregion

        internal static void AccountableFormsCombobox(ComboBox combobbox, DataTable dataTable)
        {
            try
            {
                var dtAccountableFormRepo = AccFactory.AccountableFormsRepository().GetRecords();
                dtAccountableFormRepo.Columns.Add("accountableForm", typeof(string), "acc_form_no + ' - ' + acc_form_desc");

                combobbox.DataSource = dtAccountableFormRepo;
                combobbox.ValueMember = "id";
                combobbox.DisplayMember = "accountableForm";
            }
            catch (Exception ex)
            {
                Helper.MessageBoxError(ex.Message);
            }
        }

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

        internal static void BanksDepositsSummaryDatagridView(DataTable dataTable, DataGridView datagrid)
        {
            datagrid.Rows.Clear();
            datagrid.Columns.Clear();


            datagrid.Columns.Add("banks_id", "Bank ID");
            datagrid.Columns.Add("account_number", "Account No.");
            datagrid.Columns.Add("bank_name", "Bank Name");
            datagrid.Columns.Add("amount", "Amount");

            datagrid.Columns["banks_id"].Visible = false;
            datagrid.Columns["amount"].DefaultCellStyle.Format = "N2";
            datagrid.Columns["amount"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;

            datagrid.Columns["account_number"].Width = 130;
            datagrid.Columns["account_number"].MinimumWidth = 130;
            datagrid.Columns["bank_name"].Width = 170;
            datagrid.Columns["bank_name"].MinimumWidth = 170;
            datagrid.Columns["amount"].Width = 80;
            datagrid.Columns["amount"].MinimumWidth = 80;

            foreach (DataRow row in dataTable.Rows)
            {
                datagrid.Rows.Add(new object[]
                {
                    row["banks_id"], 
                    row["account_no"], 
                    row["bank_name"], 
                    row["amount"], 
                });
            }

            float fontSize = 8.5f;
            datagrid.DefaultCellStyle.Font = new Font("Segoe UI", fontSize);
            datagrid.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            datagrid.ClearSelection();
            Helper.DatagridFullRowSelectStyle(datagrid, true);
        }

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
                    drRCD["rcd_date"],
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


            foreach (DataRow row in dataTable.Rows)
            {
                var status = Convert.ToInt16(row["is_approved"].ToString()) == 1 ? " Approved" :
                             Convert.ToInt16(row["is_disapproved"].ToString()) == 1 ? " Disapproved" : " Pending";

                string collectingOfficerId;
                string collectingOfficer;
                if (string.IsNullOrEmpty(row["job_orders_id"].ToString()))
                {
                    collectingOfficer = $"{row["collecting_officers_first_name"]} {row["collecting_officers_mid_initital"]}. {row["collecting_officers_last_name"]}";
                    collectingOfficerId = row["collecting_officers_id"].ToString();
                }

                else
                {
                    collectingOfficer = $"{row["job_orders_first_name"]} {row["job_orders_mid_initial"]}. {row["job_orders_last_name"]}";
                    collectingOfficerId = row["job_orders_id"].ToString();
                }


                datagrid.Rows.Add(new object[]
                {
                    row["id"],
                    row["report_no"],
                    collectingOfficerId,
                    collectingOfficer,
                    row["fund_id"],
                    row["fund_name"],
                    row["date"],
                    row["is_approved"],
                    row["is_disapproved"],
                    row["amount"],
                    status
                });
            }

            float fontSize = 8.5f;
            datagrid.DefaultCellStyle.Font = new Font("Segoe UI", fontSize);


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

        internal static void RCIObligationDatagridview(DataTable dataTable, DataGridView datagrid)
        {
            datagrid.DataSource = dataTable;

            datagrid.Columns[0].HeaderText = "Obligation No. ";

            datagrid.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }

        internal static void RCIDeductionsDatagridview(DataTable dataTable, DataGridView datagrid)
        {
            datagrid.DataSource = dataTable;

            datagrid.Columns[0].HeaderText = "Description";
            datagrid.Columns[1].HeaderText = "Amount";

            datagrid.Columns[1].DefaultCellStyle.Format = "D2";
            datagrid.Columns[1].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;


            datagrid.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }

        internal static void RCIDatagridView(DataTable dataTable, DataGridView datagrid)
        {
            datagrid.DataSource = dataTable;

            datagrid.Columns[0].HeaderText = "Id ";
            datagrid.Columns[1].HeaderText = "Bank Id ";
            datagrid.Columns[2].HeaderText = "Account No.";
            datagrid.Columns[3].HeaderText = "Bank Name";
            datagrid.Columns[4].HeaderText = "Fund Id";
            datagrid.Columns[5].HeaderText = "Fund Code";
            datagrid.Columns[6].HeaderText = "Fund";
            datagrid.Columns[7].HeaderText = "Check Date";
            datagrid.Columns[8].HeaderText = "Check No.";
            datagrid.Columns[9].HeaderText = "DV No.";
            datagrid.Columns[10].HeaderText = "Payee";
            datagrid.Columns[11].HeaderText = "Nature of Payment";
            datagrid.Columns[12].HeaderText = "Obligation No.";
            datagrid.Columns[13].HeaderText = "FPP Id";
            datagrid.Columns[14].HeaderText = "FPP Code";
            datagrid.Columns[15].HeaderText = "Deductions";
            datagrid.Columns[15].DefaultCellStyle.Format = "N2";
            datagrid.Columns[15].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;

            datagrid.Columns[16].HeaderText = "Net Amount";
            datagrid.Columns[16].DefaultCellStyle.Format = "N2";
            datagrid.Columns[16].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            datagrid.Columns[17].HeaderText = "Created at";
            datagrid.Columns[18].HeaderText = "Updated at";

            datagrid.Columns[2].Width = 150;
            datagrid.Columns[3].Width = 250;
            datagrid.Columns[6].Width = 100;
            datagrid.Columns[7].Width = 100;
            datagrid.Columns[8].Width = 100;
            datagrid.Columns[9].Width = 150;
            datagrid.Columns[10].Width = 250;
            datagrid.Columns[11].Width = 250;
            datagrid.Columns[12].Width = 250;


            datagrid.Columns[0].Visible = false;
            datagrid.Columns[1].Visible = false;
            datagrid.Columns[4].Visible = false;
            datagrid.Columns[5].Visible = false;
            datagrid.Columns[13].Visible = false;
            datagrid.Columns[17].Visible = false;
            datagrid.Columns[18].Visible = false;

        }
        #endregion

        #region Real Property Tax View
        public static void PropertiesDatagridView(DataTable dataTable, DataGridView datagrid)
        {
            datagrid.Rows.Clear();
            datagrid.Columns.Clear();

            datagrid.Columns.Add("property_kind", "Property Kind");
            datagrid.Columns.Add("complete_arp_no", "Complete ARP No.");
            datagrid.Columns.Add("pin", "PIN");
            datagrid.Columns.Add("owner_name", "Owner Name");
            datagrid.Columns.Add("owner_address", "Owner Address");
            datagrid.Columns.Add("market_value", "Market Value");
            datagrid.Columns.Add("assessed_value", "Assessment Value");

            datagrid.Columns["property_kind"].Width = 80;
            datagrid.Columns["property_kind"].MinimumWidth = 80;

            datagrid.Columns["complete_arp_no"].Width = 80;
            datagrid.Columns["complete_arp_no"].MinimumWidth = 80;

            datagrid.Columns["pin"].Width = 80;
            datagrid.Columns["pin"].MinimumWidth = 80;

            datagrid.Columns["owner_address"].Width = 200;
            datagrid.Columns["owner_address"].MinimumWidth = 200;

            datagrid.Columns["market_value"].Width = 120;
            datagrid.Columns["market_value"].MinimumWidth = 120;
            datagrid.Columns["market_value"].DefaultCellStyle.Format = "N2";
            datagrid.Columns["market_value"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;

            datagrid.Columns["assessed_value"].Width = 120;
            datagrid.Columns["assessed_value"].MinimumWidth = 120;
            datagrid.Columns["assessed_value"].DefaultCellStyle.Format = "N2";
            datagrid.Columns["assessed_value"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;


            foreach (DataRow row in dataTable.Rows)
            {
                datagrid.Rows.Add(new object[]
                {
                    row["property_kind"],
                    row["complete_arp_no"],
                    row["pin"],
                    row["owner_name"],
                    row["owner_address"],
                    row["market_value"],
                    row["assessed_value"]
                });
            }

            float fontSize = 8.5f;
            datagrid.DefaultCellStyle.Font = new Font("Segoe UI", fontSize);


            //datagrid.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            datagrid.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            datagrid.DefaultCellStyle.WrapMode = DataGridViewTriState.True;

            datagrid.ClearSelection();
            Helper.DatagridFullRowSelectStyle(datagrid, true);
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

        internal static void PaymentSummaryDatagridView(DataTable dataTable, DataGridView datagrid)
        {
            datagrid.Rows.Clear();
            datagrid.Columns.Clear();

            datagrid.Columns.Add("collecting_officer_id", "ID");
            datagrid.Columns.Add("collecting_officer", "Collecting Officer");
            datagrid.Columns.Add("amount", "Amount");

            datagrid.Columns["collecting_officer_id"].Visible = false;
            datagrid.Columns["collecting_officer"].Width = 300;
            datagrid.Columns["collecting_officer"].MinimumWidth = 300;

            datagrid.Columns["amount"].Width = 80;
            datagrid.Columns["amount"].MinimumWidth = 80;
            datagrid.Columns["amount"].DefaultCellStyle.Format = "N2";
            datagrid.Columns["amount"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;

            foreach (DataRow row in dataTable.Rows)
            {
                var regularCollector = $"{row["collecting_officers_first_name"]} {row["collecting_officers_mid_initial"]}. {row["collecting_officers_last_name"]}";
                var jobOrderCollector = $"{row["job_orders_first_name"]} {row["job_orders_mid_initial"]}. {row["job_orders_last_name"]}";
                var collectingOfficer = string.IsNullOrEmpty(row["job_orders_id"].ToString()) ? regularCollector : jobOrderCollector;

                datagrid.Rows.Add(new object[]
                {
                    row["collecting_officer_id"],
                    collectingOfficer,
                    row["amount"]
                });
            }

            float fontSize = 8.5f;
            datagrid.DefaultCellStyle.Font = new Font("Segoe UI", fontSize);

            datagrid.ClearSelection();
            Helper.DatagridFullRowSelectStyle(datagrid, true);
        }

        internal static void PaymentDatagridView(DataTable dataTable, DataGridView datagrid)
        {
            datagrid.Rows.Clear();
            datagrid.Columns.Clear();

            datagrid.Columns.Add("id", "ID");
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

            datagrid.Columns["id"].Visible = false;
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

            datagrid.Columns["receipt_no"].DefaultCellStyle.Format = "D7";
            datagrid.Columns["receipt_no"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

            foreach (DataRow row in dataTable.Rows)
            {
                var abstractOfGeneralCollection = $"{row["account_code"]} - {row["ledger_name"]}";

                datagrid.Rows.Add(new object[]
                {
                    row["id"],
                    row["funds_id"],
                    row["fund_name"],
                    row["accountable_form_id"],
                    row["accountable_forms"],
                    row["general_ledger_accounts_id"],
                    abstractOfGeneralCollection,
                    row["payee"],
                    row["receipt_no"],
                    row["quantity"],
                    row["payment_date"],
                    row["amount"]
                });
            }

            float fontSize = 8.5f;
            datagrid.DefaultCellStyle.Font = new Font("Segoe UI", fontSize);

            datagrid.ClearSelection();
            Helper.DatagridFullRowSelectStyle(datagrid, true);

        }
        #endregion

        #region PaymentCollectionReport
        internal static void PaymentCollectionReportDatagrid(DataTable dataTable, DataGridView datagrid)
        {
            datagrid.Rows.Clear();
            datagrid.Columns.Clear();

            datagrid.Columns.Add("payment_collections_id", "Payment Collections Id");
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

            datagrid.Columns["payment_collections_id"].Visible = false;
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
                    drPaymentCollection["payment_collections_id"],
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

        internal static void FunctionalClassificationDatagridView(DataTable dataTable, DataGridView datagrid)
        {
            datagrid.DataSource = dataTable;
            datagrid.Columns["id"].Visible = false;
            datagrid.Columns["sector_code"].HeaderText = "Code";
            datagrid.Columns["sector_name"].HeaderText = "Sector Name";
            datagrid.Columns[2].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            datagrid.Columns["created_at"].Visible = false;
            datagrid.Columns["updated_at"].Visible = false;
        }

        internal static void FunctionalClassificationServiceDatagridView(DataTable dataTable, DataGridView datagrid)
        {
            datagrid.DataSource = dataTable;
            datagrid.Columns["id"].Visible = false;
            datagrid.Columns["service_name"].HeaderText = "Name";
            datagrid.Columns["functional_classifications_id"].Visible = false;
            datagrid.Columns["functional_classifications_sector_code"].Visible = false;
            datagrid.Columns["functional_classifications_sector_name"].HeaderText = "Sector";
            datagrid.Columns["created_at"].Visible = false;
            datagrid.Columns["updated_at"].Visible = false;
        }

        internal static void FunctionProjectProgramDatagridView(DataGridView datagrid)
        {
            var isSpecial = new DataGridViewImageColumn();
            isSpecial.Name = "is_special";
            isSpecial.HeaderText = "Special";

            datagrid.Columns.Add("id", "Id");
            datagrid.Columns.Add("fpp_code", "Code");
            datagrid.Columns.Add("fpp_name", "Name");
            datagrid.Columns.Add("functional_classification_services_id", "functional_classification_services_id");
            datagrid.Columns.Add("service_name", "Service");
            datagrid.Columns.Add(isSpecial);
            datagrid.Columns.Add("created_at", "Created At");
            datagrid.Columns.Add("updated_at", "Updated At");

            datagrid.Columns["id"].Visible = false;
            datagrid.Columns["functional_classification_services_id"].Visible = false;
            datagrid.Columns["created_at"].Visible = false;
            datagrid.Columns["updated_at"].Visible = false;

            datagrid.Columns["fpp_code"].Width = 40;
            datagrid.Columns["is_special"].AutoSizeMode = DataGridViewAutoSizeColumnMode.ColumnHeader;
            datagrid.Columns["is_special"].DefaultCellStyle.NullValue = null;
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
            comboBox1.DropDownHeight = 200;

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

        internal static void AllotmentClasssesCombobox(DataTable dataTable, ComboBox comboBox, string displayMember, string valueMember)
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
            datagrid.Columns[5].Visible = false;
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

        internal static void RegularAndJOCollectingOfficerComboBox(DataTable dataTable, ComboBox comboBox, string displayMember, string valueMember)
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

        #region JobOrders
        internal static void JobOrdersDatagridView(DataTable dataTable, DataGridView datagrid)
        {
            datagrid.DataSource = dataTable;

            datagrid.Columns[0].Visible = false;
            datagrid.Columns[1].HeaderText = "Full Name";
            datagrid.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            datagrid.Columns[2].HeaderText = "Job Title";
            datagrid.Columns[2].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
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
            datagrid.Columns[5].Visible = false;

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
            datagrid.Columns["id"].Visible = false;
            datagrid.Columns["roles_id"].Visible = false;
            datagrid.Columns["prefix"].Visible = false;
            datagrid.Columns["first_name"].Visible = false;
            datagrid.Columns["mid_initial"].Visible = false;
            datagrid.Columns["last_name"].Visible = false;
            datagrid.Columns["suffix"].Visible = false;
            datagrid.Columns["user_full_name"].HeaderText = "Name";
            datagrid.Columns["username"].HeaderText = "Username";
            datagrid.Columns["password"].Visible = false;
            datagrid.Columns["is_deleted"].Visible = false;
            datagrid.Columns["created_at"].Visible = false;
            datagrid.Columns["updated_at"].Visible = false;
            datagrid.Columns["office"].HeaderText = "Office";
            datagrid.Columns["role_name"].HeaderText = "Role";
            datagrid.Columns["permission_name"].Visible = false;
            datagrid.Columns["permission_office"].Visible = false;

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

        #region Budget Appropriations

        internal static void BudgetApproprationsFPPCombobox(DataTable dataTable, ComboBox comboBox, string displayMember, string valueMember)
        {
            comboBox.DataSource = dataTable;
            comboBox.ValueMember = valueMember;
            comboBox.DisplayMember = displayMember;
            comboBox.DropDownHeight = 200;
        }

        internal static void BudgetAppropriationsAllotmentClassCombobox(DataTable dataTable, ComboBox comboBox, string displayMember, string valueMember)
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
            #region Datagrid Format
            //Image Column
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
            dgvBudgetAppropriations.Columns.Add("object_of_expenditures", "Object of Expenditures");
            dgvBudgetAppropriations.Columns.Add("date_entry", "Date Entry");
            dgvBudgetAppropriations.Columns.Add("amount", "Appropriation");
            dgvBudgetAppropriations.Columns.Add("allotment_released", "Allotment Released");
            dgvBudgetAppropriations.Columns.Add("obligations", "Obligations");
            dgvBudgetAppropriations.Columns.Add("unobligated_balance", "Unobligated Balance");
            dgvBudgetAppropriations.Columns.Add("year", "Year");
            dgvBudgetAppropriations.Columns.Add(imgColumn);
            dgvBudgetAppropriations.Columns.Add(imgRealignedColumn);
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
            int amountColumWidth = 140;
            dgvBudgetAppropriations.Columns["object_of_expenditures"].Width = 400;

            dgvBudgetAppropriations.Columns["amount"].Resizable = DataGridViewTriState.False;
            dgvBudgetAppropriations.Columns["amount"].Width = amountColumWidth;
            dgvBudgetAppropriations.Columns["amount"].MinimumWidth = amountColumWidth;
            dgvBudgetAppropriations.Columns["amount"].DefaultCellStyle.Format = "N2";
            dgvBudgetAppropriations.Columns["amount"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;


            dgvBudgetAppropriations.Columns["allotment_released"].Resizable = DataGridViewTriState.False;
            dgvBudgetAppropriations.Columns["allotment_released"].Width = amountColumWidth;
            dgvBudgetAppropriations.Columns["allotment_released"].MinimumWidth = amountColumWidth;
            dgvBudgetAppropriations.Columns["allotment_released"].DefaultCellStyle.Format = "N2";
            dgvBudgetAppropriations.Columns["allotment_released"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;

            dgvBudgetAppropriations.Columns["obligations"].Resizable = DataGridViewTriState.False;
            dgvBudgetAppropriations.Columns["obligations"].Width = amountColumWidth;
            dgvBudgetAppropriations.Columns["obligations"].MinimumWidth = amountColumWidth;
            dgvBudgetAppropriations.Columns["obligations"].DefaultCellStyle.Format = "N2";
            dgvBudgetAppropriations.Columns["obligations"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;

            dgvBudgetAppropriations.Columns["unobligated_balance"].Resizable = DataGridViewTriState.False;
            dgvBudgetAppropriations.Columns["unobligated_balance"].Width = amountColumWidth;
            dgvBudgetAppropriations.Columns["unobligated_balance"].MinimumWidth = amountColumWidth;
            dgvBudgetAppropriations.Columns["unobligated_balance"].DefaultCellStyle.Format = "N2";
            dgvBudgetAppropriations.Columns["unobligated_balance"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;


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

            var dtGetViewRecordsByFFPIDByAllotmentClass = AccFactory.BudgetAppropriationsRepository().GetViewRecordsByIdsYear(budgetAppropriationsModel);


            //Load by loop All Budget Appropriations Records without Others FPP 
            foreach (DataRow drGetViewRecordsByIds in dtGetViewRecordsByFFPIDByAllotmentClass.Rows)
            {
                FieldData(dgvBudgetAppropriations, continuingIcon, realignmentIcon, drGetViewRecordsByIds);
            }


            //Initialize Repository Method for others fpp records
            var dtGetRecordsOthersFPP = AccFactory.BudgetAppropriationsRepository().GetHeaderOthersFPP(fppID, allotmentClassID, fundId, year);

            //Load by loop All Budget Appropriations Records with Others FPP 
            foreach (DataRow drGetRecordsOthersFPP in dtGetRecordsOthersFPP.Rows)
            {
                string othersFPPName = drGetRecordsOthersFPP["others_fpp_name"].ToString();
                int othersFPPID = Convert.ToInt32(drGetRecordsOthersFPP["others_fpp_id"]);

                //Set Header for Others FPP 
                dgvBudgetAppropriations.Rows.Add(new object[] { null, null, null, null, null, null, othersFPPName });


                budgetAppropriationsModel.OthersFPPId = othersFPPID;
                DataTable dtGetViewRecordsByIds = AccFactory.BudgetAppropriationsRepository().GetViewRecordsByIdsYear(budgetAppropriationsModel);

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
                byte rowRealignment = Convert.ToByte(AccFactory.BudgetRealignmentRepository().BudgetHasRealignment(rowId));
                string remarks = drGetViewRecordsByIds["remarks"].ToString();

                //GET TOTAL SUPPLEMENTAL APPROPRIATIONS
                decimal totalSupplementalAppropriation = AccFactory.SupplementalAppropriationsRepository().GetSumSupplementalAppropriationsBy_BudgetAppropriationsId(rowId);


                //GET TOTAL ALLOTMENT RELEASE
                var dtAllotmentRelease = AccFactory.AllotmentReleaseRepository().GetViewRecordsByBudgetAppropriationId(rowId);
                decimal totalAllotmentRelease = Convert.ToDecimal(dtAllotmentRelease.Rows.Count == 0 ? 0 : dtAllotmentRelease.Compute("SUM(amount)", string.Empty));

                //GET TOTAL REALIGNMENT
                var totalRealignmentTo = AccFactory.BudgetRealignmentRepository().GetAmountOfBudgetRealignedToByBudgetId(rowId);

                var totalRealignmentFrom = AccFactory.BudgetRealignmentRepository().GetAmountOfBudgetRealignedFromByBudgetId(rowId);

                //GET TOTAL APPROPRIATION
                decimal totalAppropriationAmount = (totalSupplementalAppropriation + rowAppropriationAmount + totalRealignmentTo) - totalRealignmentFrom;

                //GET TOTAL OBLIGATIONS
                var totalObligations = AccFactory.ObligationRequestRepository().GetSumObligationsByBudgetAppropriationAndStatus(rowId);
                var unobligatedBalance = totalAppropriationAmount - totalObligations;

                dgvBudgetAppropriations.Rows.Add(new object[] {
                        rowId,
                        rowFundId,
                        rowFPPId,
                        rowOthersFPPId,
                        rowAllotmentClassId,
                        rowAccountId,
                        $"   {rowAccountCode} - {rowAccountName}{(string.IsNullOrEmpty(remarks)? string.Empty : $" → {remarks}")}",
                        rowDateEntry,
                        totalAppropriationAmount,
                        totalAllotmentRelease,
                        totalObligations,
                        unobligatedBalance,
                        rowYear,
                        rowContinuing == 1? continuingIcon : null,
                        rowRealignment == 1? continuingIcon : null,
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
        }

        #endregion BUDGET APPROPRIATIONS

        #region Allotment Release

        internal static void SearchAllotmentReleaseDatagridView(DataTable dataTable, DataGridView dataGridView)
        {
            Helper.DatagridFullRowSelectStyle(dataGridView, true);
            string[] columns = new[] { "allotment_release_id", "full_aro_no", "date_issued", "purpose", "total_allotment_release", "continuing" };
            var filteredColumnsDtAllotmentRelease = new DataView(dataTable).ToTable(false, columns);
            dataGridView.DataSource = filteredColumnsDtAllotmentRelease;

            dataGridView.Columns["allotment_release_id"].HeaderText = "Allotment Release ID";
            dataGridView.Columns["allotment_release_id"].Visible = false;
            dataGridView.Columns["full_aro_no"].HeaderText = "ARO No.";
            dataGridView.Columns["full_aro_no"].AutoSizeMode = DataGridViewAutoSizeColumnMode.ColumnHeader;
            dataGridView.Columns["date_issued"].HeaderText = "Date Issued";
            dataGridView.Columns["date_issued"].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
            dataGridView.Columns["purpose"].HeaderText = "Purpose";
            dataGridView.Columns["total_allotment_release"].HeaderText = "Total Allotment Release";
            dataGridView.Columns["total_allotment_release"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dataGridView.Columns["continuing"].HeaderText = "Continuing";
            dataGridView.Columns["continuing"].DefaultCellStyle.NullValue = null;
            dataGridView.Columns["continuing"].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
        }

        #endregion

        #region DASHBOARD

        internal static void DashboardDetailedDatagridView(DataGridView dgvBudgetAppropriations, string fppID, int allotmentClassID, int fundId, DateTime dateAsOf)
        {
            try
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

                var dtGetViewRecordsByFFPIDByAllotmentClass = AccFactory.BudgetAppropriationsRepository().GetViewRecordsByFPPIdAndFundIdAndAllotmentClassIdAndDateEntry(fppID, sub_fpp, fundId, allotmentClassID, dateAsOf);


                //Load by loop All Budget Appropriations Records without Others FPP 
                foreach (DataRow drGetViewRecordsByIds in dtGetViewRecordsByFFPIDByAllotmentClass.Rows)
                {
                    FieldData(dgvBudgetAppropriations, continuingIcon, drGetViewRecordsByIds, dateAsOf);
                }


                //Initialize Repository Method for others fpp records
                DataTable dtGetRecordsOthersFPP = AccFactory.BudgetAppropriationsRepository().GetHeaderOthersFPP(fppID, allotmentClassID, fundId, Convert.ToInt16(dateAsOf.Year));

                //Load by loop All Budget Appropriations Records with Others FPP 
                foreach (DataRow drGetRecordsOthersFPP in dtGetRecordsOthersFPP.Rows)
                {
                    string othersFPPName = drGetRecordsOthersFPP["others_fpp_name"].ToString();
                    int othersFPPID = Convert.ToInt32(drGetRecordsOthersFPP["others_fpp_id"]);

                    //Set Header for Others FPP 
                    dgvBudgetAppropriations.Rows.Add(new object[] { null, null, null, null, null, null, othersFPPName });


                    sub_fpp = othersFPPID;
                    DataTable dtGetViewRecordsByIds = AccFactory.BudgetAppropriationsRepository().GetViewRecordsByFPPIdAndFundIdAndAllotmentClassIdAndDateEntry(fppID, sub_fpp, fundId, allotmentClassID, dateAsOf);

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
                    decimal supplementalAppropriation = AccFactory.SupplementalAppropriationsRepository().GetSumSupplementalAppropriationsBy_BudgetAppropriationsId_DateEntry(rowId, dateAsOf);

                    //GET TOTAL ALLOTMENT RELEASE
                    decimal allotments = AccFactory.AllotmentReleaseRepository().GetSumAllotments(rowId, dateAsOf);

                    decimal obligations = AccFactory.ObligationRequestRepository().GetSumObligationsByAppropriationId(rowId, dateAsOf);

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
            catch (Exception ex)
            {
                Helper.MessageBoxError(ex.Message);
            }

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

        internal static void SupplementalDatagridView(DataGridView dgv)
        {
            try
            {
                dgv.Rows.Clear();
                dgv.Columns.Clear();

                dgv.Columns.Add("date_entry", "Date Entry");
                dgv.Columns.Add("amount", "Amount");
                dgv.Columns.Add("remarks", "Remarks");
                dgv.Columns.Add("created_at", "Created at");
                dgv.Columns.Add("updated_at", "Updated at");

                dgv.Columns["created_at"].Visible = false;
                dgv.Columns["updated_at"].Visible = false;

                #region Format
                dgv.Columns["amount"].DefaultCellStyle.Format = "N2";
                dgv.Columns["date_entry"].DefaultCellStyle.Format = "MMM. dd, yyyy";
                #endregion

                dgv.ShowCellToolTips = false;
            }
            catch (Exception ex) { Helper.MessageBoxError(ex.Message); }
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

        internal static void ObligationRequestDatagridView(DataTable dataTable, DataGridView dataGridView)
        {
            try
            {
                dataGridView.DataSource = dataTable;
                dataGridView.Columns["id"].Visible = false;
                dataGridView.Columns["obligation_no"].HeaderText = "Obligation No.";
                dataGridView.Columns["date_requested"].HeaderText = "Date Requested";
                dataGridView.Columns["payee"].HeaderText = "Payee";
                dataGridView.Columns["explanation"].HeaderText = "Explanation";
                dataGridView.Columns["reference_no"].HeaderText = "Reference No.";
                dataGridView.Columns["total_obligations_amount"].HeaderText = "Total Obligations";
                dataGridView.Columns["status"].HeaderText = "Status";
                dataGridView.Columns["created_at"].Visible = false;
                dataGridView.Columns["created_by_id"].Visible = false;
                dataGridView.Columns["created_by_full_name"].HeaderText = "Created By";
                dataGridView.Columns["updated_at"].Visible = false;
                dataGridView.Columns["updated_by_id"].Visible = false;
                dataGridView.Columns["updated_by_full_name"].Visible = false;

                dataGridView.Columns["status"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

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
            datagrid.Columns.Add("jev_no", "JEV No.");
            datagrid.Columns.Add("full_jev_no", "JEV No.");
            datagrid.Columns.Add("date_entry", "Date Entry");
            datagrid.Columns.Add("funds_id", "Funds ID");
            datagrid.Columns.Add("fund_name", "Fund");
            datagrid.Columns.Add("journals_id", "Journals ID");
            datagrid.Columns.Add("journal_name", "Journal");
            datagrid.Columns.Add("ref_no", "Ref No.");
            datagrid.Columns.Add("payee", "Payee");
            datagrid.Columns.Add("explanation", "Explanation");
            datagrid.Columns.Add("created_at", "Created At");
            datagrid.Columns.Add("created_by_id", "Created By ID");
            datagrid.Columns.Add("created_by_name", "Created By");
            datagrid.Columns.Add("updated_at", "Updated At");
            datagrid.Columns.Add("updated_by_id", "Updated By ID");
            datagrid.Columns.Add("updated_by_name", "Updated By");
            datagrid.Columns.Add("status", "Status");


            #region Datagrid Column Formats

            datagrid.Columns["id"].Visible = false;
            datagrid.Columns["funds_id"].Visible = false;
            datagrid.Columns["journals_id"].Visible = false;
            datagrid.Columns["full_jev_no"].Width = 60;
            datagrid.Columns["full_jev_no"].MinimumWidth = 60;
            datagrid.Columns["full_jev_no"].Resizable = DataGridViewTriState.False;
            datagrid.Columns["ref_no"].Width = 60;
            datagrid.Columns["status"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            datagrid.Columns["status"].SortMode = DataGridViewColumnSortMode.Automatic;
            datagrid.Columns["status"].Width = 40;
            datagrid.Columns["status"].MinimumWidth = 40;
            datagrid.Columns["status"].Resizable = DataGridViewTriState.False;
            datagrid.Columns["created_by_name"].Width = 50;
            datagrid.Columns["payee"].Width = 100;
            datagrid.Columns["date_entry"].DefaultCellStyle.Format = "MMMM dd, yyyy";
            datagrid.Columns["date_entry"].Width = 60;
            datagrid.Columns["date_entry"].MinimumWidth = 60;
            datagrid.Columns["date_entry"].Resizable = DataGridViewTriState.False;
            datagrid.Columns["jev_no"].Visible = false;
            datagrid.Columns["created_at"].Visible = false;
            datagrid.Columns["updated_at"].Visible = false;
            datagrid.Columns["created_by_id"].Visible = false;
            datagrid.Columns["updated_by_id"].Visible = false;
            datagrid.Columns["updated_by_name"].Visible = false;
            datagrid.Columns["explanation"].Width = 100;
            datagrid.Columns["journal_name"].Width = 200;

            #endregion

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
