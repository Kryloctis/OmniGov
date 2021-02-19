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
    public partial class frmFundAdd : Form
    {
        private frmFunds _frmFunds;

        public frmFundAdd(frmFunds frmFunds)
        {
            InitializeComponent();
            _frmFunds = frmFunds;
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

                // proceed to insert
                var fundModel = new FundsModel()
                {
                    FundName = uc.txtName.Text.Trim()
                    
                };

                var fundsRepository = Factory.FundsRepository();
                return fundsRepository.Insert(fundModel);
            }
            catch (Exception ex)
            {
                Helper.MessageBoxError(ex.Message);
            }

            return false;
        }


        private void frmFundAdd_Load(object sender, EventArgs e)
        {
            Helper.LoadFormIcon(this);
        }

        private void btnSave_Click_1(object sender, EventArgs e)
        {
            if (SaveData())
            {
                Helper.MessageBoxSuccess("Fund has been saved.");
                _frmFunds.LoadRecords();
                ucFunds1.ResetForm();
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            ucFunds1.ResetForm();
        }
    }
}
