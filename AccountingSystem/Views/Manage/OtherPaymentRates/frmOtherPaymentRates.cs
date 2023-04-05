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

        private void toolStripButtonNew_Click(object sender, EventArgs e)
        {
            _ = new frmAddOtherPaymentRates().ShowDialog();
        }

        private void toolStripButtonEdit_Click(object sender, EventArgs e)
        {
            _ = new frmEditOtherPaymentRates().ShowDialog();
        }

        private void frmOtherPaymentRates_Load(object sender, EventArgs e)
        {
            LoadOtherPaymentRates();
        }

        private void LoadOtherPaymentRates()
        {
            try
            {
                var dtOtherPaymentRates = new DataTable();
                dtOtherPaymentRates = AccFactory.OtherPaymentRatesRepository().GetRecords();
                HelperLoadRecords.OtherPaymentRatesDatagridView(dgOtherPaymentRates, dtOtherPaymentRates);

            }
            catch (Exception ex) { Helper.MessageBoxError(ex.Message); }
        }
    }
}
