using AccountingSystem.Views.Reports.RealPropertyTaxReports.ListOfRealPropertyTaxDelinquencies;
using AccountingSystem.Views.Reports.RealPropertyTaxReports.RealPropertyTaxAccountRegister;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AccountingSystem.Views.Reports.RealPropertyTaxReports.RealPropertyTaxStatementOfAccount
{
    public partial class frmRealPropertyTaxStatementOfAccount : Form
    {
        public frmRealPropertyTaxStatementOfAccount()
        {
            InitializeComponent();
        }

        private void btnFindOwner_Click(object sender, EventArgs e)
        {
            _ = new frmRptTaxPayerList(null, this, null, null).ShowDialog();
        }
    }
}
