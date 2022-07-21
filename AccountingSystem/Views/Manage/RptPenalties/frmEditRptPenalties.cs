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
    public partial class frmEditRptPenalties : Form
    {
        private readonly frmRptPenalties _frmRptPenalties;
        private ucRptPenalties uc;
        public frmEditRptPenalties(int rptPenaltiesId, frmRptPenalties frmRptPenalties)
        {
            InitializeComponent();
            _frmRptPenalties = frmRptPenalties;
            uc = ucRptPenalties1;
            uc.rptPenaltiesId = rptPenaltiesId;
            Helper.LoadFormIcon(this);
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
                    Id = uc.rptPenaltiesId,
                    Code = uc.txtCode.Text.Trim(),
                    Description = uc.txtDescription.Text.Trim(),
                    Rate = uc.nudRate.Value
                };

                return Factory.rptPenaltiesRepository().Update(model);
            }
            catch (Exception ex)
            {
                Helper.MessageBoxError(ex.Message);
            }
            return false;
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (Save())
            {
                Helper.MessageBoxSuccess("Penalty has been updated.");
                _frmRptPenalties.LoadPenalties();
                Close();
            }
        }
    }
}
