using System;
using System.Windows.Forms;

namespace AccountingSystem.Views.Manage.RealProperties
{
    public partial class frmRealProperties : Form
    {
        public frmRealProperties()
        {
            Helper.LoadFormIcon(this);
            InitializeComponent();
            Helper.DatagridFullRowSelectStyle(dataGridView1, true);
        }

        private void frmRealProperties_Load(object sender, EventArgs e)
        {

        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            _ = new frmAddRealProperties().ShowDialog();
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            _ = new frmEditRealProperties().ShowDialog();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {

        }

        private void btnSynchronize_Click(object sender, EventArgs e)
        {

        }
    }
}
