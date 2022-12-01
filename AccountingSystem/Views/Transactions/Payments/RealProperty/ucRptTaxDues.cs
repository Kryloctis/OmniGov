using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AccountingSystem.Views.Transactions.Payments.RealProperty
{
    public partial class ucRptTaxDues : UserControl
    {
        internal int TaxpayersId;

        public ucRptTaxDues()
        {
            InitializeComponent();
        }

        private DataColumn[] DataColumnsPostedProperties() 
        {
            return new DataColumn[]
            {
                new DataColumn("is_selected", typeof(bool)),
                new DataColumn("id", typeof(int)),
                new DataColumn("real_taxpayers_id", typeof(int)),
                new DataColumn("complete_arp_no", typeof(string)),
                new DataColumn("property_pin", typeof(string)),
                new DataColumn("address", typeof(string)),
                new DataColumn("kind", typeof(string)),
            }; 
        }

        private DataTable DataTablePostedProperties() 
        {
            bool showCancelled = chckBxCancelled.Checked;
            var dtAssessmentPosts = AccFactory.RptAssessmentPostsRepository().GetRecordsByRealTaxpayersId(TaxpayersId, showCancelled);
            var dataTable = new DataTable();

            foreach (DataRow row in dtAssessmentPosts.Rows)
            {
                var newRow = dataTable.NewRow();

                newRow["is_selected"] = false;
                newRow["id"] = row["id"];
                newRow["real_taxpayers_id"] = row["real_taxpayers_id"];
                newRow["complete_arp_no"] = row["complete_arp_no"];
                newRow["property_pin"] = row["property_ping"];
                newRow["full_address"] = Helper.GenerateFullAddress(row["street"].ToString(),row["barangay"].ToString(), row["municipality"].ToString(), row["province"].ToString());
            }
        }

        internal void LoadPostedProperties() 
        {

            dgProperties.DataSource = dtAssessmentPosts;
        }

        private void OnLoad() 
        {
            Helper.DatagridFullRowSelectStyle(dgProperties, true, false);
            Helper.DatagridFullRowSelectStyle(dgTaxDues, true, false);
        }

        private void ucRptTaxDues_Load(object sender, EventArgs e)
        {
            try
            {
                OnLoad();
            }
            catch (Exception ex){Helper.MessageBoxError(ex.Message);}
        }
    }
}
