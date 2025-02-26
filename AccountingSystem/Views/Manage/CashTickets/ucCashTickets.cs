using ACC.Data;
using ACC.Domain.Models;
using System;
using System.Collections.Generic;
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

        internal void LoadSelectedValue()
        {
            Dictionary<string, string> dictReceipts = AccFactory.CashTicketsRepository().GetRecordByID(cashTicketId.Value);

            var description = dictReceipts["description"].ToString();
            var dateReceived = Convert.ToDateTime(dictReceipts["received_date"]);
            var quantity = Convert.ToInt32(dictReceipts["quantity"]);
            var remarks = dictReceipts["remarks"].ToString();

            txtDescription.Text = description;
            dtpReceivedDate.Value = dateReceived;
            nudQuantity.Value = quantity;
            txtRemark.Text = remarks;
        }

        internal CashTicketsModel CashTicketsModel()
        {
            var model = new CashTicketsModel
            {
                Description = txtDescription.Text.Trim(),
                Quantity = (int)nudQuantity.Value,
                ReceivedDate = dtpReceivedDate.Value,
                Remarks = txtRemark.Text.Trim()
            };

            if (isEdit) model.Id = cashTicketId.Value;

            return model;
        }

        internal void OnLoad(bool isEdit, int? cashTicketId)
        {
            this.isEdit = isEdit;
            this.cashTicketId = cashTicketId;

            if (isEdit) LoadSelectedValue();
        }
    }
}