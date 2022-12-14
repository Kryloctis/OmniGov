using System;
using System.Windows.Forms;

namespace AccountingSystem.Views.Manage.Augmentation
{
    public partial class frmAugmentation : Form
    {
        public frmAugmentation()
        {
            InitializeComponent();
            Helper.LoadFormIcon(this);
        }

        private void frmAugmentation_Load(object sender, EventArgs e)
        {
            Helper.DatagridDefaultStyle(dataGridView1, true);
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
        }
    }
}