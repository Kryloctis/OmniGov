using ACC.Domain.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AccountingSystem.Views.Manage.TaxPayers
{
    public partial class frmAddTaxpayers : Form
    {
        internal readonly ucTaxPayers uc;
        public frmAddTaxpayers()
        {
            InitializeComponent();
            uc = ucTaxPayers1;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (SaveTaxpayer())
            {
                Helper.MessageBoxSuccess("Barangay has been saved.");
                uc.ResetForm();
            }
        }

        private bool SaveTaxpayer()
        {
            if (!uc.ValidateChildren())
            {
                Helper.MessageBoxError(uc.GetFormErrors());
                return false;
            }

            var barangaysId = Convert.ToInt32(uc.cmbxBarangay.SelectedValue);
            var taxpayerTypeId = Convert.ToInt32(uc.cmbxTaxPayerType.SelectedValue);
            var tin = uc.txtTIN.Text.Trim();
            var name = uc.txtName.Text.Trim();
            var contactInfo = uc.txtContact.Text.Trim();

            var taxpayersModel = new TaxpayersModel() { 
                BarangayId = barangaysId, 
                TaxpayerTypeId = taxpayerTypeId,
                Tin = tin,
                Name = name,
                ContactInfo = contactInfo
            };

            var taxpayersRepo = AccFactory.TaxpayersRepository();
            return taxpayersRepo.Insert(taxpayersModel);

        }
    }
}
