using System;
using System.Data;
using System.Windows.Forms;

namespace AccountingSystem.Views.Transactions.CheckIssuance.Obligations
{
    public partial class frmObligations : Form
    {
        public frmObligations()
        {
            InitializeComponent();
            Helper.DatagridFullRowSelectStyle(dgObligation);
        }

        private void frmObligations_Load(object sender, EventArgs e)
        {

        }

        private void btnAdd_Click(object sender, EventArgs e)
        {

        }
    }
}
