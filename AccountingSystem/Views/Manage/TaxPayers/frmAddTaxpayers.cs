using ACC.Domain.Models;
using System;
using System.Windows.Forms;

namespace AccountingSystem.Views.Manage.TaxPayers
{
    public partial class frmAddTaxpayers : Form
    {
        internal readonly ucTaxPayers uc;
        public frmAddTaxpayers()
        {
            InitializeComponent();
            Helper.LoadFormIcon(this);
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

            int barangaysId = Convert.ToInt32(uc.cmbxBarangay.SelectedValue);
            int taxpayerTypeId = Convert.ToInt32(uc.cmbxTaxPayerType.SelectedValue);
            string tin = uc.txtTIN.Text.Trim();
            string name = uc.txtName.Text.Trim();
            string street = uc.txtStreet.Text.Trim();
            string contactInfo = uc.txtContact.Text.Trim();
            bool isActive = uc.chckIsActive.Checked;

            var taxpayersModel = new TaxpayersModel()
            {
                BarangayId = barangaysId,
                TaxpayerTypeId = taxpayerTypeId,
                Street = street,
                Tin = tin,
                Name = name,
                ContactInfo = contactInfo,
                IsActive = isActive
            };

            var taxpayersRepo = AccFactory.TaxpayersRepository();
            return taxpayersRepo.Insert(taxpayersModel);

        }
    }
}
