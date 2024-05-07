using AccountingSystem.Views.Reports.RCD;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AccountingSystem.Views.Dashboard.Treasury
{
    public partial class ucTreasury : UserControl
    {
        public ucTreasury()
        {
            InitializeComponent();
        }

        private void rcdTstrpMnuItm_Click(object sender, EventArgs e)
        {
            try
            {
                _ = new frmRcd().ShowDialog();
            }
            catch (Exception ex) { Helper.MessageBoxError(ex.Message); }
        }
    }
}