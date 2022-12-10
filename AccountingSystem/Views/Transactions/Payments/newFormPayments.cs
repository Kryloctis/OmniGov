using AccountingSystem.Views.Transactions.Payments.RealProperty;
using Microsoft.CodeAnalysis.VisualBasic.Syntax;
using SpreadsheetLight.Drawing;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AccountingSystem.Views.Transactions.Payments
{
    public partial class newFormPayments : Form
    {
        private ucRptTaxDues ucRptTaxDues;

        public newFormPayments()
        {
            InitializeComponent();
            Helper.LoadFormIcon(this);
            Helper.DatagridFullRowSelectStyle(dgTaxpayers, true);
            ucRptTaxDues = ucRptTaxDues1;
        }

        private DataColumn[] TaxpayersColumns()
        {
            return new DataColumn[]
            {
                new DataColumn("id", typeof(int)),
                new DataColumn("tin", typeof(string)),
                new DataColumn("name", typeof(string)),
                new DataColumn("full_address", typeof(string)),
                new DataColumn("contact_info", typeof(string))
            };
        }
        private DataTable DataTableTaxpayers() 
        {
            string searchText = txtTaxpayerSearch.Text.Trim();
            var dtTaxpayers = AccFactory.TaxpayersRepository().GetRecordsBySearch(searchText);
            var dataTable = new DataTable();
            dataTable.Columns.AddRange(TaxpayersColumns());

            foreach (DataRow row in dtTaxpayers.Rows)
            {
                var newRow = dataTable.NewRow();
                newRow["id"] = row["id"];
                newRow["tin"] = row["tin"];
                newRow["name"] = row["name"];
                newRow["full_address"] = Helper.GenerateFullAddress(row["street"].ToString(), row["barangay"].ToString(), row["municipality"].ToString(), row["province"].ToString());
                newRow["contact_info"] = row["contact_info"];
                dataTable.Rows.Add(newRow);
            }

            return dataTable;
        }

        private void LoadTaxpayers()
        {
            try
            {
                HelperLoadRecords.DataGridViewPaymentTaxpayers(dgTaxpayers, DataTableTaxpayers());
                dgTaxpayers.CurrentCell = dgTaxpayers.FirstDisplayedCell;
            }
            catch (Exception ex){Helper.MessageBoxError(ex.Message);}
        }

        private int GetRealTaxpayersId() 
        {
            int rowIndex = dgTaxpayers.CurrentRow.Index;
            return Convert.ToInt32(dgTaxpayers.Rows[rowIndex].Cells["id"].Value);
        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            if (tabControl1.SelectedTab == tabPageTaxpayer)
            {
                tabControl1.SelectedTab = tabPageTaxDues;
                ucRptTaxDues.taxpayersId = GetRealTaxpayersId();
                ucRptTaxDues.LoadPostedProperties();
            }
            else if (tabControl1.SelectedTab == tabPageTaxDues)
                tabControl1.SelectedTab = tabPagePayment;
            else if (tabControl1.SelectedTab == tabPagePayment)
                Helper.MessageBoxSuccess("Payment Confirmed");
        }

        private void newFormPayments_Load(object sender, EventArgs e)
        {
            LoadTaxpayers();
        }

        private void tabPageTaxpayer_Enter(object sender, EventArgs e)
        {
            btnNext.Text = "Next";
            radTaxpayer.Checked = true;
            EnableDisableButtons(btnBack);
        }

        private void tabPageTaxDues_Enter(object sender, EventArgs e)
        {
            btnNext.Text = "Proceed to Payment";
            radTaxDues.Checked = true;
            EnableDisableButtons(btnBack);
        }

        private void tabPagePayment_Enter(object sender, EventArgs e)
        {
            btnNext.Text = "Confirm Payment";
            radPayment.Checked = true;
            EnableDisableButtons(btnBack);
        }

        private void EnableDisableButtons(Button btnBack)
        {
            if (tabControl1.SelectedIndex < 1)
                btnBack.Enabled = false;
            else
                btnBack.Enabled = true;
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            if (tabControl1.SelectedIndex < 0)
                return;

            tabControl1.SelectedIndex = tabControl1.SelectedIndex - 1;
        }

        private void dataGridView1_SelectionChanged(object sender, EventArgs e)
        {
            if (dgTaxpayers.SelectedRows.Count == 1)
                btnNext.Enabled = true;
            else
                btnNext.Enabled = false;
        }

        private void radRpt_CheckedChanged(object sender, EventArgs e)
        {
            tabControl2.SelectedTab = tabPageRpt;
        }

        private void radBpl_CheckedChanged(object sender, EventArgs e)
        {
            tabControl2.SelectedTab = tabPageBpl;
        }

        private void radOthers_CheckedChanged(object sender, EventArgs e)
        {
            tabControl2.SelectedTab = tabPageOthers;
        }

        private void ucRptTaxDues1_Validating(object sender, CancelEventArgs e)
        {
            
        }

        private void txtTaxpayerSearch_TextChanged(object sender, EventArgs e)
        {
            LoadTaxpayers();
        }
    }
}