using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AccountingSystem.Views.Manage.RealProperties
{
    public partial class frmRealProperties : Form
    {
        public frmRealProperties()
        {
            InitializeComponent();
            Helper.LoadFormIcon(this);
            Helper.DatagridFullRowSelectStyle(dgRealProperties, true);
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            _ = new frmAddRealProperties().ShowDialog();
        }
    }
}
