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
    public partial class ucOtherPaymentRates : UserControl
    {
        public ucOtherPaymentRates()
        {
            InitializeComponent();
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void ucOtherPaymentRates_Load(object sender, EventArgs e)
        {
            if (!DesignMode)
            {
                LoadTaxTypes();
            }
        }

        private void LoadTaxTypes()
        {
            try
            {
                DataTable dtTaxTypes = AccFactory.TaxTypesRepository().GetRecords();
                cmbxTaxType.DataSource = dtTaxTypes;
                cmbxTaxType.ValueMember = "id";
                cmbxTaxType.DisplayMember = "code";
                cmbxTaxType.SelectedIndex = -1;
            }
            catch (Exception ex) { Helper.MessageBoxError(ex.Message); }
        }
    }
}
