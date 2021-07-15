using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
    }
}
