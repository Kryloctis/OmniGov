using AccountingSystem.Views.Transactions.PaymentPosting;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
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
                new ("complete_arp_no", typeof(string)),
                new ("property_pin", typeof(string)),
                new ("barangay_name",typeof(string)),
                new ("property_kind",typeof(string)),
                new ("is_cancelled", typeof(Image))
            };
            dataTable.Columns.AddRange(dataColumns);

            foreach (DataRow dataRow in dtAssessmentPosting.Rows)
            {
                string rowCompleteArpNo = dataRow["complete_arp_no"].ToString();
                string rowPropertyPin = dataRow["property_pin"].ToString();
                string rowBarangayName = dataRow["barangay_name"].ToString();
                string rowPropertyKind = dataRow["property_kind"].ToString();
                bool rowIsCancelled = Convert.ToBoolean(dataRow["is_cancelled"]);
                Image rowIsCancelledImg = rowIsCancelled ? Properties.Resources.ok14px : null;

                dataTable.Rows.Add(false, rowCompleteArpNo, rowPropertyPin, rowBarangayName, rowPropertyKind, rowIsCancelledImg);
            }

            return dataTable;
        }

        private void LoadProperties() 
        {
            try
            {
                HelperLoadRecords.TaxPayerProperties(dataGridView1, DataTableProperties());
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
    }
}
