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

namespace AccountingSystem.Views.Manage.RptPenalties
{
    public partial class frmAddRptPenalty : Form
    {
        private ucRptPenalties uc;
        private readonly frmRptPenalties _frmRptPenalties;
        public frmAddRptPenalty(frmRptPenalties frmRptPenalties)
        {
            InitializeComponent();
            uc = ucRptPenalties1;
            _frmRptPenalties = frmRptPenalties;
        }

        private bool Save() 
        {
            try
            {
                if (!uc.ValidateChildren())
                {
                    Helper.MessageBoxError(uc.GetFormErrors());
                    return false;
                }


                var model = new RptPenaltiesModel()
                {
                    Description = uc.txtDescription.Text.Trim(),
                    Rate = uc.nudRate.Value,
                    Frequency = uc.cmbxFrequency.Text.Trim()
                    
                };

                return AccFactory.rptPenaltiesRepository().Insert(model);
            }
            catch (Exception ex)
            {
                Helper.MessageBoxError(ex.Message);
            }

            return false;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (Save())
            {
                Helper.MessageBoxSuccess("Penalty has been saved.");
                uc.ResetForm();
                _frmRptPenalties.LoadPenalties();
            }
        }

        private void frmRptAddPenalty_Load(object sender, EventArgs e)
        {
            uc.isEdit = false;
        }
    }
}
