using AccountingSystem.Views.Transactions.PaymentPosting;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AccountingSystem.Views.Transactions.PaymentPostings.RPT_PaymentPosting
{
    public partial class frmRptTaxDue : Form
    {
        private readonly frmPaymentPosting _frmPaymentPosting;
        private readonly string _ownerName; 
        public frmRptTaxDue(string ownerName, frmPaymentPosting frmPaymentPosting)
        {
            InitializeComponent();
            _ownerName = ownerName;
            _frmPaymentPosting = frmPaymentPosting;
            Helper.LoadFormIcon(this);
            Helper.DatagridFullRowSelectStyle(dataGridView1, true);
        }

        private DataTable DataTableProperties() 
        {
            bool isCancelled = chckBxCancelled.Checked;
            var dtAssessmentPosting = AccFactory.AssessmentPostsRepository().GetRecordsByOwnerName_IsCancelled(_ownerName,isCancelled);
            var dataTable = new DataTable();

            var dataColumns= new DataColumn[]
            {
                new ("is_checked", typeof(bool)),
                new ("id", typeof(int)),
                new ("complete_arp_no", typeof(string)),
                new ("property_pin", typeof(string)),
                new ("barangay_name",typeof(string)),
                new ("property_kind",typeof(string)),
                new ("is_cancelled", typeof(Image))
            };
            dataTable.Columns.AddRange(dataColumns);

            foreach (DataRow dataRow in dtAssessmentPosting.Rows)
            {
                int rowId = Convert.ToInt32(dataRow["id"]);
                string rowCompleteArpNo = dataRow["complete_arp_no"].ToString();
                string rowPropertyPin = dataRow["property_pin"].ToString();
                string rowBarangayName = dataRow["barangay_name"].ToString();
                string rowPropertyKind = dataRow["property_kind"].ToString();
                bool rowIsCancelled = Convert.ToBoolean(dataRow["is_cancelled"]);
                Image rowIsCancelledImg = rowIsCancelled ? Properties.Resources.ok14px : null;

                dataTable.Rows.Add(false, rowId, rowCompleteArpNo, rowPropertyPin, rowBarangayName, rowPropertyKind, rowIsCancelledImg);
            }

            return dataTable;
        }

        private void LoadProperties() 
        {
            try
            {
                HelperLoadRecords.TaxPayerProperties(dataGridView1, DataTableProperties());
                CheckUncheckCheckBoxHeader(dataGridView1, "is_checked", chckBoxSelectAll);
            }
            catch (Exception ex)
            {
                Helper.MessageBoxError(ex.Message);
            }
        }

        private void frmRptTaxDue_Load(object sender, EventArgs e)
        {
            LoadProperties();
        }

        private void chckBxCancelled_CheckedChanged(object sender, EventArgs e)
        {
            LoadProperties();
        }

        private void CheckUncheckCheckBoxHeader(DataGridView dataGridView, string checkBoxColumnName, CheckBox checkBox) 
        {
            int totalRowCount = dataGridView.Rows.Count;
            int checkedRowCount = 0;

            foreach (DataGridViewRow row in dataGridView.Rows)
            {
                if (Convert.ToBoolean(row.Cells[checkBoxColumnName].Value) == true)
                    checkedRowCount += 1;
            }

            if (totalRowCount == checkedRowCount)
                checkBox.Checked = true;
            else
                checkBox.Checked = false;
        }

        private void CheckUncheckCheckBoxRows(DataGridView dataGridView, string checkBoxColumnName, bool isChecked)
        {
            foreach (DataGridViewRow row in dataGridView.Rows)
            {
                row.Cells[checkBoxColumnName].Value = isChecked;
            }
        }

        private void chckBoxSelectAll_CheckedChanged(object sender, EventArgs e)
        {
            
        }

        private void chckBoxSelectAll_MouseClick(object sender, MouseEventArgs e)
        {
            if (chckBoxSelectAll.Checked)
                CheckUncheckCheckBoxRows(dataGridView1, "is_checked", true);
            else
                CheckUncheckCheckBoxRows(dataGridView1, "is_checked", false);
        }

        private void dataGridView1_CurrentCellDirtyStateChanged(object sender, EventArgs e)
        {
            if (dataGridView1.CurrentCell is DataGridViewCheckBoxCell)
                dataGridView1.CommitEdit(DataGridViewDataErrorContexts.Commit);
        }

        private void dataGridView1_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            CheckUncheckCheckBoxHeader(dataGridView1, "is_checked", chckBoxSelectAll);
        }
    }
}
