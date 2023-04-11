using AccountingSystem.Views.Manage.TaxPayers;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AccountingSystem.Views.Manage.OtherPaymentRates
{
    public partial class frmOtherPaymentRates : Form
    {


        public frmOtherPaymentRates()
        {
            InitializeComponent();
            Helper.LoadFormIcon(this);
            Helper.DatagridFullRowSelectStyle(dgOtherPaymentRates, false);
        }

        private void toolStripButtonEdit_Click(object sender, EventArgs e)
        {
            int rowIndex = dgOtherPaymentRates.CurrentCell.RowIndex;
            int otherPaymentRatesID = Convert.ToInt32(dgOtherPaymentRates.Rows[rowIndex].Cells["id"].Value);

            _ = new frmEditOtherPaymentRates(this, otherPaymentRatesID).ShowDialog();
        }

        private void frmOtherPaymentRates_Load(object sender, EventArgs e)
        {
            LoadOtherPaymentRates();
        }

        internal void LoadOtherPaymentRates()
        {
            try
            {
                var dtOtherPaymentRates = new DataTable();
                dtOtherPaymentRates = AccFactory.OtherPaymentRatesRepository().GetRecords();
                HelperLoadRecords.OtherPaymentRatesDatagridView(dgOtherPaymentRates, dtOtherPaymentRates);

            }
            catch (Exception ex) { Helper.MessageBoxError(ex.Message); }
        }

        private void dgOtherPaymentRates_SelectionChanged(object sender, EventArgs e)
        {
            try
            {
                if (dgOtherPaymentRates.Columns.Count < 1)
                    return;

                byte createdByIndex = (byte)dgOtherPaymentRates.Columns["created_at"].Index;
                byte updatedByIndex = (byte)dgOtherPaymentRates.Columns["updated_at"].Index;

                var indexes = new byte[] { createdByIndex, updatedByIndex };
                Helper.EnableDisableToolStripButtons(dgOtherPaymentRates, btnEdit, btnDelete);
                Helper.ShowRecordTimestamp(dgOtherPaymentRates, indexes, toolStripStatusLabelCreatedAt, toolStripStatusLabelUpdatedAt);
            }
            catch (Exception ex)
            {
                Helper.MessageBoxError(ex.Message);
            }
        }

        private void btnAdd_Click_1(object sender, EventArgs e)
        {
            _ = new frmAddOtherPaymentRates(this).ShowDialog();
        }
    }
}
