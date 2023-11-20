using ACC.Data;
using ACC.Domain.Models;
using System;
using System.Windows.Forms;

namespace AccountingSystem.Views.Manage.Amortization
{
    public partial class ucAmortizationSchedule : UserControl
    {
        internal int amortizationId;
        internal string amortizationTerm;
        internal int amortizationScheduleId;
        internal bool isEdit;

        public ucAmortizationSchedule()
        {
            InitializeComponent();
        }

        internal void SetAmortizationTerm()
        {
            string dateFormat;

            switch (amortizationTerm)
            {
                case "Annually":
                    dateFormat = "yyyy";
                    break;

                case "Monthly":
                    dateFormat = "MMMMM, yyyy";
                    break;

                case "Daily":
                    dateFormat = "dddd,dd, MMMMM, yyyy";
                    break;

                default:
                    dateFormat = "dddd,dd, MMMMM, yyyy";
                    break;
            }

            dtDate.Format = DateTimePickerFormat.Custom;
            dtDate.CustomFormat = dateFormat;
            dtDate.ShowUpDown = true;
        }

        internal void ResetForm()
        {
            nudPrincipal.Value = 0;
            nudInterest.Value = 0;
            nudGRT.Value = 0;
        }

        internal bool SaveData()
        {
            try
            {
                DateTime date = dtDate.Value;
                decimal principalAmount = nudPrincipal.Value;
                decimal interestAmount = nudInterest.Value;
                decimal grtAmount = nudGRT.Value;

                var amortizationScheduleModel = new AmortizationScheduleModel()
                {
                    AmortizationId = amortizationId,
                    Date = date,
                    PrincipalAmount = principalAmount,
                    InterestAmount = interestAmount,
                    GRTAmount = grtAmount
                };

                if (isEdit)
                {
                    amortizationScheduleModel.Id = amortizationScheduleId;
                    return AccFactory.AmortizationScheduleRepository().Update(amortizationScheduleModel);
                }
                else
                    return AccFactory.AmortizationScheduleRepository().Insert(amortizationScheduleModel);
            }
            catch (Exception ex)
            {
                Helper.MessageBoxError(ex.Message);
            }
            return false;
        }

        private void ucAmortizationSchedule_Load(object sender, EventArgs e)
        {
            if (!DesignMode)
            {
            }
        }
    }
}