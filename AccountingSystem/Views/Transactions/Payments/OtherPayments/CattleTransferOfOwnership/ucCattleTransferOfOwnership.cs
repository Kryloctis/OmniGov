using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AccountingSystem.Views.Transactions.Payments.OtherPayments.CattleTransferOfOwnership
{
    public partial class ucCattleTransferOfOwnership : UserControl
    {
        internal int oldOwnerID;

        public ucCattleTransferOfOwnership()
        {
            InitializeComponent();
        }

        internal void LoadOldOwnerInfo(int taxpayerID)
        {
            var dictTaxpayer = AccFactory.TaxpayersRepository().GetViewRecordById(taxpayerID);

            txtCattleOldOwner.Text = dictTaxpayer["taxpayers_name"];
            oldOwnerID = Convert.ToInt32(dictTaxpayer["taxpayers_id"]);
        }

        private void ucCattleTransferOfOwnership_Load(object sender, EventArgs e)
        {
            if (!DesignMode)
            {
                LoadBarangays();
                LoadMunicipalities();
                LoadProvince();
            }
        }

        internal void LoadBarangays()
        {
            try
            {
                var dtBarangays = AccFactory.BarangayRepository().GetRecords();
                HelperLoadRecords.BarangaysCombobox(dtBarangays, cmbxBarangay, "name", null);
            }
            catch (Exception ex) { Helper.MessageBoxError(ex.Message); }
        }

        internal void LoadMunicipalities()
        {
            try
            {
                var dtMunicipalities = AccFactory.MunicipalitiesRepository().GetRecords();
                HelperLoadRecords.MunicipalitiesCombobox(dtMunicipalities, cmbxMunicipality, "name", null);
            }
            catch (Exception ex) { Helper.MessageBoxError(ex.Message); }
        }

        internal void LoadProvince()
        {
            try
            {
                var dtProvince = AccFactory.ProvincesRepository().GetRecords();
                HelperLoadRecords.ProvinceCombobox(dtProvince, cmbxProvince, "name", null);
            }
            catch (Exception ex) { Helper.MessageBoxError(ex.Message); }
        }

    }


}
