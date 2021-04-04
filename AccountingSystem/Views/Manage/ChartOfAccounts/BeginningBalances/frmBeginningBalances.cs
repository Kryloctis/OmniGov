using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AccountingSystem.Views.Manage.BeginningBalances
{
    public partial class frmBeginningBalances : Form
    {
        public frmBeginningBalances()
        {
            InitializeComponent();
        }

        private void frmBeginningBalances_Load(object sender, EventArgs e)
        {
            Helper.LoadFormIcon(this);
        }
    }
}
