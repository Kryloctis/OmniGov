using ACC.Data;
using ACC.Domain.Models;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace AccountingSystem.Views.Manage.CashTickets
{
    public partial class frmCashTicketEdit : Form
    {
        private readonly frmCashTickets frmCashTickets;
        private readonly int cashTicketId;
        private readonly ucCashTickets uc;

        public frmCashTicketEdit(frmCashTickets frmCashTickets, int cashTicketId)
        {
            InitializeComponent();
            this.frmCashTickets = frmCashTickets;
            this.cashTicketId = cashTicketId;
            uc = ucCashTickets1;
        }

        private void FrmCashTicketEdit_Load(object sender, EventArgs e)
        {
            try
            {
                uc.OnLoad(true, cashTicketId);
                LoadSelectedValue();
            }
            catch (Exception ex) { Helper.MessageBoxError(ex.Message); }
        }

        private void LoadSelectedValue()
        {
            Dictionary<string, string> dictReceipts = AccFactory.CashTicketsRepository().GetRecordByID(cashTicketId);

            var description = dictReceipts["description"].ToString();
            var dateReceived = Convert.ToDateTime(dictReceipts["received_date"]);
            var quantity = Convert.ToInt32(dictReceipts["quantity"]);
            var remarks = dictReceipts["remarks"].ToString();

            uc.dtpReceivedDate.Value = dateReceived;
            uc.nudQuantity.Value = quantity;
            uc.txtRemark.Text = remarks;
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            try
            {
                if (UpdateData())
                {
                    Helper.MessageBoxSuccess("Cash Ticket has been updated.");
                    frmCashTickets.LoadCashTickets();
                    Close();
                }
            }
            catch (Exception ex) { Helper.MessageBoxError(ex.Message); }
        }

        private bool UpdateData()
        {
            if (!uc.ValidateChildren())
            {
                Helper.MessageBoxError(uc.GetFormErrors());
                return false;
            }

            return AccFactory.CashTicketsRepository().Update(uc.CashTicketsModel());
        }

        private void ucCashTickets1_Load(object sender, EventArgs e)
        {

        }
    }
}