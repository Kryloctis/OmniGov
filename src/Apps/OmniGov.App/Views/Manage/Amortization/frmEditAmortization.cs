using OmniGov.Accounting.Data.Factories;
using OmniGov.App.Helpers;

namespace OmniGov.App.Views.Manage.Amortization
{
    public partial class frmEditAmortization : Form
    {
        private ucAmortization uc;
        private frmAmortization _frmAmortization;
        internal int amortizationId;

        public frmEditAmortization(frmAmortization frmAmortization)
        {
            InitializeComponent();
            uc = ucAmortization1;
            uc.isEdit = true;
            _frmAmortization = frmAmortization;
        }

        internal void LoadSelectedAmortization()
        {
            try
            {
                var dicAmortizationRecord = AccountingFactory.AmortizationRepository().GetRecordByID(amortizationId);

                string bankName = dicAmortizationRecord["bank_name"];
                string amortizationTerm = dicAmortizationRecord["amortization_term"];
                decimal interest = Convert.ToDecimal(dicAmortizationRecord["interest"]);
                decimal amountReleased = Convert.ToDecimal(dicAmortizationRecord["amount_released"]);

                uc.amortizationId = amortizationId;
                uc.txtBankName.Text = bankName;
                uc.cmbxTerm.Text = amortizationTerm;
                uc.nudInterest.Value = interest;
                uc.nudAmountRelease.Value = amountReleased;
            }
            catch (Exception ex)
            {
                Helper.MessageBoxError(ex.Message);
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (uc.SaveData())
            {
                Helper.MessageBoxSuccess("Amortization has been updated.");
                uc.ResetForm();
                _frmAmortization.LoadAmortizationRecords();
            }
        }

        private void frmEditAmortization_Load(object sender, EventArgs e)
        {
            LoadSelectedAmortization();
        }
    }
}