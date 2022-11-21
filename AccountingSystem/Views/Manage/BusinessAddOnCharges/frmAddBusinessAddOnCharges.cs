using ACC.Domain.Models;
using AccountingSystem.Views.Manage.BusinessCategories;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AccountingSystem.Views.Manage.BusinessAdOnCharges
{
    public partial class frmAddBusinessAddOnCharges : Form
    {
        private readonly frmBusinessAddOnCharges _frmBusinessAdOnCharges;
        private readonly ucBusinessAddOnCharges _ucBusinessAdOnCharges;


        public frmAddBusinessAddOnCharges(frmBusinessAddOnCharges frmBusinessAdOnCharges)
        {
            InitializeComponent();
            _frmBusinessAdOnCharges = frmBusinessAdOnCharges;
            _ucBusinessAdOnCharges = ucBusinessAdOnCharges1;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (SaveData())
            {
                Helper.MessageBoxSuccess("Business Add-on has been saved.");
                _frmBusinessAdOnCharges.LoadBusinessAddOnCharges();
                _ucBusinessAdOnCharges.ResetForm();
            }
        }

        private bool SaveData()
        {
            if (!_ucBusinessAdOnCharges.ValidateChildren())
            {
                Helper.MessageBoxError(_ucBusinessAdOnCharges.GetFormErrors());
                return false;
            }

            var code = _ucBusinessAdOnCharges.txtCode.Text.Trim();
            var description = _ucBusinessAdOnCharges.txtDescription.Text.Trim();
            var appliedEachBusiness = _ucBusinessAdOnCharges.cbxAppliedToEachBusiness.Checked;

            var businessAdOnChargesModel = new BusinessAddOnChargesModel()
            {
                Code = code,
                Description = description,
                IsAppliedEachBusiness = appliedEachBusiness, 
                CreatedBy = Helper.UserId
            };

            return AccFactory.BusinessAddOnChargesRepository().Insert(businessAdOnChargesModel);
        }




    }
}
