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
        }

        private void frmEditTaxpayers_Load(object sender, EventArgs e)
        {
            LoadSelectedRecord();
        }

        private void LoadSelectedRecord()
        {
            var dictTaxpayer = AccFactory.TaxpayersRepository().GetRecordByID(_taxpayerId);

            uc.txtTIN.Text = dictTaxpayer["tin"];
            uc.txtName.Text = dictTaxpayer["name"];
            uc.txtStreet.Text = dictTaxpayer["street"];
            uc.cmbxTaxPayerType.SelectedValue = Convert.ToInt32(dictTaxpayer["taxpayer_type_id"]);
            uc.txtContact.Text = dictTaxpayer["contact_info"];
            uc.cmbxBarangay.SelectedValue = Convert.ToInt32(dictTaxpayer["barangays_id"]);
            uc.chckIsActive.Checked = Convert.ToBoolean(Convert.ToByte(dictTaxpayer["is_active"]));
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

            int barangaysId = Convert.ToInt32(uc.cmbxBarangay.SelectedValue);
            int taxpayerTypeId = Convert.ToInt32(uc.cmbxTaxPayerType.SelectedValue);
            string tin = uc.txtTIN.Text.Trim();
            string name = uc.txtName.Text.Trim();
            string street = uc.txtStreet.Text.Trim();
            string contactInfo = uc.txtContact.Text.Trim();
            bool isActive = uc.chckIsActive.Checked;

            var taxpayersModel = new TaxpayersModel()
            {
                Id = _taxpayerId,
                BarangayId = barangaysId,
                TaxpayerTypeId = taxpayerTypeId,
                Tin = tin,
                Name = name,
                Street = street,
                ContactInfo = contactInfo,
                IsActive = isActive
            };

            var taxpayersRepo = AccFactory.TaxpayersRepository();
            return taxpayersRepo.Update(taxpayersModel);
        }
    }
}
