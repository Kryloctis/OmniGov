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
    public partial class frmEditBusinessAddOnCharges : Form
    {
        private int _businessAddOnChargesID;
        private readonly frmBusinessAddOnCharges _frmBusinessAdOnCharges;
        private readonly ucBusinessAddOnCharges _ucBusinessAddOnCharges;
       
        public frmEditBusinessAddOnCharges(int businessAddOnChargesID, frmBusinessAddOnCharges frmBusinessAdOnCharges)
        {
            InitializeComponent();
            _ucBusinessAddOnCharges = ucBusinessAddOnCharges1;
            _businessAddOnChargesID = businessAddOnChargesID;
           _frmBusinessAdOnCharges = frmBusinessAdOnCharges;
        }

        private void frmEditBusinessAddOnCharges_Load(object sender, EventArgs e)
        {
            LoadSelectedRecord();
        }
        private void LoadSelectedRecord()
        {
            var dictBusinessAddOnCharges = AccFactory.BusinessAddOnChargesRepository().GetRecordByID(_businessAddOnChargesID);

            var appliedEachBusiness = Convert.ToInt16(dictBusinessAddOnCharges["is_applied_each_business"]);
            _ucBusinessAddOnCharges.txtCode.Text = dictBusinessAddOnCharges["code"];
            _ucBusinessAddOnCharges.txtDescription.Text = dictBusinessAddOnCharges["description"];
            _ucBusinessAddOnCharges.cbxAppliedToEachBusiness.Checked = Convert.ToBoolean(appliedEachBusiness);
        }
    }
}
