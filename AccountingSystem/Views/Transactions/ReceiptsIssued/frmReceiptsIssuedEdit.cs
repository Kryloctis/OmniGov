using ACC.Domain.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AccountingSystem.Views.Transactions.ReceiptsIssued
{
    public partial class frmReceiptsIssuedEdit : Form
    {
        private frmReceiptsIssued frmr;

        public frmReceiptsIssuedEdit(frmReceiptsIssued _frmr,int id)
        {
            InitializeComponent();
            frmr = _frmr;
            ucReceipts1.Id = id;
        }

        private void frmReceiptsEdit_Load(object sender, EventArgs e)
        {
            ucReceipts1.LoadCollectors();
            LoadSelectedValue();
        }

        internal void LoadSelectedValue()
        {
            try
            {
                var uc = ucReceipts1;
                var riRepository = Factory.ReceiptsIssuedRepository();
                var riData = riRepository.GetRecordByID(uc.Id);
                uc.cmbCollector.SelectedValue = riData["collecting_officers_id"];
                uc.cmbReceipt.SelectedValue = riData["receipts_id"];
                uc.dtpIssued.Value = Convert.ToDateTime(riData["date_issued"]);
                uc.nudReceiptIssuedFrom.Text = riData["issuefrom"];
                uc.nudReceiptIssuedTo.Text = riData["issueto"];
                uc.txtReceiptQuantity.Text = riData["quantity"];

                uc.nudReceiptIssuedFrom.ReadOnly = true;
                uc.nudReceiptIssuedTo.ReadOnly = true;
            }
            catch (Exception ex) { Helper.MessageBoxError(ex.Message); }
        }

        private bool SaveData()
        {
            try
            {
                var uc = ucReceipts1;
                if (!uc.ValidateChildren())
                {
                    Helper.MessageBoxError(uc.GetFormErrors());
                    return false;
                }
                var riModel = new ReceiptsIssuedModel()
                {
                    Id = uc.Id,
                    CollectorId = Convert.ToInt32(uc.cmbCollector.SelectedValue),
                    ReceiptId = Convert.ToInt32(uc.cmbReceipt.SelectedValue),
                    Issued = uc.dtpIssued.Value,
                    IssuedFrom = Convert.ToInt32(uc.nudReceiptIssuedFrom.Text.Trim()),
                    IssuedTo = Convert.ToInt32(uc.nudReceiptIssuedTo.Text.Trim()),
                    Quantity = Convert.ToInt32(uc.txtReceiptQuantity.Text.Trim())
                };

                var riRepository = Factory.ReceiptsIssuedRepository();
                if (!uc.isTickets)
                {
                    if (Convert.ToInt32(uc.nudReceiptIssuedFrom.Text.Trim()) > Convert.ToInt32(uc.nudReceiptIssuedTo.Text.Trim()))
                    {
                        Helper.MessageBoxError("Invalid Receipt!");
                        return false;
                    }
                    else if (int.Parse(uc.txtReceiptQuantity.Text.Trim()) <= 0)
                    {
                        Helper.MessageBoxError("Quantity Empty!");
                        return false;
                    }
                    else return riRepository.Update(riModel);
                }
                else
                {
                    if (int.Parse(uc.txtReceiptQuantity.Text.Trim()) <= 0)
                    {
                        Helper.MessageBoxError("Quantity Empty!");
                        return false;
                    }
                    else return riRepository.Update(riModel);
                }
                
            }
            catch (Exception ex) { Helper.MessageBoxError(ex.Message); }
            return false; 
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (SaveData())
            {
                Helper.MessageBoxSuccess("Receipt Issued has been updated.");
                frmr.LoadRecords();
            }
        }
    }
}
