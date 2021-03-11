using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AccountingSystem.Views.Transactions.JEV
{
    public partial class ucJEVAccount : UserControl
    {
        internal byte fundId;

        public ucJEVAccount()
        {
            InitializeComponent();
        }

        internal void LoadFPP()
        {
            try
            {
                DataTable dtFPP = Factory.FunctionProgramProjectRepository().GetRecords();

                HelperLoadRecords.FPPComboBox(dtFPP, cmbFPP, "fpp_name", "id");
                
            }
            catch (Exception ex)
            {
                Helper.MessageBoxError(ex.Message);
            }
        }

        internal void LoadGeneralLedgers()
        {
            try
            {
                this.cmbAccount.SelectedValueChanged -= cmbAccount_SelectedValueChanged;
                DataTable dtGeneralLedgers = Factory.GeneralLedgerAccountsRepository().GetRecords();

                HelperLoadRecords.GeneralLedgerComboBox(dtGeneralLedgers, cmbAccount, "ledger_name", "id");
                this.cmbAccount.SelectedValueChanged += cmbAccount_SelectedValueChanged;
            }
            catch (Exception ex)
            {
                Helper.MessageBoxError(ex.Message);
            }
        }

        private void LoadSubsidiary()
        {
            try
            {
                ushort generalLedgerId = Convert.ToUInt16(cmbAccount.SelectedValue);
                DataTable dtSubsidiary = Factory.SubsidiaryLedgerAccountsRepository().GetRecordsByFundAndGeneralLedger(fundId, generalLedgerId);

                HelperLoadRecords.SubsidiaryLedgerComboBox(dtSubsidiary, cmbSubsidiary, "sub_name", "id");
            }
            catch (Exception ex)
            {
                Helper.MessageBoxError(ex.Message);
            }
        }

        private void cmbAccount_SelectedValueChanged(object sender, EventArgs e)
        { 
            LoadSubsidiary();
        }
    }
}
