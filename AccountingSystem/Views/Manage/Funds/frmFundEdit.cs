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

namespace AccountingSystem.Views.Manage.Funds
{
    public partial class frmFundEdit : Form
    {
        private frmFunds _frmFunds;
        public frmFundEdit(frmFunds frmFunds, int fundId)
        {
            InitializeComponent();
            _frmFunds = frmFunds;
          ucFunds1.fundId = fundId;
        }

        private void LoadSelectedRecord()
        {
            try
            {
                var uc = ucFunds1;
                var fundsRepository = Factory.FundsRepository();
                var fundData = fundsRepository.GetRecordByID(uc.fundId);

                uc.txtName.Text = fundData["fund_name"];
                             
            }
            catch (Exception ex)
            {

                Helper.MessageBoxError(ex.Message);
            }
        }



        private bool SaveData()
        {
            try
            {
                var uc = ucFunds1;


                // if error occurs, show messagebox error
                if (!uc.ValidateChildren())
                {
                    Helper.MessageBoxError(uc.GetFormErrors());
                    return false;
                }

                // proceed to update
                var fundModel = new FundsModel()
                {
                    Id = uc.fundId,
                    FundName = uc.txtName.Text.Trim()
                };

                var fundsRepository = Factory.FundsRepository();
                return fundsRepository.Update(fundModel);

               
            }
            catch (Exception ex)
            {
                Helper.MessageBoxError(ex.Message);
            }

            return false;
        }

        private void frmFundsEdit_Load(object sender, EventArgs e)
        {
            Helper.LoadFormIcon(this);
            LoadSelectedRecord();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (SaveData())
            {
                Helper.MessageBoxSuccess("Fund has been saved.");
                _frmFunds.LoadRecords();
            }
        }

        private void btnSave_Click_1(object sender, EventArgs e)
        {
            if (SaveData())
            {
                Helper.MessageBoxSuccess("Fund has been saved.");
                _frmFunds.LoadRecords();
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            ucFunds1.ResetForm();
            this.Close();
        }
    }
}
