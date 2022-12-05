using Org.BouncyCastle.Crypto.Agreement;
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

        private DataColumn[] DataColumnsTaxDues() 
        {
            return new DataColumn[]
            {
                new DataColumn("is_selected", typeof(bool)),
                new DataColumn("year", typeof(int)),
                new DataColumn("complete_arp_no", typeof(string)),
                new DataColumn("type", typeof(string)),
                new DataColumn("tax_due_amount", typeof(decimal)),
                new DataColumn("penalty_discount", typeof(decimal)),
                new DataColumn("total_payment", typeof(decimal))
            };
        }

        private DataTable DataTableTaxDues() 
        {
            var dataTable = new DataTable();
            dataTable.Columns.AddRange(DataColumnsTaxDues());
            return dataTable;
        }

        private void LoadTaxDues(DataGridView dataGridView, DataTable dataTable)
        {
            try
            {
                HelperLoadRecords.DatagridViewPaymentTaxpayerTaxDues(dataGridView, dataTable);
            }
            catch (Exception ex){Helper.MessageBoxError(ex.Message);}
        }

        private DataColumn[] DataColumnsPostedProperties() 
        {
            return new DataColumn[]
            {
                new DataColumn("is_selected", typeof(bool)),
                new DataColumn("id", typeof(int)),
                 new DataColumn("kind", typeof(string)),
                new DataColumn("real_taxpayers_id", typeof(int)),   
                new DataColumn("complete_arp_no", typeof(string)),
                new DataColumn("property_pin", typeof(string)),
                new DataColumn("full_address", typeof(string))             
            }; 
        }

        private DataTable DataTablePostedProperties() 
        {
            bool showCancelled = chckBxCancelled.Checked;
            var dtAssessmentPosts = AccFactory.RptAssessmentPostsRepository().GetRecordsByRealTaxpayersId(TaxpayersId, showCancelled);
            var dataTable = new DataTable();
            dataTable.Columns.AddRange(DataColumnsPostedProperties());

            foreach (DataRow row in dtAssessmentPosts.Rows)
            {
                var newRow = dataTable.NewRow();

                newRow["is_selected"] = false;
                newRow["id"] = row["id"];
                newRow["real_taxpayers_id"] = row["real_taxpayers_id"];
                newRow["complete_arp_no"] = row["complete_arp_no"];
                newRow["property_pin"] = row["property_pin"];
                newRow["full_address"] = Helper.GenerateFullAddress(row["street"].ToString(),row["barangay_name"].ToString(), row["municipality_name"].ToString(), row["province_name"].ToString());
                newRow["kind"] = row["property_kind"];
                dataTable.Rows.Add(newRow);
            }
            return dataTable;
        }

        internal void LoadPostedProperties() 
        {
            try
            {
                HelperLoadRecords.DatagridViewPaymentTaxpayerProperties(dgProperties, DataTablePostedProperties());
                chckBoxProperties.Checked = false;
            }
            catch (Exception ex){Helper.MessageBoxError(ex.Message);}
        }

        private void OnLoad() 
        {
            Helper.DatagridFullRowSelectStyle(dgProperties, false, false);
            Helper.DatagridFullRowSelectStyle(dgTaxDues, true, false);
            LoadTaxDues(dgTaxDues, DataTableTaxDues());
        }

        private void ucRptTaxDues_Load(object sender, EventArgs e)
        {
            try
            {
                OnLoad();
            }
            catch (Exception ex){Helper.MessageBoxError(ex.Message);}
        }

        private void chckBoxProperties_MouseClick(object sender, MouseEventArgs e)
        {
            try
            {
                bool isChecked = chckBoxProperties.Checked;
                Helper.CheckUncheckCheckBoxRows(dgProperties, "is_selected", isChecked);
            }
            catch (Exception ex){Helper.MessageBoxError(ex.Message);}
        }

        private void dgProperties_CurrentCellDirtyStateChanged(object sender, EventArgs e)
        {
            if (dgProperties.CurrentCell is DataGridViewCheckBoxCell)
                dgProperties.CommitEdit(DataGridViewDataErrorContexts.Commit);
        }

        private void dgProperties_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                Helper.CheckUncheckCheckBoxHeader(dgProperties, "is_selected", chckBoxProperties);

            }
            catch (Exception ex){Helper.MessageBoxError(ex.Message);}
        }

        private void dgProperties_ColumnAdded(object sender, DataGridViewColumnEventArgs e)
        {
            try
            {
                if (e.Column.Name != "is_selected")
                    e.Column.ReadOnly = true;
            }
            catch (Exception ex){Helper.MessageBoxError(ex.Message);}
        }

        private void chckBxCancelled_CheckedChanged(object sender, EventArgs e)
        {
            LoadPostedProperties();
        }
    }
}
