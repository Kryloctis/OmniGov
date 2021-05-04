using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AccountingSystem.Views.Manage.SupplementalAppropriations
{
    public partial class frmSupplementalAppropriations : Form
    {
        public frmSupplementalAppropriations()
        {
            InitializeComponent();
            Helper.LoadFormIcon(this);
            btnAdd.Click += new EventHandler(BtnAdd_Click);
        }

        private void BtnAdd_Click(object sender, EventArgs e)
        {
            _ = new frmSupplementalAppropriationAdd().ShowDialog();
        }

        private void frmSupplementalAppropriationsMain_Load(object sender, EventArgs e)
        {

        }
    }
}
