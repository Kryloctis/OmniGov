using ACC.Data;
using ACC.Domain.Models;
using System;
using System.Windows.Forms;

namespace LFS.Views.Manage.BusinessCategories
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
            _ucBusinessCategories.isEdit = false;
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

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                if (SaveData())
                {
                    Helper.MessageBoxSuccess("Business category has been saved.");
                    _frmBusinessCategories.LoadBusinessCategories();
                    int lastInsertedId = AccFactory.BusinessCategoriesRepository().GetLastInsertedId();
                    Helper.DatagridViewRecordFinder(_frmBusinessCategories.dgBusinessCategories, "id", lastInsertedId.ToString());
                    _ucBusinessCategories.ResetForm();
                }
            }
            catch (Exception ex) { Helper.MessageBoxError(ex.Message); }
        }
    }
}