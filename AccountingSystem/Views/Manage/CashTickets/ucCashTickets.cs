using ACC.Data;
using ACC.Domain.Models;
using System;
using System.Data;
using System.Windows.Forms;

namespace AccountingSystem.Views.Manage.CashTickets
{
    public partial class ucCashTickets : UserControl
    {
        private int? cashTicketId;
        private bool isEdit;

        public ucCashTickets()
        {
            InitializeComponent();
        }

        internal string GetFormErrors()
        {
            var errorArray = new string[]
            {
                errorProvider1.GetError(txtDescription),
                errorProvider1.GetError(nudQuantity),
                errorProvider1.GetError(dtpReceivedDate)
            };

            return AccFactory.CreateErrors(errorArray).GenerateErrorMessage();
        }

        internal void ResetForm()
        {
            txtDescription.Clear();
            dtpReceivedDate.Value = DateTime.Today;
            nudQuantity.Value = 0;
            txtRemark.Clear();
        }

        internal CashTicketsModel CashTicketsModel()
        {
            return new CashTicketsModel
            {
                Id = cashTicketId.Value,
                Description = txtDescription.Text.Trim(),
                Quantity = (int)nudQuantity.Value,
                ReceivedDate = dtpReceivedDate.Value,
                Remarks = txtRemark.Text.Trim()
            };
        }

        internal void OnLoad(bool isEdit, int? cashTicketId)
        {
            this.isEdit = isEdit;
            this.cashTicketId = cashTicketId;
        }
    }
}