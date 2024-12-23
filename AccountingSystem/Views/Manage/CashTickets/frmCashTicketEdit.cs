using ACC.Data;
using ACC.Domain.Models;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace AccountingSystem.Views.Manage.CashTickets
{
    public partial class frmCashTicketEdit : Form
    {
        private readonly frmCashTickets _frmCashTickets;
        private readonly int _cashTicketId;
        private readonly ucCashTickets uc;
        private readonly int userId = Helper.userId;

        public frmCashTicketEdit(frmCashTickets frmCashTickets, int cashTicketId)
        {

            InitializeComponent();
            _frmCashTickets = frmCashTickets;
            _cashTicketId = cashTicketId;

            uc = ucCashTickets1;
            uc.cashTicketId = _cashTicketId;
        }

        private void frmCashTicketEdit_Load(object sender, System.EventArgs e)
        {
            try
            {
                OnLoad();
            }
            catch (Exception ex) { Helper.MessageBoxError(ex.Message); }
        }

        private void OnLoad()
        {
            uc.OnLoad();
            LoadSelectedValue();
            //SetUpdateRestrictions();
        }

        private void LoadSelectedValue()
        {
            Dictionary<string, string> dictReceipts = AccFactory.CashTicketsRepository().GetRecordByID(_cashTicketId);

            int cashTicketId = Convert.ToInt32(dictReceipts["id"]);
            int accountableFormID = Convert.ToInt32(dictReceipts["accountable_forms_id"]);
            int quantity = Convert.ToInt32(dictReceipts["quantity"]);
            DateTime dateReceived = Convert.ToDateTime(dictReceipts["received_date"]);
            string remarks = dictReceipts["remarks"].ToString();

            uc.cmbAccountableForms.SelectedValue = accountableFormID;
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
                    Helper.MessageBoxSuccess("Receipt has been updated.");
                    _frmCashTickets.LoadCashTickets();
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


            var cashTicketsModel = new CashTicketsModel()
            {
                Id = _cashTicketId,
                AccountableFormId = Convert.ToInt32(uc.cmbAccountableForms.SelectedValue),
                Quantity = Convert.ToInt32(uc.nudQuantity.Value),
                ReceivedDate = Convert.ToDateTime(uc.dtpReceivedDate.Value),
                Remarks = uc.txtRemark.Text,
            };

            return AccFactory.CashTicketsRepository().Update(cashTicketsModel);
        }
    }
}
