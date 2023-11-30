using ACC.Data;
using AccountingSystem.Views.Shared;
using System;
using System.Windows.Forms;

namespace AccountingSystem.Views.Transactions.Payments.OtherPayments.CattleOwnership
{
    public partial class ucCattleDetails : UserControl
    {
        internal int ownerID;
        internal frmCattleOwnership frmCattleOwnership;

        public ucCattleDetails()
        {
            InitializeComponent();
        }

        internal string GetFormErrors()
        {
            var errorArray = new string[]
            {
                errorProvider1.GetError(txtOwnerName),
                errorProvider1.GetError(cmbxType),
            };

            return AccFactory.CreateErrors(errorArray).GenerateErrorMessage();
        }

        private void ucCattleOwnership_Load(object sender, EventArgs e)
        {
            if (!DesignMode)
            {
            }
        }
    }
}