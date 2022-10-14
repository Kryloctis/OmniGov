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
    public partial class frmEditTaxpayers : Form
    {
        internal readonly ucTaxPayers uc;
        private int _taxpayerId;
        private frmTaxpayers _frmTaxpayers;

        
        public frmEditTaxpayers(int taxpayerId, frmTaxpayers frmTaxpayers)
        {
            InitializeComponent();
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
            uc.cmbxTaxPayerType.SelectedValue = Convert.ToInt32(dictTaxpayer["taxpayer_type_id"]);
            uc.txtContact.Text = dictTaxpayer["contact_info"];
            uc.cmbxBarangay.SelectedValue = Convert.ToInt32(dictTaxpayer["barangays_id"]);
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (UpdateTaxpayer())
            {
                Helper.MessageBoxSuccess("Taxpayer has been updated.");
                _frmTaxpayers.LoadTaxpayer();
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

            var barangaysId = Convert.ToInt32(uc.cmbxBarangay.SelectedValue);
            var taxpayerTypeId = Convert.ToInt32(uc.cmbxTaxPayerType.SelectedValue);
            var tin = uc.txtTIN.Text.Trim();
            var name = uc.txtName.Text.Trim();
            var contactInfo = uc.txtContact.Text.Trim();

            var taxpayersModel = new TaxpayersModel()
            {
                Id = _taxpayerId,
                BarangayId = barangaysId,
                TaxpayerTypeId = taxpayerTypeId,
                Tin = tin,
                Name = name,
                ContactInfo = contactInfo
            };

            var taxpayersRepo = AccFactory.TaxpayersRepository();
            return taxpayersRepo.Update(taxpayersModel);
        }
    }
}
