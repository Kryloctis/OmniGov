using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AccountingSystem.Views.Transactions.ObligationRequest
{

    public partial class ucObligationRequest : UserControl
    {
        public ucObligationRequest()
        {
            InitializeComponent();
        }

        private void lnklblAllotmentRelease_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            _ = new frmSelectAllotmentRelease().ShowDialog();
        }
    }
}
