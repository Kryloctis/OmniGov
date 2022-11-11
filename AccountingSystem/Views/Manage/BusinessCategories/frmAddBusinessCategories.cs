using ACC.Domain.Models;
using AccountingSystem.Views.Manage.Barangay;
using DocumentFormat.OpenXml.Wordprocessing;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AccountingSystem.Views.Manage.BusinessCategories
{
    public partial class frmAddBusinessCategories : Form
    {
        private readonly frmBusinessCategories _frmBusinessCategories;
        private readonly ucBusinessCategories _ucBusinessCategories;

        public frmAddBusinessCategories(frmBusinessCategories frmBusinessCategories)
        {
            InitializeComponent();
            _frmBusinessCategories = frmBusinessCategories;
            _ucBusinessCategories = ucBusinessCategories1;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (SaveData())
            {
                Helper.MessageBoxSuccess("Business category has been saved.");
                _frmBusinessCategories.LoadBusinessCategories();
                _ucBusinessCategories.ResetForm();
            }
        }

        private bool SaveData()
        {
            if (!_ucBusinessCategories.ValidateChildren())
            {
                Helper.MessageBoxError(_ucBusinessCategories.GetFormErrors());
                return false;
            }

            var code = _ucBusinessCategories.txtCode.Text.Trim();
            var ordinanceReferenceNo = _ucBusinessCategories.txtOrdinanceReferenceNo.Text.Trim();
            var description = _ucBusinessCategories.txtDescription.Text.Trim();
            var lineInBusiness = _ucBusinessCategories.cbxLineOfBusiness.Checked;

            var businessCategoriesModel = new BusinessCategoriesModel()
            {
                Code = code,
                OrdinanceReferenceNumber = ordinanceReferenceNo,
                Description = description,
                LineOfBusiness = lineInBusiness
            };

            return AccFactory.BusinessCategoriesRepository().Insert(businessCategoriesModel);
        }
    }
}
