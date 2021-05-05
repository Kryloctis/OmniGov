using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AccountingSystem.Views.Dashboard
{
    public partial class UcAccountingDashboard : UserControl
    {
        public UcAccountingDashboard()
        {
            InitializeComponent();
        }

        internal void LoadFunds()
        {
            cmbFund.DataSource = Factory.FundsRepository().GetRecords();
            cmbFund.DisplayMember = "fund_name";
            cmbFund.ValueMember = "id";
        }

        internal void LoadFPP()
        {
            var dtFPP = Factory.FunctionProgramProjectRepository().GetRecords();
            HelperLoadRecords.FPPComboBox(dtFPP, cmbFPP, "fpp_name", "id");
        }

        private void UcAccountingDashboard_Load(object sender, EventArgs e)
        {
            LoadFunds();
            LoadFPP();
            Dock = DockStyle.Fill;
        }
    }
}
