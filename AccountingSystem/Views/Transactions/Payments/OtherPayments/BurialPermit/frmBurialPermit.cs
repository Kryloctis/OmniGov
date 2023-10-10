using AccountingSystem.Views.Dialogs;
using AccountingSystem.Views.Manage.TaxPayers;
using System;
using System.Data;
using System.Text;
using System.Windows.Forms;

namespace AccountingSystem.Views.Transactions.Payments.OtherPayments.BurialPermit
{
    public partial class frmBurialPermit : Form
    {

        private readonly ucTaxPayers ucTaxPayers;
        private readonly ucPayment ucPayment;
        private dialogPayment dialog = new dialogPayment();
        private bool paymentComplete = false;
        private readonly ucOtherCharges ucOtherCharges;
        private readonly ucBurialPermit ucBurialPermit;
        private bool isNewPayee = false;

        public frmBurialPermit()
        {
            InitializeComponent();
            Helper.DatagridFullRowSelectStyle(dgPayees, true);
            ucTaxPayers = ucTaxPayers1;
            ucPayment = ucPayment1;
            ucBurialPermit = ucBurialPermit1;
            ucOtherCharges = ucOtherCharges1;
            ucOtherCharges.accountableForm = "58";
        }


        private void frmBurialPermit_Load(object sender, System.EventArgs e)
        {
            try
            {
                string searchText = txtSearch.Text;
                LoadPayees(searchText);
                ucTaxPayers.chckIsActive.Enabled = false;
            }
            catch (Exception ex) { Helper.MessageBoxError(ex.Message); }
        }

        private DataColumn[] PayeesColumns()
        {
            return new DataColumn[]
            {
                new DataColumn("taxpayers_id", typeof (int)),
                new DataColumn("taxpayer_type_code", typeof(string)),
                new DataColumn("taxpayers_tin", typeof(string)),
                new DataColumn("taxpayers_name", typeof(string)),
                new DataColumn("taxpayers_address", typeof(string)),
                new DataColumn("taxpayers_contact_info", typeof(string)),
            };
        }

        private DataTable DataTablePayees(string searchText)
        {
            var dtPayees = AccFactory.TaxpayersRepository().GetViewRecordsBySearch(searchText.Trim());
            var dataTable = new DataTable();
            dataTable.Columns.AddRange(PayeesColumns());

            int progressCount = 0;
            int totalProgressCount = dtPayees.Rows.Count;

            foreach (DataRow row in dtPayees.Rows)
            {
                var newRow = dataTable.NewRow();
                int taxpayerId = Convert.ToInt32(row["taxpayers_id"]);
                string taxpayerTin = row["taxpayers_tin"].ToString();
                string taxpayerName = row["taxpayers_name"].ToString();
                string taxpayerTypeCode = row["taxpayer_type"].ToString();
                string street = string.IsNullOrEmpty(row["taxpayers_street"].ToString()) ? string.Empty : $"{row["taxpayers_street"]},";
                string barangay = string.IsNullOrEmpty(row["taxpayers_barangay"].ToString()) ? string.Empty : $"{row["taxpayers_barangay"]},";
                string municipality = string.IsNullOrEmpty(row["taxpayers_municipality"].ToString()) ? string.Empty : $"{row["taxpayers_municipality"]},";
                string province = string.IsNullOrEmpty(row["taxpayers_province"].ToString()) ? string.Empty : $"{row["taxpayers_province"]},";
                string taxpayerAddress = $"{street} {barangay} {municipality} {province}";
                string taxpayerContactInfo = row["taxpayers_contact_info"].ToString();

                newRow["taxpayers_id"] = taxpayerId;
                newRow["taxpayer_type_code"] = taxpayerTypeCode;
                newRow["taxpayers_tin"] = taxpayerTin;
                newRow["taxpayers_name"] = taxpayerName;
                newRow["taxpayers_address"] = taxpayerAddress;
                newRow["taxpayers_contact_info"] = taxpayerContactInfo;

                progressCount++;
                Helper.ProgressCounter(bgwPayee, totalProgressCount, progressCount);

                dataTable.Rows.Add(newRow);
            }

            return dataTable;
        }

        private void LoadPayees(string searchText)
        {
            if (!bgwPayee.IsBusy)
            {
                bgwPayee.RunWorkerAsync(searchText);
            }
        }

        private void bgwPayee_DoWork(object sender, System.ComponentModel.DoWorkEventArgs e)
        {
            string searchText = e.Argument.ToString();
            var dataTable = DataTablePayees(searchText);

            Invoke((MethodInvoker)delegate
            {
                HelperLoadRecords.DatagridViewPayees(dgPayees, dataTable);
            });
        }

        private void bgwPayee_ProgressChanged(object sender, System.ComponentModel.ProgressChangedEventArgs e)
        {
            progressBar1.Value = e.ProgressPercentage;
        }

        private void bgwPayee_RunWorkerCompleted(object sender, System.ComponentModel.RunWorkerCompletedEventArgs e)
        {
            dgPayees.CurrentCell = dgPayees.FirstDisplayedCell;
        }

        private void ConfirmPayment()
        {
            try
            {
                if (!FormValidations())
                    return;

                if (!Helper.MessageBoxConfirmCancel("Are you sure to confirm the payment?"))
                    return;

                bgwSavingPayment.RunWorkerAsync();
                dialog.ShowDialog();
                dialog.Text = "Processing Payment...";
                dialog.label1.Text = "Processing Payment...";
            }
            catch (Exception ex)
            {
                var sb = new StringBuilder();
                sb.AppendLine("Transaction cancelled");
                sb.AppendLine(ex.Message);
                Helper.MessageBoxError(sb.ToString());
            }
        }

        private bool FormValidations()
        {
            var selectedTab = tabControlMain.SelectedTab;

            if (selectedTab == tabPagePayee)
            {
                if (isNewPayee)
                {
                    if (!ucTaxPayers.ValidateChildren())
                    {
                        Helper.MessageBoxError(ucTaxPayers.GetFormErrors());
                        return false;
                    }
                }
            }

            else if (selectedTab == tabPageFees)
            {
                if (!ucBurialPermit.ValidateChildren())
                {
                    Helper.MessageBoxError(ucBurialPermit.GetFormErrors());
                    return false;
                }
            }

            //else if (selectedTab == tabPagePayment)
            //{
            //    if (!ucPayment.ValidateChildren())
            //    {
            //        Helper.MessageBoxError(ucPayment.GetFormErrors());
            //        return false;
            //    }
            //}


            return true;
        }

        private void ChangeTabs()
        {
            var selectedTab = tabControlMain.SelectedTab;

            if (selectedTab == tabPagePayee)
                tabControlMain.SelectedTab = tabPageFees;
            else if (selectedTab == tabPageFees)
                tabControlMain.SelectedTab = tabPagePayment;
            else if (selectedTab == tabPagePayment)
                ConfirmPayment();
        }

        private void btnNextMain_Click(object sender, EventArgs e)
        {
            try
            {
                if (!FormValidations())
                    return;

                ChangeTabs();
            }
            catch (Exception ex) { Helper.MessageBoxError(ex.Message); }
        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            tabControlPayee.SelectedTab = tabNewPayee;
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            if (Helper.MessageBoxConfirmCancel("Your input won't be stored."))
            {
                tabControlPayee.SelectedTab = tabPayeeList;
                ucTaxPayers.ResetForm();
            }
        }

        private void btnBackMain_Click(object sender, EventArgs e)
        {
            try
            {
                if (tabControlMain.SelectedIndex < 0)
                    return;

                tabControlMain.SelectedIndex = tabControlMain.SelectedIndex - 1;
            }
            catch (Exception ex) { Helper.MessageBoxError(ex.Message); }
        }
    }
}
