using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ACC.Domain.Models;

namespace AccountingSystem.Views.Manage.BeginningBalances
{
    public partial class frmBeginningBalanceAdd : Form
    {
        private UcBeginningBalances uc;
        public frmBeginningBalanceAdd()
        {
            InitializeComponent();
            uc = ucBeginningBalances1;
        }

        private bool SaveData()
        {
            if (!uc.ValidateChildren())
            {
                Helper.MessageBoxError(uc.GetFormErrors());
                return false;
            }

            var beginningBalanceModel = new BeginningBalancesModel()
            {
                FundsId = uc.fundId,
                GeneralLedgerId = (ushort) uc.lstBoxGeneralAccount.SelectedValue,
                SubsidiaryLedgerId = (ushort?) uc.cmbSubsidiaryAccount.SelectedValue,
                Year = (short) uc.nudYear.Value,
                Amount = uc.nudAmount.Value
            };

            return Factory.BeginningBalancesRepository().Insert(beginningBalanceModel);
        }

        private void frmBeginningBalanceAdd_Load(object sender, EventArgs e)
        {
            Helper.LoadFormIcon(this);
            uc.LoadFunds();
            uc.nudYear.Value = DateTime.Now.Year;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (SaveData())
            {
                Helper.MessageBoxSuccess("Beginning balance has been saved.");
                uc.ResetForm();
            }
        }
    }
}
