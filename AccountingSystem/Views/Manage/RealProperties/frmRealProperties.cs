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
            Helper.LoadFormIcon(this);
            InitializeComponent();
            Helper.DatagridFullRowSelectStyle(dataGridView1, true);
        }

        private void frmRealProperties_Load(object sender, EventArgs e)
        {

        }
    }
}
