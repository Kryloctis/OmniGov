using LFS.Views.Manage.BudgetAppropriations;
using System;
using System.Windows.Forms;

namespace LFS.Views.Manage.Realignment
{
    public partial class frmRealignment : Form
    {
        internal frmBudgetAppropriations _frmBudgetAppropriation;

        public frmRealignment()
        {
            InitializeComponent();
            Helper.LoadFormIcon(this);
        }

        private void frmRealignment_Load(object sender, EventArgs e)
        {
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            _ = new frmRealignmentAdd(this, _frmBudgetAppropriation).ShowDialog();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
        }
    }
}