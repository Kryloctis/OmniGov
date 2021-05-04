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
    public partial class frmSupplementalAppropriationsEdit : Form
    {
        private ucSupplementalAppropriations uc;

        public frmSupplementalAppropriationsEdit()
        {
            InitializeComponent();
            Helper.LoadFormIcon(this);
            uc = ucSupplementalAppropriations1;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            
        }
    }
}
