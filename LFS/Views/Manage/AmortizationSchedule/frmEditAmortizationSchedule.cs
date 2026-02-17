using Accounting.Data;
using LFS.Helpers;
using LFS.Views.Manage.Amortization;
using System;
using System.Windows.Forms;

namespace LFS.Views.Manage.AmortizationSchedule
{
    public partial class frmEditAmortizationSchedule : Form
    {
        private ucAmortizationSchedule uc;
        internal int amortizationId;
        internal string amortizationTerm;
        private frmAmortizationSchedule _frmAmortizationSchedule;
        internal int amortizationScheduleId;

        public frmEditAmortizationSchedule(frmAmortizationSchedule frmAmortizationSchedule)
        {
            InitializeComponent();
            _frmAmortizationSchedule = frmAmortizationSchedule;
            uc = ucAmortizationSchedule1;
            uc.isEdit = true;
        }

        private void LoadSelectedAmortizationSchedule()
        {
            var dicAmortizationScheduleRecord = AccountingFactory.AmortizationScheduleRepository().GetRecordByID(amortizationScheduleId);

            uc.dtDate.Value = Convert.ToDateTime(dicAmortizationScheduleRecord["date"]);
            uc.nudPrincipal.Value = Convert.ToDecimal(dicAmortizationScheduleRecord["principal_amount"]);
            uc.nudInterest.Value = Convert.ToDecimal(dicAmortizationScheduleRecord["interest_amount"]);
            uc.nudGRT.Value = Convert.ToDecimal(dicAmortizationScheduleRecord["grt_amount"]);
        }

        private void frmEditAmortizationSchedule_Load(object sender, EventArgs e)
        {
            uc.amortizationScheduleId = amortizationScheduleId;
            uc.amortizationId = amortizationId;
            uc.amortizationTerm = amortizationTerm;
            uc.SetAmortizationTerm();
            LoadSelectedAmortizationSchedule();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (uc.SaveData())
            {
                Helper.MessageBoxSuccess("Amortization Schedule has been updated");
                _frmAmortizationSchedule.LoadRecords();
                Close();
            }
        }
    }
}
