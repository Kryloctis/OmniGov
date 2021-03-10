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
                DataTable dtGeneralLedgers = Factory.GeneralLedgerAccountsRepository().GetRecords();

                HelperLoadRecords.GeneralLedgerComboBox(dtGeneralLedgers, cmbAccount, "ledger_name", "id");
            }
            catch (Exception ex)
            {
                Helper.MessageBoxError(ex.Message);
            }
        }
    }
}
