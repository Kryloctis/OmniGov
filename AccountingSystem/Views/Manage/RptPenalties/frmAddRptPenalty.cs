using ACC.Domain.Models;
using System;
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

            return AccFactory.RptPenaltiesRepository().Insert(model);
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                if (Save())
                {
                    Helper.MessageBoxSuccess("Penalty has been saved.");
                    uc.ResetForm();
                    _frmRptPenalties.LoadPenalties();
                }
            }
            catch (Exception ex)
            { Helper.MessageBoxError(ex.Message); }
        }

        private void frmRptAddPenalty_Load(object sender, EventArgs e)
        {
            uc.isEdit = false;
        }
    }
}