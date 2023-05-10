using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AccountingSystem.Views.Transactions.Payments.OtherPayments.BurialPermit
{
    public partial class ucBurialPermit : UserControl
    {
        public ucBurialPermit()
        {
            InitializeComponent();
        }

        internal void LoadTaxpayerInfo(int taxpayerId)
        {
            var dictTaxpayer = AccFactory.TaxpayersRepository().GetViewRecordById(taxpayerId);

            txtTaxpayer.Text = dictTaxpayer["taxpayers_name"];
        }

        private void ucBurialPermit_Load(object sender, EventArgs e)
        {
            if (!DesignMode)
            {
                HelperLoadRecords.SexComboBox(cmbxRemainsSex);
            }
        }
    }
}
