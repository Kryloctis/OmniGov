using ACC.Domain.Models;
using AccountingSystem.Views.Manage.Barangay;
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
    public partial class frmEditBusinessCategories : Form
    {
        private int _businessCategoriesID;
        private readonly frmBusinessCategories _frmBusinessCategories;
        private readonly ucBusinessCategories _ucBusinessCategories;

        public frmEditBusinessCategories(int businessCategoriesID, frmBusinessCategories frmBusinessCategories)
        {
            InitializeComponent();
            _ucBusinessCategories = ucBusinessCategories1;
            _businessCategoriesID = businessCategoriesID;
            _frmBusinessCategories = frmBusinessCategories;
            _ucBusinessCategories.businessCategoryID = businessCategoriesID;
            _ucBusinessCategories.isEdit = true;
        }

        private void frmEditBusinessCategories_Load(object sender, EventArgs e)
        {
            LoadSelectedRecord();
        }

        private void LoadSelectedRecord()
        {
            var dictBusinessCategories = AccFactory.BusinessCategoriesRepository().GetRecordByID(_businessCategoriesID);

            var isLineOfBusiness = Convert.ToInt16(dictBusinessCategories["is_line_of_business"]);

            _ucBusinessCategories.txtCode.Text = dictBusinessCategories["code"];
            _ucBusinessCategories.txtOrdinanceReferenceNo.Text = dictBusinessCategories["ordinance_ref_no"];
            _ucBusinessCategories.txtDescription.Text = dictBusinessCategories["description"];
            _ucBusinessCategories.cbxLineOfBusiness.Checked = Convert.ToBoolean(isLineOfBusiness);

        }

        private bool UpdateBusinessCategories()
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
                BusinessCategoryID = _businessCategoriesID,
                Code = code,
                OrdinanceReferenceNumber = ordinanceReferenceNo,
                Description = description,
                LineOfBusiness = lineInBusiness
            };

            return AccFactory.BusinessCategoriesRepository().Update(businessCategoriesModel);
            
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                if (UpdateBusinessCategories())
                {
                    Helper.MessageBoxSuccess("Business Categories has been updated.");
                    _frmBusinessCategories.LoadBusinessCategories();
                    Helper.DatagridViewRecordFinder(_frmBusinessCategories.dgBusinessCategories, "id", _businessCategoriesID.ToString());
                    Close();
                }
            }
            catch (Exception ex){Helper.MessageBoxError(ex.Message);}
        }    
    }
}
