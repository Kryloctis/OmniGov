using ACC.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AccountingSystem.Views.Transactions.Payments.OtherPayments.CattleOwnership
{
    public partial class ucCattleOwnership : UserControl
    {
        internal int ownerID;

        public ucCattleOwnership()
        {
            InitializeComponent();
        }

        private void btnBrowse_Click(object sender, EventArgs e)
        {
        }

        internal void LoadTaxpayerInfo(int taxpayerID)
        {
            var dictTaxpayer = AccFactory.TaxpayersRepository().GetViewRecordById(taxpayerID);

            ownerID = taxpayerID;
            txtOwnerName.Text = dictTaxpayer["taxpayers_name"];
            cmbxProvince.Text = dictTaxpayer["taxpayers_province"];
            cmbxMunicipality.Text = dictTaxpayer["taxpayers_municipality"];
            cmbxBarangay.Text = dictTaxpayer["taxpayers_barangay"];
        }

        private void ucCattleOwnership_Load(object sender, EventArgs e)
        {
            if (!DesignMode)
            {
                HelperLoadRecords.SexComboBox(cmbxSex);
            }
        }
    }
}