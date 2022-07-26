using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static AccountingSystem.Views.Transactions.PaymentPosting.frmPaymentPosting;

namespace AccountingSystem.Views.Transactions.PaymentPosting
{
    public partial class frmTaxPayerList : Form
    {
        private readonly MainForm _mainForm;
        public frmTaxPayerList(MainForm mainForm)
        {
            InitializeComponent();
            _mainForm = mainForm;
            Helper.LoadFormIcon(this);
            Helper.DatagridFullRowSelectStyle(dataGridView1, true);
        }

        private DataTable DataTableAssessmentPost(string searchText) 
        {
            var columns = new string[] {"id", "owner_tin", "owner_name", "barangay_name", "municipality_name", "province_name", "owner_address"};
            var dtAssessmentPostin = AccFactory.AssessmentPostsRepository().GetRecordsBySearch(searchText);
            var dtView = new DataView(dtAssessmentPostin);
            return dtView.ToTable(false, columns);
        }

        private void LoadTaxpayerList() 
        {
            try
            {
                string searchText = txtSearch.Text.Trim();
                HelperLoadRecords.TaxPayerListDatagridView(dataGridView1, DataTableAssessmentPost(searchText));
            }
            catch (Exception ex)
            {
                Helper.MessageBoxError(ex.Message); 
            }
        }

        private void ShowPaymentPosting() 
        {
            if(dataGridView1.SelectedRows.Count == 1)
            {
                int rowIndex = dataGridView1.CurrentCell.RowIndex;
                string tin = dataGridView1.Rows[rowIndex].Cells["owner_tin"].Value.ToString();
                string taxPayerName = dataGridView1.Rows[rowIndex].Cells["owner_name"].Value.ToString();
                string address = dataGridView1.Rows[rowIndex].Cells["owner_address"].Value.ToString();
                string barangayName = dataGridView1.Rows[rowIndex].Cells["barangay_name"].Value.ToString();
                string municipalityName = dataGridView1.Rows[rowIndex].Cells["municipality_name"].Value.ToString();
                string provinceName = dataGridView1.Rows[rowIndex].Cells["province_name"].Value.ToString();

                var paymentPostingFields = new PaymentTaxPayerInfo()
                {
                    TIN = tin,
                    TaxPayerName = taxPayerName,
                    Address = address, 
                    BarangayName = barangayName, 
                    MunicipalityName = municipalityName, 
                    ProvinceName = provinceName
                };
                _ = new frmPaymentPosting(paymentPostingFields, this).ShowDialog();
            }
        }

        private void btnSelect_Click(object sender, EventArgs e)
        {
            ShowPaymentPosting();
        }

        private void frmTaxPayerList_Load(object sender, EventArgs e)
        {
            LoadTaxpayerList();
            EnableDisableSelectButton();
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            LoadTaxpayerList();
        }

        private void dataGridView1_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
                contextMenuStrip1.Show(Cursor.Position);
        }

        private void refreshToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LoadTaxpayerList();
        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex > -1)
            {
                ShowPaymentPosting();
            }
        }

        private void EnableDisableSelectButton() 
        {
            if (dataGridView1.SelectedRows.Count == 1)
            {
                btnSelect.Enabled = true;
                return;
            }
            btnSelect.Enabled = false;
        }

        private void dataGridView1_SelectionChanged(object sender, EventArgs e)
        {
            EnableDisableSelectButton();
        }
    }
}
