using ACC.Data;
using ACC.Domain.Models;
using System;
using System.Windows.Forms;

namespace AccountingSystem.Views.Transactions.CashTicketIssuance
{
    public partial class frmCashTicketAddIssuance : Form
    {
        private readonly ucCashTicketIssuance uc;
        private frmCashTicketIssuance frmCashTicketIssuance;

        public frmCashTicketAddIssuance(frmCashTicketIssuance frmCashTicketIssuance)
        {
            InitializeComponent();
            uc = ucCashTicketIssuance1;
            this.frmCashTicketIssuance = frmCashTicketIssuance;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                if (SaveData())
                {
                    Helper.MessageBoxSuccess("Cash tickets has been issued.");
                    frmCashTicketIssuance.LoadIssuedCashTickets();
                    uc.ResetForm();
                }
            }
            catch (Exception ex) { Helper.MessageBoxError(ex.Message); }
        }

        private bool SaveData()
        {
            if (!uc.ValidateChildren())
            {
                Helper.MessageBoxError(uc.GetFormErrors());
                return false;
            }

            int collectorId = Convert.ToInt32(uc.cmbCollector.SelectedValue);
            int cashTicketId = Convert.ToInt32(uc.cmbxCashTickets.SelectedValue);
            DateTime dateIssued = uc.dtpDateIssued.Value;
            int quantity = Convert.ToInt32(uc.nudQuantity.Value);

            var cashTicketsIssuedModel = new CashTicketsIssuedModel()
            {
                CashTicketId = cashTicketId,
                CollectorId = collectorId,
                Quantity = quantity,
                DateIssued = dateIssued,
                IssuedBy = Helper.userId,
            };

            if (uc.isCollectorJO)
            {
                cashTicketsIssuedModel.JobOrderId = collectorId;
                cashTicketsIssuedModel.CollectorId = AccFactory.CollectingOfficerHasJobOrdersRepository().GetCollectingOfficerIDByJobOrderId(collectorId);
            }

            return AccFactory.CashTicketsIssuedRepository().Insert(cashTicketsIssuedModel);
        }
    }
}