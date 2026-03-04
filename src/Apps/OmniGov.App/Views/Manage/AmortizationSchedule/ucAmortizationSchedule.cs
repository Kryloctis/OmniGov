using OmniGov.Accounting.Data.Factories;
using OmniGov.Accounting.Domain.Entities;
using OmniGov.App.Helpers;

namespace OmniGov.App.Views.Manage.AmortizationSchedule
{
    public partial class ucAmortizationSchedule : UserControl
    {
        internal int amortizationId;
        internal int amortizationScheduleId;
        internal string amortizationTerm;
        internal bool isEdit;

        public ucAmortizationSchedule()
        {
            InitializeComponent();
        }

        internal void ResetForm()
        {
            nudPrincipal.Value = 0;
            nudInterest.Value = 0;
            nudGRT.Value = 0;
        }

        internal bool SaveData()
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
                return AccountingFactory.AmortizationScheduleRepository().Update(amortizationScheduleModel);
            }
            else
                return AccountingFactory.AmortizationScheduleRepository().Insert(amortizationScheduleModel);
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

        private void ucAmortizationSchedule_Load(object sender, EventArgs e)
        {
            if (!DesignMode)
            {
            }
        }
    }
}