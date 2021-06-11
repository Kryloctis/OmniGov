using ACC.Domain.Interfaces;
using ACC.Domain.Models;
using AccountingSystem.Views.Transactions.BankDeposits;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AccountingSystem.Views.Reports.PaymentCollection
{
    public partial class frmGC : Form
    {
        private int Id;
        Dictionary<int, string> _data = new Dictionary<int, string>();
        public frmGC(Dictionary<int, string> data)
        {
            InitializeComponent();
            _data = data;
        }

        private void frmGC_Load(object sender, EventArgs e)
        {

        }

        private string GetFormErrors()
        {
            var errorArray = new string[1];
            errorArray[0] = errorProvider.GetError(txtrcd);

            IError _errors = Factory.CreateErrors(errorArray);
            return _errors.GenerateErrorMessage();
        }

        private void txtrcd_Validating(object sender, CancelEventArgs e)
        {
            e.Cancel = Helper.ShowErrorTextBoxEmpty(errorProvider, txtrcd, "RCD No.");
        }

        private void txtrcd_Validated(object sender, EventArgs e)
        {
            Helper.ClearErrorTextBox(errorProvider, txtrcd);
        }

        private bool SaveData()
        {
            try
            {
                if (!this.ValidateChildren())
                {
                    Helper.MessageBoxError(this.GetFormErrors());
                    return false;
                }
                var gcModel = new GeneralCollectionsModel()
                {
                    Rcdno = txtrcd.Text.Trim(),
                    Rcddate = Convert.ToDateTime(dtdate.Value),
                    Userid = 2
                    //Userid=Helper.UserId
                };
                var gcRepository = Factory.GeneralCollectionsRepository();
                if (!gcRepository.CodeExist(txtrcd.Text.Trim()))
                {
                    if (gcRepository.Insert(gcModel))
                    {
                        var gcData = gcRepository.GetRecordByID(txtrcd.Text.Trim());
                        Id = int.Parse(gcData["id"]);
                        if (_data.Count > 0)
                        { 
                            List<GeneralCollectionPaymentsModel> list = new List<GeneralCollectionPaymentsModel>();
                            list.Clear();
                            foreach (var item in _data)
                            {
                                list.Add(new GeneralCollectionPaymentsModel() { Gcid = Id, Crid = item.Key });
                            }
                            var gcpRepository = Factory.GeneralCollectionsPaymentsRepository();
                            return gcpRepository.Append(list);
                        }
                        else
                        {
                            return true;
                        }

                    }
                }
                else
                {
                    Helper.ErrorMessage("General Collection/RCD already exists!");
                    txtrcd.Focus();
                }
               
            }
            catch (Exception ex)
            {
                Helper.MessageBoxError(ex.Message);
            }
            return false;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (SaveData())
            {
                Helper.MessageBoxSuccess("General Collection/RCD has been saved.");
                var gcRepository = Factory.GeneralCollectionsRepository();
                decimal gcsum = gcRepository.SumRecords(Id);
                if ( gcsum > 0)
                {
                    if (Helper.MessageBoxConfirmGCDeposit())
                    {
                        frmBankDeposits fd = new frmBankDeposits();
                        frmBankDepositsAdd fbd = new frmBankDepositsAdd(fd);
                        fbd.Gcid = Id;
                        fbd.Gcamount = gcsum;
                        if(fbd.ShowDialog() == DialogResult.OK)
                        {
                            this.Close();
                        }
                    }
                }
            }
        }
    }
}
