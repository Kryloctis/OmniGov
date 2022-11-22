using ACC.Domain.Models;
using System;
using System.Windows.Forms;

namespace AccountingSystem.Views.Manage.TaxPayers
{
    public partial class frmEditTaxpayers : Form
    {
        internal readonly ucTaxPayers uc;
        private int _taxpayerId;
        private frmTaxpayers _frmTaxpayers;

        public frmEditTaxpayers(int taxpayerId, frmTaxpayers frmTaxpayers)
        {
            InitializeComponent();
            Helper.LoadFormIcon(this);
            _taxpayerId = taxpayerId;
            _frmTaxpayers = frmTaxpayers;
            uc = ucTaxPayers1;
            uc.isEdit = true;
        }

        private void frmEditTaxpayers_Load(object sender, EventArgs e)
        {
            LoadSelectedRecord();
        }

        private void LoadSelectedRecord()
        {
            try
            {
                var dictTaxpayer = AccFactory.TaxpayersRepository().GetRecordByID(_taxpayerId);

                uc.txtTIN.Text = dictTaxpayer["tin"];
                uc.txtName.Text = dictTaxpayer["name"];
                uc.txtStreet.Text = dictTaxpayer["street"];
                uc.txtBarangay.Text = dictTaxpayer["barangay"];
                uc.txtMunicipality.Text = dictTaxpayer["municipality"];
                uc.txtProvince.Text = dictTaxpayer["province"];
                uc.cmbxTaxPayerType.SelectedValue = Convert.ToInt32(dictTaxpayer["taxpayer_type_id"]);
                uc.txtContact.Text = dictTaxpayer["contact_info"];
                uc.chckIsActive.Checked = Convert.ToBoolean(Convert.ToByte(dictTaxpayer["is_active"]));
            }
            catch (Exception ex)
            {
                Helper.MessageBoxError(ex.Message);
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (UpdateTaxpayer())
            {
                Helper.MessageBoxSuccess("Taxpayer has been updated.");
                _frmTaxpayers.LoadTaxpayers();
                Close();
            }
        }

        private bool UpdateTaxpayer()
        {
            if (!uc.ValidateChildren())
            {
                Helper.MessageBoxError(uc.GetFormErrors());
                return false;
            }

            int taxpayerTypeId = Convert.ToInt32(uc.cmbxTaxPayerType.SelectedValue);
            string tin = uc.txtTIN.Text.Trim();
            string name = uc.txtName.Text.Trim();
            string street = uc.txtStreet.Text.Trim();
            string barangay = uc.txtBarangay.Text.Trim();
            string municipality = uc.txtMunicipality.Text.Trim();
            string province = uc.txtProvince.Text.Trim();
            string contactInfo = uc.txtContact.Text.Trim();
            bool isActive = uc.chckIsActive.Checked;

            var taxpayersModel = new TaxpayersModel()
            {
                Id = _taxpayerId,
                TaxpayerTypeId = taxpayerTypeId,
                Tin = tin,
                Name = name,
                Street = street,
                Barangay = barangay,
                Municipality = municipality,
                Province = province,
                ContactInfo = contactInfo,
                IsActive = isActive,
                UpdatedBy = Helper.UserId
            };

            var taxpayersRepo = AccFactory.TaxpayersRepository();
            return taxpayersRepo.Update(taxpayersModel);
        }
    }
}
