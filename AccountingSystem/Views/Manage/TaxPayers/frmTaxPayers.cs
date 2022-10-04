using ACC.Domain.Models;
using AccountingSystem.Views.Manage.RptTaxRates;
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
    public partial class frmTaxPayers : Form
    {
        internal  ucTaxPayers uc;

        public frmTaxPayers()
        {
            InitializeComponent();
            uc = ucTaxPayers1;
            Helper.LoadFormIcon(this);
            Helper.DatagridFullRowSelectStyle(uc.dgProperties);
        }

        private void frmTaxPayers_Load(object sender, EventArgs e)
        {
            
        }

      
        private bool SaveTaxPayers()
        {
            if (!uc.ValidateChildren())
            {
                Helper.MessageBoxError(uc.GetFormErrors());
                return false;
            }

            var taxPayersModel = new TaxpayersModel()
            {
                Tin = uc.txtTIN.Text,
                Name = uc.txtName.Text,
                Type = uc.cmbxTaxPayerType.Text,
                ContactInfo = uc.txtContact.Text,
                Street = uc.txtStreet.Text,
                Barangay = uc.txtBarangay.Text,
                Municipality = uc.txtMunicipality.Text,
                Province = uc.txtMunicipality.Text
            };

            return AccFactory.TaxpayersRepository().Insert(taxPayersModel);
        }

        private void btnSave_Click_1(object sender, EventArgs e)
        {
            if (!uc.isEdit)
            {
                if (SaveTaxPayers())
                {
                    Helper.MessageBoxSuccess("Taxpayer Property has been saved.");
                    uc.ResetForm();
                }
            }

            else 
            {
                if (UpdateTaxpayer())
                {
                    Helper.MessageBoxSuccess("Taxpayer Property has been updated.");
                    uc.ResetForm();


                    btnSave.Text = "Save";
                    btnCancel.Enabled = false;
                }
            }  
        }

        private bool UpdateTaxpayer()
        {
            if (!uc.ValidateChildren()) 
            {
                Helper.MessageBoxError(uc.GetFormErrors());
                return false;
            }

            var taxPayersModel = new TaxpayersModel() 
            {
                Id = uc.taxPayerId,
                Tin = uc.txtTIN.Text,
                Name = uc.txtName.Text,
                Type = uc.cmbxTaxPayerType.Text,
                ContactInfo = uc.txtContact.Text,
                Street = uc.txtStreet.Text,
                Barangay = uc.txtBarangay.Text,
                Municipality = uc.txtMunicipality.Text,
                Province = uc.txtProvince.Text
            };

            return AccFactory.TaxpayersRepository().Update(taxPayersModel);
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            _ = new frmTaxPayersSearch(this).ShowDialog();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
        
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            uc.ResetForm();
            btnCancel.Enabled = false;
            btnSave.Text = "Save";
        }
    }
}
