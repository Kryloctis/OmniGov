using System;
using System.Windows.Forms;

namespace AccountingSystem.Views.Transactions.Payments.OtherPayments.AF51_57
{
    public partial class ucAF51_57 : UserControl
    {
        internal int taxpayerID;

        public ucAF51_57()
        {
            InitializeComponent();
        }

        internal void LoadTaxpayerInfo(int taxpayerID)
        {
            var dictTaxpayer = AccFactory.TaxpayersRepository().GetViewRecordById(taxpayerID);

            txtTaxpayer.Text = dictTaxpayer["taxpayers_name"];
            txtType.Text = dictTaxpayer["taxpayer_type"];
            txtContact.Text = string.Empty;
        }

        private void ucAF51_57_Load(object sender, EventArgs e)
        {
            if (!DesignMode)
            {
            }
        }
    }
}