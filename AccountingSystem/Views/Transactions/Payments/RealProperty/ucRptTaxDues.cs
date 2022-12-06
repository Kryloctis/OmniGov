using AccountingSystem.Views.Shared;
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
        internal int taxpayersId;

        public ucRptTaxDues()
        {
            InitializeComponent();
        }

        private void OnLoad()
        {
            Helper.DatagridFullRowSelectStyle(dgProperties, false, false);
            Helper.DatagridFullRowSelectStyle(dgTaxDues, false, false);
        }

        private void ucRptTaxDues_Load(object sender, EventArgs e)
        {
            try
            {
                OnLoad();
            }
            catch (Exception ex) { Helper.MessageBoxError(ex.Message); }
        }


        //Properties DatagridView

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
            var dtAssessmentPosts = AccFactory.RptAssessmentPostsRepository().GetRecordsByRealTaxpayersId(taxpayersId, showCancelled);
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
                newRow["full_address"] = Helper.GenerateFullAddress(row["street"].ToString(), row["barangay_name"].ToString(), row["municipality_name"].ToString(), row["province_name"].ToString());
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
                LoadTaxDues(dgTaxDues);
            }
            catch (Exception ex) { Helper.MessageBoxError(ex.Message); }
        }
        private void chckBoxProperties_MouseClick(object sender, MouseEventArgs e)
        {
            try
            {
                bool isChecked = chckBoxProperties.Checked;
                Helper.CheckUncheckCheckBoxRows(dgProperties, "is_selected", isChecked);
            }
            catch (Exception ex) { Helper.MessageBoxError(ex.Message); }
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
                LoadTaxDues(dgTaxDues);
            }
            catch (Exception ex) { Helper.MessageBoxError(ex.Message); }
        }

        private void dgProperties_ColumnAdded(object sender, DataGridViewColumnEventArgs e)
        {
            try
            {
                if (e.Column.Name != "is_selected")
                    e.Column.ReadOnly = true;
            }
            catch (Exception ex) { Helper.MessageBoxError(ex.Message); }
        }

        private void chckBxCancelled_CheckedChanged(object sender, EventArgs e)
        {
            LoadPostedProperties();
        }



        //Tax Dues DatagridView
        private DataColumn[] DataColumnsTaxDues()
        {
            return new DataColumn[]
            {
                new DataColumn("is_selected", typeof(bool)),
                new DataColumn("year", typeof(int)),
                new DataColumn("complete_arp_no", typeof(string)),
                new DataColumn("type", typeof(string)),
                new DataColumn("tax_due_amount", typeof(string)),
                new DataColumn("penalty_discount", typeof(string)),
                new DataColumn("total_payment", typeof(string))
            };
        }

        private DataTable DataTableTaxDues(int taxPayersId, List<string> completeArpNoList)
        {
            var dataTable = new DataTable();
            dataTable.Columns.AddRange(DataColumnsTaxDues());

            foreach (string completeArpNo in completeArpNoList)
            {
                var dtAssessmentPosting = AccFactory.RptAssessmentPostsRepository().GetViewRptPropertyAssessmentsRecords_By_RealTaxpayersId_CompleteArpNo(taxPayersId, completeArpNo);
                foreach (DataRow row in dtAssessmentPosting.Rows)
                {
                    decimal assessedValue = Convert.ToDecimal(row["assessed_value"]);
                    decimal sefRate = Convert.ToDecimal(row["sef_rate"]);
                    decimal basicRate = Convert.ToDecimal(row["basic_rate"]);
                    string sefTaxDue = RealPropertyTaxComputations.GetSefTaxDue(sefRate, assessedValue).ToString("N2");
                    string basicTaxDue = RealPropertyTaxComputations.GetBasicTaxDue(basicRate, assessedValue).ToString("N2");

                    var newRow = dataTable.NewRow();
                    newRow["is_selected"] = false;
                    newRow["year"] = row["year"];
                    newRow["complete_arp_no"] = row["complete_arp_no"];
                    newRow["type"] = "BSC\nSEF";

                    newRow["tax_due_amount"] = $"{basicTaxDue}\n{sefTaxDue}";
                    newRow["penalty_discount"] = "0.00\n0.00";
                    newRow["total_payment"] = "0.00\n0.00";
                    dataTable.Rows.Add(newRow);
                }
            }
            return dataTable;
        }

        private void LoadTaxDues(DataGridView dataGridView)
        {
            try
            {
                List<string> completeArpNoList = new List<string>();

                foreach (DataGridViewRow row in dgProperties.Rows)
                {
                    if (Convert.ToBoolean(row.Cells["is_selected"].Value))
                        completeArpNoList.Add(row.Cells["complete_arp_no"].Value.ToString());
                }

                HelperLoadRecords.DatagridViewPaymentTaxpayerTaxDues(dataGridView, DataTableTaxDues(taxpayersId, completeArpNoList));
            }
            catch (Exception ex) { Helper.MessageBoxError(ex.Message); }
        }

        private void dgTaxDues_ColumnAdded(object sender, DataGridViewColumnEventArgs e)
        {
            if (e.Column.Name != "is_selected")
                e.Column.ReadOnly = true;
        }

        private void dgTaxDues_CurrentCellDirtyStateChanged(object sender, EventArgs e)
        {
            if (dgTaxDues.CurrentCell is DataGridViewCheckBoxCell)
                dgTaxDues.CommitEdit(DataGridViewDataErrorContexts.Commit);
        }

        private void dgTaxDues_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                Helper.CheckUncheckCheckBoxHeader(dgTaxDues, "is_selected", chckBxTaxDues);
            }
            catch (Exception ex) { Helper.MessageBoxError(ex.Message); }
        }

        private void chckBxTaxDues_MouseClick(object sender, MouseEventArgs e)
        {
            try
            {
                bool isChecked = chckBxTaxDues.Checked;
                Helper.CheckUncheckCheckBoxRows(dgTaxDues, "is_selected", isChecked);
            }
            catch (Exception ex) { Helper.MessageBoxError(ex.Message); }
        }
    }
}
