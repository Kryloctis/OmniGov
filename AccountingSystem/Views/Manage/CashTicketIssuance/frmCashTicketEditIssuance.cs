using ACC.Data;
using ACC.Domain.Models;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace AccountingSystem.Views.Transactions.CashTicketIssuance
{
    public partial class frmCashTicketEditIssuance : Form
    {
        private frmCashTicketIssuance frmCashTicketIssuance;
        private int cashTicketIssuanceId;
        private ucCashTicketIssuance uc;

        public frmCashTicketEditIssuance(frmCashTicketIssuance frmCashTicketIssuance, int cashTicketIssuanceId)
        {
            InitializeComponent();
            uc = ucCashTicketIssuance1;
            this.frmCashTicketIssuance = frmCashTicketIssuance;
            this.cashTicketIssuanceId = cashTicketIssuanceId;
        }

        private void frmCashTicketEditIssuance_Load(object sender, EventArgs e)
        {
            try
            {
                OnLoad();
            }
            catch (Exception ex) { Helper.MessageBoxError(ex.Message); }
        }

        private void OnLoad()
        {
            uc.LoadCashTickets();
            LoadSelectedValue();
        }

        internal void LoadSelectedValue()
        {
            Dictionary<string, string> cashTicketIssuedDict = AccFactory.CashTicketsIssuedRepository().GetRecordByID(cashTicketIssuanceId);

            string jobOrderID = cashTicketIssuedDict["job_orders_id"];
            var collectingOfficerID = Convert.ToInt32(cashTicketIssuedDict["collecting_officer_id"]);
            int collector = string.IsNullOrEmpty(jobOrderID) ? collectingOfficerID : Convert.ToInt32(jobOrderID);
            int cashTicketId = Convert.ToInt32(cashTicketIssuedDict["cash_tickets_id"]);
            DateTime dateIssued = Convert.ToDateTime(cashTicketIssuedDict["date_issued"]);
            int quantity = Convert.ToInt32(cashTicketIssuedDict["quantity"]);

            if (!string.IsNullOrEmpty(jobOrderID))
                uc.cbCollectingOfficerTypeJO.Checked = true;

            uc.selectedCashTicketID = cashTicketIssuanceId;
            uc.cmbCollector.SelectedValue = collector;
            uc.cmbxCashTickets.SelectedValue = cashTicketId;
            uc.dtpDateIssued.Value = dateIssued;
            uc.nudQuantity.Text = quantity.ToString();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                if (SaveData())
                {
                    Helper.MessageBoxSuccess("Cash Ticket Issued has been updated.");
                    frmCashTicketIssuance.LoadIssuedCashTickets();
                    Close();
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

            var cashTicketsIssuedRepository = AccFactory.CashTicketsIssuedRepository();

            int collectorID = Convert.ToInt32(uc.cmbCollector.SelectedValue);
            int cashTicketId = Convert.ToInt32(uc.cmbxCashTickets.SelectedValue);
            DateTime dateIssued = uc.dtpDateIssued.Value;
            int quantity = Convert.ToInt32(uc.nudQuantity.Text);

            var cashTicketsIssuedModel = new CashTicketsIssuedModel()
            {
                Id = cashTicketIssuanceId,
                CashTicketId = cashTicketId,
                CollectorId = collectorID,
                Quantity = quantity,
                DateIssued = dateIssued,
                IssuedBy = Helper.userId,
            };

            return cashTicketsIssuedRepository.Update(cashTicketsIssuedModel);
        }
    }
}