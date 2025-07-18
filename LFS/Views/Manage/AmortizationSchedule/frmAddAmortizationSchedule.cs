using LFS.Views.Manage.Amortization;
using System;
using System.Windows.Forms;

namespace LFS.Views.Manage.AmortizationSchedule
{
    public partial class frmAddAmortizationSchedule : Form
    {
        private ucAmortizationSchedule uc;
        internal int amortizationId;
        internal string amortizationTerm;
        private frmAmortizationSchedule _frmAmortizationSchedule;

        public frmAddAmortizationSchedule(frmAmortizationSchedule frmAmortizationSchedule)
        {
            InitializeComponent();
            uc = ucAmortizationSchedule1;
            uc.isEdit = false;
            _frmAmortizationSchedule = frmAmortizationSchedule;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (uc.SaveData())
            {
                Helper.MessageBoxSuccess("Amortization Schedule has been saved.");
                _frmAmortizationSchedule.LoadRecords();
                uc.ResetForm();
            }
        }

        private void frmAddAmortizationSchedule_Load(object sender, EventArgs e)
        {
            uc.amortizationId = amortizationId;
            uc.amortizationTerm = amortizationTerm;
            uc.SetAmortizationTerm();
        }
    }
}