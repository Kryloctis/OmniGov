using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AccountingSystem.Views.Transactions.PropertyPayment
{
    public partial class ucPropertyTaxPayment : UserControl
    {
        public ucPropertyTaxPayment()
        {
            InitializeComponent();
        }

        private DataTable CollectorDataTable() 
        {
            if (chckBxJobOrders.Checked)
                return AccFactory.CollectingOfficerHasJobOrdersRepository().GetRecords();
            else
                return AccFactory.CollectingOfficerRepository().GetRecords();
        }

        internal void LoadCollectors() 
        {
            try
            {
                HelperLoadRecords.CollectingOfficerComboBox(CollectorDataTable(), cmbxCollectingOfficers, "fullname", "id");
            }
            catch (Exception ex)
            {
                Helper.MessageBoxError(ex.Message);
            }
        }

        private void ucPropertyTaxPayment_Load(object sender, EventArgs e)
        {
            if (!DesignMode)
            {
                LoadCollectors();
            }
        }

        private void chckBxJobOrders_CheckedChanged(object sender, EventArgs e)
        {
            LoadCollectors();
        }
    }
}
