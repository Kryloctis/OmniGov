using ACC.Data;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace LFS
{
    public class HelperLoadRecords
    {
        public static Dictionary<int, string> SexDataSource()
        {
            var sex = new Dictionary<int, string>();
            sex.Add(1, "Male");
            sex.Add(2, "Female");

            return sex;
        }

        internal static void SexComboBox(ComboBox comboBox)
        {
            foreach (var item in SexDataSource().Values)
                comboBox.Items.Add(item);
            comboBox.SelectedIndex = 0;
        }

        internal static void BusinessAddOnChargesDataGridView(DataGridView datagrid, DataTable dataTable)
        {
            datagrid.Rows.Clear();
            datagrid.Columns.Clear();

            DataGridViewCheckBoxColumn dgvCheckBox = new DataGridViewCheckBoxColumn();
            dgvCheckBox.HeaderText = "Applied each business";
            dgvCheckBox.Name = "is_applied_each_business";

            datagrid.Columns.Add("id", "ID");
            datagrid.Columns.Add("code", "Code");
            datagrid.Columns.Add("description", "Description");
            datagrid.Columns.Add(dgvCheckBox);

            datagrid.Columns.Add("created_at", "Created At");
            datagrid.Columns.Add("created_by", "Created By");
            datagrid.Columns.Add("updated_at", "Updated At");
            datagrid.Columns.Add("updated_by", "Updated By");

            datagrid.Columns["created_at"].Visible = false;
            datagrid.Columns["created_by"].Visible = false;
            datagrid.Columns["updated_at"].Visible = false;
            datagrid.Columns["updated_by"].Visible = false;

            datagrid.Columns["id"].Visible = false;
            datagrid.Columns["is_applied_each_business"].AutoSizeMode = DataGridViewAutoSizeColumnMode.ColumnHeader;

            foreach (DataRow row in dataTable.Rows)
            {
                datagrid.Rows.Add(new object[]
                {
                    row["id"],
                    row["code"],
                    row["description"],
                    Convert.ToBoolean(row["is_applied_each_business"]),
                    row["created_at"],
                    row["created_by"],
                    row["updated_at"],
                    row["updated_by"]
                });
            }

            datagrid.ClearSelection();
        }

        public static void ActualUseCombobox(DataTable dataTable, ComboBox comboBox, string valueMember, string displayMember)
        {
            comboBox.DataSource = dataTable;
            comboBox.ValueMember = valueMember;
            comboBox.DisplayMember = displayMember;

            comboBox.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            comboBox.AutoCompleteSource = AutoCompleteSource.ListItems;
        }

        internal static void BusinessCategoriesDataGridView(DataGridView dataGridView, DataTable dataTable)
        {
            dataGridView.DataSource = dataTable;
            dataGridView.Columns["id"].Visible = false;
            dataGridView.Columns["code"].HeaderText = "Code";
            dataGridView.Columns["ordinance_ref_no"].HeaderText = "Ordinance ref no.";
            dataGridView.Columns["description"].HeaderText = "Description";
            dataGridView.Columns["is_line_of_business"].HeaderText = "Line of Business";
            dataGridView.Columns["created_at"].Visible = false;
            dataGridView.Columns["updated_at"].Visible = false;
        }

        internal static void BusinessCategorissAddOnsDatagridView(DataGridView dataGridView1, DataTable dataTable)
        {
            dataGridView1.DataSource = dataTable;
            dataGridView1.Columns["is_selected"].MinimumWidth = 20;
            dataGridView1.Columns["is_selected"].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
            dataGridView1.Columns["is_selected"].HeaderText = string.Empty;
            dataGridView1.Columns["id"].Visible = false;
            dataGridView1.Columns["code"].HeaderText = "Code";
            dataGridView1.Columns["description"].HeaderText = "Description";
        }

        public static void TaxpayerDatagridView(DataGridView dataGridView, DataTable dataTable)
        {
            dataGridView.DataSource = dataTable;

            dataGridView.Columns["taxpayers_id"].Visible = false;
            dataGridView.Columns["taxpayer_type"].HeaderText = "Type";
            dataGridView.Columns["taxpayer_type"].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
            dataGridView.Columns["taxpayer_type"].MinimumWidth = 30;
            dataGridView.Columns["taxpayers_tin"].HeaderText = "TIN";
            dataGridView.Columns["taxpayers_name"].HeaderText = "Name";
            dataGridView.Columns["taxpayers_address"].HeaderText = "Address";
            dataGridView.Columns["taxpayers_contact_info"].HeaderText = "Contact Info.";
            dataGridView.Columns["representative_name"].HeaderText = "Representative";
            dataGridView.Columns["is_active"].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
            dataGridView.Columns["is_active"].HeaderText = "Active";
            dataGridView.Columns["created_at"].Visible = false;
            dataGridView.Columns["updated_at"].Visible = false;
        }

        public static void DatagridViewPaymentTaxpayerTaxDues(DataGridView dataGridView, DataTable dataTable)
        {
            dataGridView.DataSource = dataTable;
            dataGridView.Columns["is_selected"].HeaderText = string.Empty;
            dataGridView.Columns["is_selected"].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
            dataGridView.Columns["is_selected"].MinimumWidth = 20;
            dataGridView.Columns["is_selected"].Frozen = true;
            dataGridView.Columns["status"].HeaderText = "Status";
            dataGridView.Columns["assessment_posts_id"].Visible = false;
            dataGridView.Columns["year"].HeaderText = "Year";
            dataGridView.Columns["year"].Frozen = true;
            dataGridView.Columns["year"].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
            dataGridView.Columns["complete_arp_no"].Frozen = true;
            dataGridView.Columns["complete_arp_no"].HeaderText = "ARP No.";
            dataGridView.Columns["type"].HeaderText = "Type";
            dataGridView.Columns["type"].MinimumWidth = 50;
            dataGridView.Columns["type"].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
            dataGridView.Columns["tax_due_amount"].HeaderText = "Tax Due";
            dataGridView.Columns["penalty_discount"].HeaderText = "Penalty/(Discount)";
            dataGridView.Columns["total_payment"].HeaderText = "Total Payment";
            dataGridView.Columns["total_payment_consolidated"].Visible = false;
            dataGridView.DefaultCellStyle.WrapMode = DataGridViewTriState.True;
            dataGridView.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.DisplayedCells;
        }

        public static void DatagridViewPaymentTaxpayerProperties(DataGridView dataGridView, DataTable dataTable)
        {
            dataGridView.DataSource = dataTable;
            dataGridView.Columns["is_selected"].Frozen = true;
            dataGridView.Columns["is_selected"].MinimumWidth = 20;
            dataGridView.Columns["is_selected"].HeaderText = string.Empty;
            dataGridView.Columns["is_selected"].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
            dataGridView.Columns["id"].Visible = false;
            dataGridView.Columns["real_taxpayers_id"].Visible = false;
            dataGridView.Columns["complete_arp_no"].HeaderText = "ARP No.";
            dataGridView.Columns["property_pin"].HeaderText = "PIN";
            dataGridView.Columns["full_address"].HeaderText = "Address";
            dataGridView.Columns["kind"].HeaderText = "Kind";
            dataGridView.Columns["kind"].AutoSizeMode = DataGridViewAutoSizeColumnMode.ColumnHeader;
            dataGridView.Columns["kind"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridView.Columns["kind"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridView.Columns["effectivity"].HeaderText = "Effectivity";
            dataGridView.Columns["assessed_value"].HeaderText = "Assessed Value";
            dataGridView.Columns["assessed_value"].DefaultCellStyle.Format = "N2";
        }

        public static void TaxRatesDatagridView(DataGridView dataGridView, DataTable dataTable)
        {
            dataGridView.DataSource = dataTable;

            dataGridView.Columns["id"].Visible = false;
            dataGridView.Columns["code"].HeaderText = "Code";
            dataGridView.Columns["description"].HeaderText = "Description";
            dataGridView.Columns["rate"].HeaderText = "Rate";
            dataGridView.Columns["rate"].DefaultCellStyle.Format = "P";
        }

        public static void PenaltiesDatagridView(DataGridView dataGridView, DataTable dataTable)
        {
            dataGridView.DataSource = dataTable;

            dataGridView.Columns["id"].Visible = false;
            dataGridView.Columns["description"].HeaderText = "Description";
            dataGridView.Columns["rate"].HeaderText = "Rate";
            dataGridView.Columns["rate"].DefaultCellStyle.Format = "P";
            dataGridView.Columns["frequency"].HeaderText = "Frequency";
        }

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

        internal static void BarangaysCombobox(DataTable dataTable, ComboBox comboBox, string displayMember, string valueMember)
        {
            comboBox.DataSource = dataTable;
            comboBox.DisplayMember = displayMember;
            comboBox.ValueMember = valueMember;
            comboBox.DropDownHeight = 200;
        }

        internal static void MunicipalitiesCombobox(DataTable dataTable, ComboBox comboBox, string displayMember, string valueMember)
        {
            comboBox.DataSource = dataTable;
            comboBox.DisplayMember = displayMember;
            comboBox.ValueMember = valueMember;
            comboBox.DropDownHeight = 200;
        }

        internal static void ProvinceCombobox(DataTable dataTable, ComboBox comboBox, string displayMember, string valueMember)
        {
            comboBox.DataSource = dataTable;
            comboBox.DisplayMember = displayMember;
            comboBox.ValueMember = valueMember;
            comboBox.DropDownHeight = 200;
        }

        internal static void RptAssessmentDatagridView(DataTable dataTable, DataGridView dataGridView)
        {
            dataGridView.DataSource = dataTable;
            dataGridView.Columns["is_checked"].MinimumWidth = 20;
            dataGridView.Columns["is_checked"].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
            dataGridView.Columns["is_checked"].HeaderText = string.Empty;
            dataGridView.Columns["pin"].Visible = false;
            dataGridView.Columns["posting_status"].HeaderText = "Status";
            dataGridView.Columns["posting_status"].MinimumWidth = 100;
            dataGridView.Columns["posting_status"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridView.Columns["posting_status"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridView.Columns["real_property_id"].Visible = false;
            dataGridView.Columns["taxpayers_id"].Visible = false;
            dataGridView.Columns["complete_arp_no"].HeaderText = "ARP No.";
            dataGridView.Columns["complete_arp_no"].MinimumWidth = 100;
            dataGridView.Columns["taxpayer_name"].HeaderText = "Owner Name";
            dataGridView.Columns["taxpayer_name"].MinimumWidth = 150;
            dataGridView.Columns["taxpayer_tin"].Visible = false;
            dataGridView.Columns["taxpayer_contact_info"].Visible = false;
            dataGridView.Columns["is_cancelled"].Visible = false;
            dataGridView.Columns["taxpayer_address"].Visible = false;
            dataGridView.Columns["property_kind"].HeaderText = "Kind";
            dataGridView.Columns["property_kind"].MinimumWidth = 40;
            dataGridView.Columns["property_kind"].Width = 40;
            dataGridView.Columns["property_kind"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridView.Columns["property_kind"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridView.Columns["property_location"].HeaderText = "Property location";
            dataGridView.Columns["property_location"].MinimumWidth = 150;
            dataGridView.Columns["effectivity"].HeaderText = "Effectivity";
            dataGridView.Columns["effectivity"].MinimumWidth = 150;
            dataGridView.Columns["assessed_value"].HeaderText = "AssessedValue";
            dataGridView.Columns["assessed_value"].MinimumWidth = 150;
            dataGridView.Columns["area"].Visible = false;
            dataGridView.Columns["classification_code"].Visible = false;
            dataGridView.Columns["classification_name"].Visible = false;
            dataGridView.Columns["actual_use_code"].Visible = false;
            dataGridView.Columns["actual_use_name"].Visible = false;
            dataGridView.Columns["gr_year"].Visible = false;
            dataGridView.Columns["lot_no"].Visible = false;
            dataGridView.Columns["other_improvements"].HeaderText = "Other Imp.";
            dataGridView.Columns["other_improvements"].MinimumWidth = 150;
            dataGridView.Columns["is_taxable"].HeaderText = "Taxable";
            dataGridView.Columns["is_taxable"].MinimumWidth = 20;
            dataGridView.Columns["is_taxable"].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
            dataGridView.Columns["penalty_rate"].Visible = false;
            dataGridView.Columns["penalty_frequency"].Visible = false;
            dataGridView.Columns["basic_rate"].Visible = false;
            dataGridView.Columns["sef_rate"].Visible = false;
            dataGridView.Columns["posted_at"].Visible = false;
            dataGridView.Columns["posted_by"].Visible = false;

            dataGridView.Columns["posting_status"].ReadOnly = true;
            dataGridView.Columns["real_property_id"].ReadOnly = true;
            dataGridView.Columns["pin"].ReadOnly = true;
            dataGridView.Columns["complete_arp_no"].ReadOnly = true;
            dataGridView.Columns["property_kind"].ReadOnly = true;
            dataGridView.Columns["taxpayers_id"].ReadOnly = true;
            dataGridView.Columns["taxpayer_name"].ReadOnly = true;
            dataGridView.Columns["taxpayer_tin"].ReadOnly = true;
            dataGridView.Columns["taxpayer_contact_info"].ReadOnly = true;
            dataGridView.Columns["taxpayer_address"].ReadOnly = true;
            dataGridView.Columns["property_location"].ReadOnly = true;
            dataGridView.Columns["effectivity"].ReadOnly = true;
            dataGridView.Columns["other_improvements"].ReadOnly = true;
            dataGridView.Columns["assessed_value"].ReadOnly = true;
            dataGridView.Columns["area"].ReadOnly = true;
            dataGridView.Columns["lot_no"].ReadOnly = true;
            dataGridView.Columns["classification_code"].ReadOnly = true;
            dataGridView.Columns["classification_name"].ReadOnly = true;
            dataGridView.Columns["actual_use_code"].ReadOnly = true;
            dataGridView.Columns["actual_use_name"].ReadOnly = true;
            dataGridView.Columns["gr_year"].ReadOnly = true;
            dataGridView.Columns["is_taxable"].ReadOnly = true;
            dataGridView.Columns["is_cancelled"].ReadOnly = true;
            dataGridView.Columns["penalty_rate"].ReadOnly = true;
            dataGridView.Columns["penalty_frequency"].ReadOnly = true;
            dataGridView.Columns["basic_rate"].ReadOnly = true;
            dataGridView.Columns["sef_rate"].ReadOnly = true;
            dataGridView.Columns["posted_at"].ReadOnly = true;
            dataGridView.Columns["posted_by"].ReadOnly = true;
        }

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

        internal static void SignatoriesDatagridView(DataTable dataTable, DataGridView dataGridView)
        {
            dataGridView.DataSource = dataTable;
            dataGridView.Columns["id"].Visible = false;
            dataGridView.Columns["name"].HeaderText = "Name";
            dataGridView.Columns["title"].HeaderText = "Title";
            dataGridView.Columns["created_at"].Visible = false;
            dataGridView.Columns["updated_at"].Visible = false;
        }

        internal static void YearComboBox(ComboBox comboBox)
        {
            _ = comboBox.Items.Add("2023");
            comboBox.SelectedIndex = 0;
        }

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

        internal static void DgvRoles(DataTable dataTable, DataGridView datagrid)
        {
            datagrid.DataSource = dataTable;
            datagrid.Columns["id"].Visible = false;
            datagrid.Columns["role_name"].HeaderText = "Role Name";
            datagrid.Columns["created_at"].Visible = false;
            datagrid.Columns["updated_at"].Visible = false;
            datagrid.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }

        internal static void RolesPermissionsDataGridView(DataTable dataTable, DataGridView dataGridView)
        {
            dataGridView.DataSource = dataTable;
            dataGridView.ColumnHeadersVisible = false;
            dataGridView.Columns["id"].Visible = false;
            dataGridView.Columns["permission_name"].HeaderText = "Permissions";
            dataGridView.Columns["permission_name"].ReadOnly = true;
            dataGridView.Columns["is_checked"].HeaderText = "";
            dataGridView.Columns["is_checked"].MinimumWidth = 30;
            dataGridView.Columns["is_checked"].Width = 30;
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

        internal static void SubsidiaryLedgerComboBox(DataTable dataTable, ComboBox comboBox, string displayMember, string valueMember)
        {
            comboBox.DisplayMember = displayMember;
            comboBox.ValueMember = valueMember;
            comboBox.DataSource = dataTable;
        }

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

        internal static void ReceiptsIssuedDatagridView(DataTable dataTable, DataGridView datagrid)
        {
            datagrid.DataSource = dataTable;

            datagrid.Columns["id"].Visible = false;
            datagrid.Columns["receipts"].HeaderText = "Receipt";
            datagrid.Columns["receipts"].Width = 450;
            datagrid.Columns["receipts"].MinimumWidth = 450;
            datagrid.Columns["serial_number_from"].HeaderText = "Serial Number From";
            datagrid.Columns["serial_number_from"].DefaultCellStyle.Format = "D7";
            datagrid.Columns["serial_number_from"].Width = 150;
            datagrid.Columns["serial_number_from"].MinimumWidth = 150;
            datagrid.Columns["serial_number_from"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            datagrid.Columns["serial_number_from"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            datagrid.Columns["serial_number_to"].HeaderText = "Serial Number To";
            datagrid.Columns["serial_number_to"].DefaultCellStyle.Format = "D7";
            datagrid.Columns["serial_number_to"].Width = 150;
            datagrid.Columns["serial_number_to"].MinimumWidth = 150;
            datagrid.Columns["serial_number_to"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            datagrid.Columns["serial_number_to"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            datagrid.Columns["quantity"].HeaderText = "Quantity";
            datagrid.Columns["quantity"].Width = 60;
            datagrid.Columns["quantity"].MinimumWidth = 60;
            datagrid.Columns["quantity"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleRight;
            datagrid.Columns["quantity"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            datagrid.Columns["date_issued"].HeaderText = "Date Issued";
            datagrid.Columns["date_issued"].DefaultCellStyle.Format = "yyyy-dd-MM";
            datagrid.Columns["date_issued"].Width = 80;
            datagrid.Columns["date_issued"].MinimumWidth = 80;
            datagrid.Columns["collecting_officer"].HeaderText = "Collecting Officer";
            datagrid.Columns["collecting_officer"].Width = 150;
            datagrid.Columns["collecting_officer"].MinimumWidth = 150;
            datagrid.Columns["issued_by"].HeaderText = "Issued By";
            datagrid.Columns["issued_by"].Width = 150;
            datagrid.Columns["issued_by"].MinimumWidth = 150;
        }

        internal static void ReturnedReceiptsDatagridView(DataTable dataTable, DataGridView datagrid)
        {
            datagrid.DataSource = dataTable;

            datagrid.Columns[0].HeaderText = "Receipt ID";
            datagrid.Columns[1].HeaderText = "Accountable Form ID";
            datagrid.Columns[2].HeaderText = "Accountable Form";
            datagrid.Columns[3].HeaderText = "Collecting Officer ID ";
            datagrid.Columns[4].HeaderText = "Collecting Officer";
            datagrid.Columns[5].HeaderText = "Date Issued";
            datagrid.Columns[6].HeaderText = "Receipt No. From";
            datagrid.Columns[7].HeaderText = "Receipt No. To";
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

        internal static void ReceiptsDatagridView(DataTable dataTable, DataGridView datagrid)
        {
            datagrid.DataSource = dataTable;
            datagrid.Columns["id"].Visible = false;

            datagrid.Columns["accountable_form_code"].Width = 80;
            datagrid.Columns["accountable_form_code"].MinimumWidth = 80;
            datagrid.Columns["accountable_form_code"].HeaderText = "Form";

            datagrid.Columns["receipt"].Width = 400;
            datagrid.Columns["receipt"].MinimumWidth = 400;
            datagrid.Columns["receipt"].HeaderText = "Receipt";

            datagrid.Columns["receipt_number"].HeaderText = "Receipt No. (Range)";
            datagrid.Columns["receipt_number"].MinimumWidth = 150;
            datagrid.Columns["receipt_number"].Width = 150;

            datagrid.Columns["received_date"].DefaultCellStyle.Format = "MMM dd, yyyy";
            datagrid.Columns["received_date"].HeaderText = "Date Received";
            datagrid.Columns["received_date"].Width = 150;
            datagrid.Columns["received_date"].MinimumWidth = 150;

            datagrid.Columns["quantity"].HeaderText = "Quantity";
            datagrid.Columns["quantity"].MinimumWidth = 80;
            datagrid.Columns["quantity"].Width = 80;

            datagrid.Columns["officer"].Width = 150;
            datagrid.Columns["officer"].MinimumWidth = 150;
            datagrid.Columns["officer"].HeaderText = "Issued By";
        }

        internal static void CashTicketsDatagridView(DataTable dataTable, DataGridView datagrid)
        {
            datagrid.DataSource = dataTable;
            datagrid.Columns["id"].Visible = false;
            datagrid.Columns["description"].HeaderText = "Description";
            datagrid.Columns["received_date"].DefaultCellStyle.Format = "MMM dd, yyyy";
            datagrid.Columns["received_date"].HeaderText = "Date Received";
            datagrid.Columns["received_date"].Width = 100;
            datagrid.Columns["received_date"].MinimumWidth = 100;
            datagrid.Columns["quantity"].HeaderText = "Quantity";
            datagrid.Columns["quantity"].MinimumWidth = 80;
            datagrid.Columns["quantity"].Width = 80;
            datagrid.Columns["remarks"].Width = 300;
            datagrid.Columns["remarks"].MinimumWidth = 300;
            datagrid.Columns["remarks"].HeaderText = "Remarks";
        }

        internal static void CashTicketIssuedDatagridView(DataTable dataTable, DataGridView datagrid)
        {
            datagrid.DataSource = dataTable;
            datagrid.Columns["id"].Visible = false;

            datagrid.Columns["cash_tickets_desc"].HeaderText = "Description";
            datagrid.Columns["cash_tickets_desc"].MinimumWidth = 80;

            datagrid.Columns["quantity"].HeaderText = "Quantity";
            datagrid.Columns["quantity"].MinimumWidth = 80;
            datagrid.Columns["quantity"].Width = 80;

            datagrid.Columns["date_issued"].DefaultCellStyle.Format = "MMM dd, yyyy";
            datagrid.Columns["date_issued"].HeaderText = "Date Received";
            datagrid.Columns["date_issued"].Width = 100;
            datagrid.Columns["date_issued"].MinimumWidth = 100;

            datagrid.Columns["collecting_officer"].Width = 300;
            datagrid.Columns["collecting_officer"].MinimumWidth = 300;
            datagrid.Columns["collecting_officer"].HeaderText = "Remarks";

            datagrid.Columns["issued_by"].Width = 300;
            datagrid.Columns["issued_by"].MinimumWidth = 300;
            datagrid.Columns["issued_by"].HeaderText = "Issued By";
        }

        internal static void ReceiptsCombobox(ComboBox combobox, DataTable dataTable)
        {
            combobox.DataSource = dataTable;
            combobox.ValueMember = "id";
            combobox.DisplayMember = "description";
            combobox.DropDownHeight = 106;
        }

        internal static void AccountableFormsCombobox(ComboBox combobox, DataTable dataTable, string valueMember, string displayMember)
        {
            combobox.DataSource = dataTable;
            combobox.ValueMember = valueMember;
            combobox.DisplayMember = displayMember;
        }

        internal static void FundsDatagridView(DataTable dataTable, DataGridView datagrid)
        {
            datagrid.DataSource = dataTable;
            datagrid.Columns["id"].Visible = false;
            datagrid.Columns["fund_code"].HeaderText = "Code";
            datagrid.Columns["fund_code"].AutoSizeMode = DataGridViewAutoSizeColumnMode.ColumnHeader;
            datagrid.Columns["fund_code"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            datagrid.Columns["fund_code"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            datagrid.Columns["fund_name"].HeaderText = "Name";
            datagrid.Columns["created_at"].Visible = false;
            datagrid.Columns["updated_at"].Visible = false;

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

        internal static void BankAccountsComboBox(DataTable dataTable, ComboBox comboBox, string valueMember, string displayMember)
        {
            comboBox.DataSource = dataTable;
            comboBox.ValueMember = valueMember;
            comboBox.DisplayMember = displayMember;
        }

        internal static void BanksDatagridView(DataTable dataTable, DataGridView datagrid)
        {
            datagrid.DataSource = dataTable;
            datagrid.Columns["id"].Visible = false;
            datagrid.Columns["created_at"].Visible = false;
            datagrid.Columns["updated_at"].Visible = false;
            datagrid.Columns["bank_code"].HeaderText = "Bank Code";
            datagrid.Columns["bank_code"].AutoSizeMode = DataGridViewAutoSizeColumnMode.ColumnHeader;
            datagrid.Columns["bank_name"].HeaderText = "Bank Name";
            datagrid.Columns["bank_branch"].HeaderText = "Branch";

            datagrid.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }

        internal static void DatagridViewBankAccounts(DataTable dataTable, DataGridView datagrid)
        {
            datagrid.DataSource = dataTable;
            datagrid.Columns["id"].Visible = false;
            datagrid.Columns["bank_name"].HeaderText = "Bank Name";
            datagrid.Columns["banks_id"].Visible = false;
            datagrid.Columns["account_no"].HeaderText = "Account No.";
            datagrid.Columns["bank_code"].Visible = false;
            datagrid.Columns["bank_branch"].Visible = false;
            datagrid.Columns["created_at"].Visible = false;
            datagrid.Columns["updated_at"].Visible = false;
        }

        internal static void BankComboBox(DataTable dataTable, ComboBox comboBox, string valueMember, string displayMember)
        {
            comboBox.DataSource = dataTable;
            comboBox.ValueMember = valueMember;
            comboBox.DisplayMember = displayMember;
        }

        internal static void FaceValueDatagridView(DataTable dataTable, DataGridView datagridView)
        {
            datagridView.DataSource = dataTable;

            datagridView.Columns["id"].Visible = false;
            datagridView.Columns["accountable_forms_id"].Visible = false;
            datagridView.Columns["date_effective"].DefaultCellStyle.Format = "MMM dd, yyyy";
            datagridView.Columns["amount"].HeaderText = "Amount";
            datagridView.Columns["amount"].DefaultCellStyle.Format = "N2";
            datagridView.Columns["amount"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            datagridView.Columns["date_effective"].HeaderText = "Date Effective";
            datagridView.Columns["date_effective"].SortMode = DataGridViewColumnSortMode.NotSortable;
            datagridView.Columns["amount"].SortMode = DataGridViewColumnSortMode.NotSortable;
            datagridView.Columns["is_default"].HeaderText = "Default";
            datagridView.Columns["is_default"].MinimumWidth = 10;
            datagridView.Columns["is_default"].AutoSizeMode = DataGridViewAutoSizeColumnMode.ColumnHeader;
        }

        internal static void DepositsDatagridView(DataTable dataTable, DataGridView datagridView)
        {
            datagridView.DataSource = dataTable;

            datagridView.Columns["id"].Visible = false;
            datagridView.Columns["created_by_id"].Visible = false;
            datagridView.Columns["created_by_name"].HeaderText = "Accountable Officer";
            datagridView.Columns["updated_by_id"].Visible = false;
            datagridView.Columns["updated_by_name"].Visible = false;
            datagridView.Columns["account_no"].HeaderText = "Account No.";
            datagridView.Columns["bank_name"].HeaderText = "Bank";
            datagridView.Columns["reference"].HeaderText = "Reference";
            datagridView.Columns["amount"].HeaderText = "Amount";
            datagridView.Columns["amount"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            datagridView.Columns["amount"].DefaultCellStyle.Format = "N2";
            datagridView.Columns["created_at"].Visible = false;
            datagridView.Columns["updated_at"].Visible = false;
        }

        internal static void RCIObligationDatagridview(DataTable dataTable, DataGridView datagrid)
        {
            datagrid.DataSource = dataTable;

            datagrid.Columns["obligation_no"].HeaderText = "Obligation No. ";
            datagrid.Columns["date_entry"].HeaderText = "Date Entry";
            datagrid.Columns["date_entry"].DefaultCellStyle.Format = "MMMM-dd-yyyy";

            datagrid.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }

        internal static void RCIDeductionsDatagridview(DataTable dataTable, DataGridView datagrid)
        {
            datagrid.DataSource = dataTable;

            datagrid.Columns["description"].HeaderText = "Description";
            datagrid.Columns["amount"].HeaderText = "Amount";

            datagrid.Columns["amount"].DefaultCellStyle.Format = "N2";
            datagrid.Columns["amount"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;

            datagrid.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }

        internal static void RCIDatagridView(DataTable dataTable, DataGridView datagrid)
        {
            datagrid.DataSource = dataTable;

            datagrid.Columns["id"].Visible = false;
            datagrid.Columns["cheques_id"].Visible = false;
            datagrid.Columns["bank_accounts_id"].Visible = false;
            datagrid.Columns["bank_id"].Visible = false;
            datagrid.Columns["fund_id"].Visible = false;
            datagrid.Columns["date_entry"].Visible = false;
            datagrid.Columns["fpp_id"].Visible = false;
            datagrid.Columns["created_at"].Visible = false;
            datagrid.Columns["updated_at"].Visible = false;
            datagrid.Columns["cheque_no"].HeaderText = "Check No.";
            datagrid.Columns["cheque_date"].HeaderText = "Check Date";
            datagrid.Columns["cheque_date"].DefaultCellStyle.Format = "MMMM-dd-yyyy";
            datagrid.Columns["amount"].HeaderText = "Amount";
            datagrid.Columns["bank_account_no"].HeaderText = "Bank Account No.";
            datagrid.Columns["bank_account_no"].MinimumWidth = 150;
            datagrid.Columns["bank_name"].HeaderText = "Bank Name";
            datagrid.Columns["fund"].HeaderText = "Fund";
            datagrid.Columns["fund"].MinimumWidth = 200;
            datagrid.Columns["dv_no"].HeaderText = "DV No.";
            datagrid.Columns["payee"].HeaderText = "Payee";
            datagrid.Columns["nature_of_payment"].HeaderText = "Nature of Payment";
            datagrid.Columns["nature_of_payment"].MinimumWidth = 200;
            datagrid.Columns["obligation_no"].HeaderText = "Obligation No.";
            datagrid.Columns["date_entry"].HeaderText = "Date Entry";
            datagrid.Columns["fpp"].HeaderText = "FPP";
            datagrid.Columns["fpp"].MinimumWidth = 300;
            datagrid.Columns["total_deductions"].HeaderText = "Total Deductions";
            datagrid.Columns["total_deductions"].MinimumWidth = 150;
            datagrid.Columns["total_deductions"].DefaultCellStyle.Format = "N2";
            datagrid.Columns["total_deductions"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            datagrid.Columns["amount"].DefaultCellStyle.Format = "N2";
            datagrid.Columns["amount"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
        }

        internal static void RCIReleasedAndUnreleasedDatagridView(DataTable dataTable, DataGridView datagrid)
        {
            datagrid.DataSource = dataTable;

            datagrid.Columns["rci_id"].Visible = false;
            datagrid.Columns["cheques_id"].Visible = false;
            datagrid.Columns["bank_accounts_id"].Visible = false;
            datagrid.Columns["funds_id"].Visible = false;

            datagrid.Columns["cheque_no"].HeaderText = "Check No.";
            datagrid.Columns["cheque_no"].MinimumWidth = 150;
            datagrid.Columns["cheque_amount"].DefaultCellStyle.Format = "N2";
            datagrid.Columns["cheque_amount"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            datagrid.Columns["cheque_amount"].MinimumWidth = 130;
            datagrid.Columns["cheque_date"].HeaderText = "Check date";
            datagrid.Columns["cheque_date"].MinimumWidth = 200;
            datagrid.Columns["cheque_amount"].HeaderText = "Amount";
            datagrid.Columns["fund_code"].HeaderText = "Fund Code";
            datagrid.Columns["fund_name"].HeaderText = "Fund Name";
            datagrid.Columns["dv_no"].HeaderText = "DV No.";
            datagrid.Columns["dv_no"].MinimumWidth = 200;
            datagrid.Columns["payee"].HeaderText = "Payee";
            datagrid.Columns["payee"].MinimumWidth = 200;
            datagrid.Columns["nature_of_payment"].HeaderText = "Nature of Payment";
            datagrid.Columns["nature_of_payment"].MinimumWidth = 200;
            datagrid.Columns["released_date"].HeaderText = "Released Date";
            datagrid.Columns["released_date"].MinimumWidth = 200;
            datagrid.Columns["status"].HeaderText = "Status";
            datagrid.Columns["status"].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;

            datagrid.Columns["cheque_date"].DefaultCellStyle.Format = "MMMM-dd-yyyy";
        }

        public static void RealPropertiesDatagridView(DataGridView datagridView, DataTable dataTable)
        {
            datagridView.DataSource = dataTable;

            datagridView.Columns["real_property_id"].Visible = false;
            datagridView.Columns["complete_arp_no"].HeaderText = "ARP No.";
            datagridView.Columns["complete_arp_no"].MinimumWidth = 100;
            datagridView.Columns["property_pin"].HeaderText = "PIN";
            datagridView.Columns["property_pin"].MinimumWidth = 100;
            datagridView.Columns["property_kind"].HeaderText = "Kind";
            datagridView.Columns["property_kind"].Width = 40;
            datagridView.Columns["property_kind"].MinimumWidth = 40;
            datagridView.Columns["property_kind"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            datagridView.Columns["property_kind"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            datagridView.Columns["property_kind"].HeaderText = "Kind";
            datagridView.Columns["property_location"].HeaderText = "Location";
            datagridView.Columns["property_location"].MinimumWidth = 100;
            datagridView.Columns["classification_code"].HeaderText = "Classification";
            datagridView.Columns["classification_code"].Width = 80;
            datagridView.Columns["classification_code"].MinimumWidth = 80;
            datagridView.Columns["classification_code"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            datagridView.Columns["classification_code"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            datagridView.Columns["actual_use_code"].HeaderText = "Actual Use";
            datagridView.Columns["actual_use_code"].Width = 70;
            datagridView.Columns["actual_use_code"].MinimumWidth = 70;
            datagridView.Columns["actual_use_code"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            datagridView.Columns["actual_use_code"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            datagridView.Columns["effectivity_quarter_and_year"].HeaderText = "Effectivity";
            datagridView.Columns["effectivity_quarter_and_year"].MinimumWidth = 100;
            datagridView.Columns["taxpayer_name"].HeaderText = "Taxpayer";
            datagridView.Columns["taxpayer_name"].MinimumWidth = 150;
            datagridView.Columns["representative_name"].HeaderText = "Representative";
            datagridView.Columns["representative_name"].MinimumWidth = 150;
            datagridView.Columns["other_improvements"].HeaderText = "Other Imp.";
            datagridView.Columns["other_improvements"].DefaultCellStyle.Format = "N2";
            datagridView.Columns["other_improvements"].MinimumWidth = 100;
            datagridView.Columns["assessed_value"].DefaultCellStyle.Format = "N2";
            datagridView.Columns["assessed_value"].MinimumWidth = 100;
            datagridView.Columns["assessed_value"].HeaderText = "Assessed Value";
            datagridView.Columns["is_taxable"].HeaderText = "Taxable";
            datagridView.Columns["is_taxable"].Width = 50;
            datagridView.Columns["is_taxable"].MinimumWidth = 50;
            datagridView.Columns["is_taxable"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            datagridView.Columns["is_taxable"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            datagridView.Columns["is_cancelled"].HeaderText = "Cancelled";
            datagridView.Columns["is_cancelled"].Width = 80;
            datagridView.Columns["is_cancelled"].MinimumWidth = 80;
            datagridView.Columns["is_cancelled"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            datagridView.Columns["is_cancelled"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            datagridView.Columns["real_property_created_at"].Visible = false;
            datagridView.Columns["real_property_updated_at"].Visible = false;
            datagridView.Columns["prev_assessments"].HeaderText = "Previous Assessments";
        }

        public static void RptPreviousDatagridView(DataGridView dataGridView, DataTable dataTable)
        {
            dataGridView.DataSource = dataTable;
            dataGridView.Columns["real_property_id"].Visible = false;
            dataGridView.Columns["complete_arp_no"].HeaderText = "ARP No.";
            dataGridView.Columns["taxpayers_id"].Visible = false;
            dataGridView.Columns["is_taxable"].Visible = false;
            dataGridView.Columns["is_cancelled"].Visible = false;
            dataGridView.Columns["taxpayer"].HeaderText = "Taxpayer";
            dataGridView.Columns["pin"].HeaderText = "Pin";
            dataGridView.Columns["assessed_value"].HeaderText = "Assessed Value";
            dataGridView.Columns["assessed_value"].DefaultCellStyle.Format = "N2";
            dataGridView.Columns["assessed_value"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleRight;
            dataGridView.Columns["date_of_entry"].HeaderText = "Date of Entry";
            dataGridView.Columns["date_of_entry"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleRight;
            dataGridView.Columns["date_of_entry"].DefaultCellStyle.Format = "MMM dd, yyyy";
            dataGridView.Columns["effectivity_quarter"].HeaderText = "Eff. Qtr";
            dataGridView.Columns["effectivity_quarter"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleRight;
            dataGridView.Columns["effectivity_year"].HeaderText = "Eff. Year";
            dataGridView.Columns["effectivity_year"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleRight;
            dataGridView.Columns["gr_year"].HeaderText = "GR Year";
            dataGridView.Columns["gr_year"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleRight;
            dataGridView.Columns["recording_person"].HeaderText = "Recording Person";
            dataGridView.Columns["taxpayer"].AutoSizeMode = DataGridViewAutoSizeColumnMode.ColumnHeader;
            dataGridView.Columns["pin"].AutoSizeMode = DataGridViewAutoSizeColumnMode.ColumnHeader;
            dataGridView.Columns["complete_arp_no"].AutoSizeMode = DataGridViewAutoSizeColumnMode.ColumnHeader;
            dataGridView.Columns["assessed_value"].AutoSizeMode = DataGridViewAutoSizeColumnMode.ColumnHeader;
            dataGridView.Columns["date_of_entry"].AutoSizeMode = DataGridViewAutoSizeColumnMode.ColumnHeader;
            dataGridView.Columns["effectivity_quarter"].AutoSizeMode = DataGridViewAutoSizeColumnMode.ColumnHeader;
            dataGridView.Columns["effectivity_year"].AutoSizeMode = DataGridViewAutoSizeColumnMode.ColumnHeader;
            dataGridView.Columns["gr_year"].AutoSizeMode = DataGridViewAutoSizeColumnMode.ColumnHeader;
            dataGridView.Columns["recording_person"].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;

            dataGridView.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }

        public static void ClassificationCombobox(DataTable dataTable, ComboBox comboBox, string valueMember, string displayMember)
        {
            comboBox.DataSource = dataTable;
            comboBox.ValueMember = valueMember;
            comboBox.DisplayMember = displayMember;

            comboBox.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            comboBox.AutoCompleteSource = AutoCompleteSource.ListItems;
        }

        internal static void AccFormDatagridView(DataTable dataTable, DataGridView datagrid)
        {
            datagrid.DataSource = dataTable;
            datagrid.Columns["id"].Visible = false;
            datagrid.Columns["form_code"].HeaderText = "Form Code";
            datagrid.Columns["form_description"].HeaderText = "Form Description";
            datagrid.Columns["form_face_value"].HeaderText = "Face Value";

            datagrid.Columns["form_code"].MinimumWidth = 90;
            datagrid.Columns["form_code"].Width = 90;

            datagrid.Columns["form_description"].MinimumWidth = 500;
            datagrid.Columns["form_description"].Width = 500;

            datagrid.Columns["form_face_value"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;

            datagrid.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }

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

        internal static void CollectingOfficerDatagridView(DataTable dataTable, DataGridView datagrid)
        {
            datagrid.DataSource = dataTable;
            datagrid.Columns["id"].Visible = false;
            datagrid.Columns["full_name"].HeaderText = "Name";
            datagrid.Columns["full_name"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            datagrid.Columns["job_title"].HeaderText = "Job Title";
            datagrid.Columns["job_title"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            datagrid.Columns["is_deleted"].Visible = false;
            datagrid.Columns["created_at"].Visible = false;
            datagrid.Columns["updated_at"].Visible = false;
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

            if (comboBox.Items.Count == 0)
                comboBox.DropDownHeight = 106;
        }

        internal static void JobOrdersDatagridView(DataTable dataTable, DataGridView datagrid)
        {
            datagrid.DataSource = dataTable;

            datagrid.Columns[0].Visible = false;
            datagrid.Columns[1].HeaderText = "Full Name";
            datagrid.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            datagrid.Columns[2].HeaderText = "Job Title";
            datagrid.Columns[2].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
        }

        internal static void DisbursingOfficerDatagridView(DataTable dataTable, DataGridView datagrid)
        {
            datagrid.DataSource = dataTable;
            datagrid.Columns["id"].Visible = false;
            datagrid.Columns["full_name"].HeaderText = "Full Name";
            datagrid.Columns["job_title"].HeaderText = "Job Title";
            datagrid.Columns["created_at"].Visible = false;
            datagrid.Columns["updated_at"].Visible = false;
            datagrid.Columns["users_id"].Visible = false;
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

        internal static void UsersDatagridView(DataTable dataTable, DataGridView dataGridView)
        {
            dataGridView.DataSource = dataTable;
            dataGridView.Columns["id"].Visible = false;
            dataGridView.Columns["full_name"].HeaderText = "Name";
            dataGridView.Columns["office_role"].HeaderText = "Office > Role";
            dataGridView.Columns["created_at"].Visible = false;
            dataGridView.Columns["updated_at"].Visible = false;
            dataGridView.Columns["is_active"].AutoSizeMode = DataGridViewAutoSizeColumnMode.ColumnHeader;
            dataGridView.Columns["is_active"].HeaderText = "Active";
        }

        internal static void UsersComboBox(DataTable dataTable, ComboBox comboBox, string valueMember, string displayMember)
        {
            comboBox.DataSource = dataTable;
            comboBox.DisplayMember = displayMember;
            comboBox.ValueMember = valueMember;
        }

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

        internal static void BudgetAppropriationsDatagridView(DataGridView dataGridView, DataTable dataTable)
        {
            dataGridView.DataSource = dataTable;

            //Column's Visibility
            dataGridView.Columns["id"].Visible = false;
            dataGridView.Columns["funds_id"].Visible = false;
            dataGridView.Columns["fpp_id"].Visible = false;
            dataGridView.Columns["year"].Visible = false;
            dataGridView.Columns["others_fpp_id"].Visible = false;
            dataGridView.Columns["allotment_class_id"].Visible = false;
            dataGridView.Columns["general_ledger_accounts_id"].Visible = false;
            dataGridView.Columns["date_entry"].Visible = false;
            dataGridView.Columns["created_at"].Visible = false;
            dataGridView.Columns["updated_at"].Visible = false;

            //Column's Format
            int amountColumWidth = 140;
            dataGridView.Columns["object_of_expenditures"].Width = 400;
            dataGridView.Columns["object_of_expenditures"].HeaderText = "Object of Expenditures";

            dataGridView.Columns["amount"].Resizable = DataGridViewTriState.False;
            dataGridView.Columns["amount"].Width = amountColumWidth;
            dataGridView.Columns["amount"].MinimumWidth = amountColumWidth;
            dataGridView.Columns["amount"].HeaderText = "Appropriation";
            dataGridView.Columns["amount"].DefaultCellStyle.Format = "N2";
            dataGridView.Columns["amount"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleRight;
            dataGridView.Columns["amount"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;

            dataGridView.Columns["allotment_released"].Resizable = DataGridViewTriState.False;
            dataGridView.Columns["allotment_released"].Width = amountColumWidth;
            dataGridView.Columns["allotment_released"].MinimumWidth = amountColumWidth;
            dataGridView.Columns["allotment_released"].DefaultCellStyle.Format = "N2";
            dataGridView.Columns["allotment_released"].HeaderText = "Allotment Released";
            dataGridView.Columns["allotment_released"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleRight;
            dataGridView.Columns["allotment_released"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;

            dataGridView.Columns["obligations"].Resizable = DataGridViewTriState.False;
            dataGridView.Columns["obligations"].Width = amountColumWidth;
            dataGridView.Columns["obligations"].MinimumWidth = amountColumWidth;
            dataGridView.Columns["obligations"].DefaultCellStyle.Format = "N2";
            dataGridView.Columns["obligations"].HeaderText = "Obligations";
            dataGridView.Columns["obligations"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleRight;
            dataGridView.Columns["obligations"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;

            dataGridView.Columns["unobligated_balance"].Resizable = DataGridViewTriState.False;
            dataGridView.Columns["unobligated_balance"].Width = amountColumWidth;
            dataGridView.Columns["unobligated_balance"].MinimumWidth = amountColumWidth;
            dataGridView.Columns["unobligated_balance"].DefaultCellStyle.Format = "N2";
            dataGridView.Columns["unobligated_balance"].HeaderText = "Unobligated Balance";
            dataGridView.Columns["unobligated_balance"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleRight;
            dataGridView.Columns["unobligated_balance"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;

            dataGridView.Columns["continuing"].Resizable = DataGridViewTriState.False;
            dataGridView.Columns["continuing"].DefaultCellStyle.NullValue = null;
            dataGridView.Columns["continuing"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridView.Columns["continuing"].Width = 80;
            dataGridView.Columns["continuing"].MinimumWidth = 80;

            dataGridView.Columns["realigned"].Resizable = DataGridViewTriState.False;
            dataGridView.Columns["realigned"].DefaultCellStyle.NullValue = null;
            dataGridView.Columns["realigned"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridView.Columns["realigned"].Width = 80;
            dataGridView.Columns["realigned"].MinimumWidth = 80;
        }

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

        internal static void DashboardDetailedDatagridView(DataGridView dgvBudgetAppropriations, string fppID, int allotmentClassID, int fundId, DateTime dateAsOf)
        {
            try
            {
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

                    decimal appropriationBalance = supplementalAppropriation + rowAppropriationAmount - obligations;

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

                        row.DefaultCellStyle.Font = new Font(Control.DefaultFont, FontStyle.Bold);
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

                dgv.Columns["amount"].DefaultCellStyle.Format = "N2";
                dgv.Columns["date_entry"].DefaultCellStyle.Format = "MMM. dd, yyyy";

                dgv.ShowCellToolTips = false;
            }
            catch (Exception ex) { Helper.MessageBoxError(ex.Message); }
        }

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

        internal static void JevDatagridView(DataGridView datagrid, DataTable dataTable)
        {
            datagrid.DataSource = dataTable;
            datagrid.Columns["id"].Visible = false;
            datagrid.Columns["funds_id"].Visible = false;
            datagrid.Columns["fund_name"].HeaderText = "Fund";
            datagrid.Columns["ref_no"].HeaderText = "Ref No.";
            datagrid.Columns["payee"].HeaderText = "Payee";
            datagrid.Columns["journals_id"].Visible = false;
            datagrid.Columns["full_jev_no"].MinimumWidth = 60;
            datagrid.Columns["full_jev_no"].HeaderText = "JEV No.";
            datagrid.Columns["full_jev_no"].Resizable = DataGridViewTriState.False;
            datagrid.Columns["status"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            datagrid.Columns["status"].SortMode = DataGridViewColumnSortMode.Automatic;
            datagrid.Columns["status"].MinimumWidth = 40;
            datagrid.Columns["status"].Resizable = DataGridViewTriState.False;
            datagrid.Columns["status"].HeaderText = "Status";
            datagrid.Columns["created_by_name"].Width = 50;
            datagrid.Columns["date_entry"].DefaultCellStyle.Format = "MMMM dd, yyyy";
            datagrid.Columns["date_entry"].MinimumWidth = 60;
            datagrid.Columns["date_entry"].Resizable = DataGridViewTriState.False;
            datagrid.Columns["date_entry"].HeaderText = "Date Entry";
            datagrid.Columns["jev_no"].Visible = false;
            datagrid.Columns["created_at"].Visible = false;
            datagrid.Columns["updated_at"].Visible = false;
            datagrid.Columns["created_by_id"].Visible = false;
            datagrid.Columns["created_by_name"].HeaderText = "Recording Person";
            datagrid.Columns["updated_by_id"].Visible = false;
            datagrid.Columns["updated_by_name"].Visible = false;
            datagrid.Columns["explanation"].MinimumWidth = 100;
            datagrid.Columns["explanation"].HeaderText = "Explanation";
            datagrid.Columns["journal_name"].MinimumWidth = 200;
            datagrid.Columns["journal_name"].HeaderText = "Journal";
        }

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

        internal static void BarangaysDatagridView(DataGridView dataGridView, DataTable dataTable)
        {
            dataGridView.DataSource = dataTable;

            dataGridView.Columns["id"].Visible = false;
            dataGridView.Columns["code"].HeaderText = "Code";
            dataGridView.Columns["name"].HeaderText = "Barangay";
            dataGridView.Columns["code"].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
        }

        internal static void DatagridViewPayees(DataGridView dataGridView, DataTable dataTable)
        {
            dataGridView.DataSource = dataTable;

            dataGridView.Columns["taxpayers_id"].Visible = false;
            dataGridView.Columns["taxpayer_type_code"].HeaderText = "Type";
            dataGridView.Columns["taxpayer_type_code"].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
            dataGridView.Columns["taxpayer_type_code"].MinimumWidth = 30;
            dataGridView.Columns["taxpayers_tin"].HeaderText = "TIN";
            dataGridView.Columns["taxpayers_name"].HeaderText = "Name";
            dataGridView.Columns["taxpayers_address"].HeaderText = "Address";
            dataGridView.Columns["taxpayers_contact_info"].HeaderText = "Contact Info.";
        }

        internal static void CattleDatagridView(DataGridView datagrid, DataTable dataTable)
        {
            datagrid.DataSource = dataTable;

            datagrid.Columns["id"].Visible = false;
            datagrid.Columns["cattle_type"].HeaderText = "Type";
            datagrid.Columns["cattle_sex"].HeaderText = "Sex";
            datagrid.Columns["cattle_age"].HeaderText = "Age";
            datagrid.Columns["description"].HeaderText = "Description";

            datagrid.RowHeadersVisible = false;
            datagrid.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            datagrid.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            datagrid.Columns["cattle_type"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            datagrid.Columns["cattle_type"].MinimumWidth = 100;
            datagrid.Columns["cattle_sex"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            datagrid.Columns["cattle_sex"].MinimumWidth = 80;
            datagrid.Columns["cattle_sex"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            datagrid.Columns["description"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            datagrid.Columns["description"].MinimumWidth = 150;
        }

        internal static void SearchableComboboxParameters(ComboBox comboBox, DataTable dataTable, string valueMember, string displayMember, List<string> searchSources, string searchText = "", bool isSearch = false)
        {
            DataView dataView = new DataView(dataTable);

            if (isSearch)
            {
                string filter = string.Join(" OR ", searchSources.Select(source => $"{source} Like '%{searchText}%'"));
                dataView.RowFilter = filter;
            }

            comboBox.ValueMember = valueMember;
            comboBox.DisplayMember = displayMember;
            comboBox.DataSource = dataView.ToTable();

            if (dataTable.Rows.Count < 1)
                return;

            if (isSearch)
            {
                comboBox.DroppedDown = false;
                comboBox.DroppedDown = true;
                Cursor.Current = Cursors.Default;
            }
            else
            {
                comboBox.DroppedDown = false;
                comboBox.SelectedIndex = -1;
            }
        }

        internal static void SearchableCombobox(ComboBox comboBox, DataTable dataTable, string valueMember, string displayMember, string searchSource = "", string searchText = "", bool isSearch = false)
        {
            DataView dataView = new DataView(dataTable);

            if (isSearch)
                dataView.RowFilter = $"{searchSource} Like '%{searchText}%'";

            comboBox.ValueMember = valueMember;
            comboBox.DisplayMember = displayMember;
            comboBox.DataSource = dataView.ToTable();

            if (dataTable.Rows.Count < 1)
                return;

            if (isSearch)
            {
                comboBox.DroppedDown = false;
                comboBox.DroppedDown = true;
                Cursor.Current = Cursors.Default;
            }
            else
            {
                comboBox.DroppedDown = false;
                comboBox.SelectedIndex = -1;
            }
        }

        public static void SearchableCombobox2(DataTable dataTable, ComboBox comboBox, string valueMember, string displayMember)
        {
            var filteredDtbl = dataTable.Clone();
            string searchKey = comboBox.Text.Trim();
            comboBox.DropDownHeight = 200;

            comboBox.DataSource = null;
            filteredDtbl.Rows.Clear();

            DataRow[] filteredRows = dataTable.Select($"{displayMember} LIKE '%{searchKey}%'");
            foreach (DataRow row in filteredRows)
                filteredDtbl.ImportRow(row);

            comboBox.ValueMember = valueMember;
            comboBox.DisplayMember = displayMember;

            if (filteredDtbl.Rows.Count < 1)
                comboBox.DataSource = dataTable;
            else
            {
                comboBox.DataSource = filteredDtbl;
            }
        }

        internal static void ComboboxRowLimitFilter(ComboBox comboBox)
        {
            DataTable dataTable = new DataTable();

            // Add columns to the DataTable using AddRange
            DataColumn[] columns =
            {
                new DataColumn("id", typeof(int)),
                new DataColumn("description", typeof(string))
            };

            dataTable.Columns.AddRange(columns);

            int[] values = { 50, 100, 200, 300 };

            foreach (int value in values)
            {
                var newRow = dataTable.NewRow();

                newRow["id"] = value;
                newRow["description"] = $"Limit to {value} rows";
                dataTable.Rows.Add(newRow);
            }

            comboBox.DataSource = dataTable;
            comboBox.ValueMember = "id";
            comboBox.DisplayMember = "description";
        }

        internal static void DataGridViewPaymentFeesCharges(DataTable dataTable, DataGridView dataGridView)
        {
            dataGridView.DataSource = dataTable;

            dataGridView.Columns["fees_charges_id"].Visible = false;
            dataGridView.Columns["classification"].HeaderText = "Classification";
            dataGridView.Columns["description"].HeaderText = "Description";
            dataGridView.Columns["is_rate_editable"].HeaderText = "Editable";
            dataGridView.Columns["is_rate_editable"].AutoSizeMode = DataGridViewAutoSizeColumnMode.ColumnHeader;
            dataGridView.Columns["amount"].HeaderText = "Amount";
            dataGridView.Columns["amount"].DefaultCellStyle.Format = "N2";
            dataGridView.Columns["unit"].HeaderText = "Unit";
            dataGridView.Columns["sub_total"].HeaderText = "Sub Total";
            dataGridView.Columns["sub_total"].DefaultCellStyle.Format = "N2";
            dataGridView.Columns["classification"].ReadOnly = true;
            dataGridView.Columns["description"].ReadOnly = true;
            dataGridView.Columns["sub_total"].ReadOnly = true;
            dataGridView.Columns["is_rate_editable"].ReadOnly = true;
        }

        internal static void DatagridViewRegistry(DataTable dataTable, DataGridView dataGridView)
        {
            dataGridView.DataSource = dataTable;

            dataGridView.Columns["id"].Visible = false;
            dataGridView.Columns["name"].HeaderText = "Name";
            dataGridView.Columns["sex"].HeaderText = "Sex";
            dataGridView.Columns["sex"].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
            dataGridView.Columns["nationality"].HeaderText = "Nationality";
            dataGridView.Columns["birth_date"].HeaderText = "Birth Date";
            dataGridView.Columns["birth_date"].DefaultCellStyle.Format = "MMM dd, yyyy";
            dataGridView.Columns["birth_place"].HeaderText = "Birthplace";
            dataGridView.Columns["contact_info"].HeaderText = "Contact Info.";
            dataGridView.Columns["created_at"].Visible = false;
            dataGridView.Columns["updated_at"].Visible = false;
        }

        internal static void DatagridViewPaymentCheques(DataTable dataTable, DataGridView dataGridView)
        {
            dataGridView.DataSource = dataTable;

            dataGridView.Columns["id"].Visible = false;
            dataGridView.Columns["id"].HeaderText = "Id";
            dataGridView.Columns["cheque_no"].HeaderText = "Cheque No.";
            dataGridView.Columns["cheque_date"].HeaderText = "Date";
            dataGridView.Columns["cheque_amount"].HeaderText = "Amount";
            dataGridView.Columns["bank_account_no"].HeaderText = "Bank Acc. No.";
            dataGridView.Columns["bank_branch"].HeaderText = "Bank Branch";
            dataGridView.Columns["bank_name"].HeaderText = "Bank Name";
        }

        internal static void DatagridViewPaymentHistory(DataTable dataTable, DataGridView datagridView)
        {
            datagridView.DataSource = dataTable;

            datagridView.Columns["id"].Visible = false;
            datagridView.Columns["receipt_no"].HeaderText = "Receipt No.";
            datagridView.Columns["payee"].HeaderText = "Payee";
            datagridView.Columns["payment_date"].HeaderText = "Payment Date";
            datagridView.Columns["amount"].HeaderText = "Amount";
            datagridView.Columns["is_cancelled"].HeaderText = "Void";

            datagridView.Columns["payee"].MinimumWidth = 200;
            datagridView.Columns["amount"].DefaultCellStyle.Format = "N2";
            datagridView.Columns["payment_date"].DefaultCellStyle.Format = "MMM dd, yyyy";
            datagridView.Columns["is_cancelled"].AutoSizeMode = DataGridViewAutoSizeColumnMode.ColumnHeader;
        }

        internal static void RptDelinquenciesDatagridView(DataTable dataTable, DataGridView dataGridView)
        {
            dataGridView.DataSource = dataTable;
            dataGridView.Columns["id"].Visible = false;
            dataGridView.Columns["rpt_assessment_posts_id"].Visible = false;

            dataGridView.Columns["complete_arp_no"].HeaderText = "Complete Arp No.";
            dataGridView.Columns["complete_arp_no"].MinimumWidth = 120;
            dataGridView.Columns["complete_arp_no"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridView.Columns["complete_arp_no"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;

            dataGridView.Columns["taxpayer_name"].HeaderText = "Tax Payer";
            dataGridView.Columns["taxpayer_name"].MinimumWidth = 200;
            dataGridView.Columns["taxpayer_name"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridView.Columns["taxpayer_name"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;

            dataGridView.Columns["property_kind"].HeaderText = "Property Kind";
            dataGridView.Columns["property_kind"].MinimumWidth = 80;
            dataGridView.Columns["property_kind"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridView.Columns["property_kind"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;

            dataGridView.Columns["property_pin"].HeaderText = "Property Pin";
            dataGridView.Columns["property_pin"].MinimumWidth = 80;
            dataGridView.Columns["property_pin"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridView.Columns["property_pin"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;

            dataGridView.Columns["tax_due"].HeaderText = "Tax Due";
            dataGridView.Columns["tax_due"].MinimumWidth = 100;
            dataGridView.Columns["tax_due"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dataGridView.Columns["tax_due"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridView.Columns["tax_due"].DefaultCellStyle.Format = "N2";

            dataGridView.Columns["delinquency_status"].HeaderText = "Delinquency Status";
            dataGridView.Columns["delinquency_status"].MinimumWidth = 200;
            dataGridView.Columns["delinquency_status"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridView.Columns["delinquency_status"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;

            dataGridView.Columns["created_at"].HeaderText = "Date";
            dataGridView.Columns["created_at"].MinimumWidth = 100;
            dataGridView.Columns["created_at"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridView.Columns["created_at"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridView.Columns["created_at"].DefaultCellStyle.Format = "MM-dd-yyyy";

            dataGridView.Columns["created_at"].Visible = true;
            dataGridView.Columns["created_by"].Visible = false;
            dataGridView.Columns["updated_at"].Visible = false;
            dataGridView.Columns["updated_by"].Visible = false;

            dataGridView.Columns["complete_arp_no"].ReadOnly = false;
            dataGridView.Columns["taxpayer_name"].ReadOnly = false;
            dataGridView.Columns["property_kind"].ReadOnly = false;
            dataGridView.Columns["delinquency_status"].ReadOnly = false;
        }

        internal static void DgvRcd(DataGridView dataGridView, DataTable dataTable)
        {
            dataGridView.DataSource = dataTable;
            dataGridView.Columns["id"].Visible = false;
            dataGridView.Columns["report_no"].HeaderText = "Report No.";
            dataGridView.Columns["date"].HeaderText = "Date";
            dataGridView.Columns["date"].DefaultCellStyle.Format = "MMM dd, yyyy";
            dataGridView.Columns["created_by_name"].HeaderText = "Accountable Officer";
            dataGridView.Columns["created_at"].Visible = false;
            dataGridView.Columns["created_by_id"].Visible = false;
        }

        internal static void DgvRcdCollections(DataGridView dataGridView, DataTable dataTable)
        {
            dataGridView.DataSource = dataTable;
            dataGridView.ShowCellToolTips = false;
            dataGridView.Columns["acc_form_id"].Visible = false;
            dataGridView.Columns["acc_form"].HeaderText = "Form";
            dataGridView.Columns["receipt_no"].HeaderText = "Receipt No. (From > To)";
            dataGridView.Columns["receipt_no"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridView.Columns["receipt_no"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridView.Columns["total_amount"].HeaderText = "Total Amount";
            dataGridView.Columns["total_amount"].DefaultCellStyle.Format = "N2";
            dataGridView.Columns["total_amount"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dataGridView.Columns["total_amount"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleRight;
        }

        internal static void DgvRcdDeposits(DataGridView dataGridView, DataTable dataTable)
        {
            dataGridView.DataSource = dataTable;
            dataGridView.Columns["id"].Visible = false;
            dataGridView.Columns["account_no"].HeaderText = "Account No.";
            dataGridView.Columns["bank_name"].HeaderText = "Accountable Officer/Bank";
            dataGridView.Columns["bank_name"].MinimumWidth = 200;
            dataGridView.Columns["reference"].HeaderText = "Reference";
            dataGridView.Columns["amount"].HeaderText = "Amount";
            dataGridView.Columns["amount"].DefaultCellStyle.Format = "N2";
            dataGridView.Columns["amount"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dataGridView.Columns["amount"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleRight;
        }

        internal static void DgvRptDelinquencyNotices(DataGridView dataGridView, DataTable dataTable)
        {
            dataGridView.DataSource = dataTable;
            dataGridView.Columns["delinquent_notice_id"].Visible = false;
            dataGridView.Columns["notice_type"].HeaderText = "Notice Type";
            dataGridView.Columns["notice_date"].HeaderText = "Notice Date";
            dataGridView.Columns["notice_date"].DefaultCellStyle.Format = "MMM dd, yyyy";
            dataGridView.Columns["complete_arp_no"].HeaderText = "ARP No.";
            dataGridView.Columns["taxpayers_name"].HeaderText = "Taxpayer Name";
            dataGridView.Columns["created_at"].Visible = false;
            dataGridView.Columns["created_by"].HeaderText = "Created By";
            dataGridView.Columns["updated_at"].Visible = false;
            dataGridView.Columns["updated_by"].Visible = false;
        }

        internal static void DgvWarrantLevy(DataGridView dataGridView, DataTable dataTable)
        {
            dataGridView.DataSource = dataTable;
            dataGridView.Columns["rpt_levy_id"].Visible = false;
            dataGridView.Columns["complete_arp_no"].HeaderText = "ARP No.";
            dataGridView.Columns["property_kind"].HeaderText = "Property Kind";
            dataGridView.Columns["property_kind"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridView.Columns["property_kind"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridView.Columns["date_issued"].HeaderText = "Date Issued";
            dataGridView.Columns["date_issued"].DefaultCellStyle.Format = "MMM dd, yyyy";
            dataGridView.Columns["taxpayers_name"].HeaderText = "Taxpayer";
            dataGridView.Columns["created_at"].Visible = false;
            dataGridView.Columns["created_by"].HeaderText = "Created By";
            dataGridView.Columns["updated_at"].Visible = false;
            dataGridView.Columns["updated_by"].Visible = false;
        }

        internal static void DgAuction(DataGridView dataGridView, DataTable dataTable)
        {
            dataGridView.DataSource = dataTable;
            dataGridView.Columns["id"].Visible = false;
            dataGridView.Columns["start_date"].HeaderText = "Start Date";
            dataGridView.Columns["start_date"].DefaultCellStyle.Format = "MMM dd, yyyy";
            dataGridView.Columns["end_date"].HeaderText = "End Date";
            dataGridView.Columns["end_date"].DefaultCellStyle.Format = "MMM dd, yyyy";
            dataGridView.Columns["location"].HeaderText = "Location";
            dataGridView.Columns["created_at"].Visible = false;
        }

        internal static void DgRptAuction(DataGridView dataGridView, DataTable dataTable)
        {
            dataGridView.DataSource = dataTable;
            dataGridView.Columns["rpt_auction_id"].Visible = false;
            dataGridView.Columns["real_properties_id"].Visible = false;
            dataGridView.Columns["auction_id"].Visible = false;
            dataGridView.Columns["taxpayers_id"].Visible = false;
            dataGridView.Columns["start_date"].HeaderText = "Start Date";
            dataGridView.Columns["start_date"].DefaultCellStyle.Format = "MMM dd, yyyy";
            dataGridView.Columns["end_date"].HeaderText = "End Date";
            dataGridView.Columns["end_date"].DefaultCellStyle.Format = "MMM dd, yyyy";
            dataGridView.Columns["location"].HeaderText = "Location";
            dataGridView.Columns["street"].HeaderText = "Street";
            dataGridView.Columns["complete_arp_no"].HeaderText = "Complete ARP No.";
        }

        internal static void AuctionScheduleCombobox(DataTable dataTable, ComboBox comboBox, string displayMember, string valueMember)
        {
            comboBox.ValueMember = valueMember;
            comboBox.DisplayMember = displayMember;
            comboBox.DataSource = dataTable;
        }

        internal static void BiddersCombobox(DataTable dataTable, ComboBox comboBox, string displayMember, string valueMember)
        {
            comboBox.ValueMember = valueMember;
            comboBox.DisplayMember = displayMember;
            comboBox.DataSource = dataTable;
        }

        internal static void DgBidders(DataGridView dataGridView, DataTable dataTable)
        {
            dataGridView.DataSource = dataTable;
            dataGridView.Columns["id"].Visible = false;
            dataGridView.Columns["taxpayers_id"].Visible = false;
            dataGridView.Columns["auction_id"].Visible = false;
            dataGridView.Columns["name"].HeaderText = "Bidder";
            dataGridView.Columns["bidder_no"].HeaderText = "Bidder No.";
            dataGridView.Columns["ordinance_no"].HeaderText = "Ordinance No.";
            dataGridView.Columns["date"].HeaderText = "Date";
            dataGridView.Columns["date"].DefaultCellStyle.Format = "MMM dd, yyyy";
            dataGridView.Columns["bid_amount"].HeaderText = "Bid Amount";
            dataGridView.Columns["bid_amount"].DefaultCellStyle.Format = "N2";
            dataGridView.Columns["bid_amount"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dataGridView.Columns["bid_amount"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleRight;
        }
    }
}