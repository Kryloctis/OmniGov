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
            Helper.DatagridFullRowSelectStyle(dataGridView2, true, false);
            HelperLoadRecords.TaxPayerDues(dataGridView2);
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

        private void frmRptTaxDue_Load(object sender, EventArgs e)
        {
            LoadProperties();
        }


        #region Properties

        private void LoadProperties()
        {
            try
            {
                HelperLoadRecords.TaxPayerProperties(dataGridView1, DataTableProperties());
                Helper.CheckUncheckCheckBoxHeader(dataGridView1, "is_checked", chckBoxProperties);
                dataGridView2.Rows.Clear();
            }
            catch (Exception ex)
            {
                Helper.MessageBoxError(ex.Message);
            }
        }

        private void chckBxCancelled_CheckedChanged(object sender, EventArgs e)
        {
            LoadProperties();
        }

        private void chckBoxProperties_MouseClick(object sender, MouseEventArgs e)
        {
            if (chckBoxProperties.Checked)
                Helper.CheckUncheckCheckBoxRows(dataGridView1, "is_checked", true);
            else
                Helper.CheckUncheckCheckBoxRows(dataGridView1, "is_checked", false);
        }

        private void dataGridView1_CurrentCellDirtyStateChanged(object sender, EventArgs e)
        {
            if (dataGridView1.CurrentCell is DataGridViewCheckBoxCell)
                dataGridView1.CommitEdit(DataGridViewDataErrorContexts.Commit);
        }

        private void dataGridView1_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            Helper.CheckUncheckCheckBoxHeader(dataGridView1, "is_checked", chckBoxProperties);
            LoadTaxDues();
        }

        #endregion

        #region Tax Dues

        private void LoadTaxDues()
        {
            if (dataGridView1.Rows.Count < 1)
                return;

            dataGridView2.Rows.Clear();
            chckBxTaxDues.Checked = false;

            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                string arpNo = row.Cells["complete_arp_no"].Value.ToString();
                bool isChecked = Convert.ToBoolean(row.Cells["is_checked"].Value);

                if (isChecked)
                    GetTaxDues(arpNo);
            }
        }

        private void GetTaxDues(string completeArpNo)
        {
            var dtAssessmentPosting = AccFactory.AssessmentPostsRepository().GetRecordsByArpNo(completeArpNo);

            foreach (DataRow row in dtAssessmentPosting.Rows)
            {
                int year = Convert.ToDateTime(row["posted_at"]).Year;
                string arpNo = row["complete_arp_no"].ToString();
                decimal assessedValue = Convert.ToDecimal(row["assessed_value"]);
                dataGridView2.Rows.Add(false, year, arpNo, assessedValue, 0, 0, 0, 0);
            }
        }

        private void chckBxTaxDues_MouseClick(object sender, MouseEventArgs e)
        {
            if (chckBxTaxDues.Checked)
                Helper.CheckUncheckCheckBoxRows(dataGridView2, "is_checked", true);
            else
                Helper.CheckUncheckCheckBoxRows(dataGridView2, "is_checked", false);
        }

        private void dataGridView2_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            Helper.CheckUncheckCheckBoxHeader(dataGridView2, "is_checked", chckBxTaxDues);
        }

        private void dataGridView2_CurrentCellDirtyStateChanged(object sender, EventArgs e)
        {
            if (dataGridView2.CurrentCell is DataGridViewCheckBoxCell)
                dataGridView2.CommitEdit(DataGridViewDataErrorContexts.Commit);
        }

        private void dataGridView2_ColumnAdded(object sender, DataGridViewColumnEventArgs e)
        {
            if (e.Column.Name != "is_checked")
                e.Column.ReadOnly = true;
        }

        #endregion
    }
}
