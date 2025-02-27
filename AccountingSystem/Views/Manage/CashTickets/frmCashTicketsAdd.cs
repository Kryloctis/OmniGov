using ACC.Data;
using ACC.Domain.Models;
using System;
using System.Windows.Forms;

namespace AccountingSystem.Views.Manage.CashTickets
{
    public partial class frmCashTicketsAdd : Form
    {
        private readonly ucCashTickets uc;
        private frmCashTickets _frmCashTickets;

        public frmCashTicketsAdd(frmCashTickets frmCashTickets)
        {
            InitializeComponent();
            uc = ucCashTickets1;
            _frmCashTickets = frmCashTickets;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            SaveCashTickets();
        }

        private void SaveCashTickets()
        {
            try
            {
                if (SaveData())
                {
                    Helper.MessageBoxSuccess("Cash Ticket has been added.");
                    _frmCashTickets.LoadCashTickets();
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


            var cashTicketsModel = new CashTicketsModel()
            {
                AccountableFormId = Convert.ToInt32(uc.cmbAccountableForms.SelectedValue),
                Quantity = Convert.ToInt32(uc.nudQuantity.Value),
                ReceivedDate = Convert.ToDateTime(uc.dtpReceivedDate.Value),
                Remarks = uc.txtRemark.Text,
            };

            return AccFactory.CashTicketsRepository().Insert(cashTicketsModel);
        }
    }
}
