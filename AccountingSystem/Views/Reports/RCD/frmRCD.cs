using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AccountingSystem.Views.Reports.RCD
{
    public partial class frmRCD : Form
    {
        public frmRCD()
        {
            InitializeComponent();
            Helper.LoadFormIcon(this);
        }

        private void btnadd_Click(object sender, EventArgs e)
        {
            _ = new frmRCDAdd().ShowDialog();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            _ = new frmSearch().ShowDialog();
        }

        private void frmRCD_Load(object sender, EventArgs e)
        {

        }
    }
}
