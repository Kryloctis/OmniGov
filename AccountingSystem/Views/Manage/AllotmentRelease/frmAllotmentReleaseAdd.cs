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
            uc.lblSelectBudgetAppropriation.Click += new EventHandler(lblSelectBudgetAppropriation_Click);
        }

        private bool SaveData() 
        {
            try
            {
                var uc = ucAllotmentRelease1;
                //Validation
                if (!uc.ValidateChildren()) 
                {
                    Helper.MessageBoxError(uc.GetFormErrors());
                    return false;
                }
                return true;

            }
            catch (Exception ex)
            {
                Helper.MessageBoxError(ex.Message);
            }
            return false;
        }

        private void lblSelectBudgetAppropriation_Click(object sender, EventArgs e) 
        {
            _ = new frmSearchBudgetAppropriation(this).ShowDialog();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (SaveData()) 
            {
                var uc = ucAllotmentRelease1;
                uc.ResetForm();
                Helper.MessageBoxSuccess("Allotment Release has been saved.");
            }
        }
    }
}
