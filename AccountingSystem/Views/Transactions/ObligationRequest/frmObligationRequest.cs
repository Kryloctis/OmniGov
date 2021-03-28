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
    public partial class frmObligationRequest : Form
    {
        public frmObligationRequest()
        {
            InitializeComponent();
            btnSave.Click += new EventHandler(btnSave_Click);   
        }

        private void btnSave_Click(object sender, EventArgs e) 
        {

        }

        private void frmObligationRequest_Load(object sender, EventArgs e)
        {
        }
    }
}
