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

namespace AccountingSystem.Views.Manage.AllotmentRelease
{
    public partial class frmAllotmentReleaseAdd : Form
    {
        private frmAllotmentRelease _frmAllotmentRelease;
        public frmAllotmentReleaseAdd(frmAllotmentRelease frmAllotmentRelease)
        {
            InitializeComponent();
            _frmAllotmentRelease = frmAllotmentRelease;
            var uc = ucAllotmentRelease1;
        }

        private bool SaveData() 
        {
            try
            {
                var uc = ucAllotmentRelease1;

                //Validation
                if (!uc.ValidateChildren() ) 
                {
                    Helper.MessageBoxError(uc.GetFormErrors());
                    return false;
                }


                // proceed to insert
                var allotmentReleaseModel = new AllotmentReleaseModel()
                {
                    BudgetAppropriationsID = uc.budgetAppropriationID,
                    ARONumber = uc.mskTxtAroNo.Text.Trim(),
                    Purpose = uc.txtPurpose.Text.Trim(),
                    DateIssued = uc.dtDateIssued.Value,
                    amount = uc.nudAmount.Value,
                };

                return Factory.AllotmentReleaseRepository().Insert(allotmentReleaseModel);

            }
            catch (Exception ex)
            {
                Helper.MessageBoxError(ex.Message);
            }
            return false;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (SaveData()) 
            {
                var uc = ucAllotmentRelease1;
                uc.ResetForm();
                Helper.MessageBoxSuccess("Allotment Release has been saved.");
                _frmAllotmentRelease.LoadAppropriationDetails();
                _frmAllotmentRelease.LoadAllotmentReleaseRecords();
            }
        }
    }
}
