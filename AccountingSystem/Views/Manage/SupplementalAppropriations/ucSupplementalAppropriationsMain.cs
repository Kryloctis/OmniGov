using System;
using System.Windows.Forms;

namespace AccountingSystem.Views.Manage.SupplementalAppropriations
{
    public partial class ucSupplementalAppropriationsMain : UserControl
    {
        internal int supplementalAppropriationId;
        internal int budgetAppropriationId;
        internal DateTime dateEntry;

        public ucSupplementalAppropriationsMain()
        {
            InitializeComponent();
        }

        private void ucSupplementalAppropriations_Load(object sender, EventArgs e)
        {

        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            _ = new frmSupplementalAppropriationsAdd().ShowDialog();
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            _ = new frmSupplementalAppropriationsEdit().ShowDialog();
        }
    }
}
