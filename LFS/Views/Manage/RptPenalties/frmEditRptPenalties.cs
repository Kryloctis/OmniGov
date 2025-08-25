using ACC.Data;
using ACC.Domain.Models;
using LFS.Helpers;
using System;
using System.Windows.Forms;

namespace LFS.Views.Manage.RptPenalties
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
            if (!uc.ValidateChildren())
            {
                Helper.MessageBoxError(uc.GetFormErrors());
                return false;
            }

            var model = new RptPenaltiesModel()
            {
                Id = uc.rptPenaltiesId,
                Description = uc.txtDescription.Text.Trim(),
                Rate = uc.nudRate.Value,
                Frequency = uc.cmbxFrequency.Text.Trim()
            };

            return AccFactory.RptPenaltiesRepository().Update(model);
        }

        private void LoadRecord()
        {
            var dictRptDiscounts = AccFactory.RptPenaltiesRepository().GetRecordByID(uc.rptPenaltiesId);
            decimal rate = Convert.ToDecimal(dictRptDiscounts["rate"]);

            uc.txtDescription.Text = dictRptDiscounts["description"];
            uc.nudRate.Value = (rate * 100);
            uc.cmbxFrequency.Text = dictRptDiscounts["frequency"];
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            try
            {
                if (Save())
                {
                    Helper.MessageBoxSuccess("Penalty has been updated.");
                    _frmRptPenalties.LoadPenalties();
                    Close();
                }
            }
            catch (Exception ex) { Helper.MessageBoxError(ex.Message); }
        }

        private void frmEditRptPenalties_Load(object sender, EventArgs e)
        {
            try
            {
                uc.isEdit = true;
                LoadRecord();
            }
            catch (Exception ex) { Helper.MessageBoxError(ex.Message); }
        }
    }
}